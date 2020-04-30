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
    public partial class frmRSCardOpterDetail : frmBaseMDIChildReportPrint
    {
        protected override void InitForm()
        {
            formCode = "RSCardOpterDetail";
            ReportFile = "RSCardOpterDetail";
            base.InitForm();
            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEnd.Value = DateTime.Now.Date;
            DataTableReader dr = null;
            TCommonType cType;
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001004, new string[] { "0" }));
                while (dr.Read())
                {
                    cType = new TCommonType(dr["OpterTypeSysID"].ToString(), dr["OpterTypeID"].ToString(),
                      dr["OpterTypeName"].ToString(), true);
                    clbOpterType.Items.Add(cType);
                    clbOpterType.SetItemChecked(clbOpterType.Items.Count - 1, false);
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
            chkOpterType_CheckedChanged(null, null);
        }

        public frmRSCardOpterDetail()
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
            string OpterType = "";
            if (chkOpterType.Checked)
            {
                for (int i = 0; i < clbOpterType.Items.Count; i++)
                {
                    if (clbOpterType.GetItemChecked(i)) OpterType = OpterType + "'" + ((TCommonType)clbOpterType.Items[i]).name + "',";
                }
                if (OpterType != "") OpterType = OpterType.Substring(0, OpterType.Length - 1);
            }
            QuerySQL = Pub.GetSQL(DBCode.DB_001004, new string[] { "1", EmpTag, EmpNo, DepartTag, DepartID, DepartList, OpterType,
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

        private void chkOpterType_CheckedChanged(object sender, EventArgs e)
        {
            clbOpterType.Enabled = chkOpterType.Checked;
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