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
  public partial class frmBaseReport : frmBaseMDIChildGrid
  {
    protected GridppReport Report = new GridppReport();
    protected string ReportTable = "";
    protected string ReportHeader = "";

    protected override void InitForm()
    {
      SetToolItemState("ItemExport", false);
      IgnoreSelect = true;
      AddColumn(0, "ReportName", false, 200);
      AddColumn(0, "ReportView", false, 200);
      AddColumn(1, "IsSys", false, false, 1, 80);
      AddColumn(0, "GUID", true, false, 0);
      ItemPrint.Image = Properties.Resources.FilePrintPreview;
      base.InitForm();
      dataGrid.ReadOnly = true;
      ExecItemRefresh();
    }

    public frmBaseReport()
    {
      InitializeComponent();
    }

    protected override void ExecItemImport()
    {
      dlgOpen.Filter = Pub.GetResText(formCode, "CustomReportFile", "") + "(*.grd)|*.grd";
      if (dlgOpen.ShowDialog() != DialogResult.OK) return;
      Pub.ExpandFile(dlgOpen.FileName, SystemInfo.ReportPath);
      StreamReader sr = null;
      string reportTitle = "";
      string reportView = "";
      string reportViewFile = "";
      string reportFile = "";
      byte DateFlag = 0;
      string DateField = "";
      string OrderField = "";
      try
      {
        sr = new StreamReader(SystemInfo.ReportPath + "report.txt", Encoding.Default);
        string s = "";
        int i = 0;
        while (!sr.EndOfStream)
        {
          s = sr.ReadLine();
          switch (i)
          {
            case 0:
              reportTitle = s;
              break;
            case 1:
              reportView = s;
              break;
            case 2:
              reportViewFile = s;
              break;
            case 3:
              reportFile = s;
              break;
            case 4:
              byte.TryParse(s, out DateFlag);
              break;
            case 5:
              DateField = s;
              break;
            case 6:
              OrderField = s;
              break;
          }
          i += 1;
        }
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E);
      }
      finally
      {
        if (sr != null) sr.Close();
      }
      if (reportTitle == "")
      {
        Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorReportNameEmpty", ""));
        return;
      }
      if (reportView == "")
      {
        Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorReportViewEmpty", ""));
        return;
      }
      if (reportViewFile != "")
      {
        reportViewFile = SystemInfo.ReportPath + reportViewFile;
      }
      if (reportFile != "")
      {
        reportFile = SystemInfo.ReportPath + reportFile;
      }
      if ((reportFile == "") || !File.Exists(reportFile))
      {
        Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorReportFileNotExists", ""));
        return;
      }
      if ((reportViewFile != "") && File.Exists(reportViewFile))
      {
        if (!db.UpdateScript(reportViewFile)) return;
      }
      bool IsOk = true;
      DataTableReader dr = null;
      try
      {
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "602", ReportTable, reportTitle }));
        if (dr.Read())
        {
          Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorReportNameRepeat", ""));
          IsOk = false;
        }
        dr.Close();
        if (IsOk)
        {
          string sql = Pub.GetSQL(DBCode.DB_000001, new string[] { "603", ReportTable, reportTitle, reportView, 
            OrderField, DateFlag.ToString(), DateField });
          db.ExecSQL(sql);
          sr = new StreamReader(reportFile, Encoding.Default);
          string reportData = sr.ReadToEnd();
          db.UpdateTextData(Pub.GetSQL(DBCode.DB_000001, new string[] { "303", ReportTable, 
            reportTitle }), "ReportData", reportData);
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
        if (sr != null) sr.Close();
      }
      ExecItemRefresh();
    }

    protected override void ExecItemPrint()
    {
      ShowReport(false);
    }

    protected override void ExecItemAdd()
    {
      frmPubReportWizard frm = new frmPubReportWizard(this.Text, ReportTable);
      if (frm.ShowDialog() == DialogResult.OK)
      {
        ExecItemRefresh();
        bool isFind = false;
        for (int i = 0; i < dataGrid.RowCount; i++)
        {
          if (dataGrid[0, i].Value.ToString() == frm.ReportName)
          {
            dataGrid.Rows[i].Selected = true;
            dataGrid.CurrentCell = dataGrid.Rows[i].Cells[0];
            isFind = true;
            break;
          }
        }
        if (isFind) ShowReport(true);
      }
    }

    protected override void ExecItemEdit()
    {
      ShowReport(true);
    }

    protected override void ExecItemDelete()
    {
      DataRowView drv = (DataRowView)bindingSource.Current;
      bool IsSys = false;
      bool.TryParse(drv.Row["IsSys"].ToString(), out IsSys);
      if (IsSys)
      {
        Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorDeleteSystemDefaultReport", ""));
        return;
      }
      base.ExecItemDelete();
    }

    protected override void ExecItemRefresh()
    {
      QuerySQL = Pub.GetSQL(DBCode.DB_000001, new string[] { "601", ReportTable });
      base.ExecItemRefresh();
    }

    private void ShowReport(bool IsDesign)
    {
      DataRowView drv = (DataRowView)bindingSource.Current;
      string SysID = ReportHeader + drv.Row["GUID"].ToString();
      string ReportName = drv.Row["ReportName"].ToString();
      string ReportView = drv.Row["ReportView"].ToString();
      string ReportData = "";
      string OrderField = drv.Row["OrderField"].ToString();
      byte DateFlag = 0;
      byte.TryParse(drv.Row["DateFlag"].ToString(), out DateFlag);
      string DateField = drv.Row["DateField"].ToString();
      DataTableReader dr = null;
      bool IsError = false;
      try
      {
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "604", ReportTable, ReportName }));
        if (dr.Read())
        {
          ReportData = dr["ReportData"].ToString();
          Report.Register(SystemInfo.ReportRegister);
          Report.LoadFromStr(ReportData);
        }
        else
          IsError = true;
      }
      catch (Exception E)
      {
        IsError = true;
        Pub.ShowErrorMsg(E);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      if (IsError) return;
      if (IsDesign)
      {
        frmPubDesign frm = new frmPubDesign(Report, ReportName, "", ReportTable, ReportName);
        if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
      }
      else
      {
        frmPubShowReport frm = new frmPubShowReport(ReportTable, ReportName, ReportView, ReportData,
          OrderField, DateFlag, DateField);
        frm.Tag = SysID;
        frm.Name = "frm" + ReportHeader + ReportName;
        frm.Text = ReportName;
        if (appMainForm != null) appMainForm.ExecShowReport(frm);
      }
    }

    protected override void GetDelSql(int rowIndex, ref List<string> sql)
    {
      string ret = Pub.GetSQL(DBCode.DB_000001, new string[] { "607", ReportTable, dataGrid[0, rowIndex].Value.ToString() });
      sql.Add(ret);
    }

    protected override string GetDelMsg(int rowIndex)
    {
      string ret = base.GetDelMsg(rowIndex);
      ret = dataGrid.Columns[0].HeaderText + "=" + dataGrid[0, rowIndex].Value.ToString();
      return ret;
    }
  }
}