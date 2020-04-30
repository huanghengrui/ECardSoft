using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmMJMacTimeGroup : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "MJMacTimeGroup";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      label1.ForeColor = Color.Red;
      label3.ForeColor = Color.Blue;
      label9.ForeColor = Color.Navy;
      SetTextboxNumber(txtID);
      LoadData();
    }

    public frmMJMacTimeGroup(string title, string CurrentTool, string GUID)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      InitializeComponent();
    }

    private void LoadData()
    {
      DataTableReader dr = null;
      TCommonType ctype;
      cbbSun.Items.Clear();
      cbbMon.Items.Clear();
      cbbTue.Items.Clear();
      cbbWed.Items.Clear();
      cbbThu.Items.Clear();
      cbbFri.Items.Clear();
      cbbSat.Items.Clear();
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003003, new string[] { "7" }));
        while (dr.Read())
        {
          ctype = new TCommonType(dr["MacTimeSysID"].ToString(), dr["MacTimeNo"].ToString(), dr["MacTimeName"].ToString());
          cbbSun.Items.Add(ctype);
          cbbMon.Items.Add(ctype);
          cbbTue.Items.Add(ctype);
          cbbWed.Items.Add(ctype);
          cbbThu.Items.Add(ctype);
          cbbFri.Items.Add(ctype);
          cbbSat.Items.Add(ctype);
        }
        if (SysID == "")
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003003, new string[] { "1010" }));
          if (dr.Read())
          {
            int no = 0;
            int.TryParse(dr[0].ToString(), out no);
            if (no > SystemInfo.MaxTimeNoNew) no = SystemInfo.MaxTimeNoNew;
            txtID.Text = no.ToString();
          }
          cbbSun.SelectedIndex = 0;
          cbbMon.SelectedIndex = 0;
          cbbTue.SelectedIndex = 0;
          cbbWed.SelectedIndex = 0;
          cbbThu.SelectedIndex = 0;
          cbbFri.SelectedIndex = 0;
          cbbSat.SelectedIndex = 0;
        }
        else
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003003, new string[] { "1006", SysID }));
          if (dr.Read())
          {
            txtID.Text = dr["MacTimeHeaderTimeNo"].ToString();
            txtName.Text = dr["MacTimeHeaderName"].ToString();
            SetTimeIndex(cbbSun, dr["MacTimeHeaderSunday"].ToString());
            SetTimeIndex(cbbMon, dr["MacTimeHeaderMonday"].ToString());
            SetTimeIndex(cbbTue, dr["MacTimeHeaderTuesday"].ToString());
            SetTimeIndex(cbbWed, dr["MacTimeHeaderWednesday"].ToString());
            SetTimeIndex(cbbThu, dr["MacTimeHeaderThursday"].ToString());
            SetTimeIndex(cbbFri, dr["MacTimeHeaderFriday"].ToString());
            SetTimeIndex(cbbSat, dr["MacTimeHeaderSaturday"].ToString());
            int v = 0;
            int.TryParse(dr["MacTimeHeaderHoliday"].ToString(), out v);
            chkHoliday.Checked = v > 0;
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

    private void SetTimeIndex(ComboBox cbb, string id)
    {
      for (int i = 0; i < cbb.Items.Count; i++)
      {
        if (((TCommonType)cbb.Items[i]).id == id)
        {
          cbb.SelectedIndex = i;
          break;
        }
      }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (!Pub.IsNumeric(txtID.Text.Trim()))
      {
        txtID.Focus();
        ShowErrorEnterCorrect(label1.Text);
        return;
      }
      int id = 0;
      int.TryParse(txtID.Text.Trim(), out id);
      if ((id < 0) || (id > SystemInfo.MaxTimeNo))
      {
        txtID.Focus();
        Pub.ShowErrorMsg(string.Format(Pub.GetResText(formCode, "Error101", ""), 0, SystemInfo.MaxTimeNo));
        return;
      }
      string name = txtName.Text.Trim();
      if (!Pub.CheckTextMaxLength(label2.Text, name, txtName.MaxLength)) return;
      if (cbbSun.SelectedIndex < 0)
      {
        ShowErrorSelectCorrect(label3.Text);
        return;
      }
      if (cbbMon.SelectedIndex < 0)
      {
        ShowErrorSelectCorrect(label4.Text);
        return;
      }
      if (cbbTue.SelectedIndex < 0)
      {
        ShowErrorSelectCorrect(label5.Text);
        return;
      }
      if (cbbWed.SelectedIndex < 0)
      {
        ShowErrorSelectCorrect(label6.Text);
        return;
      }
      if (cbbThu.SelectedIndex < 0)
      {
        ShowErrorSelectCorrect(label7.Text);
        return;
      }
      if (cbbFri.SelectedIndex < 0)
      {
        ShowErrorSelectCorrect(label8.Text);
        return;
      }
      if (cbbSat.SelectedIndex < 0)
      {
        ShowErrorSelectCorrect(label9.Text);
        return;
      }
      string SunID = ((TCommonType)cbbSun.Items[cbbSun.SelectedIndex]).id;
      string MonID = ((TCommonType)cbbMon.Items[cbbMon.SelectedIndex]).id;
      string TueID = ((TCommonType)cbbTue.Items[cbbTue.SelectedIndex]).id;
      string WedID = ((TCommonType)cbbWed.Items[cbbWed.SelectedIndex]).id;
      string ThuID = ((TCommonType)cbbThu.Items[cbbThu.SelectedIndex]).id;
      string FriID = ((TCommonType)cbbFri.Items[cbbFri.SelectedIndex]).id;
      string SatID = ((TCommonType)cbbSat.Items[cbbSat.SelectedIndex]).id;
      DataTableReader dr = null;
      bool IsOk = false;
      string sql = "";
      try
      {
        if (SysID == "")
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003003, new string[] { "1004", id.ToString() }));
          if (dr.Read())
          {
            txtID.Focus();
            ShowErrorCannotRepeated(label1.Text);
          }
          else
          {
            sql = Pub.GetSQL(DBCode.DB_003003, new string[] { "1011", id.ToString(), name, SunID, MonID, TueID, 
              WedID, ThuID, FriID, SatID, Convert.ToByte(chkHoliday.Checked).ToString() });
            db.ExecSQL(sql);
            IsOk = true;
          }
        }
        else
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003003, new string[] { "1005", SysID, id.ToString() }));
          if (dr.Read())
          {
            txtID.Focus();
            ShowErrorCannotRepeated(label1.Text);
          }
          else
          {
            sql = Pub.GetSQL(DBCode.DB_003003, new string[] { "1012", id.ToString(), name, SunID, MonID, TueID, 
              WedID, ThuID, FriID, SatID, Convert.ToByte(chkHoliday.Checked).ToString(), SysID });
            db.ExecSQL(sql);
            IsOk = true;
          }
        }
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E, sql);
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