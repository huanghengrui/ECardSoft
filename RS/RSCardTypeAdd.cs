using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmRSCardTypeAdd : frmBaseDialog
    {
        protected override void InitForm()
        {
            formCode = "RSCardTypeAdd";
            base.InitForm();
            this.Text = Title + "[" + CurrentOprt + "]";
            txtFee.Enter += TextBoxCurrency_Enter;
            txtFee.Leave += TextBoxCurrency_Leave;
            txtStored.Enter += TextBoxCurrency_Enter;
            txtStored.Leave += TextBoxCurrency_Leave;
            SetTextboxNumber(txtDeposit);
            LoadData();
            lblHint.ForeColor = Color.Blue;
            if (SystemInfo.AllowCheckDepositLimit == 0)
            {
                Height = 370;
                label7.Enabled = false;
                txtDepositLimit.Enabled = false;
                label7.Visible = false;
                txtDepositLimit.Visible = false;
                label9.Enabled = false;
                txtDepositTimes.Enabled = false;
                label8.Enabled = false;
                txtRefundment.Enabled = false;
                label9.Visible = false;
                txtDepositTimes.Visible = false;
                label8.Visible = false;
                txtRefundment.Visible = false;
            }
            else if (SystemInfo.AllowCheckDepositLimit == 1)
            {
                Height = 400;
                label9.Enabled = false;
                txtDepositTimes.Enabled = false;
                label8.Enabled = false;
                txtRefundment.Enabled = false;
                label9.Visible = false;
                txtDepositTimes.Visible = false;
                label8.Visible = false;
                txtRefundment.Visible = false;
                label7.Top = label8.Top;
                txtDepositLimit.Top = txtRefundment.Top;
            }
            else if (SystemInfo.AllowCheckDepositLimit == 3)
            {
                Height = 400;
                label7.Enabled = false;
                txtDepositLimit.Enabled = false;
                label7.Visible = false;
                txtDepositLimit.Visible = false;
                label9.Enabled = false;
                txtDepositTimes.Enabled = false;
                label9.Visible = false;
                txtDepositTimes.Visible = false;
            }
        }

        public frmRSCardTypeAdd(string title, string CurrentTool, string GUID)
        {
            Title = title;
            CurrentOprt = CurrentTool;
            SysID = GUID;
            InitializeComponent();
        }

        private void LoadData()
        {
            DataTableReader dr = null;
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001001, new string[] { "0", SysID }));
                if (dr.Read())
                {
                    txtID.Text = dr["CardTypeID"].ToString();
                    txtName.Text = dr["CardTypeName"].ToString();
                    txtFee.Text = CurrencyToString(dr["CardFee"].ToString());
                    txtStored.Text = CurrencyToString(dr["CardStored"].ToString());
                    chkCheckOrder.Checked = Convert.ToBoolean(dr["CardCheckOrder"].ToString());
                    chkCardRetirement.Checked = Convert.ToBoolean(dr["CardRetirement"].ToString());
                    chkCardRefundment.Checked = Convert.ToBoolean(dr["CardRefundment"].ToString());
                    chkCardRefundmentDev.Checked = Convert.ToBoolean(dr["CardRefundmentDev"].ToString());
                    txtDeposit.Text = dr["DepositDiscount"].ToString();
                    txtRefundment.Text = dr["CardRefundmentDiscount"].ToString();
                    txtDepositLimit.Text = CurrencyToString(dr["CardDepositLimit"].ToString());
                    txtDepositTimes.Text = dr["CardDepositTimes"].ToString();
                    txtDesc.Text = dr["CardDescription"].ToString();
                }
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            DataTableReader dr = null;
            bool IsOk = false;
            string sql = "";
            string name = txtName.Text.Trim();
            if (!Pub.CheckTextMaxLength(label2.Text, name, txtName.MaxLength))
            {
                txtName.Focus();
                return;
            }
            string desc = txtDesc.Text.Trim();
            if (!Pub.CheckTextMaxLength(label6.Text, desc, txtDesc.MaxLength))
            {
                txtDesc.Focus();
                return;
            }
            string fee = CurrencyToStringEx(txtFee.Text);
            string Stored = CurrencyToStringEx(txtStored.Text);
            string DepositLimit = "0.00";
            if (Convert.ToDecimal(fee) < 0)
            {
                txtFee.Focus();
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", ""));
                return;
            }
            if ((Convert.ToDecimal(Stored) < 0) || (Convert.ToDecimal(Stored) > 1000))
            {
                txtStored.Focus();
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error002", ""));
                return;
            }
            if (txtDepositLimit.Enabled)
            {
                DepositLimit = CurrencyToStringEx(txtDepositLimit.Text);
                if (SystemInfo.AllowCheckDepositLimit == 1)
                {
                    if ((Convert.ToDecimal(DepositLimit) < 0) || (Convert.ToDouble(DepositLimit) > SystemInfo.MaxDeposit))
                    {
                        txtDepositLimit.Focus();
                        Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error004", ""));
                        return;
                    }
                }
            }
            string CheckOrder = Convert.ToByte(chkCheckOrder.Checked).ToString();
            string CardRetirement = Convert.ToByte(chkCardRetirement.Checked).ToString();
            string CardRefundment = Convert.ToByte(chkCardRefundment.Checked).ToString();
            string CardRefundmentDev = Convert.ToByte(chkCardRefundmentDev.Checked).ToString();
            int Deposit = 0;
            if (Pub.IsNumeric(txtDeposit.Text.Trim())) Deposit = Convert.ToInt32(txtDeposit.Text.Trim());
            if (Deposit < 0)
            {
                txtDeposit.Focus();
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error003", ""));
                return;
            }
            int Refundment = 0;
            if (txtRefundment.Enabled)
            {
                if (Pub.IsNumeric(txtRefundment.Text.Trim())) Refundment = Convert.ToInt32(txtRefundment.Text.Trim());
                if (Refundment < 0)
                {
                    txtRefundment.Focus();
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error005", ""));
                    return;
                }
            }
            int DepositTimes = 0;
            if (txtDepositTimes.Enabled)
            {
                if (Pub.IsNumeric(txtRefundment.Text.Trim())) DepositTimes = Convert.ToInt32(txtDepositTimes.Text.Trim());
                if (DepositTimes < 0)
                {
                    txtDepositTimes.Focus();
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error006", ""));
                    return;
                }
            }
            try
            {
                sql = Pub.GetSQL(DBCode.DB_001001, new string[] { "1", name, fee, Stored, CheckOrder, CardRetirement,
          CardRefundment, CardRefundmentDev, Deposit.ToString(), Refundment.ToString(), DepositLimit,
          DepositTimes.ToString(), desc, SysID });
                db.ExecSQL(sql);
                IsOk = true;
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
            if (IsOk)
            {
                db.WriteSYLog(this.Text, CurrentOprt, sql);
                Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
           
        }
       
  }
}