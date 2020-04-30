using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using grproLib;

namespace ECard78
{
    public partial class frmRSEmp : frmBaseMDIChildReportTree
    {
        private int DepartImportID = 1;

        protected override void InitForm()
        {
            formCode = "RSEmp";
            ReportFile = "RSEmp";
            if (SystemInfo.HasFaCard)
            {
                SetToolItemState("ItemTAG1", true);
                SetToolItemState("ItemTAG2", true);
                SetToolItemState("ItemTAG3", true);
                SetToolItemState("ItemTAG4", true);
                SetToolItemState("ItemTAG5", true);
                SetToolItemState("ItemTAG6", true);
                SetToolItemState("ItemTAG7", true);
                SetToolItemState("ItemTAG8", true);
                SetToolItemState("ItemTAG9", true);
                SetToolItemState("ItemLine3", true);
                SetToolItemState("ItemDelete",false);//删除的
                AddExtDropDownItem("CardModify", CardModify_Click);
                if (SystemInfo.AllowCustomerCardNo) AddExtDropDownItem("ItemCardFill", CardFill_Click);
                AddExtDropDownItem("ItemCardBlack", CardBlack_Click);
            }
            else if (SystemInfo.HasMJ)
            {
                SetToolItemState("ItemLine3", true);
                AddExtDropDownItem("ItemCardFillPhysics", ItemCardFillPhysics_Click);
            }
            if (SystemInfo.HasKQ && ((SystemInfo.KQFlag == 1) || (SystemInfo.KQFlag == 2)))
            {
                AddExtDropDownItem("ItemCardFaceDown", ItemCardFaceDown_Click);
                AddExtDropDownItem("ItemCardFaceUp", ItemCardFaceUp_Click);
                AddExtDropDownItem("ItemCardFaceDelete", ItemCardFaceDelete_Click);

            }
            if (SystemInfo.HasSEA)
            {
                AddExtDropDownItem("ItemSEADown", ItemSEADown_Click);
                AddExtDropDownItem("ItemSEAUp", ItemSEAUp_Click);
                AddExtDropDownItem("ItemSEADelete", ItemSEADelete_Click);

            }
            AddExtDropDownItem("CardPrint", CardPrint_Click);
            //定制的批量修改部门
            //AddExtDropDownItem("BatchChangeDepart", BatchChangeDepart_Click);
            SetToolItemState("ItemLine5", true);
            SetToolItemState("ItemSearch", true);
            SetToolItemState("ItemFindLabel", true);
            SetToolItemState("ItemFindText", true);
            ReportStartIndex = 3;
            IsInitBaseForm = true;
            InitEmp = false;
            base.InitForm();
            QuerySQL = Pub.GetSQL(DBCode.DB_001003, new string[] { "0", OprtInfo.DepartPower });
            FindSQL = Pub.GetSQL(DBCode.DB_001003, new string[] { "301", OprtInfo.DepartPower });
            FindOrderBy = Pub.GetSQL(DBCode.DB_001003, new string[] { "302" });
            FindKeyWord = formCode;
            ImportShowDepart = true;
            ImportFieldList = new string[] { "EmpNo", "EmpName", "EmpSexName", "DepartID", "DepartName", "CardTypeID",
        "EmpHireDate", "EmpCertNo", "EmpAddress", "EmpZipNo", "EmpPhoneNo", "EmpEmail", "CardSectorNo",
        "CardPWD", "CardStartDate", "CardEndDate", "CardFingerNo", "OtherCardNo" };
            if ((SystemInfo.KQFlag != 1) && (SystemInfo.KQFlag != 2))
            {
                SetReportColumnVisible("CardFingerNo", false);
            }
            DeviceObject.objCard.IDCardInit();
            ItemFindText.ToolTipText = Pub.GetResText("", "lblQuickSearchToolTipCard", "");
            ExecTreeAfterSelect();
        }

        protected override void FreeForm()
        {
            DeviceObject.objCard.IDCardFree();
            base.FreeForm();
        }

        public frmRSEmp()
        {
            InitializeComponent();
        }

        private void ShowAdd()
        {
            frmRSEmpAdd frm = new frmRSEmpAdd(this.Text, CurrentTool, "");
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
            if (frm.IsAddNext) ShowAdd();
        }

        protected override void ExecItemAdd()
        {
            base.ExecItemAdd();
            ShowAdd();
            
        }

        protected override void ExecItemEdit()
        {
            base.ExecItemEdit();
            string SysID = GetSysID();
            if (!db.CheckDepartPowerByEmpSysID(SysID)) return;
            frmRSEmpAdd frm = new frmRSEmpAdd(this.Text, CurrentTool, SysID);
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
           
        }

        protected override void ExecItemDelete()
        {
            int CardStatusID = 0;
            string msg = Pub.GetResText(formCode, "Error105", "");
            int RecNo = Report.DetailGrid.Recordset.RecordNo;
            Report.DetailGrid.Recordset.First();
            while (!Report.DetailGrid.Recordset.Eof())
            {
                if (Report.FieldByName("Checked").AsInteger == (int)GRSystemImage.grsi3DChecked)
                {
                    CardStatusID = Report.FieldByName("CardStatusID").AsInteger;
                    if ((CardStatusID != 10) && (CardStatusID != 60))
                    {
                        msg = string.Format(msg, Report.FieldByName("EmpNo").AsString, Report.FieldByName("CardStatusName").AsString);
                        Pub.ShowErrorMsg(msg);
                        return;
                    }
                }
                Report.DetailGrid.Recordset.Next();
            }
            Report.DetailGrid.Recordset.MoveTo(RecNo);
            base.ExecItemDelete();
            
        }

        protected override void ExecItemImport()
        {
            DepartImportID = 1;
            base.ExecItemImport();
            
        }

