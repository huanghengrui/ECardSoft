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
    public partial class frmSFReportSFDetail : frmBaseMDIChildReportPrint
    {
        private IGRField IsAlarmField = null;
        private string CardData10 = "";
        private string CardDataH = "";
        private string CardData8 = "";
        private HSUNFK.TCardPubData pubData = new HSUNFK.TCardPubData();
        private HSUNFK.TCardSFData sfData = new HSUNFK.TCardSFData();
        private bool IsWorking = false;
        private bool OkContinue = true;
        private bool IsReadCard = false;
        protected override void InitForm()
        {
            formCode = "SFReportSFDetail";
            ReportFile = "SFReportSFDetail";

            base.InitForm();

            //clbSFType.Size = new System.Drawing.Size(200, 491);
            SetToolItemState("ItemTAG1", true);
            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
            dtpEnd.Value = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            dtpStart.CustomFormat = SystemInfo.DateTimeFormat;
            dtpEnd.CustomFormat = SystemInfo.DateTimeFormat;
            Report.Initialize += new _IGridppReportEvents_InitializeEventHandler(Report_Initialize);
            Report.SectionFormat += new _IGridppReportEvents_SectionFormatEventHandler(Report_SectionFormat);
            GetCardTypeList();
            for (int i = 0; i < cardTypeList.Count; i++)
            {
                clbCardType.Items.Add(cardTypeList[i]);
                clbCardType.SetItemChecked(clbCardType.Items.Count - 1, false);
            }
            DataTableReader dr = null;
            TCommonType cType;
            try
            {
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004011, new string[] { "0" }));
                while (dr.Read())
                {
                    cType = new TCommonType(dr["SFTypeSysID"].ToString(), dr["SFTypeID"].ToString(), dr["SFTypeName"].ToString(), true);
                    clbSFType.Items.Add(cType);
                    clbSFType.SetItemChecked(clbSFType.Items.Count - 1, false);
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
            try
            {
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004005, new string[] { "2" }));
                while (dr.Read())
                {
                    cType = new TCommonType(dr["MealTypeSysID"].ToString(), dr["MealTypeID"].ToString(),
                      dr["MealTypeName"].ToString(), true);
                    clbMealType.Items.Add(cType);
                    clbMealType.SetItemChecked(clbMealType.Items.Count - 1, false);
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
            try
            {
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004004, new string[] { "0" }));
                while (dr.Read())
                {
                    clbMacSN.Items.Add(dr["MacSN"].ToString());
                    clbMacSN.SetItemChecked(clbMacSN.Items.Count - 1, false);
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
            clbMacSN.Items.Add("255");
            clbMacSN.SetItemChecked(clbMacSN.Items.Count - 1, false);
            chkCardType_CheckedChanged(null, null);
            chkSFType_CheckedChanged(null, null);
            chkSFMealType_CheckedChanged(null, null);
            chkMacSN_CheckedChanged(null, null);
            btnAddress.Text = btnSelectEmp.Text;
            //SetToolItemState("ItemTAG7", true);

        }

        protected override void ExecItemTAG7()
        {
            base.ExecItemTAG7();
            //ShowCardView(true);
            ExecItemRefresh();
        }

        public frmSFReportSFDetail()
        {
            InitializeComponent();
        }

        protected override void ExecItemRefresh()
        {
            string EmpTag = "0";
            string EmpNo = "";
            string DepartTag = "0";
            string DepartID = "";
            string DepartList = "";
            string CardType = "";
            string SFType = "";
            string MealType = "";
            string MacSN = "";
            string AddressTag = "0";
            string AddressID = "";
            string AddressList = "";
            string CardNo = "";
            if ((txtEmp.Text.Trim() != "") && (txtEmp.Tag != null))
            {
                EmpNo = txtEmp.Tag.ToString();
                EmpTag = "1";
            }
            else if (txtEmp.Text.Trim() != "")
            {
                EmpNo = txtEmp.Text.Trim();
            }
            if (txtCardNo.Text.Trim() != "")
            {
                CardNo = txtCardNo.Text.Trim();
            }
            if ((txtDepart.Text.Trim() != "") && (txtDepart.Tag != null))
            {
                DepartID = txtDepart.Tag.ToString();
                DepartTag = "1";
            }
            else if (txtDepart.Text.Trim() != "")
            {
                DepartID = txtDepart.Text.Trim();
            }
            if (DepartTag == "1")
            {
                if (DepartID != "") DepartList = db.GetDepartChildID(DepartID);
                if (DepartList == "") DepartList = "''";
            }
            if (chkCardType.Checked)
            {
                for (int i = 0; i < clbCardType.Items.Count; i++)
                {
                    if (clbCardType.GetItemChecked(i)) CardType = CardType + ((TCardType)clbCardType.Items[i]).id.ToString() + ",";
                }
                if (CardType != "") CardType = CardType.Substring(0, CardType.Length - 1);
            }
            if (chkSFType.Checked)
            {
                for (int i = 0; i < clbSFType.Items.Count; i++)
                {
                    if (clbSFType.GetItemChecked(i)) SFType = SFType + ((TCommonType)clbSFType.Items[i]).id + ",";
                }
                if (SFType != "") SFType = SFType.Substring(0, SFType.Length - 1);
            }
            if (chkSFMealType.Checked)
            {
                for (int i = 0; i < clbMealType.Items.Count; i++)
                {
                    if (clbMealType.GetItemChecked(i)) MealType = MealType + ((TCommonType)clbMealType.Items[i]).id + ",";
                }
                if (MealType != "") MealType = MealType.Substring(0, MealType.Length - 1);
            }
            if (chkMacSN.Checked)
            {
                for (int i = 0; i < clbMacSN.Items.Count; i++)
                {
                    if (clbMacSN.GetItemChecked(i)) MacSN = MacSN + "'" + clbMacSN.Items[i].ToString() + "',";
                }
                if (MacSN != "") MacSN = MacSN.Substring(0, MacSN.Length - 1);
            }
            if ((txtAddress.Text.Trim() != "") && (txtAddress.Tag != null))
            {
                AddressID = txtAddress.Tag.ToString();
                AddressTag = "1";
            }
            else if (txtAddress.Text.Trim() != "")
            {
                AddressID = txtAddress.Text.Trim();
            }
            if (AddressTag == "1")
            {
                if (AddressID != "") AddressList = db.GetAddressChildID(AddressID);
                if (AddressList == "") AddressList = "''";
            }
            QuerySQL = Pub.GetSQL(DBCode.DB_004011, new string[] { "1", EmpTag, EmpNo, DepartTag, DepartID, DepartList, CardType, SFType,
        MealType, MacSN, dtpStart.Value.ToString(SystemInfo.SQLDateTimeFMT), dtpEnd.Value.ToString(SystemInfo.SQLDateTimeFMT),
        OprtInfo.DepartPower, AddressTag, AddressID, AddressList, Convert.ToByte(chkShowAlarm.Checked).ToString(),CardNo });
            SetReportDate(dispView, label4.Text + ": " + dtpStart.Value.ToString() + " - " + dtpEnd.Value.ToString());
            base.ExecItemRefresh();
            SetReportTitle(dispView, this.Text);
          
        }

        private string GetSFAmount()
        {
            return Report.FieldByName("SFAmount").AsString;
        }

        private string GetBTAmount()
        {
            return Report.FieldByName("BTAmount").AsString;
        }

        private string GetCardNo()
        {
            return Report.FieldByName("CardNo").AsString;
        }

        private string GetSFTypeID()
        {
            return Report.FieldByName("SFTypeID").AsString;
        }

        private void btnSelectEmp_Click(object sender, EventArgs e)
        {
            frmPubSelectEmp frm = new frmPubSelectEmp();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtEmp.Text = frm.EmpName;
                txtEmp.Tag = frm.EmpNo;
                ExecItemRefresh();
            }
        
        }

        private void btnSelectDepart_Click(object sender, EventArgs e)
        {
            frmPubSelectDepart frm = new frmPubSelectDepart();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtDepart.Text = frm.DepartName;
                txtDepart.Tag = frm.DepartID;
                ExecItemRefresh();
            }
         
        }

        protected override void ExecItemTAG1()
        {
            base.ExecItemTAG1();
            int ID = int.Parse(GetSFTypeID());
            if (ID != 1 && ID != 3 && ID != 6 && ID != 7 && ID != 8 && ID != 60)
            {
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorOprt", ""));
                return;
            }
            if (!db.CheckOprtRole(formCode, "M", true)) return;
            IsReadCard = ReadCard();
            if (!IsReadCard) return;
            if (IsWorking) return;
            IsWorking = true;
            WriteCard();
            IsWorking = false;
            ExecItemRefresh();
          
        }

        private bool ReadCard()
        {
            CardData10 = "";
            CardDataH = "";
            CardData8 = "";
            if (!Pub.CheckCardExists(ref CardData10, ref CardDataH, ref CardData8)) return false;
            pubData = new HSUNFK.TCardPubData();
            sfData = new HSUNFK.TCardSFData();
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
                if (pubData.CardNo != GetCardNo())
                {
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorCard", ""));
                    return false;
                }
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "215", pubData.CardNo }));
                if (dr.Read())
                {
                    if (Convert.ToInt32(dr["CardStatusID"]) != 20)
                    {
                        Pub.ShowErrorMsg(Pub.GetResText(formCode, "MsgCardRefunNotNormal", ""));
                    }
                    else if (!Convert.ToBoolean(dr["CardRefundment"].ToString()))
                    {
                        Pub.ShowErrorMsg(string.Format(Pub.GetResText("", "ErrorCardRefundment", ""),
                          dr["CardTypeName"].ToString()));
                    }
                    else
                    {
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

        private void WriteCard()
        {
            string DepositType = "120";
            double money = 0;
            double BTmoney = 0;
            double Fact = 0;
            double.TryParse(CurrencyToStringEx(GetSFAmount()), out money);
            double.TryParse(CurrencyToStringEx(GetBTAmount()), out BTmoney);
            money = Math.Abs(money);
            BTmoney = Math.Abs(BTmoney);
            frmPubCorrection frm = new frmPubCorrection(money,BTmoney);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                money = frm.Money;
                BTmoney = frm.MoneyBT;
            }
            else
            {
                return;    
            }
            if (money <= 0 && BTmoney <= 0)
            {
                IsReadCard = false;
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorMoneyZero", ""));
                return;
            }
            if (!ReadCard()) return;
            DateTime dt = new DateTime();
            if (!db.GetServerDate(this.Text, ref dt))
            {
                IsReadCard = false;
                return;
            }
            if (!Pub.CheckUseDate(dt, sfData.UseDate))
            {
                IsReadCard = false;
                return;
            }
            Pub.ClearCardLimitInfo(dt, ref sfData);
            double AllBalance = sfData.Balance;

            List<string> sql = new List<string>();
            sql.Clear();
            string Title = Pub.GetResText(formCode, "DepositTitle", "");
            double Amount = money + BTmoney;
            double ReceivablesAmount = Fact;
            double CardBalance = AllBalance + Fact;
            sfData.Balance = sfData.Balance + money;
            sfData.BtMonery = sfData.BtMonery + BTmoney;
            sfData.UseTimes = sfData.UseTimes + 1;
            sfData.UseDate = dt;
            double mm = sfData.Balance;
            double BTmm = sfData.BtMonery;
            string OpterStartDate = "";
            string OpterEndDate = "";
            DataTableReader dr = null;
            DateTime StartDt = new DateTime();
            DateTime EndDt = new DateTime();
            dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "251", pubData.CardNo }));
            while (dr.Read())
            {
                OpterStartDate = "";
                OpterEndDate = "";
                OpterStartDate = dr["OpterStartDate"].ToString();
                OpterEndDate = dr["OpterEndDate"].ToString();
                if (OpterStartDate != "")
                {
                    StartDt = Convert.ToDateTime(OpterStartDate);
                }
                if (OpterEndDate != "")
                {
                    EndDt = Convert.ToDateTime(OpterEndDate);
                }
                if (OpterStartDate != "" && OpterEndDate != "")
                {
                    if (dt > StartDt && dt < EndDt)
                    {
                        break;
                    }
                }
                else if (OpterStartDate != "" && OpterEndDate == "")
                {
                    if (dt > StartDt)
                    {
                        OpterEndDate = dt.ToString(SystemInfo.SQLDateTimeFMT);
                        break;
                    }
                }

            }
            if (OpterStartDate != "")
                OpterStartDate = Convert.ToDateTime(OpterStartDate).ToString(SystemInfo.SQLDateTimeFMT);
            if (OpterEndDate != "")
                OpterEndDate = Convert.ToDateTime(OpterEndDate).ToString(SystemInfo.SQLDateTimeFMT);
            sql.Add(Pub.GetSQL(DBCode.DB_004005, new string[] { "0", pubData.CardNo, DepositType,
        dt.ToString(SystemInfo.SQLDateTimeFMT), money.ToString(), mm.ToString(), "0", "", "0",
        sfData.UseTimes.ToString(), OprtInfo.OprtSysID, "", "1", "", CardData10, pubData.MacTAG, "",BTmoney.ToString(), BTmm.ToString(),"0",OpterStartDate, OpterEndDate }));

            if (db.ExecSQL(sql) != 0)
            {
                IsReadCard = false;
                return;
            }
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
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "ReadCardError3", ""));
                    goto ContinueSF;
                }
                if (CardNo10 != CardData10)
                {
                    if (OkContinue)
                    {
                        Pub.ShowErrorMsg(Pub.GetResText(formCode, "MsgCardSame", "") + "\r\n\r\n" +
                          Pub.GetResText(formCode, "MsgCardOkContinue", ""));
                        goto ContinueSF;
                    }
                    else
                    {
                        if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "MsgCardSame", "")))
                        {
                            IsReadCard = false;
                            return;
                        }
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
                    Pub.ShowErrorMsg(Pub.GetCardMsg(cardRet) + "\r\n\r\n" + Pub.GetResText(formCode, "MsgCardOkContinue", ""));
                    IsSFError = true;
                    goto ContinueSF;
                }
                else
                {
                    if (Pub.MessageBoxShowQuestion(Pub.GetCardMsg(cardRet) + Pub.GetResText(formCode, "MsgContinue", "")))
                    {
                        IsReadCard = false;
                        return;
                    }
                    else
                    {
                        IsSFError = true;
                        goto ContinueSF;
                    }
                }
            }
            double temp = sfData.Balance;
            Pub.CardBuzzer();
            string CurrentOprt = Pub.GetResText(formCode, "ItemEdit", "");
            string msg = string.Format("[{0:f2},{1:f2}]", Amount, temp);
            db.WriteSYLog(this.Text, CurrentOprt, msg);
            DispExtScreen(Amount, temp, 0, 1);
            Pub.MessageBoxShow(CurrentOprt + Pub.GetResText(formCode, "MsgSuccess", ""), MessageBoxIcon.Asterisk);
            IsReadCard = false;
        }

        private void btnAddress_Click(object sender, EventArgs e)
        {
            frmPubSelectAddress frm = new frmPubSelectAddress();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtAddress.Text = frm.AddressName;
                txtAddress.Tag = frm.AddressID;
            }
        }

        private void chkCardType_CheckedChanged(object sender, EventArgs e)
        {
            clbCardType.Enabled = chkCardType.Checked;
        }

        private void chkSFType_CheckedChanged(object sender, EventArgs e)
        {
            clbSFType.Enabled = chkSFType.Checked;
        }

        private void chkSFMealType_CheckedChanged(object sender, EventArgs e)
        {
            clbMealType.Enabled = chkSFMealType.Checked;
        }

        private void chkMacSN_CheckedChanged(object sender, EventArgs e)
        {
            clbMacSN.Enabled = chkMacSN.Checked;
        }

        private void Report_Initialize()
        {
            IsAlarmField = dispView.Report.FieldByName("IsAlarm");
        }

        private void Report_SectionFormat(IGRSection pSender)
        {
            try
            {
                if (IsAlarmField == null) return;
                if (IsAlarmField.AsBoolean)
                {
                    for (int i = 1; i <= dispView.Report.DetailGrid.ColumnContent.ContentCells.Count; i++)
                    {
                        dispView.Report.DetailGrid.ColumnContent.ContentCells[i].ForeColor = Pub.ColorToOleColor(Color.Red);
                    }
                }
                else
                {
                    for (int i = 1; i <= dispView.Report.DetailGrid.ColumnContent.ContentCells.Count; i++)
                    {
                        dispView.Report.DetailGrid.ColumnContent.ContentCells[i].ForeColor = Pub.ColorToOleColor(Color.Black);
                    }
                }
            }
            catch
            {
            }
        }

        private void chkShowAlarm_Click(object sender, EventArgs e)
        {
            ExecItemRefresh();
        }

        protected override void ExecKeyDown(KeyEventArgs e)
        {
            base.ExecKeyDown(e);
            if (e.Control && e.Alt)
            {
                switch (e.KeyCode)
                {
                    case Keys.M:
                        chkShowAlarm.Enabled = true;
                        chkShowAlarm.Visible = true;
                        break;
                    case Keys.L:
                        appMainForm.ExecModule("SFReportLoss", "SF");
                        break;
                    case Keys.A:
                        appMainForm.ExecModule("SFReportAlarm", "SF");
                        break;
                    case Keys.E:
                        appMainForm.ExecModule("SFReportError", "SF");
                        break;
                    case Keys.R:
                        appMainForm.ExecModule("SFReportReturn", "SF");
                        break;
                    case Keys.O:
                        appMainForm.ExecModule("SFReportDataOrder", "SF");
                        break;
                        /*case Keys.I:
                          appMainForm.ExecModule("SFReportAirData", "SF");
                          break;*/
                }
            }
        }

        private void txtEmp_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtEmp.Tag = null;
        }

        private void txtDepart_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtDepart.Tag = null;
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtAddress.Tag = null;
        }

        private void btnCardNo_Click(object sender, EventArgs e)
        {
            HSUNFK.TCardPubData pubData = new HSUNFK.TCardPubData();
            HSUNFK.TCardSFData sfData = new HSUNFK.TCardSFData();
            if (!Pub.ReadCardInfo(ref pubData, ref sfData)) return;
            txtCardNo.Text = pubData.CardNo;
            ExecItemRefresh();
        }
    }
}