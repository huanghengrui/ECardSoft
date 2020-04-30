using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmKQPassTime : frmBaseMDIChildReport
    {
        private string title = "";

        protected override void InitForm()
        {
            SetToolItemState("ItemImport", false);
            SetToolItemState("ItemAdd", false);
            SetToolItemState("ItemDelete", false);
            formCode = "KQPassTime";
            ReportFile = "KQPassTime";
            ReportStartIndex = 2;
            base.InitForm();
            this.Text = title;
            QuerySQL = Pub.GetSQL(DBCode.DB_002001, new string[] { "3000" });
            Rectangle rect = Screen.PrimaryScreen.WorkingArea;
            this.Left = rect.Left;
            this.Top = rect.Top;
            this.Width = rect.Width;
            this.Height = rect.Height;
        }

        public frmKQPassTime(string Title)
        {
            title = Title;
            InitializeComponent();
        }

        protected override void ExecItemAdd()
        {
            base.ExecItemAdd();
            frmKQPassTimeAdd frm = new frmKQPassTimeAdd(this.Text, CurrentTool, "");
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
           
        }

        protected override void ExecItemEdit()
        {
            base.ExecItemEdit();
            frmKQPassTimeAdd frm = new frmKQPassTimeAdd(this.Text, CurrentTool, Report.FieldByName("PassTimeID").AsString);
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
           
        }

        protected override void GetDelSql(int rowIndex, ref List<string> sql)
        {
            string ret = Pub.GetSQL(DBCode.DB_002001, new string[] { "3001", Report.FieldByName("PassTimeID").AsString });
            sql.Add(ret);
        }

        protected override string GetDelMsg(int rowIndex)
        {
            string ret = Pub.GetResText(formCode, "PassTimeID", "") + "=" + Report.FieldByName("PassTimeID").AsString;
            return ret;
        }

        protected override void RefreshForm(bool State)
        {
            base.RefreshForm(State);
            ItemTAG1.Enabled = State;
        }
    }
}