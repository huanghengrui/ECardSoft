using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmPubFindMacEdit : frmBaseDialog
  {
    public string IP = "";
    public string NetMask = "";
    public string Gateway = "";
    public int Port = 0;

    protected override void InitForm()
    {
      formCode = "PubFindMacEdit";
      base.InitForm();
      SetTextboxNumber(txtPort);
      txtIP.Text = IP;
      txtNetMask.Text = NetMask;
      txtGateway.Text = Gateway;
      txtPort.Text = Port.ToString();
    }

    public frmPubFindMacEdit()
    {
      InitializeComponent();
    }

    private bool CheckIP(string Label, string Text)
    {
      bool ret = false;
      string[] tmp = Text.Split('.');
      if (tmp.Length == 4)
      {
        ret = (Pub.IsNumeric(tmp[0])) && (Convert.ToInt16(tmp[0]) >= 0) && (Convert.ToInt16(tmp[0]) <= 255);
        ret = ret && (Pub.IsNumeric(tmp[1])) && (Convert.ToInt16(tmp[1]) >= 0) && (Convert.ToInt16(tmp[1]) <= 255);
        ret = ret && (Pub.IsNumeric(tmp[2])) && (Convert.ToInt16(tmp[2]) >= 0) && (Convert.ToInt16(tmp[2]) <= 255);
        ret = ret && (Pub.IsNumeric(tmp[3])) && (Convert.ToInt16(tmp[3]) >= 0) && (Convert.ToInt16(tmp[3]) <= 255);
      }
      if (!ret) ShowErrorEnterCorrect(Label);
      return ret;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (!CheckIP(label1.Text, txtIP.Text.Trim())) return;
      if (!CheckIP(label2.Text, txtNetMask.Text.Trim())) return;
      if (!CheckIP(label3.Text, txtGateway.Text.Trim())) return;
      if (!Pub.IsNumeric(txtPort.Text.Trim()))
      {
        ShowErrorEnterCorrect(label4.Text);
        return;
      }
      IP = txtIP.Text.Trim();
      NetMask = txtNetMask.Text.Trim();
      Gateway = txtGateway.Text.Trim();
      Port = Convert.ToInt32(txtPort.Text.Trim());
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
  }
}