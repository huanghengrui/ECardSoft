using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmMJMacBJExtAdv : frmBaseDialog
  {
    public string Source = "";

    protected override void InitForm()
    {
      formCode = "MJMacBJExtAdv";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      checkBox1.Checked = Source.Substring(0, 1) == "1";
      radioButton1.Checked = Source.Substring(1, 1) == "0";
      radioButton2.Checked = Source.Substring(1, 1) == "1";
    }

    public frmMJMacBJExtAdv(string title, string CurrentTool, string source)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      Source = source;
      InitializeComponent();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      Source = string.Format("{0}{1}", Convert.ToByte(checkBox1.Checked), Convert.ToByte(radioButton2.Checked));
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
  }
}