using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Net;
using Newtonsoft.Json;

namespace ECard78
{
    public enum FKRun
    {
        RUN_SUCCESS = 1,
        RUNERR_NOSUPPORT = 0,
        RUNERR_UNKNOWNERROR = -1,
        RUNERR_NO_OPEN_COMM = -2,
        RUNERR_WRITE_FAIL = -3,
        RUNERR_READ_FAIL = -4,
        RUNERR_INVALID_PARAM = -5,
        RUNERR_NON_CARRYOUT = -6,
        RUNERR_DATAARRAY_END = -7,
        RUNERR_DATAARRAY_NONE = -8,
        RUNERR_MEMORY = -9,
        RUNERR_MIS_PASSWORD = -10,
        RUNERR_MEMORYOVER = -11,
        RUNERR_DATADOUBLE = -12,
        RUNERR_MANAGEROVER = -14,
        RUNERR_FPDATAVERSION = -15,
        RUNERR_LOGINOUTMODE = -16
    }

    public enum FKMax
    {
        MAX_BELLCOUNT_DAY = 24,
        MAX_PASSCTRLGROUP_COUNT = 50,
        MAX_PASSCTRL_COUNT = 7,         // Pass Count Max Value
        MAX_USERPASSINFO_COUNT = 3,
        MAX_GROUPPASSKIND_COUNT = 5,
        MAX_GROUPPASSINFO_COUNT = 3,
        MAX_GROUPMATCHINFO_COUNT = 10,
        MAX_PASSTIMECOUNT = 6,          //Pass Count Max Value
        MAX_TIMEGROUP = 255,            //Time Group
        MAX_RECORDTIMEINFO_COUNT = 6,   //Record Time

        MAX_REAL_TIME = 4,
        MAX_SHIFTCOUNT = 24,
        MAX_POSTCOUNT = 16,
        MAX_SHIFTDAY = 32,

        TIME_SLOT_COUNT = 6,
        TIME_ZONE_COUNT = 255,
        SIZE_TIME_ZONE_STRUCT = 32,
        SIZE_USER_WEEK_PASS_TIME_STRUCT = 16,

        FK_PasswordDataSize = 40,
        FK_FPDataSize = 1680,
        FK_FaceDataSize = 20080,
        FK_VeinDataSize = 3080,
        FK_PhotoDataSize = 15000,
        PALMVEINDataSize = 20080,
        FK_BellSize = MAX_BELLCOUNT_DAY * 3,
        FK_PassSize = 28,

        NAME_BYTE_COUNT = 128,
        USER_INFO_SIZE_V2 = 184,
        USER_INFO_VER2 = 2,
        POST_SHIFT_SIZE_V2 = 2476,
        POST_SHIFT_VER2 = 2,
        MAX_DAY_IN_MONTH = 31,

        SIZE_EXT_CMD_CODE = 56,
        VER_USERDOORINFO_V1 = 2,
        SIZE_USERDOORINFO_V1 = 20
    }

    public enum FKBackup
    {
        BACKUP_FP_0 = 0,                // 被登记的第一个指纹区
        BACKUP_FP_1 = 1,                // Finger 1
        BACKUP_FP_2 = 2,                // Finger 2
        BACKUP_FP_3 = 3,                // Finger 3
        BACKUP_FP_4 = 4,                // Finger 4
        BACKUP_FP_5 = 5,                // Finger 5
        BACKUP_FP_6 = 6,                // Finger 6
        BACKUP_FP_7 = 7,                // Finger 7
        BACKUP_FP_8 = 8,                // Finger 8
        BACKUP_FP_9 = 9,                // 被登记的第十个指纹区
        BACKUP_PSW = 10,                // 被登记密码
        BACKUP_CARD = 11,               // 被登记卡号
        BACKUP_FACE = 12,               // Face
        BACKUP_PALMVEIN_0 = 13,
        BACKUP_PALMVEIN_1 = 14,
        BACKUP_PALMVEIN_2 = 15,
        BACKUP_PALMVEIN_3 = 16,
        BACKUP_VEIN_0 = 20              // Vein 0
    }
    ///<summary>
    ////Manipulation of LogData
    ///</summary>
    public enum FKLog
    {
        //VerifyMode of GeneralLogData
        LOG_FPVERIFY = 1,               //Fp Verify
        LOG_PASSVERIFY = 2,             //Pass Verify
        LOG_CARDVERIFY = 3,             //Card Verify
        LOG_FPPASS_VERIFY = 4,          //Pass+Fp Verify
        LOG_FPCARD_VERIFY = 5,          //Card+Fp Verify
        LOG_PASSFP_VERIFY = 6,          //Pass+Fp Verify
        LOG_CARDFP_VERIFY = 7,          //Card+Fp Verify
        LOG_CARDPASS_VERIFY = 9,        //Card+Pass Verify
        LOG_FACEVERIFY = 20,            //Face Verify
        LOG_FACECARDVERIFY = 21,        //Face+Card Verify
        LOG_FACEPASSVERIFY = 22,        //Face+Pass Verify
        LOG_CARDFACEVERIFY = 23,        //Card+Face Verify
        LOG_PASSFACEVERIFY = 24,        //Pass+Face Verify
                                        //Verify Kind of Device
        VK_NONE = 0,
        VK_FP = 1,
        VK_PASS = 2,
        VK_CARD = 3,
        VK_FACE = 4,
        VK_VEIN = 5,
        VK_IRIS = 6,
        //IOMode of GeneralLogData
        LOG_IOMODE_IN = 0,
        LOG_IOMODE_OUT = 1,
        LOG_IOMODE_OVER_IN = 2,
        LOG_IOMODE_OVER_OUT = 3,
        //DoorMode of GeneralLogData
        LOG_CLOSE_DOOR = 1,                    //Door Close
        LOG_OPEN_HAND = 2,                     //Hand Open
        LOG_PROG_OPEN = 3,                     //Open by PC
        LOG_PROG_CLOSE = 4,                    //Close by PC
        LOG_OPEN_IREGAL = 5,                   //Illegal Open
        LOG_CLOSE_IREGAL = 6,                  //Illegal Close
        LOG_OPEN_COVER = 7,                    //Cover Open
        LOG_CLOSE_COVER = 8,                   //Cover Close
        LOG_OPEN_DOOR = 9,                     //Door Open
        LOG_OPEN_DOOR_THREAT = 10             //Door Open
    }
    //Manipulation of SuperLogData
    public enum FKSLog
    {
        LOG_ENROLL_USER = 3,               // Enroll-User
        LOG_ENROLL_MANAGER = 4,            // Enroll-Manager
        LOG_ENROLL_DELFP = 5,              // FP Delete
        LOG_ENROLL_DELPASS = 6,            // Pass Delete
        LOG_ENROLL_DELCARD = 7,            // Card Delete
        LOG_LOG_ALLDEL = 8,                // LogAll Delete
        LOG_SETUP_SYS = 9,                 // Setup Sys
        LOG_SETUP_TIME = 10,               // Setup Time
        LOG_SETUP_LOG = 11,                // Setup Log
        LOG_SETUP_COMM = 12,               // Setup Comm
        LOG_PASSTIME = 13,                 // Pass Time Set
        LOG_SETUP_DOOR = 14,               // Door Set Log
    };
    ///<summary>
    ////Machine Privilege
    ///</summary>
    public enum FKMP
    {
        MP_NONE = 0,                    // General user
        MP_MANAGER_1 = 1,               // Manager1 : Super Manager
        MP_MANAGER_2 = 2,               // Manager2 : General Manager
        MP_MANAGER_3 = 3                // Manager3 : Capable to register user
    }

    ///<summary>
    ////Index of  GetDeviceStatus
    ///</summary>
    public enum FKDS
    {
        GET_MANAGERS = 1,
        GET_USERS = 2,
        GET_FPS = 3,
        GET_PSWS = 4,
        GET_SLOGS = 5,
        GET_GLOGS = 6,
        GET_ASLOGS = 7,
        GET_AGLOGS = 8,
        GET_CARDS = 9,
        GET_FACES = 10,
        GET_PALMVEINS = 40
    }

    ///<summary>
    ////Index of  GetDeviceInfo
    ///</summary>
    public enum FKDI
    {
        DI_MANAGERS = 1,                // Numbers of Manager
        DI_MACHINENUM = 2,
        DI_LANGAUGE = 3,                // Language
        DI_POWEROFF_TIME = 4,           // Auto-PowerOff Time
        DI_LOCK_CTRL = 5,               // Lock Control
        DI_GLOG_WARNING = 6,            // General-Log Warning
        DI_SLOG_WARNING = 7,            // Super-Log Warning
        DI_VERIFY_INTERVALS = 8,        // Verify Interval Time
        DI_RSCOM_BPS = 9,               // Comm Buadrate
        DI_DATE_SEPARATE = 10,          // Date Separate Symbol
        DI_VERIFY_KIND = 24,            // VerrifyKind
        DI_MULTIUSERS = 77              // MultiUser
    }
    ///<summary>
    ////Baudrate = value of DI_RSCOM_BPS
    ///</summary>
    public enum FKBPS
    {
        BPS_9600 = 3,
        BPS_19200 = 4,
        BPS_38400 = 5,
        BPS_57600 = 6,
        BPS_115200 = 7
    }
    ///<summary>
    ////Product Data Index
    ///</summary>
    public enum FKProduct
    {
        PRODUCT_SERIALNUMBER = 1,       // Serial Number
        PRODUCT_BACKUPNUMBER = 2,       // Backup Number
        PRODUCT_CODE = 3,               // Product code
        PRODUCT_NAME = 4,               // Product name
        PRODUCT_WEB = 5,                // Product web
        PRODUCT_DATE = 6,               // Product date
        PRODUCT_SENDTO = 7              // Product sendto
    }
    ///<summary>
    ////Door Status
    ///</summary>
    public enum FKDoor
    {
        DOOR_CONTROLRESET = 0,          // 机器的门控制状态
        DOOR_OPEND = 1,                 // 门已开
        DOOR_CLOSED = 2,                // 门已关
        DOOR_COMMNAD = 3                // 按照门控制指令，门开了后过一段时间自动关门
    }

    public enum ConnType
    {
        USB,
        Comm,
        TCPIP
    }

