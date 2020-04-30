using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmKQShiftRuleAdd : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "KQShiftRuleAdd";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      cbbFlag.Items.Clear();
      cbbFlag.Items.Add(Pub.GetResText(formCode, "ShiftRuleFlag0", ""));
      cbbFlag.Items.Add(Pub.GetResText(formCode, "ShiftRuleFlag1", ""));
      cbbFlag.Items.Add(Pub.GetResText(formCode, "ShiftRuleFlag2", ""));
      SetTextboxNumber(txtDays);
      LoadData();
    }

    public frmKQShiftRuleAdd(string title, string CurrentTool, string GUID)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      InitializeComponent();
    }

    private void LoadData()
    {
      DataTableReader dr = null;
      TCommonType ctype = new TCommonType("", "", "", true);
      ComboBox cbb;
      int row = 0;
      for (int i = 1; i <= 31; i++)
      {
        cbb = (ComboBox)this.Controls["cbbShift" + i.ToString("00")];
        cbb.Items.Clear();
        cbb.Items.Add(ctype);
      }
      try
      {
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002004, new string[] { "3" }));
        while (dr.Read())
        {
          ctype = new TCommonType(dr["GUID"].ToString(), dr["ShiftNo"].ToString(), dr["ShiftName"].ToString(), true);
          for (int i = 1; i <= 31; i++)
          {
            cbb = (ComboBox)this.Controls["cbbShift" + i.ToString("00")];
            cbb.Items.Add(ctype);
          }
        }
        for (int i = 1; i <= 31; i++)
        {
          cbb = (ComboBox)this.Controls["cbbShift" + i.ToString("00")];
          cbb.SelectedIndex = 0;
        }
        if (SysID == "")
        {
          cbbFlag.SelectedIndex = 0;
        }
        else
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002004, new string[] { "4", SysID }));
          if (dr.Read())
          {
            txtName.Text = dr["ShiftRuleName"].ToString();
            cbbFlag.SelectedIndex = Convert.ToInt32(dr["Flag"].ToString());
            txtDays.Text = dr["CycDays"].ToString();
          }
          dr.Close();
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002004, new string[] { "10", SysID }));
          while (dr.Read())
          {
            int.TryParse(dr["ShiftRuleRow"].ToString(), out row);
            cbb = (ComboBox)this.Controls["cbbShift" + row.ToString("00")];
            for (int i = 0; i < cbb.Items.Count; i++)
            {
              if (((TCommonType)cbb.Items[i]).id == dr["ShiftNo"].ToString())
              {
                cbb.SelectedIndex = i;
                break;
              }
            }
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

    private void cbbFlag_SelectedIndexChanged(object sender, EventArgs e)
    {
      label3.Enabled = cbbFlag.SelectedIndex == 0;
      txtDays.Enabled = label3.Enabled;
      if (cbbFlag.SelectedIndex == 0)
        txtDays.Text = "1";
      else if (cbbFlag.SelectedIndex == 1)
        txtDays.Text = "7";
      else if (cbbFlag.SelectedIndex == 2)
        txtDays.Text = "31";
    }

    private void txtDays_TextChanged(object sender, EventArgs e)
    {
      int min = 1;
      int max = 31;
      int v = 0;
      int.TryParse(txtDays.Text, out v);
      if (cbbFlag.SelectedIndex == 0)
      {
        if (v < min) txtDays.Text = min.ToString();
        if (v > max) txtDays.Text = max.ToString();
        int.TryParse(txtDays.Text, out v);
      }
      Label lab;
      ComboBox cbb;
      string res = "";
      for (int i = 1; i <= 31; i++)
      {
        lab = (Label)this.Controls["label" + i.ToString("00")];
        cbb = (ComboBox)this.Controls["cbbShift" + i.ToString("00")];
        lab.Enabled = (i <= v);
        lab.Visible = lab.Enabled;
        cbb.Enabled = lab.Enabled;
        cbb.Visible = lab.Enabled;
        lab.Text = i.ToString();
        if ((cbbFlag.SelectedIndex == 1) && (i <= 7))
        {
          switch (i)
          {
            case 1:
              res = "Sunday";
              break;
            case 2:
              res = "Monday";
              break;
            case 3:
              res = "Tuesday";
              break;
            case 4:
              res = "Wednesday";
              break;
            case 5:
              res = "Thursday";
              break;
            case 6:
              res = "Friday";
              break;
            case 7:
              res = "Saturday";
              break;
          }
          lab.Text = Pub.GetResText(formCode, res, lab.Text);
        }
        toolTip.SetToolTip(lab, lab.Text);
      }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      string RuleName = txtName.Text.Trim();
      if (!Pub.CheckTextMaxLength(label1.Text, RuleName, txtName.MaxLength)) return;
      if (RuleName == "")
      {
        txtName.Focus();
        ShowErrorEnterCorrect(label1.Text);
        return;
      }
      int flag = cbbFlag.SelectedIndex;
      int days = 0;
      int.TryParse(txtDays.Text, out days);
      ComboBox cbb;
      DataTableReader dr = null;
      bool IsOk = true;
      List<string> sql = new List<string>();
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        if (SysID == "")
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002004, new string[] { "5", RuleName }));
          if (dr.Read())
          {
            IsOk = false;
            txtName.Focus();
            ShowErrorCannotRepeated(label1.Text);
          }
          else
          {
            sql.Add(Pub.GetSQL(DBCode.DB_002004, new string[] { "7", RuleName, flag.ToString(), days.ToString() }));
          }
        }
        else
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002004, new string[] { "6", SysID, RuleName }));
          if (dr.Read())
          {
            IsOk = false;
            txtName.Focus();
            ShowErrorCannotRepeated(label1.Text);
          }
          else
          {
            sql.Add(Pub.GetSQL(DBCode.DB_002004, new string[] { "8", RuleName, flag.ToString(), days.ToString(), SysID }));
            sql.Add(Pub.GetSQL(DBCode.DB_002004, new string[] { "2", SysID }));
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
      string ShiftNo = "";
      for (int i = 1; i <= days; i++)
      {
        cbb = (ComboBox)this.Controls["cbbShift" + i.ToString("00")];
        ShiftNo = ((TCommonType)cbb.Items[cbb.SelectedIndex]).id;
        sql.Add(Pub.GetSQL(DBCode.DB_002004, new string[] { "9", i.ToString(), ShiftNo, RuleName }));
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