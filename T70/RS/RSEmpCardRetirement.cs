using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmRSEmpCardRetirement : frmBaseDialog
  {
    private string title = "";
    private string oprt = "";
    private string otherCoin = "";
    private bool IsChgOk = false;
    private bool IsReadCard = false;
    private string EmpSysID = "";
    private double CardBalance = 0;
    private double CardFee = 0;
    private double ReFee = 0;
    private double BTMoney = 0;
    private double ShowBTMoney = 0;
    private int CardUseTimes = 0;
    private string CardData10 = "";
    private string CardDataH = "";
    private string CardData8 = "";
    private bool IsWorking = false;
    public bool ShowSFAllowance = false;
    private string MacTag = "";
    private bool OkContinue = true;

    protected override void InitForm()
    {
      formCode = "RSEmpCardRetirement";
      base.InitForm();
      this.Text = title + "[" + oprt + "]";
      txtCardFee.Enter += TextBoxCurrency_Enter;
      txtCardFee.Leave += TextBoxCurrency_Leave;
      btnSelectEmp.Text = "...";
      otherCoin = Pub.GetSQL(DBCode.DB_001003, new string[] { "223" });
      IsChgOk = false;
      lblResult.ForeColor = Color.Red;
      RadioButton_Click(null, null);
      ShowSFAllowance = false;
      OkContinue = SystemInfo.ini.ReadIni("Public", "CardOk", true);
      chkPrint.Checked = SystemInfo.ini.ReadIni("Public", "CheckPrint", false);
    }

    public frmRSEmpCardRetirement(string Title, string Oprt)
    {
      title = Title;
      oprt = Oprt;
      InitializeComponent();
    }

    private void RadioButton_Click(object sender, EventArgs e)
    {
      btnReadCard.Enabled = rbNormal.Checked;
      btnReadCard.Visible = btnReadCard.Enabled;
      lblFind.Enabled = rbLoss.Checked;
      txtFind.Enabled = lblFind.Enabled;
      btnSelectEmp.Enabled = lblFind.Enabled;
      btnFindEmp.Enabled = lblFind.Enabled;
      lblFind.Visible = lblFind.Enabled;
      txtFind.Visible = lblFind.Enabled;
      btnSelectEmp.Visible = lblFind.Enabled;
      btnFindEmp.Visible = lblFind.Enabled;
      IsReadCard = false;
      label8.Text = Pub.GetResText(formCode, rbNormal.Checked ? "SFCardBalance" : "CardBalanceBT", "");
      ResetForm();
    }

    private void frmRSEmpCardRetirement_FormClosed(object sender, FormClosedEventArgs e)
    {
      if (IsChgOk) this.DialogResult = DialogResult.OK;
      if (ShowSFAllowance)
      {
        frmAppMain frm = Pub.GetAppMainForm();
        if (frm != null) frm.ExecModule("SFAllowance", "SF");
      }
    }

    private void btnReadCard_Click(object sender, EventArgs e)
    {
      IsReadCard = false;
      QHAPI.TCardPubData pubData = new QHAPI.TCardPubData();
      QHAPI.TCardSFData sfData = new QHAPI.TCardSFData();
      if (!Pub.CheckCardExists(ref CardData10, ref CardDataH, ref CardData8)) return;
      if (!Pub.ReadCardInfo(ref pubData, ref sfData))
      {
        ResetForm();
        return;
      }
      if (!db.CheckCardExists(pubData.CardNo, CardData10))
      {
        ResetForm();
        return;
      }
      if (!db.CheckDepartPowerByCard(pubData.CardNo))
      {
        ResetForm();
        return;
      }
      MacTag = pubData.MacTAG;
      BTMoney = sfData.BtMonery;
      ShowBTMoney = db.GetBTMoney(sfData.BtDate, BTMoney);
      CardBalance = sfData.Balance + ShowBTMoney;
      CardUseTimes = sfData.UseTimes + 1;
      DataTableReader dr = null;
      bool IsOk = false;
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "215", pubData.CardNo, CardData10 }));
        if (dr.Read())
        {
          if (Convert.ToInt32(dr["CardStatusID"]) != 20)
          {
            Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgCardRetirNotNormal", ""));
          }
          else if (!Convert.ToBoolean(dr["CardRetirement"].ToString()))
          {
            Pub.MessageBoxShow(string.Format(Pub.GetResText("", "ErrorCardRetirement", ""),
              dr["CardTypeName"].ToString()));
          }
          else
          {
            txtEmpNo.Text = dr["EmpNo"].ToString();
            txtEmpName.Text = dr["EmpName"].ToString();
            txtDepartName.Text = dr["DepartName"].ToString();
            txtCardSectorNo.Text = dr["CardSectorNo"].ToString();
            txtCardStatusName.Text = dr["CardStatusName"].ToString();
            txtCardUseDate.Text = dr["CardUseDate"].ToString();
            txtCardType.Text = dr["CardTypeName"].ToString();
            txtCardBalanceBT.Text = CardBalance.ToString(SystemInfo.CurrencySymbol + "0.00");
            CardFee = 0;
            double.TryParse(dr["CardFee"].ToString(), out CardFee);
            txtCardFee.Text = CardFee.ToString(SystemInfo.CurrencySymbol + "0.00");
            EmpSysID = dr["EmpSysID"].ToString();
            ReFee = CardBalance + CardFee;
            txtReFee.Text = ReFee.ToString(SystemInfo.CurrencySymbol + "0.00");
            IsOk = true;
          }
        }
        else
        {
          Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorIllegalCard", ""));
        }
      }
      catch (Exception E)
      {
        IsOk = false;
        Pub.ShowErrorMsg(E);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      if (!IsOk)
      {
        ResetForm();
        return;
      }
      ReFee = CardBalance + CardFee;
      txtReFee.Text = ReFee.ToString(SystemInfo.CurrencySymbol + "0.00");
      IsReadCard = true;
      Pub.CardBuzzer();
      ResetForm();
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
          if (!Convert.ToBoolean(dr["CardRetirement"].ToString()))
          {
            Pub.MessageBoxShow(string.Format(Pub.GetResText("", "ErrorCardRetirement", ""),
              dr["CardTypeName"].ToString()));
          }
          else
          {
            MacTag = DeviceObject.objCPIC.GetMacTAG();
            txtEmpNo.Text = dr["EmpNo"].ToString();
            txtEmpName.Text = dr["EmpName"].ToString();
            txtDepartName.Text = dr["DepartName"].ToString();
            txtCardSectorNo.Text = dr["CardSectorNo"].ToString();
            txtCardStatusName.Text = dr["CardStatusName"].ToString();
            txtCardUseDate.Text = dr["CardUseDate"].ToString();
            txtCardType.Text = dr["CardTypeName"].ToString();
            CardBalance = 0;
            double.TryParse(dr["CardBalanceBT"].ToString(), out CardBalance);
            txtCardBalanceBT.Text = CardBalance.ToString(SystemInfo.CurrencySymbol + "0.00");
            CardFee = 0;
            double.TryParse(dr["CardFee"].ToString(), out CardFee);
            txtCardFee.Text = CardFee.ToString(SystemInfo.CurrencySymbol + "0.00");
            EmpSysID = dr["EmpSysID"].ToString();
            CardUseTimes = 0;
            int.TryParse(dr["CardUseTimes"].ToString(), out CardUseTimes);
            ReFee = CardBalance + CardFee;
            txtReFee.Text = ReFee.ToString(SystemInfo.CurrencySymbol + "0.00");
            IsReadCard = true;
          }
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
              IsReadCard = false;
              Pub.MessageBoxShow(Pub.GetResText(formCode, "Error001", ""));
            }
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

    private void txtCardFee_TextChanged(object sender, EventArgs e)
    {
      if (!txtCardFee.Enabled) return;
      string s = CurrencyToStringEx(txtCardFee.Text);
      double money = 0;
      if (!Pub.IsNumeric(s))
      {
        double.TryParse(CurrencyToStringEx(txtCardFee.Text), out money);
        if (money < 0) money = 0.00;
        txtCardFee.Text = money.ToString("0.00");
        s = txtCardFee.Text;
      }
      double.TryParse(s, out CardFee);
      ReFee = CardBalance + CardFee;
      txtReFee.Text = ReFee.ToString(SystemInfo.CurrencySymbol + "0.00");
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      IsWorking = true;
      WriteCard();
      IsWorking = false;
      SystemInfo.ini.WriteIni("Public", "CheckPrint", chkPrint.Checked);
    }

    private void WriteCard()
    {
      int RetirementFlag = 0;
      string msg = "";
      if (rbNormal.Checked)
      {
        RetirementFlag = 2;
        msg = rbNormal.Text;
      }
      else
      {
        RetirementFlag = 1;
        msg = rbLoss.Text;
      }
      msg = msg + "[" + txtEmpNo.Text + "]" + txtEmpName.Text + ": " + txtCardSectorNo.Text + "/" + txtDepartName.Text;
      if (!IsReadCard)
      {
        if (rbNormal.Checked)
          Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgCardReadFirst", ""));
        else
          Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgEmpFindFirst", ""));
        return;
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
      if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "MsgCardRetirementContinue", ""))) return;
    ContinueData:
      Application.DoEvents();
      if (!db.EmpCardRetirement(this.Text, oprt, EmpSysID, RetirementFlag, BTMoney, ShowBTMoney,
        CardBalance, CardFee, CardUseTimes, CardData10, MacTag))
      {
        if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "ErrorCardDB", "")))
          return;
        else
          goto ContinueData;
      }
      if (RetirementFlag == 2)
      {
        string CardNo10 = "";
        string CardNoH = "";
        string CardNo8 = "";
      ClearCard:
        if (!DeviceObject.objCPIC.GetCardData(ref CardNo10, ref CardNoH, ref CardNo8))
        {
          lblResult.Text = Pub.GetResText(formCode, "ReadCardError3", "");
          goto ClearCard;
        }
        if (CardNo10 != CardData10)
        {
          if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "MsgCardSame", "")))
            return;
          else
            goto ClearCard;
        }
        cardRet = Pub.ClearCardInfo();
        if (cardRet != 0)
        {
          if (OkContinue)
          {
            Pub.MessageBoxShow(Pub.GetCardMsg(cardRet) + "\r\n\r\n" + Pub.GetResText(formCode, "MsgCardOkContinue", ""));
            goto ClearCard;
          }
          else
          {
            if (Pub.MessageBoxShowQuestion(Pub.GetCardMsg(cardRet) + Pub.GetResText(formCode, "MsgContinue", "")))
              return;
            else
              goto ClearCard;
          }
        }
        Pub.CardBuzzer();
      }
      lblResult.Text = Pub.GetResText(formCode, "MsgCardRetirementSuccess", "");
      IsChgOk = true;
      IsReadCard = false;
      if (chkPrint.Checked)
      {
        double Amount = CardBalance + CardFee;
        string Title = Pub.GetResText(formCode, "RetirementTitle", "");
        string AmountTitle = label7.Text;
        PrintCardBillByEmpSysID(Title, Amount, Amount, 0, AmountTitle, EmpSysID);
      }
      db.WriteSYLog(this.Text, oprt, msg);
      db.UpdateEmpRegisterData(EmpSysID, 11, "");
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
        txtCardFee.Text = "";
        txtReFee.Text = "";
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
      txtCardFee.Enabled = IsReadCard;
      txtReFee.Enabled = IsReadCard;
      btnOk.Enabled = IsReadCard;
    }

    private void frmRSEmpCardRetirement_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (IsWorking) e.Cancel = true;
    }
  }
}