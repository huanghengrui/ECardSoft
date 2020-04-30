using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Windows.Forms;
using QHKS;

namespace ECard78
{
  public class KQParamInfo
  {
    private Base Pub = new Base();
    private int _CardInterval = 0;
    private int _RelayOutput1 = 0;
    private int _RelayOutput2 = 0;
    private byte _RelayOutputActionTime1 = 10;
    private byte _RelayOutputActionTime2 = 10;
    private byte _RingingBells = 0;
    private byte _ShowCardInfo = 0;
    private byte _EnabledCardOrder = 0;
    private string _AttendanceTitle = "";
    private string _CardType = SystemInfo.CardTypeDefault;
    private byte _EnabledOpter = 0;
    private string[] _Order = new string[4] { "0000", "0000", "0000", "0000" };
    private byte[] _NextDay = new byte[4];
    private byte[] _Restday = new byte[7];
    private string[] _OrderFrom = new string[4] { "00:00", "00:00", "00:00", "00:00" };
    private string[] _OrderTo = new string[4] { "00:00", "00:00", "00:00", "00:00" };
    private byte _MessageEnabled = 0;
    private string _Message = "";

    public KQParamInfo(string ParamString)
    {
      string[] tmp = ParamString.Split('#');
      if (tmp.Length >= 36)
      {
        int.TryParse(tmp[0], out _CardInterval);
        int.TryParse(tmp[1], out _RelayOutput1);
        int.TryParse(tmp[2], out _RelayOutput2);
        byte.TryParse(tmp[3], out _RelayOutputActionTime1);
        byte.TryParse(tmp[4], out _RelayOutputActionTime2);
        byte.TryParse(tmp[5], out _RingingBells);
        byte.TryParse(tmp[6], out _ShowCardInfo);
        byte.TryParse(tmp[7], out _EnabledCardOrder);
        _AttendanceTitle = tmp[8];
        _CardType = tmp[9];
        byte.TryParse(tmp[10], out _EnabledOpter);
        _Order[0] = tmp[11];
        _Order[1] = tmp[12];
        _Order[2] = tmp[13];
        _Order[3] = tmp[14];
        byte.TryParse(tmp[15], out _NextDay[0]);
        byte.TryParse(tmp[16], out _NextDay[1]);
        byte.TryParse(tmp[17], out _NextDay[2]);
        byte.TryParse(tmp[18], out _NextDay[3]);
        _OrderFrom[0] = Pub.ValidatTime(tmp[19]);
        _OrderFrom[1] = Pub.ValidatTime(tmp[20]);
        _OrderFrom[2] = Pub.ValidatTime(tmp[21]);
        _OrderFrom[3] = Pub.ValidatTime(tmp[22]);
        _OrderTo[0] = Pub.ValidatTime(tmp[23]);
        _OrderTo[1] = Pub.ValidatTime(tmp[24]);
        _OrderTo[2] = Pub.ValidatTime(tmp[25]);
        _OrderTo[3] = Pub.ValidatTime(tmp[26]);
        byte.TryParse(tmp[27], out _MessageEnabled);
        _Message = tmp[28];
        byte.TryParse(tmp[29], out _Restday[0]);
        byte.TryParse(tmp[30], out _Restday[1]);
        byte.TryParse(tmp[31], out _Restday[2]);
        byte.TryParse(tmp[32], out _Restday[3]);
        byte.TryParse(tmp[33], out _Restday[4]);
        byte.TryParse(tmp[34], out _Restday[5]);
        byte.TryParse(tmp[35], out _Restday[6]);
        
      }
    }

    public int CardInterval
    {
      get { return _CardInterval; }
    }

    public int RelayOutput1
    {
      get { return _RelayOutput1; }
    }

    public int RelayOutput2
    {
      get { return _RelayOutput2; }
    }

    public byte RelayOutputActionTime1
    {
      get { return _RelayOutputActionTime1; }
    }

    public byte RelayOutputActionTime2
    {
      get { return _RelayOutputActionTime2; }
    }

    public byte RingingBells
    {
      get { return _RingingBells; }
    }

    public byte ShowCardInfo
    {
      get { return _ShowCardInfo; }
    }

    public byte EnabledCardOrder
    {
      get { return _EnabledCardOrder; }
    }

    public string AttendanceTitle
    {
      get { return _AttendanceTitle; }
    }

    public string CardType
    {
      get { return _CardType; }
    }

    public byte EnabledOpter
    {
      get { return _EnabledOpter; }
    }

