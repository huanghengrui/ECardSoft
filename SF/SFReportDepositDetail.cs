using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSFReportDepositDetail : frmBaseMDIChildReportPrint
    {
        protected override void InitForm()
        {
            formCode = "SFReportDepositDetail";
            ReportFile = "SFReportDepositDetail";
            base.InitForm();
            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
            dtpEnd.Value = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            dtpStart.CustomFormat = SystemInfo.DateTimeFormat;
            dtpEnd.CustomFormat = SystemInfo.DateTimeFormat;
            DataTableReader dr = null;
            TCommonType cType;
            try
            {
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { "1" }));
                while (dr.Read())
                {
                    cType = new TCommonType(dr["OprtNo"].ToString(), dr["OprtNo"].ToString(), dr["OprtName"].ToString());
                    clbOprt.Items.Add(cType);
                    clbOprt.SetItemChecked(clbOprt.Items.Count - 1, false);
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
            GetCardTypeList();
            for (int i = 0; i < cardTypeList.Count; i++)
            {
                clbCardType.Items.Add(cardTypeList[i]);
                clbCardType.SetItemChecked(clbCardType.Items.Count - 1, false);
            }
            chkOprt_CheckedChanged(null, null);
            chkCardType_CheckedChanged(null, null);
        }

        public frmSFReportDepositDetail()
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
            string Oprt = "";
            string CardType = "";
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
            if (chkOprt.Checked)
            {
                for (int i = 0; i < clbOprt.Items.Count; i++)
                {
                    if (clbOprt.GetItemChecked(i))
                        Oprt = Oprt + "'" + ((TCommonType)clbOprt.Items[i]).id.ToString() + "',";
                }
                if (Oprt != "") Oprt = Oprt.Substring(0, Oprt.Length - 1);
            }
            if (chkCardType.Checked)
            {
                for (int i = 0; i < clbCardType.Items.Count; i++)
                {
                    if (clbCardType.GetItemChecked(i))
                        CardType = CardType + ((TCardType)clbCardType.Items[i]).id.ToString() + ",";
                }
                if (CardType != "") CardType = CardType.Substring(0, CardType.Length - 1);
            }
            QuerySQL = Pub.GetSQL(DBCode.DB_004011, new string[] { "20", EmpTag, EmpNo, DepartTag, DepartID, DepartList, CardType, Oprt,
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

        private void chkOprt_CheckedChanged(object sender, EventArgs e)
        {
            clbOprt.Enabled = chkOprt.Checked;
        }

        private void chkCardType_CheckedChanged(object sender, EventArgs e)
        {
            clbCardType.Enabled = chkCardType.Checked;
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