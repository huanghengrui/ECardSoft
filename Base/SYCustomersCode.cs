using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmSYCustomersCode : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "SYCustomersCode";
      base.InitForm();
      txtCode.Text = SystemInfo.CustomersCode.ToString("000000");
      SetTextboxNumber(txtCode);
    }

    public frmSYCustomersCode()
    {
      InitializeComponent();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      const int MinCode = 1;
      const int MaxCode = 999999;
      if (!Pub.IsNumeric(txtCode.Text.Trim()))
      {
        Pub.ShowErrorMsg(string.Format(Pub.GetResText(formCode, "ErrorCode", ""), MinCode, MaxCode));
        return;
      }
      int Code = 0;
      int.TryParse(txtCode.Text.Trim(), out Code);
      if (Code < MinCode || Code > MaxCode)
      {
        Pub.ShowErrorMsg(string.Format(Pub.GetResText(formCode, "ErrorCode", ""), MinCode, MaxCode));
        return;
      }
      SystemInfo.CustomersCode = Code;
      if (!db.WriteConfig("RS_System", "CustomersCode", SystemInfo.CustomersCode)) return;
      string msg = Pub.GetResText(formCode, "MsgSuccess", "");
      db.WriteSYLog(this.Text, btnOk.Text, msg);
      Pub.MessageBoxShow(msg, MessageBoxIcon.Information);
      this.Close();
    }
  }
}