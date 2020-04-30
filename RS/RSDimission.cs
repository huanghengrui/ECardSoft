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
    public partial class frmRSDimission : frmBaseMDIChildReport
    {
        protected override void InitForm()
        {
            formCode = "RSDimission";
            ReportFile = "RSDimission";
            SetToolItemState("ItemTAG1", true);
            SetToolItemState("ItemFindLabel", true);
            SetToolItemState("ItemFindText", true);
            SetToolItemState("ItemDelete", false);
          //  AddExtDropDownItem("ItemClearInfoDim", ItemClearInfoDim_Click);
            ReportStartIndex = 3;
            base.InitForm();
            QuerySQL = Pub.GetSQL(DBCode.DB_001003, new string[] { "22","", OprtInfo.DepartPower });
            FindKeyWord = formCode;
            ImportShowDepart = true;

            ImportFieldList = new string[] { "EmpNo", "EmpName", "EmpSexName", "DepartID", "DepartName", "CardTypeID",
        "EmpHireDate", "EmpCertNo", "EmpAddress", "EmpZipNo", "EmpPhoneNo", "EmpEmail", "CardSectorNo",
        "CardPWD", "CardStartDate", "CardEndDate", "CardFingerNo", "OtherCardNo" , "OldCardNO","DimissionDate","DimissionReason"};
            if ((SystemInfo.KQFlag != 1) && (SystemInfo.KQFlag != 2))
            {
                SetReportColumnVisible("CardFingerNo", false);
            }
            DeviceObject.objCard.IDCardInit();
            ItemFindText.ToolTipText = Pub.GetResText("", "lblQuickSearchToolTipCard", "");
        }

        protected override void FreeForm()
        {
            DeviceObject.objCard.IDCardFree();
            base.FreeForm();
        }

        public frmRSDimission()
        {
            InitializeComponent();
        }

        private void ShowAdd()
        {
            frmRSDimissionAdd frm = new frmRSDimissionAdd(this.Text, CurrentTool, "",false);
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
           
        }

        protected override void ExecItemAdd()
        {
            SystemInfo.IsDimission = true;
            base.ExecItemAdd();
            ShowAdd();
            SystemInfo.IsDimission = false;
        }

        protected override void ExecItemEdit()
        {
            SystemInfo.IsDimission = true;
            base.ExecItemEdit();
            string SysID = GetSysID();
            if (!db.CheckDepartPowerByEmpSysID(SysID)) return;
            frmRSDimissionAdd frm = new frmRSDimissionAdd(this.Text, CurrentTool, SysID,false);
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
            SystemInfo.IsDimission = false;
         
        }

        private void ItemClearInfoDim_Click(object sender, EventArgs e)
        {
            SystemInfo.IsDelDimission = true;
            contextMenu.Close();
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            CurrentTool = ((ToolStripItem)sender).Text;
            ShowRSEmpDim(2);
            SystemInfo.IsDelDimission = false;
         
        }

        private void ShowRSEmpDim(byte flag)
        {
            frmRSEmpFace frm = new frmRSEmpFace(this.Text, CurrentTool, GetSysID(), flag);
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
      
        }
        protected override void ExecItemDelete()
        {
            //int CardStatusID = 0;
            //string msg = Pub.GetResText(formCode, "Error105", "");
            //int RecNo = Report.DetailGrid.Recordset.RecordNo;
            //Report.DetailGrid.Recordset.First();
            //while (!Report.DetailGrid.Recordset.Eof())
            //{
            //  if (Report.FieldByName("Checked").AsInteger == (int)GRSystemImage.grsi3DChecked)
            //  {
            //    CardStatusID = Report.FieldByName("CardStatusID").AsInteger;
            //    if ((CardStatusID != 10) && (CardStatusID != 60))
            //    {
            //      msg = string.Format(msg, Report.FieldByName("EmpNo").AsString, Report.FieldByName("CardStatusName").AsString);
            //      Pub.MessageBoxShow(msg);
            //      return;
            //    }
            //  }
            //  Report.DetailGrid.Recordset.Next();
            //}
            //Report.DetailGrid.Recordset.MoveTo(RecNo);
            //base.ExecItemDelete();
        }

        protected override void ExecItemImport()
        {
            base.ExecItemImport();
         
        }

        protected override void ExecItemImportAfter()
        {
            db.UpdateEmpInfoCount(this.Text);
       
        }

        protected override void ExecItemTAG1()
        {
            base.ExecItemTAG1();
            string msg = Pub.GetResText(formCode, "Error105", "");
            int RecNo = Report.DetailGrid.Recordset.RecordNo;
            Report.DetailGrid.Recordset.First();
            List<string> sql = new List<string>();
            while (!Report.DetailGrid.Recordset.Eof())
            {
                if (Report.FieldByName("Checked").AsInteger == (int)GRSystemImage.grsi3DChecked)
                {
                    sql.Add(Pub.GetSQL(DBCode.DB_001003, new string[] { "24", Report.FieldByName("EmpNo").AsString }));
                }
                Report.DetailGrid.Recordset.Next();
            }
            Report.DetailGrid.Recordset.MoveTo(RecNo);
            if (db.ExecSQL(sql) != 0) return;
            db.WriteSYLog(this.Text, ItemTAG1.Text, sql);
            ExecItemRefresh();
          
        }

        protected override void ExecItemFindText()
        {
            QuerySQL = Pub.GetSQL(DBCode.DB_001003, new string[] { "22", ItemFindText.Text.Trim(), OprtInfo.DepartPower });
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
    }
}