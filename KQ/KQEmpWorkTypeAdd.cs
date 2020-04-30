using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmKQEmpWorkTypeAdd : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "KQEmpWorkTypeAdd";
      CreateCardGridView(cardGrid);
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      toolTip.SetToolTip(txtQuickSearch, Pub.GetResText(formCode, "lblQuickSearchToolTip", ""));
      groupBox1.Enabled = SysID == "";
      txtEmpNo.Enabled = groupBox1.Enabled;
      btnSelectEmp.Enabled = groupBox1.Enabled;
      btnSelectEmp.Visible = btnSelectEmp.Enabled;
      txtEmpName.Enabled = groupBox1.Enabled;
      txtDepart.Enabled = groupBox1.Enabled;
      SetTextboxNumber(txtDays);
      LoadData();
    }

    public frmKQEmpWorkTypeAdd(string title, string CurrentTool, string GUID)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      InitializeComponent();
    }

    private void LoadData()
    {
      cbbRest.Items.Clear();
      cbbRest.Items.Add(Pub.GetResText(formCode, "NormalRest", ""));
      cbbRest.Items.Add(Pub.GetResText(formCode, "TurnsoffRest", ""));
      cbbShiftNo.Items.Clear();
      cbbWeek.Items.Clear();
      cbbHoli.Items.Clear();
      cbbUnit.Items.Clear();
      TCommonType ctype = new TCommonType("M", "M", Pub.GetResText(formCode, "RestMonth", ""));
      cbbUnit.Items.Add(ctype);
      ctype = new TCommonType("W", "W", Pub.GetResText(formCode, "RestWeek", ""));
      cbbUnit.Items.Add(ctype);
      ctype = new TCommonType("", "", "", true);
      cbbShiftNo.Items.Add(ctype);
      cbbWeek.Items.Add(ctype);
      cbbHoli.Items.Add(ctype);
      DataTableReader dr = null;
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002004, new string[] { "3" }));
        while (dr.Read())
        {
          ctype = new TCommonType(dr["GUID"].ToString(), dr["ShiftNo"].ToString(), dr["ShiftName"].ToString(), true);
          cbbShiftNo.Items.Add(ctype);
        }
        dr.Close();
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002017, new string[] { "0" }));
        while (dr.Read())
        {
          ctype = new TCommonType(dr["WeekEndSysID"].ToString(), dr["WeekEndNo"].ToString(), dr["WeekEndName"].ToString(), true);
          cbbWeek.Items.Add(ctype);
        }
        dr.Close();
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002016, new string[] { "0" }));
        while (dr.Read())
        {
          ctype = new TCommonType(dr["HolidaySysID"].ToString(), dr["HolidayNo"].ToString(), dr["HolidayName"].ToString(), true);
          cbbHoli.Items.Add(ctype);
        }
        cbbShiftNo.SelectedIndex = 0;
        cbbRest.SelectedIndex = 0;
        cbbWeek.SelectedIndex = 0;
        cbbHoli.SelectedIndex = 0;
        cbbUnit.SelectedIndex = 0;
        if (SysID != "")
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002018, new string[] { "4", SysID }));
          if (dr.Read())
          {
            txtEmpNo.Text = dr["EmpNo"].ToString();
            txtEmpNo.Tag = dr["EmpSysID"].ToString();
            txtEmpName.Text = dr["EmpName"].ToString();
            txtDepart.Text = "[" + dr["DepartID"].ToString() + "]" + dr["DepartName"].ToString();
            for (int i = 0; i < cbbShiftNo.Items.Count; i++)
            {
              if (((TCommonType)cbbShiftNo.Items[i]).id == dr["ShiftNo"].ToString())
              {
                cbbShiftNo.SelectedIndex = i;
                break;
              }
            }
            chkOtIsHaveBar.Checked = dr["EmpOtIsHaveBar"].ToString().ToUpper() == "Y";
            chkIsPressed.Checked = dr["EmpIsPressed"].ToString().ToUpper() == "Y";
            int index = 0;
            int.TryParse(dr["EmpRest"].ToString(), out index);
            cbbRest.SelectedIndex = index - 1;
            if (cbbRest.SelectedIndex == 0)
            {
              for (int i = 0; i < cbbWeek.Items.Count; i++)
              {
                if (((TCommonType)cbbWeek.Items[i]).sysID == dr["WeekEndSysID"].ToString())
                {
                  cbbWeek.SelectedIndex = i;
                  break;
                }
              }
              for (int i = 0; i < cbbHoli.Items.Count; i++)
              {
                if (((TCommonType)cbbHoli.Items[i]).sysID == dr["HolidaySysID"].ToString())
                {
                  cbbHoli.SelectedIndex = i;
                  break;
                }
              }
            }
            else
            {
              for (int i = 0; i < cbbUnit.Items.Count; i++)
              {
                if (((TCommonType)cbbUnit.Items[i]).id == dr["EmpTimeWorkUnit"].ToString())
                {
                  cbbUnit.SelectedIndex = i;
                  break;
                }
              }
              txtDays.Text = dr["EmpRestDays"].ToString();
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

    private void btnSelectEmp_Click(object sender, EventArgs e)
    {
      frmPubSelectEmp frm = new frmPubSelectEmp(false);
      if (frm.ShowDialog() == DialogResult.OK)
      {
        txtEmpNo.Text = frm.EmpNo;
        txtEmpNo_Leave(null, null);
      }
    }

    private void txtEmpNo_Leave(object sender, EventArgs e)
    {
      txtEmpNo.Tag = "";
      txtEmpName.Text = "";
      txtDepart.Text = "";
      if (txtEmpNo.Text.Trim() != "")
      {
        string EmpSysID = "";
        string EmpName = "";
        string DepartID = "";
        string DepartName = "";
        if (db.GetEmpInfo(txtEmpNo.Text.Trim(), ref EmpSysID, ref EmpName, ref DepartID, ref DepartName))
        {
          txtEmpNo.Tag = EmpSysID;
          txtEmpName.Text = EmpName;
          txtDepart.Text = "[" + DepartID + "]" + DepartName;
        }
        else
        {
          txtEmpNo.Text = "";
          Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorEmpNotExists", ""));
        }
      }
    }

    private void cbbRest_SelectedIndexChanged(object sender, EventArgs e)
    {
      panel1.Enabled = cbbRest.SelectedIndex == 0;
      panel1.Visible = panel1.Enabled;
      panel2.Enabled = !panel1.Enabled;
      panel2.Visible = panel2.Enabled;
    }

    private void btnQuickSearch_Click(object sender, EventArgs e)
    {
      QuickSearchNormalEmp(btnQuickSearch.Text, cardGrid);
    }

    private void txtQuickSearch_KeyDown(object sender, KeyEventArgs e)
    {
      QuickSearchNormalEmp(txtQuickSearch, e, cardGrid);
    }

    private void GetSql(string EmpSysID, string ShiftNo, string OtIsHaveBar, string IsPressed, int Rest,
      string WeekEndSysID, string HolidaySysID, string WorkUnit, int Days, ref List<string> sql)
    {
      string RestDays = Days == 0 ? "" : Days.ToString();
      if (Rest == 1)
      {
        RestDays = "";
        WorkUnit = "";
      }
      else
      {
        WeekEndSysID = "";
        HolidaySysID = "";
      }
      WeekEndSysID = WeekEndSysID == "" ? WeekEndSysID = "NULL" : "'" + WeekEndSysID + "'";
      HolidaySysID = HolidaySysID == "" ? HolidaySysID = "NULL" : "'" + HolidaySysID + "'";
      WorkUnit = WorkUnit == "" ? WorkUnit = "NULL" : "'" + WorkUnit + "'";
      if (RestDays == "") RestDays = "NULL";
      string tmp = "", tmp1 = "";
      if (SysID == "")
      {
        tmp = Pub.GetSQL(DBCode.DB_002018, new string[] { "5", EmpSysID });
        sql.Add(tmp);
        tmp1 = Pub.GetSQL(DBCode.DB_002018, new string[] { "1", EmpSysID, ShiftNo, OtIsHaveBar, IsPressed, 
          Rest.ToString(), WeekEndSysID, HolidaySysID, WorkUnit, RestDays });
        sql.Add(tmp);
        sql.Add(tmp1);
      }
      else
      {
        tmp = Pub.GetSQL(DBCode.DB_002018, new string[] { "2", ShiftNo, OtIsHaveBar, IsPressed, Rest.ToString(), 
          WeekEndSysID, HolidaySysID, WorkUnit, RestDays, SysID });
        sql.Add(tmp);
      }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (!CheckEmp()) return;
      string EmpSysID = txtEmpNo.Tag.ToString();
      string ShiftNo = ((TCommonType)cbbShiftNo.Items[cbbShiftNo.SelectedIndex]).id;
      string OtIsHaveBar = chkOtIsHaveBar.Checked ? "Y" : "N";
      string IsPressed = chkIsPressed.Checked ? "Y" : "N";
      int Rest = cbbRest.SelectedIndex + 1;
      string WeekEndSysID = ((TCommonType)cbbWeek.Items[cbbWeek.SelectedIndex]).sysID;
      string HolidaySysID = ((TCommonType)cbbHoli.Items[cbbHoli.SelectedIndex]).sysID;
      string WorkUnit = ((TCommonType)cbbUnit.Items[cbbUnit.SelectedIndex]).id;
      int Days = 0;
      int.TryParse(txtDays.Text.Trim(), out Days);
      List<string> sql = new List<string>();
      if (SysID == "")
      {
        GetSql(EmpSysID, ShiftNo, OtIsHaveBar, IsPressed, Rest, WeekEndSysID, HolidaySysID, WorkUnit, Days, ref sql);
        if (cardGrid.DataSource != null)
        {
          DataTable dtGrid = (DataTable)cardGrid.DataSource;
          for (int i = 0; i < dtGrid.Rows.Count; i++)
          {
            if (dtGrid.Rows[i]["EmpSysID"].ToString() == EmpSysID) continue;
            GetSql(dtGrid.Rows[i]["EmpSysID"].ToString(), ShiftNo, OtIsHaveBar, IsPressed, Rest, WeekEndSysID,
              HolidaySysID, WorkUnit, Days, ref sql);
          }
        }
      }
      else
      {
        GetSql(EmpSysID, ShiftNo, OtIsHaveBar, IsPressed, Rest, WeekEndSysID, HolidaySysID, WorkUnit, Days, ref sql);
      }
      if (db.ExecSQL(sql) != 0) return;
      db.WriteSYLog(this.Text, CurrentOprt, sql);
      Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private bool CheckEmp()
    {
      txtEmpNo.Tag = "";
      if (txtEmpNo.Text.Trim() == "")
      {
        txtEmpNo.Focus();
        ShowErrorEnterCorrect(label2.Text);
        return false;
      }
      string EmpSysID = "";
      string EmpName = "";
      string DepartID = "";
      string DepartName = "";
      if (!db.GetEmpInfo(txtEmpNo.Text.Trim(), ref EmpSysID, ref EmpName, ref DepartID, ref DepartName))
      {
        txtEmpNo.Focus();
        Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorEmpNotExists", ""));
        return false;
      }
      txtEmpNo.Tag = EmpSysID;
      return true;
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      cardGrid.DataSource = null;
    }
  }
}