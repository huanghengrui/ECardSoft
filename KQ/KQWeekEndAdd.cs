using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmKQWeekEndAdd : frmBaseDialog
  {
    private List<TCommonType> HolidayTimeList = new List<TCommonType>();
    private List<TCommonType> HoliDayOtTypeList = new List<TCommonType>();

    protected override void InitForm()
    {
      formCode = "KQWeekEndAdd";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      LoadData();
    }

    public frmKQWeekEndAdd(string title, string CurrentTool, string GUID)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      InitializeComponent();
    }

    private void LoadData()
    {
      HolidayTimeList.Clear();
      HoliDayOtTypeList.Clear();
      DataTableReader dr = null;
      ComboBox cbb;
      for (int i = 1; i <= 7; i++)
      {
        cbb = (ComboBox)this.Controls["cbbTime" + i.ToString()];
        cbb.Items.Clear();
        cbb.Items.Add(new TCommonType("", "0", "", true));
        cbb = (ComboBox)this.Controls["cbbType" + i.ToString()];
        cbb.Items.Clear();
        cbb.Items.Add(new TCommonType("", "", "", true));
      }
      try
      {
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002016, new string[] { "5" }));
        while (dr.Read())
        {
          HolidayTimeList.Add(new TCommonType(dr["HolidayTimeSegSysID"].ToString(), dr["HolidayTimeSegID"].ToString(),
            dr["HolidayTimeSegName"].ToString(), true));
          for (int i = 1; i <= 7; i++)
          {
            cbb = (ComboBox)this.Controls["cbbTime" + i.ToString()];
            cbb.Items.Add(HolidayTimeList[HolidayTimeList.Count - 1]);
          }
        }
        dr.Close();
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002002, new string[] { "0" }));
        while (dr.Read())
        {
          HoliDayOtTypeList.Add(new TCommonType(dr["OtTypeSysID"].ToString(), dr["OtTypeNo"].ToString(),
            dr["OtTypeName"].ToString(), true));
          for (int i = 1; i <= 7; i++)
          {
            cbb = (ComboBox)this.Controls["cbbType" + i.ToString()];
            cbb.Items.Add(HoliDayOtTypeList[HoliDayOtTypeList.Count - 1]);
          }
        }
        dr.Close();
        if (SysID == "")
        {
          for (int i = 1; i <= 7; i++)
          {
            cbb = (ComboBox)this.Controls["cbbTime" + i.ToString()];
            cbb.SelectedIndex = 0;
            if (((i == 1) || (i == 7)) && (cbb.Items.Count > 1)) cbb.SelectedIndex = 1;
            cbb = (ComboBox)this.Controls["cbbType" + i.ToString()];
            cbb.SelectedIndex = 0;
            if (((i == 1) || (i == 7)) && (cbb.Items.Count > 1)) cbb.SelectedIndex = 1;
          }
        }
        else
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002017, new string[] { "5", SysID }));
          if (dr.Read())
          {
            txtNo.Text = dr["WeekEndNo"].ToString();
            txtName.Text = dr["WeekEndName"].ToString();
          }
          dr.Close();
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002017, new string[] { "6", SysID }));
          while (dr.Read())
          {
            cbb = (ComboBox)this.Controls["cbbTime" + dr["WeekIndex"].ToString()];
            for (int i = 0; i < cbb.Items.Count; i++)
            {
              if (((TCommonType)cbb.Items[i]).id == dr["WeekTimeSeg"].ToString())
              {
                cbb.SelectedIndex = i;
                break;
              }
            }
            cbb = (ComboBox)this.Controls["cbbType" + dr["WeekIndex"].ToString()];
            for (int i = 0; i < cbb.Items.Count; i++)
            {
              if (((TCommonType)cbb.Items[i]).sysID == dr["WeekOtTypeSysID"].ToString())
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

    private void btnOk_Click(object sender, EventArgs e)
    {
      string WeekNo = txtNo.Text.Trim();
      string WeekName = txtName.Text.Trim();
      if (!Pub.CheckTextMaxLength(label1.Text, WeekNo, txtNo.MaxLength)) return;
      if (!Pub.CheckTextMaxLength(label2.Text, WeekName, txtName.MaxLength)) return;
      if (WeekNo == "")
      {
        txtNo.Focus();
        ShowErrorEnterCorrect(label1.Text);
        return;
      }
      if (WeekName == "")
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
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002017, new string[] { "7", WeekNo }));
          if (dr.Read())
          {
            IsOk = false;
            txtNo.Focus();
            ShowErrorCannotRepeated(label1.Text);
          }
          else
          {
            sql.Add(Pub.GetSQL(DBCode.DB_002017, new string[] { "9", WeekNo, WeekName }));
          }
        }
        else
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002016, new string[] { "8", SysID, WeekNo }));
          if (dr.Read())
          {
            IsOk = false;
            txtNo.Focus();
            ShowErrorCannotRepeated(label1.Text);
          }
          else
          {
            sql.Add(Pub.GetSQL(DBCode.DB_002017, new string[] { "10", WeekNo, WeekName, SysID }));
            sql.Add(Pub.GetSQL(DBCode.DB_002017, new string[] { "11", SysID }));
          }
        }
        if (IsOk)
        {
          ComboBox cbb;
          string TimeID = "";
          string TypeSysID = "";
          for (int i = 1; i <= 7; i++)
          {
            cbb = (ComboBox)this.Controls["cbbTime" + i.ToString()];
            TimeID = ((TCommonType)cbb.Items[cbb.SelectedIndex]).id;
            if (TimeID == "") TimeID = "0";
            cbb = (ComboBox)this.Controls["cbbType" + i.ToString()];
            TypeSysID = ((TCommonType)cbb.Items[cbb.SelectedIndex]).sysID;
            sql.Add(Pub.GetSQL(DBCode.DB_002017, new string[] { "12", i.ToString(), TimeID, TypeSysID, WeekNo }));
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