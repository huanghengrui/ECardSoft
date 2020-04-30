using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmSKDeposit : frmBaseDialog
  {
    private string CardData10 = "";
    private string CardDataH = "";
    private string CardData8 = "";
    private QHAPI.TCardPubData pubData = new QHAPI.TCardPubData();
    private QHAPI.TCardSFData sfData = new QHAPI.TCardSFData();
    private QHAPI.TCardSKData skData = new QHAPI.TCardSKData();
    private bool IsWorking = false;
    private bool OkContinue = true;

    protected override void InitForm()
    {
      formCode = "SKDeposit";
      base.InitForm();
      this.Text = Pub.GetResText(formCode, "mnu" + formCode, "", new string[] { "Main" });
      txtDepositMoney.Enter += TextBoxCurrency_Enter;
      txtDepositMoney.Leave += TextBoxCurrency_Leave;
      txtTransferAmount.Enter += TextBoxCurrency_Enter;
      txtTransferAmount.Leave += TextBoxCurrency_Leave;
      double d = 0;
      txtDepositMoney.Text = d.ToString(SystemInfo.CurrencySymbol + "0.00");
      txtTransferAmount.Text = txtDepositMoney.Text;
      txtDepositMoney.Focus();
      OkContinue = SystemInfo.ini.ReadIni("Public", "CardOk", true);
      chkPrint.Checked = SystemInfo.ini.ReadIni("Public", "CheckPrint", false);
    }

    public frmSKDeposit()
    {
      InitializeComponent();
    }

    private void btnReadCard_Click(object sender, EventArgs e)
    {
      ResetForm();
      if (!ReadCard(true)) return;
      Pub.CardBuzzer();
      txtSKCardBalanceSK.Text = skData.Money.ToString(SystemInfo.CurrencySymbol + "0.00");
      double ShowBTMoney = db.GetBTMoney(sfData.BtDate, sfData.BtMonery);
      double AllBalance = sfData.Balance + ShowBTMoney;
      txtSKCardBalanceSF.Text = AllBalance.ToString(SystemInfo.CurrencySymbol + "0.00");
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
        txtDepositMoney.Text = d.ToString(SystemInfo.CurrencySymbol + "0.00");
        txtTransferAmount.Text = txtDepositMoney.Text;
      }
      if (tabControl1.SelectedIndex == 0)
        txtDepositMoney.Focus();
      else
        txtTransferAmount.Focus();
      SystemInfo.ini.WriteIni("Public", "CheckPrint", chkPrint.Checked);
    }

    private void WriteCard()
    {
      ResetForm();
      CurrentOprt = btnOk.Text;
      double money = 0;
      string cap = tabControl1.SelectedTab.Text;
      if (tabControl1.SelectedIndex == 0)
        double.TryParse(CurrencyToStringEx(txtDepositMoney.Text), out money);
      else
        double.TryParse(CurrencyToStringEx(txtTransferAmount.Text), out money);
      if (money <= 0)
      {
        Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorMoneyZero", ""));
        return;
      }
      if (!ReadCard(false)) return;
      DateTime dt = new DateTime();
      if (!db.GetServerDate(this.Text, ref dt)) return;
      if (tabControl1.SelectedIndex == 1)
      {
        if (!Pub.CheckUseDate(dt, sfData.UseDate)) return;
      }
      txtSKCardBalanceSK.Text = skData.Money.ToString(SystemInfo.CurrencySymbol + "0.00");
      if (!SystemInfo.SKDepositTotal) skData.Money = 0;
      if (skData.Money + money > SystemInfo.MaxDepositSK)
      {
        Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "ErrorBalanceIsBig", ""), SystemInfo.MaxDeposit));
        return;
      }
      List<string> sql = new List<string>();
      double AllBalance = 0;
      sql.Clear();
      string[] Title;
      double[] Amount;
      double[] ReceivablesAmount;
      double[] CardBalance;
      string[] AmountTitle;
      if (tabControl1.SelectedIndex == 0)
      {
        skData.Money += money;
        sql.Add(Pub.GetSQL(DBCode.DB_005001, new string[] { "0", pubData.CardNo, "10", 
          dt.ToString(SystemInfo.SQLDateTimeFMT), money.ToString("0.00"), skData.Money.ToString("0.00"), 
          OprtInfo.OprtSysID }));
        Title = new string[1] { Pub.GetResText(formCode, "DepositTitle", "") };
        Amount = new double[1] { money };
        ReceivablesAmount = new double[1] { money };
        CardBalance = new double[1] { skData.Money };
        AmountTitle = new string[1] { label6.Text };
      }
      else
      {
        double ShowBTMoney = db.GetBTMoney(sfData.BtDate, sfData.BtMonery);
        AllBalance = sfData.Balance + ShowBTMoney;
        txtSKCardBalanceSF.Text = AllBalance.ToString(SystemInfo.CurrencySymbol + "0.00");
        if (AllBalance < money)
        {
          Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorBalanceNotEnough", ""));
          return;
        }
        skData.Money += money;
        sfData.UseDate = dt;
        sfData.UseTimes += 1;
        sql.Add(Pub.GetSQL(DBCode.DB_005001, new string[] { "0", pubData.CardNo, "20", 
          dt.ToString(SystemInfo.SQLDateTimeFMT), money.ToString(), skData.Money.ToString(), OprtInfo.OprtSysID }));
        if (ShowBTMoney == 0)
        {
          sfData.Balance -= money;
          if (sfData.BtMonery > 0)
          {
            double m = -sfData.BtMonery;
            sql.Add(Pub.GetSQL(DBCode.DB_004005, new string[] { "0", pubData.CardNo, "0", 
              dt.ToString(SystemInfo.SQLDateTimeFMT), m.ToString(), AllBalance.ToString(), "0", "", "0", 
              sfData.UseTimes.ToString(), OprtInfo.OprtSysID, "", "1", "", CardData10, pubData.MacTAG, "" }));
            sfData.UseTimes += 1;
            sfData.BtMonery = 0;
          }
        }
        else
        {
          sfData.BtMonery -= money;
          if (sfData.BtMonery < 0)
          {
            sfData.Balance += sfData.BtMonery;
            sfData.BtMonery = 0;
          }
        }
        AllBalance -= money;
        double mm = -money;
        sql.Add(Pub.GetSQL(DBCode.DB_004005, new string[] { "0", pubData.CardNo, "20", 
          dt.ToString(SystemInfo.SQLDateTimeFMT), mm.ToString(SystemInfo.SQLDateTimeFMT), 
          AllBalance.ToString(), "0", "", "0", sfData.UseTimes.ToString(), OprtInfo.OprtSysID, 
          "", "1", "", CardData10, pubData.MacTAG, "" }));
        Title = new string[2] { Pub.GetResText(formCode, "DepositTitle", ""), 
          Pub.GetResText(formCode, "RefundmentTitle", "") };
        Amount = new double[2] { money, money };
        ReceivablesAmount = new double[2] { money, money };
        CardBalance = new double[2] { skData.Money, AllBalance };
        AmountTitle = new string[2] { label6.Text, Pub.GetResText(formCode, "RefundmentMoney", "") };
      }
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
          Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgCardSame", "") + "\r\n\r\n" +
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
        if (Pub.MessageBoxShowQuestion(Pub.GetCardMsg(cardRet) + Pub.GetResText(formCode, "MsgContinue", "")))
          return;
        else
          goto ContinueSK;
      }
      if (tabControl1.SelectedIndex == 1)
      {
        bool IsSFError = false;
      ContinueSF:
        Application.DoEvents();
        if (IsSFError)
        {
          CardNo10 = "";
          CardNoH = "";
          CardNo8 = "";
          if (!Pub.CheckCardExists(ref CardNo10, ref CardNoH, ref CardNo8, false))
          {
            lblResult.Text = Pub.GetResText(formCode, "ReadCardError3", "");
            goto ContinueSF;
          }
          if (CardNo10 != CardData10)
          {
            if (OkContinue)
            {
              Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgCardSame", "") + "\r\n\r\n" +
                Pub.GetResText(formCode, "MsgCardOkContinue", ""));
              goto ContinueSF;
            }
            else
            {
              if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "MsgCardSame", "")))
                return;
              else
                goto ContinueSF;
            }
          }
          IsSFError = false;
        }
        cardRet = Pub.WriteCardInfo(sfData);
        if (cardRet != 0)
        {
          if (OkContinue)
          {
            Pub.MessageBoxShow(Pub.GetCardMsg(cardRet) + "\r\n\r\n" + Pub.GetResText(formCode, "MsgCardOkContinue", ""));
            IsSFError = true;
            goto ContinueSF;
          }
          else
          {
            if (Pub.MessageBoxShowQuestion(Pub.GetCardMsg(cardRet) + Pub.GetResText(formCode, "MsgContinue", "")))
              return;
            else
            {
              IsSFError = true;
              goto ContinueSF;
            }
          }
        }
      }
      txtSKCardBalanceSK.Text = skData.Money.ToString(SystemInfo.CurrencySymbol + "0.00");
      txtSKCardBalanceSF.Text = AllBalance.ToString(SystemInfo.CurrencySymbol + "0.00");
      db.WriteSYLog(this.Text, cap, sql);
      Pub.CardBuzzer();
      if (chkPrint.Checked)
      {
        PrintCardBill(Title, Amount, ReceivablesAmount, CardBalance, AmountTitle, pubData.CardNo);
      }
      lblResult.Text = cap + Pub.GetResText(formCode, "MsgSuccess", "");
    }

    private bool ReadCard(bool ReadAll)
    {
      CardData10 = "";
      CardDataH = "";
      CardData8 = "";
      if (!Pub.CheckCardExists(ref CardData10, ref CardDataH, ref CardData8)) return false;
      pubData = new QHAPI.TCardPubData();
      sfData = new QHAPI.TCardSFData();
      skData = new QHAPI.TCardSKData();
      if ((tabControl1.SelectedIndex == 0) && !ReadAll)
      {
        if (!Pub.ReadCardInfo(ref pubData)) return false;
        if (!Pub.ReadCardInfo(ref skData)) return false;
      }
      else
      {
        if (!Pub.ReadCardInfo(ref pubData, ref sfData)) return false;
        if (!Pub.ReadCardInfo(ref skData)) return false;
      }
      if (!db.CheckCardExists(pubData.CardNo, CardData10)) return false;
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
            Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgCardDepositNotNormal", ""));
          }
          else if (tabControl1.SelectedIndex != 0 && !Convert.ToBoolean(dr["CardRefundment"].ToString()))
          {
            Pub.MessageBoxShow(string.Format(Pub.GetResText("", "ErrorCardRefundment", ""),
              dr["CardTypeName"].ToString()));
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
          Pub.MessageBoxShow(Pub.GetResText("", "ErrorIllegalCard", ""));
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

    private void frmSKDeposit_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (IsWorking) e.Cancel = true;
    }

    private void RefreshForm()
    {
      gbxEmpInfo.Enabled = !IsWorking;
      tabControl1.Enabled = !IsWorking;
      btnReadCard.Enabled = !IsWorking;
      chkPrint.Enabled = !IsWorking;
      chkEmptyZero.Enabled = !IsWorking;
      btnOk.Enabled = !IsWorking;
      btnCancel.Enabled = !IsWorking;
    }

    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (tabControl1.SelectedIndex == 0)
        txtDepositMoney.Focus();
      else
        txtTransferAmount.Focus();
    }
  }
}