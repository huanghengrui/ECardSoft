using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmRSDepositDiscount : frmBaseMDIChildGrid
    {
        protected override void InitForm()
        {
            formCode = "RSDepositDiscount";
            SetToolItemState("ItemImport", false);
            SetToolItemState("ItemExport", false);
            SetToolItemState("ItemPrint", false);
            SetToolItemState("ItemLine1", false);
            AddColumn(1, "SelectCheck", false, false, 1, 60);
            AddColumn(0, "GUID", true, false, 0);
            AddColumn(0, "CardTypeID", true, false, 0);
            AddColumn(0, "CardTypeName", false, false, 0);
            AddColumn(0, "DiscStart", false, false, 2, 100);
            //AddColumn(0, "DiscEnd", false, false, 2, 100);
            AddColumn(0, "DiscDiscount", false, false, 2, 100);
            base.InitForm();
            SetColCurrencyFormat("DiscStart");
            //SetColCurrencyFormat("DiscEnd");
            SetColCurrencyFormat("DiscDiscount");
            QuerySQL = Pub.GetSQL(DBCode.DB_001001, new string[] { "101" });
            ExecItemRefresh();
        }

        public frmRSDepositDiscount()
        {
            InitializeComponent();
        }

        protected override void ExecItemAdd()
        {
            base.ExecItemAdd();
            frmRSDepositDiscountAdd frm = new frmRSDepositDiscountAdd(this.Text, CurrentTool, "");
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
           
        }

        protected override void ExecItemEdit()
        {
            base.ExecItemEdit();
            frmRSDepositDiscountAdd frm = new frmRSDepositDiscountAdd(this.Text, CurrentTool, GetSysID());
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
          
        }

        protected override void GetDelSql(int rowIndex, ref List<string> sql)
        {
            string ret = Pub.GetSQL(DBCode.DB_001001, new string[] { "105", dataGrid[1, rowIndex].Value.ToString() });
            sql.Add(ret);
        }

        protected override string GetDelMsg(int rowIndex)
        {
            string ret = base.GetDelMsg(rowIndex);
            ret = dataGrid.Columns[2].HeaderText + "=" + dataGrid[2, rowIndex].Value.ToString() + "," +
              dataGrid.Columns[3].HeaderText + "=" + dataGrid[3, rowIndex].Value.ToString() + "," +
              dataGrid.Columns[4].HeaderText + "=" + dataGrid[4, rowIndex].Value.ToString() + "," +
              dataGrid.Columns[5].HeaderText + "=" + dataGrid[5, rowIndex].Value.ToString();
            //dataGrid.Columns[6].HeaderText + "=" + dataGrid[6, rowIndex].Value.ToString();
            
            return ret;
        }

        protected string GetSysID()
        {
            DataRowView drv = (DataRowView)bindingSource.Current;
            return drv.Row["GUID"].ToString();

        }
    }
}