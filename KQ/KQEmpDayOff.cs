using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmKQEmpDayOff : frmBaseMDIChildReport
    {
        protected override void InitForm()
        {
            formCode = "KQEmpDayOff";
            ReportFile = "KQEmpDayOff";
            SetToolItemState("ItemImport", false);
            SetToolItemState("ItemLine5", true);
            SetToolItemState("ItemSearch", true);
            SetToolItemState("ItemFindLabel", true);
            SetToolItemState("ItemFindText", true);
            ReportStartIndex = 4;
            CheckForward = false;
            base.InitForm();
            QuerySQL = Pub.GetSQL(DBCode.DB_002008, new string[] { "0", OprtInfo.DepartPower });
            FindSQL = Pub.GetSQL(DBCode.DB_002008, new string[] { "1", OprtInfo.DepartPower });
            FindOrderBy = Pub.GetSQL(DBCode.DB_002008, new string[] { "2" });
            FindKeyWord = formCode;
        }

        public frmKQEmpDayOff()
        {
            InitializeComponent();
        }

        protected override void ExecItemAdd()
        {
            base.ExecItemAdd();
            frmKQEmpDayOffAdd frm = new frmKQEmpDayOffAdd(this.Text, CurrentTool, "");
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
           
        }

        protected override void ExecItemEdit()
        {
            base.ExecItemEdit();
            if (!db.CheckDepartPowerByEmpSysID(Report.FieldByName("EmpSysID").AsString)) return;
            frmKQEmpDayOffAdd frm = new frmKQEmpDayOffAdd(this.Text, CurrentTool, Report.FieldByName("GUID").AsString);
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
           
        }

        protected override void ExecItemFindText()
        {
            QuerySQL = Pub.GetSQL(DBCode.DB_002008, new string[] { "101", ItemFindText.Text.Trim(), OprtInfo.DepartPower });
            ExecItemRefresh();
        }

        protected override void GetDelSql(int rowIndex, ref List<string> sql)
        {
            string EmpSysID = Report.FieldByName("EmpSysID").AsString;
            string DayoffBillNo = Report.FieldByName("DayoffBillNo").AsString;
            sql.Add(Pub.GetSQL(DBCode.DB_002008, new string[] { "3", EmpSysID, DayoffBillNo }));
        }

        protected override string GetDelMsg(int rowIndex)
        {
            string ret = base.GetDelMsg(rowIndex);
            ret = Pub.GetResText(formCode, "EmpNo", "") + "=" + Report.FieldByName("EmpNo").AsString + "," +
              Pub.GetResText(formCode, "DayoffBillNo", "") + "=" + Report.FieldByName("DayoffBillNo").AsString;
            return ret;
        }
    }
}