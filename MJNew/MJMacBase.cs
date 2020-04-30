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
    protected List<TConnInfoNewMJ> connList = new List<TConnInfoNewMJ>();
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
          QueryCoin = Pub.GetSQL(DBCode.DB_003001, new string[] { "1001" });
          break;
        case 2:
          QueryCoin = Pub.GetSQL(DBCode.DB_003001, new string[] { "1002" });
          break;
        case 3:
          QueryCoin = Pub.GetSQL(DBCode.DB_003001, new string[] { "1011" });
          break;
      }
      QuerySQL = Pub.GetSQL(DBCode.DB_003001, new string[] { "1000", QueryCoin });
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
      TConnInfoNewMJ connInfo;
      connList.Clear();
      if (dataGrid.RowCount == 1)
      {
        int row = 0;
        connInfo = Pub.ValueToNewMJConnInfo(dataGrid[2, row].Value.ToString(), dataGrid[3, row].Value.ToString(),
          dataGrid[4, row].Value.ToString(), dataGrid[5, row].Value.ToString(), dataGrid[6, row].Value.ToString());
        connList.Add(connInfo);
      }
      else
      {
        for (int i = 0; i < dataGrid.RowCount; i++)
        {
          if (Pub.ValueToBool(dataGrid[0, i].EditedFormattedValue))
          {
            connInfo = Pub.ValueToNewMJConnInfo(dataGrid[2, i].Value.ToString(), dataGrid[3, i].Value.ToString(),
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
      TConnInfoNewMJ conn;
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
          AccessV2API.TYPE_DoorBasic upInfo;
          byte DoorID;
          string DoorPassword="";
          for (int i = 0; i < connList.Count; i++)
          {
            conn = connList[i];
            SysID = GetMacSysID(conn.MacSN.ToString());
            dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003001, new string[] { "7", SysID }));
            while (dr.Read())
            {
              doorInfo = new TMJUpDoorInfo();
              doorInfo.MacSN = conn.MacSN;
              byte.TryParse(dr["MacDoorID"].ToString(), out DoorID);
              doorInfo.DoorID = DoorID;
              upInfo = new AccessV2API.TYPE_DoorBasic();
              UInt32.TryParse(dr["MacDoorDelay"].ToString(), out upInfo.LockedDelay);
              UInt32.TryParse(dr["MacDoorInterval"].ToString(), out upInfo.Interval);
              DoorPassword = dr["MacDoorPassword"].ToString();
              if (DoorPassword.Length >= 16)
              {
                upInfo.PasswordA = DoorPassword.Substring(0, 8);
                upInfo.PasswordB = DoorPassword.Substring(8, 8);
              }
              else
              {
                upInfo.PasswordA = "00000000";
                upInfo.PasswordB = "00000000";
              }
              doorInfo.DoorInfo = upInfo;
              upDoorInfo.Add(doorInfo);
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
      }
      if (IsError) return;
      RefreshForm(false);
      DateTime start = new DateTime();
      start = DateTime.Now;
      string ExecTimes = "";
      for (int i = 0; i < connList.Count; i++)
      {
        conn = connList[i];
        RefreshMsg(currOprt + "[" + conn.MacSN.ToString() + "]......");
        DeviceObject.objMJNew.NewDevice(conn);
        state = ExecMacCommand(flag, conn.MacSN.ToString(), ref MacMsg);
        ExecTimes = "    " + Pub.GetDateDiffTimes(start, DateTime.Now);
        if (MacMsg != "") MacMsg = "[" + MacMsg + "]";
        SetMacResult(conn.MacSN.ToString(), state, MacMsg + GetErrMsg(state) + ExecTimes);
        msg = msg + GetMacMsg(conn.MacSN.ToString()) + ":" + MacMsg + GetErrMsg(state) + ";";
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
      }
      e.Cancel = !dataGrid.Enabled;
    }

    protected bool SyncTime()
    {
      bool ret = false;
      DateTime dt = new DateTime();
      if (db.GetServerDate(ref dt))
      {
        AccessV2API.TYPE_Setting setting = new AccessV2API.TYPE_Setting();
        ret = DeviceObject.objMJNew.ReadSetting(out setting);
        if (ret)
        {
          DeviceObject.objMJNew.DateTimeToMJDateTime(dt, ref setting.DateTime);
          ret = DeviceObject.objMJNew.SetSetting(setting);
        }
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

    protected string GetErrMsg(bool ret)
    {
      return ret ? Pub.GetResText("", "MsgSuccess", "") : Pub.GetResText("", "MsgFailure", "");
    }
  }

  public class TMJUpDoorInfo
  {
    private UInt32 macSN = 0;
    private byte doorID = 0;
    private AccessV2API.TYPE_DoorBasic doorInfo = new AccessV2API.TYPE_DoorBasic();

    public UInt32 MacSN
    {
      get { return macSN; }
      set { macSN = value; }
    }

    public byte DoorID
    {
      get { return doorID; }
      set { doorID = value; }
    }

    public AccessV2API.TYPE_DoorBasic DoorInfo
    {
      get { return doorInfo; }
      set { doorInfo = value; }
    }
  }
}