using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmRSEmpCardModify : frmBaseDialog
    {
        private string title = "";
        private string oprt = "";
        private bool IsChgOk = false;
        private bool IsReadCard = false;
        private HSUNFK.TCardPubData pubData = new HSUNFK.TCardPubData();
        private HSUNFK.TCardSFData sfData = new HSUNFK.TCardSFData();
        private string CardData10 = "";
        private string CardDataH = "";
        private string CardData8 = "";
        private bool IsWorking = false;
        private bool CardCheckOrder = false;
        private bool OkContinue = true;

        protected override void InitForm()
        {
            formCode = "RSEmpCardModify";
            base.InitForm();
            this.Text = title + "[" + oprt + "]";
            btnSelectCardStartDate.Text = Pub.GetResText(formCode, "btnSelectDepart", "");
            btnSelectCardEndDate.Text = btnSelectCardStartDate.Text;
            SetTextboxNumber(txtCardPWD);
            SetTextboxNumber(txtCardPWDA);
            SetTextboxNumber(txtCardSectorNo);
            IsChgOk = false;
            IsReadCard = false;
            GetCardTypeList();
            for (int i = 0; i < cardTypeList.Count; i++)
            {
                cbbCardType.Items.Add(cardTypeList[i]);
            }
            ResetForm();
            txtEmpNo.MaxLength = SystemInfo.EmpNoPrefix.Length + SystemInfo.EmpNoNumBit;
            OkContinue = SystemInfo.ini.ReadIni("Public", "CardOk", true);
        }

        public frmRSEmpCardModify(string Title, string Oprt)
        {
            title = Title;
            oprt = Oprt;
            InitializeComponent();
        }

        private void frmRSEmpCardModify_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (IsChgOk) this.DialogResult = DialogResult.OK;
        }

        private void btnSelectCardStartDate_Click(object sender, EventArgs e)
        {
            DateTime d = new DateTime();
            DateTime.TryParse(txtCardStartDate.Text, out d);
            if (Pub.GetSelectDate(false, ref d)) txtCardStartDate.Text = d.ToShortDateString();
        }

        private void btnSelectCardEndDate_Click(object sender, EventArgs e)
        {
            DateTime d = new DateTime();
            DateTime.TryParse(txtCardEndDate.Text, out d);
            if (Pub.GetSelectDate(false, ref d)) txtCardEndDate.Text = d.ToShortDateString();
        }

        private void btnReadCard_Click(object sender, EventArgs e)
        {
            IsReadCard = false;
            pubData = new HSUNFK.TCardPubData();
            sfData = new HSUNFK.TCardSFData();
            CardData10 = "";
            CardDataH = "";
            CardData8 = "";
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
            DataTableReader dr = null;
            bool IsOk = false;
            string EmpNo = "";
            string EmpName = "";
            string CardPWD = "";
            string DepartName = "";
            string DepartID = "";
            string CardStatusName = "";
            string FaDate = "";
            CardCheckOrder = false;
            SysID = "";
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "215", pubData.CardNo }));
                if (dr.Read())
                {
                    if (Convert.ToInt32(dr["CardStatusID"]) != 20)
                    {
                        Pub.ShowErrorMsg(Pub.GetResText(formCode, "MsgCardModifyNotNormal", ""));
                    }
                    else
                    {
                        SysID = dr["EmpSysID"].ToString();
                        EmpNo = dr["EmpNo"].ToString();
                        EmpName = dr["EmpName"].ToString();
                        CardPWD = dr["CardPWD"].ToString();
                        DepartName = dr["DepartName"].ToString();
                        DepartID = dr["DepartSysID"].ToString();
                        CardStatusName = dr["CardStatusName"].ToString();
                        FaDate = dr["FaDate"].ToString();
                        CardCheckOrder = Pub.ValueToBool(dr["CardCheckOrder"].ToString());
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
            double BTMoney = db.GetBTMoney(sfData.BtDate, sfData.BtMonery);
            double AllBalance = sfData.Balance + BTMoney;
            txtEmpNo.Text = EmpNo;
            txtEmpName.Text = EmpName;
            txtCardPWD.Text = CardPWD;
            txtCardPWDA.Text = CardPWD;
            txtCardSectorNo.Text = pubData.CardNo;
            cbbCardType.SelectedIndex = -1;
            for (int i = 0; i < cbbCardType.Items.Count; i++)
            {
                if (((TCardType)cbbCardType.Items[i]).id == pubData.CardTypeID)
                {
                    cbbCardType.SelectedIndex = i;
                    break;
                }
            }
            txtCardStartDate.Text = pubData.CardBeginDate.ToShortDateString();
            txtCardEndDate.Text = pubData.CardEndDate.ToShortDateString();
            txtDepartName.Text = DepartName;
            txtDepartName.Tag = DepartID;
            txtCardStatusName.Text = CardStatusName;
            txtFaDate.Text = FaDate;
            txtSFCardBalance.Text = AllBalance.ToString(SystemInfo.CurrencySymbol + "0.00");
            IsReadCard = true;
            Pub.CardBuzzer();
            ResetForm();
            txtEmpNo.Focus();
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
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "MsgCardReadFirst", ""));
                return;
            }
            string EmpNo = txtEmpNo.Text.Trim();
            string EmpName = txtEmpName.Text.Trim();
            int CardTypeID = ((TCardType)cbbCardType.Items[cbbCardType.SelectedIndex]).id;
            string CardSectorNo = txtCardSectorNo.Text.Trim();
            CardSectorNo = Convert.ToUInt32(CardSectorNo).ToString("0000000000");
            DateTime CardStartDate = new DateTime();
            DateTime CardEndDate = new DateTime();
            string CardPWD = txtCardPWD.Text.Trim();
            string CardPWDA = txtCardPWDA.Text.Trim();
            string DepartSysID = "";
            if (txtDepartName.Tag != null) DepartSysID = txtDepartName.Tag.ToString();
            if (EmpNo == "")
            {
                txtEmpNo.Focus();
                ShowErrorEnterCorrect(label1.Text);
                return;
            }
            if (DepartSysID == "")
            {
                txtDepartName.Focus();
                ShowErrorSelectCorrect(label4.Text);
                return;
            }
            if (!Pub.CheckTextMaxLength(label1.Text, EmpNo, txtEmpNo.MaxLength))
            {
                txtEmpNo.Focus();
                return;
            }
            if (!Pub.CheckTextMaxLength(label2.Text, EmpName, txtEmpName.MaxLength))
            {
                txtEmpName.Focus();
                return;
            }
            if (CardPWD == "") CardPWD = "000000";
            if (!Pub.IsNumeric(CardPWD))
            {
                txtCardPWD.Focus();
                ShowErrorEnterCorrect(label16.Text);
                return;
            }
            if (!Pub.CheckTextMaxLength(label16.Text, CardPWD, txtCardPWD.MaxLength))
            {
                txtCardPWD.Focus();
                return;
            }
            CardPWD = Convert.ToInt32(CardPWD).ToString("000000");
            if (CardPWD != CardPWDA)
            {
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorPasswordTwo", ""));
                return;
            }
            if ((txtCardStartDate.Text.Trim() == "") || (!DateTime.TryParse(txtCardStartDate.Text.Trim(), out CardStartDate)))
            {
                txtCardStartDate.Focus();
                ShowErrorEnterCorrect(label13.Text);
                return;
            }
            if ((txtCardEndDate.Text.Trim() == "") || (!DateTime.TryParse(txtCardEndDate.Text.Trim(), out CardEndDate)))
            {
                txtCardEndDate.Focus();
                ShowErrorEnterCorrect(label14.Text);
                return;
            }
            DataTableReader dr = null;
            bool IsOk = true;
            try
            {
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "4", SysID, EmpNo }));
                if (dr.Read())
                {
                    txtEmpNo.Focus();
                    ShowErrorCannotRepeated(label1.Text);
                    IsOk = false;
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
            pubData.EmpNo = EmpNo;
            pubData.EmpName = EmpName;
            pubData.CardNo = CardSectorNo;
            pubData.CardTypeID = Convert.ToByte(CardTypeID);
            pubData.CardPWD = CardPWD;
            pubData.CardBeginDate = CardStartDate;
            pubData.CardEndDate = CardEndDate;
            pubData.IsCheckOrder = Convert.ToByte(CardCheckOrder);
            int cardRet = 0;
            string CardNo10 = "";
            string CardNoH = "";
            string CardNo8 = "";
            string msg = "[" + EmpNo + "]" + EmpName + ": " + CardSectorNo + "/" + txtDepartName.Text;
        ContinuePub:
            Application.DoEvents();
            CardNo10 = "";
            CardNoH = "";
            CardNo8 = "";
            if (!DeviceObject.objCPIC.GetCardData(ref CardNo10, ref CardNoH, ref CardNo8))
            {
                if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "ReadCardError3", "") + "\r\n\r\n" +
                  Pub.GetResText(formCode, "MsgContinue", "")))
                    return;
                else
                    goto ContinuePub;
            }
            if (CardNo10 != CardData10)
            {
                if (OkContinue)
                {
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "MsgCardSame", "") + "\r\n\r\n" +
                      Pub.GetResText(formCode, "MsgCardOkContinue", ""));
                    goto ContinuePub;
                }
                else
                {
                    if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "MsgCardSame", "")))
                        return;
                    else
                        goto ContinuePub;
                }
            }
            cardRet = Pub.WriteCardInfo(pubData);
            if (cardRet != 0)
            {
                if (OkContinue)
                {
                    Pub.ShowErrorMsg(Pub.GetCardMsg(cardRet) + "\r\n\r\n" + Pub.GetResText(formCode, "MsgCardOkContinue", ""));
                    goto ContinuePub;
                }
                else
                {
                    if (Pub.MessageBoxShowQuestion(Pub.GetCardMsg(cardRet) + Pub.GetResText(formCode, "MsgContinue", "")))
                        return;
                    else
                        goto ContinuePub;
                }
            }
        ContinueData:
            Application.DoEvents();
            if (!db.EmpCardModify(this.Text, oprt, CardSectorNo, CardTypeID, CardPWD, CardStartDate, CardEndDate,
              EmpNo, EmpName, DepartSysID))
            {
                if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "ErrorCardDB", "")))
                {
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "MsgCardModifyFailed", ""));
                    return;
                }
                else
                    goto ContinueData;
            }
            IsChgOk = true;
            Pub.CardBuzzer();
            db.WriteSYLog(this.Text, oprt, msg);
            db.UpdateEmpRegisterData(SysID, 10, CardPWD);
            Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgCardModifySuccess", ""), MessageBoxIcon.Information);
            IsReadCard = false;
            ResetForm();
            
        }

        private void ResetForm()
        {
            if (!IsReadCard)
            {
                txtEmpNo.Text = "";
                txtEmpName.Text = "";
                txtCardPWD.Text = "";
                txtCardPWDA.Text = "";
                txtCardSectorNo.Text = "";
                cbbCardType.SelectedIndex = -1;
                txtCardStartDate.Text = "";
                txtCardEndDate.Text = "";
                txtDepartName.Text = "";
                txtCardStatusName.Text = "";
                txtFaDate.Text = "";
                txtSFCardBalance.Text = Convert.ToDecimal("0").ToString(SystemInfo.CurrencySymbol + "0.00");
                CardData10 = "";
                CardDataH = "";
                CardData8 = "";
            }
            txtEmpNo.Enabled = IsReadCard;
            txtEmpName.Enabled = IsReadCard;
            txtCardPWD.Enabled = IsReadCard;
            txtCardPWDA.Enabled = IsReadCard;
            txtCardSectorNo.Enabled = IsReadCard;
            cbbCardType.Enabled = IsReadCard;
            txtCardStartDate.Enabled = IsReadCard;
            txtCardEndDate.Enabled = IsReadCard;
            txtDepartName.Enabled = IsReadCard;
            txtCardStatusName.Enabled = IsReadCard;
            txtFaDate.Enabled = IsReadCard;
            txtSFCardBalance.Enabled = IsReadCard;
            btnSelectCardStartDate.Enabled = IsReadCard;
            btnSelectCardEndDate.Enabled = IsReadCard;
            btnOk.Enabled = IsReadCard;
        }

        private void frmRSEmpCardModify_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsWorking) e.Cancel = true;
        }

        private void btnSelectDepart_Click(object sender, EventArgs e)
        {
            frmPubSelectDepart frm = new frmPubSelectDepart(false);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtDepartName.Text = frm.DepartName;
                txtDepartName.Tag = frm.DepartSysID;
            }
           
        }
    }
}