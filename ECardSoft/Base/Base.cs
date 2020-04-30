using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Drawing;
using System.Reflection;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.Win32;

namespace ECard78
{
  public struct SystemInfo
  {
    public static bool isInit = false;
    public static string AppPath = "";
    public static string ReportPath = "";
    public static string DataFilePath = "";
    public static string System32Path = "";
    public static string IniFileName;
    public static string AppTitle = "";
    public static int DBType = 1;
    public static string ConnStr = "";
    public static string ConnStrReport = "";
    public static string AppVersion = "V78.3.0";
    public static string ComputerName = "";
    public static bool AccIsForward = false;
    public static string AccDBVersion = "";
    public static DateTime AccDBDate = new DateTime();
    public static string AccDBName = "";
    public static string DatabaseName = "";
    public static string CommanyName = "";
    public static string CommanySysID = "";
    public static string LangName = "";
    public static string CustomerName = "";
    public static int CardTypeCount = 8;
    public static bool AllowCardWarn = false;
    public static DateTime LastDBDate = new DateTime();

    public static IniFile ini = null;
    public static IniFile webIni = null;
    public static LangRes res = null;

    public const string Encry = "quzhengyu";
    public const string ReportRegister = "19B6T1BGD4W3";
    public const int MaxSN603 = 254;
    public const int MaxSN603Ex = 65534;
    public const int MaxSN603Find = 255;
    public const int MaxSN603FindEx = 65535;
    public const int MaxProd603 = 9999;
    public const int LAN603Port = 6000;
    public const int LAN80XPort = 60000;
    public const string GPRS603IP = "120.24.65.195";
    public const int REAL603Port = 8600;
    public const double MaxDeposit = 999999.99;
    public const double MaxDepositSK = 42949672.95;
    public const uint MaxCardID = 0xffffffff;
    public static string CardTypeDefault = "";
    public static string CurrencySymbol = "";
    public const string DefaultDBBak = "ECard.bak";
    public static string SQLDateFMT = "yyyy-MM-dd";
    public static string SQLDateTimeFMT = "yyyy-MM-dd HH:mm:ss";
    public static string DateFormatDBVer = "yyyy.MM.dd";
    public static string DateTimeFormat = "";
    public static string DateTimeFormatLog = "";
    public static string DateFormatLog = "";
    public static string DateFormatNo = "yyMMdd";
    public static string YMFormatCard = "yyyyMM";
    public static string YMFormat = "";
    public static string YMFormatDB = "";

    public const int MaxSNFinger = 255;

    public static bool IsAddEmpNo = true;
    public static string EmpNoPrefix = "";
    public static byte EmpNoNumBit = 4;
    public static byte PubCardSector = 1;
    public static byte SFCardSector = 2;
    public static byte SKCardSector = 4;
    public static string DealersCode = "";
    public static int CustomersCode = 0;
    public static byte SFBtBagFlag = 0;
    public static byte SFBtBagDate = 0;
    public static string CardKey = "";
    public static int CardValidDays = 60;
    public static bool EmpDelete = false;
    public static bool FaCardFee = false;
    public static bool AllDevAllowance = false;
    public static bool AllowExtScreen = false;
    public static bool AllowFaDeposit = false;
    public static bool AllowRefAllowance = false;
    public static bool AllowLossSelect = false;
    public static bool AllowCustomerCardNo = false;
    public static bool IsDecimalProduct = false;
    public static bool HasMobileFailLog = false;
    public static int AllowCheckDepositLimit = 0;

    public static bool SystemIsExit = true;

    public static IntPtr MainHandle;

    public static List<FuncObject> funcList = new List<FuncObject>();

    public static bool HasRS = false;
    public static bool HasKQ = false;
    public static byte KQFlag = 0;
    public static bool HasMJ = false;
    public static bool HasSF = false;
    public static bool HasSK = false;
    public static bool HasFaCard = true;
    public static byte CardProtocol = 0;
    public static bool AdvTimeGroup = true;
    public static bool AdvUseOtherCard = true;
    public const int MaxTimeNo = 99;
    public const int MaxTimeNoNew = 50;
    public const int WanInterval = 1000;
    public static byte WaterFlag = 2;

    public static bool AllowanceCardType = false;
    public static byte CardType = 0;

    public static bool IsRestart = false;

    public static bool SFCardDRMode = false;
    public static byte CheckSameBT = 1;
    public static bool SKDepositTotal = false;

    public static bool HasMoreDepositType = false;
    public static double DefDepositMoney = 0.00;
    public static bool HasMoreRefundmentType = false;
    public static bool DefMoreRefundmentType = false;
    public static string MsgMaxCardID = "";

    public static bool IsMonthLimit = false;
    public static bool IsBigMacAdd = false;
    public static bool IsRealOther = false;
    public static bool IsLongEmpID = false;

    public static bool IgnoreRegister = false;
    public static bool IgnoreMobile = false;

    public static bool UseRealSendKQ = false;
    public static bool UseRealSendMJ = false;
    public static bool UseRealSendSF = false;
    public static bool RelieveReqCard = true;

    public static bool IsNewMJ = false;

    public static List<string> langList = new List<string>() 
    { 
      "CHS", "CHT", "JPN", "KOR", "DEU", "RUS", "FRA", "ESN", "SQI", "ARG", "AZE", "ETI", "EUQ", "BGR", 
      "BEL", "ISL", "PLK", "TTT", "DAN", "DIV", "FOS", "FAR", "SAN", "FIN", "KAT", "GUJ", "KKZ", "NLD", 
      "KYR", "GLC", "CAT", "CSY", "KAN", "HRV", "KNK", "LVI", "LTH", "ROM", "MAR", "MSL", "MKI", "MON", 
      "AFK", "NOR", "PAN", "PTG", "SVE", "SRL", "SKY", "SLV", "SWK", "TEL", "TAM", "THA", "TRK", "URD", 
      "UKR", "UZB", "HEB", "ELL", "HUN", "SYR", "HYE", "ITA", "HIN", "IND", "VIT", "ENG", 
    };
    public static string[] AppTitleLNG = new string[langList.Count];
  }

  public struct ExtModuleInfo
  {
    public static Assembly[] objDll = null;
    public static Type[] tpDll = null;
    public static string[] homeName = null;
  }

  public struct DBServerInfo
  {
    public static string ServerName = "";
    public static bool WindowsNT = true;
    public static string UserName = "";
    public static string UserPass = "";
  }

  public struct OprtInfo
  {
    public static string OprtSysID = "";
    public static string OprtNo = "";
    public static bool OprtIsSys = false;
    public static string DepartPower = "";
    public static string DepartPowerSysID = "";
    public static string OprtNoAndName = "";
  }

  public struct RegisterInfo
  {
    public static string ProductName = "";
    public static string Serial = "";
    public static int EmpCount = 0;
    public static int ModuleCount = 0;
    public static bool MustReg = false;
    public static bool AllowReg = false;
    public static bool IsReg = false;
    public static bool IsAlways = false;
    public static bool IsTest = false;
    public static bool IsValid = false;
    public static string RegUser = "";
    public static string RegKey = "";
    public static string StateText = "";
    public static DateTime StartDate;
    public static DateTime EndDate;
    public static DateTime ValidDate;
    public static string RegDateText = "";
  }

  public struct MacConnTypeString
  {
    public const string USB = "USB";
    public const string Comm = "RS232/485";
    public const string LAN = "LAN";
    public const string GPRS = "GPRS";
  }

  public struct DeviceObject
  {
    public static HSUNFK.AES objAES = null;
    public static HSUNFK.DES objDES = null;
    public static HSUNFK.CPIC objCPIC = null;
    public static HSUNFK.Card objCard = null;
    public static QHKS.KS objKS = null;
    public static QHKS.MJ objMJ = null;
    public static QHKS.App objApp = null;
    public static FK623Attend objFK623 = new FK623Attend();
    public static AccessV2API objMJNew = new AccessV2API();
  }

  public enum DateInterval
  {
    Milliseconds, Second, Minute, Hour, Day, Week, Month, Quarter, Year
  }

  public class Base
  {
    private static MSSQL objMS = new MSSQL();
    private static frmMessage frmMsg = null;
    private static frmException frmErr = null;
    private static frmDBPathSelect DBPathSelect = null;

    public Base()
    {
    }

    private void LoadDll(ref Assembly obj, ref Type tp, string DllName)
    {
      obj = null;
      try
      {
        obj = Assembly.LoadFile(SystemInfo.AppPath + DllName);
        tp = obj.GetTypes()[0];
      }
      catch
      {
      }
    }

    [DllImport("user32.dll", EntryPoint = "SendMessageA")]
    private static extern IntPtr SendMessageA(IntPtr hwnd, int wMsg, StringBuilder wParam, StringBuilder lParam);
    [DllImport("user32.dll", EntryPoint = "SendMessageA")]
    private static extern IntPtr SendMessageB(IntPtr hwnd, int wMsg, IntPtr wParam, StringBuilder lParam);
    public int SendMessage(IntPtr hwnd, int wMsg, StringBuilder wParam, StringBuilder lParam)
    {
      IntPtr ptr = SendMessageA(hwnd, wMsg, wParam, lParam);
      int ret = Convert.ToInt32(PtrToString(ptr));
      return ret;
    }
    public int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, StringBuilder lParam)
    {
      IntPtr ptr = SendMessageB(hwnd, wMsg, wParam, lParam);
      int ret = Convert.ToInt32(PtrToString(ptr));
      return ret;
    }

    public string PtrToString(IntPtr Ptr)
    {
      return System.Runtime.InteropServices.Marshal.PtrToStringAnsi(Ptr);
    }

    public IntPtr StringToPtr(string src)
    {
      return System.Runtime.InteropServices.Marshal.StringToBSTR(src);
    }

