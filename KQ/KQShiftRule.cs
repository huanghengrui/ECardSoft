using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmKQShiftRule : frmBaseMDIChildGrid
  {
    protected override void InitForm()
    {
      formCode = "KQShiftRule";
      dataGrid.Columns.Clear();
      AddColumn(0, "ShiftRuleSysID", true, false, 0);
      AddColumn(0, "ShiftRuleName", false, 80);
      AddColumn(0, "ShiftRuleFlagName", false, 100);
      AddColumn(0, "Flag", true, false, 1, 80);
      AddColumn(0, "CycDays", false, false, 1, 80);
      SetToolItemState("ItemImport", false);
      SetToolItemState("ItemExport", false);
      SetToolItemState("ItemPrint", false);
      SetToolItemState("ItemLine1", false);
      IgnoreSelect = true;
      CheckForward = false;
      base.InitForm();
      ExecItemRefresh();
    }

    public frmKQShiftRule()
    {
      InitializeComponent();
    }

    protected override void ExecItemAdd()
    {
      base.ExecItemAdd();
      frmKQShiftRuleAdd frm = new frmKQShiftRuleAdd(this.Text, CurrentTool, "");
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemEdit()
    {
      base.ExecItemEdit();
      DataRowView drv = (DataRowView)bindingSource.Current;
      string GUID = drv.Row["ShiftRuleSysID"].ToString();
      frmKQShiftRuleAdd frm = new frmKQShiftRuleAdd(this.Text, CurrentTool, GUID);
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemRefresh()
    {
      QuerySQL = Pub.GetSQL(DBCode.DB_002004, new string[] { "0", Pub.GetResText(formCode, "ShiftRuleFlag0", ""), 
        Pub.GetResText(formCode, "ShiftRuleFlag1", ""), Pub.GetResText(formCode, "ShiftRuleFlag2", "") });
      base.ExecItemRefresh();
    }

    protected override void GetDelSql(int rowIndex, ref List<string> sql)
    {
      string GUID = dataGrid[0, rowIndex].Value.ToString();
      sql.Add(Pub.GetSQL(DBCode.DB_002004, new string[] { "1", GUID }));
      sql.Add(Pub.GetSQL(DBCode.DB_002004, new string[] { "2", GUID }));
    }

    protected override string GetDelMsg(int rowIndex)
    {
      string ret = base.GetDelMsg(rowIndex);
      ret = dataGrid.Columns[1].HeaderText + "=" + dataGrid[1, rowIndex].Value.ToString();
      return ret;
    }
  }
}