using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmDBRest : frmBaseDialog
    {
        public string AccName = "";
        public string DBName = "";

        protected override void InitForm()
        {
            formCode = "DBRest";
            base.InitForm();
            this.txtAccName.Text = AccName;
            this.txtDBName.Text = DBName;
        }

        public frmDBRest()
        {
            InitializeComponent();
        }

        private void btnDBName_Click(object sender, EventArgs e)
        {
            string BakFile = txtBak.Text;
            if (BakFile == "") BakFile = db.GetDatabasePath().ToString() + "ECard.bak";
            BakFile = Pub.SelectDBPath(false, BakFile);
            if (BakFile != "") txtBak.Text = BakFile;
           
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string FileName = txtBak.Text;
            string msg = string.Format(Pub.GetResText(formCode, "Msg001", ""), AccName);
            bool IsOk = false;

            if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "Msg000", ""))) return;
            if (FileName == "")
            {
                btnDBName.Focus();
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorDBFileEmpty", ""));
                return;
            }
            Pub.ShowMessageForm(msg);
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                IsOk = db.RestoreDatabase(DBName, FileName);
                if (IsOk)
                {
                    IsOk = true;
                    string fn = FileName.Substring(FileName.LastIndexOf("\\") + 1).ToLower();
                    Database dbEx = new Database(GetConnStr(DBName));
                    try
                    {
                        dbEx.Open();
                    }
                    catch (Exception E)
                    {
                        IsOk = false;
                        Pub.ShowErrorMsg(E);
                    }
                    finally
                    {
                        dbEx.Close();
                        dbEx = null;
                    }
                    db.ExecSQL(Pub.GetSQL(DBCode.DB_000001, new string[] { "108", DBName }));
                }
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
                Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "Msg002", ""), AccName), MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}