using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmSFAllowanceClear : frmBaseDialog
  {
    private string CardData10 = "";
    private string CardDataH = "";
    private string CardData8 = "";
    private QHAPI.TCardPubData pubData = new QHAPI.TCardPubData();
    private QHAPI.TCardSFData sfData = new QHAPI.TCardSFData();
    private bool IsWorking = false;
    private bool OkContinue = true;

    protected override void InitForm()
    {
      formCode = "SFAllowanceClear";
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

    public frmSFAllowanceClear()
    {
      InitializeComponent();
    }

    private void btnReadCard_Click(object sender, EventArgs e)
    {
      ResetForm();
      if (!ReadCard()) return;
      Pub.CardBuzzer();
      double ShowBTMoney = db.GetBTMoney(sfData.BtDate, sfData.BtMonery);
      txtCardBalanceCZ.Text = sfData.Balance.ToString(SystemInfo.CurrencySymbol + "0.00");
      txtCardBalanceBT.Text = ShowBTMoney.ToString(SystemInfo.CurrencySymbol + "0.00");
      txtMoney.Text = txtCardBalanceCZ.Text;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (!db.CheckOprtRole(formCode, "M", true)) return;
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
        Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorMoneyZero", ""));
        return;
      }
      if (!ReadCard()) return;
      DateTime dt = new DateTime();
      if (!db.GetServerDate(ref dt)) return;
      if (!Pub.CheckUseDate(dt, sfData.UseDate)) return;
      Pub.ClearCardLimitInfo(dt, ref sfData);
      double ShowBTMoney = db.GetBTMoney(sfData.BtDate, sfData.BtMonery);
      txtCardBalanceCZ.Text = sfData.Balance.ToString(SystemInfo.CurrencySymbol + "0.00");
      txtCardBalanceBT.Text = ShowBTMoney.ToString(SystemInfo.CurrencySymbol + "0.00");
      if (sfData.Balance < money)
      {
        Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorBalanceNotEnough", ""));
        return;
      }
      sfData.UseDate = dt;
      sfData.UseTimes += 1;
      List<string> sql = new List<string>();
      sql.Clear();
      sfData.Balance -= money;
      double mm = -money;
      sql.Add(Pub.GetSQL(DBCode.DB_004005, new string[] { "0", pubData.CardNo, "0", 
        dt.ToString(SystemInfo.SQLDateTimeFMT), mm.ToString(), sfData.Balance.ToString(), "0", "", "0", 
        sfData.UseTimes.ToString(), OprtInfo.OprtSysID, "", "1", "", CardData10, pubData.MacTAG, "" }));
      string Title = Pub.GetResText(formCode, "RefundmentTitle", "");
      double Amount = money;
      double ReceivablesAmount = money;
      double CardBalance = sfData.Balance;
      string AmountTitle = label6.Text;
      if (db.ExecSQL(sql) != 0) return;
      int cardRet = 0;
      string CardNo10 = "";
      string CardNoH = "";
      string CardNo8 = "";
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
      txtCardBalanceCZ.Text = sfData.Balance.ToString(SystemInfo.CurrencySymbol + "0.00");
      Pub.CardBuzzer();
      if (chkPrint.Checked)
      {
        PrintCardBill(Title, Amount, ReceivablesAmount, CardBalance, AmountTitle, pubData.CardNo);
      }
      lblResult.Text = this.Text + Pub.GetResText(formCode, "MsgSuccess", "");
    }

    private bool ReadCard()
    {
      CardData10 = "";
      CardDataH = "";
      CardData8 = "";
      if (!Pub.CheckCardExists(ref CardData10, ref CardDataH, ref CardData8)) return false;
      pubData = new QHAPI.TCardPubData();
      sfData = new QHAPI.TCardSFData();
      if (!Pub.ReadCardInfo(ref pubData, ref sfData)) return false;
      if (!db.CheckCardExists(pubData.CardNo, CardData10)) return false;
      DateTime dt = new DateTime();
      if (!db.GetServerDate(ref dt)) return false;
      if (!Pub.CheckCardValidDate(dt, pubData.CardBeginDate, pubData.CardEndDate)) return false;
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
            Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgCardRefunNotNormal", ""));
          }
          else
          {
            IsOk = true;
            if (SystemInfo.HasMoreDepositType)
            {
              string SFTypeName = "";
              double SFAmount = 0;
              IsOk = db.SFGetLastSFType(dr["EmpSysID"].ToString(), ref SFTypeName, ref SFAmount);
              if (IsOk && (SFTypeName != ""))
              {
                txtCardBalanceBT.Text = SFTypeName + ":" + SFAmount.ToString(SystemInfo.CurrencySymbol + "0.00");
              }
            }
            if (IsOk)
            {
              txtEmpNo.Text = dr["EmpNo"].ToString();
              txtEmpName.Text = dr["EmpName"].ToString();
              txtDepartName.Text = dr["DepartName"].ToString();
              txtCardSectorNo.Text = dr["CardSectorNo"].ToString();
              txtCardStatusName.Text = dr["CardStatusName"].ToString();
              txtCardType.Text = dr["CardTypeName"].ToString();
            }
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
      txtCardBalanceBT.Text = "";
      lblResult.Text = "";
    }

    private void frmSFAllowanceClear_FormClosing(object sender, FormClosingEventArgs e)
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