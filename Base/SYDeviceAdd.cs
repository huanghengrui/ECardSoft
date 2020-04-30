using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmSYDeviceAdd : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "SYDeviceAdd";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      Label1.ForeColor = Color.Red;
      Label2.ForeColor = Color.Red;
      Label3.ForeColor = Color.Red;
      Label6.ForeColor = Color.Red;
      Label4.ForeColor = Color.Blue;
      Label5.ForeColor = Color.Blue;
      LoadData();
      SetTextboxNumber(txtNo);
      SetTextboxNumber(txtPass);
      SetTextboxNumber(txtPassA);
    }

    public frmSYDeviceAdd(string title, string CurrentTool, string GUID)
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
        if (SysID == "")
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000004, new string[] { "101" }));
          if (dr.Read())
          {
            int no = 0;
            int.TryParse(dr[0].ToString(), out no);
            if (no > 20) no = 20;
            txtNo.Text = no.ToString();
          }
        }
        else
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000004, new string[] { "4", SysID }));
          if (dr.Read())
          {
            txtNo.Text = dr["MacOpterID"].ToString();
            txtName.Text = dr["MacOpterName"].ToString();
            txtPass.Text = dr["MacOpterPWD"].ToString();
            txtPassA.Text = txtPass.Text;
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
      int OprtNo = 0;
      if (Pub.IsNumeric(txtNo.Text.Trim())) OprtNo = Convert.ToInt32(txtNo.Text.Trim());
      string OprtName = txtName.Text.Trim();
      string Pass = txtPass.Text.Trim();
      string PassA = txtPassA.Text.Trim();
      DataTableReader dr = null;
      bool IsOk = false;
      string sql = "";

      if (!Pub.CheckTextMaxLength(Label2.Text, txtName.Text, txtName.MaxLength)) return;
      if ((OprtNo < 1) || (OprtNo > 20))
      {
        txtNo.Focus();
        ShowErrorSelectCorrect(Label1.Text);
        return;
      }
      if (OprtName == "")
      {
        txtName.Focus();
        ShowErrorSelectCorrect(Label2.Text);
        return;
      }
      if ((Pass == "") || (!Pub.IsNumeric(Pass)))
      {
        txtPass.Focus();
        ShowErrorSelectCorrect(Label3.Text);
        return;
      }
      if (Pass != PassA)
      {
        txtPass.Focus();
        Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorPasswordTwo", ""));
        return;
      }
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        if (SysID == "")
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000004, new string[] { "5", OprtNo.ToString() }));
          if (dr.Read())
          {
            txtNo.Focus();
            ShowErrorCannotRepeated(Label1.Text);
          }
          else
          {
            sql = Pub.GetSQL(DBCode.DB_000004, new string[] { "1", OprtNo.ToString(), OprtName, Pass });
            db.ExecSQL(sql);
            IsOk = true;
          }
        }
        else
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000004, new string[] { "6", SysID, OprtNo.ToString() }));
          if (dr.Read())
          {
            txtNo.Focus();
            Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error005", ""));
          }
          else
          {
            sql = Pub.GetSQL(DBCode.DB_000004, new string[] { "2", OprtNo.ToString(), OprtName, Pass, SysID });
            db.ExecSQL(sql);
            IsOk = true;
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
        db.WriteSYLog(this.Text, CurrentOprt, sql);
        Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }
  }
}