using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmBaseMDIChildTree : frmBaseMDIChild
  {
    protected string otherCoin = "";
    protected bool IsInit = false;
    protected bool InitEmp = false;

    protected override void InitForm()
    {
      IsInit = true;
      SetToolItemState("ItemImport", false);
      SetToolItemState("ItemExport", false);
      SetToolItemState("ItemPrint", false);
      SetToolItemState("ItemLine1", false);
      SetToolItemState("ItemAdd", false);
      IgnoreSelect = true;
      lblRecordState.Visible = false;
      base.InitForm();
      InitDepartTreeView(tvEmp, InitEmp, false, otherCoin);
      IsInit = false;
    }

    public frmBaseMDIChildTree()
    {
      InitializeComponent();
    }
  }
}