using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Web;
using System.Collections;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Data;
using Newtonsoft.Json;

namespace ECard78
{
    public class SeaHttpServer
    {
        HttpListener httpListener = new HttpListener();
        Label label;
        ECard78.FingerReadData.ProcessSeaRealData prog;
        bool stop = false;
        KQTextFormatInfo textFormat;
        Database db = null;
        public void Setup(Database db, int port, Label label, KQTextFormatInfo textFormat, ECard78.FingerReadData.ProcessSeaRealData prog)
        {
            try
            {
                this.db = db;
                this.label = label;
                this.prog = prog;
                this.textFormat = textFormat;
                if (port == 0)
                {
                    stop = true;
                    httpListener.Close();
                    return;
                }
                stop = false;
                httpListener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
                httpListener.Prefixes.Add(string.Format("http://*:{0}/", port));
                httpListener.Start();
                Receive();
               
            }
            catch
            {

            }
           
        }

        private void Receive()
        {
            if(!stop)
                httpListener.BeginGetContext(new AsyncCallback(EndReciver), null);
        }

        void EndReciver(IAsyncResult ar)
        {
            if(!stop)
            {
                var context = httpListener.EndGetContext(ar);
                Dispather(context);
                Receive();
            } 
        }

        RequestHelper RequestHelper;
        ResponseHelper ResponseHelper;
        void Dispather(HttpListenerContext context)
        {
            HttpListenerRequest request= context.Request;
            HttpListenerResponse response = context.Response;
            RequestHelper = new RequestHelper(db,request, label,prog, textFormat);
            ResponseHelper = new ResponseHelper(response);
            RequestHelper.DispatchResources(state => { ResponseHelper.WriteToClient(state); });
           
        }

    }

    public class RequestHelper
    {  
        private HttpListenerRequest request;
        private Label label;
        ECard78.FingerReadData.ProcessSeaRealData prog;
        private FingerReadData readData = new FingerReadData("");
        private TSeaLog attLog = new TSeaLog();
        KQTextFormatInfo textFormat;
        string MacSN = "";
        Database db = null;
        public delegate void OutDelegate(string text);
        public delegate void OutDelegateE(string text);

        public RequestHelper(Database db,HttpListenerRequest request, Label label, ECard78.FingerReadData.ProcessSeaRealData prog, KQTextFormatInfo textFormat)
        {
            this.db = db;
            this.request = request;
            this.label = label;
            this.prog = prog;
            this.textFormat = textFormat;
        }
        
         public delegate void ExecutingDispatch(int state);
         public void DispatchResources(ExecutingDispatch action)
         {
             var rawUrl = request.RawUrl;
             try
             {
                 string deviceId = request.Headers.Get("dev_id");
                 StreamReader sr = new StreamReader(request.InputStream);
                 string requestBody = sr.ReadToEnd();
              
                if (requestBody.Contains("VerifyPush"))
                {
                    OutText(requestBody);
                }
                else if (requestBody.Contains("CardVerify"))
                {
                    //MyDelegate myDelegateLambda = (string str) => {
                    //    SaveCardLog(requestBody);
                    //};
                }
                else if (requestBody.Contains("SnapPush"))
                {
                    OutTextE(requestBody);
                }
                else if (requestBody.Contains("RemoteOpenDoorPush"))
                {
                    OutText(requestBody);
                }
            }
             catch
             {
                return;
             }

            action.Invoke(404);
        }
        public void OutText(string text)
        {

            if (label.InvokeRequired)

            {

                OutDelegate outdelegate = new OutDelegate(OutText);

                label.BeginInvoke(outdelegate, new object[] { text });

                return;

            }
            SaveFaceLog(text);
        }

        public void OutTextE(string text)
        {

            if (label.InvokeRequired)

            {

                OutDelegateE outdelegate = new OutDelegateE(OutTextE);

                label.BeginInvoke(outdelegate, new object[] { text });

                return;

            }
            SaveSnapLog(text);
        }

        public void SaveSnapLog(string LogStr)
        {
            VerifyPush<SnapPush> verifyPush = JsonConvert.DeserializeObject<VerifyPush<SnapPush>>(LogStr);
            byte[] PhotoImage = null;
            string GUID = "";
            MacSN = verifyPush.info.DeviceID.ToString();
            PhotoImage = Convert.FromBase64String(verifyPush.SanpPic.Replace("data:image/jpeg;base64,", ""));
            DateTime time = Convert.ToDateTime(verifyPush.info.CreateTime);
            db.SaveSnapLog(MacSN, verifyPush.info.PictureType, time.ToString(SystemInfo.SQLDateTimeFMT), verifyPush.info.Temperature.ToString(), verifyPush.info.TemperatureAlarm.ToString(), PhotoImage,ref GUID);
            attLog.CardID = "0";
            attLog.CardTime = time;
            if (prog != null) prog(attLog, Int32.Parse(MacSN),GUID);
        }


