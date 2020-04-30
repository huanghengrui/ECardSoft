using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmMJMacTimeAdv : frmBaseMDIChild
  {
    private string groupQuerySQL = "";

    protected override void InitForm()
    {
      formCode = "MJMacTimeAdv";
      SetToolItemState("ItemImport", false);
      SetToolItemState("ItemExport", false);
      SetToolItemState("ItemPrint", false);
      SetToolItemState("ItemLine1", false);
      SetToolItemState("ItemTAG1", true);
      SetToolItemState("ItemLine3", true);
      groupGrid.Columns.Clear();
      AddColumn(groupGrid, 1, "SelectCheck", false, false, 1, 80);
      AddColumn(groupGrid, 0, "MacTimeHeaderSysID", true, false, 0, 0);
      AddColumn(groupGrid, 0, "MacTimeHeaderTimeNo", false, false, 1, 100);
      AddColumn(groupGrid, 0, "MacTimeHeaderName", false, false, 0, 100);
      AddColumn(groupGrid, 0, "MacTimeHeaderSunday", false, false, 0, 70);
      AddColumn(groupGrid, 0, "MacTimeHeaderMonday", false, false, 0, 70);
      AddColumn(groupGrid, 0, "MacTimeHeaderTuesday", false, false, 0, 70);
      AddColumn(groupGrid, 0, "MacTimeHeaderWednesday", false, false, 0, 70);
      AddColumn(groupGrid, 0, "MacTimeHeaderThursday", false, false, 0, 70);
      AddColumn(groupGrid, 0, "MacTimeHeaderFriday", false, false, 0, 70);
      AddColumn(groupGrid, 0, "MacTimeHeaderSaturday", false, false, 0, 70);
      AddColumn(groupGrid, 1, "MacTimeHeaderHoliday", false, false, 1, 100);
      dataGrid.Columns.Clear();
      AddColumn(dataGrid, 1, "SelectCheck", false, false, 1, 80);
      AddColumn(dataGrid, 0, "MacTimeSysID", true, false, 0, 0);
      AddColumn(dataGrid, 0, "MacTimeNo", false, false, 1, 100);
      AddColumn(dataGrid, 0, "MacTimeName", false, false, 0, 100);
      AddColumn(dataGrid, 0, "MacTimeTimes1", false, false, 1, 60);
      AddColumn(dataGrid, 0, "MacTimeBeginTime1", false, false, 1, 60);
      AddColumn(dataGrid, 0, "MacTimeEndTime1", false, false, 1, 60);
      AddColumn(dataGrid, 0, "MacTimeModeName1", false, false, 1, 70);
      AddColumn(dataGrid, 0, "MacTimeTimes2", false, false, 1, 60);
      AddColumn(dataGrid, 0, "MacTimeBeginTime2", false, false, 1, 60);
      AddColumn(dataGrid, 0, "MacTimeEndTime2", false, false, 1, 60);
      AddColumn(dataGrid, 0, "MacTimeModeName2", false, false, 1, 70);
      AddColumn(dataGrid, 0, "MacTimeTimes3", false, false, 1, 60);
      AddColumn(dataGrid, 0, "MacTimeBeginTime3", false, false, 1, 60);
      AddColumn(dataGrid, 0, "MacTimeEndTime3", false, false, 1, 60);
      AddColumn(dataGrid, 0, "MacTimeModeName3", false, false, 1, 70);
      AddColumn(dataGrid, 0, "MacTimeTimes4", false, false, 1, 60);
      AddColumn(dataGrid, 0, "MacTimeBeginTime4", false, false, 1, 60);
      AddColumn(dataGrid, 0, "MacTimeEndTime4", false, false, 1, 60);
      AddColumn(dataGrid, 0, "MacTimeModeName4", false, false, 1, 70);
      AddColumn(dataGrid, 0, "MacTimeTimes5", false, false, 1, 60);
      AddColumn(dataGrid, 0, "MacTimeBeginTime5", false, false, 1, 60);
      AddColumn(dataGrid, 0, "MacTimeEndTime5", false, false, 1, 60);
      AddColumn(dataGrid, 0, "MacTimeModeName5", false, false, 1, 70);
      AddColumn(dataGrid, 0, "MacTimeTimes6", false, false, 1, 60);
      AddColumn(dataGrid, 0, "MacTimeBeginTime6", false, false, 1, 60);
      AddColumn(dataGrid, 0, "MacTimeEndTime6", false, false, 1, 60);
      AddColumn(dataGrid, 0, "MacTimeModeName6", false, false, 1, 70);
      base.InitForm();
      groupGrid.Columns[4].HeaderText = Pub.GetResText(formCode, "Sunday", "");
      groupGrid.Columns[5].HeaderText = Pub.GetResText(formCode, "Monday", "");
      groupGrid.Columns[6].HeaderText = Pub.GetResText(formCode, "Tuesday", "");
      groupGrid.Columns[7].HeaderText = Pub.GetResText(formCode, "Wednesday", "");
      groupGrid.Columns[8].HeaderText = Pub.GetResText(formCode, "Thursday", "");
      groupGrid.Columns[9].HeaderText = Pub.GetResText(formCode, "Friday", "");
      groupGrid.Columns[10].HeaderText = Pub.GetResText(formCode, "Saturday", "");
      dataGrid.Columns[10].HeaderText = Pub.GetResText(formCode, "MJTimeInType", "");
      for (int i = 0; i < 6; i++)
      {
        dataGrid.Columns[i * 4 + 4].HeaderText = Pub.GetResText(formCode, "MacTimeSegmentTimes", "");
        dataGrid.Columns[i * 4 + 5].HeaderText = Pub.GetResText(formCode, "MacTimeSegmentBegin", "");
        dataGrid.Columns[i * 4 + 6].HeaderText = Pub.GetResText(formCode, "MacTimeSegmentEnd", "");
        dataGrid.Columns[i * 4 + 7].HeaderText = Pub.GetResText(formCode, "MacTimeCtrlMode", "");
      }
      dataGrid.ColumnDeep = 2;
      tvGrid.Nodes.Clear();
      for (int i = 0; i < 4; i++)
      {
        tvGrid.Nodes.Add(dataGrid.Columns[i].HeaderText);
      }
      TreeNode node = tvGrid.Nodes.Add(Pub.GetResText(formCode, "MacTimeSegment1", ""));
      for (int i = 4; i < 8; i++)
      {
        node.Nodes.Add(dataGrid.Columns[i].HeaderText);
      }
      node = tvGrid.Nodes.Add(Pub.GetResText(formCode, "MacTimeSegment2", ""));
      for (int i = 8; i < 12; i++)
      {
        node.Nodes.Add(dataGrid.Columns[i].HeaderText);
      }
      node = tvGrid.Nodes.Add(Pub.GetResText(formCode, "MacTimeSegment3", ""));
      for (int i = 12; i < 16; i++)
      {
        node.Nodes.Add(dataGrid.Columns[i].HeaderText);
      }
      node = tvGrid.Nodes.Add(Pub.GetResText(formCode, "MacTimeSegment4", ""));
      for (int i = 16; i < 20; i++)
      {
        node.Nodes.Add(dataGrid.Columns[i].HeaderText);
      }
      node = tvGrid.Nodes.Add(Pub.GetResText(formCode, "MacTimeSegment5", ""));
      for (int i = 20; i < 24; i++)
      {
        node.Nodes.Add(dataGrid.Columns[i].HeaderText);
      }
      node = tvGrid.Nodes.Add(Pub.GetResText(formCode, "MacTimeSegment6", ""));
      for (int i = 24; i < 28; i++)
      {
        node.Nodes.Add(dataGrid.Columns[i].HeaderText);
      }
      QuerySQL = Pub.GetSQL(DBCode.DB_003003, new string[] { "7" });
      groupQuerySQL = Pub.GetSQL(DBCode.DB_003003, new string[] { "1000" });
      ExecItemRefresh();
    }

    public frmMJMacTimeAdv()
    {
      InitializeComponent();
    }

    private void tabControl1_Selected(object sender, TabControlEventArgs e)
    {
      RefreshForm(true);
    }

    private void bindingSource1_PositionChanged(object sender, EventArgs e)
    {
      RefreshForm(true);
    }

    protected override void ExecItemAdd()
    {
      base.ExecItemAdd();
      if (tabControl1.SelectedIndex == 0)
      {
        frmMJMacTimeGroup frm = new frmMJMacTimeGroup(this.Text, CurrentTool, "");
        if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
      }
      else
      {
        frmMJMacTimeAdd frm = new frmMJMacTimeAdd(this.Text, CurrentTool, "");
        if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
      }
    }

    protected override void ExecItemEdit()
    {
      base.ExecItemEdit();
      if (tabControl1.SelectedIndex == 0)
      {
        frmMJMacTimeGroup frm = new frmMJMacTimeGroup(this.Text, CurrentTool, GetTimeSysID());
        if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
      }
      else
      {
        frmMJMacTimeAdd frm = new frmMJMacTimeAdd(this.Text, CurrentTool, GetTimeSysID());
        if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
      }
    }

    protected override void ExecItemDelete()
    {
      base.ExecItemDelete();
      List<string> sql = new List<string>();
      string msg = "";
      string tmp = "";
      if (tabControl1.SelectedIndex == 0)
      {
        for (int i = 0; i < groupGrid.RowCount; i++)
        {
          if (Pub.ValueToBool(groupGrid[0, i].EditedFormattedValue))
          {
            GetDelSql(i, ref sql);
            tmp = GetDelMsg(i);
            if (tmp != "") tmp = tmp + ";";
            msg = msg + tmp;
          }
        }
      }
      else
      {
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

    protected override void ExecItemRefresh()
    {
      DateTime StartTime = DateTime.Now;
      int row = -1;
      RefreshMsg(StrReading);
      if (groupQuerySQL != "")
      {
        try
        {
          if (bindingSource1.DataSource != null) row = bindingSource1.Position;
          bindingSource1.DataSource = null;
          if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
          bindingSource1.DataSource = db.GetDataTable(groupQuerySQL);
        }
        catch (Exception E)
        {
          Pub.ShowErrorMsg(E, QuerySQL);
        }
        finally
        {
          if (bindingSource1.DataSource != null)
          {
            if (row < bindingSource1.Count)
              bindingSource1.Position = row;
            else if (bindingSource1.Count > 0)
              bindingSource1.Position = bindingSource1.Count - 1;
          }
        }
      }
      if (QuerySQL != "")
      {
        try
        {
          if (bindingSource.DataSource != null) row = bindingSource.Position;
          bindingSource.DataSource = null;
          if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
          bindingSource.DataSource = db.GetDataTable(QuerySQL);
        }
        catch (Exception E)
        {
          Pub.ShowErrorMsg(E, QuerySQL);
        }
        finally
        {
          if (bindingSource.DataSource != null)
          {
            if (row < bindingSource.Count)
              bindingSource.Position = row;
            else if (bindingSource.Count > 0)
              bindingSource.Position = bindingSource.Count - 1;
          }
        }
      }
      RefreshForm(true);
      RefreshMsg(StrReadEnd + Pub.GetDateDiffTimes(StartTime, DateTime.Now, true), true);
    }

    protected override void SelectData(bool State)
    {
      if (tabControl1.SelectedIndex == 0)
      {
        if (bindingSource1.DataSource != null)
        {
          DataTable dt = (DataTable)bindingSource1.DataSource;
          for (int i = 0; i < dt.Rows.Count; i++)
          {
            dt.Rows[i].BeginEdit();
            dt.Rows[i]["SelectCheck"] = State;
            dt.Rows[i].EndEdit();
          }
        }
      }
      else
      {
        if (bindingSource.DataSource != null)
        {
          DataTable dt = (DataTable)bindingSource.DataSource;
          for (int i = 0; i < dt.Rows.Count; i++)
          {
            dt.Rows[i].BeginEdit();
            dt.Rows[i]["SelectCheck"] = State;
            dt.Rows[i].EndEdit();
          }
        }
      }
    }

    protected override void RefreshForm(bool State)
    {
      int row = 0;
      int rows = 0;
      int id = 0;
      if (tabControl1.SelectedIndex == 0)
      {
        if (bindingSource1.DataSource != null)
        {
          row = bindingSource1.Position + 1;
          rows = bindingSource1.Count;
          if (bindingSource1.Count > 0)
          {
            DataRowView drv = (DataRowView)bindingSource1.Current;
            int.TryParse(drv.Row["MacTimeHeaderTimeNo"].ToString(), out id);
          }
        }
      }
      else
      {
        if (bindingSource.DataSource != null)
        {
          row = bindingSource.Position + 1;
          rows = bindingSource.Count;
          if (bindingSource.Count > 0)
          {
            DataRowView drv = (DataRowView)bindingSource.Current;
            int.TryParse(drv.Row["MacTimeNo"].ToString(), out id);
          }
        }
      }
      ItemImport.Enabled = State;
      ItemExport.Enabled = (rows > 0);
      ItemPrint.Enabled = (rows > 0);
      ItemAdd.Enabled = State;
      ItemEdit.Enabled = State && (rows > 0) && (id > 1);
      ItemDelete.Enabled = State && (rows > 0) && (id > 1);
      ItemTAG1.Enabled = State && (rows > 0);
      ItemTAG2.Enabled = State && (rows > 0);
      ItemTAG3.Enabled = State && (rows > 0);
      ItemTAG4.Enabled = State && (rows > 0);
      ItemTAG5.Enabled = State && (rows > 0);
      ItemTAG6.Enabled = State && (rows > 0);
      ItemTAG7.Enabled = State && (rows > 0);
      ItemTAGExt.Enabled = State;
      for (int i = 0; i < ItemTAGExt.DropDownItems.Count; i++)
      {
        if (ItemTAGExt.DropDownItems[i].Name == "ItemSetupDisplay")
          ItemTAGExt.DropDownItems[i].Enabled = State;
        else
          ItemTAGExt.DropDownItems[i].Enabled = State && (rows > 0);
      }
      ItemSelect.Enabled = State && (rows > 0);
      ItemUnselect.Enabled = State && (rows > 0);
      ItemRefresh.Enabled = State;
      ItemSearch.Enabled = State;
      SetContextMenuState();
      lblRecordState.Text = string.Format(StrPosition, row, rows);
    }

    protected override void GetDelSql(int rowIndex, ref List<string> sql)
    {
      string ret = "";
      int id = 0;
      if (tabControl1.SelectedIndex == 0)
      {
        int.TryParse(groupGrid[2, rowIndex].Value.ToString(), out id);
        if (id > 1)
        {
          ret = Pub.GetSQL(DBCode.DB_003003, new string[] { "1003", groupGrid[1, rowIndex].Value.ToString() });
          sql.Add(ret);
        }
      }
      else
      {
        int.TryParse(dataGrid[2, rowIndex].Value.ToString(), out id);
        if (id > 1)
        {
          ret = Pub.GetSQL(DBCode.DB_003003, new string[] { "3", dataGrid[1, rowIndex].Value.ToString() });
          sql.Add(ret);
        }
      }
    }

    protected override string GetDelMsg(int rowIndex)
    {
      string ret = base.GetDelMsg(rowIndex);
      int id = 0;
      if (tabControl1.SelectedIndex == 0)
      {
        int.TryParse(groupGrid[2, rowIndex].Value.ToString(), out id);
        if (id > 1)
        {
          ret = groupGrid.Columns[2].HeaderText + "=" + groupGrid[2, rowIndex].Value.ToString();
        }
      }
      else
      {
        int.TryParse(dataGrid[2, rowIndex].Value.ToString(), out id);
        if (id > 1)
        {
          ret = dataGrid.Columns[2].HeaderText + "=" + dataGrid[2, rowIndex].Value.ToString();
        }
      }
      return ret;
    }

    protected string GetTimeSysID()
    {
      if (tabControl1.SelectedIndex == 0)
      {
        DataRowView drv = (DataRowView)bindingSource1.Current;
        if (drv == null)
          return "";
        else
          return drv.Row["MacTimeHeaderSysID"].ToString();
      }
      else
      {
        DataRowView drv = (DataRowView)bindingSource.Current;
        if (drv == null)
          return "";
        else
          return drv.Row["MacTimeSysID"].ToString();
      }
    }
  }
}