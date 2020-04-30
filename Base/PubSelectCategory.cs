using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmPubSelectCategory : frmBaseDialog
    {
        public string CategoryID = "";
        public string CategoryName = "";

        protected override void InitForm()
        {
            formCode = "PubSelectCategory";
            base.InitForm();

            CategoryID = "";
            CategoryName = "";
            // InitAddressTreeView(tvAddress);
            this.Text = Pub.GetResText(formCode, "Category", "");
            InitCategoryTreeView(tvAddress);
        }

        public frmPubSelectCategory()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (tvAddress.SelectedNode == null || tvAddress.SelectedNode.Level == 0)
            {
                Pub.ShowErrorMsg(string.Format(Pub.GetResText(formCode, "ErrorSelectCorrect", ""), this.Text));
                return;
            }
            CategoryID = tvAddress.SelectedNode.Tag.ToString();
            string[] tmp = tvAddress.SelectedNode.Text.ToString().Split('[');
            tmp = tmp[1].Split(']');
            CategoryName = tmp[1];
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void tvDepart_DoubleClick(object sender, EventArgs e)
        {
            btnOk.PerformClick();
        }
    }
}