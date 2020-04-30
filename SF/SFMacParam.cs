using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using QHKS;

namespace ECard78
{
    public partial class frmSFMacParam : frmSFMacBase
    {
        private string usbPath = "";
        private string CurrentSysID = "";

        protected override void InitForm()
        {
            formCode = "SFMacParam";
            SetToolItemState("ItemImport", false);
            SetToolItemState("ItemExport", false);
            SetToolItemState("ItemPrint", false);
            SetToolItemState("ItemLine1", false);
            SetToolItemState("ItemAdd", false);
            SetToolItemState("ItemEdit", false);
            SetToolItemState("ItemDelete", false);
            SetToolItemState("ItemLine2", false);
            SetToolItemState("ItemTAG1", true);
            SetToolItemState("ItemTAG2", true);
            SetToolItemState("ItemTAG3", true);
            SetToolItemState("ItemLine3", true);
            base.InitForm();
            GetCardTypeList();
            chkCardType.Items.Clear();
            for (int i = 0; i < cardTypeList.Count; i++)
            {
                chkCardType.Items.Add(cardTypeList[i]);
            }
            RefreshForm(true);
            txtDZAmount1.Enter += TextBoxCurrency_Enter;
            txtDZAmount1.Leave += TextBoxCurrency_Leave;
            txtDZAmount2.Enter += TextBoxCurrency_Enter;
            txtDZAmount2.Leave += TextBoxCurrency_Leave;
            txtDZAmount3.Enter += TextBoxCurrency_Enter;
            txtDZAmount3.Leave += TextBoxCurrency_Leave;
            txtDZAmount4.Enter += TextBoxCurrency_Enter;
            txtDZAmount4.Leave += TextBoxCurrency_Leave;
            txtJZAmount1.Enter += TextBoxCurrency_Enter;
            txtJZAmount1.Leave += TextBoxCurrency_Leave;
            txtJZAmount2.Enter += TextBoxCurrency_Enter;
            txtJZAmount2.Leave += TextBoxCurrency_Leave;
            txtJZAmount3.Enter += TextBoxCurrency_Enter;
            txtJZAmount3.Leave += TextBoxCurrency_Leave;
            txtJZAmount4.Enter += TextBoxCurrency_Enter;
            txtJZAmount4.Leave += TextBoxCurrency_Leave;
            txtMaxCons.Enter += TextBoxCurrency_Enter;
            txtMaxCons.Leave += TextBoxCurrency_Leave;
            txtMaxDeposit.Enter += TextBoxCurrency_Enter;
            txtMaxDeposit.Leave += TextBoxCurrency_Leave;
        }

        public frmSFMacParam()
        {
            InitializeComponent();
        }

        protected override void ExecItemTAG1()
        {
            DateTime dt = new DateTime();
            DateTime dt1 = new DateTime();
            DateTime dt2 = new DateTime();
            DateTime dt3 = new DateTime();
            MaskedTextBox txt;
            MaskedTextBox txt1;
            TextBox txtEx;
            string tmp;
            for (int i = 1; i <= 4; i++)
            {
                txt = (MaskedTextBox)groupBox1.Controls["txtBeginTime" + i.ToString()];
                if (!DateTime.TryParse(txt.Text, out dt))
                {
                    txt.Focus();
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error00" + i.ToString(), ""));
                    return;
                }
                txt = (MaskedTextBox)groupBox1.Controls["txtEndTime" + i.ToString()];
                if (!DateTime.TryParse(txt.Text, out dt1))
                {
                    txt.Focus();
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error00" + i.ToString(), ""));
                    return;
                }
                dt2 = dt;
                dt3 = dt1;
                if ((i < 4) && (dt > dt1))
                {
                    txt.Focus();
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error00" + i.ToString(), ""));
                    return;
                }
                if (i > 1)
                {
                    txt1 = (MaskedTextBox)groupBox1.Controls["txtEndTime" + (i - 1).ToString()];
                    DateTime.TryParse(txt1.Text, out dt1);
                    if (dt < dt1)
                    {
                        txt.Focus();
                        Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error00" + i.ToString(), ""));
                        return;
                    }
                }
                if ((i == 4) && (dt2 > dt3))
                {
                    txt1 = (MaskedTextBox)groupBox1.Controls["txtBeginTime1"];
                    DateTime.TryParse(txt1.Text, out dt);
                    txt1 = (MaskedTextBox)groupBox1.Controls["txtEndTime" + i.ToString()];
                    DateTime.TryParse(txt1.Text, out dt1);
                    if (dt < dt1)
                    {
                        txt.Focus();
                        Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error00" + i.ToString(), ""));
                        return;
                    }
                }
                txtEx = (TextBox)groupBox1.Controls["txtDZAmount" + i.ToString()];
                tmp = CurrencyToStringEx(txtEx.Text);
                if (Convert.ToDecimal(tmp) <= 0)
                {
                    txtEx.Focus();
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error005", ""));
                    return;
                }
                txtEx = (TextBox)groupBox1.Controls["txtJZAmount" + i.ToString()];
                tmp = CurrencyToStringEx(txtEx.Text);
                if (Convert.ToDecimal(tmp) <= 0)
                {
                    txtEx.Focus();
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error006", ""));
                    return;
                }
            }
            base.ExecItemTAG1();
            ExecMacOprt(0, false);
           
        }

        protected override void ExecItemTAG2()
        {
            base.ExecItemTAG2();
            ExecMacOprt(1);
            
        }

        protected override void ExecItemTAG3()
        {
            if (dlgFolder.ShowDialog() != DialogResult.OK) return;
            usbPath = dlgFolder.SelectedPath;
            if (usbPath.Substring(usbPath.Length - 1, 1) != "\\") usbPath = usbPath + "\\";
            base.ExecItemTAG3();
            ExecMacOprt(2, false);
           
        }

