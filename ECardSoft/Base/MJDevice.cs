using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;
using System.Data;
using System.Windows.Forms;
using QHKS;

namespace ECard78
{
  public class TMacMoreCard
  {
    private byte _In = 0;
    private byte _Out = 0;
    private byte _Count = 0;
    private string empList = "";

    public TMacMoreCard(string cardString)
    {
      string[] tmp = cardString.Split('@');
      if (tmp.Length == 4)
      {
        byte.TryParse(tmp[0], out _In);
        byte.TryParse(tmp[1], out _Out);
        byte.TryParse(tmp[2], out _Count);
        string[] tmp1 = tmp[3].Split('#');
        for (int i = 0; i < tmp1.Length - 1; i++)
        {
          if (tmp1[i] == "") continue;
          empList += "'" + tmp1[i] + "',";
        }
        if (empList.Length > 0) empList = empList.Substring(0, empList.Length - 1);
      }
    }

    public byte EnabledIn
    {
      get { return _In; }
    }

    public byte EnabledOut
    {
      get { return _Out; }
    }

    public byte EmpCount
    {
      get { return _Count; }
    }

    public string EmpList
    {
      get { return empList; }
    }
  }

  public class TMacMoreCardNew
  {
    private string[] empList = new string[10] { "", "", "", "", "", "", "", "", "", "" };
    private int[] countList = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    public TMacMoreCardNew(string cardString)
    {
      string[] tmp = cardString.Split('@');
      if (tmp.Length == 20)
      {
        string[] tmp1;
        for (int i = 0; i < 10; i++)
        {
          tmp1 = tmp[i].Split('#');
          for (int j = 0; j < tmp1.Length; j++)
          {
            if (tmp1[j] == "") continue;
            empList[i] += "'" + tmp1[j] + "',";
          }
          if (empList[i].Length > 0) empList[i] = empList[i].Substring(0, empList[i].Length - 1);
          int.TryParse(tmp[i + 10], out countList[i]);
        }
      }
    }

    public string[] EmpList
    {
      get { return empList; }
    }

    public int[] CountList
    {
      get { return countList; }
    }
  }

  public class TMacFirstCard
  {
    private Base Pub = new Base();
    private byte[] _Way = new byte[2] { 0, 0 };
    private byte[] _Week = new byte[7] { 0, 0, 0, 0, 0, 0, 0 };
    private string _StartTime = "00:00";
    private string _EndTime = "00:00";
    private string empList = "";

    public TMacFirstCard(string cardString)
    {
      string[] tmp = cardString.Split('@');
      if (tmp.Length == 5)
      {
        for (int i = 0; i < 2; i++)
        {
          byte.TryParse(tmp[0].Substring(i, 1), out _Way[i]);
        }
        for (int i = 0; i < 7; i++)
        {
          byte.TryParse(tmp[1].Substring(i, 1), out _Week[i]);
        }
        _StartTime = Pub.ValidatTime(tmp[2]);
        _EndTime = Pub.ValidatTime(tmp[3]);
        string[] tmp1 = tmp[4].Split('#');
        for (int i = 0; i < tmp1.Length - 1; i++)
        {
          if (tmp1[i] == "") continue;
          empList += "'" + tmp1[i] + "',";
        }
        if (empList.Length > 0) empList = empList.Substring(0, empList.Length - 1);
      }
    }

    public byte[] Way
    {
      get { return _Way; }
    }

    public byte[] Week
    {
      get { return _Week; }
    }

    public string StartTime
    {
      get { return _StartTime; }
    }

    public string EndTime
    {
      get { return _EndTime; }
    }

    public string EmpList
    {
      get { return empList; }
    }
  }

  public class TInOutCard
  {
    private string empList = "";

    public TInOutCard(string cardString)
    {
      if (cardString.Length > 0)
      {
        string[] tmp = cardString.Split('#');
        for (int i = 0; i < tmp.Length - 1; i++)
        {
          if (tmp[i] == "") continue;
          empList += "'" + tmp[i] + "',";
        }
        if (empList.Length > 0) empList = empList.Substring(0, empList.Length - 1);
      }
    }

    public string EmpList
    {
      get { return empList; }
    }
  }

  public class TMacExtensionBoard
  {
    private byte[] _port = new byte[4] { 1, 2, 3, 4 };
    private byte[] _doorID = new byte[4];
    private string[] _events = new string[4] { "0000000", "0000000", "0000000", "0000000" };
    private string[] _souce = new string[4] { "00", "00", "00", "00" };
    private short[] _timeOut = new short[4] { 10, 10, 10, 10 };

    public TMacExtensionBoard(string extString)
    {
      string[] tmp = extString.Split('@');
      if (tmp.Length == 5)
      {
        for (int i = 0; i < 4; i++)
        {
          byte.TryParse(tmp[0].Substring(i, 1), out _port[i]);
          byte.TryParse(tmp[1].Substring(i, 1), out _doorID[i]);
          _events[i] = tmp[2].Substring(i * 7, 7);
          _souce[i] = tmp[3].Substring(i * 2, 2);
          short.TryParse(tmp[4].Substring(i * 4, 4), out _timeOut[i]);
        }
      }
    }

    public byte[] Port
    {
      get { return _port; }
    }

    public byte[] DoorID
    {
      get { return _doorID; }
    }

    public string[] Events
    {
      get { return _events; }
    }

    public string[] Souce
    {
      get { return _souce; }
    }

    public short[] TimeOut
    {
      get { return _timeOut; }
    }
  }

  public class TMacExtensionBoardNew
  {
    private byte[] _port = new byte[4] { 1, 2, 3, 4 };
    private byte[] _doorID = new byte[4];
    private string[] _events = new string[4] { "0000000", "0000000", "0000000", "0000000" };
    private string[] _souce = new string[4] { "00", "00", "00", "00" };
    private short[] _timeOut = new short[4] { 10, 10, 10, 10 };
    private short[] _timeLoop = new short[4] { 5, 5, 5, 5 };

