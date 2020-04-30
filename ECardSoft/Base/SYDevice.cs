using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmSYDevice : frmBaseMDIChildGrid
  {
    protected override void InitForm()
    {
      formCode = "SYDevice";
      dataGrid.Columns.Clear();
      AddColumn(1, "SelectCheck", false, false, 1, 60);
      AddColumn(0, "MacOpterID", false, 120);
      AddColumn(0, "MacOpterName", false, 120);
      AddColumn(0, "GUID", true, false, 0);
      AddColumn(0, "MacOpterPWD", true, false, 0);
      SetToolItemState("ItemImport", false);
      SetToolItemState("ItemExport", false);
      SetToolItemState("ItemPrint", false);
      SetToolItemState("ItemLine1", false);
      base.InitForm();
      ExecItemRefresh();
    }

    public frmSYDevice()
    {
      InitializeComponent();
    }

    protected override void ExecItemAdd()
    {
      base.ExecItemAdd();
      frmSYDeviceAdd frm = new frmSYDeviceAdd(this.Text, CurrentTool, "");
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemEdit()
    {
      base.ExecItemEdit();
      DataRowView drv = (DataRowView)bindingSource.Current;
      string GUID = drv.Row["GUID"].ToString();
      frmSYDeviceAdd frm = new frmSYDeviceAdd(this.Text, CurrentTool, GUID);
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemRefresh()
    {
      QuerySQL = Pub.GetSQL(DBCode.DB_000004, new string[] { "0" });
      base.ExecItemRefresh();
    }

    protected override void GetDelSql(int rowIndex, ref List<string> sql)
    {
      string ret = Pub.GetSQL(DBCode.DB_000004, new string[] { "3", dataGrid[3, rowIndex].Value.ToString() });
      sql.Add(ret);
    }

    protected override string GetDelMsg(int rowIndex)
    {
      string ret = base.GetDelMsg(rowIndex);
      ret = dataGrid.Columns[1].HeaderText + "=" + dataGrid[1, rowIndex].Value.ToString() + "," +
        dataGrid.Columns[2].HeaderText + "=" + dataGrid[2, rowIndex].Value.ToString();
      return ret;
    }
  }
}