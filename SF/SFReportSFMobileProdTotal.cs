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
    public partial class frmSFReportSFMobileProdTotal : frmBaseMDIChildReportPrint
    {
        protected override void InitForm()
        {
            formCode = "SFReportSFMobileProdTotal";
            ReportFile = "SFReportSFMobileProdTotal";
            base.InitForm();
            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
            dtpEnd.Value = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            dtpStart.CustomFormat = SystemInfo.DateTimeFormat;
            dtpEnd.CustomFormat = SystemInfo.DateTimeFormat;
            DataTableReader dr = null;
            TCommonType cType;
            try
            {
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004011, new string[] { "3" }));
                while (dr.Read())
                {
                    cType = new TCommonType(dr["SFTypeSysID"].ToString(), dr["SFTypeID"].ToString(), dr["SFTypeName"].ToString(), true);
                    clbSFType.Items.Add(cType);
                    clbSFType.SetItemChecked(clbSFType.Items.Count - 1, false);
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
            clbMacSN.SetItemChecked(clbMacSN.Items.Count - 1, false);
            chkSFType_CheckedChanged(null, null);
            chkMacSN_CheckedChanged(null, null);
            btnAddress.Text = Pub.GetResText(formCode, "btnSelectAddress", "");
        }

        public frmSFReportSFMobileProdTotal()
        {
            InitializeComponent();
        }

        protected override void ExecItemRefresh()
        {
            string SFType = "";
            string MacSN = "";
            string AddressTag = "0";
            string AddressID = "";
            string AddressList = "";
            if (chkSFType.Checked)
            {
                for (int i = 0; i < clbSFType.Items.Count; i++)
                {
                    if (clbSFType.GetItemChecked(i)) SFType = SFType + ((TCommonType)clbSFType.Items[i]).id + ",";
                }
                if (SFType != "") SFType = SFType.Substring(0, SFType.Length - 1);
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
            QuerySQL = Pub.GetSQL(DBCode.DB_004011, new string[] { "6", SFType, MacSN, dtpStart.Value.ToString(SystemInfo.SQLDateTimeFMT),
        dtpEnd.Value.ToString(SystemInfo.SQLDateTimeFMT), AddressTag, AddressID, AddressList });
            SetReportDate(dispView, label4.Text + ": " + dtpStart.Value.ToString() + " - " + dtpEnd.Value.ToString());
            base.ExecItemRefresh();
            SetReportTitle(dispView, this.Text);
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

        private void chkSFType_CheckedChanged(object sender, EventArgs e)
        {
            clbSFType.Enabled = chkSFType.Checked;
        }

        private void chkMacSN_CheckedChanged(object sender, EventArgs e)
        {
            clbMacSN.Enabled = chkMacSN.Checked;
        }

        private void chkShowAlarm_Click(object sender, EventArgs e)
        {
            ExecItemRefresh();
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtAddress.Tag = null;
        }
    }
}