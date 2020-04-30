using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ECard78
{
  public partial class frmDBRestPWD : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "DBRestPWD";
      base.InitForm();
      this.Text = Title;
    }

    public frmDBRestPWD(string title)
    {
      Title = title;
      InitializeComponent();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      
      if (txtPWD.Text.Trim() != "hysoon1234")
      {
        txtPWD.Focus();
        Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", ""));
        return;
      }
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
  }
}