using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using QHKS;
using grproLib;

namespace ECard78
{
    public partial class frmBaseMDIChild : frmBaseForm
    {
        protected string StrPosition = "";
        protected string StrReading = "";
        protected string StrReadEnd = "";
        protected string CurrentTool = "";
        protected string QuerySQL = "";
        protected bool ImportShowDepart = false;
        protected bool ImportShowCount = false;
        protected string[] ImportFieldList;
        protected bool IgnoreSelect = false;
        protected string DeleteMsg = "";
        protected bool CheckForward = true;
        protected bool AllowCheckOprtRole = true;
        protected frmAppMain appMainForm;

        public delegate void FormMinSize(object sender, EventArgs e);
        public event FormMinSize OnFormMinSize;

        protected void AddExtDropDownItem(string ItemName, EventHandler onClick)
        {
            ItemTAGExt.DropDownItems.Add(Pub.GetResText(formCode, ItemName, ""), null, onClick);
            ItemTAGExt.DropDownItems[ItemTAGExt.DropDownItems.Count - 1].Name = ItemName;
        }

        protected override void InitForm()
        {
            appMainForm = Pub.GetAppMainForm();
            Pub.SetFormAppIcon(this);
            ToolStripDropDownButton toolDown;
            ToolStripItem item;
            base.InitForm();
            if (IgnoreSelect)
            {
                SetToolItemState("ItemSelect", false);
                SetToolItemState("ItemUnselect", false);
                SetToolItemState("ItemLine4", false);
            }
            StrPosition = Pub.GetResText(formCode, "ItemPosition", "");
            StrReading = Pub.GetResText(formCode, "MsgReadingData", "");
            StrReadEnd = Pub.GetResText(formCode, "MsgReadEndData", "");
            contextMenu.Items.Clear();
            bool HasTAG = ItemTAG1.Visible || ItemTAG2.Visible || ItemTAG3.Visible || ItemTAG4.Visible ||
              ItemTAG5.Visible || ItemTAG6.Visible || ItemTAG7.Visible;
            for (int i = 0; i < Toolbar.Items.Count; i++)
            {
                if (Toolbar.Items[i] is ToolStripButton)
                {
                    item = contextMenu.Items.Add(Toolbar.Items[i].Text, Toolbar.Items[i].Image);
                    item.Tag = Toolbar.Items[i].Name;
                    item.Name = "pop" + Toolbar.Items[i].Name;
                }
                else if (Toolbar.Items[i] is ToolStripSeparator)
                {
                    item = new ToolStripSeparator();
                    item.Tag = Toolbar.Items[i].Name;
                    item.Name = "pop" + Toolbar.Items[i].Name;
                    contextMenu.Items.Add(item);
                }
                else if (Toolbar.Items[i] is ToolStripDropDownButton)
                {
                    toolDown = (ToolStripDropDownButton)Toolbar.Items[i];
                    if ((toolDown.DropDownItems.Count > 0) && HasTAG)
                    {
                        item = new ToolStripSeparator();
                        item.Tag = "popItemTAGExtLine";
                        item.Name = "popItemTAGExtLine";
                        contextMenu.Items.Add(item);
                    }
                    for (int j = 0; j < toolDown.DropDownItems.Count; j++)
                    {
                        item = contextMenu.Items.Add(toolDown.DropDownItems[j].Text, toolDown.DropDownItems[j].Image);
                        item.Tag = null;
                        item.Name = "pop" + toolDown.DropDownItems[j].Name;
                    }
                }
            }
            DeleteLine();
        }

        private void DeleteLine()
        {
            bool IsLine = false;
            for (int i = contextMenu.Items.Count - 1; i >= 0; i--)
            {
                if (contextMenu.Items[i] is ToolStripSeparator)
                {
                    if (IsLine)
                    {
                        IsLine = false;
                        contextMenu.Items.RemoveAt(i);
                        DeleteLine();
                        return;
                    }
                    else
                        IsLine = true;
                }
                else
                    IsLine = false;
            }
        }

        protected override void FreeForm()
        {
            base.FreeForm();
            if (appMainForm != null) appMainForm.ExecFreeForm(this.Name);
        }

        protected void SetToolItemState(string ItemName, bool State)
        {
            Toolbar.Items[ItemName].Enabled = State;
            Toolbar.Items[ItemName].Visible = State;
        }

        protected virtual void ExecItemImport()
        {
            frmPubDataIn frm = new frmPubDataIn(this.Text, ImportShowDepart, ImportShowCount, ImportFieldList, ProcessImportData);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ExecItemImportAfter();
                ExecItemRefresh();
            }
        }

        protected virtual void ExecItemImportAfter()
        {

        }

        protected virtual void ExecItemExport()
        {

        }

