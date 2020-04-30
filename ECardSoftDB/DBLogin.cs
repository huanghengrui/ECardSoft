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
  public partial class frmDBLogin : frmBaseDialog
  {
    private bool ShowDBConnect()
    {
      bool ret = false;
      if (new frmDBConnect().ShowDialog() == DialogResult.OK)
      {
        ret = true;
        Application.Restart();
      }
      return ret;
    }

    protected override void InitForm()
    {
      formCode = "DBLogin";
      base.InitForm();
      SystemInfo.ConnStr = GetConnStrSystem();
      if ((SystemInfo.DBType == 1) && (DBServerInfo.ServerName == ""))
      {
        if (ShowDBConnect()) return;
      }
      if (SystemInfo.DBType == 2)
      {
        btnConnect.Visible = false;
        btnConnect.Enabled = false;
      }
       txtPass.Focus();
    }

    public frmDBLogin()
    {
      InitializeComponent();
    }

    private void btnConnect_Click(object sender, EventArgs e)
    {
      ShowDBConnect();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      bool IsOk = false;
      try
      {
        db.Open(SystemInfo.ConnStr);
        db.CreateAccountTable();
        DataTableReader dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { }));
        if (!dr.Read())
        {
          db.ExecSQL(Pub.GetSQL(DBCode.DB_000001, new string[] { "4" }));
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { }));
          dr.Read();
        }
        if (txtPass.Text.Trim() != dr[0].ToString().Trim())
        {
          txtPass.Focus();
          Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", ""));
        }
        else
          IsOk = true;
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E);
      }
      db.Close();
      if (!IsOk)
      {
        txtPass.Focus();
        return;
      }
      this.Close();
      this.DialogResult = DialogResult.OK;
    }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnOk_Click(null,null);
            }
        }
    }
}