using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmSYPowerAdd : frmBaseDialog
  {
    protected override void InitForm()
    {
      DateTime dt = new DateTime(2099, 12, 31);
      formCode = "SYPowerAdd";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      Label1.ForeColor = Color.Red;
      Label2.ForeColor = Color.Red;
      Label3.ForeColor = Color.Red;
      Label4.ForeColor = Color.Blue;
      Label5.ForeColor = Color.Red;
      dtpOprtStartDay.Value = DateTime.Now.Date;
      dtpOprtEndDay.Value = dt;
      chkActive.Checked = true;
      if (SysID != "") LoadData();
    }

    public frmSYPowerAdd(string title, string CurrentTool, string GUID)
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
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000003, new string[] { "4", SysID }));
        if (dr.Read())
        {
          txtOprtNo.Text = dr["OprtNo"].ToString();
          txtOprtName.Text = dr["OprtName"].ToString();
          txtOprtPWD.Text = Pub.GetOprtDecrypt(dr["OprtPWD"].ToString());
          txtOprtPWDA.Text = txtOprtPWD.Text;
          dtpOprtStartDay.Value = Convert.ToDateTime(dr["OprtStartDay"]);
          dtpOprtEndDay.Value = Convert.ToDateTime(dr["OprtEndDay"]);
          txtOprtDesc.Text = dr["OprtDesc"].ToString();
          chkActive.Checked = dr["OprtIsActive"].ToString().ToUpper()=="Y";
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
      string OprtNo = txtOprtNo.Text.Trim();
      string OprtName = txtOprtName.Text.Trim();
      string Pass = txtOprtPWD.Text.Trim();
      string PassA = txtOprtPWDA.Text.Trim();
      string StartDay = dtpOprtStartDay.Value.ToString(SystemInfo.SQLDateFMT);
      string EndDay = dtpOprtEndDay.Value.ToString(SystemInfo.SQLDateFMT);
      string Desc = txtOprtDesc.Text.Trim();
      string IsActive = "N";
      DataTableReader dr = null;
      bool IsOk = false;
      string sql = "";
      if (!Pub.CheckTextMaxLength(Label1.Text, txtOprtNo.Text, txtOprtNo.MaxLength)) return;
      if (!Pub.CheckTextMaxLength(Label2.Text, txtOprtName.Text, txtOprtName.MaxLength)) return;
      if (!Pub.CheckTextMaxLength(Label3.Text, txtOprtPWD.Text, txtOprtPWD.MaxLength)) return;
      if (!Pub.CheckTextMaxLength(Label8.Text, txtOprtDesc.Text, txtOprtDesc.MaxLength)) return;
      if (OprtNo == "")
      {
        txtOprtNo.Focus();
        ShowErrorEnterCorrect(Label1.Text);
        return;
      }
      if (Pub.GetTextLength(OprtNo) <3)
      {
        txtOprtNo.Focus();
        Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", ""));
        return;
      }
      if (OprtName == "")
      {
        txtOprtName.Focus();
        ShowErrorEnterCorrect(Label2.Text);
        return;
      }
      if (Pass != PassA)
      {
        txtOprtPWD.Focus();
        Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorPasswordTwo", ""));
        return;
      }
      Pass = Pub.GetOprtEncrypt(Pass);
      if (Pass == "") Pass = Pub.GetOprtEncrypt("0");
      if (chkActive.Checked) IsActive = "Y";
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        if (SysID == "")
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000003, new string[] { "5", OprtNo }));
          if (dr.Read())
          {
            txtOprtNo.Focus();
            ShowErrorCannotRepeated(Label1.Text);
          }
          else
          {
            sql = Pub.GetSQL(DBCode.DB_000003, new string[] { "1", OprtNo, OprtName, Pass, 
              StartDay, EndDay, Desc, IsActive });
            db.ExecSQL(sql);
            IsOk = true;
          }
        }
        else
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000003, new string[] { "6", SysID, OprtNo }));
          if (dr.Read())
          {
            txtOprtNo.Focus();
            ShowErrorCannotRepeated(Label1.Text);
          }
          else
          {
            sql = Pub.GetSQL(DBCode.DB_000003, new string[] { "2", OprtNo, OprtName, Pass, 
              StartDay, EndDay, Desc, IsActive, SysID });
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