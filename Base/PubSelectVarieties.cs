using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmPubSelectVarieties : frmBaseDialog
    {
        public string ProductsID = "";
        public string ProductsName = "";
        private string CategoryID = "";
        protected override void InitForm()
        {
            formCode = "PubSelectCategory";
            base.InitForm();

            ProductsID = "";
            ProductsName = "";
            this.Text = Pub.GetResText(formCode, "ProductInfo", "");
            InitVarietiesTreeView(tvAddress, CategoryID);
        }

        public frmPubSelectVarieties(string categoryID)
        {
            if (categoryID != "")
                CategoryID = categoryID;
            else
                CategoryID = "01";
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (tvAddress.SelectedNode == null || tvAddress.SelectedNode.Level==0)
            {
                Pub.ShowErrorMsg(string.Format(Pub.GetResText(formCode, "ErrorSelectCorrect", ""),this.Text));
                return;
            }
            ProductsID = tvAddress.SelectedNode.Tag.ToString();
            string[] tmp = tvAddress.SelectedNode.Text.ToString().Split('[');
            tmp = tmp[1].Split(']');
            ProductsName = tmp[1];
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void tvDepart_DoubleClick(object sender, EventArgs e)
        {
            btnOk.PerformClick();
        }
    }
}