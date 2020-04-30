using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSFMacData : frmSFMacBase
    {
        private string MsgString = "";
        private string usbFile = "";
        private bool AllowShowAll = false;
        private byte currflag = 0;
        private SFReadData readData = null;
        private static int Flag = 0;
        private string Tool = "";
        protected override void InitForm()
        {
            formCode = "SFMacData";
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
            if (Flag == 1)
            {
                SetToolItemState("ItemLine5", true);
                SetToolItemState("ItemlbData", true);
                SetToolItemState("ItemTAG2", false);
                SetToolItemState("ItemTAG4", false);
                SetToolItemState("ItemLine3", false);
                SetToolItemState("ItemTAGExt", false);
                SetToolItemState("ItemTAGExt", false);
                SetToolItemState("ItemSelect", false);
                SetToolItemState("ItemUnselect", false);

                dataGrid.ReadOnly = true;
            }
            base.InitForm();
            KeyPreview = true;
            if (Flag == 1)
            {
                ItemlbData.Text = string.Format(Pub.GetResText("RSEmp", "lbGetData", ""), Tool);
                ItemlbData.ForeColor = Color.Red;
            }
            //base.ExecItemSelect();
        }

        public frmSFMacData(int falg, string tool)
        {
            Tool = tool;
            Flag = falg;
            InitializeComponent();
        }

        protected override void ExecItemTAG1()
        {
            base.ExecItemTAG1();
            IsExec = true;
            readData = null;
            ExecMacOprt(0);
            IsExec = false;
            RefreshForm(true);
            if (Flag == 1)
            {
                if (SystemInfo.IsGetData)
                    this.Close();
                else
                {
                    if (SystemInfo.HasForcedRecoveryOfData)
                    {
                        if (!SystemInfo.IsGetData)
                        {
                            string tmp = string.Format(Pub.GetResText("RSEmp", "Error107", ""), Tool);
                            if (Pub.MessageBoxShowData(tmp, MessageBoxIcon.Warning))
                                return;
                            else
                                ExecItemTAG1();
                        }
                    }
                    else
                        this.Close();
                }
            }
           
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
            //dlgOpen.Filter = Pub.GetResText(formCode, "FilterUSB", "") + "(XF*.dat;DC*.dat)|XF*.dat;DC*.dat";
            //if (dlgOpen.ShowDialog() != DialogResult.OK) return;
            //base.ExecItemTAG4();
            //usbFile = dlgOpen.FileName;
            //string MacMsg = "";
            //ExecMacCommand(2, 0, ref MacMsg);
            string msg = "";
            CurrentTool = ItemTAG4.Text;
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = true;//等于true表示可以选择多个文件
            dlg.DefaultExt = ".txt";
            dlg.Filter = Pub.GetResText(formCode, "FilterUSB", "") + "(XF*.dat;DC*.dat)|XF*.dat;DC*.dat";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                msg = "";
                foreach (string file in dlg.FileNames)
                {

                    base.ExecItemTAG4();
                    usbFile = file;
                    string MacMsg = "";
                    ExecMacCommand(2, 0, ref MacMsg);
                    msg = msg + " [" + usbFile + "] " + MacMsg + "; ";
                }
                db.WriteSYLog(this.Text, CurrentTool, msg);
              
            }
            else return;
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
            if (Flag == 1)
                base.ExecItemSelect();
        }

        protected override bool ExecMacCommand(byte flag, int MacSN, ref string MacMsg)
        {
            bool ret = base.ExecMacCommand(flag, MacSN, ref MacMsg);
            byte MacType = 0;
            if ((flag == 0) || (flag == 1)) MacType = Convert.ToByte(GetMacType(MacSN.ToString()));
            bool IsNew = false;
            if (flag == 0) IsNew = true;
            if (readData == null) readData = new SFReadData(this.Text + "[" + CurrentTool + "]", IsNew);
            currflag = flag;
            string dataMsg = "";
            switch (flag)
            {
                case 0:
                case 1:
                    DeviceObject.objKS.SysSetState(false);
                    MsgString = lblMsg.Text;
                    progBar.Style = ProgressBarStyle.Blocks;
                    progBar.Value = 0;
                    ret = readData.ReadData(db, MacSN, MacType, ref dataMsg, false, ShowReadDataProcess);
                    MacMsg = dataMsg;
                    break;
                case 2:
                    RefreshMsg(CurrentTool + "[" + usbFile + "]......");
                    MsgString = lblMsg.Text;
                    progBar.Style = ProgressBarStyle.Blocks;
                    progBar.Value = 0;
                    ret = readData.ReadDataUSB(usbFile, db, ref dataMsg, ShowReadDataProcess);
                    MacMsg = dataMsg;
                    lblMsg.Text = MsgString + MacMsg;

                    break;
                case 3:
                    RefreshMsg(CurrentTool + "[" + usbFile + "]......");
                    MsgString = lblMsg.Text;
                    progBar.Style = ProgressBarStyle.Blocks;
                    progBar.Value = 0;
                    ret = readData.ReadDataText(usbFile, db, ref dataMsg, ShowReadDataProcess);
                    MacMsg = dataMsg;
                    lblMsg.Text = MsgString + MacMsg;
                    progBar.Style = ProgressBarStyle.Blocks;
                    progBar.Value = 0;
                    break;
            }
            if (flag == 0 || flag == 1) DeviceObject.objKS.SysSetState(true);
            readData = null;
            
            return ret;
        }

        public void ShowReadDataProcess(int RecordCount, int RecordIndex, string msg)
        {
            if (currflag == 3)
            {
                progBar.Value = 50;
                progBar.Style = ProgressBarStyle.Marquee;
            }
            else
            {
                progBar.Value = RecordIndex * 100 / RecordCount;
            }
            lblMsg.Text = MsgString + msg;
            Application.DoEvents();
           
        }

        private void ItemTextData_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            CurrentTool = ((ToolStripDropDownItem)sender).Text;
            if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
            //dlgOpen.Filter = Pub.GetResText(formCode, "FilterText", "") + "(XF*.dat)|XF*.dat";
            //if (dlgOpen.ShowDialog() != DialogResult.OK) return;
            //usbFile = dlgOpen.FileName;
            //string MacMsg = "";
            //ExecMacCommand(3, 0, ref MacMsg);

            string msg = "";
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = true;//等于true表示可以选择多个文件
            dlg.DefaultExt = ".txt";
            dlg.Filter = Pub.GetResText(formCode, "FilterText", "") + "(XF*.dat)|XF*.dat";
            if (dlg.ShowDialog() == DialogResult.OK)
            {

                foreach (string file in dlg.FileNames)
                {

                    usbFile = file;
                    string MacMsg = "";
                    ExecMacCommand(3, 0, ref MacMsg);
                    msg = msg + " [" + usbFile + "] " + MacMsg + "; ";

                }
                db.WriteSYLog(this.Text, CurrentTool, msg);
               
            }
            else return;
        }

        private void frmSFMacData_KeyDown(object sender, KeyEventArgs e)
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