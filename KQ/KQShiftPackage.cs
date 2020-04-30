using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmKQShiftPackage : frmBaseMDIChildGrid
  {
    protected override void InitForm()
    {
      formCode = "KQShiftPackage";
      dataGrid.Columns.Clear();
      AddColumn(0, "GUID", true, false, 0);
      AddColumn(0, "ShiftPackNo", false, 0);
      AddColumn(0, "ShiftPackName", false, 0);
      AddColumn(0, "IsBackUp", false, false, 1, 0);
      AddColumn(0, "BackUpShiftNo", false, false, 0);
      AddColumn(0, "IsPrevious", false, false, 1, 0);
      SetToolItemState("ItemImport", false);
      SetToolItemState("ItemExport", false);
      SetToolItemState("ItemPrint", false);
      SetToolItemState("ItemLine1", false);
      IgnoreSelect = true;
      CheckForward = false;
      base.InitForm();
      ExecItemRefresh();
    }

    public frmKQShiftPackage()
    {
      InitializeComponent();
    }

    protected override void ExecItemAdd()
    {
      base.ExecItemAdd();
      frmKQShiftPackageAdd frm = new frmKQShiftPackageAdd(this.Text, CurrentTool, "");
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemEdit()
    {
      base.ExecItemEdit();
      DataRowView drv = (DataRowView)bindingSource.Current;
      string GUID = drv.Row["GUID"].ToString();
      frmKQShiftPackageAdd frm = new frmKQShiftPackageAdd(this.Text, CurrentTool, GUID);
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemRefresh()
    {
      QuerySQL = Pub.GetSQL(DBCode.DB_002020, new string[] { "0" });
      base.ExecItemRefresh();
    }

    protected override void GetDelSql(int rowIndex, ref List<string> sql)
    {
      string GUID = dataGrid[0, rowIndex].Value.ToString();
      sql.Add(Pub.GetSQL(DBCode.DB_002020, new string[] { "3", GUID }));
      sql.Add(Pub.GetSQL(DBCode.DB_002003, new string[] { "3", GUID }));
    }

    protected override string GetDelMsg(int rowIndex)
    {
      string ret = base.GetDelMsg(rowIndex);
      ret = dataGrid.Columns[1].HeaderText + "=" + dataGrid[1, rowIndex].Value.ToString() + "," +
        dataGrid.Columns[2].HeaderText + "=" + dataGrid[2, rowIndex].Value.ToString();
      return ret;
    }

    protected override bool CheckDelete(int rowIndex)
    {
      bool ret = base.CheckDelete(rowIndex);
      string No = dataGrid[1, rowIndex].Value.ToString().ToUpper();
      DataTableReader dr = null;
      try
      {
        for (int i = 7; i <= 12; i++)
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002003, new string[] { i.ToString(), No }));
          if (dr.Read())
          {
            ret = Convert.ToInt32(dr[0].ToString()) == 0;
            if (!ret)
            {
              Pub.ShowErrorMsg(Pub.GetResText("KQShift", "Error002", ""));
              break;
            }
          }
          dr.Close();
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