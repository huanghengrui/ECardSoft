using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSeaFaceData : frmSeaFaceBase
    {
        private string MsgString = "";
        private bool AllowShowAll = false;
        private KQTextFormatInfo textFormat = new KQTextFormatInfo("");
        private FingerReadData readData = null;

        protected override void InitForm()
        {
            formCode = "SeaFaceData";
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
            SetToolItemState("ItemTAGExt", false);
            // AddExtDropDownItem("ItemTextDataFormat", ItemTextDataFormat_Click);
            SetToolItemState("ItemlbDataStartTime", true);
            SetToolItemState("ItemlbDataEndTime", true);
            SetToolItemState("ItemStarTime", true);
            SetToolItemState("ItemEndTime", true);
           
            base.InitForm();
            LoadTextFormat();
            KeyPreview = true;
            ItemStarTime.ToolTipText = Pub.GetResText(formCode, "MagSetTime", "");
            ItemEndTime.ToolTipText = Pub.GetResText(formCode, "MagSetTime", "");
        }

        public frmSeaFaceData()
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
        protected override void ExecItemTAG3()
        {
            base.ExecItemTAG3();
            if (readData != null) readData.StopData();
           
        }

        protected override void ExecItemTAG4()
        {
            base.ExecItemTAG4();
            IsExec = true;
            readData = null;
            ExecMacOprt(2);
            IsExec = false;
            RefreshForm(true);
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

        private string checkTime(string Time)
        {
            string NewTime = "";
            try
            {
                NewTime = Convert.ToDateTime(Time).ToString(SystemInfo.SQLDateFMT);
            }
            catch
            {
                NewTime = "";
            }
            return NewTime;
        }

        protected override bool ExecMacCommand(byte flag, int MacSN, string url, string NetName, string NetPassword, ref string MacMsg)
        {
            bool ret = base.ExecMacCommand(flag, MacSN, url, NetName, NetPassword, ref MacMsg);
            byte IsNew = 0;
            if (flag == 0) IsNew = 1;
            if (readData == null) readData = new FingerReadData(this.Text + "[" + CurrentTool + "]", IsNew);
            int RecordCount = 0;
            int RecordIndex = 0;
            string StarTime = ItemStarTime.Text;
            string EndTime = ItemEndTime.Text;
            if(StarTime != "")
            {
                StarTime = checkTime(StarTime);
                if(StarTime == "")
                {
                    ItemStarTime.Focus();
                    ShowErrorEnterCorrect(ItemlbDataStartTime.Text);
                    return false;
                }
            }
            if (EndTime != "")
            {
                EndTime = checkTime(EndTime);
                if (EndTime == "")
                {
                    ItemEndTime.Focus();
                    ShowErrorEnterCorrect(ItemlbDataEndTime.Text);
                    return false;
                }
            }
            if(StarTime == ""&&EndTime != "")
            {
                ItemStarTime.Focus();
                ShowErrorEnterCorrect(ItemlbDataStartTime.Text);
                return false;
            }
            if (StarTime != "" && EndTime == "")
            {
                ItemEndTime.Focus();
                ShowErrorEnterCorrect(ItemlbDataEndTime.Text);
                return false;
            }
            if (StarTime != "" && EndTime != "")
            {
                if (Convert.ToDateTime(StarTime) > Convert.ToDateTime(EndTime))
                {
                    Pub.MessageBoxShow(Pub.GetResText(formCode, "Error001", ""), MessageBoxIcon.Error);
                    return false;
                }
            }
           
            switch (flag)
            {
                case 0:
                case 1:
                    MsgString = lblMsg.Text;
                    progBar.Style = ProgressBarStyle.Blocks;
                    progBar.Value = 0;
                    ret = readData.Sea_FK623ReadData(db,textFormat, MacSN, url, NetName, NetPassword, StarTime, EndTime, ref RecordCount, ref RecordIndex, ShowReadDataProcess);
                    MacMsg = string.Format("{0}/{1}", RecordIndex, RecordCount);
                    break;
                case 2:
                    MsgString = lblMsg.Text;
                    progBar.Style = ProgressBarStyle.Blocks;
                    progBar.Value = 0;
                    ret = readData.Sea_SnapShotsData(db, textFormat, MacSN, url, NetName, NetPassword, StarTime, EndTime, ref RecordCount, ref RecordIndex, ShowReadDataProcess);
                    MacMsg = string.Format("{0}/{1}", RecordIndex, RecordCount);
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
    }
}