    public struct BellInfo
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)FKMax.MAX_BELLCOUNT_DAY)]
        public byte[] mValid;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)FKMax.MAX_BELLCOUNT_DAY)]
        public byte[] mHour;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)FKMax.MAX_BELLCOUNT_DAY)]
        public byte[] mMinute;

        public void Init()
        {
            mValid = new byte[(int)FKMax.MAX_BELLCOUNT_DAY];
            mHour = new byte[(int)FKMax.MAX_BELLCOUNT_DAY];
            mMinute = new byte[(int)FKMax.MAX_BELLCOUNT_DAY];
        }
    }

    public struct PassTime
    {
        public byte StartHour;                  // Door open enable start time(hour)
        public byte StartMinute;              // Door open enable start time(minute)
        public byte EndHour;                  // Door open enable end time(hour)
        public byte EndMinute;                // Door open enable end time(minute)
    };

    public struct PassCtrlTime
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)FKMax.MAX_PASSCTRL_COUNT)]
        public PassTime[] mPassTime;

        public void Init()
        {
            mPassTime = new PassTime[(int)FKMax.MAX_PASSCTRL_COUNT];
        }
    }

    public struct PassCtrlTimeAll
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)FKMax.MAX_PASSCTRLGROUP_COUNT)]
        public PassCtrlTime[] mPassCtrlTime;

        public void Init()
        {
            mPassCtrlTime = new PassCtrlTime[(int)FKMax.MAX_PASSCTRLGROUP_COUNT];
            for (int i = 0; i < (int)FKMax.MAX_PASSCTRLGROUP_COUNT; i++)
            {
                mPassCtrlTime[i].Init();
            }
        }
    }

    public struct UserPassInfo
    {
        public static byte[] UserPassID = new byte[(int)FKMax.MAX_USERPASSINFO_COUNT];
    }

    public struct GroupPassInfo
    {
        public static byte[] GroupPassID = new byte[(int)FKMax.MAX_GROUPPASSINFO_COUNT];
    }

    public struct GroupMatchInfo
    {
        public static ushort[] GroupMatch = new ushort[(int)FKMax.MAX_GROUPMATCHINFO_COUNT];
    }

    public struct TimeSlot
    {
        public byte StartHour;
        public byte StartMinute;
        public byte EndHour;
        public byte EndMinute;
    };

    public struct TimeZone
    {
        public int Size;
        public int TimeZoneID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)FKMax.TIME_SLOT_COUNT)]
        public TimeSlot[] TimeSlots;

        public void Init()
        {
            Size = (int)FKMax.SIZE_TIME_ZONE_STRUCT;
            TimeZoneID = 0;
            TimeSlots = new TimeSlot[(int)FKMax.TIME_SLOT_COUNT];
        }
    };

    public struct UserWeekPassTime
    {
        public int Size;
        public UInt32 UserID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
        public byte[] WeekPassTime;
        public byte Reserved;

        public void Init()
        {
            Size = (int)FKMax.SIZE_USER_WEEK_PASS_TIME_STRUCT;
            UserID = 0;
            WeekPassTime = new byte[7];
        }
    }

    public struct ExtCmdStructHeader
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)FKMax.SIZE_EXT_CMD_CODE)]
        public byte[] bytCmdCode;    // 0, 56
        public Int32 StructVer;     // 56, 4
        public Int32 StructSize;    // 60, 4

        public void Init(string asCmdCode, int aStructVer, int aStructSize)
        {
            bytCmdCode = new byte[(int)FKMax.SIZE_EXT_CMD_CODE];
            Array.Clear(bytCmdCode, 0, bytCmdCode.Length);
            byte[] bytAnsi = System.Text.Encoding.GetEncoding("utf-8").GetBytes(asCmdCode);
            int nBytesToCopy = bytAnsi.Length;
            if (nBytesToCopy > bytCmdCode.Length - 1) nBytesToCopy = bytCmdCode.Length - 1;
            Array.Copy(bytAnsi, bytCmdCode, nBytesToCopy);

            StructVer = aStructVer;
            StructSize = aStructSize;
        }
    }

    public struct ExtCmd_USERDOORINFO
    {
        public ExtCmdStructHeader CmdHeader;
        public UInt32 UserID;       //4
        public byte Reserved;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
        public byte[] WeekPassTime;
        public short StartYear;
        public byte StartMonth;
        public byte StartDay;
        public short EndYear;
        public byte EndMonth;
        public byte EndDay;

        public void Init(bool IsSet, UInt32 anUserID)
        {
            CmdHeader = new ExtCmdStructHeader();
            CmdHeader.Init(IsSet ? "ECMD_SetUserDoorInfo" : "ECMD_GetUserDoorInfo", (int)FKMax.VER_USERDOORINFO_V1, (int)FKMax.SIZE_USERDOORINFO_V1);
            WeekPassTime = new byte[7];
            UserID = anUserID;
            Reserved = 0;
            StartYear = 0;
            StartMonth = 0;
            StartDay = 0;
            EndYear = 0;
            EndMonth = 0;
            EndDay = 0;
        }
    }

    public struct DoorTime
    {
        public byte PassStartH;               // Door open enable start time(hour)
        public byte PassStartM;               // Door open enable start time(minute)
        public byte PassEndH;                   // Door open enable end time(hour)
        public byte PassEndM;                   // Door open enable end time(minute)
    }

    public struct DoorPassTime
    {
        public static DoorTime[] DoorTime = new DoorTime[(int)FKMax.MAX_PASSTIMECOUNT];
    }

    public struct LockInfo
    {
        public static DoorTime[,] LockTime = new DoorTime[(int)FKMax.MAX_TIMEGROUP, (int)FKMax.MAX_PASSTIMECOUNT];
    }

    public struct RecordTimeInfo
    {
        public static byte[] mValid = new byte[(int)FKMax.MAX_RECORDTIMEINFO_COUNT];
        public static byte[] mStartHour = new byte[(int)FKMax.MAX_RECORDTIMEINFO_COUNT];
        public static byte[] mStartMinute = new byte[(int)FKMax.MAX_RECORDTIMEINFO_COUNT];
        public static byte[] mEndHour = new byte[(int)FKMax.MAX_RECORDTIMEINFO_COUNT];
        public static byte[] mEndMinute = new byte[(int)FKMax.MAX_RECORDTIMEINFO_COUNT];
        public static byte[] mReserve = new byte[2];
    }

    public struct RealTimeInfo
    {
        public static byte Valid;
        public static byte AckTime;
        public static byte WaitTime;
        public static byte Reserve;
        public static int SendPos;
        public static byte[] Hour = new byte[(int)FKMax.MAX_REAL_TIME];
        public static byte[] Minute = new byte[(int)FKMax.MAX_REAL_TIME];
    }

    public struct ShiftTime
    {
        public static byte AMStartH;    //AM time(hour)
        public static byte AMStartM;    //AM min(minute)
        public static byte AMEndH;      //AM time(hour)
        public static byte AMEndM;      //AM min(minute)
        public static byte PMStartH;    //PM time(hour)
        public static byte PMStartM;    //PM min(minute)
        public static byte PMEndH;      //PM time(hour)
        public static byte PMEndM;      //PM min(minute)
        public static byte OVStartH;    //OV time(hour)
        public static byte OVStartM;    //OV min(minute)
        public static byte OVEndH;      //OV time(hour)
        public static byte OVEndM;      //OV min(minute)
    }

    public struct PostInfo
    {
        public static byte[] PostName = new byte[(int)FKMax.NAME_BYTE_COUNT];
    }

    public struct PostShift
    {
        public int Size;
        public int Ver;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)FKMax.MAX_SHIFTCOUNT)]
        public ShiftTime[] ShiftTime;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)FKMax.MAX_POSTCOUNT)]
        public PostInfo[] PostInfo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)FKMax.NAME_BYTE_COUNT)]
        public byte[] CompanyName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Reserved;

        public void Init()
        {
            ShiftTime = new ShiftTime[(int)FKMax.MAX_SHIFTCOUNT];
            PostInfo = new PostInfo[(int)FKMax.MAX_POSTCOUNT];
            CompanyName = new byte[(int)FKMax.NAME_BYTE_COUNT];
            Reserved = new byte[4];
        }
    }

    public struct UserData
    {
        public int Size;
        public int Ver;
        public UInt32 UserId;
        public int Reserved;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)FKMax.NAME_BYTE_COUNT)]
        public byte[] UserName;
        public int PostID;
        public short YearAssigned;
        public short MonthAssigned;
        public byte StartWeekdayOfMonth;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)FKMax.MAX_DAY_IN_MONTH)]
        public byte[] ShiftID;

        public void Init()
        {
            UserName = new byte[(int)FKMax.NAME_BYTE_COUNT];
            ShiftID = new byte[(int)FKMax.MAX_DAY_IN_MONTH];
        }
    }

    ///<summary>
    ///调用FK623Attend.dll
    ///</summary>
    public class FK623Attend
    {
        private ECard78.Base Pub = new ECard78.Base();
        private const string Dll_FK623Attend = "FK623Attend.dll";
        private TConnInfoFinger conn = null;
        private static bool OpenFlag = false;
        private static int hComm = 0;
        private const int License = 1261;
        private static int ResultCode = (int)FKRun.RUN_SUCCESS;
        public static string SeaBody = "";

        public string SeaBodyStr()
        {
            return SeaBody;
        }


        public static FtpWebRequest FtpGetRequest(string URI, string username, string password)
        {
            //根据服务器信息FtpWebRequest创建类的对象
            FtpWebRequest result = (FtpWebRequest)FtpWebRequest.Create(URI);
            //提供身份验证信息
            result.Credentials = new System.Net.NetworkCredential(username, password);
            //设置请求完成之后是否保持到FTP服务器的控制连接，默认值为true
            result.KeepAlive = false;
            return result;
        }


        public bool POST_GetResponse(string url, string name, string pwd, ref string json)
        {
            string StrDate = "";
            try
            {
                //此处为为http请求url 
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                CookieContainer cookieContainer = new CookieContainer();
                request.KeepAlive = false; //解决基础连接已关闭
                request.ProtocolVersion = HttpVersion.Version11;//解决基础连接已关闭
                request.CookieContainer = cookieContainer;
                request.Credentials = GetCredentialCache(url, name, pwd);
                request.Headers.Add("Authorization", GetAuthorization(name, pwd));
                request.Method = "POST";
                request.ContentType = "application/json;charset=UTF-8";
                request.AllowAutoRedirect = true;
                request.Timeout = 30000;

                byte[] payload = Encoding.UTF8.GetBytes(json);
                json = "";
                request.ContentLength = payload.Length;
                Stream writer = request.GetRequestStream();
                writer.Write(payload, 0, payload.Length);
                writer.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream s = response.GetResponseStream();

                StreamReader Reader = new StreamReader(s, Encoding.UTF8);
                while ((StrDate = Reader.ReadLine()) != null)
                {
                    json += StrDate;
                }
            }
            catch (Exception e)
            {
                //Pub.ShowErrorMsg(E);
                string s = e.Message;
                FK623Attend.SeaBody = Pub.GetResText("", "FK_RUNERR_NO_OPEN_COMM", "");
                return false;
            }
            if (json == "")
            {
                FK623Attend.SeaBody = Pub.GetResText("", "FK_RUNERR_NO_OPEN_COMM", "");
                return false;
            }
            else
            {
                try
                {
                    jsonBody<Answer> body = JsonConvert.DeserializeObject<jsonBody<Answer>>(json);
                    if (body.info.Result == "Fail")
                    {
                        FK623Attend.SeaBody = body.info.Detail;
                        return false;
                    }
                    else
                    {
                        FK623Attend.SeaBody = Pub.GetResText("", "FK_RUN_SUCCESS", "");
                        return true;
                    }
                }
                catch
                {
                    FK623Attend.SeaBody = Pub.GetResText("", "FK_RUN_SUCCESS", "");
                    return true;
                }

            }
        }

        /// <summary>
        /// 创建认证
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private static CredentialCache GetCredentialCache(string uri, string username, string password)
        {
            CredentialCache credCache = new CredentialCache();
            credCache.Add(new Uri(uri), "Basic", new NetworkCredential(username, password));

            return credCache;
        }
        /// <summary>
        /// 创建Basic
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private static string GetAuthorization(string username, string password)
        {
            string authorization = string.Format("{0}:{1}", username, password);

            return "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(authorization));
        }
        public FK623Attend()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public void InitConn(TConnInfoFinger connInfo)
        {
            conn = connInfo;
        }

        public bool IsOpen
        {
            get { return OpenFlag; }
        }

        public void Open()
        {
            Close();
            ResultCode = (int)FKRun.RUNERR_UNKNOWNERROR;
            if (conn.ConnType == 0)
                hComm = ConnectUSB(conn.MacSN);
            else if (conn.ConnType == 1)
                hComm = ConnectComm(conn.MacSN, conn.CommPort, conn.CommBaudrate, "", 0, 0);
            else
            {
                IPAddress ip;
                if (!System.Net.IPAddress.TryParse(conn.NetIP, out ip))
                {
                    try
                    {
                        IPHostEntry hostEntry = Dns.GetHostEntry(conn.NetIP);
                        IPEndPoint ipEndPoint = new IPEndPoint(hostEntry.AddressList[0], 0);
                        conn.NetIP = ipEndPoint.Address.ToString();
                    }
                    catch
                    {
                    }
                }
                if (conn.IsGPRS)
                    hComm = ConnectGPRS(conn.MacSN_GPRS, conn.NetIP, conn.NetPort, 0, 0, conn.NetPassword);
                else
                    hComm = ConnectNet(conn.MacSN, conn.NetIP, conn.NetPort, 0, 0, conn.NetPassword);
            }
            if (hComm > 0)
            {
                OpenFlag = true;
                ResultCode = (int)FKRun.RUN_SUCCESS;
            }
            else
            {
                ResultCode = hComm;
            }
        }

        public bool ReOpen()
        {
            bool ret = false;
            int ReTimes = 0;
            Close();
            while (ReTimes < 5)
            {
                ReTimes++;
                Open();
                if (OpenFlag)
                {
                    EnableDevice(0);
                    break;
                }
            }
            ret = OpenFlag;
            return ret;
        }

        public string ErrMsg
        {
            get { return ReturnResultPrint(); }
        }

        public int RunCode
        {
            get { return ResultCode; }
            set { ResultCode = value; }
        }

        public void Close()
        {
            if (OpenFlag) DisConnect();
            OpenFlag = false;
        }

        public string GetRunMsg(int ResultCode)
        {
            switch (ResultCode)
            {
                case (int)FKRun.RUN_SUCCESS: return Pub.GetResText("", "FK_RUN_SUCCESS", "");
                case (int)FKRun.RUNERR_NOSUPPORT: return Pub.GetResText("", "FK_RUNERR_NOSUPPORT", "");
                case (int)FKRun.RUNERR_UNKNOWNERROR: return Pub.GetResText("", "FK_RUNERR_UNKNOWNERROR", "");
                case (int)FKRun.RUNERR_NO_OPEN_COMM: return Pub.GetResText("", "FK_RUNERR_NO_OPEN_COMM", "");
                case (int)FKRun.RUNERR_WRITE_FAIL: return Pub.GetResText("", "FK_RUNERR_WRITE_FAIL", "");
                case (int)FKRun.RUNERR_READ_FAIL: return Pub.GetResText("", "FK_RUNERR_READ_FAIL", "");
                case (int)FKRun.RUNERR_INVALID_PARAM: return Pub.GetResText("", "FK_RUNERR_INVALID_PARAM", "");
                case (int)FKRun.RUNERR_NON_CARRYOUT: return Pub.GetResText("", "FK_RUNERR_NON_CARRYOUT", "");
                case (int)FKRun.RUNERR_DATAARRAY_END: return Pub.GetResText("", "FK_RUNERR_DATAARRAY_END", "");
                case (int)FKRun.RUNERR_DATAARRAY_NONE: return Pub.GetResText("", "FK_RUNERR_DATAARRAY_NONE", "");
                case (int)FKRun.RUNERR_MEMORY: return Pub.GetResText("", "FK_RUNERR_MEMORY", "");
                case (int)FKRun.RUNERR_MIS_PASSWORD: return Pub.GetResText("", "FK_RUNERR_MIS_PASSWORD", "");
                case (int)FKRun.RUNERR_MEMORYOVER: return Pub.GetResText("", "FK_RUNERR_MEMORYOVER", "");
                case (int)FKRun.RUNERR_DATADOUBLE: return Pub.GetResText("", "FK_RUNERR_DATADOUBLE", "");
                case (int)FKRun.RUNERR_MANAGEROVER: return Pub.GetResText("", "FK_RUNERR_MANAGEROVER", "");
                case (int)FKRun.RUNERR_FPDATAVERSION: return Pub.GetResText("", "FK_RUNERR_FPDATAVERSION", "");
                case (int)FKRun.RUNERR_LOGINOUTMODE: return Pub.GetResText("", "FK_RUNERR_LOGINOUTMODE", "");
                default:
                    return Pub.GetResText("", "FK_RUNERR_UNKNOWNERROR", "");
            }
        }

        private string ReturnResultPrint()
        {
            return GetRunMsg(ResultCode);
        }

        private string InfoIndexString(int InfoIndex, int nValue)
        {
            string ret = "";
            string S;
            switch (InfoIndex)
            {
                case (int)FKDI.DI_MANAGERS:
                    ret = Pub.GetResText("", "FK_DI_MANAGERS", "") + "={0}";
                    break;
                case (int)FKDI.DI_MACHINENUM:
                    ret = Pub.GetResText("", "MacSN", "") + "={0}";
                    break;
                case (int)FKDI.DI_LANGAUGE:
                    ret = Pub.GetResText("", "FK_DI_LANGAUGE", "") + "={0}";
                    break;
                case (int)FKDI.DI_POWEROFF_TIME:
                    ret = Pub.GetResText("", "FK_DI_POWEROFF_TIME", "") + "={0}";
                    break;
                case (int)FKDI.DI_LOCK_CTRL:
                    ret = Pub.GetResText("", "FK_DI_LOCK_CTRL", "") + "={0}";
                    break;
                case (int)FKDI.DI_GLOG_WARNING:
                    ret = Pub.GetResText("", "FK_DI_GLOG_WARNING", "") + "={0}";
                    break;
                case (int)FKDI.DI_SLOG_WARNING:
                    ret = Pub.GetResText("", "FK_DI_SLOG_WARNING", "") + "={0}";
                    break;
                case (int)FKDI.DI_VERIFY_INTERVALS:
                    ret = Pub.GetResText("", "FK_DI_VERIFY_INTERVALS", "") + "={0}";
                    break;
                case (int)FKDI.DI_RSCOM_BPS:
                    {
                        switch (nValue)
                        {
                            case (int)FKBPS.BPS_9600:
                                S = "9600";
                                break;
                            case (int)FKBPS.BPS_19200:
                                S = "19200";
                                break;
                            case (int)FKBPS.BPS_38400:
                                S = "38400";
                                break;
                            case (int)FKBPS.BPS_57600:
                                S = "57600";
                                break;
                            case (int)FKBPS.BPS_115200:
                                S = "115200";
                                break;
                            default:
                                S = "--";
                                break;
                        }
                        ret = Pub.GetResText("", "FK_DI_RSCOM_BPS", "") + "=" + S;
                        break;
                    }
                case (int)FKDI.DI_VERIFY_KIND:
                    {
                        S = "";
                        switch (nValue)
                        {
                            case 0:
                                S = "F / P / C";
                                break;
                            case 1:
                                S = "F + P";
                                break;
                            case 2:
                                S = "F + C";
                                break;
                            case 3:
                                S = "C";
                                break;
                        }
                        ret = Pub.GetResText("", "FK_DI_VERIFY_KIND", "") + "=" + S;
                        break;
                    }
                case (int)FKDI.DI_DATE_SEPARATE:
                    ret = Pub.GetResText("", "FK_DI_DATE_SEPARATE", "") + "={0}";
                    break;
                case (int)FKDI.DI_MULTIUSERS:
                    ret = Pub.GetResText("", "FK_DI_MULTIUSERS", "") + "={0}";
                    break;
                default:
                    ret = "--";
                    break;
            }
            if (ret.IndexOf("{0}") > 0) ret = string.Format(ret, nValue.ToString());
            return ret;
        }

        private string StatusIndexString(int StatusIndex, int nValue)
        {
            string ret = "";
            switch (StatusIndex)
            {
                case (int)FKDS.GET_MANAGERS:
                    ret = Pub.GetResText("", "FK_GET_MANAGERS", "") + "={0}";
                    break;
                case (int)FKDS.GET_USERS:
                    ret = Pub.GetResText("", "FK_GET_USERS", "") + "={0}";
                    break;
                case (int)FKDS.GET_FPS:
                    ret = Pub.GetResText("", "FK_GET_FPS", "") + "={0}";
                    break;
                case (int)FKDS.GET_PSWS:
                    ret = Pub.GetResText("", "FK_GET_PSWS", "") + "={0}";
                    break;
                case (int)FKDS.GET_SLOGS:
                    ret = Pub.GetResText("", "FK_GET_SLOGS", "") + "={0}";
                    break;
                case (int)FKDS.GET_GLOGS:
                    ret = Pub.GetResText("", "FK_GET_GLOGS", "") + "={0}";
                    break;
                case (int)FKDS.GET_ASLOGS:
                    ret = Pub.GetResText("", "FK_GET_ASLOGS", "") + "={0}";
                    break;
                case (int)FKDS.GET_AGLOGS:
                    ret = Pub.GetResText("", "FK_GET_AGLOGS", "") + "={0}";
                    break;
                case (int)FKDS.GET_CARDS:
                    ret = Pub.GetResText("", "FK_GET_CARDS", "") + "={0}";
                    break;
                case (int)FKDS.GET_FACES:
                    ret = Pub.GetResText("", "FK_GET_FACES", "") + "={0}";
                    break;
                case (int)FKDS.GET_PALMVEINS:
                    ret = Pub.GetResText("", "FK_GET_PALMVEINS", "") + "={0}";
                    break;
                default:
                    ret = "--";
                    break;
            }
            if (ret.IndexOf("{0}") > 0) ret = string.Format(ret, nValue.ToString());
            return ret;
        }

        private void ConvertStructToByteArray(object Struct, byte[] ByteArray)
        {
            IntPtr vptr = IntPtr.Zero;
            int Size = Marshal.SizeOf(Struct);
            if (ByteArray.Length < Size) return;
            vptr = Marshal.AllocHGlobal(Size);
            Marshal.StructureToPtr(Struct, vptr, false);
            Marshal.Copy(vptr, ByteArray, 0, Size);
            Marshal.FreeHGlobal(vptr);
        }

        private object ConvertByteArrayToStruct(byte[] ByteArray, Type Typ)
        {
            object obj;
            IntPtr ptr;
            int Size = Marshal.SizeOf(Typ);
            if (ByteArray.Length < Size) return null;
            ptr = Marshal.AllocHGlobal(Size);
            Marshal.Copy(ByteArray, 0, ptr, Size);
            obj = Marshal.PtrToStructure(ptr, Typ);
            Marshal.FreeHGlobal(ptr);
            return obj;
        }

        public UInt32 EnrollNumberToUInt32(int EnrollNumber)
        {
            Int64 ret = EnrollNumber;
            if (ret < 0) ret = 0xffffffff + ret + 1;
            return Convert.ToUInt32(ret);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_ConnectUSB(int nMachineNo, int nLicense);
        ///<summary>
        ///机器连接与断开
        ///使用USB方式连接设备
        ///</summary>
        private int ConnectUSB(int MachineNo)
        {
            return FK_ConnectUSB(MachineNo, License);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_ConnectComm(int nMachineNo, int nComPort, int nBaudRate, string nTelNumber,
          int nWaitDialTime, int nLicense, int nComTimeOut);
        ///<summary>
        ///机器连接与断开
        ///使用RS232/485方式连接设备
        ///</summary>
        private int ConnectComm(int MachineNo, int ComPort, int BaudRate, string TelNumber, int WaitDialTime,
          int ComTimeOut)
        {
            return FK_ConnectComm(MachineNo, ComPort, BaudRate, TelNumber, WaitDialTime, License, ComTimeOut);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_ConnectNet(int MachineNo, string nIpAddress, int nNetPort, int nTimeOut,
          int nProtocolType, int nNetPassword, int nLicense);
        ///<summary>
        ///机器连接与断开
        ///使用TCP/IP方式连接设备
        ///</summary>
        private int ConnectNet(int MachineNo, string IpAddress, int NetPort, int TimeOut, int ProtocolType,
          int NetPassword)
        {
            return FK_ConnectNet(MachineNo, IpAddress, NetPort, TimeOut, ProtocolType, NetPassword, License);
        }

        [DllImport("FK623Attend.dll", CharSet = CharSet.Ansi)]
        private static extern int FK_ConnectGPRS(string MachineNo, string nIpAddress, int nNetPort, int nTimeOut,
          int nProtocolType, int nNetPassword, int nLicense);
        private int ConnectGPRS(string MachineNo, string IpAddress, int NetPort, int TimeOut, int ProtocolType,
          int NetPassword)
        {
            return FK_ConnectGPRS(MachineNo, IpAddress, NetPort, TimeOut, ProtocolType, NetPassword, License);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern void FK_DisConnect(int hComm);
        ///<summary>
        ///机器连接与断开
        ///断开设备
        ///</summary>
        private void DisConnect()
        {
            FK_DisConnect(hComm);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_EnableDevice(int hComm, byte nEnableFlag);
        ///<summary>
        ///机器管理
        ///设置机器是否可用
        ///</summary>
        public int EnableDevice(byte EnableFlag)
        {
            return FK_EnableDevice(hComm, EnableFlag);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern void FK_PowerOnAllDevice(int hComm);
        ///<summary>
        ///机器管理
        ///打开机器电源
        ///</summary>
        private void PowerOnAllDevice(int hComm)
        {
            FK_PowerOnAllDevice(hComm);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_PowerOffDevice(int hComm);
        ///<summary>
        ///机器管理
        ///关闭机器电源
        ///</summary>
        private int PowerOffDevice()
        {
            return FK_PowerOffDevice(hComm);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_GetDeviceStatus(int hComm, int nStatusIndex, ref int nValue);
        ///<summary>
        ///机器管理
        ///获取机器上的状态值
        ///</summary>
        private int GetDeviceStatus(int StatusIndex, ref int Value)
        {
            return FK_GetDeviceStatus(hComm, StatusIndex, ref Value);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_GetDeviceTime(int hComm, ref DateTime nDateTime);
        ///<summary>
        ///机器管理
        ///获取机器时间
        ///</summary>
        public bool GetDeviceTime(ref DateTime DateTime)
        {
            bool ret = false;
            if (!OpenFlag) Open();
            if (OpenFlag)
            {
                if (FK_GetDeviceTime(hComm, ref DateTime) == (int)FKRun.RUN_SUCCESS) ret = true;
            }
            Close();
            return ret;
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_SetDeviceTime(int hComm, DateTime nDateTime);
        ///<summary>
        ///机器管理
        ///设置机器时间
        ///</summary>
        public bool SetDeviceTime(DateTime DateTime)
        {
            bool ret = false;
            if (!OpenFlag) Open();
            if (OpenFlag)
            {
                if (FK_SetDeviceTime(hComm, DateTime) == (int)FKRun.RUN_SUCCESS) ret = true;
            }
            Close();
            return ret;
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_GetDeviceInfo(int hComm, int nInfoIndex, ref int nValue);
        ///<summary>
        ///机器管理
        ///获取机器信息
        ///</summary>
        private int GetDeviceInfo(int InfoIndex, ref int Value)
        {
            return FK_GetDeviceInfo(hComm, InfoIndex, ref Value);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_SetDeviceInfo(int hComm, int nInfoIndex, int nValue);
        ///<summary>
        ///机器管理
        ///设置机器信息
        ///</summary>
        private int SetDeviceInfo(int InfoIndex, int Value)
        {
            return FK_SetDeviceInfo(hComm, InfoIndex, Value);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_GetProductData(int hComm, int nDataIndex, StringBuilder nValue);
        ///<summary>
        ///机器管理
        ///获取产品信息
        ///</summary>
        private int GetProductData(int DataIndex, ref string Value)
        {
            StringBuilder sb = new StringBuilder(256);
            int ret = FK_GetProductData(hComm, DataIndex, sb);
            Value = sb.ToString().Trim();
            return ret;
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_LoadSuperLogData(int hComm, int nReadMark);
        ///<summary>
        ///记录数据管理
        ///读取管理记录
        ///</summary>
        public int LoadSuperLogData(int ReadMark)
        {
            return FK_LoadSuperLogData(hComm, ReadMark);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_USBLoadSuperLogDataFromFile(int hComm, string nFilePath);
        ///<summary>
        ///记录数据管理
        ///从文件读取管理记录
        ///</summary>
        private int USBLoadSuperLogDataFromFile(string FileName)
        {
            return FK_USBLoadSuperLogDataFromFile(hComm, FileName);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_GetSuperLogData(int hComm, ref UInt32 nSEnrollNumber, ref UInt32 nGEnrollNumber,
          ref int nManipulation, ref int nBackupNumber, ref DateTime nDateTime);
        ///<summary>
        ///记录数据管理
        ///通过LoadSuperLogData或者USBLoadSuperLogDataFromFile读取的管理记录一个一个获取
        ///</summary>
        public int GetSuperLogData(ref UInt32 SEnrollNumber, ref UInt32 GEnrollNumber, ref int Manipulation,
          ref int BackupNumber, ref DateTime DateTime)
        {
            return FK_GetSuperLogData(hComm, ref SEnrollNumber, ref GEnrollNumber, ref Manipulation, ref BackupNumber,
              ref DateTime);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_EmptySuperLogData(int hComm);
        ///<summary>
        ///记录数据管理
        ///删除机器上所有管理记录
        ///</summary>
        private int EmptySuperLogData()
        {
            return FK_EmptySuperLogData(hComm);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_LoadGeneralLogData(int hComm, int nReadMark);
        ///<summary>
        ///记录数据管理
        ///读取进出记录
        ///</summary>
        public int LoadGeneralLogData(int ReadMark)
        {
            return FK_LoadGeneralLogData(hComm, ReadMark);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_USBLoadGeneralLogDataFromFile(int hComm, string nFilePath);
        ///<summary>
        ///记录数据管理
        ///从文件读取进出记录
        ///</summary>
        public int USBLoadGeneralLogDataFromFile(string FileName)
        {
            return FK_USBLoadGeneralLogDataFromFile(hComm, FileName);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_GetGeneralLogData(int hComm, ref UInt32 nEnrollNumber, ref int nVerifyMode,
          ref int nInOutMode, ref DateTime nDateTime);
        ///<summary>
        ///记录数据管理
        ///通过LoadSuperLogData或者USBLoadSuperLogDataFromFile读取的管理记录一个一个获取
        ///</summary>
        public int GetGeneralLogData(ref UInt32 EnrollNumber, ref int VerifyMode, ref int InOutMode, ref DateTime DateTime)
        {
            return FK_GetGeneralLogData(hComm, ref EnrollNumber, ref VerifyMode, ref InOutMode, ref DateTime);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_EmptyGeneralLogData(int hComm);
        ///<summary>
        ///记录数据管理
        ///删除机器上所有进出记录
        ///</summary>
        private int EmptyGeneralLogData()
        {
            return FK_EmptyGeneralLogData(hComm);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_GetBellTime(int hComm, ref int nBellCount, ref int nBellInfo);
        ///<summary>
        ///响铃管理
        ///获取机器响铃信息
        ///</summary>
        private int GetBellTime(ref int BellCount, ref int BellInfo)
        {
            return FK_GetBellTime(hComm, ref BellCount, ref BellInfo);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_SetBellTime(int hComm, int nBellCount, ref int nBellInfo);
        ///<summary>
        ///响铃管理
        ///设置机器响铃信息
        ///</summary>
        private int SetBellTime(int BellCount, ref int BellInfo)
        {
            return FK_SetBellTime(hComm, BellCount, ref BellInfo);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_GetEnrollData(int hComm, UInt32 nEnrollNumber, int nBackupNumber,
          ref int nMachinePrivilege, byte[] nEnrollData, ref int nPassWord);
        ///<summary>
        ///登记数据管理
        ///获取用户登记资料和权限
        ///</summary>
        public int GetEnrollData(UInt32 EnrollNumber, int BackupNumber, ref int MachinePrivilege, byte[] EnrollData,
          ref int PassWord)
        {
            return FK_GetEnrollData(hComm, EnrollNumber, BackupNumber, ref MachinePrivilege, EnrollData, ref PassWord);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_PutEnrollData(int hComm, UInt32 nEnrollNumber, int nBackupNumber,
          int nMachinePrivilege, byte[] nEnrollData, int nPassWord);
        [DllImport(Dll_FK623Attend)]
        private static extern int FK_PutEnrollDataWithString(int hComm, UInt32 nEnrollNumber, int nBackupNumber,
          int nMachinePrivilege, string nEnrollData);
        ///<summary>
        ///登记数据管理
        ///将用户的登记资料和权限传送到机器
        ///</summary>
        public int PutEnrollData(UInt32 EnrollNumber, int BackupNumber, int MachinePrivilege, byte[] EnrollData, int PassWord)
        {
            return FK_PutEnrollData(hComm, EnrollNumber, BackupNumber, MachinePrivilege, EnrollData, PassWord);
        }
        public int PutEnrollData(UInt32 EnrollNumber, int BackupNumber, int MachinePrivilege, string EnrollData)
        {
            return FK_PutEnrollDataWithString(hComm, EnrollNumber, BackupNumber, MachinePrivilege, EnrollData);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_SaveEnrollData(int hComm);
        ///<summary>
        ///登记数据管理
        ///将PutEnrollData传送的资料登记到机器上
        ///</summary>
        public int SaveEnrollData()
        {
            return FK_SaveEnrollData(hComm);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_DeleteEnrollData(int hComm, UInt32 nEnrollNumber, int nBackupNumber);
        ///<summary>
        ///登记数据管理
        ///删除登记资料
        ///</summary>
        public int DeleteEnrollData(UInt32 EnrollNumber, int BackupNumber)
        {
            return FK_DeleteEnrollData(hComm, EnrollNumber, BackupNumber);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_SetUSBModel(int hComm, int nModel);
        public int SetUSBModel(int Model)
        {
            return FK_SetUSBModel(hComm, Model);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_SetUDiskFileFKModel(int hComm, string FKModel);
        public int SetUSBModel(string FKModel)
        {
            return FK_SetUDiskFileFKModel(hComm, FKModel);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_USBReadAllEnrollDataFromFile(int hComm, string nFilePath);
        ///<summary>
        ///登记数据管理
        ///从文件中读取登记资料
        ///</summary>
        private int USBReadAllEnrollDataFromFile(string FilePath)
        {
            return FK_USBReadAllEnrollDataFromFile(hComm, FilePath);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_USBReadAllEnrollDataCount(int hComm, int nValue);
        private int USBReadAllEnrollDataCount(int nValue)
        {
            return FK_USBReadAllEnrollDataCount(hComm, nValue);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_USBGetOneEnrollData(int hComm, ref UInt32 nEnrollNumber, ref int nBackupNumber,
          ref int nMachinePrivilege, byte[] nEnrollData, ref int nPassWord, ref int nEnableFlag, ref string nEnrollName);
        ///<summary>
        ///登记数据管理
        ///获取通过USBReadAllEnrollDataFromFile读取的登记资料
        ///</summary>
        private int USBGetOneEnrollData(ref UInt32 EnrollNumber, ref int BackupNumber, ref int MachinePrivilege,
          byte[] EnrollData, ref int PassWord, ref int EnableFlag, ref string EnrollName)
        {
            return FK_USBGetOneEnrollData(hComm, ref EnrollNumber, ref BackupNumber, ref MachinePrivilege,
              EnrollData, ref PassWord, ref EnableFlag, ref EnrollName);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_USBSetOneEnrollData(int hComm, UInt32 nEnrollNumber, int nBackupNumber,
          int nMachinePrivilege, byte[] nEnrollData, int nPassWord, int nEnableFlag, string nEnrollName);
        private int USBSetOneEnrollData(UInt32 EnrollNumber, int BackupNumber, int MachinePrivilege, byte[] EnrollData,
          int PassWord, int EnableFlag, string EnrollName)
        {
            return FK_USBSetOneEnrollData(hComm, EnrollNumber, BackupNumber, MachinePrivilege, EnrollData,
              PassWord, EnableFlag, EnrollName);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_USBWriteAllEnrollDataToFile(int hComm, string nFilePath);
        ///<summary>
        ///登记数据管理
        ///将通过USBSetOneEnrollData制作的登记资料保存为文件
        ///</summary>
        private int USBWriteAllEnrollDataToFile(string FileName)
        {
            return FK_USBWriteAllEnrollDataToFile(hComm, FileName);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_USBReadAllEnrollDataFromFile_Color(int hComm, string nFilePath);
        ///<summary>
        ///登记数据管理
        ///从文件中读取登记资料
        ///</summary>
        private int USBReadAllEnrollDataFromFile_Color(string FilePath)
        {
            return FK_USBReadAllEnrollDataFromFile_Color(hComm, FilePath);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_USBWriteAllEnrollDataToFile_Color(int hComm, string nFilePath);
        ///<summary>
        ///登记数据管理
        ///将通过USBSetOneEnrollData制作的登记资料保存为文件
        ///</summary>
        private int USBWriteAllEnrollDataToFile_Color(string FileName)
        {
            return FK_USBWriteAllEnrollDataToFile_Color(hComm, FileName);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_USBGetOneEnrollData_Color(int hComm, ref UInt32 nEnrollNumber, ref int nBackupNumber,
          ref int nMachinePrivilege, ref int nEnrollData, ref int nPassWord, ref int nEnableFlag, ref string nEnrollName,
          ref int nNewsKind);
        ///<summary>
        ///登记数据管理
        ///获取通过USBReadAllEnrollDataFromFile读取的登记资料
        ///</summary>
        private int USBGetOneEnrollData_Color(ref UInt32 EnrollNumber, ref int BackupNumber, ref int MachinePrivilege,
          ref int EnrollData, ref int PassWord, ref int EnableFlag, ref string EnrollName, ref int NewsKind)
        {
            return FK_USBGetOneEnrollData_Color(hComm, ref EnrollNumber, ref BackupNumber, ref MachinePrivilege,
              ref EnrollData, ref PassWord, ref EnableFlag, ref EnrollName, ref NewsKind);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_USBSetOneEnrollData_Color(int hComm, UInt32 nEnrollNumber, int nBackupNumber,
          int nMachinePrivilege, ref int nEnrollData, int nPassWord, int nEnableFlag, string nEnrollName, int NewsKind);
        private int USBSetOneEnrollData_Color(UInt32 EnrollNumber, int BackupNumber, int MachinePrivilege, ref int EnrollData,
          int PassWord, int EnableFlag, string EnrollName, int NewsKind)
        {
            return FK_USBSetOneEnrollData_Color(hComm, EnrollNumber, BackupNumber, MachinePrivilege, ref EnrollData,
              PassWord, EnableFlag, EnrollName, NewsKind);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_EnableUser(int hComm, UInt32 nEnrollNumber, int nBackupNumber, int nEnableFlag);
        ///<summary>
        ///用户信息管理
        ///设置用户对机器是否可用
        ///</summary>
        private int EnableUser(UInt32 EnrollNumber, int BackupNumber, int EnableFlag)
        {
            return FK_EnableUser(hComm, EnrollNumber, BackupNumber, EnableFlag);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_ModifyPrivilege(int hComm, UInt32 nEnrollNumber, int nBackupNumber,
          int nMachinePrivilege);
        ///<summary>
        ///用户信息管理
        ///设置用户对机器的操作权限
        ///</summary>
        private int ModifyPrivilege(UInt32 EnrollNumber, int BackupNumber, int MachinePrivilege)
        {
            return FK_ModifyPrivilege(hComm, EnrollNumber, BackupNumber, MachinePrivilege);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_BenumbAllManager(int hComm);
        ///<summary>
        ///登记数据管理
        ///将所有登记用户至为一般用户
        ///</summary>
        public bool BenumbAllManager()
        {
            bool ret = false;
            if (!OpenFlag) Open();
            if (OpenFlag)
            {
                if (FK_BenumbAllManager(hComm) == (int)FKRun.RUN_SUCCESS) ret = true;
            }
            Close();
            return ret;
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_ReadAllUserID(int hComm);
        ///<summary>
        ///登记数据管理
        ///读取机器上所有登记资料
        ///</summary>
        public int ReadAllUserID()
        {
            return FK_ReadAllUserID(hComm);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_GetAllUserID(int hComm, ref UInt32 nEnrollNumber, ref int nBackupNumber,
          ref int nMachinePrivilege, ref int nEnable);
        ///<summary>
        ///登记数据管理
        ///将通过ReadAllUserID读取的登记资料一个一个获取
        ///</summary>
        public int GetAllUserID(ref UInt32 EnrollNumber, ref int BackupNumber, ref int MachinePrivilege, ref int Enable)
        {
            return FK_GetAllUserID(hComm, ref EnrollNumber, ref BackupNumber, ref MachinePrivilege, ref Enable);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_EmptyEnrollData(int hComm);
        ///<summary>
        ///登记数据管理
        ///删除所有登记资料
        ///</summary>
        public bool EmptyEnrollData()
        {
            bool ret = false;
            if (!OpenFlag) Open();
            if (OpenFlag)
            {
                if (FK_EmptyEnrollData(hComm) == (int)FKRun.RUN_SUCCESS) ret = true;
            }
            Close();
            return ret;
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_ClearKeeperData(int hComm);
        ///<summary>
        ///登记数据管理
        ///删除所有登记资料和记录数据，即初始化机器
        ///</summary>
        public bool ClearKeeperData()
        {
            bool ret = false;
            if (!OpenFlag) Open();
            if (OpenFlag)
            {
                if (FK_ClearKeeperData(hComm) == (int)FKRun.RUN_SUCCESS) ret = true;
            }
            Close();
            return ret;
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_SetFontName(int hComm, string FontName, int FontType);
        public int SetFontName(string FontName, int FontType)
        {
            return FK_SetFontName(hComm, FontName, FontType);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_GetUserName(int hComm, UInt32 nEnrollNumber, ref string nUserName);
        [DllImport(Dll_FK623Attend)]
        private static extern int FK_GetUserInfoEx(int hComm, UInt32 nEnrollNumber, ref byte UserInfo, ref int UserInfoLen);
        ///<summary>
        ///用户信息管理
        ///获取用户名称
        ///</summary>
        public bool GetUserName(UInt32 EnrollNumber, ref string UserName)
        {
            byte[] UserInfo = new byte[(int)FKMax.USER_INFO_SIZE_V2];
            int UserInfoLen = (int)FKMax.USER_INFO_SIZE_V2;
            UserData data = new UserData();
            data.Init();
            UserName = "";
            data.Size = (int)FKMax.USER_INFO_SIZE_V2;
            data.Ver = (int)FKMax.USER_INFO_VER2;
            data.YearAssigned = 2014;
            data.MonthAssigned = 12;
            ConvertStructToByteArray(data, UserInfo);
            int ErrCode = FK_GetUserInfoEx(hComm, EnrollNumber, ref UserInfo[0], ref UserInfoLen);
            bool ret = ErrCode == (int)FKRun.RUN_SUCCESS;
            if (ret)
            {
                data = (UserData)ConvertByteArrayToStruct(UserInfo, typeof(UserData));
                UserName = Encoding.GetEncoding("utf-16").GetString(data.UserName);
                UserName = UserName.Replace("\0", "").Trim();
            }
            else
            {
                ErrCode = FK_GetUserName(hComm, EnrollNumber, ref UserName);
                ret = ErrCode == (int)FKRun.RUN_SUCCESS;
            }
            return ret;
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_SetUserName(int hComm, UInt32 nEnrollNumber, string nUserName);
        [DllImport(Dll_FK623Attend)]
        private static extern int FK_SetUserInfoEx(int hComm, UInt32 nEnrollNumber, ref byte UserInfo, int UserInfoLen);
        ///<summary>
        ///用户信息管理
        ///设置用户名称
        ///</summary>
        public bool SetUserName(UInt32 EnrollNumber, string UserName, ref int ErrCode)
        {
            byte[] UserInfo = new byte[(int)FKMax.USER_INFO_SIZE_V2];
            int UserInfoLen = (int)FKMax.USER_INFO_SIZE_V2;
            UserData data = new UserData();
            data.Init();
            data.Size = (int)FKMax.USER_INFO_SIZE_V2;
            data.Ver = (int)FKMax.USER_INFO_VER2;
            data.YearAssigned = 2014;
            data.MonthAssigned = 12;
            data.UserId = EnrollNumber;
            Encoding.GetEncoding("utf-16").GetBytes(UserName).CopyTo(data.UserName, 0);
            ConvertStructToByteArray(data, UserInfo);
            ErrCode = FK_SetUserInfoEx(hComm, EnrollNumber, ref UserInfo[0], UserInfoLen);
            if (ErrCode != (int)FKRun.RUN_SUCCESS) ErrCode = FK_SetUserName(hComm, EnrollNumber, UserName);
            return ErrCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_GetNewsMessage(int hComm, int nNewsId, ref string nNews);
        ///<summary>
        ///用户信息管理
        ///获取通知信息
        ///</summary>
        private int GetNewsMessage(int NewsId, ref string News)
        {
            return FK_GetNewsMessage(hComm, NewsId, ref News);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_SetNewsMessage(int hComm, int nNewsId, string nNews);
        ///<summary>
        ///用户信息管理
        ///设置通知信息
        ///</summary>
        private int SetNewsMessage(int NewsId, string News)
        {
            return FK_SetNewsMessage(hComm, NewsId, News);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_GetUserNewsID(int hComm, UInt32 nEnrollNumber, ref int nNewsId);
        ///<summary>
        ///用户信息管理
        ///获取用户通知信息
        ///</summary>
        private int GetUserNewsID(UInt32 EnrollNumber, ref int NewsId)
        {
            return FK_GetUserNewsID(hComm, EnrollNumber, ref NewsId);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_SetUserNewsID(int hComm, UInt32 nEnrollNumber, int nNewsId);
        ///<summary>
        ///用户信息管理
        ///设置用户通知信息
        ///</summary>
        private int SetUserNewsID(UInt32 EnrollNumber, int NewsId)
        {
            return FK_SetUserNewsID(hComm, EnrollNumber, NewsId);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_GetDoorStatus(int hComm, ref int nStatusVal);
        ///<summary>
        ///门铃管理
        ///获取门状态
        ///</summary>
        public bool GetDoorStatus(ref int StatusVal)
        {
            ResultCode = FK_GetDoorStatus(hComm, ref StatusVal);
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_SetDoorStatus(int hComm, int nStatusVal);
        ///<summary>
        ///门铃管理
        ///设置门状态
        ///</summary>
        public bool SetDoorStatus(int StatusVal)
        {
            ResultCode = FK_SetDoorStatus(hComm, StatusVal);
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_GetPassTime(int hComm, int nPassTimeID, ref int nPassTime, int PassTimeSize);
        ///<summary>
        ///门铃管理
        ///获取时间段信息
        ///</summary>
        private int GetPassTime(int PassTimeID, ref int PassTime, int PassTimeSize)
        {
            return FK_GetPassTime(hComm, PassTimeID, ref PassTime, PassTimeSize);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_SetPassTime(int hComm, int nPassTimeID, ref int nPassTime, int PassTimeSize);
        ///<summary>
        ///门铃管理
        ///设置时间段信息
        ///</summary>
        private int SetPassTime(int PassTimeID, ref int PassTime, int PassTimeSize)
        {
            return FK_SetPassTime(hComm, PassTimeID, ref PassTime, PassTimeSize);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_GetUserPassTime(int hComm, UInt32 nEnrollNumber, ref int nGroupID, ref int nPassTime,
          int nPassTimeIDSize);
        ///<summary>
        ///门铃管理
        ///读取用户时间段信息
        ///</summary>
        private int GetUserPassTime(UInt32 EnrollNumber, ref int GroupID, ref int PassTime, int PassTimeIDSize)
        {
            return FK_GetUserPassTime(hComm, EnrollNumber, ref GroupID, ref PassTime, PassTimeIDSize);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_SetUserPassTime(int hComm, UInt32 nEnrollNumber, int nGroupID, ref int nPassTime,
          int nPassTimeIDSize);
        ///<summary>
        ///门铃管理
        ///设置用户时间段信息
        ///</summary>
        private int SetUserPassTime(UInt32 EnrollNumber, int GroupID, ref int PassTime, int PassTimeIDSize)
        {
            return FK_SetUserPassTime(hComm, EnrollNumber, GroupID, ref PassTime, PassTimeIDSize);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_GetGroupPassTime(int hComm, int nGroupID, ref int nPassTime, int nPassTimeIDSize);
        private int GetGroupPassTime(int GroupID, ref int PassTime, int PassTimeIDSize)
        {
            return FK_GetGroupPassTime(hComm, GroupID, ref PassTime, PassTimeIDSize);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_SetGroupPassTime(int hComm, int nGroupID, ref int nPassTime, int nPassTimeIDSize);
        private int SetGroupPassTime(int GroupID, ref int PassTime, int PassTimeIDSize)
        {
            return FK_SetGroupPassTime(hComm, GroupID, ref PassTime, PassTimeIDSize);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_GetGroupMatch(int hComm, ref int nGroupMatch, int nGroupMatchSize);
        private int GetGroupMatch(ref int GroupMatch, int GroupMatchSize)
        {
            return FK_GetGroupMatch(hComm, ref GroupMatch, GroupMatchSize);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_SetGroupMatch(int hComm, ref int nGroupMatch, int nGroupMatchSize);
        private int SetGroupMatch(ref int GroupMatch, int GroupMatchSize)
        {
            return FK_SetGroupMatch(hComm, ref GroupMatch, GroupMatchSize);
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_HS_GetTimeZone(int hComm, byte[] abytOneTimeZone);
        public bool HS_GetTimeZone(byte[] TimeZone)
        {
            ResultCode = FK_HS_GetTimeZone(hComm, TimeZone);
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_HS_SetTimeZone(int hComm, byte[] abytOneTimeZone);
        public bool HS_SetTimeZone(byte[] TimeZone)
        {
            ResultCode = FK_HS_SetTimeZone(hComm, TimeZone);
            return ResultCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend)]
        private static extern void FK_ConnectGetIP(ref string apnComName);
        private void ConnectGetIP(ref string apnComName)
        {
            FK_ConnectGetIP(ref apnComName);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_GetAdjustInfo(int hComm, ref int dwAdjustedState, ref int dwAdjustedMonth,
          ref int dwAdjustedDay, ref int dwAdjustedHour, ref int dwAdjustedMinute, ref int dwRestoredState,
          ref int dwRestoredMonth, ref int dwRestoredDay, ref int dwRestoredHour, ref int dwRestoredMinte);
        private int GetAdjustInfo(ref int dwAdjustedState, ref int dwAdjustedMonth, ref int dwAdjustedDay,
          ref int dwAdjustedHour, ref int dwAdjustedMinute, ref int dwRestoredState, ref int dwRestoredMonth,
          ref int dwRestoredDay, ref int dwRestoredHour, ref int dwRestoredMinte)
        {
            return FK_GetAdjustInfo(hComm, ref dwAdjustedState, ref dwAdjustedMonth, ref dwAdjustedDay, ref dwAdjustedHour,
              ref dwAdjustedMinute, ref dwRestoredState, ref dwRestoredMonth, ref dwRestoredDay, ref dwRestoredHour,
              ref dwRestoredMinte);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_SetAdjustInfo(int hComm, int dwAdjustedState, int dwAdjustedMonth, int dwAdjustedDay,
          int dwAdjustedHour, int dwAdjustedMinute, int dwRestoredState, int dwRestoredMonth, int dwRestoredDay,
          int dwRestoredHour, int dwRestoredMinte);
        private int SetAdjustInfo(int dwAdjustedState, int dwAdjustedMonth, int dwAdjustedDay, int dwAdjustedHour,
          int dwAdjustedMinute, int dwRestoredState, int dwRestoredMonth, int dwRestoredDay, int dwRestoredHour,
          int dwRestoredMinte)
        {
            return FK_SetAdjustInfo(hComm, dwAdjustedState, dwAdjustedMonth, dwAdjustedDay, dwAdjustedHour, dwAdjustedMinute,
              dwRestoredState, dwRestoredMonth, dwRestoredDay, dwRestoredHour, dwRestoredMinte);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_GetAccessTime(int hComm, UInt32 nEnrollNumber, ref int nAccessTime);
        private int GetAccessTime(UInt32 EnrollNumber, ref int nAccessTime)
        {
            return FK_GetAccessTime(hComm, EnrollNumber, ref nAccessTime);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_SetAccessTime(int hComm, UInt32 nEnrollNumber, int nAccessTime);
        private int SetAccessTime(UInt32 EnrollNumber, int nAccessTime)
        {
            return FK_SetAccessTime(hComm, EnrollNumber, nAccessTime);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_GetRealTimeInfo(int hComm, ref int nRealTime);
        private int GetRealTimeInfo(ref int nRealTime)
        {
            return FK_GetRealTimeInfo(hComm, ref nRealTime);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_SetRealTimeInfo(int hComm, ref int nRealTime);
        private int SetRealTimeInfo(ref int nRealTime)
        {
            return FK_SetRealTimeInfo(hComm, ref nRealTime);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_GetServerNetInfo(int hComm, ref string ServerIPAddress, ref int ServerPort,
          ref int ServerRequest);
        private int GetServerNetInfo(ref string ServerIPAddress, ref int ServerPort, ref int ServerRequest)
        {
            return FK_GetServerNetInfo(hComm, ref ServerIPAddress, ref ServerPort, ref ServerRequest);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_SetServerNetInfo(int hComm, string ServerIPAddress, int ServerPort, int ServerRequest);
        private int SetServerNetInfo(string ServerIPAddress, int ServerPort, int ServerRequest)
        {
            return FK_SetServerNetInfo(hComm, ServerIPAddress, ServerPort, ServerRequest);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_GetEnrollPhoto(int hComm, UInt32 nEnrollNumber, byte[] nPhotoImage, ref int nPhotoLength);
        public bool GetEnrollPhoto(UInt32 EnrollNumber, ref byte[] PhotoImage)
        {
            int PhotoSize = 0;
            PhotoImage = new byte[0];
            int ret = FK_GetEnrollPhoto(hComm, EnrollNumber, PhotoImage, ref PhotoSize);
            if (ret == (int)FKRun.RUN_SUCCESS)
            {
                PhotoImage = new byte[PhotoSize];
                ret = FK_GetEnrollPhoto(hComm, EnrollNumber, PhotoImage, ref PhotoSize);
            }
            return ret == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_SetEnrollPhoto(int hComm, UInt32 nEnrollNumber, byte[] nPhotoImage, int nPhotoLength);
        public bool SetEnrollPhoto(UInt32 EnrollNumber, byte[] PhotoImage, int PhotoSize)
        {
            int ret = FK_SetEnrollPhoto(hComm, EnrollNumber, PhotoImage, PhotoSize);
            return ret == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_DeleteEnrollPhoto(int hComm, UInt32 nEnrollNumber);
        private int DeleteEnrollPhoto(UInt32 EnrollNumber)
        {
            return FK_DeleteEnrollPhoto(hComm, EnrollNumber);
        }

        [DllImport(Dll_FK623Attend)]
        private static extern int FK_GetLogPhoto(int hComm, UInt32 nEnrollNumber, int nYear, int nMonth, int nDay,
          int nHour, int nMinute, int nSec, ref byte nPhotoImage, ref int nPhotoLength);
        public bool GetLogPhoto(UInt32 EnrollNumber, DateTime LogTime, ref byte[] PhotoImage)
        {
            int PhotoSize = 0;
            PhotoImage = new byte[4];
            int ret = FK_GetLogPhoto(hComm, EnrollNumber, LogTime.Year, LogTime.Month, LogTime.Day, LogTime.Hour,
              LogTime.Minute, LogTime.Second, ref PhotoImage[0], ref PhotoSize);
            if (ret == (int)FKRun.RUN_SUCCESS)
            {
                PhotoImage = new byte[PhotoSize];
                ret = FK_GetLogPhoto(hComm, EnrollNumber, LogTime.Year, LogTime.Month, LogTime.Day, LogTime.Hour,
                  LogTime.Minute, LogTime.Second, ref PhotoImage[0], ref PhotoSize);
            }
            return ret == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_IsSupportedEnrollData(int hComm, int nBackupNumber, ref int pnSupportFlag);
        public bool IsSupportedEnrollData(int nBackupNumber, ref bool nSupportFlag)
        {
            int flag = 0;
            int ret = FK_IsSupportedEnrollData(hComm, nBackupNumber, ref flag);
            nSupportFlag = flag != 0;
            return ret == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_ExtCommand(int hComm, byte[] buff);
        public bool ExtCommand(byte[] buff)
        {
            RunCode = FK_ExtCommand(hComm, buff);
            return RunCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_HS_GetUserWeekPassTime(int hComm, byte[] abytUserWeekPassTime);
        public bool HS_GetUserWeekPassTime(byte[] UserWeekPassTime)
        {
            RunCode = FK_HS_GetUserWeekPassTime(hComm, UserWeekPassTime);
            return RunCode == (int)FKRun.RUN_SUCCESS;
        }

        [DllImport(Dll_FK623Attend, CharSet = CharSet.Ansi)]
        private static extern int FK_HS_SetUserWeekPassTime(int hComm, byte[] abytUserWeekPassTime);
        public bool HS_SetUserWeekPassTime(byte[] UserWeekPassTime)
        {
            RunCode = FK_HS_SetUserWeekPassTime(hComm, UserWeekPassTime);
            return RunCode == (int)FKRun.RUN_SUCCESS;
        }

        public void StructToByteArray(object Struct, byte[] ByteArray)
        {
            try
            {
                IntPtr ptr = IntPtr.Zero;
                int Size = Marshal.SizeOf(Struct);
                if (ByteArray.Length < Size) return;
                ptr = Marshal.AllocHGlobal(Size);
                Marshal.StructureToPtr(Struct, ptr, false);
                Marshal.Copy(ptr, ByteArray, 0, Size);
                Marshal.FreeHGlobal(ptr);
            }
            catch
            {
            }
        }

        public object ByteArrayToStruct(byte[] ByteArray, System.Type Type)
        {
            object obj = null;
            IntPtr ptr;
            try
            {
                int Size = Marshal.SizeOf(Type);
                if (ByteArray.Length < Size) return null;
                ptr = Marshal.AllocHGlobal(Size);
                Marshal.Copy(ByteArray, 0, ptr, Size);
                obj = Marshal.PtrToStructure(ptr, Type);
                Marshal.FreeHGlobal(ptr);
                return obj;
            }
            catch
            {
                return null;
            }
        }

        private bool GetDeviceInfoForIndex(FKDI Index, ref string info)
        {
            int Value = 0;
            string s = "";
            ResultCode = GetDeviceInfo((int)Index, ref Value);
            bool ret = ResultCode == (int)FKRun.RUN_SUCCESS;
            if (ret)
                s = InfoIndexString((int)Index, Value);
            else
                s = ReturnResultPrint();
            s = "    " + s + "\r\n";
            info += s;
            return ret;
        }

        public bool GetDeviceInfoForIndex(FKDI Index, ref int Value)
        {
            Value = 0;
            ResultCode = GetDeviceInfo((int)Index, ref Value);
            bool ret = ResultCode == (int)FKRun.RUN_SUCCESS;
            return ret;
        }

        private bool GetDeviceStatusForIndex(FKDS Index, ref string info)
        {
            int Value = 0;
            string s = "";
            ResultCode = GetDeviceStatus((int)Index, ref Value);
            bool ret = ResultCode == (int)FKRun.RUN_SUCCESS;
            if (!ret) return true;
            s = StatusIndexString((int)Index, Value);
            s = "    " + s + "\r\n";
            info += s;
            return ret;
        }

        public bool GetDeviceStatusForIndex(FKDS Index, ref int Value)
        {
            Value = 0;
            ResultCode = GetDeviceStatus((int)Index, ref Value);
            bool ret = ResultCode == (int)FKRun.RUN_SUCCESS;
            return ret;
        }

        public bool GetDeviceInfo(ref string info)
        {
            bool ret = false;
            info = "";
            if (!OpenFlag) Open();
            if (OpenFlag)
            {
                if (EnableDevice(0) == (int)FKRun.RUN_SUCCESS)
                {
                    ret = GetDeviceInfoForIndex(FKDI.DI_MANAGERS, ref info);
                    if (!ret) goto DeviceExit;
                    ret = GetDeviceInfoForIndex(FKDI.DI_GLOG_WARNING, ref info);
                    if (!ret) goto DeviceExit;
                    ret = GetDeviceInfoForIndex(FKDI.DI_SLOG_WARNING, ref info);
                    if (!ret) goto DeviceExit;
                    ret = GetDeviceInfoForIndex(FKDI.DI_VERIFY_INTERVALS, ref info);
                    if (!ret) goto DeviceExit;
                    info += "\r\n";
                    ret = GetDeviceStatusForIndex(FKDS.GET_MANAGERS, ref info);
                    if (!ret) goto DeviceExit;
                    ret = GetDeviceStatusForIndex(FKDS.GET_USERS, ref info);
                    if (!ret) goto DeviceExit;
                    ret = GetDeviceStatusForIndex(FKDS.GET_PSWS, ref info);
                    if (!ret) goto DeviceExit;
                    ret = GetDeviceStatusForIndex(FKDS.GET_CARDS, ref info);
                    if (!ret) goto DeviceExit;
                    GetDeviceStatusForIndex(FKDS.GET_FPS, ref info);
                    //if (!ret) goto DeviceExit;
                    GetDeviceStatusForIndex(FKDS.GET_FACES, ref info);
                    //if (!ret) goto DeviceExit;
                    GetDeviceStatusForIndex(FKDS.GET_PALMVEINS, ref info);
                    //if (!ret) goto DeviceExit;
                    ret = GetDeviceStatusForIndex(FKDS.GET_SLOGS, ref info);
                    if (!ret) goto DeviceExit;
                    ret = GetDeviceStatusForIndex(FKDS.GET_GLOGS, ref info);
                    if (!ret) goto DeviceExit;
                    ret = GetDeviceStatusForIndex(FKDS.GET_ASLOGS, ref info);
                    if (!ret) goto DeviceExit;
                    ret = GetDeviceStatusForIndex(FKDS.GET_AGLOGS, ref info);
                    if (!ret) goto DeviceExit;
                }
            DeviceExit:
                EnableDevice(1);
            }
            Close();
            return ret;
        }
    }

    public class TSeaLog
    {
        private string _CardID = "";
        private DateTime _Time = new DateTime();
        private byte _ReadMark = 0;
        private string _Remark = "";
        private UInt32 _FingerNo = 0;
        private int _VerifyMode = 0;
        private string _VerifyModeName = "";
        private int _InOutMode = 0;
        private string _InOutModeName = "";
        private int _DoorMode = 0;
        private string _DoorModeName = "";
        private bool _Bell = false;
        private string _DoorStauts = "";
        private int _InOut = 0;
        private int _IoMode = 0;
        private string _MacSN = "";
        private string _GUID = "";
        private double _Temperature;
        private int _TemperatureAlarm;
        public double Temperature
        {
            get { return _Temperature; }
            set { _Temperature = value; }
        }
        public int TemperatureAlarm
        {
            get { return _TemperatureAlarm; }
            set { _TemperatureAlarm = value; }
        }
        public string GUID
        {
            get { return _GUID; }
            set { _GUID = value; }
        }

        public string CardID
        {
            get { return _CardID; }
            set { _CardID = value; }
        }

        public DateTime CardTime
        {
            get { return _Time; }
            set { _Time = value; }
        }

        public byte ReadMark
        {
            get { return _ReadMark; }
            set { _ReadMark = value; }
        }

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        public UInt32 FingerNo
        {
            get { return _FingerNo; }
            set { _FingerNo = value; }
        }

        public int VerifyMode
        {
            get { return _VerifyMode; }
            set { _VerifyMode = value; }
        }

        public string VerifyModeName
        {
            get { return _VerifyModeName; }
            set { _VerifyModeName = value; }
        }

        public int InOutMode
        {
            get { return _InOutMode; }
            set { _InOutMode = value; }
        }

        public int InOut
        {
            get { return _InOut; }
            set { _InOut = value; }
        }

        public string InOutModeName
        {
            get { return _InOutModeName; }
            set { _InOutModeName = value; }
        }

        public int DoorMode
        {
            get { return _DoorMode; }
            set { _DoorMode = value; }
        }

        public string DoorModeName
        {
            get { return _DoorModeName; }
            set { _DoorModeName = value; }
        }

        public bool Bell
        {
            get { return _Bell; }
            set { _Bell = value; }
        }

        public string DoorStauts
        {
            get { return _DoorStauts; }
            set { _DoorStauts = value; }
        }

        public int IoMode
        {
            get { return _IoMode; }
            set { _IoMode = value; }
        }
        public string MacSN
        {
            get { return _MacSN; }
            set { _MacSN = value; }
        }
    }

    public class TFingerLog
    {
        private string _CardID = "";
        private DateTime _Time = new DateTime();
        private byte _ReadMark = 0;

        public string CardID
        {
            get { return _CardID; }
            set { _CardID = value; }
        }

        public DateTime Time
        {
            get { return _Time; }
            set { _Time = value; }
        }

        public byte ReadMark
        {
            get { return _ReadMark; }
            set { _ReadMark = value; }
        }
    }

    public class FingerReadData
    {
        private Base Pub = new Base();
        private string cap = "";
        private string msgContinue = "";
        private byte IsNew = 0;
        private TFingerLog attLog = new TFingerLog();
        private bool IsStop = false;

        public delegate void ProcessReadData(int RecordCount, int RecordIndex);
        public delegate void ProcessRealData(TFingerLog attLog, int MacSN);
        public delegate void ProcessSeaRealData(TSeaLog attLog, int MacSN,string GUID);

        public FingerReadData(string title)
        {
            cap = title;
            msgContinue = Pub.GetResText("", "MsgContinue", "");
        }

        public FingerReadData(string title, byte NewData)
        {
            cap = title;
            msgContinue = Pub.GetResText("", "MsgContinue", "");
            IsNew = NewData;
        }

        public void StopData()
        {
            IsStop = true;
        }

        public bool FK623ReadData(Database db, KQTextFormatInfo textFormat, int MacSN, ref int RecordCount,
          ref int RecordIndex, ProcessReadData prog)
        {
            RecordCount = 0;
            RecordIndex = 0;
            bool ret = false;
            if (!DeviceObject.objFK623.IsOpen) DeviceObject.objFK623.Open();
            if (DeviceObject.objFK623.IsOpen)
            {
                if (DeviceObject.objFK623.EnableDevice(0) == (int)FKRun.RUN_SUCCESS)
                {
                    if (IsNew == 1)
                        ret = DeviceObject.objFK623.GetDeviceStatusForIndex(FKDS.GET_GLOGS, ref RecordCount);
                    else
                        ret = DeviceObject.objFK623.GetDeviceStatusForIndex(FKDS.GET_AGLOGS, ref RecordCount);
                    if (!ret || RecordCount == 0) goto DeviceSLog;
                    DeviceObject.objFK623.RunCode = DeviceObject.objFK623.LoadGeneralLogData(IsNew);
                    ret = DeviceObject.objFK623.RunCode == (int)FKRun.RUN_SUCCESS;
                    if (!ret) goto DeviceSLog;
                    UInt32 EnrollNumber = 0;
                    int VerifyMode = 0;
                    int InOutMode = 0;
                    DateTime dwDate = new DateTime();
                    do
                    {
                        if (IsStop) break;
                        Application.DoEvents();
                        DeviceObject.objFK623.RunCode = DeviceObject.objFK623.GetGeneralLogData(ref EnrollNumber,
                          ref VerifyMode, ref InOutMode, ref dwDate);
                        if (DeviceObject.objFK623.RunCode != (int)FKRun.RUN_SUCCESS)
                        {
                            if (DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_DATAARRAY_END)
                                DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                            break;
                        }
                        attLog = new TFingerLog();
                        attLog.CardID = EnrollNumber.ToString("0000000000");
                        attLog.Time = dwDate;
                        WriteTextFile(attLog, MacSN);
                        if (textFormat.Allow) WriteTextFormat(db, textFormat, attLog, MacSN);
                        SaveDB(db, attLog, MacSN, EnrollNumber);
                        RecordIndex = RecordIndex + 1;
                        prog(RecordCount, RecordIndex);
                    }
                    while (true);
                DeviceSLog:
                    int scnt = 0;
                    if (IsNew == 1)
                        ret = DeviceObject.objFK623.GetDeviceStatusForIndex(FKDS.GET_SLOGS, ref scnt);
                    else
                        ret = DeviceObject.objFK623.GetDeviceStatusForIndex(FKDS.GET_ASLOGS, ref scnt);
                    if (!ret || scnt == 0) goto DeviceExit;
                    DeviceObject.objFK623.RunCode = DeviceObject.objFK623.LoadSuperLogData(IsNew);
                    ret = DeviceObject.objFK623.RunCode == (int)FKRun.RUN_SUCCESS;
                    if (!ret) goto DeviceExit;
                    UInt32 SEnrollNo = 0;
                    UInt32 GEnrollNo = 0;
                    int Manipulation = 0;
                    int BakNo = 0;
                    dwDate = new DateTime();
                    do
                    {
                        if (IsStop) break;
                        Application.DoEvents();
                        DeviceObject.objFK623.RunCode = DeviceObject.objFK623.GetSuperLogData(ref SEnrollNo,
                          ref GEnrollNo, ref Manipulation, ref BakNo, ref dwDate);
                        if (DeviceObject.objFK623.RunCode != (int)FKRun.RUN_SUCCESS)
                        {
                            if (DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_DATAARRAY_END)
                                DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                            break;
                        }
                        SaveDBSLog(db, MacSN, SEnrollNo, GEnrollNo, Manipulation, BakNo, dwDate);
                    }
                    while (true);
                DeviceExit:
                    DeviceObject.objFK623.EnableDevice(1);
                }
            }
            DeviceObject.objFK623.Close();
            return ret;
        }

        public bool FK623ReadDataUSB(string usbFile, Database db, KQTextFormatInfo textFormat, ref int RecordCount,
          ref int RecordIndex, ProcessReadData prog)
        {
            RecordCount = 0;
            RecordIndex = 0;
            bool ret = false;
            int MacSN = 0;
            DeviceObject.objFK623.RunCode = DeviceObject.objFK623.USBLoadGeneralLogDataFromFile(usbFile);
            ret = DeviceObject.objFK623.RunCode == (int)FKRun.RUN_SUCCESS;
            if (!ret) return ret;
            UInt32 EnrollNumber = 0;
            int VerifyMode = 0;
            int InOutMode = 0;
            DateTime dwDate = new DateTime();
            do
            {
                DeviceObject.objFK623.RunCode = DeviceObject.objFK623.GetGeneralLogData(ref EnrollNumber, ref VerifyMode,
                  ref InOutMode, ref dwDate);
                if (DeviceObject.objFK623.RunCode != (int)FKRun.RUN_SUCCESS)
                {
                    if (DeviceObject.objFK623.RunCode == (int)FKRun.RUNERR_DATAARRAY_END)
                        DeviceObject.objFK623.RunCode = (int)FKRun.RUN_SUCCESS;
                    break;
                }
                attLog = new TFingerLog();
                attLog.CardID = EnrollNumber.ToString("0000000000");
                attLog.Time = dwDate;
                WriteTextFile(attLog, MacSN);
                if (textFormat.Allow) WriteTextFormat(db, textFormat, attLog, MacSN);
                SaveDB(db, attLog, MacSN, EnrollNumber);
                RecordIndex = RecordIndex + 1;
                RecordCount = RecordIndex;
                prog(RecordCount, RecordIndex);
            }
            while (true);
            return ret;
        }

        public bool Sea_FK623ReadData(Database db,KQTextFormatInfo textFormat, int MacSN, string url, string name, string pwd,
            string StarTime,string EndTime, ref int RecordCount,ref int RecordIndex, ProcessReadData prog)
        {
            RecordCount = 0;
            RecordIndex = 0;
            bool ret = false;
            int InOutMode = 0;
            string PhotoStr = "";
            int VerifyStatus = 0;
            int VerifyType = 0;
            List<string> sqlList = new List<string>();

            DataTableReader dr = null;
            dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_006001, new string[] { "4", MacSN.ToString() }));

            if (dr.Read())
            {
                int.TryParse(dr["MacInOut"].ToString(), out InOutMode);
            }

            try
            {
                DateTime dateTime = DateTime.Now.AddYears(10);
                string _strWorkingDayAM = "2000-01-01T00:00:00";
                string _strWorkingDayPM = dateTime.ToString("yyyy-MM-dd") + "T23:59:59";

                if(StarTime!="")
                {
                    _strWorkingDayAM = StarTime + "T00:00:00";
                }
                if(EndTime!="")
                {
                    _strWorkingDayPM = EndTime + "T23:59:59";
                }
             
                string selurl = url + "action/SearchControlNum";
                SearchControlNum searchControlNum = new SearchControlNum(MacSN.ToString(), _strWorkingDayAM, _strWorkingDayPM);

                jsonBody<SearchControlNum> jsonBodyNum = new jsonBody<SearchControlNum>("SearchControlNum", searchControlNum);
                string jsonBodyStr = JsonConvert.SerializeObject(jsonBodyNum);
                ret = DeviceObject.objFK623.POST_GetResponse(selurl, name, pwd, ref jsonBodyStr);

                if (!ret)
                {
                    return ret;
                }

                jsonBody<GetSearchControlNum> getMachineInfo = JsonConvert.DeserializeObject<jsonBody<GetSearchControlNum>>(jsonBodyStr);
                RecordCount = getMachineInfo.info.ControlNum;
                if (RecordCount == 0)
                {
                    return ret;
                }
                string urlRecord = url + "action/SearchControl";

                SearchControlCmd searchControlCmd = new SearchControlCmd(MacSN, _strWorkingDayAM, _strWorkingDayPM, 0, 100, 0);
                if (SystemInfo.IsGetDataPhoto)
                {
                    searchControlCmd.Picture = 2;
                    searchControlCmd.RequestCount = 50;
                }

                jsonBody<SearchControlCmd> jsonBody = new jsonBody<SearchControlCmd>("SearchControl", searchControlCmd);
                RecordIndex = 0;
                int Count = 0;
                int SendCount = 0;
                while (true)
                {
                    if (IsStop) break;
                    jsonBody.info.BeginNO = Count;
                    if (SystemInfo.IsGetDataPhoto)
                        Count = Count + 50;
                    else
                        Count = Count + 100;
                    string jsonString = JsonConvert.SerializeObject(jsonBody);
                EE:
                    ret = DeviceObject.objFK623.POST_GetResponse(urlRecord, name, pwd, ref jsonString);

                    if (!ret)
                    {
                        ret = true;
                        FK623Attend.SeaBody = Pub.GetResText("", "FK_RUN_SUCCESS", "");
                        break;
                    }

                    jsonBody <SearchControl<SearchInfo>> dataInfo = JsonConvert.DeserializeObject<jsonBody<SearchControl<SearchInfo>>>(jsonString);

                    if (dataInfo.info.TotalNum == 0)
                    {
                        SendCount++;
                        if (SendCount >= 3)
                        {
                            FK623Attend.SeaBody = Pub.GetResText("", "FK_RUN_SUCCESS", "");
                            break;
                        }
                        else
                            goto EE;
                    }

                    byte[] PhotoImage = new byte[0];
                    for (int i = 0; i < dataInfo.info.TotalNum; i++)
                    {
                        PhotoImage = new byte[0];
                        UInt32 FingerNo = 0;
                        UInt32.TryParse(dataInfo.info.SearchInfo[i].CustomizeID.ToString(), out FingerNo);
                        TSeaLog attLog = new TSeaLog();
                        attLog.CardID = FingerNo.ToString("0000000000");
                        attLog.CardTime = DateTime.Parse(dataInfo.info.SearchInfo[i].Time);
                        attLog.FingerNo = FingerNo;
                        attLog.InOutMode = InOutMode;
                        attLog.Temperature = dataInfo.info.SearchInfo[i].Temperature;
                        attLog.TemperatureAlarm = dataInfo.info.SearchInfo[i].TemperatureAlarm;
                        VerifyType = dataInfo.info.SearchInfo[i].VerfyType;
                        VerifyStatus = dataInfo.info.SearchInfo[i].VerifyStatus;

                        Sea_SetLogName(attLog, InOutMode, VerifyStatus, VerifyType);

                        if (dataInfo.info.SearchInfo[i].SnapPicinfo != null)
                        {
                            PhotoStr = dataInfo.info.SearchInfo[i].SnapPicinfo.Replace("data:image/jpeg;base64,", "");
                            if (PhotoStr.Length > 0)
                            {
                                PhotoImage = Convert.FromBase64String(PhotoStr);
                            }
                        }

                        WriteTextFile(attLog, MacSN);
                        if (textFormat.Allow) WriteTextFormat(db, textFormat, attLog, MacSN);
                        SeaSaveDB(db, attLog, MacSN, FingerNo, PhotoImage);

                        if (attLog.VerifyMode == 0)
                        {
                            attLog.VerifyMode = attLog.DoorMode;
                            attLog.VerifyModeName = attLog.DoorModeName;
                        }

                        SeaSaveDBMJ(db, attLog, MacSN.ToString(), PhotoImage);

                        RecordIndex = RecordIndex + 1;
                        prog(RecordCount, RecordIndex);
                    }

                }

              
            }
            catch (Exception ex)
            {
                Pub.ShowErrorMsg(ex);
            }
            finally
            {
                if (dr != null) dr.Close();
            }
            return ret;
        }

        public void Sea_SetLogName(TSeaLog attLog, int InOutMode, int VerifyStatus, int VerifyType)
        {
            //进出方式
            if (InOutMode == 0)
            {
                attLog.InOutModeName = Pub.GetResText("Public", "LOG_IOMODE_IO", "");
            }
            else if (InOutMode == 1)
            {
                attLog.InOutModeName = Pub.GetResText("Public", "LOG_IOMODE_IN1", "");
            }
            else if (InOutMode == 2)
            {
                attLog.InOutModeName = Pub.GetResText("Public", "LOG_IOMODE_OUT1", "");
            }

            //识别类型
            switch (VerifyType)
            {
                case 1:
                    attLog.VerifyMode = 20;
                    attLog.VerifyModeName = Pub.GetResText("Public", "LOG_FACEVERIFY", "");
                    break;
                case 2:
                case 21:
                case 24:
                    attLog.VerifyMode = 3;
                    attLog.VerifyModeName = Pub.GetResText("Public", "LOG_CARDVERIFY", "");
                    break;
                case 3:
                case 22:
                case 25:
                    attLog.VerifyMode = 21;
                    attLog.VerifyModeName = Pub.GetResText("Public", "LOG_FACECARDVERIFY", "");
                    break;
                case 27:
                    attLog.VerifyMode = 0;
                    attLog.VerifyModeName = Pub.GetResText("Public", "LOG_PROG_OPEN", "");
                    break;
            }

            if (VerifyStatus == 1)
            {
                attLog.DoorMode = 9;
                attLog.DoorModeName = Pub.GetResText("Public", "LOG_OPEN_DOOR", "");
            }
            else if (VerifyType == 27)
            {
                attLog.DoorMode = 3;
                attLog.DoorModeName = Pub.GetResText("Public", "LOG_PROG_OPEN", "");
            }
            else
            {
                attLog.DoorMode = 0;
            }

        }

        public bool Sea_SnapShotsData(Database db, KQTextFormatInfo textFormat, int MacSN, string url, string name, string pwd,
         string StarTime, string EndTime, ref int RecordCount, ref int RecordIndex, ProcessReadData prog)
        {
            RecordCount = 0;
            RecordIndex = 0;
            bool ret = false;
            List<string> sqlList = new List<string>();

            try
            {
                DateTime dateTime = DateTime.Now.AddYears(10);
                string _strWorkingDayAM = "2000-01-01T00:00:00";
                string _strWorkingDayPM = dateTime.ToString("yyyy-MM-dd") + "T23:59:59";

                if (StarTime != "")
                {
                    _strWorkingDayAM = StarTime + "T00:00:00";
                }
                if (EndTime != "")
                {
                    _strWorkingDayPM = EndTime + "T23:59:59";
                }

                string selurl = url + "action/SearchCaptureNum";
                SearchCaptureNum searchCaptureNum = new SearchCaptureNum(MacSN.ToString(), _strWorkingDayAM, _strWorkingDayPM);

                jsonBody<SearchCaptureNum> jsonBodyNum = new jsonBody<SearchCaptureNum>("SearchCaptureNum", searchCaptureNum);
                string jsonBodyStr = JsonConvert.SerializeObject(jsonBodyNum);
                ret = DeviceObject.objFK623.POST_GetResponse(selurl, name, pwd, ref jsonBodyStr);
                if (!ret)
                {
                    return ret;
                }
                jsonBody<GetSearchCaptureNum> getMachineInfo = JsonConvert.DeserializeObject<jsonBody<GetSearchCaptureNum>>(jsonBodyStr);
                RecordCount = getMachineInfo.info.CaptureNum;
                if (RecordCount == 0)
                {
                    return ret;
                }
                string urlRecord = url + "action/SearchCapture";

                SearchCapture searchCaptureCmd = new SearchCapture(MacSN, _strWorkingDayAM, _strWorkingDayPM, 0, 10);

                jsonBody<SearchCapture> jsonBody = new jsonBody<SearchCapture>("SearchCapture", searchCaptureCmd);
                int Count = 0;
                int SendCount = 0;
                while (true)
                {
                    if (IsStop) break;
                    jsonBody.info.BeginNO = Count;
                    Count = Count + 10;
                    string jsonString = JsonConvert.SerializeObject(jsonBody);
                EE:
                    ret = DeviceObject.objFK623.POST_GetResponse(urlRecord, name, pwd, ref jsonString);

                    if (!ret)
                    {
                        if (RecordIndex > 0)
                        {
                            ret = true;
                            FK623Attend.SeaBody = Pub.GetResText("", "FK_RUN_SUCCESS", "");
                        }

                        break;
                    }
                    jsonBody<GetSearchCapture<OneSearchCapture>> dataInfo = JsonConvert.DeserializeObject<jsonBody<GetSearchCapture<OneSearchCapture>>>(jsonString);

                    if (dataInfo.info.Listnum == 0)
                    {
                        SendCount++;
                        if (SendCount > 2)
                            break;
                        else
                            goto EE;
                    }

                    byte[] PhotoImage = null;
                    for (int i = 0; i < dataInfo.info.Listnum; i++)
                    {
                        PhotoImage = Convert.FromBase64String(dataInfo.info.List[i].SnapPicinfo.Replace("data:image/jpeg;base64,", ""));
                        DateTime time = Convert.ToDateTime(dataInfo.info.List[i].CreateTime);
                        db.SaveSnapLog(MacSN.ToString(), "0", time.ToString(SystemInfo.SQLDateTimeFMT), dataInfo.info.List[i].Temperature.ToString(), dataInfo.info.List[i].TemperatureAlarm.ToString(), PhotoImage);

                        RecordIndex = RecordIndex + 1;
                        prog(RecordCount, RecordIndex);
                    }

                }

            }
            catch (Exception ex)
            {
                Pub.ShowErrorMsg(ex);
            }
          
            return ret;
        }

        public void WriteTextFile(TSeaLog attLog, int MacSN, bool http)
        {
            WriteTextFile(attLog, MacSN);
        }
        private void WriteTextFile(TFingerLog attLog, int MacSN)
        {
            DateTime t = Convert.ToDateTime(attLog.Time);
            string fileName = SystemInfo.DataFilePath + "KQF" +
              DateTime.Now.Date.ToString(SystemInfo.DateFormatLog) + ".txt";
            string msg = attLog.ReadMark.ToString("00") + attLog.CardID + t.ToString(SystemInfo.DateTimeFormatLog) +
              MacSN.ToString("00000");
            Pub.WriteTextFile(fileName, msg);
        }
        private void WriteTextFile(TSeaLog attLog, int MacSN)
        {
            DateTime t = Convert.ToDateTime(attLog.CardTime);
            string fileName = SystemInfo.DataFilePath + "KQF" +
              DateTime.Now.Date.ToString(SystemInfo.DateFormatLog) + ".txt";
            string msg = attLog.ReadMark.ToString("00") + attLog.CardID + t.ToString(SystemInfo.DateTimeFormatLog) +
              MacSN.ToString("00000");
            Pub.WriteTextFile(fileName, msg);
        }
        private void WriteTextFormat(Database db, KQTextFormatInfo textFormat, TFingerLog attLog, int MacSN)
        {
            DataTableReader dr = null;
            string EmpNo = "";
            string EmpName = "";
            bool IsError = false;
            try
            {
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002001, new string[] { "106", "2", attLog.CardID }));
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
            string fileName = SystemInfo.DataFilePath + "KQF" +
              DateTime.Now.Date.ToString(SystemInfo.DateFormatLog) + "_Format.txt";
            string msg = textFormat.GetKQFormatText(MacSN, EmpNo, EmpName, attLog.CardID,
              Convert.ToDateTime(attLog.Time));
            Pub.WriteTextFile(fileName, msg);
        }

        public void WriteTextFormat(Database db, KQTextFormatInfo textFormat, TSeaLog attLog, int MacSN,bool http)
        {
            WriteTextFormat(db, textFormat, attLog, MacSN);
        }

        private void WriteTextFormat(Database db, KQTextFormatInfo textFormat, TSeaLog attLog, int MacSN)
        {
            DataTableReader dr = null;
            string EmpNo = "";
            string EmpName = "";
            bool IsError = false;
            try
            {
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002001, new string[] { "106", "2", attLog.CardID }));
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
            string fileName = SystemInfo.DataFilePath + "KQF" +
              DateTime.Now.Date.ToString(SystemInfo.DateFormatLog) + "_Format.txt";
            string msg = textFormat.GetKQFormatText(MacSN, EmpNo, EmpName, attLog.CardID,
              Convert.ToDateTime(attLog.CardTime));
            Pub.WriteTextFile(fileName, msg);
        }
        public bool SeaSaveDB(Database db, TSeaLog attLog, int MacSN, UInt32 EnrollNumber, byte[] PhotoImage)
        {
            string GUID = "";
            bool ret = SaveDB(db, attLog, MacSN, ref GUID);
            if (ret && GUID != "" && PhotoImage.Length > 0)
            {
                 SaveDBPhoto(db, GUID, PhotoImage);
            }
            return ret;
        }
        private string GetGUID()
        {
            string ret = System.Guid.NewGuid().ToString().ToUpper();
            return ret;
        }

        public bool SeaSaveDBMJ(Database db, TSeaLog attLog, string MacSN, byte[] PhotoImage)
        {
            string GUID = "";
            return SeaSaveDBMJ(db, attLog, MacSN, PhotoImage, ref GUID);
        }

        public bool SeaSaveDBMJ(Database db, TSeaLog attLog, string MacSN, byte[] PhotoImage,ref string GUID)
        {
            bool ret = false;
            GUID = GetGUID();
            string EmpSysID = "";
            DateTime t = attLog.CardTime;
            int KQTime = t.Hour * 60 * 60 + t.Minute * 60 + t.Second;
            int Alarm = 0;
            if (attLog.Bell) Alarm = 1;
            DataTableReader dr = null;
            string sql = "";
            try
            {
                sql = Pub.GetSQL(DBCode.DB_006001, new string[] { "11", MacSN, attLog.VerifyMode.ToString(), t.ToString(SystemInfo.SQLDateFMT), t.ToString(SystemInfo.SQLDateHMS) });
                dr = db.GetDataReader(sql);
                if (!dr.Read())
                {
                    dr.Close();
                    sql = Pub.GetSQL(DBCode.DB_006001, new string[] { "9", attLog.FingerNo.ToString() });
                    dr = db.GetDataReader(sql);
                    if (dr.Read())
                    {
                        EmpSysID = dr["EmpSysID"].ToString();
                    }
                    sql = Pub.GetSQL(DBCode.DB_006001, new string[] { "8", GUID, EmpSysID, MacSN, t.ToString(SystemInfo.SQLDateFMT),
                    KQTime.ToString(),attLog.DoorStauts,attLog.VerifyMode.ToString(),attLog.VerifyModeName,
                    attLog.InOutMode.ToString(),attLog.InOutModeName,OprtInfo.OprtNo,DateTime.Now.ToString(SystemInfo.SQLDateTimeFMT),
                    attLog.Remark,Alarm.ToString(),attLog.Temperature.ToString(),attLog.TemperatureAlarm.ToString()});
                    if (db.ExecSQL(sql) > 0)
                    {
                        if (GUID != "" && PhotoImage.Length > 0)
                        {
                            SeaSaveDBPhoto(db, GUID, PhotoImage);
                        }
                        ret = true;
                    }
                }
                else
                {
                    GUID = dr["GUID"].ToString();
                    if (GUID != "" && PhotoImage.Length > 0)
                    {
                        dr.Close();
                        sql = Pub.GetSQL(DBCode.DB_006001, new string[] { "13", GUID });
                        dr = db.GetDataReader(sql);
                        if (dr.Read())
                        {
                            db.UpdateByteData(Pub.GetSQL(DBCode.DB_006001, new string[] { "12", GUID }), "Photo", PhotoImage);
                        }
                        else
                        {
                            SeaSaveDBPhoto(db, GUID, PhotoImage);
                        }

                    }
                    ret = true;
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E, sql);
            }

            return ret;
        }

        public void SeaSaveDBPhoto(Database db, string GUID, byte[] phData)
        {
            db.UpdateByteData(Pub.GetSQL(DBCode.DB_006001, new string[] { "10", GUID }), "Photo", phData);
        }
        public bool SaveDB(Database db, TFingerLog attLog, int MacSN, UInt32 EnrollNumber)
        {
            string GUID = "";
            bool ret = SaveDB(db, attLog, MacSN, ref GUID);
            if (ret && GUID != "" && SystemInfo.IsGetDataPhoto)
            {
                byte[] PhotoImage = new byte[0];
                DateTime t = Convert.ToDateTime(attLog.Time);
                if (DeviceObject.objFK623.GetLogPhoto(EnrollNumber, t, ref PhotoImage)) SaveDBPhoto(db, GUID, PhotoImage);
            }
            return ret;
        }
       
        public bool SaveDB(Database db, TFingerLog attLog, int MacSN, ref string GUID)
        {
            bool ret = false;
            GUID = "";
            DateTime t = Convert.ToDateTime(attLog.Time);
            int KQTime = t.Hour * 60 * 60 + t.Minute * 60 + t.Second;
            string sql = Pub.GetSQL(DBCode.DB_002001, new string[] { "105", "2", attLog.CardID,
        t.ToString(SystemInfo.SQLDateFMT), KQTime.ToString(), MacSN.ToString(), "0", "",
        OprtInfo.OprtSysID, attLog.ReadMark.ToString() });
            DataTableReader dr = null;
            try
            {
                dr = db.GetDataReader(sql);
                if (dr.Read()) GUID = dr[0].ToString().Trim();
                ret = GUID != "";
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
        public bool SaveDB(Database db, TSeaLog attLog, int MacSN, ref string GUID)
        {
            bool ret = false;
            GUID = "";
            DateTime t = Convert.ToDateTime(attLog.CardTime);
            int KQTime = t.Hour * 60 * 60 + t.Minute * 60 + t.Second;
            string sql = Pub.GetSQL(DBCode.DB_002001, new string[] { "105", "2", attLog.CardID,
        t.ToString(SystemInfo.SQLDateFMT), KQTime.ToString(), MacSN.ToString(), "0", "",
        OprtInfo.OprtSysID, attLog.ReadMark.ToString() });
            DataTableReader dr = null;
            try
            {
                dr = db.GetDataReader(sql);
                if (dr.Read()) GUID = dr[0].ToString().Trim();
                ret = GUID != "";
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

        public void SaveDBPhoto(Database db, string GUID, byte[] phData)
        {
            db.UpdateByteData(Pub.GetSQL(DBCode.DB_002001, new string[] { "111", GUID }), "Photo", phData);
        }

        public void SaveDBPhoto(Database db, string GUID, string fileName)
        {
            if (File.Exists(fileName))
            {
                Image img = Image.FromFile(fileName);
                MemoryStream ms = new MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                int bufLen = (int)ms.Length;
                byte[] buff = new byte[bufLen];
                ms.Position = 0;
                ms.Read(buff, 0, bufLen);
                SaveDBPhoto(db, GUID, buff);
            }
        }

        public bool SaveDBSLog(Database db, int MacSN, UInt32 SEnrollNo, UInt32 GEnrollNo, int Manipulation,
          int BakNo, DateTime dwDate)
        {
            bool ret = false;
            string ManipulationName = "--";
            switch (Manipulation)
            {
                case (int)FKSLog.LOG_ENROLL_USER:
                    ManipulationName = "Enroll User";
                    break;
                case (int)FKSLog.LOG_ENROLL_MANAGER:
                    ManipulationName = "Enroll Manager";
                    break;
                case (int)FKSLog.LOG_ENROLL_DELFP:
                    ManipulationName = "Delete Fp Data";
                    break;
                case (int)FKSLog.LOG_ENROLL_DELPASS:
                    ManipulationName = "Delete Password";
                    break;
                case (int)FKSLog.LOG_ENROLL_DELCARD:
                    ManipulationName = "Delete Card Data";
                    break;
                case (int)FKSLog.LOG_LOG_ALLDEL:
                    ManipulationName = "Delete All LogData";
                    break;
                case (int)FKSLog.LOG_SETUP_SYS:
                    ManipulationName = "Modify System Info";
                    break;
                case (int)FKSLog.LOG_SETUP_TIME:
                    ManipulationName = "Modify System Time";
                    break;
                case (int)FKSLog.LOG_SETUP_LOG:
                    ManipulationName = "Modify Log Setting";
                    break;
                case (int)FKSLog.LOG_SETUP_COMM:
                    ManipulationName = "Modify Comm Setting";
                    break;
                case (int)FKSLog.LOG_PASSTIME:
                    ManipulationName = "Pass Time Set";
                    break;
                case (int)FKSLog.LOG_SETUP_DOOR:
                    ManipulationName = "Door Set Log";
                    break;
            }
            string BakName = "--";
            switch (BakNo)
            {
                case (int)FKBackup.BACKUP_FP_0:
                case (int)FKBackup.BACKUP_FP_1:
                case (int)FKBackup.BACKUP_FP_2:
                case (int)FKBackup.BACKUP_FP_3:
                case (int)FKBackup.BACKUP_FP_4:
                case (int)FKBackup.BACKUP_FP_5:
                case (int)FKBackup.BACKUP_FP_6:
                case (int)FKBackup.BACKUP_FP_7:
                case (int)FKBackup.BACKUP_FP_8:
                case (int)FKBackup.BACKUP_FP_9:
                    BakName = "Fp-" + BakNo.ToString();
                    break;
                case (int)FKBackup.BACKUP_PSW:
                    BakName = "Password";
                    break;
                case (int)FKBackup.BACKUP_CARD:
                    BakName = "Card";
                    break;
                case (int)FKBackup.BACKUP_FACE:
                    BakName = "Face";
                    break;
                case (int)FKBackup.BACKUP_PALMVEIN_0:
                case (int)FKBackup.BACKUP_PALMVEIN_1:
                case (int)FKBackup.BACKUP_PALMVEIN_2:
                case (int)FKBackup.BACKUP_PALMVEIN_3:
                    BakName = "PalmVein";
                    break;
            }
            string sql = Pub.GetSQL(DBCode.DB_002001, new string[] { "113", MacSN.ToString(), SEnrollNo.ToString(),
        GEnrollNo.ToString(), Manipulation.ToString(), ManipulationName, BakNo.ToString(), BakName,
        dwDate.ToString(SystemInfo.SQLDateTimeFMT), OprtInfo.OprtSysID });
            try
            {
                db.ExecSQL(sql);
                ret = true;
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E, sql);
            }
            string fileName = SystemInfo.DataFilePath + "KQ_SLOG" +
              DateTime.Now.Date.ToString(SystemInfo.DateFormatLog) + ".txt";
            string sep = "\t";
            string msg = SEnrollNo.ToString() + sep + SEnrollNo.ToString() + sep + Manipulation.ToString() +
              sep + BakNo.ToString() + sep + dwDate.ToString();
            Pub.WriteTextFile(fileName, msg);
            return ret;
        }
    }

    public class TDownSelectList
    {
        private string _empSysID = "";
        private bool _isSuccess = false;
        private UInt32 _enrollNumber = 0;
        private string _enrollName = "";
        private int _privilege = 0;
        private int _enableFlag = 0;

        public string EmpSysID
        {
            get { return _empSysID; }
            set { _empSysID = value; }
        }

        public bool IsSuccess
        {
            get { return _isSuccess; }
            set { _isSuccess = value; }
        }

        public UInt32 EnrollNumber
        {
            get { return _enrollNumber; }
            set { _enrollNumber = value; }
        }

        public string EnrollName
        {
            get { return _enrollName; }
            set { _enrollName = value; }
        }

        public int Privilege
        {
            get { return _privilege; }
            set { _privilege = value; }
        }

        public int EnableFlag
        {
            get { return _enableFlag; }
            set { _enableFlag = value; }
        }
    }

    public class TDownInfoList
    {
        private UInt32 _enrollNumber = 0;
        private bool _isReqName = false;

        public TDownInfoList(UInt32 EnrollNo, bool ReqName)
        {
            _enrollNumber = EnrollNo;
            _isReqName = ReqName;
        }

        public UInt32 EnrollNumber
        {
            get { return _enrollNumber; }
            set { _enrollNumber = value; }
        }

        public bool ReqName
        {
            get { return _isReqName; }
            set { _isReqName = value; }
        }
    }
}