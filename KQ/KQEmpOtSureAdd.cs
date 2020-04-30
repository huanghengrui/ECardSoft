using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmKQEmpOtSureAdd : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "KQEmpOtSureAdd";
      CreateCardGridView(cardGrid);
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      toolTip.SetToolTip(txtQuickSearch, Pub.GetResText(formCode, "lblQuickSearchToolTip", ""));
      dtpStart.Value = DateTime.Now.Date;
      dtpEnd.Value = DateTime.Now.Date;
      groupBox1.Enabled = SysID == "";
      txtNo.Enabled = groupBox1.Enabled;
      txtEmpNo.Enabled = groupBox1.Enabled;
      btnSelectEmp.Enabled = groupBox1.Enabled;
      btnSelectEmp.Visible = btnSelectEmp.Enabled;
      txtEmpName.Enabled = groupBox1.Enabled;
      txtDepart.Enabled = groupBox1.Enabled;
      label6.Enabled = groupBox1.Enabled;
      dtpEnd.Enabled = groupBox1.Enabled;
      label6.Visible = groupBox1.Enabled;
      dtpEnd.Visible = groupBox1.Enabled;
      LoadData();
      SetTextboxNumber(txtBefore1);
      SetTextboxNumber(txtBefore2);
      SetTextboxNumber(txtBefore3);
      SetTextboxNumber(txtAfter1);
      SetTextboxNumber(txtAfter2);
      SetTextboxNumber(txtAfter3);
    }

    public frmKQEmpOtSureAdd(string title, string CurrentTool, string GUID)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      InitializeComponent();
    }

    private void LoadData()
    {
      cbbOtType1.Items.Clear();
      cbbOtType2.Items.Clear();
      cbbOtType3.Items.Clear();
      TCommonType ctype = new TCommonType("", "", "", true);
      cbbOtType1.Items.Add(ctype);
      cbbOtType2.Items.Add(ctype);
      cbbOtType3.Items.Add(ctype);
      DataTableReader dr = null;
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002002, new string[] { "0" }));
        while (dr.Read())
        {
          ctype = new TCommonType(dr["OtTypeSysID"].ToString(), dr["OtTypeNo"].ToString(),
            dr["OtTypeName"].ToString(), true);
          cbbOtType1.Items.Add(ctype);
          cbbOtType2.Items.Add(ctype);
          cbbOtType3.Items.Add(ctype);
        }
        if (SysID == "")
        {
          cbbInNextDay1.SelectedIndex = 0;
          cbbInNextDay2.SelectedIndex = 0;
          cbbInNextDay3.SelectedIndex = 0;
          cbbOutNextDay1.SelectedIndex = 0;
          cbbOutNextDay2.SelectedIndex = 0;
          cbbOutNextDay3.SelectedIndex = 0;
          if (cbbOtType1.Items.Count > 0) cbbOtType1.SelectedIndex = 0;
          if (cbbOtType2.Items.Count > 0) cbbOtType2.SelectedIndex = 0;
          if (cbbOtType3.Items.Count > 0) cbbOtType3.SelectedIndex = 0;
          txtNo.Text = GetBillNo();
        }
        else
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002010, new string[] { "5", SysID }));
          if (dr.Read())
          {
            txtNo.Text = dr["OTBillNo"].ToString();
            txtEmpNo.Text = dr["EmpNo"].ToString();
            txtEmpNo.Tag = dr["EmpSysID"].ToString();
            txtEmpName.Text = dr["EmpName"].ToString();
            txtDepart.Text = "[" + dr["DepartID"].ToString() + "]" + dr["DepartName"].ToString();
            DateTime dt = new DateTime();
            DateTime.TryParse(dr["OTDate"].ToString(), out dt);
            dtpStart.Value = dt;
            txtReason.Text = dr["OTReason"].ToString();
            TextBox txt;
            MaskedTextBox txtA;
            MaskedTextBox txtB;
            ComboBox cbb;
            int m = 0;
            for (int i = 1; i <= 3; i++)
            {
              txtA = (MaskedTextBox)groupBox2.Controls["txtStartTime" + i.ToString()];
              txtB = (MaskedTextBox)groupBox2.Controls["txtEndTime" + i.ToString()];
              txtA.Text = dr["Ot" + i.ToString() + "StartTimeStr"].ToString();
              txtB.Text = dr["Ot" + i.ToString() + "EndTimeStr"].ToString();
              cbb = (ComboBox)groupBox2.Controls["cbbInNextDay" + i.ToString()];
              cbb.SelectedIndex = 0;
              if (dr["Ot" + i.ToString() + "StartIsNextday"].ToString().ToUpper() == "Y") cbb.SelectedIndex = 1;
              cbb = (ComboBox)groupBox2.Controls["cbbOutNextDay" + i.ToString()];
              cbb.SelectedIndex = 0;
              if (dr["Ot" + i.ToString() + "EndIsNextday"].ToString().ToUpper() == "Y") cbb.SelectedIndex = 1;
              cbb = (ComboBox)groupBox2.Controls["cbbOtType" + i.ToString()];
              cbb.SelectedIndex = 0;
              for (int j = 0; j < cbb.Items.Count; j++)
              {
                if (((TCommonType)cbb.Items[j]).sysID == dr["OtTypeSysID" + i.ToString()].ToString())
                {
                  cbb.SelectedIndex = j;
                  break;
                }
              }
              txt = (TextBox)groupBox2.Controls["txtBefore" + i.ToString()];
              int.TryParse(dr["Ot" + i.ToString() + "Before"].ToString(), out m);
              m /= 60;
              txt.Text = m.ToString();
              txt = (TextBox)groupBox2.Controls["txtAfter" + i.ToString()];
              int.TryParse(dr["Ot" + i.ToString() + "After"].ToString(), out m);
              m /= 60;
              txt.Text = m.ToString();
            }
            chkIsDirect.Checked = dr["OtIsDirectResult"].ToString() == "Y";
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

    private void GetSql(int days, string EmpSysID, string BillNo, string[] TypeSysID, int[] StartTime, int[] EndTime,
      int[] OtBefore, int[] OtAfter, string Reason, ref List<string> sql)
    {
      string tmp = "";
      if (SysID != "")
      {
        tmp = Pub.GetSQL(DBCode.DB_002010, new string[] { "3", EmpSysID, BillNo });
        sql.Add(tmp);
        days = 0;
      }
      DateTime dt = dtpStart.Value.Date;
      string IsDirect = chkIsDirect.Checked ? "Y" : "N";
      for (int i = 0; i <= days; i++)
      {
        tmp = Pub.GetSQL(DBCode.DB_002010, new string[] { "7", BillNo, EmpSysID, 
          dt.AddDays(i).ToString(SystemInfo.SQLDateFMT),
          TypeSysID[0], OtBefore[0].ToString(), StartTime[0].ToString(), EndTime[0].ToString(), OtAfter[0].ToString(), 
          TypeSysID[1], OtBefore[1].ToString(), StartTime[1].ToString(), EndTime[1].ToString(), OtAfter[1].ToString(), 
          TypeSysID[2], OtBefore[2].ToString(), StartTime[2].ToString(), EndTime[2].ToString(), OtAfter[2].ToString(), 
          IsDirect, Reason, OprtInfo.OprtSysID });
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
      string BillNo = txtNo.Text;
      string EmpSysID = txtEmpNo.Tag.ToString();
      string Reason = txtReason.Text.Trim();
      if (!Pub.CheckTextMaxLength(label8.Text, Reason, txtReason.MaxLength)) return;
      string[] TypeSysID = new string[3];
      int[] StartTime = new int[3];
      int[] EndTime = new int[3];
      int[] OtBefore = new int[3];
      int[] OtAfter = new int[3];
      List<string> sql = new List<string>();
      int days = (int)Pub.DateDiff(DateInterval.Day, dtpStart.Value.Date, dtpEnd.Value.Date);
      DataTableReader dr = null;
      bool IsError = false;
      bool IsExists = true;
      TextBox txt;
      MaskedTextBox txtA;
      MaskedTextBox txtB;
      ComboBox cbb;
      const int DaySeconds = 24 * 3600;
      DateTime dt = new DateTime();
      for (int i = 1; i <= 3; i++)
      {
        txtA = (MaskedTextBox)groupBox2.Controls["txtStartTime" + i.ToString()];
        txtB = (MaskedTextBox)groupBox2.Controls["txtEndTime" + i.ToString()];
        if ((txtA.Text == "00:00") && (txtB.Text == "00:00")) continue;
        if (!DateTime.TryParse(txtA.Text, out dt))
        {
          txtA.Focus();
          Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", ""));
          return;
        }
        StartTime[i - 1] = dt.Hour * 3600 + dt.Minute * 60;
        cbb = (ComboBox)groupBox2.Controls["cbbInNextDay" + i.ToString()];
        if (cbb.SelectedIndex == 1) StartTime[i - 1] += DaySeconds;
        if (!DateTime.TryParse(txtB.Text, out dt))
        {
          txtB.Focus();
          Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error002", ""));
          return;
        }
        EndTime[i - 1] = dt.Hour * 3600 + dt.Minute * 60;
        cbb = (ComboBox)groupBox2.Controls["cbbOutNextDay" + i.ToString()];
        if (cbb.SelectedIndex == 1) EndTime[i - 1] += DaySeconds;
        if (StartTime[i - 1] >= EndTime[i - 1])
        {
          txtB.Focus();
          Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error003", ""));
          return;
        }
        cbb = (ComboBox)groupBox2.Controls["cbbOtType" + i.ToString()];
        if (cbb.SelectedIndex < 1)
        {
          cbb.Focus();
          ShowErrorSelectCorrect(label13.Text);
          return;
        }
        TypeSysID[i - 1] = ((TCommonType)cbb.Items[cbb.SelectedIndex]).sysID;
        txt = (TextBox)groupBox2.Controls["txtBefore" + i.ToString()];
        int.TryParse(txt.Text.Trim(), out OtBefore[i - 1]);
        OtBefore[i - 1] *= 60;
        txt = (TextBox)groupBox2.Controls["txtAfter" + i.ToString()];
        int.TryParse(txt.Text.Trim(), out OtAfter[i - 1]);
        OtAfter[i - 1] *= 60;
      }
      try
      {
        if (SysID == "")
        {
          while (IsExists)
          {
            dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002010, new string[] { "6", BillNo }));
            if (!dr.Read()) IsExists = false;
            dr.Close();
            if (IsExists) BillNo = GetBillNo();
          }
          GetSql(days, EmpSysID, BillNo, TypeSysID, StartTime, EndTime, OtBefore, OtAfter, Reason, ref sql);
          if (cardGrid.DataSource != null)
          {
            DataTable dtGrid = (DataTable)cardGrid.DataSource;
            for (int i = 0; i < dtGrid.Rows.Count; i++)
            {
              if (dtGrid.Rows[i]["EmpSysID"].ToString() == EmpSysID) continue;
              GetSql(days, dtGrid.Rows[i]["EmpSysID"].ToString(), BillNo, TypeSysID, StartTime, EndTime, OtBefore,
                OtAfter, Reason, ref sql);
            }
          }
        }
        else
        {
          GetSql(days, EmpSysID, BillNo, TypeSysID, StartTime, EndTime, OtBefore, OtAfter, Reason, ref sql);
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
      string BillNo = "JB-" + DateTime.Now.ToString(SystemInfo.DateFormatNo) + "-";
      try
      {
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002010, new string[] { "4", BillNo }));
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