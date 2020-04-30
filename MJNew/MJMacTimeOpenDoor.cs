using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmMJMacTimeOpenDoor : frmBaseMDIChild
  {
    protected override void InitForm()
    {
      formCode = "MJMacTimeOpenDoor";
      SetToolItemState("ItemImport", false);
      SetToolItemState("ItemExport", false);
      SetToolItemState("ItemPrint", false);
      SetToolItemState("ItemLine1", false);
      SetToolItemState("ItemAdd", false);
      SetToolItemState("ItemDelete", false);
      SetToolItemState("ItemTAG1", true);
      SetToolItemState("ItemLine3", true);
      IgnoreSelect = true;
      AddColumn(dataGrid, 0, "WeekID", false, false, 1, 80);
      AddColumn(dataGrid, 0, "WeekName", false, false, 1, 80);
      AddColumn(dataGrid, 0, "BeginTime1", false, false, 1, 60);
      AddColumn(dataGrid, 0, "EndTime1", false, false, 1, 60);
      AddColumn(dataGrid, 0, "ModeName1", false, false, 1, 80);
      AddColumn(dataGrid, 0, "BeginTime2", false, false, 1, 60);
      AddColumn(dataGrid, 0, "EndTime2", false, false, 1, 60);
      AddColumn(dataGrid, 0, "ModeName2", false, false, 1, 80);
      AddColumn(dataGrid, 0, "BeginTime3", false, false, 1, 60);
      AddColumn(dataGrid, 0, "EndTime3", false, false, 1, 60);
      AddColumn(dataGrid, 0, "ModeName3", false, false, 1, 80);
      AddColumn(dataGrid, 0, "BeginTime4", false, false, 1, 60);
      AddColumn(dataGrid, 0, "EndTime4", false, false, 1, 60);
      AddColumn(dataGrid, 0, "ModeName4", false, false, 1, 80);
      base.InitForm();
      dataGrid.ColumnDeep = 2;
      tvGrid.Nodes.Clear();
      for (int i = 0; i < 2; i++)
      {
        tvGrid.Nodes.Add(dataGrid.Columns[i].HeaderText);
      }
      TreeNode node = tvGrid.Nodes.Add(Pub.GetResText(formCode, "MacTimezone1", ""));
      for (int i = 2; i < 5; i++)
      {
        node.Nodes.Add(dataGrid.Columns[i].HeaderText);
      }
      node = tvGrid.Nodes.Add(Pub.GetResText(formCode, "MacTimezone2", ""));
      for (int i = 5; i < 8; i++)
      {
        node.Nodes.Add(dataGrid.Columns[i].HeaderText);
      }
      node = tvGrid.Nodes.Add(Pub.GetResText(formCode, "MacTimezone3", ""));
      for (int i = 8; i < 11; i++)
      {
        node.Nodes.Add(dataGrid.Columns[i].HeaderText);
      }
      node = tvGrid.Nodes.Add(Pub.GetResText(formCode, "MacTimezone4", ""));
      for (int i = 11; i < dataGrid.ColumnCount; i++)
      {
        node.Nodes.Add(dataGrid.Columns[i].HeaderText);
      }
      QuerySQL = Pub.GetSQL(DBCode.DB_003009, new string[] { "100" });
      ExecItemRefresh();
    }

    public frmMJMacTimeOpenDoor()
    {
      InitializeComponent();
    }

    protected override void ExecItemEdit()
    {
      base.ExecItemEdit();
      frmMJMacTimeOpenDoorEdit frm = new frmMJMacTimeOpenDoorEdit(this.Text, CurrentTool, GetWeekID());
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemTAG1()
    {
      base.ExecItemTAG1();
      frmMJMacDoorDown frm = new frmMJMacDoorDown(this.Text, CurrentTool, 0);
      frm.ShowDialog();
    }

    private string GetWeekID()
    {
      DataRowView drv = (DataRowView)bindingSource.Current;
      if (drv == null)
        return "";
      else
        return drv.Row["WeekID"].ToString();
    }

    private void dataGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (ItemEdit.Enabled) ExecItemEdit();
    }
  }
}