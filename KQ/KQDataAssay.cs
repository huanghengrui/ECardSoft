using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmKQDataAssay : frmBaseDialog
  {
    private bool IsWorking = false;

    protected override void InitForm()
    {
      formCode = "KQDataAssay";
      CreateCardGridView(cardGrid);
      base.InitForm();
      this.Text = Pub.GetResText(formCode, "mnu" + formCode, "", new string[] { "Main" });
      dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
      dtpEnd.Value = DateTime.Now.Date;
      IsWorking = false;
      RefreshControl();
    }

    public frmKQDataAssay()
    {
      InitializeComponent();
    }

    private void RadioButton_Click(object sender, EventArgs e)
    {
      groupBox1.Enabled = rbEmp.Checked && !IsWorking;
    }

    private void btnQuickSearch_Click(object sender, EventArgs e)
    {
      QuickSearchNormalEmp(btnQuickSearch.Text, cardGrid);
    }

    private void txtQuickSearch_KeyDown(object sender, KeyEventArgs e)
    {
      QuickSearchNormalEmp(txtQuickSearch, e, cardGrid);
    }

    private void RefreshControl()
    {
      label1.Enabled = !IsWorking;
      dtpStart.Enabled = !IsWorking;
      label2.Enabled = !IsWorking;
      dtpEnd.Enabled = !IsWorking;
      rbAll.Enabled = !IsWorking;
      rbEmp.Enabled = !IsWorking;
      button1.Enabled = !IsWorking;
      button2.Enabled = IsWorking;
      btnCancel.Enabled = !IsWorking;
      RadioButton_Click(null, null);
    }

    private void frmKQDataAssay_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (IsWorking) e.Cancel = true;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (!db.CheckOprtRole(formCode, "M")) return;
      if (rbEmp.Checked && (cardGrid.RowCount == 0))
      {
        Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorSelectEmp", ""));
        return;
      }
      IsWorking = true;
      RefreshControl();
      string msg = Pub.GetResText(formCode, "Msg001", "");
      bool IsError = false;
      DateTime StartTime = DateTime.Now;
      DataTable dt = null;
      label3.Text = msg;
      progBar.Value = 0;
      string EmpSysID;
      DateTime StartDate = dtpStart.Value.Date;
      DateTime EndDate = dtpEnd.Value.Date;
      DataTableReader dr = null;
      int empCount = 0;
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        if (rbAll.Checked)
        {
          dt = db.GetDataTable(Pub.GetSQL(DBCode.DB_001003, new string[] { "0", OprtInfo.DepartPower }));
          for (int i = 0; i < dt.Rows.Count; i++)
          {
            label3.Text = msg + string.Format("{0}/{1}", i + 1, dt.Rows.Count) + "  [" +
              dt.Rows[i]["DepartID"].ToString() + "]" + dt.Rows[i]["DepartName"].ToString() + " - " +
              dt.Rows[i]["EmpNo"].ToString() + "]" + dt.Rows[i]["EmpName"].ToString() + "  " +
              Pub.GetDateDiffTimes(StartTime, DateTime.Now, true);
            Application.DoEvents();
            EmpSysID = dt.Rows[i]["EmpSysID"].ToString();
            if (!CalcEmpData(EmpSysID, StartDate, EndDate))
            {
              IsError = true;
              break;
            }
            empCount += 1;
            progBar.Value = (i + 1) * 100 / dt.Rows.Count;
            if (!IsWorking) break;
            Application.DoEvents();
          }
        }
        else
        {
          DataTable dtGrid = (DataTable)cardGrid.DataSource;
          for (int i = 0; i < dtGrid.Rows.Count; i++)
          {
            label3.Text = msg + string.Format("{0}/{1}", i + 1, cardGrid.RowCount) + "  [" +
              dtGrid.Rows[i]["DepartID"].ToString() + "]" + dtGrid.Rows[i]["DepartName"].ToString() + " - " +
              dtGrid.Rows[i]["EmpNo"].ToString() + "]" + dtGrid.Rows[i]["EmpName"].ToString() + "  " +
              Pub.GetDateDiffTimes(StartTime, DateTime.Now, true);
            Application.DoEvents();
            EmpSysID = dtGrid.Rows[i]["EmpSysID"].ToString();
            if (!CalcEmpData(EmpSysID, StartDate, EndDate))
            {
              IsError = true;
              break;
            }
            empCount += 1;
            progBar.Value = (i + 1) * 100 / cardGrid.RowCount;
            if (!IsWorking) break;
            Application.DoEvents();
          }
        }
      }
      catch (Exception E)
      {
        IsError = true;
        Pub.ShowErrorMsg(E);
      }
      finally
      {
        if (dt != null)
        {
          dt.Clear();
          dt.Reset();
        }
        dt = null;
        if (dr != null) dr.Close();
        dr = null;
      }
      IsWorking = false;
      RefreshControl();
      if (IsError)
        msg = Pub.GetResText(formCode, "Msg003", "");
      else
        msg = Pub.GetResText(formCode, "Msg002", "");
      label3.Text = string.Format(msg, empCount, Pub.GetDateDiffTimes(StartTime, DateTime.Now, true));
    }

    private void button2_Click(object sender, EventArgs e)
    {
      IsWorking = false;
    }

    private bool CalcEmpData(string EmpSysID, DateTime StartDate, DateTime EndDate)
    {
      bool ret = false;
      string strStart = StartDate.ToString(SystemInfo.SQLDateFMT);
      string strEnd = EndDate.ToString(SystemInfo.SQLDateFMT);
      string calcSQL = "";
      string IsAttend = "N";
      DataTableReader dr = null;
      try
      {
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "3", EmpSysID }));
        if (dr.Read()) IsAttend = dr["IsAttend"].ToString();
        dr.Close();
        if (IsAttend == "Y")
        {
          calcSQL = Pub.GetSQL(DBCode.DB_002012, new string[] { "0", EmpSysID, strStart, strEnd });
          db.ExecSQL(calcSQL);
        }
        ret = true;
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E, calcSQL);
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