    public string[] Order
    {
      get { return _Order; }
    }

    public byte[] NextDay
    {
      get { return _NextDay; }
    }
    public byte[] Restday
    {
      get { return _Restday; }
    }
    public string[] OrderFrom
    {
      get { return _OrderFrom; }
    }

    public string[] OrderTo
    {
      get { return _OrderTo; }
    }

    public byte MessageEnabled
    {
      get { return _MessageEnabled; }
    }

    public string Message
    {
      get { return _Message; }
    }
  }

  public class KQTimeInfo
  {
    private Base Pub = new Base();
    private string[] _BeginTime = new string[6] { "00:01", "00:00", "00:00", "00:00", "00:00", "00:00" };
    private string[] _EndTime = new string[6] { "23:59", "00:00", "00:00", "00:00", "00:00", "00:00" };

    public KQTimeInfo(string TimeString)
    {
      string[] tmp = TimeString.Split('#');
      if (tmp.Length >= 12)
      {
        for (int i = 0; i <= 5; i++)
        {
          _BeginTime[i] = Pub.ValidatTime(tmp[i]);
          _EndTime[i] = Pub.ValidatTime(tmp[i + 6]);
        }
      }
    }

    public string[] BeginTime
    {
      get { return _BeginTime; }
    }

    public string[] EndTime
    {
      get { return _EndTime; }
    }
  }

  public class KQBellTimeInfo
  {
    private Base Pub = new Base();
    private string[] _BellTime = new string[6] { "00:00", "00:00", "00:00", "00:00", "00:00", "00:00" };

    public KQBellTimeInfo(string BellString)
    {
      string[] tmp = BellString.Split('#');
      if (tmp.Length >= 6)
      {
        for (int i = 0; i <= 5; i++)
        {
          _BellTime[i] = Pub.ValidatTime(tmp[i]);
        }
      }
    }

    public string[] BellTime
    {
      get { return _BellTime; }
    }
  }

  public class KQTextFormatInfo
  {
    private Base Pub = new Base();

    public const string KQ_ConfigID = "KQSetup";
    public const string KQ_TextFormat = "TextFormat";

    private bool _Allow = false;
    private byte _SepFlag = 0;
    private string _SepStr = "";
    private bool _MacSNAllow = true;
    private byte _MacSNLen = 3;
    private byte _MacSNOrder = 0;
    private bool _EmpNoAllow = true;
    private byte _EmpNoLen = 10;
    private byte _EmpNoOrder = 1;
    private bool _EmpNameAllow = true;
    private byte _EmpNameLen = 20;
    private byte _EmpNameOrder = 2;
    private bool _CardNoAllow = true;
    private byte _CardNoLen = 10;
    private byte _CardNoOrder = 3;
    private bool _DataTimeAllow = true;
    private string _DataTimeFormat = "yyyyMMddHHmmss";
    private byte _DataTimeOrder = 4;

    public KQTextFormatInfo(string formatString)
    {
      string[] tmp = formatString.Split('#');
      if (tmp.Length >= 18)
      {
        _Allow = tmp[0] == "1";
        byte.TryParse(tmp[1], out _SepFlag);
        _SepStr = tmp[2];
        _MacSNAllow = tmp[3] == "1";
        byte.TryParse(tmp[4], out _MacSNLen);
        byte.TryParse(tmp[5], out _MacSNOrder);
        _EmpNoAllow = tmp[6] == "1";
        byte.TryParse(tmp[7], out _EmpNoLen);
        byte.TryParse(tmp[8], out _EmpNoOrder);
        _EmpNameAllow = tmp[9] == "1";
        byte.TryParse(tmp[10], out _EmpNameLen);
        byte.TryParse(tmp[11], out _EmpNameOrder);
        _CardNoAllow = tmp[12] == "1";
        byte.TryParse(tmp[13], out _CardNoLen);
        byte.TryParse(tmp[14], out _CardNoOrder);
        _DataTimeAllow = tmp[15] == "1";
        _DataTimeFormat = tmp[16];
        byte.TryParse(tmp[17], out _DataTimeOrder);
      }
    }

    public bool Allow
    {
      get { return _Allow; }
    }

    public byte SepFlag
    {
      get { return _SepFlag; }
    }

    public string SepStr
    {
      get { return _SepStr; }
    }

    public bool MacSNAllow
    {
      get { return _MacSNAllow; }
    }

    public byte MacSNLen
    {
      get { return _MacSNLen; }
    }

    public byte MacSNOrder
    {
      get { return _MacSNOrder; }
    }

