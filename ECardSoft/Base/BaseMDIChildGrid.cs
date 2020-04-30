using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmBaseMDIChildGrid : frmBaseMDIChild
  {
    protected void AddColumn(int colType, string Field, int colWidth)
    {
      AddColumn(colType, Field, false, true, colWidth);
    }

    protected void AddColumn(int colType, string Field, bool IsHide, int colWidth)
    {
      AddColumn(colType, Field, IsHide, true, colWidth);
    }

    protected void AddColumn(int colType, string Field, bool IsHide, bool HasSort, int colWidth)
    {
      AddColumn(colType, Field, IsHide, HasSort, 0, colWidth);
    }

    protected void AddColumn(int colType, string Field, bool IsHide, bool HasSort, byte CenterFlag,int colWidth)
    {
      AddColumn(dataGrid, colType, Field, IsHide, HasSort, CenterFlag, colWidth);
    }

    protected void SetColCurrencyFormat(string DataPropertyName)
    {
      SetColCurrencyFormat(dataGrid, DataPropertyName);
    }

    protected override void InitForm()
    {
      base.InitForm();
    }

    public frmBaseMDIChildGrid()
    {
      InitializeComponent();
    }

    protected override void ExecItemDelete()
    {
      base.ExecItemDelete();
      List<string> sql = new List<string>();
      string msg = "";
      string tmp = "";
      if (dataGrid.Columns[0].DataPropertyName.ToLower() == "selectcheck")
      {
        for (int i = 0; i < dataGrid.RowCount; i++)
        {
          if (Pub.ValueToBool(dataGrid[0, i].EditedFormattedValue))
          {
            if (!CheckDelete(i)) return;
            GetDelSql(i, ref sql);
            tmp = GetDelMsg(i);
            if (tmp != "") tmp = tmp + ";";
            msg = msg + tmp;
          }
        }
      }
      if (sql.Count == 0)
      {
        if (!CheckDelete(bindingSource.Position)) return;
        GetDelSql(bindingSource.Position, ref sql);
        tmp = GetDelMsg(bindingSource.Position);
        if (tmp != "") tmp = tmp + ";";
        msg = msg + tmp;
      }
      if (sql.Count == 0)
      {
        Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgNoSelectDelete", ""));
        return;
      }
      GetDelSqlExt(ref sql);
      if (db.ExecSQL(sql) != 0) return;
      db.WriteSYLog(this.Text, CurrentTool, msg);
      ExecItemRefresh();
      Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgDeleteSucceed", ""), MessageBoxIcon.Information);
    }

    protected virtual bool CheckDelete(int rowIndex)
    {
      return true;
    }

    protected override void ExecItemRefresh()
    {
      dataGrid.DataSource = null;
      base.ExecItemRefresh();
      dataGrid.DataSource = bindingSource;
    }

    protected override void RefreshForm(bool State)
    {
      base.RefreshForm(State);
      dataGrid.Enabled = State;
    }

    private void dataGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
      e.Cancel = true;
    }

    private void dataGrid_DoubleClick(object sender, EventArgs e)
    {
      if (ItemEdit.Enabled) ItemEdit.PerformClick();
    }
  }
}