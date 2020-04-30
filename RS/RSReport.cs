using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmRSReport : frmBaseReport
  {
    protected override void InitForm()
    {
      formCode = "RSReport";
      ReportTable = "RS_Report";
      ReportHeader = "RS";
      base.InitForm();
    }

    public frmRSReport()
    {
      InitializeComponent();
    }
  }
}