    public bool EmpNoAllow
    {
      get { return _EmpNoAllow; }
    }

    public byte EmpNoLen
    {
      get { return _EmpNoLen; }
    }

    public byte EmpNoOrder
    {
      get { return _EmpNoOrder; }
    }

    public bool EmpNameAllow
    {
      get { return _EmpNameAllow; }
    }

    public byte EmpNameLen
    {
      get { return _EmpNameLen; }
    }

    public byte EmpNameOrder
    {
      get { return _EmpNameOrder; }
    }

    public bool CardNoAllow
    {
      get { return _CardNoAllow; }
    }

    public byte CardNoLen
    {
      get { return _CardNoLen; }
    }

    public byte CardNoOrder
    {
      get { return _CardNoOrder; }
    }

    public bool DataTimeAllow
    {
      get { return _DataTimeAllow; }
    }

    public string DataTimeFormat
    {
      get { return _DataTimeFormat; }
    }

    public byte DataTimeOrder
    {
      get { return _DataTimeOrder; }
    }

    public string GetKQFormatText(int MacSN, string EmpNo, string EmpName, string CardNo, DateTime dt)
    {
      string ret = "";
      string SepStr = "";
      string MacSNX = "";
      string EmpNoX = "";
      string EmpNameX = "";
      string CardNoX = "";
      string DataTimeX = "";
      if (_Allow)
      {
        switch (_SepFlag)
        {
          case 0:
            SepStr = "";
            break;
          case 1:
            SepStr = "\t";
            break;
          default:
            SepStr = _SepStr;
            break;
        }
        if (_MacSNAllow)
        {
          MacSNX = MacSN.ToString();
          if (_MacSNLen > 0)
          {
            while (MacSNX.Length < _MacSNLen)
            {
              MacSNX = "0" + MacSNX;
            }
          }
        }
        if (_EmpNoAllow)
        {
          EmpNoX = EmpNo;
          if (_EmpNoLen > 0)
          {
            while (EmpNoX.Length < _EmpNoLen)
            {
              EmpNoX = " " + EmpNoX;
            }
          }
        }
        if (_EmpNameAllow)
        {
          EmpNameX = EmpName;
          if (_EmpNameLen > 0)
          {
            while (Pub.GetTextLength(EmpNameX) < _EmpNameLen)
            {
              EmpNameX = " " + EmpNameX;
            }
          }
        }
        if (_CardNoAllow)
        {
          CardNoX = CardNo;
          if (_CardNoLen > 0)
          {
            while (CardNoX.Length < _CardNoLen)
            {
              CardNoX = "0" + CardNoX;
            }
          }
        }
        if (_DataTimeAllow)
        {
          DataTimeX = dt.ToString();
          if (_DataTimeFormat != "") DataTimeX = dt.ToString(_DataTimeFormat);
        }
        if (_MacSNOrder == 0)
          ret += MacSNX + SepStr;
        else if (_EmpNoOrder == 0)
          ret += EmpNoX + SepStr;
        else if (_EmpNameOrder == 0)
          ret += EmpNameX + SepStr;
        else if (_CardNoOrder == 0)
          ret += CardNoX + SepStr;
        else if (_DataTimeOrder == 0)
          ret += DataTimeX + SepStr;
        if (_MacSNOrder == 1)
          ret += MacSNX + SepStr;
        else if (_EmpNoOrder == 1)
          ret += EmpNoX + SepStr;
        else if (_EmpNameOrder == 1)
          ret += EmpNameX + SepStr;
        else if (_CardNoOrder == 1)
          ret += CardNoX + SepStr;
        else if (_DataTimeOrder == 1)
          ret += DataTimeX + SepStr;
        if (_MacSNOrder == 2)
          ret += MacSNX + SepStr;
        else if (_EmpNoOrder == 2)
          ret += EmpNoX + SepStr;
        else if (_EmpNameOrder == 2)
          ret += EmpNameX + SepStr;
        else if (_CardNoOrder == 2)
          ret += CardNoX + SepStr;
        else if (_DataTimeOrder == 2)
          ret += DataTimeX + SepStr;
        if (_MacSNOrder == 3)
          ret += MacSNX + SepStr;
        else if (_EmpNoOrder == 3)
          ret += EmpNoX + SepStr;
        else if (_EmpNameOrder == 3)
          ret += EmpNameX + SepStr;
        else if (_CardNoOrder == 3)
          ret += CardNoX + SepStr;
        else if (_DataTimeOrder == 3)
          ret += DataTimeX + SepStr;
        if (_MacSNOrder == 4)
          ret += MacSNX + SepStr;
        else if (_EmpNoOrder == 4)
          ret += EmpNoX + SepStr;
        else if (_EmpNameOrder == 4)
          ret += EmpNameX + SepStr;
        else if (_CardNoOrder == 4)
          ret += CardNoX + SepStr;
        else if (_DataTimeOrder == 4)
          ret += DataTimeX + SepStr;
        if (ret.Substring(ret.Length - SepStr.Length) == SepStr) ret = ret.Substring(0, ret.Length - SepStr.Length);
      }
      return ret;
    }
  }

