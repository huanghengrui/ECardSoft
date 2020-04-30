using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSFQueryBalance : frmBaseMDIChildReportPrint
    {
        protected override void InitForm()
        {
            formCode = "SFQueryBalance";
            ReportFile = "SFQueryBalance";
            base.InitForm();
            GetCardTypeList();
            for (int i = 0; i < cardTypeList.Count; i++)
            {
                clbCardType.Items.Add(cardTypeList[i]);
                clbCardType.SetItemChecked(clbCardType.Items.Count - 1, false);
            }
            chkCardType_CheckedChanged(null, null);
        }

        public frmSFQueryBalance()
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
            string CardType = "";
            if (chkCardType.Checked)
            {
                for (int i = 0; i < clbCardType.Items.Count; i++)
                {
                    if (clbCardType.GetItemChecked(i)) CardType = CardType + ((TCardType)clbCardType.Items[i]).id.ToString() + ",";
                }
                if (CardType != "") CardType = CardType.Substring(0, CardType.Length - 1);
            }
            QuerySQL = Pub.GetSQL(DBCode.DB_004009, new string[] { EmpTag, EmpNo, DepartTag, DepartID, DepartList, CardType, OprtInfo.DepartPower });
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