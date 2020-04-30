using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using AxgrproLib;
using grproLib;

namespace ECard78
{
  public partial class frmBaseForm : Form
  {
    protected string formCode = "";
    protected Base Pub = new Base();
    protected Database db = null;
    protected List<TCardType> cardTypeList = new List<TCardType>();
    protected bool IgnoreReportSet = false;
    protected bool IsFinger = false;
    protected bool HasAbnormal = false;
    protected bool IsToggleCheckStateAll = false;

    public bool IsAllowanceDownSelect = false;

    protected void AddColumn(DataGridView grid, int colType, string Field, bool IsHide, bool HasSort,
      byte CenterFlag, int colWidth)
    {
      grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
      DataGridViewTextBoxColumn colText;
      DataGridViewCheckBoxColumn colCheck;
      DataGridViewComboBoxColumn colCombo;
      switch (colType)
      {
        case 0:
          colText = new DataGridViewTextBoxColumn();
          colText.DataPropertyName = Field;
          colText.Visible = !IsHide;
          if (!HasSort) colText.SortMode = DataGridViewColumnSortMode.NotSortable;
          colText.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
          if (CenterFlag == 1)
            colText.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
          else if (CenterFlag == 2)
            colText.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          if (colWidth > 0)
            colText.Width = colWidth;
          else
            colText.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
          grid.Columns.Add(colText);
          break;
        case 1:
          colCheck = new DataGridViewCheckBoxColumn();
          colCheck.DataPropertyName = Field;
          colCheck.Visible = !IsHide;
          colCheck.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
          if (CenterFlag == 1)
            colCheck.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
          else if (CenterFlag == 2)
            colCheck.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          if (colWidth > 0)
            colCheck.Width = colWidth;
          else
            colCheck.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
          grid.Columns.Add(colCheck);
          break;
        case 2:
          colCombo = new DataGridViewComboBoxColumn();
          colCombo.DataPropertyName = Field;
          colCombo.Visible = !IsHide;
          colCombo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
          if (CenterFlag == 1)
            colCombo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
          else if (CenterFlag == 2)
            colCombo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          if (colWidth > 0)
            colCombo.Width = colWidth;
          else
            colCombo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
          colCombo.DisplayStyleForCurrentCellOnly = true;
          grid.Columns.Add(colCombo);
          break;
      }
    }

    protected void SetControlsText(Control obj)
    {
      MenuStrip menuBar;
      ContextMenuStrip ContextMenu;
      ToolStrip toolBar;
      ListView listView;
      DataGridView grid;
      StatusStrip statusBar;
      ToolStripMenuItem MenuItem;
      TabControl tabC;
      GroupBox gbx;
      Label lab;
      CheckBox chk;
      RadioButton rb;
      Button btn;
      AxGRDisplayViewer grv;
      SplitContainer sc;
      TextBox txt;
      for (int i = 0; i < obj.Controls.Count; i++)
      {
        if (obj.Controls[i].ContextMenuStrip != null)
        {
          ContextMenu = (ContextMenuStrip)obj.Controls[i].ContextMenuStrip;
          for (int j = 0; j < ContextMenu.Items.Count; j++)
          {
            ContextMenu.Items[j].Text = Pub.GetResText(formCode, ContextMenu.Items[j].Name, ContextMenu.Items[j].Text);
          }
        }
        if (obj.Controls[i] is MenuStrip)
        {
          menuBar = (MenuStrip)obj.Controls[i];
          for (int j = 0; j < menuBar.Items.Count; j++)
          {
            MenuItem = (ToolStripMenuItem)menuBar.Items[j];
            MenuItem.Text = Pub.GetResText(formCode, MenuItem.Name, MenuItem.Text);
            for (int k = 0; k < MenuItem.DropDownItems.Count; k++)
            {
              MenuItem.DropDownItems[k].Text = Pub.GetResText(formCode, MenuItem.DropDownItems[k].Name, MenuItem.DropDownItems[k].Text);
            }
          }
        }
        else if (obj.Controls[i] is ToolStrip)
        {
          toolBar = (ToolStrip)obj.Controls[i];
          for (int j = 0; j < toolBar.Items.Count; j++)
          {
            if (toolBar.Items[j].Tag != null)
              toolBar.Items[j].Text = Pub.GetResText(formCode, toolBar.Items[j].Tag.ToString(), toolBar.Items[j].Text);
            else
              toolBar.Items[j].Text = Pub.GetResText(formCode, toolBar.Items[j].Name, toolBar.Items[j].Text);
            toolBar.Items[j].ToolTipText = toolBar.Items[j].Text;
            if (toolBar.Items[j] is ToolStripTextBox)
            {
              toolBar.Items[j].Text = "";
              ((ToolStripTextBox)toolBar.Items[j]).GotFocus += TextBox_GotFocus;
            }
          }
        }
        else if (obj.Controls[i] is ListView)
        {
          listView = (ListView)obj.Controls[i];
          for (int j = 0; j < listView.Columns.Count; j++)
          {
            if (listView.Columns[j].Tag != null)
              listView.Columns[j].Text = Pub.GetResText(formCode, listView.Columns[j].Tag.ToString(), listView.Columns[j].Text);
            else
              listView.Columns[j].Text = Pub.GetResText(formCode, listView.Columns[j].Name, listView.Columns[j].Text);
          }
        }
        else if (obj.Controls[i] is TreeView)
        {
          ((TreeView)obj.Controls[i]).ItemHeight = 17;
        }
        else if (obj.Controls[i] is DataGridView)
        {
          grid = (DataGridView)obj.Controls[i];
          for (int j = 0; j < grid.ColumnCount; j++)
          {
            if (grid.Columns[j].DataPropertyName == "")
              grid.Columns[j].HeaderText = Pub.GetResText(formCode, grid.Columns[j].Name, grid.Columns[j].HeaderText);
            else
              grid.Columns[j].HeaderText = Pub.GetResText(formCode, grid.Columns[j].DataPropertyName, grid.Columns[j].HeaderText);
            if (j > 0) grid.Columns[j].ReadOnly = true;
          }
        }
        else if (obj.Controls[i] is StatusStrip)
        {
          statusBar = (StatusStrip)obj.Controls[i];
          for (int j = 0; j < statusBar.Items.Count; j++)
          {
            statusBar.Items[j].Text = Pub.GetResText(formCode, statusBar.Items[j].Name, statusBar.Items[j].Text);
          }
        }
        else if (obj.Controls[i] is Panel)
        {
          SetControlsText(obj.Controls[i]);
        }
        else if (obj.Controls[i] is GroupBox)
        {
          gbx = (GroupBox)obj.Controls[i];
          gbx.Text = Pub.GetResText(formCode, gbx.Name, gbx.Text);
          if ((gbx.Text == "") && (gbx.Tag != null))
          {
            gbx.Text = Pub.GetResText(formCode, gbx.Tag.ToString(), gbx.Text);
          }
          SetControlsText(gbx);
        }
        else if (obj.Controls[i] is TabControl)
        {
          tabC = (TabControl)obj.Controls[i];
          for (int j = 0; j < tabC.TabCount; j++)
          {
            tabC.TabPages[j].Text = Pub.GetResText(formCode, tabC.TabPages[j].Name, tabC.TabPages[j].Text);
            if ((tabC.TabPages[j].Text == "") && (tabC.TabPages[j].Tag != null))
            {
              tabC.TabPages[j].Text = Pub.GetResText(formCode, tabC.TabPages[j].Tag.ToString(), tabC.TabPages[j].Text);
            }
            SetControlsText(tabC.TabPages[j]);
          }
        }
        else if (obj.Controls[i] is Label)
        {
          lab = (Label)obj.Controls[i];
          lab.BackColor = Color.Transparent;
          lab.Text = Pub.GetResText(formCode, lab.Name, lab.Text);
          if ((lab.Text == "") && (lab.Tag != null))
          {
            lab.Text = Pub.GetResText(formCode, lab.Tag.ToString(), lab.Text);
          }
          toolTip.SetToolTip(lab, lab.Text);
        }
        else if (obj.Controls[i] is CheckBox)
        {
          chk = (CheckBox)obj.Controls[i];
          chk.BackColor = Color.Transparent;
          chk.Text = Pub.GetResText(formCode, chk.Name, chk.Text);
          if ((chk.Text == "") && (chk.Tag != null))
          {
            chk.Text = Pub.GetResText(formCode, chk.Tag.ToString(), chk.Text);
          }
          toolTip.SetToolTip(chk, chk.Text);
        }
        else if (obj.Controls[i] is RadioButton)
        {
          rb = (RadioButton)obj.Controls[i];
          rb.BackColor = Color.Transparent;
          rb.Text = Pub.GetResText(formCode, rb.Name, rb.Text);
          if ((rb.Text == "") && (rb.Tag != null))
          {
            rb.Text = Pub.GetResText(formCode, rb.Tag.ToString(), rb.Text);
          }
          toolTip.SetToolTip(rb, rb.Text);
        }
        else if (obj.Controls[i] is Button)
        {
          btn = (Button)obj.Controls[i];
          btn.Text = Pub.GetResText(formCode, btn.Name, btn.Text);
          if ((btn.Text == "") && (btn.Tag != null))
          {
            btn.Text = Pub.GetResText(formCode, btn.Tag.ToString(), btn.Text);
          }
          toolTip.SetToolTip(btn, btn.Text);
        }
        else if (obj.Controls[i] is TextBox)
        {
          txt = (TextBox)obj.Controls[i];
          if (txt.PasswordChar.ToString() == "\0") txt.ImeMode = ImeMode.On;
        }
        else if (obj.Controls[i] is AxGRDisplayViewer)
        {
          grv = (AxGRDisplayViewer)obj.Controls[i];
          if (grv.Report == null) continue;
          SetReportCaption(grv);
        }
        else if (obj.Controls[i] is SplitContainer)
        {
          sc = (SplitContainer)obj.Controls[i];
          SetControlsText(sc.Panel1);
          SetControlsText(sc.Panel2);
        }
        if ((obj.Controls[i] is TextBox) || (obj.Controls[i] is MaskedTextBox) ||
          (obj.Controls[i] is NumericUpDown) || (obj.Controls[i] is RichTextBox))
        {
          obj.Controls[i].GotFocus += TextBox_GotFocus;
        }
        if (obj.Controls[i] is ComboBox)
        {
          ((ComboBox)obj.Controls[i]).DropDown += ComboBox_OnDropDown;
          ((ComboBox)obj.Controls[i]).ImeMode = ImeMode.Disable;
        }
        if ((obj.Controls[i] is DataGridView) || (obj.Controls[i] is HeaderView) || (obj.Controls[i] is RowMergeView))
        {
          grid = (DataGridView)obj.Controls[i];
          grid.AutoGenerateColumns = false;
          if (!(obj.Controls[i] is HeaderView))
          {
            grid.ColumnHeadersHeight = 20;
          }
          grid.RowTemplate.Height = 20;
        }
      }
    }

