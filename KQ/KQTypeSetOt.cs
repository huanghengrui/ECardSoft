using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmKQTypeSetOt : frmBaseMDIChildGrid
  {
    protected override void InitForm()
    {
      formCode = "KQTypeSetOt";
      dataGrid.Columns.Clear();
      AddColumn(0, "OtTypeNo", false, 120);
      AddColumn(0, "OtTypeName", false, 120);
      AddColumn(1, "OtIsDefault", false, false, 1, 100);
      AddColumn(0, "OtTypeSysID", true, false, 0);
      SetToolItemState("ItemImport", false);
      SetToolItemState("ItemExport", false);
      SetToolItemState("ItemPrint", false);
      SetToolItemState("ItemLine1", false);
      IgnoreSelect = true;
      CheckForward = false;
      base.InitForm();
      ExecItemRefresh();
    }

    public frmKQTypeSetOt()
    {
      InitializeComponent();
    }

    protected override void ExecItemAdd()
    {
      base.ExecItemAdd();
      frmKQTypeSetOtAdd frm = new frmKQTypeSetOtAdd(this.Text, CurrentTool, "");
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemEdit()
    {
      base.ExecItemEdit();
      DataRowView drv = (DataRowView)bindingSource.Current;
      string GUID = drv.Row["OtTypeSysID"].ToString();
      frmKQTypeSetOtAdd frm = new frmKQTypeSetOtAdd(this.Text, CurrentTool, GUID);
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemRefresh()
    {
      QuerySQL = Pub.GetSQL(DBCode.DB_002002, new string[] { "0" });
      base.ExecItemRefresh();
    }

    protected override void GetDelSql(int rowIndex, ref List<string> sql)
    {
      string ret = Pub.GetSQL(DBCode.DB_002002, new string[] { "3", dataGrid[3, rowIndex].Value.ToString() });
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
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002002, new string[] { "8", dataGrid[3, rowIndex].Value.ToString() }));
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