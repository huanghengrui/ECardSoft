using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmDelAccount : frmBaseDialog
  {
    public string AccName = "";
    public string DBName = "";

    protected override void InitForm()
    {
      formCode = "DelAccount";
      base.InitForm();
      this.txtAccName.Text = AccName;
      this.txtDBName.Text = DBName;
    }

    public frmDelAccount()
    {
      InitializeComponent();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
     
      string msg = "";
      bool IsOk = false;
      if (rbInfo.Checked)
        msg = Pub.GetResText(formCode, "Msg001", "");
      else
        msg = Pub.GetResText(formCode, "Msg003", "");
      if (Pub.MessageBoxShowQuestion(msg)) return;
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        if (rbInfo.Checked)
          IsOk = true;
        else
        {
          Pub.ShowMessageForm(string.Format(Pub.GetResText(formCode, "Msg004", ""), DBName));
          IsOk = db.DeleteDatabase(DBName, false);
        }
        if (IsOk) db.ExecSQL(Pub.GetSQL(DBCode.DB_000001, new string[] { "107", AccName }));
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E);
      }
      finally
      {
        Pub.FreeMessageForm();
      }
      if (IsOk)
      {
        Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "Msg002", ""), AccName), MessageBoxIcon.Information);
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }
  }
}