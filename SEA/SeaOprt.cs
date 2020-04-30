using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using System.IO;

namespace ECard78
{
    public partial class frmSeaOprt : frmBaseDialog
    {
        private string title = "";
        private string oprt = "";
        private int flag = 0;
        private List<TConnInfoSEA> connList = new List<TConnInfoSEA>();
        private List<TimeZone> timeList = new List<TimeZone>();
        private List<UInt32> fingerNoList = new List<UInt32>();
        private bool IsWorking = false;
        private List<string> GUID = new List<string>();
        protected int selectNo = 0;
        protected int selectNoEnd = 0;
        protected bool isSelect = false;
        protected bool isSelectEnd = false;
        private string Parameter = "";
        public string BodyParameter = "";
        public string[] userNameAndPwd = new string[0];
        protected bool IsExec = false;
        protected int QueryFlag = 0;
        protected int ShowFlag = 0;
        protected bool ShowTextMsg = false;

        private void AddColumn(int colType, string Field, int colWidth)
        {
            AddColumn(colType, Field, false, true, colWidth);
        }

        private void AddColumn(int colType, string Field, bool IsHide, int colWidth)
        {
            AddColumn(colType, Field, IsHide, true, colWidth);
        }

        private void AddColumn(int colType, string Field, bool IsHide, bool HasSort, int colWidth)
        {
            AddColumn(colType, Field, IsHide, HasSort, 0, colWidth);
        }

        private void AddColumn(int colType, string Field, bool IsHide, bool HasSort, byte CenterFlag, int colWidth)
        {
            AddColumn(dataGrid, colType, Field, IsHide, HasSort, CenterFlag, colWidth);
        }