        protected override void RefreshForm(bool State)
        {
            base.RefreshForm(State);
            CurrentSysID = GetMacSysID();
            DataTableReader dr = null;
            string MealStr = "";
            string ParamStr = "";
            string BellStr = "";
            try
            {
                pnlParam.Enabled = State && ItemTAG1.Enabled;
            }
            catch
            {
            }
            if (ItemTAG1.Enabled)
            {
                string tmp = GetMacType();
                button1.Enabled = tmp == "32" && tmp != "132";
                button2.Enabled = tmp == "32" && tmp != "132";
                button3.Enabled = tmp == "32" && tmp != "132";
                button4.Enabled = tmp == "32" && tmp != "132";
                button5.Enabled = tmp == "32" && tmp != "132";
                button7.Enabled = tmp == "35" && tmp != "132";
                button8.Enabled = tmp == "36" && tmp != "132";
                button10.Enabled = tmp == "32" || tmp == "33" || tmp == "132";

                groupBox1.Enabled = tmp != "132";
                groupBox2.Enabled = tmp != "132";
                groupBox3.Enabled = tmp != "132";
                groupBox4.Enabled = tmp != "132";
                groupBox5.Enabled = tmp != "132";
                groupBox6.Enabled = tmp != "132";
                chkDownProd.Enabled = tmp != "132";
                button9.Enabled = tmp != "132";
                try
                {
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004004, new string[] { "7", CurrentSysID }));
                    if (dr.Read())
                    {
                        MealStr = dr["MealInfo"].ToString();
                        ParamStr = dr["ParamInfo"].ToString();
                        BellStr = dr["BellTime"].ToString();
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
                SFMealInfo meal = new SFMealInfo(MealStr);
                txtBeginTime1.Text = meal.BeginTime[0];
                txtBeginTime2.Text = meal.BeginTime[1];
                txtBeginTime3.Text = meal.BeginTime[2];
                txtBeginTime4.Text = meal.BeginTime[3];
                txtEndTime1.Text = meal.EndTime[0];
                txtEndTime2.Text = meal.EndTime[1];
                txtEndTime3.Text = meal.EndTime[2];
                txtEndTime4.Text = meal.EndTime[3];
                txtDZAmount1.Text = meal.DZAmount[0].ToString(SystemInfo.CurrencySymbol + "0.00");
                txtDZAmount2.Text = meal.DZAmount[1].ToString(SystemInfo.CurrencySymbol + "0.00");
                txtDZAmount3.Text = meal.DZAmount[2].ToString(SystemInfo.CurrencySymbol + "0.00");
                txtDZAmount4.Text = meal.DZAmount[3].ToString(SystemInfo.CurrencySymbol + "0.00");
                txtJZAmount1.Text = meal.JZAmount[0].ToString(SystemInfo.CurrencySymbol + "0.00");
                txtJZAmount2.Text = meal.JZAmount[1].ToString(SystemInfo.CurrencySymbol + "0.00");
                txtJZAmount3.Text = meal.JZAmount[2].ToString(SystemInfo.CurrencySymbol + "0.00");
                txtJZAmount4.Text = meal.JZAmount[3].ToString(SystemInfo.CurrencySymbol + "0.00");
                SFParamInfo param = new SFParamInfo(ParamStr);
                txtMaxCons.Text = param.MaxCons.ToString(SystemInfo.CurrencySymbol + "0.00");
                txtMaxDeposit.Text = param.MaxDeposit.ToString(SystemInfo.CurrencySymbol + "0.00");
                txtTitle.Text = param.Title;
                chkIsContinuous.Checked = param.IsContinuous;
                chkIsNeedPWD.Checked = param.IsNeedPWD;
                chkAllowUseAllowance.Checked = param.AllowUseAllowance;
                chkAllowUseRecharge.Checked = param.AllowUseRecharge;
                chkFirstUseRecharge.Checked = param.FirstUseRecharge;
                chkRelay1.Checked = param.Relay1;
                rbWay0.Checked = param.ConsumptionWay == 1;
                rbWay1.Checked = param.ConsumptionWay == 2;
                rbWay2.Checked = param.ConsumptionWay == 3;
                rbWay3.Checked = param.ConsumptionWay == 4;
                if (!rbWay0.Checked && rbWay1.Checked && rbWay2.Checked && rbWay3.Checked) rbWay1.Checked = true;
                chkBreakfast.Checked = param.ChkOrdering.Substring(0, 1) == "1";
                chkLunch.Checked = param.ChkOrdering.Substring(1, 1) == "1";
                chkDinner.Checked = param.ChkOrdering.Substring(2, 1) == "1";
                chkSnack.Checked = param.ChkOrdering.Substring(3, 1) == "1";
                chkRelay2.Checked = param.Relay2;
                string cardtype = param.CardType;
                if ((cardtype == "") || (!Pub.IsNumeric(cardtype)))
                {
                    cardtype = SystemInfo.CardTypeDefault;
                }
                for (int i = 0; i < chkCardType.Items.Count; i++)
                {
                    chkCardType.SetItemChecked(i, cardtype.Substring(i, 1) == "1");
                }
                if (ParamStr == "") txtTitle.Text = GetMacTypeName();
                SFBellTime bell = new SFBellTime(BellStr);
                txtRelayTimeout.Value = bell.RelayTimeout;
                txtBellTimeout.Value = bell.BellTimeout;
                txtBells1.Text = bell.BellTime[0];
                txtBells2.Text = bell.BellTime[1];
                txtBells3.Text = bell.BellTime[2];
                txtBells4.Text = bell.BellTime[3];
                txtBells5.Text = bell.BellTime[4];
                txtBells6.Text = bell.BellTime[5];
            }
        }

