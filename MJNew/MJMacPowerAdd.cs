using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmMJMacPowerAdd : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "MJMacPowerAdd";
      CreateCardGridView(cardGrid);
      CreateDoorGridView(doorGrid, true);
      base.InitForm();
      lblQuickSearchToolTip.ForeColor = Color.Blue;
      this.Text = Title + "[" + CurrentOprt + "]";
      label1.ForeColor = Color.Red;
      LoadData();
    }

    public frmMJMacPowerAdd(string title, string CurrentTool, string GUID)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      InitializeComponent();
    }

    private void btnQuickSearch_Click(object sender, EventArgs e)
    {
      QuickSearchNormalCard(btnQuickSearch.Text, cardGrid, 0, false, true);
    }

    private void txtQuickSearch_KeyDown(object sender, KeyEventArgs e)
    {
      QuickSearchNormalCard(txtQuickSearch, e, cardGrid, 0, false, true);
    }

    private void LoadData()
    {
      DataTableReader dr = null;
      TCommonType ctype;
      cbbID.Items.Clear();
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003003, new string[] { "1000" }));
        while (dr.Read())
        {
          ctype = new TCommonType(dr["MacTimeHeaderSysID"].ToString(), dr["MacTimeHeaderTimeNo"].ToString(),
            dr["MacTimeHeaderName"].ToString());
          cbbID.Items.Add(ctype);
        }
        bindingSource.DataSource = db.GetDataTable(Pub.GetSQL(DBCode.DB_003001, new string[] { "1007" }));
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
      cbbID.SelectedIndex = 1;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      SelectDoor(true);
    }

    private void button2_Click(object sender, EventArgs e)
    {
      SelectDoor(false);
    }

    private void SelectDoor(bool state)
    {
      for (int i = 0; i < doorGrid.RowCount; i++)
      {
        doorGrid[0, i].Value = state;
      }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (cbbID.SelectedIndex < 0)
      {
        ShowErrorSelectCorrect(label1.Text);
        return;
      }
      if (cardGrid.RowCount == 0)
      {
        Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorSelectEmp", ""));
        return;
      }
      bool HasDoor = false;
      for (int i = 0; i < doorGrid.RowCount; i++)
      {
        if (Pub.ValueToBool(doorGrid[0, i].Value))
        {
          HasDoor = true;
          break;
        }
      }
      if (!HasDoor)
      {
        Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorSelectDoor", ""));
        return;
      }
      string TimeNo = ((TCommonType)cbbID.Items[cbbID.SelectedIndex]).id;
      List<string> sql = new List<string>();
      string EmpSysID = "";
      string MacSysID="";
      string MacDoorSysID = "";
      DataTableReader dr = null;
      bool IsError = false;
      string flag = "";
      DataTable dtGrid = (DataTable)cardGrid.DataSource;
      try
      {
        for (int i = 0; i < dtGrid.Rows.Count; i++)
        {
          EmpSysID = dtGrid.Rows[i]["EmpSysID"].ToString();
          for (int j = 0; j < doorGrid.RowCount; j++)
          {
            MacSysID = doorGrid[4, j].Value.ToString();
            MacDoorSysID = doorGrid[5, j].Value.ToString();
            if (Pub.ValueToBool(doorGrid[0, j].EditedFormattedValue))
            {
              dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003004, new string[] { "1", EmpSysID, MacSysID, MacDoorSysID }));
              flag = dr.Read() ? "3" : "2";
              sql.Add(Pub.GetSQL(DBCode.DB_003004, new string[] { flag, EmpSysID, MacSysID, MacDoorSysID, TimeNo }));
            }
          }
        }
      }
      catch (Exception E)
      {
        IsError = true;
        Pub.ShowErrorMsg(E);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      if (IsError) return;
      if (db.ExecSQL(sql) != 0) return;
      db.WriteSYLog(this.Text, CurrentOprt, sql);
      Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      cardGrid.DataSource = null;
    }
  }
}