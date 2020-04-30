using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSFReportOrderTotal : frmBaseMDIChildReportPrint
    {
        int flag = -1;

        protected override void InitForm()
        {
            formCode = "SFReportOrderTotal";
            ReportFile = "";
            base.InitForm();
            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEnd.Value = DateTime.Now.Date;
            RadioButton_Click(null, null);
        }

        public frmSFReportOrderTotal()
        {
            InitializeComponent();
        }

        private void RadioButton_Click(object sender, EventArgs e)
        {
            int tmpFlag = 0;
            string tmpReportFile = "";
            if (rbEmp.Checked)
            {
                tmpFlag = 4;
                tmpReportFile = "SFReportOrderTotalA";
            }
            else if (rbDept.Checked)
            {
                tmpFlag = 5;
                tmpReportFile = "SFReportOrderTotalB";
            }
            else if (rbDate.Checked)
            {
                tmpFlag = 6;
                tmpReportFile = "SFReportOrderTotalC";
            }
            else if (rbCardType.Checked)
            {
                tmpFlag = 7;
                tmpReportFile = "SFReportOrderTotalD";
            }
            else if (rbMac.Checked)
            {
                tmpFlag = 8;
                tmpReportFile = "SFReportOrderTotalE";
            }
            if (tmpFlag == flag) return;
            flag = tmpFlag;
            ReportFile = tmpReportFile;
            IsActiveForm = false;
            LoadReport();
            if (dispView.Report != null) SetReportCaption(dispView);
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
            QuerySQL = Pub.GetSQL(DBCode.DB_004010, new string[] { flag.ToString(), EmpTag, EmpNo, DepartTag, DepartID, DepartList,
        dtpStart.Value.ToString(SystemInfo.SQLDateFMT), dtpEnd.Value.ToString(SystemInfo.SQLDateFMT), OprtInfo.DepartPower });
            SetReportDate(dispView, label4.Text + ": " + dtpStart.Value.ToShortDateString() + " - " + dtpEnd.Value.ToShortDateString());
            base.ExecItemRefresh();
            SetReportTitle(dispView, this.Text);
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
    }
}