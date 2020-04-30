using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSeaFaceInfo : frmSeaFaceBase
    {
        private bool AllowShowInit = false;
        private TDownSelectList[] selList = new TDownSelectList[0];
        private List<TDownInfoList> downList = new List<TDownInfoList>();
        private List<TDownInfoList> lossList = new List<TDownInfoList>();
        private List<TimeZone> timeList = new List<TimeZone>();
        private DataTable dtUpload = null;
        private DataTable dtUploadcount = null;

        protected override void InitForm()
        {
            formCode = "SeaFaceInfo";
            SetToolItemState("ItemImport", false);
            SetToolItemState("ItemExport", false);
            SetToolItemState("ItemPrint", false);
            SetToolItemState("ItemLine1", false);
            SetToolItemState("ItemTAG1", true);
            SetToolItemState("ItemTAG2", true);
            //SetToolItemState("ItemTAG3", true);
            SetToolItemState("ItemTAG4", false);
            SetToolItemState("ItemTAG5", true);
            SetToolItemState("ItemTAG6", true);
            SetToolItemState("ItemLine3", true);
            SetToolItemState("ItemTAGExt", true);
           
            AddExtDropDownItem("ItemPowerSetup", ItemPowerSetup_Click);
            //AddExtDropDownItem("ItemPowerDownload", ItemPowerDownload_Click);
            //AddExtDropDownItem("ItemPowerUpload", ItemPowerUpload_Click);
            AddExtDropDownItem("ItemDoorOpen", ItemDoorOpen_Click);
            AddExtDropDownItem("ItemClearInfoDim", ItemClearInfoDim_Click);
           // AddExtDropDownItem("ItemClearLossCard", ItemClearLossCard_Click);
            AddExtDropDownItem("ItemClearLog", ItemClearLog_Click);
            AddExtDropDownItem("ItemClearEmp", ItemClearEmp_Click);
            AddExtDropDownItem("ItemInitMac", ItemInitMac_Click);
            AddExtDropDownItem("ItemRebootMac", ItemRebootMac_Click);
            ShowTextMsg = true;
            base.InitForm();
        }

        public frmSeaFaceInfo()
        {
            InitializeComponent();
        }

        private void ItemPowerSetup_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            frmSeaPower frm = new frmSeaPower();
            frm.ShowDialog();

        }

        private void ItemPowerDownload_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            CurrentTool = ((ToolStripItem)sender).Text;
            ExecMacOprt(100);

        }

        private void ItemPowerUpload_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            CurrentTool = ((ToolStripItem)sender).Text;
            ExecMacOprt(101);

        }

        private void ItemDoorOpen_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            CurrentTool = ((ToolStripItem)sender).Text;
            ExecMacOprt(102);

        }

        private void ItemClearInfoDim_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            lossList.Clear();
            string sql = Pub.GetSQL(DBCode.DB_006001, new string[] { "33"});
            DataTableReader dr = null;
            bool IsError = false;
            TDownInfoList lst;
            try
            {
                dr = db.GetDataReader(sql);
                while (dr.Read())
                {
                    lst = new TDownInfoList(Convert.ToUInt32(dr["CardFingerNo"].ToString()), false);
                    lossList.Add(lst);
                }
            }
            catch (Exception E)
            {
                IsError = true;
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            if (IsError) return;
            CurrentTool = ((ToolStripItem)sender).Text;
            ExecMacOprt(103);

        }

        private void ItemClearLossCard_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            lossList.Clear();
            string sql = Pub.GetSQL(DBCode.DB_001003, new string[] { "0", Pub.GetSQL(DBCode.DB_001003, new string[] { "223" }) });
            DataTableReader dr = null;
            bool IsError = false;
            TDownInfoList lst;
            try
            {
                dr = db.GetDataReader(sql);
                while (dr.Read())
                {
                    lst = new TDownInfoList(Convert.ToUInt32(dr["CardFingerNo"].ToString()), false);
                    lossList.Add(lst);
                }
            }
            catch (Exception E)
            {
                IsError = true;
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            if (IsError) return;
            CurrentTool = ((ToolStripItem)sender).Text;
            ExecMacOprt(108);

        }

        private void ItemClearLog_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
           
            CurrentTool = ((ToolStripItem)sender).Text;
            ExecMacOprt(104);

        }
        private void ItemClearEmp_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;

            CurrentTool = ((ToolStripItem)sender).Text;
            ExecMacOprt(105);

        }

        private void ItemInitMac_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;

            CurrentTool = ((ToolStripItem)sender).Text;
            ExecMacOprt(106);

        }

        private void ItemRebootMac_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;

            CurrentTool = ((ToolStripItem)sender).Text;
            ExecMacOprt(107);

        }

        protected override void ExecItemAdd()
        {
            base.ExecItemAdd();
            frmSeaFaceInfoAdd frm = new frmSeaFaceInfoAdd(this.Text, CurrentTool, "");
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();

        }

        protected override void ExecItemEdit()
        {
            base.ExecItemEdit();
            frmSeaFaceInfoAdd frm = new frmSeaFaceInfoAdd(this.Text, CurrentTool, GetMacSysID());
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();

        }

        protected override void ExecItemTAG1()
        {
            base.ExecItemTAG1();
            ExecMacOprt(0);

        }

        protected override void ExecItemTAG2()
        {
            base.ExecItemTAG2();
            ExecMacOprt(1);

        }

        protected override void ExecItemTAG5()
        {

            base.ExecItemTAG5();
            ExecMacOprt(4);
        }

        protected override void ExecItemTAG6()
        {
            frmSeaFaceSelectEmp frm = new frmSeaFaceSelectEmp(this.Text, CurrentTool);
            if (frm.ShowDialog() != DialogResult.OK) return;
            selList = new TDownSelectList[frm.selList.Length];
            selList = frm.selList;
            dtUpload = null;
            string sql = Pub.GetSQL(DBCode.DB_002001, new string[] { "2016", "3", frm.selEmpSysID });
            string sqlcount = Pub.GetSQL(DBCode.DB_001003, new string[] { "36", frm.selEmpSysID });
            try
            {
                dtUpload = db.GetDataTable(sql);
                dtUploadcount = db.GetDataTable(sqlcount);
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
                return;
            }
            base.ExecItemTAG6();
            ExecMacOprt(5);
            dtUpload = null;

        }

        protected override void RefreshForm(bool State)
        {
            ItemTAG4.Visible = AllowShowInit;
            base.RefreshForm(State);
            SetContextMenuVisible(ItemTAG4.Name, AllowShowInit);
            SetContextMenuState();
        }

        protected override void GetDelSql(int rowIndex, ref List<string> sql)
        {
            string MacSN = dataGrid[1, rowIndex].Value.ToString();
            string ret = Pub.GetSQL(DBCode.DB_006001, new string[] { "1", MacSN });
            sql.Add(ret);
            ret = Pub.GetSQL(DBCode.DB_006001, new string[] { "26", MacSN });
            sql.Add(ret);
        }

        protected override string GetDelMsg(int rowIndex)
        {
            string ret = base.GetDelMsg(rowIndex);
            ret = dataGrid.Columns[2].HeaderText + "=" + dataGrid[2, rowIndex].Value.ToString();
            return ret;
        }

        protected override bool ExecMacCommand(byte flag, int MacSN, string url, string name, string pwd, ref string MacMsg)
        {
            bool ret = base.ExecMacCommand(flag, MacSN, url, name, pwd, ref MacMsg);
            switch (flag)
            {
                case 0:
                    ret = SyncTime(url, name, pwd);  //同步时间
                    break;
                case 1:
                    ret = ReadMacInfo(MacSN, url, name, pwd);//读取信息
                    break;
                case 4:
                    ret = DownloadInfo(url, name, pwd, MacSN.ToString(), ref MacMsg);//下载人员
                    break;
                case 5:
                    ret = UploadInfo(url, name, pwd, MacSN.ToString(), ref MacMsg);//上传人员
                    break;
                case 100:
                    ret = PowerDownload(MacSN, url, name, pwd, ref MacMsg);//权限下载
                    break;
                case 101:
                    ret = PowerUpload(MacSN, url, name, pwd, ref MacMsg);//权限上传
                    break;
                case 102:
                    ret = SetDoorState(MacSN, url, name, pwd, ref MacMsg);//开门
                    break;
                case 103:
                    ret = ClearInfoDim(url, name, pwd, MacSN.ToString(), ref MacMsg);//清除离职登记人员资料
                    break;
                case 104:
                    ret = ClearData(url, name, pwd);//删除刷卡记录
                    break;
                case 105:
                    ret = ClearInfo(url, name, pwd);//清除登记人员资料
                    break;
                case 106:
                    ret = InitDevice(url, name, pwd);//初始化
                    break;
                case 107:
                    ret = RebootDevice(MacSN, url, name, pwd, ref MacMsg);//重启
                    break;
                case 108:
                    ret = ClearLossCard(url, name, pwd, MacSN.ToString(), ref MacMsg);//清除挂失卡
                    break;
            }

            return ret;
        }

        private bool RebootDevice(int MacSN, string url, string name, string pwd, ref string MacMsg)
        {
            bool ret;
            url = url + "action/RebootDevice";

            RebootDeviceCmd rebootDeviceCmd = new RebootDeviceCmd(MacSN, 1);

            jsonBody<RebootDeviceCmd> jsonBodyRebootDeviceCmd = new jsonBody<RebootDeviceCmd>("RebootDevice", rebootDeviceCmd);
            string jsonString = JsonConvert.SerializeObject(jsonBodyRebootDeviceCmd);
            ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref jsonString);
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

        private bool ClearData(string url, string name, string pwd)
        {
            bool ret = false;
            url = url + "action/SetFactoryDefault";
            SeaSeriesInitDevice seaSeriesInitDevice = new SeaSeriesInitDevice(0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0);
            jsonBody<SeaSeriesInitDevice> SeaSeriesInitDeviceJson = new jsonBody<SeaSeriesInitDevice>("SetFactoryDefault", seaSeriesInitDevice);
            string jsonString = JsonConvert.SerializeObject(SeaSeriesInitDeviceJson);
            ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref jsonString);

            return ret;
        }

        private void frmKQFaceInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Alt)
            {
                int h = SystemInfo.MainHandle.ToInt32();
                switch (e.KeyCode)
                {
                    case Keys.I:
                        AllowShowInit = true;
                        RefreshForm(dataGrid.Enabled);
                        break;
                }
            }
        }

        private bool ReadMacInfo(int MacSN, string url, string name, string pwd)
        {

            string infoUrl = url + "action/GetMachineInfo";
            bool ret = false;
            string jsonBodyStr = "";
            ret = DeviceObject.objFK623.POST_GetResponse(infoUrl, name, pwd, ref jsonBodyStr);
            string msg = "";
            if (ret)
            {
                jsonBody<GetMachineInfo> getMachineInfo = JsonConvert.DeserializeObject<jsonBody<GetMachineInfo>>(jsonBodyStr);
                msg = string.Format(Pub.GetResText("", "MsgReadMacInfo", ""), getMachineInfo.info.PersonNum, getMachineInfo.info.CardNum, getMachineInfo.info.RecordNum);
                msg = Pub.GetResText(formCode, "MacSN", "") + ": " + MacSN + "\r\n" + msg;
                ShowMsg(msg);
            }

            return ret;
        }

        private bool InitDevice(string url, string name, string pwd)
        {
            bool ret = false;
            url = url + "action/SetFactoryDefault";
            SeaSeriesInitDevice seaSeriesInitDevice = new SeaSeriesInitDevice(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);
            jsonBody<SeaSeriesInitDevice> SeaSeriesInitDeviceJson = new jsonBody<SeaSeriesInitDevice>("SetFactoryDefault", seaSeriesInitDevice);
            string jsonString = JsonConvert.SerializeObject(SeaSeriesInitDeviceJson);
            ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref jsonString);
            return ret;
        }

        private void CountFingerInfo(int BackupNumber, ref int FingerCount, ref int PSWCount, ref int CardCount,
          ref int FaceCount, ref int PalmVeinCnt)
        {
            switch (BackupNumber)
            {
                case (int)FKBackup.BACKUP_FP_0:
                case (int)FKBackup.BACKUP_FP_1:
                case (int)FKBackup.BACKUP_FP_2:
                case (int)FKBackup.BACKUP_FP_3:
                case (int)FKBackup.BACKUP_FP_4:
                case (int)FKBackup.BACKUP_FP_5:
                case (int)FKBackup.BACKUP_FP_6:
                case (int)FKBackup.BACKUP_FP_7:
                case (int)FKBackup.BACKUP_FP_8:
                case (int)FKBackup.BACKUP_FP_9:
                    FingerCount++;
                    break;
                case (int)FKBackup.BACKUP_PSW:
                    PSWCount++;
                    break;
                case (int)FKBackup.BACKUP_CARD:
                    CardCount++;
                    break;
                case (int)FKBackup.BACKUP_FACE:
                    FaceCount++;
                    break;
                case (int)FKBackup.BACKUP_PALMVEIN_0:
                case (int)FKBackup.BACKUP_PALMVEIN_1:
                case (int)FKBackup.BACKUP_PALMVEIN_2:
                case (int)FKBackup.BACKUP_PALMVEIN_3:
                    PalmVeinCnt++;
                    break;
            }
        }

        private void AddDownInfo(TDownInfoList downInfo)
        {
            bool isFind = false;
            for (int i = 0; i < downList.Count; i++)
            {
                if (downList[i].EnrollNumber == downInfo.EnrollNumber)
                {
                    isFind = true;
                    break;
                }
            }
            if (!isFind) downList.Add(downInfo);

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
        private void SetUploadSuccess(UInt32 EnrollNumber)
        {
            for (int i = 0; i < selList.Length; i++)
            {
                if (selList[i].EnrollNumber == EnrollNumber)
                {
                    selList[i].IsSuccess = true;
                    return;
                }
            }
        }

        private bool GetUploadSuccess(UInt32 EnrollNumber)
        {
            bool ret = false;
            for (int i = 0; i < selList.Length; i++)
            {
                if (selList[i].EnrollNumber == EnrollNumber)
                {
                    ret = selList[i].IsSuccess;
                    return ret;
                }
            }

            return ret;
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
            byte[] buffCard = null;
            byte[] buff = null;
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
            if (dtUploadcount == null)
            {
                string tmp = Pub.GetResText(formCode, "MsgUpInfo", "");
                MacMsg = string.Format(tmp, 0, CountUp, CountUpFp);
                return true;
            }
            try
            {
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
                    buffCard = null;
                    CardNo10 = "";
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_006001, new string[] { "47", EmpSysID,"11" }));
                    if (dr.Read())
                    {
                        buffCard = (byte[])dr["FaceTemplate"];
                        if(buffCard.Length > 0)
                        {
                            EncAndDec.PWDAndCard(11, buffCard, ref CardNo10);
                        }
                    }
                    dr.Close();

                    if(string.IsNullOrEmpty(CardNo10))
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

        private bool ClearLossCard(string url, string name, string pwd, string MacSN, ref string MacMsg)
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

            byte[] buff = null;
            EditPersonInfo editPerson = null;
            Person<EditPersonInfo> editPersonCmd = null;

            SearchOnePerson searchOnePerson = null;
            jsonBody<SearchOnePerson> searchOnePersonCmd = null;
            string jsonString = "";
            List<int> CustomizeIDList = new List<int>();
            string ID = "";
            bool IsUpdate = false;

            DataTableReader drImg = null;
            string ESysID = "";
            for (int i = 0; i < lossList.Count; i++)
            {
                ESysID += "'" + lossList[i].EnrollNumber + "',";
            }
            ESysID = ESysID.Substring(0, ESysID.Length - 1);

           
            try
            {
                dtUploadcount = db.GetDataTable(Pub.GetSQL(DBCode.DB_006001, new string[] { "48", ESysID }));
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
                         EmpAddress, EmpMemo, 0, 0, "", Valid, "", ValidBegin, ValidEnd);
                        editPersonCmd = new Person<EditPersonInfo>("EditPerson", editPerson, picinfo);
                        jsonString = JsonConvert.SerializeObject(editPersonCmd);
                        ret = DeviceObject.objFK623.POST_GetResponse(updUrl, name, pwd, ref jsonString);
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


        private bool PowerDownload(int MacSN, string url, string name, string pwd, ref string MacMsg)
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
                MacMsg = string.Format(tmp,  EmpCount, EmpCount, PersonNum);
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
        private bool PowerUpload(int MacSN, string url, string name, string pwd, ref string MacMsg)
        {
            bool ret = false;
            UInt32 EnrollNumber = 0;
            string addUrl = url + "action/AddPerson";
            string delUrl = url + "action/SearchPerson";
            string UpdUrl = url + "action/EditPerson";

            byte[] fpData = new byte[0];
            string EnrollName = "";
            string EmpNo = "";

            string EmpCertNo = "";
            string CardNo10 = "";
            long WeCardNo10 = 0;
            int WeCardNoType = 0;
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
            DataTable dtUploadcount = db.GetDataTable(Pub.GetSQL(DBCode.DB_006001, new string[] { "30", MacSN.ToString() }));
            if (dtUploadcount == null || dtUploadcount.Rows.Count == 0)
            {
                string tmp = Pub.GetResText(formCode, "ItemPowerUpload", "" );
                MacMsg = string.Format(tmp, 0, CountUp, CountUpFp);
                return true;
            }

            try
            {
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
                    //CardNo10 = dtUploadcount.Rows[i]["OtherCardNo"].ToString();

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

                    searchOnePerson  = new SearchOnePerson(MacSN, 0, EnrollNumber.ToString(), 0);
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
                MacMsg = string.Format(tmp, dtUploadcount.Rows.Count, CountUp, CountUpFp);
            }

            return ret;
        }

        private bool SetDoorState(int MacSN, string url, string name, string pwd, ref string MacMsg)
        {
            bool ret;
            url = url + "action/OpenDoor";

            OpenDoorCmd openDoorCmd = new OpenDoorCmd(MacSN, 0, 1);

            jsonBody<OpenDoorCmd> jsonBodyOpenDoorCmd = new jsonBody<OpenDoorCmd>("OpenDoor", openDoorCmd);
            string jsonString = JsonConvert.SerializeObject(jsonBodyOpenDoorCmd);
            ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref jsonString);

            return ret;
        }
        private bool KQFaceDoorStateGet(int MacSN, ref string MacMsg)
        {
            int v = 0;
            bool ret = DeviceObject.objFK623.GetDoorStatus(ref v);
            if (ret)
            {
                string state = "";
                switch (v)
                {
                    case (int)FKDoor.DOOR_CONTROLRESET:
                        state = Pub.GetResText(formCode, "FK_DOOR_CONTROLRESET", "");
                        break;
                    case (int)FKDoor.DOOR_OPEND:
                        state = Pub.GetResText(formCode, "FK_DOOR_OPEND", "");
                        break;
                    case (int)FKDoor.DOOR_CLOSED:
                        state = Pub.GetResText(formCode, "FK_DOOR_CLOSED", "");
                        break;
                    case (int)FKDoor.DOOR_COMMNAD:
                        state = Pub.GetResText(formCode, "FK_DOOR_COMMNAD", "");
                        break;
                    default:
                        state = Pub.GetResText(formCode, "FK_DOOR_UNKNOWN", "");
                        break;
                }
                MacMsg = state;
            }

            return ret;
        }

        private bool ClearInfoDim(string url, string name, string pwd, string MacSN,ref string MacMsg)
        {
            bool ret = false;
            url = url + "action/DeletePerson";
            UInt32 EnrollNumber = 0;
            int BakNo = 0;
            DeletePerson deletePersonInfo = null;
            jsonBody<DeletePerson> deletePerson = null;
            string jsonString = "";
            string StatusMsg = lblMsg.Text;
            List<int> CustomizeIDList = new List<int>();
            List<int> IDList = new List<int>();
            try
            {
                for (int i = 0; i < lossList.Count; i++)
                {
                    CustomizeIDList = new List<int>();
                    EnrollNumber = lossList[i].EnrollNumber;
                    lblMsg.Text = StatusMsg + Pub.GetResText(formCode, "MsgFingerInfo", "") +
                      string.Format(" - {0}/{1}  {2}-{3}", i + 1, lossList.Count, EnrollNumber, BakNo);
                    if (IDList.Contains(Convert.ToInt32(EnrollNumber)))
                        continue;
                    IDList.Add(Convert.ToInt32(EnrollNumber));
                    CustomizeIDList.Add(Convert.ToInt32(EnrollNumber));
                    //删除人员
                    deletePersonInfo = new DeletePerson(Convert.ToInt32(MacSN), CustomizeIDList.Count, 0, CustomizeIDList);

                    deletePerson = new jsonBody<DeletePerson>("DeletePerson", deletePersonInfo);
                    jsonString = JsonConvert.SerializeObject(deletePerson);
                    ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd, ref jsonString);
                    Application.DoEvents();
                }

                ret = true;
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            if (ret) MacMsg = lossList.Count.ToString();
            return ret;
        }
    
    }
}