        protected override void ExecItemImportAfter()
        {
            db.UpdateEmpInfoCount(this.Text);
            InitDepartTreeView(tvEmp, InitEmp, otherCoin);
            ExecTreeAfterSelect();
        }

        protected override void ExecItemTAG1()
        {
            base.ExecItemTAG1();
            ShowCardFa(true);
           
        }

        protected override void ExecItemTAG2()
        {
            base.ExecItemTAG2();
            ShowCardLoss(true, GetSysID());
            
        }

        protected override void ExecItemTAG3()
        {
            base.ExecItemTAG3();
            ShowCardRelieve(true);
           
        }

        protected override void ExecItemTAG4()
        {
            base.ExecItemTAG4();
            ShowCardChange(true);
            
        }

        protected override void ExecItemTAG5()
        {
            base.ExecItemTAG5();
            ShowCardRetirement(true);
            
        }

        protected override void ExecItemTAG6()
        {
            base.ExecItemTAG6();
            ShowCardRepair(true);
           
        }

        protected override void ExecItemTAG7()
        {
            base.ExecItemTAG7();
            ShowCardView(true);
           
        }

        protected override void ExecItemTAG8()
        {
            base.ExecItemTAG8();
            ShowRSDimissionAdd(true);
            
        }
        protected override void ExecItemTAG9()
        {
            base.ExecItemTAG9();
            frmSFDeposit frm = new frmSFDeposit();
            frm.ShowDialog();
        }
        protected override void ExecItemFindText()
        {
            QuerySQL = Pub.GetSQL(DBCode.DB_001003, new string[] { "303", ItemFindText.Text.Trim(), OprtInfo.DepartPower });
            ExecItemRefresh();
            
        }

        protected override void RefreshForm(bool State)
        {
            base.RefreshForm(State);
            ItemTAG1.Enabled = State;
            ItemTAG2.Enabled = State;
            ItemTAG3.Enabled = State;
            ItemTAG4.Enabled = State;
            ItemTAG5.Enabled = State;
            ItemTAG7.Enabled = State;
            ItemTAGExt.Enabled = State;
            for (int i = 0; i < ItemTAGExt.DropDownItems.Count; i++)
            {
                if (ItemTAGExt.DropDownItems[i].Name != "CardPrint") ItemTAGExt.DropDownItems[i].Enabled = State;
            }
            SetContextMenuState();
           
        }

