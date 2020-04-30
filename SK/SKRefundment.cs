using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmSKRefundment : frmBaseDialog
  {
    private string CardData10 = "";
    private string CardDataH = "";
    private string CardData8 = "";
    private HSUNFK.TCardPubData pubData = new HSUNFK.TCardPubData();
    private HSUNFK.TCardSKData skData = new HSUNFK.TCardSKData();
    private bool IsWorking = false;
    private bool OkContinue = true;

    protected override void InitForm()
    {
      formCode = "SKRefundment";
      base.InitForm();
      this.Text = Pub.GetResText(formCode, "mnu" + formCode, "", new string[] { "Main" });
      txtMoney.Enter += TextBoxCurrency_Enter;
      txtMoney.Leave += TextBoxCurrency_Leave;
      double d = 0;
      txtMoney.Text = d.ToString(SystemInfo.CurrencySymbol + "0.00");
      txtMoney.Focus();
      OkContinue = SystemInfo.ini.ReadIni("Public", "CardOk", true);
      chkPrint.Checked = SystemInfo.ini.ReadIni("Public", "CheckPrint", false);
    }

    public frmSKRefundment()
    {
      InitializeComponent();
    }

    private void btnReadCard_Click(object sender, EventArgs e)
    {
      ResetForm();
      if (!ReadCard(true)) return;
      Pub.CardBuzzer();
      txtSKCardBalanceSK.Text = skData.Money.ToString(SystemInfo.CurrencySymbol + "0.00");
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (!db.CheckOprtRole(formCode, "M", true)) return;
      if (IsWorking) return;
      IsWorking = true;
      RefreshForm();
      WriteCard();
      IsWorking = false;
      RefreshForm();
      if (!chkEmptyZero.Checked)
      {
        double d = 0;
        txtMoney.Text = d.ToString(SystemInfo.CurrencySymbol + "0.00");
      }
      txtMoney.Focus();
      SystemInfo.ini.WriteIni("Public", "CheckPrint", chkPrint.Checked);
    }

    private void WriteCard()
    {
      ResetForm();
      CurrentOprt = btnOk.Text;
      double money = 0;
      double.TryParse(CurrencyToStringEx(txtMoney.Text), out money);
      if (money <= 0)
      {
        Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorMoneyZero", ""));
        return;
      }
      if (!ReadCard(false)) return;
      DateTime dt = new DateTime();
      if (!db.GetServerDate(this.Text, ref dt)) return;
      txtSKCardBalanceSK.Text = skData.Money.ToString(SystemInfo.CurrencySymbol + "0.00");
      if (skData.Money - money < 0)
      {
        Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorBalanceIsZero", ""));
        return;
      }
      List<string> sql = new List<string>();
      sql.Clear();
      string Title;
      double Amount;
      double ReceivablesAmount;
      double CardBalance;
      string AmountTitle;
      skData.Money -= money;
      double m = -money;
      sql.Add(Pub.GetSQL(DBCode.DB_005001, new string[] { "0", pubData.CardNo, "30", 
        dt.ToString(SystemInfo.SQLDateTimeFMT), m.ToString("0.00"), skData.Money.ToString("0.00"), 
        OprtInfo.OprtSysID }));
      Title = Pub.GetResText(formCode, "RefundmentTitle", "");
      Amount = money;
      ReceivablesAmount = money;
      CardBalance = skData.Money;
      AmountTitle = label6.Text;
      if (db.ExecSQL(sql) != 0) return;
      int cardRet = 0;
      string CardNo10 = "";
      string CardNoH = "";
      string CardNo8 = "";
      skData.CardTime = dt;
    ContinueSK:
      Application.DoEvents();
      CardNo10 = "";
      CardNoH = "";
      CardNo8 = "";
      if (!Pub.CheckCardExists(ref CardNo10, ref CardNoH, ref CardNo8, false))
      {
        lblResult.Text = Pub.GetResText(formCode, "ReadCardError3", "");
        goto ContinueSK;
      }
      if (CardNo10 != CardData10)
      {
        if (OkContinue)
        {
          Pub.ShowErrorMsg(Pub.GetResText(formCode, "MsgCardSame", "") + "\r\n\r\n" +
            Pub.GetResText(formCode, "MsgCardOkContinue", ""));
          goto ContinueSK;
        }
        else
        {
          if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "MsgCardSame", "")))
            return;
          else
            goto ContinueSK;
        }
      }
      cardRet = Pub.WriteCardInfo(skData);
      if (cardRet != 0)
      {
        if (OkContinue)
        {
          Pub.ShowErrorMsg(Pub.GetCardMsg(cardRet) + "\r\n\r\n" + Pub.GetResText(formCode, "MsgCardOkContinue", ""));
          goto ContinueSK;
        }
        else
        {
          if (Pub.MessageBoxShowQuestion(Pub.GetCardMsg(cardRet) + Pub.GetResText(formCode, "MsgContinue", "")))
            return;
          else
            goto ContinueSK;
        }
      }
      txtSKCardBalanceSK.Text = skData.Money.ToString(SystemInfo.CurrencySymbol + "0.00");
      db.WriteSYLog(this.Text, Title, sql);
      Pub.CardBuzzer();
      if (chkPrint.Checked)
      {
        PrintCardBill(Title, Amount, ReceivablesAmount, CardBalance, AmountTitle, pubData.CardNo);
      }
      lblResult.Text = Title + Pub.GetResText(formCode, "MsgSuccess", "");
    }

    private bool ReadCard(bool ReadAll)
    {
      CardData10 = "";
      CardDataH = "";
      CardData8 = "";
      if (!Pub.CheckCardExists(ref CardData10, ref CardDataH, ref CardData8)) return false;
      pubData = new HSUNFK.TCardPubData();
      skData = new HSUNFK.TCardSKData();
      if (!Pub.ReadCardInfo(ref pubData)) return false;
      if (!db.CheckCardExists(pubData.CardNo, CardData10)) return false;
      if (!Pub.ReadCardInfo(ref skData)) return false;
      DataTableReader dr = null;
      bool IsOk = false;
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        if (!db.CheckDepartPowerByCard(pubData.CardNo)) return false;
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "215", pubData.CardNo }));
        if (dr.Read())
        {
          if (Convert.ToInt32(dr["CardStatusID"]) != 20)
          {
            Pub.ShowErrorMsg(Pub.GetResText(formCode, "MsgCardRefunNotNormal", ""));
          }
          else
          {
            txtEmpNo.Text = dr["EmpNo"].ToString();
            txtEmpName.Text = dr["EmpName"].ToString();
            txtDepartName.Text = dr["DepartName"].ToString();
            txtCardSectorNo.Text = dr["CardSectorNo"].ToString();
            txtCardStatusName.Text = dr["CardStatusName"].ToString();
            txtCardType.Text = dr["CardTypeName"].ToString();
            IsOk = true;
          }
        }
        else
        {
          Pub.ShowErrorMsg(Pub.GetResText("", "ErrorIllegalCard", ""));
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
      return IsOk;
    }

    private void ResetForm()
    {
      txtEmpNo.Text = "";
      txtEmpName.Text = "";
      txtDepartName.Text = "";
      txtCardSectorNo.Text = "";
      txtCardStatusName.Text = "";
      txtCardType.Text = "";
      lblResult.Text = "";
    }

    private void frmSKRefundment_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (IsWorking) e.Cancel = true;
    }

    private void RefreshForm()
    {
      gbxEmpInfo.Enabled = !IsWorking;
      label6.Enabled = !IsWorking;
      txtMoney.Enabled = !IsWorking;
      btnReadCard.Enabled = !IsWorking;
      chkPrint.Enabled = !IsWorking;
      chkEmptyZero.Enabled = !IsWorking;
      btnOk.Enabled = !IsWorking;
      btnCancel.Enabled = !IsWorking;
    }
  }
}