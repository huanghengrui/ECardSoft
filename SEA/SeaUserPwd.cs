using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSeaUserPwd : frmBaseDialog
    {

        protected override void InitForm()
        {
            formCode = "SeaUserPwd";
            base.InitForm();
            this.Text = Pub.GetResText(formCode, "mnu" + formCode, "");
            txtMacSeriesUserName.Text = "admin";
        }
        public frmSeaUserPwd()
        {
            InitializeComponent();
        }
   
        private void btnOk_Click(object sender, EventArgs e)
        {
            if(txtMacSeriesUserName.Text == "")
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText("", "ErrorEnterCorrect", ""), lbUserName.Text),MessageBoxIcon.Error);
                txtMacSeriesUserName.Focus();
                return;
            }

            if(txtPwd1.Text=="")
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText("", "ErrorEnterCorrect", ""), label1.Text), MessageBoxIcon.Error);
                txtPwd1.Focus();
                return;
            }
            if (txtPwd2.Text == "")
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText("", "ErrorEnterCorrect", ""), label2.Text), MessageBoxIcon.Error);
                txtPwd2.Focus();
                return;
            }
            if (txtPwd2.Text != txtPwd1.Text)
            {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "Error001", ""), MessageBoxIcon.Error);
                txtPwd2.Focus();
                return;
            }

            frmSeaOprt frm = new frmSeaOprt(this.Text, Pub.GetResText(formCode, "SetPwd", ""), txtMacSeriesUserName.Text+":"+txtPwd2.Text,4,null);
            frm.ShowDialog();
        }
    }
}
