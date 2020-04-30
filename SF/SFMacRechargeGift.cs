using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSFMacRechargeGift : frmBaseDialog
    {
        protected override void InitForm()
        {
            formCode = "SFMacRechargeGift";
            base.InitForm();

            this.Text = Title + "[" + CurrentOprt + "]";
            SetTextboxNumber(txtRate);
            cbbCardType.Items.Clear();
            GetCardTypeList();
            for (int i = 0; i < cardTypeList.Count; i++)
            {
                cbbCardType.Items.Add(cardTypeList[i]);
            }
            cbbCardType.Text = cbbCardType.Items[0].ToString();
            txtRate.Text = "0";
            label1.Text = Pub.GetResText(formCode, "lblCardType", "");
            label2.Text = Pub.GetResText(formCode, "DepositDiscount", "");
            label3.Text = Pub.GetResText(formCode, "DepositMoney", "");
            label4.Text = Pub.GetResText(formCode, "DiscDiscount", "");
            TextBox txt1;
            TextBox txt2;
            for (int i = 0; i < 5; i++)
            {
                txt1 = (TextBox)panel1.Controls[string.Format("txtValue2{0}", i + 1)];
                txt2 = (TextBox)panel1.Controls[string.Format("txtGift3{0}", i + 1)];
                txt1.Enter += TextBoxCurrency_Enter;
                txt1.Leave += TextBoxCurrency_Leave;

                txt2.Enter += TextBoxCurrency_Enter;
                txt2.Leave += TextBoxCurrency_Leave;

            }

            LoadData();
        }

        public frmSFMacRechargeGift(string title, string CurrentTool, string GUID)
        {
            Title = title;
            CurrentOprt = CurrentTool;
            SysID = GUID;
            InitializeComponent();
        }

        private void LoadData()
        {
            DataTableReader dr = null;
            string rechargegiftStr = "";
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004004, new string[] { "7", SysID }));
                if (dr.Read()) rechargegiftStr = dr["TFeeRechargeGift"].ToString();
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
            TFeeRechargeGift rechargegift = new TFeeRechargeGift(rechargegiftStr);
            cbbCardType.Text = cbbCardType.Items[rechargegift.CardType].ToString();
            txtRate.Text = rechargegift.Rate.ToString();
            TextBox txt;
            for (int i = 0; i < 5; i++)
            {
                txt = (TextBox)panel1.Controls[string.Format("txtValue2{0}", i + 1)];
                txt.Text = rechargegift.Value[i].ToString(SystemInfo.CurrencySymbol + "0.00");
                txt = (TextBox)panel1.Controls[string.Format("txtGift3{0}", i + 1)];
                txt.Text = rechargegift.Gift[i].ToString(SystemInfo.CurrencySymbol + "0.00");
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int Deposit = 0;
            if (Pub.IsNumeric(txtRate.Text.Trim())) Deposit = Convert.ToInt32(txtRate.Text.Trim());
            if (Deposit < 0)
            {
                txtRate.Focus();
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error003", ""));
                return;
            }
            TextBox txt;
            for (int i = 0; i < 5; i++)
            {
                txt = (TextBox)panel1.Controls[string.Format("txtValue2{0}", i + 1)];
                if (txt.Text == "")
                    txt.Text = "0";
                txt = (TextBox)panel1.Controls[string.Format("txtGift3{0}", i + 1)];
                if (txt.Text == "")
                    txt.Text = "0";
            }
            string rechargegiftStr = "";
            string result = System.Text.RegularExpressions.Regex.Replace(cbbCardType.Text, @"[^0-9]+", "");
            rechargegiftStr = result + "#";
            rechargegiftStr += txtRate.Text + "#";
            for (int i = 0; i < 5; i++)
            {
                txt = (TextBox)panel1.Controls[string.Format("txtValue2{0}", i + 1)];
                rechargegiftStr += CurrencyToStringEx(txt.Text) + "#";
            }
            for (int i = 0; i < 5; i++)
            {
                txt = (TextBox)panel1.Controls[string.Format("txtGift3{0}", i + 1)];
                rechargegiftStr += CurrencyToStringEx(txt.Text) + "#";
            }

            string sql = Pub.GetSQL(DBCode.DB_004004, new string[] { "125", rechargegiftStr, SysID });
            try
            {
                db.ExecSQL(sql);
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E, sql);
                return;
            }
            db.WriteSYLog(this.Text, CurrentOprt, sql);
            Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}