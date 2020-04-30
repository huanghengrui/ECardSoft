using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmRSEmpFace : frmBaseDialog
    {
        private string title = "";
        private string oprt = "";
        private byte oprtFlag = 0;

        protected override void InitForm()
        {
            formCode = "RSEmpFace";
            IsFinger = true;
            CreateCardGridView(cardGrid);
            macGrid.Rows.Clear();
            AddColumn(macGrid, 1, "SelectCheck", false, false, 1, 60);
            AddColumn(macGrid, 0, "MacSysID", true, false, 0, 0);
            AddColumn(macGrid, 0, "MacSN", false, true, 0, 70);
            AddColumn(macGrid, 0, "MacTypeID", true, false, 0, 0);
            AddColumn(macGrid, 0, "MacTypeName", false, false, 0, 0);
            AddColumn(macGrid, 0, "MacConnType", false, false, 0, 70);
            AddColumn(macGrid, 0, "MacIPAddress", false, false, 0, 110);
            AddColumn(macGrid, 0, "MacPort", false, false, 0, 60);
            AddColumn(macGrid, 0, "MacConnPWD", false, false, 0, 80);
            AddColumn(macGrid, 1, "IsGPRS", false, false, 1, 60);
            AddColumn(macGrid, 0, "MacDesc", false, false, 0, 80);
            base.InitForm();
            lblQuickSearchToolTip.ForeColor = Color.Blue;
            this.Text = oprt;

            if (SysID != "") QuickSearchNormalCardByEmpSysID(SysID, cardGrid, 0);

            try
            {
                macGrid.DataSource = db.GetDataTable(Pub.GetSQL(DBCode.DB_002001, new string[] { "2000" }));
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
        }

        public frmRSEmpFace(string Title, string Oprt, string GUID, byte flag)
        {
            title = Title;
            oprt = Oprt;
            SysID = GUID;
            oprtFlag = flag;
            InitializeComponent();
        }

        private void btnQuickSearch_Click(object sender, EventArgs e)
        {
            QuickSearchNormalCard(btnQuickSearch.Text, cardGrid, 0, IsFinger);
        }

        private void txtQuickSearch_KeyDown(object sender, KeyEventArgs e)
        {
            QuickSearchNormalCard(txtQuickSearch, e, cardGrid, 0, IsFinger);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cardGrid.DataSource = null;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cardGrid.RowCount == 0)
            {
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorSelectEmp", ""));
                return;
            }
            bool HasMac = false;
            for (int i = 0; i < macGrid.RowCount; i++)
            {
                if (Pub.ValueToBool(macGrid[0, i].Value))
                {
                    HasMac = true;
                    break;
                }
            }
            if (!HasMac)
            {
                ShowErrorSelectCorrect(gbxMacInfo.Text);
                return;
            }
            string msg = "";
            DataTable dtMac = (DataTable)macGrid.DataSource;
            DataTable dtEmp = (DataTable)cardGrid.DataSource;
            DataTable dtFinger = null;
            TConnInfoFinger conn;
            UInt32 EnrollNumber = 0;
            string CardID = "";
            string CardPWD = "";
            int BackupNumber = 0;
            int Privilege = 0;
            int EnableFlag = 0;
            int PasswordData = 0;
            int nPhotoSize = 0;
            byte[] fpData = new byte[(int)FKMax.FK_FaceDataSize];
            string EnrollName = "";
            bool IsError = false;
            string EmpSysID = "";
            byte[] buff = new byte[0];
            bool ReqName = false;
            int ErrCode = 0;
            for (int j = 0; j < dtEmp.Rows.Count; j++)
            {
                EnrollNumber = Convert.ToUInt32(dtEmp.Rows[j]["CardFingerNo"]);
                EnrollName = dtEmp.Rows[j]["EmpName"].ToString();
                msg = EnrollNumber.ToString() + "[" + dtEmp.Rows[j]["EmpNo"].ToString() + "]" + EnrollName;
                EmpSysID = dtEmp.Rows[j]["EmpSysID"].ToString();
                if (oprtFlag != 0)
                {
                    try
                    {
                        dtFinger = db.GetDataTable(Pub.GetSQL(DBCode.DB_002001, new string[] { "2014", "3", EmpSysID }));
                    }
                    catch (Exception E)
                    {
                        Pub.ShowErrorMsg(E);
                        return;
                    }
                }
                IsError = false;
                int MacSN = 0;
                string MacSN_GRPS = "";
                bool IsGPRS = false;
                for (int i = 0; i < dtMac.Rows.Count; i++)
                {
                    DataRow row = dtMac.Rows[i];
                    if (!Pub.ValueToBool(dtMac.Rows[i]["SelectCheck"])) continue;
                    MacSN = 0;
                    MacSN_GRPS = "";
                    IsGPRS = Pub.ValueToBool(dtMac.Rows[i]["IsGPRS"].ToString());
                    if (IsGPRS)
                        MacSN_GRPS = row["MacSN"].ToString();
                    else
                    {
                        MacSN = Convert.ToInt32(row["MacSN"].ToString());
                        MacSN_GRPS = MacSN.ToString();
                    }
                    conn = Pub.ValueToConnInfoFinger(MacSN, MacSN_GRPS, row["MacConnType"].ToString(),
                      row["MacIPAddress"].ToString(), row["MacPort"].ToString(), row["MacConnPWD"].ToString(), IsGPRS);
                    DeviceObject.objFK623.InitConn(conn);
                    if (!DeviceObject.objFK623.IsOpen) DeviceObject.objFK623.Open();
                    if (!DeviceObject.objFK623.IsOpen)
                    {
                        Pub.ShowErrorMsg(DeviceObject.objFK623.ErrMsg);
                        return;
                    }
                    if (DeviceObject.objFK623.EnableDevice(0) != (int)FKRun.RUN_SUCCESS)
                    {
                        IsError = true;
                        Pub.ShowErrorMsg(DeviceObject.objFK623.ErrMsg);
                        goto ErrorExitFK623;
                    }
                    switch (oprtFlag)
                    {
                        case 0:
                            foreach (FKBackup ii in Enum.GetValues(typeof(FKBackup)))
                            {
                                BackupNumber = (int)ii;
                                DeviceObject.objFK623.RunCode = DeviceObject.objFK623.GetEnrollData(EnrollNumber, BackupNumber,
                                  ref Privilege, fpData, ref PasswordData);
                                if (DeviceObject.objFK623.RunCode == (int)FKRun.RUN_SUCCESS)
                                {
                                    EnrollName = "";
                                    DeviceObject.objFK623.GetUserName(EnrollNumber, ref EnrollName);
                                    if (!db.SaveEnrollToDB(EnrollNumber, BackupNumber, EnableFlag, Privilege, PasswordData, fpData,
                                      EnrollName, ref ReqName))
                                    {
                                        IsError = true;
                                        goto ErrorExitFK623;
                                    }
                                }
                            }
                            buff = new byte[0];
                            if (DeviceObject.objFK623.GetEnrollPhoto(EnrollNumber, ref buff))
                            {
                                db.UpdateByteData(Pub.GetSQL(DBCode.DB_001003, new string[] { "10", EmpSysID }), "EmpPhotoImage", buff);
                            }
                            break;
                        case 1:
                            for (int ii = 0; ii < dtFinger.Rows.Count; ii++)
                            {
                                BackupNumber = Convert.ToInt32(dtFinger.Rows[ii]["FaceBkNo"].ToString());
                                CardID = dtFinger.Rows[ii]["CardPhysicsNo10"].ToString();
                                CardPWD = dtFinger.Rows[ii]["CardPWD"].ToString();
                                Privilege = 0;
                                int.TryParse(dtFinger.Rows[ii]["FacePrivilege"].ToString(), out Privilege);
                                EnrollName = dtFinger.Rows[ii]["EmpName"].ToString();
                                PasswordData = 0;
                                buff = new byte[0];
                                if (dtFinger.Rows[ii]["FaceTemplate"].ToString() != "") buff = (byte[])dtFinger.Rows[ii]["FaceTemplate"];
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
                                DeviceObject.objFK623.RunCode = DeviceObject.objFK623.PutEnrollData(EnrollNumber, BackupNumber,
                                  Privilege, fpData, PasswordData);
                                if (DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_DATADOUBLE)
                                {
                                    DeviceObject.objFK623.DeleteEnrollData(EnrollNumber, BackupNumber);
                                    goto EEE;
                                }
                                if (DeviceObject.objFK623.RunCode != (int)FKRun.RUN_SUCCESS)
                                {
                                    IsError = true;
                                    Pub.ShowErrorMsg(DeviceObject.objFK623.ErrMsg);
                                    goto ErrorExitFK623;
                                }
                            }
                            if (DeviceObject.objFK623.RunCode == (int)FKRun.RUN_SUCCESS)
                            {
                                DeviceObject.objFK623.SetUserName(EnrollNumber, EnrollName, ref ErrCode);
                                DataTableReader drPhoto = null;
                                try
                                {
                                    drPhoto = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "104", EmpSysID }));
                                    if (drPhoto.Read())
                                    {
                                        if (drPhoto["EmpPhotoImage"].ToString() != "")
                                        {
                                            byte[] buf = (byte[])(drPhoto["EmpPhotoImage"]);
                                            nPhotoSize = buf.Length;
                                            DeviceObject.objFK623.SetEnrollPhoto(EnrollNumber, buf, nPhotoSize);
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
                            break;
                        case 2:
                            for (int ii = 0; ii < dtFinger.Rows.Count; ii++)
                            {
                                BackupNumber = Convert.ToInt32(dtFinger.Rows[ii]["FaceBkNo"].ToString());
                                DeviceObject.objFK623.RunCode = DeviceObject.objFK623.DeleteEnrollData(EnrollNumber, BackupNumber);
                                if (DeviceObject.objFK623.RunCode != (int)FKRun.RUN_SUCCESS)
                                {
                                    IsError = true;
                                    Pub.ShowErrorMsg(DeviceObject.objFK623.ErrMsg);
                                    goto ErrorExitFK623;
                                }
                                else
                                {
                                    try
                                    {
                                        db.ExecSQL(Pub.GetSQL(DBCode.DB_001003, new string[] { "18", EmpSysID, BackupNumber.ToString() }));
                                    }
                                    catch (Exception E)
                                    {
                                        IsError = true;
                                        Pub.ShowErrorMsg(E);
                                        goto ErrorExitFK623;
                                    }
                                }
                            }
                            break;
                    }
                ErrorExitFK623:
                    DeviceObject.objFK623.EnableDevice(1);
                    DeviceObject.objFK623.Close();
                }
                if (IsError) break;
                if (!IsError) db.WriteSYLog(title, oprt, msg);
            }
            if (IsError) return;
            this.Close();
            this.DialogResult = DialogResult.OK;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectMac(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectMac(false);
        }

        private void SelectMac(bool state)
        {
            for (int i = 0; i < macGrid.RowCount; i++)
            {
                macGrid[0, i].Value = state;
            }
        }
    }
}