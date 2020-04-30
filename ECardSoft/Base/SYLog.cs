using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmSYLog : frmBaseMDIChildReportPrint
  {
    protected override void InitForm()
    {
      formCode = "SYLog";
      ReportFile = "SYLog";
      base.InitForm();
      Rectangle rect = Screen.PrimaryScreen.WorkingArea;
      this.Left = rect.Left;
      this.Top = rect.Top;
      this.Width = rect.Width;
      this.Height = rect.Height;
      dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
      dtpEnd.Value = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
      dtpStart.CustomFormat = SystemInfo.DateTimeFormat;
      dtpEnd.CustomFormat = SystemInfo.DateTimeFormat;
      DataTableReader dr = null;
      cbbModule.Items.Clear();
      try
      {
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "4000" }));
        while (dr.Read())
        {
          cbbModule.Items.Add(dr["OprtModule"].ToString());
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
      cbbModule.Items.Insert(0, Pub.GetResText(formCode, "OprtModuleAll", ""));
      cbbModule.SelectedIndex = 0;
    }

    public frmSYLog()
    {
      InitializeComponent();
    }

    protected override void ExecItemRefresh()
    {
      string OprtModule = "";
      if (cbbModule.SelectedIndex > 0) OprtModule = cbbModule.Text;
      QuerySQL = Pub.GetSQL(DBCode.DB_000001, new string[] { "4001",
        dtpStart.Value.ToString(SystemInfo.SQLDateTimeFMT), 
        dtpEnd.Value.ToString(SystemInfo.SQLDateTimeFMT), OprtModule });
      SetReportDate(dispView, label4.Text + ": " + dtpStart.Value.ToString() + " - " + dtpEnd.Value.ToString());
      base.ExecItemRefresh();
      SetReportTitle(dispView, this.Text);
    }
  }
}