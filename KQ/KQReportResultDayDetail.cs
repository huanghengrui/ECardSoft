using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmKQReportResultDayDetail : frmBaseForm
  {
    protected override void InitForm()
    {
      formCode = "KQReportResultDayDetail";
      findGrid.AutoGenerateColumns = false;
      base.InitForm();
    }

    public frmKQReportResultDayDetail()
    {
      InitializeComponent();
    }

    public void ShowKQData(string EmpNo, DateTime KQDate)
    {
      string sql = Pub.GetSQL(DBCode.DB_002015, new string[] { "101", EmpNo, KQDate.ToString(SystemInfo.SQLDateFMT) });
      findGrid.DataSource = null;
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        findGrid.DataSource = db.GetDataTable(sql);
      }
      catch (Exception e)
      {
        Pub.ShowErrorMsg(e, sql);
      }
    }

    private void findGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
      e.Cancel = true;
    }
  }
}