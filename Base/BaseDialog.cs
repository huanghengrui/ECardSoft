using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmBaseDialog : frmBaseForm
  {
    protected string Title = "";
    protected string SysID = "";
    protected string CurrentOprt = "";

    public frmBaseDialog()
    {
      InitializeComponent();
    }
  }
}