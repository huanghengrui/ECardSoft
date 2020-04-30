using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmSYPassword : frmBaseDialog
  {
    private string oprtNo = "";
    private bool isHideOld = false;

    protected override void InitForm()
    {
      formCode = "SYPassword";
      base.InitForm();
      this.Text = Title;
      if (isHideOld)
      {
        Label1.Visible = false;
        txtOld.Visible = false;
        Label1.Enabled = false;
        txtOld.Enabled = false;
        Label3.Top = Label2.Top;
        txtNewA.Top = txtNew.Top;
        Label2.Top = Label1.Top;
        txtNew.Top = txtOld.Top;
        Height = Height - 30;
      }
    }

    public frmSYPassword(string title)
    {
      Title = title;
      oprtNo = OprtInfo.OprtNo;
      InitializeComponent();
    }

    public frmSYPassword(string title, string OprtNo)
    {
      Title = title;
      oprtNo = OprtNo;
      isHideOld = true;
      InitializeComponent();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      string OldPass = Pub.GetOprtEncrypt(txtOld.Text.Trim());
      string Pass = Pub.GetOprtEncrypt(txtNew.Text.Trim());
      string PassA = Pub.GetOprtEncrypt(txtNewA.Text.Trim());
      string OldPassA = "";
      DataTableReader dr = null;
      bool IsOk = false;
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { "3", oprtNo }));
        if (!dr.Read())
        {
          Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorOldPassword", ""));
        }
        else if (Pass != PassA)
        {
          Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorPasswordTwo", ""));
        }
        else
        {
          if (isHideOld)
          {
            db.ExecSQL(Pub.GetSQL(DBCode.DB_000002, new string[] { "201", Pass, oprtNo }));
            IsOk = true;
          }
          else
          {
            OldPassA = dr["OprtPWD"].ToString();
            if (OldPass == "") OldPass = Pub.GetOprtEncrypt("0");
            if (OldPassA == "") OldPassA = Pub.GetOprtEncrypt("0");
            if (Pass == "") Pass = Pub.GetOprtEncrypt("0");
            if (OldPass == OldPassA)
            {
              db.ExecSQL(Pub.GetSQL(DBCode.DB_000002, new string[] { "201", Pass, oprtNo }));
              IsOk = true;
            }
            else
            {
              Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorOldPassword", ""));
            }
          }
        }
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      if (IsOk)
      {
        string msg = Pub.GetResText(formCode, "MsgPasswordSuccess", "");
        db.WriteSYLog(this.Text, btnOk.Text, msg);
        Pub.MessageBoxShow(msg, MessageBoxIcon.Information);
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }
  }
}