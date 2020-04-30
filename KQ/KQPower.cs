using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using grproLib;

namespace ECard78
{
    public partial class frmKQPower : frmBaseMDIChildReportPrint
    {
        private string title = "";

        protected override void InitForm()
        {
            SetToolItemState("ItemImport", false);
            formCode = "KQPower";
            ReportFile = "KQPower";
            ReportStartIndex = 3;
            base.InitForm();
            SetToolItemState("ItemAdd", true);
            SetToolItemState("ItemEdit", true);
            SetToolItemState("ItemDelete", true);
            SetToolItemState("ItemLine2", true);
            this.Text = title;
            QuerySQL = Pub.GetSQL(DBCode.DB_002001, new string[] { "4000"});
            Rectangle rect = Screen.PrimaryScreen.WorkingArea;
            this.Left = rect.Left;
            this.Top = rect.Top;
            this.Width = rect.Width;
            this.Height = rect.Height;
            clbMacSN.Enabled = false;
            DataTableReader dr = null;
            try
            {
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004004, new string[] { "0" }));
                while (dr.Read())
                {
                    clbMacSN.Items.Add(dr["MacSN"].ToString());
                    clbMacSN.SetItemChecked(clbMacSN.Items.Count - 1, false);
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            base.ExecItemRefresh();
        }

        public frmKQPower(string Title)
        {
            title = Title;
            InitializeComponent();
        }

        protected override void ExecItemAdd()
        {
            base.ExecItemAdd();
            frmKQPowerAdd frm = new frmKQPowerAdd(this.Text, CurrentTool);
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
            formCode = "KQPower";
        }

        protected override void ExecItemEdit()
        {
            base.ExecItemEdit();
            frmKQPowerEdit frm = new frmKQPowerEdit(this.Text, CurrentTool, Report.FieldByName("EmpSysID").AsString,
               Report.FieldByName("MacSN").AsString);
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
        }

        protected override void GetDelSql(int rowIndex, ref List<string> sql)
        {
            string ret = Pub.GetSQL(DBCode.DB_002001, new string[] { "4002", Report.FieldByName("MacSN").AsString,
        Report.FieldByName("EmpSysID").AsString  });
            sql.Add(ret);
        }

        protected override string GetDelMsg(int rowIndex)
        {
            string ret = base.GetDelMsg(rowIndex);
            ret = "[" + Report.FieldByName("EmpNo").AsString + "]" + Report.FieldByName("EmpName").AsString +
              " [" + Report.FieldByName("MacSN").AsString + "]";
            return ret;
        }

        protected override void ExecItemRefresh()
        {
            string EmpTag = "0";
            string EmpNo = "";
            string MacSN = "";
            if ((txtEmp.Text.Trim() != "") && (txtEmp.Tag != null))
            {
                EmpNo = txtEmp.Tag.ToString();
                EmpTag = "1";
            }
            else if (txtEmp.Text.Trim() != "")
            {
                EmpNo = txtEmp.Text.Trim();
            }
            if (chkMacSN.Checked)
            {
                for (int i = 0; i < clbMacSN.Items.Count; i++)
                {
                    if (clbMacSN.GetItemChecked(i)) MacSN = MacSN + "'" + clbMacSN.Items[i].ToString() + "',";
                }
                if (MacSN != "") MacSN = MacSN.Substring(0, MacSN.Length - 1);
            }
            QuerySQL = Pub.GetSQL(DBCode.DB_002001, new string[] { "4000", EmpTag, EmpNo, MacSN });
            base.ExecItemRefresh();
        }
        protected override void RefreshForm(bool State)
        {
            base.RefreshForm(State);
            ItemTAG1.Enabled = State;
        }

        private void btnSelectEmp_Click(object sender, EventArgs e)
        {
            frmPubSelectEmp frm = new frmPubSelectEmp();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtEmp.Text = frm.EmpName;
                txtEmp.Tag = frm.EmpNo;
                ExecItemRefresh();
            }
        }

        private void chkMacSN_CheckedChanged(object sender, EventArgs e)
        {
            clbMacSN.Enabled = chkMacSN.Checked;
        }
    }
}