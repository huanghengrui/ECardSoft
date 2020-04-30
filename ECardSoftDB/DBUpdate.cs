using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmDBUpdate : frmBaseDialog
    {
        public string AccName = "";
        public string DBName = "";

        private bool UpdateIsOk = false;

        protected override void InitForm()
        {
            formCode = "DBUpdate";
            base.InitForm();
            this.txtAccName.Text = AccName;
            this.txtDBName.Text = DBName;
            UpdateIsOk = false;
        }

        public frmDBUpdate()
        {
            InitializeComponent();
        }

        private void btnDBName_Click(object sender, EventArgs e)
        {
            ofd.Filter = Pub.GetResText(formCode, "Msg001", "") + "|*.sql";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtBak.Text = ofd.FileName;
            }
         
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
          
            string FileName = txtBak.Text;
            string msg = string.Format(Pub.GetResText(formCode, "Msg002", ""), AccName);
            bool IsOk = false;
            if (FileName == "")
            {
                btnDBName.Focus();
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", ""));
                return;
            }
            Pub.ShowMessageForm(msg);
            try
            {
                if (!db.IsOpen) db.Open(GetConnStr(DBName));
                IsOk = db.UpdateScript(FileName);
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
                UpdateIsOk = true;
                Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "Msg003", ""), AccName), MessageBoxIcon.Information);
            }
         
        }

        private void frmDBUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (UpdateIsOk) this.DialogResult = DialogResult.OK;
        }
    }
}