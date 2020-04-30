using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmRSEmpCardChange : frmBaseDialog
  {
    private string title = "";
    private string oprt = "";
    private string otherCoin = "";
    private bool IsChgOk = false;
    private bool IsReadCard = false;
    private string EmpSysID = "";
    private byte CardTypeID = 0;
    private string CardPWD = "";
    private DateTime CardStartDate = new DateTime();
    private DateTime CardEndDate = new DateTime();
    private bool CardCheckOrder = false;
    private double CardBalance = 0;
    private double CardFee = 0;
    private DateTime CardUseDate = new DateTime();
    private int CardUseTimes = 0;
    private string BTFlag = "";
    private bool IsWorking = false;
    public bool ShowSFAllowance = false;

    protected override void InitForm()
    {
      formCode = "RSEmpCardChange";
      base.InitForm();
      this.Text = title + "[" + oprt + "]";
      SetTextboxNumber(txtCardNo);
      txtCardFee.Enter += TextBoxCurrency_Enter;
      txtCardFee.Leave += TextBoxCurrency_Leave;
      btnSelectEmp.Text = "...";
      otherCoin = Pub.GetSQL(DBCode.DB_001003, new string[] { "223" });
      IsChgOk = false;
      IsReadCard = false;
      ResetForm();
      lblResult.ForeColor = Color.Red;
      ShowSFAllowance = false;
      label6.Visible = SystemInfo.AllowCustomerCardNo;
      txtCardNo.Enabled = SystemInfo.AllowCustomerCardNo;
      txtCardNo.Visible = SystemInfo.AllowCustomerCardNo;
      if (!SystemInfo.AllowCustomerCardNo)
      {
        label7.Left = label6.Left;
        txtCardFee.Left = txtCardNo.Left;
      }
    }

    public frmRSEmpCardChange(string Title, string Oprt)
    {
      title = Title;
      oprt = Oprt;
      InitializeComponent();
    }

    private void frmRSEmpCardChange_FormClosed(object sender, FormClosedEventArgs e)
    {
      if (IsChgOk) this.DialogResult = DialogResult.OK;
      if (ShowSFAllowance)
      {
        frmAppMain frm = Pub.GetAppMainForm();
        if (frm != null) frm.ExecModule("SFAllowance", "SF");
      }
    }

    private void btnSelectEmp_Click(object sender, EventArgs e)
    {
      frmPubSelectEmp frm;
      frm = new frmPubSelectEmp(otherCoin);
      if (frm.ShowDialog() == DialogResult.OK)
      {
        txtFind.Text = frm.EmpNo;
        btnFindEmp.PerformClick();
      }
    }

    private void btnFindEmp_Click(object sender, EventArgs e)
    {
      IsReadCard = false;
      DataTableReader dr = null;
      string sql = Pub.GetSQL(DBCode.DB_001003, new string[] { "224", OprtInfo.DepartPower, txtFind.Text.Trim() });
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        dr = db.GetDataReader(sql);
        if (dr.Read())
        {
          txtEmpNo.Text = dr["EmpNo"].ToString();
          txtEmpName.Text = dr["EmpName"].ToString();
          txtDepartName.Text = dr["DepartName"].ToString();
          txtCardSectorNo.Text = dr["CardSectorNo"].ToString();
          txtCardStatusName.Text = dr["CardStatusName"].ToString();
          CardUseDate = new DateTime();
          DateTime.TryParse(dr["CardUseDate"].ToString(), out CardUseDate);
          txtCardUseDate.Text = CardUseDate.ToString();
          txtCardType.Text = dr["CardTypeName"].ToString();
          CardBalance = 0;
          double.TryParse(dr["CardBalanceBT"].ToString(), out CardBalance);
          txtCardBalanceBT.Text = CardBalance.ToString(SystemInfo.CurrencySymbol + "0.00");
          if (SystemInfo.AllowCustomerCardNo) txtCardNo.Text = db.GetMaxCardSectorNo();
          CardFee = 0;
          double.TryParse(dr["CardFee"].ToString(), out CardFee);
          txtCardFee.Text = CardFee.ToString(SystemInfo.CurrencySymbol + "0.00");
          EmpSysID = dr["EmpSysID"].ToString();
          CardTypeID = Convert.ToByte(dr["CardTypeID"]);
          CardPWD = dr["CardPWD"].ToString();
          if ((CardPWD == "") || (!Pub.IsNumeric(CardPWD))) CardPWD = "000000";
          if (Convert.ToInt32(CardPWD) > 999999) CardPWD = "000000";
          CardStartDate = (DateTime)dr["CardStartDate"];
          CardEndDate = (DateTime)dr["CardEndDate"];
          CardCheckOrder = Pub.ValueToBool(dr["CardCheckOrder"].ToString());
          CardUseTimes = 0;
          int.TryParse(dr["CardUseTimes"].ToString(), out CardUseTimes);
          BTFlag = "";
          if (dr["LastBTFlag"].ToString() != "")
          {
            DateTime dd = new DateTime();
            if (DateTime.TryParse(dr["LastBTFlag"].ToString(), out dd)) BTFlag = dd.ToString("yyMMdd");
          }
          IsReadCard = true;
        }
        if (IsReadCard && SystemInfo.HasSF)
        {
          dr.Close();
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "227", EmpSysID }));
          if (dr.Read())
          {
            double d = 0;
            double.TryParse(dr["SFCardBalance"].ToString(), out d);
            if (CardBalance != d)
            {
              if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "Error001", ""))) return;
            }
            CardBalance = d;
          }
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
      ResetForm();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      IsWorking = true;
      WriteCard();
      IsWorking = false;
    }

    private void WriteCard()
    {
      if (!IsReadCard)
      {
        Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgEmpFindFirst", ""));
        return;
      }
      string CardNo = txtCardNo.Text.Trim();
      if (SystemInfo.AllowCustomerCardNo)
      {
        if ((CardNo == "") || (!Pub.IsNumeric(CardNo)))
        {
          txtCardNo.Focus();
          ShowErrorEnterCorrect(label6.Text);
          return;
        }
        if (!Pub.CheckTextMaxLength(label6.Text, CardNo, txtCardNo.MaxLength))
        {
          txtCardNo.Focus();
          return;
        }
        CardNo = Convert.ToUInt32(CardNo).ToString("0000000000");
      }
      string CardNoDays = "";
      string msg = "";
      DateTime dt = new DateTime();
      if (!db.GetServerDate(ref dt)) return;
      DateTime d = new DateTime();
      if (SystemInfo.AllowCustomerCardNo)
      {

        if (db.CardSectorNoIsExists(EmpSysID, CardNo, ref CardNoDays))
        {
          if (CardNoDays == " ")
            msg = Pub.GetResText(formCode, "MsgCardExistsBlack", "");
          else if (DateTime.TryParse(CardNoDays, out d))
            msg = Pub.GetResText(formCode, "MsgCardExistsUseDays", "");
          else
            msg = Pub.GetResText(formCode, "MsgCardExistsUseing", "");
          msg = string.Format(msg, CardNo, CardNoDays);
          if (Pub.MessageBoxShowQuestion(msg)) return;
          CardNo = db.GetMaxCardSectorNo();
          if (CardNo == "")
          {
            Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorBuildCardFailed", ""));
            return;
          }
        }
      }
      int cardRet = 0;
      if (SystemInfo.HasSF)
      {
        cardRet = db.CheckSFAllowance(EmpSysID);
        if (cardRet == 1)
        {
          if (!Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "MsgCardHasAllowance", "")))
          {
            IsWorking = false;
            ShowSFAllowance = true;
            this.Close();
            return;
          }
        }
        else if (cardRet == 2)
        {
          return;
        }
      }
      string CardData10 = "";
      string CardDataH = "";
      string CardData8 = "";
      string UseEmpNo = "";
      if (!Pub.CheckCardExists(ref CardData10, ref CardDataH, ref CardData8)) return;
      cardRet = db.CheckCardPhysicsNo(EmpSysID, CardData10, ref UseEmpNo);
      if (cardRet == 1)
      {
        Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "MsgCardCheckExistsUseing", ""), CardData10, UseEmpNo));
        return;
      }
      else if (cardRet == 2)
      {
        Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "MsgCardExistsBlackAgainA", ""), CardData10));
        return;
      }
      else if (cardRet == 3)
      {
        return;
      }
      if (CardBalance < 0)
      {
        Pub.MessageBoxShow(Pub.GetResText(formCode, "Msg001", ""));
        return;
      }
      if (!SystemInfo.AllowCustomerCardNo) CardNo = CardData10;
      QHAPI.TCardPubData pubData = new QHAPI.TCardPubData();
      if (!Pub.ReadCardInfo(ref pubData)) return;
      if (pubData.DealersCode != SystemInfo.DealersCode)
      {
        Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorIllegalCard", ""));
        return;
      }
      if ((pubData.CardNo != "") && (Convert.ToUInt32(pubData.CardNo) > 0))
      {
        Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgCardFaExists", ""));
        return;
      }
      pubData.EmpNo = txtEmpNo.Text;
      pubData.EmpName = txtEmpName.Text;
      pubData.CardNo = CardNo;
      pubData.CardTypeID = CardTypeID;
      pubData.CardPWD = CardPWD;
      pubData.DealersCode = SystemInfo.DealersCode;
      pubData.CustomersCode = SystemInfo.CustomersCode;
      pubData.CardBeginDate = CardStartDate.Date;
      pubData.CardEndDate = CardEndDate.Date;
      pubData.IsCheckOrder = Convert.ToByte(CardCheckOrder);
      QHAPI.TCardSFData sfData = new QHAPI.TCardSFData();
      sfData.Balance = CardBalance;
      sfData.UseDate = CardUseDate;
      sfData.UseTimes = CardUseTimes;
      sfData.BtMonery = 0;
      if (BTFlag != "")
      {
        BTFlag = DeviceObject.objCPIC.NumToHex(BTFlag.Substring(0, 2), 1) +
          DeviceObject.objCPIC.NumToHex(BTFlag.Substring(2, 2), 1) +
          DeviceObject.objCPIC.NumToHex(BTFlag.Substring(4, 2), 1);
      }
      sfData.BtDate = BTFlag == "" ? "000000" : BTFlag;
      QHAPI.TCardSKData skData = new QHAPI.TCardSKData();
      skData.CardID = pubData.CardNo;
      skData.CardTime = CardUseDate;
      bool IsError = false;
      string CardNo10 = "";
      string CardNoH = "";
      string CardNo8 = "";
      string oprtMsg = "[" + txtEmpNo.Text + "]" + txtEmpName.Text + ": " + CardNo + "/" + txtDepartName.Text;
    ContinuePS:
      Application.DoEvents();
      if (IsError)
      {
        if (!DeviceObject.objCPIC.GetCardData(ref CardNo10, ref CardNoH, ref CardNo8))
        {
          lblResult.Text = Pub.GetResText(formCode, "ReadCardError3", "");
          goto ContinuePS;
        }
        if (CardNo10 != CardData10)
        {
          if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "MsgCardSame", "")))
            return;
          else
            goto ContinuePS;
        }
        IsError = false;
      }
      cardRet = Pub.WriteCardInfo(pubData, sfData, skData);
      if (cardRet != 0)
      {
        if (Pub.MessageBoxShowQuestion(Pub.GetCardMsg(cardRet) + Pub.GetResText(formCode, "MsgContinue", "")))
          return;
        else
        {
          IsError = true;
          goto ContinuePS;
        }
      }
    ContinueData:
      Application.DoEvents();
      if (!db.EmpCardChange(this.Text, oprt, EmpSysID, CardNo, CardData10, CardData8, CardFee,
        CardData10, DeviceObject.objCPIC.GetMacTAG()))
      {
        if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "ErrorCardDB", "")))
        {
          Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgCardChangeFailed", ""));
          return;
        }
        else
          goto ContinueData;
      }
      Pub.CardBuzzer();
      lblResult.Text = Pub.GetResText(formCode, "MsgCardChangeSuccess", "");
      IsChgOk = true;
      IsReadCard = false;
      db.WriteSYLog(this.Text, oprt, oprtMsg);
      db.UpdateEmpRegisterData(EmpSysID, 11, CardData10);
      Pub.MessageBoxShow(lblResult.Text, MessageBoxIcon.Information);
      ResetForm();
    }

    private void ResetForm()
    {
      if (!IsReadCard)
      {
        txtEmpNo.Text = "";
        txtEmpName.Text = "";
        txtDepartName.Text = "";
        txtCardSectorNo.Text = "";
        txtCardStatusName.Text = "";
        txtCardUseDate.Text = "";
        txtCardType.Text = "";
        txtCardBalanceBT.Text = "";
        txtCardNo.Text = "";
        txtCardFee.Text = "";
        EmpSysID = "";
        lblResult.Text = "";
      }
      txtEmpNo.Enabled = IsReadCard;
      txtEmpName.Enabled = IsReadCard;
      txtDepartName.Enabled = IsReadCard;
      txtCardSectorNo.Enabled = IsReadCard;
      txtCardStatusName.Enabled = IsReadCard;
      txtCardUseDate.Enabled = IsReadCard;
      txtCardType.Enabled = IsReadCard;
      txtCardBalanceBT.Enabled = IsReadCard;
      txtCardNo.Enabled = IsReadCard && SystemInfo.AllowCustomerCardNo;
      txtCardFee.Enabled = IsReadCard;
      btnOk.Enabled = IsReadCard;
    }

    private void frmRSEmpCardChange_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (IsWorking) e.Cancel = true;
    }
  }
}