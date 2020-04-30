using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmMJMacTime : frmBaseMDIChild
  {
    protected override void InitForm()
    {
      formCode = "MJMacTime";
      SetToolItemState("ItemImport", false);
      SetToolItemState("ItemExport", false);
      SetToolItemState("ItemPrint", false);
      SetToolItemState("ItemLine1", false);
      SetToolItemState("ItemTAG1", true);
      SetToolItemState("ItemLine3", true);
      dataGrid.Columns.Clear();
      AddColumn(dataGrid, 1, "SelectCheck", false, false, 1, 80);
      AddColumn(dataGrid, 0, "MacTimeSysID", true, false, 0, 0);
      AddColumn(dataGrid, 0, "MacTimeNo", false, false, 1, 100);
      AddColumn(dataGrid, 0, "MacTimeName", false, false, 0, 100);
      AddColumn(dataGrid, 0, "MacTimeBeginTime1", false, false, 1, 60);
      AddColumn(dataGrid, 0, "MacTimeEndTime1", false, false, 1, 60);
      AddColumn(dataGrid, 0, "MacTimeBeginTime2", false, false, 1, 60);
      AddColumn(dataGrid, 0, "MacTimeEndTime2", false, false, 1, 60);
      AddColumn(dataGrid, 0, "MacTimeBeginTime3", false, false, 1, 60);
      AddColumn(dataGrid, 0, "MacTimeEndTime3", false, false, 1, 60);
      AddColumn(dataGrid, 0, "MacTimeInTypeName1", false, false, 1, 120);
      AddColumn(dataGrid, 0, "MacTimeBeginTime4", false, false, 1, 60);
      AddColumn(dataGrid, 0, "MacTimeEndTime4", false, false, 1, 60);
      AddColumn(dataGrid, 0, "MacTimeBeginTime5", false, false, 1, 60);
      AddColumn(dataGrid, 0, "MacTimeEndTime5", false, false, 1, 60);
      AddColumn(dataGrid, 0, "MacTimeBeginTime6", false, false, 1, 60);
      AddColumn(dataGrid, 0, "MacTimeEndTime6", false, false, 1, 60);
      AddColumn(dataGrid, 0, "MacTimeInTypeName2", false, false, 1, 120);
      base.InitForm();
      dataGrid.Columns[10].HeaderText = Pub.GetResText(formCode, "MJTimeInType", "");
      dataGrid.ColumnDeep = 2;
      tvGrid.Nodes.Clear();
      for (int i = 0; i < 4; i++)
      {
        tvGrid.Nodes.Add(dataGrid.Columns[i].HeaderText);
      }
      TreeNode node = tvGrid.Nodes.Add(Pub.GetResText(formCode, "MacTimeGroup1", ""));
      for (int i = 4; i < 11; i++)
      {
        node.Nodes.Add(dataGrid.Columns[i].HeaderText);
      }
      node = tvGrid.Nodes.Add(Pub.GetResText(formCode, "MacTimeGroup2", ""));
      for (int i = 11; i < dataGrid.ColumnCount; i++)
      {
        dataGrid.Columns[i].HeaderText = dataGrid.Columns[i - 7].HeaderText;
        node.Nodes.Add(dataGrid.Columns[i].HeaderText);
      }
      QuerySQL = Pub.GetSQL(DBCode.DB_003003, new string[] { "0" });
      ExecItemRefresh();
    }

    public frmMJMacTime()
    {
      InitializeComponent();
    }

    protected override void ExecItemAdd()
    {
      base.ExecItemAdd();
      frmMJMacTimeAdd frm = new frmMJMacTimeAdd(this.Text, CurrentTool, "");
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemEdit()
    {
      base.ExecItemEdit();
      frmMJMacTimeAdd frm = new frmMJMacTimeAdd(this.Text, CurrentTool, GetTimeSysID());
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemDelete()
    {
      base.ExecItemDelete();
      List<string> sql = new List<string>();
      string msg = "";
      string tmp = "";
      for (int i = 0; i < dataGrid.RowCount; i++)
      {
        if (Pub.ValueToBool(dataGrid[0, i].EditedFormattedValue))
        {
          GetDelSql(i, ref sql);
          tmp = GetDelMsg(i);
          if (tmp != "") tmp = tmp + ";";
          msg = msg + tmp;
        }
      }
      if (sql.Count == 0)
      {
        Pub.ShowErrorMsg(Pub.GetResText(formCode, "MsgNoSelectDelete", ""));
        return;
      }
      if (db.ExecSQL(sql) != 0) return;
      db.WriteSYLog(this.Text, CurrentTool, msg);
      ExecItemRefresh();
      Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgDeleteSucceed", ""), MessageBoxIcon.Information);
    }

    protected override void ExecItemTAG1()
    {
      base.ExecItemTAG1();
      frmMJMacDown frm = new frmMJMacDown(this.Text, CurrentTool, 1);
      frm.ShowDialog();
    }
    
    protected override void RefreshForm(bool State)
    {
      base.RefreshForm(State);
      if (bindingSource.Count > 0)
      {
        DataRowView drv = (DataRowView)bindingSource.Current;
        int id = 0;
        int.TryParse(drv.Row["MacTimeNo"].ToString(), out id);
        ItemEdit.Enabled = ItemEdit.Enabled && (id > 1);
        ItemDelete.Enabled = ItemDelete.Enabled && (id > 1);
        SetContextMenuState();
      }
    }

    protected override void GetDelSql(int rowIndex, ref List<string> sql)
    {
      string ret = "";
      int id = 0;
      int.TryParse(dataGrid[2, rowIndex].Value.ToString(), out id);
      if (id > 1)
      {
        ret = Pub.GetSQL(DBCode.DB_003003, new string[] { "3", dataGrid[1, rowIndex].Value.ToString() });
        sql.Add(ret);
      }
    }

    protected override string GetDelMsg(int rowIndex)
    {
      string ret = base.GetDelMsg(rowIndex);
      int id = 0;
      int.TryParse(dataGrid[2, rowIndex].Value.ToString(), out id);
      if (id > 1)
      {
        ret = dataGrid.Columns[2].HeaderText + "=" + dataGrid[2, rowIndex].Value.ToString();
      }
      return ret;
    }

    private string GetTimeSysID()
    {
      DataRowView drv = (DataRowView)bindingSource.Current;
      if (drv == null)
        return "";
      else
        return drv.Row["MacTimeSysID"].ToString();
    }
  }
}