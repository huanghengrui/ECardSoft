using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSFDepositType : frmBaseMDIChildGrid
    {
        protected override void InitForm()
        {
            formCode = "SFDepositType";
            dataGrid.Columns.Clear();
            AddColumn(1, "SelectCheck", false, false, 1, 60);
            AddColumn(0, "DepositTypeID", false, 120);
            AddColumn(0, "DepositTypeName", false, 120);
            AddColumn(0, "GUID", true, false, 0);
            SetToolItemState("ItemImport", false);
            SetToolItemState("ItemExport", false);
            SetToolItemState("ItemPrint", false);
            SetToolItemState("ItemLine1", false);
            SetToolItemState("ItemDelete", false);
            base.InitForm();
            ExecItemRefresh();
        }

        public frmSFDepositType()
        {
            InitializeComponent();
        }

        protected override void ExecItemAdd()
        {
            base.ExecItemAdd();
            frmSFDepositTypeAdd frm = new frmSFDepositTypeAdd(this.Text, CurrentTool, "");
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
           
        }

        protected override void ExecItemEdit()
        {
            base.ExecItemEdit();
            DataRowView drv = (DataRowView)bindingSource.Current;
            string GUID = drv.Row["GUID"].ToString();
            string ID = drv.Row["DepositTypeID"].ToString();
            if (IsDefaultType(ID))
            {
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", ""));
                return;
            }
            frmSFDepositTypeAdd frm = new frmSFDepositTypeAdd(this.Text, CurrentTool, GUID);
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
          
        }

        protected override void ExecItemRefresh()
        {
            QuerySQL = Pub.GetSQL(DBCode.DB_004013, new string[] { "0" });
            base.ExecItemRefresh();
        }

        protected override void GetDelSql(int rowIndex, ref List<string> sql)
        {
            string ret = Pub.GetSQL(DBCode.DB_004013, new string[] { "3", dataGrid[3, rowIndex].Value.ToString() });
            sql.Add(ret);
        }

        protected override string GetDelMsg(int rowIndex)
        {
            string ret = base.GetDelMsg(rowIndex);
            ret = dataGrid.Columns[1].HeaderText + "=" + dataGrid[1, rowIndex].Value.ToString() + "," +
              dataGrid.Columns[2].HeaderText + "=" + dataGrid[2, rowIndex].Value.ToString();
            return ret;
        }

        protected override bool CheckDelete(int rowIndex)
        {
            bool ret = true;
            string ID = dataGrid[1, rowIndex].Value.ToString();
            if (IsDefaultType(ID))
            {
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error002", ""));
                ret = false;
            }
            return ret;
        }

        private bool IsDefaultType(string TypeID)
        {
            bool ret = false;
            if (!SystemInfo.IgnoreMobile && (TypeID == "100" || TypeID == "101")) ret = true;
            return ret;
        }
    }
}