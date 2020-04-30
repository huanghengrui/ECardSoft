using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSFCheckAccount : frmBaseDialog
    {
        private DateTime upCheckDate = new DateTime();
        private double upCardSum = 0;
        private double upLossSum = 0;
        private double upAbnormalDZSum = 0;
        private double upInCardFee = 0;
        private double upToCardFee = 0;
        private double upDepositDiscount = 0;
        private double upGiftCount = 0;
        private string upForwardName = "";
        private bool IsWorking = false;
        private string AccName = "";
        private string AccDB = "";
        private string BakFile = "";
        private string DBPath = "";

        protected override void InitForm()
        {
            formCode = "SFCheckAccount";
            base.InitForm();
            this.Text = Pub.GetResText(formCode, "mnu" + formCode, "", new string[] { "Main" });
            txtUp.Text = Pub.GetResText(formCode, "AccForwardN", "");
            upGrid.Rows.Clear();
            upGrid.Rows.Add(15);
            upGrid[0, 0].Value = Pub.GetResText(formCode, "CheckOutDate", "");
            upGrid[1, 0].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            upGrid[1, 0].Value = txtUp.Text;
            upGrid[0, 1].Value = Pub.GetResText(formCode, "CardSum", "");
            upGrid[0, 2].Value = Pub.GetResText(formCode, "DepositMoney", "");
            upGrid[0, 3].Value = Pub.GetResText(formCode, "PrepaidDiscount", "");
            upGrid[0, 4].Value = Pub.GetResText(formCode, "GiftCount", "");
            upGrid[0, 5].Value = Pub.GetResText(formCode, "RefundmentMoney", "");
            upGrid[0, 6].Value = Pub.GetResText(formCode, "EliminateSum", "");
            upGrid[0, 7].Value = Pub.GetResText(formCode, "BTSum", "");
            upGrid[0, 8].Value = Pub.GetResText(formCode, "ZeroSum", "");
            upGrid[0, 9].Value = Pub.GetResText(formCode, "NormalDZSum", "");
            upGrid[0, 10].Value = Pub.GetResText(formCode, "NormalJZSum", "");
            upGrid[0, 11].Value = Pub.GetResText(formCode, "AbnormalDZSum", "");
            upGrid[0, 12].Value = Pub.GetResText(formCode, "LossCount", "");
            upGrid[0, 13].Value = Pub.GetResText(formCode, "iICInSum", "");
            upGrid[0, 14].Value = Pub.GetResText(formCode, "iICOutSum", "");
            for (int i = 1; i < upGrid.RowCount; i++)
            {
                upGrid[1, i].Value = SystemInfo.CurrencySymbol + "0.00";
            }
            dataGrid.Rows.Clear();
            dataGrid.Rows.Add(15);
            dataGrid[0, 0].Value = Pub.GetResText(formCode, "CheckOutDate", "");
            dataGrid[1, 0].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGrid[0, 1].Value = Pub.GetResText(formCode, "CardSum", "");
            dataGrid[0, 2].Value = Pub.GetResText(formCode, "DepositMoney", "");
            dataGrid[0, 3].Value = Pub.GetResText(formCode, "PrepaidDiscount", "");
            dataGrid[0, 4].Value = Pub.GetResText(formCode, "GiftCount", "");
            dataGrid[0, 5].Value = Pub.GetResText(formCode, "RefundmentMoney", "");
            dataGrid[0, 6].Value = Pub.GetResText(formCode, "EliminateSum", "");
            dataGrid[0, 7].Value = Pub.GetResText(formCode, "BTSum", "");
            dataGrid[0, 8].Value = Pub.GetResText(formCode, "ZeroSum", "");
            dataGrid[0, 9].Value = Pub.GetResText(formCode, "NormalDZSum", "");
            dataGrid[0, 10].Value = Pub.GetResText(formCode, "NormalJZSum", "");
            dataGrid[0, 11].Value = Pub.GetResText(formCode, "AbnormalDZSum", "");
            dataGrid[0, 12].Value = Pub.GetResText(formCode, "LossCount", "");
            dataGrid[0, 13].Value = Pub.GetResText(formCode, "iICInSum", "");
            dataGrid[0, 14].Value = Pub.GetResText(formCode, "iICOutSum", "");
            for (int i = 1; i < dataGrid.RowCount; i++)
            {
                dataGrid[1, i].Value = SystemInfo.CurrencySymbol + "0.00";
            }
            txtAccName.Text = "ECard" + DateTime.Now.Date.ToString(SystemInfo.DateFormatLog);
            txtDBName.Text = "ECard" + DateTime.Now.Date.ToString(SystemInfo.DateFormatLog);
            txtBak.Text = db.GetDatabasePath().ToString() + SystemInfo.DefaultDBBak;
            dtpCheck.Value = DateTime.Now.Date.AddDays(-1);
            LoadData();
            RefreshForm();
        }

        public frmSFCheckAccount()
        {
            InitializeComponent();
        }

        private void btnDBName_Click(object sender, EventArgs e)
        {
            string BakFile = txtBak.Text;
            BakFile = Pub.SelectDBPath(false, BakFile);
            if (BakFile != "") txtBak.Text = BakFile;
        }

        private void LoadData()
        {
            double d = 0;
            DataTableReader dr = null;
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004007, new string[] { "0" }));
                if (dr.Read())
                {
                    DateTime.TryParse(dr["CheckOutDate"].ToString(), out upCheckDate);
                    double.TryParse(dr["CardSum"].ToString(), out upCardSum);
                    upForwardName = dr["ForwardName"].ToString();
                    txtUp.Text = upCheckDate.ToShortDateString();
                    if (upForwardName != "") txtUp.Text += "[" + upForwardName + "]";
                    upGrid[1, 0].Value = upCheckDate.ToShortDateString();
                    for (int i = 1; i < upGrid.RowCount; i++)
                    {
                        double.TryParse(dr[i].ToString(), out d);
                        upGrid[1, i].Value = d.ToString(SystemInfo.CurrencySymbol + "0.00");
                    }
                }
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004007, new string[] { "9" }));
                if (dr.Read())
                {
                    double.TryParse(dr["LossCount"].ToString(), out upLossSum);
                    double.TryParse(dr["AbnormalDZSum"].ToString(), out upAbnormalDZSum);
                    double.TryParse(dr["InCardFee"].ToString(), out upInCardFee);
                    double.TryParse(dr["ToCardFee"].ToString(), out upToCardFee);
                    double.TryParse(dr["DepositDiscount"].ToString(), out upDepositDiscount);
                    double.TryParse(dr["GiftCount"].ToString(), out upGiftCount);
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!db.CheckOprtRole(formCode, "M", true)) return;
            if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "Msg001", ""))) return;
            if (dtpCheck.Value >= DateTime.Now.Date)
            {
                dtpCheck.Focus();
                Pub.ShowErrorMsg(string.Format(Pub.GetResText(formCode, "Error001", ""),
                  DateTime.Now.Date.ToShortDateString()));
                return;
            }
            AccName = txtAccName.Text.Trim();
            if (AccName == "")
            {
                txtAccName.Focus();
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorAccountNameEmpty", ""));
                return;
            }
            AccDB = txtDBName.Text.Trim();
            if (AccDB == "")
            {
                txtDBName.Focus();
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorDBNameEmpty", ""));
                return;
            }
            BakFile = txtBak.Text.Trim();
            if (BakFile == "")
            {
                txtBak.Focus();
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorDBFileEmpty", ""));
                return;
            }
            bool IsOk = false;
            DataTableReader dr = null;
            int count = 0;
            try
            {
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "105", AccName }));
                if (dr.Read())
                {
                    txtAccName.Focus();
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorAccountNameExists", ""));
                }
                else
                    IsOk = true;
                dr.Close();
                if (IsOk)
                {
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "105", SystemInfo.AccDBName }));
                    if (dr.Read())
                    {
                        DBPath = dr["DBPath"].ToString();
                        DBPath = GetFileNamePath(DBPath);
                    }
                    else
                        IsOk = false;
                    dr.Close();
                }
                if (IsOk)
                {
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "106", AccDB }));
                    if (dr.Read())
                    {
                        IsOk = false;
                        txtDBName.Focus();
                        Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorDBNameExists", ""));
                    }
                    dr.Close();
                }
                if (IsOk)
                {
                    IsOk = db.DBFileExists(BakFile);
                    if (!IsOk)
                    {
                        txtBak.Focus();
                        Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorDBFileEmptyNotExists", ""));
                    }
                }
                if (IsOk)//判断收费
                {
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004007, new string[] { "2",
            dtpCheck.Value.AddDays(1).ToString(SystemInfo.SQLDateTimeFMT) }));
                    if (dr.Read()) int.TryParse(dr[0].ToString(), out count);
                    if (count == 0)
                    {
                        IsOk = false;
                        Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error003", ""));
                    }
                    dr.Close();
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
            if (!IsOk) return;
            IsWorking = true;
            RefreshForm();
            CheckAccount();
            IsWorking = false;
            RefreshForm();
            lblMsg.Text = "";
        }

        private void CheckAccount()
        {
            int DepositCount = 0;
            double DepositSum = 0;
            double DepositDiscount = 0;
            double GiftCount = 0;
            int RefundmentCount = 0;
            double RefundmentSum = 0;
            int EliminateCount = 0;
            double EliminateSum = 0;
            double BTSum = 0;
            double BTWSum = 0;
            double ZeroSum = 0;
            double NormalDZSum = 0;
            double NormalJZSum = 0;
            double InCardFee = 0;
            double ToCardFee = 0;
            double CardSum = 0;
            if (!CheckData(0, dtpCheck.Value, ref DepositCount, ref DepositSum, ref DepositDiscount, ref GiftCount,
              ref RefundmentCount, ref RefundmentSum, ref EliminateCount, ref EliminateSum, ref BTSum, ref ZeroSum,
              ref NormalDZSum, ref NormalJZSum, ref InCardFee, ref ToCardFee, ref CardSum, ref BTWSum)) return;
            int DepositCountX = 0;
            double DepositSumX = 0;
            double DepositDiscountX = 0;
            double GiftCountX = 0;
            int RefundmentCountX = 0;
            double RefundmentSumX = 0;
            int EliminateCountX = 0;
            double EliminateSumX = 0;
            double BTSumX = 0;
            double BTWSumX = 0;
            double ZeroSumX = 0;
            double NormalDZSumX = 0;
            double NormalJZSumX = 0;
            double InCardFeeX = 0;
            double ToCardFeeX = 0;
            double CardSumX = 0;
            if (!CheckData(1, dtpCheck.Value, ref DepositCountX, ref DepositSumX, ref DepositDiscountX, ref GiftCountX,
              ref RefundmentCountX, ref RefundmentSumX, ref EliminateCountX, ref EliminateSumX, ref BTSumX, ref ZeroSumX,
              ref NormalDZSumX, ref NormalJZSumX, ref InCardFeeX, ref ToCardFeeX, ref CardSumX, ref BTWSumX)) return;
            DataTableReader dr = null;
            double CardBalance = 0;
            double BTBalance = 0;
            double CardBTMoney = 0;
            double SFCardBalance = 0;
            double SFCardBalanceX = 0;
            double BTBalanceX = 0;
            bool IsError = false;
            try
            {
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004007, new string[] { "4" }));
                if (dr.Read())
                {
                    double.TryParse(dr["CardBalance"].ToString(), out CardBalance);
                    double.TryParse(dr["CardBTMoney"].ToString(), out CardBTMoney);
                }
                dr.Close();
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004007, new string[] { "5" }));
                if (dr.Read())
                {
                    double.TryParse(dr[0].ToString(), out SFCardBalance);
                    //double.TryParse(dr[0].ToString(), out BTBalance);
                }
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004007, new string[] { "10",
          dtpCheck.Value.AddDays(1).ToString(SystemInfo.SQLDateFMT)}));
                if (dr.Read())
                {
                    double.TryParse(dr[0].ToString(), out SFCardBalanceX);
                    //double.TryParse(dr[0].ToString(), out BTBalanceX);
                }
                dr.Close();
            }
            catch (Exception E)
            {
                IsError = true;
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            if (IsError) return;
            CardBalance = Math.Round(CardBalance, 2);
            SFCardBalance = Math.Round(SFCardBalance, 2);
            CardBTMoney = Math.Round(CardBTMoney, 2);
            SFCardBalanceX = Math.Round(SFCardBalanceX, 2);
            BTBalance = Math.Round(BTBalance, 2);
            BTBalanceX = Math.Round(BTBalanceX, 2);
            CardSum = Math.Round(CardSum, 2);
            CardSumX = Math.Round(CardSumX, 2);
            BTSumX = Math.Round(BTSumX, 2);
            BTSum = Math.Round(BTSum, 2);
            string msg = string.Format(Pub.GetResText(formCode, "Msg003", ""),
              (CardBalance + CardBTMoney).ToString(SystemInfo.CurrencySymbol + "0.00"),
              (SFCardBalance + BTBalance).ToString(SystemInfo.CurrencySymbol + "0.00"),
              (CardSumX).ToString(SystemInfo.CurrencySymbol + "0.00"),
              dtpCheck.Value.ToShortDateString(), (CardSum).ToString(SystemInfo.CurrencySymbol + "0.00"));
            string msgex = Pub.GetResText(formCode, "Msg004", "");
            MessageBoxIcon icon = MessageBoxIcon.Question;
            bool IsEnforce = false;
            if ((CardBalance + CardBTMoney != CardSumX) || (CardBalance + CardBTMoney != SFCardBalance + BTBalance) ||
                      (CardSumX != SFCardBalance + BTBalance) || (CardSum != SFCardBalanceX + BTBalance))
            {
                IsEnforce = true;
                msgex = Pub.GetResText(formCode, "Msg006", "");
                icon = MessageBoxIcon.Exclamation;
            }
            if (Pub.MessageBoxShowQuestion(msg + "\r\n\r\n" + msgex, icon)) return;
            lblMsg.Text = Pub.GetResText(formCode, "Msg002", "");
            Application.DoEvents();
            if (!db.CreateDatabase(DBPath, AccDB)) return;
            if (!db.RestoreDatabase(AccDB, BakFile))
            {
                db.DeleteDatabase(AccDB, true);
                return;
            }
            else
            {
                string fn = BakFile.Substring(BakFile.LastIndexOf("\\") + 1).ToLower();
                bool IsOk = true;
                Database dbLang = new Database(GetConnStr(AccDB));
                try
                {
                    dbLang.Open();
                    if (IsOk && (fn == SystemInfo.DefaultDBBak.ToLower()))
                    {
                        IsOk = dbLang.UpdateDatabasesLang();
                    }
                }
                catch (Exception E)
                {
                    IsOk = false;
                    Pub.ShowErrorMsg(E);
                }
                finally
                {
                    dbLang.Close();
                    dbLang = null;
                }
                if (!IsOk)
                {
                    db.DeleteDatabase(AccDB, true);
                    return;
                }
            }
            string ConnStr = GetConnStr(AccDB);
            Database dbEx = new Database(ConnStr);
            try
            {
                dbEx.Open();
                dr = dbEx.GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { "2" }));
                if (dr.Read())
                {
                    DateTime dt = Convert.ToDateTime(dr["DbDate"]);
                    dbEx.UpdateDatabase(this.Text, dt);
                }
                dr.Close();
                switch (SystemInfo.DBType)
                {
                    case 1:
                    case 2:
                        dbEx.ExecSQL("ALTER TABLE RS_EmpFingerInfo DROP COLUMN FingerBackUpNo", true);
                        dbEx.ExecSQL("ALTER TABLE RS_EmpFingerInfo ALTER COLUMN FingerTemplate image NULL", true);
                        break;
                }
                if (IsEnforce)
                {
                    CardSum = SFCardBalanceX;
                    DepositCount = 0;
                    DepositSum = 0;
                    DepositDiscount = 0;
                    GiftCount = 0;
                    RefundmentCount = 0;
                    RefundmentSum = 0;
                    EliminateCount = 0;
                    EliminateSum = 0;
                    BTSum = 0;
                    ZeroSum = 0;
                    NormalDZSum = 0;
                    NormalJZSum = 0;
                    InCardFee = 0;
                    ToCardFee = 0;
                    BTWSum = 0;
                }
                switch (SystemInfo.DBType)
                {
                    case 1:
                    case 2:
                        IsError = ExecCheck(dtpCheck.Value, CardSum, DepositCount, DepositSum, DepositDiscount, GiftCount,
                          RefundmentCount, RefundmentSum, EliminateCount, EliminateSum, BTSum, ZeroSum, NormalDZSum, NormalJZSum,
                          InCardFee, ToCardFee, AccName, AccDB, SystemInfo.AccDBName, SystemInfo.DatabaseName, IsEnforce, BTWSum);
                        break;
                }
                if (IsError)
                {
                    dbEx.Close();
                    db.DeleteDatabase(AccDB, true);
                }
            }
            catch (Exception E)
            {
                IsError = true;
                dbEx.Close();
                db.DeleteDatabase(AccDB, true);
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
                dbEx.Close();
            }
            if (IsError) return;
            dataGrid[1, 0].Value = dtpCheck.Value.ToShortDateString();
            dataGrid[1, 1].Value = CardSum.ToString(SystemInfo.CurrencySymbol + "0.00");
            dataGrid[1, 2].Value = DepositSum.ToString(SystemInfo.CurrencySymbol + "0.00");
            dataGrid[1, 3].Value = DepositDiscount.ToString(SystemInfo.CurrencySymbol + "0.00");
            dataGrid[1, 4].Value = GiftCount.ToString(SystemInfo.CurrencySymbol + "0.00");
            dataGrid[1, 5].Value = RefundmentSum.ToString(SystemInfo.CurrencySymbol + "0.00");
            dataGrid[1, 6].Value = EliminateSum.ToString(SystemInfo.CurrencySymbol + "0.00");
            dataGrid[1, 7].Value = BTSum.ToString(SystemInfo.CurrencySymbol + "0.00");
            dataGrid[1, 8].Value = ZeroSum.ToString(SystemInfo.CurrencySymbol + "0.00");
            dataGrid[1, 9].Value = NormalDZSum.ToString(SystemInfo.CurrencySymbol + "0.00");
            dataGrid[1, 10].Value = NormalJZSum.ToString(SystemInfo.CurrencySymbol + "0.00");
            dataGrid[1, 11].Value = InCardFee.ToString(SystemInfo.CurrencySymbol + "0.00");
            dataGrid[1, 12].Value = ToCardFee.ToString(SystemInfo.CurrencySymbol + "0.00");
            SystemInfo.AccIsForward = true;
            Pub.MessageBoxShow(Pub.GetResText(formCode, "Msg005", ""), MessageBoxIcon.Information);
        }

        private void frmSFCheckAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsWorking) e.Cancel = true;
        }

        private void RefreshForm()
        {
            label1.Enabled = !IsWorking;
            label2.Enabled = !IsWorking;
            label3.Enabled = !IsWorking;
            label4.Enabled = !IsWorking;
            label5.Enabled = !IsWorking;
            txtUp.Enabled = !IsWorking;
            dtpCheck.Enabled = !IsWorking;
            txtAccName.Enabled = !IsWorking;
            txtDBName.Enabled = !IsWorking;
            groupBox1.Enabled = !IsWorking;
            groupBox2.Enabled = !IsWorking;
            btnOk.Enabled = !IsWorking && !SystemInfo.AccIsForward;
            btnCancel.Enabled = !IsWorking;
            txtBak.Enabled = !IsWorking;
            btnDBName.Enabled = !IsWorking;
        }

        private bool CheckData(int flag, DateTime CheckOutDate, ref int DepositCount, ref double DepositSum,
          ref double DepositDiscount, ref double GiftCount, ref int RefundmentCount, ref double RefundmentSum,
          ref int EliminateCount, ref double EliminateSum, ref double BTSum, ref double ZeroSum,
          ref double NormalDZSum, ref double NormalJZSum, ref double InCardFee, ref double ToCardFee,
          ref double CardSum, ref double BTWSum)
        {
            bool ret = false;
            DataTableReader dr = null;
            int SFType = 0;
            int times = 0;
            double money = 0;
            double CardSumLast = 0;
            //double DepositDiscountLast = 0;
            //double GiftCountLast = 0;
            double ErrorCorrection = 0;
            string sql = "";
            try
            {
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004007, new string[] { "7" }));
                if (dr.Read())
                {
                    double.TryParse(dr[0].ToString(), out CardSumLast);
                    //double.TryParse(dr[1].ToString(), out DepositDiscountLast);
                    //double.TryParse(dr[2].ToString(), out GiftCountLast);
                }
                dr.Close();
                if (flag == 0)
                    sql = Pub.GetSQL(DBCode.DB_004007, new string[] { "3",
            CheckOutDate.AddDays(1).ToString(SystemInfo.SQLDateFMT) });
                else
                    sql = Pub.GetSQL(DBCode.DB_004007, new string[] { "3" });
                dr = db.GetDataReader(sql);
                while (dr.Read())
                {
                    int.TryParse(dr["SFTypeID"].ToString(), out SFType);
                    int.TryParse(dr["CountTimes"].ToString(), out times);
                    double.TryParse(dr["SumSFAmount"].ToString(), out money);
                    if (SFType == 0)//补贴清零
                        ZeroSum += money;
                    else if ((SFType == 1) || (SFType == 3) || (SFType == 6) || (SFType == 7) || (SFType == 8) ||
                      (SFType == 60) || (SFType == 130)) //扣款消费
                        NormalDZSum += money;
                    else if (SFType == 2)//记帐消费
                        NormalJZSum += money;
                    else if ((SFType == 4) || (SFType == 10) || (SFType >= 90 && SFType <= 99) || (SFType >= 100 && SFType <= 109))//充值
                    {
                        DepositCount += times;
                        DepositSum += money;
                    }
                    else if (SFType == 5)//补贴金额
                        BTSum += money;
                    else if ((SFType == 9) || (SFType == 20) || (SFType == 21) || (SFType >= 200 && SFType <= 209))//取款
                    {
                        RefundmentCount += times;
                        RefundmentSum += money;
                    }
                    else if (SFType == 30)//销户
                    {
                        EliminateCount += times;
                        EliminateSum += money;
                    }
                    else if (SFType == 40)//收工本费
                        InCardFee += money;
                    else if (SFType == 50)//退工本费
                        ToCardFee += money;
                    else if (SFType == 70) //充值折扣
                        DepositDiscount += money;
                    else if (SFType == 80)//充值赠送
                        GiftCount += money;
                    else if (SFType == 120)//消费纠错
                        ErrorCorrection += money;

                }
                dr.Close();
                if (flag == 0)
                    sql = Pub.GetSQL(DBCode.DB_004007, new string[] { "20",
            CheckOutDate.AddDays(1).ToString(SystemInfo.SQLDateFMT) });
                else
                    sql = Pub.GetSQL(DBCode.DB_004007, new string[] { "20" });
                dr = db.GetDataReader(sql);
                while (dr.Read())
                {
                    if (SFType == 130)//餐次补贴
                        BTWSum += money;
                }
                ret = true;
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
            //DepositDiscount += DepositDiscountLast;
            //GiftCount += GiftCountLast;
            //double CashIncome = DepositSum + InCardFee; //现金收入
            //double CashOut = RefundmentSum + EliminateSum + ToCardFee; //现金支出(算工本费)
            double CashIncome = DepositSum; //现金收入
            double CashOut = RefundmentSum + EliminateSum; //现金支出
            double Income = CashIncome - CashOut; //净收入
            double Consumer = NormalDZSum; //消费汇总
            CardSum = CardSumLast + Income + BTSum + DepositDiscount + GiftCount + ErrorCorrection - ZeroSum - Consumer; //当期结余
            CardSum = Math.Round(CardSum, 2);
            return ret;
        }

        private bool ExecCheck(DateTime CheckOutDate, double CardSum, int DepositCount, double DepositSum,
          double DepositDiscount, double GiftCount, int RefundmentCount, double RefundmentSum, int EliminateCount,
          double EliminateSum, double BTSum, double ZeroSum, double NormalDZSum, double NormalJZSum, double InCardFee,
          double ToCardFee, string AccName, string AccDB, string CurrentAccName, string CurrentAccDB, bool IsEnforce, double BTWSum)
        {
            bool ret = true;
            string sql = string.Format("EXEC PSF_CheckAccount '{0}',{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}," +
              "{13},{14},{15},'{16}','{17}','{18}','{19}',{20},{21}", CheckOutDate.ToString(SystemInfo.SQLDateFMT),
              CardSum, DepositCount, DepositSum, DepositDiscount, GiftCount, RefundmentCount, RefundmentSum, EliminateCount,
              EliminateSum, BTSum, ZeroSum, NormalDZSum, NormalJZSum, InCardFee, ToCardFee, AccName, AccDB, CurrentAccName,
              CurrentAccDB, Convert.ToByte(IsEnforce), BTWSum);
            try
            {
                db.ExecSQL(sql);
                ret = false;
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E, sql);
            }
            return ret;
        }
    }
}