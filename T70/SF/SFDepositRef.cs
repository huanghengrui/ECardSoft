using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmSFDepositRef : frmBaseMDIChild
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

    protected override void InitForm()
    {
      formCode = "SFDepositRef";
      base.InitForm();
      this.Toolbar.Visible = false;
      this.Statusbar.Visible = false;
      Font fnt = new Font(this.Font.FontFamily, 20);
      txtMoney.Enter += TextBoxCurrency_Enter;
      txtMoney.Leave += TextBoxCurrency_Leave;
      txtMoney1.Enter += TextBoxCurrency_Enter;
      txtMoney1.Leave += TextBoxCurrency_Leave;
      double d = 0;
      txtMoney.Text = d.ToString(SystemInfo.CurrencySymbol + "0.00");
      txtMoney1.Text = d.ToString(SystemInfo.CurrencySymbol + "0.00");
      ResetForm(0);
      ResetForm(1);
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
      label10.Visible = cbbType.Enabled;
      txtUpDepositType.Enabled = ExistsDepositType;
      txtUpDepositType.Visible = txtUpDepositType.Enabled;
      lblUpDepositType.Visible = txtUpDepositType.Enabled;
      txtMoney.Focus();
      toolTip.SetToolTip(picDisc, Pub.GetResText(formCode, "DiscHint", ""));
      OkContinue = SystemInfo.ini.ReadIni("Public", "CardOk", true);
      chkPrint.Checked = SystemInfo.ini.ReadIni("Public", "CheckPrint", false);
      checkBox1.Checked = SystemInfo.ini.ReadIni("Public", "CheckPrint1", false);
      MobileInfo = new TMobileInfo("");
      DeviceObject.objCard.MobileInit(MobileInfo.MobTyp, MobileInfo.MercID, MobileInfo.TrmNo, MobileInfo.PWD, MobileInfo.XJLName, MobileInfo.XJLPWD);
    }

    public frmSFDepositRef()
    {
      InitializeComponent();
    }

    private void frmSFDepositRef_Resize(object sender, EventArgs e)
    {
    }

    private void btnReadCard_Click(object sender, EventArgs e)
    {
      ResetForm(0);
      if (!ReadCard(0)) return;
      Pub.CardBuzzer();
      double ShowBTMoney = db.GetBTMoney(sfData.BtDate, sfData.BtMonery);
      double AllBalance = sfData.Balance + ShowBTMoney;
      txtCardBalance.Text = AllBalance.ToString(SystemInfo.CurrencySymbol + "0.00");
    }

    private void btnReadCard1_Click(object sender, EventArgs e)
    {
      ResetForm(1);
      if (!ReadCard(1)) return;
      Pub.CardBuzzer();
      double ShowBTMoney = db.GetBTMoney(sfData.BtDate, sfData.BtMonery);
      double AllBalance = sfData.Balance + ShowBTMoney;
      textBox2.Text = AllBalance.ToString(SystemInfo.CurrencySymbol + "0.00");
      txtMoney1.Text = textBox2.Text;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (!db.CheckOprtRole(formCode, "M", true)) return;
      if (IsWorking) return;
      IsWorking = true;
      CurrentTool = button1.Text;
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
      ResetForm(0);
      string AmountTitle = label7.Text;
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
      if (!ReadCard(0)) return;
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
        bool IsWeiXin = DepositType == "100";
        string ErrMsg = "";
        if (!DeviceObject.objCard.MobileShow(h, CardData10, pubData.CardNo, MobileMoney, ref IsWeiXin, true, ref ErrMsg))
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
        if (Pub.MessageBoxShowQuestion(Pub.GetCardMsg(cardRet) + Pub.GetResText(formCode, "MsgContinue", "")))
          return;
        else
        {
          IsSFError = true;
          goto ContinueSF;
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

    private bool ReadCard(byte flag)
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
            if (flag==0)
              Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgCardDepositNotNormal", ""));
            else
              Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgCardRefunNotNormal", ""));
          }
          else if (flag != 0 && !Convert.ToBoolean(dr["CardRefundment"].ToString()))
          {
            Pub.MessageBoxShow(string.Format(Pub.GetResText("", "ErrorCardRefundment", ""),
              dr["CardTypeName"].ToString()));
          }
          else
          {
            IsOk = true;
            if (flag == 0)
            {
              txtEmpNo.Text = dr["EmpNo"].ToString();
              txtEmpName.Text = dr["EmpName"].ToString();
              txtDepartName.Text = dr["DepartName"].ToString();
              txtCardSectorNo.Text = dr["CardSectorNo"].ToString();
              txtCardStatusName.Text = dr["CardStatusName"].ToString();
              txtCardType.Text = dr["CardTypeName"].ToString();
              int.TryParse(dr["DepositDiscount"].ToString(), out Discount);
              txtDepositDiscount.Text = Discount.ToString();
            }
            else
            {
              if (ExistsDepositType)
              {
                string SFTypeName = "";
                double SFAmount = 0;
                IsOk = db.SFGetLastSFType(dr["EmpSysID"].ToString(), ref SFTypeName, ref SFAmount);
                if (IsOk && (SFTypeName != ""))
                {
                  txtUpDepositType.Text = SFTypeName + ":" + SFAmount.ToString(SystemInfo.CurrencySymbol + "0.00");
                }
              }
              if (IsOk)
              {
                textBox8.Text = dr["EmpNo"].ToString();
                textBox9.Text = dr["EmpName"].ToString();
                textBox7.Text = dr["DepartName"].ToString();
                textBox5.Text = dr["CardSectorNo"].ToString();
                textBox6.Text = dr["CardStatusName"].ToString();
                textBox4.Text = dr["CardTypeName"].ToString();
              }
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

    private void ResetForm(byte flag)
    {
      double d = 0;
      if (flag == 0)
      {
        txtEmpNo.Text = "";
        txtEmpName.Text = "";
        txtDepartName.Text = "";
        txtCardSectorNo.Text = "";
        txtCardStatusName.Text = "";
        txtCardType.Text = "";
        txtDepositDiscount.Text = "";
        txtCardBalance.Text = d.ToString(SystemInfo.CurrencySymbol + "0.00");
        lblResult.Text = "";
      }
      else
      {
        textBox8.Text = "";
        textBox9.Text = "";
        textBox7.Text = "";
        textBox5.Text = "";
        textBox6.Text = "";
        textBox4.Text = "";
        textBox2.Text = d.ToString(SystemInfo.CurrencySymbol + "0.00");
        txtUpDepositType.Text = "";
        lblResult1.Text = "";
      }
    }

    private void RefreshForm()
    {
      gbxEmpInfo.Enabled = !IsWorking;
      label7.Enabled = !IsWorking;
      txtMoney.Enabled = !IsWorking;
      cbbType.Enabled = !IsWorking && cbbType.Visible;
      btnReadCard.Enabled = !IsWorking;
      chkPrint.Enabled = !IsWorking;
      chkEmptyZero.Enabled = !IsWorking;
      button1.Enabled = !IsWorking;
      groupBox1.Enabled = !IsWorking;
      label14.Enabled = !IsWorking;
      txtMoney1.Enabled = !IsWorking;
      btnReadCard1.Enabled = !IsWorking;
      checkBox1.Enabled = !IsWorking;
      chkEmptyZero1.Enabled = !IsWorking;
      button2.Enabled = !IsWorking;
    }

    private void button2_Click(object sender, EventArgs e)
    {
      if (!db.CheckOprtRole(formCode, "M", true)) return;
      if (IsWorking) return;
      IsWorking = true;
      CurrentTool = button2.Text;
      RefreshForm();
      WriteCard1();
      IsWorking = false;
      RefreshForm();
      if (!chkEmptyZero1.Checked)
      {
        double d = 0;
        txtMoney1.Text = d.ToString(SystemInfo.CurrencySymbol + "0.00");
      }
      txtMoney1.Focus();
      SystemInfo.ini.WriteIni("Public", "CheckPrint1", checkBox1.Checked);
    }

    private void WriteCard1()
    {
      ResetForm(1);
      double money = 0;
      double.TryParse(CurrencyToStringEx(txtMoney1.Text), out money);
      if (money <= 0)
      {
        Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorMoneyZero", ""));
        return;
      }
      if (!ReadCard(1)) return;
      DateTime dt = new DateTime();
      if (!db.GetServerDate(this.Text, ref dt)) return;
      if (!Pub.CheckUseDate(dt, sfData.UseDate)) return;
      Pub.ClearCardLimitInfo(dt, ref sfData);
      double ShowBTMoney = db.GetBTMoney(sfData.BtDate, sfData.BtMonery);
      double AllBalance = sfData.Balance + ShowBTMoney;
      textBox2.Text = AllBalance.ToString(SystemInfo.CurrencySymbol + "0.00");
      if (AllBalance < money)
      {
        Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorBalanceNotEnough", ""));
        return;
      }
      sfData.UseDate = dt;
      sfData.UseTimes += 1;
      List<string> sql = new List<string>();
      sql.Clear();
      if (ShowBTMoney == 0)
      {
        sfData.Balance -= money;
        if (sfData.BtMonery > 0)
        {
          double m = -sfData.BtMonery;
          sql.Add(Pub.GetSQL(DBCode.DB_004005, new string[] { "0", pubData.CardNo, "0", 
            dt.ToString(SystemInfo.SQLDateTimeFMT), m.ToString(), sfData.Balance.ToString(), "0", "", "0", 
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
      double mm = -money;
      AllBalance = sfData.Balance + sfData.BtMonery;
      sql.Add(Pub.GetSQL(DBCode.DB_004005, new string[] { "0", pubData.CardNo, "20", 
        dt.ToString(SystemInfo.SQLDateTimeFMT), mm.ToString(), AllBalance.ToString(), "0", "", "0", 
        sfData.UseTimes.ToString(), OprtInfo.OprtSysID, "", "1", "", CardData10, pubData.MacTAG, "" }));
      string Title = Pub.GetResText(formCode, "RefundmentTitle", "");
      double Amount = money;
      double ReceivablesAmount = money;
      double CardBalance = AllBalance;
      string AmountTitle = label14.Text;
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
      textBox2.Text = temp.ToString(SystemInfo.CurrencySymbol + "0.00");
      Pub.CardBuzzer();
      DispExtScreen(Amount, temp, 1, 2);
      if (checkBox1.Checked)
      {
        PrintCardBill(Title, Amount, ReceivablesAmount, CardBalance, AmountTitle, pubData.CardNo);
      }
      lblResult1.Text = this.Text + Pub.GetResText(formCode, "MsgSuccess", "");
    }

    private void splitContainer1_Resize(object sender, EventArgs e)
    {
      int w = (splitContainer1.Width - 25) / 2;
      splitContainer1.SplitterDistance = w;
    }

    private void picDisc_Click(object sender, EventArgs e)
    {
      string DiscHint = "";
      if (db.GetDiscHint(ref DiscHint)) Pub.MessageBoxShow(DiscHint, MessageBoxIcon.Information);
    }
  }
}