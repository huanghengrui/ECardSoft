using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmKQWeekEnd : frmBaseMDIChildGrid
  {
    protected override void InitForm()
    {
      formCode = "KQWeekEnd";
      dataGrid.Columns.Clear();
      AddColumn(0, "WeekEndNo", false, 120);
      AddColumn(0, "WeekEndNameA", false, 120);
      AddColumn(0, "WeekEndSysID", true, false, 0);
      SetToolItemState("ItemImport", false);
      SetToolItemState("ItemExport", false);
      SetToolItemState("ItemPrint", false);
      SetToolItemState("ItemLine1", false);
      IgnoreSelect = true;
      CheckForward = false;
      base.InitForm();
      ExecItemRefresh();
    }

    public frmKQWeekEnd()
    {
      InitializeComponent();
    }

    protected override void ExecItemAdd()
    {
      base.ExecItemAdd();
      frmKQWeekEndAdd frm = new frmKQWeekEndAdd(this.Text, CurrentTool, "");
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemEdit()
    {
      base.ExecItemEdit();
      DataRowView drv = (DataRowView)bindingSource.Current;
      string GUID = drv.Row["WeekEndSysID"].ToString();
      frmKQWeekEndAdd frm = new frmKQWeekEndAdd(this.Text, CurrentTool, GUID);
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemRefresh()
    {
      QuerySQL = Pub.GetSQL(DBCode.DB_002017, new string[] { "0" });
      base.ExecItemRefresh();
    }

    protected override void GetDelSql(int rowIndex, ref List<string> sql)
    {
      string GUID = dataGrid[2, rowIndex].Value.ToString();
      sql.Add(Pub.GetSQL(DBCode.DB_002017, new string[] { "1", GUID }));
      sql.Add(Pub.GetSQL(DBCode.DB_002017, new string[] { "2", GUID }));
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
      string GUID = dataGrid[2, rowIndex].Value.ToString();
      DataTableReader dr = null;
      try
      {
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002017, new string[] { "3", GUID }));
        if (dr.Read())
        {
          ret = Convert.ToInt32(dr[0].ToString()) == 0;
          if (!ret) Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", ""));
        }
        if (ret)
        {
          dr.Close();
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002017, new string[] { "4", GUID }));
          if (dr.Read())
          {
            ret = Convert.ToInt32(dr[0].ToString()) == 0;
            if (!ret) Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", ""));
          }
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