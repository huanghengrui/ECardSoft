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
    public partial class frmSFMacMobileInfo : frmBaseDialog
    {
        private string IP = "";
        private int Port = 0;
        private string KeyID = "";
        private string MercID = "";
        private string TrmNo = "";
        private string PWD = "";
        private byte Rate11 = 0;
        private int Rate12 = 0;
        private byte Rate21 = 0;
        private int Rate22 = 0;
        private byte MobTyp = 0;
        private string XJLName = "";
        private string XJLPWD = "";

        protected override void InitForm()
        {
            formCode = "SFMacMobileInfo";
            base.InitForm();
            this.Text = Title + "[" + CurrentOprt + "]";
            SetTextboxNumber(txtPort);
            SetTextboxNumber(txtRate1);
            SetTextboxNumber(txtRate2);
            cbbRate1.Items.Clear();
            cbbRate2.Items.Clear();
            for (int i = 0; i < 3; i++)
            {
                string s = Pub.GetResText("SFMobileInfo", "Rate" + i.ToString(), "");
                cbbRate1.Items.Add(s);
                cbbRate2.Items.Add(s);
            }
            Label lbl;
            rbType1.Text = Pub.GetResText("SFMobileInfo", rbType1.Name, "");
            rbType2.Text = Pub.GetResText("SFMobileInfo", rbType2.Name, "");
            gbxRate.Text = Pub.GetResText("SFMobileInfo", gbxRate.Name, "");
            gbxWX.Text = Pub.GetResText("SFMobileInfo", gbxWX.Name, "");
            gbxAli.Text = Pub.GetResText("SFMobileInfo", gbxAli.Name, "");
            button1.Text = Pub.GetResText("SFMobileInfo", button1.Name, "");
            button2.Text = Pub.GetResText("SFMobileInfo", button2.Name, "");
            button3.Text = Pub.GetResText("SFMobileInfo", button3.Name, "");
            button4.Text = Pub.GetResText("SFMobileInfo", button4.Name, "");
            for (int i = 0; i < gbxType1.Controls.Count; i++)
            {
                if (gbxType1.Controls[i] is Label)
                {
                    lbl = (Label)gbxType1.Controls[i];
                    lbl.Text = Pub.GetResText("SFMobileInfo", lbl.Name, "");
                    toolTip.SetToolTip(lbl, lbl.Text);
                }
            }
            for (int i = 0; i < gbxType2.Controls.Count; i++)
            {
                if (gbxType2.Controls[i] is Label)
                {
                    lbl = (Label)gbxType2.Controls[i];
                    lbl.Text = Pub.GetResText("SFMobileInfo", lbl.Name, "");
                    toolTip.SetToolTip(lbl, lbl.Text);
                }
            }
            for (int i = 0; i < gbxRate.Controls.Count; i++)
            {
                if (gbxRate.Controls[i] is Label)
                {
                    lbl = (Label)gbxRate.Controls[i];
                    lbl.Text = Pub.GetResText("SFMobileInfo", lbl.Name, "");
                    toolTip.SetToolTip(lbl, lbl.Text);
                }
            }
            lblRate11.Text = Pub.GetResText("SFMobileInfo", "Rate", "");
            toolTip.SetToolTip(lblRate11, lblRate11.Text);
            lblRate21.Text = Pub.GetResText("SFMobileInfo", "Rate", "");
            toolTip.SetToolTip(lblRate21, lblRate21.Text);
            LoadData();
        }

        public frmSFMacMobileInfo(string title, string CurrentTool, string GUID)
        {
            Title = title;
            CurrentOprt = CurrentTool;
            SysID = GUID;
            InitializeComponent();
        }

        private void LoadData()
        {
            DataTableReader dr = null;
            string mobileStr = "";
            MemoryStream weixin = new MemoryStream();
            MemoryStream alipay = new MemoryStream();
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004004, new string[] { "7", SysID }));
                if (dr.Read())
                {
                    mobileStr = dr["MobileInfo"].ToString();
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
            TMobileInfo info = new TMobileInfo(mobileStr);
            IP = info.IP;
            Port = info.Port;
            KeyID = info.KeyID;
            MercID = info.MercID;
            TrmNo = info.TrmNo;
            PWD = info.PWD;
            Rate11 = info.Rate11;
            Rate12 = info.Rate12;
            Rate21 = info.Rate21;
            Rate22 = info.Rate22;
            MobTyp = info.MobTyp;
            XJLName = info.XJLName;
            XJLPWD = info.XJLPWD;
            rbType1.Checked = MobTyp == 0;
            txtIP.Text = IP;
            txtPort.Text = Port.ToString();
            txtMercID.Text = MercID;
            txtTrmNo.Text = TrmNo;
            txtPWD.Text = PWD;
            rbType2.Checked = !rbType1.Checked;
            txtXJLName.Text = XJLName;
            txtXJLPWD.Text = XJLPWD;
            cbbRate1.SelectedIndex = Rate11;
            txtRate1.Text = Rate12.ToString();
            cbbRate2.SelectedIndex = Rate21;
            txtRate2.Text = Rate22.ToString();
            if (weixin.Length > 0)
            {
                picWX.BackgroundImage = Image.FromStream(weixin);
            }
            else if (info.WeiXin.Length > 0)
            {
                picWX.BackgroundImage = Image.FromStream(info.WeiXin);
            }
            if (alipay.Length > 0)
            {
                picAli.BackgroundImage = Image.FromStream(alipay);
            }
            else if (info.AliPay.Length > 0)
            {
                picAli.BackgroundImage = Image.FromStream(info.AliPay);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            IP = txtIP.Text.Trim();
            int.TryParse(txtPort.Text.Trim(), out Port);
            MercID = Pub.GetOprtEncrypt(txtMercID.Text.Trim());
            TrmNo = Pub.GetOprtEncrypt(txtTrmNo.Text.Trim());
            PWD = Pub.GetOprtEncrypt(txtPWD.Text.Trim());
            MobTyp = 0;
            if (rbType2.Checked) MobTyp = 1;
            XJLName = Pub.GetOprtEncrypt(txtXJLName.Text.Trim());
            XJLPWD = Pub.GetOprtEncrypt(txtXJLPWD.Text.Trim());
            Rate11 = (byte)cbbRate1.SelectedIndex;
            int.TryParse(txtRate1.Text.Trim(), out Rate12);
            Rate21 = (byte)cbbRate2.SelectedIndex;
            int.TryParse(txtRate2.Text.Trim(), out Rate22);
            if (Rate12 <= 0) Rate12 = 0;
            if (Rate22 <= 0) Rate22 = 0;
            string mobileStr = IP + "@" + Port.ToString() + "@" + KeyID + "@" + MercID + "@" + TrmNo + "@" + PWD + "@" +
              Rate11.ToString() + "@" + Rate12.ToString() + "@" + Rate21.ToString() + "@" + Rate22.ToString() + "@" +
              MobTyp.ToString() + "@" + XJLName + "@" + XJLPWD;
            string sql = Pub.GetSQL(DBCode.DB_004004, new string[] { "121", mobileStr, SysID });
            try
            {
                db.ExecSQL(sql);
                sql = "";
                byte[] buff = new byte[0];
                if (picWX.BackgroundImage != null)
                {
                    MemoryStream ms = new MemoryStream();
                    picWX.BackgroundImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    buff = ms.ToArray();
                }
                db.UpdateByteData(Pub.GetSQL(DBCode.DB_004004, new string[] { "123", SysID }), "ScanWeiXin", buff);
                buff = new byte[0];
                if (picAli.BackgroundImage != null)
                {
                    MemoryStream ms = new MemoryStream();
                    picAli.BackgroundImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    buff = ms.ToArray();
                }
                db.UpdateByteData(Pub.GetSQL(DBCode.DB_004004, new string[] { "124", SysID }), "ScanAliPay", buff);
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E, sql);
                return;
            }
            db.WriteSYLog(this.Text, CurrentOprt, sql);
            Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dlgOpen.ShowDialog() != DialogResult.OK) return;
            picWX.BackgroundImage = ScanCustomSizeImage(Image.FromFile(dlgOpen.FileName));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            picWX.BackgroundImage = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dlgOpen.ShowDialog() != DialogResult.OK) return;
            picAli.BackgroundImage = ScanCustomSizeImage(Image.FromFile(dlgOpen.FileName));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            picAli.BackgroundImage = null;
        }
    }
}