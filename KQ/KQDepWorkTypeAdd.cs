using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmKQDepWorkTypeAdd : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "KQDepWorkTypeAdd";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      groupBox1.Enabled = SysID == "";
      txtDepartID.Enabled = groupBox1.Enabled;
      btnSelectDepart.Enabled = groupBox1.Enabled;
      btnSelectDepart.Visible = btnSelectDepart.Enabled;
      txtDepartName.Enabled = groupBox1.Enabled;
      SetTextboxNumber(txtDays);
      InitDepartTreeView(tvDepart);
      LoadData();
    }

    public frmKQDepWorkTypeAdd(string title, string CurrentTool, string GUID)
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
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002019, new string[] { "4", SysID }));
          if (dr.Read())
          {
            txtDepartID.Text = dr["DepartID"].ToString();
            txtDepartID.Tag = dr["DepartSysID"].ToString();
            txtDepartName.Text = dr["DepartName"].ToString();
            for (int i = 0; i < cbbShiftNo.Items.Count; i++)
            {
              if (((TCommonType)cbbShiftNo.Items[i]).id == dr["ShiftNo"].ToString())
              {
                cbbShiftNo.SelectedIndex = i;
                break;
              }
            }
            chkOtIsHaveBar.Checked = dr["DepOtIsHaveBar"].ToString().ToUpper() == "Y";
            chkIsPressed.Checked = dr["DepIsPressed"].ToString().ToUpper() == "Y";
            int index = 0;
            int.TryParse(dr["DepRest"].ToString(), out index);
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
                if (((TCommonType)cbbUnit.Items[i]).id == dr["DepTimeWorkUnit"].ToString())
                {
                  cbbUnit.SelectedIndex = i;
                  break;
                }
              }
              txtDays.Text = dr["DepRestDays"].ToString();
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

    private void btnSelectDepart_Click(object sender, EventArgs e)
    {
      frmPubSelectDepart frm = new frmPubSelectDepart(false);
      if (frm.ShowDialog() == DialogResult.OK)
      {
        txtDepartID.Text = frm.DepartID;
        txtDepartID.Tag = frm.DepartSysID;
        txtDepartName.Text = frm.DepartName;
      }
    }

    private void txtDepartID_Leave(object sender, EventArgs e)
    {
      txtDepartID.Tag = "";
      txtDepartName.Text = "";
      if (txtDepartID.Text.Trim() != "")
      {
        string DepartSysID = "";
        string DepartName = "";
        if (db.GetDepartInfo(txtDepartID.Text.Trim(), ref DepartSysID, ref DepartName))
        {
          txtDepartID.Tag = DepartSysID;
          txtDepartName.Text = DepartName;
        }
        else
        {
          txtDepartID.Text = "";
          Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorDepartNotExists", ""));
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

    private void tvDepart_AfterCheck(object sender, TreeViewEventArgs e)
    {
      if (optSelectAll.Checked) SelectTreeNode(e.Node);
    }

    private void GetSql(string DepartSysID, string ShiftNo, string OtIsHaveBar, string IsPressed, int Rest,
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
        tmp = Pub.GetSQL(DBCode.DB_002019, new string[] { "5", DepartSysID });
        tmp1 = Pub.GetSQL(DBCode.DB_002019, new string[] { "1", DepartSysID, ShiftNo, OtIsHaveBar, IsPressed, 
          Rest.ToString(), WeekEndSysID, HolidaySysID, WorkUnit, RestDays });
        sql.Add(tmp);
        sql.Add(tmp1);
      }
      else
      {
        tmp = Pub.GetSQL(DBCode.DB_002019, new string[] { "2", ShiftNo, OtIsHaveBar, IsPressed, Rest.ToString(), 
          WeekEndSysID, HolidaySysID, WorkUnit, RestDays, SysID });
        sql.Add(tmp);
      }
    }

    private void GetNodeSql(TreeNode node, string DepartSysID, string ShiftNo, string OtIsHaveBar, string IsPressed, int Rest,
      string WeekEndSysID, string HolidaySysID, string WorkUnit, int Days, ref List<string> sql)
    {
      if (node.Checked && (node.Tag.ToString() != DepartSysID))
      {
        GetSql(node.Tag.ToString(), ShiftNo, OtIsHaveBar, IsPressed, Rest, WeekEndSysID, HolidaySysID, WorkUnit, Days, ref sql);
      }
      for (int i = 0; i < node.Nodes.Count; i++)
      {
        GetNodeSql(node.Nodes[i], DepartSysID, ShiftNo, OtIsHaveBar, IsPressed, Rest, WeekEndSysID, HolidaySysID, 
          WorkUnit, Days, ref sql);
      }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (!CheckDepart()) return;
      string DepartSysID = txtDepartID.Tag.ToString();
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
        GetSql(DepartSysID, ShiftNo, OtIsHaveBar, IsPressed, Rest, WeekEndSysID, HolidaySysID, WorkUnit, Days, ref sql);
        for (int i = 0; i < tvDepart.Nodes.Count; i++)
        {
          GetNodeSql(tvDepart.Nodes[i], DepartSysID, ShiftNo, OtIsHaveBar, IsPressed, Rest, WeekEndSysID, HolidaySysID, 
            WorkUnit, Days, ref sql);
        }
      }
      else
      {
        GetSql(DepartSysID, ShiftNo, OtIsHaveBar, IsPressed, Rest, WeekEndSysID, HolidaySysID, WorkUnit, Days, ref sql);
      }
      if (db.ExecSQL(sql) != 0) return;
      db.WriteSYLog(this.Text, CurrentOprt, sql);
      Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private bool CheckDepart()
    {
      txtDepartID.Tag = "";
      if (txtDepartID.Text.Trim() == "")
      {
        txtDepartID.Focus();
        ShowErrorEnterCorrect(label2.Text);
        return false;
      }
      string DepartSysID = "";
      string DepartName = "";
      if (!db.GetDepartInfo(txtDepartID.Text.Trim(), ref DepartSysID, ref DepartName))
      {
        txtDepartID.Focus();
        Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorDepartNotExists", ""));
        return false;
      }
      txtDepartID.Tag = DepartSysID;
      return true;
    }
  }
}