using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmMJReportCustom : frmBaseReport
  {
    protected override void InitForm()
    {
      formCode = "MJReportCustom";
      ReportTable = "MJ_Report";
      ReportHeader = "MJ";
      base.InitForm();
    }

    public frmMJReportCustom()
    {
      InitializeComponent();
    }
  }
}