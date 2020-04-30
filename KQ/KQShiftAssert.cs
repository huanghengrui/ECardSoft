using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmKQShiftAssert : frmBaseMDIChildReport
  {
    private bool ReadingShift = false;
    int flag = -1;

    protected override void InitForm()
    {
      formCode = "KQShiftAssert";
      SetToolItemState("ItemImport", false);
      SetToolItemState("ItemAdd", false);
      SetToolItemState("ItemDelete", false);
      IgnoreSelect = true;
      IgnoreRefreshFirst = true;
      CheckForward = false;
      base.InitForm();
      RefreshForm(true);
      button1_Click(null, null);
      dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
      dtpEnd.Value = DateTime.Now.Date;
    }

    public frmKQShiftAssert()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (flag == 0) return;
      flag = 0;
      ReportFile = "KQEmpShiftsTotal";
      IsActiveForm = false;
      LoadReport();
      if (dispView.Report != null)
      {
        SetReportCaption(dispView);
        SetReportTitle(dispView, button1.Text);
      }
      SetSelectState();
      ReportStartIndex = 3;
      RefreshForm(true);
    }

    private void button2_Click(object sender, EventArgs e)
    {
      if (flag == 1) return;
      flag = 1;
      ReportFile = "KQEmpShift";
      IsActiveForm = false;
      LoadReport();
      if (dispView.Report != null)
      {
        SetReportCaption(dispView);
        SetReportTitle(dispView, button2.Text);
      }
      SetSelectState();
      ReportStartIndex = 3;
      RefreshForm(true);
    }

    private void button3_Click(object sender, EventArgs e)
    {
      appMainForm.ExecModule("KQEmpShift", "KQ");
    }

    private void button4_Click(object sender, EventArgs e)
    {
      if (flag == 2) return;
      flag = 2;
      ReportFile = "KQDepShift";
      IsActiveForm = false;
      LoadReport();
      if (dispView.Report != null)
      {
        SetReportCaption(dispView);
        SetReportTitle(dispView, button4.Text);
      }
      SetSelectState();
      ReportStartIndex = 3;
      RefreshForm(true);
    }

    private void button5_Click(object sender, EventArgs e)
    {
      appMainForm.ExecModule("KQDepShift", "KQ");
    }

    private void button6_Click(object sender, EventArgs e)
    {
      if (flag == 3) return;
      flag = 3;
      ReportFile = "KQEmpWorkType";
      IsActiveForm = false;
      LoadReport();
      if (dispView.Report != null)
      {
        SetReportCaption(dispView);
        SetReportTitle(dispView, button6.Text);
      }
      SetSelectState();
      ReportStartIndex = 3;
      RefreshForm(true);
    }

    private void button7_Click(object sender, EventArgs e)
    {
      appMainForm.ExecModule("KQEmpWorkType", "KQ");
    }

    private void button8_Click(object sender, EventArgs e)
    {
      if (flag == 4) return;
      flag = 4;
      ReportFile = "KQDepWorkType";
      IsActiveForm = false;
      LoadReport();
      if (dispView.Report != null)
      {
        SetReportCaption(dispView);
        SetReportTitle(dispView, button8.Text);
      }
      SetSelectState();
      ReportStartIndex = 3;
      RefreshForm(true);
    }

    private void button9_Click(object sender, EventArgs e)
    {
      appMainForm.ExecModule("KQDepWorkType", "KQ");
    }

    private void button10_Click(object sender, EventArgs e)
    {
      appMainForm.ExecModule("KQShift", "KQ");
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

    private void SetSelectState()
    {
      label6.Enabled = button1.Checked || button2.Checked || button6.Checked;
      txtEmp.Enabled = label6.Enabled;
      btnSelectEmp.Enabled = label6.Enabled;
      label6.Visible = label6.Enabled;
      txtEmp.Visible = label6.Enabled;
      btnSelectEmp.Visible = label6.Enabled;
      label4.Enabled = button1.Checked || button2.Checked || button4.Checked;
      dtpStart.Enabled = label4.Enabled;
      dtpEnd.Enabled = label4.Enabled;
      label4.Visible = label4.Enabled;
      dtpStart.Visible = label4.Enabled;
      dtpEnd.Visible = label4.Enabled;
      button3.Enabled = button2.Checked;
      button5.Enabled = button4.Checked;
      button7.Enabled = button6.Checked;
      button9.Enabled = button8.Checked;
    }

    protected override void ExecItemEdit()
    {
      base.ExecItemEdit();
      string GUID = "";
      if (button2.Checked)
      {
        if (!db.CheckOprtRole("KQEmpShift", "M", CheckForward)) return;
        GUID = Report.FieldByName("GUID").AsString;
        frmKQShiftAssertEmp frm = new frmKQShiftAssertEmp(this.Text, CurrentTool, GUID);
        if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
      }
      else if (button4.Checked)
      {
        if (!db.CheckOprtRole("KQDepShift", "M", CheckForward)) return;
        GUID = Report.FieldByName("GUID").AsString;
        frmKQShiftAssertDep frm = new frmKQShiftAssertDep(this.Text, CurrentTool, GUID);
        if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
      }
      else if (button6.Checked)
      {
        if (!db.CheckOprtRole("KQEmpWorkType", "M", CheckForward)) return;
        GUID = Report.FieldByName("GUID").AsString;
        frmKQEmpWorkTypeAdd frm = new frmKQEmpWorkTypeAdd(this.Text, CurrentTool, GUID);
        if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
      }
      else if (button8.Checked)
      {
        if (!db.CheckOprtRole("KQDepWorkType", "M", CheckForward)) return;
        GUID = Report.FieldByName("GUID").AsString;
        frmKQDepWorkTypeAdd frm = new frmKQDepWorkTypeAdd(this.Text, CurrentTool, GUID);
        if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
      }
    }

    protected override void ExecItemRefresh()
    {
      DateTime StartTime = DateTime.Now;
      string StartDate = dtpStart.Value.ToString(SystemInfo.SQLDateFMT);
      string EndDate = dtpEnd.Value.ToString(SystemInfo.SQLDateFMT);
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
      ReadingShift = true;
      RefreshForm(true);
      if (DepartTag == "1")
      {
        if (DepartID != "") DepartList = db.GetDepartChildID(DepartID);
        if (DepartList == "") DepartList = "''";
      }
      contextMenu.Close();
      RefreshMsg(StrReading);
      if (button1.Checked)
      {
        DataTable dt = null;
        string sql = "";
        try
        {
          if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
          dt = db.GetDataTable(Pub.GetSQL(DBCode.DB_002007, new string[] { "0", OprtInfo.DepartPower, EmpTag, EmpNo, DepartTag, DepartID, DepartList }));
          for (int i = 0; i < dt.Rows.Count; i++)
          {
            sql = Pub.GetSQL(DBCode.DB_002007, new string[] { "1", dt.Rows[i]["EmpSysID"].ToString(), StartDate, EndDate });
            db.ExecSQL(sql);
            RefreshMsg(StrReading + string.Format("    {0}/{1}", i + 1, dt.Rows.Count));
            Application.DoEvents();
          }
        }
        catch (Exception E)
        {
          RefreshMsg(StrReading);
          Pub.ShowErrorMsg(E);
        }
        finally
        {
          if (dt != null)
          {
            dt.Reset();
            dt.Clear();
          }
        }
      }
      RefreshMsg(StrReading);
      SetReportDate(dispView, label4.Text + ": " + dtpStart.Value.ToShortDateString() + " - " + dtpStart.Value.ToShortDateString());
      QuerySQL = "";
      string NormalRest = Pub.GetResText(formCode, "NormalRest", "");
      string TurnsoffRest = Pub.GetResText(formCode, "TurnsoffRest", "");
      if (button1.Checked)
      {
        QuerySQL = Pub.GetSQL(DBCode.DB_002007, new string[] { "2", StartDate, EndDate, EmpTag, EmpNo, DepartTag, DepartID, DepartList, OprtInfo.DepartPower });
      }
      else if (button2.Checked)
      {
        QuerySQL = Pub.GetSQL(DBCode.DB_002007, new string[] { "3", StartDate, EndDate, EmpTag, EmpNo, DepartTag, DepartID, DepartList, OprtInfo.DepartPower });
      }
      else if (button4.Checked)
      {
        QuerySQL = Pub.GetSQL(DBCode.DB_002007, new string[] { "4", StartDate, EndDate, DepartTag, DepartID, DepartList, OprtInfo.DepartPower });
      }
      else if (button6.Checked)
      {
        QuerySQL = Pub.GetSQL(DBCode.DB_002007, new string[] { "5", NormalRest, TurnsoffRest, EmpTag, EmpNo, DepartTag, DepartID, DepartList, OprtInfo.DepartPower });
      }
      else if (button8.Checked)
      {
        QuerySQL = Pub.GetSQL(DBCode.DB_002007, new string[] { "6", NormalRest, TurnsoffRest, DepartTag, DepartID, DepartList, OprtInfo.DepartPower });
      }
      int row = -1;
      if (QuerySQL != "")
      {
        dispView.Report.DetailGrid.Recordset.QuerySQL = QuerySQL;
        try
        {
          if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
          row = dispView.SelRowNo;
          dispView.Refresh();
          Application.DoEvents();
        }
        catch (Exception E)
        {
          Pub.ShowErrorMsg(E, QuerySQL);
        }
        finally
        {
          if (row < dispView.RowCount)
            dispView.SelRowNo = row;
          else if (dispView.RowCount > 0)
            dispView.SelRowNo = dispView.RowCount - 1;
        }
      }
      RefreshMsg(StrReadEnd + Pub.GetDateDiffTimes(StartTime, DateTime.Now, true), true);
      ReadingShift = false;
      RefreshForm(true);
    }

    protected override void RefreshForm(bool State)
    {
      base.RefreshForm(State);
      ItemEdit.Enabled = ItemEdit.Enabled && (button2.Checked || button4.Checked || button6.Checked || button8.Checked);
      SetContextMenuState();
      panel1.Enabled = State && !ReadingShift;
      pnlDisp.Enabled = State && !ReadingShift;
    }

    private void txtEmp_KeyPress(object sender, KeyPressEventArgs e)
    {
      txtEmp.Tag = null;
    }

    private void txtDepart_KeyPress(object sender, KeyPressEventArgs e)
    {
      txtDepart.Tag = null;
    }

    private void frmKQShiftAssert_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (ReadingShift) e.Cancel = true;
    }
  }
}