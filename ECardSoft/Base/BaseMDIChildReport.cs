using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using AxgrproLib;
using grproLib;

namespace ECard78
{
  public partial class frmBaseMDIChildReport : frmBaseMDIChild
  {
    protected GridppReport Report = new GridppReport();
    protected string ReportFile = "";
    private bool IsFirst = true;
    protected int ReportStartIndex = 1;
    protected string FindSQL = "";
    protected string FindOrderBy = "";
    protected string FindKeyWord = "";
    protected bool FindShowTime = false;
    protected bool DesignReport = false;
    protected bool IgnoreTagExt = false;
    protected bool IgnoreRefreshFirst = false;
    protected bool IgnoreReportHead = false;
    protected string ReportTable = "";
    protected string ReportName = "";
    protected string ReportData = "";
    protected bool ShowKQType = false;
    protected bool IsActiveForm = false;

    protected override void InitForm()
    {
      switch (SystemInfo.LangName)
      {
        case "CHS"://繁体中文
          Report.Language = 0x804;
          break;
        case "CHT"://繁体中文
          Report.Language = 0x404;
          break;
        case "JPN": //日语
          Report.Language = 0x0411;
          break;
        case "KOR": //朝鲜语
          Report.Language = 0x0412;
          break;
        case "DEU"://德语
          Report.Language = 0x0407;
          break;
        case "RUS": //俄语
          Report.Language = 0x0419;
          break;
        case "FRA"://法语
          Report.Language = 0x040c;
          break;
        case "ESN"://西班牙语
          Report.Language = 0x040a;
          break;
        case "ITA"://意大利语
          Report.Language = 0x0410;
          break;
        case "PTG"://葡萄牙语
          Report.Language = 0x0816;
          break;
        default://英语
          Report.Language = 0x0409;
          break;
      }
      ItemExport.Enabled = false;
      ItemPrint.Enabled = false;
      ItemTAGExt.Enabled = false;
      if (ReportFile != "") ReportFile = SystemInfo.ReportPath + ReportFile + ".grf";
      try
      {
        Report.Register(SystemInfo.ReportRegister);
        if ((ReportFile != "") && File.Exists(ReportFile))
          Report.LoadFromFile(ReportFile);
        else if (ReportData != "")
          Report.LoadFromStr(ReportData);
        if (Report.DetailGrid != null)
        {
          Report.DetailGrid.Recordset.ConnectionString = SystemInfo.ConnStrReport;
          Report.DetailGrid.Recordset.QuerySQL = "";
          Report.BeforePostRecord += new _IGridppReportEvents_BeforePostRecordEventHandler(ReportBeforePostRecord);
          Report.ExportBegin += new _IGridppReportEvents_ExportBeginEventHandler(ReportExportBegin);
          if (!SystemInfo.AllowCustomerCardNo)
          {
            SetReportColumnVisible("CardPhysicsNo10", false);
            SetReportColumnVisible("PhyID", false);
          }
        }
        Report.ShowProgressUI = false;
        ShowReportHeader(false);
        dispView.Report = Report;
        dispView.Start();
        ItemTAGExt.Enabled = true;
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E);
      }
      if (!IgnoreTagExt)
      {
        AddExtDropDownItem("ItemSetupDisplay", ItemSetupDisplay_Click);
        SetToolItemState("ItemTAGExt", true);
        SetToolItemState("ItemLine3", true);
      }
      base.InitForm();
      KeyPreview = true;
    }

    public frmBaseMDIChildReport()
    {
      InitializeComponent();
    }

    protected override void ExecItemExport()
    {
      ShowReportHeader(true);
      ExportToXLS(Report, this.Text, SystemInfo.AppPath + this.Text + ".xls");
      ShowReportHeader(false);
    }

