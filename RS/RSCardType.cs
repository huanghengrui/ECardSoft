using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmRSCardType : frmBaseMDIChildGrid
    {
        protected override void InitForm()
        {
            formCode = "RSCardType";
            SetToolItemState("ItemImport", false);
            SetToolItemState("ItemExport", false);
            SetToolItemState("ItemPrint", false);
            SetToolItemState("ItemLine1", false);
            SetToolItemState("ItemAdd", false);
            SetToolItemState("ItemDelete", false);
            SetToolItemState("ItemSelect", false);
            SetToolItemState("ItemUnselect", false);
            SetToolItemState("ItemLine4", false);
            AddColumn(0, "CardTypeSysID", true, false, 0);
            AddColumn(0, "CardTypeID", false, 0);
            AddColumn(0, "CardTypeName", false, 0);
            AddColumn(0, "CardFee", false, false, 2, 0);
            AddColumn(0, "CardStored", false, false, 2, 0);
            AddColumn(1, "CardCheckOrder", false, false, 1, 0);
            AddColumn(1, "CardRetirement", false, false, 1, 0);
            AddColumn(1, "CardRefundment", false, false, 1, 0);
            AddColumn(1, "CardRefundmentDev", false, false, 1, 0);
            AddColumn(0, "DepositDiscount", false, false, 0);
            AddColumn(0, "CardRefundmentDiscount", SystemInfo.AllowCheckDepositLimit != 2 && SystemInfo.AllowCheckDepositLimit != 3, false, 0);
            AddColumn(0, "CardDepositLimit", SystemInfo.AllowCheckDepositLimit == 0 || SystemInfo.AllowCheckDepositLimit == 3, false, 2, 0);
            AddColumn(0, "CardDepositTimes", SystemInfo.AllowCheckDepositLimit != 2, false, 2, 0);
            AddColumn(0, "CardDescription", false, false, 200);
            base.InitForm();
            SetColCurrencyFormat("CardFee");
            SetColCurrencyFormat("CardStored");
            SetColCurrencyFormat("CardDepositLimit");
            QuerySQL = Pub.GetSQL(DBCode.DB_000001, new string[] { "203" });
            ExecItemRefresh();
        }

        public frmRSCardType()
        {
            InitializeComponent();
        }

        protected override void ExecItemEdit()
        {
            base.ExecItemEdit();
            frmRSCardTypeAdd frm = new frmRSCardTypeAdd(this.Text, CurrentTool, GetCardTypeSysID());
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
           
        }

        protected string GetCardTypeSysID()
        {
            DataRowView drv = (DataRowView)bindingSource.Current;
            return drv.Row["CardTypeSysID"].ToString();
        }
    }
}