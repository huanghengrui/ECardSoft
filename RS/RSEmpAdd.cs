using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ECard78
{
    public partial class frmRSEmpAdd : frmBaseDialog
    {
        public bool IsAddNext = false;
        private bool IsAdd = false;
        private byte IDCardDevice = 0;
        private byte IDCardPort = 0;

        protected override void InitForm()
        {
            formCode = "RSEmpAdd";
            base.InitForm();
            this.Text = Title + "[" + CurrentOprt + "]";
            SetTextboxNumber(txtCardPWD);
            SetTextboxNumber(txtCardSectorNo);
            SetTextboxNumber(txtCardFingerNo);
            SetTextboxNumber(txtOtherCardNo);
            IsAdd = SysID == "";
            cbbFingerPrivilege.Items.Clear();
            cbbFingerPrivilege.Items.Add(Pub.GetResText(formCode, "FingerPrivilege0", ""));
            cbbFingerPrivilege.Items.Add(Pub.GetResText(formCode, "FingerPrivilege1", ""));
            label1.ForeColor = Color.Red;
            label4.ForeColor = Color.Red;
            label5.ForeColor = Color.Red;
            label11.ForeColor = Color.Red;
            chkIsAdd.Enabled = SysID == "";
            chkIsAdd.Visible = chkIsAdd.Enabled;
            btnSelectEmpHireDate.Text = btnSelectDepart.Text;
            btnSelectCardStartDate.Text = btnSelectDepart.Text;
            btnSelectCardEndDate.Text = btnSelectDepart.Text;
            lbPhotoSize.Text = "";
            lbDynPhotoSize.Text = "";
            if (!SystemInfo.HasFaCard)
            {
                label12.Enabled = false;
                txtCardSectorNo.Enabled = false;
            }
            if (!SystemInfo.HasKQ || (SystemInfo.HasKQ && ((SystemInfo.KQFlag == 0) || (SystemInfo.KQFlag == 3))))
            {
                label15.Enabled = false;
                txtCardFingerNo.Enabled = false;
                label9.Enabled = false;
                cbbFingerPrivilege.Enabled = false;
            }
            KeyPreview = true;
            txtEmpNo.MaxLength = SystemInfo.EmpNoPrefix.Length + SystemInfo.EmpNoNumBit;
            btnIDCard.Enabled = SystemInfo.ini.ReadIni("Public", "IDCardUse", false);
            btnIDCard.Visible = btnIDCard.Enabled;
            IDCardDevice = SystemInfo.ini.ReadIni("Public", "IDCardDevice", (byte)0);
            IDCardPort = SystemInfo.ini.ReadIni("Public", "IDCardDevice", (byte)0);
            txtCardSectorNo.Enabled = SystemInfo.AllowCustomerCardNo;
            LoadData();
        }

        public frmRSEmpAdd(string title, string CurrentTool, string GUID)
        {
            Title = title;
            CurrentOprt = CurrentTool;
            SysID = GUID;
            InitializeComponent();
        }

        private void LoadData()
        {
            cbbEmpSex.Items.Clear();
            cbbCardType.Items.Clear();
            DataTableReader dr = null;
            GetCardTypeList();
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                TCardType cardType;
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "102" }));
                while (dr.Read())
                {
                    cardType = new TCardType(dr["EmpSexSysID"].ToString(), Convert.ToInt32(dr["EmpSexID"].ToString()),
                      dr["EmpSexName"].ToString());
                    cbbEmpSex.Items.Add(cardType);
                }
                dr.Close();
                for (int i = 0; i < cardTypeList.Count; i++)
                {
                    cbbCardType.Items.Add(cardTypeList[i]);
                }
                if (SysID == "")
                {
                    txtCardSectorNo.Enabled = true;
                    txtEmpNo.Text = db.GetAutoEmpNo();
                    txtEmpHireDate.Text = DateTime.Now.Date.ToShortDateString();
                    txtCardStartDate.Text = DateTime.Now.Date.ToShortDateString();
                    txtCardEndDate.Text = DateTime.Now.Date.AddYears(20).ToShortDateString();
                    if (cbbEmpSex.Items.Count > 0) cbbEmpSex.SelectedIndex = 0;
                    if (cbbCardType.Items.Count > 0) cbbCardType.SelectedIndex = 0;
                    txtCardPWD.Text = "000000";
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "103" }));
                    if (dr.Read())
                    {
                        txtCardFingerNo.Text = dr[0].ToString();
                    }
                    dr.Close();

                    txtCardSectorNo.Text = db.GetMaxCardSectorNo(); ;
                    txtDepartName.Text = SystemInfo.CommanyName;
                    txtDepartName.Tag = SystemInfo.CommanySysID;
                    cbbFingerPrivilege.SelectedIndex = 0;
                }
                else
                {

                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "1", SysID }));
                    if (dr.Read())
                    {
                        txtCardSectorNo.Enabled = true;
                        txtEmpNo.Text = dr["EmpNo"].ToString();
                        txtEmpName.Text = dr["EmpName"].ToString();
                        cbbEmpSex.Text = dr["EmpSexName"].ToString();
                        DateTime d = new DateTime();
                        if (DateTime.TryParse(dr["EmpHireDate"].ToString(), out d)) txtEmpHireDate.Text = d.ToShortDateString();
                        txtDepartName.Text = dr["DepartName"].ToString();
                        txtDepartName.Tag = dr["DepartSysID"].ToString();
                        cbbCardType.Text = dr["CardTypeName"].ToString();
                        txtEmpCertNo.Text = dr["EmpCertNo"].ToString();
                        txtCardPWD.Text = dr["CardPWD"].ToString();
                        txtCardSectorNo.Text = dr["CardSectorNo"].ToString();
                        if (DateTime.TryParse(dr["CardStartDate"].ToString(), out d)) txtCardStartDate.Text = d.ToShortDateString();
                        if (DateTime.TryParse(dr["CardEndDate"].ToString(), out d)) txtCardEndDate.Text = d.ToShortDateString();
                        txtCardFingerNo.Text = dr["CardFingerNo"].ToString();
                        int index = 0;
                        int.TryParse(dr["FingerPrivilege"].ToString(), out index);
                        cbbFingerPrivilege.SelectedIndex = index;
                        txtEmpAddress.Text = dr["EmpAddress"].ToString();
                        txtEmpZipNo.Text = dr["EmpZipNo"].ToString();
                        txtEmpEmail.Text = dr["EmpEmail"].ToString();
                        chkIsAttend.Checked = dr["IsAttend"].ToString() == "Y";
                        txtEmpPhoneNo.Text = dr["EmpPhoneNo"].ToString();
                        txtOtherCardNo.Text = dr["OtherCardNo"].ToString();
                        int cardStatusID = Convert.ToInt32(dr["CardStatusID"].ToString());
                        switch (cardStatusID)
                        {
                            case 10:
                            case 60:
                                break;
                            default:
                                txtEmpNo.Enabled = false;
                                txtEmpName.Enabled = false;
                                cbbCardType.Enabled = false;
                                txtCardPWD.Enabled = false;
                                txtCardSectorNo.Enabled = false;
                                txtCardStartDate.Enabled = false;
                                btnSelectCardStartDate.Enabled = false;
                                txtCardEndDate.Enabled = false;
                                btnSelectCardEndDate.Enabled = false;
                                txtCardFingerNo.Enabled = false;
                                btnIDCard.Enabled = false;
                                btnIDCard.Visible = btnIDCard.Enabled;

                                break;
                        }
                        dr.Close();
                        int FingerNo = 0;
                        int.TryParse(txtCardFingerNo.Text, out FingerNo);
                        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "114", FingerNo.ToString() }));
                        if (dr.Read())
                            txtCardFingerNo.Enabled = false;
                        else
                        {
                            dr.Close();
                            dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "115", FingerNo.ToString() }));
                            if (dr.Read()) txtCardFingerNo.Enabled = false;
                        }
                        dr.Close();
                        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "104", SysID }));
                        if (dr.Read())
                        {
                            if (dr["EmpPhotoImage"].ToString() != "")
                            {
                                byte[] buff = (byte[])(dr["EmpPhotoImage"]);
                                if (buff.Length > 0)
                                {
                                    MemoryStream ms = new MemoryStream(buff);
                                    picPhoto.BackgroundImage = Image.FromStream(ms);
                                    ms.Close();
                                    lbPhotoSize.Text = picPhoto.BackgroundImage.Height + "*" + picPhoto.BackgroundImage.Width;
                                }
                            }
                        }
                        dr.Close();
                        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "33", SysID }));
                        if (dr.Read())
                        {
                            if (dr["EmpPhotoImage"].ToString() != "")
                            {
                                byte[] buff = (byte[])(dr["EmpPhotoImage"]);
                                if (buff.Length > 0)
                                {
                                    MemoryStream ms = new MemoryStream(buff);
                                    picDynPhoto.BackgroundImage = Image.FromStream(ms);
                                    ms.Close();
                                    lbDynPhotoSize.Text = picDynPhoto.BackgroundImage.Height + "*"+ picDynPhoto.BackgroundImage.Width;
                                }
                            }
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
        }

        private void btnSelectEmpHireDate_Click(object sender, EventArgs e)
        {
            DateTime d = new DateTime();
            DateTime.TryParse(txtEmpHireDate.Text, out d);
            if (Pub.GetSelectDate(false, ref d)) txtEmpHireDate.Text = d.ToShortDateString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (dlgOpen.ShowDialog() != DialogResult.OK) return;
            picPhoto.BackgroundImage = CustomSizeImage(Image.FromFile(dlgOpen.FileName));
            picDynPhoto.BackgroundImage = CustomSizePhoto(Image.FromFile(dlgOpen.FileName));
            if(picPhoto.BackgroundImage!=null)
            {
                lbPhotoSize.Text = picPhoto.BackgroundImage.Height + "*" + picPhoto.BackgroundImage.Width;
            }
            if (picDynPhoto.BackgroundImage != null)
            {
                lbDynPhotoSize.Text = picDynPhoto.BackgroundImage.Height + "*" + picDynPhoto.BackgroundImage.Width;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            picPhoto.BackgroundImage = null;
            picDynPhoto.BackgroundImage = null;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cbbCardType.SelectedIndex == -1)
            {
                cbbCardType.Focus();
                ShowErrorSelectCorrect(label11.Text);
                return;
            }
            string EmpNo = txtEmpNo.Text.Trim();
            string EmpName = txtEmpName.Text.Trim();
            string EmpSexSysID = "";
            if (cbbEmpSex.SelectedIndex >= 0)
            {
                EmpSexSysID = ((TCardType)cbbEmpSex.Items[cbbEmpSex.SelectedIndex]).sysID;
            }
            string EmpHireDate = txtEmpHireDate.Text.Trim();
            string DepartSysID = "";
            if (txtDepartName.Tag != null) DepartSysID = txtDepartName.Tag.ToString();
            string CardTypeSysID = ((TCardType)cbbCardType.Items[cbbCardType.SelectedIndex]).sysID;
            string EmpCertNo = txtEmpCertNo.Text.Trim();
            string CardPWD = txtCardPWD.Text.Trim();
            string CardSectorNo = txtCardSectorNo.Text.Trim();
            string CardStartDate = txtCardStartDate.Text.Trim();
            string CardEndDate = txtCardEndDate.Text.Trim();
            string CardFingerNo = txtCardFingerNo.Text.Trim();
            string FingerPrivilege = cbbFingerPrivilege.SelectedIndex.ToString();
            string EmpPhoneNo = txtEmpPhoneNo.Text.Trim();
            string EmpAddress = txtEmpAddress.Text.Trim();
            string EmpZipNo = txtEmpZipNo.Text.Trim();
            string EmpEmail = txtEmpEmail.Text.Trim();
            string IsAttend = "N";
            if (chkIsAttend.Checked) IsAttend = "Y";
            string OtherCardNo = txtOtherCardNo.Text.Trim();
            if (txtEmpNo.Enabled)
            {
                if (EmpNo == "")
                {
                    txtEmpNo.Focus();
                    ShowErrorEnterCorrect(label1.Text);
                    return;
                }
                if (!Pub.CheckTextMaxLength(label1.Text, EmpNo, txtEmpNo.MaxLength))
                {
                    txtEmpNo.Focus();
                    return;
                }
            }
            if (txtEmpName.Enabled)
            {
                if (!Pub.CheckTextMaxLength(label2.Text, EmpName, txtEmpName.MaxLength))
                {
                    txtEmpName.Focus();
                    return;
                }
            }
            if (DepartSysID == "")
            {
                txtDepartName.Focus();
                ShowErrorSelectCorrect(label4.Text);
                return;
            }
            DateTime d = new DateTime();
            if ((EmpHireDate == "") || (!DateTime.TryParse(EmpHireDate, out d)))
            {
                txtEmpHireDate.Focus();
                ShowErrorEnterCorrect(label5.Text);
                return;
            }
            EmpHireDate = d.ToString(SystemInfo.SQLDateFMT);
            if (!Pub.CheckTextMaxLength(label6.Text, EmpCertNo, txtEmpCertNo.MaxLength))
            {
                txtEmpCertNo.Focus();
                return;
            }
            if (txtCardPWD.Enabled)
            {
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
            }
            if (txtCardSectorNo.Enabled)
            {
                if ((CardSectorNo != "") && (!Pub.IsNumeric(CardSectorNo)))
                {
                    txtCardSectorNo.Focus();
                    ShowErrorEnterCorrect(label12.Text);
                    return;
                }
                if (!Pub.CheckTextMaxLength(label12.Text, CardSectorNo, txtCardSectorNo.MaxLength))
                {
                    txtCardSectorNo.Focus();
                    return;
                }
                if (CardSectorNo != "")
                {
                    CardSectorNo = Convert.ToUInt64(CardSectorNo).ToString("0000000000");
                    if ((Convert.ToUInt64(CardSectorNo) <= 0) || (Convert.ToUInt64(CardSectorNo) > SystemInfo.MaxCardID))
                    {
                        Pub.ShowErrorMsg(SystemInfo.MsgMaxCardID);
                        return;
                    }
                }
            }
            if (txtOtherCardNo.Enabled)
            {
                if ((OtherCardNo != "") && (!Pub.IsNumeric(OtherCardNo)))
                {
                    txtOtherCardNo.Focus();
                    ShowErrorEnterCorrect(label19.Text);
                    return;
                }
                if (!Pub.CheckTextMaxLength(label19.Text, OtherCardNo, txtOtherCardNo.MaxLength))
                {
                    txtOtherCardNo.Focus();
                    return;
                }
                //if (OtherCardNo != "") OtherCardNo = Convert.ToUInt32(OtherCardNo).ToString("0000000000");
            }
            if (txtCardStartDate.Enabled)
            {
                if ((CardStartDate == "") || (!DateTime.TryParse(CardStartDate, out d)))
                {
                    txtCardStartDate.Focus();
                    ShowErrorEnterCorrect(label13.Text);
                    return;
                }
                CardStartDate = d.ToString(SystemInfo.SQLDateFMT);
            }
            if (txtCardEndDate.Enabled)
            {
                if ((CardEndDate == "") || (!DateTime.TryParse(CardEndDate, out d)))
                {
                    txtCardEndDate.Focus();
                    ShowErrorEnterCorrect(label14.Text);
                    return;
                }
                CardEndDate = d.ToString(SystemInfo.SQLDateFMT);
            }
            if (txtCardFingerNo.Enabled)
            {
                if ((CardFingerNo != "") && (!Pub.IsNumeric(CardFingerNo)))
                {
                    txtCardFingerNo.Focus();
                    ShowErrorEnterCorrect(label15.Text);
                    return;
                }
                if (!Pub.CheckTextMaxLength(label15.Text, CardFingerNo, txtCardFingerNo.MaxLength))
                {
                    txtCardFingerNo.Focus();
                    return;
                }
            }
            if (!Pub.CheckTextMaxLength(label17.Text, EmpPhoneNo, txtEmpPhoneNo.MaxLength))
            {
                txtEmpPhoneNo.Focus();
                return;
            }
            if (!Pub.CheckTextMaxLength(label7.Text, EmpAddress, txtEmpAddress.MaxLength))
            {
                txtEmpAddress.Focus();
                return;
            }
            if (!Pub.CheckTextMaxLength(label8.Text, EmpZipNo, txtEmpZipNo.MaxLength))
            {
                txtEmpZipNo.Focus();
                return;
            }
            if (!Pub.CheckTextMaxLength(label10.Text, EmpEmail, txtEmpEmail.MaxLength))
            {
                txtEmpEmail.Focus();
                return;
            }
            CardStartDate = "'" + CardStartDate + "'";
            CardEndDate = "'" + CardEndDate + "'";
            DataTableReader dr = null;
            bool IsOk = true;
            List<string> sql = new List<string>();
            string CardNoDays = "";
            string msg = "";
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                if (IsAdd)
                {
                    if (!db.GetServerGUID(ref SysID)) return;
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "2", EmpNo }));
                    if (dr.Read())
                    {
                        txtEmpNo.Focus();
                        ShowErrorCannotRepeated(label1.Text);
                        IsOk = false;
                    }
                    dr.Close();
                    if (IsOk && (CardSectorNo != ""))
                    {
                        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "206", CardSectorNo }));
                        if (dr.Read())
                        {
                            txtCardSectorNo.Focus();
                            ShowErrorCannotRepeated(label12.Text);
                            IsOk = false;
                        }
                        if (IsOk & db.CardSectorNoIsExists(SysID, CardSectorNo, ref CardNoDays))
                        {
                            if (CardNoDays == " ")
                                msg = Pub.GetResText(formCode, "MsgCardExistsBlackAgainA", "");
                            else if (DateTime.TryParse(CardNoDays, out d))
                                msg = Pub.GetResText(formCode, "MsgCardExistsUseDaysAgainA", "");
                            else
                                msg = Pub.GetResText(formCode, "MsgCardExistsUseingAgainA", "");
                            msg = string.Format(msg, CardSectorNo, CardNoDays);
                            txtCardSectorNo.Focus();
                            Pub.ShowErrorMsg(msg);
                            IsOk = false;
                        }
                    }
                    dr.Close();
                    if (IsOk && (OtherCardNo != ""))
                    {
                        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "109", OtherCardNo }));
                        if (dr.Read())
                        {
                            txtOtherCardNo.Focus();
                            ShowErrorCannotRepeated(label19.Text);
                            IsOk = false;
                        }
                    }
                    dr.Close();
                    if (IsOk && (CardFingerNo != ""))
                    {
                        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "5", CardFingerNo }));
                        if (dr.Read())
                        {
                            txtCardFingerNo.Focus();
                            ShowErrorCannotRepeated(label15.Text);
                            IsOk = false;
                        }
                    }
                    dr.Close();
                    if (IsOk)
                    {
                        sql.Add(Pub.GetSQL(DBCode.DB_001003, new string[] { "8", SysID, EmpNo, EmpName, EmpSexSysID,
              CardTypeSysID, DepartSysID, EmpHireDate, EmpCertNo, EmpAddress, EmpZipNo, EmpPhoneNo,
              EmpEmail, IsAttend, OtherCardNo, FingerPrivilege }));
                    }
                }
                else
                {
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "4", SysID, EmpNo }));
                    if (dr.Read())
                    {
                        txtEmpNo.Focus();
                        ShowErrorCannotRepeated(label1.Text);
                        IsOk = false;
                    }
                    if (IsOk && (CardSectorNo != "") && txtCardSectorNo.Enabled)
                    {
                        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "6", SysID, CardSectorNo }));
                        if (dr.Read())
                        {
                            txtCardSectorNo.Focus();
                            ShowErrorCannotRepeated(label12.Text);
                            IsOk = false;
                        }
                        if (IsOk && db.CardSectorNoIsExists(SysID, CardSectorNo, ref CardNoDays))
                        {
                            if (CardNoDays == " ")
                                msg = Pub.GetResText(formCode, "MsgCardExistsBlackAgainA", "");
                            else if (DateTime.TryParse(CardNoDays, out d))
                                msg = Pub.GetResText(formCode, "MsgCardExistsUseDaysAgainA", "");
                            else
                                msg = Pub.GetResText(formCode, "MsgCardExistsUseingAgainA", "");
                            msg = string.Format(msg, CardSectorNo, CardNoDays);
                            txtCardSectorNo.Focus();
                            Pub.ShowErrorMsg(msg);
                            IsOk = false;
                        }
                    }
                    dr.Close();
                    if (IsOk && (OtherCardNo != "") && txtOtherCardNo.Enabled)
                    {
                        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "110", SysID, OtherCardNo }));
                        if (dr.Read())
                        {
                            txtOtherCardNo.Focus();
                            ShowErrorCannotRepeated(label19.Text);
                            IsOk = false;
                        }
                    }
                    dr.Close();
                    if (IsOk && (CardFingerNo != "") && txtCardFingerNo.Enabled)
                    {
                        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "7", SysID, CardFingerNo }));
                        if (dr.Read())
                        {
                            txtCardFingerNo.Focus();
                            ShowErrorCannotRepeated(label15.Text);
                            IsOk = false;
                        }
                    }
                    dr.Close();
                    if (IsOk)
                    {
                        sql.Add(Pub.GetSQL(DBCode.DB_001003, new string[] { "9", EmpNo, EmpName, EmpSexSysID, CardTypeSysID,
              DepartSysID, EmpHireDate, EmpCertNo, EmpAddress, EmpZipNo, EmpPhoneNo, EmpEmail, IsAttend,
              OtherCardNo, FingerPrivilege, SysID }));
                    }
                }
                if (IsOk)
                {
                    if (txtEmpNo.Enabled)
                    {
                        sql.Add(Pub.GetSQL(DBCode.DB_001003, new string[] { "232", CardSectorNo, CardPWD, CardStartDate,
              CardEndDate, SysID, CardFingerNo }));
                    }
                    if (db.ExecSQL(sql) != 0) IsOk = false;
                }
                if (IsOk)
                {
                    byte[] buff = new byte[0];
                    if (picPhoto.BackgroundImage != null)
                    {
                        MemoryStream ms = new MemoryStream();
                        picPhoto.BackgroundImage = CustomSizeImage(picPhoto.BackgroundImage);
                        Bitmap t = new Bitmap(picPhoto.BackgroundImage);
                        t.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        buff = ms.ToArray();
                    }
                    db.UpdateByteData(Pub.GetSQL(DBCode.DB_001003, new string[] { "10", SysID }), "EmpPhotoImage", buff);

                    buff = new byte[0];
                    if (picDynPhoto.BackgroundImage != null)
                    {
                        MemoryStream ms = new MemoryStream();
                        picDynPhoto.BackgroundImage = CustomSizePhoto(picDynPhoto.BackgroundImage);
                        Bitmap t = new Bitmap(picDynPhoto.BackgroundImage);
                        t.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        buff = ms.ToArray();
                    }
                    if (dr != null) dr.Close();
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "34", SysID}));
                    if(!dr.Read())
                    {
                        db.ExecSQL(Pub.GetSQL(DBCode.DB_001003, new string[] { "35", SysID }));
                    }
                    db.UpdateByteData(Pub.GetSQL(DBCode.DB_001003, new string[] { "29", SysID }), "EmpPhotoImage", buff);

                    if (txtCardPWD.Enabled) db.UpdateEmpRegisterData(SysID, 10, CardPWD);
                  //  if (txtOtherCardNo.Enabled) db.UpdateEmpRegisterData(SysID, 11, OtherCardNo);
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
            if (IsOk)
            {
                db.WriteSYLog(this.Text, CurrentOprt, sql);
                Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
                IsAddNext = chkIsAdd.Checked;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnIDCard_Click(object sender, EventArgs e)
        {
            string EmpName = "";
            string EmpSex = "";
            string EmpNation = "";
            string EmpAddress = "";
            string EmpIDCard = "";
            string EmpIssued = "";
            string EmpNewAddr = "";
            byte EmpSexNum = 0;
            DateTime EmpBorn = new DateTime();
            DateTime EmpValidStart = new DateTime();
            DateTime EmpValidEnd = new DateTime();
            string EmpPhotoPath = "";
            if (!DeviceObject.objCard.IDCardGet(SystemInfo.AppPath, IDCardDevice, IDCardPort, ref EmpName, ref EmpSex, ref EmpNation, ref EmpAddress,
              ref EmpIDCard, ref EmpIssued, ref EmpNewAddr, ref EmpSexNum, ref EmpBorn, ref EmpValidStart, ref EmpValidEnd, ref EmpPhotoPath)) return;
            txtEmpName.Text = EmpName;
            if (EmpSexNum == 2)
                cbbEmpSex.SelectedIndex = 1;
            else
                cbbEmpSex.SelectedIndex = 0;
            txtEmpCertNo.Text = EmpIDCard;
            txtEmpAddress.Text = EmpAddress;
            if (EmpPhotoPath != "" && File.Exists(EmpPhotoPath))
            {
                Image img = Image.FromFile(EmpPhotoPath);
                picPhoto.BackgroundImage = CustomSizeImage(img);
                try
                {
                    img.Dispose();
                    File.Delete(EmpPhotoPath);
                }
                catch
                {
                }
            }
         
        }

        private void checkBox1_MouseMove(object sender, MouseEventArgs e)
        {
            checkBox1.Text = Pub.GetResText(formCode, "chkDisplayPassword", "");
        }

        private void checkBox1_MouseEnter(object sender, EventArgs e)
        {
            checkBox1.Text = Pub.GetResText(formCode, "chkDisplayPassword", "");
        }

        private void checkBox1_MouseLeave(object sender, EventArgs e)
        {
            checkBox1.Text = "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtCardPWD.PasswordChar = Convert.ToChar(0);
            }

            else
                txtCardPWD.PasswordChar = '*';
        }

        private void frmRSEmpAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.Enter))
            {
                btnOk_Click(null, null);
            }
        }

        private void btnFPReader_Click(object sender, EventArgs e)
        {
            frmRSFpReader fp = new frmRSFpReader(txtEmpNo.Text, txtCardFingerNo.Text);
            fp.ShowDialog();
        }
    }
}