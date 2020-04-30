using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmKQEmpTripAdd : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "KQEmpTripAdd";
      CreateCardGridView(cardGrid);
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      toolTip.SetToolTip(txtQuickSearch, Pub.GetResText(formCode, "lblQuickSearchToolTip", ""));
      dtpStart.Value = DateTime.Now.Date.AddHours(8);
      dtpEnd.Value = DateTime.Now.Date.AddHours(17).AddMinutes(30);
      groupBox1.Enabled = SysID == "";
      txtNo.Enabled = groupBox1.Enabled;
      txtEmpNo.Enabled = groupBox1.Enabled;
      btnSelectEmp.Enabled = groupBox1.Enabled;
      btnSelectEmp.Visible = btnSelectEmp.Enabled;
      txtEmpName.Enabled = groupBox1.Enabled;
      txtDepart.Enabled = groupBox1.Enabled;
      LoadData();
    }

    public frmKQEmpTripAdd(string title, string CurrentTool, string GUID)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      InitializeComponent();
    }

    private void LoadData()
    {
      cbbType.Items.Clear();
      TCommonType ctype;
      DataTableReader dr = null;
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002002, new string[] { "200" }));
        while (dr.Read())
        {
          ctype = new TCommonType(dr["TripTypeSysID"].ToString(), dr["TripTypeNo"].ToString(),
            dr["TripTypeName"].ToString(), true);
          cbbType.Items.Add(ctype);
        }
        if (SysID == "")
        {
          if (cbbType.Items.Count > 0) cbbType.SelectedIndex = 0;
          txtNo.Text = GetBillNo();
        }
        else
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002009, new string[] { "5", SysID }));
          if (dr.Read())
          {
            txtNo.Text = dr["TripBillNo"].ToString();
            txtEmpNo.Text = dr["EmpNo"].ToString();
            txtEmpNo.Tag = dr["EmpSysID"].ToString();
            txtEmpName.Text = dr["EmpName"].ToString();
            txtDepart.Text = "[" + dr["DepartID"].ToString() + "]" + dr["DepartName"].ToString();
            DateTime dt = new DateTime();
            DateTime.TryParse(dr["TripStartDate"].ToString(), out dt);
            string[] tt = dr["TripStartTime"].ToString().Split(':');
            dt = dt.AddHours(Convert.ToDouble(tt[0])).AddMinutes(Convert.ToDouble(tt[1]));
            dtpStart.Value = dt;
            DateTime.TryParse(dr["TripEndDate"].ToString(), out dt);
            tt = dr["TripEndTime"].ToString().Split(':');
            dt = dt.AddHours(Convert.ToDouble(tt[0])).AddMinutes(Convert.ToDouble(tt[1]));
            dtpEnd.Value = dt;
            for (int i = 0; i < cbbType.Items.Count; i++)
            {
              if (((TCommonType)cbbType.Items[i]).sysID == dr["TripTypeSysID"].ToString())
              {
                cbbType.SelectedIndex = i;
                break;
              }
            }
            txtReason.Text = dr["TripReason"].ToString();
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

    private void btnQuickSearch_Click(object sender, EventArgs e)
    {
      QuickSearchNormalEmp(btnQuickSearch.Text, cardGrid);
    }

    private void txtQuickSearch_KeyDown(object sender, KeyEventArgs e)
    {
      QuickSearchNormalEmp(txtQuickSearch, e, cardGrid);
    }

    private void btnViewShift_Click(object sender, EventArgs e)
    {
      if (!CheckEmp()) return;
      frmKQEmpShiftView frm = new frmKQEmpShiftView(this.Text, btnViewShift.Text, txtEmpNo.Tag.ToString(),
        dtpStart.Value, dtpEnd.Value);
      frm.ShowDialog();
    }

    private void GetSql(int days, string EmpSysID, string BillNo, string TypeSysID, string Reason, ref List<string> sql)
    {
      string tmp = "";
      if (SysID == "")
      {
        tmp = Pub.GetSQL(DBCode.DB_002009, new string[] { "7", BillNo, EmpSysID, 
          dtpStart.Value.ToString(SystemInfo.SQLDateFMT), dtpStart.Value.ToString("HH:mm"), 
          dtpEnd.Value.ToString(SystemInfo.SQLDateFMT), dtpEnd.Value.ToString("HH:mm"), 
          TypeSysID, Reason, OprtInfo.OprtSysID });
        sql.Add(tmp);
      }
      else
      {
        tmp = Pub.GetSQL(DBCode.DB_002009, new string[] { "8", dtpStart.Value.ToString(SystemInfo.SQLDateFMT), 
          dtpStart.Value.ToString("HH:mm"), dtpEnd.Value.ToString(SystemInfo.SQLDateFMT), 
          dtpEnd.Value.ToString("HH:mm"), TypeSysID, Reason, OprtInfo.OprtSysID, SysID });
        sql.Add(tmp);
      }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (!CheckEmp()) return;
      if (dtpStart.Value > dtpEnd.Value)
      {
        dtpStart.Focus();
        Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorStartTimeBegreater", ""));
        return;
      }
      if (cbbType.SelectedIndex == -1)
      {
        cbbType.Focus();
        ShowErrorSelectCorrect(label7.Text);
        return;
      }
      string BillNo = txtNo.Text;
      string EmpSysID = txtEmpNo.Tag.ToString();
      string TypeSysID = ((TCommonType)cbbType.Items[cbbType.SelectedIndex]).sysID;
      string Reason = txtReason.Text.Trim();
      if (!Pub.CheckTextMaxLength(label8.Text, Reason, txtReason.MaxLength)) return;
      List<string> sql = new List<string>();
      int days = (int)Pub.DateDiff(DateInterval.Day, dtpStart.Value.Date, dtpEnd.Value.Date);
      DataTableReader dr = null;
      bool IsError = false;
      bool IsExists = true;
      try
      {
        if (SysID == "")
        {
          while (IsExists)
          {
            dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002009, new string[] { "6", BillNo }));
            if (!dr.Read()) IsExists = false;
            dr.Close();
            if (IsExists) BillNo = GetBillNo();
          }
          GetSql(days, EmpSysID, BillNo, TypeSysID, Reason, ref sql);
          if (cardGrid.DataSource != null)
          {
            DataTable dtGrid = (DataTable)cardGrid.DataSource;
            for (int i = 0; i < dtGrid.Rows.Count; i++)
            {
              if (dtGrid.Rows[i]["EmpSysID"].ToString() == EmpSysID) continue;
              GetSql(days, dtGrid.Rows[i]["EmpSysID"].ToString(), BillNo, TypeSysID, Reason, ref sql);
            }
          }
        }
        else
        {
          GetSql(days, EmpSysID, BillNo, TypeSysID, Reason, ref sql);
        }
      }
      catch (Exception E)
      {
        IsError = true;
        Pub.ShowErrorMsg(E);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      if (IsError) return;
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

    private string GetBillNo()
    {
      string ret = "";
      DataTableReader dr = null;
      string BillNo = "CC-" + DateTime.Now.ToString(SystemInfo.DateFormatNo) + "-";
      try
      {
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002009, new string[] { "4", BillNo }));
        int No = 1;
        if (dr.Read()) int.TryParse(dr["MaxNo"].ToString(), out No);
        ret = BillNo + No.ToString("000");
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
      return ret;
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      cardGrid.DataSource = null;
    }
  }
}