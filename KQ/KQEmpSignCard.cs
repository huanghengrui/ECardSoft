using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmKQEmpSignCard : frmBaseMDIChildReport
    {
        protected override void InitForm()
        {
            formCode = "KQEmpSignCard";
            ReportFile = "KQEmpSignCard";
            SetToolItemState("ItemImport", false);
            SetToolItemState("ItemEdit", false);
            SetToolItemState("ItemLine5", true);
            SetToolItemState("ItemSearch", true);
            SetToolItemState("ItemFindLabel", true);
            SetToolItemState("ItemFindText", true);
            ReportStartIndex = 4;
            IgnoreRefreshFirst = true;
            CheckForward = false;
            base.InitForm();
            QuerySQL = Pub.GetSQL(DBCode.DB_002011, new string[] { "0", OprtInfo.DepartPower });
            FindSQL = Pub.GetSQL(DBCode.DB_002011, new string[] { "1", OprtInfo.DepartPower });
            FindOrderBy = Pub.GetSQL(DBCode.DB_002011, new string[] { "2" });
            FindKeyWord = formCode;
            RefreshForm(true);
        }

        public frmKQEmpSignCard()
        {
            InitializeComponent();
        }

        protected override void ExecItemAdd()
        {
            base.ExecItemAdd();
            frmKQEmpSignCardAdd frm = new frmKQEmpSignCardAdd(this.Text, CurrentTool, "");
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
            
        }

        protected override void ExecItemFindText()
        {
            QuerySQL = Pub.GetSQL(DBCode.DB_002011, new string[] { "101", ItemFindText.Text.Trim(), OprtInfo.DepartPower });
            ExecItemRefresh();
           
        }

        protected override void GetDelSql(int rowIndex, ref List<string> sql)
        {
            string GUID = Report.FieldByName("GUID").AsString;
            sql.Add(Pub.GetSQL(DBCode.DB_002011, new string[] { "3", GUID }));
        }

        protected override string GetDelMsg(int rowIndex)
        {
            string ret = base.GetDelMsg(rowIndex);
            ret = Pub.GetResText(formCode, "EmpNo", "") + "=" + Report.FieldByName("EmpNo").AsString + "," +
              Pub.GetResText(formCode, "CardKQDate", "") + "=" + Report.FieldByName("KQDate").AsString + "," +
              Pub.GetResText(formCode, "CardKQTime", "") + "=" + Report.FieldByName("KQTime").AsString;
            return ret;
        }
    }
}