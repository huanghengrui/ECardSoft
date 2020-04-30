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
    public partial class frmSFPrintTitle : frmBaseDialog
    {
        protected override void InitForm()
        {
            formCode = "SFPrintTitle";
            base.InitForm();
            this.Text = Pub.GetResText(formCode, "mnu" + formCode, "", new string[] { "Main" });
            TPrintTitleInfo info = new TPrintTitleInfo("");
            TextBox txt;
            ComboBox cbb;
            for (int i = 0; i < 5; i++)
            {
                txt = ((TextBox)gbxTitle.Controls["txtTitle" + i.ToString()]);
                if (txt != null) txt.Text = info.Title[i];
                cbb = ((ComboBox)gbxTitle.Controls["cbbOption" + i.ToString()]);
                if (cbb == null) continue;
                cbb.Items.Clear();
                for (int j = 0; j < 5; j++)
                {
                    cbb.Items.Add(Pub.GetResText(formCode, "PrintOption" + j.ToString(), ""));
                }
                if (cbb.Items.Count > 0) cbb.SelectedIndex = info.Zoom[i];
            }
            if (info.Logo.Length > 0)
            {
                picLogo.BackgroundImage = Image.FromStream(info.Logo);
            }
            txtLine.Text = info.Line.ToString();
            SetTextboxNumber(txtLine);
        }

        public frmSFPrintTitle()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!db.CheckOprtRole(formCode, "M", true)) return;
            CurrentOprt = btnOk.Text;
            string T0 = txtTitle0.Text;
            string T1 = txtTitle1.Text;
            string T2 = txtTitle2.Text;
            string T3 = txtTitle3.Text;
            string T4 = txtTitle4.Text;
            int I0 = cbbOption0.SelectedIndex;
            int I1 = cbbOption1.SelectedIndex;
            int I2 = cbbOption2.SelectedIndex;
            int I3 = cbbOption3.SelectedIndex;
            int I4 = cbbOption4.SelectedIndex;
            if (!Pub.CheckTextMaxLength(label1.Text, T0, txtTitle0.MaxLength)) return;
            if (!Pub.CheckTextMaxLength(label2.Text, T1, txtTitle1.MaxLength)) return;
            if (!Pub.CheckTextMaxLength(label3.Text, T2, txtTitle2.MaxLength)) return;
            if (!Pub.CheckTextMaxLength(label4.Text, T3, txtTitle3.MaxLength)) return;
            if (!Pub.CheckTextMaxLength(label5.Text, T4, txtTitle4.MaxLength)) return;
            int PrintLine = 0;
            int.TryParse(txtLine.Text.Trim(), out PrintLine);
            if ((PrintLine < 0) || (PrintLine > 255))
            {
                string msg = string.Format(Pub.GetResText(formCode, "Error001", ""), 0, 255);
                Pub.ShowErrorMsg(msg);
                return;
            }
            DataTableReader dr = null;
            string sql = "";
            bool ret = false;
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004002, new string[] { "0" }));
                if (dr.Read())
                    sql = Pub.GetSQL(DBCode.DB_004002, new string[] { "2", T0, T1, T2, T3, T4, I0.ToString(), I1.ToString(),
            I2.ToString(), I3.ToString(), I4.ToString(), PrintLine.ToString() });
                else
                    sql = Pub.GetSQL(DBCode.DB_004002, new string[] { "1", T0, T1, T2, T3, T4, I0.ToString(), I1.ToString(),
            I2.ToString(), I3.ToString(), I4.ToString(), PrintLine.ToString() });
                db.ExecSQL(sql);
                byte[] buff = new byte[0];
                if (picLogo.BackgroundImage != null)
                {
                    MemoryStream ms = new MemoryStream();
                    picLogo.BackgroundImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    buff = ms.ToArray();
                }
                db.UpdateByteData(Pub.GetSQL(DBCode.DB_004002, new string[] { "3" }), "PrintLogo", buff);
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
                db.WriteSYLog(this.Text, CurrentOprt, sql);
                Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dlgOpen.ShowDialog() != DialogResult.OK) return;
            picLogo.BackgroundImage = Image.FromStream(PrintLogoCustomSizeImage(dlgOpen.FileName));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            picLogo.BackgroundImage = null;
        }
    }
}