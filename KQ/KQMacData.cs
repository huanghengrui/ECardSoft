using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmKQMacData : frmKQMacBase
    {
        private string MsgString = "";
        private KQTextFormatInfo textFormat = new KQTextFormatInfo("");
        private string usbFile = "";
        private bool AllowShowAll = false;
        private KQReadData readData = null;

        protected override void InitForm()
        {
            formCode = "KQMacData";
            SetToolItemState("ItemImport", false);
            SetToolItemState("ItemExport", false);
            SetToolItemState("ItemPrint", false);
            SetToolItemState("ItemLine1", false);
            SetToolItemState("ItemAdd", false);
            SetToolItemState("ItemEdit", false);
            SetToolItemState("ItemDelete", false);
            SetToolItemState("ItemLine2", false);
            SetToolItemState("ItemTAG1", true);
            SetToolItemState("ItemTAG2", true);
            SetToolItemState("ItemTAG3", false);
            SetToolItemState("ItemTAG4", true);
            SetToolItemState("ItemLine3", true);
            SetToolItemState("ItemTAGExt", true);
            AddExtDropDownItem("ItemTextData", ItemTextData_Click);
            AddExtDropDownItem("ItemTextDataFormat", ItemTextDataFormat_Click);
            base.InitForm();
            LoadTextFormat();
            KeyPreview = true;
        }

        public frmKQMacData()
        {
            InitializeComponent();
        }

        private void LoadTextFormat()
        {
            DataTableReader dr = null;
            try
            {
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "112", KQTextFormatInfo.KQ_ConfigID,
          KQTextFormatInfo.KQ_TextFormat }));
                if (dr.Read()) textFormat = new KQTextFormatInfo(dr["Value"].ToString());
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
        }

        protected override void ExecItemTAG1()
        {
            base.ExecItemTAG1();
            IsExec = true;
            readData = null;
            ExecMacOprt(0);
            IsExec = false;
            RefreshForm(true);
           
        }

        protected override void ExecItemTAG2()
        {
            base.ExecItemTAG2();
            IsExec = true;
            readData = null;
            ExecMacOprt(1);
            IsExec = false;
            RefreshForm(true);
        }

        protected override void ExecItemTAG3()
        {
            base.ExecItemTAG3();
            if (readData != null) readData.StopData();
           
        }

        protected override void ExecItemTAG4()
        {
            dlgOpen.Filter = Pub.GetResText(formCode, "FilterUSB", "") + "(KQ*.dat)|KQ*.dat";
            if (dlgOpen.ShowDialog() != DialogResult.OK) return;
            base.ExecItemTAG4();
            usbFile = dlgOpen.FileName;
            string MacMsg = "";
            ExecMacCommand(2, 0, ref MacMsg);
            
        }

        protected override void RefreshForm(bool State)
        {
            ItemTAG2.Visible = AllowShowAll;
            base.RefreshForm(State);
            ItemTAG1.Enabled = ItemTAG1.Enabled && !IsExec;
            ItemTAG2.Enabled = ItemTAG2.Enabled && !IsExec;
            //ItemTAG3.Enabled = IsExec && dataGrid.RowCount > 0;
            SetContextMenuVisible(ItemTAG2.Name, AllowShowAll);
            SetContextMenuState();
        }

        protected override bool ExecMacCommand(byte flag, int MacSN, ref string MacMsg)
        {
            bool ret = base.ExecMacCommand(flag, MacSN, ref MacMsg);
            bool IsNew = false;
            if (flag == 0) IsNew = true;
            if (readData == null) readData = new KQReadData(this.Text + "[" + CurrentTool + "]", IsNew);
            int RecordCount = 0;
            int RecordIndex = 0;
            switch (flag)
            {
                case 0:
                case 1:
                    DeviceObject.objKS.SysSetState(false);
                    MsgString = lblMsg.Text;
                    progBar.Style = ProgressBarStyle.Blocks;
                    progBar.Value = 0;
                    ret = readData.ReadData(db, textFormat, MacSN, ref RecordCount, ref RecordIndex, false, ShowReadDataProcess);
                    MacMsg = string.Format("{0}/{1}", RecordIndex, RecordCount);
                    break;
                case 2:
                    RefreshMsg(CurrentTool + "[" + usbFile + "]......");
                    MsgString = lblMsg.Text;
                    progBar.Style = ProgressBarStyle.Blocks;
                    progBar.Value = 0;
                    ret = readData.ReadDataUSB(usbFile, db, textFormat, ref RecordCount, ref RecordIndex, ShowReadDataProcess);
                    MacMsg = string.Format("{0}/{1}", RecordIndex, RecordCount);
                    lblMsg.Text = MsgString + MacMsg;
                    break;
                case 3:
                    RefreshMsg(CurrentTool + "[" + usbFile + "]......");
                    MsgString = lblMsg.Text;
                    progBar.Style = ProgressBarStyle.Blocks;
                    progBar.Value = 0;
                    ret = readData.ReadDataText(usbFile, db, textFormat, ref RecordCount, ref RecordIndex, ShowReadDataProcess);
                    MacMsg = string.Format("{0}/{1}", RecordIndex, RecordCount);
                    lblMsg.Text = MsgString + MacMsg;
                    break;
            }
            if (flag == 0 || flag == 1) DeviceObject.objKS.SysSetState(true);
            readData = null;
           
            return ret;
        }

        public void ShowReadDataProcess(int RecordCount, int RecordIndex)
        {
            progBar.Value = RecordIndex * 100 / RecordCount;
            lblMsg.Text = MsgString + string.Format("{0}/{1}", RecordIndex, RecordCount);
            Application.DoEvents();
           
        }

        private void ItemTextData_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            CurrentTool = ((ToolStripDropDownItem)sender).Text;
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            dlgOpen.Filter = Pub.GetResText(formCode, "FilterText", "") + "(KQ*.dat)|KQ*.dat";
            if (dlgOpen.ShowDialog() != DialogResult.OK) return;
            usbFile = dlgOpen.FileName;
            string MacMsg = "";
            ExecMacCommand(3, 0, ref MacMsg);
           
        }

        private void ItemTextDataFormat_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            CurrentTool = ((ToolStripDropDownItem)sender).Text;
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            frmKQMacDataFormat frm = new frmKQMacDataFormat(this.Text, CurrentTool);
            if (frm.ShowDialog() == DialogResult.OK) LoadTextFormat();
            
        }

        private void frmKQMacData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Alt)
            {
                int h = SystemInfo.MainHandle.ToInt32();
                switch (e.KeyCode)
                {
                    case Keys.A:
                        AllowShowAll = true;
                        RefreshForm(dataGrid.Enabled);
                        break;
                }
            }
        }
    }
}