using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmKQHolidayAdd : frmBaseDialog
  {
    private List<TCommonType> HolidayTimeList = new List<TCommonType>();
    private List<TCommonType> HoliDayOtTypeList = new List<TCommonType>();

    protected override void InitForm()
    {
      formCode = "KQHolidayAdd";
      dataGrid.AutoGenerateColumns = false;
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      LoadData();
      RefreshButton();
    }

    public frmKQHolidayAdd(string title, string CurrentTool, string GUID)
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
      try
      {
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002016, new string[] { "5" }));
        while (dr.Read())
        {
          HolidayTimeList.Add(new TCommonType(dr["HolidayTimeSegSysID"].ToString(), dr["HolidayTimeSegID"].ToString(),
            dr["HolidayTimeSegName"].ToString(), true));
        }
        dr.Close();
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002002, new string[] { "0" }));
        while (dr.Read())
        {
          HoliDayOtTypeList.Add(new TCommonType(dr["OtTypeSysID"].ToString(), dr["OtTypeNo"].ToString(),
            dr["OtTypeName"].ToString(), true));
        }
        dr.Close();
        if (SysID != "")
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002016, new string[] { "6", SysID }));
          if (dr.Read())
          {
            txtNo.Text = dr["HolidayNo"].ToString();
            txtName.Text = dr["HolidayName"].ToString();
          }
        }
        dataGrid.DataSource = db.GetDataTable(Pub.GetSQL(DBCode.DB_002016, new string[] { "7", SysID }));
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
      string HoliNo = txtNo.Text.Trim();
      string HoliName = txtName.Text.Trim();
      if (!Pub.CheckTextMaxLength(label1.Text, HoliNo, txtNo.MaxLength)) return;
      if (!Pub.CheckTextMaxLength(label2.Text, HoliName, txtName.MaxLength)) return;
      if (HoliNo == "")
      {
        txtNo.Focus();
        ShowErrorEnterCorrect(label1.Text);
        return;
      }
      if (HoliName == "")
      {
        txtName.Focus();
        ShowErrorEnterCorrect(label2.Text);
        return;
      }
      DataTableReader dr = null;
      bool IsOk = true;
      List<string> sql = new List<string>();
      DateTime d = new DateTime();
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        if (SysID == "")
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002016, new string[] { "8", HoliNo }));
          if (dr.Read())
          {
            IsOk = false;
            txtNo.Focus();
            ShowErrorCannotRepeated(label1.Text);
          }
          else
          {
            sql.Add(Pub.GetSQL(DBCode.DB_002016, new string[] { "10", HoliNo, HoliName }));
          }
        }
        else
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002016, new string[] { "9", SysID, HoliNo }));
          if (dr.Read())
          {
            IsOk = false;
            txtNo.Focus();
            ShowErrorCannotRepeated(label1.Text);
          }
          else
          {
            sql.Add(Pub.GetSQL(DBCode.DB_002016, new string[] { "11", HoliNo, HoliName, SysID }));
            sql.Add(Pub.GetSQL(DBCode.DB_002016, new string[] { "12", SysID }));
          }
        }
        if (IsOk)
        {
          DataTable dt = (DataTable)dataGrid.DataSource;
          for (int i = 0; i < dt.Rows.Count; i++)
          {
            DateTime.TryParse(dt.Rows[i]["HolidayDate"].ToString(), out d);
            sql.Add(Pub.GetSQL(DBCode.DB_002016, new string[] { "13", d.ToString(SystemInfo.SQLDateFMT), 
              dt.Rows[i]["HolidayDName"].ToString(), GetHolidayTimeID(dt.Rows[i]["HolidayTime"].ToString()), 
              GetHoliDayOtTypeSysID(dt.Rows[i]["HoliDayOtType"].ToString()), HoliNo }));
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

    private string GetHolidayTimeID(string value)
    {
      string ret = "";
      for (int i = 0; i < HolidayTimeList.Count; i++)
      {
        if (HolidayTimeList[i].name == value)
        {
          ret = HolidayTimeList[i].id;
          break;
        }
      }
      if (ret == "") ret = "0";
      return ret;
    }

    private string GetHoliDayOtTypeSysID(string value)
    {
      string ret = "";
      for (int i = 0; i < HoliDayOtTypeList.Count; i++)
      {
        if (HoliDayOtTypeList[i].name == value)
        {
          ret = HoliDayOtTypeList[i].sysID;
          break;
        }
      }
      return ret;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      frmKQHolidayAddA frm = new frmKQHolidayAddA(button1.Text, HolidayTimeList, HoliDayOtTypeList);
      if (frm.ShowDialog() != DialogResult.OK) return;
      DateTime d = frm.StartDate;
      int days = (int)Pub.DateDiff(DateInterval.Day, d, frm.EndDate);
      DataTable dt = (DataTable)dataGrid.DataSource;
      for (int i = 0; i <= days; i++)
      {
        DataRow da = dt.NewRow();
        da["HolidayDate"] = d.AddDays(i);
        da["HolidayDName"] = frm.HoliName;
        da["HolidayTime"] = frm.HoliTime;
        da["HoliDayOtType"] = frm.OtType;
        dt.Rows.Add(da);
      }
      RefreshButton();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      DataTable dt = (DataTable)dataGrid.DataSource;
      dt.Rows.RemoveAt(dataGrid.SelectedRows[0].Index);
      RefreshButton();
    }

    private void RefreshButton()
    {
      button1.Enabled = true;
      button2.Enabled = dataGrid.RowCount > 0;
    }
  }
}