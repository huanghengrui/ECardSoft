using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmKQTypeSetOtAdd : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "KQTypeSetOtAdd";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      if (SysID != "") LoadData();
    }

    public frmKQTypeSetOtAdd(string title, string CurrentTool, string GUID)
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
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002002, new string[] { "4", SysID }));
        if (dr.Read())
        {
          txtNo.Text = dr["OtTypeNo"].ToString();
          txtName.Text = dr["OtTypeName"].ToString();
          chkDefault.Checked = dr["OtIsDefault"].ToString().ToUpper() == "Y";
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
      string OtNo = txtNo.Text.Trim();
      string OtName = txtName.Text.Trim();
      string Def = "N";
      if (chkDefault.Checked) Def = "Y";
      if (!Pub.CheckTextMaxLength(label1.Text, OtNo, txtNo.MaxLength)) return;
      if (!Pub.CheckTextMaxLength(label2.Text, OtName, txtName.MaxLength)) return;
      if (OtNo == "")
      {
        txtNo.Focus();
        ShowErrorEnterCorrect(label1.Text);
        return;
      }
      if (OtName == "")
      {
        txtName.Focus();
        ShowErrorEnterCorrect(label2.Text);
        return;
      }
      DataTableReader dr = null;
      bool IsOk = true;
      List<string> sql = new List<string>();
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        if (SysID == "")
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002002, new string[] { "5", OtNo }));
          if (dr.Read())
          {
            IsOk = false;
            txtNo.Focus();
            ShowErrorCannotRepeated(label1.Text);
          }
          else
          {
            sql.Add(Pub.GetSQL(DBCode.DB_002002, new string[] { "1", OtNo, OtName, Def }));
          }
        }
        else
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002002, new string[] { "6", SysID, OtNo }));
          if (dr.Read())
          {
            IsOk = false;
            txtNo.Focus();
            ShowErrorCannotRepeated(label1.Text);
          }
          else
          {
            sql.Add(Pub.GetSQL(DBCode.DB_002002, new string[] { "2", OtNo, OtName, Def, SysID }));
          }
        }
      }
      catch (Exception E)
      {
        IsOk = false;
        Pub.ShowErrorMsg(E);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      if (!IsOk) return;
      if (chkDefault.Checked)
      {
        sql.Add(Pub.GetSQL(DBCode.DB_002002, new string[] { "7", OtNo }));
      }
      if (db.ExecSQL(sql) != 0) IsOk = false;
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