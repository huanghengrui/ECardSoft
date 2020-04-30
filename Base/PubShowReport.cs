using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmPubShowReport : frmBaseMDIChildReportPrint
  {
    private string ReportView = "";
    private string OrderField = "";
    private byte DateFlag = 0;
    private string DateField = "";
    private byte empFlag = 0;
    private byte departFlag = 0;

    protected override void InitForm()
    {
      label1.Tag = DateField;
      label2.Tag = DateField;
      IgnoreReportSet = true;
      base.InitForm();
      dtpBegin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
      dtpEnd.Value = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
      dtpYM.Value = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, 1);
      dtpYM.CustomFormat = SystemInfo.YMFormat;
      label1.Enabled = ((DateFlag == 1) || (DateFlag == 2));
      dtpBegin.Enabled = label1.Enabled;
      dtpEnd.Enabled = label1.Enabled;
      label2.Enabled = (DateFlag == 3);
      dtpYM.Enabled = label2.Enabled;
      label1.Visible = label1.Enabled;
      dtpBegin.Visible = dtpBegin.Enabled;
      dtpEnd.Visible = dtpEnd.Enabled;
      label2.Visible = label2.Enabled;
      dtpYM.Visible = dtpYM.Enabled;
      bool HasEmpNo = false;
      bool HasEmpName = false;
      bool HasDepartID = false;
      bool HasDepartName = false;
      DataTableReader dr = null;
      try
      {
        if (db.IsOpen) db.Open(SystemInfo.ConnStr);
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "606", ReportView }));
        for (int i = 0; i < dr.FieldCount; i++)
        {
          if (dr.GetName(i).ToLower() == "empno") HasEmpNo = true;
          if (dr.GetName(i).ToLower() == "empname") HasEmpName = true;
          if (dr.GetName(i).ToLower() == "departid") HasDepartID = true;
          if (dr.GetName(i).ToLower() == "departname") HasDepartName = true;
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
      if (HasEmpNo && !HasEmpName)
        empFlag = 1;
      else if (!HasEmpNo && HasEmpName)
        empFlag = 2;
      else if (HasEmpNo && HasEmpName)
        empFlag = 3;
      if (HasDepartID && !HasDepartName)
        departFlag = 1;
      else if (!HasDepartID && HasDepartName)
        departFlag = 2;
      else if (HasDepartID && HasDepartName)
        departFlag = 3;
      label4.Enabled = empFlag > 0;
      txtEmp.Enabled = label4.Enabled;
      btnSelectEmp.Enabled = label4.Enabled;
      label3.Enabled = departFlag > 0;
      txtDepart.Enabled = label3.Enabled;
      btnSelectDepart.Enabled = label3.Enabled;
      label4.Visible = label4.Enabled;
      txtEmp.Visible = txtEmp.Enabled;
      btnSelectEmp.Visible = btnSelectEmp.Enabled;
      label3.Visible = label3.Enabled;
      txtDepart.Visible = txtDepart.Enabled;
      btnSelectDepart.Visible = btnSelectDepart.Enabled;
      if (DateFlag == 1)
      {
        dtpBegin.Format = DateTimePickerFormat.Custom;
        dtpEnd.Format = DateTimePickerFormat.Custom;
        dtpBegin.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
      }
      if (label1.Enabled)
      {
        txtEmp.Top = dtpYM.Top;
        label4.Top = txtEmp.Top + 4;
        btnSelectEmp.Top = txtEmp.Top + 1;
        txtDepart.Top = txtEmp.Top + 30;
        label3.Top = txtDepart.Top + 4;
        btnSelectDepart.Top = txtDepart.Top + 1;
      }
      else if (label2.Enabled)
      {
        label2.Top = label1.Top;
        dtpYM.Top = dtpBegin.Top;
        txtEmp.Top = dtpYM.Top + 30;
        label4.Top = txtEmp.Top + 4;
        btnSelectEmp.Top = txtEmp.Top + 1;
        txtDepart.Top = txtEmp.Top + 30;
        label3.Top = txtDepart.Top + 4;
        btnSelectDepart.Top = txtDepart.Top + 1;
      }
      else if (!label1.Enabled && !label2.Enabled)
      {
        txtEmp.Top = 10;
        label4.Top = txtEmp.Top+4;
        btnSelectEmp.Top = txtEmp.Top + 1;
        txtDepart.Top = txtEmp.Top + 30;
        label3.Top = txtDepart.Top + 4;
        btnSelectDepart.Top = txtDepart.Top + 1;
      }
    }

    public frmPubShowReport(string reportTable, string reportName, string reportView, string reportData, string orderField,
      byte dateFlag, string dateField)
    {
      ReportTable = reportTable;
      ReportName = reportName;
      ReportView = reportView;
      ReportData = reportData;
      OrderField = orderField;
      DateFlag = dateFlag;
      DateField = dateField;
      InitializeComponent();
    }

    protected override void ExecItemRefresh()
    {
      string EmpTag = "0";
      string EmpNo = "";
      string DepartTag = "0";
      string DepartID = "";
      string DepartList = "";
      if (empFlag > 0)
      {
        if ((txtEmp.Text.Trim() != "") && (txtEmp.Tag != null))
        {
          EmpNo = txtEmp.Tag.ToString();
          EmpTag = "1";
        }
        else if (txtEmp.Text.Trim() != "")
        {
          EmpNo = txtEmp.Text.Trim();
        }
      }
      if (departFlag > 0)
      {
        if ((txtDepart.Text.Trim() != "") && (txtDepart.Tag != null))
        {
          DepartID = txtDepart.Tag.ToString();
          DepartTag = "1";
        }
        else if (txtDepart.Text.Trim() != "")
        {
          DepartID = txtDepart.Text.Trim();
        }
        if (DepartTag == "1" && (departFlag == 2) || (departFlag == 3))
        {
          if (DepartID != "") DepartList = db.GetDepartChildID(DepartID);
          if (DepartList == "") DepartList = "''";
        }
      }
      string BeginTime = dtpBegin.Value.ToString(SystemInfo.SQLDateTimeFMT);
      string EndTime = dtpEnd.Value.ToString(SystemInfo.SQLDateTimeFMT);
      string DateTitle = label1.Text;
      string BeginTimeTitle = dtpBegin.Value.ToString();
      string EndTimeTitle = dtpEnd.Value.ToString();
      if (DateFlag == 2)
      {
        BeginTimeTitle = dtpBegin.Value.ToShortDateString();
        EndTimeTitle = dtpEnd.Value.ToShortDateString();
      }
      else if (DateFlag == 3)
      {
        BeginTime = dtpYM.Value.ToString(SystemInfo.YMFormatDB);
        EndTime = "";
        BeginTimeTitle = BeginTime;
        EndTimeTitle = EndTime;
        DateTitle = label2.Text;
      }
      QuerySQL = Pub.GetSQL(DBCode.DB_000001, new string[] { "605", ReportView, DateField, EmpNo, DepartID, 
        DepartList, BeginTime, EndTime, OprtInfo.DepartPower, OrderField, empFlag.ToString(), 
        departFlag.ToString(), DateFlag.ToString(), EmpTag, DepartTag });
      DateTitle = DateTitle + ": " + BeginTimeTitle;
      if (EndTimeTitle != "") DateTitle = DateTitle + " - " + EndTimeTitle;
      SetReportDate(dispView, DateTitle);
      base.ExecItemRefresh();
      SetReportTitle(dispView, this.Text);
    }

    private void btnSelectEmp_Click(object sender, EventArgs e)
    {
      frmPubSelectEmp frm = new frmPubSelectEmp();
      if (frm.ShowDialog() == DialogResult.OK)
      {
        txtEmp.Text = frm.EmpName;
        if ((empFlag == 2) || (empFlag == 3))
          txtEmp.Tag = frm.EmpNo;
        else
          txtEmp.Tag = frm.EmpName;
      }
    }

    private void btnSelectDepart_Click(object sender, EventArgs e)
    {
      frmPubSelectDepart frm = new frmPubSelectDepart();
      if (frm.ShowDialog() == DialogResult.OK)
      {
        txtDepart.Text = frm.DepartName;
        if ((departFlag == 2) || (departFlag == 3))
          txtDepart.Tag = frm.DepartID;
        else
          txtDepart.Tag = frm.DepartName;
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