        protected override bool ExecMacCommand(byte flag, int MacSN, ref string MacMsg)
        {
            bool ret = base.ExecMacCommand(flag, MacSN, ref MacMsg);
            DataTableReader dr = null;
            DataTableReader dtr = null;
            DataTable dtBlack = null;
            string sysID = GetMacSysID(MacSN.ToString());
            string cardType = "";
            string mealStr = "";
            string paramStr = "";
            string bellStr = "";
            string limitStr = "";
            string opterStr = "";
            string prodStr = "";
            string consStr = "";
            string discStr = "";
            string lowStr = "";
            string timingStr = "";
            string orderStr = "";
            string printStr = "";
            string mobileStr = "";
            string msgContinue = Pub.GetResText(formCode, "MsgContinue", "");
            string tmpMsg = "";
            string tmp = "";
            TFeePrintTitle feePrint = new TFeePrintTitle();
            feePrint.Zoom = new byte[5];
            feePrint.Title = new string[5];
            bool IsError = false;
            TCardTAG cardTAG = new TCardTAG();
            cardTAG.Count = 0;
            cardTAG.TAG = new string[200];
            MemoryStream logo = new MemoryStream();
            MemoryStream weixin = new MemoryStream();
            MemoryStream alipay = new MemoryStream();
            string tmpFile = "";

            try
            {
                if (flag == 0)
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004004, new string[] { "7", CurrentSysID }));
                else
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004004, new string[] { "7", sysID }));
                if (dr.Read())
                {
                    mealStr = dr["MealInfo"].ToString();
                    paramStr = dr["ParamInfo"].ToString();
                    bellStr = dr["BellTime"].ToString();
                    limitStr = dr["SFLimitConsumption"].ToString();
                    opterStr = dr["Opter"].ToString();
                    prodStr = dr["Products"].ToString();
                    consStr = dr["ConsumptionWay"].ToString();
                    discStr = dr["WithinDiscount"].ToString();
                    lowStr = dr["CardLowBalance"].ToString();
                    timingStr = dr["Timing"].ToString();
                    orderStr = dr["Ordering"].ToString();
                    printStr = dr["PrintTitle"].ToString();
                    mobileStr = dr["MobileInfo"].ToString();
                    if (dr["PrintLogo"].ToString() != "")
                    {
                        byte[] buff = (byte[])(dr["PrintLogo"]);
                        if (buff.Length > 0) logo = new MemoryStream(buff);
                    }
                    if (dr["ScanWeiXin"].ToString() != "")
                    {
                        byte[] buff = (byte[])(dr["ScanWeiXin"]);
                        if (buff.Length > 0) weixin = new MemoryStream(buff);
                    }
                    if (dr["ScanAliPay"].ToString() != "")
                    {
                        byte[] buff = (byte[])(dr["ScanAliPay"]);
                        if (buff.Length > 0) alipay = new MemoryStream(buff);
                    }
                }
                dr.Close();
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "3002" }));
                while (dr.Read())
                {
                    tmp = dr[0].ToString();
                    if (tmp.Length == 32)
                    {
                        tmp = Pub.GetOprtDecrypt(tmp);
                        cardTAG.TAG[cardTAG.Count] = tmp;
                        cardTAG.Count++;
                    }
                }
                if ((flag == 1) || (flag == 2))
                {
                    TPrintTitleInfo ptInfo = new TPrintTitleInfo(printStr);
                    for (int i = 0; i < 5; i++)
                    {
                        feePrint.Zoom[i] = (byte)(ptInfo.Zoom[i] + 1);
                        feePrint.Title[i] = ptInfo.Title[i];
                    }
                    feePrint.SpaceLine = ptInfo.Line;
                    if (logo.Length == 0) logo = ptInfo.Logo;
                }
                dtBlack = db.GetDataTable(Pub.GetSQL(DBCode.DB_001003, new string[] { "501" }));
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
            if (IsError) return false;

            QHKS.TMobileInfo mobileInfo = new QHKS.TMobileInfo();
            TMobileInfo mobInfo = new TMobileInfo(mobileStr);
            mobileInfo.IP = mobInfo.IP;
            mobileInfo.Port = mobInfo.Port;
            mobileInfo.KeyID = mobInfo.KeyID;
            mobileInfo.MercID = mobInfo.MercID;
            mobileInfo.TrmNo = mobInfo.TrmNo;
            mobileInfo.PWD = mobInfo.PWD;
            mobileInfo.Rate11 = mobInfo.Rate11;
            mobileInfo.Rate12 = mobInfo.Rate12;
            mobileInfo.Rate21 = mobInfo.Rate21;
            mobileInfo.Rate22 = mobInfo.Rate22;
            mobileInfo.MTyp = mobInfo.MobTyp;
            mobileInfo.XJLName = mobInfo.XJLName;
            mobileInfo.XJLPWD = mobInfo.XJLPWD;
            if (mobileInfo.IP == "") mobileInfo.IP = "000.000.000.000";
            if (mobileInfo.KeyID == "") mobileInfo.KeyID = "000";
            if (mobileInfo.MercID == "") mobileInfo.MercID = " ";
            if (mobileInfo.TrmNo == "") mobileInfo.TrmNo = " ";
            if (mobileInfo.PWD == "") mobileInfo.PWD = " ";

            //QHKS.TFeeRechargeGift feeRechargeGift = new QHKS.TFeeRechargeGift();
            //TFeeRechargeGift rechargegift = new TFeeRechargeGift(rechargegiftStr);
            //feeRechargeGift.CardType = Convert.ToByte(rechargegift.CardType);
            //feeRechargeGift.Rate = Convert.ToByte(rechargegift.Rate);
            //feeRechargeGift.Value = new double[5];
            //feeRechargeGift.Gift = new double[5];
            //for (int i = 0; i < 5; i++)
            //{ 
            //    feeRechargeGift.Value[i] = rechargegift.Value[i];
            //    feeRechargeGift.Gift[i] = rechargegift.Gift[i];
            //}

            switch (flag)
            {
                case 0:
                    if (sysID == CurrentSysID)
                    {
                        for (int i = 0; i < chkCardType.Items.Count; i++)
                        {
                            cardType += Convert.ToByte(chkCardType.GetItemChecked(i)).ToString();
                        }
                        MaskedTextBox txt;
                        TextBox txtEx;
                        mealStr = "";
                        for (int i = 1; i <= 4; i++)
                        {
                            txt = (MaskedTextBox)groupBox1.Controls["txtBeginTime" + i.ToString()];
                            mealStr = mealStr + txt.Text + "#";
                            txt = (MaskedTextBox)groupBox1.Controls["txtEndTime" + i.ToString()];
                            mealStr = mealStr + txt.Text + "#";
                            txtEx = (TextBox)groupBox1.Controls["txtDZAmount" + i.ToString()];
                            mealStr = mealStr + CurrencyToStringEx(txtEx.Text) + "#";
                            txtEx = (TextBox)groupBox1.Controls["txtJZAmount" + i.ToString()];
                            mealStr = mealStr + CurrencyToStringEx(txtEx.Text) + "@";
                        }
                        mealStr = mealStr.Substring(0, mealStr.Length - 1);
                        byte ConsumptionWay = 0;
                        if (rbWay0.Checked)
                            ConsumptionWay = 1;
                        else if (rbWay1.Checked)
                            ConsumptionWay = 2;
                        else if (rbWay2.Checked)
                            ConsumptionWay = 3;
                        else if (rbWay3.Checked)
                            ConsumptionWay = 4;
                        tmp = string.Format("{0}{1}{2}{3}", Convert.ToByte(chkBreakfast.Checked),
                          Convert.ToByte(chkLunch.Checked), Convert.ToByte(chkDinner.Checked), Convert.ToByte(chkSnack.Checked));
                        paramStr = string.Format("{0}#{1}#{2}#{3}#{4}#{5}#{6}#{7}#{8}#{9}#{10}#{11}#{12}#{13}#{14}#",
                          CurrencyToStringEx(txtMaxCons.Text), CurrencyToStringEx(txtMaxDeposit.Text), ConsumptionWay, cardType,
                          Convert.ToByte(chkIsContinuous.Checked), Convert.ToByte(chkIsNeedPWD.Checked),
                          Convert.ToByte(chkAllowUseAllowance.Checked), SystemInfo.SFBtBagDate, tmp, "", txtTitle.Text,
                          Convert.ToByte(chkRelay1.Checked), Convert.ToByte(chkRelay2.Checked), Convert.ToByte(chkAllowUseRecharge.Checked), Convert.ToByte(chkFirstUseRecharge.Checked));
                        bellStr = txtRelayTimeout.Value.ToString() + "\t" + txtBellTimeout.Value.ToString();
                        for (int i = 1; i <= 6; i++)
                        {
                            txt = (MaskedTextBox)groupBox5.Controls["txtBells" + i.ToString()];
                            bellStr = bellStr + "\t" + txt.Text;
                        }
                    }
                    MacMsg = Pub.GetSQL(DBCode.DB_004004, new string[] { "104", mealStr, paramStr, bellStr, limitStr, opterStr,
            prodStr, consStr, discStr, timingStr, orderStr, printStr, lowStr, mobileStr, sysID });
                    db.ExecSQL(MacMsg);
                    byte[] buff = logo.ToArray();
                    db.UpdateByteData(Pub.GetSQL(DBCode.DB_004004, new string[] { "122", sysID }), "PrintLogo", buff);
                    buff = weixin.ToArray();
                    db.UpdateByteData(Pub.GetSQL(DBCode.DB_004004, new string[] { "123", sysID }), "ScanWeiXin", buff);
                    buff = alipay.ToArray();
                    db.UpdateByteData(Pub.GetSQL(DBCode.DB_004004, new string[] { "124", sysID }), "ScanAliPay", buff);
                    ret = true;
                    break;
                case 1:
                case 2:
                    QHKS.TCheckIsOrder IsOrder = new TCheckIsOrder();
                    if (!db.GetCheckIsOrder(ref IsOrder)) return false;
                    SFMealInfo meal = new SFMealInfo(mealStr);
                    SFParamInfo param = new SFParamInfo(paramStr);
                    SFBellTime bell = new SFBellTime(bellStr);
                    SFLimitConsumption limit = new SFLimitConsumption(limitStr);
                    SFConsumptionWay way = new SFConsumptionWay(consStr);
                    SFWithinDiscount disc = new SFWithinDiscount(discStr);
                    SFCardLowBalance low = new SFCardLowBalance(lowStr);
                    SFTiming timing = new SFTiming(timingStr);
                    SFOrdering order = new SFOrdering(orderStr);
                    TFeeDefault feeDef = new TFeeDefault();
                    feeDef.MaxConsumption = param.MaxCons;
                    feeDef.MaxDeposit = param.MaxDeposit;
                    feeDef.ConsumptionModel = param.ConsumptionWay;
                    feeDef.AllowContinuous = Convert.ToByte(param.IsContinuous);
                    feeDef.NeedPWD = Convert.ToByte(param.IsNeedPWD);
                    feeDef.AllowUseAllowance = Convert.ToByte(param.AllowUseAllowance);
                    feeDef.AllowUseRecharge = Convert.ToByte(param.AllowUseRecharge);
                    feeDef.AllowanceFlag = SystemInfo.SFBtBagFlag;
                    feeDef.AllowanceValidity = SystemInfo.SFBtBagDate;
                    feeDef.FirstUseRecharge = Convert.ToByte(param.FirstUseRecharge);
                    feeDef.ReserveCheck = new byte[4];
                    feeDef.ReserveCheck[0] = 0;
                    if (param.ChkOrdering.Substring(0, 1) == "1") feeDef.ReserveCheck[0] = 1;
                    feeDef.ReserveCheck[1] = 0;
                    if (param.ChkOrdering.Substring(1, 1) == "1") feeDef.ReserveCheck[1] = 1;
                    feeDef.ReserveCheck[2] = 0;
                    if (param.ChkOrdering.Substring(2, 1) == "1") feeDef.ReserveCheck[2] = 1;
                    feeDef.ReserveCheck[3] = 0;
                    if (param.ChkOrdering.Substring(3, 1) == "1") feeDef.ReserveCheck[3] = 1;
                    feeDef.CardType = new byte[256];
                    for (int i = 0; i < SystemInfo.CardTypeCount; i++)
                    {
                        feeDef.CardType[i] = 0;
                        if (param.CardType.Substring(i, 1) == "1") feeDef.CardType[i] = 1;
                    }
                    feeDef.IsLongID = Convert.ToByte(SystemInfo.IsLongEmpID);
                    TRelaySet relaySet = new TRelaySet();
                    relaySet.Relay1 = Convert.ToByte(param.Relay1);
                    relaySet.Relay2 = Convert.ToByte(param.Relay2);
                    TFeeTimeSet feeTimeSet = new TFeeTimeSet();
                    feeTimeSet.BeginTime = new string[4];
                    feeTimeSet.EndTime = new string[4];
                    feeTimeSet.Evaluate = new double[4];
                    feeTimeSet.Charge = new double[4];
                    for (int i = 0; i <= 3; i++)
                    {
                        feeTimeSet.BeginTime[i] = meal.BeginTime[i];
                        feeTimeSet.EndTime[i] = meal.EndTime[i];
                        feeTimeSet.Evaluate[i] = meal.DZAmount[i];
                        feeTimeSet.Charge[i] = meal.JZAmount[i];
                    }
                    TAdminUser adminSer = new TAdminUser();
                    adminSer.ID = new byte[20];
                    adminSer.Pass = new int[20];
                    string[] ss = opterStr.Split(' ');
                    tmp = "";
                    for (int i = 0; i < ss.Length; i++)
                    {
                        if ((ss[i] != "") && (Pub.IsNumeric(ss[i]))) tmp = tmp + ss[i] + ",";
                    }
                    if (tmp != "") tmp = tmp.Substring(0, tmp.Length - 1);
                    try
                    {
                        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004004, new string[] { "105", tmp }));
                        while (dr.Read())
                        {
                            adminSer.ID[adminSer.Count] = Convert.ToByte(dr["MacOpterID"]);
                            adminSer.Pass[adminSer.Count] = Convert.ToInt32(dr["MacOpterPWD"]);
                            adminSer.Count++;
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
                    List<TFeeProduct> prodList = new List<TFeeProduct>();
                    TFeeProduct feeProd;
                    prodList.Clear();
                    if (chkDownProd.Checked)
                    {
                        ss = prodStr.Split(' ');
                        string CategoryID = ss[0];
                        tmp = "";
                        if (CategoryID != "")
                            feeDef.ProductCategory = Convert.ToByte(CategoryID);
                        for (int i = 1; i < ss.Length; i++)
                        {
                            if ((ss[i] != "") && (Pub.IsNumeric(ss[i]))) tmp = tmp + ss[i] + ",";
                        }
                        if (tmp != "") tmp = tmp.Substring(0, tmp.Length - 1);
                        try
                        {
                            dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004004, new string[] { "106", tmp, CategoryID }));
                            while (dr.Read())
                            {
                                feeProd = new TFeeProduct();
                                feeProd.ID = Convert.ToInt32(dr["ProductsID"]);
                                feeProd.Name = dr["ProductsName"].ToString();
                                feeProd.Price = Convert.ToDouble(dr["ProductsPrice"]);
                                prodList.Add(feeProd);
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
                    TFeeLimit feeLimit;
                    TFeeConsumptionModel feeWay;
                    TFeeDiscount feeDisc;
                    TFeeCardLowBalance feeLow;
                    TFeeTimingPar feeTimingPar;
                    TFeeTimingRate feeTimingRate;
                    TFeeOrderRule feeOrder;
                    TFeeRinging feeBell = new TFeeRinging();
                    feeBell.Ringing = new string[6];
                    feeBell.RelayTimeout = bell.RelayTimeout;
                    feeBell.RingingTimeout = bell.BellTimeout;
                    for (int i = 0; i <= 5; i++)
                    {
                        feeBell.Ringing[i] = bell.BellTime[i];
                    }
                    string MacType = GetMacType(MacSN.ToString());
                    if (flag == 1)
                    {
                        DeviceObject.objKS.SysSetState(false);
                        DeviceObject.objKS.FeeClear();
                        tmpMsg = Pub.GetResText(formCode, "MsgSyncTime", "");
                    RetrySyncTime:
                        ret = SyncTime();
                        if (!ret)
                        {
                            if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                            {
                                MacMsg = tmpMsg;
                                goto ErrEnd;
                            }
                            else
                                goto RetrySyncTime;
                        }
                        tmpMsg = Pub.GetResText(formCode, "MsgCardSector", "");
                    RetryCard:
                        ret = DeviceObject.objKS.PubSectorSet();
                        if (!ret)
                        {
                            if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                            {
                                MacMsg = tmpMsg;
                                goto ErrEnd;
                            }
                            else
                                goto RetryCard;
                        }
                        tmpMsg = Pub.GetResText(formCode, "MsgCardKey", "");
                    RetryCardKey:
                        ret = DeviceObject.objKS.SysCardKey();
                        if (!ret)
                        {
                            if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                            {
                                MacMsg = tmpMsg;
                                goto ErrEnd;
                            }
                            else
                                goto RetryCardKey;
                        }
                        tmpMsg = Pub.GetResText(formCode, "Msg001", "");
                    RetryParam:
                        ret = DeviceObject.objKS.FeeDefault(ref feeDef);
                        if (!ret)
                        {
                            if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                            {
                                MacMsg = tmpMsg;
                                goto ErrEnd;
                            }
                            else
                                goto RetryParam;
                        }
                        tmpMsg = Pub.GetResText(formCode, "Msg002", "");
                    RetryTitle:
                        ret = DeviceObject.objKS.PubTitleSet(param.Title);
                        if (!ret)
                        {
                            if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                            {
                                MacMsg = tmpMsg;
                                goto ErrEnd;
                            }
                            else
                                goto RetryTitle;
                        }
                        tmpMsg = Pub.GetResText(formCode, "Msg003", "");
                    RetryRelay:
                        ret = DeviceObject.objKS.PubRelaySet(ref relaySet);
                        if (!ret)
                        {
                            if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                            {
                                MacMsg = tmpMsg;
                                goto ErrEnd;
                            }
                            else
                                goto RetryRelay;
                        }
                        tmpMsg = Pub.GetResText(formCode, "Msg013", "");
                    RetryBell:
                        ret = DeviceObject.objKS.FeeRingingSet(ref feeBell);
                        if (!ret)
                        {
                            if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                            {
                                MacMsg = tmpMsg;
                                goto ErrEnd;
                            }
                            else
                                goto RetryBell;
                        }
                        tmpMsg = Pub.GetResText(formCode, "Msg004", "");
                    RetryMeal:
                        ret = DeviceObject.objKS.FeeTimeSet(ref feeTimeSet);
                        if (!ret)
                        {
                            if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                            {
                                MacMsg = tmpMsg;
                                goto ErrEnd;
                            }
                            else
                                goto RetryMeal;
                        }
                        tmpMsg = Pub.GetResText(formCode, "MsgDeviceBlack", "");
                    RetryBlack:
                        int max = dtBlack.Rows.Count;
                        for (int i = 0; i < max; i++)
                        {
                            DeviceObject.objKS.PubBlackInit(dtBlack.Rows[i]["CardSectorNo"].ToString(), i == 0, false);
                        }
                        ret = DeviceObject.objKS.PubBlackClear();
                        if (!ret)
                        {
                            if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                            {
                                MacMsg = tmpMsg;
                                goto ErrEnd;
                            }
                            else
                                goto RetryBlack;
                        }
                        if (max > 0)
                        {
                            ret = DeviceObject.objKS.PubBlackData(SystemInfo.MainHandle.ToInt32());
                            if (!ret)
                            {
                                if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                                {
                                    MacMsg = tmpMsg;
                                    goto ErrEnd;
                                }
                                else
                                    goto RetryBlack;
                            }
                        }
                        tmpMsg = Pub.GetResText(formCode, "Msg005", "");
                    RetryPrint:
                        ret = DeviceObject.objKS.FeePrintTitle(ref feePrint);
                        if (!ret)
                        {
                            if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                            {
                                MacMsg = tmpMsg;
                                goto ErrEnd;
                            }
                            else
                                goto RetryPrint;
                        }
                        tmpMsg = Pub.GetResText(formCode, "Msg018", "");
                        tmpFile = SystemInfo.AppPath + "tmp.bmp";
                        try
                        {
                            if (File.Exists(tmpFile)) File.Delete(tmpFile);
                            if (logo.Length > 0)
                            {
                                Bitmap bmp = new Bitmap(logo);
                                bmp.Save(tmpFile);
                                bmp.Dispose();
                            }
                        }
                        catch
                        {
                        }
                    RetryPrintLogo:
                        ret = DeviceObject.objKS.PubPrintLogoClear();
                        if (!ret)
                        {
                            if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                            {
                                MacMsg = tmpMsg;
                                goto ErrEnd;
                            }
                            else
                                goto RetryPrintLogo;
                        }
                        if (File.Exists(tmpFile))
                        {
                            ret = DeviceObject.objKS.PubPrintLogoData(SystemInfo.MainHandle.ToInt32(), tmpFile);
                            if (!ret)
                            {
                                if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                                {
                                    MacMsg = tmpMsg;
                                    goto ErrEnd;
                                }
                                else
                                    goto RetryPrintLogo;
                            }
                            try
                            {
                                if (File.Exists(tmpFile)) File.Delete(tmpFile);
                            }
                            catch
                            {
                            }
                        }
                        tmpMsg = Pub.GetResText(formCode, "MsgDeviceOprt", "");
                    RetryOprt:
                        ret = DeviceObject.objKS.PubAdminUserClear();
                        if (!ret)
                        {
                            if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                            {
                                MacMsg = tmpMsg;
                                goto ErrEnd;
                            }
                            else
                                goto RetryOprt;
                        }
                        ret = DeviceObject.objKS.PubAdminUserSet(ref adminSer);
                        if (!ret)
                        {
                            if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                            {
                                MacMsg = tmpMsg;
                                goto ErrEnd;
                            }
                            else
                                goto RetryOprt;
                        }
                        tmpMsg = Pub.GetResText(formCode, "Msg014", "");
                    RetryCheckOrder:
                        ret = DeviceObject.objKS.PubSetCheckOrder(ref IsOrder);
                        if (!ret)
                        {
                            if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                            {
                                MacMsg = tmpMsg;
                                goto ErrEnd;
                            }
                            else
                                goto RetryCheckOrder;
                        }
                        tmpMsg = Pub.GetResText(formCode, "MsgCardTAG", "");
                    RetryCardTAG:
                        ret = DeviceObject.objKS.PubCardTAG(ref cardTAG);
                        if (!ret)
                        {
                            if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                            {
                                MacMsg = tmpMsg;
                                goto ErrEnd;
                            }
                            else
                                goto RetryCardTAG;
                        }
                        if (MacType == "32" || MacType == "33")
                        {
                            tmpMsg = Pub.GetResText(formCode, "Msg015", "");
                        RetryMobile:
                            ret = DeviceObject.objKS.SysMobileClear();
                            if (!ret)
                            {
                                if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                                {
                                    MacMsg = tmpMsg;
                                    goto ErrEnd;
                                }
                                else
                                    goto RetryMobile;
                            }
                            ret = DeviceObject.objKS.SysMobileSet(ref mobileInfo);
                            if (!ret)
                            {
                                if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                                {
                                    MacMsg = tmpMsg;
                                    goto ErrEnd;
                                }
                                else
                                    goto RetryMobile;
                            }
                        }
                        if (MacType == "32" || MacType == "33")
                        {
                            tmpMsg = Pub.GetResText(formCode, "Msg019", "");
                            try
                            {
                                for (int i = 0; i < chkCardType.Items.Count; i++)
                                {
                                    if (Convert.ToByte(chkCardType.GetItemChecked(i)).ToString() == "1")
                                    {
                                        QHKS.TFeeRechargeGift feeRechargeGift = new QHKS.TFeeRechargeGift();

                                        dtr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001001, new string[] { "110", chkCardType.Items[i].ToString() }));
                                        if (dtr.Read())
                                        {
                                            feeRechargeGift.CardType = Convert.ToByte(dtr["CardTypeID"]);
                                            Byte.TryParse(dtr["DepositDiscount"].ToString(), out feeRechargeGift.Rate);
                                        }
                                        dtr.Close();
                                        feeRechargeGift.Value = new double[5];
                                        feeRechargeGift.Gift = new double[5];
                                        int j = 0;
                                        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001001, new string[] { "109", chkCardType.Items[i].ToString() }));
                                        while (dr.Read())
                                        {
                                            feeRechargeGift.Value[j] = Convert.ToDouble(dr["DiscStart"]);
                                            feeRechargeGift.Gift[j] = Convert.ToDouble(dr["DiscDiscount"]);
                                            j++;
                                        }
                                        dr.Close();
                                    RetryMobile:

                                        ret = DeviceObject.objKS.FeeRechargeGift(ref feeRechargeGift);
                                        if (!ret)
                                        {
                                            if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                                            {
                                                MacMsg = tmpMsg;
                                                goto ErrEnd;
                                            }
                                            else
                                                goto RetryMobile;
                                        }
                                    }

                                }
                            }
                            catch
                            { }


                        }
                        if (MacType == "32")
                        {
                            tmpMsg = Pub.GetResText(formCode, "Msg016", "");
                            tmpFile = SystemInfo.AppPath + "tmp.jpg";
                            try
                            {
                                if (File.Exists(tmpFile)) File.Delete(tmpFile);
                                if (weixin.Length > 0)
                                {
                                    Bitmap bmp = new Bitmap(weixin);
                                    bmp.Save(tmpFile);
                                    bmp.Dispose();
                                }
                            }
                            catch
                            {
                            }
                        RetryWeiXin:
                            ret = DeviceObject.objKS.SysScanClear(0);
                            if (!ret)
                            {
                                if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                                {
                                    MacMsg = tmpMsg;
                                    goto ErrEnd;
                                }
                                else
                                    goto RetryWeiXin;
                            }
                            if (File.Exists(tmpFile))
                            {
                                ret = DeviceObject.objKS.SysScanData(SystemInfo.MainHandle.ToInt32(), 0, tmpFile);
                                if (!ret)
                                {
                                    if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                                    {
                                        MacMsg = tmpMsg;
                                        goto ErrEnd;
                                    }
                                    else
                                        goto RetryWeiXin;
                                }
                            }
                            try
                            {
                                if (File.Exists(tmpFile)) File.Delete(tmpFile);
                            }
                            catch
                            {
                            }
                            tmpMsg = Pub.GetResText(formCode, "Msg017", "");
                            tmpFile = SystemInfo.AppPath + "tmp.jpg";
                            try
                            {
                                if (File.Exists(tmpFile)) File.Delete(tmpFile);
                                if (alipay.Length > 0)
                                {
                                    Bitmap bmp = new Bitmap(alipay);
                                    bmp.Save(tmpFile);
                                    bmp.Dispose();
                                }
                            }
                            catch
                            {
                            }
                        RetryAliPay:
                            ret = DeviceObject.objKS.SysScanClear(1);
                            if (!ret)
                            {
                                if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                                {
                                    MacMsg = tmpMsg;
                                    goto ErrEnd;
                                }
                                else
                                    goto RetryAliPay;
                            }
                            if (File.Exists(tmpFile))
                            {
                                ret = DeviceObject.objKS.SysScanData(SystemInfo.MainHandle.ToInt32(), 1, tmpFile);
                                if (!ret)
                                {
                                    if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                                    {
                                        MacMsg = tmpMsg;
                                        goto ErrEnd;
                                    }
                                    else
                                        goto RetryAliPay;
                                }
                            }
                            try
                            {
                                if (File.Exists(tmpFile)) File.Delete(tmpFile);
                            }
                            catch
                            {
                            }
                            if (chkDownProd.Checked)
                            {
                                tmpMsg = Pub.GetResText(formCode, "Msg006", "");
                                max = prodList.Count;
                                if (max > SystemInfo.MaxProd603) max = SystemInfo.MaxProd603;
                                for (int i = 0; i < max; i++)
                                {
                                    feeProd = prodList[i];
                                    DeviceObject.objKS.FeeProductInit(ref feeProd, i == 0);
                                }
                            RetryProd:
                                ret = DeviceObject.objKS.FeeProductClear();
                                if (!ret)
                                {
                                    if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                                    {
                                        MacMsg = tmpMsg;
                                        goto ErrEnd;
                                    }
                                    else
                                        goto RetryProd;
                                }
                                if (max > 0)
                                {
                                    ret = DeviceObject.objKS.FeeProduct(SystemInfo.MainHandle.ToInt32());
                                    if (!ret)
                                    {
                                        if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                                        {
                                            MacMsg = tmpMsg;
                                            goto ErrEnd;
                                        }
                                        else
                                            goto RetryProd;
                                    }
                                }
                            }
                            if (limit.ExistsLimit)
                            {
                                tmpMsg = Pub.GetResText(formCode, "Msg007", "");
                            RetryLimit:
                                for (byte i = 0; i < SystemInfo.CardTypeCount; i++)
                                {
                                    feeLimit = new TFeeLimit();
                                    feeLimit.CardLevel = i;
                                    feeLimit.LimitType = limit.LimitType;
                                    feeLimit.AllowPass = Convert.ToByte(limit.AbovePass);
                                    feeLimit.MaxMoney = new double[6];
                                    feeLimit.MaxTimes = new byte[6];
                                    feeLimit.MaxMoney[0] = limit.Money1[i];
                                    feeLimit.MaxMoney[1] = limit.Money2[i];
                                    feeLimit.MaxMoney[2] = limit.Money3[i];
                                    feeLimit.MaxMoney[3] = limit.Money4[i];
                                    feeLimit.MaxMoney[4] = limit.Money5[i];
                                    feeLimit.MaxTimes[0] = limit.Ci1[i];
                                    feeLimit.MaxTimes[1] = limit.Ci2[i];
                                    feeLimit.MaxTimes[2] = limit.Ci3[i];
                                    feeLimit.MaxTimes[3] = limit.Ci4[i];
                                    feeLimit.MaxTimes[4] = limit.Ci5[i];
                                    feeLimit.MonthLimit = Convert.ToByte(SystemInfo.IsMonthLimit);
                                    ret = DeviceObject.objKS.FeeLimit(ref feeLimit);
                                    if (!ret)
                                    {
                                        if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                                        {
                                            MacMsg = tmpMsg;
                                            goto ErrEnd;
                                        }
                                        else
                                            goto RetryLimit;
                                    }
                                }
                            }
                            tmpMsg = Pub.GetResText(formCode, "Msg008", "");
                        RetryWay:
                            ret = DeviceObject.objKS.FeeConsumptionClear();
                            if (!ret)
                            {
                                if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                                {
                                    MacMsg = tmpMsg;
                                    goto ErrEnd;
                                }
                                else
                                    goto RetryWay;
                            }
                            if (way.ExistsWay)
                            {
                                for (byte i = 0; i < SystemInfo.CardTypeCount; i++)
                                {
                                    if ((way.CardTypeTime[i] == "* * * * * * * * * * * * * * * * * * * * * * * * ") ||
                                      (way.CardTypeTime[i] == "* * * * * * ")) continue;
                                    ss = way.CardTypeTime[i].Split(' ');
                                    feeWay = new TFeeConsumptionModel();
                                    feeWay.CardLevel = i;
                                    feeWay.Model = way.Way;
                                    feeWay.SecondAlarm = way.TwoBJ;
                                    feeWay.Allow = new byte[8];
                                    feeWay.Consumption = new byte[8];
                                    feeWay.Money = new double[8];
                                    int i1 = 0;
                                    int i2 = 8;
                                    if (way.Way == 2) i2 = 2;
                                    for (int j = i1; j < i2; j++)
                                    {
                                        feeWay.Consumption[j] = 0;
                                        feeWay.Money[j] = 0;
                                        if (ss[j * 3].ToUpper() == "Y")
                                        {
                                            feeWay.Allow[j] = 1;
                                            if (ss[j * 3 + 1] == "7")
                                                feeWay.Consumption[j] = 1;
                                            //else if(ss[j * 3 + 1] == "130")
                                            //  feeWay.Consumption[j] = 5;    //²Í´Î²¹Ìù
                                            else
                                                feeWay.Consumption[j] = 2;
                                            double.TryParse(ss[j * 3 + 2], out feeWay.Money[j]);
                                        }
                                        else if (ss[j * 3].ToUpper() == "N")
                                            feeWay.Allow[j] = 2;
                                        else
                                            feeWay.Allow[j] = 0;
                                    }
                                    ret = DeviceObject.objKS.FeeConsumptionModel(ref feeWay);
                                    if (!ret)
                                    {
                                        if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                                        {
                                            MacMsg = tmpMsg;
                                            goto ErrEnd;
                                        }
                                        else
                                            goto RetryWay;
                                    }
                                }
                            }
                            if (disc.ExistsDisc)
                            {
                                tmpMsg = Pub.GetResText(formCode, "Msg009", "");
                            RetryDisc:
                                for (byte i = 0; i < SystemInfo.CardTypeCount; i++)
                                {
                                    feeDisc = new TFeeDiscount();
                                    feeDisc.CardLevel = i;
                                    feeDisc.Discount = new byte[4];
                                    ss = disc.CardTypeTime[i].Split(' ');
                                    byte.TryParse(ss[0], out feeDisc.Discount[0]);
                                    byte.TryParse(ss[1], out feeDisc.Discount[1]);
                                    byte.TryParse(ss[2], out feeDisc.Discount[2]);
                                    byte.TryParse(ss[3], out feeDisc.Discount[3]);
                                    ret = DeviceObject.objKS.FeeDiscount(ref feeDisc);
                                    if (!ret)
                                    {
                                        if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                                        {
                                            MacMsg = tmpMsg;
                                            goto ErrEnd;
                                        }
                                        else
                                            goto RetryDisc;
                                    }
                                }
                            }
                            if (low.ExistsLowBalance)
                            {
                                tmpMsg = Pub.GetResText(formCode, "Msg010", "");
                            RetryBalance:
                                for (byte i = 0; i < SystemInfo.CardTypeCount; i++)
                                {
                                    if ((low.LowBalance[i] == "*") || !Pub.IsNumeric(low.LowBalance[i])) continue;
                                    feeLow = new TFeeCardLowBalance();
                                    feeLow.CardType = i;
                                    byte.TryParse(low.LowBalance[i], out feeLow.CardLow);
                                    ret = DeviceObject.objKS.FeeCardLowBalance(ref feeLow);
                                    if (!ret)
                                    {
                                        if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                                        {
                                            MacMsg = tmpMsg;
                                            goto ErrEnd;
                                        }
                                        else
                                            goto RetryBalance;
                                    }
                                }
                            }
                        }
                        else if (MacType == "35")
                        {
                            tmpMsg = Pub.GetResText(formCode, "Msg011", "");
                        RetryTimingPar:
                            ret = DeviceObject.objKS.FeeTimingClear();
                            if (!ret)
                            {
                                if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                                {
                                    MacMsg = tmpMsg;
                                    goto ErrEnd;
                                }
                                else
                                    goto RetryTimingPar;
                            }
                            if (timing.ExistsTiming)
                            {
                                feeTimingPar = new TFeeTimingPar();
                                feeTimingPar.Units = timing.Units;
                                feeTimingPar.Model = timing.Way;
                                feeTimingPar.MinValue = timing.MinuteMin;
                                feeTimingPar.MaxValue = timing.MinuteMax;
                                feeTimingPar.FreeValue = timing.MinuteFree;
                                feeTimingPar.DecFree = Convert.ToByte(timing.DecFree);
                                ret = DeviceObject.objKS.FeeTimingPar(ref feeTimingPar);
                                if (!ret)
                                {
                                    if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                                    {
                                        MacMsg = tmpMsg;
                                        goto ErrEnd;
                                    }
                                    else
                                        goto RetryTimingPar;
                                }
                                for (byte i = 0; i < 20; i++)
                                {
                                    feeTimingRate = new TFeeTimingRate();
                                    feeTimingRate.No = i;
                                    ss = timing.Info[i].Split(' ');
                                    feeTimingRate.DateType = ss[0];
                                    feeTimingRate.BeginTime = ss[1];
                                    feeTimingRate.EndTime = ss[2];
                                    feeTimingRate.RatesType = new byte[8];
                                    feeTimingRate.RatesMoney = new double[8];
                                    for (int j = 0; j < 8; j++)
                                    {
                                        if (Pub.IsNumeric(ss[j * 2 + 3]))
                                        {
                                            feeTimingRate.RatesType[j] = 1;
                                            double.TryParse(ss[j * 2 + 3], out feeTimingRate.RatesMoney[j]);
                                        }
                                        else if (Pub.IsNumeric(ss[j * 2 + 4]))
                                        {
                                            feeTimingRate.RatesType[j] = 2;
                                            double.TryParse(ss[j * 2 + 4], out feeTimingRate.RatesMoney[j]);
                                        }
                                        else
                                        {
                                            feeTimingRate.RatesType[j] = 0;
                                            feeTimingRate.RatesMoney[j] = 0;
                                        }
                                    }
                                RetryTimingRate:
                                    ret = DeviceObject.objKS.FeeTimingRate(ref feeTimingRate);
                                    if (!ret)
                                    {
                                        if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                                        {
                                            MacMsg = tmpMsg;
                                            goto ErrEnd;
                                        }
                                        else
                                            goto RetryTimingRate;
                                    }
                                }
                            }
                        }
                        else if (MacType == "36")
                        {
                            if (order.ExistsOrdering)
                            {
                                feeOrder = new TFeeOrderRule();
                                feeOrder.OrderType = order.OrderType;
                                feeOrder.OrderUnit = order.Units;
                                feeOrder.NextDay = new byte[4];
                                feeOrder.BeginTime = new string[4];
                                feeOrder.EndTime = new string[4];
                                feeOrder.OrderInfo = new byte[16];
                                feeOrder.Restday = new byte[7];
                                for (int j = 0; j < 4; j++)
                                {
                                    feeOrder.NextDay[j] = order.IsNextDay[j];
                                    feeOrder.BeginTime[j] = order.BeginTime[j];
                                    feeOrder.EndTime[j] = order.EndTime[j];
                                    for (int k = 0; k < 4; k++)
                                    {
                                        feeOrder.OrderInfo[j * 4 + k] = 0;
                                        if (order.OrderMemo.Substring(j * 4, 4).Substring(k, 1) == "1") feeOrder.OrderInfo[j * 4 + k] = 1;
                                    }
                                }
                                for (int h = 0; h < 7; h++)
                                {
                                    feeOrder.Restday[h] = order.Restday[h];
                                }
                                tmpMsg = Pub.GetResText(formCode, "Msg012", "");
                            RetryOrdering:
                                ret = DeviceObject.objKS.FeeOrderRule(ref feeOrder);
                                if (!ret)
                                {
                                    if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                                    {
                                        MacMsg = tmpMsg;
                                        goto ErrEnd;
                                    }
                                    else
                                        goto RetryOrdering;
                                }
                            }
                        }
                    }
                    else
                    {
                        DeviceObject.objKS.InitUSBFile(usbPath);
                        DeviceObject.objKS.PubSectorSetUSB();
                        DeviceObject.objKS.SysCardKeyUSB();
                        DeviceObject.objKS.FeeDefaultUSB(ref feeDef);
                        DeviceObject.objKS.PubTitleSetUSB(param.Title);
                        DeviceObject.objKS.PubRelaySetUSB(ref relaySet);
                        DeviceObject.objKS.FeeRingingSetUSB(ref feeBell);
                        DeviceObject.objKS.FeeTimeSetUSB(ref feeTimeSet);
                        DeviceObject.objKS.PubBlackClearUSB();

                        int max = dtBlack.Rows.Count;
                        for (int i = 0; i < max; i++)
                        {
                            DeviceObject.objKS.PubBlackInit(dtBlack.Rows[i]["CardSectorNo"].ToString(), i == 0, true);
                        }
                        if (max > 0) DeviceObject.objKS.PubBlackDataUSB();
                        DeviceObject.objKS.FeePrintTitleUSB(ref feePrint);
                        DeviceObject.objKS.PubAdminUserClearUSB();
                        DeviceObject.objKS.PubAdminUserSetUSB(ref adminSer);
                        DeviceObject.objKS.PubSetCheckOrderUSB(ref IsOrder);
                        DeviceObject.objKS.PubCardTAGUSB(ref cardTAG);

                        if (MacType == "32" || MacType == "33")
                        {

                            DeviceObject.objKS.SysMobileClearUSB();

                            DeviceObject.objKS.SysMobileSetUSB(ref mobileInfo);

                        }
                        if (MacType == "32" || MacType == "33")
                        {
                            try
                            {
                                for (int i = 0; i < chkCardType.Items.Count; i++)
                                {
                                    if (Convert.ToByte(chkCardType.GetItemChecked(i)).ToString() == "1")
                                    {
                                        QHKS.TFeeRechargeGift feeRechargeGift = new QHKS.TFeeRechargeGift();
                                        
                                        dtr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001001, new string[] { "110", chkCardType.Items[i].ToString() }));
                                        if (dtr.Read())
                                        {
                                            feeRechargeGift.CardType = Convert.ToByte(dtr["CardTypeID"]);
                                            feeRechargeGift.Rate = Convert.ToByte(dtr["DepositDiscount"]);
                                        }
                                        dtr.Close();
                                        feeRechargeGift.Value = new double[5];
                                        feeRechargeGift.Gift = new double[5];
                                        int j = 0;
                                        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001001, new string[] { "109", chkCardType.Items[i].ToString() }));
                                        while (dr.Read())
                                        {
                                            feeRechargeGift.Value[j] = Convert.ToDouble(dr["DiscStart"]);
                                            feeRechargeGift.Gift[j] = Convert.ToDouble(dr["DiscDiscount"]);
                                            j++;
                                        }
                                        dr.Close();
                                        DeviceObject.objKS.FeeRechargeGiftUSB(ref feeRechargeGift);
                                    }

                                }
                            }
                            catch
                            { }

                        }
                        if (MacType == "32")
                        {
                            if (chkDownProd.Checked)
                            {
                                max = prodList.Count;
                                if (max > SystemInfo.MaxProd603) max = SystemInfo.MaxProd603;
                                for (int i = 0; i < max; i++)
                                {
                                    feeProd = prodList[i];
                                    DeviceObject.objKS.FeeProductInit(ref feeProd, i == 0);
                                }
                                DeviceObject.objKS.FeeProductClearUSB();
                                if (max > 0) DeviceObject.objKS.FeeProductUSB();
                            }
                            if (limit.ExistsLimit)
                            {
                                for (byte i = 0; i < SystemInfo.CardTypeCount; i++)
                                {
                                    feeLimit = new TFeeLimit();
                                    feeLimit.CardLevel = i;
                                    feeLimit.LimitType = limit.LimitType;
                                    feeLimit.AllowPass = Convert.ToByte(limit.AbovePass);
                                    feeLimit.MaxMoney = new double[6];
                                    feeLimit.MaxTimes = new byte[6];
                                    feeLimit.MaxMoney[0] = limit.Money1[i];
                                    feeLimit.MaxMoney[1] = limit.Money2[i];
                                    feeLimit.MaxMoney[2] = limit.Money3[i];
                                    feeLimit.MaxMoney[3] = limit.Money4[i];
                                    feeLimit.MaxMoney[4] = limit.Money5[i];
                                    feeLimit.MaxTimes[0] = limit.Ci1[i];
                                    feeLimit.MaxTimes[1] = limit.Ci2[i];
                                    feeLimit.MaxTimes[2] = limit.Ci3[i];
                                    feeLimit.MaxTimes[3] = limit.Ci4[i];
                                    feeLimit.MaxTimes[4] = limit.Ci5[i];
                                    feeLimit.MonthLimit = Convert.ToByte(SystemInfo.IsMonthLimit);
                                    DeviceObject.objKS.FeeLimitUSB(ref feeLimit);
                                }
                            }
                            DeviceObject.objKS.FeeConsumptionClearUSB();
                            if (way.ExistsWay)
                            {
                                for (byte i = 0; i < SystemInfo.CardTypeCount; i++)
                                {
                                    if ((way.CardTypeTime[i] == "* * * * * * * * * * * * * * * * * * * * * * * * ") ||
                                      (way.CardTypeTime[i] == "* * * * * * ")) continue;
                                    ss = way.CardTypeTime[i].Split(' ');
                                    feeWay = new TFeeConsumptionModel();
                                    feeWay.CardLevel = i;
                                    feeWay.Model = way.Way;
                                    feeWay.SecondAlarm = way.TwoBJ;
                                    feeWay.Allow = new byte[8];
                                    feeWay.Consumption = new byte[8];
                                    feeWay.Money = new double[8];
                                    int i1 = 0;
                                    int i2 = 8;
                                    if (way.Way == 2) i2 = 2;
                                    for (int j = i1; j < i2; j++)
                                    {
                                        feeWay.Consumption[j] = 0;
                                        feeWay.Money[j] = 0;
                                        if (ss[j * 3].ToUpper() == "Y")
                                        {
                                            feeWay.Allow[j] = 1;
                                            if (ss[j * 3 + 1] == "7")
                                                feeWay.Consumption[j] = 1;
                                            else
                                                feeWay.Consumption[j] = 2;
                                            double.TryParse(ss[j * 3 + 2], out feeWay.Money[j]);
                                        }
                                        else if (ss[j * 3].ToUpper() == "N")
                                            feeWay.Allow[j] = 2;
                                        else
                                            feeWay.Allow[j] = 0;
                                    }
                                    DeviceObject.objKS.FeeConsumptionModelUSB(ref feeWay);
                                }
                            }
                            if (disc.ExistsDisc)
                            {
                                for (byte i = 0; i < SystemInfo.CardTypeCount; i++)
                                {
                                    feeDisc = new TFeeDiscount();
                                    feeDisc.CardLevel = i;
                                    feeDisc.Discount = new byte[4];
                                    ss = disc.CardTypeTime[i].Split(' ');
                                    byte.TryParse(ss[0], out feeDisc.Discount[0]);
                                    byte.TryParse(ss[1], out feeDisc.Discount[1]);
                                    byte.TryParse(ss[2], out feeDisc.Discount[2]);
                                    byte.TryParse(ss[3], out feeDisc.Discount[3]);
                                    DeviceObject.objKS.FeeDiscountUSB(ref feeDisc);
                                }
                            }
                            if (low.ExistsLowBalance)
                            {
                                for (byte i = 0; i < SystemInfo.CardTypeCount; i++)
                                {
                                    if ((low.LowBalance[i] == "*") || !Pub.IsNumeric(low.LowBalance[i])) continue;
                                    feeLow = new TFeeCardLowBalance();
                                    feeLow.CardType = i;
                                    byte.TryParse(low.LowBalance[i], out feeLow.CardLow);
                                    DeviceObject.objKS.FeeCardLowBalanceUSB(ref feeLow);
                                }
                            }
                        }
                        else if (MacType == "35")
                        {
                            DeviceObject.objKS.FeeTimingClearUSB();
                            if (timing.ExistsTiming)
                            {
                                feeTimingPar = new TFeeTimingPar();
                                feeTimingPar.Units = timing.Units;
                                feeTimingPar.Model = timing.Way;
                                feeTimingPar.MinValue = timing.MinuteMin;
                                feeTimingPar.MaxValue = timing.MinuteMax;
                                feeTimingPar.FreeValue = timing.MinuteFree;
                                feeTimingPar.DecFree = Convert.ToByte(timing.DecFree);
                                DeviceObject.objKS.FeeTimingParUSB(ref feeTimingPar);
                                for (byte i = 0; i < 20; i++)
                                {
                                    feeTimingRate = new TFeeTimingRate();
                                    feeTimingRate.No = i;
                                    ss = timing.Info[i].Split(' ');
                                    feeTimingRate.DateType = ss[0];
                                    feeTimingRate.BeginTime = ss[1];
                                    feeTimingRate.EndTime = ss[2];
                                    feeTimingRate.RatesType = new byte[8];
                                    feeTimingRate.RatesMoney = new double[8];
                                    for (int j = 0; j < 8; j++)
                                    {
                                        if (Pub.IsNumeric(ss[j * 2 + 3]))
                                        {
                                            feeTimingRate.RatesType[j] = 1;
                                            double.TryParse(ss[j * 2 + 3], out feeTimingRate.RatesMoney[j]);
                                        }
                                        else if (Pub.IsNumeric(ss[j * 2 + 4]))
                                        {
                                            feeTimingRate.RatesType[j] = 2;
                                            double.TryParse(ss[j * 2 + 4], out feeTimingRate.RatesMoney[j]);
                                        }
                                        else
                                        {
                                            feeTimingRate.RatesType[j] = 0;
                                            feeTimingRate.RatesMoney[j] = 0;
                                        }
                                    }
                                    DeviceObject.objKS.FeeTimingRateUSB(ref feeTimingRate);
                                }
                            }
                        }
                        else if (MacType == "36")
                        {
                            if (order.ExistsOrdering)
                            {
                                feeOrder = new TFeeOrderRule();
                                feeOrder.OrderType = order.OrderType;
                                feeOrder.OrderUnit = order.Units;
                                feeOrder.NextDay = new byte[4];
                                feeOrder.BeginTime = new string[4];
                                feeOrder.EndTime = new string[4];
                                feeOrder.OrderInfo = new byte[16];
                                feeOrder.Restday = new byte[7];
                                for (int j = 0; j < 4; j++)
                                {
                                    feeOrder.NextDay[j] = order.IsNextDay[j];
                                    feeOrder.BeginTime[j] = order.BeginTime[j];
                                    feeOrder.EndTime[j] = order.EndTime[j];
                                    for (int k = 0; k < 4; k++)
                                    {
                                        feeOrder.OrderInfo[j * 4 + k] = 0;
                                        if (order.OrderMemo.Substring(j * 4, 4).Substring(k, 1) == "1") feeOrder.OrderInfo[j * 4 + k] = 1;
                                    }
                                }
                                for (int h = 0; h < 7; h++)
                                {
                                    feeOrder.Restday[h] = order.Restday[h];
                                }
                                DeviceObject.objKS.FeeOrderRuleUSB(ref feeOrder);
                            }
                        }
                        ret = true;
                    }
                    break;
            }
        ErrEnd:
            if (flag == 1) DeviceObject.objKS.SysSetState(true);
            if (dtBlack != null)
            {
                dtBlack.Clear();
                dtBlack.Reset();
            }
           
            return ret;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmSFMacLimit frm = new frmSFMacLimit(this.Text, ((Button)sender).Text, GetMacSysID());
            frm.ShowDialog();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmSFMacWay frm = new frmSFMacWay(this.Text, ((Button)sender).Text, GetMacSysID());
            frm.ShowDialog();
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmSFMacDisc frm = new frmSFMacDisc(this.Text, ((Button)sender).Text, GetMacSysID());
            frm.ShowDialog();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmSFMacLowBalance frm = new frmSFMacLowBalance(this.Text, ((Button)sender).Text, GetMacSysID());
            frm.ShowDialog();
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmSFMacProductsSelect frm = new frmSFMacProductsSelect(this.Text, ((Button)sender).Text, GetMacSysID());
            frm.ShowDialog();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmSFMacOpterSelect frm = new frmSFMacOpterSelect(this.Text, ((Button)sender).Text, GetMacSysID());
            frm.ShowDialog();
          
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmSFMacTiming frm = new frmSFMacTiming(this.Text, ((Button)sender).Text, GetMacSysID());
            frm.ShowDialog();
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmSFMacOrder frm = new frmSFMacOrder(this.Text, ((Button)sender).Text, GetMacSysID());
            frm.ShowDialog();
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frmSFMacPrintTitle frm = new frmSFMacPrintTitle(this.Text, ((Button)sender).Text, GetMacSysID());
            frm.ShowDialog();
           
        }

        private void button10_Click(object sender, EventArgs e)
        {
            frmSFMacMobileInfo frm = new frmSFMacMobileInfo(this.Text, ((Button)sender).Text, GetMacSysID());
            frm.ShowDialog();
           
        }
    }
}