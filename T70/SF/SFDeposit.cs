using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmSFDeposit : frmBaseDialog
  {
    private string CardData10 = "";
    private string CardDataH = "";
    private string CardData8 = "";
    private QHAPI.TCardPubData pubData = new QHAPI.TCardPubData();
    private QHAPI.TCardSFData sfData = new QHAPI.TCardSFData();
    private bool IsWorking = false;
    private int Discount = 0;
    private bool ExistsDepositType = false;
    private bool OkContinue = true;
    private TMobileInfo MobileInfo;
    private bool AllowPayCode = false;
    private bool AllowPayUSB = false;

    protected override void InitForm()
    {
      formCode = "SFDeposit";
      base.InitForm();
      this.Text = Pub.GetResText(formCode, "mnu" + formCode, "", new string[] { "Main" });
      txtMoney.Enter += TextBoxCurrency_Enter;
      txtMoney.Leave += TextBoxCurrency_Leave;
      double d = 0;
      txtMoney.Text = d.ToString(SystemInfo.CurrencySymbol + "0.00");
      ExistsDepositType = SystemInfo.HasMoreDepositType;
      if (ExistsDepositType)
      {
        cbbType.Items.Clear();
        DataTableReader dr = null;
        try
        {
          if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004013, new string[] { "102" }));
          dr.Read();
          cbbType.Items.Add(new TCommonType(dr["SFTypeSysID"].ToString(), dr["SFTypeID"].ToString(),
              dr["SFTypeName"].ToString(), true));
          dr.Close();
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004013, new string[] { "0" }));
          while (dr.Read())
          {
            cbbType.Items.Add(new TCommonType(dr["GUID"].ToString(), dr["DepositTypeID"].ToString(),
              dr["DepositTypeName"].ToString(), true));
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
        if (cbbType.Items.Count > 0) cbbType.SelectedIndex = 0;
        if (cbbType.Items.Count == 1) ExistsDepositType = false;
      }
      cbbType.Enabled = ExistsDepositType;
      cbbType.Visible = cbbType.Enabled;
      label7.Visible = cbbType.Enabled;
      txtMoney.Focus();
      toolTip.SetToolTip(picDisc, Pub.GetResText(formCode, "DiscHint", ""));
      OkContinue = SystemInfo.ini.ReadIni("Public", "CardOk", true);
      lblShowMoney.Font = new Font(Font.Name, 35, FontStyle.Bold);
      lblShowMoney.ForeColor = Color.Red;
      chkPrint.Checked = SystemInfo.ini.ReadIni("Public", "CheckPrint", false);
      AllowPayCode = SystemInfo.ini.ReadIni("Public", "AllowPayCode", false);
      AllowPayUSB = SystemInfo.ini.ReadIni("Public", "AllowPayUSB", false);
      if (AllowPayCode) chkPayCode.Checked = SystemInfo.ini.ReadIni("Public", "PayCode", false);
      if (AllowPayUSB) chkPayCodeUSB.Checked = SystemInfo.ini.ReadIni("Public", "PayCodeUSB", false);
      MobileInfo = new TMobileInfo("");
      DeviceObject.objCard.MobileInit(MobileInfo.MobTyp, MobileInfo.MercID, MobileInfo.TrmNo, MobileInfo.PWD, MobileInfo.XJLName, MobileInfo.XJLPWD);
      Pub.InitCommList(cbbCommPort);
      cbbCommPort.Text = SystemInfo.ini.ReadIni("Public", "PayComm", "");
      if (cbbCommPort.SelectedIndex == -1) cbbCommPort.SelectedIndex = 0;
      DeviceObject.objCard.MobilePayCodeInit();
    }

    protected override void FreeForm()
    {
      DeviceObject.objCard.MobilePayCodeFree();
      base.FreeForm();
    }

    public frmSFDeposit()
    {
      InitializeComponent();
    }

    private void btnReadCard_Click(object sender, EventArgs e)
    {
      ResetForm();
      if (!ReadCard()) return;
      Pub.CardBuzzer();
      double ShowBTMoney = db.GetBTMoney(sfData.BtDate, sfData.BtMonery);
      double AllBalance = sfData.Balance + ShowBTMoney;
      txtCardBalance.Text = AllBalance.ToString(SystemInfo.CurrencySymbol + "0.00");
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
      if (chkPayCode.Enabled) SystemInfo.ini.WriteIni("Public", "PayCode", chkPayCode.Checked);
      if (chkPayCodeUSB.Enabled) SystemInfo.ini.WriteIni("Public", "PayCodeUSB", chkPayCodeUSB.Checked);
      if (cbbCommPort.Enabled) SystemInfo.ini.ReadIni("Public", "PayComm", cbbCommPort.Text);
    }

    private void WriteCard()
    {
      ResetForm();
      CurrentOprt = btnOk.Text;
      string AmountTitle = label6.Text;
      string DepositType = "10";
      if (ExistsDepositType)
      {
        DepositType = ((TCommonType)cbbType.Items[cbbType.SelectedIndex]).id;
        AmountTitle = cbbType.Text;
      }
      double money = 0;
      double Fact = 0;
      double DiscountMoney = 0;
      int DiscountType = 0;
      double.TryParse(CurrencyToStringEx(txtMoney.Text), out money);
      if (money <= 0)
      {
        Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorMoneyZero", ""));
        return;
      }
      double MobileMoney = money;
      if (DepositType == "100" || DepositType == "101")
      {
        money -= MobileInfo.RateMoney(DepositType == "100", MobileMoney);
      }
      Fact = money;
      if (!ReadCard()) return;
      DateTime dt = new DateTime();
      if (!db.GetServerDate(this.Text, ref dt)) return;
      if (!Pub.CheckUseDate(dt, sfData.UseDate)) return;
      Pub.ClearCardLimitInfo(dt, ref sfData);
      double ShowBTMoney = db.GetBTMoney(sfData.BtDate, sfData.BtMonery);
      double AllBalance = sfData.Balance + ShowBTMoney;
      txtCardBalance.Text = AllBalance.ToString(SystemInfo.CurrencySymbol + "0.00");
      double tmpMoney = 0;
      byte DiscFlag = db.GetDiscDiscount(money, pubData.CardTypeID, ref tmpMoney);
      if (DiscFlag == 2) return;
      if (DiscFlag == 1)
      {
        DiscountMoney = tmpMoney;
        Fact = money + DiscountMoney;
        DiscountType = 80;
      }
      else if ((Discount > 0) && (Discount != 100))
      {
        DiscountMoney = money * Discount / 100;
        DiscountMoney = DiscountMoney - money;
        Fact = money + DiscountMoney;
        if (DiscountMoney > 0)
          DiscountType = 80;
        else
          DiscountType = 70;
      }
      if (AllBalance + Fact > SystemInfo.MaxDeposit)
      {
        Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "ErrorBalanceIsBig", ""), SystemInfo.MaxDeposit));
        return;
      }
      if (DepositType == "100" || DepositType == "101")
      {
        int h = SystemInfo.MainHandle.ToInt32();
        bool IsWeiXin = DepositType == "100", ret;
        string ErrMsg = "";
        if (chkPayCode.Checked)
        {
          DeviceObject.objCard.MobilePayCodeSet(cbbCommPort.Text);
          ret = DeviceObject.objCard.MobilePayCode(h, chkPayCodeUSB.Checked, CardData10, pubData.CardNo, MobileMoney, ref IsWeiXin, true, ref ErrMsg);
        }
        else
          ret = DeviceObject.objCard.MobileShow(h, CardData10, pubData.CardNo, MobileMoney, ref IsWeiXin, true, ref ErrMsg);
        if (!ret)
        {
          Pub.MessageBoxShow(ErrMsg);
          return;
        }
        DepositType = IsWeiXin ? "100" : "101";
      }
      List<string> sql = new List<string>();
      sql.Clear();
      string Title = Pub.GetResText(formCode, "DepositTitle", "");
      double Amount = money;
      double ReceivablesAmount = Fact;
      double CardBalance = AllBalance + Fact;
      sfData.Balance = sfData.Balance + money;
      sfData.UseTimes = sfData.UseTimes + 1;
      sfData.UseDate = dt;
      double mm = sfData.Balance + sfData.BtMonery;
      sql.Add(Pub.GetSQL(DBCode.DB_004005, new string[] { "0", pubData.CardNo, DepositType, 
        dt.ToString(SystemInfo.SQLDateTimeFMT), money.ToString(), mm.ToString(), "0", "", "0", 
        sfData.UseTimes.ToString(), OprtInfo.OprtSysID, "", "1", "", CardData10, pubData.MacTAG, "" }));
      if (DiscountMoney != 0)
      {
        sfData.Balance = sfData.Balance + DiscountMoney;
        sfData.UseTimes = sfData.UseTimes + 1;
        mm = sfData.Balance + sfData.BtMonery;
        sql.Add(Pub.GetSQL(DBCode.DB_004005, new string[] { "0", pubData.CardNo, DiscountType.ToString(), 
          dt.AddSeconds(1).ToString(SystemInfo.SQLDateTimeFMT), DiscountMoney.ToString(), mm.ToString(), 
          "0", "", "0", sfData.UseTimes.ToString(), OprtInfo.OprtSysID, "", "1", "", CardData10, pubData.MacTAG, "" }));
      }
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
      double temp = sfData.Balance + db.GetBTMoney(sfData.BtDate, sfData.BtMonery);
      txtCardBalance.Text = temp.ToString(SystemInfo.CurrencySymbol + "0.00");
      Pub.CardBuzzer();
      DispExtScreen(Amount, temp, 0, 1);
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
            Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgCardDepositNotNormal", ""));
          }
          else
          {
            txtEmpNo.Text = dr["EmpNo"].ToString();
            txtEmpName.Text = dr["EmpName"].ToString();
            txtDepartName.Text = dr["DepartName"].ToString();
            txtCardSectorNo.Text = dr["CardSectorNo"].ToString();
            txtCardStatusName.Text = dr["CardStatusName"].ToString();
            txtCardType.Text = dr["CardTypeName"].ToString();
            int.TryParse(dr["DepositDiscount"].ToString(), out Discount);
            txtDepositDiscount.Text = Discount.ToString();
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
      txtDepositDiscount.Text = "";
      lblResult.Text = "";
    }

    private void frmSFDeposit_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (IsWorking) e.Cancel = true;
    }

    private void RefreshForm()
    {
      gbxEmpInfo.Enabled = !IsWorking;
      label6.Enabled = !IsWorking;
      txtMoney.Enabled = !IsWorking;
      cbbType.Enabled = !IsWorking && cbbType.Visible;
      btnReadCard.Enabled = !IsWorking;
      chkPrint.Enabled = !IsWorking;
      chkEmptyZero.Enabled = !IsWorking;
      btnOk.Enabled = !IsWorking;
      btnCancel.Enabled = !IsWorking;
    }

    private void picDisc_Click(object sender, EventArgs e)
    {
      string DiscHint = "";
      if (db.GetDiscHint(ref DiscHint)) Pub.MessageBoxShow(DiscHint, MessageBoxIcon.Information);
    }

    private void cbbType_SelectedIndexChanged(object sender, EventArgs e)
    {
      chkPayCode.Enabled = cbbType.Enabled && cbbType.SelectedIndex > 0 && AllowPayCode;
      chkPayCode.Visible = chkPayCode.Enabled;
      chkPayCodeUSB.Enabled = cbbType.Enabled && cbbType.SelectedIndex > 0 && AllowPayCode && AllowPayUSB;
      chkPayCodeUSB.Visible = chkPayCodeUSB.Enabled;
      cbbCommPort.Enabled = cbbType.Enabled && cbbType.SelectedIndex > 0 && AllowPayCode;
      cbbCommPort.Visible = cbbCommPort.Enabled;
      cbbCommPort.Top = chkPayCodeUSB.Enabled ? 225 : chkPayCodeUSB.Top;
    }

    private void txtMoney_TextChanged(object sender, EventArgs e)
    {
      lblShowMoney.Text = txtMoney.Text;
    }
  }
}