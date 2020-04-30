using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSFRefundment : frmBaseDialog
    {
        private string CardData10 = "";
        private string CardDataH = "";
        private string CardData8 = "";
        private HSUNFK.TCardPubData pubData = new HSUNFK.TCardPubData();
        private HSUNFK.TCardSFData sfData = new HSUNFK.TCardSFData();
        private bool IsWorking = false;
        private bool ExistsDepositType = false;
        private bool ExistsRefundmentType = false;
        private bool OkContinue = true;
        private int Discount = 0;
        private bool IsReadCard = false;

        protected override void InitForm()
        {
            formCode = "SFRefundment";
            base.InitForm();
            this.Text = Pub.GetResText(formCode, "mnu" + formCode, "", new string[] { "Main" });
            txtMoney.Enter += TextBoxCurrency_Enter;
            txtMoney.Leave += TextBoxCurrency_Leave;
            if (SystemInfo.AllowRefAllowance)
                txtMoneyBT.Enabled = true;
            double d = 0;
            txtMoney.Text = d.ToString(SystemInfo.CurrencySymbol + "0.00");
            txtMoneyBT.Text = d.ToString(SystemInfo.CurrencySymbol + "0.00");
            ExistsDepositType = SystemInfo.HasMoreDepositType;
            if (ExistsDepositType)
            {
                DataTableReader dr = null;
                try
                {
                    if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004013, new string[] { "0" }));
                    if (!dr.Read()) ExistsDepositType = false;
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
            txtUpDepositType.Enabled = ExistsDepositType;
            txtUpDepositType.Visible = txtUpDepositType.Enabled;
            lblUpDepositType.Visible = txtUpDepositType.Enabled;
            ExistsRefundmentType = SystemInfo.DefMoreRefundmentType;
            if (ExistsRefundmentType)
            {
                cbbType.Items.Clear();
                DataTableReader dr = null;
                try
                {
                    if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004014, new string[] { "102" }));
                    if (dr.Read())
                        cbbType.Items.Add(new TCommonType(dr["SFTypeSysID"].ToString(), dr["SFTypeID"].ToString(),
                            dr["SFTypeName"].ToString(), true));
                    dr.Close();
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004014, new string[] { "0" }));
                    while (dr.Read())
                    {
                        cbbType.Items.Add(new TCommonType(dr["GUID"].ToString(), dr["RefundmentTypeID"].ToString(),
                          dr["RefundmentTypeName"].ToString(), true));
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
                if (cbbType.Items.Count == 1) ExistsRefundmentType = false;
            }
            txtMoney.Focus();
            cbbType.Enabled = ExistsRefundmentType;
            cbbType.Visible = cbbType.Enabled;
            label7.Visible = cbbType.Enabled;
            OkContinue = SystemInfo.ini.ReadIni("Public", "CardOk", true);
            chkPrint.Checked = SystemInfo.ini.ReadIni("Public", "CheckPrint", false);
            label8.Enabled = SystemInfo.AllowCheckDepositLimit == 3;
            textBox1.Visible = SystemInfo.AllowCheckDepositLimit == 3;
            label8.Enabled = SystemInfo.AllowCheckDepositLimit == 3;
            textBox1.Visible = SystemInfo.AllowCheckDepositLimit == 3;
            SetTextboxNumber(textBox1);
        }

        public frmSFRefundment()
        {
            InitializeComponent();
        }

        private void btnReadCard_Click(object sender, EventArgs e)
        {
            ResetForm();
            IsReadCard = ReadCard();
            if (!IsReadCard) return;
            Pub.CardBuzzer();
            double CardBTBalance = 0;
            double ShowBTMoney = db.GetBTMoney(sfData.BtDate, sfData.BtMonery);
            if (!SystemInfo.AllowRefAllowance)
            {
                lbBTget.Visible = false;
                lbBTNotget.Visible = true;
                CardBTBalance = 0;
            }/*ShowBTMoney = 0*/
            else
            {
                lbBTget.Visible = true;
                lbBTNotget.Visible = false;
                CardBTBalance = ShowBTMoney;
            }
            double AllBalance = sfData.Balance;
            double BTBalance = ShowBTMoney;

            txtCardBalance.Text = AllBalance.ToString(SystemInfo.CurrencySymbol + "0.00");
            txtMoney.Text = AllBalance.ToString(SystemInfo.CurrencySymbol + "0.00");
            txtBTBalance.Text = BTBalance.ToString(SystemInfo.CurrencySymbol + "0.00");
            txtMoneyBT.Text = CardBTBalance.ToString(SystemInfo.CurrencySymbol + "0.00");
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
                txtMoneyBT.Text = d.ToString(SystemInfo.CurrencySymbol + "0.00");
            }
            txtMoney.Focus();
            SystemInfo.ini.WriteIni("Public", "CheckPrint", chkPrint.Checked);
        }

        private void WriteCard()
        {
            ResetForm();
            CurrentOprt = btnOk.Text;
            string RefundmentType = "20";
            string AmountTitle = label6.Text;
            double dtm = 0;
            if (ExistsRefundmentType)
            {
                RefundmentType = ((TCommonType)cbbType.Items[cbbType.SelectedIndex]).id;
                AmountTitle = cbbType.Text;
            }
            double money = 0;
            double.TryParse(CurrencyToStringEx(txtMoney.Text), out money);
            double moneyBT = 0;
            double.TryParse(CurrencyToStringEx(txtMoneyBT.Text), out moneyBT);
            if (money <= 0 && moneyBT <= 0)
            {
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorMoneyZero", ""));
                return;
            }
            if (SystemInfo.AllowCheckDepositLimit == 3)
            {
                if (!IsReadCard)
                {
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "MsgCardReadFirst", ""));
                    return;
                }
                if (textBox1.Enabled) int.TryParse(textBox1.Text.Trim(), out Discount);
            }
            else
            {
                if (!ReadCard()) return;
            }
            DateTime dt = new DateTime();
            if (!db.GetServerDate(this.Text, ref dt)) return;
            if (!Pub.CheckUseDate(dt, sfData.UseDate)) return;
            Pub.ClearCardLimitInfo(dt, ref sfData);
            double ShowBTMoney = db.GetBTMoney(sfData.BtDate, sfData.BtMonery);
            if (!SystemInfo.AllowRefAllowance) ShowBTMoney = 0;
            double AllBalance = sfData.Balance;
            txtCardBalance.Text = AllBalance.ToString(SystemInfo.CurrencySymbol + "0.00");
            double BTBalance = ShowBTMoney;
            txtBTBalance.Text = BTBalance.ToString(SystemInfo.CurrencySymbol + "0.00");
            if (AllBalance < money)
            {
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorBalanceNotEnough", ""));
                return;
            }
            if (BTBalance < moneyBT)
            {
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorBalanceNotEnough", ""));
                return;
            }
            sfData.UseDate = dt;
            sfData.UseTimes += 1;
            List<string> sql = new List<string>();
            sql.Clear();
            DataTableReader dr = null;
            string OpterStartDate = "";
            string OpterEndDate = "";
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
            if (ShowBTMoney == 0)
            {
                sfData.Balance -= money;
                if (sfData.BtMonery > 0 && SystemInfo.AllowRefAllowance)
                {
                    double m = -sfData.BtMonery;
                    sql.Add(Pub.GetSQL(DBCode.DB_004005, new string[] { "0", pubData.CardNo, "0",
            dt.ToString(SystemInfo.SQLDateTimeFMT),"0",  sfData.Balance.ToString(), "0", "", "0",
            sfData.UseTimes.ToString(), OprtInfo.OprtSysID, "", "1", "", CardData10, pubData.MacTAG, "",
            sfData.BtMonery.ToString(),m.ToString(),"0","0",OpterStartDate,OpterEndDate}));
                    sfData.UseTimes += 1;
                    sfData.BtMonery = 0;
                }
            }
            else
            {
                //double olddtm = sfData.BtMonery;
                //sfData.BtMonery -= money;
                //dtm = -money;
                //if (sfData.BtMonery < 0)
                //{
                //  sfData.Balance += sfData.BtMonery;
                //  sfData.BtMonery = 0;
                //  dtm = -olddtm;
                //}
                dtm = -moneyBT;
                sfData.BtMonery -= moneyBT;
            }
            double DiscountMoney = 0;
            double mm = 0;
            if (SystemInfo.AllowCheckDepositLimit == 2 || SystemInfo.AllowCheckDepositLimit == 3)
            {
                if (Discount > 0 && Discount != 100)
                {
                    DiscountMoney = money * Discount / 100;
                    double x = sfData.Balance + money - DiscountMoney /*+ sfData.BtMonery*/;
                    double xx = -DiscountMoney;
                    sql.Add(Pub.GetSQL(DBCode.DB_004005, new string[] { "0", pubData.CardNo, "21",
            dt.AddSeconds(-1).ToString(SystemInfo.SQLDateTimeFMT), xx.ToString(),
            x.ToString(), "0", "", "0", sfData.UseTimes.ToString(), OprtInfo.OprtSysID, "", "1", "",
            CardData10, pubData.MacTAG, "" , dtm.ToString(),sfData.BtMonery.ToString(),"0",OpterStartDate,OpterEndDate}));
                    sfData.UseTimes += 1;
                    mm = -(money - DiscountMoney);
                }
            }
            else
            {
                mm = -money;
                // sfData.Balance -= money;
            }
            AllBalance = sfData.Balance + sfData.BtMonery;
            sql.Add(Pub.GetSQL(DBCode.DB_004005, new string[] { "0", pubData.CardNo, RefundmentType,
        dt.ToString(SystemInfo.SQLDateTimeFMT), mm.ToString(), sfData.Balance.ToString(), "0", "", "0",
        sfData.UseTimes.ToString(), OprtInfo.OprtSysID, "", "1", "", CardData10, pubData.MacTAG, "" , dtm.ToString(),sfData.BtMonery.ToString(),"0",OpterStartDate,OpterEndDate}));
            string Title = Pub.GetResText(formCode, "RefundmentTitle", "");
            double Amount = money + moneyBT;
            double ReceivablesAmount = money + moneyBT;
            double CardBalance = AllBalance;
            if (SystemInfo.AllowCheckDepositLimit == 3)
            {
                string msgX = string.Format("本初取出款总金额，其中，\r\n\r\n退款：{0}元\r\n扣除：{1}元",
                  Math.Abs(mm).ToString(SystemInfo.CurrencySymbol + "0.00"),
                  Math.Abs(DiscountMoney).ToString(SystemInfo.CurrencySymbol + "0.00"));
                Form frm = new Form();
                frm.FormBorderStyle = FormBorderStyle.FixedDialog;
                frm.MaximizeBox = false;
                frm.MinimizeBox = false;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Width = 600;
                frm.Height = 360;
                Label lab = new Label();
                lab.Left = 10;
                lab.Top = 14;
                lab.Text = msgX;
                lab.AutoSize = false;
                lab.Left = 0;
                lab.Top = 0;
                lab.Width = frm.ClientSize.Width;
                lab.Height = frm.ClientSize.Height - 50;
                lab.TextAlign = ContentAlignment.MiddleCenter;
                lab.Font = new Font(Font.Name, 20, FontStyle.Bold);
                int BtnLeft = (lab.Width - 100 * 2 - 20) / 2;
                Button btnOkX = new Button();
                btnOkX.Text = Pub.GetResText("Public", "btnOk", "");
                btnOkX.Width = 100;
                btnOkX.Height = 40;
                btnOkX.Left = BtnLeft;
                btnOkX.Top = lab.Top + lab.Height;
                btnOkX.DialogResult = DialogResult.OK;
                Button btnCancelX = new Button();
                btnCancelX.Text = Pub.GetResText("Public", "btnCancel", "");
                btnCancelX.Width = 100;
                btnCancelX.Height = 40;
                btnCancelX.Left = BtnLeft + 120;
                btnCancelX.Top = lab.Top + lab.Height;
                btnCancelX.DialogResult = DialogResult.Cancel;
                frm.Controls.Add(lab);
                frm.Controls.Add(btnOkX);
                frm.Controls.Add(btnCancelX);
                if (frm.ShowDialog() != DialogResult.OK) return;
            }
            if (db.ExecSQL(sql) != 0) return;
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
                    Pub.ShowErrorMsg(Pub.GetCardMsg(cardRet) + "\r\n\r\n" + Pub.GetResText(formCode, "MsgCardOkContinue", ""));
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
            double tempBalance = sfData.Balance;
            double tempBT = db.GetBTMoney(sfData.BtDate, sfData.BtMonery);
            txtCardBalance.Text = tempBalance.ToString(SystemInfo.CurrencySymbol + "0.00");
            txtBTBalance.Text = tempBT.ToString(SystemInfo.CurrencySymbol + "0.00");
            Pub.CardBuzzer();
            msg = msg + string.Format("[{0:f2},{1:f2}]", Amount, temp);
            db.WriteSYLog(this.Text, CurrentOprt, msg);
            DispExtScreen(Amount, temp, 1, 2);
            if (chkPrint.Checked)
            {
                PrintCardBill(Title, Amount, ReceivablesAmount, CardBalance, AmountTitle, pubData.CardNo);
            }
            lblResult.Text = this.Text + Pub.GetResText(formCode, "MsgSuccess", "");
        }

        private bool ReadCard()
        {
            Discount = 0;
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
                            txtEmpNo.Text = dr["EmpNo"].ToString();
                            txtEmpName.Text = dr["EmpName"].ToString();
                            txtDepartName.Text = dr["DepartName"].ToString();
                            txtCardSectorNo.Text = dr["CardSectorNo"].ToString();
                            txtCardStatusName.Text = dr["CardStatusName"].ToString();
                            txtCardType.Text = dr["CardTypeName"].ToString();
                            int.TryParse(dr["CardRefundmentDiscount"].ToString(), out Discount);
                            if (textBox1.Enabled) textBox1.Text = Discount.ToString();
                        }
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

        private void ResetForm()
        {
            txtEmpNo.Text = "";
            txtEmpName.Text = "";
            txtDepartName.Text = "";
            txtCardSectorNo.Text = "";
            txtCardStatusName.Text = "";
            txtCardType.Text = "";
            txtUpDepositType.Text = "";
            lblResult.Text = "";
        }

        private void frmSFRefundment_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsWorking) e.Cancel = true;
        }

        private void RefreshForm()
        {
            gbxEmpInfo.Enabled = !IsWorking;
            label6.Enabled = !IsWorking;
            txtMoney.Enabled = !IsWorking;

            txtMoneyBT.Enabled = !IsWorking;
            btnReadCard.Enabled = !IsWorking;
            chkPrint.Enabled = !IsWorking;
            chkEmptyZero.Enabled = !IsWorking;
            btnOk.Enabled = !IsWorking;
            btnCancel.Enabled = !IsWorking;
            if (!SystemInfo.AllowRefAllowance)
                txtMoneyBT.Enabled = false;
        }
    }
}