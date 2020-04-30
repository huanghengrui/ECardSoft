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
        private HSUNFK.TCardPubData pubData = new HSUNFK.TCardPubData();
        private HSUNFK.TCardSFData sfData = new HSUNFK.TCardSFData();
        private bool IsWorking = false;
        private int Discount = 0;
        private bool ExistsDepositType = false;
        private bool OkContinue = true;
        private TMobileInfo MobileInfo;
        private double CardDepositLimit = 0;
        private int CardDepositTimes = 0;
        private string EmpSysID = "";
        private bool AllowPayCode = false;
        private bool AllowPayUSB = false;
        private bool IsReadCard = false;
        private int countTimes = 0;
        private double countMoney = 0;

        protected override void InitForm()
        {
            formCode = "SFDeposit";
            base.InitForm();
            this.Text = Pub.GetResText(formCode, "mnu" + formCode, "", new string[] { "Main" });
            txtMoney.Enter += TextBoxCurrency_Enter;
            txtMoney.Leave += TextBoxCurrency_Leave;
            double d = SystemInfo.DefDepositMoney;
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
            txtMoney.Focus();
            toolTip.SetToolTip(picDisc, Pub.GetResText(formCode, "DiscHint", ""));
            cbbType.Enabled = ExistsDepositType;
            cbbType.Visible = cbbType.Enabled;
            label7.Visible = cbbType.Enabled;
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
            IsReadCard = ReadCard();
            if (!IsReadCard) return;
            Pub.CardBuzzer();
            double ShowBTMoney = db.GetBTMoney(sfData.BtDate, sfData.BtMonery);
            double AllBalance = sfData.Balance + ShowBTMoney;
            txtCardBalance.Text = AllBalance.ToString(SystemInfo.CurrencySymbol + "0.00");
            if (SystemInfo.AllowCheckDepositLimit == 3)
            {
                string msg = label1.Text + ": " + txtEmpNo.Text + "\r\n";
                msg += label2.Text + ": " + txtEmpName.Text + "\r\n";
                msg += label4.Text + ": " + txtDepartName.Text + "\r\n";
                msg += label3.Text + ": " + txtCardType.Text + "\r\n\r\n";
                msg += "本月累计已经充值次数: " + countTimes.ToString() + "\r\n";
                msg += "本月累计已经充值金额: " + countMoney.ToString(SystemInfo.CurrencySymbol + "0.00") + "\r\n";
                Form frm = new Form();
                frm.Text = this.Text;
                frm.FormBorderStyle = FormBorderStyle.FixedDialog;
                frm.MaximizeBox = false;
                frm.MinimizeBox = false;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Width = 600;
                frm.Height = 360;
                Label lab = new Label();
                lab.Text = msg;
                lab.AutoSize = false;
                lab.Left = 0;
                lab.Top = 0;
                lab.Width = frm.ClientSize.Width;
                lab.Height = frm.ClientSize.Height - 50;
                lab.TextAlign = ContentAlignment.MiddleLeft;
                lab.Font = new Font(Font.Name, 20, FontStyle.Bold);
                Button btn = new Button();
                btn.Text = Pub.GetResText("Public", "btnOk", "");
                btn.Width = 100;
                btn.Height = 40;
                btn.Left = (lab.Width - btn.Width) / 2;
                btn.Top = lab.Top + lab.Height;
                btn.DialogResult = DialogResult.OK;
                frm.Controls.Add(lab);
                frm.Controls.Add(btn);
                frm.ShowDialog();
            }
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
                double d = SystemInfo.DefDepositMoney;
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
            string TradeNo = "";
            double DiscountMoney = 0;
            int DiscountType = 0;
            double.TryParse(CurrencyToStringEx(txtMoney.Text), out money);
            if (money <= 0)
            {
                IsReadCard = false;
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorMoneyZero", ""));
                return;
            }
            double MobileMoney = money;
            if (!SystemInfo.IgnoreMobile && (DepositType == "100" || DepositType == "101"))
            {
                money -= MobileInfo.RateMoney(DepositType == "100", MobileMoney);
            }
            Fact = money;
            if (SystemInfo.AllowCheckDepositLimit == 3)
            {
                if (!IsReadCard)
                {
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "MsgCardReadFirst", ""));
                    return;
                }
            }
            else
            {
                if (!ReadCard()) return;
            }
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
            txtCardBalance.Text = AllBalance.ToString(SystemInfo.CurrencySymbol + "0.00");
            double tmpMoney = 0;
            byte discFlag = db.GetDiscDiscount(money, pubData.CardTypeID, ref tmpMoney);
            if (discFlag == 2)
            {
                IsReadCard = false;
                return;
            }
            if (discFlag == 1)
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
                IsReadCard = false;
                Pub.ShowErrorMsg(string.Format(Pub.GetResText(formCode, "ErrorBalanceIsBig", ""), SystemInfo.MaxDeposit));
                return;
            }
            if (SystemInfo.AllowCheckDepositLimit == 1)
            {
                if (CardDepositLimit > 0 && sfData.Balance + Fact >= CardDepositLimit)
                {
                    IsReadCard = false;
                    Pub.ShowErrorMsg(string.Format(Pub.GetResText(formCode, "ErrorBalanceIsBigA", ""), CardDepositLimit));
                    return;
                }
            }
            else if (SystemInfo.AllowCheckDepositLimit == 2)
            {
                if (!db.CheckDepositLimit(EmpSysID, CardDepositLimit, CardDepositTimes, Fact))
                {
                    IsReadCard = false;
                    return;
                }
            }
            if (!SystemInfo.IgnoreMobile && (DepositType == "100" || DepositType == "101"))
            {
                int h = SystemInfo.MainHandle.ToInt32();
                bool IsWeiXin = DepositType == "100", ret;
                bool IsPayM = false;
                string ErrMsg = "";
                TradeNo = "";
                if (chkPayCode.Checked)
                {
                    DeviceObject.objCard.MobilePayCodeSet(cbbCommPort.Text);
                    ret = DeviceObject.objCard.MobilePayCode(h, chkPayCodeUSB.Checked, CardData10, pubData.CardNo, MobileMoney, ref IsWeiXin, ref IsPayM, true, ref TradeNo, ref ErrMsg);
                }
                else
                    ret = DeviceObject.objCard.MobileShow(h, CardData10, pubData.CardNo, MobileMoney, ref IsWeiXin, ref IsPayM, true, ref TradeNo, ref ErrMsg);
                if (!ret)
                {
                    IsReadCard = false;
                    Pub.ShowErrorMsg(ErrMsg);
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
            double mm = sfData.Balance;
            string OpterStartDate = "";
            string OpterEndDate = "";
            string OpterEndDate0 = "";
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
                        OpterEndDate0 = dt.AddSeconds(1).ToString(SystemInfo.SQLDateTimeFMT);
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
        sfData.UseTimes.ToString(), OprtInfo.OprtSysID, "", "1", "", CardData10, pubData.MacTAG, TradeNo,"0", sfData.BtMonery.ToString(),"0",OpterStartDate, OpterEndDate }));
            if (DiscountMoney != 0)
            {
                sfData.Balance = sfData.Balance + DiscountMoney;
                sfData.UseTimes = sfData.UseTimes + 1;
                mm = sfData.Balance;
                sql.Add(Pub.GetSQL(DBCode.DB_004005, new string[] { "0", pubData.CardNo, DiscountType.ToString(),
          dt.AddSeconds(1).ToString(SystemInfo.SQLDateTimeFMT), DiscountMoney.ToString(),
          mm.ToString(), "0", "", "0", sfData.UseTimes.ToString(), OprtInfo.OprtSysID, "", "1", "",
          CardData10, pubData.MacTAG, TradeNo ,"0", sfData.BtMonery.ToString(),"0",OpterStartDate, OpterEndDate0 }));
            }
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
            string msg = "[" + txtEmpNo.Text + "]" + txtEmpName.Text + ": " + txtCardSectorNo.Text + "/" + txtDepartName.Text;
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
            double temp = sfData.Balance+sfData.BtMonery;
            txtCardBalance.Text = temp.ToString(SystemInfo.CurrencySymbol + "0.00");
            Pub.CardBuzzer();
            msg = msg + string.Format("[{0:f2},{1:f2}]", Amount, temp);
            db.WriteSYLog(this.Text, CurrentOprt, msg);
            DispExtScreen(Amount, temp, 0, 1);
            if (chkPrint.Checked)
            {
                PrintCardBill(Title, Amount, ReceivablesAmount, CardBalance, AmountTitle, pubData.CardNo);
            }
            lblResult.Text = this.Text + Pub.GetResText(formCode, "MsgSuccess", "");
            IsReadCard = false;
        }

        private bool ReadCard()
        {
            countTimes = 0;
            countMoney = 0;
            CardDepositLimit = 0;
            CardDepositTimes = 0;
            CardData10 = "";
            CardDataH = "";
            CardData8 = "";
            EmpSysID = "";
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
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "215", pubData.CardNo }));
                if (dr.Read())
                {
                    if (Convert.ToInt32(dr["CardStatusID"]) != 20)
                    {
                        Pub.ShowErrorMsg(Pub.GetResText(formCode, "MsgCardDepositNotNormal", ""));
                    }
                    else
                    {
                        EmpSysID = dr["EmpSysID"].ToString();
                        txtEmpNo.Text = dr["EmpNo"].ToString();
                        txtEmpName.Text = dr["EmpName"].ToString();
                        txtDepartName.Text = dr["DepartName"].ToString();
                        txtCardSectorNo.Text = dr["CardSectorNo"].ToString();
                        txtCardStatusName.Text = dr["CardStatusName"].ToString();
                        txtCardType.Text = dr["CardTypeName"].ToString();
                        int.TryParse(dr["DepositDiscount"].ToString(), out Discount);
                        txtDepositDiscount.Text = Discount.ToString();
                        double.TryParse(dr["CardDepositLimit"].ToString(), out CardDepositLimit);
                        int.TryParse(dr["CardDepositTimes"].ToString(), out CardDepositTimes);
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
            if (IsOk && SystemInfo.AllowCheckDepositLimit == 3)
            {
                IsOk = false;
                try
                {
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004013, new string[] { "200", EmpSysID }));
                    if (dr.Read())
                    {
                        double.TryParse(dr["SFAmount"].ToString(), out countMoney);
                        int.TryParse(dr["Times"].ToString(), out countTimes);
                        IsOk = true;
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

        private void txtMoney_TextChanged(object sender, EventArgs e)
        {
            lblShowMoney.Text = txtMoney.Text;
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
    }
}