        protected override void InitForm()
        {
            formCode = "SeaOprt";
            dataGrid.Columns.Clear();
            AddColumn(1, "SelectCheck", false, false, 1, 60);
            AddColumn(0, "MacSysID", true, false, 0);
            AddColumn(0, "MacSN", false, 0);
            AddColumn(0, "MacIPAddress", false, false, 0);
            AddColumn(0, "MacPort", false, false, 0);
            AddColumn(0, "MacName", false, false, 0);
            AddColumn(0, "MacPWD", true, false, 0);
            AddColumn(0, "MacInOut", true, false, 0);
            AddColumn(0, "MacInOutName", false, false, 0);
            AddColumn(0, "MacDesc", false, false, 0);

            base.InitForm();
            msgGrid.BackgroundColor = dataGrid.BackgroundColor;
            msgGrid.DefaultCellStyle.SelectionForeColor = dataGrid.DefaultCellStyle.SelectionForeColor;
            this.Text = title;
            btnSeaOprt.Text = oprt;
            toolTip.SetToolTip(btnSeaOprt, btnSeaOprt.Text);
            string QueryCoin = "";
            switch (QueryFlag)
            {
                case 1:
                    QueryCoin = Pub.GetSQL(DBCode.DB_002001, new string[] { "103" });
                    break;
                case 255:
                    QueryCoin = Pub.GetSQL(DBCode.DB_002001, new string[] { "107" });
                    break;
            }
            string QuerySQL = Pub.GetSQL(DBCode.DB_006001, new string[] { "0", QueryCoin });

            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                bindingSource.DataSource = db.GetDataTable(QuerySQL);
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E, QuerySQL);
            }
            RefresButton();
            msgGrid_Resize(null, null);
        }

        public frmSeaOprt(string Title, string Oprt,string msg,int Flag,List<String> guid)
        {
            title = Title;
            oprt = Oprt;
            Parameter = msg;
            flag = Flag;
            GUID = guid;
            switch (flag)
            {
                case 0:
                    title = Pub.GetResText("", "mnuSeaDoorOpen", "");
                    oprt = Pub.GetResText("Main", "mnuSeaDoorOpen", "");
                    break;
                case 4:
                    userNameAndPwd = msg.Split(':');
                    break;
            }
            BodyParameter = "";
            InitializeComponent();
        }

        private void dataGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void msgGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void msgGrid_Resize(object sender, EventArgs e)
        {
            Column1.Width = msgGrid.Width - 20;
        }

        private void RefresButton()
        {
            dataGrid.Enabled = !IsWorking;
            btnSeaOprt.Enabled = !IsWorking && (bindingSource.Count > 0);
            btnExit.Enabled = !IsWorking;
            progBar.Visible = IsWorking;
        }

        private void RowToConnInfo(int RowIndex)
        {
            string MacSN = dataGrid[2, RowIndex].Value.ToString();
            string MacIPAddress = dataGrid[3, RowIndex].Value.ToString();
            string MacPort = dataGrid[4, RowIndex].Value.ToString();
            string MacName = dataGrid[5, RowIndex].Value.ToString();
            string MacPWD = dataGrid[6, RowIndex].Value.ToString();
            TConnInfoSEA conn = Pub.ValueToConnInfoSEA(MacSN, MacIPAddress, MacPort, MacName, MacPWD);
            connList.Add(conn);
        }

        private bool InitMacList()
        {
           
            connList.Clear();
            if (dataGrid.RowCount == 1)
            {
                RowToConnInfo(0);
            }
            else
            {
                for (int i = 0; i < dataGrid.RowCount; i++)
                {
                    if (Pub.ValueToBool(dataGrid[0, i].EditedFormattedValue))
                    {
                        RowToConnInfo(i);
                    }
                }
            }
            if ((connList.Count == 0))
            {
                RowToConnInfo(dataGrid.CurrentRow.Index);
            }
            if (connList.Count == 0)
            {
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorSelectMacOprt", ""));
            }
            return connList.Count > 0;
        }

        private void RefreshMacMsg(string msg)
        {
            msgGrid.Rows.Add();
            msgGrid[0, msgGrid.RowCount - 1].Value = "[" + DateTime.Now.ToString() + "] " + msg;
            msgGrid.Rows[msgGrid.RowCount - 1].Selected = true;
            msgGrid.CurrentCell = msgGrid.Rows[msgGrid.RowCount - 1].Cells[0];
        }

        private void UpdateMacMsg(string msg, bool state)
        {
            string s = msgGrid[0, msgGrid.RowCount - 1].Value.ToString();

            msgGrid[0, msgGrid.RowCount - 1].Value = s + "    " + msg;
            if (state)
                msgGrid[0, msgGrid.RowCount - 1].Style.ForeColor = Color.Blue;
            else
                msgGrid[0, msgGrid.RowCount - 1].Style.ForeColor = Color.Red;
        }

        private void RefreshMsg(string msg,int count)
        {
            RefreshMsg(msg,count, false);
        }

        private void RefreshMsg(string msg,int count, bool IsEnd)
        {
            lblMsg.Text = msg;
            if ((lblMsg.Text == "") || IsEnd)
            {
                progBar.Value = 0;
                progBar.Style = ProgressBarStyle.Marquee;
            }
            else
            {
                progBar.Value = count*100/ connList.Count;
                progBar.Style = ProgressBarStyle.Blocks;
            }
        }

        private void ExecMacOprt()
        {
            bool state;
            string msg = "";
            string MacMsg = "";
            if (!InitMacList()) return;
            IsWorking = true;
            RefresButton();
            DateTime start = new DateTime();
            start = DateTime.Now;
            string ExecTimes = "";
            string url = "";
            TConnInfoSEA conn;

            for (int i = 0; i < connList.Count; i++)
            {
                MacMsg = "";
                conn = connList[i];
                RefreshMsg(oprt + "[" + conn.MacSN + "]......",i);
                RefreshMacMsg(oprt + "[" + conn.MacSN + "]......");

                url = "http://" + conn.NetIP + "/";
                string body = "";
                string urlTestConnt = "http://" + conn.NetIP + "/action/GetSysParam";
                bool ret = DeviceObject.objFK623.POST_GetResponse(urlTestConnt, conn.NetName, conn.NetPassword, ref body);

                if (ret)
                {
                    state = ExecMacCommand(Int32.Parse(conn.MacSN), url, conn.NetName, conn.NetPassword, ref MacMsg);
                }
                else
                {
                    state = false;
                }
                
                ExecTimes = "    " + Pub.GetDateDiffTimes(start, DateTime.Now);
                if (MacMsg != "") MacMsg = "[" + MacMsg + "]";
                UpdateMacMsg(MacMsg + DeviceObject.objFK623.SeaBodyStr() + ExecTimes, state);
                msg = msg + conn.MacSN.ToString() + ":" + MacMsg + DeviceObject.objFK623.SeaBodyStr() + ";";
               
                Application.DoEvents();
                start = DateTime.Now;
                if (!IsWorking) break;
            }
            db.WriteSYLog(this.Text, oprt, msg);
            IsWorking = false;
            RefresButton();
            RefreshMsg("",0);
        }

        private bool ExecMacCommand(int MacSN,string url, string name, string pwd,  ref string MacMsg)
        {
            bool ret = false;
            DateTime start = new DateTime();
            start = DateTime.Now;
            MacMsg = "";
            switch (flag)
            {
                case 0://远程控制门
                    ret = MJDoorOpen(MacSN, url, name, pwd, ref MacMsg);
                    break;
                case 1://实时监控
                    ret = MJRealTimeMonitoringSettingsUpload(MacSN, url, name, pwd, ref MacMsg);
                    break;
                case 2://设置开门参数
                    ret = SetMJCondition(MacSN, url, name, pwd, ref MacMsg);
                    break;
                case 3://获取开门参数
                    ret = GetMJCondition(MacSN, url, name, pwd, ref MacMsg);
                    break;
                case 4://设置设备密码
                    ret = SetMJPwd(MacSN, url, name, pwd, ref MacMsg);
                    break;
                case 5://设置网络参数
                    ret = SetNetParam(MacSN, url, name, pwd, ref MacMsg);
                    break;
                case 6://获取网络参数
                    ret = GetNetParam(MacSN, url, name, pwd, ref MacMsg);
                    break;
                case 7://获取有效期
                    ret = GetValidity(MacSN, url, name, pwd, ref MacMsg);
                    break;
                case 8://设置有效期
                    ret = SetValidity(MacSN, url, name, pwd, ref MacMsg);
                    break;
                case 9://设置声音参数
                    ret = SetSound(MacSN, url, name, pwd, ref MacMsg);
                    break;
                case 10://获取声音参数
                    ret = GetSound(MacSN, url, name, pwd, ref MacMsg);
                    break;
            
                case 14://设置温度参数
                    ret = SetTemperatureParam(MacSN, url, name, pwd, ref MacMsg);
                    break;
                case 15://获取温度参数
                    ret = GetTemperatureParam(MacSN, url, name, pwd, ref MacMsg);
                    break;

                case 20://下载人员
                    ret = DownloadInfo(url, name, pwd, MacSN.ToString(), ref MacMsg);
                    break;
                case 21://上传
                    ret = UploadInfo(url, name, pwd, MacSN.ToString(), ref MacMsg);
                    break;
                case 22: //删除人员
                    ret = ClearInfo(url, name, pwd);
                    break;

            }
            return ret;
        }

        private bool ClearInfo(string url, string name, string pwd)
        {
            bool ret = false;
            url = url + "action/SetFactoryDefault";
            DefaltPersonCmd seaSeriesInitDevice = new DefaltPersonCmd(1);
            jsonBody<DefaltPersonCmd> SeaSeriesInitDeviceJson = new jsonBody<DefaltPersonCmd>("SetFactoryDefault", seaSeriesInitDevice);
            string jsonString = JsonConvert.SerializeObject(SeaSeriesInitDeviceJson);
            ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref jsonString);
            if (!ret)
            {
                ret = false;
            }
            else
            {
                jsonBody<Answer> answer = JsonConvert.DeserializeObject<jsonBody<Answer>>(jsonString);
                {
                    if (answer.info.Result != "Ok")
                    {
                        ret = false;
                        DeviceObject.objFK623.RunCode = (int)FKRun.RUNERR_UNKNOWNERROR;
                    }
                    else
                    {
                        DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                    }

                }
            }
            return ret;
        }


        private bool MJDoorOpen(int MacSN, string url, string name, string pwd, ref string MacMsg)
        {
            bool ret;
            url = url + "action/OpenDoor";
           
            OpenDoorCmd openDoorCmd = new OpenDoorCmd(MacSN,0,1);

            jsonBody<OpenDoorCmd> jsonBodyOpenDoorCmd = new jsonBody<OpenDoorCmd>("OpenDoor", openDoorCmd);
            string jsonString = JsonConvert.SerializeObject(jsonBodyOpenDoorCmd);
            ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref jsonString);
           
            return ret;
        }

        private bool MJRealTimeMonitoringSettingsUpload(int MacSN, string url, string name, string pwd, ref string MacMsg)
        {
            bool ret;
            List<string> TopList = new List<string>();
            TopList.Add("Snap");
            TopList.Add("Verify");
            url = url + "action/Subscribe";
            SubscribeUrlInfo subscribeUrlInfo = new SubscribeUrlInfo("/Subscribe/Snap", "/Subscribe/Verify", "/Subscribe/heartbeat");
            Subscribe<SubscribeUrlInfo> subscribe = new Subscribe<SubscribeUrlInfo>(MacSN,2, TopList, Parameter, subscribeUrlInfo, "none");

            jsonBody<Subscribe<SubscribeUrlInfo>> jsonBodySubscribe = new jsonBody<Subscribe<SubscribeUrlInfo>>("Subscribe", subscribe);
            string jsonString = JsonConvert.SerializeObject(jsonBodySubscribe);
            ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref jsonString);
           
            return ret;
        }

        private bool SetMJCondition(int MacSN, string url, string name, string pwd, ref string MacMsg)
        {
            bool ret;
            url = url + "action/SetDoorCondition";

            ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref Parameter);
            return ret;
        }
        private bool GetMJCondition(int MacSN, string url, string name, string pwd, ref string MacMsg)
        {
            bool ret;
            url = url + "action/GetDoorCondition";

            ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref Parameter);
            if (ret)
            {
                BodyParameter = Parameter;
                FK623Attend.SeaBody = Pub.GetResText("", "FK_RUN_SUCCESS", "");
            }

            this.DialogResult = DialogResult.OK;
            IsWorking = false;
            this.Close();
            return ret;
        }

        private bool SetMJPwd(int MacSN, string url, string name, string pwd, ref string MacMsg)
        {
            bool ret;
            url = url + "action/SetUserPwd";

            SetUserPwd userPwd = new SetUserPwd(userNameAndPwd[0], userNameAndPwd[1]);
            jsonBody<SetUserPwd> jsonBody = new jsonBody<SetUserPwd>("SetUserPwd", userPwd);
            string jsonString = JsonConvert.SerializeObject(jsonBody);
            ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref jsonString);
            if (ret)
            {
                FK623Attend.SeaBody = Pub.GetResText("", "FK_RUN_SUCCESS", "");
                Pub.MessageBoxShow(btnSeaOprt.Text + Pub.GetResText("", "FK_RUN_SUCCESS", ""),MessageBoxIcon.Information);
                string sql = Pub.GetSQL(DBCode.DB_006001, new string[] { "31", userNameAndPwd[0], userNameAndPwd[1], MacSN.ToString() });
                db.ExecSQL(sql);
            }
            return ret;
        }

        private bool SetNetParam(int MacSN, string url, string name, string pwd, ref string MacMsg)
        {
            bool ret;
            url = url + "action/SetNetParam";

            ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref Parameter);
            return ret;
        }



        private bool GetNetParam(int MacSN, string url, string name, string pwd, ref string MacMsg)
        {
            bool ret;
            url = url + "action/GetNetParam";

            ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref Parameter);
            if (ret)
            {
                BodyParameter = Parameter;
            }

            this.DialogResult = DialogResult.OK;
            IsWorking = false;
            this.Close();
            return ret;
        }

        private bool SetTemperatureParam(int MacSN, string url, string name, string pwd, ref string MacMsg)
        {
            bool ret;
            url = url + "action/SetTemperature";
            Parameter = Parameter.Replace("111111", MacSN.ToString());
            ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref Parameter);
            return ret;
        }



        private bool GetTemperatureParam(int MacSN, string url, string name, string pwd, ref string MacMsg)
        {
            bool ret;
            url = url + "action/GetTemperature";

            ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref Parameter);
            if (ret)
            {
                BodyParameter = Parameter;
            }

            this.DialogResult = DialogResult.OK;
            IsWorking = false;
            this.Close();
            return ret;
        }

        private bool SetValidity(int MacSN, string url, string name, string pwd, ref string MacMsg)
        {
            bool ret = false;
            UInt32 EnrollNumber = 0;
            string addUrl = url + "action/AddPerson";
            string delUrl = url + "action/SearchPerson";
            string UpdUrl = url + "action/EditPerson";

            byte[] fpData = new byte[0];
            string EnrollName = "";
            string EmpNo = "";
            long WeCardNo10 = 0;
            int WeCardNoType = 0;
            string EmpCertNo = "";
            string CardNo10 = "";
            string EmpAddress = "";
            string EmpPhoneNo = "";
            string picinfo = "";
            string EmpMemo = "";
            string StatusMsg = lblMsg.Text;
            int CountUpFp = 0;
            int CountUp = 0;
            string jsonString = "";
            List<int> CustomizeIDList = new List<int>();
            string ID = "";
            int Valid = 0;
            string ValidBegin = "";
            string ValidEnd = "";
            bool IsUpdate = true;
            string EmpSysID = "";
            DataTableReader dr = null;
            DataTableReader drImg = null;
            EditPersonInfo editPerson = null;
            Person<EditPersonInfo> editPersonCmd = null;

            SearchOnePerson searchOnePerson = null;
            jsonBody<SearchOnePerson> searchOnePersonCmd = null;

            PersonInfo personInfo = null;
            Person<PersonInfo> addPerson = null;
            string SysID = "";
            for(int i =0; i<GUID.Count;i++)
            {
                SysID +=  "'" + GUID[i] + "',";
            }
            SysID = SysID.Substring(0, SysID.Length -1);
            DataTable dtUploadcount = null;


            try
            {
                dtUploadcount = db.GetDataTable(Pub.GetSQL(DBCode.DB_006001, new string[] { "32", SysID }));
                if (dtUploadcount == null || dtUploadcount.Rows.Count == 0)
                {
                    string tmp = Pub.GetResText(formCode, "ItemPowerUpload", "");
                    MacMsg = string.Format(tmp, 0, CountUp, CountUpFp);
                    return true;
                }

                for (int i = 0; i < dtUploadcount.Rows.Count; i++)
                {
                    CustomizeIDList = new List<int>();
                    EnrollNumber = Convert.ToUInt32(dtUploadcount.Rows[i]["CardFingerNo"].ToString());
                    CustomizeIDList.Add(Convert.ToInt32(EnrollNumber));
                    EnrollName = dtUploadcount.Rows[i]["EmpName"].ToString();
                    lblMsg.Text = StatusMsg + string.Format(" - {2}/{3}  {0}[{1}]", EnrollNumber, EnrollName,
                      i + 1, dtUploadcount.Rows.Count);
                    progBar.Value = (i + 1) * 100 / dtUploadcount.Rows.Count;

                    EmpNo = dtUploadcount.Rows[i]["EmpNo"].ToString();
                    EmpSysID = dtUploadcount.Rows[i]["EmpSysID"].ToString();
                    EmpCertNo = dtUploadcount.Rows[i]["EmpCertNo"].ToString();
                   // CardNo10 = dtUploadcount.Rows[i]["OtherCardNo"].ToString();
                    //long.TryParse(CardNo10, out WeCardNo10);
                    EmpAddress = dtUploadcount.Rows[i]["EmpAddress"].ToString();
                    EmpPhoneNo = dtUploadcount.Rows[i]["EmpPhoneNo"].ToString();
                    EmpMemo = dtUploadcount.Rows[i]["EmpMemo"].ToString();

                    CardNo10 = "";
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_006001, new string[] { "47", EmpSysID, "11" }));
                    if (dr.Read())
                    {
                        byte[] buffCard = (byte[])dr["FaceTemplate"];
                        if (buffCard.Length > 0)
                        {
                            EncAndDec.PWDAndCard(11, buffCard, ref CardNo10);
                        }
                    }
                    dr.Close();

                    if (string.IsNullOrEmpty(CardNo10))
                        CardNo10 = dtUploadcount.Rows[i]["OtherCardNo"].ToString();
                    long.TryParse(CardNo10, out WeCardNo10);

                    CardNo10 = StrToHex(CardNo10);
                    if (CardNo10.Length > 10) CardNo10 = CardNo10.Substring(CardNo10.Length - 10, 10);
                    if (WeCardNo10 != 0) WeCardNoType = 2;
                    else WeCardNoType = 0;
                    ValidBegin = "";
                    ValidEnd = "";
                    if (!string.IsNullOrEmpty(dtUploadcount.Rows[i]["StartDate"].ToString()))
                        ValidBegin = Convert.ToDateTime(dtUploadcount.Rows[i]["StartDate"]).ToString(SystemInfo.SQLDateFMT) + "T00:00:00";
                    if (!string.IsNullOrEmpty(dtUploadcount.Rows[i]["EndDate"].ToString()))
                        ValidEnd = Convert.ToDateTime(dtUploadcount.Rows[i]["EndDate"]).ToString(SystemInfo.SQLDateFMT) + "T23:59:59";

                    if (ValidBegin != "" || ValidEnd != "")
                    {
                        Valid = 1;
                    }
                    else
                    {
                        Valid = 0;
                    }

                    CountUp++;

                    picinfo = "";
                    byte[] buff = null;
                    drImg = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "33", EmpSysID }));
                    if (drImg.Read())
                    {
                        if (drImg["EmpPhotoImage"].ToString() != "")
                        {
                            buff = (byte[])(drImg["EmpPhotoImage"]);
                            if (buff.Length > 0)
                            {
                                picinfo = "data:image/jpeg:base64," + Convert.ToBase64String(buff);
                                CountUpFp++;
                            }
                        }
                    }
                    drImg.Close();
                    if (buff == null || buff.Length == 0)
                    {
                        drImg = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "104", EmpSysID }));
                        if (drImg.Read())
                        {
                            if (drImg["EmpPhotoImage"].ToString() != "")
                            {
                                buff = (byte[])(drImg["EmpPhotoImage"]);
                                if (buff.Length > 0)
                                {
                                    picinfo = "data:image/jpeg:base64," + Convert.ToBase64String(buff);
                                    CountUpFp++;
                                }
                            }
                        }
                    }

                    searchOnePerson = new SearchOnePerson(MacSN, 0, EnrollNumber.ToString(), 0);
                    searchOnePersonCmd = new jsonBody<SearchOnePerson>("SearchPerson", searchOnePerson);
                    jsonString = JsonConvert.SerializeObject(searchOnePersonCmd);
                    IsUpdate = false;
                    ret = DeviceObject.objFK623.POST_GetResponse(delUrl, name, pwd, ref jsonString);
                    if (ret)
                    {
                        jsonBody<SearchPersonInfo> searchPersonInfo = JsonConvert.DeserializeObject<jsonBody<SearchPersonInfo>>(jsonString);
                        if (searchPersonInfo.info.CustomizeID == EnrollNumber)
                        {
                            IsUpdate = true;
                        }
                    }

                EEE:
                    if (IsUpdate)
                    {
                        editPerson = new EditPersonInfo(Convert.ToInt32(MacSN), 0, Convert.ToInt32(EnrollNumber), 0, EnrollName, 0, 1, 0, EmpCertNo, "", EmpPhoneNo, "",
                       EmpAddress, EmpMemo, WeCardNoType, WeCardNo10, StrToHex(CardNo10), Valid, "", ValidBegin, ValidEnd);
                        editPersonCmd = new Person<EditPersonInfo>("EditPerson", editPerson, picinfo);
                        jsonString = JsonConvert.SerializeObject(editPersonCmd);
                        ret = DeviceObject.objFK623.POST_GetResponse(UpdUrl, name, pwd, ref jsonString);
                    }
                    else
                    {
                        //增加人员
                        personInfo = new PersonInfo(MacSN, 0, EnrollName, 0, 1, 0, EmpCertNo, "", EmpPhoneNo, "",
                         EmpAddress, EmpMemo, WeCardNoType, WeCardNo10, StrToHex(CardNo10), Valid, Convert.ToInt32(EnrollNumber), "", ValidBegin, ValidEnd, "1", "1", "1", "1");
                        addPerson = new Person<PersonInfo>("AddPerson", personInfo, picinfo);

                        jsonString = JsonConvert.SerializeObject(addPerson);
                        ret = DeviceObject.objFK623.POST_GetResponse(addUrl, name, pwd, ref jsonString);
                    }

                    if (!ret)
                    {
                        if (DeviceObject.objFK623.SeaBodyStr().Equals(Pub.GetResText("", "FK_RUNERR_NO_OPEN_COMM", "")))
                        {
                            DialogResult MessRet = Pub.MessageBoxQuestion(DeviceObject.objFK623.SeaBodyStr() + "\r\n\r\n" +
                     Pub.GetResText(formCode, "MsgContinue", ""), MessageBoxButtons.YesNoCancel);
                            if (MessRet == DialogResult.Yes)
                                goto EEE;
                            else if (MessRet == DialogResult.Cancel)
                            {
                                ret = false;
                                break;
                            }
                            else
                                continue;
                        }
                        else
                        {
                            ID += "[" + EnrollNumber + "]" + DeviceObject.objFK623.SeaBodyStr() + "]";
                        }

                    }

                    Application.DoEvents();
                    ret = true;
                }

            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                string tmp = Pub.GetResText(formCode, "MsgUpInfo", "");
                if (ID != "")
                {
                    tmp += "  <" + Pub.GetResText(formCode, "UnsuccessfulEmpNo", "") + ID + ">  ";
                }
                if(dtUploadcount!=null)
                MacMsg = string.Format(tmp, dtUploadcount.Rows.Count, CountUp, CountUpFp);
            }

            return ret;
        }
        public string StrToHex(string str)
        {
            string hex = "";
            try
            {
                long hexInt = Convert.ToInt64(str, 10);
                int index = str.Length - hexInt.ToString().Length;

                switch (index)
                {
                    case 0:
                        hex = hexInt.ToString("X");
                        break;
                    case 1:
                        hex = "0" + hexInt.ToString("X");
                        break;
                    case 2:
                        hex = "00" + hexInt.ToString("X");
                        break;
                    case 3:
                        hex = "000" + hexInt.ToString("X");
                        break;
                    case 4:
                        hex = "0000" + hexInt.ToString("X");
                        break;
                    case 5:
                        hex = "00000" + hexInt.ToString("X");
                        break;
                    case 6:
                        hex = "000000" + hexInt.ToString("X");
                        break;
                    case 7:
                        hex = "0000000" + hexInt.ToString("X");
                        break;
                    case 8:
                        hex = "00000000" + hexInt.ToString("X");
                        break;
                    case 9:
                        hex = "000000000" + hexInt.ToString("X");
                        break;
                    case 10:
                        hex = "0000000000" + hexInt.ToString("X");
                        break;
                    default:
                        hex = hexInt.ToString();
                        break;
                }


            }
            catch
            {

            }
            return hex;
        }
        private bool GetValidity(int MacSN, string url, string name, string pwd, ref string MacMsg)
        {
            bool ret = false;
            byte[] Photo = new byte[0];
            int EmpCount = 0;
            DataRow[] rows = null;
            DataRow[] empRows = null;
            string EmpNo = "";

            int PersonNum = 0;

            string jsonString = "";
            string StatusMsg = lblMsg.Text;

            string StartDate = "NULL";
            string EndDate = "NULL";

            byte[] CardData = new byte[0];
            string guid = "";


            DataTable dtInsert = new DataTable();
            DataTable dtUpdate = new DataTable();
            DataTable dtSelect = new DataTable();
            DataTable dtEmpSelect = new DataTable();
            try
            {
                dtInsert = db.GetDataTable(Pub.GetSQL(DBCode.DB_006001, new string[] { "28" }));
                dtUpdate = db.GetDataTable(Pub.GetSQL(DBCode.DB_006001, new string[] { "28" }));
                dtSelect = db.GetDataTable(Pub.GetSQL(DBCode.DB_006001, new string[] { "27", MacSN.ToString() }));
                dtEmpSelect = db.GetDataTable(Pub.GetSQL(DBCode.DB_006001, new string[] { "29" }));

                //查询人员总数
                string searchTotlePersonUrl = url + "action/SearchPersonNum";
                SearchTotlePerson searchTotlePerson = new SearchTotlePerson(Convert.ToInt32(MacSN), 0, "", "", 2, "0-100", 0, "");
                jsonBody<SearchTotlePerson> jsonBodySearchTotlePerson = new jsonBody<SearchTotlePerson>("SearchPersonNum", searchTotlePerson);
                jsonString = JsonConvert.SerializeObject(jsonBodySearchTotlePerson);
                ret = DeviceObject.objFK623.POST_GetResponse(searchTotlePersonUrl, name, pwd, ref jsonString);
                if (!ret) return false;
                jsonBody<SearchTotlePersonInfo> searchTotlePersonInfo = JsonConvert.DeserializeObject<jsonBody<SearchTotlePersonInfo>>(jsonString);
                {
                    PersonNum = searchTotlePersonInfo.info.PersonNum;
                }
                if (PersonNum == 0)
                {
                    return false;
                }

                int i = 0;
                while (true)
                {
                    //查询人员
                    string searchMultipleUrl = url + "action/SearchPersonList";
                    SearchMultiplePerson searchMultiple = new SearchMultiplePerson(Convert.ToInt32(MacSN), 0, "", "", 2, "0-100", 0, "", i * 10, 10, 1);
                    i++;
                    jsonBody<SearchMultiplePerson> jsonBodySearchMultiplePerson = new jsonBody<SearchMultiplePerson>("SearchPersonList", searchMultiple);
                ES:
                    jsonString = JsonConvert.SerializeObject(jsonBodySearchMultiplePerson);
                    ret = DeviceObject.objFK623.POST_GetResponse(searchMultipleUrl, name, pwd, ref jsonString);
                    if (!ret)
                    {
                        if (DeviceObject.objFK623.SeaBodyStr().Equals(Pub.GetResText("", "FK_RUNERR_NO_OPEN_COMM", "")))
                        {
                            DialogResult MessRet = Pub.MessageBoxQuestion(DeviceObject.objFK623.SeaBodyStr() + "\r\n\r\n" +
                   Pub.GetResText(formCode, "MsgContinue", ""), MessageBoxButtons.OKCancel);
                            if (MessRet == DialogResult.OK)
                            {
                                goto ES;
                            }
                            else
                            {
                                ret = false;
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    jsonBody<SearchMultiplePersonInfo<SearchPersonInfo>> searchMultiplePersonInfo = JsonConvert.DeserializeObject<jsonBody<SearchMultiplePersonInfo<SearchPersonInfo>>>(jsonString);
                    {
                        for (int j = 0; j < searchMultiplePersonInfo.info.Listnum; j++)
                        {
                            if (searchMultiplePersonInfo.info.List[j].Tempvalid != 0)
                            {
                                StartDate = searchMultiplePersonInfo.info.List[j].ValidBegin;
                                EndDate = searchMultiplePersonInfo.info.List[j].ValidEnd;
                            }
                            else
                            {
                                StartDate = null;
                                EndDate = null;
                            }

                            empRows = dtEmpSelect.Select("CardFingerNo=" + searchMultiplePersonInfo.info.List[j].CustomizeID + "");
                            if (empRows.Length > 0)
                            {
                                EmpNo = empRows[0]["EmpNo"].ToString();
                                rows = dtSelect.Select("EmpNo='" + EmpNo + "'");
                                if (rows.Length > 0)
                                {
                                    guid = rows[0]["GUID"].ToString();
                                    dtUpdate.Rows.Add(new object[] { guid, MacSN, EmpNo, OprtInfo.OprtNo, DateTime.Now.ToString(SystemInfo.SQLDateTimeFMT), StartDate, EndDate });
                                }
                                else
                                {
                                    dtInsert.Rows.Add(new object[] { GetGUID(), MacSN, EmpNo, OprtInfo.OprtNo, DateTime.Now.ToString(SystemInfo.SQLDateTimeFMT), StartDate, EndDate });
                                }
                                EmpCount++;
                            }

                            lblMsg.Text = StatusMsg + Pub.GetResText(formCode, "MsgFingerInfo", "") +
                          string.Format(" - {2}/{3}  [{0}: {1}]", searchMultiplePersonInfo.info.List[j].CustomizeID, searchMultiplePersonInfo.info.List[j].Name, EmpCount, PersonNum);
                            if (EmpCount > 0)
                                progBar.Value = EmpCount * 100 / PersonNum;
                            Application.DoEvents();
                        }
                        if (dtInsert.Rows.Count > 0)
                        {
                            db.batchEmpInSertData(dtInsert, "Sea_SeaPower");
                            dtInsert.Clear();
                        }
                        if (dtUpdate.Rows.Count > 0)
                        {
                            db.batchEmpUpdateData(dtUpdate, "Sea_SeaPower", "GUID");
                            dtUpdate.Clear();
                        }
                    }
                }

            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                string tmp = Pub.GetResText(formCode, "MsgUpInfo", "");
                MacMsg = string.Format(tmp, EmpCount, EmpCount, PersonNum);
            }

            if (EmpCount > 0)
            {
                FK623Attend.SeaBody = Pub.GetResText("", "FK_RUN_SUCCESS", "");
                ret = true;
            }
            return ret;
        }

        private string GetGUID()
        {
            string ret = System.Guid.NewGuid().ToString().ToUpper();
            return ret;
        }
        private bool SetSound(int MacSN, string url, string name, string pwd, ref string MacMsg)
        {
            bool ret;
            url = url + "action/SetSound";

            ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref Parameter);
            return ret;
        }



        private bool GetSound(int MacSN, string url, string name, string pwd, ref string MacMsg)
        {
            bool ret;
            url = url + "action/GetSound";

            ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref Parameter);
            if (ret)
            {
                BodyParameter = Parameter;
            }

            this.DialogResult = DialogResult.OK;
            IsWorking = false;
            this.Close();
            return ret;
        }


        private void btnOprt_Click(object sender, EventArgs e)
        {
            ExecMacOprt();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMJOprt_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsWorking) e.Cancel = true;
        }

        private void SelectData(bool State)
        {
            if (bindingSource.DataSource != null)
            {
                DataTable dt = (DataTable)bindingSource.DataSource;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i].BeginEdit();
                    dt.Rows[i]["SelectCheck"] = State;
                    dt.Rows[i].EndEdit();
                }
            }
        }

        private void ItemSelect_Click(object sender, EventArgs e)
        {
            SelectData(true);
        }

        private void ItemUnselect_Click(object sender, EventArgs e)
        {
            SelectData(false);
        }

        private void dataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey && !isSelectEnd)
            {
                selectNo = dataGrid.CurrentRow.Index;
                isSelect = true;
                isSelectEnd = true;
            }
           
        }

        private void dataGrid_KeyUp(object sender, KeyEventArgs e)
        {
            isSelect = false;
            isSelectEnd = false;
        }

        private void dataGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGrid.Rows.Count == 0) return;
            selectNoEnd = dataGrid.CurrentRow.Index;
            if (selectNoEnd < 0) return;
            if (isSelect)
            {
                int i = 0;
                for (int j = 0; j < dataGrid.RowCount; j++)
                {

                    if (selectNo < selectNoEnd)
                    {
                        if (i >= selectNo && i <= selectNoEnd)
                            dataGrid.Rows[i].Cells[0].Value = true;
                    }
                    else
                    {
                        if (i <= selectNo && i >= selectNoEnd)
                            dataGrid.Rows[i].Cells[0].Value = true;
                    }
                    i++;
                }
            }
        }

        private bool DownloadInfo(string url, string name, string pwd, string MacSN, ref string MacMsg)
        {
            bool ret = false;
            int Privilege = 0;
            byte[] Photo = new byte[0];
            int EmpCount = 0;
            string EmpNo = "";
            byte[] EmpPhotoBuff = null;
            byte[] PhotoBuff = null;
            int PersonNum = 0;
            int PhotoCount = 0;
            string jsonString = "";
            string StatusMsg = lblMsg.Text;
            string CardNo = "";

            int userCount = 0;
            int CardCount = 0;
            string StartDate = "";
            string EndDate = "";
            string EmpName = "";
            byte[] CardData = new byte[0];
            string EmpSysID = "";
            UInt32 EnrollNumber = 0;
            DataTableReader dr = null;
            string CardTypeSysID = "";
            List<string> sql = new List<string>(0);
            try
            {
                //查询人员总数
                string searchTotlePersonUrl = url + "action/SearchPersonNum";
                SearchTotlePerson searchTotlePerson = new SearchTotlePerson(Convert.ToInt32(MacSN), 0, "", "", 2, "0-100", 0, "");
                jsonBody<SearchTotlePerson> jsonBodySearchTotlePerson = new jsonBody<SearchTotlePerson>("SearchPersonNum", searchTotlePerson);
                jsonString = JsonConvert.SerializeObject(jsonBodySearchTotlePerson);
                ret = DeviceObject.objFK623.POST_GetResponse(searchTotlePersonUrl, name, pwd, ref jsonString);
                if (!ret) return false;
                jsonBody<SearchTotlePersonInfo> searchTotlePersonInfo = JsonConvert.DeserializeObject<jsonBody<SearchTotlePersonInfo>>(jsonString);
                {
                    PersonNum = searchTotlePersonInfo.info.PersonNum;
                }
                if (PersonNum == 0)
                {
                    return false;
                }
                int i = 0;
                while (true)
                {
                    //查询人员
                    string searchMultipleUrl = url + "action/SearchPersonList";
                    SearchMultiplePerson searchMultiple = new SearchMultiplePerson(Convert.ToInt32(MacSN), 0, "", "", 2, "0-100", 0, "", i * 10, 10, 1);
                    i++;
                    jsonBody<SearchMultiplePerson> jsonBodySearchMultiplePerson = new jsonBody<SearchMultiplePerson>("SearchPersonList", searchMultiple);
                ES:
                    jsonString = JsonConvert.SerializeObject(jsonBodySearchMultiplePerson);
                    ret = DeviceObject.objFK623.POST_GetResponse(searchMultipleUrl, name, pwd, ref jsonString);
                    if (!ret)
                    {
                        if (DeviceObject.objFK623.SeaBodyStr().Equals(Pub.GetResText("", "FK_RUNERR_NO_OPEN_COMM", "")))
                        {
                            DialogResult MessRet = Pub.MessageBoxQuestion(DeviceObject.objFK623.SeaBodyStr() + "\r\n\r\n" +
                   Pub.GetResText(formCode, "MsgContinue", ""), MessageBoxButtons.OKCancel);
                            if (MessRet == DialogResult.OK)
                            {
                                goto ES;
                            }
                            else
                            {
                                ret = false;
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    jsonBody<SearchMultiplePersonInfo<SearchPersonInfo>> searchMultiplePersonInfo = JsonConvert.DeserializeObject<jsonBody<SearchMultiplePersonInfo<SearchPersonInfo>>>(jsonString);
                    {
                        for (int j = 0; j < searchMultiplePersonInfo.info.Listnum; j++)
                        {
                            EmpCount++;
                            UInt32.TryParse(searchMultiplePersonInfo.info.List[j].CustomizeID.ToString(), out EnrollNumber);
                            EmpName = searchMultiplePersonInfo.info.List[j].Name;
                            Photo = new byte[0];
                            if (!string.IsNullOrEmpty(searchMultiplePersonInfo.info.List[j].Picinfo))
                                Photo = Convert.FromBase64String(searchMultiplePersonInfo.info.List[j].Picinfo.Replace("data:image/jpeg;base64,", ""));
                            if (searchMultiplePersonInfo.info.List[j].RFIDCard != null)
                            {
                                CardNo = searchMultiplePersonInfo.info.List[j].RFIDCard.ToString();

                                if (CardNo != "")
                                    CardNo = HexToStr(CardNo);
                                if (CardNo.Length > 10) CardNo = CardNo.Substring(CardNo.Length - 10, 10);
                                CardCount++;
                            }
                            else
                            {
                                CardNo = searchMultiplePersonInfo.info.List[j].MjCardNo.ToString();
                                if (CardNo.Length > 1) CardCount++;
                                else
                                {
                                    CardNo = "";
                                }
                                if (CardNo.Length > 10) CardNo = CardNo.Substring(CardNo.Length - 10, 10);
                            }
                            if (searchMultiplePersonInfo.info.List[j].Tempvalid != 0)
                            {
                                StartDate = searchMultiplePersonInfo.info.List[j].ValidBegin;
                                EndDate = searchMultiplePersonInfo.info.List[j].ValidEnd;
                            }
                            else
                            {
                                StartDate = null;
                                EndDate = null;
                            }


                            EmpNo = "";
                            CardTypeSysID = "";
                            sql = new List<string>(0);
                            EmpSysID = "";
                            dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "5", EnrollNumber.ToString() }));
                            if (dr.Read())
                                EmpSysID = dr["EmpSysID"].ToString();
                            dr.Close();
                            if (EmpSysID == "")
                            {
                                if (!db.GetServerGUID(ref EmpSysID)) return false;
                                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "204", "0" }));
                                if (dr.Read()) CardTypeSysID = dr["CardTypeSysID"].ToString();
                                dr.Close();
                                EmpNo = db.GetAutoEmpNo();

                                if (EmpNo == "") EmpNo = searchMultiplePersonInfo.info.List[j].CustomizeID.ToString();
                                sql.Add(Pub.GetSQL(DBCode.DB_001003, new string[] { "8", EmpSysID, EmpNo, EmpName, "", CardTypeSysID,
            SystemInfo.CommanySysID, DateTime.Now.ToString(SystemInfo.SQLDateFMT), searchMultiplePersonInfo.info.List[j].IdCard, searchMultiplePersonInfo.info.List[j].Address, "",
            searchMultiplePersonInfo.info.List[j].Telnum, "", "Y", CardNo,"0" }));
                                sql.Add(Pub.GetSQL(DBCode.DB_001003, new string[] { "242", EnrollNumber.ToString(), EmpSysID }));

                            }
                            else
                            {
                                sql.Add(Pub.GetSQL(DBCode.DB_001003, new string[] { "28",  EmpName,
              searchMultiplePersonInfo.info.List[j].Address, searchMultiplePersonInfo.info.List[j].Telnum, CardNo,searchMultiplePersonInfo.info.List[j].IdCard, EmpSysID }));
                            }
                            if (db.ExecSQL(sql) == 0)
                            {
                                sql.Clear();
                                if (Photo.Length > 1)
                                {
                                    MemoryStream ms = new MemoryStream(Photo);
                                    Image empPhotoImage = CustomSizeImage(Image.FromStream(ms));
                                    ms.Dispose();
                                    using (Bitmap t = new Bitmap(empPhotoImage))
                                    {
                                        ms = new MemoryStream();
                                        t.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                        EmpPhotoBuff = ms.ToArray();
                                        ms.Dispose();
                                        ms.Close();
                                    }

                                    MemoryStream msi = new MemoryStream(Photo);
                                    Image empPhoto = CustomSizePhoto(Image.FromStream(msi));
                                    msi.Dispose();
                                    using (Bitmap ti = new Bitmap(empPhoto))
                                    {
                                        msi = new MemoryStream();
                                        ti.Save(msi, System.Drawing.Imaging.ImageFormat.Jpeg);
                                        PhotoBuff = msi.ToArray();
                                        msi.Dispose();
                                        msi.Close();
                                    }
                                    db.UpdateByteData(Pub.GetSQL(DBCode.DB_001003, new string[] { "10", EmpSysID }), "EmpPhotoImage", EmpPhotoBuff);
                                    if (dr != null) dr.Close();
                                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "34", EmpSysID }));
                                    if (!dr.Read())
                                    {
                                        db.ExecSQL(Pub.GetSQL(DBCode.DB_001003, new string[] { "35", EmpSysID }));
                                    }

                                    db.UpdateByteData(Pub.GetSQL(DBCode.DB_001003, new string[] { "29", EmpSysID }), "EmpPhotoImage", PhotoBuff);
                                    PhotoCount++;
                                }
                                if (CardNo != "")
                                {
                                    byte[] CardBuff = EncAndDec.getCard(CardNo);
                                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "32", "3", EnrollNumber.ToString(), "11" }));

                                    sql.Add(Pub.GetSQL(DBCode.DB_001003, new string[] { dr.Read() ? "31" : "30", "3",
                                            EnrollNumber.ToString(), "11", "0", Privilege.ToString(), "NULL" }));
                                    dr.Close();

                                    sql.Add(Pub.GetSQL(DBCode.DB_001003, new string[] { "903", "1", EmpSysID }));

                                    if (db.ExecSQL(sql) == 0)
                                    {
                                        db.UpdateByteData(Pub.GetSQL(DBCode.DB_002001, new string[] { "2012", "3", EnrollNumber.ToString(),
                                                                     "11" }), "FaceTemplate", CardBuff);
                                    }
                                    ret = true;
                                    CardCount++;
                                }
                            }
                            userCount++;
                            lblMsg.Text = StatusMsg + Pub.GetResText(formCode, "MsgFingerInfo", "") +
                          string.Format(" - {2}/{3}  [{0}: {1}]", searchMultiplePersonInfo.info.List[j].CustomizeID, searchMultiplePersonInfo.info.List[j].Name, EmpCount, PersonNum);
                            if (EmpCount > 0)
                                progBar.Value = EmpCount * 100 / PersonNum;
                            Application.DoEvents();
                        }

                    }
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                string tmp = Pub.GetResText(formCode, "MsgSeaDownInfo", "");
                MacMsg = string.Format(tmp, userCount, PhotoCount, CardCount);
            }
            if (userCount > 0)
            {
                FK623Attend.SeaBody = Pub.GetResText("", "FK_RUN_SUCCESS", "");
                ret = true;
            }
            return ret;
        }
        public string HexToStr(string str)
        {
            string hex = "";
            try
            {
                long hexInt = Convert.ToInt64(str, 16);
                int index = str.Length - hexInt.ToString("X").Length;

                switch (index)
                {
                    case 0:
                        hex = hexInt.ToString();
                        break;
                    case 1:
                        hex = "0" + hexInt.ToString();
                        break;
                    case 2:
                        hex = "00" + hexInt.ToString();
                        break;
                    case 3:
                        hex = "000" + hexInt.ToString();
                        break;
                    case 4:
                        hex = "0000" + hexInt.ToString();
                        break;
                    case 5:
                        hex = "00000" + hexInt.ToString();
                        break;
                    case 6:
                        hex = "000000" + hexInt.ToString();
                        break;
                    case 7:
                        hex = "0000000" + hexInt.ToString();
                        break;
                    case 8:
                        hex = "00000000" + hexInt.ToString();
                        break;
                    case 9:
                        hex = "000000000" + hexInt.ToString();
                        break;
                    case 10:
                        hex = "0000000000" + hexInt.ToString();
                        break;
                    default:
                        hex = hexInt.ToString();
                        break;

                }


            }
            catch
            {

            }
            return hex;
        }

        private bool UploadInfo(string url, string name, string pwd, string MacSN, ref string MacMsg)
        {
            bool ret = false;
            UInt32 EnrollNumber = 0;
            string addUrl = url + "action/AddPerson";
            string selUrl = url + "action/SearchPerson";
            string updUrl = url + "action/EditPerson";
            string EnrollName = "";
            string EmpNo = "";
            string EmpSysID = "";
            string EmpCertNo = "";
            string CardNo10 = "";
            long WeCardNo10 = 0;
            int WeCardNoType = 0;
            string EmpAddress = "";
            string EmpPhoneNo = "";
            string picinfo = "";
            string EmpMemo = "";
            string ValidBegin = "";
            string ValidEnd = "";
            string StatusMsg = lblMsg.Text;
            int CountUpFp = 0;
            int CountUp = 0;
            int Valid = 0;
            EditPersonInfo editPerson = null;
            Person<EditPersonInfo> editPersonCmd = null;

            SearchOnePerson searchOnePerson = null;
            jsonBody<SearchOnePerson> searchOnePersonCmd = null;

            PersonInfo personInfo = null;
            Person<PersonInfo> addPerson = null;
            string jsonString = "";
            List<int> CustomizeIDList = new List<int>();
            string ID = "";
            bool IsUpdate = false;
            DataTableReader dr = null;
            DataTableReader drImg = null;
            DataTable dtUploadcount = null;
            byte[] buffCard = null;
            byte[] buff = null;
            string ESysID = "";
            for (int i = 0; i < GUID.Count; i++)
            {
                ESysID += "'" + GUID[i] + "',";
            }
            ESysID = ESysID.Substring(0, ESysID.Length - 1);

            try
            {
                dtUploadcount = db.GetDataTable(Pub.GetSQL(DBCode.DB_006001, new string[] { "46", ESysID }));
                if (dtUploadcount == null)
                {
                    string tmp = Pub.GetResText(formCode, "MsgUpInfo", "");
                    MacMsg = string.Format(tmp, 0, CountUp, CountUpFp);
                    return true;
                }

                for (int i = 0; i < dtUploadcount.Rows.Count; i++)
                {
                    CustomizeIDList = new List<int>();
                    EmpSysID = dtUploadcount.Rows[i]["EmpSysID"].ToString();
                    
                    EmpNo = dtUploadcount.Rows[i]["EmpNo"].ToString();
                    EnrollNumber = Convert.ToUInt32(dtUploadcount.Rows[i]["CardFingerNo"].ToString());

                    CustomizeIDList.Add(Convert.ToInt32(EnrollNumber));
                    EnrollName = dtUploadcount.Rows[i]["EmpName"].ToString();
                    lblMsg.Text = StatusMsg + string.Format(" - {2}/{3}  {0}[{1}]", EnrollName, EnrollNumber,
                      i + 1, dtUploadcount.Rows.Count);
                    progBar.Value = (i + 1) * 100 / dtUploadcount.Rows.Count;

                    EmpCertNo = dtUploadcount.Rows[i]["EmpCertNo"].ToString();

                    EmpAddress = dtUploadcount.Rows[i]["EmpAddress"].ToString();
                    EmpPhoneNo = dtUploadcount.Rows[i]["EmpPhoneNo"].ToString();
                    EmpMemo = dtUploadcount.Rows[i]["EmpMemo"].ToString();
                    ValidBegin = "";
                    ValidEnd = "";
                    //if (!string.IsNullOrEmpty(dtUploadcount.Rows[i]["StartDate"].ToString()))
                    //    ValidBegin = Convert.ToDateTime(dtUploadcount.Rows[i]["StartDate"]).ToString(SystemInfo.SQLDateFMT) + "T00:00:00";
                    //if (!string.IsNullOrEmpty(dtUploadcount.Rows[i]["EndDate"].ToString()))
                    //    ValidEnd = Convert.ToDateTime(dtUploadcount.Rows[i]["EndDate"]).ToString(SystemInfo.SQLDateFMT) + "T23:59:59";

                    if (ValidBegin != "" || ValidEnd != "")
                    {
                        Valid = 1;
                    }
                    else
                    {
                        Valid = 0;
                    }

                    CardNo10 = "";
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_006001, new string[] { "47", EmpSysID, "11" }));
                    if (dr.Read())
                    {
                        buffCard = (byte[])dr["FaceTemplate"];
                        if (buffCard.Length > 0)
                        {
                            EncAndDec.PWDAndCard(11, buffCard, ref CardNo10);
                        }
                    }
                    dr.Close();

                    if (string.IsNullOrEmpty(CardNo10))
                        CardNo10 = dtUploadcount.Rows[i]["OtherCardNo"].ToString();

                    long.TryParse(CardNo10, out WeCardNo10);

                    CountUp++;
                    picinfo = "";
                    buff = null;
                    drImg = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "33", EmpSysID }));
                    if (drImg.Read())
                    {
                        if (drImg["EmpPhotoImage"].ToString() != "")
                        {
                            buff = (byte[])(drImg["EmpPhotoImage"]);
                            if (buff.Length > 0)
                            {
                                picinfo = "data:image/jpeg:base64," + Convert.ToBase64String(buff);
                                CountUpFp++;
                            }
                        }
                    }
                    drImg.Close();
                    if (buff == null || buff.Length == 0)
                    {
                        drImg = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "104", EmpSysID }));
                        if (drImg.Read())
                        {
                            if (drImg["EmpPhotoImage"].ToString() != "")
                            {
                                buff = (byte[])(drImg["EmpPhotoImage"]);
                                if (buff.Length > 0)
                                {
                                    picinfo = "data:image/jpeg:base64," + Convert.ToBase64String(buff);
                                    CountUpFp++;
                                }
                            }
                        }
                    }

                    CardNo10 = StrToHex(CardNo10);
                    if (CardNo10.Length > 10) CardNo10 = CardNo10.Substring(CardNo10.Length - 10, 10);

                    if (WeCardNo10 != 0) WeCardNoType = 2;
                    else WeCardNoType = 0;
                    searchOnePerson = new SearchOnePerson(Int32.Parse(MacSN), 0, EnrollNumber.ToString(), 0);
                    searchOnePersonCmd = new jsonBody<SearchOnePerson>("SearchPerson", searchOnePerson);
                    jsonString = JsonConvert.SerializeObject(searchOnePersonCmd);
                    IsUpdate = false;
                    ret = DeviceObject.objFK623.POST_GetResponse(selUrl, name, pwd, ref jsonString);
                    if (ret)
                    {
                        jsonBody<SearchPersonInfo> searchPersonInfo = JsonConvert.DeserializeObject<jsonBody<SearchPersonInfo>>(jsonString);
                        if (searchPersonInfo.info.CustomizeID == EnrollNumber)
                        {
                            IsUpdate = true;
                        }
                    }
                EEE:
                    if (IsUpdate)
                    {
                        editPerson = new EditPersonInfo(Convert.ToInt32(MacSN), 0, Convert.ToInt32(EnrollNumber), 0, EnrollName, 0, 1, 0, EmpCertNo, "", EmpPhoneNo, "",
                         EmpAddress, EmpMemo, WeCardNoType, WeCardNo10, CardNo10, Valid, "", ValidBegin, ValidEnd);
                        editPersonCmd = new Person<EditPersonInfo>("EditPerson", editPerson, picinfo);
                        jsonString = JsonConvert.SerializeObject(editPersonCmd);
                        ret = DeviceObject.objFK623.POST_GetResponse(updUrl, name, pwd, ref jsonString);
                    }
                    else
                    {
                        //增加人员
                        personInfo = new PersonInfo(Convert.ToInt32(MacSN), 0, EnrollName, 0, 1, 0, EmpCertNo, "", EmpPhoneNo, "",
                            EmpAddress, EmpMemo, WeCardNoType, WeCardNo10, CardNo10, Valid, Convert.ToInt32(EnrollNumber), "", ValidBegin, ValidEnd, "1", "1", "1", "1");
                        addPerson = new Person<PersonInfo>("AddPerson", personInfo, picinfo);
                        jsonString = JsonConvert.SerializeObject(addPerson);
                        ret = DeviceObject.objFK623.POST_GetResponse(addUrl, name, pwd, ref jsonString);
                    }

                    if (!ret)
                    {
                        if (DeviceObject.objFK623.SeaBodyStr().Equals(Pub.GetResText("", "FK_RUNERR_NO_OPEN_COMM", "")))
                        {
                            DialogResult MessRet = Pub.MessageBoxQuestion(DeviceObject.objFK623.SeaBodyStr() + "\r\n\r\n" +
                     Pub.GetResText(formCode, "MsgContinue", ""), MessageBoxButtons.YesNoCancel);
                            if (MessRet == DialogResult.Yes)
                                goto EEE;
                            else if (MessRet == DialogResult.Cancel)
                            {
                                ret = false;
                                break;
                            }
                            else
                                continue;
                        }
                        else
                        {
                            ID += "[" + EnrollNumber + "]" + DeviceObject.objFK623.SeaBodyStr() + "]";
                        }

                    }
                    ret = true;
                    Application.DoEvents();
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                string tmp = Pub.GetResText(formCode, "MsgUpInfo", "");
                if (ID != "")
                {
                    tmp += "  <" + Pub.GetResText(formCode, "UnsuccessfulEmpNo", "") + ID + ">  ";
                }
                MacMsg = string.Format(tmp, dtUploadcount.Rows.Count, CountUp, CountUpFp);
            }

            return ret;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectData(true);
        }

        private void btnUnselect_Click(object sender, EventArgs e)
        {
            SelectData(false);
        }
    }
}