    protected override void ExecItemPrint()
    {
      ShowReportHeader(true);
      if (Report.ColumnByName("CheckBox") != null) Report.ColumnByName("CheckBox").Visible = false;
      frmPubPreview frm = new frmPubPreview(Report, this.Text, ReportFile, ReportTable, ReportName, DesignReport);
      frm.ShowDialog();
      if (Report.ColumnByName("CheckBox") != null) Report.ColumnByName("CheckBox").Visible = true;
      ShowReportHeader(false);
    }

    protected override void ExecItemDelete()
    {
      base.ExecItemDelete();
      List<string> sql = new List<string>();
      string msg = "";
      int RecNo = Report.DetailGrid.Recordset.RecordNo;
      Report.DetailGrid.Recordset.First();
      while (!Report.DetailGrid.Recordset.Eof())
      {
        if (Report.FieldByName("Checked").AsInteger == (int)GRSystemImage.grsi3DChecked)
        {
          GetDelSql(0, ref sql);
          msg = msg + GetDelMsg(0) + ";";
        }
        Report.DetailGrid.Recordset.Next();
      }
      Report.DetailGrid.Recordset.MoveTo(RecNo);
      if (sql.Count == 0)
      {
        Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgNoSelectDelete", ""));
        return;
      }
      GetDelSqlExt(ref sql);
      if (db.ExecSQL(sql) != 0) return;
      db.WriteSYLog(this.Text, CurrentTool, msg);
      ExecItemRefresh();
      Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgDeleteSucceed", ""), MessageBoxIcon.Information);
    }

    protected override void ExecItemSearch()
    {
      List<string> FieldText = new List<string>();
      List<string> FieldName = new List<string>();
      List<GRFieldType> FieldType = new List<GRFieldType>();
      string s = "";
      for (int i = ReportStartIndex; i <= Report.DetailGrid.Columns.Count; i++)
      {
        if (!Report.DetailGrid.Columns[i].TitleCell.FreeCell)
        {
          s = Report.DetailGrid.Columns[i].TitleCell.Text;
          if (Report.DetailGrid.Columns[i].TitleCell.SupCell != null)
            s = Report.DetailGrid.Columns[i].TitleCell.SupCell.Text + s;
          FieldText.Add(s);
          s = Report.DetailGrid.Columns[i].ContentCell.DataField;
          FieldName.Add(s);
          FieldType.Add(Report.FieldByName(s).FieldType);
        }
      }
      frmPubFind frm = new frmPubFind(this.Text + "[" + CurrentTool + "]", FindSQL, FindOrderBy,
        FindKeyWord, FieldText, FieldName, FieldType, FindShowTime);
      if (frm.ShowDialog() == DialogResult.OK)
      {
        QuerySQL = frm.QuerySQL;
        ExecItemRefresh();
      }
    }

    protected override void ExecItemRefresh()
    {
      DateTime StartTime = DateTime.Now;
      contextMenu.Close();
      int row = -1;
      RefreshMsg(StrReading);
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
      string s = this.Text;
      if (s == "") s = Pub.GetResText("Main", "mnu" + formCode, "");
      SetReportTitle(dispView, s);
      RefreshForm(true);
      RefreshMsg(StrReadEnd + Pub.GetDateDiffTimes(StartTime, DateTime.Now, true), true);
    }

    protected override void SelectData(bool State)
    {
      if (dispView.RowCount == 0) return;
      Report.DetailGrid.Recordset.First();
      while (!Report.DetailGrid.Recordset.Eof())
      {
        Report.DetailGrid.Recordset.Edit();
        if (State)
          Report.FieldByName("Checked").AsInteger = (int)GRSystemImage.grsi3DChecked;
        else
          Report.FieldByName("Checked").AsInteger = (int)GRSystemImage.grsi3DUnchecked;
        Report.DetailGrid.Recordset.Post();
        Report.DetailGrid.Recordset.Next();
      }
      dispView.UpdateViewer();
    }

