using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmKQFaceInfo : frmKQFaceBase
    {
        private bool AllowShowInit = false;
        private TDownSelectList[] selList = new TDownSelectList[0];
        private List<TDownInfoList> downList = new List<TDownInfoList>();
        private List<TDownInfoList> lossList = new List<TDownInfoList>();
        private List<TimeZone> timeList = new List<TimeZone>();
        private DataTable dtUpload = null;

        protected override void InitForm()
        {
            formCode = "KQFaceInfo";
            SetToolItemState("ItemImport", false);
            SetToolItemState("ItemExport", false);
            SetToolItemState("ItemPrint", false);
            SetToolItemState("ItemLine1", false);
            SetToolItemState("ItemTAG1", true);
            SetToolItemState("ItemTAG2", true);
            SetToolItemState("ItemTAG3", true);
            SetToolItemState("ItemTAG4", true);
            SetToolItemState("ItemTAG5", true);
            SetToolItemState("ItemTAG6", true);
            SetToolItemState("ItemLine3", true);
            SetToolItemState("ItemTAGExt", true);
            AddExtDropDownItem("ItemPassTimeSetup", ItemPassTimeSetup_Click);
            AddExtDropDownItem("ItemPassTimeDownload", ItemPassTimeDownload_Click);
            AddExtDropDownItem("ItemPassTimeUpload", ItemPassTimeUpload_Click);
            AddExtDropDownItem("ItemPowerSetup", ItemPowerSetup_Click);
            AddExtDropDownItem("ItemPowerDownload", ItemPowerDownload_Click);
            AddExtDropDownItem("ItemPowerUpload", ItemPowerUpload_Click);
            AddExtDropDownItem("ItemDoorOpen", ItemDoorOpen_Click);
            AddExtDropDownItem("ItemDoorClose", ItemDoorClose_Click);
            AddExtDropDownItem("ItemClearLossCard", ItemClearLossCard_Click);
            AddExtDropDownItem("ItemClearInfoDim", ItemClearInfoDim_Click);
            ShowTextMsg = true;
            base.InitForm();
        }

        public frmKQFaceInfo()
        {
            InitializeComponent();
        }

        private void ItemPassTimeSetup_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            CurrentTool = ((ToolStripItem)sender).Text;
            frmKQPassTime frm = new frmKQPassTime(CurrentTool);
            frm.ShowDialog();
            
        }

        private void ItemPassTimeDownload_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            CurrentTool = ((ToolStripItem)sender).Text;
            ExecMacOprt(100);
            
        }

        private void ItemPassTimeUpload_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            CurrentTool = ((ToolStripItem)sender).Text;
            timeList.Clear();
            TimeZone tz;
            DataTableReader dr = null;
            string tmp;
            bool IsError = false;
            try
            {
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002001, new string[] { "3000" }));
                while (dr.Read())
                {
                    tz = new TimeZone();
                    tz.Init();
                    tz.TimeZoneID = Convert.ToInt32(dr["PassTimeID"].ToString());
                    for (int i = 0; i < (int)FKMax.TIME_SLOT_COUNT; i++)
                    {
                        tmp = dr["T" + (i + 1).ToString() + "S"].ToString();
                        tz.TimeSlots[i].StartHour = Convert.ToByte(tmp.Substring(0, 2));
                        tz.TimeSlots[i].StartMinute = Convert.ToByte(tmp.Substring(3, 2));
                        tmp = dr["T" + (i + 1).ToString() + "E"].ToString();
                        tz.TimeSlots[i].EndHour = Convert.ToByte(tmp.Substring(0, 2));
                        tz.TimeSlots[i].EndMinute = Convert.ToByte(tmp.Substring(3, 2));
                    }
                    timeList.Add(tz);
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
            ExecMacOprt(101);
           
        }

        private void ItemPowerSetup_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            CurrentTool = ((ToolStripItem)sender).Text;
            frmKQPower frm = new frmKQPower(CurrentTool);
            frm.ShowDialog();
           
        }

        private void ItemPowerDownload_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            CurrentTool = ((ToolStripItem)sender).Text;
            ExecMacOprt(102);
            
        }

        private void ItemPowerUpload_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            CurrentTool = ((ToolStripItem)sender).Text;
            ExecMacOprt(103);
            
        }

        private void ItemDoorOpen_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            CurrentTool = ((ToolStripItem)sender).Text;
            ExecMacOprt(104);
           
        }

        private void ItemDoorClose_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            CurrentTool = ((ToolStripItem)sender).Text;
            ExecMacOprt(105);
            
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
            ExecMacOprt(106);
            
        }

        private void ItemClearInfoDim_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            string sql = Pub.GetSQL(DBCode.DB_006001, new string[] { "33" });
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
            ExecMacOprt(107);

        }

        protected override void ExecItemAdd()
        {
            base.ExecItemAdd();
            frmKQFaceInfoAdd frm = new frmKQFaceInfoAdd(this.Text, CurrentTool, "");
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
           
        }

        protected override void ExecItemEdit()
        {
            base.ExecItemEdit();
            frmKQFaceInfoAdd frm = new frmKQFaceInfoAdd(this.Text, CurrentTool, GetMacSysID());
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

        protected override void ExecItemTAG3()
        {
            if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "MsgClearManager", ""))) return;
            base.ExecItemTAG3();
            ExecMacOprt(2);
            
        }

        protected override void ExecItemTAG4()
        {
            if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "MsgInit", ""))) return;
            base.ExecItemTAG4();
            ExecMacOprt(3);
            
        }

        protected override void ExecItemTAG5()
        {
            /*DialogResult MessRet = Pub.MessageBoxQuestion(Pub.GetResText(formCode, "MsgFaceClearDBDown", ""),
              MessageBoxButtons.YesNoCancel);
            if (MessRet == DialogResult.Cancel) return;
            if (MessRet == DialogResult.Yes)
            {
              try
              {
                string sql = Pub.GetSQL(DBCode.DB_002001, new string[] { "2015" });
                db.ExecSQL(sql);
              }
              catch (Exception E)
              {
                Pub.ShowErrorMsg(E);
                return;
              }
            }*/
            base.ExecItemTAG5();
            ExecMacOprt(4);
            
        }

        protected override void ExecItemTAG6()
        {
            frmKQFaceSelectEmp frm = new frmKQFaceSelectEmp(this.Text, CurrentTool);
            if (frm.ShowDialog() != DialogResult.OK) return;
            selList = new TDownSelectList[frm.selList.Length];
            selList = frm.selList;
            dtUpload = null;
            string sql = Pub.GetSQL(DBCode.DB_002001, new string[] { "2016", "3", frm.selEmpSysID });
            try
            {
                dtUpload = db.GetDataTable(sql);
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
            string ret = Pub.GetSQL(DBCode.DB_002001, new string[] { "2001", MacSN });
            sql.Add(ret);
            ret = Pub.GetSQL(DBCode.DB_002001, new string[] { "4007", MacSN });
            sql.Add(ret);
        }

        protected override string GetDelMsg(int rowIndex)
        {
            string ret = base.GetDelMsg(rowIndex);
            ret = dataGrid.Columns[2].HeaderText + "=" + dataGrid[2, rowIndex].Value.ToString();
            return ret;
        }

        protected override bool ExecMacCommand(byte flag, int MacSN, byte MacType, ref string MacMsg)
        {
            bool ret = base.ExecMacCommand(flag, MacSN, MacType, ref MacMsg);
            switch (flag)
            {
                case 0:
                    ret = SyncTime(MacType);
                    break;
                case 1:
                    ret = ReadMacInfo(MacSN, MacType);
                    break;
                case 2:
                    ret = ClearManager(MacType);
                    break;
                case 3:
                    ret = InitDevice(MacType);
                    break;
                case 4:
                    ret = DownloadInfo(MacType, ref MacMsg);
                    break;
                case 5:
                    ret = UploadInfo(MacSN, MacType, ref MacMsg);
                    break;
                case 100:
                    ret = PassTimeDownload(MacSN, MacType, ref MacMsg);
                    break;
                case 101:
                    ret = PassTimeUpload(MacSN, MacType, ref MacMsg);
                    break;
                case 102:
                    ret = PowerDownload(MacSN, MacType, ref MacMsg);
                    break;
                case 103:
                    ret = PowerUpload(MacSN, MacType, ref MacMsg);
                    break;
                case 104:
                    ret = SetDoorState(true, MacSN, ref MacMsg);
                    break;
                case 105:
                    ret = SetDoorState(false, MacSN, ref MacMsg);
                    break;
                case 106:
                    ret = ClearLossCard(MacSN, MacType, ref MacMsg);
                    break;
                case 107:
                    ret = ClearInfoDim(MacSN, MacType, ref MacMsg);
                    break;
            }
            
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

        private bool ReadMacInfo(int MacSN, byte MacType)
        {
            bool ret = false;
            string msg = "";
            ret = DeviceObject.objFK623.GetDeviceInfo(ref msg);
            if (ret)
            {
                msg = Pub.GetResText(formCode, "MacSN", "") + ": " + MacSN + "\r\n" + msg;
                ShowMsg(msg);
            }
            return ret;
        }

        private bool ClearManager(byte MacType)
        {
            bool ret = false;
            ret = DeviceObject.objFK623.BenumbAllManager();
            return ret;
        }

        private bool InitDevice(byte MacType)
        {
            bool ret = false;
            ret = DeviceObject.objFK623.ClearKeeperData();
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

        private bool DownloadInfo(byte MacType, ref string MacMsg)
        {
            bool ret = false;
            UInt32 EnrollNumber = 0;
            int BackupNumber = 0;
            int Privilege = 0;
            int EnableFlag = 0;
            int PasswordData = 0;
            byte[] fpData = new byte[(int)FKMax.FK_FaceDataSize];
            string EnrollName = "";
            DialogResult MessRet;
            string EmpSysID = "";
            bool ReqName = false;
            int FingerCount = 0;
            int PSWCount = 0;
            int CardCount = 0;
            int FaceCount = 0;
            int PalmVeinCnt = 0;
            int EmpCount = 0;
            int ErrCode = 0;
            string StatusMsg = lblMsg.Text;
            downList.Clear();
            if (!DeviceObject.objFK623.IsOpen) DeviceObject.objFK623.Open();
            if (DeviceObject.objFK623.IsOpen)
            {
                if (DeviceObject.objFK623.EnableDevice(0) == (int)FKRun.RUN_SUCCESS)
                {
                    ret = DeviceObject.objFK623.GetDeviceStatusForIndex(FKDS.GET_USERS, ref EmpCount);
                    if (!ret) goto DeviceExit;
                    DeviceObject.objFK623.RunCode = DeviceObject.objFK623.ReadAllUserID();
                    ret = DeviceObject.objFK623.RunCode == (int)FKRun.RUN_SUCCESS;
                    if (!ret) goto DeviceExit;
                    do
                    {
                    FFF:
                        DeviceObject.objFK623.RunCode = DeviceObject.objFK623.GetAllUserID(ref EnrollNumber,
                          ref BackupNumber, ref Privilege, ref EnableFlag);
                        if (DeviceObject.objFK623.RunCode != (int)FKRun.RUN_SUCCESS)
                        {
                            if (DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_DATAARRAY_END)
                                DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                            break;
                        }
                    EEE:
                        DeviceObject.objFK623.RunCode = DeviceObject.objFK623.GetEnrollData(EnrollNumber, BackupNumber,
                          ref Privilege, fpData, ref PasswordData);
                        if (DeviceObject.objFK623.RunCode != (int)FKRun.RUN_SUCCESS)
                        {
                            ErrCode = DeviceObject.objFK623.RunCode;
                            if (ErrCode == (int)FKRun.RUNERR_NO_OPEN_COMM || ErrCode == (int)FKRun.RUNERR_WRITE_FAIL)
                            {
                                if (DeviceObject.objFK623.ReOpen()) goto EEE;
                                DeviceObject.objFK623.RunCode = ErrCode;
                            }
                            MessRet = Pub.MessageBoxQuestion(DeviceObject.objFK623.ErrMsg + "\r\n\r\n" +
                              Pub.GetResText(formCode, "MsgContinue", ""), MessageBoxButtons.YesNoCancel);
                            if (MessRet == DialogResult.Yes)
                                goto EEE;
                            else if (MessRet == DialogResult.Cancel)
                                break;
                            else
                                goto FFF;
                        }
                        CountFingerInfo(BackupNumber, ref FingerCount, ref PSWCount, ref CardCount, ref FaceCount, ref PalmVeinCnt);
                        db.SaveEnrollToDB(EnrollNumber, BackupNumber, EnableFlag, Privilege, PasswordData, fpData,
                          EnrollName, ref ReqName);
                        AddDownInfo(new TDownInfoList(EnrollNumber, ReqName));
                        lblMsg.Text = StatusMsg + Pub.GetResText(formCode, "MsgFingerInfo", "") +
                          string.Format(" - {2}/{3}  [{0}: {1}]", EnrollNumber, BackupNumber, downList.Count, EmpCount);
                        Application.DoEvents();
                    }
                    while (true);
                    byte[] buff = new byte[0];
                    StatusMsg = StatusMsg + Pub.GetResText(formCode, "MsgFingerName", "");
                    for (int i = 0; i < downList.Count; i++)
                    {
                        EnrollNumber = downList[i].EnrollNumber;
                        lblMsg.Text = StatusMsg + string.Format(" - {1}/{2}  [{0}]", EnrollNumber, i + 1, downList.Count);
                        if (downList[i].ReqName)
                        {
                            EnrollName = "";
                            DeviceObject.objFK623.GetUserName(EnrollNumber, ref EnrollName);
                            if (EnrollName != "") db.SaveEmpNameByFinger(EnrollNumber, EnrollName);
                        }
                        if (db.GetEmpSysID(EnrollNumber, ref EmpSysID))
                        {
                            if (DeviceObject.objFK623.GetEnrollPhoto(EnrollNumber, ref buff) && buff.Length > 0)
                            {
                                db.UpdateByteData(Pub.GetSQL(DBCode.DB_001003, new string[] { "10", EmpSysID }), "EmpPhotoImage", buff);
                            }
                        }
                        buff = null;
                        Application.DoEvents();
                    }
                }
            DeviceExit:
                DeviceObject.objFK623.EnableDevice(1);
            }
            DeviceObject.objFK623.Close();
            ret = DeviceObject.objFK623.RunCode == (int)FKRun.RUN_SUCCESS;
            if (ret)
            {
                string tmp = Pub.GetResText(formCode, "MsgDownInfo", "");
                MacMsg = string.Format(tmp, downList.Count, FingerCount, FaceCount, PSWCount, CardCount, PalmVeinCnt);
            }
            db.UpdateEmpInfoCount(this.Text);
            
            return ret;
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

        private bool UploadInfo(int MacSN, byte MacType, ref string MacMsg)
        {
            bool ret = false;
            UInt32 EnrollNumber = 0;
            string CardID = "";
            string CardPWD = "";
            int BackupNumber = 0;
            int Privilege = 0;
            int PasswordData = 0;
            int nPhotoSize = 0;
            byte[] fpData = new byte[0];
            string EnrollName = "";
            DialogResult MessRet;
            bool SupportFlag = false;
            bool IsSupportPhoto = true;
            string StatusMsg = lblMsg.Text;
            int CountUpFp = 0;
            int CountUp = 0;
            int ErrCode = 0;
            bool IsReOpen = false;
            try
            {
                if (!DeviceObject.objFK623.IsOpen) DeviceObject.objFK623.Open();
                if (DeviceObject.objFK623.IsOpen)
                {
                    if (DeviceObject.objFK623.EnableDevice(0) == (int)FKRun.RUN_SUCCESS)
                    {
                        for (int i = 0; i < dtUpload.Rows.Count; i++)
                        {
                            EnrollNumber = Convert.ToUInt32(dtUpload.Rows[i]["FaceNo"].ToString());
                            CardID = dtUpload.Rows[i]["CardPhysicsNo10"].ToString();
                            CardPWD = dtUpload.Rows[i]["CardPWD"].ToString();
                            BackupNumber = Convert.ToInt32(dtUpload.Rows[i]["FaceBkNo"].ToString());
                            Privilege = 0;
                            int.TryParse(dtUpload.Rows[i]["FacePrivilege"].ToString(), out Privilege);
                            EnrollName = dtUpload.Rows[i]["EmpName"].ToString();
                            lblMsg.Text = StatusMsg + Pub.GetResText(formCode, "MsgFingerInfo", "") +
                              string.Format(" - {3}/{4}  {0}[{1}: {2}]", EnrollName, EnrollNumber, BackupNumber,
                              i + 1, dtUpload.Rows.Count);
                            byte[] buff = new byte[0];
                            if (dtUpload.Rows[i]["FaceTemplate"].ToString() != "") buff = (byte[])dtUpload.Rows[i]["FaceTemplate"];
                            if (BackupNumber >= (int)FKBackup.BACKUP_FP_0 && BackupNumber <= (int)FKBackup.BACKUP_FP_9)
                            {
                                fpData = new byte[(int)FKMax.FK_FPDataSize];
                            }
                            else if (BackupNumber == (int)FKBackup.BACKUP_PSW)
                            {
                                fpData = new byte[(int)FKMax.FK_PasswordDataSize];
                                string xxx = "";
                                EncAndDec.PWDAndCard(BackupNumber, buff, ref xxx);
                                if (CardPWD != "" && CardPWD != "000000" && CardPWD != xxx) buff = EncAndDec.getPWD(CardPWD);
                                if (buff.Length == 0 && (CardPWD == "" || CardPWD == "000000")) continue;
                                if (buff.Length == 0) buff = EncAndDec.getPWD(CardPWD);
                            }
                            else if (BackupNumber == (int)FKBackup.BACKUP_CARD)
                            {
                                fpData = new byte[(int)FKMax.FK_PasswordDataSize];
                                string xxx = "";
                                EncAndDec.PWDAndCard(BackupNumber, buff, ref xxx);
                                if (CardID != "" && CardID != xxx) buff = EncAndDec.getCard(CardID);
                                if (buff.Length == 0 && CardID == "") continue;
                                if (buff.Length == 0) buff = EncAndDec.getCard(CardID);
                            }
                            else if (BackupNumber == (int)FKBackup.BACKUP_FACE)
                            {
                                fpData = new byte[(int)FKMax.FK_FaceDataSize];
                            }
                            else if (BackupNumber >= (int)FKBackup.BACKUP_PALMVEIN_0 && BackupNumber <= (int)FKBackup.BACKUP_PALMVEIN_3)
                            {
                                fpData = new byte[(int)FKMax.PALMVEINDataSize];
                            }
                            else if (BackupNumber == (int)FKBackup.BACKUP_VEIN_0)
                            {
                                fpData = new byte[(int)FKMax.FK_VeinDataSize];
                            }
                            Array.Copy(buff, fpData, fpData.Length);
                        EEE:
                            DeviceObject.objFK623.IsSupportedEnrollData(BackupNumber, ref SupportFlag);
                            if (SupportFlag)
                                DeviceObject.objFK623.RunCode = DeviceObject.objFK623.PutEnrollData(EnrollNumber, BackupNumber,
                                  Privilege, fpData, PasswordData);
                            else if (!IsReOpen)
                                DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                            if (DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_DATADOUBLE)
                            {
                                DeviceObject.objFK623.DeleteEnrollData(EnrollNumber, BackupNumber);
                                goto EEE;
                            }
                            if (DeviceObject.objFK623.RunCode != (int)FKRun.RUN_SUCCESS)
                            {
                                if (GetUploadSuccess(EnrollNumber) || DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_INVALID_PARAM)
                                {
                                    DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                                    continue;
                                }
                                if (DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_MEMORYOVER)
                                {
                                    DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                                    break;
                                }
                                ErrCode = DeviceObject.objFK623.RunCode;
                                IsReOpen = false;
                                if (ErrCode == (int)FKRun.RUNERR_NO_OPEN_COMM || ErrCode == (int)FKRun.RUNERR_WRITE_FAIL)
                                {
                                    IsReOpen = true;
                                    if (DeviceObject.objFK623.ReOpen()) goto EEE;
                                    DeviceObject.objFK623.RunCode = ErrCode;
                                }
                                MessRet = Pub.MessageBoxQuestion(DeviceObject.objFK623.ErrMsg + "\r\n\r\n" +
                                  Pub.GetResText(formCode, "MsgContinue", ""), MessageBoxButtons.YesNoCancel);
                                if (MessRet == DialogResult.Yes)
                                    goto EEE;
                                else if (MessRet == DialogResult.Cancel)
                                    break;
                                else
                                    continue;
                            }
                            else
                            {
                                CountUpFp++;
                            }
                            SetUploadSuccess(EnrollNumber);
                            Application.DoEvents();
                        }
                        if (DeviceObject.objFK623.RunCode == (int)FKRun.RUN_SUCCESS)
                        {
                            if (dtUpload.Rows.Count > 0) DeviceObject.objFK623.RunCode = DeviceObject.objFK623.SaveEnrollData();
                            StatusMsg = StatusMsg + Pub.GetResText(formCode, "MsgFingerName", "");
                            for (int i = 0; i < selList.Length; i++)
                            {
                                if (selList[i].IsSuccess)
                                {
                                    lblMsg.Text = StatusMsg + string.Format(" - {2}/{3}  {0}[{1}]", selList[i].EnrollName, EnrollNumber,
                                      i + 1, selList.Length);
                                ContinueName:
                                    if (!DeviceObject.objFK623.SetUserName(selList[i].EnrollNumber, selList[i].EnrollName, ref ErrCode))
                                    {
                                        if (ErrCode == (int)FKRun.RUNERR_NO_OPEN_COMM || ErrCode == (int)FKRun.RUNERR_WRITE_FAIL)
                                        {
                                            if (DeviceObject.objFK623.ReOpen()) goto ContinueName;
                                        }
                                        MessRet = Pub.MessageBoxQuestion(DeviceObject.objFK623.GetRunMsg(ErrCode) + "\r\n\r\n" +
                                          Pub.GetResText(formCode, "MsgContinue", ""), MessageBoxButtons.YesNo);
                                        if (MessRet == DialogResult.Yes)
                                            goto ContinueName;
                                        else
                                            break;
                                    }
                                    CountUp++;
                                    if (IsSupportPhoto)
                                    {
                                        DataTableReader drPhoto = null;
                                        try
                                        {
                                            drPhoto = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "104",
                        selList[i].EmpSysID }));
                                            if (drPhoto.Read())
                                            {
                                                if (drPhoto["EmpPhotoImage"].ToString() != "")
                                                {
                                                    byte[] buf = (byte[])(drPhoto["EmpPhotoImage"]);
                                                    if (buf.Length > 0)
                                                    {
                                                        nPhotoSize = buf.Length;
                                                        IsSupportPhoto = DeviceObject.objFK623.SetEnrollPhoto(selList[i].EnrollNumber, buf, nPhotoSize);
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
                                            if (drPhoto != null) drPhoto.Close();
                                            drPhoto = null;
                                        }
                                    }
                                }
                                Application.DoEvents();
                            }
                            ret = true;
                        }
                    }
                    DeviceObject.objFK623.EnableDevice(1);
                }
                DeviceObject.objFK623.Close();
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            if (ret)
            {
                string tmp = Pub.GetResText(formCode, "MsgUpInfo", "");
                MacMsg = string.Format(tmp, selList.Length, CountUp, CountUpFp);
            }
           
            return ret;
        }

        private bool PassTimeDownload(int MacSN, byte MacType, ref string MacMsg)
        {
            string StatusMsg = lblMsg.Text;
            bool ret = false;
            int count = 0;
            if (!DeviceObject.objFK623.IsOpen) DeviceObject.objFK623.Open();
            if (DeviceObject.objFK623.IsOpen)
            {
                if (DeviceObject.objFK623.EnableDevice(0) == (int)FKRun.RUN_SUCCESS)
                {
                    List<TimeZone> tzList = new List<TimeZone>();
                    byte[] byt = new byte[(int)FKMax.SIZE_TIME_ZONE_STRUCT];
                    TimeZone tz;
                    for (int i = 0; i < (int)FKMax.TIME_ZONE_COUNT; i++)
                    {
                        lblMsg.Text = StatusMsg + string.Format(" - {0}/{1}", i + 1, (int)FKMax.TIME_ZONE_COUNT);
                        tz = new TimeZone();
                        tz.Init();
                        tz.TimeZoneID = i + 1;
                        DeviceObject.objFK623.StructToByteArray(tz, byt);
                        ret = DeviceObject.objFK623.HS_GetTimeZone(byt);
                        if (!ret) break;
                        tz = (TimeZone)DeviceObject.objFK623.ByteArrayToStruct(byt, typeof(TimeZone));
                        tzList.Add(tz);
                        Application.DoEvents();
                    }
                    if (ret && tzList.Count > 0)
                    {
                        string sql = "";
                        DataTableReader dr = null;
                        string ID = "";
                        string Name = "";
                        string[] TS = new string[(int)FKMax.TIME_SLOT_COUNT];
                        string[] TE = new string[(int)FKMax.TIME_SLOT_COUNT];
                        try
                        {
                            for (int i = 0; i < tzList.Count; i++)
                            {
                                tz = tzList[i];
                                ID = tz.TimeZoneID.ToString();
                                for (int j = 0; j < (int)FKMax.TIME_SLOT_COUNT; j++)
                                {
                                    TS[j] = string.Format("{0:d2}:{1:d2}", tz.TimeSlots[j].StartHour, tz.TimeSlots[j].StartMinute);
                                    TE[j] = string.Format("{0:d2}:{1:d2}", tz.TimeSlots[j].EndHour, tz.TimeSlots[j].EndMinute);
                                }
                                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002001, new string[] { "3003", ID }));
                                if (dr.Read())
                                    sql = Pub.GetSQL(DBCode.DB_002001, new string[] { "3005", ID, Name, TS[0], TE[0], TS[1], TE[1],
                    TS[2], TE[2], TS[3], TE[3], TS[4], TE[4], TS[5], TE[5], OprtInfo.OprtNo });
                                else
                                    sql = Pub.GetSQL(DBCode.DB_002001, new string[] { "3004", ID, Name, TS[0], TE[0], TS[1], TE[1],
                    TS[2], TE[2], TS[3], TE[3], TS[4], TE[4], TS[5], TE[5], OprtInfo.OprtNo });
                                dr.Close();
                                db.ExecSQL(sql);
                                count++;
                            }
                        }
                        catch (Exception E)
                        {
                            ret = false;
                            Pub.ShowErrorMsg(E, sql);
                        }
                        finally
                        {
                            if (dr != null) dr.Close();
                            dr = null;
                        }
                        MacMsg = string.Format("{0}/{1}", count, tzList.Count);
                    }
                    DeviceObject.objFK623.EnableDevice(1);
                }
                DeviceObject.objFK623.Close();
            }
            
            return ret;
        }

        private bool PassTimeUpload(int MacSN, byte MacType, ref string MacMsg)
        {
            string StatusMsg = lblMsg.Text;
            bool ret = false;
            int count = 0;
            if (!DeviceObject.objFK623.IsOpen) DeviceObject.objFK623.Open();
            if (DeviceObject.objFK623.IsOpen)
            {
                if (DeviceObject.objFK623.EnableDevice(0) == (int)FKRun.RUN_SUCCESS)
                {
                    byte[] byt = new byte[(int)FKMax.SIZE_TIME_ZONE_STRUCT];
                    TimeZone tz;
                    if (timeList.Count > 0)
                    {
                        for (int i = 0; i < timeList.Count; i++)
                        {
                            lblMsg.Text = StatusMsg + string.Format(" - {0}/{1}", i + 1, timeList.Count);
                            tz = timeList[i];
                            DeviceObject.objFK623.StructToByteArray(tz, byt);
                            ret = DeviceObject.objFK623.HS_SetTimeZone(byt);
                            if (!ret) break;
                            Application.DoEvents();
                            count++;
                        }
                        if (count > 0)
                        {
                            ret = true;
                            MacMsg = string.Format("{0}/{1}", count, timeList.Count);
                        }
                    }
                }
                DeviceObject.objFK623.EnableDevice(1);
            }
            
            DeviceObject.objFK623.Close();
            return ret;
        }

        private bool PowerDownload(int MacSN, byte MacType, ref string MacMsg)
        {
            string StatusMsg = lblMsg.Text;
            bool ret = false;
            UInt32 EnrollNumber = 0;
            int BackupNumber = 0;
            int Privilege = 0;
            int EnableFlag = 0;
            int count = 0;
            List<ExtCmd_USERDOORINFO> uiList = new List<ExtCmd_USERDOORINFO>();
            byte[] byt = new byte[((int)FKMax.SIZE_USERDOORINFO_V1) + 64];
            ExtCmd_USERDOORINFO ui = new ExtCmd_USERDOORINFO();
            UserWeekPassTime uw = new UserWeekPassTime();
            byte[] bytUserPassTime = new byte[(int)FKMax.SIZE_USER_WEEK_PASS_TIME_STRUCT];
            if (!DeviceObject.objFK623.IsOpen) DeviceObject.objFK623.Open();
            if (DeviceObject.objFK623.IsOpen)
            {
                if (DeviceObject.objFK623.EnableDevice(0) == (int)FKRun.RUN_SUCCESS)
                {
                    DeviceObject.objFK623.RunCode = DeviceObject.objFK623.ReadAllUserID();
                    if (DeviceObject.objFK623.RunCode == (int)FKRun.RUN_SUCCESS)
                    {
                        do
                        {
                            DeviceObject.objFK623.RunCode = DeviceObject.objFK623.GetAllUserID(ref EnrollNumber, ref BackupNumber,
                              ref Privilege, ref EnableFlag);
                            if (DeviceObject.objFK623.RunCode != (int)FKRun.RUN_SUCCESS)
                            {
                                if (DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_DATAARRAY_END)
                                {
                                    DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                                    break;
                                }
                            }
                            else
                            {
                                bool isFind = false;
                                for (int i = 0; i < uiList.Count; i++)
                                {
                                    if (uiList[i].UserID == EnrollNumber)
                                    {
                                        isFind = true;
                                        break;
                                    }
                                }
                                if (!isFind)
                                {
                                    ui.Init(false, EnrollNumber);
                                    lblMsg.Text = StatusMsg + string.Format(" - {0}]", ui.UserID);
                                    DeviceObject.objFK623.StructToByteArray(ui, byt);
                                    if (DeviceObject.objFK623.ExtCommand(byt))
                                    {
                                        ui = (ExtCmd_USERDOORINFO)DeviceObject.objFK623.ByteArrayToStruct(byt, typeof(ExtCmd_USERDOORINFO));
                                        uiList.Add(ui);
                                    }
                                    else
                                    {
                                        uw.Init();
                                        uw.UserID = EnrollNumber;
                                        DeviceObject.objFK623.StructToByteArray(uw, bytUserPassTime);
                                        if (DeviceObject.objFK623.HS_GetUserWeekPassTime(bytUserPassTime))
                                        {
                                            uw = (UserWeekPassTime)DeviceObject.objFK623.ByteArrayToStruct(bytUserPassTime, typeof(UserWeekPassTime));
                                            ui.Init(false, EnrollNumber);
                                            for (int i = 0; i < 7; i++)
                                            {
                                                ui.WeekPassTime[i] = uw.WeekPassTime[i];
                                            }
                                            uiList.Add(ui);
                                        }
                                    }
                                }
                            }
                            Application.DoEvents();
                        }
                        while (true);
                    }
                    if (uiList.Count > 0)
                    {
                        DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                        ret = true;
                        string sql = "";
                        DataTableReader dr = null;
                        string SysID = MacSN.ToString();
                        string EmpSysID = "";
                        string SunID = "";
                        string MonID = "";
                        string TueID = "";
                        string WedID = "";
                        string ThuID = "";
                        string FriID = "";
                        string SatID = "";
                        string StartDate = "";
                        string EndDate = "";
                        DateTime dt;
                        try
                        {
                            for (int i = 0; i < uiList.Count; i++)
                            {
                                ui = uiList[i];
                                ret = db.GetEmpSysID(ui.UserID, ref EmpSysID);
                                if (!ret) break;
                                SunID = ui.WeekPassTime[0].ToString();
                                MonID = ui.WeekPassTime[1].ToString();
                                TueID = ui.WeekPassTime[2].ToString();
                                WedID = ui.WeekPassTime[3].ToString();
                                ThuID = ui.WeekPassTime[4].ToString();
                                FriID = ui.WeekPassTime[5].ToString();
                                SatID = ui.WeekPassTime[6].ToString();
                                StartDate = "NULL";
                                dt = new DateTime();
                                try
                                {
                                    dt = new DateTime(ui.StartYear, ui.StartMonth, ui.StartDay);
                                    StartDate = "'" + dt.ToString(SystemInfo.SQLDateFMT) + "'";
                                }
                                catch
                                {
                                }
                                EndDate = "NULL";
                                try
                                {
                                    dt = new DateTime(ui.EndYear, ui.EndMonth, ui.EndDay);
                                    EndDate = "'" + dt.ToString(SystemInfo.SQLDateFMT) + "'";
                                }
                                catch
                                {
                                }
                                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002001, new string[] { "4003", SysID, EmpSysID }));
                                if (dr.Read())
                                    sql = Pub.GetSQL(DBCode.DB_002001, new string[] { "4005", SysID, EmpSysID, SunID, MonID, TueID, WedID, ThuID,
                    FriID, SatID, OprtInfo.OprtNo, StartDate, EndDate });
                                else
                                    sql = Pub.GetSQL(DBCode.DB_002001, new string[] { "4004", SysID, EmpSysID, SunID, MonID, TueID, WedID, ThuID,
                    FriID, SatID, OprtInfo.OprtNo, StartDate, EndDate });
                                dr.Close();
                                db.ExecSQL(sql);
                                count++;
                            }
                            ret = true;
                            MacMsg = string.Format("{0}/{1}", count, uiList.Count);
                        }
                        catch (Exception E)
                        {
                            ret = false;
                            Pub.ShowErrorMsg(E);
                        }
                        finally
                        {
                            if (dr != null) dr.Close();
                            dr = null;
                        }
                    }
                }
                DeviceObject.objFK623.EnableDevice(1);
            }
           
            DeviceObject.objFK623.Close();
            return ret;
        }

        private bool PowerUpload(int MacSN, byte MacType, ref string MacMsg)
        {
            string StatusMsg = lblMsg.Text;
            bool ret = false;
            UInt32 EnrollNumber = 0;
            int BackupNumber = 0;
            int Privilege = 0;
            int EnableFlag = 0;
            int count = 0;
            List<UInt32> userIDList = new List<UInt32>();
            if (!DeviceObject.objFK623.IsOpen) DeviceObject.objFK623.Open();
            if (DeviceObject.objFK623.IsOpen)
            {
                if (DeviceObject.objFK623.EnableDevice(0) == (int)FKRun.RUN_SUCCESS)
                {
                    DeviceObject.objFK623.RunCode = DeviceObject.objFK623.ReadAllUserID();
                    if (DeviceObject.objFK623.RunCode == (int)FKRun.RUN_SUCCESS)
                    {
                        do
                        {
                            DeviceObject.objFK623.RunCode = DeviceObject.objFK623.GetAllUserID(ref EnrollNumber, ref BackupNumber,
                              ref Privilege, ref EnableFlag);
                            if (DeviceObject.objFK623.RunCode != (int)FKRun.RUN_SUCCESS)
                            {
                                if (DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_DATAARRAY_END)
                                {
                                    DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                                    break;
                                }
                            }
                            else
                            {
                                if (userIDList.IndexOf(EnrollNumber) < 0) userIDList.Add(EnrollNumber);
                            }
                            Application.DoEvents();
                        }
                        while (true);
                    }
                    List<ExtCmd_USERDOORINFO> uiList = new List<ExtCmd_USERDOORINFO>();
                    ExtCmd_USERDOORINFO ui;
                    List<UserWeekPassTime> uwList = new List<UserWeekPassTime>();
                    UserWeekPassTime uw;
                    DataTableReader dr = null;
                    DateTime dt;
                    try
                    {
                        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002001, new string[] { "4001", MacSN.ToString() }));
                        while (dr.Read())
                        {
                            EnrollNumber = Convert.ToUInt32(dr["CardFingerNo"].ToString());
                            if (userIDList.IndexOf(EnrollNumber) >= 0)
                            {
                                ui = new ExtCmd_USERDOORINFO();
                                ui.Init(true, EnrollNumber);
                                ui.WeekPassTime[0] = Convert.ToByte(dr["SunID"].ToString());
                                ui.WeekPassTime[1] = Convert.ToByte(dr["MonID"].ToString());
                                ui.WeekPassTime[2] = Convert.ToByte(dr["TueID"].ToString());
                                ui.WeekPassTime[3] = Convert.ToByte(dr["WedID"].ToString());
                                ui.WeekPassTime[4] = Convert.ToByte(dr["ThuID"].ToString());
                                ui.WeekPassTime[5] = Convert.ToByte(dr["FriID"].ToString());
                                ui.WeekPassTime[6] = Convert.ToByte(dr["SatID"].ToString());
                                try
                                {
                                    dt = Convert.ToDateTime(dr["StartDate"].ToString());
                                    ui.StartYear = (short)dt.Year;
                                    ui.StartMonth = (byte)dt.Month;
                                    ui.StartDay = (byte)dt.Day;
                                }
                                catch
                                {
                                }
                                try
                                {
                                    dt = Convert.ToDateTime(dr["EndDate"].ToString());
                                    ui.EndYear = (short)dt.Year;
                                    ui.EndMonth = (byte)dt.Month;
                                    ui.EndDay = (byte)dt.Day;
                                }
                                catch
                                {
                                }
                                uiList.Add(ui);
                                uw = new UserWeekPassTime();
                                uw.Init();
                                uw.UserID = EnrollNumber;
                                for (int i = 0; i < 7; i++)
                                {
                                    uw.WeekPassTime[i] = ui.WeekPassTime[i];
                                }
                                uwList.Add(uw);
                            }
                        }
                        ret = true;
                    }
                    catch (Exception E)
                    {
                        ret = false;
                        Pub.ShowErrorMsg(E);
                    }
                    finally
                    {
                        if (dr != null) dr.Close();
                        dr = null;
                    }
                    if (ret && uiList.Count > 0)
                    {
                        byte[] byt = new byte[((int)FKMax.SIZE_USERDOORINFO_V1) + 64];
                        for (int i = 0; i < uiList.Count; i++)
                        {
                            ui = uiList[i];
                            lblMsg.Text = StatusMsg + string.Format(" - {0}/{1}[{2}]", i + 1, uiList.Count, ui.UserID);
                            DeviceObject.objFK623.StructToByteArray(ui, byt);
                            ret = DeviceObject.objFK623.ExtCommand(byt);
                            if (!ret) break;
                            Application.DoEvents();
                            count++;
                        }
                        if (!ret && count == 0)
                        {
                            byte[] bytUserPassTime = new byte[(int)FKMax.SIZE_USER_WEEK_PASS_TIME_STRUCT];
                            for (int i = 0; i < uwList.Count; i++)
                            {
                                uw = uwList[i];
                                lblMsg.Text = StatusMsg + string.Format(" - {0}/{1}[{2}]", i + 1, uwList.Count, uw.UserID);

                                DeviceObject.objFK623.StructToByteArray(uw, bytUserPassTime);
                                ret = DeviceObject.objFK623.HS_SetUserWeekPassTime(bytUserPassTime);
                                if (!ret) break;
                                Application.DoEvents();
                                count++;
                            }
                        }
                        if (count > 0)
                        {
                            ret = true;
                            MacMsg = string.Format("{0}/{1}", count, uiList.Count);
                        }
                    }
                }
                DeviceObject.objFK623.EnableDevice(1);
            }
            
            DeviceObject.objFK623.Close();
            return ret;
        }

        private bool SetDoorState(bool IsOpen, int MacSN, ref string MacMsg)
        {
            bool ret = false;
            if (!DeviceObject.objFK623.IsOpen) DeviceObject.objFK623.Open();
            if (DeviceObject.objFK623.IsOpen)
            {
                if (IsOpen)
                    ret = DeviceObject.objFK623.SetDoorStatus((int)FKDoor.DOOR_OPEND);
                else
                    ret = DeviceObject.objFK623.SetDoorStatus((int)FKDoor.DOOR_CLOSED);
                if (ret) ret = KQFaceDoorStateGet(MacSN, ref MacMsg);
                DeviceObject.objFK623.Close();
            }
            
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

        private bool ClearLossCard(int MacSN, byte MacType, ref string MacMsg)
        {
            string StatusMsg = lblMsg.Text;
            bool ret = false;
            UInt32 EnrollNumber = 0;
            int BackupNumber = 0;
            int Privilege = 0;
            int EnableFlag = 0;
            List<UInt32> userIDList = new List<UInt32>();
            int ErrCode = 0;
            DialogResult MessRet;
            if (!DeviceObject.objFK623.IsOpen) DeviceObject.objFK623.Open();
            if (DeviceObject.objFK623.IsOpen)
            {
                if (DeviceObject.objFK623.EnableDevice(0) == (int)FKRun.RUN_SUCCESS)
                {
                    DeviceObject.objFK623.RunCode = DeviceObject.objFK623.ReadAllUserID();
                    if (DeviceObject.objFK623.RunCode == (int)FKRun.RUN_SUCCESS)
                    {
                        do
                        {
                            DeviceObject.objFK623.RunCode = DeviceObject.objFK623.GetAllUserID(ref EnrollNumber, ref BackupNumber,
                              ref Privilege, ref EnableFlag);
                            if (DeviceObject.objFK623.RunCode != (int)FKRun.RUN_SUCCESS)
                            {
                                if (DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_DATAARRAY_END)
                                {
                                    DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                                    break;
                                }
                            }
                            else
                            {
                                if (userIDList.IndexOf(EnrollNumber) < 0 && BackupNumber == (int)FKBackup.BACKUP_CARD) userIDList.Add(EnrollNumber);
                            }
                            Application.DoEvents();
                        }
                        while (true);
                    }
                    for (int i = 0; i < lossList.Count; i++)
                    {
                        if (userIDList.IndexOf(lossList[i].EnrollNumber) >= 0)
                        {
                        EEE:
                            DeviceObject.objFK623.RunCode = DeviceObject.objFK623.DeleteEnrollData(lossList[i].EnrollNumber, (int)FKBackup.BACKUP_CARD);
                            if (DeviceObject.objFK623.RunCode != (int)FKRun.RUN_SUCCESS)
                            {
                                ErrCode = DeviceObject.objFK623.RunCode;
                                if (ErrCode == (int)FKRun.RUNERR_NO_OPEN_COMM || ErrCode == (int)FKRun.RUNERR_WRITE_FAIL)
                                {
                                    if (DeviceObject.objFK623.ReOpen()) goto EEE;
                                    DeviceObject.objFK623.RunCode = ErrCode;
                                }
                                MessRet = Pub.MessageBoxQuestion(DeviceObject.objFK623.ErrMsg + "\r\n\r\n" +
                                  Pub.GetResText(formCode, "MsgContinue", ""), MessageBoxButtons.YesNoCancel);
                                if (MessRet == DialogResult.Yes)
                                    goto EEE;
                                else if (MessRet == DialogResult.Cancel)
                                    break;
                                else
                                    continue;
                            }
                        }
                    }
                    ret = true;
                }
                DeviceObject.objFK623.EnableDevice(1);
            }
            
            DeviceObject.objFK623.Close();
            return ret;
        }
        private bool ClearInfoDim(int MacSN, byte MacType, ref string MacMsg)
        {
            string StatusMsg = lblMsg.Text;
            bool ret = false;
            List<UInt32> userIDList = new List<UInt32>();
            int ErrCode = 0;
            DialogResult MessRet;
            if (!DeviceObject.objFK623.IsOpen) DeviceObject.objFK623.Open();
            if (DeviceObject.objFK623.IsOpen)
            {
                if (DeviceObject.objFK623.EnableDevice(0) == (int)FKRun.RUN_SUCCESS)
                {
                    for (int i = 0; i < lossList.Count; i++)
                    {
                    EEE:
                        for(int j = 0; j <= 16; j++)
                        {
                            DeviceObject.objFK623.RunCode = DeviceObject.objFK623.DeleteEnrollData(lossList[i].EnrollNumber, j);
                            if (DeviceObject.objFK623.RunCode != (int)FKRun.RUN_SUCCESS)
                            {
                                ErrCode = DeviceObject.objFK623.RunCode;
                                if (ErrCode == (int)FKRun.RUNERR_NO_OPEN_COMM || ErrCode == (int)FKRun.RUNERR_WRITE_FAIL)
                                {
                                    if (DeviceObject.objFK623.ReOpen()) goto EEE;
                                    DeviceObject.objFK623.RunCode = ErrCode;
                                }
                                MessRet = Pub.MessageBoxQuestion(DeviceObject.objFK623.ErrMsg + "\r\n\r\n" +
                                  Pub.GetResText(formCode, "MsgContinue", ""), MessageBoxButtons.YesNoCancel);
                                if (MessRet == DialogResult.Yes)
                                    goto EEE;
                                else if (MessRet == DialogResult.Cancel)
                                    break;
                                else
                                    continue;
                            }
                        }
                      
                    }
                    ret = true;
                }
                DeviceObject.objFK623.EnableDevice(1);
            }

            DeviceObject.objFK623.Close();
            return ret;
        }
    }
}