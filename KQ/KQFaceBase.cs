using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmKQFaceBase : frmBaseMDIChildGrid
  {
    private List<TConnInfoFinger> connList = new List<TConnInfoFinger>();
    protected bool IsExec = false;
    protected int QueryFlag = 0;
    protected int ShowFlag = 0;
    private string currOprt = "";
    protected bool ShowTextMsg = false;

    protected override void InitForm()
    {
      dataGrid.Columns.Clear();
      AddColumn(1, "SelectCheck", false, false, 1, 60);
      AddColumn(0, "MacSysID", true, false, 0);
      AddColumn(0, "MacSN", false, 0);
      AddColumn(0, "MacTypeID", true, false, 0);
      AddColumn(0, "MacTypeName", true, false, 0);
      AddColumn(0, "MacConnType", false, false, 0);
      AddColumn(0, "MacIPAddress", false, false, 0);
      AddColumn(0, "MacPort", false, false, 0);
      AddColumn(0, "MacConnPWD", false, false, 0);
      AddColumn(1, "IsGPRS", false, false, 1, 60);
      AddColumn(0, "MacDesc", false, false, 0);
      if (ShowFlag == 0)
        AddColumn(0, "MacResult", false, false, 0);
      else if (ShowFlag == 1)
        AddColumn(0, "DataCount", false, false, 100);
      base.InitForm();
      string QueryCoin = "";
      switch (QueryFlag)
      {
        case 1:
          QueryCoin = Pub.GetSQL(DBCode.DB_002001, new string[] { "103" });
          break;
        case 255:
          QueryCoin = Pub.GetSQL(DBCode.DB_002001, new string[] { "107" });
          break;
      }
      QuerySQL = Pub.GetSQL(DBCode.DB_002001, new string[] { "2000", QueryCoin });
      ExecItemRefresh();
    }

    public frmKQFaceBase()
    {
      InitializeComponent();
    }

    private void RowToConnInfo(int RowIndex)
    {
      int MacSN = 0;
      string MacSN_GRPS = "";
      bool IsGPRS = Pub.ValueToBool(dataGrid[9, RowIndex].Value.ToString());
      if (IsGPRS)
        MacSN_GRPS = dataGrid[2, RowIndex].Value.ToString();
      else
      {
        MacSN = Convert.ToInt32(dataGrid[2, RowIndex].Value.ToString());
        MacSN_GRPS = MacSN.ToString();
      }
      byte MacType = Convert.ToByte(dataGrid[3, RowIndex].Value.ToString());
      string MacConnType = dataGrid[5, RowIndex].Value.ToString();
      string MacIPAddress = dataGrid[6, RowIndex].Value.ToString();
      string MacPort = dataGrid[7, RowIndex].Value.ToString();
      string MacConnPWD = dataGrid[8, RowIndex].Value.ToString();
      TConnInfoFinger conn = Pub.ValueToConnInfoFinger(MacSN, MacSN_GRPS, MacConnType, MacIPAddress, MacPort, MacConnPWD, IsGPRS);
      connList.Add(conn);
    }

    private bool InitMacList(bool IsMac)
    {
      for (int i = 0; i < dataGrid.RowCount; i++)
      {
        SetMacResult(Convert.ToInt32(dataGrid[2, i].Value.ToString()), true, "");
      }
      connList.Clear();
      if (dataGrid.RowCount == 1)
      {
        RowToConnInfo(0);
      }
      else
      {
        for (int i = 0; i < dataGrid.RowCount; i++)
        {
          if (Pub.ValueToBool(dataGrid[0, i].EditedFormattedValue))
          {
            RowToConnInfo(i);
          }
        }
      }
      if ((connList.Count == 0) && !IsMac)
      {
        RowToConnInfo(dataGrid.CurrentRow.Index);
      }
      if (connList.Count == 0)
      {
        Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorSelectMacOprt", ""));
      }
      return connList.Count > 0;
    }

    private void SetMacResult(int MacSN, bool state, string result)
    {
      for (int i = 0; i < dataGrid.RowCount; i++)
      {
        if (dataGrid[2, i].Value.ToString() == MacSN.ToString())
        {
          if (result == "")
            dataGrid[11, i].Value = result;
          else
          {
            dataGrid[11, i].Value = currOprt + ": " + result;
            if (state)
              dataGrid[11, i].Style.ForeColor = Color.Blue;
            else
              dataGrid[11, i].Style.ForeColor = Color.Red;
          }
          break;
        }
      }
    }
    protected void ExecMacOprt(byte flag)
    {
      ExecMacOprt(flag, true);
    }

    protected void ExecMacOprt(byte flag, bool IsMac)
    {
      currOprt = CurrentTool;
      bool state;
      string msg = "";
      string MacMsg = "";
      if (!InitMacList(IsMac)) return;
      IsExec = true;
      string tmp = "";
      RefreshForm(false);
      DateTime start = new DateTime();
      start = DateTime.Now;
      string ExecTimes = "";
      txtMag.Text = "";
      for (int i = 0; i < connList.Count; i++)
      {
        TConnInfoFinger conn = connList[i];
        RefreshMsg(currOprt + "[" + conn.MacSN.ToString() + "]......");
        DeviceObject.objFK623.InitConn(conn);
        state = ExecMacCommand(flag, conn.MacSN, conn.MacType, ref MacMsg);
        ExecTimes = "    " + Pub.GetDateDiffTimes(start, DateTime.Now);
        if (IsMac)
        {
          if (MacMsg != "") MacMsg = "[" + MacMsg + "]";
          tmp = DeviceObject.objFK623.ErrMsg;
          SetMacResult(conn.MacSN, state, MacMsg + tmp + ExecTimes);
          msg = msg + GetMacMsg(conn.MacSN) + ":" + MacMsg + DeviceObject.objFK623.ErrMsg + ";";
        }
        else if (state)
        {
          SetMacResult(conn.MacSN, state, Pub.GetResText(formCode, "MsgSaveSucceed", "") + ExecTimes);
          msg = msg + GetMacMsg(conn.MacSN) + ":" + Pub.GetResText(formCode, "MsgSaveSucceed", "") + MacMsg + ";";
        }
        else
        {
          SetMacResult(conn.MacSN, state, Pub.GetResText(formCode, "MsgSaveFailed", "") + ExecTimes);
          msg = msg + GetMacMsg(conn.MacSN) + ":" + Pub.GetResText(formCode, "MsgSaveFailed", "") + MacMsg + ";";
        }
        Application.DoEvents();
        start = DateTime.Now;
        if (!IsExec) break;
      }
      db.WriteSYLog(this.Text, currOprt, msg);
      IsExec = false;
      RefreshForm(true);
      RefreshMsg("");
    }

    protected virtual bool ExecMacCommand(byte flag, int MacSN, byte MacType, ref string MacMsg)
    {
      MacMsg = "";
      return false;
    }

    protected string GetMacMsg(int MacSN)
    {
      string ret = dataGrid.Columns[2].HeaderText + "=" + MacSN.ToString();
      return ret;
    }

    protected string GetMacSysID()
    {
      DataRowView drv = (DataRowView)bindingSource.Current;
      if (drv == null)
        return "";
      else
        return drv.Row["MacSysID"].ToString();
    }

    protected string GetMacSysID(int rowIndex)
    {
      if (rowIndex < 0)
        return "";
      else
        return dataGrid[1, rowIndex].Value.ToString();
    }

    protected string GetMacSysID(string MacSN)
    {
      string ret = "";
      for (int i = 0; i < dataGrid.RowCount; i++)
      {
        if (dataGrid[2, i].Value.ToString() == MacSN)
        {
          ret = dataGrid[1, i].Value.ToString();
          break;
        }
      }
      return ret;
    }

    protected byte GetMacType()
    {
      DataRowView drv = (DataRowView)bindingSource.Current;
      if (drv == null)
        return 0;
      else
        return Convert.ToByte(drv.Row["MacTypeID"].ToString());
    }

    protected byte GetMacType(int rowIndex)
    {
      if (rowIndex < 0)
        return 0;
      else
        return Convert.ToByte(dataGrid[2, rowIndex].Value.ToString());
    }

    protected byte GetMacType(string MacSN)
    {
      byte ret = 0;
      for (int i = 0; i < dataGrid.RowCount; i++)
      {
        if (dataGrid[1, i].Value.ToString() == MacSN)
        {
          ret = Convert.ToByte(dataGrid[2, i].Value.ToString());
          break;
        }
      }
      return ret;
    }

    private void frmKQFaceBase_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (IsExec)
      {
        IsExec = false;
      }
      e.Cancel = !dataGrid.Enabled;
    }

    protected bool SyncTime(byte MacType)
    {
      bool ret = false;
      DateTime dt = new DateTime();
      if (db.GetServerDate(ref dt))
      {
        ret = DeviceObject.objFK623.SetDeviceTime(dt);
      }
      return ret;
    }

    protected void ShowMsg(string msg)
    {
      txtMag.Text = txtMag.Text + msg;
    }

    protected override void RefreshForm(bool State)
    {
      base.RefreshForm(State);
      txtMag.Enabled = State && !IsExec && ShowTextMsg;
      txtMag.Visible = ShowTextMsg;
    }
  }
}