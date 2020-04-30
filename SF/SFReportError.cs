using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSFReportError : frmBaseMDIChildReportPrint
    {
        protected override void InitForm()
        {
            formCode = "SFReportError";
            ReportFile = "SFReportError";
            base.InitForm();
            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
            dtpEnd.Value = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            dtpStart.CustomFormat = SystemInfo.DateTimeFormat;
            dtpEnd.CustomFormat = SystemInfo.DateTimeFormat;
            GetCardTypeList();
            for (int i = 0; i < cardTypeList.Count; i++)
            {
                clbCardType.Items.Add(cardTypeList[i]);
                clbCardType.SetItemChecked(clbCardType.Items.Count - 1, false);
            }
            DataTableReader dr = null;
            TCommonType cType;
            try
            {
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004011, new string[] { "0" }));
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
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004005, new string[] { "2" }));
                while (dr.Read())
                {
                    cType = new TCommonType(dr["MealTypeSysID"].ToString(), dr["MealTypeID"].ToString(),
                      dr["MealTypeName"].ToString(), true);
                    clbMealType.Items.Add(cType);
                    clbMealType.SetItemChecked(clbMealType.Items.Count - 1, false);
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
            clbMacSN.Items.Add("255");
            clbMacSN.SetItemChecked(clbMacSN.Items.Count - 1, false);
            chkCardType_CheckedChanged(null, null);
            chkSFType_CheckedChanged(null, null);
            chkSFMealType_CheckedChanged(null, null);
            chkMacSN_CheckedChanged(null, null);
            btnAddress.Text = btnSelectEmp.Text;
           
        }

        public frmSFReportError()
        {
            InitializeComponent();
        }
        protected override void ExecItemRefresh()
        {
            string EmpTag = "0";
            string EmpNo = "";
            string DepartTag = "0";
            string DepartID = "";
            string DepartList = "";
            string CardType = "";
            string SFType = "";
            string MealType = "";
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
            if (chkCardType.Checked)
            {
                for (int i = 0; i < clbCardType.Items.Count; i++)
                {
                    if (clbCardType.GetItemChecked(i)) CardType = CardType + ((TCardType)clbCardType.Items[i]).id.ToString() + ",";
                }
                if (CardType != "") CardType = CardType.Substring(0, CardType.Length - 1);
            }
            if (chkSFType.Checked)
            {
                for (int i = 0; i < clbSFType.Items.Count; i++)
                {
                    if (clbSFType.GetItemChecked(i)) SFType = SFType + ((TCommonType)clbSFType.Items[i]).id + ",";
                }
                if (SFType != "") SFType = SFType.Substring(0, SFType.Length - 1);
            }
            if (chkSFMealType.Checked)
            {
                for (int i = 0; i < clbMealType.Items.Count; i++)
                {
                    if (clbMealType.GetItemChecked(i)) MealType = MealType + ((TCommonType)clbMealType.Items[i]).id + ",";
                }
                if (MealType != "") MealType = MealType.Substring(0, MealType.Length - 1);
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
            QuerySQL = Pub.GetSQL(DBCode.DB_004011, new string[] { "72", EmpTag, EmpNo, DepartTag, DepartID, DepartList, CardType, SFType,
        MealType, MacSN, dtpStart.Value.ToString(SystemInfo.SQLDateTimeFMT), dtpEnd.Value.ToString(SystemInfo.SQLDateTimeFMT),
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

        private void chkCardType_CheckedChanged(object sender, EventArgs e)
        {
            clbCardType.Enabled = chkCardType.Checked;
        }

        private void chkSFType_CheckedChanged(object sender, EventArgs e)
        {
            clbSFType.Enabled = chkSFType.Checked;
        }

        private void chkSFMealType_CheckedChanged(object sender, EventArgs e)
        {
            clbMealType.Enabled = chkSFMealType.Checked;
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