using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmInputBox : frmBaseDialog
  {
    private string Prompt = "";
    private string DefText = "";
    public string ResultText = "";
    public int ResultNumber = 0;
    public bool EnterNumber = false;
    public int MaxNumber = 0;
    public bool IsPass = false;

    protected override void InitForm()
    {
      formCode = "InputBox";
      base.InitForm();
      this.Text = Title;
      this.label1.Text = Prompt;
      this.textBox1.Text = DefText;
      if (EnterNumber)
      {
        SetTextboxNumber(textBox1);
        textBox1.MaxLength = 9;
      }
      if (IsPass) textBox1.PasswordChar = '*';
    }

    public frmInputBox(string title, string prompt, string defText)
    {
      Title = title;
      Prompt = prompt;
      DefText = defText;
      InitializeComponent();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (EnterNumber)
      {
        if (!Pub.IsNumeric(textBox1.Text.Trim()))
        {
          textBox1.Focus();
          ShowErrorEnterCorrect(this.Text);
          return;
        }
        int i = Convert.ToInt32(textBox1.Text.Trim());
        if ((MaxNumber > 0) && (i > MaxNumber))
        {
          textBox1.Focus();
          ShowErrorEnterCorrect(label1.Text);
          return;
        }
        ResultNumber = i;
      }
      else
        ResultText = textBox1.Text;
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
  }
}