    protected override void RefreshForm(bool State)
    {
      int row = 0;
      int rows = 0;
      pnlDisp.Enabled = State;
      ItemLine1.Visible = true;
      row = dispView.SelRowNo;
      try
      {
        rows = dispView.RowCount;
        if (rows > 0) row = row + 1;
      }
      catch
      {
      }
      finally
      {
      }
      if (row < 0) row = 0;
      ItemImport.Enabled = State;
      ItemExport.Enabled = State && (rows > 0);
      ItemPrint.Enabled = State && (rows > 0);
      ItemAdd.Enabled = State;
      ItemEdit.Enabled = State && (rows > 0);
      ItemDelete.Enabled = State && (rows > 0);
      ItemTAG1.Enabled = State && (rows > 0);
      ItemTAG2.Enabled = State && (rows > 0);
      ItemTAG3.Enabled = State && (rows > 0);
      ItemTAG4.Enabled = State && (rows > 0);
      ItemTAG5.Enabled = State && (rows > 0);
      ItemTAG6.Enabled = State && (rows > 0);
      ItemTAG7.Enabled = State && (rows > 0);
      ItemTAGExt.Enabled = State;
      for (int i = 0; i < ItemTAGExt.DropDownItems.Count; i++)
      {
        if (ItemTAGExt.DropDownItems[i].Name == "ItemSetupDisplay")
          ItemTAGExt.DropDownItems[i].Enabled = State && (Report.DetailGrid != null);
        else
          ItemTAGExt.DropDownItems[i].Enabled = State && (rows > 0);
      }
      ItemSelect.Enabled = State && (rows > 0);
      ItemUnselect.Enabled = State && (rows > 0);
      ItemRefresh.Enabled = State;
      ItemSearch.Enabled = State;
      SetContextMenuState();
      lblRecordState.Text = string.Format(StrPosition, row, rows);
    }

    private void dispView_ColumnLayoutChange(object sender, EventArgs e)
    {
      string sql;
      if ((ReportFile != "") && File.Exists(ReportFile))
      {
        if (Report.DetailGrid != null)
        {
          sql = Report.DetailGrid.Recordset.QuerySQL;
          dispView.PostColumnLayout();
          Report.DetailGrid.Recordset.ConnectionString = "";
          Report.DetailGrid.Recordset.QuerySQL = "";
          Report.SaveToFile(ReportFile);
          Report.DetailGrid.Recordset.ConnectionString = SystemInfo.ConnStrReport;
          Report.DetailGrid.Recordset.QuerySQL = sql;
        }
        else
        {
          dispView.PostColumnLayout();
          Report.SaveToFile(ReportFile);
        }
      }
      else if ((ReportTable != "") && (ReportName != ""))
      {
        string ReportData = "";
        if (Report.DetailGrid != null)
        {
          sql = Report.DetailGrid.Recordset.QuerySQL;
          dispView.PostColumnLayout();
          Report.DetailGrid.Recordset.ConnectionString = "";
          Report.DetailGrid.Recordset.QuerySQL = "";
          ReportData = Report.SaveToStr();
          Report.DetailGrid.Recordset.ConnectionString = SystemInfo.ConnStrReport;
          Report.DetailGrid.Recordset.QuerySQL = sql;
        }
        else
        {
          dispView.PostColumnLayout();
          ReportData = Report.SaveToStr();
        }
        db.UpdateTextData(Pub.GetSQL(DBCode.DB_000001, new string[] { "303", ReportTable, ReportName }), "ReportData", ReportData);
      }
    }

    private void dispView_ContentCellClick(object sender, AxgrproLib._IGRDisplayViewerEvents_ContentCellClickEvent e)
    {
      if ((Report.ColumnByName("CheckBox") != null) && (Report.ColumnByName("CheckBox").Name == e.pSender.Column.Name))
      {
        Report.DetailGrid.Recordset.Edit();
        if (Report.FieldByName("Checked").AsInteger == (int)GRSystemImage.grsi3DUnchecked)
          Report.FieldByName("Checked").AsInteger = (int)GRSystemImage.grsi3DChecked;
        else
          Report.FieldByName("Checked").AsInteger = (int)GRSystemImage.grsi3DUnchecked;
        Report.DetailGrid.Recordset.Post();
        dispView.UpdateSelCell();
      }
    }

