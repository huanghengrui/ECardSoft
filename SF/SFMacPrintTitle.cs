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
    public partial class frmSFMacPrintTitle : frmBaseDialog
    {
        protected override void InitForm()
        {
            formCode = "SFMacPrintTitle";
            base.InitForm();
            this.Text = Title + "[" + CurrentOprt + "]";
            SetTextboxNumber(txtLine);
            LoadData();
        }

        public frmSFMacPrintTitle(string title, string CurrentTool, string GUID)
        {
            Title = title;
            CurrentOprt = CurrentTool;
            SysID = GUID;
            InitializeComponent();
        }

        private void LoadData()
        {
            DataTableReader dr = null;
            string printStr = "";
            MemoryStream logo = new MemoryStream();
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004004, new string[] { "7", SysID }));
                if (dr.Read())
                {
                    printStr = dr["PrintTitle"].ToString();
                    if (dr["PrintLogo"].ToString() != "")
                    {
                        byte[] buff = (byte[])(dr["PrintLogo"]);
                        if (buff.Length > 0) logo = new MemoryStream(buff);
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
            TPrintTitleInfo info = new TPrintTitleInfo(printStr);
            int i;
            Label lbl;
            gbxTitle.Text = Pub.GetResText("SFPrintTitle", gbxTitle.Name, "");
            for (i = 1; i <= 6; i++)
            {
                lbl = ((Label)gbxTitle.Controls["label" + i.ToString()]);
                if (lbl != null)
                {
                    lbl.Text = Pub.GetResText("SFPrintTitle", lbl.Name, "");
                    toolTip.SetToolTip(lbl, lbl.Text);
                }
            }
            gbxLogo.Text = Pub.GetResText("SFPrintTitle", gbxLogo.Name, "");
            button1.Text = Pub.GetResText("SFPrintTitle", button1.Name, "");
            button2.Text = Pub.GetResText("SFPrintTitle", button2.Name, "");
            label6.Text = Pub.GetResText("SFPrintTitle", label6.Name, "");
            TextBox txt;
            ComboBox cbb;
            for (i = 0; i < 5; i++)
            {
                txt = ((TextBox)gbxTitle.Controls["txtTitle" + i.ToString()]);
                if (txt != null) txt.Text = info.Title[i];
                cbb = ((ComboBox)gbxTitle.Controls["cbbOption" + i.ToString()]);
                if (cbb == null) continue;
                cbb.Items.Clear();
                for (int j = 0; j < 5; j++)
                {
                    cbb.Items.Add(Pub.GetResText("SFPrintTitle", "PrintOption" + j.ToString(), ""));
                }
                if (cbb.Items.Count > 0) cbb.SelectedIndex = info.Zoom[i];
            }
            if (logo.Length > 0)
            {
                picLogo.BackgroundImage = Image.FromStream(logo);
            }
            else if (info.Logo.Length > 0)
            {
                picLogo.BackgroundImage = Image.FromStream(info.Logo);
            }
            txtLine.Text = info.Line.ToString();
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
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
            string printStr = T0 + "@" + T1 + "@" + T2 + "@" + T3 + "@" + T4 + "@" + I0.ToString() + "@" + I1.ToString() +
              "@" + I2.ToString() + "@" + I3.ToString() + "@" + I4.ToString() + "@" + PrintLine.ToString();
            string sql = Pub.GetSQL(DBCode.DB_004004, new string[] { "120", printStr, SysID });
            try
            {
                db.ExecSQL(sql);
                byte[] buff = new byte[0];
                if (picLogo.BackgroundImage != null)
                {
                    MemoryStream ms = new MemoryStream();
                    picLogo.BackgroundImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    buff = ms.ToArray();
                }
                db.UpdateByteData(Pub.GetSQL(DBCode.DB_004004, new string[] { "122", SysID }), "PrintLogo", buff);
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
            picLogo.BackgroundImage = Image.FromStream(PrintLogoCustomSizeImage(dlgOpen.FileName));
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            picLogo.BackgroundImage = null;
        }
    }
}