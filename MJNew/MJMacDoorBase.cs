using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmMJMacDoorBase : frmBaseMDIChildGrid
  {
    protected List<string> ExtField = new List<string>();
    protected List<TMJDoorInfo> doorList = new List<TMJDoorInfo>();
    private int ResultIndex = 6;
    protected bool IsExec = false;
    private string currOprt = "";
    protected byte HideExtField = 0;
    protected bool HideStop = false;
    protected bool IgnoreTAG2State = false;

    protected override void InitForm()
    {
      dataGrid.Columns.Clear();
      AddColumn(1, "SelectCheck", false, false, 1, 60);
      AddColumn(0, "MacSysID", true, false, 0);
      AddColumn(0, "MacDoorSysID", true, false, 0);
      AddColumn(0, "MacSN", false, 80);
      AddColumn(0, "MacDoorID", false, false, 80);
      AddColumn(0, "MacDoorName", false, false, 160);
      for (int i = 0; i < ExtField.Count; i++)
      {
        if (HideExtField == 0)
          AddColumn(0, ExtField[i], false, false, 160);
        else if (HideExtField == 1)
          AddColumn(0, ExtField[i], i > 0, false, 160);
        else
          AddColumn(0, ExtField[i], true, false, 160);
        ResultIndex += 1;
      }
      AddColumn(0, "MacResult", false, false, 0);
      AddColumn(0, "MacConnType", true, false, 0);
      AddColumn(0, "MacIPAddress", true, false, 0);
      AddColumn(0, "MacPort", true, false, 0);
      AddColumn(0, "MacConnPWD", true, false, 0);
      AddColumn(0, "SendKey", true, false, 0);
      SetToolItemState("ItemImport", false);
      SetToolItemState("ItemExport", false);
      SetToolItemState("ItemPrint", false);
      SetToolItemState("ItemLine1", false);
      SetToolItemState("ItemAdd", false);
      SetToolItemState("ItemDelete", false);
      SetToolItemState("ItemTAG1", true);
      if (!HideStop) SetToolItemState("ItemTAG2", true);
      SetToolItemState("ItemLine3", true);
      base.InitForm();
      QuerySQL = Pub.GetSQL(DBCode.DB_003001, new string[] { "1007" });
      ExecItemRefresh();
    }

    public frmMJMacDoorBase()
    {
      InitializeComponent();
    }

    protected string GetMacDoorSysID()
    {
      DataRowView drv = (DataRowView)bindingSource.Current;
      if (drv == null)
        return "";
      else
        return drv.Row["MacDoorSysID"].ToString();
    }

    protected override void ExecItemTAG2()
    {
      base.ExecItemTAG2();
      IsExec = false;
    }

    protected override void RefreshForm(bool State)
    {
      base.RefreshForm(State);
      ItemTAG1.Enabled = ItemTAG1.Enabled && !IsExec;
      if (IgnoreTAG2State)
        ItemTAG2.Enabled = ItemTAG2.Enabled && !IsExec;
      else
        ItemTAG2.Enabled = IsExec && dataGrid.RowCount > 0;
      SetContextMenuState();
    }

    protected bool InitMacDoorList()
    {
      for (int i = 0; i < dataGrid.RowCount; i++)
      {
        SetMacDoorResult(dataGrid[2, i].Value.ToString(), true, "");
      }
      TMJDoorInfo doorInfo;
      doorList.Clear();
      if (dataGrid.RowCount == 1)
      {
        doorInfo = new TMJDoorInfo();
        int row = 0;
        doorInfo.ConnInfo = Pub.ValueToNewMJConnInfo(dataGrid[3, row].Value.ToString(),
          dataGrid[ResultIndex + 1, row].Value.ToString(), dataGrid[ResultIndex + 2, row].Value.ToString(),
          dataGrid[ResultIndex + 3, row].Value.ToString(), dataGrid[ResultIndex + 4, row].Value.ToString());
        doorInfo.DoorSysID = dataGrid[2, row].Value.ToString();
        byte doorID = 0;
        byte.TryParse(dataGrid[4, row].Value.ToString(), out doorID);
        doorInfo.DoorID = doorID;
        doorInfo.DoorName = dataGrid[5, row].Value.ToString();
        for (int i = 0; i < ExtField.Count; i++)
        {
          doorInfo.ExtField.Add(dataGrid[6 + i, row].Value.ToString());
        }
        doorList.Add(doorInfo);
      }
      else
      {
        for (int i = 0; i < dataGrid.RowCount; i++)
        {
          if (Pub.ValueToBool(dataGrid[0, i].EditedFormattedValue))
          {
            doorInfo = new TMJDoorInfo();
            doorInfo.ConnInfo = Pub.ValueToNewMJConnInfo(dataGrid[3, i].Value.ToString(),
              dataGrid[ResultIndex + 1, i].Value.ToString(), dataGrid[ResultIndex + 2, i].Value.ToString(),
              dataGrid[ResultIndex + 3, i].Value.ToString(), dataGrid[ResultIndex + 4, i].Value.ToString());
            doorInfo.DoorSysID = dataGrid[2, i].Value.ToString();
            byte doorID = 0;
            byte.TryParse(dataGrid[4, i].Value.ToString(), out doorID);
            doorInfo.DoorID = doorID;
            doorInfo.DoorName = dataGrid[5, i].Value.ToString();
            for (int j = 0; j < ExtField.Count; j++)
            {
              doorInfo.ExtField.Add(dataGrid[6 + j, i].Value.ToString());
            }
            doorList.Add(doorInfo);
          }
        }
      }
      if (doorList.Count == 0)
      {
        Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorSelectMacDoorOprt", ""));
      }
      return doorList.Count > 0;
    }

    private void SetMacDoorResult(string MacDoorSysID, bool state, string result)
    {
      for (int i = 0; i < dataGrid.RowCount; i++)
      {
        if (dataGrid[2, i].Value.ToString() == MacDoorSysID)
        {
          if (result == "")
            dataGrid[ResultIndex, i].Value = result;
          else
          {
            dataGrid[ResultIndex, i].Value = currOprt + ": " + result;
            if (state)
              dataGrid[ResultIndex, i].Style.ForeColor = Color.Blue;
            else
              dataGrid[ResultIndex, i].Style.ForeColor = Color.Red;
          }
          break;
        }
      }
    }

    protected void ExecMacDoorOprt(byte flag)
    {
      ExecMacDoorOprt(flag, 0);
    }

    protected void ExecMacDoorOprt(byte flag, byte dataFlag)
    {
      currOprt = CurrentTool;
      TMJDoorInfo doorInfo;
      TConnInfoNewMJ connInfo;
      bool state;
      string msg = "";
      string MacMsg = "";
      if (!InitMacDoorList()) return;
      IsExec = true;
      RefreshForm(false);
      DateTime start = new DateTime();
      start = DateTime.Now;
      string ExecTimes = "";
      DataTableReader dr = null;
      bool IsError = false;
      for (int i = 0; i < doorList.Count; i++)
      {
        doorInfo = doorList[i];
        connInfo = doorInfo.ConnInfo;
        RefreshMsg(currOprt + "[" + connInfo.MacSN.ToString() + "  " + doorInfo.DoorID + ":" + doorInfo.DoorName + "]......");
        if (dataFlag == 1)
        {
          try
          {
            dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003001, new string[] { "1009", connInfo.MacSN.ToString() }));
            while (dr.Read())
            {
              doorList[i].DoorPass = dr["MacDoorPassword"].ToString();
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
        }
        if (IsError) break;
        DeviceObject.objMJNew.NewDevice(connInfo);
        state = ExecMacDoorCommand(flag, doorInfo, ref MacMsg);
        ExecTimes = "    " + Pub.GetDateDiffTimes(start, DateTime.Now);
        if (MacMsg != "") MacMsg = "[" + MacMsg + "]";
        SetMacDoorResult(doorInfo.DoorSysID, state, MacMsg + GetErrMsg(state) + ExecTimes);
        msg = msg + GetMacDoorMsg(doorInfo) + ":" + MacMsg + GetErrMsg(state) + ";";
        Application.DoEvents();
        start = DateTime.Now;
        if (!IsExec) break;
      }
      db.WriteSYLog(this.Text, currOprt, msg);
      IsExec = false;
      RefreshForm(true);
      RefreshMsg("");
    }

    protected virtual bool ExecMacDoorCommand(byte flag, TMJDoorInfo doorInfo, ref string MacMsg)
    {
      MacMsg = "";
      return false;
    }

    protected string GetMacDoorMsg(TMJDoorInfo doorInfo)
    {
      string ret = doorInfo.ConnInfo.MacSN + "  " + doorInfo.DoorID + ":" + doorInfo.DoorName + "]";
      return ret;
    }

    protected string GetErrMsg(bool ret)
    {
      return ret ? Pub.GetResText("", "MsgSuccess", "") : Pub.GetResText("", "MsgFailure", "");
    }
  }

  public class TMJDoorInfo
  {
    private TConnInfoNewMJ connInfo;
    private string doorSysID = "";
    private byte doorID = 0;
    private string doorName = "";
    private string doorPass = "";
    private List<string> extField = new List<string>();

    public TConnInfoNewMJ ConnInfo
    {
      get { return connInfo; }
      set { connInfo = value; }
    }

    public string DoorSysID
    {
      get { return doorSysID; }
      set { doorSysID = value; }
    }

    public byte DoorID
    {
      get { return doorID; }
      set { doorID = value; }
    }

    public string DoorName
    {
      get { return doorName; }
      set { doorName = value; }
    }

    public string DoorPass
    {
      get { return doorPass; }
      set { doorPass = value; }
    }

    public List<string> ExtField
    {
      get { return extField; }
      set { extField = value; }
    }
  }
}