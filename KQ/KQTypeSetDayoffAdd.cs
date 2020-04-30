using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmKQTypeSetDayoffAdd : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "KQTypeSetDayoffAdd";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      if (SysID != "") LoadData();
    }

    public frmKQTypeSetDayoffAdd(string title, string CurrentTool, string GUID)
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
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002002, new string[] { "104", SysID }));
        if (dr.Read())
        {
          txtNo.Text = dr["DayOffTypeNo"].ToString();
          txtName.Text = dr["DayOffTypeName"].ToString();
          chkGS.Checked = dr["DayOffIsGS"].ToString().ToUpper() == "Y";
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
      string DayoffNo = txtNo.Text.Trim();
      string DayoffName = txtName.Text.Trim();
      string IsGS = "N";
      if (chkGS.Checked) IsGS = "Y";
      if (!Pub.CheckTextMaxLength(label1.Text, DayoffNo, txtNo.MaxLength)) return;
      if (!Pub.CheckTextMaxLength(label2.Text, DayoffName, txtName.MaxLength)) return;
      if (DayoffNo == "")
      {
        txtNo.Focus();
        ShowErrorEnterCorrect(label1.Text);
        return;
      }
      if (DayoffName == "")
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
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002002, new string[] { "105", DayoffNo }));
          if (dr.Read())
          {
            IsOk = false;
            txtNo.Focus();
            ShowErrorCannotRepeated(label1.Text);
          }
          else
          {
            sql.Add(Pub.GetSQL(DBCode.DB_002002, new string[] { "101", DayoffNo, DayoffName, IsGS }));
          }
        }
        else
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002002, new string[] { "106", SysID, DayoffNo }));
          if (dr.Read())
          {
            IsOk = false;
            txtNo.Focus();
            ShowErrorCannotRepeated(label1.Text);
          }
          else
          {
            sql.Add(Pub.GetSQL(DBCode.DB_002002, new string[] { "102", DayoffNo, DayoffName, IsGS, SysID }));
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