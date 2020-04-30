using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmSYPowerFunc : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "SYPowerFunc";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
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
      funcGrid.MergeColumnNames.Add("Column1");
      LoadData();
    }

    public frmSYPowerFunc(string title, string CurrentTool, string GUID)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      InitializeComponent();
    }

    private void LoadData()
    {
      DataTableReader dr = null;
      string ModuleID;
      string SubID;
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        for (int i = 0; i < funcGrid.RowCount; i++)
        {
          ModuleID = funcGrid[7, i].Value.ToString();
          SubID = funcGrid[8, i].Value.ToString();
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000003, new string[] { "103", SysID, ModuleID, SubID }));
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

    private void SelectAllItem(bool state)
    {
      for (int i = 0; i < funcGrid.Rows.Count; i++)
      {
        funcGrid[2, i].Value = state;
        if (!state)
        {
          for (int j = 3; j <= 6; j++)
          {
            funcGrid[j, i].Value = state;
          }
        }
      }
    }

    private void SelectCurrentItem(bool state)
    {
      string item = funcGrid[0, funcGrid.CurrentRow.Index].Value.ToString();
      for (int i = 0; i < funcGrid.Rows.Count; i++)
      {
        if (funcGrid[0, i].Value.ToString() == item)
        {
          funcGrid[2, i].Value = state;
          if (!state)
          {
            for (int j = 3; j <= 6; j++)
            {
              funcGrid[j, i].Value = state;
            }
          }
        }
      }
    }

    private void SelectItemRole(int itemIndex, bool state)
    {
      for (int i = 0; i < funcGrid.Rows.Count; i++)
      {
        if (itemIndex == 255)
        {
          for (int j = 2; j <= 6; j++)
          {
            funcGrid[j, i].Value = state;
          }
        }
        else if (Pub.ValueToBool(funcGrid[2, i].Value))
        {
          funcGrid[itemIndex, i].Value = state;
        }
      }
    }

    private void ItemSelect_Click(object sender, EventArgs e)
    {
      SelectAllItem(true);
    }

    private void ItemUnselect_Click(object sender, EventArgs e)
    {
      SelectAllItem(false);
    }

    private void ItemSelectCurrent_Click(object sender, EventArgs e)
    {
      SelectCurrentItem(true);
    }

    private void ItemSelectUnCurrent_Click(object sender, EventArgs e)
    {
      SelectCurrentItem(false);
    }

    private void ItemSelectNewAll_Click(object sender, EventArgs e)
    {
      SelectItemRole(3, true);
    }

    private void ItemSelectNewUnAll_Click(object sender, EventArgs e)
    {
      SelectItemRole(3, false);
    }

    private void ItemSelectEditAll_Click(object sender, EventArgs e)
    {
      SelectItemRole(4, true);
    }

    private void ItemSelectEditUnAll_Click(object sender, EventArgs e)
    {
      SelectItemRole(4, false);
    }

    private void ItemSelectDeleteAll_Click(object sender, EventArgs e)
    {
      SelectItemRole(5, true);
    }

    private void ItemSelectDeleteUnAll_Click(object sender, EventArgs e)
    {
      SelectItemRole(5, false);
    }

    private void ItemSelectExtAll_Click(object sender, EventArgs e)
    {
      SelectItemRole(6, true);
    }

    private void ItemSelectExtUnAll_Click(object sender, EventArgs e)
    {
      SelectItemRole(6, false);
    }

    private void ItemSelectAll_Click(object sender, EventArgs e)
    {
      SelectItemRole(255, true);
    }

    private void ItemSelectUnAll_Click(object sender, EventArgs e)
    {
      SelectItemRole(255, false);
    }

    private void funcGrid_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if ((e.RowIndex >= 0) && (e.RowIndex < funcGrid.Rows.Count) && (e.ColumnIndex >= 2) && (e.ColumnIndex <= 6))
      {
        funcGrid[e.ColumnIndex, e.RowIndex].Value = !Pub.ValueToBool(funcGrid[e.ColumnIndex, e.RowIndex].Value);
        switch (e.ColumnIndex)
        {
          case 2:
            break;
          case 3:
          case 4:
          case 5:
          case 6:
            if (Pub.ValueToBool(funcGrid[e.ColumnIndex, e.RowIndex].Value)) funcGrid[2, e.RowIndex].Value = true;
            break;
        }
      }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      List<string> sql = new List<string>();
      string ModuleID;
      string SubID;
      string Power_E;
      string Power_A;
      string Power_M;
      string Power_D;
      string Power_Ext;
      sql.Add(Pub.GetSQL(DBCode.DB_000003, new string[] { "101", SysID }));
      for (int i = 0; i < funcGrid.Rows.Count; i++)
      {
        if (Pub.ValueToBool(funcGrid[2, i].Value))
        {
          ModuleID = funcGrid[7, i].Value.ToString();
          SubID = funcGrid[8, i].Value.ToString();
          Power_E = "Y";
          Power_A = "N";
          Power_M = "N";
          Power_D = "N";
          Power_Ext = "N";
          if (Pub.ValueToBool(funcGrid[3, i].Value)) Power_A = "Y";
          if (Pub.ValueToBool(funcGrid[4, i].Value)) Power_M = "Y";
          if (Pub.ValueToBool(funcGrid[5, i].Value)) Power_D = "Y";
          if (Pub.ValueToBool(funcGrid[6, i].Value)) Power_Ext = "Y";
          sql.Add(Pub.GetSQL(DBCode.DB_000003, new string[] { "102", SysID, ModuleID, SubID, 
            Power_E, Power_A, Power_M, Power_D, Power_Ext }));
        }
      }
      if (db.ExecSQL(sql) != 0) return;
      db.WriteSYLog(this.Text, CurrentOprt, sql);
      Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
  }
}