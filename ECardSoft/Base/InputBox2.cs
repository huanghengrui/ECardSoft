using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmInputBox2 : frmBaseDialog
  {
    private string Prompt1 = "";
    private string Prompt2 = "";
    private string DefText1 = "";
    private string DefText2 = "";
    public string ResultText1 = "";
    public string ResultText2 = "";
    public int ResultNumber1 = 0;
    public int ResultNumber2 = 0;
    public bool EnterNumber = false;
    public int MaxNumber1 = 0;
    public int MaxNumber2 = 0;

    protected override void InitForm()
    {
      formCode = "InputBox";
      base.InitForm();
      this.Text = Title;
      this.label1.Text = Prompt1;
      this.textBox1.Text = DefText1;
      this.label2.Text = Prompt2;
      this.textBox2.Text = DefText2;
      if (EnterNumber)
      {
        SetTextboxNumber(textBox1);
        textBox1.MaxLength = 9;
        SetTextboxNumber(textBox2);
        textBox2.MaxLength = 9;
      }
    }

    public frmInputBox2(string title, string prompt1, string defText1, string prompt2, string defText2)
    {
      Title = title;
      Prompt1 = prompt1;
      DefText1 = defText1;
      Prompt2 = prompt2;
      DefText2 = defText2;
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
        if ((MaxNumber1 > 0) && (i > MaxNumber1))
        {
          textBox1.Focus();
          ShowErrorEnterCorrect(label1.Text);
          return;
        }
        ResultNumber1 = i;
        if (!Pub.IsNumeric(textBox2.Text.Trim()))
        {
          textBox2.Focus();
          ShowErrorEnterCorrect(this.Text);
          return;
        }
        i = Convert.ToInt32(textBox2.Text.Trim());
        if ((MaxNumber2 > 0) && (i > MaxNumber2))
        {
          textBox2.Focus();
          ShowErrorEnterCorrect(label2.Text);
          return;
        }
        ResultNumber2 = i;
      }
      else
      {
        ResultText1 = textBox1.Text;
        ResultText2 = textBox2.Text;
      }
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
  }
}