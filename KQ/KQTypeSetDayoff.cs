using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmKQTypeSetDayoff : frmBaseMDIChildGrid
  {
    protected override void InitForm()
    {
      formCode = "KQTypeSetDayoff";
      dataGrid.Columns.Clear();
      AddColumn(0, "DayOffTypeNo", false, 120);
      AddColumn(0, "DayOffTypeName", false, 120);
      AddColumn(1, "DayOffIsGS", false, false, 1, 100);
      AddColumn(0, "DayOffTypeSysID", true, false, 0);
      SetToolItemState("ItemImport", false);
      SetToolItemState("ItemExport", false);
      SetToolItemState("ItemPrint", false);
      SetToolItemState("ItemLine1", false);
      IgnoreSelect = true;
      CheckForward = false;
      base.InitForm();
      ExecItemRefresh();
    }

    public frmKQTypeSetDayoff()
    {
      InitializeComponent();
    }

    protected override void ExecItemAdd()
    {
      base.ExecItemAdd();
      frmKQTypeSetDayoffAdd frm = new frmKQTypeSetDayoffAdd(this.Text, CurrentTool, "");
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemEdit()
    {
      base.ExecItemEdit();
      DataRowView drv = (DataRowView)bindingSource.Current;
      string GUID = drv.Row["DayOffTypeSysID"].ToString();
      frmKQTypeSetDayoffAdd frm = new frmKQTypeSetDayoffAdd(this.Text, CurrentTool, GUID);
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemRefresh()
    {
      QuerySQL = Pub.GetSQL(DBCode.DB_002002, new string[] { "100" });
      base.ExecItemRefresh();
    }

    protected override void GetDelSql(int rowIndex, ref List<string> sql)
    {
      string ret = Pub.GetSQL(DBCode.DB_002002, new string[] { "103", dataGrid[3, rowIndex].Value.ToString() });
      sql.Add(ret);
    }

    protected override string GetDelMsg(int rowIndex)
    {
      string ret = base.GetDelMsg(rowIndex);
      ret = dataGrid.Columns[0].HeaderText + "=" + dataGrid[0, rowIndex].Value.ToString() + "," +
        dataGrid.Columns[1].HeaderText + "=" + dataGrid[1, rowIndex].Value.ToString();
      return ret;
    }

    protected override bool CheckDelete(int rowIndex)
    {
      bool ret = base.CheckDelete(rowIndex);
      DataTableReader dr = null;
      try
      {
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002002, new string[] { "107", dataGrid[3, rowIndex].Value.ToString() }));
        if (dr.Read())
        {
          ret = Convert.ToInt32(dr[0].ToString()) == 0;
          if (!ret) Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", ""));
        }
      }
      catch (Exception E)
      {
        ret = false;
        Pub.ShowErrorMsg(E);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      return ret;
    }
  }
}