    public TMacExtensionBoardNew(string extString)
    {
      string[] tmp = extString.Split('@');
      if (tmp.Length == 6)
      {
        for (int i = 0; i < 4; i++)
        {
          byte.TryParse(tmp[0].Substring(i, 1), out _port[i]);
          byte.TryParse(tmp[1].Substring(i, 1), out _doorID[i]);
          _events[i] = tmp[2].Substring(i * 7, 7);
          _souce[i] = tmp[3].Substring(i * 2, 2);
          short.TryParse(tmp[4].Substring(i * 4, 4), out _timeOut[i]);
          short.TryParse(tmp[5].Substring(i * 4, 4), out _timeLoop[i]);
        }
      }
    }

    public byte[] Port
    {
      get { return _port; }
    }

    public byte[] DoorID
    {
      get { return _doorID; }
    }

    public string[] Events
    {
      get { return _events; }
    }

    public string[] Souce
    {
      get { return _souce; }
    }

    public short[] TimeOut
    {
      get { return _timeOut; }
    }

    public short[] TimeLoop
    {
      get { return _timeLoop; }
    }
  }

  public class MJReadData
  {
    private Base Pub = new Base();
    private string cap = "";
    private string msgContinue = "";
    private int logCount = 0;
    private TMJRecordInfo recInfo = new TMJRecordInfo();
    private bool IsStop = false;

    public delegate void ProcessReadData(int RecordCount, int RecordIndex);
    public delegate void ProcessRealData(TMJRecordInfo recInfo, string MacSN);

    public MJReadData(string title)
    {
      cap = title;
      msgContinue = Pub.GetResText("", "MsgContinue", "");
    }

    public void StopData()
    {
      IsStop = true;
    }

    public bool ReadData(Database db, string MacSN, ref int RecordCount, ref int RecordIndex, ProcessReadData prog)
    {
      RecordCount = 0;
      RecordIndex = 0;
      bool ret = false;
      TMJMacInfo macInfo = new TMJMacInfo();
      if (!DeviceObject.objMJ.GetMacInfo(ref macInfo)) return false;
      RecordCount = macInfo.RecordCount;
      if (RecordCount == 0) return true;
      DialogResult result;
      for (int i = 0; i < macInfo.RecordSector; i++)
      {
      RetryReadData:
        if (IsStop)
        {
          DeviceObject.objMJ.Close();
          break;
        }
        Application.DoEvents();
        ret = DeviceObject.objMJ.GetMacRecord(SystemInfo.DataFilePath, i, ref logCount);
        if (!ret)
        {
          result = Pub.MessageBoxQuestion(cap + "\r\n\r\n" + DeviceObject.objMJ.ErrMsg + "\r\n\r\n" + msgContinue,
            MessageBoxButtons.AbortRetryIgnore);
          if (result == DialogResult.Abort)
            break;
          else if (result == DialogResult.Ignore)
            continue;
          else
            goto RetryReadData;
        }
        for (int j = 0; j < logCount; j++)
        {
          if (RecordIndex >= macInfo.RecordCount) break;
          if (DeviceObject.objMJ.GetMacRecordValue(j, ref recInfo))
          {
            WriteTextFile(recInfo, MacSN);
            SaveDB(db, recInfo, MacSN);
            RecordIndex = RecordIndex + 1;
            if (RecordIndex > macInfo.RecordCount) RecordIndex = macInfo.RecordCount;
            prog(macInfo.RecordCount, RecordIndex);
          }
        }
      }
      if (!IsStop)
      {
      RetryClear:
        ret = DeviceObject.objMJ.ClearMacRecord();
        if (!ret)
        {
          if (!Pub.MessageBoxShowQuestion(cap + "\r\n\r\n" + DeviceObject.objMJ.ErrMsg + "\r\n\r\n" + msgContinue)) goto RetryClear;
        }
      }
      return ret;
    }

    public bool ReadDataNew(Database db, string MacSN, ref int RecordCount, ref int RecordIndex, ProcessReadData prog)
    {
      RecordCount = 0;
      RecordIndex = 0;
      bool ret = false;
      AccessV2API.TYPE_Setting setting = new AccessV2API.TYPE_Setting();
      if (!DeviceObject.objMJNew.ReadSetting(out setting)) return false;
      RecordCount = (int)setting.LogCount;
      if (RecordCount == 0) return true;
      AccessV2API.TYPE_LogPack LogPack = new AccessV2API.TYPE_LogPack();
      UInt32 PackIndex = 0;
      int PackCount;
      while (true)
      {
        if (IsStop) break;
        Application.DoEvents();
        PackCount = DeviceObject.objMJNew.ReadBlockLog(PackIndex, ref LogPack);
        if (PackCount <= 0 || LogPack.Count == 0) break;
        PackIndex++;
        for (int i = 0; i < LogPack.Count; i++)
        {
          if (LogPack.Log[i].Door != 0 && LogPack.Log[i].Door != 255)
          {
            TMJRecordInfo recInfo = new TMJRecordInfo();
            recInfo.AlarmType = Convert.ToByte(LogPack.Log[i].WarnCode);
            recInfo.CardNo = LogPack.Log[i].CardNo.ToString("0000000000");
            recInfo.CardTime = DeviceObject.objMJNew.MJDateTimeToDateTime(LogPack.Log[i].DateTime);
            recInfo.DoorID = Convert.ToByte(LogPack.Log[i].Door);
            recInfo.IsCard = Convert.ToByte(LogPack.Log[i].CardNo > 0);
            if (recInfo.DoorID > 0 && recInfo.DoorID <= 4)
            {
              recInfo.IsPass = Convert.ToByte(LogPack.Log[i].DoorState[recInfo.DoorID - 1] > 0);
              if (recInfo.IsCard == 1 && recInfo.AlarmType >= 0x80 && recInfo.AlarmType <= 0x86) recInfo.IsPass = 1;
            }
            recInfo.ReaderID = Convert.ToByte(LogPack.Log[i].Reader);
            WriteTextFile(recInfo, MacSN);
            SaveDB(db, recInfo, MacSN);
          }
          RecordIndex++;
          prog(RecordCount, RecordIndex);
        }
      }
      if (!IsStop)
      {
      RetryClear:
        ret = DeviceObject.objMJNew.ClearNewLog();
        if (!ret)
        {
          if (!Pub.MessageBoxShowQuestion(cap + "\r\n\r\n" + Pub.GetResText("", "MsgFailure", "") + "\r\n\r\n" + msgContinue)) goto RetryClear;
        }
      }
      return ret;
    }

