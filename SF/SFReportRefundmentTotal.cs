using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSFReportRefundmentTotal : frmBaseMDIChildReportPrint
    {
        int flag = -1;

        protected override void InitForm()
        {
            formCode = "SFReportRefundmentTotal";
            ReportFile = "";
            base.InitForm();
            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
            dtpEnd.Value = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            dtpStart.CustomFormat = SystemInfo.DateTimeFormat;
            dtpEnd.CustomFormat = SystemInfo.DateTimeFormat;
            RadioButton_Click(null, null);
        }

        public frmSFReportRefundmentTotal()
        {
            InitializeComponent();
        }

        private void RadioButton_Click(object sender, EventArgs e)
        {
            int tmpFlag = 0;
            string tmpReportFile = "";
            if (rbEmp.Checked)
            {
                tmpFlag = 0;
                tmpReportFile = "SFReportRefundmentTotalA";
            }
            else if (rbDept.Checked)
            {
                tmpFlag = 1;
                tmpReportFile = "SFReportRefundmentTotalB";
            }
            else if (rbOprt.Checked)
            {
                tmpFlag = 2;
                tmpReportFile = "SFReportRefundmentTotalC";
            }
            else if (rbSysOprt.Checked)
            {
                tmpFlag = 3;
                tmpReportFile = "SFReportRefundmentTotalD";
            }
            else if (rbDate.Checked)
            {
                tmpFlag = 4;
                tmpReportFile = "SFReportRefundmentTotalE";
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
            QuerySQL = Pub.GetSQL(DBCode.DB_004011, new string[] { "31", flag.ToString(), EmpTag, EmpNo, DepartTag, DepartID, DepartList,
        dtpStart.Value.ToString(SystemInfo.SQLDateTimeFMT), dtpEnd.Value.ToString(SystemInfo.SQLDateTimeFMT), OprtInfo.DepartPower });
            SetReportDate(dispView, label4.Text + ": " + dtpStart.Value.ToString() + " - " + dtpEnd.Value.ToString());
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