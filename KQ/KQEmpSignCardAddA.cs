using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmKQEmpSignCardAddA : frmBaseDialog
  {
    public DateTime CardDate = new DateTime();
    public DateTime CardTime = new DateTime();
    public int CardDays = 0;

    protected override void InitForm()
    {
      formCode = "KQEmpSignCardAddA";
      base.InitForm();
      this.Text = this.Text + "[" + CurrentOprt + "]";
      dtpDate.Value = DateTime.Now.Date.AddDays(-1);
      dtpTime.Value = DateTime.Now;
    }

    public frmKQEmpSignCardAddA(string CurrentTool)
    {
      CurrentOprt = CurrentTool;
      InitializeComponent();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (!Pub.IsNumeric(txtDays.Text.Trim()))
      {
        txtDays.Focus();
        ShowErrorEnterCorrect(label3.Text);
        return;
      }
      CardDate = dtpDate.Value.Date;
      CardTime = dtpTime.Value;
      CardDays = Convert.ToInt32(txtDays.Text.Trim());
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
  }
}