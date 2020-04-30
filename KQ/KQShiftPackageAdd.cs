using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmKQShiftPackageAdd : frmBaseDialog
  {
    private bool _ReadOnly = false;

    protected override void InitForm()
    {
      formCode = "KQShiftPackageAdd";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      TextBox txt;
      for (int i = 1; i <= 10; i++)
      {
        txt = (TextBox)this.Controls["txtSeq" + i.ToString()];
        SetTextboxNumber(txt);
      }
      LoadData();
    }

    public frmKQShiftPackageAdd(string title, string CurrentTool, string GUID)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      _ReadOnly = false;
      InitializeComponent();
    }

    public frmKQShiftPackageAdd(string title, string CurrentTool, string GUID, bool ReadOnly)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      _ReadOnly = ReadOnly;
      InitializeComponent();
    }

    private void RadioButton_Click(object sender, EventArgs e)
    {
      cbbBackUpShiftNo.Enabled = rbIsBackUp.Checked;
    }

    private void LoadData()
    {
      DataTableReader dr = null;
      TCommonType ctype = new TCommonType("", "", "", true);
      TextBox txt;
      ComboBox cbb;
      cbbBackUpShiftNo.Items.Clear();
      cbbBackUpShiftNo.Items.Add(ctype);
      for (int i = 1; i <= 10; i++)
      {
        cbb = (ComboBox)this.Controls["cbbShiftNo" + i.ToString()];
        cbb.Items.Clear();
        cbb.Items.Add(ctype);
      }
      try
      {
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002020, new string[] { "101" }));
        while (dr.Read())
        {
          ctype = new TCommonType(dr["GUID"].ToString(), dr["ShiftNo"].ToString(), dr["ShiftName"].ToString(), true);
          cbbBackUpShiftNo.Items.Add(ctype);
          ctype = new TCommonType(dr["GUID"].ToString(), dr["ShiftName"].ToString(), dr["ShiftNo"].ToString(), true);
          for (int i = 1; i <= 10; i++)
          {
            cbb = (ComboBox)this.Controls["cbbShiftNo" + i.ToString()];
            cbb.Items.Add(ctype);
          }
        }
        if (SysID == "")
        {
          cbbBackUpShiftNo.SelectedIndex = 0;
          for (int i = 1; i <= 10; i++)
          {
            cbb = (ComboBox)this.Controls["cbbShiftNo" + i.ToString()];
            cbb.SelectedIndex = 0;
          }
        }
        else
        {
          txtNo.Enabled = false;
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002020, new string[] { "4", SysID }));
          if (dr.Read())
          {
            txtNo.Text = dr["ShiftPackNo"].ToString();
            txtName.Text = dr["ShiftPackName"].ToString();
            rbIsBackUp.Checked = dr["IsBackUp"].ToString().ToUpper() == "Y";
            rbIsPrevious.Checked = !rbIsBackUp.Checked;
            for (int i = 0; i < cbbBackUpShiftNo.Items.Count; i++)
            {
              if (((TCommonType)cbbBackUpShiftNo.Items[i]).id == dr["BackUpShiftNo"].ToString())
              {
                cbbBackUpShiftNo.SelectedIndex = i;
                break;
              }
            }
          }
          dr.Close();
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002020, new string[] { "5", txtNo.Text }));
          int index = 1;
          while (dr.Read())
          {
            txt = (TextBox)this.Controls["txtSeq" + index.ToString()];
            txt.Text = dr["PrioritySeq"].ToString();
            cbb = (ComboBox)this.Controls["cbbShiftNo" + index.ToString()];
            for (int i = 0; i < cbb.Items.Count; i++)
            {
              if (((TCommonType)cbb.Items[i]).name == dr["ShiftNo"].ToString())
              {
                cbb.SelectedIndex = i;
                break;
              }
            }
            index += 1;
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
      RadioButton_Click(null, null);
    }

    private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      ComboBox cbb = (ComboBox)sender;
      string n = cbb.Name;
      if (Pub.IsNumeric(n.Substring(n.Length - 2, 2)))
        n = n.Substring(n.Length - 2, 2);
      else if (Pub.IsNumeric(n.Substring(n.Length - 1, 1)))
        n = n.Substring(n.Length - 1, 1);
      TextBox txt = (TextBox)this.Controls["txtShiftName" + n];
      txt.Text = ((TCommonType)cbb.Items[cbb.SelectedIndex]).id;
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
      string IsBackUp = rbIsBackUp.Checked ? "Y" : "N";
      string BackUpShiftNo = IsBackUp == "Y" ? ((TCommonType)cbbBackUpShiftNo.Items[cbbBackUpShiftNo.SelectedIndex]).id : "";
      string IsPrevious = rbIsPrevious.Checked ? "Y" : "N";
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
            sql.Add(Pub.GetSQL(DBCode.DB_002020, new string[] { "1", ShiftNo, ShiftName }));
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
            sql.Add(Pub.GetSQL(DBCode.DB_002020, new string[] { "2", ShiftNo, ShiftName, SysID }));
            sql.Add(Pub.GetSQL(DBCode.DB_002020, new string[] { "3", SysID }));
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
      ComboBox cbb;
      TextBox txt;
      string v;
      for (int i = 1; i <= 10; i++)
      {
        cbb = (ComboBox)this.Controls["cbbShiftNo" + i.ToString()];
        if (cbb.SelectedIndex < 1) continue;
        txt = (TextBox)this.Controls["txtSeq" + i.ToString()];
        v = txt.Text.Trim();
        if ((v == "") || (!Pub.IsNumeric(v))) v = "0";
        sql.Add(Pub.GetSQL(DBCode.DB_002020, new string[] { "6", ShiftNo, 
          ((TCommonType)cbb.Items[cbb.SelectedIndex]).name, IsBackUp, BackUpShiftNo, IsPrevious, v }));
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