    private void dispView_ContentCellDblClick(object sender, AxgrproLib._IGRDisplayViewerEvents_ContentCellDblClickEvent e)
    {
      if (ItemEdit.Enabled) ItemEdit.PerformClick();
    }

    private void dispView_SelectionCellChange(object sender, AxgrproLib._IGRDisplayViewerEvents_SelectionCellChangeEvent e)
    {
      RefreshForm(true);
    }

    private void dispView_MouseDownEvent(object sender, AxgrproLib._IGRDisplayViewerEvents_MouseDownEvent e)
    {
      if (e.button == GRMouseButton.grmbRight) contextMenu.Show(dispView, e.xPos, e.yPos);
    }

    private void frmBaseMDIChildReport_Activated(object sender, EventArgs e)
    {
      IsActiveForm = true;
      try
      {
        dispView.Start();
      }
      catch
      {
      }
      if (IsFirst)
      {
        IsFirst = false;
        if (ShowKQType)
        {
          KQTypeShow();
          dispView.Refresh();
          dispView_ColumnLayoutChange(null, null);
        }
        if (!IgnoreRefreshFirst) ExecItemRefresh();
      }
    }

    private void ItemSetupDisplay_Click(object sender, EventArgs e)
    {
      contextMenu.Close();
      frmPubDisplay frm = new frmPubDisplay(Report, this.Text + "[" + ((ToolStripItem)sender).Text + "]",
        ReportStartIndex);
      if (frm.ShowDialog() == DialogResult.OK)
      {
        dispView.Refresh();
        dispView_ColumnLayoutChange(null, null);
      }
    }

    private void ReportBeforePostRecord()
    {
      if (Report.DetailGrid != null)
      {
        if ((Report.FieldByName("Checked") != null) && Report.FieldByName("Checked").IsNull)
        {
          Report.FieldByName("Checked").AsInteger = (int)GRSystemImage.grsi3DUnchecked;
        }
      }
    }

    private void ReportExportBegin(IGRExportOption Sender)
    {
      switch (Sender.ExportType)
      {
        case GRExportType.gretXLS:
          Sender.AsE2XLSOption.MailExportFile = false;
          Sender.AsE2XLSOption.ExportPageBreak = false;
          Sender.AsE2XLSOption.ColumnAsDetailGrid = false;
          Sender.AsE2XLSOption.SameAsPrint = false;
          Sender.AsE2XLSOption.ExportPageHeaderFooter = false;
          Sender.AsE2XLSOption.OnlyExportPureText = false;
          Sender.AsE2XLSOption.ExpandRowHeight = false;
          Sender.AsE2XLSOption.OnlyExportDetailGrid = true;
          Sender.AsE2XLSOption.SupressEmptyLines = false;
          Sender.AsE2XLSOption.ExpandRowHeight = false;
          break;
        case GRExportType.gretTXT:
          Sender.AsE2TXTOption.MailExportFile = false;
          Sender.AsE2TXTOption.OnlyExportDetailGrid = true;
          break;
        case GRExportType.gretHTM:
          Sender.AsE2HTMOption.OnlyExportDetailGrid = true;
          break;
        case GRExportType.gretRTF:
          Sender.AsE2RTFOption.ExportPageBreak = false;
          Sender.AsE2RTFOption.SameAsPrint = false;
          Sender.AsE2RTFOption.ExportPageHeaderFooter = false;
          Sender.AsE2RTFOption.OnlyExportDetailGrid = true;
          break;
        case GRExportType.gretPDF:
          break;
        case GRExportType.gretCSV:
          Sender.AsE2CSVOption.OnlyExportDetailGrid = true;
          break;
        case GRExportType.gretIMG:
          Sender.AsE2IMGOption.ImageType = GRExportImageType.greitJPEG;
          break;
      }
    }

    private void ShowReportHeader(bool state)
    {
      if (IgnoreReportHead) return;
      for (int j = 1; j <= Report.ReportHeaderCount; j++)
      {
        Report.get_ReportHeader(j).Visible = state;
      }
    }

