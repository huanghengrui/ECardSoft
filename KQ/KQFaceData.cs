using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmKQFaceData : frmKQFaceBase
    {
        private string MsgString = "";
        private string usbFile = "";
        private bool AllowShowAll = false;
        private KQTextFormatInfo textFormat = new KQTextFormatInfo("");
        private FingerReadData readData = null;

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
            AddExtDropDownItem("ItemTextDataFormat", ItemTextDataFormat_Click);
            base.InitForm();
            LoadTextFormat();
            KeyPreview = true;
        }

        public frmKQFaceData()
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
            dlgOpen.Filter = Pub.GetResText(formCode, "FilterUSB", "") + "(*.txt)|*.txt";
            if (dlgOpen.ShowDialog() != DialogResult.OK) return;
            usbFile = dlgOpen.FileName;
            base.ExecItemTAG4();
            string MacMsg = "";
            ExecMacCommand(2, 0, 0, ref MacMsg);
           
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

        protected override bool ExecMacCommand(byte flag, int MacSN, byte MacType, ref string MacMsg)
        {
            bool ret = base.ExecMacCommand(flag, MacSN, MacType, ref MacMsg);
            byte IsNew = 0;
            if (flag == 0) IsNew = 1;
            if (readData == null) readData = new FingerReadData(this.Text + "[" + CurrentTool + "]", IsNew);
            int RecordCount = 0;
            int RecordIndex = 0;
            switch (flag)
            {
                case 0:
                case 1:
                    MsgString = lblMsg.Text;
                    progBar.Style = ProgressBarStyle.Blocks;
                    progBar.Value = 0;
                    ret = readData.FK623ReadData(db, textFormat, MacSN, ref RecordCount, ref RecordIndex, ShowReadDataProcess);
                    MacMsg = string.Format("{0}/{1}", RecordIndex, RecordCount);
                    break;
                case 2:
                    RefreshMsg(CurrentTool + "[" + usbFile + "]......");
                    MsgString = lblMsg.Text;
                    progBar.Style = ProgressBarStyle.Blocks;
                    progBar.Value = 0;
                    ret = readData.FK623ReadDataUSB(usbFile, db, textFormat, ref RecordCount, ref RecordIndex, ShowReadDataProcess);
                    if (!ret) MacMsg = DeviceObject.objFK623.ErrMsg;
                    if (ret) MacMsg = string.Format("{0}/{1}", RecordIndex, RecordCount);
                    lblMsg.Text = MsgString + MacMsg;
                    break;
            }
            readData = null;
           
            return ret;
        }

        public void ShowReadDataProcess(int RecordCount, int RecordIndex)
        {
            progBar.Value = RecordIndex * 100 / RecordCount;
            lblMsg.Text = MsgString + string.Format("{0}/{1}", RecordIndex, RecordCount);
            Application.DoEvents();
           
        }

        private void ItemTextDataFormat_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            CurrentTool = ((ToolStripDropDownItem)sender).Text;
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            frmKQMacDataFormat frm = new frmKQMacDataFormat(this.Text, CurrentTool);
            if (frm.ShowDialog() == DialogResult.OK) LoadTextFormat();
           
        }

        private void frmKQFaceData_KeyDown(object sender, KeyEventArgs e)
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