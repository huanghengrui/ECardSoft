using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using grproLib;

namespace ECard78
{
  public partial class frmRSEmpCardFa : frmBaseForm
  {
    private string title = "";
    private string StrPosition = "";
    private string StrReading = "";
    private string OriginSQL = "";
    private string QuerySQL = "";
    private bool IsFaOk = false;
    private bool IsFaCard = false;
    private string CardStatusNormal = "20";

    protected override void InitForm()
    {
      formCode = "RSEmpCardFa";
      base.InitForm();
      this.Text = title;
      ItemMoneyText.Enter += TextBoxCurrency_Enter;
      ItemMoneyText.Leave += TextBoxCurrency_Leave;
      ItemMoneyText.Text = SystemInfo.CurrencySymbol + "0.00";
      Column8.DefaultCellStyle.Format = SystemInfo.CurrencySymbol + "0.00";
      Column9.DefaultCellStyle.Format = SystemInfo.CurrencySymbol + "0.00";
      StrPosition = Pub.GetResText(formCode, "ItemPosition", "");
      StrReading = Pub.GetResText(formCode, "MsgReadingData", "");
      OriginSQL = Pub.GetSQL(DBCode.DB_001003, new string[] { "105", OprtInfo.DepartPower });
      QuerySQL = Pub.GetSQL(DBCode.DB_001003, new string[] { "113", OriginSQL });
      lblMsg.ForeColor = Color.Blue;
      lblResult.ForeColor = Color.Red;
      IsFaOk = false;
      IsFaCard = false;
      DataTableReader dr = null;
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "108" }));
        if (dr.Read()) CardStatusNormal = dr[0].ToString();
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
      LoadData();
      ItemCardFill.Visible = SystemInfo.AllowCustomerCardNo;
      ItemLine3.Visible = SystemInfo.AllowCustomerCardNo;
    }

    public frmRSEmpCardFa(string Title)
    {
      title = Title;
      InitializeComponent();
    }

    private void LoadData()
    {
      int row = -1;
      RefreshMsg(StrReading);
      if (QuerySQL != "")
      {
        try
        {
          if (bindingSource.DataSource != null) row = bindingSource.Position;
          bindingSource.DataSource = null;
          if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
          bindingSource.DataSource = db.GetDataTable(QuerySQL);
        }
        catch (Exception E)
        {
          Pub.ShowErrorMsg(E, QuerySQL);
        }
        finally
        {
          if (bindingSource.DataSource != null)
          {
            if (row < bindingSource.Count)
              bindingSource.Position = row;
            else if (bindingSource.Count > 0)
              bindingSource.Position = bindingSource.Count - 1;
          }
        }
      }
      RefreshForm(true);
      RefreshMsg("");
    }

    private void RefreshMsg(string msg)
    {
      lblMsg.Text = msg;
      if (lblMsg.Text == "")
      {
        progBar.Value = 0;
        progBar.Style = ProgressBarStyle.Blocks;
      }
      else
      {
        progBar.Value = 50;
        progBar.Style = ProgressBarStyle.Marquee;
      }
      statusBar.Refresh();
    }

    private void RefreshForm(bool state)
    {
      int row = 0;
      int rows = 0;
      if (bindingSource.DataSource != null)
      {
        row = bindingSource.Position + 1;
        rows = bindingSource.Count;
      }
      ItemSearch.Enabled = state && !IsFaCard;
      ItemFindLabel.Enabled = ItemSearch.Enabled;
      ItemFindText.Enabled = ItemSearch.Enabled;
      ItemBatchFa.Enabled = ItemSearch.Enabled && (rows > 0);
      ItemStop.Enabled = state && IsFaCard;
      ItemMoneyLabel.Enabled = state && !IsFaCard;
      ItemMoneyText.Enabled = state && !IsFaCard;
      ItemSingleFa.Enabled = ItemBatchFa.Enabled;
      ItemCardFill.Enabled = ItemSearch.Enabled;
      ItemExit.Enabled = ItemSearch.Enabled;
      dataGrid.Enabled = ItemSearch.Enabled;
      lblCount.Text = string.Format(StrPosition, row, rows);
    }

    private void frmRSEmpCardFa_FormClosed(object sender, FormClosedEventArgs e)
    {
      if (IsFaOk) this.DialogResult = DialogResult.OK;
    }

    private void bindingSource_PositionChanged(object sender, EventArgs e)
    {
      RefreshForm(true);
    }

    private void ItemSearch_Click(object sender, EventArgs e)
    {
      List<string> FieldText = new List<string>();
      List<string> FieldName = new List<string>();
      List<GRFieldType> FieldType = new List<GRFieldType>();
      FieldName.Add("CardStatusName");
      FieldName.Add("CardTypeName");
      FieldName.Add("EmpNo");
      FieldName.Add("EmpName");
      FieldName.Add("DepartID");
      FieldName.Add("DepartName");
      for (int i = 0; i < FieldName.Count; i++)
      {
        FieldText.Add(Pub.GetResText(formCode, FieldName[i], ""));
        FieldType.Add(GRFieldType.grftString);
      }
      frmPubFind frm = new frmPubFind(this.Text + "[" + ItemSearch.Text + "]", OriginSQL,
        Pub.GetSQL(DBCode.DB_001003, new string[] { "302" }), formCode, FieldText, FieldName, FieldType, false);
      if (frm.ShowDialog() == DialogResult.OK)
      {
        QuerySQL = frm.QuerySQL;
        LoadData();
      }
    }

    private void ItemFindText_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Enter) return;
      QuerySQL = Pub.GetSQL(DBCode.DB_001003, new string[] { "107", ItemFindText.Text.Trim(), OprtInfo.DepartPower });
      LoadData();
    }

    private void ItemBatchFa_Click(object sender, EventArgs e)
    {
      FaCard(true, ItemBatchFa.Text);
    }

    private void ItemStop_Click(object sender, EventArgs e)
    {
      IsFaCard = false;
      RefreshForm(true);
      RefreshMsg("");
      lblResult.Text = "";
      string sql = Pub.GetSQL(DBCode.DB_001003, new string[] { "241", SystemInfo.ComputerName });
      try
      {
        db.ExecSQL(sql);
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E, sql);
      }
      if (IsFaOk) LoadData();
    }

    private void ItemSingleFa_Click(object sender, EventArgs e)
    {
      FaCard(false, ItemSingleFa.Text);
    }

    private void ItemCardFill_Click(object sender, EventArgs e)
    {
      frmRSEmpCardFill frm = new frmRSEmpCardFill(ItemCardFill.Text);
      if (frm.ShowDialog() == DialogResult.OK) LoadData();
    }

    private void ItemExit_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void FaCard(bool IsBatch, string Oprt)
    {
      frmAppMain frm = Pub.GetAppMainForm();
      if (SystemInfo.CardKey == "")
      {
        Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorCardkey", ""));
        if (frm != null) frm.ExecModule("SYOption", "");
        return;
      }
      if (SystemInfo.DealersCode == "")
      {
        Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorDealersCode", ""));
        if (frm != null) frm.ExecModule("SYOption", "");
        return;
      }
      if (SystemInfo.CustomersCode == 0)
      {
        Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorCustomersCode", ""));
        if (frm != null) frm.ExecModule("SYOption", "");
        return;
      }
      if (!DeviceObject.objCPIC.IsOnline())
      {
        lblMsg.Text = Pub.GetResText(formCode, "ReadCardError1", "");
        return;
      }
      DateTime d = new DateTime();
      if (!db.GetServerDate(ref d)) return;
      if (Pub.MessageBoxShowQuestion(string.Format(Pub.GetResText(formCode, "MsgServerDate", ""), d))) return;
      double DepositMoney = 0;
      double.TryParse(CurrencyToStringEx(ItemMoneyText.Text), out DepositMoney);
      if (DepositMoney < 0) DepositMoney = 0.00;
      DataTable dt = (DataTable)bindingSource.DataSource;
      DataRow dr = null;
      IsFaCard = true;
      RefreshForm(true);
      string EmpSysID = "";
      string CardSectorNo = "";
      int CardStatusID = 0;
      string msg = "";
      int DepositDiscount = 0;
      int UseTimes = 0;
      DateTime CardStartDate = new DateTime();
      DateTime CardEndDate = new DateTime();
      bool IsFirst = true;
      long CardDays = 0;
      string CardPWD = "";
      string EmpNo = "";
      string EmpName = "";
      int CardTypeID = 0;
      double CardStored = 0.00;
      double DiscountM = 0.00;
      bool CardCheckOrder = false;
      string CardNoDays = "";
      int cardRet = 0;
      string CardData10;
      string CardDataH;
      string CardData8;
      string CardNo10;
      string CardNoH;
      string CardNo8;
      string UseEmpNo = "";
      string ErrMsg = "";
      double CardFee = 0;
      bool IsLock = false;
      string LockOprtNo = "";
      string LockComputerName = "";
      int currRow = bindingSource.Position;
      string MacTAG = DeviceObject.objCPIC.GetMacTAG();
      QHAPI.TCardPubData pubData = new QHAPI.TCardPubData();
      QHAPI.TCardSFData sfData = new QHAPI.TCardSFData();
      QHAPI.TCardSKData skData = new QHAPI.TCardSKData();
      bool IsError = false;
      while (IsFaCard)
      {
        for (int i = currRow; i < dt.Rows.Count; i++)
        {
          bindingSource.Position = i;
          dataGrid.CurrentCell = dataGrid.SelectedRows[0].Cells[0];
          Application.DoEvents();
          dr = dt.Rows[i];
          EmpSysID = dr["EmpSysID"].ToString();
          if (!db.EmpGetCardStatusIDByEmpSysID(EmpSysID, ref CardStatusID, ref IsLock, ref LockOprtNo, ref LockComputerName)) continue;
          if (IsLock || ((CardStatusID != 10) && (CardStatusID != 60))) continue;
          CardSectorNo = dr["CardSectorNo"].ToString();
          CardStartDate = (DateTime)dr["CardStartDate"];
          CardEndDate = (DateTime)dr["CardEndDate"];
          CardPWD = dr["CardPWD"].ToString();
          if ((CardPWD == "") || (!Pub.IsNumeric(CardPWD))) CardPWD = "000000";
          if (Convert.ToInt32(CardPWD) > 999999) CardPWD = "000000";
          EmpNo = dr["EmpNo"].ToString();
          EmpName = dr["EmpName"].ToString();
          CardTypeID = Convert.ToByte(dr["CardTypeID"]);
          DepositDiscount = 0;
          if (!dr.IsNull("DepositDiscount")) DepositDiscount = Convert.ToInt32(dr["DepositDiscount"].ToString());
          CardFee = 0;
          if (!dr.IsNull("CardFee")) CardFee = Convert.ToDouble(dr["CardFee"].ToString());
          UseTimes = 0;
          if (!dr.IsNull("CardUseTimes")) UseTimes = Convert.ToInt32(dr["CardUseTimes"].ToString());
          CardStored = 0.00;
          if (!dr.IsNull("CardStored")) CardStored = Convert.ToDouble(dr["CardStored"]);
          if (!IsBatch && (DepositMoney > 0))
          {
            CardStored = DepositMoney;
            if (SystemInfo.FaCardFee) CardStored -= CardFee;
            if (CardStored < 0)
            {
              CardFee = 0;
              CardStored = 0;
            }
          }
          DiscountM = CardStored;
          double tmpMoney = 0;
          byte DiscFlag = db.GetDiscDiscount(CardStored, CardTypeID, ref tmpMoney);
          if (DiscFlag == 2) break;
          if (DiscFlag == 1)
            DiscountM = DiscountM + tmpMoney;
          else if (DepositDiscount > 0)
            DiscountM = CardStored * DepositDiscount / 100;
          CardCheckOrder = false;
          if (!dr.IsNull("CardCheckOrder")) CardCheckOrder = Pub.ValueToBool(dr["CardCheckOrder"]);
          if (IsFirst)
          {
            IsFirst = false;
            CardDays = Pub.DateDiff(DateInterval.Day, CardStartDate, CardEndDate);
            if (CardDays <= 30)
            {
              msg = Pub.GetResText(formCode, "MsgCardDaySmall", "");
              msg = string.Format(msg, CardDays);
              if (Pub.MessageBoxShowQuestion(msg))
              {
                ItemStop_Click(null, null);
                return;
              }
            }
          }
          if (SystemInfo.AllowCustomerCardNo)
          {
            if ((CardSectorNo == "") || (!Pub.IsNumeric(CardSectorNo)))
            {
              CardSectorNo = db.GetMaxCardSectorNo(EmpSysID);
              if (CardSectorNo == "")
              {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorBuildCardFailed", ""));
                ItemStop_Click(null, null);
                return;
              }
            }
            else if ((CardStatusID == 60) && db.CardSectorNoIsExists(EmpSysID, CardSectorNo, ref CardNoDays))
            {
              if (CardNoDays == " ")
                msg = Pub.GetResText(formCode, "MsgCardExistsBlack", "");
              else if (DateTime.TryParse(CardNoDays, out d))
                msg = Pub.GetResText(formCode, "MsgCardExistsUseDays", "");
              else
                msg = Pub.GetResText(formCode, "MsgCardExistsUseing", "");
              msg = string.Format(msg, CardSectorNo, CardNoDays);
              if (Pub.MessageBoxShowQuestion(msg))
              {
                ItemStop_Click(null, null);
                return;
              }
              CardSectorNo = db.GetMaxCardSectorNo(EmpSysID);
              if (CardSectorNo == "")
              {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorBuildCardFailed", ""));
                ItemStop_Click(null, null);
                return;
              }
            }
            msg = Pub.GetResText(formCode, "MsgCardFaInfo", "");
            msg = string.Format(msg, EmpNo, EmpName, CardSectorNo);
          }
          else
          {
            CardSectorNo = "";
            msg = Pub.GetResText(formCode, "MsgCardFaInfo", "");
            msg = string.Format(msg, EmpNo, EmpName);
          }
          RefreshMsg(msg);
        LoopCard:
          Application.DoEvents();
          if (!IsFaCard)
          {
            ItemStop_Click(null, null);
            return;
          }
          CardData10 = "";
          CardDataH = "";
          CardData8 = "";
          if (!Pub.CheckCardExists(ref CardData10, ref CardDataH, ref CardData8, ref ErrMsg))
          {
            lblResult.Text = ErrMsg;
            goto LoopCard;
          }
          cardRet = db.CheckCardPhysicsNo(EmpSysID, CardData10, ref UseEmpNo);
          if (cardRet == 1)
          {
            lblResult.Text = string.Format(Pub.GetResText(formCode, "MsgCardCheckExistsUseing", ""),
              CardData10, UseEmpNo);
            goto LoopCard;
          }
          else if (cardRet == 2)
          {
            lblResult.Text = string.Format(Pub.GetResText(formCode, "MsgCardExistsBlackAgainA", ""), CardData10);
            goto LoopCard;
          }
          else if (cardRet == 3)
          {
            goto LoopCard;
          }
          pubData = new QHAPI.TCardPubData();
          cardRet = DeviceObject.objCPIC.ReadCardInfoPub(ref pubData);
          if (cardRet != 0)
          {
            lblResult.Text = Pub.GetCardMsg(cardRet);
            goto LoopCard;
          }
          if (pubData.DealersCode != SystemInfo.DealersCode)
          {
            lblResult.Text = Pub.GetResText(formCode, "ErrorIllegalCard", "");
            goto LoopCard;
          }
          if ((pubData.CardNo != "") && (Convert.ToUInt32(pubData.CardNo) > 0))
          {
            lblResult.Text = Pub.GetResText(formCode, "MsgCardFaExists", "");
            goto LoopCard;
          }
          lblResult.Text = Pub.GetResText(formCode, "MsgCardFaing", "");
          if (!SystemInfo.AllowCustomerCardNo) CardSectorNo = CardData10;
          Application.DoEvents();
        LoopCardExists:
          pubData.EmpNo = EmpNo;
          pubData.EmpName = EmpName;
          pubData.CardNo = CardSectorNo;
          pubData.CardTypeID = CardTypeID;
          pubData.CardPWD = CardPWD;
          pubData.DealersCode = SystemInfo.DealersCode;
          pubData.CustomersCode = SystemInfo.CustomersCode;
          pubData.CardBeginDate = CardStartDate.Date;
          pubData.CardEndDate = CardEndDate.Date;
          pubData.IsCheckOrder = Convert.ToByte(CardCheckOrder);
          if (!db.GetServerDate(ref d))
          {
            ItemStop_Click(null, null);
            return;
          }
          sfData = new QHAPI.TCardSFData();
          sfData.Balance = DiscountM;
          sfData.UseDate = d;
          if (sfData.Balance > 0)
            sfData.UseTimes = UseTimes + 1;
          else
            sfData.UseTimes = UseTimes;
          if (DiscountM != CardStored) sfData.UseTimes = sfData.UseTimes + 1;
          sfData.BtMonery = 0;
          sfData.BtDate = "000000";
          skData = new QHAPI.TCardSKData();
          skData.CardID = pubData.CardNo;
          skData.CardTime = d;
          IsError = false;
        ContinuePS:
          Application.DoEvents();
          if (IsError)
          {
            CardNo10 = "";
            CardNoH = "";
            CardNo8 = "";
            if (!Pub.CheckCardExists(ref CardNo10, ref CardNoH, ref CardNo8, false))
            {
              lblResult.Text = Pub.GetResText(formCode, "ReadCardError3", "");
              goto ContinuePS;
            }
            if (CardNo10 != CardData10)
            {
              if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "MsgCardSame", "")))
              {
                db.EmpCardFa(this.Text, Oprt, EmpSysID, CardSectorNo, CardData10, CardData8, CardStored,
                  Convert.ToDateTime(sfData.UseDate), sfData.UseTimes, CardStored, DiscountM, 70, 80, 
                  CardData10, MacTAG);
                IsFaOk = true;
                ItemStop_Click(null, null);
                return;
              }
              else
              {
                goto ContinuePS;
              }
            }
            IsError = false;
          }
          cardRet = Pub.WriteCardInfo(pubData, sfData, skData);
          if (cardRet != 0)
          {
            if (Pub.MessageBoxShowQuestion(Pub.GetCardMsg(cardRet) + Pub.GetResText(formCode, "MsgContinue", "")))
            {
              db.EmpCardFa(this.Text, Oprt, EmpSysID, CardSectorNo, CardData10, CardData8, CardStored,
                Convert.ToDateTime(sfData.UseDate), sfData.UseTimes, CardStored, DiscountM, 70, 80,
                CardData10, MacTAG);
              IsFaOk = true;
              Pub.ClearCardInfo();
              ItemStop_Click(null, null);
              return;
            }
            else
            {
              IsError = true;
              goto ContinuePS;
            }
          }
        ContinueData:
          Application.DoEvents();
          if (db.CardSectorNoIsExists(EmpSysID, CardSectorNo, ref CardNoDays))
          {
            if (CardNoDays == " ")
              msg = Pub.GetResText(formCode, "MsgCardExistsBlackAgain", "");
            else if (DateTime.TryParse(CardNoDays, out d))
              msg = Pub.GetResText(formCode, "MsgCardExistsUseDaysAgain", "");
            else
              msg = Pub.GetResText(formCode, "MsgCardExistsUseingAgain", "");
            msg = string.Format(msg, CardSectorNo, CardNoDays);
            Pub.ClearCardInfo();
            Pub.MessageBoxShow(msg);
            CardSectorNo = db.GetMaxCardSectorNo(EmpSysID);
            if (CardSectorNo == "")
            {
              Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorBuildCardFailed", ""));
              ItemStop_Click(null, null);
              return;
            }
            msg = Pub.GetResText(formCode, "MsgCardFaInfo", "");
            msg = string.Format(msg, EmpNo, EmpName, CardSectorNo);
            RefreshMsg(msg);
            goto LoopCardExists;
          }
          if (!db.EmpCardFa(this.Text, Oprt, EmpSysID, CardSectorNo, CardData10, CardData8, CardStored,
            Convert.ToDateTime(sfData.UseDate), sfData.UseTimes, CardStored, DiscountM, 20, 10, 
            CardData10, MacTAG))
          {
            if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "ErrorCardDB", "")))
            {
              Pub.ClearCardInfo();
              Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgCardFaFailed", ""));
              ItemStop_Click(null, null);
              return;
            }
            else
              goto ContinueData;
          }
          lblResult.Text = Pub.GetResText(formCode, "MsgCardFaSuccess", "");
          IsFaOk = true;
          Pub.CardBuzzer();
          dr["CardSectorNo"] = CardSectorNo;
          dr["CardStatusName"] = CardStatusNormal;
          db.UpdateEmpRegisterData(EmpSysID, 11, CardData10);
        LoopNoCard:
          Application.DoEvents();
          if (!IsBatch || !IsFaCard || (i + 1 == dt.Rows.Count)) break;
          if (DeviceObject.objCPIC.CardIsExists()) goto LoopNoCard;
        }
        IsFaCard = false;
        Application.DoEvents();
      }
      ItemStop_Click(null, null);
      lblResult.Text = "";
      lblMsg.Text = Pub.GetResText(formCode, "MsgOprtComplete", "");
    }

    private void frmRSEmpCardFa_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (IsFaCard) e.Cancel = true;
    }
  }
}