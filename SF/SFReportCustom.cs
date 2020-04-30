using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmSFReportCustom : frmBaseReport
  {
    protected override void InitForm()
    {
      formCode = "SFReportCustom";
      ReportTable = "SF_Report";
      ReportHeader = "SF";
      base.InitForm();
    }

    public frmSFReportCustom()
    {
      InitializeComponent();
    }
  }
}