        protected virtual void ExecItemPrint()
        {

        }

        protected virtual void ExecItemAdd()
        {

        }

        protected virtual void ExecItemEdit()
        {

        }

        protected virtual void ExecItemDelete()
        {

        }

        protected virtual void ExecItemTAG1()
        {

        }

        protected virtual void ExecItemTAG2()
        {

        }

        protected virtual void ExecItemTAG3()
        {

        }

        protected virtual void ExecItemTAG4()
        {

        }

        protected virtual void ExecItemTAG5()
        {

        }

        protected virtual void ExecItemTAG6()
        {

        }

        protected virtual void ExecItemTAG7()
        {

        }

        protected virtual void ExecItemTAG8()
        {

        }

        protected virtual void ExecItemTAG9()
        {

        }

        protected virtual void ExecItemSelect()
        {
            SelectData(true);
        }

        protected virtual void ExecItemUnselect()
        {
            SelectData(false);
        }

        protected virtual void ExecItemSearch()
        {

        }

        protected virtual void ExecItemRefresh()
        {
            if ((db == null) || (SystemInfo.ConnStr == "")) return;
            DateTime StartTime = DateTime.Now;
            int row = -1;
            RefreshMsg(StrReading);
            if (QuerySQL != "")
            {
                try
                {
                    if (bindingSource.DataSource != null) row = bindingSource.Position;
                    bindingSource.DataSource = null;
                    if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                    bindingSource.DataSource = db.GetDataTable(QuerySQL);
                }
                catch (Exception E)
                {
                    Pub.ShowErrorMsg(E, QuerySQL);
                }
                finally
                {
                    if ((bindingSource.DataSource != null) && (row >= 0))
                    {
                        if (row < bindingSource.Count)
                            bindingSource.Position = row;
                        else if (bindingSource.Count > 0)
                            bindingSource.Position = bindingSource.Count - 1;
                    }
                }
            }
            RefreshForm(true);
            RefreshMsg(StrReadEnd + Pub.GetDateDiffTimes(StartTime, DateTime.Now, true), true);
        }

        protected virtual void ExecItemFindText()
        {

        }

        protected virtual void ExecItemZoomIn()
        {

        }

        protected virtual void ExecItemZoomOut()
        {

        }

