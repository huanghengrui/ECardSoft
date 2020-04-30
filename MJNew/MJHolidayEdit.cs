using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmMJHolidayEdit : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "MJHolidayEdit";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      LoadData();
    }

    public frmMJHolidayEdit(string title, string CurrentTool, string GUID)
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
      cbbTimeNo.Items.Clear();
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003003, new string[] { "7" }));
        while (dr.Read())
        {
          ctype = new TCommonType(dr["MacTimeSysID"].ToString(), dr["MacTimeNo"].ToString(), dr["MacTimeName"].ToString());
          cbbTimeNo.Items.Add(ctype);
        }
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003002, new string[] { "1", SysID }));
        if (dr.Read())
        {
          txtID.Text = dr["MJHoliID"].ToString();
          chkApply.Checked = Convert.ToBoolean(dr["MJHoliIsApply"].ToString());
          DateTime d = new DateTime();
          if (DateTime.TryParse(dr["MJHoliBeginDate"].ToString(), out d)) txtBegin.Text = d.ToString();
          if (DateTime.TryParse(dr["MJHoliEndDate"].ToString(), out d)) txtEnd.Text = d.ToString();
          SetTimeIndex(cbbTimeNo, dr["MacTimeNo"].ToString());
          txtMemo.Text = dr["MJHoliMemo"].ToString();
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

    private void btnBegin_Click(object sender, EventArgs e)
    {
      DateTime d = new DateTime();
      DateTime.TryParse(txtBegin.Text.Trim(), out d);
      if (Pub.GetSelectDate(true, ref d)) txtBegin.Text = d.ToString();
    }

    private void btnEnd_Click(object sender, EventArgs e)
    {
      DateTime d = new DateTime();
      DateTime.TryParse(txtEnd.Text.Trim(), out d);
      if (Pub.GetSelectDate(true, ref d)) txtEnd.Text = d.ToString();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      byte Apply = Convert.ToByte(chkApply.Checked);
      string BeginDate = "NULL";
      DateTime d = new DateTime();
      if (DateTime.TryParse(txtBegin.Text.Trim(), out d)) BeginDate = "'" + d.ToString(SystemInfo.SQLDateTimeFMT) + "'";
      string EndDate = "NULL";
      if (DateTime.TryParse(txtEnd.Text.Trim(), out d)) EndDate = "'" + d.ToString(SystemInfo.SQLDateTimeFMT) + "'";
      string TimeID = "0";
      if (cbbTimeNo.SelectedIndex >= 0) TimeID = ((TCommonType)cbbTimeNo.Items[cbbTimeNo.SelectedIndex]).id;
      string sql = Pub.GetSQL(DBCode.DB_003002, new string[] { "3", Apply.ToString(), BeginDate, EndDate, TimeID,
        txtMemo.Text.Trim(), SysID });
      try
      {
        db.ExecSQL(sql);
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E, sql);
        return;
      }
      db.WriteSYLog(this.Text, CurrentOprt, sql);
      Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
  }
}