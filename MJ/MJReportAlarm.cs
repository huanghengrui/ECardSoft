using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmMJReportAlarm : frmBaseMDIChildReportPrint
  {
    protected override void InitForm()
    {
      formCode = "MJReportAlarm";
      ReportFile = "MJReportAlarm";
      base.InitForm();
      dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
      dtpEnd.Value = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
      dtpStart.CustomFormat = SystemInfo.DateTimeFormat;
      dtpEnd.CustomFormat = SystemInfo.DateTimeFormat;
      DataTableReader dr = null;
      try
      {
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003001, new string[] { "0" }));
        while (dr.Read())
        {
          clbMacSN.Items.Add(dr["MacSN"].ToString());
          clbMacSN.SetItemChecked(clbMacSN.Items.Count - 1, false);
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
      chkMacSN_CheckedChanged(null, null);
    }

    public frmMJReportAlarm()
    {
      InitializeComponent();
    }

    protected override void ExecItemRefresh()
    {
      string MacSN = "";
      if (chkMacSN.Checked)
      {
        for (int i = 0; i < clbMacSN.Items.Count; i++)
        {
          if (clbMacSN.GetItemChecked(i)) MacSN = MacSN + "'" + clbMacSN.Items[i].ToString() + "',";
        }
        if (MacSN != "") MacSN = MacSN.Substring(0, MacSN.Length - 1);
      }
      QuerySQL = Pub.GetSQL(DBCode.DB_003008, new string[] { "1", MacSN, 
        dtpStart.Value.ToString(SystemInfo.SQLDateTimeFMT), dtpEnd.Value.ToString(SystemInfo.SQLDateTimeFMT) });
      SetReportDate(dispView, label4.Text + ": " + dtpStart.Value.ToString() + " - " + dtpEnd.Value.ToString());
      base.ExecItemRefresh();
      SetReportTitle(dispView, this.Text);
    }

    private void chkMacSN_CheckedChanged(object sender, EventArgs e)
    {
      clbMacSN.Enabled = chkMacSN.Checked;
    }
  }
}