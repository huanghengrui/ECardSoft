using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmSYPower : frmBaseMDIChildGrid
  {
    protected override void InitForm()
    {
      formCode = "SYPower";
      dataGrid.Dock = DockStyle.Top;
      dataGrid.Height = 150;
      AddColumn(1, "SelectCheck", false, false, 1, 60);
      AddColumn(0, "OprtNo", false, true, 80);
      AddColumn(0, "OprtName", false, true, 0);
      AddColumn(1, "OprtIsActive", false, false, 1, 60);
      AddColumn(0, "OprtLastLoginTime", false, true, 1, 120);
      AddColumn(0, "OprtDesc", false, false, 0);
      AddColumn(0, "OprtStartDay", false, true, 1, 80);
      AddColumn(0, "OprtEndDay", false, true, 1, 80);
      AddColumn(1, "RoleIsSys", false, false, 1, 60);
      AddColumn(0, "OprtSysID", true, false, 0);
      SetToolItemState("ItemImport", false);
      SetToolItemState("ItemExport", false);
      SetToolItemState("ItemPrint", false);
      SetToolItemState("ItemLine1", false);
      SetToolItemState("ItemTAG1", true);
      SetToolItemState("ItemTAG2", true);
      SetToolItemState("ItemTAG3", true);
      SetToolItemState("ItemLine3", true);
      base.InitForm();
      FuncObject funcObj;
      FuncSubObject funcSubObj;
      funcGrid.Rows.Clear();
      for (int i = 0; i < SystemInfo.funcList.Count; i++)
      {
        funcObj = SystemInfo.funcList[i];
        for (int j = 0; j < funcObj.SubCount; j++)
        {
          funcSubObj = funcObj.SubGet(j);
          if (funcSubObj.IsLine != 2)
          {
            funcGrid.Rows.Add();
            funcGrid[0, funcGrid.RowCount - 1].Value = funcObj.Text;
            funcGrid[1, funcGrid.RowCount - 1].Value = funcSubObj.Text;
            funcGrid[2, funcGrid.RowCount - 1].Value = false;
            funcGrid[3, funcGrid.RowCount - 1].Value = false;
            funcGrid[4, funcGrid.RowCount - 1].Value = false;
            funcGrid[5, funcGrid.RowCount - 1].Value = false;
            funcGrid[6, funcGrid.RowCount - 1].Value = false;
            funcGrid[7, funcGrid.RowCount - 1].Value = funcObj.Name;
            funcGrid[8, funcGrid.RowCount - 1].Value = funcSubObj.Name;
          }
        }
      }
      funcGrid.MergeColumnNames.Add("Column10");
      InitDepartTreeView(tvDepart);
      ExecItemRefresh();
    }

    public frmSYPower()
    {
      InitializeComponent();
    }

    protected override void ExecItemAdd()
    {
      base.ExecItemAdd();
      frmSYPowerAdd frm = new frmSYPowerAdd(this.Text, CurrentTool, "");
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemEdit()
    {
      base.ExecItemEdit();
      frmSYPowerAdd frm = new frmSYPowerAdd(this.Text, CurrentTool, GetOprtSysID());
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemTAG1()
    {
      base.ExecItemTAG1();
      frmSYPowerFunc frm = new frmSYPowerFunc(this.Text, CurrentTool, GetOprtSysID());
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemTAG2()
    {
      base.ExecItemTAG2();
      frmSYPowerDept frm = new frmSYPowerDept(this.Text, CurrentTool, GetOprtSysID());
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemTAG3()
    {
      base.ExecItemTAG3();
      new frmSYPassword(this.Text + "[" + CurrentTool + "]", GetOprtNo()).ShowDialog();
    }

    protected override void ExecItemRefresh()
    {
      QuerySQL = Pub.GetSQL(DBCode.DB_000003, new string[] { "0" });
      base.ExecItemRefresh();
    }

    private void LoadDataDepartSub(TreeNode node, string GUID)
    {
      DataTableReader dr = null;
      for (int i = 0; i < node.Nodes.Count; i++)
      {
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000003, new string[] { "106", GUID, node.Nodes[i].Tag.ToString() }));
        if (dr.Read())
        {
          node.Nodes[i].StateImageIndex = 1;
        }
        LoadDataDepartSub(node.Nodes[i], GUID);
      }
    }

    protected override void RefreshForm(bool State)
    {
      base.RefreshForm(State);
      for (int i = 0; i < funcGrid.RowCount; i++)
      {
        for (int j = 2; j <= 6; j++)
        {
          funcGrid[j, i].Value = false;
        }
      }
      SetTreeViewStateImageIndex(tvDepart, false);
      if (bindingSource.Count > 0)
      {
        DataRowView drv = (DataRowView)bindingSource.Current;
        bool IsSys = Pub.ValueToBool(drv.Row["RoleIsSys"].ToString());
        ItemEdit.Enabled = ItemEdit.Enabled && !IsSys;
        ItemDelete.Enabled = ItemDelete.Enabled && !IsSys;
        ItemTAG1.Enabled = ItemTAG1.Enabled && !IsSys;
        ItemTAG2.Enabled = ItemTAG2.Enabled && !IsSys;
        ItemTAGExt.Enabled = ItemTAGExt.Enabled && !IsSys;
        for (int i = 0; i < ItemTAGExt.DropDownItems.Count; i++)
        {
          ItemTAGExt.DropDownItems[i].Enabled = ItemTAGExt.Enabled;
        }
        SetContextMenuState();
        if (IsSys)
        {
          string id = drv.Row["OprtNo"].ToString().ToLower();
          if (id == "admin")
          {
            for (int i = 0; i < funcGrid.RowCount; i++)
            {
              for (int j = 2; j <= 6; j++)
              {
                funcGrid[j, i].Value = true;
              }
            }
          }
          else if (id == "browser")
          {
            for (int i = 0; i < funcGrid.RowCount; i++)
            {
              funcGrid[2, i].Value = true;
            }
          }
          else if (id == "operator")
          {
            for (int i = 0; i < funcGrid.RowCount; i++)
            {
              for (int j = 2; j <= 6; j++)
              {
                funcGrid[j, i].Value = true;
              }
            }
          }
          SetTreeViewStateImageIndex(tvDepart, true);
        }
        else
        {
          DataTableReader dr = null;
          string GUID = drv.Row["OprtSysID"].ToString();
          string ModuleID;
          string SubID;
          try
          {
            for (int i = 0; i < funcGrid.RowCount; i++)
            {
              ModuleID = funcGrid[7, i].Value.ToString();
              SubID = funcGrid[8, i].Value.ToString();
              dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000003, new string[] { "103", GUID, ModuleID, SubID }));
              if (dr.Read())
              {
                funcGrid[2, i].Value = dr["Power_E"].ToString().ToLower() == "y";
                funcGrid[3, i].Value = dr["Power_A"].ToString().ToLower() == "y";
                funcGrid[4, i].Value = dr["Power_M"].ToString().ToLower() == "y";
                funcGrid[5, i].Value = dr["Power_D"].ToString().ToLower() == "y";
                funcGrid[6, i].Value = dr["Power_C"].ToString().ToLower() == "y";
              }
              dr.Close();
            }
            for (int i = 0; i < tvDepart.Nodes.Count; i++)
            {
              dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000003, new string[] { "106", GUID, 
                tvDepart.Nodes[i].Tag.ToString() }));
              if (dr.Read())
              {
                tvDepart.Nodes[i].StateImageIndex = 1;
              }
              dr.Close();
              LoadDataDepartSub(tvDepart.Nodes[i], GUID);
            }
          }
          catch (Exception E)
          {
            Pub.ShowErrorMsg(E);
          }
          finally
          {
            if (dr != null) dr.Close();
            dr = null;
          }
        }
      }
    }

    protected override void GetDelSql(int rowIndex, ref List<string> sql)
    {
      string ret = "";
      bool IsSys = false;
      bool.TryParse(dataGrid[8, rowIndex].Value.ToString(), out IsSys);
      if (!IsSys)
      {
        ret = Pub.GetSQL(DBCode.DB_000003, new string[] { "3", dataGrid[9, rowIndex].Value.ToString() });
        sql.Add(ret);
      }
    }

    protected override string GetDelMsg(int rowIndex)
    {
      string ret = base.GetDelMsg(rowIndex);
      bool IsSys = false;
      bool.TryParse(dataGrid[8, rowIndex].Value.ToString(), out IsSys);
      if (!IsSys)
      {
        ret = dataGrid.Columns[1].HeaderText + "=" + dataGrid[1, rowIndex].Value.ToString() + "," +
          dataGrid.Columns[2].HeaderText + "=" + dataGrid[2, rowIndex].Value.ToString();
      }
      return ret;
    }

    private string GetOprtSysID()
    {
      DataRowView drv = (DataRowView)bindingSource.Current;
      return drv.Row["OprtSysID"].ToString();
    }

    private string GetOprtNo()
    {
      DataRowView drv = (DataRowView)bindingSource.Current;
      return drv.Row["OprtNo"].ToString();
    }
  }
}