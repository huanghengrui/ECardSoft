using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using grproLib;

namespace ECard78
{
    public partial class frmSFReportProductDetail : frmBaseMDIChildReportPrint
    {
        private GridppReport Report1 = new GridppReport();
        private string ReportFile1 = "";

        protected override void InitForm()
        {
            formCode = "SFReportProductDetail";
            ReportFile = SystemInfo.IsDecimalProduct ? "SFReportProductsDecimalDetail" : "SFReportProductDetail";
            SetToolItemState("ItemTAG1", true);
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
            chkSFMealType_CheckedChanged(null, null);
            chkMacSN_CheckedChanged(null, null);
            btnAddress.Text = btnSelectEmp.Text;
            ItemTAG1.Enabled = false;
        }

        public frmSFReportProductDetail()
        {
            InitializeComponent();
        }

        protected override void ExecItemTAG1()
        {
            base.ExecItemTAG1();
            if (!LoadBillReport()) return;
            frmPubPreview frm = new frmPubPreview(Report1, this.Text, ReportFile1, "", "", false);
            frm.ShowDialog();
            
        }

        protected override void ExecItemRefresh()
        {
            string EmpTag = "0";
            string EmpNo = "";
            string DepartTag = "0";
            string DepartID = "";
            string DepartList = "";
            string CardType = "";
            string MealType = "";
            string MacSN = "";
            string AddressTag = "0";
            string AddressID = "";
            string AddressList = "";
            string CategoryID = "";
            string CategoryTag = "0";
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
            if ((txtCategory.Text.Trim() != "") && (txtCategory.Tag != null))
            {
                CategoryID = txtCategory.Tag.ToString();
                CategoryTag = "1";
            }
            else if (txtCategory.Text.Trim() != "")
            {
                CategoryID = txtCategory.Text.Trim();
            }
            QuerySQL = Pub.GetSQL(DBCode.DB_004011, new string[] { "10", EmpTag, EmpNo, DepartTag, DepartID, DepartList, CardType, MealType,
        MacSN, dtpStart.Value.ToString(SystemInfo.SQLDateTimeFMT), dtpEnd.Value.ToString(SystemInfo.SQLDateTimeFMT),
        OprtInfo.DepartPower, AddressTag, AddressID, AddressList,CategoryTag,CategoryID });
            SetReportDate(dispView, label4.Text + ": " + dtpStart.Value.ToString() + " - " + dtpEnd.Value.ToString());
            base.ExecItemRefresh();
            SetReportTitle(dispView, this.Text);
            ItemTAG1.Enabled = ItemPrint.Enabled;
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

        private void chkSFMealType_CheckedChanged(object sender, EventArgs e)
        {
            clbMealType.Enabled = chkSFMealType.Checked;
        }

        private void chkMacSN_CheckedChanged(object sender, EventArgs e)
        {
            clbMacSN.Enabled = chkMacSN.Checked;
        }

        private bool LoadBillReport()
        {
            bool ret = false;
            if (SystemInfo.IsDecimalProduct)
                ReportFile1 = SystemInfo.ReportPath + "SFReportProductsDecimalDetailBill.grf";
            else
                ReportFile1 = SystemInfo.ReportPath + "SFReportProductDetailBill.grf";
            try
            {
                Report1.Register(SystemInfo.ReportRegister);
                Report1.LoadFromFile(ReportFile1);
                Report1.DetailGrid.Recordset.ConnectionString = SystemInfo.ConnStrReport;
                Report1.DetailGrid.Recordset.QuerySQL = QuerySQL;
                Report1.ShowProgressUI = false;
                SetReportCaption(Report1);
                ret = true;
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            return ret;
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

        private void btnCategory_Click(object sender, EventArgs e)
        {
            frmPubSelectCategory frm = new frmPubSelectCategory();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtCategory.Tag = frm.CategoryID;
                txtCategory.Text = frm.CategoryName;
            }
          
        }

        private void txtCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtCategory.Tag = null;
        }
    }
}