using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmSFSoft : frmBaseDialog
  {
    private string CardData10 = "";
    private string CardDataH = "";
    private string CardData8 = "";
    private QHAPI.TCardPubData pubData = new QHAPI.TCardPubData();
    private QHAPI.TCardSFData sfData = new QHAPI.TCardSFData();
    private bool IsWorking = false;
    private SFSoftParamInfo paramInfo = new SFSoftParamInfo("");
    private bool OkContinue = true;

    protected override void InitForm()
    {
      formCode = "SFSoft";
      base.InitForm();
      this.Text = Pub.GetResText(formCode, "mnu" + formCode, "", new string[] { "Main" });
      txtMoney.Enter += TextBoxCurrency_Enter;
      txtMoney.Leave += TextBoxCurrency_Leave;
      double d = 0;
      txtMoney.Text = d.ToString(SystemInfo.CurrencySymbol + "0.00");
      cbbMealType.Items.Clear();
      cbbSFType.Items.Clear();
      DataTableReader dr = null;
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004005, new string[] { "2" }));
        while (dr.Read())
        {
          cbbMealType.Items.Add(new TCommonType(dr["MealTypeSysID"].ToString(), dr["MealTypeID"].ToString(),
            dr["MealTypeName"].ToString(), true));
        }
        dr.Close();
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004005, new string[] { "3" }));
        while (dr.Read())
        {
          cbbSFType.Items.Add(new TCommonType(dr["SFTypeSysID"].ToString(), dr["SFTypeID"].ToString(),
            dr["SFTypeName"].ToString(), true));
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
      if (cbbMealType.Items.Count > 0) cbbMealType.SelectedIndex = 0;
      if (cbbSFType.Items.Count > 0) cbbSFType.SelectedIndex = 2;
      txtMoney.Focus();
      LoadParamInfo();
      timer1.Enabled = true;
      OkContinue = SystemInfo.ini.ReadIni("Public", "CardOk", true);
      chkPrint.Checked = SystemInfo.ini.ReadIni("Public", "CheckPrint", false);
    }

    public frmSFSoft()
    {
      InitializeComponent();
    }

    private void btnReadCard_Click(object sender, EventArgs e)
    {
      ResetForm();
      if (!ReadCard(false)) return;
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
      if (!ReadCard(true)) return;
      DateTime dt = new DateTime();
      if (!db.GetServerDate(this.Text, ref dt)) return;
      if (!Pub.CheckUseDate(dt, sfData.UseDate)) return;
      Pub.ClearCardLimitInfo(dt, ref sfData);
      double ShowBTMoney = db.GetBTMoney(sfData.BtDate, sfData.BtMonery);
      double AllBalance = sfData.Balance + ShowBTMoney;
      txtCardBalance.Text = AllBalance.ToString(SystemInfo.CurrencySymbol + "0.00");
      List<string> sql = new List<string>();
      sql.Clear();
      string cap = ((TCommonType)cbbSFType.Items[cbbSFType.SelectedIndex]).name;
      string SFType = ((TCommonType)cbbSFType.Items[cbbSFType.SelectedIndex]).id;
      byte flag = 0;
      if (SFType == "2") flag = 4;
      string MealType = ((TCommonType)cbbMealType.Items[cbbMealType.SelectedIndex]).id;
      bool DecMoney = (SFType == "1") || (SFType == "60");
      if (DecMoney)
      {
        if (AllBalance < money)
        {
          Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorBalanceNotEnough", ""));
          return;
        }
      }
      sfData.UseDate = dt;
      if ((ShowBTMoney == 0) && (sfData.BtMonery > 0))
      {
        sfData.UseTimes += 1;
        double m = -sfData.BtMonery;
        sql.Add(Pub.GetSQL(DBCode.DB_004005, new string[] { "0", pubData.CardNo, "0", 
          dt.ToString(SystemInfo.SQLDateTimeFMT), m.ToString(), AllBalance.ToString(), "0", "", "0", 
          sfData.UseTimes.ToString(), OprtInfo.OprtSysID, "", "1", "", CardData10, pubData.MacTAG, "" }));
        sfData.BtMonery = 0;
      }
      else
      {
        if (DecMoney)
        {
          sfData.UseTimes += 1;
          sfData.BtMonery -= money;
          if (sfData.BtMonery < 0)
          {
            sfData.Balance += sfData.BtMonery;
            sfData.BtMonery = 0;
          }
        }
        AllBalance -= money;
      }
      double mm = -money;
      sql.Add(Pub.GetSQL(DBCode.DB_004005, new string[] { "0", pubData.CardNo, SFType, 
        dt.ToString(SystemInfo.SQLDateTimeFMT), mm.ToString(), AllBalance.ToString(), MealType, "255", "0", 
        sfData.UseTimes.ToString(), OprtInfo.OprtSysID, "", "1", "", CardData10, pubData.MacTAG, "" }));
      string Title = cap;
      double Amount = money;
      double ReceivablesAmount = money;
      double CardBalance = AllBalance;
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
      double temp = sfData.Balance + db.GetBTMoney(sfData.BtDate, sfData.BtMonery);
      txtCardBalance.Text = temp.ToString(SystemInfo.CurrencySymbol + "0.00");
      Pub.CardBuzzer();
      DispExtScreen(Amount, temp, 1, flag);
      if (chkPrint.Checked)
      {
        PrintCardBill(Title, Amount, ReceivablesAmount, CardBalance, AmountTitle, pubData.CardNo);
      }
      lblResult.Text = this.Text + Pub.GetResText(formCode, "MsgSuccess", "");
    }

    private bool ReadCard(bool IsWrite)
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
            Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgCardCostNotNormal", ""));
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

    private void frmSFRefundment_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (IsWorking)
        e.Cancel = true;
      else
        timer1.Enabled = false;
    }

    private void RefreshForm()
    {
      gbxEmpInfo.Enabled = !IsWorking;
      label6.Enabled = !IsWorking;
      txtMoney.Enabled = !IsWorking;
      cbbMealType.Enabled = !IsWorking;
      label8.Enabled = !IsWorking;
      cbbSFType.Enabled = !IsWorking;
      btnReadCard.Enabled = !IsWorking;
      chkPrint.Enabled = !IsWorking;
      chkEmptyZero.Enabled = !IsWorking;
      btnOk.Enabled = !IsWorking;
      btnCancel.Enabled = !IsWorking;
      button1.Enabled = !IsWorking;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      frmSFSoftParam frm = new frmSFSoftParam(this.Text, button1.Text);
      if (frm.ShowDialog() == DialogResult.OK) LoadParamInfo();
    }

    private void LoadParamInfo()
    {
      DataTableReader dr = null;
      try
      {
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { "8" }));
        if (dr.Read()) paramInfo = new SFSoftParamInfo(dr["Value"].ToString());
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

    private void timer1_Tick(object sender, EventArgs e)
    {
      int t = 0;
      int t1 = 0;
      int t2 = 0;
      DateTime tt;

      if (chkAutoPeriod.Checked)
      {
        for (int i = 0; i < 3; i++)
        {
          t = DateTime.Now.Hour * 60 + DateTime.Now.Minute;
          tt = Convert.ToDateTime(paramInfo.BeginTime[i]);
          t1 = tt.Hour * 60 + tt.Minute;
          tt = Convert.ToDateTime(paramInfo.EndTime[i]);
          t2 = tt.Hour * 60 + tt.Minute;
          if ((t >= t1) && (t < t2))
          {
            cbbMealType.SelectedIndex = i;
            break;
          }
        }
      }
    }
  }
}