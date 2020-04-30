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
  public partial class frmKQReportResultDay : frmBaseMDIChildReportPrint
  {
    private IGRField ResultIsNormalField = null;
    private frmKQReportResultDayDetail frmDetail = null;

    protected override void InitForm()
    {
      formCode = "KQReportResultDay";
      ReportFile = "KQReportResultDay";
      ShowKQType = true;
      base.InitForm();
      Report.Initialize += new _IGridppReportEvents_InitializeEventHandler(Report_Initialize);
      Report.SectionFormat += new _IGridppReportEvents_SectionFormatEventHandler(Report_SectionFormat);
      dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
      dtpEnd.Value = DateTime.Now.Date;
    }

    public frmKQReportResultDay()
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
      QuerySQL = Pub.GetSQL(DBCode.DB_002015, new string[] { "2", EmpTag, EmpNo, DepartTag, DepartID, DepartList, 
        dtpStart.Value.ToString(SystemInfo.SQLDateFMT), dtpEnd.Value.ToString(SystemInfo.SQLDateFMT), 
        OprtInfo.DepartPower, Convert.ToByte(chkNormal.Checked).ToString(), 
        Convert.ToByte(chkAbsent.Checked).ToString(), Convert.ToByte(chkLater.Checked).ToString(), 
        Convert.ToByte(chkLeave.Checked).ToString()});
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

    private void Report_Initialize()
    {
      ResultIsNormalField = dispView.Report.FieldByName("ResultIsNormal");
    }

    private void Report_SectionFormat(IGRSection pSender)
    {
      try
      {
        if (ResultIsNormalField == null) return;
        if (ResultIsNormalField.AsString == "N")
        {
          for (int i = 1; i <= dispView.Report.DetailGrid.ColumnContent.ContentCells.Count; i++)
          {
            dispView.Report.DetailGrid.ColumnContent.ContentCells[i].ForeColor = Pub.ColorToOleColor(Color.Red);
          }
        }
        else
        {
          for (int i = 1; i <= dispView.Report.DetailGrid.ColumnContent.ContentCells.Count; i++)
          {
            dispView.Report.DetailGrid.ColumnContent.ContentCells[i].ForeColor = Pub.ColorToOleColor(Color.Black);
          }
        }
      }
      catch
      {
      }
    }

    private void chkNormal_CheckedChanged(object sender, EventArgs e)
    {
      chkAbsent.Enabled = !chkNormal.Checked;
      chkLater.Enabled = chkAbsent.Enabled;
      chkLeave.Enabled = chkAbsent.Enabled;
      if (!chkAbsent.Enabled)
      {
        chkAbsent.Checked = false;
        chkLater.Checked = false;
        chkLeave.Checked = false;
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

    private void dispView_ContentCellDblClick(object sender, AxgrproLib._IGRDisplayViewerEvents_ContentCellDblClickEvent e)
    {
      if (frmDetail == null)
      {
        frmDetail = new frmKQReportResultDayDetail();
        frmDetail.Left = this.Width - frmDetail.Width - 7;
        frmDetail.Top = pnlDisp.Top + 42;
        frmDetail.TopLevel = false;
        frmDetail.Parent = this;
        frmDetail.FormClosed += this.frmDetail_Closed;
        frmDetail.Show();
        frmDetail.BringToFront();
      }
      ShowKQData();
    }

    private void dispView_SelectionCellChange(object sender, AxgrproLib._IGRDisplayViewerEvents_SelectionCellChangeEvent e)
    {
      if (dispView.SelRowNo != e.oldRow) ShowKQData();
    }

    private void frmKQReportResultDay_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (frmDetail != null) frmDetail.Close();
    }

    private void frmDetail_Closed(object sender, FormClosedEventArgs e)
    {
      frmDetail.Dispose();
      frmDetail = null;
    }

    private void ShowKQData()
    {
      if (frmDetail == null) return;
      string EmpNo = Report.FieldByName("EmpNo").AsString;
      DateTime KQDate = Report.FieldByName("ResultDate").AsDateTime;
      frmDetail.ShowKQData(EmpNo, KQDate);
    }
  }
}