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
    public partial class frmSFMobileInfo : frmBaseDialog
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
            formCode = "SFMobileInfo";
            base.InitForm();
            this.Text = Pub.GetResText(formCode, "mnu" + formCode, "", new string[] { "Main" });
            TMobileInfo info = new TMobileInfo("");
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
            cbbRate1.Items.Clear();
            cbbRate2.Items.Clear();
            for (int i = 0; i < 3; i++)
            {
                string s = Pub.GetResText(formCode, "Rate" + i.ToString(), "");
                cbbRate1.Items.Add(s);
                cbbRate2.Items.Add(s);
            }
            cbbRate1.SelectedIndex = Rate11;
            txtRate1.Text = Rate12.ToString();
            cbbRate2.SelectedIndex = Rate21;
            txtRate2.Text = Rate22.ToString();
            if (info.WeiXin.Length > 0)
            {
                picWX.BackgroundImage = Image.FromStream(info.WeiXin);
            }
            if (info.AliPay.Length > 0)
            {
                picAli.BackgroundImage = Image.FromStream(info.AliPay);
            }
            SetTextboxNumber(txtPort);
            SetTextboxNumber(txtRate1);
            SetTextboxNumber(txtRate2);
        }

        public frmSFMobileInfo()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!db.CheckOprtRole(formCode, "M", true)) return;
            CurrentOprt = btnOk.Text;
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
            DataTableReader dr = null;
            string sql = "";
            bool ret = false;
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004002, new string[] { "100" }));
                if (dr.Read())
                    sql = Pub.GetSQL(DBCode.DB_004002, new string[] { "102", IP, Port.ToString(), KeyID, MercID, TrmNo, PWD,
            Rate11.ToString(), Rate12.ToString(), Rate21.ToString(), Rate22.ToString(), MobTyp.ToString(), XJLName, XJLPWD  });
                else
                    sql = Pub.GetSQL(DBCode.DB_004002, new string[] { "101", IP, Port.ToString(), KeyID, MercID, TrmNo, PWD,
            Rate11.ToString(), Rate12.ToString(), Rate21.ToString(), Rate22.ToString(), MobTyp.ToString(), XJLName, XJLPWD });
                db.ExecSQL(sql);
                byte[] buff = new byte[0];
                if (picWX.BackgroundImage != null)
                {
                    MemoryStream ms = new MemoryStream();
                    picWX.BackgroundImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    buff = ms.ToArray();
                }
                db.UpdateByteData(Pub.GetSQL(DBCode.DB_004002, new string[] { "103" }), "ScanWeiXin", buff);
                buff = new byte[0];
                if (picAli.BackgroundImage != null)
                {
                    MemoryStream ms = new MemoryStream();
                    picAli.BackgroundImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    buff = ms.ToArray();
                }
                db.UpdateByteData(Pub.GetSQL(DBCode.DB_004002, new string[] { "104" }), "ScanAliPay", buff);
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
            if (ret)
            {
                DeviceObject.objCard.MobileClear();
                db.WriteSYLog(this.Text, CurrentOprt, sql);
                Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
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