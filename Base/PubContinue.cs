using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace ECard78
{
    public partial class frmPubContinue : frmBaseDialog
    {
        public bool IsAllContinue = false;
        public bool IsNotAllContinue = false;
        public string lbText = "";
        protected override void InitForm()
        {
            formCode = "PubContinue";
            base.InitForm();
            this.Text = Title;
            label1.Text = lbText;
        }

        public frmPubContinue(string title, string text)
        {
            Title = title;
            lbText = text;
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            IsAllContinue = false;
            IsNotAllContinue = false;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnNotAllContinue_Click(object sender, EventArgs e)
        {
            IsAllContinue = false;
            IsNotAllContinue = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAllContinue_Click(object sender, EventArgs e)
        {
            IsAllContinue = true;
            IsNotAllContinue = false;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}