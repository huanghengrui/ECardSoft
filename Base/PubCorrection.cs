using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace ECard78
{
    public partial class frmPubCorrection : frmBaseDialog
    {

        public double Money = 0.00;
        public double MoneyBT = 0.00;

        protected override void InitForm()
        {
            formCode = "PubCorrection";
            base.InitForm();
            this.Text = this.Text + Pub.GetResText(formCode, "btnErrorCorrection", "");
            txtMoney.Enter += TextBoxCurrency_Enter;
            txtMoney.Leave += TextBoxCurrency_Leave;
            double d = SystemInfo.DefDepositMoney;
            txtMoney.Text = d.ToString(SystemInfo.CurrencySymbol + "0.00");
            txtMoneyBT.Enter += TextBoxCurrency_Enter;
            txtMoneyBT.Leave += TextBoxCurrency_Leave;
            double dBT = SystemInfo.DefDepositMoney;
            txtMoneyBT.Text = dBT.ToString(SystemInfo.CurrencySymbol + "0.00");
        }

        public frmPubCorrection(double money, double moneybt)
        {
            Money = money;
            MoneyBT = moneybt;
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            double M = 0.00;
            double MBT = 0.00;
            double.TryParse(CurrencyToStringEx(txtMoney.Text), out M);
            double.TryParse(CurrencyToStringEx(txtMoneyBT.Text), out MBT);
            if (M < 0)
            {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "Error001", ""), MessageBoxIcon.Error);
                txtMoney.Focus();
                return;
            }
            else if (M > Money)
            {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "Error002", ""), MessageBoxIcon.Error);
                txtMoney.Focus();
                return;
            }

            if (MBT < 0)
            {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "Error001", ""), MessageBoxIcon.Error);
                txtMoneyBT.Focus();
                return;
            }
            else if (MBT > MoneyBT)
            {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "Error002", ""), MessageBoxIcon.Error);
                txtMoneyBT.Focus();
                return;
            }

            Money = M;
            MoneyBT = MBT;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}