  public class KQReadData
  {
    private Base Pub = new Base();
    private string cap = "";
    private string msgContinue = "";
    private bool IsNew = false;
    private int logCount = 0;
    private TAttLog attLog = new TAttLog();
    private bool IsStop = false;

    public delegate void ProcessReadData(int RecordCount, int RecordIndex);
    public delegate void ProcessRealData(TAttLog attLog, int MacSN);

    public KQReadData(string title)
    {
      cap = title;
      msgContinue = Pub.GetResText("", "MsgContinue", "");
    }

    public KQReadData(string title, bool NewData)
    {
      cap = title;
      msgContinue = Pub.GetResText("", "MsgContinue", "");
      IsNew = NewData;
    }

    public void StopData()
    {
      IsStop = true;
    }

    public bool ReadData(Database db, KQTextFormatInfo textFormat, int MacSN, ref int RecordCount,
      ref int RecordIndex, bool AutoRetry, ProcessReadData prog)
    {
      return ReadData(db, textFormat, MacSN, ref RecordCount, ref RecordIndex, AutoRetry, prog, null);
    }

    public bool ReadData(Database db, KQTextFormatInfo textFormat, int MacSN, ref int RecordCount,
      ref int RecordIndex, bool AutoRetry, ProcessRealData prog)
    {
      return ReadData(db, textFormat, MacSN, ref RecordCount, ref RecordIndex, AutoRetry, null, prog);
    }

    private bool ReadData(Database db, KQTextFormatInfo textFormat, int MacSN, ref int RecordCount,
      ref int RecordIndex, bool AutoRetry, ProcessReadData prog, ProcessRealData progReal)
    {
      RecordCount = 0;
      RecordIndex = 0;
      bool ret = false;
      TRecordCount recCount = new TRecordCount();
      if (!DeviceObject.objKS.AttLogCount(IsNew, ref recCount)) return false;
      RecordCount = recCount.Count;
      if (RecordCount == 0) return true;
      DialogResult result;
      for (int i = 1; i <= recCount.Sector; i++)
      {
      RetryReadData:
        if (IsStop)
        {
          DeviceObject.objKS.Close();
          break;
        }
        Application.DoEvents();
        ret = DeviceObject.objKS.AttLogData(SystemInfo.DataFilePath, IsNew, i, ref logCount);
        if (!ret)
        {
          if (AutoRetry) goto RetryReadData;
          result = Pub.MessageBoxQuestion(cap + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue,
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
          if (RecordIndex >= recCount.Count) break;
          if (DeviceObject.objKS.AttLogDataValue(j, ref attLog))
          {
            WriteTextFile(attLog, MacSN);
            if (textFormat.Allow) WriteTextFormat(db, textFormat, attLog, MacSN);
            SaveDB(db, attLog, MacSN);
            if (attLog.IsCount != 0) RecordIndex = RecordIndex + 1;
            if (RecordIndex > recCount.Count) RecordIndex = recCount.Count;
            if (prog != null) prog(recCount.Count, RecordIndex);
            if (progReal != null) progReal(attLog, MacSN);
          }
        }
      }
      if (ret && IsNew && recCount.Count > 0 && !IsStop)
      {
      RetryFlag:
        ret = DeviceObject.objKS.AttLogFlag(recCount.Count);
        if (!ret)
        {
          if (AutoRetry) goto RetryFlag;
          if (!Pub.MessageBoxShowQuestion(cap + "\r\n\r\n" +
            DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue)) goto RetryFlag;
        }
      }
      return ret;
    }

    public bool ReadDataUSB(string usbFile, Database db, KQTextFormatInfo textFormat, ref int RecordCount,
      ref int RecordIndex, ProcessReadData prog)
    {
      bool ret = false;
      RecordCount = 0;
      RecordIndex = 0;
      TRecordCountUSB recCount = new TRecordCountUSB();
      bool IsBigMac = false;
      try
      {
        ret = DeviceObject.objKS.AttLogCountUSB(IsBigMac, usbFile, ref recCount);
        if (!ret)
        {
          Pub.ShowErrorMsg(Pub.GetResText("", "ErrorKQUSB", ""));
          return false;
        }
        if (recCount.MacType != 1)
        {
          Pub.ShowErrorMsg(Pub.GetResText("", "ErrorKQUSBType", ""));
          return false;
        }
        RecordCount = recCount.Count;
        int MacSN = recCount.MacSN;
        int CardType = recCount.CardType;
        string MacVer = recCount.Ver;
        if (RecordCount == 0) ret = true;
        for (int i = 1; i <= recCount.Sector; i++)
        {
          ret = DeviceObject.objKS.AttLogDataUSB(IsBigMac, MacVer, i, ref logCount);
          if (ret)
          {
            for (int j = 0; j < logCount; j++)
            {
              if (RecordIndex >= recCount.Count) break;
              if (DeviceObject.objKS.AttLogDataValue(j, ref attLog))
              {
                WriteTextFile(attLog, MacSN);
                if (textFormat.Allow) WriteTextFormat(db, textFormat, attLog, MacSN);
                SaveDB(db, attLog, MacSN);
                if (attLog.IsCount != 0) RecordIndex = RecordIndex + 1;
                if (RecordIndex > recCount.Count) RecordIndex = recCount.Count;
                prog(recCount.Count, RecordIndex);
              }
            }
          }
        }
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E);
      }
      return ret;
    }

