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
    public partial class frmRSEmpDelete : frmBaseMDIChildReport
    {
        protected override void InitForm()
        {
            formCode = "RSEmpDelete";
            ReportFile = "RSEmpDelete";
            SetToolItemState("ItemImport", false);
            SetToolItemState("ItemAdd", false);
            SetToolItemState("ItemEdit", false);
            SetToolItemState("ItemLine2", false);
            SetToolItemState("ItemTAG1", true);
            SetToolItemState("ItemLine5", true);
            SetToolItemState("ItemSearch", true);
            SetToolItemState("ItemFindLabel", true);
            SetToolItemState("ItemFindText", true);
            ReportStartIndex = 3;
            AllowCheckOprtRole = false;
            base.InitForm();
            QuerySQL = Pub.GetSQL(DBCode.DB_001003, new string[] { "701", OprtInfo.DepartPower });
            FindSQL = Pub.GetSQL(DBCode.DB_001003, new string[] { "702", OprtInfo.DepartPower });
            FindOrderBy = Pub.GetSQL(DBCode.DB_001003, new string[] { "703" });
            FindKeyWord = formCode;
            if (SystemInfo.HasFaCard)
            {
                SetReportColumnVisible("CardSectorNo", true);
                SetReportColumnVisible("CardPhysicsNo10", false);
            }
            else
            {
                SetReportColumnVisible("CardSectorNo", false);
                SetReportColumnVisible("CardPhysicsNo10", true);
            }
            ItemFindText.ToolTipText = Pub.GetResText("", "lblQuickSearchToolTipCard", "");
        }

        public frmRSEmpDelete()
        {
            InitializeComponent();
        }

        protected override void ExecItemTAG1()
        {
            DateTime StartTime = DateTime.Now;
            contextMenu.Close();
            string msg = Pub.GetResText(formCode, "Msg001", "");
            RefreshMsg(msg);
            List<string> sql = new List<string>();
            int RecNo = Report.DetailGrid.Recordset.RecordNo;
            while (!Report.DetailGrid.Recordset.Eof())
            {
                if (Report.FieldByName("Checked").AsInteger == (int)GRSystemImage.grsi3DChecked)
                {
                    sql.Add(Pub.GetSQL(DBCode.DB_001003, new string[] { "704", GetSysID() }));
                }
                Report.DetailGrid.Recordset.Next();
            }
            Report.DetailGrid.Recordset.MoveTo(RecNo);
            if (sql.Count == 0)
            {
                RefreshMsg("");
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", ""));
                return;
            }
            if (db.ExecSQL(sql) != 0) return;
            db.WriteSYLog(this.Text, CurrentTool, msg);
            ExecItemRefresh();
            msg = string.Format(Pub.GetResText(formCode, "Msg002", ""), sql.Count);
            RefreshMsg(msg + Pub.GetDateDiffTimes(StartTime, DateTime.Now, true), true);
           
        }

        protected override void ExecItemFindText()
        {
            QuerySQL = Pub.GetSQL(DBCode.DB_001003, new string[] { "705", ItemFindText.Text.Trim(), OprtInfo.DepartPower });
            ExecItemRefresh();
        }

        protected override void GetDelSql(int rowIndex, ref List<string> sql)
        {
            string ret = "";
            ret = Pub.GetSQL(DBCode.DB_001003, new string[] { "12", GetSysID() });
            sql.Add(ret);
            ret = Pub.GetSQL(DBCode.DB_001003, new string[] { "13", GetSysID() });
            sql.Add(ret);
            ret = Pub.GetSQL(DBCode.DB_001003, new string[] { "14", GetSysID() });
            sql.Add(ret);
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
    }
}