        protected virtual void SelectData(bool State)
        {
            if (bindingSource.DataSource != null)
            {
                DataTable dt = (DataTable)bindingSource.DataSource;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i].BeginEdit();
                    dt.Rows[i]["SelectCheck"] = State;
                    dt.Rows[i].EndEdit();
                }
            }
        }

        protected virtual void RefreshForm(bool State)
        {
            int row = 0;
            int rows = 0;
            if (bindingSource.DataSource != null)
            {
                row = bindingSource.Position + 1;
                rows = bindingSource.Count;
            }
            ItemImport.Enabled = State;
            ItemExport.Enabled = (rows > 0);
            ItemPrint.Enabled = (rows > 0);
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
                    ItemTAGExt.DropDownItems[i].Enabled = State;
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

        protected void RefreshMsg(string msg)
        {
            RefreshMsg(msg, false);
        }

        protected void RefreshMsg(string msg, bool IsEnd)
        {
            lblMsg.Text = msg;
            if ((lblMsg.Text == "") || IsEnd)
            {
                progBar.Value = 0;
                progBar.Style = ProgressBarStyle.Blocks;
            }
            else
            {
                progBar.Value = 50;
                progBar.Style = ProgressBarStyle.Marquee;
            }
            Statusbar.Refresh();
        }

        public frmBaseMDIChild()
        {
            InitializeComponent();
        }

        private void frmBaseMDIChild_Activated(object sender, EventArgs e)
        {
            if (appMainForm != null) appMainForm.ExecShowForm(this.Name, this.Text);
        }

        private void frmBaseMDIChild_Shown(object sender, EventArgs e)
        {
            RefreshForm(true);
        }

        private void ItemImport_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            CurrentTool = ((ToolStripButton)sender).Text;
            if (!db.CheckOprtRole(formCode, "A", CheckForward, AllowCheckOprtRole)) return;
            ExecItemImport();
        }

        private void ItemExport_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            CurrentTool = ((ToolStripButton)sender).Text;
            ExecItemExport();
        }

        private void ItemPrint_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            CurrentTool = ((ToolStripButton)sender).Text;
            ExecItemPrint();
        }

        private void ItemAdd_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            CurrentTool = ((ToolStripButton)sender).Text;
            if (!db.CheckOprtRole(formCode, "A", CheckForward, AllowCheckOprtRole)) return;
            ExecItemAdd();
        }

        private void ItemEdit_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            CurrentTool = ((ToolStripButton)sender).Text;
            if (!db.CheckOprtRole(formCode, "M", CheckForward, AllowCheckOprtRole)) return;
            ExecItemEdit();
        }

        private void ItemDelete_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            if (!db.CheckOprtRole(formCode, "D", CheckForward, AllowCheckOprtRole)) return;
            if (DeleteMsg == "") DeleteMsg = Pub.GetResText(formCode, "MsgDeleteSelect", "");
            if (!Pub.MessageBoxShowQuestion(DeleteMsg))
            {
                CurrentTool = ((ToolStripButton)sender).Text;
                ExecItemDelete();
            }
        }

        private void ItemTAG1_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            CurrentTool = ((ToolStripButton)sender).Text;
            if (!db.CheckOprtRole(formCode, "C", CheckForward, AllowCheckOprtRole)) return;
            ExecItemTAG1();
        }

        private void ItemTAG2_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            CurrentTool = ((ToolStripButton)sender).Text;
            if (!db.CheckOprtRole(formCode, "C", CheckForward, AllowCheckOprtRole)) return;
            ExecItemTAG2();
        }

        private void ItemTAG3_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            CurrentTool = ((ToolStripButton)sender).Text;
            if (!db.CheckOprtRole(formCode, "C", CheckForward, AllowCheckOprtRole)) return;
            ExecItemTAG3();
        }

        private void ItemTAG4_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            CurrentTool = ((ToolStripButton)sender).Text;
            if (!db.CheckOprtRole(formCode, "C", CheckForward, AllowCheckOprtRole)) return;
            ExecItemTAG4();
        }

        private void ItemTAG5_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            CurrentTool = ((ToolStripButton)sender).Text;
            if (!db.CheckOprtRole(formCode, "C", CheckForward, AllowCheckOprtRole)) return;
            ExecItemTAG5();
        }

        private void ItemTAG6_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            CurrentTool = ((ToolStripButton)sender).Text;
            if (!db.CheckOprtRole(formCode, "C", CheckForward, AllowCheckOprtRole)) return;
            ExecItemTAG6();
        }

        private void ItemTAG7_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            CurrentTool = ((ToolStripButton)sender).Text;
            if (!db.CheckOprtRole(formCode, "C", CheckForward, AllowCheckOprtRole)) return;
            ExecItemTAG7();
        }
        private void ItemTAG9_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            CurrentTool = ((ToolStripButton)sender).Text;
            if (!db.CheckOprtRole(formCode, "C", CheckForward, AllowCheckOprtRole)) return;
            ExecItemTAG9();
        }

        private void ItemSelect_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            CurrentTool = ((ToolStripButton)sender).Text;
            ExecItemSelect();
        }

        private void ItemUnselect_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            CurrentTool = ((ToolStripButton)sender).Text;
            ExecItemUnselect();
        }

        private void ItemSearch_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            CurrentTool = ((ToolStripButton)sender).Text;
            ExecItemSearch();
        }

        private void ItemRefresh_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            CurrentTool = ((ToolStripButton)sender).Text;
            ExecItemRefresh();
        }

        private void ItemFindText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            CurrentTool = ItemFindLabel.Text;
            ExecItemFindText();
        }

        private void ItemZoomIn_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            CurrentTool = ((ToolStripButton)sender).Text;
            ExecItemZoomIn();
        }

        private void ItemZoomOut_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            CurrentTool = ((ToolStripButton)sender).Text;
            ExecItemZoomOut();
        }

        private void bindingSource_PositionChanged(object sender, EventArgs e)
        {
            RefreshForm(true);
        }

        private void contextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem[] findItem = null;
            if ((e.ClickedItem.Tag != null) && (e.ClickedItem.Tag.ToString() != ""))
            {
                findItem = Toolbar.Items.Find(e.ClickedItem.Tag.ToString(), true);
            }
            else if (e.ClickedItem.Tag == null)
            {
                findItem = Toolbar.Items.Find(e.ClickedItem.Name.Substring(3), true);
            }
            if ((findItem != null) && (findItem.Length > 0))
            {
                findItem[0].PerformClick();
            }
        }

        public virtual bool ProcessImportData(DataRow row, List<string> sys, List<string> src, string DepartUpSysID,
          ref string ErrorMsg, ref double Sum)
        {
            ErrorMsg = "";
            return true;
        }

        private void ExportGridReport(GridppReport report, GRExportType exportType, string Title, string FileName)
        {
            DateTime StartTime = DateTime.Now;
            string msg = Pub.GetResText("", "MsgExportingData", "");
            msg = string.Format(msg, Title);
            try
            {
                if (File.Exists(FileName)) File.Delete(FileName);
                if (report.DetailGrid != null)
                {
                    if (report.ColumnByName("CheckBox") != null) report.ColumnByName("CheckBox").Visible = false;
                }
                bool ret = report.ExportDirect(exportType, FileName, true, false);
                if (report.DetailGrid != null)
                {
                    if (report.ColumnByName("CheckBox") != null) report.ColumnByName("CheckBox").Visible = true;
                }
                if (!ret) return;
                msg = Pub.GetResText("", "MsgExportSuccess", "");
                msg = string.Format(msg, Title);
                RefreshMsg(msg + Pub.GetDateDiffTimes(StartTime, DateTime.Now, true), true);
                Pub.MessageBoxShow(msg, MessageBoxIcon.Information);
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }

        }

        protected void ExportToXLS(GridppReport report, string Title, string FileName)
        {
            ExportGridReport(report, GRExportType.gretXLS, Title, FileName);
        }

        protected void ExportToTXT(GridppReport report, string Title, string FileName)
        {
            ExportGridReport(report, GRExportType.gretTXT, Title, FileName);
        }

        protected void ExportToHTM(GridppReport report, string Title, string FileName)
        {
            ExportGridReport(report, GRExportType.gretHTM, Title, FileName);
        }

        protected void ExportToRTF(GridppReport report, string Title, string FileName)
        {
            ExportGridReport(report, GRExportType.gretRTF, Title, FileName);
        }

        protected void ExportToPDF(GridppReport report, string Title, string FileName)
        {
            ExportGridReport(report, GRExportType.gretPDF, Title, FileName);
        }

        protected void ExportToCSV(GridppReport report, string Title, string FileName)
        {
            ExportGridReport(report, GRExportType.gretCSV, Title, FileName);
        }

        protected void ExportToIMG(GridppReport report, string Title, string FileName)
        {
            ExportGridReport(report, GRExportType.gretIMG, Title, FileName);
        }

        protected virtual void GetDelSql(int rowIndex, ref List<string> sql)
        {
        }

        protected virtual void GetDelSqlExt(ref List<string> sql)
        {
        }

        protected virtual string GetDelMsg(int rowIndex)
        {
            return "";
        }
        protected virtual bool GetProduts(ref string CategoryID)
        {
            return false;
        }

        protected virtual bool GetProdutsID(ref string CategoryID)
        {
            return false;
        }
        protected void SetToolImage(string ItemName, string ImageName)
        {
            ToolStripButton btn = (ToolStripButton)Toolbar.Items[ItemName];
            switch (ImageName)
            {
                case "FileSave":
                    btn.Image = Properties.Resources.FileSave;
                    break;
                case "FileSaveAll":
                    btn.Image = Properties.Resources.FileSaveAll;
                    break;
                case "EditUndo":
                    btn.Image = Properties.Resources.EditUndo;
                    break;
            }
        }

        protected void SetContextMenuState()
        {
            ToolStripItem[] findItem;
            for (int i = 0; i < contextMenu.Items.Count; i++)
            {
                if (contextMenu.Items[i].Tag != null)
                {
                    if (contextMenu.Items[i].Tag.ToString() == "popItemTAGExtLine")
                    {
                        contextMenu.Items[i].Enabled = ItemTAGExt.Enabled;
                        contextMenu.Items[i].Visible = ItemTAGExt.Visible;
                    }
                    else
                    {
                        findItem = Toolbar.Items.Find(contextMenu.Items[i].Tag.ToString(), true);
                        if ((findItem != null) && (findItem.Length > 0))
                        {
                            contextMenu.Items[i].Enabled = findItem[0].Enabled;
                            contextMenu.Items[i].Visible = findItem[0].Visible;
                        }
                    }
                }
                else
                {
                    findItem = Toolbar.Items.Find(contextMenu.Items[i].Name.Substring(3), true);
                    if ((findItem != null) && (findItem.Length > 0))
                    {
                        contextMenu.Items[i].Enabled = findItem[0].Enabled;
                    }
                }
            }
        }

        protected void SetContextMenuVisible(string itemName, bool visible)
        {
            ToolStripItem[] findItem = contextMenu.Items.Find("pop" + itemName, true);
            for (int i = 0; i < findItem.Length; i++)
            {
                findItem[i].Visible = visible;
            }
        }

        private void frmBaseMDIChild_SizeChanged(object sender, EventArgs e)
        {
            if (this.OnFormMinSize != null && this.WindowState == FormWindowState.Minimized)
            {
                this.OnFormMinSize(this, e);
            }
        }

        private void ItemTAG8_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            CurrentTool = ((ToolStripButton)sender).Text;
            if (!db.CheckOprtRole(formCode, "C", CheckForward, AllowCheckOprtRole)) return;
            ExecItemTAG8();
        }
    }
}