    private void WriteTextFile(TMJRecordInfo recInfo, string MacSN)
    {
      DateTime t = recInfo.CardTime;
      string fileName = SystemInfo.DataFilePath + "MJ" + t.ToString(SystemInfo.DateFormatLog) + ".dat";
      string msg = recInfo.IsCard.ToString("00") + recInfo.AlarmType.ToString("00") +
        recInfo.DoorID.ToString("00") + recInfo.ReaderID.ToString("00") + recInfo.CardNo +
        recInfo.IsPass.ToString() + t.ToString(SystemInfo.DateTimeFormatLog) + MacSN;
      Pub.WriteTextFile(fileName, msg);
    }

    private void SaveDB(Database db, TMJRecordInfo recInfo, string MacSN)
    {
      DateTime t = recInfo.CardTime;
      int MJTime = t.Hour * 60 * 60 + t.Minute * 60 + t.Second;
      string memo = "";
      string sql = "";
      string hexStr = recInfo.AlarmType.ToString("X");
      while (hexStr.Length < 2) hexStr = "0" + hexStr;
      if (recInfo.IsCard == 0 || recInfo.IsPass == 0)
      {
        memo = Pub.GetResText("", "MJRecordMemo_" + hexStr, "");
        sql = Pub.GetSQL(DBCode.DB_003005, new string[] { "101", t.ToString(SystemInfo.SQLDateFMT), 
          MJTime.ToString(), MacSN, recInfo.DoorID.ToString(), recInfo.AlarmType.ToString(), memo, 
          OprtInfo.OprtSysID });
      }
      else
      {
        memo = Pub.GetResText("", "MJRecordMemo_FF", "") + "[" + recInfo.CardNo + "]";
        sql = Pub.GetSQL(DBCode.DB_003005, new string[] { "100", SystemInfo.CardProtocol.ToString(), recInfo.CardNo, 
          t.ToString(SystemInfo.SQLDateFMT), MJTime.ToString(), MacSN, Pub.GetMJReaderID(MacSN, recInfo.ReaderID), 
          OprtInfo.OprtSysID, memo, "Y", recInfo.AlarmType.ToString() });
      }
      try
      {
        db.ExecSQL(sql);
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E, sql);
        return;
      }
    }
  }

  public class TMapDoorInfo
  {
    private string _doorSysID;
    private string _macSN;
    private string _doorID;
    private string _doorName;
    private int _x = 0;
    private int _y = 0;
    private string _MacConnType = "";
    private string _MacIPAddress = "";
    private string _MacPort = "";
    private string _MacConnPWD = "";

    public TMapDoorInfo(string doorSysID, string macSN, string doorID, string doorName)
    {
      _doorSysID = doorSysID;
      _macSN = macSN;
      _doorID = doorID;
      _doorName = doorName;
    }

    public string DoorSysID
    {
      get { return _doorSysID; }
    }

    public string MacSN
    {
      get { return _macSN; }
    }

    public string DoorID
    {
      get { return _doorID; }
    }

    public string DoorName
    {
      get { return _doorName; }
    }

    public int X
    {
      get { return _x; }
      set { _x = value; }
    }

    public int Y
    {
      get { return _y; }
      set { _y = value; }
    }

    public string MacConnType
    {
      get { return _MacConnType; }
      set { _MacConnType = value; }
    }


    public string MacIPAddress
    {
      get { return _MacIPAddress; }
      set { _MacIPAddress = value; }
    }

    public string MacPort
    {
      get { return _MacPort; }
      set { _MacPort = value; }
    }

    public string MacConnPWD
    {
      get { return _MacConnPWD; }
      set { _MacConnPWD = value; }
    }
  }

  public class MJDownBlack
  {
    private DataTable dt = null;
    private QHKS.TMJConnInfo conn;
    private TConnInfoNewMJ connNew;
    private Base Pub = new Base();

    public MJDownBlack(DataTable dataTable, QHKS.TMJConnInfo connInfo)
    {
      dt = dataTable.Copy();
      conn = connInfo;
    }

    public MJDownBlack(DataTable dataTable, TConnInfoNewMJ connInfo)
    {
      dt = dataTable.Copy();
      connNew = connInfo;
    }

    public bool Down()
    {
      bool ret = true;
      string cardNo = "";
      string OtherCardNo = "";
      byte DoorType = 0;
      byte.TryParse(conn.MacSN.Substring(0, 2), out DoorType);
      for (int i = 0; i < dt.Rows.Count; i++)
      {
        if (!Pub.ValueToBool(dt.Rows[i]["SelectCheck"])) continue;
        cardNo = dt.Rows[i]["CardPhysicsNo10"].ToString();
        OtherCardNo = dt.Rows[i]["OtherCardNo"].ToString();
        for (byte DoorID = 1; DoorID <= DoorType; DoorID++)
        {
          ret = DeviceObject.objMJ.ClearMacUpPowerInfo(DoorID, cardNo, OtherCardNo);
          if (!ret) break;
        }
        if (!ret) break;
      }
      return ret;
    }

    public bool DownNew()
    {
      bool ret = true;
      UInt32 cardNo = 0;
      UInt32 OtherCardNo = 0;
      byte DoorType = 0;
      byte.TryParse(connNew.MacSN.ToString().Substring(1, 1), out DoorType);
      for (int i = 0; i < dt.Rows.Count; i++)
      {
        if (!Pub.ValueToBool(dt.Rows[i]["SelectCheck"])) continue;
        UInt32.TryParse(dt.Rows[i]["CardPhysicsNo10"].ToString(), out cardNo);
        UInt32.TryParse(dt.Rows[i]["OtherCardNo"].ToString(), out OtherCardNo);
        for (byte DoorID = 1; DoorID <= DoorType; DoorID++)
        {
          if (cardNo > 0) ret = DeviceObject.objMJNew.RemoveRegister(DoorID, cardNo);
          if (ret && OtherCardNo > 0) ret = DeviceObject.objMJNew.RemoveRegister(DoorID, OtherCardNo);
          if (!ret) break;
        }
        if (!ret) break;
      }
      return ret;
    }
  }

  public class AccessV2API
  {
    private static UInt32 DeviceID = 0;
    private static int Succeed = 0;
    private const UInt32 DefCommTimeOut = 1000;
    private const string DefCommPassword1 = "000000";
    private const string DefCommPassword2 = "FFFFFF";
    private static string CommPassword = "FFFFFF";

    public struct SYSTEMTIME
    {
      public UInt16 wYear;
      public UInt16 wMonth;
      public UInt16 wDayOfWeek;
      public UInt16 wDay;
      public UInt16 wHour;
      public UInt16 wMinute;
      public UInt16 wSecond;
      public UInt16 wMilliseconds;
    }

    public struct TYPE_Network
    {
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
      public string DevAddr;    //设备IP地址
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
      public string GateWay;      //网关
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
      public string NetMask;      //掩码
      public UInt32 DevPort;    //设备端口
    }

    //搜索设备
    public struct TYPE_NetSearch
    {
      public UInt32 DevSN;        //设备序列号
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
      public string DevAddr;      //设备IP地址
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
      public string GateWay;      //网关
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
      public string NetMask;      //掩码
      public UInt32 DevPort;      //设备端口
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
      public string DevMac;       //设备mac地址
    }
    //设备配置
    public struct TYPE_Setting
    {
      public SYSTEMTIME DateTime;			//日期
      public UInt32 LogCount; 				//记录个数
      public UInt32 RegCount; 				//注册权限个数
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
      public UInt32[] DoorState; 			//门状态
      public UInt32 Version; 			    //硬件版本号
      public UInt32 RightType; 				//权限类型
      public UInt32 Restrict; 				//互锁参数
      public UInt32 AntiReturn; 				//反潜回参数
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
      public string StressCodeA;			    //胁迫密码A
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
      public string StressCodeB;			    //胁迫密码B
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
      public string LocalAddr; 			    //设备IP
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
      public string GateWay;				    //网关
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
      public string NetMask;				    //掩码
      public UInt32 LocalPort;				//端口
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
      public string NetWorkAddr;			    //mac地址
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
      public string ServerIP;				//服务端IP
      public UInt32 ServerPort;				//服务端端口
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
      public string CommPassword;			//通讯密码
      public UInt32 EnableRecCover; 			//允许循环覆盖
    }
    //门基础信息
    public struct TYPE_DoorBasic
    {
      public UInt32 State;			//门状态
      public UInt32 Interval;			//刷卡间隔
      public UInt32 LockedDelay;		//开门延时
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
      public string PasswordA;		//开门密码
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
      public string PasswordB;
      public UInt32 CtrlMode;			//门控制方式
    }
    //门高级信息_工作模式
    public struct TYPE_DoorExpertWorkMode
    {
      public UInt32 DayOfWeek;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.Struct)]
      public SYSTEMTIME[] TimeBegin;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.Struct)]
      public SYSTEMTIME[] TimeEnd;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
      public UInt32[] Mode;
    }
    //门高级信息_定时开关门
    public struct TYPE_DoorExpertTiming
    {
      public UInt32 DayOfWeek;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.Struct)]
      public SYSTEMTIME[] TimeBegin;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.Struct)]
      public SYSTEMTIME[] TimeEnd;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
      public UInt32[] Ctrl;
    }

    //门高级信息_首卡
    public struct TYPE_DoorExpert_First
    {
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
      public UInt32[] CardNo;			  //卡号
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
      public byte[] WeekConfig;		//星期配置
      public SYSTEMTIME TimeBegin;	//开始时间
      public UInt32 InsideMode;		//范围内工作模式
      public SYSTEMTIME TimeEnd;		//结束时间
      public UInt32 OutsideMode;		//时间范围外工作模式
    }
    //门高级信息
    public struct TYPE_DoorExpert
    {
      public UInt32 EnableFirstCard;
      public UInt32 EnableGuardCard;
      public UInt32 EnableTiming;
      public UInt32 EnableMulitCard;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7, ArraySubType = UnmanagedType.Struct)]
      public TYPE_DoorExpertTiming[] ExpertTiming;
      public TYPE_DoorExpert_First ExpertFirstCard;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
      public UInt32[] ExpertGuardCard;

    }
    //多卡开门数据
    public struct TYPE_MulitCardDat
    {
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
      public UInt32[] GroupA;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
      public UInt32[] GroupB;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
      public UInt32[] GroupC;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
      public UInt32[] GroupD;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
      public UInt32[] GroupE;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
      public UInt32[] GroupF;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
      public UInt32[] GroupG;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
      public UInt32[] GroupH;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
      public UInt32[] GroupI;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
      public UInt32[] GroupJ;
    }
    //多卡开门组合
    public struct TYPE_MulitCardMap
    {
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
      public UInt32[] ProgramA;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
      public UInt32[] ProgramB;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
      public UInt32[] ProgramC;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
      public UInt32[] ProgramD;
    }
    //记录索引
    public struct TYPE_LogMemory
    {
      public UInt32 Start;
      public UInt32 End;
      public UInt32 Size;
    }
    //记录
    public struct TYPE_Log
    {
      public UInt32 DevSN;        //设备序列号
      public UInt32 Index;        //记录索引
      public UInt32 CardNo;       //卡号
      public UInt32 Door;         //门号
      public UInt32 Reader;       //读头号
      public SYSTEMTIME DateTime; //事件时间
      public UInt32 WarnCode;     //记录标志
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
      public UInt32[] DoorState; 			//门状态
    }
    //身份证记录
    public struct Identity_Log
    {
      public UInt32 DevSN;        //设备序列号
      public UInt32 Index;        //记录索引
      public UInt32 CardNo;       //卡号
      public UInt32 Door;         //门号
      public UInt32 Reader;       //读头号
      public UInt32 WarnCode;     //记录标志
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
      public UInt32[] DoorState; 			//门状态
      public SYSTEMTIME DateTime; //事件时间
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
      public string IdCardNum;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 60)]
      public string Name;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 140)]
      public string Address;

    }

    public struct TYPE_LogPack
    {
      public UInt32 Type;
      public UInt32 Count;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = UnmanagedType.Struct)]
      public TYPE_Log[] Log;
    }

    public struct Identity_LogPack
    {
      public UInt32 Type;
      public UInt32 Count;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.Struct)]
      public Identity_Log[] Log;
    }
    //注册权限
    public struct TYPE_Register
    {
      public UInt32 CardNo;           //卡号
      public UInt32 Door;             //门号
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
      public string Password;         //密码
      public UInt32 TimeGroup;        //时间组    
      public SYSTEMTIME DateBegin;           //有效期开始时间
      public SYSTEMTIME DateEnd;             //有效期结束时间
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
      public string UserID;                  //用户ID
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
      public string UserName;                //用户姓名
      public UInt32 DepartmentCode;          //部门编码
    }

    public struct Register_Guest
    {
      public UInt32 cardNum;
      public UInt32 door;
      public SYSTEMTIME timeBegin;
      public SYSTEMTIME tiemEnd;
    }
    //临时卡权限包
    public struct Type_GeustPack
    {
      public UInt32 count;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 200, ArraySubType = UnmanagedType.Struct)]
      public Register_Guest[] guestInfo;   //权限信息
    }
    //权限包
    public struct TYPE_RegisterPack
    {
      public UInt32 Count;		//权限个数
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.Struct)]
      public TYPE_Register[] register;	//权限信息
    }
    //UDP端点
    public struct TYPE_UDPEndPoint
    {
      public UInt32 Address;
      public UInt32 Port;
    }

    public struct TYPE_Comment
    {
      public UInt32 Size;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
      public string Data;
    }
    //时间段
    public struct TYPE_TimeSegment
    {
      public int Index;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.I4)]
      public int[] Times;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.Struct)]
      public SYSTEMTIME[] TimeBegin;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.Struct)]
      public SYSTEMTIME[] TimeEnd;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
      public int[] Mode;
    }
    public struct TYPE_TimeSegmentPack
    {
      public int Count;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50, ArraySubType = UnmanagedType.Struct)]
      public TYPE_TimeSegment[] Data;
    }
    //时间组
    public struct TYPE_TimeGroup
    {
      public int Index;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7, ArraySubType = UnmanagedType.I4)]
      public int[] WeekDay;
      public int Holiday;
    }
    public struct TYPE_TimeGroupPack
    {
      public int Count;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50, ArraySubType = UnmanagedType.Struct)]
      public TYPE_TimeGroup[] Data;
    }

    public struct TYPE_Holiday
    {
      public UInt32 Index;
      public UInt32 Enable;
      public SYSTEMTIME TimeBegin;           //开始时间
      public SYSTEMTIME TimeEnd;
      public UInt32 SegmentNo;                //时间段编号
    }
    //节假日包
    public struct TYPE_HolidayPack
    {
      public UInt32 Count;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10, ArraySubType = UnmanagedType.Struct)]
      public TYPE_Holiday[] Holiday;
    }

    public struct TYPE_ExtendAlarm
    {
      public UInt32 Alarm;              //报警继电器序号 
      public UInt32 Door;               //门号 
      public UInt32 NoAccess;           //无权限报警 
      public UInt32 Unlocked;           //门未关报警 
      public UInt32 UnlockedMode;       //门未关报警模式 0 门长时间未关维持报警一段设定时间，直到门关好后解除 1 门长时间未关维持报警，直到门关好后解除 
      public UInt32 UnlockedTick;       //门未关判定时限 
      public UInt32 UnlockedLoop;       //门未关报警维持时间 
      public UInt32 BreakIn;            //非法闯入报警 
      public UInt32 BreakInMode;        //非法闯入报警模式 1 非法闯入维持报警，直到门关好后解除 
      public UInt32 Linkage;            //继电器联动
      public UInt32 Fire;               //火警报警 
      public UInt32 Stress;             //胁迫报警 
      public UInt32 Curfew;             //强制锁门报警 
    }

    public AccessV2API()
    {
    }

    public AccessV2API(TConnInfoNewMJ ConnInfo)
    {
      NewDevice(ConnInfo);
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_NetSearchOpen")]
    private static extern int AccessV2_NetSearchOpen(string password, UInt32 timeOut);
    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_NetSearchGet")]
    private static extern int AccessV2_NetSearchGet(UInt32 index, ref TYPE_NetSearch search);
    public List<TYPE_NetSearch> Search()
    {
      int count = AccessV2_NetSearchOpen(CommPassword, 1000 * 5);
      var list = new List<TYPE_NetSearch>();
      for (UInt32 index = 0; index < count; index++)
      {
        var one = new TYPE_NetSearch();
        int success = AccessV2_NetSearchGet(index, ref one);
        if (success != 0)
        {
          list.Add(one);
        }
      }
      return list;
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_NetWorkSet")]
    private static extern int AccessV2_NetWorkSet(UInt32 devSN, string password, ref TYPE_Network network);
    public bool SetNetwork(UInt32 devSN, TYPE_Network network)
    {
      int success = AccessV2_NetWorkSet(devSN, CommPassword, ref network);
      return success != 0;
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_NewDevice")]
    private static extern uint AccessV2_NewDevice(UInt32 dwDevSN, string zCommPassword, string zCommMode, string zCommParam1,
      UInt32 nCommParam2, UInt32 nCommTimeOut);
    public bool NewDevice(UInt32 dwDevSN, string MacConnType, string MacIPAddress, string MacPort)
    {
      string zCommMode = "UDP";
      string zCommParam1 = MacIPAddress;
      UInt32 nCommParam2 = 19200;
      if (MacConnType.ToUpper() == MacConnTypeString.Comm)
      {
        zCommMode = "485";
        zCommParam1 = MacPort;
      }
      else
      {
        nCommParam2 = Convert.ToUInt32(MacPort);
      }
      DeviceID = AccessV2_NewDevice(dwDevSN, CommPassword, zCommMode, zCommParam1, nCommParam2, DefCommTimeOut);
      return DeviceID > 0;
    }
    public bool NewDevice(TConnInfoNewMJ ConnInfo, int CommTimeOut = 0)
    {
      string zCommMode = "UDP";
      string zCommParam1 = ConnInfo.NetIP;
      UInt32 nCommParam2 = 19200;
      if (ConnInfo.ConnType.ToUpper() == MacConnTypeString.Comm)
      {
        zCommMode = "485";
        zCommParam1 = ConnInfo.CommPort;
      }
      else
      {
        nCommParam2 = ConnInfo.NetPort;
      }
      UInt32 TimeOut = (UInt32)CommTimeOut;
      if (TimeOut == 0) TimeOut = DefCommTimeOut;
      DeviceID = AccessV2_NewDevice(ConnInfo.MacSN, CommPassword, zCommMode, zCommParam1, nCommParam2, TimeOut);
      return DeviceID > 0;
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_GetDeviceInfo")]
    private static extern int AccessV2_GetDeviceInfo(UInt32 devNum, ref TYPE_Setting setting);
    public bool IsOnline()
    {
      TYPE_Setting setting = new TYPE_Setting();
      Succeed = AccessV2_GetDeviceInfo(DeviceID, ref setting);
      return Succeed != 0;
    }

    public bool ReadSetting(out TYPE_Setting setting)
    {
      setting = new TYPE_Setting();
      Succeed = AccessV2_GetDeviceInfo(DeviceID, ref setting);
      return Succeed != 0;
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_SetDeviceInfo")]
    private static extern int AccessV2_SetDeviceInfo(UInt32 devNum, ref TYPE_Setting setting);
    public bool SetSetting(TYPE_Setting setting)
    {
      Succeed = AccessV2_SetDeviceInfo(DeviceID, ref setting);
      return Succeed != 0;
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_GetDoorInfo")]
    private static extern int AccessV2_GetDoorInfo(UInt32 devNum, byte door, ref TYPE_DoorBasic basic, ref TYPE_DoorExpert expert);
    public bool ReadDoorInfo(byte door, ref TYPE_DoorBasic basic, ref TYPE_DoorExpert expert)
    {
      basic = new TYPE_DoorBasic();
      expert = new TYPE_DoorExpert();
      Succeed = AccessV2_GetDoorInfo(DeviceID, door, ref basic, ref expert);
      return Succeed != 0;
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_SetDoorBascInfo")]
    private static extern int AccessV2_SetDoorBascInfo(UInt32 devNum, byte door, ref TYPE_DoorBasic basic);
    public bool SetDoorBasicInfo(byte door, TYPE_DoorBasic basic)
    {
      Succeed = AccessV2_SetDoorBascInfo(DeviceID, door, ref basic);
      return Succeed != 0;
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_SetDoorExpertInfo")]
    private static extern int AccessV2_SetDoorExpertInfo(UInt32 devNum, byte door, ref TYPE_DoorExpert expert);
    public bool SetDoorExpertInfo(byte door, TYPE_DoorExpert expert)
    {
      Succeed = AccessV2_SetDoorExpertInfo(DeviceID, door, ref expert);
      return Succeed != 0;
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_ClrRight")]
    private static extern int AccessV2_ClrRight(UInt32 devNum);
    public bool ClearRegister()
    {
      Succeed = AccessV2_ClrRight(DeviceID);
      return Succeed != 0;
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_WriteComment")]
    private static extern int AccessV2_WriteComment(UInt32 devNum, ref TYPE_Comment comment);
    public bool WriteComment(string data)
    {
      var comment = new TYPE_Comment();
      comment.Size = (uint)System.Text.Encoding.Default.GetBytes(data).Length;
      comment.Data = data;
      Succeed = AccessV2_WriteComment(DeviceID, ref comment);
      return Succeed != 0;
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_ReadComment")]
    private static extern int AccessV2_ReadComment(UInt32 devNum, ref TYPE_Comment comment);
    public bool ReadComment(ref string comment)
    {
      comment = "";
      var obj = new TYPE_Comment();
      Succeed = AccessV2_ReadComment(DeviceID, ref obj);
      if (Succeed != 0) comment = obj.Data.Substring(0, (int)obj.Size);
      return Succeed != 0;
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_RebootDevice")]
    private static extern int AccessV2_RebootDevice(UInt32 devNum);
    public bool RebootDevice()
    {
      Succeed = AccessV2_RebootDevice(DeviceID);
      return Succeed != 0;
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_InitDevice")]
    private static extern int AccessV2_InitDevice(UInt32 devNum, byte regType);
    public bool Init(byte regType = 1)
    {
      Succeed = AccessV2_InitDevice(DeviceID, regType);
      return Succeed != 0;
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_TimeHolidayRead")]
    private static extern int AccessV2_TimeHolidayRead(UInt32 devNum, ref TYPE_HolidayPack HolidayGroup);
    public bool TimeHolidayRead(ref TYPE_HolidayPack HolidayGroup)
    {
      Succeed = AccessV2_TimeHolidayRead(DeviceID, ref HolidayGroup);
      return Succeed != 0;
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_TimeHolidayWrite")]
    private static extern int AccessV2_TimeHolidayWrite(UInt32 devNum, ref TYPE_HolidayPack HolidayGroup);
    public bool TimeHolidayWrite(TYPE_HolidayPack HolidayGroup)
    {
      Succeed = AccessV2_TimeHolidayWrite(DeviceID, ref HolidayGroup);
      return Succeed != 0;
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_TimeSegmentWrite")]
    private static extern int AccessV2_TimeSegmentWrite(UInt32 devNum, ref TYPE_TimeSegmentPack segmentPack);
    public bool WriteTimeSegment(TYPE_TimeSegmentPack pack)
    {
      Succeed = AccessV2_TimeSegmentWrite(DeviceID, ref pack);
      return Succeed != 0;
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_TimeGroupWrite")]
    private static extern int AccessV2_TimeGroupWrite(UInt32 devNum, ref TYPE_TimeGroupPack groupPack);
    public bool WriteTimeGroup(TYPE_TimeGroupPack pack)
    {
      Succeed = AccessV2_TimeGroupWrite(DeviceID, ref pack);
      return Succeed != 0;
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_TimeSegmentRead")]
    private static extern int AccessV2_TimeSegmentRead(UInt32 devNum, ref TYPE_TimeSegmentPack segmentPack);
    public bool ReadTimeSegment(ref TYPE_TimeSegmentPack pack)
    {
      Succeed = AccessV2_TimeSegmentRead(DeviceID, ref pack);
      return Succeed != 0;
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_TimeGroupRead")]
    private static extern int AccessV2_TimeGroupRead(UInt32 devNum, ref TYPE_TimeGroupPack groupPack);
    public bool ReadTimeGroup(ref TYPE_TimeGroupPack pack)
    {
      Succeed = AccessV2_TimeGroupRead(DeviceID, ref pack);
      return Succeed != 0;
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_AddRight")]
    private static extern int AccessV2_AddRight(UInt32 devNum, ref TYPE_Register register);
    public bool AddRegister(TYPE_Register register)
    {
      Succeed = AccessV2_AddRight(DeviceID, ref register);
      return Succeed != 0;
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_DelRight")]
    private static extern int AccessV2_DelRight(UInt32 devNum, byte door, UInt32 cardNo);
    public bool RemoveRegister(byte door, UInt32 cardNo)
    {
      Succeed = AccessV2_DelRight(DeviceID, door, cardNo);
      return Succeed != 0;
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_GetLogMemory")]
    private static extern int AccessV2_GetLogMemory(UInt32 devNum, ref TYPE_LogMemory memory);
    public bool ReadLogMemory(ref UInt32 start, ref UInt32 end, ref UInt32 size)
    {
      TYPE_LogMemory memory = new TYPE_LogMemory();
      Succeed = AccessV2_GetLogMemory(DeviceID, ref memory);
      if (Succeed != 0)
      {
        start = memory.Start;
        end = memory.End;
        size = memory.Size;
      }
      return Succeed != 0;
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_GetOneLog")]
    private static extern int AccessV2_GetOneLog(UInt32 devNum, UInt32 index, ref TYPE_Log log);
    public bool ReadLog(UInt32 index, out TYPE_Log log)
    {
      log = new TYPE_Log();
      Succeed = AccessV2_GetOneLog(DeviceID, index, ref log);
      return Succeed != 0;
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_GetBlockLogNew")]
    private static extern int AccessV2_GetBlockLogNew(UInt32 devNum, UInt32 block, ref TYPE_LogPack pack);
    public int ReadBlockLog(UInt32 block, ref TYPE_LogPack pack)
    {
      return AccessV2_GetBlockLogNew(DeviceID, block, ref pack);
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_ClrNewLog")]
    private static extern int AccessV2_ClrNewLog(UInt32 devNum);
    public bool ClearNewLog()
    {
      Succeed = AccessV2_ClrNewLog(DeviceID);
      return Succeed != 0;
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_RemoteOpen")]
    private static extern int AccessV2_RemoteOpen(UInt32 devNum, byte door);
    public bool RemoteOpen(byte door)
    {
      Succeed = AccessV2_RemoteOpen(DeviceID, door);
      return Succeed != 0;
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_AwhileOpen")]
    private static extern int AccessV2_AwhileOpen(UInt32 devNum, byte door, UInt32 seconds);
    public bool AwhileOpen(byte door, UInt32 seconds)
    {
      Succeed = AccessV2_AwhileOpen(DeviceID, door, seconds);
      return Succeed != 0;
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_SetDoorMode")]
    private static extern int AccessV2_SetDoorMode(UInt32 devNum, byte door, byte mode);
    public bool DoorOpen(byte door, byte mode)
    {
      Succeed = AccessV2_SetDoorMode(DeviceID, door, mode);
      return Succeed != 0;
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_SetAlarmInfo")]
    private static extern int AccessV2_SetAlarmInfo(UInt32 devNum, ref TYPE_ExtendAlarm ExtendAlarm1,
      ref TYPE_ExtendAlarm ExtendAlarm2, ref TYPE_ExtendAlarm ExtendAlarm3, ref TYPE_ExtendAlarm ExtendAlarm4);
    public bool SetAlarmInfo(TYPE_ExtendAlarm[] ExtendAlarm)
    {
      Succeed = AccessV2_SetAlarmInfo(DeviceID, ref ExtendAlarm[0], ref ExtendAlarm[1], ref ExtendAlarm[2], ref ExtendAlarm[3]);
      return Succeed != 0;
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_SetMultiCardDat")]
    private static extern int AccessV2_SetMultiCardDat(UInt32 devNum, byte door, ref TYPE_MulitCardDat CardDat);
    public bool SetMultiCardDat(byte door, TYPE_MulitCardDat CardDat)
    {
      Succeed = AccessV2_SetMultiCardDat(DeviceID, door, ref CardDat);
      return Succeed != 0;
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_SetMultiCardMap")]
    private static extern int AccessV2_SetMultiCardMap(UInt32 devNum, ref TYPE_MulitCardMap CardMap);
    public bool SetMultiCardMap(TYPE_MulitCardMap CardMap)
    {
      Succeed = AccessV2_SetMultiCardMap(DeviceID, ref CardMap);
      return Succeed != 0;
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_RegisterContextCreate")]
    private static extern int AccessV2_RegisterContextCreate(UInt32 count);
    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_RegisterContextInsert")]
    private static extern int AccessV2_RegisterContextInsert(int block, UInt32 index, ref TYPE_Register register);
    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_RegisterContextSort")]
    private static extern int AccessV2_RegisterContextSort(int block);
    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_RegisterContextRead")]
    private static extern int AccessV2_RegisterContextRead(int block, UInt32 index, ref TYPE_RegisterPack pack);
    public int CreateRegisterContext(uint count)
    {
      return AccessV2_RegisterContextCreate(count);
    }
    public int InsertRegisterContext(int block, UInt32 index, TYPE_Register register)
    {
      return AccessV2_RegisterContextInsert(block, index, ref register);
    }
    public int SortRegisterContext(int block)
    {
      return AccessV2_RegisterContextSort(block);
    }
    public bool ReadRegisterContext(int block, UInt32 index, ref TYPE_RegisterPack pack)
    {
      Succeed = AccessV2_RegisterContextRead(block, index, ref pack);
      return Succeed != 0;
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_RegisterPackageWrite")]
    private static extern int AccessV2_RegisterPackageWrite(UInt32 devNum, ref TYPE_RegisterPack pack, UInt32 packIndex, UInt32 packCount);
    public bool WriteRegister(TYPE_RegisterPack pack, UInt32 index, UInt32 count)
    {
      Succeed = AccessV2_RegisterPackageWrite(DeviceID, ref pack, index, count);
      return Succeed != 0;
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_RegisterPackageRead")]
    private static extern int AccessV2_RegisterPackageRead(UInt32 devNum, byte bType, UInt32 packIndex, ref TYPE_RegisterPack pack);
    public int ReadRegister(UInt32 packIndex, ref TYPE_RegisterPack pack)
    {
      return AccessV2_RegisterPackageRead(DeviceID, 32, packIndex, ref pack);
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_GuestPackageWrite")]
    private static extern int AccessV2_GuestPackageWrite(UInt32 devNum, ref Type_GeustPack pack);
    public bool RegisterGeuster(ref Type_GeustPack pack)
    {
      Succeed = AccessV2_GuestPackageWrite(DeviceID, ref pack);
      return Succeed != 0;
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_SearchRight")]
    private static extern int AccessV2_SearchRight(UInt32 devNum, UInt32 cardNo, ref TYPE_Register registerA,
      ref TYPE_Register registerB, ref TYPE_Register registerC, ref TYPE_Register registerD);
    public List<TYPE_Register> SearchRegister(UInt32 cardNo)
    {
      var register = new TYPE_Register[4];
      Succeed = AccessV2_SearchRight(DeviceID, cardNo, ref register[0], ref register[1], ref register[2], ref register[3]);
      if (Succeed != 0)
      {
        var registerList = new List<TYPE_Register>(register);
        return registerList;
      }
      else
      {
        return null;
      }
    }

    //监听的回调原型
    public delegate void UPLOAD_Arrived(ref TYPE_UDPEndPoint remote, byte dataType, ref TYPE_Log log);
    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_ListenerCreate")]
    private static extern int AccessV2_ListenerCreate(int port, UPLOAD_Arrived uploadArrived, int userID);
    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_ListenerAdd")]
    private static extern int AccessV2_ListenerAdd(int hUDP, UInt32 devNum, int port);
    public static int ListenerOpen(UPLOAD_Arrived uploadArrived)
    {
      return AccessV2_ListenerCreate(40000, uploadArrived, 0);
    }

    public bool UploadOpen(int hUDP, int num)
    {
      Succeed = AccessV2_ListenerAdd(hUDP, DeviceID, num);
      return Succeed != 0;
    }

    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_ListenerDestroy")]
    private static extern int AccessV2_ListenerDestroy(int hUDP);
    [DllImport("NBSDK.dll", EntryPoint = "AccessV2_ListenerDel")]
    private static extern int AccessV2_ListenerDel(int hUDP, UInt32 devNum, int port);
    public static void ListenerClose(int hUDP)
    {
      AccessV2_ListenerDestroy(hUDP);
    }

    public bool UploadClose(int hUDP, int num)
    {
      Succeed = AccessV2_ListenerDel(hUDP, DeviceID, num);
      return Succeed != 0;
    }

    public string MJDateTimeToString(SYSTEMTIME MJDateTime)
    {
      DateTime dt = new DateTime(MJDateTime.wYear, MJDateTime.wMonth, MJDateTime.wDay, MJDateTime.wHour,
        MJDateTime.wMinute, MJDateTime.wSecond);
      return dt.ToString(SystemInfo.DateTimeFormat);
    }

    public DateTime MJDateTimeToDateTime(SYSTEMTIME MJDateTime)
    {
      return new DateTime(MJDateTime.wYear, MJDateTime.wMonth, MJDateTime.wDay, MJDateTime.wHour,
        MJDateTime.wMinute, MJDateTime.wSecond);
    }

    public void DateTimeToMJDateTime(DateTime dt, ref SYSTEMTIME MJDateTime)
    {
      MJDateTime.wYear = (UInt16)dt.Year;
      MJDateTime.wMonth = (UInt16)dt.Month;
      MJDateTime.wDayOfWeek = (UInt16)dt.DayOfWeek;
      MJDateTime.wDay = (UInt16)dt.Day;
      MJDateTime.wHour = (UInt16)dt.Hour;
      MJDateTime.wMinute = (UInt16)dt.Minute;
      MJDateTime.wSecond = (UInt16)dt.Second;
      MJDateTime.wMilliseconds = (UInt16)dt.Millisecond;
    }

    public string GetLengthText(string src, int len)
    {
      if (src == null) src = "";
      byte[] byteArray = System.Text.Encoding.Default.GetBytes(src);
      if (byteArray.Length > len)
        return System.Text.Encoding.Default.GetString(byteArray, 0, len);
      else
        return System.Text.Encoding.Default.GetString(byteArray);
    }
  }
}