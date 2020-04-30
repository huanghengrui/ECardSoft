using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmDBBack : frmBaseDialog
    {
        public string AccName = "";
        public string DBName = "";

        protected override void InitForm()
        {
            formCode = "DBBack";
            base.InitForm();
            this.txtAccName.Text = AccName;
            this.txtDBName.Text = DBName;
            this.txtBak.Text = "ECard" + DateTime.Now.ToString(SystemInfo.DateTimeFormatLog);
            txtPath.Text = db.GetDatabasePath().ToString();
        }

        public frmDBBack()
        {
            InitializeComponent();
        }

        private void btnDBPath_Click(object sender, EventArgs e)
        {
            string DBPath = txtPath.Text;
            DBPath = Pub.SelectDBPath(true, DBPath);
            if (DBPath != "") txtPath.Text = DBPath;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            formCode = "DBBack";
            string FileName = txtBak.Text.Trim();
            string DBPath = txtPath.Text;
            string msg = string.Format(Pub.GetResText(formCode, "Msg001", ""), AccName);
            bool IsOk = false;
            string[] s = FileName.Split('.');

            if (FileName == "")
            {
                txtBak.Focus();
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorDBFileEmpty", ""));
                return;
            }
            if (DBPath == "")
            {
                btnDBPath.Focus();
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorDBPathEmpty", ""));
                return;
            }
            if (s.Length == 1)
                FileName = FileName + ".bak";
            else if (s[s.Length - 1].Trim() == "")
            {
                FileName = "";
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i].Trim() != "") FileName = FileName + s[i].Trim() + ".";
                }
                FileName = FileName.Substring(0, FileName.Length - 1);
            }
            s = FileName.Split('.');
            if (s.Length == 1) FileName = FileName + ".bak";
            FileName = DBPath + FileName;
            Pub.ShowMessageForm(msg);
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                IsOk = db.BackupDatabase(DBName, FileName);
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                Pub.FreeMessageForm();
            }
            if (IsOk)
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "Msg002", ""), AccName, "\r\n" + FileName), MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            formCode = "DBBack";
        }
    }
}