    public bool ReadDataText(string textFile, Database db, KQTextFormatInfo textFormat, ref int RecordCount,
      ref int RecordIndex, ProcessReadData prog)
    {
      bool ret = false;
      RecordCount = 0;
      RecordIndex = 0;
      StreamReader sr = null;
      string line;
      List<TAttLog> logList = new List<TAttLog>();
      List<int> snList = new List<int>();
      int MacSN = 0;
      try
      {
        sr = new StreamReader(textFile);
        while (!sr.EndOfStream)
        {
          line = sr.ReadLine();
          if (line != "")
          {
            attLog = new TAttLog();
            attLog.ReadMark = Convert.ToByte(line.Substring(0, 2));
            attLog.CardID = line.Substring(2, 10);
            if (line.Length == 45)
            {
              attLog.PhyID = line.Substring(12, 10);
              attLog.MacTAG = line.Substring(22, 4);
              attLog.CardTime = new DateTime(Convert.ToInt16(line.Substring(26, 4)),
                Convert.ToByte(line.Substring(30, 2)), Convert.ToByte(line.Substring(32, 2)),
                Convert.ToByte(line.Substring(34, 2)), Convert.ToByte(line.Substring(36, 2)),
                Convert.ToByte(line.Substring(38, 2)));
              MacSN = Convert.ToInt32(line.Substring(40, 5));
            }
            else
            {
              attLog.PhyID = "";
              attLog.MacTAG = "";
              attLog.CardTime = new DateTime(Convert.ToInt16(line.Substring(12, 4)),
                Convert.ToByte(line.Substring(16, 2)), Convert.ToByte(line.Substring(18, 2)),
                Convert.ToByte(line.Substring(20, 2)), Convert.ToByte(line.Substring(22, 2)),
                Convert.ToByte(line.Substring(24, 2)));
              MacSN = Convert.ToInt32(line.Substring(26, 5));
            }
            logList.Add(attLog);
            snList.Add(MacSN);
            RecordCount++;
          }
        }
        for (int i = 0; i < RecordCount; i++)
        {
          attLog = logList[i];
          MacSN = snList[i];
          SaveDB(db, attLog, MacSN);
          RecordIndex = RecordIndex + 1;
          if (RecordIndex > RecordCount) RecordIndex = RecordCount;
          prog(RecordCount, RecordIndex);
        }
        ret = true;
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E);
      }
      finally
      {
        if (sr != null) sr.Close();
      }
      return ret;
    }

