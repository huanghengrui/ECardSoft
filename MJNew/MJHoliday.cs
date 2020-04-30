using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmMJHoliday : frmBaseMDIChildGrid
  {
    protected override void InitForm()
    {
      formCode = "MJHoliday";
      SetToolItemState("ItemImport", false);
      SetToolItemState("ItemExport", false);
      SetToolItemState("ItemPrint", false);
      SetToolItemState("ItemLine1", false);
      SetToolItemState("ItemAdd", false);
      SetToolItemState("ItemDelete", false);
      SetToolItemState("ItemTAG1", true);
      SetToolItemState("ItemLine3", true);
      dataGrid.Columns.Clear();
      AddColumn(1, "SelectCheck", true, false, 1, 60);
      AddColumn(0, "MJHoliID", false, false, 1, 100);
      AddColumn(1, "MJHoliIsApply", false, false, 1, 100);
      AddColumn(0, "MJHoliBeginDate", false, false, 100);
      AddColumn(0, "MJHoliEndDate", false, false, 100);
      AddColumn(0, "MacTimeNo", false, false, 100);
      AddColumn(0, "MJHoliMemo", false, false, 100);
      IgnoreSelect = true;
      base.InitForm();
      QuerySQL = Pub.GetSQL(DBCode.DB_003002, new string[] { "0" });
      ExecItemRefresh();
    }

    public frmMJHoliday()
    {
      InitializeComponent();
    }

    protected override void ExecItemEdit()
    {
      base.ExecItemEdit();
      frmMJHolidayEdit frm = new frmMJHolidayEdit(this.Text, CurrentTool, GetHoliID());
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemTAG1()
    {
      base.ExecItemTAG1();
      frmMJMacDown frm = new frmMJMacDown(this.Text, CurrentTool, 0);
      frm.ShowDialog();
    }

    protected string GetHoliID()
    {
      DataRowView drv = (DataRowView)bindingSource.Current;
      if (drv == null)
        return "";
      else
        return drv.Row["MJHoliID"].ToString();
    }
  }
}