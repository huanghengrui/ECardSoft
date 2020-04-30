using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmMJMacPasswordEdit : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "MJMacPasswordEdit";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      LoadData();
      label4.Text += "1";
      label5.Text += "2";
      SetTextboxNumber(txtPassA);
      SetTextboxNumber(txtPassB);
    }

    public frmMJMacPasswordEdit(string title, string CurrentTool, string GUID)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      InitializeComponent();
    }

    private void LoadData()
    {
      DataTableReader dr = null;
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003001, new string[] { "1008", SysID }));
        if (dr.Read())
        {
          txtMacSN.Text = dr["MacSN"].ToString();
          txtMacDoorID.Text = dr["MacDoorID"].ToString();
          txtMacDoorName.Text = dr["MacDoorName"].ToString();
          string[] pass = dr["MacDoorPassword"].ToString().Split(' ');
          if (pass.Length == 2)
          {
            txtPassA.Text = pass[0];
            txtPassB.Text = pass[1];
          }
          else
          {
            txtPassA.Text = "000000";
            txtPassB.Text = "000000";
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
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (!Pub.IsNumeric(txtPassA.Text.Trim()))
      {
        txtPassA.Focus();
        ShowErrorEnterCorrect(label4.Text);
        return;
      }
      if (!Pub.IsNumeric(txtPassB.Text.Trim()))
      {
        txtPassB.Focus();
        ShowErrorEnterCorrect(label5.Text);
        return;
      }
      string passA = txtPassA.Text.Trim();
      string passB = txtPassB.Text.Trim();
      string msg = Pub.GetResText(formCode, "Error001", "");
      const int passMin = 100000;
      if ((Convert.ToInt32(passA) > 0) && (Convert.ToInt32(passA) < passMin))
      {
        txtPassA.Focus();
        Pub.ShowErrorMsg(string.Format(msg, passMin));
        return;
      }
      if ((Convert.ToInt32(passB) > 0) && (Convert.ToInt32(passB) < passMin))
      {
        txtPassB.Focus();
        Pub.ShowErrorMsg(string.Format(msg, passMin));
        return;
      }
      while (passA.Length < txtPassA.MaxLength) passA = passA + "0";
      while (passB.Length < txtPassB.MaxLength) passB = passB + "0";
      string pass = passA + " " + passB;
      string sql = "";
      try
      {
        sql = Pub.GetSQL(DBCode.DB_003001, new string[] { "103", pass, SysID });
        db.ExecSQL(sql);
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E, sql);
        return;
      }
      db.WriteSYLog(this.Text, CurrentOprt, sql);
      Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
  }
}