    public bool ReadDataReal(string RealData, Database db, KQTextFormatInfo textFormat, int MacSN, string Version,
      ref int RecordCount, ref int LogID, ProcessRealData prog)
    {
      bool ret = false;
      RecordCount = 0;
      LogID = 0;
      try
      {
        ret = DeviceObject.objKS.AttLogDataReal(RealData, Version, ref RecordCount, ref LogID);
        for (int j = 0; j < RecordCount; j++)
        {
          if (DeviceObject.objKS.AttLogDataValue(j, ref attLog))
          {
            WriteTextFile(attLog, MacSN);
            if (textFormat.Allow) WriteTextFormat(db, textFormat, attLog, MacSN);
            SaveDB(db, attLog, MacSN);
            if (attLog.IsCount == 0) RecordCount = RecordCount - 1;
            if (prog != null) prog(attLog, MacSN);
          }
        }
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E);
      }
      return ret;
    }

    private void WriteTextFile(TAttLog attLog, int MacSN)
    {
      if (attLog.CardTime == null || attLog.CardTime.ToOADate() == 0) return;
      string fileName = SystemInfo.DataFilePath + "KQ" + DateTime.Now.ToString(SystemInfo.DateFormatLog) + ".dat";
      DateTime t = Convert.ToDateTime(attLog.CardTime);
      string msg = attLog.ReadMark.ToString("00") + attLog.CardID + attLog.PhyID + attLog.MacTAG +
        t.ToString(SystemInfo.DateTimeFormatLog) + MacSN.ToString("00000");
      Pub.WriteTextFile(fileName, msg);
    }

    private void WriteTextFormat(Database db, KQTextFormatInfo textFormat, TAttLog attLog, int MacSN)
    {
      if (attLog.CardTime == null || attLog.CardTime.ToOADate() == 0) return;
      DataTableReader dr = null;
      string EmpNo = "";
      string EmpName = "";
      bool IsError = false;
      try
      {
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002001, new string[] { "106", SystemInfo.CardType.ToString(), 
          attLog.CardID }));
        if (dr.Read())
        {
          EmpNo = dr["EmpNo"].ToString();
          EmpName = dr["EmpName"].ToString();
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
      DateTime t = Convert.ToDateTime(attLog.CardTime);
      string fileName = SystemInfo.DataFilePath + "KQ" + t.ToString(SystemInfo.DateFormatLog) + "_Format.txt";
      string msg = textFormat.GetKQFormatText(MacSN, EmpNo, EmpName, attLog.CardID, t);
      Pub.WriteTextFile(fileName, msg);
    }

    private void SaveDB(Database db, TAttLog attLog, int MacSN)
    {
      if (attLog.CardTime.ToOADate() == 0) return;
      DateTime t = attLog.CardTime;
      int KQTime = t.Hour * 60 * 60 + t.Minute * 60 + t.Second;
      List<string> sql = new List<string>();
      sql.Clear();
      if (attLog.IsOrder == 0 || attLog.IsOrder == 1)
      {
        sql.Add(Pub.GetSQL(DBCode.DB_002001, new string[] { "105", SystemInfo.CardType.ToString(), attLog.CardID, 
          t.ToString(SystemInfo.SQLDateFMT), KQTime.ToString(), MacSN.ToString(), "0", "", OprtInfo.OprtSysID, 
          attLog.ReadMark.ToString() }));
      }
      if ((attLog.IsOrder == 1 || attLog.IsOrder == 2) && attLog.OrderDate.ToOADate() != 0)
      {
        sql.Add(Pub.GetSQL(DBCode.DB_002001, new string[] { "203", attLog.CardID, 
          attLog.OrderDate.ToString(SystemInfo.SQLDateFMT), attLog.MealType.ToString(), 
          OprtInfo.OprtSysID, "0", MacSN.ToString() }));
      }
      db.ExecSQL(sql);
    }
  }

  public class KQDownBlack
  {
    private DataTable dt = null;
    private QHKS.TConnInfo conn;
    private Base Pub = new Base();

    public KQDownBlack(DataTable dataTable, QHKS.TConnInfo connInfo)
    {
      dt = dataTable.Copy();
      conn = connInfo;
    }

    public bool Down()
    {
      if (!DeviceObject.objKS.PubBlackClear()) return false;
      int max = dt.Rows.Count;
      if (max == 0) return true;
      string cardNo = "";
      for (int i = 0; i < max; i++)
      {
        if (!Pub.ValueToBool(dt.Rows[i]["SelectCheck"])) continue;
        if (SystemInfo.CardType == 0)
          cardNo = dt.Rows[i]["CardSectorNo"].ToString();
        else
          cardNo = dt.Rows[i]["CardPhysicsNo10"].ToString();
        DeviceObject.objKS.PubBlackInit(cardNo, i == 0, false);
      }
      return DeviceObject.objKS.PubBlackData(SystemInfo.MainHandle.ToInt32());
    }
  }
}