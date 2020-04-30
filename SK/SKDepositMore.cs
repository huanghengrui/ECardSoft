using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmSKDepositMore : frmBaseDialog
  {
    private string CardData10 = "";
    private string CardDataH = "";
    private string CardData8 = "";
    private HSUNFK.TCardPubData pubData = new HSUNFK.TCardPubData();
    private HSUNFK.TCardSKData skData = new HSUNFK.TCardSKData();
    private bool IsWorking = false;
    private double money = 0;

    protected override void InitForm()
    {
      formCode = "SKDepositMore";
      base.InitForm();
      this.Text = Pub.GetResText(formCode, "mnu" + formCode, "", new string[] { "Main" });
      txtMoney.Enter += TextBoxCurrency_Enter;
      txtMoney.Leave += TextBoxCurrency_Leave;
      double d = 0;
      txtMoney.Text = d.ToString(SystemInfo.CurrencySymbol + "0.00");
      txtMoney.Focus();
      RefreshForm();
      chkPrint.Checked = SystemInfo.ini.ReadIni("Public", "CheckPrint", false);
    }

    public frmSKDepositMore()
    {
      InitializeComponent();
    }

    private void RefreshForm()
    {
      gbxEmpInfo.Enabled = !IsWorking;
      txtMoney.Enabled = !IsWorking;
      chkPrint.Enabled = !IsWorking;
      btnOk.Enabled = !IsWorking;
      btnOk.Visible = btnOk.Enabled;
      btnReadCard.Enabled = IsWorking;
      btnReadCard.Visible = btnReadCard.Enabled;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (!db.CheckOprtRole(formCode, "M", true)) return;
      if (IsWorking) return;
      CurrentOprt = btnOk.Text;
      double.TryParse(CurrencyToStringEx(txtMoney.Text), out money);
      if (money <= 0)
      {
        Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorMoneyZero", ""));
        return;
      }
      DateTime dt = new DateTime();
      if (!db.GetServerDate(this.Text, ref dt)) return;
      IsWorking = true;
      RefreshForm();
      bool ret = false;
      while (IsWorking)
      {
      LoopNoCard:
        lblResult.Text = Pub.GetResText(formCode, "MsgMoreing", "");
        Application.DoEvents();
        if (!IsWorking) break;
        if (!Pub.CheckCardExists(false))
        {
          lblResult.Text = Pub.GetResText("", "ReadCardError3", "");
          goto LoopNoCard;
        }
        ret = WriteCard();
        if (ret)
          lblResult.Text = Pub.GetResText(formCode, "MsgSuccess", "");
        else
          lblResult.Text = Pub.GetResText(formCode, "MsgFailed", "");
      LoopCard:
        Application.DoEvents();
        if (!IsWorking) break;
        if (Pub.CheckCardExists(false)) goto LoopCard;
      }
      btnReadCard_Click(null, null);
      SystemInfo.ini.WriteIni("Public", "CheckPrint", chkPrint.Checked);
    }

    private void btnReadCard_Click(object sender, EventArgs e)
    {
      IsWorking = false;
      RefreshForm();
    }

    private bool WriteCard()
    {
      ResetForm();
      if (!ReadCard(false)) return false;
      DateTime dt = new DateTime();
      if (!db.GetServerDate(ref dt)) return false;
      txtSKCardBalanceSK.Text = skData.Money.ToString(SystemInfo.CurrencySymbol + "0.00");
      if (!SystemInfo.SKDepositTotal) skData.Money = 0;
      if (skData.Money + money > SystemInfo.MaxDepositSK)
      {
        lblResult.Text = string.Format(Pub.GetResText(formCode, "ErrorBalanceIsBig", ""), SystemInfo.MaxDeposit);
        return false;
      }
      List<string> sql = new List<string>();
      sql.Clear();
      string Title;
      double Amount;
      double ReceivablesAmount;
      double CardBalance;
      string AmountTitle;
      skData.Money += money;
      sql.Add(Pub.GetSQL(DBCode.DB_005001, new string[] { "0", pubData.CardNo, "10", 
        dt.ToString(SystemInfo.SQLDateTimeFMT), money.ToString("0.00"), skData.Money.ToString("0.00"), 
        OprtInfo.OprtSysID }));
      Title = Pub.GetResText(formCode, "DepositTitle", "");
      Amount = money;
      ReceivablesAmount = money;
      CardBalance = skData.Money;
      AmountTitle = label6.Text;
      if (db.ExecSQL(sql) != 0) return false;
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
        lblResult.Text = Pub.GetResText(formCode, "MsgCardSame", "");
        goto ContinueSK;
      }
      cardRet = Pub.WriteCardInfo(skData);
      if (cardRet != 0)
      {
        lblResult.Text = Pub.GetCardMsg(cardRet);
        goto ContinueSK;
      }
      txtSKCardBalanceSK.Text = skData.Money.ToString(SystemInfo.CurrencySymbol + "0.00");
      db.WriteSYLog(this.Text, Title, sql);
      if (chkPrint.Checked)
      {
        PrintCardBill(Title, Amount, ReceivablesAmount, CardBalance, AmountTitle, pubData.CardNo);
      }
      lblResult.Text = Title + Pub.GetResText(formCode, "MsgSuccess", "");
      Pub.CardBuzzer();
      return true;
    }

    private bool ReadCard(bool ReadAll)
    {
      CardData10 = "";
      CardDataH = "";
      CardData8 = "";
      string ErrorMsg = "";
      if (!Pub.CheckCardExists(ref CardData10, ref CardDataH, ref CardData8, false))
      {
        lblResult.Text = Pub.GetResText(formCode, "ReadCardError3", "");
        return false;
      }
      pubData = new HSUNFK.TCardPubData();
      skData = new HSUNFK.TCardSKData();
      if (!Pub.ReadCardInfo(ref pubData, ref ErrorMsg))
      {
        lblResult.Text = ErrorMsg;
        return false;
      }
      if (!db.CheckCardExists(pubData.CardNo, CardData10)) return false;
      if (!Pub.ReadCardInfo(ref skData, ref ErrorMsg))
      {
        lblResult.Text = ErrorMsg;
        return false;
      }
      DataTableReader dr = null;
      bool IsOk = false;
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        if (!db.CheckDepartPowerByCard(pubData.CardNo, ref ErrorMsg))
        {
          lblResult.Text = ErrorMsg;
          return false;
        }
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "215", pubData.CardNo }));
        if (dr.Read())
        {
          if (Convert.ToInt32(dr["CardStatusID"]) != 20)
          {
            lblResult.Text = Pub.GetResText(formCode, "MsgCardDepositNotNormal", "");
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
          lblResult.Text = Pub.GetResText("", "ErrorIllegalCard", "");
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

    private void frmSKDepositMore_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (IsWorking) e.Cancel = true;
    }
  }
}