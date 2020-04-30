using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmAccount : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "DMAccount";
      base.InitForm();
      SystemInfo.ConnStr = GetConnStrSystem();
      LoadAccount();
    }

    public frmAccount()
    {
      InitializeComponent();
    }

    private void LoadAccount()
    {
      DataTableReader dr = null;
      string AccName;
      string DBName;
      TCommonType obj;
      cbbAccount.Items.Clear();
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "119" }));
        while (dr.Read())
        {
          AccName = dr["AccName"].ToString();
          DBName = dr["DBName"].ToString();
          obj = new TCommonType(DBName, DBName, AccName);
          cbbAccount.Items.Add(obj);
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
      if (cbbAccount.Items.Count > 0) cbbAccount.SelectedIndex = 0;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (cbbAccount.SelectedIndex == -1)
      {
        cbbAccount.Focus();
        ShowErrorSelectCorrect(label1.Text);
        return;
      }
      if (txtPass.Text.Trim() != "hsun1234")
      //if (txtPass.Text.Trim() != "")
      {
        txtPass.Focus();
        Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", ""));
        return;
      }
      string DBName = ((TCommonType)cbbAccount.Items[cbbAccount.SelectedIndex]).id;
      SystemInfo.ConnStr = GetConnStr(DBName);
      this.Close();
      this.DialogResult = DialogResult.OK;
    }
  }
}