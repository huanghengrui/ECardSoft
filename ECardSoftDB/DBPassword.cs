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
  public partial class frmDBPassword : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "DBPassword";
      base.InitForm();
    }

    public frmDBPassword()
    {
      InitializeComponent();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      string OldPass = txtOld.Text.Trim();
      string NewPass = txtNew.Text.Trim();
      string VerifyPass = txtVerify.Text.Trim();

      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        DataTableReader dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { }));
        dr.Read();
        if (OldPass != dr["Password"].ToString().Trim())
        {
          txtOld.Focus();
          Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorOldPassword", ""));
          return;
        }
        dr.Close();
        if (NewPass != VerifyPass)
        {
          txtNew.Focus();
          Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorPasswordTwo", ""));
          return;
        }
        db.ExecSQL(Pub.GetSQL(DBCode.DB_000001, new string[] { "104", NewPass }));
        Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgPasswordSuccess", ""), MessageBoxIcon.Information);
        this.Close();
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E);
      }
    }
  }
}