    protected void SetReportCaption(AxGRDisplayViewer grv)
    {
      if (IgnoreReportSet) return;
      if (grv.Report != null)
      {
        grv.Report.Font.Name = this.Font.Name;
        grv.Report.Font.Charset = this.Font.GdiCharSet;
        SetReportCaption(grv.Report);
      }
      grv.BorderStyle = GRViewerBorderStyle.grvbsFixed3D;
      grv.ShowFooter = true;
      grv.ShowHeader = true;
      grv.GridCenterView = true;
      grv.RowSelection = true;
      grv.Resortable = true;
      grv.ResortCaseSensitive = true;
      grv.ResortDefaultAsc = true;
      grv.ColumnMove = true;
      grv.ColumnResize = true;
      grv.Searchable = false;
      grv.SelectionBackColor = Color.Teal;
      grv.SelectionForeColor = Color.White;
      grv.SelectionFollowScroll = false;
    }

    protected void SetReportCaption(GridppReport rpt)
    {
      IGRColumnTitleCell supCell;
      if (IgnoreReportSet) return;
      string s = "";
      string s1 = "";
      string cap = "";
      rpt.Font.Name = this.Font.Name;
      rpt.Font.Charset = this.Font.GdiCharSet;
      if (rpt.DetailGrid != null)
      {
        rpt.DetailGrid.CenterView = true;
        rpt.DetailGrid.Font.Name = this.Font.Name;
        rpt.DetailGrid.Font.Charset = this.Font.GdiCharSet;
        rpt.DetailGrid.ColumnTitle.Font.Name = this.Font.Name;
        rpt.DetailGrid.ColumnTitle.Font.Charset = this.Font.GdiCharSet;
        for (int j = 1; j <= rpt.ReportHeaderCount; j++)
        {
          for (int k = 1; k <= rpt.get_ReportHeader(j).Controls.Count; k++)
          {
            if (rpt.get_ReportHeader(j).Controls[k].Name == null) continue;
            s = rpt.get_ReportHeader(j).Controls[k].Name;
            if (s.ToLower().Trim() == "maintitlebox")
              rpt.get_ReportHeader(j).Controls[k].AsStaticBox.Text = "";
            else if (s.ToLower().Trim() == "staticboxdate")
              rpt.get_ReportHeader(j).Controls[k].AsStaticBox.Text = "";
            else if (rpt.get_ReportHeader(j).Controls[k] is IGRStaticBox)
            {
              s1 = rpt.get_ReportHeader(j).Controls[k].AsStaticBox.Tag;
              if (s1 != null && s1 != "")
                s1 = Pub.GetResText(formCode, s1, rpt.get_ReportHeader(j).Controls[k].AsStaticBox.Text);
              else
                s1 = Pub.GetResText(formCode, s, rpt.get_ReportHeader(j).Controls[k].AsStaticBox.Text);
              rpt.get_ReportHeader(j).Controls[k].AsStaticBox.Text = s1;
            }
          }
        }
        for (int j = 1; j <= rpt.DetailGrid.Groups.Count; j++)
        {
          for (int k = 1; k <= rpt.DetailGrid.Groups[j].Header.Controls.Count; k++)
          {
            if (rpt.DetailGrid.Groups[j].Header.Controls[k].Name == null) continue;
            if (rpt.DetailGrid.Groups[j].Header.Controls[k] is IGRStaticBox)
            {
              s = rpt.DetailGrid.Groups[j].Header.Controls[k].Name;
              if (s.ToLower() == "commanyname")
              {
                s = SystemInfo.CommanyName;
                rpt.DetailGrid.Groups[j].Header.Controls[k].AsStaticBox.Text = s;
              }
              else
              {
                s1 = rpt.DetailGrid.Groups[j].Header.Controls[k].AsStaticBox.Tag;
                if (s1 != null && s1 != "")
                  s1 = Pub.GetResText(formCode, s1, rpt.DetailGrid.Groups[j].Header.Controls[k].AsStaticBox.Text);
                else
                  s1 = Pub.GetResText(formCode, s, rpt.DetailGrid.Groups[j].Header.Controls[k].AsStaticBox.Text);
                rpt.DetailGrid.Groups[j].Header.Controls[k].AsStaticBox.Text = s1;
              }
            }
          }
          for (int k = 1; k <= rpt.DetailGrid.Groups[j].Footer.Controls.Count; k++)
          {
            if (rpt.DetailGrid.Groups[j].Footer.Controls[k].Name == null) continue;
            s = rpt.DetailGrid.Groups[j].Footer.Controls[k].Name;
            if (s.ToLower().Trim() == "staticboxsum")
            {
              s = Pub.GetResText(formCode, "StaticBoxSum", "");
              rpt.DetailGrid.Groups[j].Footer.Controls[k].AsStaticBox.Text = s;
            }
            else if (s.ToLower().Trim() == "staticboxsummin")
            {
              s = Pub.GetResText(formCode, "StaticBoxSumMin", "");
              rpt.DetailGrid.Groups[j].Footer.Controls[k].AsStaticBox.Text = s;
            }
            else if (rpt.DetailGrid.Groups[j].Footer.Controls[k] is IGRStaticBox)
            {
              s1 = rpt.DetailGrid.Groups[j].Footer.Controls[k].AsStaticBox.Tag;
              if (s1 != null && s1 != "")
                s1 = Pub.GetResText(formCode, s1, rpt.DetailGrid.Groups[j].Footer.Controls[k].AsStaticBox.Text);
              else
                s1 = Pub.GetResText(formCode, s, rpt.DetailGrid.Groups[j].Footer.Controls[k].AsStaticBox.Text);
              rpt.DetailGrid.Groups[j].Footer.Controls[k].AsStaticBox.Text = s1;
            }
          }
        }
        for (int j = 1; j <= rpt.ReportFooterCount; j++)
        {
          for (int k = 1; k <= rpt.get_ReportFooter(j).Controls.Count; k++)
          {
            if (rpt.get_ReportFooter(j).Controls[k].Name == null) continue;
            s = rpt.get_ReportFooter(j).Controls[k].Name;
            if (s.ToLower().Trim() == "staticboxsum")
            {
              s = Pub.GetResText(formCode, "StaticBoxSum", "");
              rpt.get_ReportFooter(j).Controls[k].AsStaticBox.Text = s;
            }
            else if (s.ToLower().Trim() == "staticboxsummin")
            {
              s = Pub.GetResText(formCode, "StaticBoxSumMin", "");
              rpt.get_ReportFooter(j).Controls[k].AsStaticBox.Text = s;
            }
            else if (rpt.get_ReportFooter(j).Controls[k] is IGRStaticBox)
            {
              s1 = rpt.get_ReportFooter(j).Controls[k].AsStaticBox.Tag;
              if (s1 != null && s1 != "")
                s1 = Pub.GetResText(formCode, s1, rpt.get_ReportFooter(j).Controls[k].AsStaticBox.Text);
              else
                s1 = Pub.GetResText(formCode, s, rpt.get_ReportFooter(j).Controls[k].AsStaticBox.Text);
              rpt.get_ReportFooter(j).Controls[k].AsStaticBox.Text = s1;
            }
          }
        }
        for (int j = 1; j <= rpt.DetailGrid.Columns.Count; j++)
        {
          try
          {
            rpt.DetailGrid.Columns[j].TitleCell.Font.Name = this.Font.Name;
            rpt.DetailGrid.Columns[j].TitleCell.Font.Charset = this.Font.GdiCharSet;
            rpt.DetailGrid.Columns[j].ContentCell.Font.Name = this.Font.Name;
            rpt.DetailGrid.Columns[j].ContentCell.Font.Charset = this.Font.GdiCharSet;
            supCell = rpt.DetailGrid.Columns[j].TitleCell.SupCell;
            while (supCell != null)
            {
              s = supCell.Name;
              s = Pub.GetResText(formCode, s, supCell.Text);
              supCell.Text = s;
              supCell = supCell.SupCell;
            }
            if (rpt.DetailGrid.Columns[j].Name.ToLower().Trim() == "checkbox")
              cap = Pub.GetResText(formCode, "SelectCheck", "");
            else
            {
              s = rpt.DetailGrid.Columns[j].Name;
              cap = Pub.GetResText(formCode, s, rpt.DetailGrid.Columns[j].TitleCell.Text);
              if ((cap == "") && (rpt.DetailGrid.Columns[j].TitleCell.Tag != null))
              {
                s = rpt.DetailGrid.Columns[j].TitleCell.Tag;
                cap = Pub.GetResText(formCode, s, rpt.DetailGrid.Columns[j].TitleCell.Text);
              }
              if ((cap == "") && !rpt.DetailGrid.Columns[j].ContentCell.FreeCell)
              {
                s = rpt.DetailGrid.Columns[j].ContentCell.DataField;
                cap = Pub.GetResText(formCode, s, rpt.DetailGrid.Columns[j].TitleCell.Text);
              }
            }
            for (int k = 1; k <= rpt.DetailGrid.Columns[j].TitleCell.Controls.Count; k++)
            {
              if (rpt.DetailGrid.Columns[j].TitleCell.Controls[k] is IGRStaticBox)
              {
                if (rpt.DetailGrid.Columns[j].TitleCell.Controls[k].Name != null)
                {
                  s = rpt.DetailGrid.Columns[j].TitleCell.Controls[k].Name;
                  s = Pub.GetResText(formCode, s, rpt.DetailGrid.Columns[j].TitleCell.Controls[k].AsStaticBox.Text);
                  rpt.DetailGrid.Columns[j].TitleCell.Controls[k].AsStaticBox.Text = s;
                }
              }
            }
            rpt.DetailGrid.Columns[j].TitleCell.Text = cap;
          }
          catch
          {
          }
        }
      }
    }

