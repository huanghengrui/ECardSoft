using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmMJMacInfoAddNext : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "MJMacInfoAddNext";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]" + this.Text;
      LoadData();
    }

    public frmMJMacInfoAddNext(string title, string CurrentTool, string GUID)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      InitializeComponent();
    }

    private void LoadData()
    {
      doorGrid.Rows.Clear();
      readGrid.Rows.Clear();
      DataTableReader dr = null;
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003001, new string[] { "7", SysID }));
        while (dr.Read())
        {
          doorGrid.Rows.Add();
          doorGrid[0, doorGrid.RowCount - 1].Tag = dr["MacDoorSysID"].ToString();
          doorGrid[0, doorGrid.RowCount - 1].Value = dr["MacDoorID"].ToString();
          doorGrid[1, doorGrid.RowCount - 1].Value = dr["MacDoorName"].ToString();
          doorGrid[2, doorGrid.RowCount - 1].Value = dr["MacDoorDelay"].ToString();
          doorGrid[3, doorGrid.RowCount - 1].Value = dr["MacDoorInterval"].ToString();
        }
        dr.Close();
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003001, new string[] { "8", SysID }));
        while (dr.Read())
        {
          readGrid.Rows.Add();
          readGrid[0, readGrid.RowCount - 1].Tag = dr["MacReadSysID"].ToString();
          readGrid[0, readGrid.RowCount - 1].Value = dr["MacReadID"].ToString();
          readGrid[1, readGrid.RowCount - 1].Value = dr["MacReadImpact"].ToString();
          readGrid[2, readGrid.RowCount - 1].Value = dr["IsApplyWork"].ToString() == "Y";
          readGrid[3, readGrid.RowCount - 1].Value = dr["IsAndPassword"].ToString() == "Y";
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
      for (int i = 1; i < doorGrid.ColumnCount; i++)
      {
        doorGrid.Columns[i].ReadOnly = false;
      }
      for (int i = 1; i < readGrid.ColumnCount; i++)
      {
        readGrid.Columns[i].ReadOnly = false;
      }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      string v = "";
      for (int i = 0; i < doorGrid.RowCount; i++)
      {
        v = doorGrid[1, i].EditedFormattedValue.ToString();
        if (!Pub.CheckTextMaxLength(doorGrid.Columns[1].HeaderText, v, 50)) return;
        v = doorGrid[2, i].EditedFormattedValue.ToString();
        if (!Pub.IsNumeric(v) || (Convert.ToInt32(v) < 0) || (Convert.ToInt32(v) > 255))
        {
          Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", ""));
          return;
        }
        v = doorGrid[3, i].EditedFormattedValue.ToString();
        if (!Pub.IsNumeric(v) || (Convert.ToInt32(v) < 0) || (Convert.ToInt32(v) > 255))
        {
          Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error002", ""));
          return;
        }
      }
      bool IsOk = false;
      string s1 = "";
      string s2 = "";
      List<string> sql = new List<string>();
      try
      {
        for (int i = 0; i < doorGrid.RowCount; i++)
        {
          sql.Add(Pub.GetSQL(DBCode.DB_003001, new string[] { "1010", doorGrid[1, i].EditedFormattedValue.ToString(), 
            doorGrid[2, i].EditedFormattedValue.ToString(), doorGrid[3, i].EditedFormattedValue.ToString(), 
            doorGrid[0, i].Tag.ToString() }));
        }
        for (int i = 0; i < readGrid.RowCount; i++)
        {
          s1 = Pub.ValueToBool(readGrid[2, i].EditedFormattedValue) ? "Y" : "N";
          s2 = Pub.ValueToBool(readGrid[3, i].EditedFormattedValue) ? "Y" : "N";
          sql.Add(Pub.GetSQL(DBCode.DB_003001, new string[] { "10", readGrid[1, i].EditedFormattedValue.ToString(), 
            s1, s2, readGrid[0, i].Tag.ToString() }));
        }
        if (db.ExecSQL(sql) == 0) IsOk = true;
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E);
      }
      if (IsOk)
      {
        db.WriteSYLog(this.Text, CurrentOprt, sql);
        Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }
  }
}