using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmKQTypeSetTrip : frmBaseMDIChildGrid
  {
    protected override void InitForm()
    {
      formCode = "KQTypeSetTrip";
      dataGrid.Columns.Clear();
      AddColumn(0, "TripTypeNo", false, 120);
      AddColumn(0, "TripTypeName", false, 120);
      AddColumn(0, "TripTypeSysID", true, false, 0);
      SetToolItemState("ItemImport", false);
      SetToolItemState("ItemExport", false);
      SetToolItemState("ItemPrint", false);
      SetToolItemState("ItemLine1", false);
      IgnoreSelect = true;
      CheckForward = false;
      base.InitForm();
      ExecItemRefresh();
    }

    public frmKQTypeSetTrip()
    {
      InitializeComponent();
    }

    protected override void ExecItemAdd()
    {
      base.ExecItemAdd();
      frmKQTypeSetTripAdd frm = new frmKQTypeSetTripAdd(this.Text, CurrentTool, "");
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemEdit()
    {
      base.ExecItemEdit();
      DataRowView drv = (DataRowView)bindingSource.Current;
      string GUID = drv.Row["TripTypeSysID"].ToString();
      frmKQTypeSetTripAdd frm = new frmKQTypeSetTripAdd(this.Text, CurrentTool, GUID);
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemRefresh()
    {
      QuerySQL = Pub.GetSQL(DBCode.DB_002002, new string[] { "200" });
      base.ExecItemRefresh();
    }

    protected override void GetDelSql(int rowIndex, ref List<string> sql)
    {
      string ret = Pub.GetSQL(DBCode.DB_002002, new string[] { "203", dataGrid[2, rowIndex].Value.ToString() });
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
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002002, new string[] { "207", dataGrid[2, rowIndex].Value.ToString() }));
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