    protected void SetReportTitle(AxGRDisplayViewer grv, string Title)
    {
      string reportTitle = RegisterInfo.RegUser == "" ? SystemInfo.CommanyName : RegisterInfo.RegUser;
      if (RegisterInfo.IsTest && RegisterInfo.IsValid) reportTitle = RegisterInfo.StateText;
      bool hasCommanyBox = false;
      if (grv.Report.PageHeader != null)
      {
        for (int j = 1; j <= grv.Report.PageHeader.Controls.Count; j++)
        {
          if (grv.Report.PageHeader.Controls[j].Name == null) continue;
          if (grv.Report.PageHeader.Controls[j].Name.ToLower() == "staticboxcommany")
          {
            hasCommanyBox = true;
            grv.Report.PageHeader.Controls[j].AsStaticBox.Text = reportTitle;
            break;
          }
        }
      }
      if (!hasCommanyBox)
      {
        for (int j = 1; j <= grv.Report.ReportHeaderCount; j++)
        {
          for (int k = 1; k <= grv.Report.get_ReportHeader(j).Controls.Count; k++)
          {
            if (grv.Report.get_ReportHeader(j).Controls[k].Name == null) continue;
            if (grv.Report.get_ReportHeader(j).Controls[k].Name.ToLower().Trim() == "staticboxcommany")
            {
              grv.Report.get_ReportHeader(j).Controls[k].AsStaticBox.Text = reportTitle;
              hasCommanyBox = true;
              break;
            }
          }
          if (hasCommanyBox) break;
        }
      }
      if (!hasCommanyBox) Title = reportTitle + Title;
      for (int j = 1; j <= grv.Report.ReportHeaderCount; j++)
      {
        for (int k = 1; k <= grv.Report.get_ReportHeader(j).Controls.Count; k++)
        {
          if (grv.Report.get_ReportHeader(j).Controls[k].Name == null) continue;
          if (grv.Report.get_ReportHeader(j).Controls[k].Name.ToLower().Trim() == "maintitlebox")
          {
            grv.Report.get_ReportHeader(j).Controls[k].AsStaticBox.Text = Title;
            return;
          }
        }
      }
    }

    protected void SetReportDate(AxGRDisplayViewer grv, string date)
    {
      for (int j = 1; j <= grv.Report.ReportHeaderCount; j++)
      {
        for (int k = 1; k <= grv.Report.get_ReportHeader(j).Controls.Count; k++)
        {
          if (grv.Report.get_ReportHeader(j).Controls[k].Name == null) continue;
          if (grv.Report.get_ReportHeader(j).Controls[k].Name.ToLower().Trim() == "staticboxdate")
          {
            grv.Report.get_ReportHeader(j).Controls[k].AsStaticBox.Text = date;
            grv.Report.get_ReportHeader(j).Controls[k].AsStaticBox.Dock = GRDockStyle.grdsBottom;
            return;
          }
        }
      }
    }

    protected virtual void InitForm()
    {
      if (!SystemInfo.isInit)
      {
        SystemInfo.isInit = true;
        SystemInfo.AppPath = GetFileNamePath(Application.ExecutablePath);
        SystemInfo.ReportPath = SystemInfo.AppPath + "Report\\";
        SystemInfo.DataFilePath = SystemInfo.AppPath + "DataFile\\";
        SystemInfo.System32Path = Environment.SystemDirectory;
        if (SystemInfo.System32Path.Substring(SystemInfo.System32Path.Length - 1) != "\\")
        {
          SystemInfo.System32Path = SystemInfo.System32Path + "\\";
        }
        SystemInfo.IniFileName = SystemInfo.AppPath + "ECard78.ini";
        if (SystemInfo.ini == null)
        {
          SystemInfo.ini = new IniFile(SystemInfo.IniFileName);
          string tmpLang = SystemInfo.ini.ReadIni("Public", "Lang", "");
          if (SystemInfo.langList.IndexOf(tmpLang) >= 0)
          {
            SystemInfo.LangName = tmpLang;
            switch (SystemInfo.LangName)
            {
              case "CHS"://简体中文
                SystemInfo.AppTitle = SystemInfo.AppTitleLNG[0];
                break;
              case "CHT"://繁体中文
                SystemInfo.AppTitle = SystemInfo.AppTitleLNG[1];
                break;
              default:
                SystemInfo.AppTitle = SystemInfo.AppTitleLNG[SystemInfo.AppTitleLNG.Length - 1];
                break;
            }
          }
        }
        if (SystemInfo.webIni == null) SystemInfo.webIni = new IniFile(SystemInfo.AppPath + "www\\menu.ini");
        if (SystemInfo.res == null) SystemInfo.res = new LangRes(SystemInfo.AppPath);
        SystemInfo.ComputerName = Pub.GetComputerName();
        SystemInfo.DBType = SystemInfo.ini.ReadIni("Public", "DBType", 1);
        if (DeviceObject.objAES == null) DeviceObject.objAES = new HSUNFK.AES();
        if (DeviceObject.objDES == null) DeviceObject.objDES = new HSUNFK.DES();
        if (DeviceObject.objCPIC == null) DeviceObject.objCPIC = new HSUNFK.CPIC();
        if (DeviceObject.objCard == null) DeviceObject.objCard = new HSUNFK.Card();
        if (DeviceObject.objKS == null) DeviceObject.objKS = new QHKS.KS();
        if (DeviceObject.objMJ == null) DeviceObject.objMJ = new QHKS.MJ();
        if (DeviceObject.objMJNew == null) DeviceObject.objMJNew = new AccessV2API();
        if (DeviceObject.objApp == null) DeviceObject.objApp = new QHKS.App();
        SystemInfo.CardTypeDefault = "";
        for (int i = 0; i < 256; i++)
        {
          SystemInfo.CardTypeDefault += "1";
        }
        SystemInfo.CurrencySymbol = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol;
        SystemInfo.MsgMaxCardID = Pub.GetResText("", "MsgCardIDIsBig", "");
        SystemInfo.MsgMaxCardID = string.Format(SystemInfo.MsgMaxCardID, 1, SystemInfo.MaxCardID);
        SystemInfo.DateTimeFormat = Pub.GetResText("Public", "DateTimeFormat", "yyyy-MM-dd HH:mm:ss");
        SystemInfo.DateTimeFormatLog = Pub.GetResText("Public", "DateTimeFormatLog", "yyyyMMddHHmmss");
        SystemInfo.DateFormatLog = Pub.GetResText("Public", "DateFormatLog", "yyyyMMdd");
        SystemInfo.YMFormat = Pub.GetResText("Public", "YMFormat", "yyyy-MM");
        SystemInfo.YMFormatDB = Pub.GetResText("Public", "YMFormatDB", "yyyyMM");
        if (SystemInfo.DateTimeFormat == "") SystemInfo.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        if (SystemInfo.DateTimeFormatLog == "") SystemInfo.DateTimeFormatLog = "yyyyMMddHHmmss";
        if (SystemInfo.DateFormatLog == "") SystemInfo.DateFormatLog = "yyyyMMdd";
        if (SystemInfo.YMFormat == "") SystemInfo.YMFormat = "yyyy-MM";
        if (SystemInfo.YMFormatDB == "") SystemInfo.YMFormatDB = "yyyyMM";
      }
      this.Text = Pub.GetResText(formCode, "Caption", this.Text);
      SetControlsText(this);
      db = new Database("");
    }

    protected virtual void FreeForm()
    {
      if (db != null) db.Close();
    }

    protected string GetConnStr(string DBName)
    {
      switch (SystemInfo.DBType)
      {
        case 1:
          DBServerInfo.ServerName = SystemInfo.ini.ReadIni("MSSQL", "Server", "");
          DBServerInfo.WindowsNT = SystemInfo.ini.ReadIni("MSSQL", "WindowsNT", true);
          DBServerInfo.UserName = Pub.GetAesDecrypt(SystemInfo.ini.ReadIni("MSSQL", "UserName", ""), SystemInfo.Encry);
          DBServerInfo.UserPass = Pub.GetAesDecrypt(SystemInfo.ini.ReadIni("MSSQL", "UserPass", ""), SystemInfo.Encry);
          break;
        case 2:
          DBServerInfo.ServerName = SystemInfo.ini.ReadIni("MSDE", "Server", "(local)\\MSDE");
          DBServerInfo.WindowsNT = SystemInfo.ini.ReadIni("MSDE", "WindowsNT", false);
          DBServerInfo.UserName = Pub.GetAesDecrypt(SystemInfo.ini.ReadIni("MSDE", "UserName", ""), SystemInfo.Encry);
          DBServerInfo.UserPass = Pub.GetAesDecrypt(SystemInfo.ini.ReadIni("MSDE", "UserPass", ""), SystemInfo.Encry);
          if (DBServerInfo.UserName == "") DBServerInfo.UserName = "sa";
          if (DBServerInfo.UserPass == "") DBServerInfo.UserPass = "1234";
          break;
      }
      return GetConnStr(SystemInfo.DBType, DBServerInfo.ServerName, DBServerInfo.WindowsNT,
        DBServerInfo.UserName, DBServerInfo.UserPass, DBName);
    }

    protected string GetConnStr(int DBType, string ServerName, bool WindowsNT, string UserName, string UserPass, string DBName)
    {
      string ret = "";
      switch (DBType)
      {
        case 1:
        case 2:
          ret = Pub.GetMSSQLConnStr(ServerName, WindowsNT, UserName, UserPass, DBName);
          break;
      }
      return ret;
    }

    protected string GetConnStrSystem()
    {
      return GetConnStrSystem(SystemInfo.DBType);
    }

    protected string GetConnStrSystem(int DBType)
    {
      string ret = "";
      switch (DBType)
      {
        case 1:
        case 2:
          ret = GetConnStr("master");
          break;
      }
      return ret;
    }

    protected string GetConnStrSystem(int DBType, string ServerName, bool WindowsNT, string UserName, string UserPass)
    {
      string ret = "";

      switch (DBType)
      {
        case 1:
        case 2:
          ret = GetConnStr(DBType, ServerName, WindowsNT, UserName, UserPass, "master");
          break;
      }
      return ret;
    }

    protected string GetConnStrPlan()
    {
      string ret = "";
      switch (SystemInfo.DBType)
      {
        case 1:
        case 2:
          ret = GetConnStr("msdb");
          break;
      }
      return ret;
    }