        public void SaveCardLog(string LogStr)
        {
            jsonBody<CardVerify> verifyPush = JsonConvert.DeserializeObject<jsonBody<CardVerify>>(LogStr);
            byte[] PhotoImage = null;
            int InOutMode = 0;
            string GUID = "";
            MacSN = verifyPush.info.DeviceID.ToString();
            attLog.Remark = verifyPush.info.CardNo;
            UInt32 FingerNo = 0;
            attLog = new TSeaLog();
            attLog.CardID = FingerNo.ToString("0000000000");
            attLog.CardTime = DateTime.Parse(verifyPush.info.CreateTime);
            attLog.FingerNo = FingerNo;
             if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
            DataTableReader dr = db.GetDataReader("SELECT * FROM VSEA_MacInfoFace WHERE MacSN='" + MacSN + "'");
            if (dr.Read())
            {
                int.TryParse(dr["MacInOut"].ToString(), out InOutMode);
            }
            dr.Close();
            attLog.InOutMode = InOutMode;

            readData.Sea_SetLogName(attLog, InOutMode, 1, 21);

            readData.WriteTextFile(attLog, Int32.Parse(MacSN),true);
            if (textFormat.Allow) readData.WriteTextFormat(db, textFormat, attLog, Int32.Parse(MacSN), true);
            readData.SeaSaveDB(db, attLog, Int32.Parse(MacSN), FingerNo, PhotoImage);

            if (attLog.VerifyMode == 0)
            {
                attLog.VerifyMode = attLog.DoorMode;
                attLog.VerifyModeName = attLog.DoorModeName;
            }

            readData.SeaSaveDBMJ(db, attLog, MacSN.ToString(), PhotoImage,ref GUID);
            if (prog != null) prog(attLog, Int32.Parse(MacSN),GUID);
        }

        public void SaveFaceLog(string LogStr)
        {
            byte[] PhotoImage = null;
            DataTableReader dr = null;
            int InOutMode = 0;
            int VerifyStatus = 0;
            int VerifyType = 0;
            string GUID = "";
            VerifyPush<VerifyPushInfo> verifyPush = null;
            VerifyPush<RemoteOpenDoorPushInfo> remoteOpenDoorPush = null;
            if (LogStr.Contains("RemoteOpenDoorPush"))
            {
                remoteOpenDoorPush = JsonConvert.DeserializeObject<VerifyPush<RemoteOpenDoorPushInfo>>(LogStr);
                MacSN = remoteOpenDoorPush.info.DeviceID.ToString();
                attLog.Remark = "";
                UInt32 FingerNo = 0;
                attLog = new TSeaLog();
                attLog.CardID = FingerNo.ToString("0000000000");
                attLog.CardTime = DateTime.Parse(remoteOpenDoorPush.info.CreateTime);
                attLog.FingerNo = FingerNo;
                VerifyStatus = 27;
                VerifyType = remoteOpenDoorPush.info.VerfyType;
            }
            else
            {
                verifyPush = JsonConvert.DeserializeObject<VerifyPush<VerifyPushInfo>>(LogStr);
                MacSN = verifyPush.info.DeviceID.ToString();
                attLog.Remark = verifyPush.info.Notes;
                UInt32 FingerNo = 0;
                UInt32.TryParse(verifyPush.info.ToString(), out FingerNo);
                attLog = new TSeaLog();
                attLog.CardID = FingerNo.ToString("0000000000");
                attLog.CardTime = DateTime.Parse(verifyPush.info.CreateTime);
                attLog.FingerNo = FingerNo;
                attLog.Temperature = verifyPush.info.Temperature;
                attLog.TemperatureAlarm = verifyPush.info.TemperatureAlarm;
                VerifyType = verifyPush.info.VerfyType;
                VerifyStatus = verifyPush.info.VerifyStatus;
                if (verifyPush.SanpPic != null)
                {
                    PhotoImage = Convert.FromBase64String(verifyPush.SanpPic.Replace("data:image/jpeg;base64,", ""));
                }
                else
                {
                    PhotoImage = new byte[0];
                }
            }
            if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
            dr = db.GetDataReader("SELECT * FROM VSEA_MacInfoFace WHERE MacSN='" + MacSN + "'");
            if (dr.Read())
            {
                int.TryParse(dr["MacInOut"].ToString(), out InOutMode);
            }
            dr.Close();
            readData.Sea_SetLogName(attLog, InOutMode,VerifyStatus, VerifyType);
            readData.WriteTextFile(attLog, Int32.Parse(MacSN), true);
            if (textFormat.Allow) readData.WriteTextFormat(db, textFormat, attLog, Int32.Parse(MacSN), true);
            readData.SeaSaveDB(db, attLog, Int32.Parse(MacSN), attLog.FingerNo, PhotoImage);

            if (attLog.VerifyMode == 0)
            {
                attLog.VerifyMode = attLog.DoorMode;
                attLog.VerifyModeName = attLog.DoorModeName;
            }

            readData.SeaSaveDBMJ(db, attLog, MacSN.ToString(), PhotoImage,ref GUID);
            if (prog != null) prog(attLog, Int32.Parse(MacSN),GUID);
        }

    }

    /// <summary>
    /// 返回确认信息
    /// </summary>
    public class ResponseHelper
    {
        private HttpListenerResponse response;
        private Stream OutputStream;
        public Stream _OutputStream
        {
            get { return OutputStream; }
            set { OutputStream = value; }
        }

        public ResponseHelper(HttpListenerResponse response)
        {
            this.response = response;
            OutputStream = response.OutputStream;
        }
      
        public void WriteToClient(int state)
        {
            response.StatusCode = 200;

            try
            {
                using (StreamWriter writer = new StreamWriter(OutputStream))
                {
                    response.Headers["response_code"] = "OK";
                    response.Headers["trans_id"] = "100";
                }
            }
            catch 
            {
               
            }
         
        }
    }
}