    protected void LoadReport()
    {
      if (IsActiveForm) return;
      ItemExport.Enabled = false;
      ItemPrint.Enabled = false;
      ItemTAGExt.Enabled = false;
      if (ReportFile != "") ReportFile = SystemInfo.ReportPath + ReportFile + ".grf";
      try
      {
        dispView.Stop();
      }
      catch
      {
      }
      try
      {
        if ((ReportFile != "") && File.Exists(ReportFile))
          Report.LoadFromFile(ReportFile);
        else if (ReportData != "")
          Report.LoadFromStr(ReportData);
        if (Report.DetailGrid != null)
        {
          Report.DetailGrid.Recordset.ConnectionString = SystemInfo.ConnStrReport;
          Report.DetailGrid.Recordset.QuerySQL = "";
          //Report.BeforePostRecord += new _IGridppReportEvents_BeforePostRecordEventHandler(ReportBeforePostRecord);
          //Report.ExportBegin += new _IGridppReportEvents_ExportBeginEventHandler(ReportExportBegin);
          //Report.BeforePostRecord += new _IGridppReportEvents_BeforePostRecordEventHandler(ReportBeforePostRecord);
        }
        Report.ShowProgressUI = false;
        ShowReportHeader(false);
        if (ShowKQType) KQTypeShow();
        dispView.Start();
        ItemTAGExt.Enabled = true;
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E);
      }
      SetContextMenuState();
    }

    protected void SetReportColumnVisible(string colName, bool visible)
    {
      if (Report.ColumnByName(colName) != null) Report.ColumnByName(colName).Visible = visible;
    }

    protected virtual void KQTypeShow()
    {
      DataTable dt = null;
      DataTable dt1 = null;
      DataTable dt2 = null;
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        dt = db.GetDataTable(Pub.GetSQL(DBCode.DB_002002, new string[] { "0" }));
        dt1 = db.GetDataTable(Pub.GetSQL(DBCode.DB_002002, new string[] { "100" }));
        dt2 = db.GetDataTable(Pub.GetSQL(DBCode.DB_002002, new string[] { "200" }));
        IGRColumn col;
        for (int i = 1; i <= 10; i++)
        {
          col = Report.DetailGrid.Columns["JB" + i.ToString("00")];
          col.Visible = false;
          if (i - 1 < dt.Rows.Count)
          {
            col.Visible = true;
            col.TitleCell.Text = dt.Rows[i - 1]["OtTypeName"].ToString();
          }
          col = Report.DetailGrid.Columns["QJ" + i.ToString("00")];
          col.Visible = false;
          if (i - 1 < dt1.Rows.Count)
          {
            col.Visible = true;
            col.TitleCell.Text = dt1.Rows[i - 1]["DayOffTypeName"].ToString();
          }
          col = Report.DetailGrid.Columns["CC" + i.ToString("00")];
          col.Visible = false;
          if (i - 1 < dt2.Rows.Count)
          {
            col.Visible = true;
            col.TitleCell.Text = dt2.Rows[i - 1]["TripTypeName"].ToString();
          }
        }
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E);
      }
      finally
      {
        if (dt != null)
        {
          dt.Clear();
          dt.Reset();
        }
        if (dt1 != null)
        {
          dt1.Clear();
          dt1.Reset();
        }
        if (dt2 != null)
        {
          dt2.Clear();
          dt2.Reset();
        }
      }
    }

    protected void DepositTypeShow(AxGRDisplayViewer grv)
    {
      IGRColumn col;
      IGRColumn colSum;
      int id;
      string s;
      for (int i = 0; i <= 9; i++)
      {
        col = Report.DetailGrid.Columns["CountCZ" + i.ToString()];
        if (col != null) col.Visible = false;
        colSum = Report.DetailGrid.Columns["CountSumCZ" + i.ToString()];
        if (colSum != null) colSum.Visible = false;
        col = Report.DetailGrid.Columns["CountMCZ" + i.ToString()];
        if (col != null) col.Visible = false;
        colSum = Report.DetailGrid.Columns["CountMSumCZ" + i.ToString()];
        if (colSum != null) colSum.Visible = false;
      }
      DataTable dt = null;
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        dt = db.GetDataTable(Pub.GetSQL(DBCode.DB_004013, new string[] { "0" }));
        for (int i = 0; i <= 9; i++)
        {
          if (i >= dt.Rows.Count) break;
          id = Convert.ToInt32(dt.Rows[i]["DepositTypeID"].ToString());
          s = dt.Rows[i]["DepositTypeName"].ToString();
          if (id >= 100 && id <= 109)
          {
            id -= 100;
            col = Report.DetailGrid.Columns["CountCZ" + id.ToString()];
            if (col != null)
            {
              col.Visible = true;
              col.TitleCell.SupCell.Text = s;
            }
            colSum = Report.DetailGrid.Columns["CountSumCZ" + id.ToString()];
            if (colSum != null)
            {
              colSum.Visible = true;
              if (col == null)
              {
                colSum.TitleCell.Text = s;
              }
              else
              {
                if (colSum.TitleCell.SupCell == null)
                  colSum.TitleCell.Text = s;
                else
                  colSum.TitleCell.SupCell.Text = s;
              }
            }
          }
        }
        dt = db.GetDataTable(Pub.GetSQL(DBCode.DB_004013, new string[] { "103" }));
        for (int i = 0; i <= 9; i++)
        {
          if (i >= dt.Rows.Count) break;
          s = dt.Rows[i]["SFTypeName"].ToString();
          col = Report.DetailGrid.Columns["CountMCZ" + i.ToString()];
          if (col != null)
          {
            col.Visible = true;
            col.TitleCell.SupCell.Text = s;
          }
          colSum = Report.DetailGrid.Columns["CountMSumCZ" + i.ToString()];
          if (colSum != null)
          {
            colSum.Visible = true;
            if (col == null)
            {
              colSum.TitleCell.Text = s;
            }
            else
            {
              if (colSum.TitleCell.SupCell == null)
                colSum.TitleCell.Text = s;
              else
                colSum.TitleCell.SupCell.Text = s;
            }
          }
        }
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E);
      }
      finally
      {
        if (dt != null)
        {
          dt.Clear();
          dt.Reset();
        }
      }
      grv.Refresh();
    }

    protected virtual void ExecKeyDown(KeyEventArgs e)
    {
      if (!ItemExport.Enabled) return;
      if (e.Control && e.Alt)
      {
        switch (e.KeyCode)
        {
          case Keys.D0:
            ShowReportHeader(true);
            ExportToTXT(Report, this.Text, SystemInfo.AppPath + this.Text + ".txt");
            ShowReportHeader(false);
            break;
          case Keys.D1:
            ShowReportHeader(true);
            ExportToHTM(Report, this.Text, SystemInfo.AppPath + this.Text + ".html");
            ShowReportHeader(false);
            break;
          case Keys.D2:
            ShowReportHeader(true);
            ExportToRTF(Report, this.Text, SystemInfo.AppPath + this.Text + ".rtf");
            ShowReportHeader(false);
            break;
          case Keys.D3:
            ShowReportHeader(true);
            ExportToPDF(Report, this.Text, SystemInfo.AppPath + this.Text + ".pdf");
            ShowReportHeader(false);
            break;
          case Keys.D4:
            ShowReportHeader(true);
            ExportToCSV(Report, this.Text, SystemInfo.AppPath + this.Text + ".csv");
            ShowReportHeader(false);
            break;
          case Keys.D5:
            ShowReportHeader(true);
            ExportToIMG(Report, this.Text, SystemInfo.AppPath + this.Text);
            ShowReportHeader(false);
            break;
        }
      }
    }

    private void frmBaseMDIChildReport_KeyDown(object sender, KeyEventArgs e)
    {
      ExecKeyDown(e);
    }
  }
}