    protected string GetConnStrReport(string DBName)
    {
      switch (SystemInfo.DBType)
      {
        case 1:
          DBServerInfo.ServerName = SystemInfo.ini.ReadIni("MSSQL", "Server", "");
          DBServerInfo.WindowsNT = SystemInfo.ini.ReadIni("MSSQL", "WindowsNT", true);
          DBServerInfo.UserName = Pub.GetAesDecrypt(SystemInfo.ini.ReadIni("MSSQL", "UserName", ""), SystemInfo.Encry);
          DBServerInfo.UserPass = Pub.GetAesDecrypt(SystemInfo.ini.ReadIni("MSSQL", "UserPass", ""), SystemInfo.Encry);
          break;
        case 2:
          DBServerInfo.ServerName = SystemInfo.ini.ReadIni("MSDE", "Server", "(local)\\MSDE");
          DBServerInfo.WindowsNT = SystemInfo.ini.ReadIni("MSDE", "WindowsNT", false);
          DBServerInfo.UserName = Pub.GetAesDecrypt(SystemInfo.ini.ReadIni("MSDE", "UserName", ""), SystemInfo.Encry);
          DBServerInfo.UserPass = Pub.GetAesDecrypt(SystemInfo.ini.ReadIni("MSDE", "UserPass", ""), SystemInfo.Encry);
          if (DBServerInfo.UserName == "") DBServerInfo.UserName = "sa";
          if (DBServerInfo.UserPass == "") DBServerInfo.UserPass = "1234";
          break;
      }
      return GetConnStrReport(SystemInfo.DBType, DBServerInfo.ServerName, DBServerInfo.WindowsNT,
        DBServerInfo.UserName, DBServerInfo.UserPass, DBName);
    }

    protected string GetConnStrReport(int DBType, string ServerName, bool WindowsNT, string UserName, string UserPass, string DBName)
    {
      string ret = "";
      switch (DBType)
      {
        case 1:
        case 2:
          ret = Pub.GetMSSQLConnStrReport(ServerName, WindowsNT, UserName, UserPass, DBName);
          break;
      }
      return ret;
    }

    protected string GetFileNamePath(string FileName)
    {
      string ret = "";
      string[] tmp = FileName.Split('\\');

      for (int i = 0; i < tmp.Length - 1; i++)
      {
        ret += tmp[i] + "\\";
      }
      return ret;
    }

    [DllImport("user32", EntryPoint = "GetWindowLong")]
    private static extern int GetWindowLong(IntPtr hwnd, int nIndex);
    [DllImport("user32", EntryPoint = "SetWindowLong")]
    private static extern int SetWindowLong(IntPtr hwnd, int nIndex, int dwNewLong);
    private const int GWL_STYLE = (-16);
    private const int ES_NUMBER = 0x2000;
    protected void SetTextboxNumber(TextBox txtBox)
    {
      int CurrentStyle = GetWindowLong(txtBox.Handle, GWL_STYLE);
      CurrentStyle = CurrentStyle | ES_NUMBER;
      SetWindowLong(txtBox.Handle, GWL_STYLE, CurrentStyle);
      txtBox.ImeMode = ImeMode.Disable;
    }

    protected void InitDepartTreeView(TreeView tv)
    {
      InitDepartTreeView(tv, false);
    }

    protected void InitDepartTreeView(TreeView tv, bool InitEmp)
    {
      InitDepartTreeView(tv, InitEmp, false);
    }

    protected void InitDepartTreeView(TreeView tv, bool InitEmp, bool ShowStatus)
    {
      InitDepartTreeView(tv, InitEmp, ShowStatus, "");
    }

