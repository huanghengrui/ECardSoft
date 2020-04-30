using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSFReportMealCount : frmBaseMDIChildReportPrint
    {
        int flag = -1;

        protected override void InitForm()
        {
            formCode = "SFReportMealCount";
            ReportFile = "";
            base.InitForm();
            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
            dtpEnd.Value = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            dtpStart.CustomFormat = SystemInfo.DateTimeFormat;
            dtpEnd.CustomFormat = SystemInfo.DateTimeFormat;
            DataTableReader dr = null;
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
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
            clbMacSN.Items.Add("255");
            clbMacSN.SetItemChecked(clbMacSN.Items.Count - 1, false);
            chkMacSN_CheckedChanged(null, null);
            btnAddress.Text = btnSelectEmp.Text;
            RadioButton_Click(null, null);
        }

        public frmSFReportMealCount()
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
                tmpReportFile = "SFReportMealCountA";
            }
            else if (rbDept.Checked)
            {
                tmpFlag = 1;
                tmpReportFile = "SFReportMealCountB";
            }
            else if (rbMac.Checked)
            {
                tmpFlag = 2;
                tmpReportFile = "SFReportMealCountC";
            }
            else if (rbAddress.Checked)
            {
                tmpFlag = 3;
                tmpReportFile = "SFReportMealCountD";
            }
            else if (rbDate.Checked)
            {
                tmpFlag = 4;
                tmpReportFile = "SFReportMealCountE";
            }
            else if (rbCardType.Checked)
            {
                tmpFlag = 5;
                tmpReportFile = "SFReportMealCountF";
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
            string MacSN = "";
            string AddressTag = "0";
            string AddressID = "";
            string AddressList = "";
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
            if (chkMacSN.Checked)
            {
                for (int i = 0; i < clbMacSN.Items.Count; i++)
                {
                    if (clbMacSN.GetItemChecked(i)) MacSN = MacSN + "'" + clbMacSN.Items[i].ToString() + "',";
                }
                if (MacSN != "") MacSN = MacSN.Substring(0, MacSN.Length - 1);
            }
            if ((txtAddress.Text.Trim() != "") && (txtAddress.Tag != null))
            {
                AddressID = txtAddress.Tag.ToString();
                AddressTag = "1";
            }
            else if (txtAddress.Text.Trim() != "")
            {
                AddressID = txtAddress.Text.Trim();
            }
            if (AddressTag == "1")
            {
                if (AddressID != "") AddressList = db.GetAddressChildID(AddressID);
                if (AddressList == "") AddressList = "''";
            }
            QuerySQL = Pub.GetSQL(DBCode.DB_004011, new string[] { "40", flag.ToString(), EmpTag, EmpNo, DepartTag, DepartID, DepartList,
        MacSN, dtpStart.Value.ToString(SystemInfo.SQLDateTimeFMT), dtpEnd.Value.ToString(SystemInfo.SQLDateTimeFMT),
        OprtInfo.DepartPower, AddressTag, AddressID, AddressList });
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

        private void btnAddress_Click(object sender, EventArgs e)
        {
            frmPubSelectAddress frm = new frmPubSelectAddress();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtAddress.Text = frm.AddressName;
                txtAddress.Tag = frm.AddressID;
            }
          
        }

        private void chkMacSN_CheckedChanged(object sender, EventArgs e)
        {
            clbMacSN.Enabled = chkMacSN.Checked;
        }

        private void txtEmp_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtEmp.Tag = null;
        }

        private void txtDepart_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtDepart.Tag = null;
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtAddress.Tag = null;
        }
    }
}