using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ECard78
{
  public partial class frmKQFaceOprt : frmBaseForm
  {
    private string title = "";
    private string oprt = "";
    private int flag = 0;
    private List<TConnInfoFinger> connList = new List<TConnInfoFinger>();
    private List<TimeZone> timeList = new List<TimeZone>();
    private List<UInt32> fingerNoList = new List<UInt32>();
    private bool IsWorking = false;

    private void AddColumn(int colType, string Field, int colWidth)
    {
      AddColumn(colType, Field, false, true, colWidth);
    }

    private void AddColumn(int colType, string Field, bool IsHide, int colWidth)
    {
      AddColumn(colType, Field, IsHide, true, colWidth);
    }

    private void AddColumn(int colType, string Field, bool IsHide, bool HasSort, int colWidth)
    {
      AddColumn(colType, Field, IsHide, HasSort, 0, colWidth);
    }

    private void AddColumn(int colType, string Field, bool IsHide, bool HasSort, byte CenterFlag, int colWidth)
    {
      AddColumn(dataGrid, colType, Field, IsHide, HasSort, CenterFlag, colWidth);
    }

    protected override void InitForm()
    {
      formCode = "KQFaceOprt";
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
      base.InitForm();
      this.Text = title;
      btnOprt.Text = oprt;
      toolTip.SetToolTip(btnOprt, btnOprt.Text);
      string QuerySQL = Pub.GetSQL(DBCode.DB_002001, new string[] { "2000" });
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        bindingSource.DataSource = db.GetDataTable(QuerySQL);
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E, QuerySQL);
      }
      RefresButton();
      msgGrid_Resize(null, null);
    }

    public frmKQFaceOprt(string Title, string Oprt, int Flag)
    {
      title = Title;
      oprt = Oprt;
      flag = Flag;
      InitializeComponent();
    }

    private void dataGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
      e.Cancel = true;
    }

    private void msgGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
      e.Cancel = true;
    }

    private void msgGrid_Resize(object sender, EventArgs e)
    {
      Column1.Width = msgGrid.Width - 20;
    }

    private void RefresButton()
    {
      dataGrid.Enabled = !IsWorking;
      btnOprt.Enabled = !IsWorking && (bindingSource.Count > 0);
      btnExit.Enabled = !IsWorking;
      progBar.Visible = IsWorking;
    }

    private TConnInfoFinger RowDataToConnInfo(int RowIndex)
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
      return Pub.ValueToConnInfoFinger(MacSN, MacSN_GRPS, MacConnType, MacIPAddress, MacPort, MacConnPWD, IsGPRS);
    }

    private void RowToConnInfo(int RowIndex)
    {
      connList.Add(RowDataToConnInfo(RowIndex));
    }

    private bool InitMacList()
    {
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
      if (connList.Count == 0)
      {
        Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorSelectMacOprt", ""));
      }
      return connList.Count > 0;
    }

    private void RefreshMacMsg(string msg)
    {
      msgGrid.Rows.Add();
      msgGrid[0, msgGrid.RowCount - 1].Value = "[" + DateTime.Now.ToString() + "] " + msg;
      msgGrid.Rows[msgGrid.RowCount - 1].Selected = true;
      msgGrid.CurrentCell = msgGrid.Rows[msgGrid.RowCount - 1].Cells[0];
    }

    private void UpdateMacMsg(string msg, bool state)
    {
      string s = msgGrid[0, msgGrid.RowCount - 1].Value.ToString();
      msgGrid[0, msgGrid.RowCount - 1].Value = s + "    " + msg;
      if (state)
        msgGrid[0, msgGrid.RowCount - 1].Style.ForeColor = Color.Blue;
      else
        msgGrid[0, msgGrid.RowCount - 1].Style.ForeColor = Color.Red;
    }

    private void RefreshMsg(string msg)
    {
      RefreshMsg(msg, false);
    }

    private void RefreshMsg(string msg, bool IsEnd)
    {
      lblMsg.Text = msg;
      if ((lblMsg.Text == "") || IsEnd)
      {
        progBar.Value = 0;
        progBar.Style = ProgressBarStyle.Blocks;
      }
      else
      {
        progBar.Value = 50;
        progBar.Style = ProgressBarStyle.Marquee;
      }
    }

    private void ExecMacOprt()
    {
      bool state;
      string msg = "";
      string MacMsg = "";
      if (!InitMacList()) return;
      IsWorking = true;
      RefresButton();
      DateTime start = new DateTime();
      start = DateTime.Now;
      string ExecTimes = "";
      TConnInfoFinger conn;
      for (int i = 0; i < connList.Count; i++)
      {
        conn = connList[i];
        RefreshMsg(oprt + "[" + conn.MacSN.ToString() + "]......");
        RefreshMacMsg(oprt + "[" + conn.MacSN.ToString() + "]......");
        DeviceObject.objFK623.InitConn(conn);
        if (!DeviceObject.objFK623.IsOpen) DeviceObject.objFK623.Open();
        DeviceObject.objFK623.EnableDevice(0);
        state = DeviceObject.objFK623.IsOpen;
        if (state) state = ExecMacCommand(conn.MacSN, ref MacMsg);
        ExecTimes = "    " + Pub.GetDateDiffTimes(start, DateTime.Now);
        if (MacMsg != "") MacMsg = "[" + MacMsg + "]";
        UpdateMacMsg(MacMsg + DeviceObject.objFK623.ErrMsg + ExecTimes, state);
        msg = msg + conn.MacSN.ToString() + ":" + MacMsg + DeviceObject.objFK623.ErrMsg + ";";
        DeviceObject.objFK623.EnableDevice(1);
        DeviceObject.objFK623.Close();
        Application.DoEvents();
        start = DateTime.Now;
        if (!IsWorking) break;
      }
      db.WriteSYLog(this.Text, oprt, msg);
      IsWorking = false;
      RefresButton();
      RefreshMsg("");
    }

    private bool ExecMacCommand(int MacSN, ref string MacMsg)
    {
      bool ret = false;
      DateTime start = new DateTime();
      start = DateTime.Now;
      MacMsg = "";
      switch (flag)
      {
        case 0://下载时间段信息
          ret = MJTimeDownload(MacSN, ref MacMsg);
          break;
        case 1://上传时间段信息
          ret = MJTimeUpload(MacSN, ref MacMsg);
          break;
        case 10://下载权限信息
          ret = MJPowerDownload(MacSN, ref MacMsg);
          break;
        case 11://上传权限信息
          ret = MJPowerUpload(MacSN, ref MacMsg);
          break;
      }
      return ret;
    }

    private bool MJTimeDownload(int MacSN, ref string MacMsg)
    {
      bool ret = true;
      List<TimeZone> tzList = new List<TimeZone>();
      byte[] byt = new byte[(int)FKMax.SIZE_TIME_ZONE_STRUCT];
      TimeZone tz;
      for (int i = 0; i < (int)FKMax.TIME_ZONE_COUNT; i++)
      {
        tz = new TimeZone();
        tz.Init();
        tz.TimeZoneID = i + 1;
        DeviceObject.objFK623.StructToByteArray(tz, byt);
        ret = DeviceObject.objFK623.HS_GetTimeZone(byt);
        if (!ret) break;
        tz = (TimeZone)DeviceObject.objFK623.ByteArrayToStruct(byt, typeof(TimeZone));
        tzList.Add(tz);
      }
      if (ret && tzList.Count > 0)
      {
        string sql = "";
        DataTableReader dr = null;
        string ID = "";
        string Name = "";
        string[] TS = new string[(int)FKMax.TIME_SLOT_COUNT];
        string[] TE = new string[(int)FKMax.TIME_SLOT_COUNT];
        try
        {
          for (int i = 0; i < tzList.Count; i++)
          {
            tz = tzList[i];
            ID = tz.TimeZoneID.ToString();
            for (int j = 0; j < (int)FKMax.TIME_SLOT_COUNT; j++)
            {
              TS[j] = string.Format("{0:d2}:{1:d2}", tz.TimeSlots[j].StartHour, tz.TimeSlots[j].StartMinute);
              TE[j] = string.Format("{0:d2}:{1:d2}", tz.TimeSlots[j].EndHour, tz.TimeSlots[j].EndMinute);
            }
            dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002001, new string[] { "3003", ID }));
            if (dr.Read())
              sql = Pub.GetSQL(DBCode.DB_002001, new string[] { "3005", ID, Name, TS[0], TE[0], TS[1], TE[1], 
                TS[2], TE[2], TS[3], TE[3], TS[4], TE[4], TS[5], TE[5], OprtInfo.OprtNo });
            else
              sql = Pub.GetSQL(DBCode.DB_002001, new string[] { "3004", ID, Name, TS[0], TE[0], TS[1], TE[1], 
                TS[2], TE[2], TS[3], TE[3], TS[4], TE[4], TS[5], TE[5], OprtInfo.OprtNo });
            dr.Close();
            db.ExecSQL(sql);
          }
        }
        catch (Exception E)
        {
          ret = false;
          Pub.ShowErrorMsg(E, sql);
        }
        finally
        {
          if (dr != null) dr.Close();
          dr = null;
        }
      }
      return ret;
    }

    private bool MJTimeUpload(int MacSN, ref string MacMsg)
    {
      bool ret = true;
      byte[] byt = new byte[(int)FKMax.SIZE_TIME_ZONE_STRUCT];
      TimeZone tz;
      if (timeList.Count > 0)
      {
        for (int i = 0; i < timeList.Count; i++)
        {
          tz = timeList[i];
          DeviceObject.objFK623.StructToByteArray(tz, byt);
          ret = DeviceObject.objFK623.HS_SetTimeZone(byt);
          if (!ret) break;
        }
      }
      return ret;
    }
    
    private bool MJPowerDownload(int MacSN, ref string MacMsg)
    {
      bool ret = true;
      List<ExtCmd_USERDOORINFO> uiList = new List<ExtCmd_USERDOORINFO>();
      byte[] byt = new byte[((int)FKMax.SIZE_USERDOORINFO_V1) + 64];
      ExtCmd_USERDOORINFO ui = new ExtCmd_USERDOORINFO();
      for (int i = 0; i < fingerNoList.Count; i++)
      {
        ui.Init(false, fingerNoList[i]);
        DeviceObject.objFK623.StructToByteArray(ui, byt);
        ret = DeviceObject.objFK623.ExtCommand(byt);
        if (!ret)
        {
          if (DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_NON_CARRYOUT) continue;
          if (uiList.Count > 0)
          {
            DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
            ret = true;
          }
          break;
        }
        ui = (ExtCmd_USERDOORINFO)DeviceObject.objFK623.ByteArrayToStruct(byt, typeof(ExtCmd_USERDOORINFO));
        uiList.Add(ui);
      }
      if (uiList.Count > 0)
      {
        DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
        ret = true;
        string sql = "";
        DataTableReader dr = null;
        string SysID = MacSN.ToString();
        string EmpSysID = "";
        string SunID = "";
        string MonID = "";
        string TueID = "";
        string WedID = "";
        string ThuID = "";
        string FriID = "";
        string SatID = "";
        string StartDate = "";
        string EndDate = "";
        DateTime dt;
        try
        {
          for (int i = 0; i < uiList.Count; i++)
          {
            ui = uiList[i];
            ret = db.GetEmpSysID(ui.UserID, ref EmpSysID);
            if (!ret) break;
            SunID = ui.WeekPassTime[0].ToString();
            MonID = ui.WeekPassTime[1].ToString();
            TueID = ui.WeekPassTime[2].ToString();
            WedID = ui.WeekPassTime[3].ToString();
            ThuID = ui.WeekPassTime[4].ToString();
            FriID = ui.WeekPassTime[5].ToString();
            SatID = ui.WeekPassTime[6].ToString();
            StartDate = "NULL";
            dt = new DateTime();
            try
            {
              dt = new DateTime(ui.StartYear, ui.StartMonth, ui.StartDay);
              StartDate = "'" + dt.ToString(SystemInfo.SQLDateFMT) + "'";
            }
            catch
            {
            }
            EndDate = "NULL";
            try
            {
              dt = new DateTime(ui.EndYear, ui.EndMonth, ui.EndDay);
              EndDate = "'" + dt.ToString(SystemInfo.SQLDateFMT) + "'";
            }
            catch
            {
            }
            dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002001, new string[] { "4003", SysID, EmpSysID }));
            if (dr.Read())
              sql = Pub.GetSQL(DBCode.DB_002001, new string[] { "4005", SysID, EmpSysID, SunID, MonID, TueID, WedID, ThuID, 
                FriID, SatID, OprtInfo.OprtNo, StartDate, EndDate });
            else
              sql = Pub.GetSQL(DBCode.DB_002001, new string[] { "4004", SysID, EmpSysID, SunID, MonID, TueID, WedID, ThuID, 
                FriID, SatID, OprtInfo.OprtNo, StartDate, EndDate });
            dr.Close();
            db.ExecSQL(sql);
          }
        }
        catch (Exception E)
        {
          ret = false;
          Pub.ShowErrorMsg(E);
        }
        finally
        {
          if (dr != null) dr.Close();
          dr = null;
        }
      }
      return ret;
    }

    private bool MJPowerUpload(int MacSN, ref string MacMsg)
    {
      bool ret = true;
      List<ExtCmd_USERDOORINFO> uiList = new List<ExtCmd_USERDOORINFO>();
      ExtCmd_USERDOORINFO ui;
      DataTableReader dr = null;
      DateTime dt;
      try
      {
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002001, new string[] { "4000", MacSN.ToString() }));
        while (dr.Read())
        {
          ui = new ExtCmd_USERDOORINFO();
          ui.Init(true, Convert.ToUInt32(dr["CardFingerNo"].ToString()));
          ui.WeekPassTime[0] = Convert.ToByte(dr["SunID"].ToString());
          ui.WeekPassTime[1] = Convert.ToByte(dr["MonID"].ToString());
          ui.WeekPassTime[2] = Convert.ToByte(dr["TueID"].ToString());
          ui.WeekPassTime[3] = Convert.ToByte(dr["WedID"].ToString());
          ui.WeekPassTime[4] = Convert.ToByte(dr["ThuID"].ToString());
          ui.WeekPassTime[5] = Convert.ToByte(dr["FriID"].ToString());
          ui.WeekPassTime[6] = Convert.ToByte(dr["SatID"].ToString());
          try
          {
            dt = Convert.ToDateTime(dr["StartDate"].ToString());
            ui.StartYear = (short)dt.Year;
            ui.StartMonth = (byte)dt.Month;
            ui.StartDay = (byte)dt.Day;
          }
          catch
          {
          }
          try
          {
            dt = Convert.ToDateTime(dr["EndDate"].ToString());
            ui.EndYear = (short)dt.Year;
            ui.EndMonth = (byte)dt.Month;
            ui.EndDay = (byte)dt.Day;
          }
          catch
          {
          }
          uiList.Add(ui);
        }
      }
      catch (Exception E)
      {
        ret = false;
        Pub.ShowErrorMsg(E);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      if (ret && uiList.Count > 0)
      {
        byte[] byt = new byte[((int)FKMax.SIZE_USERDOORINFO_V1) + 64];
        for (int i = 0; i < uiList.Count; i++)
        {
          ui = uiList[i];
          DeviceObject.objFK623.StructToByteArray(ui, byt);
          ret = DeviceObject.objFK623.ExtCommand(byt);
          if (!ret) break;
        }
      }
      return ret;
    }

    private void btnOprt_Click(object sender, EventArgs e)
    {
      if (flag == 1)
      {
        timeList.Clear();
        TimeZone tz;
        DataTableReader dr = null;
        string tmp;
        bool IsError = false;
        try
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002001, new string[] { "3000" }));
          while (dr.Read())
          {
            tz = new TimeZone();
            tz.Init();
            tz.TimeZoneID = Convert.ToInt32(dr["PassTimeID"].ToString());
            for (int i = 0; i < (int)FKMax.TIME_SLOT_COUNT; i++)
            {
              tmp = dr["T" + (i + 1).ToString() + "S"].ToString();
              tz.TimeSlots[i].StartHour = Convert.ToByte(tmp.Substring(0, 2));
              tz.TimeSlots[i].StartMinute = Convert.ToByte(tmp.Substring(3, 2));
              tmp = dr["T" + (i + 1).ToString() + "E"].ToString();
              tz.TimeSlots[i].EndHour = Convert.ToByte(tmp.Substring(0, 2));
              tz.TimeSlots[i].EndMinute = Convert.ToByte(tmp.Substring(3, 2));
            }
            timeList.Add(tz);
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
      }
      else if (flag == 10)
      {
        fingerNoList.Clear();
        DataTableReader dr = null;
        bool IsError = false;
        try
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002001, new string[] { "4008" }));
          while (dr.Read())
          {
            fingerNoList.Add(Convert.ToUInt32(dr["CardFingerNo"].ToString()));
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
      }
      ExecMacOprt();
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void frmKQFaceOprt_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (IsWorking) e.Cancel = true;
    }

    private void SelectData(bool State)
    {
      if (bindingSource.DataSource != null)
      {
        DataTable dt = (DataTable)bindingSource.DataSource;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
          dt.Rows[i].BeginEdit();
          dt.Rows[i]["SelectCheck"] = State;
          dt.Rows[i].EndEdit();
        }
      }
    }

    private void ItemSelect_Click(object sender, EventArgs e)
    {
      SelectData(true);
    }

    private void ItemUnselect_Click(object sender, EventArgs e)
    {
      SelectData(false);
    }
  }
}