using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmKQMacInfo : frmKQMacBase
    {
        private bool AllowShowInit = false;

        protected override void InitForm()
        {
            formCode = "KQMacInfo";
            SetToolItemState("ItemImport", false);
            SetToolItemState("ItemExport", false);
            SetToolItemState("ItemPrint", false);
            SetToolItemState("ItemLine1", false);
            SetToolItemState("ItemTAG1", true);
            SetToolItemState("ItemTAG2", true);
            SetToolItemState("ItemTAG3", true);
            SetToolItemState("ItemLine3", true);
            base.InitForm();
            KeyPreview = true;
        }

        public frmKQMacInfo()
        {
            InitializeComponent();
        }

        protected override void ExecItemAdd()
        {
            base.ExecItemAdd();
            frmKQMacInfoAdd frm = new frmKQMacInfoAdd(this.Text, CurrentTool, "");
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
            
        }

        protected override void ExecItemEdit()
        {
            base.ExecItemEdit();
            frmKQMacInfoAdd frm = new frmKQMacInfoAdd(this.Text, CurrentTool, GetMacSysID());
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
          
        }

        protected override void ExecItemTAG1()
        {
            base.ExecItemTAG1();
            frmPubFindMac frm = new frmPubFindMac(this.Text, CurrentTool, 1);
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
            
        }

        protected override void ExecItemTAG2()
        {
            base.ExecItemTAG2();
            ExecMacOprt(0);
           
        }

        protected override void ExecItemTAG3()
        {
            if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "MsgInitQuery", ""))) return;
            base.ExecItemTAG3();
            ExecMacOprt(1);
           
        }

        protected override void RefreshForm(bool State)
        {
            ItemTAG3.Visible = AllowShowInit;
            base.RefreshForm(State);
            ItemTAG1.Enabled = State;
            SetContextMenuVisible(ItemTAG3.Name, AllowShowInit);
            SetContextMenuState();
        }

        protected override void GetDelSql(int rowIndex, ref List<string> sql)
        {
            string ret = Pub.GetSQL(DBCode.DB_002001, new string[] { "3", dataGrid[1, rowIndex].Value.ToString() });
            sql.Add(ret);
        }

        protected override string GetDelMsg(int rowIndex)
        {
            string ret = base.GetDelMsg(rowIndex);
            ret = dataGrid.Columns[2].HeaderText + "=" + dataGrid[2, rowIndex].Value.ToString();
            return ret;
        }

        protected override bool ExecMacCommand(byte flag, int MacSN, ref string MacMsg)
        {
            bool ret = base.ExecMacCommand(flag, MacSN, ref MacMsg);
            switch (flag)
            {
                case 0:
                    ret = SyncTime();
                    break;
                case 1:
                    ret = DeviceObject.objKS.AttRest();
                    break;
            }
            return ret;
        }

        private void frmKQMacInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Alt)
            {
                int h = SystemInfo.MainHandle.ToInt32();
                switch (e.KeyCode)
                {
                    case Keys.I:
                        AllowShowInit = true;
                        RefreshForm(dataGrid.Enabled);
                        break;
                }
            }
        }
    }
}