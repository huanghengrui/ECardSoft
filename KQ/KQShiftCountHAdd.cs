using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmKQShiftCountHAdd : frmBaseDialog
  {
    private bool _ReadOnly = false;

    protected override void InitForm()
    {
      formCode = "KQShiftCountHAdd";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      LoadData();
    }

    public frmKQShiftCountHAdd(string title, string CurrentTool, string GUID)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      _ReadOnly = false;
      InitializeComponent();
    }

    public frmKQShiftCountHAdd(string title, string CurrentTool, string GUID, bool ReadOnly)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      _ReadOnly = ReadOnly;
      InitializeComponent();
    }

    private void LoadData()
    {
      DataTableReader dr = null;
      try
      {
        if (SysID != "")
        {
          txtNo.Enabled = false;
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002021, new string[] { "4", SysID }));
          if (dr.Read())
          {
            txtNo.Text = dr["ShiftCountHNo"].ToString();
            txtName.Text = dr["ShiftCountHName"].ToString();
            txtInTime.Text = dr["ShiftCountHInTime"].ToString();
            chkInNextDay.Checked = dr["InNextDay"].ToString().ToUpper() == "Y";
            txtOutTime.Text = dr["ShiftCountHOutTime"].ToString();
            chkOutNextDay.Checked = dr["OutNextDay"].ToString().ToUpper() == "Y";
            chkRound.Checked = dr["AddISGetInt"].ToString().ToUpper() == "Y";
            rbRoundHour.Checked = dr["AddGetInt"].ToString() == "2";
            rbRoundHalf.Checked = !rbRoundHour.Checked;
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
      string ShiftNo = txtNo.Text.Trim();
      string ShiftName = txtName.Text.Trim();
      if (!Pub.CheckTextMaxLength(label1.Text, ShiftNo, txtNo.MaxLength)) return;
      if (!Pub.CheckTextMaxLength(label2.Text, ShiftName, txtName.MaxLength)) return;
      if (ShiftNo == "")
      {
        txtNo.Focus();
        ShowErrorEnterCorrect(label1.Text);
        return;
      }
      if (ShiftName == "")
      {
        txtName.Focus();
        ShowErrorEnterCorrect(label2.Text);
        return;
      }
      const int DaySeconds = 24 * 3600;
      DateTime dt = new DateTime();
      if (!DateTime.TryParse(txtInTime.Text, out dt))
      {
        txtInTime.Focus();
        Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", ""));
        return;
      }
      int InTime = dt.Hour * 3600 + dt.Minute * 60;
      if (chkInNextDay.Checked) InTime += DaySeconds;
      if (!DateTime.TryParse(txtOutTime.Text, out dt))
      {
        txtOutTime.Focus();
        Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error002", ""));
        return;
      }
      int OutTime = dt.Hour * 3600 + dt.Minute * 60;
      if (chkOutNextDay.Checked) OutTime += DaySeconds;
      if (InTime >= OutTime)
      {
        txtOutTime.Focus();
        Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error003", ""));
        return;
      }
      string AddISGetInt = chkRound.Checked ? "Y" : "N";
      string AddGetInt = rbRoundHalf.Checked ? "1" : "2";
      DataTableReader dr = null;
      bool IsOk = true;
      List<string> sql = new List<string>();
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        if (SysID == "")
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002003, new string[] { "5", ShiftNo }));
          if (dr.Read())
          {
            IsOk = false;
            txtNo.Focus();
            ShowErrorCannotRepeated(label1.Text);
          }
          else
          {
            sql.Add(Pub.GetSQL(DBCode.DB_002021, new string[] { "1", ShiftNo, ShiftName }));
            sql.Add(Pub.GetSQL(DBCode.DB_002021, new string[] { "5", ShiftNo, InTime.ToString(), OutTime.ToString(), 
              AddISGetInt, AddGetInt }));
          }
        }
        else
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002003, new string[] { "6", SysID, ShiftNo }));
          if (dr.Read())
          {
            IsOk = false;
            txtNo.Focus();
            ShowErrorCannotRepeated(label1.Text);
          }
          else
          {
            sql.Add(Pub.GetSQL(DBCode.DB_002021, new string[] { "2", ShiftNo, ShiftName, SysID }));
            sql.Add(Pub.GetSQL(DBCode.DB_002021, new string[] { "6", InTime.ToString(), OutTime.ToString(), 
              AddISGetInt, AddGetInt, ShiftNo }));
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