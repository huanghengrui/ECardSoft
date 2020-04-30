using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmKQMacBase : frmBaseMDIChildGrid
  {
    protected List<QHKS.TConnInfo> connList = new List<QHKS.TConnInfo>();
    protected bool IsExec = false;
    protected int QueryFlag = 0;
    protected int ShowFlag = 0;
    private string currOprt = "";

    protected override void InitForm()
    {
      dataGrid.Columns.Clear();
      AddColumn(1, "SelectCheck", false, false, 1, 60);
      AddColumn(0, "MacSysID", true, false, 0);
      AddColumn(0, "MacSN", false, 0);
      AddColumn(1, "IsBigMac", true, 50);
      AddColumn(0, "MacType", true, false, 0);
      AddColumn(0, "MacConnType", false, false, 0);
      AddColumn(0, "MacIPAddress", false, false, 0);
      AddColumn(0, "MacPort", false, false, 0);
      AddColumn(0, "MacConnPWD", false, false, 0);
      AddColumn(0, "MacPhysicsAddress", false, false, 0);
      AddColumn(0, "MacDesc", false, false, 0);
      if (ShowFlag == 0)
        AddColumn(0, "MacResult", false, false, 0);
      else if (ShowFlag == 1)
        AddColumn(0, "DataCount", false, false, 100);
      AddColumn(0, "MacVersion", true, false, 0);
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
      QuerySQL = Pub.GetSQL(DBCode.DB_002001, new string[] { "0", QueryCoin });
      ExecItemRefresh();
    }

    public frmKQMacBase()
    {
      InitializeComponent();
    }

    protected QHKS.TConnInfo GetRowConnInfo(int RowIndex)
    {
      byte IsBigMac = Convert.ToByte(dataGrid[3, RowIndex].Value);
      int MacSN = Convert.ToInt32(dataGrid[2, RowIndex].Value.ToString());
      byte MacType = 1;
      string MacConnType = dataGrid[5, RowIndex].Value.ToString();
      string MacIPAddress = dataGrid[6, RowIndex].Value.ToString();
      string MacPort = dataGrid[7, RowIndex].Value.ToString();
      string MacConnPWD = dataGrid[8, RowIndex].Value.ToString();
      string MacPhysicsAddress = dataGrid[9, RowIndex].Value.ToString();
      QHKS.TConnInfo connInfo = Pub.ValueToConnInfo(IsBigMac, MacSN, MacType, MacConnType, MacIPAddress,
        MacPort, MacConnPWD, MacPhysicsAddress);
      return connInfo;
    }

    private void RowToConnInfo(int RowIndex)
    {
      connList.Add(GetRowConnInfo(RowIndex));
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
      QHKS.TConnInfo conn;
      bool state;
      string msg = "";
      string MacMsg = "";
      if (!InitMacList(IsMac)) return;
      IsExec = true;
      string MacVer = "";
      string tmp = "";
      RefreshForm(false);
      DateTime start = new DateTime();
      start = DateTime.Now;
      string ExecTimes = "";
      for (int i = 0; i < connList.Count; i++)
      {
        conn = connList[i];
        RefreshMsg(currOprt + "[" + conn.MacSN.ToString() + "]......");
        DeviceObject.objKS.Init(ref conn);
        state = true;
        if (IsMac)
        {
          state = DeviceObject.objKS.SysDeviceInfoGet(ref MacVer);
          if (MacVer == null) MacVer = "";
          if (state) DeviceObject.objKS.InitMacVer(MacVer);
        }
        if (state) state = ExecMacCommand(flag, conn.MacSN, ref MacMsg);
        ExecTimes = "    " + Pub.GetDateDiffTimes(start, DateTime.Now);
        if (IsMac)
        {
          if (MacMsg != "") MacMsg = "[" + MacMsg + "]";
          tmp = MacVer == "" ? "" : "(" + MacVer + ")";
          SetMacResult(conn.MacSN, state, MacMsg + DeviceObject.objKS.ErrMsg + tmp + ExecTimes);
          msg = msg + GetMacMsg(conn.MacSN) + ":" + MacMsg + DeviceObject.objKS.ErrMsg + ";";
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

    protected virtual bool ExecMacCommand(byte flag, int MacSN, ref string MacMsg)
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

    protected string GetMacType()
    {
      DataRowView drv = (DataRowView)bindingSource.Current;
      if (drv == null)
        return "";
      else
        return drv.Row["MacType"].ToString();
    }

    protected string GetMacType(int rowIndex)
    {
      if (rowIndex < 0)
        return "";
      else
        return dataGrid[4, rowIndex].Value.ToString();
    }

    protected string GetMacType(string MacSN)
    {
      string ret = "";
      for (int i = 0; i < dataGrid.RowCount; i++)
      {
        if (dataGrid[2, i].Value.ToString() == MacSN)
        {
          ret = dataGrid[4, i].Value.ToString();
          break;
        }
      }
      return ret;
    }

    private void frmKQMacBase_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (IsExec)
      {
        IsExec = false;
        DeviceObject.objKS.Close();
      }
      e.Cancel = !dataGrid.Enabled;
    }

    protected bool SyncTime()
    {
      bool ret = false;
      DateTime dt = new DateTime();
      if (db.GetServerDate(ref dt))
      {
        ret = DeviceObject.objKS.PubTimeSet(dt);
      }
      return ret;
    }
  }
}