    public bool IsNumeric(string str)
    {
      if (str == null) str = "";
      System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"^[-]?\d+[.]?\d*$");
      return reg.IsMatch(str);
    }

    public string ValidatTime(string str)
    {
      string ret = "";
      string[] tmp = str.Split(':');
      if (tmp.Length >= 2)
      {
        if (tmp[0].Trim() == "")
          tmp[0] = "00";
        else if (tmp[0].Trim().Length == 1)
          tmp[0] = tmp[0].Trim() + "0";
        if (tmp[1].Trim() == "")
          tmp[1] = "00";
        else if (tmp[1].Trim().Length == 1)
          tmp[1] = tmp[1].Trim() + "0";
        ret = tmp[0] + ":" + tmp[1];
      }
      else
        ret = "00:00";
      DateTime dt = new DateTime();
      if (!DateTime.TryParse(ret, out dt)) ret = "00:00";
      return ret;
    }

    [DllImport("user32.dll", EntryPoint = "GetWindowText")]
    private static extern int GetWindowText(int hwnd, StringBuilder lpString, int cch);
    [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
    private static extern IntPtr GetActiveWindow();
    public string GetWindowTitle()
    {
      StringBuilder s = new StringBuilder(1024);
      IntPtr activeWindow = GetActiveWindow();
      int i = GetWindowText(activeWindow.ToInt32(), s, s.Capacity);
      return s.ToString();
    }

    public string GetFileNamePath(string FileName)
    {
      string ret = "";
      string[] tmp = FileName.Split('\\');
      for (int i = 0; i < tmp.Length - 1; i++)
      {
        ret += tmp[i] + "\\";
      }
      return ret;
    }

    public string GetFileName(string FileName)
    {
      string ret = "";
      string[] tmp = FileName.Split('\\');
      ret = tmp[tmp.Length - 1];
      return ret;
    }

    public string GetFileNameExt(string FileName)
    {
      string ret = GetFileName(FileName);
      string[] tmp = FileName.Split('.');
      ret = tmp[tmp.Length - 1];
      return ret;
    }

    public string GetFileTimeString(string fileName)
    {
      DateTime dt = GetFileTime(fileName);
      return dt.ToString();
    }

    public DateTime GetFileTime(string fileName)
    {
      DateTime dt = File.GetLastWriteTime(fileName);
      return dt;
    }

    public void WriteTextFile(string FileName, string Text)
    {
      string path = GetFileNamePath(FileName);
      StreamWriter writer = null;
      try
      {
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        if (File.Exists(FileName))
          writer = new StreamWriter(FileName, true);
        else
          writer = new StreamWriter(FileName);
        writer.WriteLine(Text);
      }
      finally
      {
        if (writer != null) writer.Close();
      }
    }

    public void ShowErrorMsg(Exception E)
    {
      ShowErrorMsg(E, "");
    }

    public void ShowErrorMsg(Exception E, string Other)
    {
      string time = DateTime.Now.ToString(SystemInfo.DateTimeFormat);
      string src = GetResText("", "ErrorSource", "") + E.Source;
      string inf = E.StackTrace;
      string msg = GetResText("", "ErrorMessage", "") + E.Message;
      //WriteTextFile(SystemInfo.AppPath + "Error.log", "[" + time + "] " + Application.ExecutablePath + "\r\n" +
      //src + "\r\n" + inf + "\r\n" + msg + "\r\n");
      if (frmErr == null) frmErr = new frmException();
      if (Other != "") Other = "\r\n\r\n" + Other;
      frmErr.InitErrorMessage(E.Message + "\r\n" + Other);
      frmErr.ShowDialog();
      frmErr = null;
    }

    public void ShowErrorMsg(Exception E, List<string> Other)
    {
      string tmp = "";
      for (int i = 0; i < Other.Count; i++)
      {
        tmp = tmp + Other[i] + "\r\n";
      }
      ShowErrorMsg(E, tmp);
    }

    public void MessageBoxShow(string Msg)
    {
      MessageBoxShow(Msg, MessageBoxIcon.Exclamation);
    }

    public void MessageBoxShow(string Msg, MessageBoxIcon Icon)
    {
      string Title = SystemInfo.AppTitle;
      if (Title == "") Title = GetWindowTitle().ToString();
      MessageBox.Show(Msg, Title, MessageBoxButtons.OK, Icon);
    }

    public bool MessageBoxShowQuestion(string Msg)
    {
      return MessageBoxShowQuestion(Msg, MessageBoxIcon.Question);
    }

    public bool MessageBoxShowQuestion(string Msg, MessageBoxIcon Icon)
    {
      string Title = SystemInfo.AppTitle;
      if (Title == "") Title = GetWindowTitle().ToString();
      return MessageBox.Show(Msg, Title, MessageBoxButtons.YesNo, Icon,
        MessageBoxDefaultButton.Button2) == DialogResult.No;
    }

    public DialogResult MessageBoxQuestion(string Msg)
    {
      return MessageBoxQuestion(Msg, MessageBoxButtons.YesNoCancel);
    }

    public DialogResult MessageBoxQuestion(string Msg, MessageBoxButtons BoxButtons)
    {
      string Title = SystemInfo.AppTitle;
      if (Title == "") Title = GetWindowTitle().ToString();
      return MessageBox.Show(Msg, Title, BoxButtons, MessageBoxIcon.Question);
    }

    public int GetTextLength(string Text)
    {
      int ret = 0;
      int a;
      for (int i = 0; i < Text.Length; i++)
      {
        a = Convert.ToInt32(Text[i]);
        if ((a < 0) || (a > 255)) ret += 2; else ret += 1;
      }
      return ret;
    }

    public bool CheckTextMaxLength(string LabelText, string Text, int MaxLength)
    {
      int size = GetTextLength(Text);
      bool ret = ((MaxLength == 0) || (MaxLength == 32767) ||
        ((MaxLength > 0) && (MaxLength < 32767) & (size <= MaxLength)));
      if (!ret) MessageBoxShow(string.Format(GetResText("Public", "ErrorOutrideMaxLength", ""), size, MaxLength));
      return ret;
    }

    public bool ShowMessageDialog(string MsgText, string MsgFlag, string[] Param)
    {
      bool ret;
      if (frmMsg == null) frmMsg = new frmMessage();
      frmMsg.MsgText = MsgText;
      frmMsg.MsgFlag = MsgFlag;
      frmMsg.Param = Param;
      ret = (frmMsg.ShowDialog() == DialogResult.OK);
      frmMsg = null;
      return ret;
    }

    public void ShowMessageForm(string MsgText)
    {
      if (frmMsg == null) frmMsg = new frmMessage();
      frmMsg.MsgText = MsgText;
      frmMsg.Show();
      Application.DoEvents();
    }

    public void FreeMessageForm()
    {
      if (frmMsg != null) frmMsg.Close();
      frmMsg = null;
    }

    public string GetMSSQLConnStr(string ServerName, bool WindowsNT, string UserName, string UserPass, string DBName)
    {
      if (WindowsNT)
        return string.Format("Trusted_Connection=true;Server={0};Database={1};Pooling=False", ServerName, DBName);
      else
        return string.Format("Trusted_Connection=false;Server={0};Database={1};uid={2};pwd={3};Pooling=False",
          ServerName, DBName, UserName, UserPass);
    }

    public string GetMSSQLConnStrReport(string ServerName, bool WindowsNT, string UserName, string UserPass,
      string DBName)
    {
      if (WindowsNT)
        return string.Format("Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;" +
          "Data Source={0};Initial Catalog={1}", ServerName, DBName);
      else
        return string.Format("Provider=SQLOLEDB.1;Persist Security Info=True;Data Source={0};" +
          "Initial Catalog={1};User ID={2};Password={3}", ServerName, DBName, UserName, UserPass);
    }

    public string GetSQL(DBCode code, string[] Param)
    {
      return GetSQL(code, Param, SystemInfo.DBType);
    }

    public string GetSQL(DBCode code, string[] Param, int DBType)
    {
      string ret = "";
      switch (DBType)
      {
        case 1:
        case 2:
          ret = objMS.GetSQL(code, Param);
          break;
      }
      return ret;
    }

    public string SelectDBPath(bool OnlyPath, bool UseLocal, string DefPath)
    {
      string ret = "";
      if (DBPathSelect == null) DBPathSelect = new frmDBPathSelect();
      DBPathSelect.OnlyPath = OnlyPath;
      DBPathSelect.SelectItemName = DefPath;
      DBPathSelect.UseLocal = UseLocal;
      if (DBPathSelect.ShowDialog() == DialogResult.OK) ret = DBPathSelect.SelectItemName;
      DBPathSelect = null;
      return ret;
    }

    public string SelectDBPath(bool OnlyPath, string DefPath)
    {
      return SelectDBPath(OnlyPath, false, DefPath);
    }

    public void SetFormAppIcon(Form frm)
    {
      frm.Icon = ECard78.Properties.Resources.favicon;
    }

    [DllImport("kernel32.dll")]
    static extern bool GetComputerName(IntPtr p, ref int lpnSize);
    public string GetComputerName()
    {
      IntPtr p = Marshal.AllocHGlobal(256);
      int len = 256;
      GetComputerName(p, ref len);
      return PtrToString(p);
    }

    public string GetOprtEncrypt(string src)
    {
      string ret = src;
      if (src != "")
      {
        ret = DeviceObject.objAES.AesEncrypt(ret, SystemInfo.Encry);
        if (ret == null) ret = "";
      }
      return ret;
    }

    public string GetOprtDecrypt(string src)
    {
      string ret = "";
      if (src != "")
      {
        ret = DeviceObject.objAES.AesDecrypt(src, SystemInfo.Encry);
        if (ret == null) ret = "";
      }
      return ret;
    }

    public string GetAesEncrypt(string src, string key)
    {
      string ret = src;
      if (src != "")
      {
        ret = DeviceObject.objAES.AesEncrypt(ret, key);
        if (ret == null) ret = "";
      }
      return ret;
    }

    public string GetAesDecrypt(string src, string key)
    {
      string ret = "";
      if (src != "")
      {
        ret = DeviceObject.objAES.AesDecrypt(src, key);
        if (ret == null) ret = "";
      }
      return ret;
    }

    public QHKS.TConnInfo ValueToConnInfo(byte IsBigMac, int MacSN, byte MacType, string MacConnType,
      string MacIPAddress, string MacPort, string MacConnPWD, string MacPhysicsAddress)
    {
      QHKS.TConnInfo connInfo = new QHKS.TConnInfo();
      connInfo.IsBigMac = SystemInfo.IsBigMacAdd ? (byte)1 : (byte)0;
      connInfo.CommPort = "";
      connInfo.NetHost = "";
      connInfo.Password = 0;
      if (MacConnType.ToUpper() == MacConnTypeString.USB)
        connInfo.ConnType = 0;
      else if (MacConnType.ToUpper() == MacConnTypeString.Comm)
      {
        connInfo.ConnType = 1;
        connInfo.CommPort = MacPort;
        connInfo.CommBaudRate = Convert.ToInt32(MacConnPWD);
      }
      else if (MacConnType.ToUpper() == MacConnTypeString.LAN)
      {
        connInfo.ConnType = 2;
        connInfo.NetHost = MacIPAddress;
        connInfo.NetPort = Convert.ToInt32(MacPort);
        if (IsNumeric(MacConnPWD)) connInfo.Password = Convert.ToInt32(MacConnPWD);
      }
      else if (MacConnType.ToUpper() == MacConnTypeString.GPRS)
      {
        connInfo.ConnType = 3;
        connInfo.NetHost = MacIPAddress;
        connInfo.NetPort = Convert.ToInt32(MacPort);
        if (IsNumeric(MacConnPWD)) connInfo.Password = Convert.ToInt32(MacConnPWD);
      }
      connInfo.MacSN = MacSN;
      connInfo.MacType = MacType;
      if ((MacType == 32) || (MacType == 33) || (MacType == 34) || (MacType == 35) || (MacType == 36))
      {
        connInfo.MacType = Convert.ToByte(MacType - 30);
      }
      connInfo.MacAddress = MacPhysicsAddress;
      return connInfo;
    }

    public QHKS.TMJConnInfo ValueToMJConnInfo(string MacSN, string MacConnType, string MacIPAddress, string MacPort,
      string MacConnPWD)
    {
      QHKS.TMJConnInfo connInfo = new QHKS.TMJConnInfo();
      connInfo.CommPort = "";
      connInfo.NetHost = "";
      connInfo.CardProtocol = SystemInfo.CardProtocol;
      if (MacConnType.ToUpper() == MacConnTypeString.Comm)
      {
        connInfo.ConnType = 0;
        connInfo.CommPort = MacPort;
      }
      else if (MacConnType.ToUpper() == MacConnTypeString.LAN)
      {
        connInfo.ConnType = 1;
        connInfo.NetHost = MacIPAddress;
        connInfo.NetPort = Convert.ToInt32(MacPort);
      }
      connInfo.MacSN = MacSN;
      return connInfo;
    }

    public TConnInfoNewMJ ValueToNewMJConnInfo(string MacSN, string MacConnType, string MacIPAddress, string MacPort,
      string MacConnPWD)
    {
      TConnInfoNewMJ connInfo = new TConnInfoNewMJ();
      connInfo.CommPort = "";
      connInfo.NetIP = "";
      if (MacConnType.ToUpper() == MacConnTypeString.Comm)
      {
        connInfo.ConnType = MacConnTypeString.Comm;
        connInfo.CommPort = MacPort;
      }
      else if (MacConnType.ToUpper() == MacConnTypeString.LAN)
      {
        connInfo.ConnType = MacConnTypeString.LAN;
        connInfo.NetIP = MacIPAddress;
        connInfo.NetPort = Convert.ToUInt32(MacPort);
      }
      connInfo.MacSN = Convert.ToUInt32(MacSN);
      return connInfo;
    }

    public TConnInfoFinger ValueToConnInfoFinger(int MacSN, string MacSN_GPRS, string MacConnType, string MacIPAddress,
      string MacPort, string MacConnPWD, bool IsGPRS)
    {
      TConnInfoFinger connInfo = new TConnInfoFinger();
      if (MacConnType.ToUpper() == MacConnTypeString.USB)
        connInfo.ConnType = 0;
      else if (MacConnType.ToUpper() == MacConnTypeString.Comm)
      {
        connInfo.ConnType = 1;
        connInfo.CommPort = Convert.ToByte(MacPort.Substring(3));
        connInfo.CommBaudrate = Convert.ToInt32(MacConnPWD);
      }
      else if (MacConnType.ToUpper() == MacConnTypeString.LAN)
      {
        connInfo.ConnType = 2;
        connInfo.NetIP = MacIPAddress;
        connInfo.NetPort = Convert.ToInt32(MacPort);
        if (IsNumeric(MacConnPWD)) connInfo.NetPassword = Convert.ToInt32(MacConnPWD);
      }
      else if (MacConnType.ToUpper() == MacConnTypeString.GPRS)
      {
        connInfo.ConnType = 3;
        connInfo.NetIP = MacIPAddress;
        connInfo.NetPort = Convert.ToInt32(MacPort);
        if (IsNumeric(MacConnPWD)) connInfo.NetPassword = Convert.ToInt32(MacConnPWD);
      }
      connInfo.MacSN = MacSN;
      connInfo.MacSN_GPRS = MacSN_GPRS;
      connInfo.MacType = 3;
      connInfo.IsGPRS = IsGPRS;
      connInfo.ProtocolType = 1;
      return connInfo;
    }

    public byte GetKQMacType(string MacType)
    {
      byte ret = 0;
      if (MacType == GetResText("", "KQMacType0", ""))
        ret = 0;
      else if (MacType == GetResText("", "KQMacType1", ""))
        ret = 1;
      return ret;
    }

    public void InitCommList(System.Windows.Forms.ComboBox cbb)
    {
      cbb.Items.Clear();
      RegistryKey Key;
      Key = Registry.LocalMachine;
      const string Key_Comm = "HARDWARE\\DEVICEMAP\\SERIALCOMM";
      Key = Key.OpenSubKey(Key_Comm);
      TCommPort commPort;
      string tmp = "";
      if (Key != null)
      {
        string[] ValueNames = Key.GetValueNames();
        string CommName, S;
        int CommIndex;
        for (int i = 0; i < ValueNames.Length; i++)
        {
          CommName = Key.GetValue(ValueNames[i]).ToString().Trim();
          tmp = CommName.Substring(CommName.Length - 1);
          while (tmp != "" && !IsNumeric(tmp))
          {
            CommName = CommName.Substring(0, CommName.Length - 1);
            tmp = CommName.Substring(CommName.Length - 1);
          }
          if (CommName != "")
          {
            S = CommName.Substring(3);
            CommIndex = Convert.ToInt32(S);
            if (CommIndex > 10) CommName = "\\\\.\\" + CommName;
            commPort = new TCommPort(CommIndex, CommName);
            cbb.Items.Add(commPort);
          }
        }
        Key.Close();
        Key = null;
      }
      if (cbb.Items.Count == 0)
      {
        for (int i = 1; i < 10; i++)
        {
          commPort = new TCommPort(i, "COM" + i.ToString());
          cbb.Items.Add(commPort);
        }
      }
    }

    public string GetTempPathFileName(string fileName)
    {
      string tempPath = Path.GetTempPath();
      fileName = tempPath + Path.GetFileName(fileName);
      string fileNameWithoutExt = Path.GetFileNameWithoutExtension(fileName);
      string fileExt = Path.GetExtension(fileName);
      int i = 0;
      while (File.Exists(fileName))
      {
        fileName = tempPath + fileNameWithoutExt + string.Format("({0})", ++i) + fileExt;
      }
      return fileName;
    }

    public bool GetSelectDate(bool ShowTime, ref DateTime SelectDate)
    {
      frmPubSelectDate frm = new frmPubSelectDate(ShowTime, SelectDate);
      bool ret = frm.ShowDialog() == DialogResult.OK;
      if (ret) SelectDate = frm.SelectDateTime;
      return ret;
    }

    public long DateDiff(DateInterval Interval, System.DateTime StartDate, System.DateTime EndDate)
    {
      long lngDateDiffValue = 0;
      System.TimeSpan TS = new System.TimeSpan(EndDate.Ticks - StartDate.Ticks);
      switch (Interval)
      {
        case DateInterval.Milliseconds:
          lngDateDiffValue = (long)TS.TotalMilliseconds;
          break;
        case DateInterval.Second:
          lngDateDiffValue = (long)TS.TotalSeconds;
          break;
        case DateInterval.Minute:
          lngDateDiffValue = (long)TS.TotalMinutes;
          break;
        case DateInterval.Hour:
          lngDateDiffValue = (long)TS.TotalHours;
          break;
        case DateInterval.Day:
          lngDateDiffValue = (long)TS.Days;
          break;
        case DateInterval.Week:
          lngDateDiffValue = (long)(TS.Days / 7);
          break;
        case DateInterval.Month:
          lngDateDiffValue = (long)(TS.Days / 30);
          break;
        case DateInterval.Quarter:
          lngDateDiffValue = (long)((TS.Days / 30) / 3);
          break;
        case DateInterval.Year:
          lngDateDiffValue = (long)(TS.Days / 365);
          break;
      }
      return (lngDateDiffValue);
    }

    public string GetDateDiffTimes(System.DateTime StartDate, System.DateTime EndDate)
    {
      return GetDateDiffTimes(StartDate, EndDate, false);
    }

    public string GetDateDiffTimes(System.DateTime StartDate, System.DateTime EndDate, bool HideText)
    {
      long Milliseconds = DateDiff(DateInterval.Milliseconds, StartDate, EndDate);
      string ret = "";
      long sec = Milliseconds / 1000;
      long hour = sec / 3600;
      sec = sec % 3600;
      long minute = sec / 60;
      sec = sec % 60;
      Milliseconds = Milliseconds % 1000;
      ret = string.Format("{0}:{1}:{2}.{3}", hour, minute, sec, Milliseconds);
      if (!HideText) ret = GetResText("Public", "ExecTimes", "") + ret;
      return ret;
    }

    public bool CheckCardExists()
    {
      return CheckCardExists(true);
    }

    public bool CheckCardExists(bool ShowError)
    {
      if (!DeviceObject.objCPIC.CardIsExists())
      {
        if (ShowError) MessageBoxShow(GetResText("", "ReadCardError3", ""));
        return false;
      }
      return true;
    }

    public bool CheckCardExists(ref string CardData10, ref string CardDataH, ref string CardData8)
    {
      return CheckCardExists(ref CardData10, ref CardDataH, ref CardData8, true);
    }

    public bool CheckCardExists(ref string CardData10, ref string CardDataH, ref string CardData8, bool ShowError)
    {
      CardData10 = "";
      CardDataH = "";
      CardData8 = "";
      if (!DeviceObject.objCPIC.IsOnline())
      {
        if (ShowError) MessageBoxShow(GetResText("", "ReadCardError1", ""));
        return false;
      }
      if (!DeviceObject.objCPIC.GetCardData(ref CardData10, ref CardDataH, ref CardData8))
      {
        if (ShowError) MessageBoxShow(GetResText("", "ReadCardError3", ""));
        return false;
      }
      return true;
    }

    public bool CheckCardExists(ref string CardData10, ref string CardDataH, ref string CardData8, ref string ErrMsg)
    {
      CardData10 = "";
      CardDataH = "";
      CardData8 = "";
      ErrMsg = "";
      if (!DeviceObject.objCPIC.IsOnline())
      {
        ErrMsg = GetResText("", "ReadCardError1", "");
        return false;
      }
      if (!DeviceObject.objCPIC.GetCardData(ref CardData10, ref CardDataH, ref CardData8))
      {
        ErrMsg = GetResText("", "ReadCardError3", "");
        return false;
      }
      return true;
    }

    public string GetCardMsg(int cardRet)
    {
      string ret = GetResText("", "ReadCardError" + cardRet.ToString(), "");
      if (ret == "") ret = GetResText("", "ReadCardError3", "");
      return ret;
    }

    public bool ReadCardInfo(ref HSUNFK.TCardPubData pubData, ref HSUNFK.TCardSFData sfData)
    {
      if (SystemInfo.CardKey == "")
      {
        MessageBoxShow(GetResText("", "ErrorCardkey", ""));
        return false;
      }
      byte DataFlag = 0;
      HSUNFK.TCardSKData skData = new HSUNFK.TCardSKData();
      int cardRet = DeviceObject.objCPIC.ReadCardInfo(SystemInfo.IsLongEmpID, ref DataFlag, ref pubData,
        ref sfData, ref skData, 0);
      if (cardRet != 0)
      {
        MessageBoxShow(GetCardMsg(cardRet));
        return false;
      }
      if ((DataFlag != 1) && (DataFlag != 2) && (DataFlag != 3))
      {
        MessageBoxShow(GetResText("", "ErrorCardInfoChaos", ""));
        return false;
      }
      return true;
    }

    public bool ReadCardInfo(ref HSUNFK.TCardSFData sfData)
    {
      if (SystemInfo.CardKey == "")
      {
        MessageBoxShow(GetResText("", "ErrorCardkey", ""));
        return false;
      }
      byte DataFlag = 0;
      int cardRet = DeviceObject.objCPIC.ReadCardInfoSF(ref DataFlag, ref sfData);
      if (cardRet != 0)
      {
        MessageBoxShow(GetCardMsg(cardRet));
        return false;
      }
      if ((DataFlag != 1) && (DataFlag != 2) && (DataFlag != 3))
      {
        MessageBoxShow(GetResText("", "ErrorCardInfoChaos", ""));
        return false;
      }
      return true;
    }

    public bool ReadCardInfo(ref HSUNFK.TCardPubData pubData)
    {
      if (SystemInfo.CardKey == "")
      {
        MessageBoxShow(GetResText("", "ErrorCardkey", ""));
        return false;
      }
      int cardRet = DeviceObject.objCPIC.ReadCardInfoPub(SystemInfo.IsLongEmpID, ref pubData);
      if (cardRet != 0)
      {
        MessageBoxShow(GetCardMsg(cardRet));
        return false;
      }
      return true;
    }

    public bool ReadCardInfo(ref HSUNFK.TCardPubData pubData, ref string ErrorMsg)
    {
      ErrorMsg = "";
      if (SystemInfo.CardKey == "")
      {
        ErrorMsg = GetResText("", "ErrorCardkey", "");
        return false;
      }
      int cardRet = DeviceObject.objCPIC.ReadCardInfoPub(SystemInfo.IsLongEmpID, ref pubData);
      if (cardRet != 0)
      {
        ErrorMsg = GetCardMsg(cardRet);
        return false;
      }
      return true;
    }

    public bool ReadCardInfo(ref HSUNFK.TCardSKData skData)
    {
      int cardRet = DeviceObject.objCPIC.ReadCardSKInfo(ref skData);
      if (cardRet != 0)
      {
        MessageBoxShow(GetCardMsg(cardRet));
        return false;
      }
      return true;
    }

    public bool ReadCardInfo(ref HSUNFK.TCardSKData skData, ref string ErrorMsg)
    {
      ErrorMsg = "";
      int cardRet = DeviceObject.objCPIC.ReadCardSKInfo(ref skData);
      if (cardRet != 0)
      {
        ErrorMsg = GetCardMsg(cardRet);
        return false;
      }
      return true;
    }

    public int WriteCardInfo(HSUNFK.TCardPubData pubData, HSUNFK.TCardSFData sfData, HSUNFK.TCardSKData skData)
    {
      if (!SystemInfo.HasSK)
        return DeviceObject.objCPIC.WriteCardInfo(SystemInfo.IsLongEmpID, ref pubData, ref sfData, ref skData, 0);
      else
        return DeviceObject.objCPIC.WriteCardInfo(SystemInfo.IsLongEmpID, ref pubData, ref sfData, ref skData,
          SystemInfo.WaterFlag);
    }

    public int WriteCardInfo(HSUNFK.TCardPubData pubData)
    {
      return DeviceObject.objCPIC.WriteCardInfoPub(SystemInfo.IsLongEmpID, ref pubData);
    }

    public int WriteCardInfo(HSUNFK.TCardSFData sfData)
    {
      return DeviceObject.objCPIC.WriteCardInfoSF(ref sfData);
    }

    public int WriteCardInfo(HSUNFK.TCardSKData skData)
    {
      return DeviceObject.objCPIC.WriteCardSKInfo(ref skData);
    }

    public int ClearCardInfo()
    {
      return DeviceObject.objCPIC.ClearCardInfo(SystemInfo.WaterFlag);
    }

    public bool ShowSelectEmpList(string Title, string OtherCoin, ref DataTable selList)
    {
      frmPubSelectEmpList frm = new frmPubSelectEmpList(Title, OtherCoin);
      bool ret = frm.ShowDialog() == DialogResult.OK;
      if (ret) selList = frm.dtData;
      return ret;
    }

    public string GetResText(string Code, string ID, string Def)
    {
      string ret = "";
      try
      {
        ret = SystemInfo.res.GetResText(Code, ID, Def);
      }
      catch
      {
      }
      return ret;
    }

    public string GetResText(string Code, string ID, string Def, string[] Codes)
    {
      return SystemInfo.res.GetResText(Code, ID, Def, Codes);
    }

    public frmAppMain GetAppMainForm()
    {
      frmAppMain frm = null;
      for (int i = 0; i < Application.OpenForms.Count; i++)
      {
        if (Application.OpenForms[i].Name == "frmAppMain")
        {
          frm = (frmAppMain)Application.OpenForms[i];
          break;
        }
      }
      return frm;
    }

    public void InitCardInfo()
    {
      DeviceObject.objCPIC.InitCardKey(SystemInfo.CardKey, SystemInfo.DealersCode, SystemInfo.PubCardSector, SystemInfo.CustomersCode);
      DeviceObject.objCPIC.AllowCardWarn = SystemInfo.AllowCardWarn;
      DeviceObject.objKS.InitCard(SystemInfo.CardKey, SystemInfo.PubCardSector, SystemInfo.DealersCode, SystemInfo.CustomersCode,
        SystemInfo.IsDecimalProduct, SystemInfo.HasMobileFailLog);
      DeviceObject.objKS.CardTypeCount = SystemInfo.CardTypeCount;
    }

    public bool InputBox(string Title, string Prompt, ref string ResultText)
    {
      return InputBox(Title, Prompt, "", ref ResultText);
    }

    public bool InputBox(string Title, string Prompt, bool IsPass, ref string ResultText)
    {
      return InputBox(Title, Prompt, "", IsPass, ref ResultText);
    }

    public bool InputBox(string Title, string Prompt, string Def, ref string ResultText)
    {
      return InputBox(Title, Prompt, "", false, ref ResultText);
    }

    public bool InputBox(string Title, string Prompt, string Def, bool IsPass, ref string ResultText)
    {
      bool ret = false;
      ResultText = "";
      frmInputBox frm = new frmInputBox(Title, Prompt, Def);
      frm.EnterNumber = false;
      frm.IsPass = IsPass;
      if (frm.ShowDialog() == DialogResult.OK)
      {
        ret = true;
        ResultText = frm.ResultText;
      }
      return ret;
    }

    public bool InputBox(string Title, string Prompt, int MaxNumber, ref int ResultNumber)
    {
      return InputBox(Title, Prompt, 0, MaxNumber, ref ResultNumber);
    }

    public bool InputBox(string Title, string Prompt, int Def, int MaxNumber, ref int ResultNumber)
    {
      bool ret = false;
      ResultNumber = 0;
      frmInputBox frm = new frmInputBox(Title, Prompt, Def.ToString());
      frm.EnterNumber = true;
      frm.MaxNumber = MaxNumber;
      if (frm.ShowDialog() == DialogResult.OK)
      {
        ret = true;
        ResultNumber = frm.ResultNumber;
      }
      return ret;
    }

    public bool InputBox2(string Title, string Prompt1, string Prompt2, ref string ResultText1, ref string ResultText2)
    {
      return InputBox2(Title, Prompt1, Prompt2, "", "", ref ResultText1, ref ResultText2);
    }

    public bool InputBox2(string Title, string Prompt1, string Prompt2, string Def1, string Def2, ref string ResultText1, 
      ref string ResultText2)
    {
      bool ret = false;
      ResultText1 = "";
      ResultText2 = "";
      frmInputBox2 frm = new frmInputBox2(Title, Prompt1, Def1, Prompt2, Def2);
      frm.EnterNumber = false;
      if (frm.ShowDialog() == DialogResult.OK)
      {
        ret = true;
        ResultText1 = frm.ResultText1;
        ResultText2 = frm.ResultText2;
      }
      return ret;
    }

    public bool InputBox2(string Title, string Prompt1, string Prompt2, int MaxNumber1, int MaxNumber2, 
      ref int ResultNumber1, ref int ResultNumber2)
    {
      return InputBox2(Title, Prompt1, Prompt2, 0, 0, MaxNumber1, MaxNumber2, ref ResultNumber1, ref ResultNumber2);
    }

    public bool InputBox2(string Title, string Prompt1, string Prompt2, int Def1, int Def2, int MaxNumber1, 
      int MaxNumber2, ref int ResultNumber1, ref int ResultNumber2)
    {
      bool ret = false;
      ResultNumber1 = 0;
      ResultNumber2 = 0;
      frmInputBox2 frm = new frmInputBox2(Title, Prompt1, Def1.ToString(), Prompt2, Def2.ToString());
      frm.EnterNumber = true;
      frm.MaxNumber1 = MaxNumber1;
      frm.MaxNumber2 = MaxNumber2;
      if (frm.ShowDialog() == DialogResult.OK)
      {
        ret = true;
        ResultNumber1 = frm.ResultNumber1;
        ResultNumber2 = frm.ResultNumber2;
      }
      return ret;
    }

    public string DecToBin(int dec, int len)
    {
      string ret = Convert.ToString(dec, 2);
      while (ret.Length < len)
      {
        ret = "0" + ret;
      }
      ret = ret.Substring(ret.Length - len);
      return ret;
    }

    public string DecToBin(string dec, int len)
    {
      return DecToBin(Convert.ToInt32(dec), len);
    }

    public string GetMJReaderID(string MacSN, int ReaderID)
    {
      string ret = ReaderID.ToString() + "-1";
      if ((MacSN.Substring(0, 2) == "01") || (MacSN.Substring(0, 2) == "02") || (MacSN.Substring(0, 2) == "21") || (MacSN.Substring(0, 2) == "22"))
      {
        if (ReaderID == 1)
          ret = "1-1";
        else if (ReaderID == 2)
          ret = "1-2";
        else if (ReaderID == 3)
          ret = "2-1";
        else if (ReaderID == 4)
          ret = "2-2";
      }
      return ret;
    }

    [DllImport("winmm")]
    private static extern bool PlaySound(string szSound, IntPtr hMod, int flags);
    public void PlaySound(string FileName)
    {
      if (File.Exists(FileName)) PlaySound(FileName, IntPtr.Zero, 0x00020000 | 0x0001);
    }

    [DllImport("shell32")]
    private static extern bool ShellExecuteEx(ref SHELLEXECUTEINFO lpExecInfo);
    [StructLayout(LayoutKind.Sequential)]
    private struct SHELLEXECUTEINFO
    {
      public int cbSize;
      public uint fMask;
      public IntPtr hwnd;
      public string lpVerb;
      public string lpFile;
      public string lpParameters;
      public string lpDirectory;
      public int nShow;
      public IntPtr hInstApp;
      public IntPtr IDList;
      public string lpClass;
      public IntPtr hkeyClass;
      public uint dwHotKey;
      public IntPtr hIcon;
      public IntPtr hProcess;
    }
    [DllImport("Kernel32.dll ")]
    private static extern int WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern int CloseHandle(IntPtr hObject);
    public void ExpandFile(string fileName, string path)
    {
      try
      {
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        SHELLEXECUTEINFO info = new SHELLEXECUTEINFO();
        info.cbSize = Marshal.SizeOf(info);
        info.lpVerb = "open";
        info.lpFile = "expand.exe";
        info.lpDirectory = path;
        if (path.Substring(path.Length - 1, 1) == "\\") path = path.Substring(0, path.Length - 1);
        info.lpParameters = "-F:* \"" + fileName + "\" \"" + path + "\"";
        info.fMask = 67142464;
        ShellExecuteEx(ref info);
        if (info.hProcess != new IntPtr(0))
        {
          WaitForSingleObject(info.hProcess, 0xFFFFFFFF);
          CloseHandle(info.hProcess);
        }
      }
      catch (Exception E)
      {
        ShowErrorMsg(E);
      }
    }

    public bool ExecuteFile(string fileName, string path, string param)
    {
      bool ret = false;
      System.Diagnostics.Process proc = new System.Diagnostics.Process();
      try
      {
        proc.StartInfo.FileName = "cmd.exe";
        proc.StartInfo.WorkingDirectory = path;
        proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        proc.StartInfo.Verb = "open";
        proc.StartInfo.UseShellExecute = false;
        proc.StartInfo.CreateNoWindow = true;
        proc.StartInfo.RedirectStandardError = true;
        proc.StartInfo.RedirectStandardInput = true;
        proc.Start();
        string cmdLine = "\"" + fileName + "\" " + param + "\r\nExit";
        proc.StandardInput.WriteLine(cmdLine);
        proc.BeginErrorReadLine();
        proc.WaitForExit();
        ret = true;
      }
      catch (Exception E)
      {
        ShowErrorMsg(E);
      }
      finally
      {
        proc.Close();
        proc.Dispose();
      }
      return ret;
    }

    public uint RGBToOleColor(byte r, byte g, byte b)
    {
      return ((uint)b) * 256 * 256 + ((uint)g) * 256 + r;
    }

    public uint ColorToOleColor(System.Drawing.Color val)
    {
      return RGBToOleColor(val.R, val.G, val.B);
    }

    public bool ValueToBool(object value)
    {
      bool ret = (value.ToString() == "1") || (value.ToString().ToLower() == "true");
      return ret;
    }

    public bool CheckCardValidDate(DateTime dt, DateTime bt, DateTime et)
    {
      string msg = string.Format(GetResText("", "MsgCardValidDate", ""), bt, et);
      DateTime d1 = new DateTime(dt.Year, dt.Month, dt.Day);
      DateTime d2 = bt;
      DateTime d3 = et;
      if (d1 < d2)
      {
        MessageBoxShow(msg + "\r\n\r\n" + GetResText("", "MsgCardValidDateBegin", ""));
        return false;
      }
      if (d1 > d3)
      {
        MessageBoxShow(msg + "\r\n\r\n" + GetResText("", "MsgCardValidDateEnd", ""));
        return false;
      }
      return true;
    }

    public bool CheckUseDate(DateTime ServerDate, DateTime UseDate)
    {
      bool chk = SystemInfo.ini.ReadIni("Public", "CheckUseDate", false);
      if (chk && UseDate >= ServerDate)
      {
        MessageBoxShow(GetResText("Public", "MsgLastUseDateError", ""));
        return false;
      }
      return true;
    }

    public void ClearCardLimitInfo(DateTime dt, ref HSUNFK.TCardSFData sfData)
    {
      DateTime d1 = new DateTime(dt.Year, dt.Month, dt.Day);
      DateTime d2 = Convert.ToDateTime(sfData.UseDate);
      DateTime d3 = new DateTime(d2.Year, d2.Month, d2.Day);
      if (d1 != d3)
      {
        sfData.LimitMoney1 = "000000";
        sfData.LimitTimes1 = 0;
        sfData.LimitMoney2 = "000000";
        sfData.LimitTimes2 = 0;
        sfData.LimitMoney3 = "000000";
        sfData.LimitTimes3 = 0;
        sfData.LimitMoney4 = "000000";
        sfData.LimitTimes4 = 0;
      }
      if (d1.ToString(SystemInfo.YMFormatCard) != d3.ToString(SystemInfo.YMFormatCard))
      {
        sfData.LimitMoneyMonth = "000000";
        sfData.LimitTimesMonth = 0;
      }
    }

    public string GetObjFileName(string objName)
    {
      string ret = "";
      RegistryKey root = Registry.ClassesRoot;
      RegistryKey clsid = root.OpenSubKey(objName + "\\Clsid", false);
      if (clsid == null) return "";
      string v = clsid.GetValue("").ToString();
      clsid.Close();
      if (v != "")
      {
        clsid = root.OpenSubKey("CLSID\\" + v + "\\InprocServer32", false);
        ret = clsid.GetValue("").ToString();
      }
      return ret;
    }

    public string GetObjFilePath(string objName)
    {
      string ret = "";
      RegistryKey root = Registry.ClassesRoot;
      RegistryKey clsid = root.OpenSubKey(objName + "\\Clsid", false);
      if (clsid == null) return "";
      string v = clsid.GetValue("").ToString();
      clsid.Close();
      if (v != "")
      {
        clsid = root.OpenSubKey("CLSID\\" + v + "\\InprocServer32", false);
        ret = clsid.GetValue("").ToString();
        ret = GetFileNamePath(ret);
      }
      return ret;
    }

    public int ByteToInt(byte[] src)
    {
      int ret = 0;
      byte b = 0;
      for (int i = 0; i < 4; i++)
      {
        b = src[i];
        ret += (b & 0xff) << (i * 8);
      }
      return ret;
    }

    public byte[] IntToByte(int src)
    {
      byte[] ret = new byte[4];
      for (int i = 0; i < 4; i++)
      {
        ret[i] = (byte)(src >> i * 8 & 0xff);
      }
      return ret;
    }

    public string ByteToHex(byte b)
    {
      string ret = Convert.ToString(b, 16);
      while (ret.Length < 2) ret = "0" + ret;
      ret = ret.ToUpper();
      return ret;
    }

    public void CardBuzzer()
    {
      string CardData10 = "";
      string CardDataH = "";
      string CardData8 = "";
      if (!DeviceObject.objCPIC.Buzzer(1))
      {
        DeviceObject.objCPIC.GetCardData(ref CardData10, ref CardDataH, ref CardData8);
      }
    }

    [DllImport("kernel32.dll")]
    private static extern void CopyMemory(byte[] Destination, int[] Source, int Size);
    [DllImport("kernel32.dll")]
    private static extern void CopyMemory(int[] Destination, byte[] Source, int Size);
    public void MemoryCopy(byte[] Destination, int[] Source, int Size)
    {
      CopyMemory(Destination, Source, Size);
    }
    public void MemoryCopy(int[] Destination, byte[] Source, int Size)
    {
      CopyMemory(Destination, Source, Size);
    }

    public System.Globalization.CultureInfo InitLangName()
    {
      System.Globalization.CultureInfo UICulture = null;
      switch (Application.CurrentCulture.LCID)
      {
        case 0x804://简体中文
          UICulture = new System.Globalization.CultureInfo("zh-CN");
          SystemInfo.LangName = "CHS";
          break;
        case 0x404://繁体中文
        case 0x0c04:
        case 0x1004:
        case 0x1404:
          UICulture = new System.Globalization.CultureInfo("zh-TW");
          SystemInfo.LangName = "CHT";
          break;
        case 0x0411: //日语
          UICulture = new System.Globalization.CultureInfo("ja-JP");
          SystemInfo.LangName = "JPN";
          break;
        case 0x0412: //朝鲜语
          UICulture = new System.Globalization.CultureInfo("ko-KR");
          SystemInfo.LangName = "KOR";
          break;
        case 0x0c07://德语
        case 0x0407:
        case 0x1407:
        case 0x1007:
        case 0x0807:
          UICulture = new System.Globalization.CultureInfo("de-DE");
          SystemInfo.LangName = "DEU";
          break;
        case 0x0419: //俄语
          UICulture = new System.Globalization.CultureInfo("ru-RU");
          SystemInfo.LangName = "RUS";
          break;
        case 0x080c://法语
        case 0x040c:
        case 0x0c0c:
        case 0x140c:
        case 0x180c:
        case 0x100c:
          UICulture = new System.Globalization.CultureInfo("fr-FR");
          SystemInfo.LangName = "FRA";
          break;
        case 0x2c0a://西班牙语
        case 0x3c0a:
        case 0x180a:
        case 0x500a:
        case 0x400a:
        case 0x040a:
        case 0x1c0a:
        case 0x300a:
        case 0x240a:
        case 0x140a:
        case 0x0c0a:
        case 0x480a:
        case 0x280a:
        case 0x080a:
        case 0x4c0a:
        case 0x440a:
        case 0x100a:
        case 0x200a:
        case 0x380a:
        case 0x340a:
          UICulture = new System.Globalization.CultureInfo("es-ES");
          SystemInfo.LangName = "ESN";
          break;
        case 0x041c://阿尔巴尼亚语
          SystemInfo.LangName = "SQI";
          break;
        case 0x1401://阿拉伯语
        case 0x3801:
        case 0x2001:
        case 0x0c01:
        case 0x3c01:
        case 0x4001:
        case 0x3401:
        case 0x3001:
        case 0x1001:
        case 0x1801:
        case 0x0401:
        case 0x1c01:
        case 0x2801:
        case 0x2401:
        case 0x0801:
        case 0x2c01:
          UICulture = new System.Globalization.CultureInfo("ar-DZ");
          SystemInfo.LangName = "ARG";
          break;
        case 0x042c://阿塞拜疆语
        case 0x082c:
          UICulture = new System.Globalization.CultureInfo("az-AZ-Cyrl");
          SystemInfo.LangName = "AZE";
          break;
        case 0x0425: //爱沙尼亚语
          UICulture = new System.Globalization.CultureInfo("et-EE");
          SystemInfo.LangName = "ETI";
          break;
        case 0x042d://巴斯克语
          UICulture = new System.Globalization.CultureInfo("eu-ES");
          SystemInfo.LangName = "EUQ";
          break;
        case 0x0402: //保加利亚语
          UICulture = new System.Globalization.CultureInfo("bg-BG");
          SystemInfo.LangName = "BGR";
          break;
        case 0x0423: //比利时语
          UICulture = new System.Globalization.CultureInfo("nl-NL");
          SystemInfo.LangName = "BEL";
          break;
        case 0x040f: //冰岛语
          UICulture = new System.Globalization.CultureInfo("is-IS");
          SystemInfo.LangName = "ISL";
          break;
        case 0x0415: //波兰语
          UICulture = new System.Globalization.CultureInfo("pl-PL");
          SystemInfo.LangName = "PLK";
          break;
        case 0x0444: //鞑靼语
          UICulture = new System.Globalization.CultureInfo("tt-RU");
          SystemInfo.LangName = "TTT";
          break;
        case 0x0406: //丹麦语
          UICulture = new System.Globalization.CultureInfo("da-DK");
          SystemInfo.LangName = "DAN";
          break;
        case 0x0465: //第维埃语
          UICulture = new System.Globalization.CultureInfo("div-MV");
          SystemInfo.LangName = "DIV";
          break;
        case 0x0438: //法罗语
          UICulture = new System.Globalization.CultureInfo("fo-FO");
          SystemInfo.LangName = "FOS";
          break;
        case 0x0429: //波斯语
          UICulture = new System.Globalization.CultureInfo("fa-IR");
          SystemInfo.LangName = "FAR";
          break;
        case 0x044f: //梵语
          UICulture = new System.Globalization.CultureInfo("sa-IN");
          SystemInfo.LangName = "SAN";
          break;
        case 0x040b: //芬兰语
          UICulture = new System.Globalization.CultureInfo("fi-FI");
          SystemInfo.LangName = "FIN";
          break;
        case 0x0437: //格鲁吉亚语
          UICulture = new System.Globalization.CultureInfo("ka-GE");
          SystemInfo.LangName = "KAT";
          break;
        case 0x0447: //古吉拉特语
          UICulture = new System.Globalization.CultureInfo("gu-IN");
          SystemInfo.LangName = "GUJ";
          break;
        case 0x043f: //哈萨克语
          UICulture = new System.Globalization.CultureInfo("kk-KZ");
          SystemInfo.LangName = "KKZ";
          break;
        case 0x0813://荷兰语
        case 0x0413:
          UICulture = new System.Globalization.CultureInfo("nl-NL");
          SystemInfo.LangName = "NLD";
          break;
        case 0x0440: //吉尔吉斯语
          UICulture = new System.Globalization.CultureInfo("ky-KG");
          SystemInfo.LangName = "KYR";
          break;
        case 0x0456: //加里西亚语
          UICulture = new System.Globalization.CultureInfo("gl-ES");
          SystemInfo.LangName = "GLC";
          break;
        case 0x0403: //加泰隆语
          UICulture = new System.Globalization.CultureInfo("ca-ES");
          SystemInfo.LangName = "CAT";
          break;
        case 0x0405: //捷克语
          UICulture = new System.Globalization.CultureInfo("cs-CZ");
          SystemInfo.LangName = "CSY";
          break;
        case 0x044b: //卡纳拉语
          UICulture = new System.Globalization.CultureInfo("kn-IN");
          SystemInfo.LangName = "KAN";
          break;
        case 0x041a: //克罗地亚语
          UICulture = new System.Globalization.CultureInfo("hr-HR");
          SystemInfo.LangName = "HRV";
          break;
        case 0x0457: //贡根语
          UICulture = new System.Globalization.CultureInfo("kok-IN");
          SystemInfo.LangName = "KNK";
          break;
        case 0x0426: //拉脱维亚语
          UICulture = new System.Globalization.CultureInfo("lv-LV");
          SystemInfo.LangName = "LVI";
          break;
        case 0x0427: //立陶宛语
          UICulture = new System.Globalization.CultureInfo("lt-LT");
          SystemInfo.LangName = "LTH";
          break;
        case 0x0418: //罗马尼亚语
          UICulture = new System.Globalization.CultureInfo("ro-RO");
          SystemInfo.LangName = "ROM";
          break;
        case 0x044e: //马拉地语
          UICulture = new System.Globalization.CultureInfo("mr-IN");
          SystemInfo.LangName = "MAR";
          break;
        case 0x043e://马来语
        case 0x083e:
          UICulture = new System.Globalization.CultureInfo("ms-MY");
          SystemInfo.LangName = "MSL";
          break;
        case 0x042f: //马其顿语
          UICulture = new System.Globalization.CultureInfo("mk-MK");
          SystemInfo.LangName = "MKI";
          break;
        case 0x0450: //蒙古语
          UICulture = new System.Globalization.CultureInfo("mn-MN");
          SystemInfo.LangName = "MON";
          break;
        case 0x0436: //南非语
          UICulture = new System.Globalization.CultureInfo("af-ZA");
          SystemInfo.LangName = "AFK";
          break;
        case 0x0414://挪威语
        case 0x0814:
          UICulture = new System.Globalization.CultureInfo("nb-NO");
          SystemInfo.LangName = "NOR";
          break;
        case 0x0446: //旁遮普语
          UICulture = new System.Globalization.CultureInfo("pa-IN");
          SystemInfo.LangName = "PAN";
          break;
        case 0x0416://葡萄牙语
        case 0x0816:
          UICulture = new System.Globalization.CultureInfo("pt-PT");
          SystemInfo.LangName = "PTG";
          break;
        case 0x041d://瑞典语
        case 0x081d:
          UICulture = new System.Globalization.CultureInfo("sv-FI");
          SystemInfo.LangName = "SVE";
          break;
        case 0x081a://塞尔维亚
        case 0x0c1a:
          UICulture = new System.Globalization.CultureInfo("sr-SP-Cyrl");
          SystemInfo.LangName = "SRL";
          break;
        case 0x041b://斯洛伐克语
          UICulture = new System.Globalization.CultureInfo("sk-SK");
          SystemInfo.LangName = "SKY";
          break;
        case 0x0424: //斯洛文尼亚语
          UICulture = new System.Globalization.CultureInfo("sl-SI");
          SystemInfo.LangName = "SLV";
          break;
        case 0x0441: //斯瓦希里语
          UICulture = new System.Globalization.CultureInfo("sw-KE");
          SystemInfo.LangName = "SWK";
          break;
        case 0x044a: //泰卢固语
          UICulture = new System.Globalization.CultureInfo("te-IN");
          SystemInfo.LangName = "TEL";
          break;
        case 0x0449: //泰米尔语
          UICulture = new System.Globalization.CultureInfo("ta-IN");
          SystemInfo.LangName = "TAM";
          break;
        case 0x041e: //泰语
          UICulture = new System.Globalization.CultureInfo("th-TH");
          SystemInfo.LangName = "THA";
          break;
        case 0x041f: //土尔其语
          UICulture = new System.Globalization.CultureInfo("tr-TR");
          SystemInfo.LangName = "TRK";
          break;
        case 0x0420: //乌尔都语
          UICulture = new System.Globalization.CultureInfo("ur-PK");
          SystemInfo.LangName = "URD";
          break;
        case 0x0422://乌克兰语
          UICulture = new System.Globalization.CultureInfo("uk-UA");
          SystemInfo.LangName = "UKR";
          break;
        case 0x0443://乌兹别克语
        case 0x0843:
          UICulture = new System.Globalization.CultureInfo("uz-UZ-Cyrl");
          SystemInfo.LangName = "UZB";
          break;
        case 0x040d: //希伯来语
          UICulture = new System.Globalization.CultureInfo("he-IL");
          SystemInfo.LangName = "HEB";
          break;
        case 0x0408: //希腊语
          UICulture = new System.Globalization.CultureInfo("el-GR");
          SystemInfo.LangName = "ELL";
          break;
        case 0x040e: //匈牙利语
          UICulture = new System.Globalization.CultureInfo("hu-HU");
          SystemInfo.LangName = "HUN";
          break;
        case 0x045a: //叙利亚语
          UICulture = new System.Globalization.CultureInfo("syr-SY");
          SystemInfo.LangName = "SYR";
          break;
        case 0x042b: //亚美尼亚语
          UICulture = new System.Globalization.CultureInfo("hy-AM");
          SystemInfo.LangName = "HYE";
          break;
        case 0x0810://意大利语
        case 0x0410:
          UICulture = new System.Globalization.CultureInfo("it-IT");
          SystemInfo.LangName = "ITA";
          break;
        case 0x0439: //印地语
          UICulture = new System.Globalization.CultureInfo("hi-IN");
          SystemInfo.LangName = "HIN";
          break;
        case 0x0421://印度尼西亚语
          UICulture = new System.Globalization.CultureInfo("id-ID");
          SystemInfo.LangName = "IND";
          break;
        case 0x042a: //越南语
          UICulture = new System.Globalization.CultureInfo("vi-VN");
          SystemInfo.LangName = "VIT";
          break;
        default:
          UICulture = new System.Globalization.CultureInfo("en-US");
          SystemInfo.LangName = "ENG";
          break;
      }
      return UICulture;
    }
  }

  public class IniFile
  {
    private Base Pub = new Base();
    private string FileName;

    public IniFile(string IniFileName)
    {
      FileName = IniFileName;
    }
    [DllImport("kernel32", CharSet = CharSet.Auto)]
    private static extern bool GetPrivateProfileString(string section, string key, string def,
      StringBuilder retVal, int size, string fileName);
    public string ReadIni(string Section, string Key, string Def)
    {
      StringBuilder temp = new StringBuilder(1024);
      GetPrivateProfileString(Section, Key, "", temp, 1024, FileName);
      string ret = temp.ToString().Trim();
      if (ret == "") ret = Def;
      return ret;
    }

    public byte ReadIni(string Section, string Key, byte Def)
    {
      string ret = ReadIni(Section, Key, Def.ToString());
      if (!Pub.IsNumeric(ret)) ret = "0";
      return Convert.ToByte(ret);
    }

    public int ReadIni(string Section, string Key, int Def)
    {
      string ret = ReadIni(Section, Key, Def.ToString());
      if (!Pub.IsNumeric(ret)) ret = "0";
      return Convert.ToInt32(ret);
    }

    public bool ReadIni(string Section, string Key, bool Def)
    {
      byte ret = ReadIni(Section, Key, Convert.ToByte(Def));
      return ret == 1;
    }

    [DllImport("kernel32", CharSet = CharSet.Auto)]
    private static extern bool WritePrivateProfileString(string section, string key, string Val, string fileName);
    public void WriteIni(string Section, string Key, string Val)
    {
      WritePrivateProfileString(Section, Key, Val, FileName);
    }

    public void WriteIni(string Section, string Key, byte Val)
    {
      WriteIni(Section, Key, Val.ToString());
    }

    public void WriteIni(string Section, string Key, int Val)
    {
      WriteIni(Section, Key, Val.ToString());
    }

    public void WriteIni(string Section, string Key, bool Val)
    {
      WriteIni(Section, Key, Convert.ToByte(Val));
    }

    public void EraseSection(string Section)
    {
      WritePrivateProfileString(Section, null, null, FileName);
    }
  }

  public class LangRes
  {
    private static string AppDir;
    private static string LangName;
    private static IniFile LangIni;
    private static string LangFile;
    private static bool IsBig5 = false;

    public LangRes(string AppPath)
    {
      AppDir = AppPath;
      LangName = SystemInfo.LangName;
      LangFile = AppDir + "Lang\\" + LangName + ".lng";
      if (LangName == "CHT")
      {
        if (File.Exists(LangFile))
          IsBig5 = true;
        else if (File.Exists(AppDir + "Lang\\CHS.lng"))
        {
          LangFile = AppDir + "Lang\\CHS.lng";
        }
      }
      else if (LangName != "CHS")
      {
        if (!File.Exists(LangFile)) SystemInfo.LangName = "ENG";
        LangName = SystemInfo.LangName;
        LangFile = AppDir + "Lang\\" + LangName + ".lng";
      }
      LangIni = new IniFile(LangFile);
    }

    [DllImport("Kernel32", CharSet = CharSet.Auto)]
    private static extern Int32 MultiByteToWideChar(UInt32 codePage, UInt32 dwFlags,
      [In, MarshalAs(UnmanagedType.LPStr)] String lpMultiByteStr, Int32 cbMultiByte,
      [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpWideCharStr, Int32 cchWideChar);
    [DllImport("Kernel32.dll")]
    private static extern int WideCharToMultiByte(uint CodePage, uint dwFlags,
      [In, MarshalAs(UnmanagedType.LPWStr)]string lpWideCharStr, int cchWideChar,
      [Out, MarshalAs(UnmanagedType.LPStr)]StringBuilder lpMultiByteStr, int cbMultiByte,
      IntPtr lpDefaultChar, IntPtr lpUsedDefaultChar);
    [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern int LCMapString(int Locale, int dwMapFlags, string lpSrcStr, int cchSrc,
      [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpDestStr, int cchDest);
    public string GBtoBIG5(string src, bool IsFull)
    {
      string ret = "";
      int len = MultiByteToWideChar(936, 0, src, -1, null, 0);
      StringBuilder wideStr = new StringBuilder(len * 2 + 1);
      len = LCMapString(0x0804, 0x04000000, src, -1, wideStr, len * 2);
      if (IsFull)
      {
        StringBuilder ws = new StringBuilder(len + 1);
        MultiByteToWideChar(936, 0, wideStr.ToString(), -1, ws, len);
        len = WideCharToMultiByte(950, 0, ws.ToString(), -1, null, 0, IntPtr.Zero, IntPtr.Zero);
        ret = ws.ToString();
      }
      else
        ret = wideStr.ToString();
      return ret;
    }

    public string GBtoBIG5(string src)
    {
      return GBtoBIG5(src, false);
    }

    public string GetResText(string Code, string ID, string Def)
    {
      if (ID == null) ID = "";
      string ret = LangIni.ReadIni(Code, ID, "");
      Base pub = new Base();
      if (ret == "") ret = LangIni.ReadIni("Public", ID, "");
      if (ret == "") ret = LangIni.ReadIni("Main", ID, "");
      if ((ret == "") && ((pub.IsNumeric(Def) || (Def.Trim() == "-")))) ret = Def;
      ret = ret.Replace("#13#10", "\r\n");
      if ((LangName == "CHT") && !IsBig5) ret = GBtoBIG5(ret);
      return ret;
    }

    public string GetResText(string Code, string ID, string Def, string[] Codes)
    {
      string ret = GetResText(Code, ID, Def);
      if (ret == "")
      {
        for (int i = Codes.GetLowerBound(0); i <= Codes.GetUpperBound(0); i++)
        {
          ret = GetResText(Codes[i], ID, Def);
          if (ret != "") break;
        }
      }
      return ret;
    }
  }

  public class Database
  {
    private SqlConnection sqlConn = null;
    private OleDbConnection oleConn = null;
    private string ConnStr = "";
    private Base Pub = new Base();
    private CryptED Crypt = new CryptED();
    private int _DBType = 0;

    const int CommandTimeout = 36000;
    const int C_RegKey = 33990;
    const ushort con_Initial = 0xFFFF;
    ushort[] t16 = 
    {
      0x0000, 0x1021, 0x2042, 0x3063, 0x4084, 0x50A5, 0x60C6, 0x70E7, 0x8108, 0x9129, 0xA14A, 0xB16B, 0xC18C, 0xD1AD, 
      0xE1CE, 0xF1EF, 0x1231, 0x0210, 0x3273, 0x2252, 0x52B5, 0x4294, 0x72F7, 0x62D6, 0x9339, 0x8318, 0xB37B, 0xA35A, 
      0xD3BD, 0xC39C, 0xF3FF, 0xE3DE, 0x2462, 0x3443, 0x0420, 0x1401, 0x64E6, 0x74C7, 0x44A4, 0x5485, 0xA56A, 0xB54B, 
      0x8528, 0x9509, 0xE5EE, 0xF5CF, 0xC5AC, 0xD58D, 0x3653, 0x2672, 0x1611, 0x0630, 0x76D7, 0x66F6, 0x5695, 0x46B4, 
      0xB75B, 0xA77A, 0x9719, 0x8738, 0xF7DF, 0xE7FE, 0xD79D, 0xC7BC, 0x48C4, 0x58E5, 0x6886, 0x78A7, 0x0840, 0x1861, 
      0x2802, 0x3823, 0xC9CC, 0xD9ED, 0xE98E, 0xF9AF, 0x8948, 0x9969, 0xA90A, 0xB92B, 0x5AF5, 0x4AD4, 0x7AB7, 0x6A96, 
      0x1A71, 0x0A50, 0x3A33, 0x2A12, 0xDBFD, 0xCBDC, 0xFBBF, 0xEB9E, 0x9B79, 0x8B58, 0xBB3B, 0xAB1A, 0x6CA6, 0x7C87, 
      0x4CE4, 0x5CC5, 0x2C22, 0x3C03, 0x0C60, 0x1C41, 0xEDAE, 0xFD8F, 0xCDEC, 0xDDCD, 0xAD2A, 0xBD0B, 0x8D68, 0x9D49, 
      0x7E97, 0x6EB6, 0x5ED5, 0x4EF4, 0x3E13, 0x2E32, 0x1E51, 0x0E70, 0xFF9F, 0xEFBE, 0xDFDD, 0xCFFC, 0xBF1B, 0xAF3A, 
      0x9F59, 0x8F78, 0x9188, 0x81A9, 0xB1CA, 0xA1EB, 0xD10C, 0xC12D, 0xF14E, 0xE16F, 0x1080, 0x00A1, 0x30C2, 0x20E3, 
      0x5004, 0x4025, 0x7046, 0x6067, 0x83B9, 0x9398, 0xA3FB, 0xB3DA, 0xC33D, 0xD31C, 0xE37F, 0xF35E, 0x02B1, 0x1290, 
      0x22F3, 0x32D2, 0x4235, 0x5214, 0x6277, 0x7256, 0xB5EA, 0xA5CB, 0x95A8, 0x8589, 0xF56E, 0xE54F, 0xD52C, 0xC50D, 
      0x34E2, 0x24C3, 0x14A0, 0x0481, 0x7466, 0x6447, 0x5424, 0x4405, 0xA7DB, 0xB7FA, 0x8799, 0x97B8, 0xE75F, 0xF77E, 
      0xC71D, 0xD73C, 0x26D3, 0x36F2, 0x0691, 0x16B0, 0x6657, 0x7676, 0x4615, 0x5634, 0xD94C, 0xC96D, 0xF90E, 0xE92F, 
      0x99C8, 0x89E9, 0xB98A, 0xA9AB, 0x5844, 0x4865, 0x7806, 0x6827, 0x18C0, 0x08E1, 0x3882, 0x28A3, 0xCB7D, 0xDB5C, 
      0xEB3F, 0xFB1E, 0x8BF9, 0x9BD8, 0xABBB, 0xBB9A, 0x4A75, 0x5A54, 0x6A37, 0x7A16, 0x0AF1, 0x1AD0, 0x2AB3, 0x3A92, 
      0xFD2E, 0xED0F, 0xDD6C, 0xCD4D, 0xBDAA, 0xAD8B, 0x9DE8, 0x8DC9, 0x7C26, 0x6C07, 0x5C64, 0x4C45, 0x3CA2, 0x2C83, 
      0x1CE0, 0x0CC1, 0xEF1F, 0xFF3E, 0xCF5D, 0xDF7C, 0xAF9B, 0xBFBA, 0x8FD9, 0x9FF8, 0x6E17, 0x7E36, 0x4E55, 0x5E74, 
      0x2E93, 0x3EB2, 0x0ED1, 0x1EF0
    };
    private int Key0_int = 0;

    public Database(string ConnectionString)
    {
      ConnStr = ConnectionString;
      _DBType = SystemInfo.DBType;
    }

    public void Open()
    {
      Open(ConnStr);
    }

    public void Open(string ConnectionString)
    {
      ConnStr = ConnectionString;
      Open(_DBType, ConnStr);
    }

    public void Open(int DBType, string ConnectionString)
    {
      _DBType = DBType;
      ConnStr = ConnectionString;
      Close();
      switch (_DBType)
      {
        case 1:
        case 2:
          sqlConn = new SqlConnection(ConnStr);
          sqlConn.Open();
          break;
        case 255:
          oleConn = new OleDbConnection(ConnStr);
          oleConn.Open();
          break;
      }
    }

    public void SetConnStr(string ConnectionString)
    {
      ConnStr = ConnectionString;
    }

    public void Close()
    {
      if (sqlConn != null)
      {
        sqlConn.Close();
        sqlConn = null;
      }
      if (oleConn != null)
      {
        oleConn.Close();
        oleConn = null;
      }
    }

    public bool IsOpen
    {
      get
      {
        return ((sqlConn != null) && (sqlConn.State == ConnectionState.Open)) ||
          ((oleConn != null) && (oleConn.State == ConnectionState.Open));
      }
    }

    public int ExecSQL(string SQLQuery)
    {
      SQLQuery = SQLQuery.Trim();
      int ret = 0;
      if (!IsOpen) Open();
      switch (_DBType)
      {
        case 1:
        case 2:
          SqlCommand sqlCmd = new SqlCommand(SQLQuery, sqlConn);
          sqlCmd.CommandTimeout = CommandTimeout;
          ret = sqlCmd.ExecuteNonQuery();
          break;
        case 255:
          OleDbCommand oleCmd = new OleDbCommand(SQLQuery, oleConn);
          oleCmd.CommandTimeout = CommandTimeout;
          ret = oleCmd.ExecuteNonQuery();
          break;
      }
      return ret;
    }

    public int ExecSQL(List<string> SQLQuery)
    {
      int ret = 0;
      string sql = "";
      try
      {
        if (!IsOpen) Open();
        switch (_DBType)
        {
          case 1:
          case 2:
            SqlCommand sqlCmd;
            SqlTransaction sqlTran = sqlConn.BeginTransaction();
            try
            {
              for (int i = 0; i < SQLQuery.Count; i++)
              {
                sql = SQLQuery[i].Trim();
                if (sql == "") continue;
                sqlCmd = new SqlCommand(sql, sqlConn);
                sqlCmd.CommandTimeout = CommandTimeout;
                sqlCmd.Transaction = sqlTran;
                sqlCmd.ExecuteNonQuery();
              }
              sqlTran.Commit();
            }
            catch (Exception E)
            {
              ret = 1;
              Pub.ShowErrorMsg(E, sql);
              sqlTran.Rollback();
            }
            break;
          case 255:
            OleDbCommand oleCmd;
            OleDbTransaction oleTran = oleConn.BeginTransaction();
            try
            {
              for (int i = 0; i < SQLQuery.Count; i++)
              {
                sql = SQLQuery[i].Trim();
                if (sql == "") continue;
                oleCmd = new OleDbCommand(sql, oleConn);
                oleCmd.CommandTimeout = CommandTimeout;
                oleCmd.Transaction = oleTran;
                oleCmd.ExecuteNonQuery();
              }
              oleTran.Commit();
            }
            catch (Exception E)
            {
              ret = 1;
              Pub.ShowErrorMsg(E, sql);
              oleTran.Rollback();
            }
            break;
        }
      }
      catch (Exception E)
      {
        ret = 1;
        Pub.ShowErrorMsg(E);
      }
      return ret;
    }

    public int ExecSQL(string SQLQuery, bool HideError)
    {
      int ret = 0;
      if (HideError)
      {
        try
        {
          ret = ExecSQL(SQLQuery);
        }
        catch
        {
        }
      }
      else
      {
        ret = ExecSQL(SQLQuery);
      }
      return ret;
    }

    public string ExecSQLMsg(string SQLQuery)
    {
      string ret = "";
      DataTableReader dr = GetDataReader(SQLQuery);
      if (dr.Read()) ret = dr[0].ToString();
      dr.Close();
      return ret.Trim();
    }

    public DataTableReader GetDataReader(string SQLQuery)
    {
      DataSet ds = GetDataSet(SQLQuery);
      return ds.CreateDataReader();
    }

    public DataSet GetDataSet(string SQLQuery)
    {
      DataSet ds = new DataSet();
      if (SQLQuery == "")
      {
        ds = null;
      }
      else
      {
        if (!IsOpen)
        {
          if (ConnStr == "")
            Open(SystemInfo.ConnStr);
          else
            Open();
        }
        switch (_DBType)
        {
          case 1:
          case 2:
            SqlDataAdapter sqlDA = new SqlDataAdapter(SQLQuery, sqlConn);
            if (sqlDA.SelectCommand != null) sqlDA.SelectCommand.CommandTimeout = CommandTimeout;
            if (sqlDA.DeleteCommand != null) sqlDA.DeleteCommand.CommandTimeout = CommandTimeout;
            if (sqlDA.UpdateCommand != null) sqlDA.UpdateCommand.CommandTimeout = CommandTimeout;
            sqlDA.Fill(ds, "DataSource");
            sqlDA.Dispose();
            sqlDA = null;
            break;
          case 255:
            OleDbDataAdapter oleDA = new OleDbDataAdapter(SQLQuery, oleConn);
            if (oleDA.SelectCommand != null) oleDA.SelectCommand.CommandTimeout = CommandTimeout;
            if (oleDA.DeleteCommand != null) oleDA.DeleteCommand.CommandTimeout = CommandTimeout;
            if (oleDA.UpdateCommand != null) oleDA.UpdateCommand.CommandTimeout = CommandTimeout;
            oleDA.Fill(ds, "DataSource");
            oleDA.Dispose();
            oleDA = null;
            break;
        }
      }
      return ds;
    }

    public DataTable GetDataTable(string SQLQuery)
    {
      DataTable dt = new DataTable();
      if (SQLQuery == "")
      {
        dt = null;
      }
      else
      {
        if (!IsOpen) Open();
        switch (_DBType)
        {
          case 1:
          case 2:
            SqlDataAdapter sqlDA = new SqlDataAdapter(SQLQuery, sqlConn);
            if (sqlDA.SelectCommand != null) sqlDA.SelectCommand.CommandTimeout = CommandTimeout;
            if (sqlDA.DeleteCommand != null) sqlDA.DeleteCommand.CommandTimeout = CommandTimeout;
            if (sqlDA.UpdateCommand != null) sqlDA.UpdateCommand.CommandTimeout = CommandTimeout;
            sqlDA.Fill(dt);
            sqlDA.Dispose();
            sqlDA = null;
            break;
          case 255:
            OleDbDataAdapter oleDA = new OleDbDataAdapter(SQLQuery, oleConn);
            if (oleDA.SelectCommand != null) oleDA.SelectCommand.CommandTimeout = CommandTimeout;
            if (oleDA.DeleteCommand != null) oleDA.DeleteCommand.CommandTimeout = CommandTimeout;
            if (oleDA.UpdateCommand != null) oleDA.UpdateCommand.CommandTimeout = CommandTimeout;
            oleDA.Fill(dt);
            oleDA.Dispose();
            oleDA = null;
            break;
        }
      }
      return dt;
    }

    public DataTable GetDataTableList()
    {
      DataTable dt = new DataTable();
      if (!IsOpen) Open();
      switch (_DBType)
      {
        case 1:
        case 2:
          dt = sqlConn.GetSchema("Tables");
          break;
        case 255:
          dt = oleConn.GetSchema("Tables");
          break;
      }
      return dt;
    }

    public string AttachDB(string Path, string DBName)
    {
      string ret = "";
      try
      {
        switch (_DBType)
        {
          case 1:
          case 2:
            ExecSQL("EXEC sp_attach_db '" + DBName + "','" + Path + DBName + ".mdf','" + Path + DBName + ".ldf'");
            break;
        }
      }
      catch (Exception E)
      {
        ret = E.Source + "\r\n\r\n" + E.Message;
      }
      return ret;
    }

    public bool CompactDatabase()
    {
      bool ret = false;
      DataTableReader dr = null;
      try
      {
        switch (_DBType)
        {
          case 1:
          case 2:
            dr = GetDataReader("SELECT * FROM sysfiles");
            while (dr.Read())
            {
              ExecSQL("DBCC SHRINKFILE('" + dr["name"].ToString().Trim() + "')");
            }
            ret = true;
            break;
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
      return ret;
    }

    public bool CreateDatabase(string Path, string DBName)
    {
      bool ret = false;
      string sql;
      try
      {
        switch (_DBType)
        {
          case 1:
          case 2:
            sql = "CREATE DATABASE [" + DBName + "] ON(NAME='" + DBName + "_Data', FILENAME='" + Path +
              DBName + ".mdf') LOG ON(NAME='" + DBName + "_Log',FILENAME='" + Path + DBName + ".ldf')";
            ExecSQL(sql);
            ret = true;
            break;
        }
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E);
      }
      return ret;
    }

    public bool DeleteDatabase(string DBName, bool HideError)
    {
      bool ret = false;
      DataTableReader dr = null;
      try
      {
        switch (_DBType)
        {
          case 1:
          case 2:
            dr = GetDataReader("SELECT spid FROM master..sysprocesses WHERE dbid=db_id('" + DBName + "')");
            if (dr.Read()) ExecSQL("KILL " + dr[0].ToString().Trim());
            ExecSQL("DROP DATABASE [" + DBName + "]");
            ret = true;
            break;
        }
      }
      catch (Exception E)
      {
        if (!HideError) Pub.ShowErrorMsg(E);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      return ret;
    }

    public bool BackupDatabase(string DBName, string FileName)
    {
      bool ret = false;
      string tmp = "";
      try
      {
        switch (_DBType)
        {
          case 1:
          case 2:
            tmp = "BACKUP DATABASE [" + DBName + "] TO DISK='" + FileName + "' WITH INIT";
            ExecSQL(tmp);
            tmp = "UPDATE Hs_Account SET BackupDay=getdate() WHERE DBName='" + DBName + "'";
            ExecSQL(tmp);
            ret = true;
            break;
        }
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E);
      }
      return ret;
    }

    public bool RestoreDatabase(string DBName, string FileName)
    {
      bool ret = false;
      DataTableReader dr = null;
      string tmp;
      string[] s;
      string DataFile = "";
      string LogFile = "";
      string InfoDataFile = "";
      string InfoLogFile = "";
      try
      {
        switch (_DBType)
        {
          case 1:
          case 2:
            dr = GetDataReader("SELECT filename FROM [" + DBName + "]..sysfiles");
            dr.Read();
            tmp = dr[0].ToString().Trim();
            s = tmp.Split('.');
            if (s[s.Length - 1].ToLower() == "mdf")
              DataFile = tmp;
            else
              LogFile = tmp;
            dr.Read();
            tmp = dr[0].ToString().Trim();
            dr.Close();
            s = tmp.Split('.');
            if (s[s.Length - 1].ToLower() == "mdf")
              DataFile = tmp;
            else
              LogFile = tmp;
            dr = GetDataReader("RESTORE FILELISTONLY FROM DISK='" + FileName + "'");
            dr.Read();
            tmp = dr["Type"].ToString().Trim().ToLower();
            if (tmp == "d")
              InfoDataFile = dr[0].ToString().Trim();
            else
              InfoLogFile = dr[0].ToString().Trim();
            dr.Read();
            tmp = dr["Type"].ToString().Trim().ToLower();
            if (tmp == "d")
              InfoDataFile = dr[0].ToString().Trim();
            else
              InfoLogFile = dr[0].ToString().Trim();
            dr.Close();
            dr = GetDataReader("SELECT spid FROM master..sysprocesses WHERE dbid=db_id('" + DBName + "')");
            if (dr.Read()) ExecSQL("KILL " + dr[0].ToString().Trim());
            dr.Close();
            tmp = "RESTORE DATABASE [" + DBName + "] FROM DISK='" + FileName + "' WITH REPLACE, MOVE '" +
              InfoDataFile + "' TO '" + DataFile + "', MOVE '" + InfoLogFile + "' TO '" + LogFile + "'";
            ExecSQL(tmp);
            ret = true;
            break;
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
      return ret;
    }

    public bool UpdateScript(string FileName)
    {
      bool ret = false;
      StreamReader reader = null;
      string line = "";
      string sql = "";
      try
      {
        reader = new StreamReader(FileName, Encoding.Default);
        while (!reader.EndOfStream)
        {
          line = reader.ReadLine();
          if (line.ToLower() == "go")
          {
            ExecSQL(sql);
            sql = "";
          }
          else
          {
            sql = sql + line + "\r\n";
          }
        }
        ret = true;
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E, sql);
      }
      finally
      {
        if (reader != null) reader.Close();
      }
      return ret;
    }

    public bool UpdateTextData(string sql, string txtField, string Data)
    {
      bool ret = false;
      try
      {
        if (!IsOpen) Open();
        switch (_DBType)
        {
          case 1:
          case 2:
            SqlCommand sqlCmd = new SqlCommand(sql, sqlConn);
            sqlCmd.CommandTimeout = CommandTimeout;
            SqlParameter sqlParam = new SqlParameter("@" + txtField, SqlDbType.Text);
            sqlParam.Value = Data;
            sqlCmd.Parameters.Add(sqlParam);
            ret = sqlCmd.ExecuteNonQuery() > 0;
            break;
        }
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E);
      }
      return ret;
    }

    public bool UpdateByteData(string sql, string picField, byte[] Data)
    {
      bool ret = false;
      try
      {
        if (!IsOpen) Open();
        switch (_DBType)
        {
          case 1:
          case 2:
            SqlCommand sqlCmd = new SqlCommand(sql, sqlConn);
            sqlCmd.CommandTimeout = CommandTimeout;
            SqlParameter sqlParam = new SqlParameter("@" + picField, SqlDbType.Image);
            sqlParam.Value = Data;
            sqlCmd.Parameters.Add(sqlParam);
            ret = sqlCmd.ExecuteNonQuery() > 0;
            break;
        }
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E);
      }
      return ret;
    }

    public string GetDatabasePath()
    {
      string ret = "";
      string tmp = DBServerInfo.ServerName.ToLower();
      switch (_DBType)
      {
        case 1:
        case 2:
          const string loc = "(local)";
          if ((tmp == "") || (tmp == ".") || (tmp == loc) || tmp.IndexOf(loc) >= 0 ||
            tmp.IndexOf(SystemInfo.ComputerName.ToLower()) >= 0 || _DBType == 2)
          {
            ret = SystemInfo.AppPath + "Database\\";
          }
          else
          {
            DataTableReader dr = null;
            try
            {
              dr = GetDataReader("SELECT filename FROM master..sysfiles");
              if (dr.Read())
              {
                ret = dr["filename"].ToString().Trim();
                ret = Pub.GetFileNamePath(ret);
              }
            }
            finally
            {
              if (dr != null) dr.Close();
              dr = null;
            }
          }
          break;
      }
      return ret;
    }

    public bool DBFileExists(string FileName)
    {
      bool ret = false;
      DataTableReader dr = null;
      try
      {
        switch (_DBType)
        {
          case 1:
          case 2:
            dr = GetDataReader("EXEC master..xp_fileexist '" + FileName + "'");
            if (dr.Read()) ret = (dr[0].ToString() == "1");
            break;
        }
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      return ret;
    }

    public bool DBPathExists(string Path)
    {
      bool ret = false;
      DataTableReader dr = null;
      try
      {
        switch (_DBType)
        {
          case 1:
          case 2:
            dr = GetDataReader("EXEC master..xp_fileexist '" + Path + "'");
            if (dr.Read()) ret = (dr[0].ToString() == "1");
            break;
        }
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      return ret;
    }

    public bool MaintenancePlan(string DBName, string Path, string Time, string MsgMaintenancePlan,
      string MsgMaintenanceBack)
    {
      bool ret = false;
      string sql = "";
      try
      {
        switch (_DBType)
        {
          case 1:
          case 2:
            if (Path.Substring(Path.Length - 1, 1) == "\\") Path = Path.Substring(0, Path.Length - 1);
            sql = "DECLARE @DBName sysname\r\n";
            sql = sql + "DECLARE @PlanID uniqueidentifier,@JobID uniqueidentifier, @StepID int, @iResult int\r\n";
            sql = sql + "DECLARE @PlanName varchar(128)\r\n";
            sql = sql + "DECLARE @JobID1 binary(16), @JobID2 binary(16)\r\n";
            sql = sql + "DECLARE @JobName sysname, @JobCommand nvarchar(3200)\r\n";
            sql = sql + "SET @DBName='" + DBName + "'";
            sql = sql + "SET @PlanName=@DBName+'" + MsgMaintenancePlan + "'\r\n";
            //删除计划
            sql = sql + "IF EXISTS(SELECT * FROM sysdbmaintplan_databases WHERE database_name=@DBName)\r\n";
            sql = sql + "BEGIN\r\n";
            sql = sql + "  SELECT @PlanID=plan_id FROM sysdbmaintplan_databases WHERE database_name=@DBName\r\n";
            sql = sql + "  IF EXISTS(SELECT * FROM sysdbmaintplan_jobs WHERE plan_id=@PlanID)\r\n";
            sql = sql + "  BEGIN\r\n";
            sql = sql + "    SELECT @JobID=job_id FROM sysdbmaintplan_jobs WHERE plan_id=@PlanID\r\n";
            sql = sql + "    SELECT @JobName=name FROM sysjobschedules WHERE job_id=@JobID\r\n";
            sql = sql + "    SELECT @StepID=step_id FROM sysjobsteps WHERE job_id=@JobID\r\n";
            sql = sql + "    EXEC sp_delete_jobstep @JobID,@step_id=@StepID\r\n";
            sql = sql + "    SELECT @StepID=step_id FROM sysjobsteps WHERE job_id=@JobID\r\n";
            sql = sql + "    EXEC sp_delete_jobstep @JobID,@step_id=@StepID\r\n";
            sql = sql + "    EXEC sp_delete_jobschedule @JobID,@name=@JobName\r\n";
            sql = sql + "    EXEC sp_delete_job @JobID\r\n";
            sql = sql + "  END\r\n";
            sql = sql + "  EXEC sp_delete_maintenance_plan_db @PlanID,@DBName\r\n";
            sql = sql + "  EXEC sp_delete_maintenance_plan @PlanID\r\n";
            sql = sql + "END\r\n";
            //建立维护计划
            sql = sql + "EXECUTE @iResult=sp_add_maintenance_plan @PlanName, @PlanID OUTPUT\r\n";
            sql = sql + "IF (@@ERROR<>0 OR @iResult<>0)\r\n";
            sql = sql + "BEGIN\r\n";
            sql = sql + "  SELECT 1 AS Error\r\n";
            sql = sql + "  RETURN\r\n";
            sql = sql + "END\r\n";
            //将数据库关联到维护计划
            sql = sql + "EXECUTE @iResult=sp_add_maintenance_plan_db @PlanID, @DBName\r\n";
            sql = sql + "IF (@@ERROR<>0 OR @iResult<>0)\r\n";
            sql = sql + "BEGIN\r\n";
            sql = sql + "  SELECT 2 AS Error\r\n";
            sql = sql + "  RETURN\r\n";
            sql = sql + "END\r\n";
            //建立完全备份作业
            sql = sql + "SET @JobName=@PlanName+'" + MsgMaintenanceBack + "'\r\n";
            sql = sql + "SET @JobCommand='EXECUTE master.dbo.xp_sqlmaint N''-PlanID '+CONVERT(varchar(40), @PlanID)+' " +
                "-VrfyBackup -BkUpMedia DISK -BkUpDB \"" + Path + "\" -BkExt \"BAK\"'''\r\n";
            //添加作业
            sql = sql + "EXECUTE @iResult=sp_add_job @job_id=@JobID1 OUTPUT,\r\n";
            sql = sql + "  @job_name = @JobName,\r\n";
            sql = sql + "  @owner_login_name = 'sa',\r\n";
            sql = sql + "  @description = 'No description available.',\r\n";
            sql = sql + "  @category_name = NULL,\r\n";
            sql = sql + "  @enabled = 1,\r\n";
            sql = sql + "  @notify_level_email = 0,\r\n";
            sql = sql + "  @notify_level_page = 0,\r\n";
            sql = sql + "  @notify_level_netsend = 0,\r\n";
            sql = sql + "  @notify_level_eventlog = 2,\r\n";
            sql = sql + "  @delete_level = 0\r\n";
            sql = sql + "IF (@@ERROR<>0 OR @iResult<>0)\r\n";
            sql = sql + "BEGIN\r\n";
            sql = sql + "  SELECT 3 AS Error\r\n";
            sql = sql + "  RETURN\r\n";
            sql = sql + "END\r\n";
            //添加作业步骤
            sql = sql + "EXECUTE @iResult = sp_add_jobstep @job_id = @JobID1,\r\n";
            sql = sql + "  @step_id = 1,\r\n";
            sql = sql + "  @step_name = 'step 1',\r\n";
            sql = sql + "  @command = @JobCommand,\r\n";
            sql = sql + "  @database_name = 'master',\r\n";
            sql = sql + "  @server = '',\r\n";
            sql = sql + "  @database_user_name = '',\r\n";
            sql = sql + "  @subsystem = 'TSQL',\r\n";
            sql = sql + "  @cmdexec_success_code = 0,\r\n";
            sql = sql + "  @flags = 4,\r\n";
            sql = sql + "  @retry_attempts = 0,\r\n";
            sql = sql + "  @retry_interval = 0,\r\n";
            sql = sql + "  @output_file_name = '',\r\n";
            sql = sql + "  @on_success_step_id = 0,\r\n";
            sql = sql + "  @on_success_action = 1,\r\n";
            sql = sql + "  @on_fail_step_id = 0,\r\n";
            sql = sql + "  @on_fail_action = 2\r\n";
            sql = sql + "IF (@@ERROR<>0 OR @iResult<>0)\r\n";
            sql = sql + "BEGIN\r\n";
            sql = sql + "  SELECT 4 AS Error\r\n";
            sql = sql + "  RETURN\r\n";
            sql = sql + "END\r\n";
            sql = sql + "SET @JobCommand='UPDATE master..Hs_Account SET BackupDay=getdate() WHERE DBName='''+@DBName+''''\r\n";
            sql = sql + "EXECUTE @iResult = sp_add_jobstep @job_id = @JobID1,\r\n";
            sql = sql + "  @step_id = 2,\r\n";
            sql = sql + "  @step_name = 'step 2',\r\n";
            sql = sql + "  @command = @JobCommand,\r\n";
            sql = sql + "  @database_name = 'master',\r\n";
            sql = sql + "  @server = '',\r\n";
            sql = sql + "  @database_user_name = '',\r\n";
            sql = sql + "  @subsystem = 'TSQL',\r\n";
            sql = sql + "  @cmdexec_success_code = 0,\r\n";
            sql = sql + "  @flags = 4,\r\n";
            sql = sql + "  @retry_attempts = 0,\r\n";
            sql = sql + "  @retry_interval = 0,\r\n";
            sql = sql + "  @output_file_name = '',\r\n";
            sql = sql + "  @on_success_step_id = 0,\r\n";
            sql = sql + "  @on_success_action = 1,\r\n";
            sql = sql + "  @on_fail_step_id = 0,\r\n";
            sql = sql + "  @on_fail_action = 2\r\n";
            sql = sql + "IF (@@ERROR<>0 OR @iResult<>0)\r\n";
            sql = sql + "BEGIN\r\n";
            sql = sql + "  SELECT 4 AS Error\r\n";
            sql = sql + "  RETURN\r\n";
            sql = sql + "END\r\n";
            sql = sql + "EXECUTE @iResult = sp_update_job @job_id = @JobID1, @start_step_id = 1\r\n";
            sql = sql + "IF (@@ERROR<>0 OR @iResult<>0)\r\n";
            sql = sql + "BEGIN\r\n";
            sql = sql + "  SELECT 4 AS Error\r\n";
            sql = sql + "  RETURN\r\n";
            sql = sql + "END\r\n";
            //添加作业调度
            sql = sql + "EXECUTE @iResult = sp_add_jobschedule @job_id = @JobID1,\r\n";
            sql = sql + "@name = 'jobschedule 1',\r\n";
            sql = sql + "@enabled = 1, @freq_type = 4,\r\n";
            const string jobDF = "yyyyMMdd";
            const string jobTF = "HHmmss";
            sql = sql + "@active_start_date = " + DateTime.Now.ToString(jobDF) + ",\r\n";
            sql = sql + "@active_start_time = " + Convert.ToDateTime(Time).ToString(jobTF) +
              ", @freq_interval = 1,\r\n";
            sql = sql + "@freq_subday_type = 1, @freq_subday_interval = 0,\r\n";
            sql = sql + "@freq_relative_interval = 0, @freq_recurrence_factor = 0,\r\n";
            sql = sql + "@active_end_date = 99991231, @active_end_time = 235959\r\n";
            sql = sql + "IF (@@ERROR<>0 OR @iResult<>0)\r\n";
            sql = sql + "BEGIN\r\n";
            sql = sql + "  SELECT 5 AS Error\r\n";
            sql = sql + "  RETURN\r\n";
            sql = sql + "END\r\n";
            //添加目标服务器
            sql = sql + "EXECUTE @iResult = sp_add_jobserver @job_id = @JobID1, @server_name = '" +
              DBServerInfo.ServerName + "'\r\n";
            sql = sql + "IF (@@ERROR<>0 OR @iResult<>0)\r\n";
            sql = sql + "BEGIN\r\n";
            sql = sql + "  SELECT 6 AS Error\r\n";
            sql = sql + "  RETURN\r\n";
            sql = sql + "END\r\n";
            //把作业关联到维护计划
            sql = sql + "EXECUTE @iResult = sp_add_maintenance_plan_job @PlanID, @JobID1\r\n";
            sql = sql + "IF (@@ERROR<>0 OR @iResult<>0)\r\n";
            sql = sql + "BEGIN\r\n";
            sql = sql + "  SELECT 7 AS Error\r\n";
            sql = sql + "  RETURN\r\n";
            sql = sql + "END\r\n";
            sql = sql + "SELECT 0 AS Error\r\n";
            ExecSQL(sql);
            ret = true;
            break;
        }
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E, sql);
      }
      return ret;
    }

    public string ReadConfig(string ID, string KeyWord, string Def)
    {
      string ret = Def;
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "112", ID, KeyWord }));
        if (dr.Read()) ret = dr[0].ToString();
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
      return ret;
    }

    public string ReadConfig(string ID, string KeyWord)
    {
      return ReadConfig(ID, KeyWord, "");
    }

    public bool ReadConfig(string ID, string KeyWord, bool Def)
    {
      string ret = ReadConfig(ID, KeyWord, Convert.ToByte(Def).ToString());
      if (Pub.IsNumeric(ret))
        return Convert.ToByte(ret) == 1;
      else
        return false;
    }

    public byte ReadConfig(string ID, string KeyWord, byte Def)
    {
      string ret = ReadConfig(ID, KeyWord, Def.ToString());
      if (Pub.IsNumeric(ret))
        return Convert.ToByte(ret);
      else
        return 0;
    }

    public int ReadConfig(string ID, string KeyWord, int Def)
    {
      string ret = ReadConfig(ID, KeyWord, Def.ToString());
      if (Pub.IsNumeric(ret))
        return Convert.ToInt32(ret);
      else
        return 0;
    }

    public bool WriteConfig(string ID, string KeyWord, string Value, string title, string oprt)
    {
      bool ret = false;
      DataTableReader dr = null;
      string sql = "";
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "112", ID, KeyWord }));
        if (dr.Read())
          sql = Pub.GetSQL(DBCode.DB_000001, new string[] { "114", ID, KeyWord, Value });
        else
          sql = Pub.GetSQL(DBCode.DB_000001, new string[] { "113", ID, KeyWord, Value });
        ExecSQL(sql);
        ret = true;
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
      if ((ret) && (title != ""))
      {
        WriteSYLog(title, oprt, sql);
      }
      return ret;
    }

    public bool WriteConfig(string ID, string KeyWord, string Value)
    {
      return WriteConfig(ID, KeyWord, Value, "", "");
    }

    public bool WriteConfig(string ID, string KeyWord, byte Value, string title, string oprt)
    {
      return WriteConfig(ID, KeyWord, Value.ToString(), title, oprt);
    }

    public bool WriteConfig(string ID, string KeyWord, byte Value)
    {
      return WriteConfig(ID, KeyWord, Value, "", "");
    }

    public bool WriteConfig(string ID, string KeyWord, int Value, string title, string oprt)
    {
      return WriteConfig(ID, KeyWord, Value.ToString(), title, oprt);
    }

    public bool WriteConfig(string ID, string KeyWord, int Value)
    {
      return WriteConfig(ID, KeyWord, Value, "", "");
    }

    public bool WriteConfig(string ID, string KeyWord, bool Value, string title, string oprt)
    {
      return WriteConfig(ID, KeyWord, Convert.ToByte(Value), title, oprt);
    }

    public bool WriteConfig(string ID, string KeyWord, bool Value)
    {
      return WriteConfig(ID, KeyWord, Value, "", "");
    }

    public bool DeleteConfig(string ID, string KeyWord)
    {
      bool ret = false;
      try
      {
        ExecSQL(Pub.GetSQL(DBCode.DB_000001, new string[] { "115", ID, KeyWord }));
        ret = true;
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E);
      }
      return ret;
    }

    public int GetFaCardCount()
    {
      int ret = 0;
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "116" }));
        if (dr.Read()) ret = Convert.ToInt32(dr[0]);
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
      return ret;
    }

    public int GetEmpCount()
    {
      int ret = 0;
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "117" }));
        if (dr.Read()) ret = Convert.ToInt32(dr[0]);
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
      return ret;
    }

    public int GetEmpFingerCount()
    {
      int ret = 0;
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "1001" }));
        if (dr.Read()) ret = Convert.ToInt32(dr[0]);
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
      return ret;
    }

    public bool GetServerDate(ref DateTime ServerDate)
    {
      ServerDate = new DateTime();
      bool ret = false;
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "201" }));
        if (dr.Read())
        {
          ServerDate = Convert.ToDateTime(dr[0]);
          ret = true;
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
      return ret;
    }

    public bool GetServerDate(string title, ref DateTime ServerDate)
    {
      ServerDate = new DateTime();
      bool ret = false;
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "201" }));
        if (dr.Read())
        {
          ServerDate = Convert.ToDateTime(dr[0]);
          ret = true;
          if (ServerDate.Date != DateTime.Now.Date)
          {
            string msg = Pub.GetResText("", "MsgServerDateEx", "");
            msg = string.Format(msg, ServerDate.Date, DateTime.Now.Date, title);
            if (Pub.MessageBoxShowQuestion(msg)) ret = false;
          }
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
      return ret;
    }

    public bool GetServerGUID(ref string ServerGUID)
    {
      ServerGUID = "";
      bool ret = false;
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "207" }));
        if (dr.Read())
        {
          ServerGUID = dr[0].ToString();
          ret = true;
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
      return ret;
    }

    public byte CheckCardPhysicsNo(string EmpSysID, string CardPhysicsNo10, ref string UseEmpNo)
    {
      UseEmpNo = "";
      byte ret = 0;
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "212", EmpSysID, CardPhysicsNo10 }));
        if (dr.Read())
        {
          ret = 1;
          UseEmpNo = dr["EmpNo"].ToString();
        }
        else
        {
          dr = GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "604", CardPhysicsNo10 }));
          if (dr.Read())
          {
            ret = 2;
          }
        }
      }
      catch (Exception E)
      {
        ret = 3;
        Pub.ShowErrorMsg(E);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      return ret;
    }

    public byte CheckSFAllowance(string EmpSysID)
    {
      byte ret = 0;
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "304", EmpSysID }));
        if (dr.Read()) ret = 1;
      }
      catch (Exception E)
      {
        ret = 2;
        Pub.ShowErrorMsg(E);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      return ret;
    }

    public byte CheckAllowanceFlag(string EmpSysID, DateTime AllowanceFlag, ref DateTime Flag)
    {
      byte ret = 0;
      Flag = new DateTime();
      DataTableReader dr = null;
      try
      {
        if (EmpSysID == "")
          dr = GetDataReader(Pub.GetSQL(DBCode.DB_004006, new string[] { "105" }));
        else
          dr = GetDataReader(Pub.GetSQL(DBCode.DB_004006, new string[] { "5", EmpSysID }));
        if (dr.Read())
        {
          if (dr[0].ToString() != "")
          {
            Flag = (DateTime)dr[0];
            if (Flag >= AllowanceFlag) ret = 2;
          }
        }
        if (ret == 0)
        {
          dr.Close();
          if (EmpSysID == "")
            dr = GetDataReader(Pub.GetSQL(DBCode.DB_004006, new string[] { "106", EmpSysID }));
          else
            dr = GetDataReader(Pub.GetSQL(DBCode.DB_004006, new string[] { "6", EmpSysID }));
          if (dr.Read())
          {
            if (dr[0].ToString() != "")
            {
              Flag = (DateTime)dr[0];
              if (Flag >= AllowanceFlag) ret = 1;
            }
          }
        }
      }
      catch (Exception E)
      {
        ret = 3;
        Pub.ShowErrorMsg(E);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      return ret;
    }

    public bool CheckCardExists(string CardSectorNo, ref string ErrorMsg)
    {
      ErrorMsg = "";
      if (!Pub.IsNumeric(CardSectorNo) || (Convert.ToInt64(CardSectorNo) <= 0))
      {
        ErrorMsg = Pub.GetResText("", "ErrorIllegalCard", "");
        return false;
      }
      DataTableReader dr = null;
      bool ret = false;
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "15", CardSectorNo }));
        if (dr.Read()) ret = true;
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
      if (!ret) ErrorMsg = Pub.GetResText("", "ErrorIllegalCard", "");
      return ret;
    }

    public bool CheckCardExists(string CardSectorNo, string CardData10, ref string ErrorMsg)
    {
      ErrorMsg = "";
      if (!Pub.IsNumeric(CardSectorNo) || (Convert.ToInt64(CardSectorNo) <= 0))
      {
        ErrorMsg = Pub.GetResText("", "ErrorIllegalCard", "");
        return false;
      }
      DataTableReader dr = null;
      bool ret = false;
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "215", CardSectorNo, CardData10 }));
        if (dr.Read()) ret = true;
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
      if (!ret) ErrorMsg = Pub.GetResText("", "ErrorIllegalCard", "");
      return ret;
    }

    public bool CheckCardExists(string CardSectorNo)
    {
      if (!Pub.IsNumeric(CardSectorNo) || (Convert.ToInt64(CardSectorNo) <= 0))
      {
        Pub.MessageBoxShow(Pub.GetResText("", "ErrorIllegalCard", ""));
        return false;
      }
      DataTableReader dr = null;
      bool ret = false;
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "15", CardSectorNo }));
        if (dr.Read()) ret = true;
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
      if (!ret) Pub.MessageBoxShow(Pub.GetResText("", "ErrorIllegalCard", ""));
      return ret;
    }

    public bool CheckCardExists(string CardSectorNo, string CardData10)
    {
      if (!Pub.IsNumeric(CardSectorNo) || (Convert.ToInt64(CardSectorNo) <= 0))
      {
        Pub.MessageBoxShow(Pub.GetResText("", "ErrorIllegalCard", ""));
        return false;
      }
      DataTableReader dr = null;
      bool ret = false;
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "215", CardSectorNo, CardData10 }));
        if (dr.Read()) ret = true;
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
      if (!ret) Pub.MessageBoxShow(Pub.GetResText("", "ErrorIllegalCard", ""));
      return ret;
    }

    public bool EmpCardFa(string Title, string Oprt, string EmpSysID, string CardSectorNo, string CardData10,
      string CardData8, double CardBalance, DateTime CardUseDate, int CardUseTimes, double SFAmount, double DiscountM,
      int CardStatusID, int OpterType, string PhyID, string MacTAG)
    {
      bool ret = false;
      string sql = Pub.GetSQL(DBCode.DB_001003, new string[] { "213", EmpSysID, CardSectorNo, CardData10, CardData8, 
        CardBalance.ToString("0.00"), CardUseDate.ToString(SystemInfo.SQLDateTimeFMT), CardUseTimes.ToString(), 
        SFAmount.ToString("0.00"), DiscountM.ToString("0.00"), OprtInfo.OprtSysID, CardStatusID.ToString(), 
        OpterType.ToString(), PhyID,  MacTAG});
      try
      {
        ExecSQL(sql);
        ret = true;
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E, sql);
      }
      WriteSYLog(Title, Oprt, sql);
      return ret;
    }

    public bool EmpCardFill(string Title, string Oprt, string EmpSysID, string CardSectorNo, bool EditDate,
      DateTime CardDate)
    {
      bool ret = false;
      string sql = Pub.GetSQL(DBCode.DB_001003, new string[] { "214", CardSectorNo, 
        Convert.ToByte(EditDate).ToString(), CardDate.ToString(SystemInfo.SQLDateFMT), EmpSysID });
      try
      {
        ExecSQL(sql);
        ret = true;
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E, sql);
      }
      WriteSYLog(Title, Oprt, sql);
      return ret;
    }

    public bool EmpCardFillPhysics(string Title, string Oprt, string EmpSysID, string CardData10, string CardData8)
    {
      bool ret = false;
      string sql = Pub.GetSQL(DBCode.DB_001003, new string[] { "605", CardData10, CardData8, EmpSysID });
      try
      {
        ExecSQL(sql);
        ret = true;
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E, sql);
      }
      WriteSYLog(Title, Oprt, sql);
      return ret;
    }

    public bool EmpCardRelieve(string Title, string Oprt, string CardSectorNo)
    {
      bool ret = false;
      string sql = Pub.GetSQL(DBCode.DB_001003, new string[] { "216", CardSectorNo, OprtInfo.OprtSysID });
      try
      {
        ExecSQL(sql);
        ret = true;
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E, sql);
      }
      WriteSYLog(Title, Oprt, sql);
      return ret;
    }

    public bool EmpCardModify(string Title, string Oprt, string CardSectorNo, int CardTypeID, string CardPWD,
      DateTime CardStartDate, DateTime CardEndDate, string EmpID, string EmpName)
    {
      bool ret = false;
      string sql = Pub.GetSQL(DBCode.DB_001003, new string[] { "222", CardSectorNo, CardTypeID.ToString(), 
        CardPWD, CardStartDate.ToString(SystemInfo.SQLDateFMT), CardEndDate.ToString(SystemInfo.SQLDateFMT), 
        OprtInfo.OprtSysID, EmpID, EmpName });
      try
      {
        ExecSQL(sql);
        ret = true;
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E, sql);
      }
      WriteSYLog(Title, Oprt, sql);
      return ret;
    }

    public bool EmpCardChange(string Title, string Oprt, string EmpSysID, string CardSectorNo, string CardData10,
      string CardData8, double CardFee, string PhyID, string MacTAG)
    {
      bool ret = false;
      string sql = Pub.GetSQL(DBCode.DB_001003, new string[] { "225", EmpSysID, CardSectorNo, CardData10, CardData8, 
        SystemInfo.CardValidDays.ToString(), CardFee.ToString(), OprtInfo.OprtSysID, PhyID, MacTAG });
      try
      {
        ExecSQL(sql);
        ret = true;
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E, sql);
      }
      WriteSYLog(Title, Oprt, sql);
      return ret;
    }

    public bool EmpCardRetirement(string Title, string Oprt, string EmpSysID, int RetirementFlag, double BTMoney,
      double ShowBTMoney, double CardBalance, double CardFee, int CarduseTimes, string PhyID, string MacTAG)
    {
      bool ret = false;
      string sql = Pub.GetSQL(DBCode.DB_001003, new string[] { "226", EmpSysID, RetirementFlag.ToString(), 
        BTMoney.ToString(), ShowBTMoney.ToString(), CardBalance.ToString(), CardFee.ToString(), 
        SystemInfo.CardValidDays.ToString(), OprtInfo.OprtSysID, CarduseTimes.ToString(), PhyID, MacTAG });
      try
      {
        ExecSQL(sql);
        ret = true;
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E, sql);
      }
      WriteSYLog(Title, Oprt, sql);
      return ret;
    }

    public byte GetMonthDays(int Year, byte Month)
    {
      byte ret = 0;
      switch (Month)
      {
        case 2:
          if (Year % 400 == 0)
            ret = 29;
          else if ((Year % 4 == 0) && (Year % 100 != 0))
            ret = 29;
          else
            ret = 28;
          break;
        case 4:
        case 6:
        case 9:
        case 11:
          ret = 30;
          break;
        case 1:
        case 3:
        case 5:
        case 7:
        case 8:
        case 10:
        case 12:
          ret = 31;
          break;
      }
      return ret;
    }

    public double GetBTMoney(string BTDate, double BTMoney)
    {
      DateTime dt = new DateTime();
      double ret = BTMoney;
      if (BTDate == "000000") return ret;
      int y = 2000 + Convert.ToInt32(BTDate.Substring(0, 2), 16);
      int m = Convert.ToInt32(BTDate.Substring(2, 2), 16);
      int d = Convert.ToInt32(BTDate.Substring(4, 2), 16);
      dt = new DateTime(y, m, d);
      int year = DateTime.Now.Date.Year;
      byte month = (byte)DateTime.Now.Date.Month;
      byte day = (byte)DateTime.Now.Date.Day;
      byte maxDays = GetMonthDays(year, month);
      switch (SystemInfo.SFBtBagFlag)
      {
        case 0:
          if (SystemInfo.SFBtBagDate != 0)
          {
            dt = dt.AddDays(SystemInfo.SFBtBagDate);
            if (DateTime.Now.Date > dt) ret = 0;
          }
          break;
        case 1:
          if (SystemInfo.SFBtBagDate != 0)
          {
            if ((month == 1) && (dt.Month == 12) && (year == dt.Year + 1))
            {
              if (day >= SystemInfo.SFBtBagDate) ret = 0;
            }
            else if ((year == dt.Year) && (month == dt.Month + 1))
            {
              if (day >= SystemInfo.SFBtBagDate)
                ret = 0;
              else if (SystemInfo.SFBtBagDate >= maxDays)
                ret = 0;
            }
          }
          break;
        case 2:
          if ((month == 1) && (dt.Month == 12) && (year == dt.Year + 1) && (day >= 1))
            ret = 0;
          else if ((year == dt.Year) && (month == dt.Month + 1) && (day >= 1))
            ret = 0;
          break;
      }
      return ret;
    }

    public bool EmpGetCardStatusIDByEmpSysID(string EmpSysID, ref int CardStatusID, ref bool IsLock,
      ref string LockOprtNo, ref string LockComputerName)
    {
      IsLock = false;
      LockOprtNo = "";
      LockComputerName = "";
      bool ret = false;
      string sql = Pub.GetSQL(DBCode.DB_001003, new string[] { "229", EmpSysID });
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(sql);
        if (dr.Read())
        {
          CardStatusID = Convert.ToInt32(dr["CardStatusID"]);
          IsLock = Pub.ValueToBool(dr["LockCard"]);
          LockOprtNo = dr["LockOprtNo"].ToString();
          LockComputerName = dr["LockComputerName"].ToString();
          if (IsLock)
          {
            if ((LockOprtNo == OprtInfo.OprtNo) && (LockComputerName == SystemInfo.ComputerName))
            {
              IsLock = false;
              LockOprtNo = "";
              LockComputerName = "";
            }
          }
          if (!IsLock)
          {
            ExecSQL(Pub.GetSQL(DBCode.DB_001003, new string[] { "236", OprtInfo.OprtSysID, 
              SystemInfo.ComputerName, EmpSysID }));
          }
          ret = true;
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
      return ret;
    }

    public bool EmpGetCardStatusIDByCardPhysicsNo(string CardPhysicsNo10, ref string EmpSysID, ref string CardSectorNo,
      ref int CardStatusID)
    {
      bool ret = false;
      string sql = Pub.GetSQL(DBCode.DB_001003, new string[] { "228", CardPhysicsNo10 });
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(sql);
        if (dr.Read())
        {
          CardStatusID = Convert.ToInt32(dr["CardStatusID"]);
          EmpSysID = dr["EmpSysID"].ToString();
          CardSectorNo = dr["CardSectorNo"].ToString();
          ret = true;
        }
        else
          Pub.MessageBoxShow(Pub.GetResText("", "ErrorIllegalCard", ""));
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
      return ret;
    }

    public bool EmpGetCardStatusID(string CardSectorNo, ref int CardStatusID)
    {
      bool ret = false;
      string sql = Pub.GetSQL(DBCode.DB_001003, new string[] { "215", CardSectorNo });
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(sql);
        if (dr.Read())
        {
          CardStatusID = Convert.ToInt32(dr["CardStatusID"]);
          ret = true;
        }
        else
        {
          Pub.MessageBoxShow(Pub.GetResText("", "ErrorIllegalCard", ""));
        }
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E, sql);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      return ret;
    }

    public bool EmpGetCardStatusName(string CardSectorNo, ref string CardStatusName)
    {
      bool ret = false;
      string sql = Pub.GetSQL(DBCode.DB_001003, new string[] { "215", CardSectorNo });
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(sql);
        if (dr.Read())
        {
          CardStatusName = dr["CardStatusName"].ToString();
          ret = true;
        }
        else
        {
          Pub.MessageBoxShow(Pub.GetResText("", "ErrorIllegalCard", ""));
        }
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E, sql);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      return ret;
    }

    public void SetSFCardSector()
    {
      SystemInfo.SFCardSector = Convert.ToByte(SystemInfo.PubCardSector + 1);
      SystemInfo.SKCardSector = Convert.ToByte(SystemInfo.SFCardSector + 2);
    }

    private int BuildCustomersCode()
    {
      string ret = "";
      Random rd = new Random();
      for (int i = 1; i <= 6; i++)
      {
        ret += rd.Next(9).ToString();
      }
      return Convert.ToInt32(ret);
    }

    public void ReadSystemConfig()
    {
      //发卡时使用9位人员编号
      SystemInfo.IsLongEmpID = ReadConfig("RS_System", "IsLongEmpID", true);
      //人员编号是否自动增加
      SystemInfo.IsAddEmpNo = ReadConfig("RS_System", "IsAddEmpNo", "Y") == "Y";
      //人员编号前缀
      SystemInfo.EmpNoPrefix = ReadConfig("RS_System", "EmpNoPrefix", "E");
      //人员编号数字位
      byte defBit = SystemInfo.IsLongEmpID ? (byte)8 : (byte)4;
      SystemInfo.EmpNoNumBit = ReadConfig("RS_System", "EmpNoNumBit", defBit);
      //公共扇区
      SystemInfo.PubCardSector = ReadConfig("RS_System", "PubCardSector", Convert.ToByte(1));
      SetSFCardSector();
      //取收费经销商代码
      SystemInfo.DealersCode = ReadConfig("RS_System", "DealersCode", "");
      //取收费客户代码
      SystemInfo.CustomersCode = ReadConfig("RS_System", "CustomersCode", 0);
      if (SystemInfo.CustomersCode > 999999) SystemInfo.CustomersCode = 999999;
      if (SystemInfo.CustomersCode == 0)
      {
        SystemInfo.CustomersCode = BuildCustomersCode();
        WriteConfig("RS_System", "CustomersCode", SystemInfo.CustomersCode);
      }
      //取收费有效期
      SystemInfo.SFBtBagFlag = ReadConfig("RS_System", "SFBtBagFlag", Convert.ToByte(0));
      SystemInfo.SFBtBagDate = ReadConfig("RS_System", "SFBtBagDate", Convert.ToByte(0));
      //取卡密钥
      SystemInfo.CardKey = ReadConfig("RS_System", "CardKey", "");
      if (SystemInfo.CardKey != "")
      {
        SystemInfo.CardKey = DeviceObject.objCPIC.GetCardKey(SystemInfo.CardKey, "yyc120114");
      }
      //退卡、换卡之前的卡号有效天数
      SystemInfo.CardValidDays = ReadConfig("RS_System", "CardValidDays", 60);
      SystemInfo.EmpDelete = ReadConfig("RS_System", "EmpDelete", false);
      SystemInfo.FaCardFee = ReadConfig("RS_System", "FaCardFee", false);
      Pub.InitCardInfo();
      //导入补贴时是否更新卡级别、下传补贴时传卡级别
      SystemInfo.AllowanceCardType = ReadConfig("RS_System", "AllowanceCardType", false);
      //考勤使用卡号类型
      SystemInfo.CardType = ReadConfig("KQ_System", "CardType", Convert.ToByte(0));
      //门禁卡片协议
      SystemInfo.CardProtocol = ReadConfig("MJ_System", "CardProtocol", Convert.ToByte(0));
      //是否启用高级时间组
      SystemInfo.AdvTimeGroup = ReadConfig("MJ_System", "AdvTimeGroup", 1) == 1;
      //
      SystemInfo.AdvUseOtherCard = ReadConfig("MJ_System", "AdvUseOtherCard", 1) == 1;
      //帐户充值取款是否使用同一界面
      SystemInfo.SFCardDRMode = SystemInfo.ini.ReadIni("Public", "SFCardDRMode", false);
      SystemInfo.CheckSameBT = SystemInfo.ini.ReadIni("Public", "CheckSameBT", Convert.ToByte(1));
      SystemInfo.SKDepositTotal = SystemInfo.ini.ReadIni("Public", "SKSum", true);
      //实时监控USB、485方式机器
      SystemInfo.IsRealOther = ReadConfig("RS_System", "IsRealOther", false);
      //收费机、充值机、计时机支持补贴功能
      SystemInfo.AllDevAllowance = ReadConfig("RS_System", "AllDevAllowance", false);
      SystemInfo.AllowExtScreen = ReadConfig("RS_System", "AllowExtScreen", false);
      //允许使用充值发卡
      SystemInfo.AllowFaDeposit = ReadConfig("RS_System", "AllowFaDeposit", true);
      //允许取款时取出补贴金额
      SystemInfo.AllowRefAllowance = ReadConfig("RS_System", "AllowRefAllowance", false);
      //启用多种充值类型
      SystemInfo.HasMoreDepositType = ReadConfig("RS_System", "MoreDepositType", true);
      //
      SystemInfo.HasMoreRefundmentType = ReadConfig("RS_System", "MoreRefundmentType", SystemInfo.DefMoreRefundmentType);
      //
      SystemInfo.AllowLossSelect = ReadConfig("RS_System", "AllowLossSelect", false);
    }

    private void UpdateDatabaseScript(System.Resources.ResourceManager rm, string resName, ref string UpSql)
    {
      UpdateDatabaseScript(rm, resName, false, ref UpSql);
    }

    private void UpdateDatabaseScript(System.Resources.ResourceManager rm, string resName, bool HideError,
      ref string UpSql)
    {
      UpdateDatabaseScript(rm, resName, HideError, 0, ref UpSql);
    }

    private void UpdateDatabaseScript(System.Resources.ResourceManager rm, string resName, bool HideError,
      int StartLine, ref string UpSql)
    {
      UpSql = "";
      string resStr = rm.GetString(resName);
      if (resStr == null) return;
      string[] sql = resStr.Split(new string[] { "\r\nGO" }, StringSplitOptions.None);
      for (int i = StartLine; i < sql.Length; i++)
      {
        UpSql = sql[i].Trim();
        if (UpSql != "") ExecSQL(UpSql, HideError);
      }
    }

    private void UpdateDatabaseScript(string resFileName, ref string UpSql)
    {
      UpSql = "";
      StreamReader sr = new StreamReader(resFileName, Encoding.Default);
      string[] sql = sr.ReadToEnd().Split(new string[] { "\r\nGO" }, StringSplitOptions.None);
      for (int i = 0; i < sql.Length; i++)
      {
        UpSql = sql[i].Trim();
        if (UpSql != "") ExecSQL(UpSql, false);
      }
    }

    public bool UpdateDatabasesLang()
    {
      Thread.Sleep(1000);
      bool ret = false;
      System.Resources.ResourceManager rm = null;
      string UpSql = "";
      string refFileName = "";
      try
      {
        rm = new System.Resources.ResourceManager("ECard78.Properties.Resources", Assembly.GetExecutingAssembly());
        switch (_DBType)
        {
          case 1:
          case 2:
            UpdateDatabaseScript(rm, "DATA_CHS", ref UpSql);
            if (SystemInfo.LangName != "CHS")
            {
              refFileName = SystemInfo.AppPath + SystemInfo.LangName + "_MSSQL.sql";
              if (File.Exists(refFileName))
                UpdateDatabaseScript(refFileName, ref UpSql);
              else
                UpdateDatabaseScript(rm, "DATA_" + SystemInfo.LangName, ref UpSql);
            }
            break;
        }
        ret = true;
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E, UpSql);
      }
      return ret;
    }

    public void UpdateEmpInfoCount(string Title)
    {
      List<string> sql = new List<string>();
      DataTableReader dr = null;
      int idx;
      UInt32 EnrollNo = 0;
      int count = 0;
      try
      {
        ExecSQL(Pub.GetSQL(DBCode.DB_001003, new string[] { "243" }));
        for (int i = 0; i < 5; i++)
        {
          idx = 800 + i + 1;
          dr = GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { idx.ToString() }));
          while (dr.Read())
          {
            EnrollNo = Convert.ToUInt32(dr[0].ToString());
            count = Convert.ToInt32(dr[1].ToString());
            sql.Add(Pub.GetSQL(DBCode.DB_001003, new string[] { "800", i.ToString(), count.ToString(), EnrollNo.ToString() }));
          }
          dr.Close();
        }
      }
      catch (Exception E)
      {
        sql.Clear();
        Pub.ShowErrorMsg(E);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      if (sql.Count > 0) ExecSQL(sql);
    }

    public bool UpdateDatabase(string Title, DateTime dt)
    {
      bool ret = false;
      System.Resources.ResourceManager rm = null;
      DateTime newDate;
      string UpSql = "";
      try
      {
        rm = new System.Resources.ResourceManager("ECard78.Properties.Resources", Assembly.GetExecutingAssembly());
        newDate = new DateTime(2019, 3, 1);
        if (SystemInfo.LastDBDate > newDate) newDate = SystemInfo.LastDBDate;
        if (dt < newDate)
        {
          for (int i = 1; i <= 27; i++)
          {
            switch (SystemInfo.DBType)
            {
              case 1:
              case 2:
                UpdateDatabaseScript(rm, "UPDATE_" + i.ToString("000"), i == 7, ref UpSql);
                break;
            }
          }
          string pass = Pub.GetOprtEncrypt("0");
          switch (SystemInfo.DBType)
          {
            case 1:
            case 2:
              UpSql = "UPDATE SY_Oprt SET OprtPWD='" + pass + "' WHERE OprtPWD='' OR OprtPWD IS NULL";
              ExecSQL(UpSql);
              break;
          }
          UpdateEmpInfoCount(Title);
        }
        ret = true;
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E, UpSql);
      }
      return ret;
    }

    public void UpdateModuleResources(string Title, Assembly am)
    {
      System.Resources.ResourceManager rm = null;
      string UpSql = "";
      try
      {
        rm = new System.Resources.ResourceManager("ECard78.Properties.Resources", am);
        string resName = "";
        switch (SystemInfo.DBType)
        {
          case 1:
          case 2:
            resName = "UPDATE_999";
            break;
        }
        if (rm.GetString(resName) != null)
        {
          string[] lines = rm.GetString(resName).Split(new string[] { "\r\nGO" }, StringSplitOptions.None);
          string s = lines[0];
          int Y = Convert.ToInt32(s.Substring(0, 4));
          int M = Convert.ToInt32(s.Substring(4, 2));
          int D = Convert.ToInt32(s.Substring(6, 2));
          DateTime newDate = new DateTime(Y, M, D);
          if (SystemInfo.AccDBDate < newDate) UpdateDatabaseScript(rm, resName, true, 1, ref UpSql);
        }
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E, UpSql);
      }
    }

    public bool CheckOprtRole(string SubID, string role)
    {
      return CheckOprtRole(SubID, role, false, true);
    }

    public bool CheckOprtRole(string SubID, string role, bool AllowCheckOprtRole)
    {
      return CheckOprtRole(SubID, role, true, AllowCheckOprtRole);
    }

    public bool CheckOprtRole(string SubID, string role, bool CheckForward, bool AllowCheckOprtRole)
    {
      bool ret = false;
      if (!SystemInfo.AccIsForward) SystemInfo.AccIsForward = GetForwardState();
      if (SystemInfo.AccIsForward && CheckForward && (role.ToUpper().Trim() != "E"))
      {
        Pub.MessageBoxShow(Pub.GetResText("", "ErrorIsForward", ""));
        return ret;
      }
      if (!AllowCheckOprtRole) return true;
      if (OprtInfo.OprtIsSys)
      {
        if (OprtInfo.OprtNo.ToLower() == "admin") return true;
        if (OprtInfo.OprtNo.ToLower() == "browser")
        {
          if (SubID.Substring(0, 2).ToUpper() == "SY") goto RoleEnd;
          if (role.ToUpper().Trim() == "E")
            return true;
          else
            goto RoleEnd;
        }
        if (OprtInfo.OprtNo.ToLower() == "operator")
        {
          if (SubID.Substring(0, 2).ToUpper() == "SY") goto RoleEnd;
          return true;
        }
      }
      string ModuleID = SubID.Substring(0, 2);
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_000003, new string[] { "103", OprtInfo.OprtSysID, ModuleID, SubID }));
        if (dr.Read())
        {
          switch (role.ToUpper().Trim())
          {
            case "E":
              ret = dr["Power_E"].ToString().ToUpper() == "Y";
              break;
            case "A":
              ret = dr["Power_A"].ToString().ToUpper() == "Y";
              break;
            case "M":
              ret = dr["Power_M"].ToString().ToUpper() == "Y";
              break;
            case "D":
              ret = dr["Power_D"].ToString().ToUpper() == "Y";
              break;
            case "C":
              ret = dr["Power_C"].ToString().ToUpper() == "Y";
              break;
          }
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
    RoleEnd:
      if (!ret)
      {
        Pub.MessageBoxShow(Pub.GetResText("", "ErrorNoPower" + role.ToUpper().Trim(), ""));
      }
      return ret;
    }

    public bool CheckDepartPowerByEmpSysID(string EmpSysID)
    {
      bool ret = false;
      string sql = Pub.GetSQL(DBCode.DB_001003, new string[] { "3", EmpSysID });
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(sql);
        if (dr.Read())
        {
          ret = CheckDepartPowerByDeptSysID(dr["DepartSysID"].ToString());
        }
        else
        {
          Pub.MessageBoxShow(Pub.GetResText("", "ErrorNoDeptPower", ""));
        }
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E, sql);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      return ret;
    }

    public bool CheckDepartPowerByDeptSysID(string DepartSysID)
    {
      bool ret = false;
      if (OprtInfo.OprtIsSys) return true;
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_000003, new string[] { "106", OprtInfo.OprtSysID, DepartSysID }));
        if (dr.Read()) ret = true;
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
      if (!ret)
      {
        Pub.MessageBoxShow(Pub.GetResText("", "ErrorNoDeptPower", ""));
      }
      return ret;
    }

    public bool CheckDepartPowerByCard(string CardSectorNo)
    {
      bool ret = false;
      string sql = Pub.GetSQL(DBCode.DB_001003, new string[] { "215", CardSectorNo });
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(sql);
        if (dr.Read())
        {
          ret = CheckDepartPowerByDeptSysID(dr["DepartSysID"].ToString());
        }
        else
        {
          Pub.MessageBoxShow(Pub.GetResText("", "ErrorNoDeptPower", ""));
        }
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E, sql);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      return ret;
    }

    public bool CheckDepartPowerByCard(string CardSectorNo, ref string ErrorMsg)
    {
      ErrorMsg = "";
      bool ret = false;
      string sql = Pub.GetSQL(DBCode.DB_001003, new string[] { "215", CardSectorNo });
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(sql);
        if (dr.Read())
        {
          ret = CheckDepartPowerByDeptSysID(dr["DepartSysID"].ToString());
        }
        else
        {
          ErrorMsg = Pub.GetResText("", "ErrorNoDeptPower", "");
        }
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E, sql);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      return ret;
    }

    public bool GetDepartIDAndName(string DepartSysID, ref string DepartID, ref string DepartName)
    {
      bool ret = false;
      DepartID = "";
      DepartName = "";
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_001002, new string[] { "1", DepartSysID }));
        if (dr.Read())
        {
          DepartID = dr["DepartID"].ToString();
          DepartName = dr["DepartName"].ToString();
          ret = true;
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
      return ret;
    }

    public bool GetAddressIDAndName(string AddressSysID, ref string AddressID, ref string AddressName)
    {
      bool ret = false;
      AddressID = "";
      AddressName = "";
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_004001, new string[] { "1", AddressSysID }));
        if (dr.Read())
        {
          AddressID = dr["AddressNO"].ToString();
          AddressName = dr["AddressName"].ToString();
          ret = true;
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
      return ret;
    }

    public bool GetEmpInfoCard(string EmpSysID, ref string EmpNo, ref string EmpName, ref string CardSectorNo,
      ref string CardPhysicsNo10, ref string CardPhysicsNo8)
    {
      bool ret = false;
      EmpNo = "";
      EmpName = "";
      CardSectorNo = "";
      CardPhysicsNo10 = "";
      CardPhysicsNo8 = "";
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "1", EmpSysID }));
        if (dr.Read())
        {
          EmpNo = dr["EmpNo"].ToString();
          EmpName = dr["EmpName"].ToString();
          CardSectorNo = dr["CardSectorNo"].ToString();
          CardPhysicsNo10 = dr["CardPhysicsNo10"].ToString();
          CardPhysicsNo8 = dr["CardPhysicsNo8"].ToString();
          ret = true;
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
      return ret;
    }

    public bool GetEmpInfo(string EmpNo, ref string EmpSysID, ref string EmpName, ref string DepartID,
      ref string DepartName)
    {
      bool ret = false;
      EmpSysID = "";
      EmpName = "";
      DepartID = "";
      DepartName = "";
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "231", EmpNo }));
        if (dr.Read())
        {
          EmpSysID = dr["EmpSysID"].ToString();
          EmpName = dr["EmpName"].ToString();
          DepartID = dr["DepartID"].ToString();
          DepartName = dr["DepartName"].ToString();
          ret = true;
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
      return ret;
    }

    public bool GetEmpInfo(string EmpNo, ref string EmpSysID, ref string EmpName, ref string DepartID,
      ref string DepartName, ref int EnrollCount)
    {
      bool ret = false;
      EmpSysID = "";
      EmpName = "";
      DepartID = "";
      DepartName = "";
      EnrollCount = 0;
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_002001, new string[] { "204", EmpNo, OprtInfo.DepartPower }));
        if (dr.Read())
        {
          EmpSysID = dr["EmpSysID"].ToString();
          EmpName = dr["EmpName"].ToString();
          DepartID = dr["DepartID"].ToString();
          DepartName = dr["DepartName"].ToString();
          EnrollCount = Convert.ToInt32(dr["EnrollCount"].ToString());
          ret = true;
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
      return ret;
    }

    public bool GetEmpSysID(UInt32 FingerNo, ref string SysID)
    {
      SysID = "";
      bool ret = false;
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "5", FingerNo.ToString() }));
        if (dr.Read())
        {
          SysID = dr["EmpSysID"].ToString();
          ret = true;
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
      return ret;
    }

    public bool GetEmpSysID(string EmpNo, ref string SysID)
    {
      SysID = "";
      bool ret = false;
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "2", EmpNo }));
        if (dr.Read())
        {
          SysID = dr["EmpSysID"].ToString();
          ret = true;
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
      return ret;
    }

    public bool GetDepartInfo(string DepartID, ref string DepartSysID, ref string DepartName)
    {
      bool ret = false;
      DepartSysID = "";
      DepartName = "";
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_001002, new string[] { "2", DepartID }));
        if (dr.Read())
        {
          DepartSysID = dr["DepartSysID"].ToString();
          DepartName = dr["DepartName"].ToString();
          ret = true;
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
      return ret;
    }

    public string GetDepartChildSysIDByID(string DepartID)
    {
      string DepartSysID = "";
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_001002, new string[] { "2", DepartID }));
        if (dr.Read()) DepartSysID = dr["DepartSysID"].ToString();
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
      return GetDepartChildSysIDBySysID(DepartSysID);
    }

    public string GetDepartChildSysIDBySysID(string DepartSysID)
    {
      string ret = "";
      string s = "";
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_001002, new string[] { "3", DepartSysID }));
        while (dr.Read())
        {
          DepartSysID = dr["DepartSysID"].ToString();
          s = GetDepartChildSysIDBySysID(DepartSysID);
          if (s != "") s = s + ",";
          ret += "'" + DepartSysID + "'," + s.Trim();
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
      if (ret != "") ret = ret.Substring(0, ret.Length - 1);
      return ret;
    }

    public string GetDepartChildID(string DepartID)
    {
      bool IsFind = false;
      string DepartSysID = "";
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_001002, new string[] { "2", DepartID }));
        if (dr.Read())
        {
          DepartSysID = dr["DepartSysID"].ToString();
          IsFind = true;
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
      string ret = "";
      if (IsFind) ret = GetDepartChildIDBySysID(DepartSysID);
      return ret;
    }

    public string GetDepartChildIDBySysID(string DepartSysID)
    {
      string ret = "";
      string s = "";
      string DepartID = "";
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_001002, new string[] { "3", DepartSysID }));
        while (dr.Read())
        {
          DepartSysID = dr["DepartSysID"].ToString();
          DepartID = dr["DepartID"].ToString();
          s = GetDepartChildIDBySysID(DepartSysID);
          if (s != "") s = s + ",";
          ret += "'" + DepartID + "'," + s.Trim();
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
      if (ret != "") ret = ret.Substring(0, ret.Length - 1);
      return ret;
    }

    public string GetAddressChildSysIDBySysID(string AddressSysID)
    {
      string ret = "";
      string s = "";
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_004001, new string[] { "3", AddressSysID }));
        while (dr.Read())
        {
          AddressSysID = dr["GUID"].ToString();
          s = GetAddressChildSysIDBySysID(AddressSysID);
          if (s != "") s = s + ",";
          ret += "'" + AddressSysID + "'," + s.Trim();
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
      if (ret != "") ret = ret.Substring(0, ret.Length - 1);
      return ret;
    }

    public string GetAddressChildID(string AddressID)
    {
      bool IsFind = false;
      string AddressSysID = "";
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_004001, new string[] { "2", AddressID }));
        if (dr.Read())
        {
          AddressSysID = dr["GUID"].ToString();
          IsFind = true;
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
      string ret = "";
      if (IsFind) ret = GetAddressChildIDBySysID(AddressSysID);
      return ret;
    }

    public string GetAddressChildIDBySysID(string AddressSysID)
    {
      string ret = "";
      string s = "";
      string AddressID = "";
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_004001, new string[] { "3", AddressSysID }));
        while (dr.Read())
        {
          AddressSysID = dr["GUID"].ToString();
          AddressID = dr["AddressNO"].ToString();
          s = GetAddressChildIDBySysID(AddressSysID);
          if (s != "") s = s + ",";
          ret += "'" + AddressID + "'," + s.Trim();
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
      if (ret != "") ret = ret.Substring(0, ret.Length - 1);
      return ret;
    }

    public string GetAutoEmpNo()
    {
      string EmpNo = "";
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "101", SystemInfo.EmpNoPrefix }));
        if (dr.Read()) EmpNo = dr[0].ToString();
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
      UInt64 no = 1;
      if (Pub.IsNumeric(EmpNo))
      {
        no = Convert.ToUInt64(EmpNo) + 1;
      }
      return GetAutoEmpNo(no, SystemInfo.EmpNoPrefix, SystemInfo.EmpNoNumBit);
    }

    public string GetAutoEmpNo(UInt64 EmpNo, string Prefix, byte NumBit)
    {
      string ret = "";
      while (ret.Length < NumBit)
      {
        ret += "0";
      }
      ret = Prefix + EmpNo.ToString(ret);
      return ret;
    }

    public string GetMaxCardSectorNo()
    {
      return GetMaxCardSectorNo("");
    }

    public string GetMaxCardSectorNo(string EmpSysID)
    {
      string ret = "";
      UInt32 ID = 1;
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "208" }));
        if (dr.Read()) ID = Convert.ToUInt32(dr[0].ToString());
        if (ID > 0)
        {
          if (ID > SystemInfo.MaxCardID)
          {
            Pub.MessageBoxShow(SystemInfo.MsgMaxCardID);
            return "";
          }
          ret = ID.ToString("0000000000");
          ExecSQL(Pub.GetSQL(DBCode.DB_001003, new string[] { "233", ret, EmpSysID }));
        }
      }
      catch (Exception E)
      {
        ret = "";
        Pub.ShowErrorMsg(E);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      return ret;
    }

    public bool CardPhysicsNoIsExists(string EmpSysID, string PhysicsNo, ref string CardInfo)
    {
      bool ret = false;
      CardInfo = "";
      if (PhysicsNo != "")
      {
        DataTableReader dr = null;
        try
        {
          dr = GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "603", PhysicsNo, EmpSysID }));
          if (dr.Read())
          {
            CardInfo = dr["EmpNo"].ToString();
            ret = true;
          }
          dr.Close();
          if (!ret)
          {
            dr = GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "604", PhysicsNo }));
            if (dr.Read())
            {
              CardInfo = " ";
              ret = true;
            }
          }
          dr.Close();
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
      }
      return ret;
    }

    public bool CardSectorNoIsExists(string EmpSysID, string CardNo, ref string CardDays)
    {
      bool ret = false;
      CardDays = "";
      if (CardNo != "")
      {
        DataTableReader dr = null;
        try
        {
          dr = GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "209", CardNo, EmpSysID }));
          if (dr.Read())
          {
            CardDays = dr["EmpNo"].ToString();
            ret = true;
          }
          dr.Close();
          if (!ret)
          {
            dr = GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "210", CardNo }));
            if (dr.Read())
            {
              CardDays = " ";
              ret = true;
            }
          }
          dr.Close();
          if (!ret)
          {
            dr = GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "211", 
              SystemInfo.CardValidDays.ToString(), CardNo }));
            if (dr.Read())
            {
              CardDays = ((DateTime)dr["CardOprtDate"]).ToShortDateString();
              ret = true;
            }
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
      }
      return ret;
    }

    public byte[] GetMJInOutPassword(string MacSN, byte doorID)
    {
      byte[] ret = new byte[2];
      int i1 = 0;
      int i2 = 0;
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_003001, new string[] { "11", doorID.ToString() }));
        if (dr.Read()) i1 = dr["IsAndPassword"].ToString() == "Y" ? 1 : 0;
        if (dr.Read()) i2 = dr["IsAndPassword"].ToString() == "Y" ? 1 : 0;
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
      ret[0] = Convert.ToByte(i1);
      ret[1] = Convert.ToByte(i2);
      return ret;
    }

    public void WriteSYLog(string Title, string Tool, string Detail)
    {
      Detail = Detail.Replace("'", "");
      string sql = Pub.GetSQL(DBCode.DB_000001, new string[] { "118", Title, Tool, Detail, OprtInfo.OprtNoAndName,
        SystemInfo.ComputerName });
      ExecSQL(sql, true);
    }

    public void WriteSYLog(string Title, string Tool, List<string> Detail)
    {
      string tmp = "";
      int max = Detail.Count;
      if (max > 100) max = 100;
      for (int i = 0; i < max; i++)
      {
        tmp = tmp + Detail[i] + "\r\n";
      }
      tmp = "Count: " + Detail.Count.ToString() + "  " + tmp;
      if (max < Detail.Count) tmp = tmp + "  ......";
      WriteSYLog(Title, Tool, tmp);
    }

    public string GetRegSerial()
    {
      HardInfo.HardInfo hardInfo = new HardInfo.HardInfo();
      string tmp = hardInfo.GetDiskSN();
      if (tmp == "") tmp = hardInfo.GetHostName();
      if (tmp == "") tmp = hardInfo.GetMacAddress();
      string ret = DeviceObject.objAES.AesEncrypt(tmp, tmp);
      ret = DeviceObject.objDES.Des3EncryptA(ret, "123456789012345678901234");
      return ret;
    }

    public string GetDBServerSerial()
    {
      string ret = "";
      DataTableReader dr = null;
      try
      {
        ExecSQL("IF object_id('xp_ecard_getserial') IS NOT NULL EXEC sp_dropextendedproc 'xp_ecard_getserial'");
        ExecSQL("EXEC sp_addextendedproc 'xp_ecard_getserial', 'ECardCHK.dll'");
        dr = GetDataReader("EXEC master..xp_ecard_getserial");
        ExecSQL("EXEC sp_dropextendedproc 'xp_ecard_getserial'");
        ExecSQL("DBCC SPEncrypt(FREE)");
        if (dr.Read()) ret = dr[0].ToString();
      }
      catch
      {
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      return ret;
    }

    ushort UpdateCRC(ushort src, byte ch)
    {
      int ret = (src << 8) ^ t16[ch ^ (src >> 8)];
      while ((ret > 65535) || (ret < 0)) ret = ret & 0xffff;
      return Convert.ToUInt16(ret);
    }

    ushort CRCCheck(char[] X, int Num)
    {
      ushort tmp = 0;
      if (Num > 0)
      {
        tmp = UpdateCRC(con_Initial, Convert.ToByte(X[0]));
        for (int i = 1; i < Num; i++) tmp = UpdateCRC(tmp, Convert.ToByte(X[i]));
      }
      return tmp;
    }
    string GetKeyEx(string Key)
    {
      string ret = Key;
      while (ret.Length < 5) ret = "0" + ret;
      return ret;
    }

    bool IsRightKey(string Key)
    {
      string tmp = Crypt.StrEncrypt(RegisterInfo.Serial, C_RegKey);
      char[] P = new char[tmp.Length];
      tmp.CopyTo(0, P, 0, tmp.Length);
      ushort CRC = CRCCheck(P, P.Length);
      return (GetKeyEx(Convert.ToString(CRC)) == Key);
    }

    bool IsRightKeyAll(string Key)
    {
      string tmp = Crypt.StrEncrypt("8EA9B7DF48CEE555", C_RegKey);
      char[] P = new char[tmp.Length];
      tmp.CopyTo(0, P, 0, tmp.Length);
      ushort CRC = CRCCheck(P, P.Length);
      return (GetKeyEx(Convert.ToString(CRC)) == Key);
    }

    bool IsRightSoft(string Key)
    {
      string tmp = Crypt.StrEncrypt(RegisterInfo.ProductName, Key0_int);
      char[] P = new char[tmp.Length];
      tmp.CopyTo(0, P, 0, tmp.Length);
      ushort CRC = CRCCheck(P, P.Length);
      return (GetKeyEx(Convert.ToString(CRC)) == Key);
    }

    bool IsUserKey(string User, string Key)
    {
      string tmp = Crypt.StrEncrypt(User, Key0_int);
      char[] P = new char[tmp.Length];
      tmp.CopyTo(0, P, 0, tmp.Length);
      ushort CRC = CRCCheck(P, P.Length);
      return (GetKeyEx(Convert.ToString(CRC)) == Key);
    }

    string GetRightKey()
    {
      string tmp = Crypt.StrEncrypt(RegisterInfo.Serial, C_RegKey);
      char[] P = new char[tmp.Length];
      tmp.CopyTo(0, P, 0, tmp.Length);
      ushort CRC = CRCCheck(P, P.Length);
      return GetKeyEx(Convert.ToString(CRC));
    }

    string GetRightSoft(int Key0_int)
    {
      string tmp = Crypt.StrEncrypt(RegisterInfo.ProductName, Key0_int);
      char[] P = new char[tmp.Length];
      tmp.CopyTo(0, P, 0, tmp.Length);
      ushort CRC = CRCCheck(P, P.Length);
      return GetKeyEx(Convert.ToString(CRC));
    }

    string GetUserKey(string User, int Key0_int)
    {
      string tmp = Crypt.StrEncrypt(User, Key0_int);
      char[] P = new char[tmp.Length];
      tmp.CopyTo(0, P, 0, tmp.Length);
      ushort CRC = CRCCheck(P, P.Length);
      return GetKeyEx(Convert.ToString(CRC));
    }

    string GetDateKey(bool IsAlways, DateTime ValidDate, string Key0)
    {
      string tmp = "36526";
      if (!IsAlways) tmp = ValidDate.ToOADate().ToString();
      return Crypt.StrEncrypt(tmp, Key0, 0);
    }

    public string GetRegKey(string User, bool IsAlways, DateTime ValidDate)
    {
      string Key0 = GetRightKey();
      int Key0_int = Convert.ToInt32(Key0) * 2;
      string Key1 = GetRightSoft(Key0_int);
      string Key2 = GetDateKey(IsAlways, ValidDate, Key0);
      string Key3 = GetUserKey(User, Key0_int);
      return Key0 + "-" + Key1 + "-" + Key2 + "-" + Key3;
    }

    public bool IsRegister(bool ReadDB, string RegUser, string RegKey)
    {
      bool ret = false;
      string ProdKey = Crypt.StrEncrypt(RegisterInfo.ProductName, C_RegKey);
      string tmp = "";
      RegisterInfo.RegUser = "";
      RegisterInfo.RegKey = "";
      RegisterInfo.IsAlways = false;
      RegisterInfo.IsTest = true;
      RegisterInfo.IsValid = true;
      tmp = ReadConfig("SystemRegister", "BasicName", "");
      if (tmp == "") return false;
      if (ReadDB)
      {
        RegUser = ReadConfig(RegisterInfo.Serial, "RegUser", "");
        RegKey = ReadConfig(RegisterInfo.Serial, "RegKey", "");
      }
      if (tmp == Crypt.StrEncrypt("36891", ProdKey, 0))
        RegisterInfo.StartDate = DateTime.Now.Date;
      else
      {
        double tmpD = 0;
        try
        {
          tmpD = Convert.ToDouble(Crypt.StrDecrypt(tmp, ProdKey));
        }
        catch
        {
          try
          {
            tmpD = Convert.ToDouble(Crypt.StrDecrypt(tmp, C_RegKey));
          }
          catch
          {
          }
        }
        finally
        {
          RegisterInfo.StartDate = DateTime.FromOADate(tmpD);
        }
      }
      tmp = Convert.ToString(RegisterInfo.StartDate.ToOADate());
      tmp = Crypt.StrEncrypt(tmp, ProdKey, 0);
      if (!WriteConfig("SystemRegister", "BasicName", tmp)) return false;
      RegisterInfo.EndDate = RegisterInfo.StartDate.AddDays(90);
      RegisterInfo.IsValid = (RegisterInfo.EndDate < DateTime.Now.Date);
      if (RegKey != "")
      {
        tmp = RegKey;
        string[] tmpS = tmp.Split('-');
        string Key0 = "";
        string Key1 = "";
        string Key2 = "";
        string Key3 = "";
        if (tmpS.Length >= 1) Key0 = tmpS[0];
        if (tmpS.Length >= 2) Key1 = tmpS[1];
        if (tmpS.Length >= 3) Key2 = tmpS[2];
        if (tmpS.Length >= 4) Key3 = tmpS[3];
        if ((Key0 != "") && (Key1 != "") && (Key2 != "") && (Key3 != ""))
        {
          Key0_int = Convert.ToInt32(Key0) * 2;
          if ((IsRightKey(Key0) || IsRightKeyAll(Key0)) && IsRightSoft(Key1) && IsUserKey(RegUser, Key3))
          {
            tmp = Crypt.StrDecrypt(Key2, Key0);
            tmp = tmp.Substring(0, 5);
            DateTime d = new DateTime();
            d = DateTime.FromOADate(Convert.ToDouble(tmp));
            if (Key2 == Crypt.StrEncrypt("36526", Key0, 0))
            {
              RegisterInfo.IsAlways = true;
              RegisterInfo.IsValid = false;
            }
            else
            {
              RegisterInfo.IsValid = (d < DateTime.Now.Date);
            }
            if (!ReadDB)
            {
              if (!WriteConfig(RegisterInfo.Serial, "RegUser", RegUser)) return false;
              if (!WriteConfig(RegisterInfo.Serial, "RegKey", RegKey)) return false;
            }
            RegisterInfo.EndDate = d;
            RegisterInfo.IsTest = false;
            RegisterInfo.RegUser = RegUser;
            RegisterInfo.RegKey = RegKey;
            if (RegisterInfo.RegKey != null) RegisterInfo.MustReg = true;
            ret = true;
          }
        }
      }
      if (RegisterInfo.IsTest)
      {
        if (RegisterInfo.IsValid)
          RegisterInfo.StateText = Pub.GetResText("Main", "IsTest1", "");
        else
          RegisterInfo.StateText = string.Format(Pub.GetResText("Main", "IsTest", ""),
            RegisterInfo.EndDate.ToShortDateString());
      }
      else if (RegisterInfo.IsAlways)
      {
        RegisterInfo.StateText = string.Format(Pub.GetResText("Main", "IsAlways", ""), RegisterInfo.RegUser);
      }
      else
      {
        if (RegisterInfo.IsValid)
          RegisterInfo.StateText = string.Format(Pub.GetResText("Main", "IsValid", ""), RegisterInfo.RegUser);
        else
          RegisterInfo.StateText = string.Format(Pub.GetResText("Main", "IsAlways", ""), RegisterInfo.RegUser);
        RegisterInfo.RegDateText = string.Format(Pub.GetResText("Main", "IsValidDate", ""),
          RegisterInfo.RegUser, RegisterInfo.EndDate.ToShortDateString());
      }
      return ret;
    }

    public void CreateAccountTable()
    {
      ExecSQL(Pub.GetSQL(DBCode.DB_000001, new string[] { "1" }));
      ExecSQL(Pub.GetSQL(DBCode.DB_000001, new string[] { "2" }));
      ExecSQL(Pub.GetSQL(DBCode.DB_000001, new string[] { "3" }));
      for (int i = 5; i <= 11; i++)
      {
        ExecSQL(Pub.GetSQL(DBCode.DB_000001, new string[] { i.ToString() }), true);
      }
    }

    public override string ToString()
    {
      return ConnStr;
    }

    public void UpdateEmpRegisterData(string EmpSysID, int BakNo, string Data)
    {
      UInt32 x = 0;
      string CardFingerNo = "";
      string sql = "";
      DataTableReader dr = null;
      try
      {
        UInt32.TryParse(Data, out x);
        sql = Pub.GetSQL(DBCode.DB_001003, new string[] { "900", EmpSysID });
        dr = GetDataReader(sql);
        if (dr.Read()) CardFingerNo = dr[0].ToString();
        dr.Close();
        if (CardFingerNo == "") return;
        if (x == 0)
        {
          sql = Pub.GetSQL(DBCode.DB_001003, new string[] { "901", CardFingerNo, BakNo.ToString() });
          ExecSQL(sql);
          if (BakNo == 10)
            sql = Pub.GetSQL(DBCode.DB_001003, new string[] { "902", "0", EmpSysID });
          else
            sql = Pub.GetSQL(DBCode.DB_001003, new string[] { "903", "0", EmpSysID });
          ExecSQL(sql);
        }
        else
        {
          dr = GetDataReader(Pub.GetSQL(DBCode.DB_002001, new string[] { "2008", "3", CardFingerNo, BakNo.ToString() }));
          sql = Pub.GetSQL(DBCode.DB_002001, new string[] { dr.Read() ? "2011" : "2010", "3", CardFingerNo, BakNo.ToString(), "1", "0", "NULL" });
          dr.Close();
          ExecSQL(sql);
          sql = Pub.GetSQL(DBCode.DB_002001, new string[] { "2012", "3", CardFingerNo, BakNo.ToString() });
          if (BakNo == 10)
          {
            UpdateByteData(sql, "FaceTemplate", EncAndDec.getPWD(Data));
            sql = Pub.GetSQL(DBCode.DB_001003, new string[] { "902", "1", EmpSysID });
          }
          else
          {
            UpdateByteData(sql, "FaceTemplate", EncAndDec.getCard(Data));
            sql = Pub.GetSQL(DBCode.DB_001003, new string[] { "903", "1", EmpSysID });
          }
          ExecSQL(sql);
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
    }

    public bool SaveEnrollToDB(UInt32 EnrollNumber, int BackupNumber, int EnableFlag, int Privilege, int PasswordData,
      byte[] fpData, string EnrollName, ref bool ReqName)
    {
      byte[] buff = new byte[0];
      if (BackupNumber >= (int)FKBackup.BACKUP_FP_0 && BackupNumber <= (int)FKBackup.BACKUP_FP_9)
      {
        buff = new byte[(int)FKMax.FK_FPDataSize];
      }
      else if (BackupNumber == (int)FKBackup.BACKUP_PSW || BackupNumber == (int)FKBackup.BACKUP_CARD)
      {
        buff = new byte[(int)FKMax.FK_PasswordDataSize];
      }
      else if (BackupNumber == (int)FKBackup.BACKUP_FACE)
      {
        buff = new byte[(int)FKMax.FK_FaceDataSize];
      }
      else if (BackupNumber >= (int)FKBackup.BACKUP_PALMVEIN_0 && BackupNumber <= (int)FKBackup.BACKUP_PALMVEIN_3)
      {
        buff = new byte[(int)FKMax.PALMVEINDataSize];
      }
      else if (BackupNumber == (int)FKBackup.BACKUP_VEIN_0)
      {
        buff = new byte[(int)FKMax.FK_VeinDataSize];
      }
      Array.Copy(fpData, buff, buff.Length);
      ReqName = false;
      bool ret = false;
      DataTableReader dr = null;
      string EmpSysID = "";
      string EmpNo = "";
      List<string> sql = new List<string>();
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "5", EnrollNumber.ToString() }));
        if (dr.Read()) EmpSysID = dr["EmpSysID"].ToString();
        dr.Close();
        if (EmpSysID == "")
        {
          if (!GetServerGUID(ref EmpSysID)) return false;
          EmpNo = GetAutoEmpNo();
          ReqName = true;
          if (EmpNo == "") EmpNo = EnrollNumber.ToString();
          string CardTypeSysID = "";
          dr = GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "204", "0" }));
          if (dr.Read()) CardTypeSysID = dr["CardTypeSysID"].ToString();
          dr.Close();
          sql.Add(Pub.GetSQL(DBCode.DB_001003, new string[] { "8", EmpSysID, EmpNo, EnrollName, "", CardTypeSysID, 
            SystemInfo.CommanySysID, DateTime.Now.ToString(SystemInfo.SQLDateFMT), "", "", "", "", "", "Y", "", 
            Privilege.ToString() }));
          sql.Add(Pub.GetSQL(DBCode.DB_001003, new string[] { "242", EnrollNumber.ToString(), EmpSysID }));
        }
        else
          sql.Add(Pub.GetSQL(DBCode.DB_002001, new string[] { "2009", Privilege.ToString(), EmpSysID }));
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_002001, new string[] { "2008", "3", EnrollNumber.ToString(), 
          BackupNumber.ToString() }));
        sql.Add(Pub.GetSQL(DBCode.DB_002001, new string[] { dr.Read() ? "2011" : "2010", "3", 
          EnrollNumber.ToString(), BackupNumber.ToString(), EnableFlag.ToString(), Privilege.ToString(), "NULL" }));
        dr.Close();
        if (ExecSQL(sql) == 0)
        {
          UpdateByteData(Pub.GetSQL(DBCode.DB_002001, new string[] { "2012", "3", EnrollNumber.ToString(), 
            BackupNumber.ToString() }), "FaceTemplate", buff);
        }
        ret = true;
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
      return ret;
    }

    public void SaveEmpNameByFinger(UInt32 FingerNo, string EmpName)
    {
      string sql = Pub.GetSQL(DBCode.DB_001003, new string[] { "706", FingerNo.ToString(), EmpName });
      try
      {
        ExecSQL(sql);
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E, sql);
      }
    }

    public bool SFGetLastSFType(string EmpSysID, ref string SFTypeName, ref double SFAmount)
    {
      bool ret = false;
      SFTypeName = "";
      SFAmount = 0;
      DataTableReader dr = null;
      try
      {
        switch (_DBType)
        {
          case 1:
          case 2:
            dr = GetDataReader("SELECT TOP 1 SFTypeName,SFAmount FROM VSF_SFData WHERE EmpSysID='" + EmpSysID +
              "' AND (SFTypeID=10 OR SFTypeID IN(SELECT DepositTypeID FROM SF_DepositType)) " +
              "ORDER BY CardUseTimes DESC");
            break;
        }
        ret = true;
        if (dr.Read())
        {
          SFTypeName = dr["SFTypeName"].ToString();
          double.TryParse(dr["SFAmount"].ToString(), out SFAmount);
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
      return ret;
    }

    public string GetDatabaseSpace(string dbname)
    {
      string ret = "";
      string sql = "";
      DataTableReader dr = null;
      try
      {
        switch (_DBType)
        {
          case 1:
          case 2:
            sql = "DECLARE @pages int,@dbname sysname,@dbsize dec(15,0),@logsize dec(15),@bytesperpage dec(15,0),@pagesperMB dec(15,0)\r\n";
            sql += "SELECT @dbsize=SUM(CONVERT(dec(15),size)) FROM sysfiles WHERE status&64=0\r\n";
            sql += "SELECT @logsize=SUM(CONVERT(dec(15),size)) FROM sysfiles WHERE status&64<>0\r\n";
            sql += "SELECT @bytesperpage=low FROM master.dbo.spt_values WHERE number=1 AND type='E'\r\n";
            sql += "SELECT @pagesperMB=1048576/@bytesperpage\r\n";
            sql += "SELECT database_name=db_name(),database_size=LTRIM(STR((@dbsize+@logsize)/@pagesperMB,15,2)+' MB'),\r\n";
            sql += "  unallocated_space=LTRIM(STR((@dbsize-(SELECT SUM(CONVERT(dec(15),reserved))\r\n";
            sql += "  FROM sysindexes WHERE indid IN(0,1,255)))/@pagesperMB,15,2)+' MB')\r\n";
            dr = GetDataReader(sql);
            if (dr.Read()) ret = dr[1].ToString();
            break;
        }
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E, sql);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      return ret;
    }

    public bool CheckAppIsNewVer(string DBAppVer)
    {
      return CheckAppIsNewVer(false, DBAppVer);
    }

    public bool CheckAppIsNewVer(bool CheckRevision, string DBAppVer)
    {
      bool ret = false;
      string[] tmp1 = Application.ProductVersion.Split('.');
      string[] tmp2 = DBAppVer.Split('.');
      if (tmp2.Length == 3)
      {
        if (CheckRevision)
        {
          if ((Convert.ToUInt32(tmp1[0]) >= Convert.ToUInt32(tmp2[0])) &&
            (Convert.ToUInt32(tmp1[1]) >= Convert.ToUInt32(tmp2[1])))
          {
            if (Convert.ToUInt32(tmp1[2]) >= Convert.ToUInt32(tmp2[2])) ret = true;
          }
          else if ((Convert.ToUInt32(tmp1[0]) >= Convert.ToUInt32(tmp2[0])) &&
            (Convert.ToUInt32(tmp1[1]) >= Convert.ToUInt32(tmp2[1])))
            ret = true;
          else if (Convert.ToUInt32(tmp1[0]) >= Convert.ToUInt32(tmp2[0]))
          {
            if (Convert.ToUInt32(tmp1[1]) >= Convert.ToUInt32(tmp2[1])) ret = true;
          }
        }
        else
        {
          if ((Convert.ToUInt32(tmp1[0]) >= Convert.ToUInt32(tmp2[0])) &&
            (Convert.ToUInt32(tmp1[1]) >= Convert.ToUInt32(tmp2[1])) &&
            (Convert.ToUInt32(tmp1[2]) > Convert.ToUInt32(tmp2[2])))
            ret = true;
          else if ((Convert.ToUInt32(tmp1[0]) >= Convert.ToUInt32(tmp2[0])) &&
            (Convert.ToUInt32(tmp1[1]) > Convert.ToUInt32(tmp2[1])))
            ret = true;
          else if (Convert.ToUInt32(tmp1[0]) > Convert.ToUInt32(tmp2[0]))
            ret = true;
        }
      }
      else if (!CheckRevision)
        ret = true;
      return ret;
    }

    public bool GetCheckIsOrder(ref QHKS.TCheckIsOrder IsOrder)
    {
      bool ret = false;
      DataTableReader dr = null;
      IsOrder = new QHKS.TCheckIsOrder();
      IsOrder.Check = new byte[256];
      IsOrder.Refundment = new byte[256];
      byte TypeID, CheckOrder, Refundment;
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "203" }));
        while (dr.Read())
        {
          TypeID = Convert.ToByte(dr["CardTypeID"]);
          CheckOrder = Convert.ToByte(dr["CardCheckOrder"]);
          Refundment = Convert.ToByte(dr["CardRefundmentDev"]);
          IsOrder.Check[TypeID] = CheckOrder;
          IsOrder.Refundment[TypeID] = Refundment;
        }
        ret = true;
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
      return ret;
    }

    public bool GetForwardState()
    {
      bool ret = false;
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { }));
        if (dr.Read()) ret = (dr[0].ToString() == "Y");
      }
      catch
      {
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      return ret;
    }

    public void CheckSFDataCount()
    {
      if (GetForwardState()) return;
      int sfCount = 0;
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "2001" }));
        if (dr.Read()) sfCount = Convert.ToInt32(dr[0].ToString());
      }
      catch
      {
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      const int maxCount = 200000;
      if (sfCount > maxCount)
      {
        string msg = string.Format(Pub.GetResText("", "InfoSFDataCountIsBig", ""), maxCount);
        Pub.MessageBoxShow(msg);
      }
    }

    public byte GetDiscDiscount(double DiscMoney, int CardTypeID, ref double DiscountMoney)
    {
      byte ret = 0;
      DiscountMoney = 0;
      DataTableReader dr = null;
      string sql = Pub.GetSQL(DBCode.DB_001001, new string[] { "106", CardTypeID.ToString(), DiscMoney.ToString() });
      try
      {
        dr = GetDataReader(sql);
        if (dr.Read())
        {
          double.TryParse(dr[0].ToString(), out DiscountMoney);
          ret = 1;
        }
        else
        {
          dr.Close();
          sql = Pub.GetSQL(DBCode.DB_001001, new string[] { "107", CardTypeID.ToString(), DiscMoney.ToString() });
          dr = GetDataReader(sql);
          if (dr.Read())
          {
            double.TryParse(dr[0].ToString(), out DiscountMoney);
            ret = 1;
          }
          else
          {
            dr.Close();
            sql = Pub.GetSQL(DBCode.DB_001001, new string[] { "108", CardTypeID.ToString(), DiscMoney.ToString() });
            dr = GetDataReader(sql);
            if (dr.Read())
            {
              double.TryParse(dr[0].ToString(), out DiscountMoney);
              ret = 1;
            }
          }
        }
      }
      catch (Exception E)
      {
        ret = 2;
        Pub.ShowErrorMsg(E, sql);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      return ret;
    }

    public bool GetDiscHint(ref string DiscHint)
    {
      bool ret = false;
      DiscHint = "";
      DataTableReader dr = null;
      string sql = Pub.GetSQL(DBCode.DB_001001, new string[] { "101" });
      byte CardTypeID = 0;
      byte ID = 0;
      string CardTypeName = "";
      double DiscStart = 0;
      double DiscEnd = 0;
      double DiscMoney = 0;
      string S = Pub.GetResText("SFDeposit", "DiscHintA", "");
      string S1 = "";
      bool IsFirst = true;
      try
      {
        dr = GetDataReader(sql);
        while (dr.Read())
        {
          byte.TryParse(dr["CardTypeID"].ToString(), out ID);
          CardTypeName = dr["CardTypeName"].ToString();
          double.TryParse(dr["DiscStart"].ToString(), out DiscStart);
          double.TryParse(dr["DiscEnd"].ToString(), out DiscEnd);
          double.TryParse(dr["DiscDiscount"].ToString(), out DiscMoney);
          if (DiscEnd == 0)
            S1 = string.Format(S, ">" + DiscStart.ToString(SystemInfo.CurrencySymbol + "0.00"),
              DiscMoney.ToString(SystemInfo.CurrencySymbol + "0.00"));
          else if (DiscStart == DiscEnd)
            S1 = string.Format(S, "=" + DiscStart.ToString(SystemInfo.CurrencySymbol + "0.00"),
              DiscMoney.ToString(SystemInfo.CurrencySymbol + "0.00"));
          else
            S1 = string.Format(S, ">" + DiscStart.ToString(SystemInfo.CurrencySymbol + "0.00") +
              " <=" + DiscEnd.ToString(SystemInfo.CurrencySymbol + "0.00"),
              DiscMoney.ToString(SystemInfo.CurrencySymbol + "0.00"));
          if (IsFirst || CardTypeID != ID)
            DiscHint += "[" + ID.ToString() + "]" + CardTypeName + ": \r\n    " + S1 + "\r\n";
          else
            DiscHint += "    " + S1 + "\r\n";
          IsFirst = false;
          CardTypeID = ID;
        }
        if (DiscHint == "") DiscHint = Pub.GetResText("SFDeposit", "DiscHintB", "");
        ret = true;
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E, sql);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      return ret;
    }

    public void MobileCancelOrdSave(string CardID, string Detail)
    {
      string sql = Pub.GetSQL(DBCode.DB_000001, new string[] { "5001", CardID, Detail });
      try
      {
        ExecSQL(sql);
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E, sql);
      }
    }

    public bool CheckDepositLimit(string EmpSysID, double LimitMoney, int LimitTimes, double Deposit)
    {
      if (LimitMoney == 0 && LimitTimes == 0) return true;
      bool ret = false;
      string sql = Pub.GetSQL(DBCode.DB_004013, new string[] { "200", EmpSysID });
      DataTableReader dr = null;
      try
      {
        dr = GetDataReader(sql);
        if (dr.Read())
        {
          double m = 0;
          int i = 0;
          double.TryParse(dr["SFAmount"].ToString(), out m);
          int.TryParse(dr["Times"].ToString(), out i);
          if (LimitMoney > 0 && (m >= LimitMoney || m + Deposit > LimitMoney))
          {
            Pub.MessageBoxShow(string.Format(Pub.GetResText("", "ErrorCardDepositLimit", ""), LimitMoney));
          }
          else if (LimitTimes > 0 && (i >= LimitTimes || i + 1 > LimitTimes))
          {
            Pub.MessageBoxShow(string.Format(Pub.GetResText("", "ErrorCardDepositTimes", ""), LimitTimes));
          }
          else
          {
            ret = true;
          }
        }
        else
        {
          ret = true;
        }
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E, sql);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      return ret;
    }
  }

  public class FuncSubObject
  {
    private string _text = "";
    private string _name = "";
    private byte _IsLine = 0;

    public string Text
    {
      get { return _text; }
      set { _text = value; }
    }

    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }

    public byte IsLine
    {
      get { return _IsLine; }
      set { _IsLine = value; }
    }
  }

  public class FuncObject
  {
    private string _text = "";
    private string _name = "";
    private System.Collections.ArrayList list = new System.Collections.ArrayList();

    public string Text
    {
      get { return _text; }
      set { _text = value; }
    }

    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }

    public int SubCount
    {
      get { return list.Count; }
    }

    public void SubAdd(string Name, string Text, byte IsLine)
    {
      FuncSubObject obj = new FuncSubObject();
      obj.Name = Name;
      obj.Text = Text;
      obj.IsLine = IsLine;
      list.Add(obj);
    }

    public FuncSubObject SubGet(int Index)
    {
      FuncSubObject obj = new FuncSubObject();

      if ((list.Count > 0) && (Index < list.Count)) obj = (FuncSubObject)list[Index];
      return obj;
    }
  }

  public class CryptED
  {
    private readonly int C_1 = 42594;
    private readonly int C_2 = 14712;

    private string ByteToHex(byte b)
    {
      string ret = Convert.ToString(b, 16);
      while (ret.Length < 2) ret = "0" + ret;
      ret = ret.ToUpper();
      return ret;
    }

    private byte IntToByte(int src)
    {
      while ((src > 255) || (src < 0)) src = src & 0xff;
      return Convert.ToByte(src);
    }

    private byte StrToByte(string s)
    {
      char c = Convert.ToChar(s);
      int i = Convert.ToInt32(c);
      byte b = IntToByte(i);
      return b;
    }

    private byte StrToByte(char c)
    {
      byte b = Convert.ToByte(c);
      return b;
    }

    private string StringToBCD(string StrIn)
    {
      string ret = "";
      int Len = StrIn.Length;
      for (int I = 0; I < Len; I++)
      {
        string s = StrIn.Substring(I, 1);
        ret += ByteToHex(StrToByte(s));
      }
      return ret;
    }

    private string Encrypt(string StrIn, int Key)
    {
      string ret = "";
      int Len = StrIn.Length;
      for (int I = 0; I < Len; I++)
      {
        string s = StrIn.Substring(I, 1);
        byte b = StrToByte(s);
        b = (byte)(b ^ (Key >> 8));
        s = Convert.ToChar(b).ToString();
        ret += s;
        Key = (b + Key) * C_1 + C_2;
      }
      return ret;
    }

    private string StringEncryptToBCD(string StrIn, int Key)
    {
      return StringToBCD(Encrypt(StrIn, Key));
    }

    public string StrEncrypt(string src, string Key, int Len)
    {
      if (Len > 0) while (src.Length < Len) src = "0" + src;
      if (src == "") return "";
      int key = 0;
      for (int i = 0; i < Key.Length; i++) key = key + StrToByte(Key[i]);
      return StringEncryptToBCD(src, key);
    }

    public string StrEncrypt(string src, int Key)
    {
      if (src == "") return "";
      return StringEncryptToBCD(src, Key);
    }

    private int CharToInt(string c)
    {
      c = c.ToUpper();
      if ((c == "0") || (c == "1") || (c == "2") || (c == "3") || (c == "4") || (c == "5") ||
        (c == "6") || (c == "7") || (c == "8") || (c == "9"))
        return Convert.ToByte(Convert.ToChar(c)) - 48;
      else if ((c == "A") || (c == "B") || (c == "C") || (c == "D") || (c == "E") || (c == "F"))
        return Convert.ToByte(Convert.ToChar(c)) - 55;
      else
        return 0;
    }

    private string BCDToString(string StrIn)
    {
      string ret = "";
      int Len = StrIn.Length / 2;
      for (int I = 0; I < Len; I++)
      {
        string s = StrIn.Substring(I * 2, 1);
        int i1 = CharToInt(s) * 16;
        s = StrIn.Substring(I * 2 + 1, 1);
        int i2 = CharToInt(s);
        byte b = (byte)(i1 + i2);
        s = Convert.ToChar(b).ToString();
        ret += s;
      }
      return ret;
    }

    private string Decrypt(string StrIn, int Key)
    {
      string ret = "";
      int Len = StrIn.Length;
      for (int I = 0; I < Len; I++)
      {
        string s = StrIn.Substring(I, 1);
        byte b = StrToByte(s);
        byte b1 = (byte)(b ^ (Key >> 8));
        s = Convert.ToChar(b1).ToString();
        ret += s;
        Key = (b + Key) * C_1 + C_2;
      }
      return ret;
    }

    private string StringDecryptFromBCD(string StrIn, int Key)
    {
      return Decrypt(BCDToString(StrIn), Key);
    }

    public string StrDecrypt(string src, string Key)
    {
      int key = 0;
      for (int i = 0; i < Key.Length; i++) key = key + StrToByte(Key[i]);
      return StringDecryptFromBCD(src, key);
    }

    public string StrDecrypt(string src, int Key)
    {
      return StringDecryptFromBCD(src, Key);
    }
  }

  public class TCommPort
  {
    private int _CommIndex;
    private string _CommName;

    public TCommPort(int Index, string Name)
    {
      _CommIndex = Index;
      _CommName = Name;
    }

    public int CommIndex
    {
      get { return _CommIndex; }
      set { _CommIndex = value; }
    }

    public string CommName
    {
      set { _CommName = value; }
    }

    public override string ToString()
    {
      return _CommName;
    }
  }

  public class TSFMacType
  {
    private int _id;
    private string _name;

    public TSFMacType(int id, string name)
    {
      _id = id;
      _name = name;
    }

    public int id
    {
      get { return _id; }
      set { _id = value; }
    }

    public string name
    {
      get { return _name; }
      set { _name = value; }
    }

    public override string ToString()
    {
      return _name;
    }
  }

  public class TCardType
  {
    private string _sysid;
    private int _id;
    private string _name;

    public TCardType(string sysID, int id, string name)
    {
      _sysid = sysID;
      _id = id;
      _name = name;
    }

    public string sysID
    {
      get { return _sysid; }
      set { _sysid = value; }
    }

    public int id
    {
      get { return _id; }
      set { _id = value; }
    }

    public string name
    {
      get { return _name; }
      set { _name = value; }
    }

    public override string ToString()
    {
      return _name;
    }
  }

  public class TCommonType
  {
    private string _sysid;
    private string _id;
    private string _name;
    private bool _hideID;

    public TCommonType(string sysID, string id, string name)
    {
      _sysid = sysID;
      _id = id;
      _name = name;
    }

    public TCommonType(string sysID, string id, string name, bool HideID)
    {
      _sysid = sysID;
      _id = id;
      _name = name;
      _hideID = HideID;
    }

    public string sysID
    {
      get { return _sysid; }
      set { _sysid = value; }
    }

    public string id
    {
      get { return _id; }
      set { _id = value; }
    }

    public string name
    {
      get { return _name; }
      set { _name = value; }
    }

    public override string ToString()
    {
      if (_hideID || (_id == ""))
        return _name;
      else
        return "[" + _id + "]" + _name;
    }
  }

  public class TIDAndName
  {
    private string _id;
    private string _name;

    public TIDAndName(string id, string name)
    {
      _id = id;
      _name = name;
    }

    public string id
    {
      get { return _id; }
      set { _id = value; }
    }

    public string name
    {
      get { return _name; }
      set { _name = value; }
    }

    public override string ToString()
    {
      return _name;
    }
  }

  public class TRealSocket
  {
    public delegate void ReadSocketData(string SocketData);
    private Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
    private bool RunningFlag = false;
    private ReadSocketData ReadSocket;
    private bool IsSend = false;

    public TRealSocket(int Port, ReadSocketData readData)
    {
      ReadSocket = readData;
      IPAddress UdpIP = null;
      IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
      foreach (IPAddress ipa in ips)
      {
        if (ipa.AddressFamily == AddressFamily.InterNetwork)
        {
          UdpIP = ipa;
          break;
        }
      }
      IPEndPoint ipLocalPoint;
      if (UdpIP == null)
        ipLocalPoint = new IPEndPoint(IPAddress.Any, Port);
      else
        ipLocalPoint = new IPEndPoint(UdpIP, Port);
      sock.Bind(ipLocalPoint);
      RunningFlag = true;
    }

    ~TRealSocket()
    {
      Stop();
    }

    public void Start()
    {
      ReceiveHandle();
    }

    public void Stop()
    {
      RunningFlag = false;
      if (sock != null) sock.Close();
      sock = null;
    }

    public void Send(string data)
    {
      try
      {
        int size = data.Length / 2;
        byte[] s = new byte[size];
        for (int i = 0; i < size; i++)
        {
          s[i] = Convert.ToByte(data.Substring(i * 2, 2), 16);
        }
        sock.Send(s);
      }
      catch
      {
      }
    }

    private string ByteToHex(byte byt)
    {
      string ret = Convert.ToString(byt, 16);
      while (ret.Length < 2)
      {
        ret = "0" + ret;
      }
      return ret.ToUpper();
    }

    private void ReceiveHandle()
    {
      string msg;
      byte[] data = new byte[1024];
      while (RunningFlag)
      {
        try
        {
          if (sock == null || sock.Available < 1)
          {
            Application.DoEvents();
            continue;
          }
          if (IsSend)
          {
            Application.DoEvents();
            continue;
          }
          IsSend = true;
          int len = sock.Receive(data);
          msg = "";
          for (int i = 0; i < len; i++)
          {
            msg += ByteToHex(data[i]);
          }
          ReadSocket(msg);
          IsSend = false;
        }
        catch
        {
          IsSend = false;
        }
      }
    }
  }

  public class TConnInfoFinger
  {
    private int _MacSN = 0;
    private string _MacSN_GPRS = "";
    private byte _MacType = 0;
    private byte _ConnType = 0;
    private byte _CommPort = 0;
    private int _CommBaudrate = 0;
    private string _NetIP = "";
    private int _NetPort = 0;
    private int _NetPassword = 0;
    private byte _ProtocolType = 0;
    private bool _IsGPRS = false;

    public int MacSN
    {
      get { return _MacSN; }
      set { _MacSN = value; }
    }

    public string MacSN_GPRS
    {
      get { if (_IsGPRS)return _MacSN_GPRS; else return _MacSN.ToString(); }
      set { _MacSN_GPRS = value; }
    }

    public byte MacType
    {
      get { return _MacType; }
      set { _MacType = value; }
    }

    public byte ConnType
    {
      get { return _ConnType; }
      set { _ConnType = value; }
    }

    public byte CommPort
    {
      get { return _CommPort; }
      set { _CommPort = value; }
    }

    public int CommBaudrate
    {
      get { return _CommBaudrate; }
      set { _CommBaudrate = value; }
    }

    public string NetIP
    {
      get { return _NetIP; }
      set { _NetIP = value; }
    }

    public int NetPort
    {
      get { return _NetPort; }
      set { _NetPort = value; }
    }

    public int NetPassword
    {
      get { return _NetPassword; }
      set { _NetPassword = value; }
    }

    public bool IsGPRS
    {
      get { return _IsGPRS; }
      set { _IsGPRS = value; }
    }

    public byte ProtocolType
    {
      get { return _ProtocolType; }
      set { _ProtocolType = value; }
    }
  }

  public class TConnInfoNewMJ
  {
    private UInt32 _MacSN = 0;
    private string _ConnType = "";
    private string _CommPort = "";
    private UInt32 _CommBaudrate = 0;
    private string _NetIP = "";
    private UInt32 _NetPort = 0;

    public UInt32 MacSN
    {
      get { return _MacSN; }
      set { _MacSN = value; }
    }

    public string ConnType
    {
      get { return _ConnType; }
      set { _ConnType = value; }
    }

    public string CommPort
    {
      get { return _CommPort; }
      set { _CommPort = value; }
    }

    public UInt32 CommBaudrate
    {
      get { return _CommBaudrate; }
      set { _CommBaudrate = value; }
    }

    public string NetIP
    {
      get { return _NetIP; }
      set { _NetIP = value; }
    }

    public UInt32 NetPort
    {
      get { return _NetPort; }
      set { _NetPort = value; }
    }
  }

  public class EncAndDec
  {
    private static UInt32 gPassEncryptKey;

    public static byte[] getPWD(string pwd)
    {
      //PWD_HS1:  IDC_HS1:;
      byte[] bpwd = new byte[(int)FKMax.FK_PasswordDataSize];
      byte[] head = Encoding.ASCII.GetBytes("PWD_HS1:");
      byte[] spwd = Encoding.ASCII.GetBytes(pwd);
      byte[] temp = new byte[32 - spwd.Length];
      byte[] mpwd = MergerArray(spwd, temp);
      temp = new byte[32];
      FKHS3760_EncryptPwd(ref mpwd, ref temp, 32);
      bpwd = MergerArray(head, temp);
      return bpwd;
    }

    public static byte[] getCard(string card)
    {
      Int64 tmp = Convert.ToInt64(card);
      if (tmp > int.MaxValue)
      {
        tmp = tmp - 0xffffffff - 1;
        card = tmp.ToString();
      }
      //PWD_HS1:  IDC_HS1:;
      byte[] bcard = new byte[(int)FKMax.FK_PasswordDataSize];
      byte[] head = Encoding.ASCII.GetBytes("IDC_HS1:");
      byte[] scard = Encoding.ASCII.GetBytes(card);
      byte[] temp = new byte[32 - scard.Length];
      byte[] mcard = MergerArray(scard, temp);
      bcard = MergerArray(head, mcard);
      return bcard;
    }

    private static byte[] MergerArray(byte[] First, byte[] Second)
    {
      byte[] result = new byte[First.Length + Second.Length];
      First.CopyTo(result, 0);
      Second.CopyTo(result, First.Length);
      return result;
    }

    private static void FKHS3760_EncryptPwd(ref byte[] apOrgPwdData, ref byte[] apEncPwdData, int aPwdLen)
    {
      int i;

      gPassEncryptKey = 12415;
      for (i = 0; i < aPwdLen; i++)
        apEncPwdData[i] = Encrypt_1Byte(apOrgPwdData[i]);
    }

    private static byte Encrypt_1Byte(byte aByteData)
    {
      UInt32 U0 = 28904;
      UInt32 U1 = 35756;
      byte vCrytData;

      vCrytData = (byte)(aByteData ^ (byte)(gPassEncryptKey >> 8));
      gPassEncryptKey = (vCrytData + gPassEncryptKey) * U0 + U1;
      return vCrytData;
    }

    private static void FKHS3760_DecryptPwd(byte[] apEncPwdData, ref byte[] apOrgPwdData, int aPwdLen)
    {
      int i;

      gPassEncryptKey = 12415;
      for (i = 0; i < aPwdLen; i++)
        apOrgPwdData[i] = Decrypt_1Byte(apEncPwdData[i]);
    }

    private static byte Decrypt_1Byte(byte aByteData)
    {
      UInt32 U0 = 28904;
      UInt32 U1 = 35756;
      byte vCrytData;

      vCrytData = (byte)(aByteData ^ (byte)(gPassEncryptKey >> 8));
      gPassEncryptKey = (aByteData + gPassEncryptKey) * U0 + U1;
      return vCrytData;
    }

    public static void PWDAndCard(int BackupNumber, byte[] buff, ref string No)
    {
      No = "";
      if ((BackupNumber == (int)FKBackup.BACKUP_PSW || BackupNumber == (int)FKBackup.BACKUP_CARD) && buff.Length == (int)FKMax.FK_PasswordDataSize)
      {
        byte[] mbytCurEnrollData = new byte[(int)FKMax.FK_PasswordDataSize];
        Array.Copy(buff, mbytCurEnrollData, mbytCurEnrollData.Length);
        byte[] head = new byte[8];
        byte[] data = new byte[mbytCurEnrollData.Length - 8];
        string strhead = "";
        int len = mbytCurEnrollData.Length;
        for (int i = 0; i < mbytCurEnrollData.Length; i++)
        {
          if (mbytCurEnrollData[i] == 0)
          {
            len = i - 8;
            break;
          }
          if (i < 8)
          {
            head[i] = mbytCurEnrollData[i];
            if (i == 7) strhead = Encoding.ASCII.GetString(head);
          }
          else
          {
            data[i - 8] = mbytCurEnrollData[i];
          }
        }
        if (len < 1) return;
        byte[] tdata = new byte[len];
        Array.Copy(data, tdata, data.Length < tdata.Length ? data.Length : tdata.Length);
        if (strhead.StartsWith("IDC"))
        {
          bool isZero = false;
          for (int i = 0; i < tdata.Length; i++)
          {
            if (tdata[i] == 0) isZero = true;
            if (isZero) tdata[i] = 0;
          }
          No = Encoding.ASCII.GetString(tdata);
          Int64 tmp = Convert.ToInt64(No);
          if (tmp < 0)
          {
            tmp = 0xffffffff + tmp + 1;
            No = tmp.ToString();
          }
        }
        else if (strhead.StartsWith("PWD"))
        {
          byte[] pwd = new byte[tdata.Length];
          EncAndDec.FKHS3760_DecryptPwd(tdata, ref pwd, pwd.Length);
          bool isZero = false;
          for (int i = 0; i < pwd.Length; i++)
          {
            if (pwd[i] == 0) isZero = true;
            if (isZero) pwd[i] = 0;
          }
          No = Encoding.ASCII.GetString(pwd).Replace("\0", "");
        }
      }
    }
  }

  public class TRealSend
  {
    private Type typReal = null;
    private object objReal = null;

    public TRealSend()
    {
      try
      {
        typReal = Type.GetTypeFromProgID("RealSend.Send");
        if (typReal != null) objReal = Activator.CreateInstance(typReal);
      }
      catch
      {
      }
    }

    public bool IsInit
    {
      get { return typReal != null && objReal != null; }
    }

    public bool SendEmpPhoto()
    {
      if (typReal == null || objReal == null) return false;
      try
      {
        object[] args = new object[0];
        return (bool)typReal.InvokeMember("SendEmpPhoto", BindingFlags.GetProperty, null, objReal, args);
      }
      catch
      {
        return false;
      }
    }

    public void ShowSetupKQ()
    {
      if (typReal == null || objReal == null) return;
      try
      {
        object[] args = new object[] { SystemInfo.MainHandle.ToInt32() };
        typReal.InvokeMember("ShowSetupSF", BindingFlags.InvokeMethod, null, objReal, args);
      }
      catch
      {
      }
    }

    public void SendDataKQ(string MacSN, string EmpNo, string EmpName, string DeptID, string DeptName, string CardID, DateTime CardTime, string PhotoData)
    {
      if (typReal == null || objReal == null) return;
      try
      {
        object[] args = new object[] { MacSN, EmpNo, EmpName, DeptID, DeptName, CardID, CardTime, PhotoData };
        typReal.InvokeMember("SendDataKQ", BindingFlags.InvokeMethod, null, objReal, args);
      }
      catch
      {
      }
    }

    public void ShowSetupSF()
    {
      if (typReal == null || objReal == null) return;
      try
      {
        object[] args = new object[] { SystemInfo.MainHandle.ToInt32() };
        typReal.InvokeMember("ShowSetupSF", BindingFlags.InvokeMethod, null, objReal, args);
      }
      catch
      {
      }
    }

    public void SendDataSF(string MacSN, string EmpNo, string EmpName, string DeptID, string DeptName, string CardID, DateTime SFDate, string SFType,
      string MealType, double SFAmount, double Balance, string PhotoData)
    {
      if (typReal == null || objReal == null) return;
      try
      {
        object[] args = new object[] { MacSN, EmpNo, EmpName, DeptID, DeptName, CardID, SFDate, SFType, MealType, SFAmount, Balance, PhotoData };
        typReal.InvokeMember("SendDataSF", BindingFlags.InvokeMethod, null, objReal, args);
      }
      catch
      {
      }
    }
  }
}