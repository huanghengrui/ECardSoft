using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmSYRegisterDate : frmBaseDialog
  {
    public string UserName = "";
    public bool IsAlways = true;
    public DateTime SelectDate = new DateTime();

    protected override void InitForm()
    {
      formCode = "SYRegisterDate";
      base.InitForm();
      this.Text = Title;
      dtpDate.Value = DateTime.Now.Date;
    }

    public frmSYRegisterDate(string title)
    {
      Title = title;
      InitializeComponent();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      UserName = txtUser.Text.Trim();
      if (UserName == "")
      {
        Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", "", new string[] { "SYRegister" }));
        txtUser.Focus();
        return;
      }
      IsAlways = chkDate.Checked;
      SelectDate = dtpDate.Value.Date;
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void chkDate_CheckedChanged(object sender, EventArgs e)
    {
      dtpDate.Enabled = !chkDate.Checked;
    }
  }
}