using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmKQReportResultTotal : frmBaseMDIChildReportPrint
  {
    protected override void InitForm()
    {
      formCode = "KQReportResultTotal";
      ReportFile = "KQReportResultTotal";
      ShowKQType = true;
      base.InitForm();
      dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
      dtpStart.CustomFormat = SystemInfo.YMFormat;
    }

    public frmKQReportResultTotal()
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
      string ResultYM = dtpStart.Value.ToString(SystemInfo.YMFormat);
      string ResultYMA = dtpStart.Value.ToString(SystemInfo.YMFormatDB);
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
      QuerySQL = Pub.GetSQL(DBCode.DB_002015, new string[] { "4", EmpTag, EmpNo, DepartTag, DepartID, DepartList, ResultYMA, OprtInfo.DepartPower });
      SetReportDate(dispView, label4.Text + ": " + ResultYM);
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