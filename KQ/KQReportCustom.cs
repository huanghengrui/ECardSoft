using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmKQReportCustom : frmBaseReport
  {
    protected override void InitForm()
    {
      formCode = "KQReportCustom";
      ReportTable = "KQ_Report";
      ReportHeader = "KQ";
      CheckForward = false;
      base.InitForm();
    }

    public frmKQReportCustom()
    {
      InitializeComponent();
    }
  }
}

