using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmMJReportNormal : frmBaseMDIChildReportPrint
  {
    protected override void InitForm()
    {
      formCode = "MJReportNormal";
      ReportFile = "MJReportNormal";
      base.InitForm();
      dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
      dtpEnd.Value = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
      dtpStart.CustomFormat = SystemInfo.DateTimeFormat;
      dtpEnd.CustomFormat = SystemInfo.DateTimeFormat;
      DataTableReader dr = null;
      try
      {
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003001, new string[] { "0" }));
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
      chkMacSN_CheckedChanged(null, null);
    }

    public frmMJReportNormal()
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
      string MacSN = "";
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
      QuerySQL = Pub.GetSQL(DBCode.DB_003008, new string[] { "0", EmpTag, EmpNo, DepartTag, DepartID, 
        DepartList, MacSN, dtpStart.Value.ToString(SystemInfo.SQLDateTimeFMT), 
        dtpEnd.Value.ToString(SystemInfo.SQLDateTimeFMT), OprtInfo.DepartPower });
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
  }
}