        public override bool ProcessImportData(DataRow row, List<string> sys, List<string> src, string DepartUpSysID,
          ref string ErrorMsg, ref double Sum)
        {
            bool ret = base.ProcessImportData(row, sys, src, DepartUpSysID, ref ErrorMsg, ref Sum);
            string EmpNo = "";
            string EmpName = "";
            string EmpSexName = "";
            string DepartID = "";
            string DepartName = "";
            string CardTypeID = "";
            string EmpHireDate = "";
            string EmpCertNo = "";
            string EmpAddress = "";
            string EmpZipNo = "";
            string EmpPhoneNo = "";
            string EmpEmail = "";
            string CardSectorNo = "";
            string CardPWD = "";
            string CardStartDate = "";
            string CardEndDate = "";
            string CardFingerNo = "";
            string OtherCardNo = "";
            for (int i = 0; i < sys.Count; i++)
            {
                switch (sys[i])
                {
                    case "EmpNo":
                        EmpNo = row[src[i]].ToString();
                        break;
                    case "EmpName":
                        EmpName = row[src[i]].ToString();
                        break;
                    case "EmpSexName":
                        EmpSexName = row[src[i]].ToString();
                        break;
                    case "DepartID":
                        DepartID = row[src[i]].ToString();
                        break;
                    case "DepartName":
                        DepartName = row[src[i]].ToString();
                        break;
                    case "CardTypeID":
                        CardTypeID = row[src[i]].ToString();
                        break;
                    case "EmpHireDate":
                        EmpHireDate = row[src[i]].ToString();
                        break;
                    case "EmpCertNo":
                        EmpCertNo = row[src[i]].ToString();
                        break;
                    case "EmpAddress":
                        EmpAddress = row[src[i]].ToString();
                        break;
                    case "EmpZipNo":
                        EmpZipNo = row[src[i]].ToString();
                        break;
                    case "EmpPhoneNo":
                        EmpPhoneNo = row[src[i]].ToString();
                        break;
                    case "EmpEmail":
                        EmpEmail = row[src[i]].ToString();
                        break;
                    case "CardSectorNo":
                        CardSectorNo = row[src[i]].ToString();
                        break;
                    case "CardPWD":
                        CardPWD = row[src[i]].ToString();
                        break;
                    case "CardStartDate":
                        CardStartDate = row[src[i]].ToString();
                        break;
                    case "CardEndDate":
                        CardEndDate = row[src[i]].ToString();
                        break;
                    case "CardFingerNo":
                        CardFingerNo = row[src[i]].ToString();
                        break;
                    case "OtherCardNo":
                        OtherCardNo = row[src[i]].ToString();
                        break;
                }
            }
            if (EmpNo == "")
            {
                ErrorMsg = Pub.GetResText(formCode, "Error101", "");
                return false;
            }
            bool IsError = false;
            DataTableReader dr = null;
            string sql = "";
            string SexSysID = "";
            string DepartSysID = "";
            string CardTypeSysID = "";
            if (DepartID == "" && DepartName == "") DepartSysID = SystemInfo.CommanySysID;
            try
            {
                if (EmpSexName != "")
                {
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "201", EmpSexName }));
                    if (dr.Read()) SexSysID = dr["EmpSexSysID"].ToString();
                    dr.Close();
                }
                if (DepartID == "" && DepartName != "")
                {
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "202", DepartName }));
                    if (dr.Read())
                        DepartID = dr["DepartID"].ToString();
                    else
                    {
                        dr.Close();
                        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "203" }));
                        string s = "";
                        if (dr.Read()) s = dr[0].ToString();
                        dr.Close();
                        if (Pub.IsNumeric(s))
                        {
                            if (s == "001")
                                s = "001001";
                            else
                            {
                                DepartImportID = Convert.ToInt32(s) + 1;
                                s = DepartImportID.ToString("000000");
                            }
                        }
                        else
                            s = DepartImportID.ToString("000000");
                        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001002, new string[] { "2", s }));
                        while (dr.Read())
                        {
                            dr.Close();
                            DepartImportID = DepartImportID + 1;
                            s = DepartImportID.ToString("000000");
                            dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001002, new string[] { "2", s }));
                        }
                        DepartID = s;
                        sql = Pub.GetSQL(DBCode.DB_001002, new string[] { "6", DepartID, DepartName, DepartUpSysID, "" });
                        db.ExecSQL(sql);
                    }
                    dr.Close();
                }
                else if (DepartID != "" && DepartName != "")
                {
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001002, new string[] { "2", DepartID }));
                    bool HasDepart = false;
                    if (dr.Read()) HasDepart = true;
                    dr.Close();
                    if (!HasDepart)
                    {
                        sql = Pub.GetSQL(DBCode.DB_001002, new string[] { "6", DepartID, DepartName, DepartUpSysID, "" });
                        db.ExecSQL(sql);
                    }
                }
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001002, new string[] { "2", DepartID }));
                if (dr.Read()) DepartSysID = dr["DepartSysID"].ToString();
                dr.Close();
                if (!Pub.IsNumeric(CardTypeID)) CardTypeID = "0";
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "204", CardTypeID }));
                if (dr.Read())
                    CardTypeSysID = dr["CardTypeSysID"].ToString();
                else
                {
                    dr.Close();
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "204", CardTypeID }));
                    if (dr.Read()) CardTypeSysID = dr["CardTypeSysID"].ToString();
                }
                if (DepartSysID == "")
                {
                    ErrorMsg = Pub.GetResText(formCode, "Error103", "");
                    return false;
                }
                if (CardTypeSysID == "")
                {
                    ErrorMsg = Pub.GetResText(formCode, "Error104", "");
                    return false;
                }
                DateTime d = new DateTime();
                if (DateTime.TryParse(EmpHireDate, out d))
                    EmpHireDate = "'" + d.ToString(SystemInfo.SQLDateFMT) + "'";
                else
                    EmpHireDate = Pub.GetSQL(DBCode.DB_000001, new string[] { "301" });
                if ((Pub.GetTextLength(CardSectorNo) > 10) || (!Pub.IsNumeric(CardSectorNo))) CardSectorNo = "";
                if ((Pub.IsNumeric(CardSectorNo) && (Convert.ToUInt32(CardSectorNo) > SystemInfo.MaxCardID))) CardSectorNo = "";
                if (CardSectorNo != "" && Pub.IsNumeric(CardSectorNo))
                {
                    CardSectorNo = Convert.ToUInt32(CardSectorNo).ToString("0000000000");
                }
                if ((Pub.GetTextLength(CardPWD) > 6) || (!Pub.IsNumeric(CardPWD))) CardPWD = "000000";
                CardPWD = Convert.ToUInt32(CardPWD).ToString("000000");
                if (DateTime.TryParse(CardStartDate, out d))
                    CardStartDate = "'" + d.ToString(SystemInfo.SQLDateFMT) + "'";
                else
                    CardStartDate = "";
                if (DateTime.TryParse(CardEndDate, out d))
                    CardEndDate = "'" + d.ToString(SystemInfo.SQLDateFMT) + "'";
                else
                    CardEndDate = "";
                if (!Pub.IsNumeric(CardFingerNo)) CardFingerNo = "";
                if (!Pub.IsNumeric(OtherCardNo)) OtherCardNo = "";
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "2", EmpNo }));
                if (!dr.Read())
                {
                    dr.Close();
                    sql = Pub.GetSQL(DBCode.DB_001003, new string[] { "205", EmpNo, EmpName, SexSysID, CardTypeSysID,
            DepartSysID, EmpHireDate, EmpCertNo, EmpAddress, EmpZipNo, EmpPhoneNo, EmpEmail, OtherCardNo });
                    db.ExecSQL(sql);
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "2", EmpNo }));
                    dr.Read();
                    string EmpSysID = dr["EmpSysID"].ToString();
                    dr.Close();
                    if (CardSectorNo != "")
                    {
                        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "206", CardSectorNo }));
                        if (dr.Read()) CardSectorNo = "";
                        dr.Close();
                    }
                    if (CardFingerNo != "")
                    {
                        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "5", CardFingerNo }));
                        if (dr.Read()) CardFingerNo = "";
                        dr.Close();
                    }
                    db.ExecSQL(Pub.GetSQL(DBCode.DB_001003, new string[] { "207", CardSectorNo, CardPWD, CardStartDate,
            CardEndDate, EmpSysID, CardFingerNo }));
                    string picPath = SystemInfo.AppPath + "EmpPic\\";
                    string picFileName = picPath + EmpNo + ".jpg";
                    if (!File.Exists(picFileName)) picFileName = picPath + EmpNo + ".bmp";
                    if (!File.Exists(picFileName)) picFileName = picPath + EmpName + ".jpg";
                    if (!File.Exists(picFileName)) picFileName = picPath + EmpName + ".bmp";
                    if (File.Exists(picFileName))
                    {
                        string fileName = Pub.GetTempPathFileName(picFileName);
                        CustomSizeImageFile(picFileName, fileName);
                        byte[] buff = new byte[0];
                        MemoryStream ms = new MemoryStream();
                        Bitmap t = new Bitmap(fileName);
                        t.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        t.Dispose();
                        t = null;
                        File.Delete(fileName);
                        buff = ms.ToArray();
                        db.UpdateByteData(Pub.GetSQL(DBCode.DB_001003, new string[] { "10", EmpSysID }), "EmpPhotoImage", buff);
                    }
                    if (CardPWD != "") db.UpdateEmpRegisterData(EmpSysID, 10, CardPWD);
                }
                else
                {
                    ErrorMsg = Pub.GetResText(formCode, "Error106", "");
                    return false;
                }
            }
            catch (Exception E)
            {
                IsError = true;
                Pub.ShowErrorMsg(E, sql);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            if (IsError) return false;
            db.WriteSYLog(this.Text, CurrentTool, sql);
            
            return ret;
        }

        private void CustomSizeImageFile(string picFileName, string fileName)
        {
            Bitmap bmp = CustomSizeImage(Image.FromFile(picFileName));
            bmp.Save(fileName);
            bmp.Dispose();
           
        }

        private void CardPrint_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            CurrentTool = ((ToolStripItem)sender).Text;
            GridppReport cardReport = new GridppReport();
            string fileName = SystemInfo.ReportPath + "RSPrintCard.grf";
            try
            {
                cardReport.Register(SystemInfo.ReportRegister);
                cardReport.LoadFromFile(fileName);
                cardReport.DetailGrid.Recordset.ConnectionString = SystemInfo.ConnStrReport;
                cardReport.DetailGrid.Recordset.QuerySQL = "";
                cardReport.ShowProgressUI = false;
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
                return;
            }
            string s = "";
            string reportTitle = RegisterInfo.RegUser == "" ? SystemInfo.CommanyName : RegisterInfo.RegUser;
            if (RegisterInfo.IsTest && RegisterInfo.IsValid) reportTitle = RegisterInfo.StateText;
            for (int i = 1; i <= cardReport.DetailGrid.Columns[1].ContentCell.Controls.Count; i++)
            {
                switch (cardReport.DetailGrid.Columns[1].ContentCell.Controls[i].Name.ToLower())
                {
                    case "staticboxcommany":
                        cardReport.DetailGrid.Columns[1].ContentCell.Controls[i].AsStaticBox.Text = reportTitle;
                        break;
                    case "staticboxempno":
                        s = cardReport.DetailGrid.Columns[1].ContentCell.Controls[i].AsStaticBox.Text;
                        s = Pub.GetResText(formCode, "EmpNo", s);
                        cardReport.DetailGrid.Columns[1].ContentCell.Controls[i].AsStaticBox.Text = s;
                        break;
                    case "staticboxempname":
                        s = cardReport.DetailGrid.Columns[1].ContentCell.Controls[i].AsStaticBox.Text;
                        s = Pub.GetResText(formCode, "EmpName", s);
                        cardReport.DetailGrid.Columns[1].ContentCell.Controls[i].AsStaticBox.Text = s;
                        break;
                    case "staticboxdepartname":
                        s = cardReport.DetailGrid.Columns[1].ContentCell.Controls[i].AsStaticBox.Text;
                        s = Pub.GetResText(formCode, "DepartName", s);
                        cardReport.DetailGrid.Columns[1].ContentCell.Controls[i].AsStaticBox.Text = s;
                        break;
                    case "staticboxemphiredate":
                        s = cardReport.DetailGrid.Columns[1].ContentCell.Controls[i].AsStaticBox.Text;
                        s = Pub.GetResText(formCode, "EmpHireDate", s);
                        cardReport.DetailGrid.Columns[1].ContentCell.Controls[i].AsStaticBox.Text = s;
                        break;
                }
            }
            string sql = Report.DetailGrid.Recordset.QuerySQL;
            sql = Pub.GetSQL(DBCode.DB_001003, new string[] { "217", sql });
            cardReport.DetailGrid.Recordset.QuerySQL = sql;
            frmPubPreview frm = new frmPubPreview(cardReport, CurrentTool, fileName, "", "", true);
            frm.ShowDialog();
            
        }

        private void CardFill_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            CurrentTool = ((ToolStripItem)sender).Text;
            frmRSEmpCardFill frm = new frmRSEmpCardFill(CurrentTool);
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
           
        }

        private void BatchChangeDepart_Click(object sender, EventArgs e)
        {
            if (CurrentTool == "") CurrentTool = Pub.GetResText(formCode, "BatchChangeDepart", "");
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            frmRSEmpBatchChangeDepart frm = new frmRSEmpBatchChangeDepart(this.Text, CurrentTool, "");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ExecItemRefresh();
            }
            
        }

        private void ItemCardFillPhysics_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            CurrentTool = ((ToolStripItem)sender).Text;
            frmRSEmpCardFillPhysics frm = new frmRSEmpCardFillPhysics(CurrentTool);
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
           
        }

        private void CardModify_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            CurrentTool = ((ToolStripItem)sender).Text;
            ShowCardModify(true);
           
        }

        private void CardBlack_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            CurrentTool = ((ToolStripItem)sender).Text;
            ShowCardBlack(true);
           
        }

        private void ItemCardFaceDown_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            CurrentTool = ((ToolStripItem)sender).Text;
            ShowRSEmpFace(0);
            
        }



        private void ItemCardFaceUp_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            CurrentTool = ((ToolStripItem)sender).Text;
            ShowRSEmpFace(1);
        }

        private void ItemCardFaceDelete_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            CurrentTool = ((ToolStripItem)sender).Text;
            ShowRSEmpFace(2);
           
        }

        private void ItemSEADown_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            CurrentTool = ((ToolStripItem)sender).Text;
            new frmSeaOprt(this.Text, CurrentTool, "", 20, null).ShowDialog(); ;
        }



        private void ItemSEAUp_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            CurrentTool = ((ToolStripItem)sender).Text;
            List<string> GUID = new List<string>();
            int RecNo = Report.DetailGrid.Recordset.RecordNo;
            Report.DetailGrid.Recordset.First();
            while (!Report.DetailGrid.Recordset.Eof())
            {
                if (Report.FieldByName("Checked").AsInteger == (int)GRSystemImage.grsi3DChecked)
                {
                    GUID.Add(Report.FieldByName("EmpSysID").AsString);
                }
                Report.DetailGrid.Recordset.Next();
            }
            Report.DetailGrid.Recordset.MoveTo(RecNo);
            if (GUID.Count == 0)
            {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorSelectEmp", ""), MessageBoxIcon.Error);
                return;
            }
            new frmSeaOprt(this.Text, CurrentTool, "", 21, GUID).ShowDialog();
        }

        private void ItemSEADelete_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            CurrentTool = ((ToolStripItem)sender).Text;
            new frmSeaOprt(this.Text, CurrentTool, "", 22, null).ShowDialog();
        }


        protected override void GetDelSql(int rowIndex, ref List<string> sql)
        {
            string ret = "";
            string SysID = GetSysID();
            if (SystemInfo.EmpDelete)
            {
                ret = Pub.GetSQL(DBCode.DB_001003, new string[] { "12", SysID });
                sql.Add(ret);
                ret = Pub.GetSQL(DBCode.DB_001003, new string[] { "13", SysID });
                sql.Add(ret);
                ret = Pub.GetSQL(DBCode.DB_001003, new string[] { "14", SysID });
                sql.Add(ret);
                ret = Pub.GetSQL(DBCode.DB_001003, new string[] { "16", SysID });
                sql.Add(ret);
                ret = Pub.GetSQL(DBCode.DB_001003, new string[] { "19", SysID });
                sql.Add(ret);
                ret = Pub.GetSQL(DBCode.DB_002001, new string[] { "4006", SysID });
                sql.Add(ret);
            }
            else
            {
                ret = Pub.GetSQL(DBCode.DB_001003, new string[] { "11", GetSysID() });
                sql.Add(ret);
            }
        }

        protected override string GetDelMsg(int rowIndex)
        {
            string ret = base.GetDelMsg(rowIndex);
            ret = Pub.GetResText(formCode, "EmpNo", "") + "=" + Report.FieldByName("EmpNo").AsString + "," +
              Pub.GetResText(formCode, "CardSectorNo", "") + "=" + Report.FieldByName("CardSectorNo").AsString;
           
            return ret;
        }

        private string GetSysID()
        {
            return Report.FieldByName("EmpSysID").AsString;
        }

        protected override void ExecKeyDown(KeyEventArgs e)
        {
            base.ExecKeyDown(e);
            if (e.Control && e.Alt)
            {
                switch (e.KeyCode)
                {
                    case Keys.D:
                        if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
                        appMainForm.ExecModule("RSEmpDelete", "RS");
                        break;
                }
            }
            
        }

        public void InitRSEmp()
        {
            InitForm();
            this.Text = Pub.GetResText(formCode, "mnuRSEmp", "");
            
        }

        public void ShowCardFa(bool IsForm)
        {
            if (CurrentTool == "") CurrentTool = Pub.GetResText(formCode, "ItemTAG1", "");
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            frmRSEmpCardFa frm = new frmRSEmpCardFa(CurrentTool);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (IsForm) ExecItemRefresh();
            }
           
        }

        public void ShowCardLoss(bool IsForm, string GUID)
        {
            if (CurrentTool == "") CurrentTool = Pub.GetResText(formCode, "ItemTAG2", "");
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            frmRSEmpCardLoss frm = new frmRSEmpCardLoss(this.Text, CurrentTool, GUID);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (IsForm) ExecItemRefresh();
            }
           
        }

        public void ShowCardRelieve(bool IsForm)
        {
            if (CurrentTool == "") CurrentTool = Pub.GetResText(formCode, "ItemTAG3", "");
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            string msg = "";
            string card = "";

            if (SystemInfo.RelieveReqCard)
            {
                string CardData10 = "";
                string CardDataH = "";
                string CardData8 = "";
                if (!Pub.CheckCardExists(ref CardData10, ref CardDataH, ref CardData8)) return;
                HSUNFK.TCardPubData pubData = new HSUNFK.TCardPubData();
                HSUNFK.TCardSFData sfData = new HSUNFK.TCardSFData();
                if (!Pub.CheckCardExists()) return;
                if (!Pub.ReadCardInfo(ref pubData, ref sfData)) return;
                if (!db.CheckCardExists(pubData.CardNo, CardData10)) return;
                if (!db.CheckDepartPowerByCard(pubData.CardNo)) return;
                int CardStatusID = 0;
                if (!db.EmpGetCardStatusID(pubData.CardNo, ref CardStatusID)) return;
                if (CardStatusID != 40)
                {
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "MsgCardNotLoss", ""));
                    return;
                }
                string CardStatusName = "";
                if (!db.EmpGetCardStatusName(pubData.CardNo, ref CardStatusName)) return;
                card = pubData.CardNo;
                double BTMoney = db.GetBTMoney(sfData.BtDate, sfData.BtMonery);
                double AllBalance = sfData.Balance + BTMoney;
                msg = Pub.GetResText(formCode, "MsgCardViewInfo", "");
                msg = string.Format(msg, pubData.EmpNo, pubData.EmpName, pubData.CardNo, pubData.CardTypeID,
                  pubData.MacTAG, CardStatusName, pubData.CardBeginDate, pubData.CardEndDate,
                  AllBalance.ToString(SystemInfo.CurrencySymbol + "0.00"),
                  sfData.Balance.ToString(SystemInfo.CurrencySymbol + "0.00"),
                  BTMoney.ToString(SystemInfo.CurrencySymbol + "0.00"));
                if (Pub.MessageBoxShowQuestion(msg)) return;

                if (SystemInfo.realBack && SystemInfo.DbackEmp)
                {
                    SystemInfo.realHandle = SystemInfo.MainHandle;
                    frmSFMacReal.RealBackCard(1, card);
                }

                if (!db.EmpCardRelieve(this.Text, CurrentTool, pubData.CardNo)) return;
                Pub.CardBuzzer();
            }
            else
            {
                string otherCoin = Pub.GetSQL(DBCode.DB_001003, new string[] { "223" });
                frmPubSelectEmp frmSelect;
                frmSelect = new frmPubSelectEmp(otherCoin);
                if (frmSelect.ShowDialog() != DialogResult.OK) return;
                DataTableReader dr = null;
                string sql = Pub.GetSQL(DBCode.DB_001003, new string[] { "224", OprtInfo.DepartPower, frmSelect.EmpNo });
                bool IsError = false;
                int CardStatusID = 0;
                string CardSectorNo = "";
                msg = Pub.GetResText(formCode, "MsgCardRepairnfo", "");
                try
                {
                    if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                    dr = db.GetDataReader(sql);
                    if (dr.Read())
                    {
                        DateTime CardStartDate = (DateTime)dr["CardStartDate"];
                        DateTime CardEndDate = (DateTime)dr["CardEndDate"];
                        double CardBalance = 0;
                        double.TryParse(dr["CardBalanceBT"].ToString(), out CardBalance);
                        int.TryParse(dr["CardStatusID"].ToString(), out CardStatusID);
                        CardSectorNo = dr["CardSectorNo"].ToString();
                        card = CardSectorNo;
                        msg = string.Format(msg, dr["EmpNo"].ToString(), dr["EmpName"].ToString(), CardSectorNo, dr["CardTypeName"].ToString(),
                          CardStartDate.ToShortDateString(), CardEndDate.ToShortDateString(), CardBalance.ToString(SystemInfo.CurrencySymbol + "0.00"));
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
                if (CardStatusID != 40)
                {
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "MsgCardNotLoss", ""));
                    return;
                }
                if (Pub.MessageBoxShowQuestion(msg)) return;
                if (!db.EmpCardRelieve(this.Text, CurrentTool, CardSectorNo)) return;
            }
            if (IsForm) ExecItemRefresh();
            msg = Pub.GetResText(formCode, "MsgCardRelieveSuccess", "");
            if (Pub.MessageBoxShowQuestion(msg)) return;
            frmRSEmpCardBlack frm = new frmRSEmpCardBlack(card, Pub.GetResText(formCode, "ItemCardBlack", ""));
            //frmRSEmpDelCardBlack frm = new frmRSEmpDelCardBlack(card, Pub.GetResText(formCode, "ItemCardBlack", ""));
            frm.ShowDialog();
           
        }

        public void ShowCardChange(bool IsForm)
        {
            SystemInfo.IsGetData = false;
            if (CurrentTool == "") CurrentTool = Pub.GetResText(formCode, "ItemTAG4", "");
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            string msg = Pub.GetResText(formCode, "MsgCardChangingCard", "");
            // if (Pub.MessageBoxShowQuestion(msg)) return;
            frmSFMacData frm1 = new frmSFMacData(1, CurrentTool);
            frm1.ShowDialog();
            if (!db.IsGetDate()) return;
            
            frmRSEmpCardChange frm = new frmRSEmpCardChange(this.Text, CurrentTool);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (IsForm) ExecItemRefresh();
            }
            if (frm.ShowSFAllowance) appMainForm.ExecModule("SFAllowance", "SF");
           
            frm.ShowSFAllowance = false;

        }

        public void ShowCardRetirement(bool IsForm)
        {
            if (CurrentTool == "") CurrentTool = Pub.GetResText(formCode, "ItemTAG5", "");
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            string msg = Pub.GetResText(formCode, "MsgCardRetirementCard", "");
            //if (Pub.MessageBoxShowQuestion(msg)) return;
            frmRSEmpCardRetirement frm = new frmRSEmpCardRetirement(this.Text, CurrentTool, msg);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (IsForm) ExecItemRefresh();
            }
            if (frm.ShowSFAllowance) appMainForm.ExecModule("SFAllowance", "SF");
            frm.ShowSFAllowance = false;
            
        }

        public void ShowCardRepair(bool IsForm)
        {
            SystemInfo.IsGetData = false;
            if (CurrentTool == "") CurrentTool = Pub.GetResText(formCode, "ItemTAG6", "");
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            string msg = Pub.GetResText(formCode, "MsgCardRepairCard", "");
            //if (Pub.MessageBoxShowQuestion(msg)) return;
            frmSFMacData frm1 = new frmSFMacData(1, CurrentTool);
            frm1.ShowDialog();
            if (!db.IsGetDate()) return;
            formCode = "RSEmp";
            string CardData10 = "";
            string CardDataH = "";
            string CardData8 = "";
            string CardNo10 = "";
            string CardNoH = "";
            string CardNo8 = "";
            string ErrMsg = "";
            int CardStatusID = 0;
            string EmpSysID = "";
            double BtMonery = 0;
            string BtDate = "000000";
            double ShowBtMonery = 0;
            if (!Pub.CheckCardExists(ref CardData10, ref CardDataH, ref CardData8)) return;
            HSUNFK.TCardPubData pubData = new HSUNFK.TCardPubData();
            if (!Pub.ReadCardInfo(ref pubData)) return;
            string CardSectorNo = pubData.CardNo;
            //if (!SystemInfo.AllowCustomerCardNo) CardSectorNo = CardData10;
            if (!db.CheckCardExists(CardSectorNo, CardData10, ref ErrMsg))
            {
                if (!db.EmpGetCardStatusIDByCardPhysicsNo(CardData10, ref EmpSysID, ref CardSectorNo, ref CardStatusID)) return;
                if (CardStatusID != 70)
                {
                    Pub.ShowErrorMsg(ErrMsg);
                    return;
                }
            }
            if (!db.CheckDepartPowerByCard(CardSectorNo)) return;
            if (!db.EmpGetCardStatusID(CardSectorNo, ref CardStatusID))
            {
                if (!db.EmpGetCardStatusIDByCardPhysicsNo(CardData10, ref EmpSysID, ref CardSectorNo, ref CardStatusID)) return;
            }
            if ((CardStatusID != 70) && (CardStatusID != 20))
            {
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "MsgCardRepairNotNormal", ""));
                return;
            }
            DataTableReader dr = null;
            bool IsError = false;
            double CardBalanceBT = 0;
            double CardBalance = 0;
            DateTime CardUseDate = new DateTime();
            int CardUseTimes = 0;
            msg = Pub.GetResText(formCode, "MsgCardRepairnfo", "") + "\r\n\r\n" +
              Pub.GetResText(formCode, "MsgCardRepairCardOk", "");
            try
            {
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "215", CardSectorNo }));
                if (dr.Read())
                {
                    EmpSysID = dr["EmpSysID"].ToString();
                    int.TryParse(dr["CardUseTimes"].ToString(), out CardUseTimes);
                    DateTime.TryParse(dr["CardUseDate"].ToString(), out CardUseDate);
                    double.TryParse(dr["CardBalanceBT"].ToString(), out CardBalanceBT);
                    double.TryParse(dr["CardBalance"].ToString(), out CardBalance);
                    double.TryParse(dr["CardBTMoney"].ToString(), out BtMonery);
                    ShowBtMonery = CardBalanceBT;
                    if (CardStatusID == 70)
                    {
                        if ((pubData.CardNo != "") && (Convert.ToUInt32(pubData.CardNo) > 0))
                        {
                            HSUNFK.TCardSFData sfd = new HSUNFK.TCardSFData();
                            if (Pub.ReadCardInfo(ref sfd) && sfd.UseTimes > 0)
                            {
                                CardBalance = sfd.Balance;
                                CardUseTimes = sfd.UseTimes;
                                CardUseDate = sfd.UseDate;
                                BtMonery = sfd.BtMonery;
                                BtDate = sfd.BtDate;
                                ShowBtMonery = CardBalance + db.GetBTMoney(sfd.BtDate, sfd.BtMonery);
                            }
                        }
                        pubData.CardNo = CardSectorNo;
                        pubData.EmpNo = dr["EmpNo"].ToString();
                        pubData.EmpName = dr["EmpName"].ToString();
                        pubData.CardTypeID = Convert.ToByte(dr["CardTypeID"]);
                        pubData.CardPWD = dr["CardPWD"].ToString();
                        if ((pubData.CardPWD == "") || (!Pub.IsNumeric(pubData.CardPWD))) pubData.CardPWD = "000000";
                        if (Convert.ToInt32(pubData.CardPWD) > 999999) pubData.CardPWD = "000000";
                        pubData.DealersCode = SystemInfo.DealersCode;
                        pubData.CustomersCode = SystemInfo.CustomersCode;
                        pubData.CardBeginDate = ((DateTime)dr["CardStartDate"]).Date;
                        pubData.CardEndDate = ((DateTime)dr["CardEndDate"]).Date;
                        pubData.IsCheckOrder = Convert.ToByte(Pub.ValueToBool(dr["CardCheckOrder"].ToString()));
                    }
                    else
                    {
                        BtDate = "";
                        if (dr["LastBTFlag"].ToString() != "")
                        {
                            DateTime dd = new DateTime();
                            if (DateTime.TryParse(dr["LastBTFlag"].ToString(), out dd))
                            {
                                BtDate = dd.ToString("yyMMdd");
                                BtDate = DeviceObject.objCPIC.NumToHex(BtDate.Substring(0, 2), 1) +
                                  DeviceObject.objCPIC.NumToHex(BtDate.Substring(2, 2), 1) +
                                  DeviceObject.objCPIC.NumToHex(BtDate.Substring(4, 2), 1);
                            }
                        }
                    }
                    msg = string.Format(msg, dr["EmpNo"].ToString(), dr["EmpName"].ToString(), CardSectorNo, pubData.CardTypeID,
                      pubData.CardBeginDate.ToShortDateString(), pubData.CardEndDate.ToShortDateString(),
                      ShowBtMonery.ToString(SystemInfo.CurrencySymbol + "0.00"), CardBalance.ToString(SystemInfo.CurrencySymbol + "0.00"), BtMonery.ToString(SystemInfo.CurrencySymbol + "0.00"));
                }
                else
                {
                    IsError = true;
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "MsgCardRepairNotNormal", ""));
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
            if (CardBalanceBT < 0)
            {
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "Msg001", ""));
                return;
            }
            string CardNoDays = "";
            if (db.CardSectorNoIsExists(EmpSysID, CardSectorNo, ref CardNoDays))
            {
                string msgTmp = "";
                DateTime d = new DateTime();
                if (CardNoDays == " ")
                    msgTmp = Pub.GetResText(formCode, "MsgCardExistsBlackAgain", "");
                else if (DateTime.TryParse(CardNoDays, out d))
                    msgTmp = Pub.GetResText(formCode, "MsgCardExistsUseDaysAgain", "");
                else
                    msgTmp = Pub.GetResText(formCode, "MsgCardExistsUseingAgain", "");
                msgTmp = string.Format(msgTmp, CardSectorNo, CardNoDays);
                Pub.ShowErrorMsg(msgTmp);
                return;
            }
            DateTime dt = new DateTime();
            if (!db.GetServerDate(ref dt)) return;
            if (Pub.MessageBoxShowQuestion(msg)) return;
            if (CardUseDate.Year < 2000) CardUseDate = dt;
            HSUNFK.TCardSFData sfData = new HSUNFK.TCardSFData();
            sfData.Balance = CardBalance;
            sfData.UseDate = CardUseDate;
            sfData.UseTimes = CardUseTimes;
            sfData.BtMonery = BtMonery;
            sfData.BtDate = BtDate;
            IsError = false;
            int cardRet = 0;
        ContinuePS:
            Application.DoEvents();
            if (IsError)
            {
                CardNo10 = "";
                CardNoH = "";
                CardNo8 = "";
                if (!Pub.CheckCardExists(ref CardNo10, ref CardNoH, ref CardNo8, false))
                {
                    if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "ReadCardError3", "") + "\r\n\r\n" +
                      Pub.GetResText(formCode, "MsgContinue", "")))
                        return;
                    else
                        goto ContinuePS;
                }
                if (CardNo10 != CardData10)
                {
                    if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "MsgCardSame", "")))
                        return;
                    else
                        goto ContinuePS;
                }
                IsError = false;
            }
            if (CardStatusID == 70)
            {
                HSUNFK.TCardSKData skData = new HSUNFK.TCardSKData();
                skData.CardID = pubData.CardNo;
                skData.CardTime = CardUseDate;
                cardRet = Pub.WriteCardInfo(pubData, sfData, skData);
            }
            else
                cardRet = Pub.WriteCardInfo(sfData);
            if (cardRet != 0)
            {
                if (Pub.MessageBoxShowQuestion(Pub.GetCardMsg(cardRet) + Pub.GetResText(formCode, "MsgContinue", "")))
                    return;
                else
                {
                    IsError = true;
                    goto ContinuePS;
                }
            }
            List<string> sql = new List<string>();
            if (CardStatusID == 70)
                sql.Add(Pub.GetSQL(DBCode.DB_001003, new string[] { "234", CardSectorNo,
          sfData.UseDate.ToString(SystemInfo.SQLDateTimeFMT), sfData.UseTimes.ToString(),
          ShowBtMonery.ToString(), EmpSysID }));
            sql.Add(Pub.GetSQL(DBCode.DB_001003, new string[] { "235", EmpSysID, CardSectorNo, "90", OprtInfo.OprtSysID }));
        ContinueData:
            if (db.ExecSQL(sql) == 1)
            {
                if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "ErrorCardDB", "")))
                    return;
                else
                {
                    IsError = true;
                    goto ContinueData;
                }
            }
            db.WriteSYLog(this.Text, CurrentTool, msg);
            Pub.CardBuzzer();

            if (IsForm) ExecItemRefresh();
            Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgCardRepairCardSuccess", ""), MessageBoxIcon.Information);
           
        }
        public void ShowRSDimissionAdd(bool IsForm)
        {
            if (CurrentTool == "") CurrentTool = Pub.GetResText(formCode, "ItemTAG8", "");
            SystemInfo.IsDimission = true;
            frmRSDimissionAdd frm = new frmRSDimissionAdd(this.Text, CurrentTool, GetSysID(),true);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (IsForm) ExecItemRefresh();
            }
            SystemInfo.IsDimission = false;
            
        }

        public void ShowCardView(bool IsForm)
        {
            if (CurrentTool == "") CurrentTool = Pub.GetResText(formCode, "ItemTAG7", "");
            string CardData10 = "";
            string CardDataH = "";
            string CardData8 = "";
            if (!Pub.CheckCardExists(ref CardData10, ref CardDataH, ref CardData8)) return;
            HSUNFK.TCardPubData pubData = new HSUNFK.TCardPubData();
            HSUNFK.TCardSFData sfData = new HSUNFK.TCardSFData();
            if (!Pub.ReadCardInfo(ref pubData, ref sfData)) return;
            if (!db.CheckCardExists(pubData.CardNo, CardData10)) return;
            if (!db.CheckDepartPowerByCard(pubData.CardNo)) return;
            string CardStatusName = "";
            if (!db.EmpGetCardStatusName(pubData.CardNo, ref CardStatusName)) return;
            double BTMoney = db.GetBTMoney(sfData.BtDate, sfData.BtMonery);
            double AllBalance = sfData.Balance + BTMoney;
            string msg = Pub.GetResText(formCode, "MsgCardViewInfo", "");
            msg = string.Format(msg, pubData.EmpNo, pubData.EmpName, pubData.CardNo, pubData.CardTypeID,
              pubData.MacTAG, CardStatusName, pubData.CardBeginDate.ToShortDateString(), pubData.CardEndDate.ToShortDateString(),
              AllBalance.ToString(SystemInfo.CurrencySymbol + "0.00"),
              sfData.Balance.ToString(SystemInfo.CurrencySymbol + "0.00"),
              BTMoney.ToString(SystemInfo.CurrencySymbol + "0.00"));
            Pub.CardBuzzer();
            DispExtScreen(0, AllBalance, 2, 0);
            Pub.MessageBoxShow(msg, MessageBoxIcon.Information);
            
        }

        public void ShowCardModify(bool IsForm)
        {
            if (CurrentTool == "") CurrentTool = Pub.GetResText(formCode, "CardModify", "");
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            frmRSEmpCardModify frm = new frmRSEmpCardModify(this.Text, CurrentTool);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (IsForm) ExecItemRefresh();
            }
            
        }


        public void ShowCardBlack(bool IsForm)
        {
            if (CurrentTool == "") CurrentTool = Pub.GetResText(formCode, "ItemCardBlack", "");
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            frmRSEmpCardBlack frm = new frmRSEmpCardBlack("", CurrentTool);

            frm.ShowDialog();
           
        }

        private void ShowRSEmpFace(byte flag)
        {
            frmRSEmpFace frm = new frmRSEmpFace(this.Text, CurrentTool, GetSysID(), flag);
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
           
        }

        protected override void ExecTreeAfterSelect()
        {
            QuerySQL = Pub.GetSQL(DBCode.DB_001003, new string[] { "257", FindSQL, FindOrderBy, nodeDepartID, nodeDepartList });
            base.ExecTreeAfterSelect();
        }
    }
}