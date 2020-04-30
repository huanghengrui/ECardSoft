using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmMJMacBase : frmBaseMDIChildGrid
  {
    protected List<QHKS.TMJConnInfo> connList = new List<QHKS.TMJConnInfo>();
    protected List<TMJUpDoorInfo> upDoorInfo = new List<TMJUpDoorInfo>();
    protected bool IsExec = false;
    protected int ShowFlag = 0;
    protected int QueryFlag = 0;
    protected List<string> ExtField = new List<string>();
    private int ResultIndex = 9;
    protected bool HideExtField = false;
    private string currOprt = "";

    protected override void InitForm()
    {
      dataGrid.Columns.Clear();
      AddColumn(1, "SelectCheck", IgnoreSelect, false, 1, 60);
      AddColumn(0, "MacSysID", true, false, 0);
      AddColumn(0, "MacSN", false, 0);
      AddColumn(0, "MacConnType", false, false, 0);
      AddColumn(0, "MacIPAddress", false, false, 0);
      AddColumn(0, "MacPort", false, false, 0);
      AddColumn(0, "MacConnPWD", true, false, 0);
      AddColumn(0, "SendKey", true, false, 0);
      AddColumn(0, "MacDesc", false, false, 0);
      for (int i = 0; i < ExtField.Count; i++)
      {
        AddColumn(0, ExtField[i], HideExtField, false, 100);
        ResultIndex += 1;
      }
      if (ShowFlag == 0)
        AddColumn(0, "MacResult", false, false, 0);
      else if (ShowFlag == 1)
        AddColumn(0, "DataCount", false, false, 100);
      base.InitForm();
      string QueryCoin = "";
      switch (QueryFlag)
      {
        case 1:
          QueryCoin = Pub.GetSQL(DBCode.DB_003001, new string[] { "201" });
          break;
        case 2:
          QueryCoin = Pub.GetSQL(DBCode.DB_003001, new string[] { "202" });
          break;
      }
      QuerySQL = Pub.GetSQL(DBCode.DB_003001, new string[] { "0", QueryCoin });
      ExecItemRefresh();
    }

    public frmMJMacBase()
    {
      InitializeComponent();
    }

    protected bool InitMacList()
    {
      for (int i = 0; i < dataGrid.RowCount; i++)
      {
        SetMacResult(dataGrid[2, i].Value.ToString(), true, "");
      }
      QHKS.TMJConnInfo connInfo;
      connList.Clear();
      if (dataGrid.RowCount == 1)
      {
        int row = 0;
        connInfo = Pub.ValueToMJConnInfo(dataGrid[2, row].Value.ToString(), dataGrid[3, row].Value.ToString(),
          dataGrid[4, row].Value.ToString(), dataGrid[5, row].Value.ToString(), dataGrid[6, row].Value.ToString());
        connList.Add(connInfo);
      }
      else
      {
        for (int i = 0; i < dataGrid.RowCount; i++)
        {
          if (Pub.ValueToBool(dataGrid[0, i].EditedFormattedValue))
          {
            connInfo = Pub.ValueToMJConnInfo(dataGrid[2, i].Value.ToString(), dataGrid[3, i].Value.ToString(),
              dataGrid[4, i].Value.ToString(), dataGrid[5, i].Value.ToString(), dataGrid[6, i].Value.ToString());
            connList.Add(connInfo);
          }
        }
      }
      if (connList.Count == 0)
      {
        Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorSelectMacOprt", ""));
      }
      return connList.Count > 0;
    }

    private void SetMacResult(string MacSN, bool state, string result)
    {
      for (int i = 0; i < dataGrid.RowCount; i++)
      {
        if (dataGrid[2, i].Value.ToString() == MacSN)
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

    protected void ExecMacOprt(byte flag)
    {
      ExecMacOprt(flag, 0);
    }

    protected void ExecMacOprt(byte flag, byte dataFlag)
    {
      currOprt = CurrentTool;
      QHKS.TMJConnInfo conn;
      bool state;
      string msg = "";
      string MacMsg = "";
      string SysID = "";
      bool IsError = false;
      if (!InitMacList()) return;
      IsExec = true;
      if (dataFlag == 1)
      {
        upDoorInfo.Clear();
        DataTableReader dr = null;
        try
        {
          TMJUpDoorInfo doorInfo;
          QHKS.TMJUpDoorInfo upInfo;
          for (int i = 0; i < connList.Count; i++)
          {
            conn = connList[i];
            SysID = GetMacSysID(conn.MacSN);
            dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003001, new string[] { "7", SysID }));
            doorInfo = new TMJUpDoorInfo();
            doorInfo.MacSN = conn.MacSN;
            while (dr.Read())
            {
              upInfo = new QHKS.TMJUpDoorInfo();
              byte.TryParse(dr["MacDoorID"].ToString(), out upInfo.DoorID);
              byte.TryParse(dr["MacDoorCommandWay"].ToString(), out upInfo.CommandWay);
              byte.TryParse(dr["MacDoorDelay"].ToString(), out upInfo.Delay);
              upInfo.ShowChn = 0;
              upInfo.EnableBuzzer = 0;
              upInfo.PasswordInfo = db.GetMJInOutPassword(conn.MacSN, upInfo.DoorID);
              doorInfo.DoorInfo.Add(upInfo);
            }
            upDoorInfo.Add(doorInfo);
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
      if (IsError) return;
      RefreshForm(false);
      DateTime start = new DateTime();
      start = DateTime.Now;
      string ExecTimes = "";
      for (int i = 0; i < connList.Count; i++)
      {
        conn = connList[i];
        RefreshMsg(currOprt + "[" + conn.MacSN + "]......");
        DeviceObject.objMJ.Init(ref conn);
        state = ExecMacCommand(flag, conn.MacSN, ref MacMsg);
        ExecTimes = "    " + Pub.GetDateDiffTimes(start, DateTime.Now);
        if (MacMsg != "") MacMsg = "[" + MacMsg + "]";
        SetMacResult(conn.MacSN, state, MacMsg + DeviceObject.objMJ.ErrMsg + ExecTimes);
        msg = msg + GetMacMsg(conn.MacSN) + ":" + MacMsg + DeviceObject.objMJ.ErrMsg + ";";
        Application.DoEvents();
        start = DateTime.Now;
        if (!IsExec) break;
      }
      db.WriteSYLog(this.Text, currOprt, msg);
      IsExec = false;
      RefreshForm(true);
      RefreshMsg("");
    }

    protected virtual bool ExecMacCommand(byte flag, string MacSN, ref string MacMsg)
    {
      MacMsg = "";
      return false;
    }

    protected string GetMacMsg(string MacSN)
    {
      string ret = dataGrid.Columns[2].HeaderText + "=" + MacSN;
      return ret;
    }

    protected string GetMacSN()
    {
      DataRowView drv = (DataRowView)bindingSource.Current;
      if (drv == null)
        return "";
      else
        return drv.Row["MacSN"].ToString();
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

    protected string GetExtField(string MacSN)
    {
      return GetExtField(MacSN, 0);
    }

    protected string GetExtField(string MacSN, int ExtIndex)
    {
      string ret = "";
      for (int i = 0; i < dataGrid.RowCount; i++)
      {
        if (dataGrid[2, i].Value.ToString() == MacSN)
        {
          ret = dataGrid[9 + ExtIndex, i].Value.ToString();
          break;
        }
      }
      return ret;
    }

    private void frmMJMacBase_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (IsExec)
      {
        IsExec = false;
        DeviceObject.objMJ.Close();
      }
      e.Cancel = !dataGrid.Enabled;
    }

    protected bool SyncTime()
    {
      bool ret = false;
      DateTime dt = new DateTime();
      if (db.GetServerDate(ref dt))
      {
        ret = DeviceObject.objMJ.SetMacTime(dt);
      }
      return ret;
    }

    protected byte GetDoorID(string MacSN, byte ReaderID)
    {
      int ret = ReaderID;
      if (MacSN.Substring(0, 2) != "04")
      {
        if ((ReaderID == 1) || (ReaderID == 2))
          ret = 1;
        else
          ret = 2;
      }
      return Convert.ToByte(ret);
    }

    protected void ChangeSelectState()
    {
      if (bindingSource.DataSource != null)
      {
        DataTable dt = (DataTable)bindingSource.DataSource;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
          dt.Rows[i].BeginEdit();
          dt.Rows[i]["SelectCheck"] = false;
          dt.Rows[i].EndEdit();
        }
        DataRowView drv = (DataRowView)bindingSource.Current;
        drv.BeginEdit();
        drv.Row["SelectCheck"] = true;
        drv.EndEdit();
      }
    }
  }

  public class TMJUpDoorInfo
  {
    private string macSN = "";
    private List<QHKS.TMJUpDoorInfo> doorInfo = new List<QHKS.TMJUpDoorInfo>();

    public string MacSN
    {
      get { return macSN; }
      set { macSN = value; }
    }

    public List<QHKS.TMJUpDoorInfo> DoorInfo
    {
      get { return doorInfo; }
      set { doorInfo = value; }
    }
  }
}