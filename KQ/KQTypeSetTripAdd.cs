using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmKQTypeSetTripAdd : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "KQTypeSetTripAdd";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      if (SysID != "") LoadData();
    }

    public frmKQTypeSetTripAdd(string title, string CurrentTool, string GUID)
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
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002002, new string[] { "204", SysID }));
        if (dr.Read())
        {
          txtNo.Text = dr["TripTypeNo"].ToString();
          txtName.Text = dr["TripTypeName"].ToString();
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
      string TripTypeNo = txtNo.Text.Trim();
      string TripTypeName = txtName.Text.Trim();
      if (!Pub.CheckTextMaxLength(label1.Text, TripTypeNo, txtNo.MaxLength)) return;
      if (!Pub.CheckTextMaxLength(label2.Text, TripTypeName, txtName.MaxLength)) return;
      if (TripTypeNo == "")
      {
        txtNo.Focus();
        ShowErrorEnterCorrect(label1.Text);
        return;
      }
      if (TripTypeName == "")
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
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002002, new string[] { "205", TripTypeNo }));
          if (dr.Read())
          {
            IsOk = false;
            txtNo.Focus();
            ShowErrorCannotRepeated(label1.Text);
          }
          else
          {
            sql.Add(Pub.GetSQL(DBCode.DB_002002, new string[] { "201", TripTypeNo, TripTypeName }));
          }
        }
        else
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002002, new string[] { "206", SysID, TripTypeNo }));
          if (dr.Read())
          {
            IsOk = false;
            txtNo.Focus();
            ShowErrorCannotRepeated(label1.Text);
          }
          else
          {
            sql.Add(Pub.GetSQL(DBCode.DB_002002, new string[] { "202", TripTypeNo, TripTypeName, SysID }));
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