    protected void InitDepartTreeView(TreeView tv, bool InitEmp, bool ShowStatus, string otherCoin)
    {
      tv.BeginUpdate();
      if (tv.StateImageList == null)
      {
        if (tv.GetType().GetEvent("AfterCheck") == null)
        {
          tv.AfterCheck += TreeViewAfterCheck;
          tv.CheckBoxes = true;
        }
      }
      else
      {
        tv.KeyUp += TreeViewKeyUp;
        tv.NodeMouseClick += TreeViewNodeMouseClick;
      }
      tv.Nodes.Clear();
      DataTableReader dr = null;
      TreeNode node;
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { "101" }));
        while (dr.Read())
        {
          node = tv.Nodes.Add("[" + dr["DepartID"].ToString() + "]" + dr["DepartName"].ToString());
          node.Tag = dr["DepartSysID"].ToString();
          if (tv.StateImageList != null) node.StateImageIndex = 0;
          if (InitEmp) AddSubDepartEmp(tv, node, ShowStatus, otherCoin);
          AddSubDepart(tv, node, InitEmp, ShowStatus, otherCoin);
        }
      }
      catch (Exception E)
      {
        if (SystemInfo.ConnStr != "") Pub.ShowErrorMsg(E);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      if (tv.Nodes.Count > 0)
      {
        tv.SelectedNode = tv.Nodes[0];
        tv.SelectedNode.Expand();
      }
      tv.EndUpdate();
    }

    private void AddSubDepart(TreeView tv, TreeNode node, bool InitEmp, bool ShowStatus, string otherCoin)
    {
      DataTableReader dr = null;
      TreeNode nod;
      try
      {
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { "102", node.Tag.ToString() }));
        while (dr.Read())
        {
          nod = node.Nodes.Add("[" + dr["DepartID"].ToString() + "]" + dr["DepartName"].ToString());
          nod.Tag = dr["DepartSysID"].ToString();
          if (tv.StateImageList != null) nod.StateImageIndex = 0;
          if (InitEmp) AddSubDepartEmp(tv, nod, ShowStatus, otherCoin);
          AddSubDepart(tv, nod, InitEmp, ShowStatus, otherCoin);
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
      if (InitEmp)
        node.Collapse();
      else
        node.Expand();
    }

    private void AddSubDepartEmp(TreeView tv, TreeNode node, bool ShowStatus, string otherCoin)
    {
      DataTableReader dr = null;
      TreeNode nod;
      string s = "";
      string OtherCardNo = "";
      try
      {
        if (IsAllowanceDownSelect)
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004006, new string[] { "101", node.Tag.ToString(), 
            OprtInfo.DepartPower, otherCoin }));
        else
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001002, new string[] { "8", node.Tag.ToString(), 
            OprtInfo.DepartPower, otherCoin }));
        while (dr.Read())
        {
          s = dr["CardSectorNo"].ToString();
          OtherCardNo = dr["OtherCardNo"].ToString();
          if (s != "") s = "  " + s;
          if (OtherCardNo != "") s = s + "[" + OtherCardNo + "]";
          s = "[" + dr["EmpNo"].ToString() + "]" + dr["EmpName"].ToString() + s;
          if (ShowStatus) s = s + "  " + dr["CardStatusName"].ToString();
          nod = node.Nodes.Add(s);
          nod.Tag = "1" + dr["EmpSysID"].ToString();
          nod.ImageIndex = 1;
          nod.SelectedImageIndex = 1;
          if (tv.StateImageList != null) nod.StateImageIndex = 0;
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
      node.Collapse();
    }

    protected void InitAddressTreeView(TreeView tv)
    {
      if (tv.StateImageList == null)
      {
        if (tv.GetType().GetEvent("AfterCheck") == null)
        {
          tv.AfterCheck += TreeViewAfterCheck;
          tv.CheckBoxes = true;
        }
      }
      else
      {
        tv.KeyUp += TreeViewKeyUp;
        tv.NodeMouseClick += TreeViewNodeMouseClick;
      }
      tv.Nodes.Clear();
      DataTableReader dr = null;
      TreeNode nodeDepart;
      TreeNode node;
      nodeDepart = tv.Nodes.Add(SystemInfo.CommanyName);
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004001, new string[] { "101" }));
        while (dr.Read())
        {
          node = nodeDepart.Nodes.Add("[" + dr["AddressNO"].ToString() + "]" + dr["AddressName"].ToString());
          node.Tag = dr["GUID"].ToString();
          if (tv.StateImageList != null) node.StateImageIndex = 0;
          AddSubAddress(tv, node);
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
      if (tv.Nodes.Count > 0)
      {
        tv.SelectedNode = tv.Nodes[0];
        tv.SelectedNode.Expand();
      }
    }

    private void AddSubAddress(TreeView tv, TreeNode node)
    {
      DataTableReader dr = null;
      TreeNode nod;
      try
      {
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004001, new string[] { "102", node.Tag.ToString() }));
        while (dr.Read())
        {
          nod = node.Nodes.Add("[" + dr["AddressNO"].ToString() + "]" + dr["AddressName"].ToString());
          nod.Tag = dr["GUID"].ToString();
          if (tv.StateImageList != null) nod.StateImageIndex = 0;
          AddSubAddress(tv, nod);
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
      node.Expand();
    }

    private void SetTreeNodeImage(TreeNode node, int imageIndex)
    {
      for (int i = 0; i < node.Nodes.Count; i++)
      {
        node.Nodes[i].ImageIndex = imageIndex;
        node.Nodes[i].SelectedImageIndex = imageIndex;
        SetTreeNodeImage(node.Nodes[i], imageIndex);
      }
    }

    protected void SetTreeViewImage(TreeView tv, int imageIndex)
    {
      for (int i = 0; i < tv.Nodes.Count; i++)
      {
        tv.Nodes[i].ImageIndex = imageIndex;
        tv.Nodes[i].SelectedImageIndex = imageIndex;
        SetTreeNodeImage(tv.Nodes[i], imageIndex);
      }
    }

    private void SetTreeNodeChecked(TreeNode node, bool isChecked)
    {
      for (int i = 0; i < node.Nodes.Count; i++)
      {
        node.Nodes[i].Checked = isChecked;
        SetTreeNodeChecked(node.Nodes[i], isChecked);
      }
    }

    protected void SetTreeViewChecked(TreeView tv, bool isChecked)
    {
      for (int i = 0; i < tv.Nodes.Count; i++)
      {
        tv.Nodes[i].Checked = isChecked;
        SetTreeNodeChecked(tv.Nodes[i], isChecked);
      }
    }

    private void SetTreeViewStateImageIndex(TreeNode node, bool isChecked)
    {
      for (int i = 0; i < node.Nodes.Count; i++)
      {
        node.Nodes[i].StateImageIndex = isChecked ? 1 : 0;
        SetTreeViewStateImageIndex(node.Nodes[i], isChecked);
      }
    }

    protected void SetTreeViewStateImageIndex(TreeView tv, bool isChecked)
    {
      for (int i = 0; i < tv.Nodes.Count; i++)
      {
        tv.Nodes[i].StateImageIndex = isChecked ? 1 : 0;
        SetTreeViewStateImageIndex(tv.Nodes[i], isChecked);
      }
    }

    protected void SelectTreeNode(TreeNode node)
    {
      for (int i = 0; i < node.Nodes.Count; i++)
      {
        node.Nodes[i].Checked = node.Checked;
        SelectTreeNode(node.Nodes[i]);
      }
    }

    private void ToggleCheckStateChildren(TreeNode node)
    {
      TreeNode nod;
      for (int i = 0; i < node.Nodes.Count; i++)
      {
        nod = node.Nodes[i];
        nod.StateImageIndex = node.StateImageIndex;
        if (nod.Nodes.Count > 0) ToggleCheckStateChildren(nod);
      }
    }

    private void ToggleCheckStateParent(TreeNode node)
    {
      int SelecCount = 0;
      int SelectCount2 = 0;
      TreeNode nod = node.Parent;
      if (nod == null) return;
      for (int i = 0; i < nod.Nodes.Count; i++)
      {
        if (nod.Nodes[i].StateImageIndex == 1) SelecCount++;
        if (nod.Nodes[i].StateImageIndex == 2) SelectCount2++;
      }
      if (nod.Nodes.Count == SelecCount)
        nod.StateImageIndex = 1;
      else if (SelectCount2 != 0)
        nod.StateImageIndex = 2;
      else if (SelecCount == 0)
        nod.StateImageIndex = 0;
      else
        nod.StateImageIndex = 2;
      ToggleCheckStateParent(nod);
    }

    protected virtual void ToggleCheckStateAll(TreeNode node)
    {
      ToggleCheckStateChildren(node);
      ToggleCheckStateParent(node);
    }

    protected void ToggleCheckState(TreeNode node)
    {
      if (node.StateImageIndex == 1)
        node.StateImageIndex = 0;
      else
        node.StateImageIndex = 1;
      if (IsToggleCheckStateAll) ToggleCheckStateAll(node);
    }

    protected void TreeViewAfterCheck(object sender, TreeViewEventArgs e)
    {
      SelectTreeNode(e.Node);
    }

    protected void TreeViewKeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Space && sender is TreeView)
      {
        TreeNode node = ((TreeView)sender).SelectedNode;
        if (node != null) ToggleCheckState(node);
      }
    }

    protected void TreeViewNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
      if (e.Button == MouseButtons.Left && sender is TreeView)
      {
        Rectangle rect = new Rectangle(e.Node.Bounds.X, e.Node.Bounds.Y, e.Node.Bounds.Width, e.Node.Bounds.Height);
        if (e.X <= rect.X && e.X > rect.X - 15)
        {
          ToggleCheckState(e.Node);
        }
      }
    }

    protected bool GetCardTypeList()
    {
      cardTypeList.Clear();
      DataTableReader dr = null;
      TCardType cardType;
      try
      {
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "203" }));
        while (dr.Read())
        {
          cardType = new TCardType(dr["CardTypeSysID"].ToString(), Convert.ToInt32(dr["CardTypeID"]),
            dr["CardTypeName"].ToString());
          cardTypeList.Add(cardType);
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
      return cardTypeList.Count > 0;
    }

    protected void RefreshOrderControl(Control owner)
    {
      CheckBox chk;
      ComboBox cbb;
      for (int i = 0; i <= 3; i++)
      {
        for (int j = 0; j <= 3; j++)
        {
          chk = (CheckBox)owner.Controls[string.Format("chkOrder{0}{1}", i + 1, j + 1)];
          chk.Enabled = true;
        }
      }
      bool[] HasA = new bool[4];
      bool[] HasB = new bool[4];
      for (int i = 0; i <= 3; i++)
      {
        cbb = (ComboBox)owner.Controls[string.Format("cbbOrder{0}", i + 1)];
        if (cbb.SelectedIndex == 0)
        {
          for (int j = 0; j <= 3; j++)
          {
            chk = (CheckBox)owner.Controls[string.Format("chkOrder{0}{1}", i + 1, j + 1)];
            if (HasA[j])
            {
              chk.Enabled = false;
              chk.Checked = false;
            }
            else if (chk.Checked)
            {
              HasA[j] = true;
            }
          }
        }
        else if (cbb.SelectedIndex == 1)
        {
          for (int j = 0; j <= 3; j++)
          {
            chk = (CheckBox)owner.Controls[string.Format("chkOrder{0}{1}", i + 1, j + 1)];
            if (HasB[j])
            {
              chk.Enabled = false;
              chk.Checked = false;
            }
            else if (chk.Checked)
            {
              HasB[j] = true;
            }
          }
        }
      }
    }

    public frmBaseForm()
    {
      InitializeComponent();
    }

    private void frmBaseForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      FreeForm();
    }

    private void frmBaseForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      //
    }

    private void frmBaseForm_Load(object sender, EventArgs e)
    {
      InitForm();
    }

    protected void TextBoxCurrency_Enter(object sender, EventArgs e)
    {
      bool IsText = (sender is TextBox);
      string v = "";
      if (IsText)
      {
        v = ((TextBox)sender).Text;
        ((TextBox)sender).ImeMode = ImeMode.Disable;
      }
      else
        v = ((ToolStripTextBox)sender).Text;
      if (v == "") v = SystemInfo.CurrencySymbol + "0.00";
      try
      {
        if (v.Substring(0, SystemInfo.CurrencySymbol.Length) == SystemInfo.CurrencySymbol)
        {
          v = v.Substring(SystemInfo.CurrencySymbol.Length);
        }
        else if (v.Substring(1, SystemInfo.CurrencySymbol.Length) == SystemInfo.CurrencySymbol && v.Substring(0, 1) == "-")
        {
          v = "-" + v.Substring(SystemInfo.CurrencySymbol.Length + 1);
        }
      }
      catch
      {
      }
      double d = 0;
      double.TryParse(v, out d);
      if (IsText)
      {
        ((TextBox)sender).Text = d.ToString("0.00");
        ((TextBox)sender).SelectAll();
      }
      else
      {
        ((ToolStripTextBox)sender).Text = d.ToString("0.00");
        ((ToolStripTextBox)sender).SelectAll();
      }
    }

    protected void TextBoxCurrency_Leave(object sender, EventArgs e)
    {
      bool IsText = (sender is TextBox);
      string v = "";
      if (IsText)
        v = ((TextBox)sender).Text;
      else
        v = ((ToolStripTextBox)sender).Text;
      if (v == "") v = SystemInfo.CurrencySymbol + "0.00";
      if (IsText)
        ((TextBox)sender).Text = CurrencyToString(v);
      else
        ((ToolStripTextBox)sender).Text = CurrencyToString(v);
    }

    protected string CurrencyToString(string src)
    {
      string ret = src;
      if (src.Length > SystemInfo.CurrencySymbol.Length)
      {
        if (ret.Substring(0, SystemInfo.CurrencySymbol.Length) == SystemInfo.CurrencySymbol)
        {
          ret = ret.Substring(SystemInfo.CurrencySymbol.Length);
        }
        else if (ret.Substring(1, SystemInfo.CurrencySymbol.Length) == SystemInfo.CurrencySymbol && ret.Substring(0, 1) == "-")
        {
          ret = "-" + ret.Substring(SystemInfo.CurrencySymbol.Length + 1);
        }
        if (!Pub.IsNumeric(ret)) ret = "0.00";
      }
      else if (Pub.IsNumeric(src))
        ret = src;
      else
        ret = "0.00";
      double d = 0;
      double.TryParse(ret, out d);
      ret = d.ToString(SystemInfo.CurrencySymbol + "0.00");
      return ret;
    }

    protected string CurrencyToStringEx(string src)
    {
      string ret = src;
      if (src.Length > SystemInfo.CurrencySymbol.Length)
      {
        if (ret.Substring(0, SystemInfo.CurrencySymbol.Length) == SystemInfo.CurrencySymbol)
        {
          ret = ret.Substring(SystemInfo.CurrencySymbol.Length);
        }
        else if (ret.Substring(1, SystemInfo.CurrencySymbol.Length) == SystemInfo.CurrencySymbol && ret.Substring(0, 1) == "-")
        {
          ret = "-" + ret.Substring(SystemInfo.CurrencySymbol.Length + 1);
        }
        if (!Pub.IsNumeric(ret)) ret = "0.00";
      }
      else if (Pub.IsNumeric(src))
        ret = src;
      else
        ret = "0.00";
      return ret;
    }

    protected void ShowErrorEnterCorrect(string text)
    {
      string errEnter = Pub.GetResText(formCode, "ErrorEnterCorrect", "");
      Pub.MessageBoxShow(string.Format(errEnter, text));
    }

    protected void ShowErrorSelectCorrect(string text)
    {
      string errSelect = Pub.GetResText(formCode, "ErrorSelectCorrect", "");
      Pub.MessageBoxShow(string.Format(errSelect, text));
    }

    protected void ShowErrorCannotRepeated(string text)
    {
      string errRepeated = Pub.GetResText(formCode, "ErrorCannotRepeated", "");
      Pub.MessageBoxShow(string.Format(errRepeated, text));
    }

    protected void CreateCardGridView(DataGridView grid)
    {
      grid.Columns.Clear();
      if (IsFinger)
        AddColumn(grid, 0, "CardFingerNo", false, true, 1, 80);
      else if (SystemInfo.HasFaCard)
      {
        AddColumn(grid, 0, "CardSectorNo", false, true, 1, 80);
        AddColumn(grid, 0, "CardPhysicsNo10", true, false, 1, 0);
      }
      else
      {
        AddColumn(grid, 0, "CardSectorNo", true, true, 1, 0);
        AddColumn(grid, 0, "CardPhysicsNo10", false, false, 1, 80);
      }
      AddColumn(grid, 0, "OtherCardNo", false, true, 0, 70);
      AddColumn(grid, 0, "EmpNo", false, true, 0, 70);
      AddColumn(grid, 0, "EmpName", false, true, 0, 80);
      AddColumn(grid, 0, "DepartName", false, true, 0, 80);
      if (!IsFinger)
      {
        AddColumn(grid, 0, "CardTypeName", false, true, 0, 80);
        AddColumn(grid, 0, "CardStartDate", true, false, 1, 0);
        AddColumn(grid, 0, "CardEndDate", true, false, 1, 0);
        AddColumn(grid, 0, "CardValudDate", false, true, 1, 160);
      }
      AddColumn(grid, 0, "EmpSysID", true, false, 1, 0);
      AddColumn(grid, 0, "DepartID", true, false, 1, 0);
    }

    protected void CreateDoorGridView(DataGridView grid, bool ShowCheck)
    {
      grid.Columns.Clear();
      if (ShowCheck) AddColumn(grid, 1, "SelectCheck", false, false, 1, 60);
      AddColumn(grid, 0, "MacSN", false, true, 1, 80);
      AddColumn(grid, 0, "MacDoorID", false, false, 1, 0);
      AddColumn(grid, 0, "MacDoorName", false, true, 0, 70);
      AddColumn(grid, 0, "MacSysID", true, false, 1, 0);
      AddColumn(grid, 0, "MacDoorSysID", true, false, 1, 0);
    }

    private DataTable QuickSearchNormalCardDataTable(DataGridView grid)
    {
      DataTable rtn = new DataTable();
      if (grid.DataSource == null)
      {
        rtn.Columns.Add("CardSectorNo", typeof(string));
        rtn.Columns.Add("CardPhysicsNo10", typeof(string));
        rtn.Columns.Add("CardFingerNo", typeof(UInt32));
        rtn.Columns.Add("OtherCardNo", typeof(string));
        rtn.Columns.Add("EmpNo", typeof(string));
        rtn.Columns.Add("EmpName", typeof(string));
        rtn.Columns.Add("DepartName", typeof(string));
        rtn.Columns.Add("CardTypeName", typeof(string));
        rtn.Columns.Add("CardStartDate", typeof(DateTime));
        rtn.Columns.Add("CardEndDate", typeof(DateTime));
        rtn.Columns.Add("CardValudDate", typeof(string));
        rtn.Columns.Add("EmpSysID", typeof(string));
        rtn.Columns.Add("DepartID", typeof(string));
      }
      else
        rtn = (DataTable)grid.DataSource;
      return rtn;
    }

    protected void QuickSearchNormalCard(TextBox txt, KeyEventArgs e, DataGridView grid)
    {
      QuickSearchNormalCard(txt, e, grid, 0);
    }

    protected void QuickSearchNormalCard(TextBox txt, KeyEventArgs e, DataGridView grid, int MaxCard)
    {
      QuickSearchNormalCard(txt, e, grid, MaxCard, IsFinger);
    }

    protected void QuickSearchNormalCard(TextBox txt, KeyEventArgs e, DataGridView grid, int MaxCard, bool IsFinger)
    {
      QuickSearchNormalCard(txt, e, grid, MaxCard, IsFinger, false);
    }

    protected void QuickSearchNormalCard(TextBox txt, KeyEventArgs e, DataGridView grid, int MaxCard, bool IsFinger,
      bool IsAccess)
    {
      if (e.KeyCode != Keys.Enter) return;
      DataTable dtGrid = QuickSearchNormalCardDataTable(grid);
      DataTableReader dr = null;
      string sql = "";
      if (IsAccess)
        sql = Pub.GetSQL(DBCode.DB_002001, new string[] { "110", txt.Text.Trim(), OprtInfo.DepartPower });
      else if (IsFinger)
        sql = Pub.GetSQL(DBCode.DB_002001, new string[] { "202", txt.Text.Trim(), OprtInfo.DepartPower });
      else if (SystemInfo.HasFaCard)
      {
        if (HasAbnormal)
          sql = Pub.GetSQL(DBCode.DB_002001, new string[] { "109", txt.Text.Trim(), OprtInfo.DepartPower });
        else
          sql = Pub.GetSQL(DBCode.DB_002001, new string[] { "104", txt.Text.Trim(), OprtInfo.DepartPower });
      }
      else
        sql = Pub.GetSQL(DBCode.DB_002001, new string[] { "201", txt.Text.Trim(), OprtInfo.DepartPower });
      string EmpSysID = "";
      string CompEmpSysID = "";
      bool IsExists = false;
      try
      {
        dr = db.GetDataReader(sql);
        while (dr.Read())
        {
          EmpSysID = dr["EmpSysID"].ToString();
          IsExists = false;
          for (int j = 0; j < dtGrid.Rows.Count; j++)
          {
            CompEmpSysID = dtGrid.Rows[j]["EmpSysID"].ToString();
            if (CompEmpSysID == EmpSysID)
            {
              IsExists = true;
              break;
            }
          }
          if (!IsExists && ((MaxCard == 0) || ((MaxCard > 0) && (dtGrid.Rows.Count < MaxCard))))
          {
            dtGrid.Rows.Add(new object[] { dr["CardSectorNo"], dr["CardPhysicsNo10"], dr["CardFingerNo"].ToString(), 
              dr["OtherCardNo"], dr["EmpNo"], dr["EmpName"], dr["DepartName"], dr["CardTypeName"], dr["CardStartDate"], 
              dr["CardEndDate"], dr["CardValudDate"], dr["EmpSysID"], dr["DepartID"] });
          }
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
      grid.DataSource = dtGrid;
      if (grid.RowCount > 0)
      {
        grid.Rows[grid.RowCount - 1].Selected = true;
        grid.CurrentCell = grid.Rows[grid.RowCount - 1].Cells[3];
      }
    }

    protected void QuickSearchNormalCardByEmpSysID(string EmpSysID, DataGridView grid, int MaxCard)
    {
      QuickSearchNormalCardByEmpSysID(EmpSysID, grid, MaxCard, IsFinger);
    }

    protected void QuickSearchNormalCardByEmpSysID(string EmpSysID, DataGridView grid, int MaxCard, bool IsFinger)
    {
      DataTableReader dr = null;
      DataTable dtGrid = QuickSearchNormalCardDataTable(grid);
      string CardNo = "";
      string CompCardNo = "";
      bool IsExists = false;
      string sql = "";
      if (IsFinger)
        sql = Pub.GetSQL(DBCode.DB_001003, new string[] { "608", EmpSysID });
      else if (SystemInfo.HasFaCard)
        sql = Pub.GetSQL(DBCode.DB_001003, new string[] { "230", EmpSysID });
      else
        sql = Pub.GetSQL(DBCode.DB_001003, new string[] { "607", EmpSysID });
      try
      {
        dr = db.GetDataReader(sql);
        while (dr.Read())
        {
          if (IsFinger)
            CardNo = dr["CardFingerNo"].ToString();
          else if (SystemInfo.HasFaCard)
            CardNo = dr["CardSectorNo"].ToString();
          else
            CardNo = dr["CardPhysicsNo10"].ToString();
          IsExists = false;
          for (int j = 0; j < dtGrid.Rows.Count; j++)
          {
            if (IsFinger)
              CompCardNo = dtGrid.Rows[j]["CardFingerNo"].ToString();
            else if (SystemInfo.HasFaCard)
              CompCardNo = dtGrid.Rows[j]["CardSectorNo"].ToString();
            else
              CompCardNo = dtGrid.Rows[j]["CardPhysicsNo10"].ToString();
            if (CompCardNo == CardNo)
            {
              IsExists = true;
              break;
            }
          }
          if (!IsExists && ((MaxCard == 0) || ((MaxCard > 0) && (dtGrid.Rows.Count < MaxCard))))
          {
            dtGrid.Rows.Add(new object[] { dr["CardSectorNo"].ToString(), dr["CardPhysicsNo10"], dr["CardFingerNo"].ToString(), 
              dr["OtherCardNo"], dr["EmpNo"], dr["EmpName"], dr["DepartName"], dr["CardTypeName"], dr["CardStartDate"],
              dr["CardEndDate"], dr["CardValudDate"], dr["EmpSysID"], dr["DepartID"] });
          }
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
      grid.DataSource = dtGrid;
      if (grid.RowCount > 0)
      {
        grid.Rows[grid.RowCount - 1].Selected = true;
        grid.CurrentCell = grid.Rows[grid.RowCount - 1].Cells[3];
      }
    }

    protected void QuickSearchNormalCard(string Title, DataGridView grid)
    {
      QuickSearchNormalCard(Title, grid, 0);
    }

    protected void QuickSearchNormalCard(string Title, DataGridView grid, int MaxCard)
    {
      QuickSearchNormalCard(Title, grid, MaxCard, IsFinger);
    }
    protected void QuickSearchNormalCard(string Title, DataGridView grid, int MaxCard, bool IsFinger)
    {
      QuickSearchNormalCard(Title, grid, MaxCard, IsFinger, false);
    }

    protected void QuickSearchNormalCard(string Title, DataGridView grid, int MaxCard, bool IsFinger, bool IsAccess)
    {
      string OtherCoin = "";
      if (IsAccess)
        OtherCoin = Pub.GetSQL(DBCode.DB_001003, new string[] { "239" });
      else if (IsFinger)
        OtherCoin = Pub.GetSQL(DBCode.DB_001003, new string[] { "238" });
      else if (SystemInfo.HasFaCard)
      {
        if (HasAbnormal)
          OtherCoin = Pub.GetSQL(DBCode.DB_001003, new string[] { "237" });
        else
          OtherCoin = Pub.GetSQL(DBCode.DB_001003, new string[] { "218" });
      }
      else
        OtherCoin = Pub.GetSQL(DBCode.DB_001003, new string[] { "606" });
      DataTable dt = new DataTable();
      if (!Pub.ShowSelectEmpList(Title, OtherCoin, ref dt)) return;
      DataTable dtGrid = QuickSearchNormalCardDataTable(grid);
      string EmpSysID = "";
      string CompEmpSysID = "";
      bool IsExists = false;
      DataRow dr = null;
      for (int i = 0; i < dt.Rows.Count; i++)
      {
        dr = dt.Rows[i];
        EmpSysID = dr["EmpSysID"].ToString();
        IsExists = false;
        for (int j = 0; j < dtGrid.Rows.Count; j++)
        {
          CompEmpSysID = dtGrid.Rows[j]["EmpSysID"].ToString();
          if (CompEmpSysID == EmpSysID)
          {
            IsExists = true;
            break;
          }
        }
        if (!IsExists && ((MaxCard == 0) || ((MaxCard > 0) && (dtGrid.Rows.Count < MaxCard))))
        {
          dtGrid.Rows.Add(new object[] { dr["CardSectorNo"], dr["CardPhysicsNo10"], dr["CardFingerNo"].ToString(), 
            dr["OtherCardNo"], dr["EmpNo"], dr["EmpName"], dr["DepartName"], dr["CardTypeName"], dr["CardStartDate"], 
            dr["CardEndDate"], dr["CardValudDate"], dr["EmpSysID"], dr["DepartID"] });
        }
      }
      grid.DataSource = dtGrid;
      if (grid.RowCount > 0)
      {
        grid.Rows[grid.RowCount - 1].Selected = true;
        grid.CurrentCell = grid.Rows[grid.RowCount - 1].Cells[3];
      }
    }

    protected void QuickSearchNormalEmp(TextBox txt, KeyEventArgs e, DataGridView grid)
    {
      QuickSearchNormalEmp("", txt, e, grid);
    }

    protected void QuickSearchNormalEmp(string OtherCoin, TextBox txt, KeyEventArgs e, DataGridView grid)
    {
      if (e.KeyCode != Keys.Enter) return;
      DataTable dtGrid = QuickSearchNormalCardDataTable(grid);
      DataTableReader dr = null;
      string EmpNo = "";
      bool IsExists = false;
      try
      {
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002001, new string[] { "108", txt.Text.Trim(), OtherCoin, OprtInfo.DepartPower }));
        while (dr.Read())
        {
          EmpNo = dr["EmpNo"].ToString();
          IsExists = false;
          for (int j = 0; j < dtGrid.Rows.Count; j++)
          {
            if (dtGrid.Rows[j]["EmpNo"].ToString() == EmpNo)
            {
              IsExists = true;
              break;
            }
          }
          if (!IsExists)
          {
            dtGrid.Rows.Add(new object[] { dr["CardSectorNo"], dr["CardPhysicsNo10"], dr["CardFingerNo"].ToString(), 
              dr["OtherCardNo"], EmpNo, dr["EmpName"], dr["DepartName"], dr["CardTypeName"], dr["CardStartDate"], 
              dr["CardEndDate"], dr["CardValudDate"], dr["EmpSysID"], dr["DepartID"] });
          }
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
      grid.DataSource = dtGrid;
      if (grid.RowCount > 0)
      {
        grid.Rows[grid.RowCount - 1].Selected = true;
        grid.CurrentCell = grid.Rows[grid.RowCount - 1].Cells[3];
      }
    }

    protected void QuickSearchNormalEmp(string Title, DataGridView grid)
    {
      QuickSearchNormalEmp(Title, "", grid); 
    }

    protected void QuickSearchNormalEmp(string Title, string OtherCoin, DataGridView grid)
    {
      DataTable dt = new DataTable();
      if (!Pub.ShowSelectEmpList(Title, OtherCoin, ref dt)) return;
      DataTable dtGrid = QuickSearchNormalCardDataTable(grid);
      string EmpNo = "";
      bool IsExists = false;
      DataRow dr = null;
      for (int i = 0; i < dt.Rows.Count; i++)
      {
        dr = dt.Rows[i];
        EmpNo = dr["EmpNo"].ToString();
        IsExists = false;
        for (int j = 0; j < dtGrid.Rows.Count; j++)
        {
          if (dtGrid.Rows[j]["EmpNo"].ToString() == EmpNo)
          {
            IsExists = true;
            break;
          }
        }
        if (!IsExists)
        {
          dtGrid.Rows.Add(new object[] { dr["CardSectorNo"], dr["CardPhysicsNo10"], dr["CardFingerNo"].ToString(), 
            dr["OtherCardNo"], EmpNo, dr["EmpName"], dr["DepartName"], dr["CardTypeName"], dr["CardStartDate"], 
            dr["CardEndDate"], dr["CardValudDate"], dr["EmpSysID"], dr["DepartID"] });
        }
      }
      grid.DataSource = dtGrid;
      if (grid.RowCount > 0)
      {
        grid.Rows[grid.RowCount - 1].Selected = true;
        grid.CurrentCell = grid.Rows[grid.RowCount - 1].Cells[3];
      }
    }

    protected void SetColCurrencyFormat(DataGridView grid, string DataPropertyName)
    {
      for (int i = 0; i < grid.ColumnCount; i++)
      {
        if (grid.Columns[i].DataPropertyName == DataPropertyName)
        {
          grid.Columns[i].DefaultCellStyle.Format = SystemInfo.CurrencySymbol + "0.00";
          break;
        }
      }
    }

    protected void SetColCurrencyFormatByColName(DataGridView grid, string ColName)
    {
      for (int i = 0; i < grid.ColumnCount; i++)
      {
        if (grid.Columns[i].Name == ColName)
        {
          grid.Columns[i].DefaultCellStyle.Format = SystemInfo.CurrencySymbol + "0.00";
          break;
        }
      }
    }

    protected bool CheckOrderInfo(Control owner)
    {
      MaskedTextBox txt1;
      MaskedTextBox txt2;
      MaskedTextBox txt3;
      MaskedTextBox txt4;
      CheckBox chk;
      ComboBox cbb;
      bool[] HasA = new bool[4];
      bool[] HasB = new bool[4];
      for (int i = 0; i <= 3; i++)
      {
        txt1 = (MaskedTextBox)owner.Controls[string.Format("txtOrder{0}1", i + 1)];
        txt2 = (MaskedTextBox)owner.Controls[string.Format("txtOrder{0}2", i + 1)];
        if (((txt1.Text == "00:00") && (txt1.Text != "00:00")) || ((txt1.Text != "00:00") && (txt1.Text == "00:00")))
        {
          Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorOrderTime", ""));
          return false;
        }
        if ((txt1.Text != "00:00") || (txt2.Text != "00:00"))
        {
          if (i < 3)
          {
            if (txt2.Text.CompareTo(txt1.Text) <= 0)
            {
              Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorOrderTime", ""));
              return false;
            }
          }
          else if (txt2.Text != "00:00" && txt2.Text.CompareTo(txt1.Text) <= 0)
          {
            Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorOrderTime", ""));
            return false;
          }
          if (i > 0)
          {
            txt3 = (MaskedTextBox)owner.Controls[string.Format("txtOrder{0}1", i)];
            txt4 = (MaskedTextBox)owner.Controls[string.Format("txtOrder{0}2", i)];
            if ((txt3.Text != "00:00") || (txt4.Text != "00:00"))
            {
              if (txt1.Text.CompareTo(txt4.Text) < 0)
              {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorOrderTimeOver", ""));
                return false;
              }
            }
          }
          bool HasMeal = false;
          for (int j = 0; j <= 3; j++)
          {
            chk = (CheckBox)owner.Controls[string.Format("chkOrder{0}{1}", i + 1, j + 1)];
            HasMeal = chk.Checked;
            if (HasMeal) break;
          }
          if (!HasMeal)
          {
            Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorOrderMealEmpty", ""));
            return false;
          }
          cbb = (ComboBox)owner.Controls[string.Format("cbbOrder{0}", i + 1)];
          if (cbb.SelectedIndex == 0)
          {
            for (int j = 0; j <= 3; j++)
            {
              chk = (CheckBox)owner.Controls[string.Format("chkOrder{0}{1}", i + 1, j + 1)];
              if (HasA[j] && chk.Checked)
              {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorOrderMealRepeat", ""));
                return false;
              }
              else if (chk.Checked)
              {
                HasA[j] = true;
              }
            }
          }
          else if (cbb.SelectedIndex == 1)
          {
            for (int j = 0; j <= 3; j++)
            {
              chk = (CheckBox)owner.Controls[string.Format("chkOrder{0}{1}", i + 1, j + 1)];
              if (HasB[j] && chk.Checked)
              {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorOrderMealRepeat", ""));
                return false;
              }
              else if (chk.Checked)
              {
                HasB[j] = true;
              }
            }
          }
        }
      }
      return true;
    }

    protected void PrintCardBillByEmpSysID(string Title, double Amount, double ReceivablesAmount, double CardBalance,
      string AmountTitle, string EmpSysID)
    {
      PrintCardBill(new string[] { Title }, new double[] { Amount }, new double[] { ReceivablesAmount },
        new double[] { CardBalance }, new string[] { AmountTitle }, EmpSysID, true);
    }

    protected void PrintCardBill(string Title, double Amount, double ReceivablesAmount, double CardBalance,
      string AmountTitle, string CardNo)
    {
      PrintCardBill(new string[] { Title }, new double[] { Amount }, new double[] { ReceivablesAmount },
        new double[] { CardBalance }, new string[] { AmountTitle }, CardNo, false);
    }

    protected void PrintCardBill(string[] Title, double[] Amount, double[] ReceivablesAmount, double[] CardBalance,
      string[] AmountTitle, string CardNo)
    {
      PrintCardBill(Title, Amount, ReceivablesAmount, CardBalance, AmountTitle, CardNo, false);
    }

    protected void PrintCardBill(string[] Title, double[] Amount, double[] ReceivablesAmount, double[] CardBalance,
      string[] AmountTitle, string CardNo, bool IsByEmpSysID)
    {
      string sql = "";
      string Add = "";
      string sqlCode = IsByEmpSysID ? "702" : "701";
      for (int i = 0; i < Title.Length; i++)
      {
        Add = i < Title.Length - 1 ? "1" : "0";
        sql = sql + Pub.GetSQL(DBCode.DB_000001, new string[] { sqlCode, Title[i], AmountTitle[i], 
          CardBalance[i].ToString("0.00"), Amount[i].ToString("0.00"), ReceivablesAmount[i].ToString("0.00"), 
          CardNo,  Add});
      }
      GridppReport Report = new GridppReport();
      string ReportFile = SystemInfo.ReportPath + "SFCardBill.grf";
      string cap = "";
      if ((ReportFile != "") && File.Exists(ReportFile))
      {
        try
        {
          Report.Register(SystemInfo.ReportRegister);
          Report.LoadFromFile(ReportFile);
          Report.DetailGrid.Recordset.ConnectionString = SystemInfo.ConnStrReport;
          Report.DetailGrid.Recordset.QuerySQL = sql;
          for (int i = 1; i <= Report.DetailGrid.Columns[1].ContentCell.Controls.Count; i++)
          {
            switch (Report.DetailGrid.Columns[1].ContentCell.Controls[i].Name.ToLower())
            {
              case "commanyname":
                cap = RegisterInfo.RegUser == "" ? SystemInfo.CommanyName : RegisterInfo.RegUser;
                Report.DetailGrid.Columns[1].ContentCell.Controls[i].AsStaticBox.Text = cap;
                break;
              case "staticboxempno":
                cap = Pub.GetResText(formCode, "EmpNo", "");
                Report.DetailGrid.Columns[1].ContentCell.Controls[i].AsStaticBox.Text = cap;
                break;
              case "staticboxempname":
                cap = Pub.GetResText(formCode, "EmpName", "");
                Report.DetailGrid.Columns[1].ContentCell.Controls[i].AsStaticBox.Text = cap;
                break;
              case "staticboxcardno":
                cap = Pub.GetResText(formCode, "CardSectorNo", "");
                Report.DetailGrid.Columns[1].ContentCell.Controls[i].AsStaticBox.Text = cap;
                break;
              case "staticboxcardtype":
                cap = Pub.GetResText(formCode, "CardType", "");
                Report.DetailGrid.Columns[1].ContentCell.Controls[i].AsStaticBox.Text = cap;
                break;
              case "staticboxcardbalance":
                cap = Pub.GetResText(formCode, "SFCardBalance", "");
                Report.DetailGrid.Columns[1].ContentCell.Controls[i].AsStaticBox.Text = cap;
                break;
            }
          }
          if (SystemInfo.ini.ReadIni("Public", "PrintPreview", false))
          {
            frmPubPreview frm = new frmPubPreview(Report, this.Text, ReportFile, "", "",
              SystemInfo.ini.ReadIni("Public", "DesignReport", false));
            frm.ShowDialog();
          }
          else
          {
            Report.Print(SystemInfo.ini.ReadIni("Public", "PrintDialog", false));
          }
        }
        catch (Exception E)
        {
          Pub.ShowErrorMsg(E);
        }
      }
    }

    protected bool GetSFAllowance(string EmpSysID, DateTime dFlag, double AllowanceAmount, int way,
      ref List<string> sql)
    {
      bool AllowCount = false;
      return GetSFAllowance(EmpSysID, dFlag, AllowanceAmount, way, ref sql, ref AllowCount);
    }

    protected bool GetSFAllowance(string EmpSysID, DateTime dFlag, double AllowanceAmount, int way,
      ref List<string> sql, ref bool AllowCount)
    {
      bool ret = false;
      DataTableReader dr = null;
      int StatusDB = 0;
      DateTime FlagDB = new DateTime();
      bool IsDelete = false;
      double AllowanceAmountUp = 0;
      double AllowanceAmountSum = 0;
      double ExistsAllowance = 0;
      int WayUp = 0;
      string CardID = "";
      string EmpNo = "";
      string EmpName = "";
      string msg = "";
      try
      {
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "1", EmpSysID }));
        if (dr.Read())
        {
          CardID = dr["CardSectorNo"].ToString();
          EmpNo = dr["EmpNo"].ToString();
          EmpName = dr["EmpName"].ToString();
          msg = CardID == "" ? "" : Pub.GetResText(formCode, "CardNo", "") + ":" + CardID + "  ";
          msg += EmpNo == "" ? "" : Pub.GetResText(formCode, "EmpNo", "") + ":" + EmpNo + "  ";
          msg += EmpName == "" ? "" : Pub.GetResText(formCode, "EmpName", "") + ":" + EmpName + "  ";
        }
        msg += msg == "" ? "" : "\r\n\r\n";
        msg += Pub.GetResText(formCode, "MsgBTFlagSame", "");
        dr.Close();
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004006, new string[] { "8", EmpSysID }));
        if (dr.Read())
        {
          int.TryParse(dr["AllowanceStatus"].ToString(), out StatusDB);
          DateTime.TryParse(dr["AllowanceFlag"].ToString(), out FlagDB);
          if (((StatusDB == 0) && (FlagDB != dFlag)) || (StatusDB == 1))
          {
            sql.Add(Pub.GetSQL(DBCode.DB_004006, new string[] { "9", EmpSysID, FlagDB.ToString(SystemInfo.SQLDateFMT) }));
            sql.Add(Pub.GetSQL(DBCode.DB_004006, new string[] { "10", OprtInfo.OprtSysID, dr["GUID"].ToString() }));
            sql.Add(Pub.GetSQL(DBCode.DB_004006, new string[] { "11", EmpSysID }));
            if (FlagDB != dFlag) IsDelete = true;
          }
          int.TryParse(dr["AllowanceWay"].ToString(), out WayUp);
          if (StatusDB == 0)//未领
          {
            if (FlagDB == dFlag)//相同补贴标志只修改金额
            {
              if ((SystemInfo.CheckSameBT == 1) || (SystemInfo.CheckSameBT == 3))
              {
                double.TryParse(dr["AllowanceAmountUp"].ToString(), out AllowanceAmountUp);
                ExistsAllowance = 0;
                if (SystemInfo.CheckSameBT == 3) double.TryParse(dr["AllowanceAmount"].ToString(), out ExistsAllowance);
                AllowanceAmount += ExistsAllowance;
                if (way == 2)//方式为累加
                  AllowanceAmountSum = AllowanceAmount + AllowanceAmountUp;
                else
                  AllowanceAmountSum = AllowanceAmount;
                sql.Add(Pub.GetSQL(DBCode.DB_004006, new string[] { "12", AllowanceAmount.ToString(), 
                AllowanceAmountUp.ToString(), AllowanceAmountSum.ToString(), way.ToString(), OprtInfo.OprtSysID, EmpSysID }));
              }
              else if (SystemInfo.CheckSameBT == 2)
              {
                Pub.MessageBoxShow(msg);
              }
            }
            else
            {
              double.TryParse(dr["AllowanceAmountSum"].ToString(), out AllowanceAmountUp);
              if (way == 2)//方式为累加
                AllowanceAmountSum = AllowanceAmount + AllowanceAmountUp;
              else
                AllowanceAmountSum = AllowanceAmount;
              sql.Add(Pub.GetSQL(DBCode.DB_004006, new string[] { "13", EmpSysID, dFlag.ToString(SystemInfo.SQLDateFMT), 
                AllowanceAmount.ToString(), AllowanceAmountUp.ToString(), AllowanceAmountSum.ToString(), 
                way.ToString(), OprtInfo.OprtSysID, WayUp.ToString() }));
            }
            AllowCount = true;
          }
          else if (IsDelete)
          {
            AllowanceAmountUp = 0;
            AllowanceAmountSum = AllowanceAmount;
            sql.Add(Pub.GetSQL(DBCode.DB_004006, new string[] { "13", EmpSysID, dFlag.ToString(SystemInfo.SQLDateFMT), 
              AllowanceAmount.ToString(), AllowanceAmountUp.ToString(), AllowanceAmountSum.ToString(), 
              way.ToString(), OprtInfo.OprtSysID, WayUp.ToString() }));
            AllowCount = true;
          }
        }
        else
        {
          AllowanceAmountUp = 0;
          AllowanceAmountSum = AllowanceAmount;
          sql.Add(Pub.GetSQL(DBCode.DB_004006, new string[] { "13", EmpSysID, dFlag.ToString(SystemInfo.SQLDateFMT), 
            AllowanceAmount.ToString(), AllowanceAmountUp.ToString(), AllowanceAmountSum.ToString(), 
            way.ToString(), OprtInfo.OprtSysID, "255" }));
          AllowCount = true;
        }
        ret = true;
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E, sql);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      return ret;
    }

    private void TextBox_GotFocus(object sender, EventArgs e)
    {
      if (sender is TextBox)
      {
        TextBox txt = (TextBox)sender;
        txt.SelectionStart = 0;
        txt.SelectionLength = txt.Text.Length;
        txt.Select();
        txt.SelectAll();
      }
      else if (sender is MaskedTextBox)
      {
        MaskedTextBox mtxt = (MaskedTextBox)sender;
        mtxt.SelectionStart = 0;
        mtxt.SelectionLength = mtxt.Text.Length;
        mtxt.Select();
        mtxt.SelectAll();
      }
      else if (sender is NumericUpDown)
      {
        NumericUpDown num = (NumericUpDown)sender;
        num.Select(0, num.Value.ToString().Length);
      }
      else if (sender is RichTextBox)
      {
        RichTextBox rtxt = (RichTextBox)sender;
        rtxt.SelectionStart = 0;
        rtxt.SelectionLength = rtxt.Text.Length;
        rtxt.Select();
        rtxt.SelectAll();
      }
      else if (sender is ToolStripTextBox)
      {
        ToolStripTextBox ttxt = (ToolStripTextBox)sender;
        ttxt.SelectionStart = 0;
        ttxt.SelectionLength = ttxt.Text.Length;
        ttxt.Select();
        ttxt.SelectAll();
      }
    }

    private void ComboBox_OnDropDown(object sender, EventArgs e)
    {
      AdjustComboBoxDropDownListWidth((ComboBox)sender);
    }

    private void AdjustComboBoxDropDownListWidth(ComboBox cbb)
    {
      Graphics g = null;
      Font font = null;
      try
      {
        int width = cbb.Width;
        g = cbb.CreateGraphics();
        font = cbb.Font;
        int vertScrollBarWidth = (cbb.Items.Count > cbb.MaxDropDownItems) ? SystemInformation.VerticalScrollBarWidth : 0;
        int newWidth;
        foreach (object s in cbb.Items)
        {
          if (s != null)
          {
            newWidth = (int)g.MeasureString(s.ToString().Trim(), font).Width + vertScrollBarWidth;
            if (width < newWidth) width = newWidth;
          }
        }
        cbb.DropDownWidth = width;
      }
      catch
      {
      }
      finally
      {
        if (g != null) g.Dispose();
      }
    }

    private void frmBaseForm_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == 13)
      {
        SendKeys.Send("{TAB}");
      }
    }

    private Bitmap SizeImage(Image img, int width, int height)
    {
      double whX = ((double)width) / ((double)height);
      int w = width;
      int h = Convert.ToInt32(w * whX);
      Bitmap bmp = new Bitmap(w, h);
      int srcX = 0;
      int srcY = 0;
      int srcW = img.Width;
      int srcH = img.Height;
      Graphics g = Graphics.FromImage(bmp);
      g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
      Color c = Color.FromArgb(new Bitmap(img).GetPixel(1, 1).ToArgb());
      g.Clear(c);
      if (srcW * whX != srcH)
      {
        if (srcW * whX >= srcH)
        {
          srcH = Convert.ToInt32(srcW * whX);
          srcY = -(srcH - img.Height) / 2;
        }
        else
        {
          srcW = Convert.ToInt32(srcH / whX);
          srcX = -(srcW - img.Width) / 2;
        }
      }
      g.DrawImage(img, new Rectangle(0, 0, w, h), new Rectangle(srcX, srcY, srcW, srcH), GraphicsUnit.Pixel);
      g.Dispose();
      return bmp;
    }

    protected Bitmap CustomSizeImage(Image img)
    {
      return SizeImage(img, 240, 180);
    }

    protected MemoryStream PrintLogoCustomSizeImage(string FileName)
    {
      string fn = SystemInfo.AppPath + "tmp.bmp";
      MemoryStream ms = null;
      Bitmap bmp = null;
      try
      {
        if (File.Exists(fn)) File.Delete(fn);
        DeviceObject.objKS.PrintLogoCustomImage(FileName, fn);
        if (File.Exists(fn))
        {
          bmp = new Bitmap(fn);
          ms = new MemoryStream();
          bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
          bmp.Dispose();
        }
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E);
      }
      try
      {
        if (File.Exists(fn)) File.Delete(fn);
      }
      catch
      {
      }
      return ms;
    }

    protected Bitmap ScanCustomSizeImage(Image img)
    {
      return SizeImage(img, 200, 200);
    }

    protected void DispExtScreen(double Amount, double Balance, byte Mark, byte Flag)
    {
      if (SystemInfo.AllowExtScreen) DeviceObject.objApp.DispMoney(Amount, Balance, Mark, Flag);
    }
  }
}