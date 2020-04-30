using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSFAddress : frmBaseMDIChild
    {
        protected override void InitForm()
        {
            formCode = "SFAddress";
            SetToolItemState("ItemImport", false);
            SetToolItemState("ItemExport", false);
            SetToolItemState("ItemPrint", false);
            SetToolItemState("ItemLine1", false);
            SetToolItemState("ItemSelect", false);
            SetToolItemState("ItemUnselect", false);
            SetToolItemState("ItemLine4", false);
            base.InitForm();
            ExecItemRefresh();
        }

        public frmSFAddress()
        {
            InitializeComponent();
        }

        protected override void ExecItemAdd()
        {
            base.ExecItemAdd();
            string SysID = GetSysID();
            frmSFAddressAdd frm = new frmSFAddressAdd(this.Text, true, CurrentTool, "", SysID, GetParentAddress());
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
        }

        protected override void ExecItemEdit()
        {
            base.ExecItemEdit();
            string SysID = GetSysID();
            frmSFAddressAdd frm = new frmSFAddressAdd(this.Text, false, CurrentTool, SysID, GetParentAddressEditID(),
              GetParentAddressEdit());
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
            
        }

        protected override void ExecItemDelete()
        {
            string SysID = GetSysID();
            if (SysID == "")
            {
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "MsgNoSelectDelete", ""));
                return;
            }
            TreeNode node = tvAddress.SelectedNode;
            if (node.Parent == null)
            {
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", ""));
                return;
            }
            bool IsError = false;
            DataTableReader dr = null;
            List<string> sql = new List<string>();
            try
            {
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004001, new string[] { "3", SysID }));
                if (dr.Read())
                {
                    IsError = true;
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", ""));
                }
                if (!IsError)
                {
                    sql.Add(Pub.GetSQL(DBCode.DB_004001, new string[] { "8", SysID }));
                    if (db.ExecSQL(sql) != 0) IsError = true;
                }
            }
            catch (Exception E)
            {
                IsError = false;
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            if (IsError) return;
            db.WriteSYLog(this.Text, CurrentTool, sql);
            ExecItemRefresh();
            Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgDeleteSucceed", ""), MessageBoxIcon.Information);
           
        }

        protected override void ExecItemRefresh()
        {
            RefreshMsg(StrReading);
            InitAddressTreeView(tvAddress);
            RefreshForm(true);
            RefreshMsg("");
        }

        protected override void RefreshForm(bool State)
        {
            base.RefreshForm(State);
            int row = 0;
            row = 0;
            if (tvAddress.SelectedNode != null) row = tvAddress.SelectedNode.Level;
            ItemImport.Enabled = ItemImport.Visible && State;
            ItemExport.Enabled = ItemExport.Visible && State && (row > 0);
            ItemPrint.Enabled = ItemPrint.Visible && State && (row > 0);
            ItemAdd.Enabled = ItemAdd.Visible && State;
            ItemEdit.Enabled = ItemEdit.Visible && State && (row > 0);
            ItemDelete.Enabled = ItemDelete.Visible && State && (row > 0);
            ItemTAG1.Enabled = ItemTAG1.Visible && State && (row > 0);
            ItemTAG2.Enabled = ItemTAG2.Visible && State && (row > 0);
            ItemTAG3.Enabled = ItemTAG3.Visible && State && (row > 0);
            ItemTAG4.Enabled = ItemTAG4.Visible && State && (row > 0);
            ItemTAG5.Enabled = ItemTAG5.Visible && State && (row > 0);
            ItemTAG6.Enabled = ItemTAG6.Visible && State && (row > 0);
            ItemTAG7.Enabled = ItemTAG7.Visible && State && (row > 0);
            ItemTAGExt.Enabled = ItemTAGExt.Visible && State && (row > 0);
            for (int i = 0; i < ItemTAGExt.DropDownItems.Count; i++)
            {
                ItemTAGExt.DropDownItems[i].Enabled = ItemTAGExt.Enabled;
            }
            ItemSelect.Enabled = ItemSelect.Visible && State && (row > 0);
            ItemUnselect.Enabled = ItemUnselect.Visible && State && (row > 0);
            ItemRefresh.Enabled = ItemRefresh.Visible && State;
            ItemSearch.Enabled = ItemSearch.Visible && State;
            SetContextMenuState();
            lblRecordState.Enabled = false;
            lblRecordState.Visible = false;
        }

        private void tvAddress_AfterSelect(object sender, TreeViewEventArgs e)
        {
            RefreshForm(true);
        }

        private string GetSysID()
        {
            string ret = "";
            if ((tvAddress.SelectedNode != null) && (tvAddress.SelectedNode.Tag != null))
            {
                ret = tvAddress.SelectedNode.Tag.ToString();
            }
            return ret;
        }

        private string GetParentAddress()
        {
            string ret = "";
            if (tvAddress.SelectedNode != null)
            {
                ret = tvAddress.SelectedNode.Text;
            }
            return ret;
        }

        private string GetParentAddressEditID()
        {
            string ret = "";
            if ((tvAddress.SelectedNode != null) && (tvAddress.SelectedNode.Parent != null) &&
              (tvAddress.SelectedNode.Parent.Tag != null))
            {
                ret = tvAddress.SelectedNode.Parent.Tag.ToString();
            }
            return ret;
        }

        private string GetParentAddressEdit()
        {
            string ret = "";
            if ((tvAddress.SelectedNode != null) && (tvAddress.SelectedNode.Parent != null))
            {
                ret = tvAddress.SelectedNode.Parent.Text;
            }
            return ret;
        }
    }
}