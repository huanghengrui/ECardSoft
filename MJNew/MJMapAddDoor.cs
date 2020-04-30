using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmMJMapAddDoor : frmBaseDialog
  {
    public List<TMapDoorInfo> doorList = new List<TMapDoorInfo>();

    protected override void InitForm()
    {
      formCode = "MJMapAddDoor";
      dataGrid.Columns.Clear();
      AddColumn(dataGrid, 1, "SelectCheck", false, false, 1, 60);
      AddColumn(dataGrid, 0, "MacSysID", true, false, 0, 0);
      AddColumn(dataGrid, 0, "MacDoorSysID", true, false, 0, 0);
      AddColumn(dataGrid, 0, "MacSN", false, false, 1, 80);
      AddColumn(dataGrid, 0, "MacDoorID", false, false, 1, 80);
      AddColumn(dataGrid, 0, "MacDoorName", false, false, 1, 160);
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      LoadData();
    }

    public frmMJMapAddDoor(string title, string CurrentTool, string GUID)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      InitializeComponent();
    }

    private void LoadData()
    {
      dataGrid.Rows.Clear();
      DataTableReader dr = null;
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003001, new string[] { "101" }));
        while (dr.Read())
        {
          dataGrid.Rows.Add();
          dataGrid[0, dataGrid.RowCount - 1].Value = false;
          dataGrid[1, dataGrid.RowCount - 1].Value = dr["MacSysID"];
          dataGrid[2, dataGrid.RowCount - 1].Value = dr["MacDoorSysID"];
          dataGrid[3, dataGrid.RowCount - 1].Value = dr["MacSN"];
          dataGrid[4, dataGrid.RowCount - 1].Value = dr["MacDoorID"];
          dataGrid[5, dataGrid.RowCount - 1].Value = dr["MacDoorName"];
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
      for (int i = 0; i < doorList.Count; i++)
      {
        for (int j = 0; j < dataGrid.RowCount; j++)
        {
          if (dataGrid[2, j].Value.ToString() == doorList[i].DoorSysID)
          {
            dataGrid[0, j].Value = true;
            break;
          }
        }
      }
    }

    private void SelectDoor(bool state)
    {
      for (int i = 0; i < dataGrid.RowCount; i++)
      {
        dataGrid[0, i].Value = state;
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      SelectDoor(true);
    }

    private void button2_Click(object sender, EventArgs e)
    {
      SelectDoor(false);
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      doorList.Clear();
      TMapDoorInfo doorInfo;
      for (int i = 0; i < dataGrid.RowCount; i++)
      {
        if (Pub.ValueToBool(dataGrid[0, i].EditedFormattedValue))
        {
          doorInfo = new TMapDoorInfo(dataGrid[2, i].Value.ToString(), dataGrid[3, i].Value.ToString(), 
            dataGrid[4, i].Value.ToString(), dataGrid[5, i].Value.ToString());
          doorList.Add(doorInfo);
        }
      }
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
  }
}