using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSFReportOrderDetail : frmBaseMDIChildReportPrint
    {
        private bool AllowShowManual = false;

        protected override void InitForm()
        {
            formCode = "SFReportOrderDetail";
            ReportFile = "SFReportOrderDetail";
            SetToolItemState("ItemTAG1", true);
            base.InitForm();
            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEnd.Value = DateTime.Now.Date;
        }

        public frmSFReportOrderDetail()
        {
            InitializeComponent();
        }

        protected override void ExecItemTAG1()
        {
            base.ExecItemTAG1();
            frmSFOrderManual frm = new frmSFOrderManual(this.Text, CurrentTool);
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
           
        }

        protected override void ExecItemRefresh()
        {
            string EmpTag = "0";
            string EmpNo = "";
            string DepartTag = "0";
            string DepartID = "";
            string DepartList = "";
            if ((txtEmp.Text.Trim() != "") && (txtEmp.Tag != null))
            {
                EmpNo = txtEmp.Tag.ToString();
                EmpTag = "1";
            }
            else if (txtEmp.Text.Trim() != "")
            {
                EmpNo = txtEmp.Text.Trim();
            }
            if ((txtDepart.Text.Trim() != "") && (txtDepart.Tag != null))
            {
                DepartID = txtDepart.Tag.ToString();
                DepartTag = "1";
            }
            else if (txtDepart.Text.Trim() != "")
            {
                DepartID = txtDepart.Text.Trim();
            }
            if (DepartTag == "1")
            {
                if (DepartID != "") DepartList = db.GetDepartChildID(DepartID);
                if (DepartList == "") DepartList = "''";
            }
            byte flag = 0;
            if (rbAll.Checked)
                flag = 0;
            else if (rbOrderSF.Checked)
                flag = 1;
            else if (rbNotOrderSF.Checked)
                flag = 2;
            else if (rbOrderNoSF.Checked)
                flag = 3;
            QuerySQL = Pub.GetSQL(DBCode.DB_004010, new string[] { flag.ToString(), EmpTag, EmpNo, DepartTag, DepartID, DepartList,
        dtpStart.Value.ToString(SystemInfo.SQLDateFMT), dtpEnd.Value.ToString(SystemInfo.SQLDateFMT), OprtInfo.DepartPower });
            SetReportDate(dispView, label4.Text + ": " + dtpStart.Value.ToShortDateString() + " - " + dtpEnd.Value.ToShortDateString());
            base.ExecItemRefresh();
            SetReportTitle(dispView, this.Text);
        }

        protected override void RefreshForm(bool State)
        {
            ItemTAG1.Visible = AllowShowManual;
            base.RefreshForm(State);
            ItemTAG1.Enabled = AllowShowManual;
            SetContextMenuVisible(ItemTAG1.Name, AllowShowManual);
            SetContextMenuState();
        }

        private void btnSelectEmp_Click(object sender, EventArgs e)
        {
            frmPubSelectEmp frm = new frmPubSelectEmp();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtEmp.Text = frm.EmpName;
                txtEmp.Tag = frm.EmpNo;
            }
          
        }

        private void btnSelectDepart_Click(object sender, EventArgs e)
        {
            frmPubSelectDepart frm = new frmPubSelectDepart();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtDepart.Text = frm.DepartName;
                txtDepart.Tag = frm.DepartID;
            }
         
        }

        private void txtEmp_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtEmp.Tag = null;
        }

        private void txtDepart_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtDepart.Tag = null;
        }

        private void RadioButton_Click(object sender, EventArgs e)
        {
            ExecItemRefresh();
        }

        protected override void ExecKeyDown(KeyEventArgs e)
        {
            base.ExecKeyDown(e);
            if (e.Control && e.Alt)
            {
                switch (e.KeyCode)
                {
                    case Keys.M:
                        AllowShowManual = true;
                        RefreshForm(true);
                        break;
                }
            }
        }
    }
}