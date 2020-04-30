using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Windows.Forms;
using QHKS;

namespace ECard78
{
    public class SFMealInfo
    {
        private Base Pub = new Base();
        private string[] _BeginTime = new string[4] { "00:00", "09:00", "13:00", "21:00" };
        private string[] _EndTime = new string[4] { "09:00", "13:00", "21:00", "00:00" };
        private double[] _DZAmount = new double[4] { 1, 1, 1, 1 };
        private double[] _JZAmount = new double[4] { 1, 1, 1, 1 };

        public SFMealInfo(string MealString)
        {
            string[] tmp = MealString.Split('@');
            if (tmp.Length == 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    string[] tmp1 = tmp[i].Split('#');
                    if (tmp1.Length != 4) break;
                    _BeginTime[i] = Pub.ValidatTime(tmp1[0]);
                    _EndTime[i] = Pub.ValidatTime(tmp1[1]);
                    double.TryParse(tmp1[2], out _DZAmount[i]);
                    double.TryParse(tmp1[3], out _JZAmount[i]);
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

        public double[] DZAmount
        {
            get { return _DZAmount; }
        }

        public double[] JZAmount
        {
            get { return _JZAmount; }
        }
    }

    public class SFParamInfo
    {
        private double _MaxCons = 0;
        private double _MaxDeposit = 0;
        private byte _ConsumptionWay = 1;
        private string _CardType = SystemInfo.CardTypeDefault;
        private bool _IsContinuous = false;
        private bool _IsNeedPWD = false;
        private bool _AllowUseAllowance = true;
        private byte _BtBagDate = 0;
        private string _ChkOrdering = "0000";
        private string _BTDate = "";
        private string _Title = "";
        private bool _Relay1 = false;
        private bool _Relay2 = false;
        private bool _AllowUseRecharge = true;
        private bool _FirstUseRecharge = false;

        public SFParamInfo(string ParamString)
        {
            string[] tmp = ParamString.Split('#');
            if (tmp.Length >= 15)
            {
                double.TryParse(tmp[0], out _MaxCons);
                double.TryParse(tmp[1], out _MaxDeposit);
                byte.TryParse(tmp[2], out _ConsumptionWay);
                _CardType = tmp[3];
                _IsContinuous = tmp[4] == "1";
                _IsNeedPWD = tmp[5] == "1";
                _AllowUseAllowance = tmp[6] == "1";
                byte.TryParse(tmp[7], out _BtBagDate);
                _ChkOrdering = tmp[8];
                if (_ChkOrdering == "") _ChkOrdering = "0000";
                _BTDate = tmp[9];
                _Title = tmp[10];
                _Relay1 = tmp[11] == "1";
                _Relay2 = tmp[12] == "1";
                _AllowUseRecharge = tmp[13] == "1";
                _FirstUseRecharge = tmp[14] == "1";
            }
        }

        public double MaxCons
        {
            get { return _MaxCons; }
        }

        public double MaxDeposit
        {
            get { return _MaxDeposit; }
        }

        public string Title
        {
            get { return _Title; }
        }

        public bool IsContinuous
        {
            get { return _IsContinuous; }
        }

        public bool IsNeedPWD
        {
            get { return _IsNeedPWD; }
        }

        public bool AllowUseAllowance
        {
            get { return _AllowUseAllowance; }
        }
        public bool Relay1
        {
            get { return _Relay1; }
        }

        public bool Relay2
        {
            get { return _Relay2; }
        }

        public byte ConsumptionWay
        {
            get { return _ConsumptionWay; }
        }

        public string ChkOrdering
        {
            get { return _ChkOrdering; }
        }

        public string CardType
        {
            get { return _CardType; }
        }
        public bool AllowUseRecharge
        {
            get { return _AllowUseRecharge; }
        }
        public bool FirstUseRecharge
        {
            get { return _FirstUseRecharge; }
        }
    }

    public class SFBellTime
    {
        private const string DefTime = "00:00";
        private Base Pub = new Base();
        private byte _RelayTimeout = 0;
        private byte _BellTimeout = 0;
        private string[] _BellTime = new string[6] { DefTime, DefTime, DefTime, DefTime, DefTime, DefTime };

        public SFBellTime(string BellString)
        {
            string[] tmp = BellString.Split('\t');
            if (tmp.Length >= 7)
            {
                byte.TryParse(tmp[0], out _RelayTimeout);
                byte.TryParse(tmp[1], out _BellTimeout);
                for (int i = 0; i <= 5; i++)
                {
                    _BellTime[i] = Pub.ValidatTime(tmp[i + 2]);
                }
            }
        }

        public byte RelayTimeout
        {
            get { return _RelayTimeout; }
        }

        public byte BellTimeout
        {
            get { return _BellTimeout; }
        }

        public string[] BellTime
        {
            get { return _BellTime; }
        }
    }

    public class SFLimitConsumption
    {
        private const double DefMoney = 0.00;
        private const byte DefCi = 0;
        private bool _ExistsLimit = false;
        private byte _LimitType = 1;
        private double[] _Money1;
        private double[] _Money2;
        private double[] _Money3;
        private double[] _Money4;
        private double[] _Money5;
        private byte[] _Ci1;
        private byte[] _Ci2;
        private byte[] _Ci3;
        private byte[] _Ci4;
        private byte[] _Ci5;
        private bool _AbovePass = false;

        public SFLimitConsumption(string limitString)
        {
            _Money1 = new double[SystemInfo.CardTypeCount];
            _Money2 = new double[SystemInfo.CardTypeCount];
            _Money3 = new double[SystemInfo.CardTypeCount];
            _Money4 = new double[SystemInfo.CardTypeCount];
            _Money5 = new double[SystemInfo.CardTypeCount];
            _Ci1 = new byte[SystemInfo.CardTypeCount];
            _Ci2 = new byte[SystemInfo.CardTypeCount];
            _Ci3 = new byte[SystemInfo.CardTypeCount];
            _Ci4 = new byte[SystemInfo.CardTypeCount];
            _Ci5 = new byte[SystemInfo.CardTypeCount];
            for (int i = 0; i < SystemInfo.CardTypeCount; i++)
            {
                _Money1[i] = DefMoney;
                _Money2[i] = DefMoney;
                _Money3[i] = DefMoney;
                _Money4[i] = DefMoney;
                _Money5[i] = DefMoney;
                _Ci1[i] = DefCi;
                _Ci2[i] = DefCi;
                _Ci3[i] = DefCi;
                _Ci4[i] = DefCi;
                _Ci5[i] = DefCi;
            }
            _ExistsLimit = false;
            string[] tmp = limitString.Split('@');
            if (tmp.Length >= SystemInfo.CardTypeCount + 3)
            {
                byte.TryParse(tmp[0], out _LimitType);
                if ((_LimitType != 1) && (_LimitType != 2)) _LimitType = 1;
                for (int i = 0; i < SystemInfo.CardTypeCount; i++)
                {
                    string[] tmp1 = tmp[i + 1].Split('#');
                    double.TryParse(tmp1[0], out _Money1[i]);
                    double.TryParse(tmp1[1], out _Money2[i]);
                    double.TryParse(tmp1[2], out _Money3[i]);
                    double.TryParse(tmp1[3], out _Money4[i]);
                    byte.TryParse(tmp1[4], out _Ci1[i]);
                    byte.TryParse(tmp1[5], out _Ci2[i]);
                    byte.TryParse(tmp1[6], out _Ci3[i]);
                    byte.TryParse(tmp1[7], out _Ci4[i]);
                    if (tmp1.Length >= 10)
                    {
                        double.TryParse(tmp1[8], out _Money5[i]);
                        byte.TryParse(tmp1[9], out _Ci5[i]);
                    }
                }
                _AbovePass = tmp[SystemInfo.CardTypeCount + 1] == "1";
                _ExistsLimit = true;
            }
        }

        public bool ExistsLimit
        {
            get { return _ExistsLimit; }
        }

        public byte LimitType
        {
            get { return _LimitType; }
        }

        public double[] Money1
        {
            get { return _Money1; }
        }

        public double[] Money2
        {
            get { return _Money2; }
        }

        public double[] Money3
        {
            get { return _Money3; }
        }

        public double[] Money4
        {
            get { return _Money4; }
        }

        public double[] Money5
        {
            get { return _Money5; }
        }

        public byte[] Ci1
        {
            get { return _Ci1; }
        }

        public byte[] Ci2
        {
            get { return _Ci2; }
        }

        public byte[] Ci3
        {
            get { return _Ci3; }
        }

        public byte[] Ci4
        {
            get { return _Ci4; }
        }

        public byte[] Ci5
        {
            get { return _Ci5; }
        }

        public bool AbovePass
        {
            get { return _AbovePass; }
        }
    }

    public class SFWithinDiscount
    {
        private const string DefTime = "* * * *";
        private bool _ExistsDisc = false;
        private string[] _CardTypeTime;

        public SFWithinDiscount(string discString)
        {
            _CardTypeTime = new string[SystemInfo.CardTypeCount];
            for (int i = 0; i < SystemInfo.CardTypeCount; i++)
            {
                _CardTypeTime[i] = DefTime;
            }
            _ExistsDisc = false;
            string[] tmp = discString.Split('@');
            if (tmp.Length >= SystemInfo.CardTypeCount)
            {
                for (int i = 0; i < SystemInfo.CardTypeCount; i++)
                {
                    _CardTypeTime[i] = tmp[i];
                }
                _ExistsDisc = true;
            }
        }

        public bool ExistsDisc
        {
            get { return _ExistsDisc; }
        }

        public string[] CardTypeTime
        {
            get { return _CardTypeTime; }
        }
    }

    public class SFConsumptionWay
    {
        private const string DefTime = "* * * * * * * * * * * * * * * * * * * * * * * *";
        private bool _ExistsWay = false;
        private byte _Way = 1;
        private byte _TwoBJ = 0;
        private string[] _CardTypeTime;

        public SFConsumptionWay(string wayString)
        {
            _CardTypeTime = new string[SystemInfo.CardTypeCount];
            for (int i = 0; i < SystemInfo.CardTypeCount; i++)
            {
                _CardTypeTime[i] = DefTime;
            }
            _ExistsWay = false;
            string[] tmp = wayString.Split('@');
            if (tmp.Length >= SystemInfo.CardTypeCount + 2)
            {
                byte.TryParse(tmp[0], out _Way);
                if (_Way == 3) _Way = 2;
                if ((_Way != 1) && (_Way != 2)) _Way = 1;
                byte.TryParse(tmp[1], out _TwoBJ);
                for (int i = 0; i < SystemInfo.CardTypeCount; i++)
                {
                    _CardTypeTime[i] = tmp[i + 2];
                }
                _ExistsWay = true;
            }
        }

        public bool ExistsWay
        {
            get { return _ExistsWay; }
        }

        public byte TwoBJ
        {
            get { return _TwoBJ; }
        }

        public byte Way
        {
            get { return _Way; }
        }

        public string[] CardTypeTime
        {
            get { return _CardTypeTime; }
        }
    }

    public class SFCardLowBalance
    {
        private const string Def = "*";
        private bool _ExistsLowBalance = false;
        private string[] _LowBalance;

        public SFCardLowBalance(string lowString)
        {
            _LowBalance = new string[SystemInfo.CardTypeCount];
            for (int i = 0; i < SystemInfo.CardTypeCount; i++)
            {
                _LowBalance[i] = Def;
            }
            _ExistsLowBalance = false;
            string[] tmp = lowString.Split('@');
            if (tmp.Length >= SystemInfo.CardTypeCount)
            {
                for (int i = 0; i < SystemInfo.CardTypeCount; i++)
                {
                    _LowBalance[i] = tmp[i];
                }
                _ExistsLowBalance = true;
            }
        }

        public bool ExistsLowBalance
        {
            get { return _ExistsLowBalance; }
        }

        public string[] LowBalance
        {
            get { return _LowBalance; }
        }
    }

    public class SFTiming
    {
        private const string Def = "/ / / / / / / / / / / / / / / / / / / ";
        private bool _ExistsTiming = false;
        private byte _Units = 1;
        private byte _Way = 1;
        private byte _MinuteMin = 0;
        private byte _MinuteMax = 0;
        private byte _MinuteFree = 0;
        private bool _DecFree = false;
        private string[] _Info = new string[20] { Def, Def, Def, Def, Def, Def, Def, Def, Def, Def, Def, Def, Def,
      Def, Def, Def, Def, Def, Def, Def };

        public SFTiming(string timingStr)
        {
            _ExistsTiming = false;
            string[] tmp = timingStr.Split('@');
            if (tmp.Length >= 26)
            {
                byte.TryParse(tmp[0], out _Units);
                byte.TryParse(tmp[1], out _Way);
                if ((_Way < 1) || (_Way > 4)) _Way = 1;
                byte.TryParse(tmp[2], out _MinuteMin);
                byte.TryParse(tmp[3], out _MinuteMax);
                byte.TryParse(tmp[4], out _MinuteFree);
                _DecFree = tmp[5] == "1";
                for (int i = 0; i < 20; i++)
                {
                    _Info[i] = tmp[i + 6];
                }
                _ExistsTiming = true;
            }
        }

        public bool ExistsTiming
        {
            get { return _ExistsTiming; }
        }

        public byte Units
        {
            get { return _Units; }
        }

        public byte Way
        {
            get { return _Way; }
        }

        public byte MinuteMin
        {
            get { return _MinuteMin; }
        }

        public byte MinuteMax
        {
            get { return _MinuteMax; }
        }

        public byte MinuteFree
        {
            get { return _MinuteFree; }
        }

        public bool DecFree
        {
            get { return _DecFree; }
        }

        public string[] Info
        {
            get { return _Info; }
        }
    }

    public class SFOrdering
    {
        private const byte DefNextDay = 0;
        private const byte DefRestday = 0;
        private const string DefTime = "00:00";
        private bool _ExistsOrdering = false;
        private bool _IsPayMoney = false;
        private byte _OrderType = 1;
        private string _OrderMemo = "0000000000000000";
        private byte _Units = 1;
        private byte[] _IsNextDay = new byte[4] { DefNextDay, DefNextDay, DefNextDay, DefNextDay };
        private string[] _BeginTime = new string[4] { DefTime, DefTime, DefTime, DefTime };
        private string[] _EndTime = new string[4] { DefTime, DefTime, DefTime, DefTime };
        private byte[] _Restday = new byte[7] { DefRestday, DefRestday, DefRestday, DefRestday, DefRestday, DefRestday, DefRestday };

        public SFOrdering(string orderStr)
        {
            _ExistsOrdering = false;
            string[] tmp = orderStr.Split('@');
            if (tmp.Length >= 23)
            {
                _IsPayMoney = tmp[0].ToUpper() == "Y";
                byte.TryParse(tmp[1], out _OrderType);
                if ((_OrderType < 1) || (_OrderType > 2)) _OrderType = 1;
                _OrderMemo = tmp[2];
                byte.TryParse(tmp[3], out _Units);
                if ((_Units < 1) || (_Units > 7)) _Units = 1;
                for (int i = 0; i < 4; i++)
                {
                    byte.TryParse(tmp[i + 4], out _IsNextDay[i]);
                    _BeginTime[i] = tmp[i + 8];
                    _EndTime[i] = tmp[i + 12];
                }
                _ExistsOrdering = true;
                for (int i = 0; i < 7; i++)
                {
                    byte.TryParse(tmp[i + 16], out _Restday[i]);
                }
            }
            else if(tmp.Length >= 17 && tmp.Length < 23)
            {
                _IsPayMoney = tmp[0].ToUpper() == "Y";
                byte.TryParse(tmp[1], out _OrderType);
                if ((_OrderType < 1) || (_OrderType > 2)) _OrderType = 1;
                _OrderMemo = tmp[2];
                byte.TryParse(tmp[3], out _Units);
                if ((_Units < 1) || (_Units > 7)) _Units = 1;
                for (int i = 0; i < 4; i++)
                {
                    byte.TryParse(tmp[i + 4], out _IsNextDay[i]);
                    _BeginTime[i] = tmp[i + 8];
                    _EndTime[i] = tmp[i + 12];
                }
                _ExistsOrdering = true;
            }
        }

        public bool ExistsOrdering
        {
            get { return _ExistsOrdering; }
        }

        public bool IsPayMoney
        {
            get { return _IsPayMoney; }
        }

        public byte OrderType
        {
            get { return _OrderType; }
        }

        public string OrderMemo
        {
            get { return _OrderMemo; }
        }

        public byte Units
        {
            get { return _Units; }
        }

        public byte[] IsNextDay
        {
            get { return _IsNextDay; }
        }

        public string[] BeginTime
        {
            get { return _BeginTime; }
        }

        public string[] EndTime
        {
            get { return _EndTime; }
        }

        public byte[] Restday
        {
            get { return _Restday; }
        }
    }

    public class SFReadData
    {
        private Base Pub = new Base();
        private string cap = "";
        private string msgContinue = "";
        private string MsgRec = "";
        private bool IsNew = false;
        private int logCount = 0;
        private TFeeLog feeLog = new TFeeLog();
        private bool IsStop = false;

        public delegate void ProcessReadData(int RecordCount, int RecordIndex, string msg);
        public delegate void ProcessRealData(TFeeLog feeLog, int MacSN);

        public SFReadData(string title)
        {
            cap = title;
            msgContinue = Pub.GetResText("", "MsgContinue", "");
            MsgRec = Pub.GetResText("", "MsgRecordCountXF", "");
        }

        public SFReadData(string title, bool NewData)
        {
            cap = title;
            msgContinue = Pub.GetResText("", "MsgContinue", "");
            MsgRec = Pub.GetResText("", "MsgRecordCountXF", "");
            IsNew = NewData;
        }

        public void StopData()
        {
            IsStop = true;
        }

        private bool GetOrderType(Database db, int MacSN, ref byte OrderType)
        {
            OrderType = 0;
            bool ret = false;
            DataTableReader dr = null;
            string orderStr = "";
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004004, new string[] { "8", MacSN.ToString() }));
                if (dr.Read())
                {
                    orderStr = dr["Ordering"].ToString();
                    SFOrdering order = new SFOrdering(orderStr);
                    OrderType = order.OrderType;
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

        public bool ReadData(Database db, int MacSN, int MacType, ref string msg, bool AutoRetry, ProcessReadData prog)
        {
            return ReadData(db, MacSN, MacType, ref msg, AutoRetry, prog, null);
        }

        public bool ReadData(Database db, int MacSN, int MacType, ref string msg, bool AutoRetry, ProcessRealData prog)
        {
            return ReadData(db, MacSN, MacType, ref msg, AutoRetry, null, prog);
        }

        private bool ReadData(Database db, int MacSN, int MacType, ref string msg, bool AutoRetry, ProcessReadData prog,
          ProcessRealData progReal)
        {
            msg = "";
            byte orderType = 0;
            if (!GetOrderType(db, MacSN, ref orderType)) return false;
            bool ret = false;
            TRecordCount recCount = new TRecordCount();
            if (!DeviceObject.objKS.FeeLogCount(IsNew, ref recCount)) return false;
            if (recCount.Count == 0) return true;
            DialogResult result;
            int OrderCount = 0;
            DateTime orderDate;
            DataTableReader drt = null;
            int RecIndex = 0;
            int nIndex = 0;
            int aIndex = 0;
            int rIndex = 0;
            int fIndex = 0;
            double RecMoney = 0;
            double nMoney = 0;
            double aMoney = 0;
            double rMoney = 0;
            double fMoney = 0;
            DateTime date = new DateTime();
            bool falg = false;
            bool IsTitel = true;
            for (int i = 1; i <= recCount.Sector; i++)
            {
            RetryReadData:
                if (IsStop)
                {
                    DeviceObject.objKS.Close();
                    break;
                }
                Application.DoEvents();
                if (MacType == 36)
                    ret = DeviceObject.objKS.FeeLogDataOrder(SystemInfo.DataFilePath, IsNew, i, ref logCount);
                else
                    ret = DeviceObject.objKS.FeeLogData(SystemInfo.DataFilePath, IsNew, i, ref logCount);
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
                    if (MacType != 36)
                    {
                        if (RecIndex >= recCount.Count) break;
                    }
                    if (DeviceObject.objKS.FeeLogDataValue(j, ref feeLog))
                    {
                        drt = db.GetDataReader(Pub.GetSQL(DBCode.DB_004007, new string[] { "0" }));
                        if (drt.Read())
                        {
                            date = Convert.ToDateTime(drt["CheckOutDate"]);
                            date = date.AddDays(1);
                            falg = true;
                        }

                        //if (feeLog.BTWay != 0)
                        //{
                        //   feeLog.SFType = 130;    
                        //}
                        if (MacType == 36)
                        {
                            if ((OrderCount == 0) && (RecIndex >= recCount.Count)) break;
                            if (OrderCount == 0) OrderCount = feeLog.OrderCount;
                            OrderCount--;
                            if (orderType == 2)
                            {
                                orderDate = feeLog.OrderDate.AddDays(1);
                                feeLog.OrderDate = orderDate;
                            }
                        }
                        WriteTextFile(feeLog, MacSN, MacType, IsNew);

                        if (falg)
                        {
                            
                            if (date > feeLog.SFDate)
                            {
                                if (feeLog.IsCount != 0)
                                {
                                    RecIndex++;
                                    aIndex++;
                                }

                                RecMoney += Math.Abs(feeLog.CZAmount) + Math.Abs(feeLog.BTAmount) + Math.Abs(feeLog.BTWay);
                                aMoney += Math.Abs(feeLog.CZAmount) + Math.Abs(feeLog.BTAmount) + Math.Abs(feeLog.BTWay);
                                if (IsTitel)
                                {
                                    Pub.ShowErrorMsg(string.Format(Pub.GetResText("", "MsgCardUseDateDev", ""), date, feeLog.SFDate));
                                    IsTitel = false;
                                }
                                goto END;
                            }

                        }

                        if (feeLog.ReadMark == 2)
                        {
                            SaveErrorDB(db, feeLog, MacSN, MacType, IsNew);
                            if (feeLog.IsCount != 0)
                            {
                                RecIndex++;
                                aIndex++;
                            }
                            RecMoney += Math.Abs(feeLog.CZAmount) + Math.Abs(feeLog.BTAmount) + Math.Abs(feeLog.BTWay);
                            nMoney += Math.Abs(feeLog.CZAmount) + Math.Abs(feeLog.BTAmount) + Math.Abs(feeLog.BTWay);
                        }
                        else if (feeLog.ReadMark == 3)
                        {
                            SaveReturnDB(db, feeLog, MacSN, MacType, IsNew);
                            if (feeLog.IsCount != 0)
                            {
                                RecIndex++;
                                rIndex++;
                            }
                            RecMoney += Math.Abs(feeLog.CZAmount) + Math.Abs(feeLog.BTAmount) + Math.Abs(feeLog.BTWay);
                            nMoney += Math.Abs(feeLog.CZAmount) + Math.Abs(feeLog.BTAmount) + Math.Abs(feeLog.BTWay);
                        }
                        else if (feeLog.ReadMark == 0xf0)
                        {
                            SaveMobileFailDB(db, feeLog, MacSN, MacType, IsNew);
                            if (feeLog.IsCount != 0)
                            {
                                RecIndex++;
                                fIndex++;
                            }
                            RecMoney += Math.Abs(feeLog.CZAmount) + Math.Abs(feeLog.BTAmount) + Math.Abs(feeLog.BTWay);
                            nMoney += Math.Abs(feeLog.CZAmount) + Math.Abs(feeLog.BTAmount) + Math.Abs(feeLog.BTWay);
                        }
                        else if (feeLog.ReadMark != 0xff)
                        {
                            SaveDB(db, feeLog, MacSN, MacType, IsNew);
                            if (feeLog.IsCount != 0)
                            {
                                RecIndex++;
                                nIndex++;
                            }
                            RecMoney += Math.Abs(feeLog.CZAmount) + Math.Abs(feeLog.BTAmount) + Math.Abs(feeLog.BTWay);
                            nMoney += Math.Abs(feeLog.CZAmount) + Math.Abs(feeLog.BTAmount) + Math.Abs(feeLog.BTWay);
                        }

                    END:
                        if (RecIndex > recCount.Count) RecIndex = recCount.Count;
                        msg = string.Format(MsgRec, RecIndex.ToString() + "/" + recCount.Count.ToString(),
                          RecMoney.ToString(SystemInfo.CurrencySymbol + "0.00"),
                          nIndex.ToString() + "(" + nMoney.ToString(SystemInfo.CurrencySymbol + "0.00") + ")",
                          aIndex.ToString() + "(" + aMoney.ToString(SystemInfo.CurrencySymbol + "0.00") + ")",
                          rIndex.ToString() + "(" + rMoney.ToString(SystemInfo.CurrencySymbol + "0.00") + ")",
                          fIndex.ToString() + "(" + fMoney.ToString(SystemInfo.CurrencySymbol + "0.00") + ")");
                        if (prog != null) prog(recCount.Count, RecIndex, msg);
                        if (progReal != null) progReal(feeLog, MacSN);
                    }
                }
            }
            if (ret && IsNew && recCount.Count > 0 && !IsStop)
            {
            RetryFlag:
                ret = DeviceObject.objKS.FeeLogFlag(recCount.Count);
                if (!ret)
                {
                    if (AutoRetry) goto RetryFlag;
                    if (!Pub.MessageBoxShowQuestion(cap + "\r\n\r\n" +
                      DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue)) goto RetryFlag;
                }
            }
            return ret;
        }

        public bool ReadDataUSB(string usbFile, Database db, ref string msg, ProcessReadData prog)
        {
            msg = "";
            bool ret = false;
            TRecordCountUSB recCount = new TRecordCountUSB();
            bool IsBigMac = SystemInfo.IsBigMacAdd;
            int OrderCount = 0;
            int RecIndex = 0;
            int nIndex = 0;
            int aIndex = 0;
            int rIndex = 0;
            int fIndex = 0;
            double RecMoney = 0;
            double nMoney = 0;
            double aMoney = 0;
            double rMoney = 0;
            double fMoney = 0;
            bool NewData = usbFile.IndexOf("N") > 0;
            try
            {
                ret = DeviceObject.objKS.FeeLogCountUSB(IsBigMac, usbFile, ref recCount);
                if (!ret)
                {
                    Pub.ShowErrorMsg(Pub.GetResText("", "ErrorSFUSB", ""));
                    return false;
                }
                if ((recCount.MacType != 2) && (recCount.MacType != 3) && (recCount.MacType != 4) &&
                  (recCount.MacType != 5) && (recCount.MacType != 6))
                {
                    Pub.ShowErrorMsg(Pub.GetResText("", "ErrorSFUSBType", ""));
                    return false;
                }
                if (recCount.Count == 0) ret = true;
                int MacSN = recCount.MacSN;
                byte MacType = Convert.ToByte(recCount.MacType + 30);
                string MacVer = recCount.Ver;
                byte orderType = 0;
                if (!GetOrderType(db, MacSN, ref orderType)) return false;
                DateTime orderDate;
                DateTime date = new DateTime();
                bool falg = false;
                bool IsTitel = true;
                DataTableReader drt = null;
                drt = db.GetDataReader(Pub.GetSQL(DBCode.DB_004007, new string[] { "0" }));
                if (drt.Read())
                {
                    date = Convert.ToDateTime(drt["CheckOutDate"]);
                    date = date.AddDays(1);
                    falg = true;
                }
                for (int i = 1; i <= recCount.Sector; i++)
                {
                    if (MacType == 36)
                        ret = DeviceObject.objKS.FeeLogDataOrderUSB(MacVer, IsBigMac, i, ref logCount);
                    else
                        ret = DeviceObject.objKS.FeeLogDataUSB(MacVer, IsBigMac, i, ref logCount);
                    if (ret)
                    {
                        for (int j = 0; j < logCount; j++)
                        {
                            if (MacType != 36)
                            {
                                if (RecIndex >= recCount.Count) break;
                            }
                            if (DeviceObject.objKS.FeeLogDataValue(j, ref feeLog))
                            {
                                //if (feeLog.BTWay != 0)
                                //{
                                //    feeLog.SFType = 130;    
                                //}
                                if (MacType == 36)
                                {
                                    if ((OrderCount == 0) && (RecIndex >= recCount.Count)) break;
                                    if (OrderCount == 0) OrderCount = feeLog.OrderCount;
                                    OrderCount--;
                                    if (orderType == 2)
                                    {
                                        orderDate = feeLog.OrderDate.AddDays(1);
                                        feeLog.OrderDate = orderDate;
                                    }
                                }
                                WriteTextFile(feeLog, MacSN, MacType, NewData);
                                if (falg)
                                {
                                   
                                    if (date > feeLog.SFDate)
                                    {
                                        if (feeLog.IsCount != 0)
                                        {
                                            RecIndex++;
                                            aIndex++;
                                        }

                                        RecMoney += Math.Abs(feeLog.CZAmount) + Math.Abs(feeLog.BTAmount) + Math.Abs(feeLog.BTWay);
                                        aMoney += Math.Abs(feeLog.CZAmount) + Math.Abs(feeLog.BTAmount) + Math.Abs(feeLog.BTWay);
                                        if(IsTitel)
                                        {
                                            Pub.ShowErrorMsg(string.Format(Pub.GetResText("", "MsgCardUseDateDev", ""), date, feeLog.SFDate));
                                            IsTitel = false;
                                        }
                                      
                                        goto END;
                                    }

                                }
                                if (feeLog.ReadMark == 2)
                                {
                                    SaveErrorDB(db, feeLog, MacSN, MacType, NewData);
                                    if (feeLog.IsCount != 0)
                                    {
                                        RecIndex++;
                                        aIndex++;
                                    }
                                    RecMoney += Math.Abs(feeLog.CZAmount) + Math.Abs(feeLog.BTAmount) + Math.Abs(feeLog.BTWay);
                                    aMoney += Math.Abs(feeLog.CZAmount) + Math.Abs(feeLog.BTAmount) + Math.Abs(feeLog.BTWay);
                                }
                                else if (feeLog.ReadMark == 3)
                                {
                                    SaveReturnDB(db, feeLog, MacSN, MacType, NewData);
                                    if (feeLog.IsCount != 0)
                                    {
                                        RecIndex++;
                                        rIndex++;
                                    }
                                    RecMoney += Math.Abs(feeLog.CZAmount) + Math.Abs(feeLog.BTAmount) + Math.Abs(feeLog.BTWay);
                                    rMoney += Math.Abs(feeLog.CZAmount) + Math.Abs(feeLog.BTAmount) + Math.Abs(feeLog.BTWay);
                                }
                                else if (feeLog.ReadMark == 0xf0)
                                {
                                    SaveMobileFailDB(db, feeLog, MacSN, MacType, IsNew);
                                    if (feeLog.IsCount != 0)
                                    {
                                        RecIndex++;
                                        fIndex++;
                                    }
                                    RecMoney += Math.Abs(feeLog.CZAmount) + Math.Abs(feeLog.BTAmount) + Math.Abs(feeLog.BTWay);
                                    fMoney += Math.Abs(feeLog.CZAmount) + Math.Abs(feeLog.BTAmount) + Math.Abs(feeLog.BTWay);
                                }
                                else if (feeLog.ReadMark != 0xff)
                                {
                                    SaveDB(db, feeLog, MacSN, MacType, NewData);
                                    if (feeLog.IsCount != 0)
                                    {
                                        RecIndex++;
                                        nIndex++;
                                    }
                                    RecMoney += Math.Abs(feeLog.CZAmount) + Math.Abs(feeLog.BTAmount) + Math.Abs(feeLog.BTWay);
                                    nMoney += Math.Abs(feeLog.CZAmount) + Math.Abs(feeLog.BTAmount) + Math.Abs(feeLog.BTWay);
                                }
                            END:
                                if (RecIndex > recCount.Count) RecIndex = recCount.Count;
                                msg = string.Format(MsgRec, RecIndex.ToString() + "/" + recCount.Count.ToString(),
                                  RecMoney.ToString(SystemInfo.CurrencySymbol + "0.00"),
                                  nIndex.ToString() + "(" + nMoney.ToString(SystemInfo.CurrencySymbol + "0.00") + ")",
                                  aIndex.ToString() + "(" + aMoney.ToString(SystemInfo.CurrencySymbol + "0.00") + ")",
                                  rIndex.ToString() + "(" + rMoney.ToString(SystemInfo.CurrencySymbol + "0.00") + ")",
                                  fIndex.ToString() + "(" + fMoney.ToString(SystemInfo.CurrencySymbol + "0.00") + ")");
                                prog(recCount.Count, RecIndex, msg);
                            }
                        }
                    }
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            // db.WriteSYLog(Pub.GetResText("", "ErrorSFUSBType", ""), Pub.GetResText("", "ErrorSFUSBType", ""), msg);
            return ret;
        }

        public bool ReadDataText(string textFile, Database db, ref string msg, ProcessReadData prog)
        {
            msg = "";
            bool ret = false;
            StreamReader sr = null;
            string line;
            byte MacType = 0;
            int MacSN = 0;
            string ver = "";
            int len = 0;
            int RecCount = 0;
            int RecIndex = 0;
            int LogID = 0;
            int nIndex = 0;
            int aIndex = 0;
            int rIndex = 0;
            int fIndex = 0;
            double RecMoney = 0;
            double nMoney = 0;
            double aMoney = 0;
            double rMoney = 0;
            double fMoney = 0;
            DateTime date = new DateTime();
            bool falg = false;
            bool IsTitel = true;
            DataTableReader drt = null;
            drt = db.GetDataReader(Pub.GetSQL(DBCode.DB_004007, new string[] { "0" }));
            if (drt.Read())
            {
                date = Convert.ToDateTime(drt["CheckOutDate"]);
                date = date.AddDays(1);
                falg = true;
            }
            try
            {
                sr = new StreamReader(textFile);
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    if (line != "")
                    {
                        if (line.IndexOf('V') > 0)
                        {
                            ver = line.Substring(line.IndexOf('V'));
                            line.Substring(0, line.IndexOf('V') - 1);
                        }
                        MacSN = Convert.ToByte(line.Substring(10, 2), 16);
                        MacType = Convert.ToByte(Convert.ToByte(line.Substring(12, 2), 16) + 30);
                        if (MacType == 36) continue;
                        len = Convert.ToInt32(line.Substring(22, 2) + line.Substring(20, 2), 16);
                        line = line.Substring(0, len * 2 + 20 + 8);
                        if (ver == "")
                        {
                            if (line.Length == 908)
                                ver = "V11.14";
                            else
                                ver = "V11.05";
                        }
                        if (DeviceObject.objKS.FeeLogDataReal(line, ver, ref logCount, ref LogID))
                        {
                            RecCount += logCount;
                            for (int i = 0; i < logCount; i++)
                            {
                                if (DeviceObject.objKS.FeeLogDataValue(i, ref feeLog))
                                {
                                    //if (feeLog.BTWay != 0)
                                    //{
                                    //    feeLog.SFType = 130;    
                                    //}
                                    WriteTextFile(feeLog, MacSN, MacType, false);

                                    if (falg)
                                    {
                                       
                                        if (date > feeLog.SFDate)
                                        {
                                            if (feeLog.IsCount != 0)
                                            {
                                                RecIndex++;
                                                aIndex++;
                                            }

                                            RecMoney += Math.Abs(feeLog.CZAmount) + Math.Abs(feeLog.BTAmount) + Math.Abs(feeLog.BTWay);
                                            aMoney += Math.Abs(feeLog.CZAmount) + Math.Abs(feeLog.BTAmount) + Math.Abs(feeLog.BTWay);
                                            if (IsTitel)
                                            {
                                                Pub.ShowErrorMsg(string.Format(Pub.GetResText("", "MsgCardUseDateDev", ""), date, feeLog.SFDate));
                                                IsTitel = false;
                                            }
                                            goto END;
                                        }

                                    }
                                    if (feeLog.ReadMark == 2)
                                    {
                                        SaveErrorDB(db, feeLog, MacSN, MacType, false);
                                        if (feeLog.IsCount != 0)
                                        {
                                            RecIndex++;
                                            aIndex++;
                                        }
                                        RecMoney += Math.Abs(feeLog.CZAmount) + Math.Abs(feeLog.BTAmount) + Math.Abs(feeLog.BTWay);
                                        aMoney += Math.Abs(feeLog.CZAmount) + Math.Abs(feeLog.BTAmount) + Math.Abs(feeLog.BTWay);
                                    }
                                    else if (feeLog.ReadMark == 3)
                                    {
                                        SaveReturnDB(db, feeLog, MacSN, MacType, false);
                                        if (feeLog.IsCount != 0)
                                        {
                                            RecIndex++;
                                            rIndex++;
                                        }
                                        RecMoney += Math.Abs(feeLog.CZAmount) + Math.Abs(feeLog.BTAmount) + Math.Abs(feeLog.BTWay);
                                        rMoney += Math.Abs(feeLog.CZAmount) + Math.Abs(feeLog.BTAmount) + Math.Abs(feeLog.BTWay);
                                    }
                                    else if (feeLog.ReadMark == 0xf0)
                                    {
                                        SaveMobileFailDB(db, feeLog, MacSN, MacType, IsNew);
                                        if (feeLog.IsCount != 0)
                                        {
                                            RecIndex++;
                                            fIndex++;
                                        }
                                        RecMoney += Math.Abs(feeLog.CZAmount) + Math.Abs(feeLog.BTAmount) + Math.Abs(feeLog.BTWay);
                                        fMoney += Math.Abs(feeLog.CZAmount) + Math.Abs(feeLog.BTAmount) + Math.Abs(feeLog.BTWay);
                                    }
                                    else if (feeLog.ReadMark != 0xff)
                                    {
                                        SaveDB(db, feeLog, MacSN, MacType, false);
                                        if (feeLog.IsCount != 0)
                                        {
                                            RecIndex++;
                                            nIndex++;
                                        }
                                        RecMoney += Math.Abs(feeLog.CZAmount) + Math.Abs(feeLog.BTAmount) + Math.Abs(feeLog.BTWay);
                                        nMoney += Math.Abs(feeLog.CZAmount) + Math.Abs(feeLog.BTAmount) + Math.Abs(feeLog.BTWay);
                                    }
                                END:
                                    if (RecIndex > RecCount) RecIndex = RecCount;
                                    msg = string.Format(MsgRec, RecIndex.ToString() + "/" + RecCount.ToString(),
                                      RecMoney.ToString(SystemInfo.CurrencySymbol + "0.00"),
                                      nIndex.ToString() + "(" + nMoney.ToString(SystemInfo.CurrencySymbol + "0.00") + ")",
                                      aIndex.ToString() + "(" + aMoney.ToString(SystemInfo.CurrencySymbol + "0.00") + ")",
                                      rIndex.ToString() + "(" + rMoney.ToString(SystemInfo.CurrencySymbol + "0.00") + ")",
                                      fIndex.ToString() + "(" + fMoney.ToString(SystemInfo.CurrencySymbol + "0.00") + ")");
                                    prog(RecCount, RecIndex, msg);
                                }
                            }
                        }
                    }
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

        public bool ReadDataReal(string RealData, Database db, int MacSN, string Version, byte MacType, ref int RecordCount, ref int LogID,
          ref double Money, ProcessRealData prog)
        {
            bool ret = false;
            int logCount = 0;
            RecordCount = 0;
            LogID = 0;
            Money = 0;
            try
            {
                ret = DeviceObject.objKS.FeeLogDataReal(RealData, Version, ref logCount, ref LogID);
                for (int j = 0; j < logCount; j++)
                {
                    if (DeviceObject.objKS.FeeLogDataValue(j, ref feeLog))
                    {
                        WriteTextFile(feeLog, MacSN, MacType, true);
                        if (feeLog.ReadMark == 2)
                            SaveErrorDB(db, feeLog, MacSN, MacType, true);
                        else if (feeLog.ReadMark == 3)
                            SaveReturnDB(db, feeLog, MacSN, MacType, true);
                        else if (feeLog.ReadMark == 0xf0)
                            SaveMobileFailDB(db, feeLog, MacSN, MacType, true);
                        else if (feeLog.ReadMark != 0xff)
                        {
                            SaveDB(db, feeLog, MacSN, MacType, true);
                            if (feeLog.IsCount == 0) RecordCount = RecordCount - 1;
                            if (feeLog.IsCount == 1)
                            {
                                Money = Money + Math.Abs(feeLog.CZAmount) + Math.Abs(feeLog.BTAmount) + Math.Abs(feeLog.BTWay);
                                RecordCount++;
                                if (prog != null) prog(feeLog, MacSN);
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

        private string GetProduct(TFeeLog feeLog)
        {
            string ret = "";
            if (feeLog.SFType == 3 || feeLog.SFType == 130 || (feeLog.SFType == 200 && feeLog.ProductID[0] > 0))
            {
                ret = feeLog.ProductCategory.ToString("0000");
                for (int i = 0; i < 10; i++)
                {
                    string[] msg = feeLog.ProductNum[i].ToString("0.00").Split('.');
                    string[] tmp = feeLog.ProductPrice[i].ToString("0.00").Split('.');

                    if (SystemInfo.IsDecimalProduct)
                        ret += feeLog.ProductID[i].ToString("0000") + feeLog.ProductNum[i].ToString("000000000");
                    else
                        ret += feeLog.ProductID[i].ToString("0000") + Convert.ToInt32(msg[0]).ToString("000000") + Convert.ToInt32(msg[1]).ToString("00") + Convert.ToInt32(tmp[0]).ToString("00000") + "." + Convert.ToInt32(tmp[1]).ToString("00");
                }
            }
            return ret;
        }

        private void WriteTextFile(TFeeLog feeLog, int MacSN, int MacType, bool IsNew)
        {
            string Product = GetProduct(feeLog);
            string Sep = " ";
            string fileName = SystemInfo.DataFilePath + "SF";
            if (!IsNew) fileName += "A";
            string OrderDate = feeLog.OrderDate.ToOADate() == 0 ? "" : feeLog.OrderDate.ToShortDateString();
            fileName = fileName + DateTime.Now.Date.ToString(SystemInfo.DateFormatLog) + ".txt";
            string msg = MacSN.ToString("00000") + Sep + MacType.ToString("00") + Sep +
              feeLog.ReadMark.ToString("000") + Sep + feeLog.CardID + Sep + feeLog.PhyID + Sep +
              feeLog.MacTAG + Sep + feeLog.SFType.ToString("00") + Sep +
              feeLog.MealType.ToString() + Sep + feeLog.CZAmount.ToString("0.00") + Sep +
              feeLog.CZBalance.ToString("0.00") + Sep + Sep + feeLog.BTAmount.ToString("0.00") + Sep +
              feeLog.BTBalance.ToString("0.00") + Sep + Sep + feeLog.BTWay.ToString("0.00") + Sep + Sep + feeLog.SFDate.ToString(SystemInfo.SQLDateTimeFMT) + Sep +
              feeLog.CardUseTimes.ToString() + Sep + feeLog.OpterNo.ToString() + Sep + OrderDate + Sep + Product +
              Sep + feeLog.TradeNo;
            Pub.WriteTextFile(fileName, msg);
        }

        private string GetSFSQL(TFeeLog feeLog, int MacSN, bool IsNew, string OpterStartDate, string OpterEndDate)
        {
            string val = IsNew ? "200" : "100";
            string Product = GetProduct(feeLog);
            string OrderDate = feeLog.OrderDate.ToOADate() == 0 ? "" : feeLog.OrderDate.ToString(SystemInfo.SQLDateFMT);
            string JSStartTime = feeLog.JSStartTime.ToOADate() == 0 ? "" : feeLog.JSStartTime.ToString(SystemInfo.SQLDateTimeFMT);
            string JSEndTime = feeLog.JSEndTime.ToOADate() == 0 ? "" : feeLog.JSEndTime.ToString(SystemInfo.SQLDateTimeFMT);
            string JSCount = feeLog.JSCount.ToString();
            if (JSStartTime == "" || JSEndTime == "")
            {
                JSStartTime = "";
                JSEndTime = "";
                JSCount = "";
            }
            //if(feeLog.CardID=="0000000484" && feeLog.SFDate>= Convert.ToDateTime( "2019/12/10 01:00:00"))
            //      {

            //      }
            return Pub.GetSQL(DBCode.DB_004005, new string[] { val, feeLog.CardID, feeLog.SFType.ToString(),
        feeLog.SFDate.ToString(SystemInfo.SQLDateTimeFMT), feeLog.CZAmount.ToString(), feeLog.CZBalance.ToString(),
        feeLog.MealType.ToString(), MacSN.ToString(), feeLog.OpterNo.ToString(), feeLog.CardUseTimes.ToString(),
        OprtInfo.OprtSysID, Product, feeLog.ReadMark.ToString(), OrderDate, feeLog.PhyID, feeLog.MacTAG, feeLog.TradeNo,
        feeLog.BTAmount.ToString(),feeLog.BTBalance.ToString(),feeLog.BTWay.ToString(),OpterStartDate,OpterEndDate,
        JSStartTime, JSEndTime, JSCount });
        }

        private string GetSFMobileSQL(TFeeLog feeLog, int MacSN)
        {
            string Product = GetProduct(feeLog);
            return Pub.GetSQL(DBCode.DB_004005, new string[] { "10", (feeLog.SFType - 200).ToString(),
        feeLog.SFDate.ToString(SystemInfo.SQLDateTimeFMT), feeLog.CZAmount.ToString(), MacSN.ToString(),
        Product, feeLog.TradeNo, feeLog.BTAmount.ToString(),feeLog.BTWay.ToString(), OprtInfo.OprtSysID});
        }

        private string GetSFOrderSQL(TFeeLog feeLog, int MacSN, int ReadMark, string OpterStartDate, string OpterEndDate)
        {
            return Pub.GetSQL(DBCode.DB_004005, new string[] { "9", feeLog.CardID, feeLog.SFType.ToString(),
        feeLog.SFDate.ToString(SystemInfo.SQLDateTimeFMT), feeLog.CZAmount.ToString(), feeLog.CZBalance.ToString(),
        feeLog.MealType.ToString(), MacSN.ToString(), feeLog.OpterNo.ToString(), feeLog.CardUseTimes.ToString(),
        OprtInfo.OprtSysID, feeLog.PhyID, feeLog.MacTAG, ReadMark.ToString(), feeLog.BTAmount.ToString(),
        feeLog.BTBalance.ToString(),feeLog.BTWay.ToString(),OpterStartDate,OpterEndDate });
        }

        private void SaveDB(Database db, TFeeLog feeLog, int MacSN, int MacType, bool IsNew)
        {
            List<string> sql = new List<string>();
            sql.Clear();
            DataTableReader dr = null;

            string Product = GetProduct(feeLog);
            string OpterStartDate = "";
            string OpterEndDate = "";
            DateTime StartDt = new DateTime();
            DateTime EndDt = new DateTime();
            //if (feeLog.CZAmount == -271.7)
            //{
            //    MessageBox.Show(Product);
            //}
            dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "251", feeLog.CardID }));
            while (dr.Read())
            {
                OpterStartDate = "";
                OpterEndDate = "";
                OpterStartDate = dr["OpterStartDate"].ToString();
                OpterEndDate = dr["OpterEndDate"].ToString();
                if (OpterStartDate != "")
                {
                    StartDt = Convert.ToDateTime(OpterStartDate);
                }
                if (OpterEndDate != "")
                {
                    EndDt = Convert.ToDateTime(OpterEndDate);
                }
                if (OpterStartDate != "" && OpterEndDate != "")
                {
                    if (feeLog.SFDate > StartDt && feeLog.SFDate < EndDt)
                    {
                        break;
                    }
                }
                else if (OpterStartDate != "" && OpterEndDate == "")
                {
                    if (feeLog.SFDate > StartDt)
                    {
                        OpterEndDate = feeLog.SFDate.ToString(SystemInfo.SQLDateTimeFMT);
                        break;
                    }
                }

            }
            if (OpterStartDate != "")
                OpterStartDate = Convert.ToDateTime(OpterStartDate).ToString(SystemInfo.SQLDateTimeFMT);
            if (OpterEndDate != "")
                OpterEndDate = Convert.ToDateTime(OpterEndDate).ToString(SystemInfo.SQLDateTimeFMT);
            if (MacType == 36)
            {
                if (feeLog.CZAmount != 0) sql.Add(GetSFSQL(feeLog, MacSN, IsNew, OpterStartDate, OpterEndDate));
                sql.Add(Pub.GetSQL(DBCode.DB_004005, new string[] { "1", feeLog.CardID,
          feeLog.OrderDate.ToString(SystemInfo.SQLDateFMT), feeLog.MealType.ToString(),
          OprtInfo.OprtSysID, "0", MacSN.ToString() }));
            }
            else
            {
                if (feeLog.ReadMark == 0xF0)
                    sql.Add(GetSFMobileFailSQL(feeLog, MacSN, OpterStartDate, OpterEndDate));
                else if (feeLog.SFType == 100)
                    sql.Add(Pub.GetSQL(DBCode.DB_005001, new string[] { "0", feeLog.CardID, "20",
            feeLog.SFDate.ToString(SystemInfo.SQLDateTimeFMT), Math.Abs(feeLog.CZAmount).ToString(),
            feeLog.CZBalance.ToString(),/*Math.Abs(feeLog.BTAmount).ToString(),feeLog.BTBalance.ToString(),Math.Abs(feeLog.BTWay).ToString(),*/ OprtInfo.OprtSysID }));
                else if (feeLog.SFType == 8 && feeLog.CZAmount == 0)
                    sql.Add(GetSFOrderSQL(feeLog, MacSN, 0, OpterStartDate, OpterEndDate));
                else if (feeLog.SFType == 200 || feeLog.SFType == 201)
                    sql.Add(GetSFMobileSQL(feeLog, MacSN));
                else
                    sql.Add(GetSFSQL(feeLog, MacSN, IsNew, OpterStartDate, OpterEndDate));
            }
            db.ExecSQL(sql);
        }

        private string GetSFErrorSQL(TFeeLog feeLog, int MacSN, bool IsNew, string OpterStartDate, string OpterEndDate)
        {
            string val = IsNew ? "201" : "101";
            string Product = GetProduct(feeLog);
            string OrderDate = feeLog.OrderDate.ToOADate() == 0 ? "" : feeLog.OrderDate.ToString(SystemInfo.SQLDateFMT);
            string JSStartTime = feeLog.JSStartTime.ToOADate() == 0 ? "" : feeLog.JSStartTime.ToString(SystemInfo.SQLDateTimeFMT);
            string JSEndTime = feeLog.JSEndTime.ToOADate() == 0 ? "" : feeLog.JSEndTime.ToString(SystemInfo.SQLDateTimeFMT);
            string JSCount = feeLog.JSCount.ToString();
            if (JSStartTime == "" || JSEndTime == "")
            {
                JSStartTime = "";
                JSEndTime = "";
                JSCount = "";
            }
            return Pub.GetSQL(DBCode.DB_004005, new string[] { val, feeLog.CardID, feeLog.SFType.ToString(),
        feeLog.SFDate.ToString(SystemInfo.SQLDateTimeFMT), feeLog.CZAmount.ToString(), feeLog.CZBalance.ToString(),
        feeLog.MealType.ToString(), MacSN.ToString(), feeLog.OpterNo.ToString(), feeLog.CardUseTimes.ToString(),
        OprtInfo.OprtSysID, Product, OrderDate, feeLog.PhyID, feeLog.MacTAG, feeLog.TradeNo,feeLog.BTAmount.ToString(),
        feeLog.BTBalance.ToString(),feeLog.BTWay.ToString(),OpterStartDate, OpterEndDate,JSStartTime, JSEndTime, JSCount });
        }

        private string GetSFReturnSQL(TFeeLog feeLog, int MacSN, bool IsNew, string OpterStartDate, string OpterEndDate)
        {
            string val = IsNew ? "202" : "102";
            string Product = GetProduct(feeLog);
            string OrderDate = feeLog.OrderDate.ToOADate() == 0 ? "" : feeLog.OrderDate.ToString(SystemInfo.SQLDateFMT);
            string JSStartTime = feeLog.JSStartTime.ToOADate() == 0 ? "" : feeLog.JSStartTime.ToString(SystemInfo.SQLDateTimeFMT);
            string JSEndTime = feeLog.JSEndTime.ToOADate() == 0 ? "" : feeLog.JSEndTime.ToString(SystemInfo.SQLDateTimeFMT);
            string JSCount = feeLog.JSCount.ToString();
            if (JSStartTime == "" || JSEndTime == "")
            {
                JSStartTime = "";
                JSEndTime = "";
                JSCount = "";
            }
            return Pub.GetSQL(DBCode.DB_004005, new string[] { val, feeLog.CardID, feeLog.SFType.ToString(),
        feeLog.SFDate.ToString(SystemInfo.SQLDateTimeFMT), feeLog.CZAmount.ToString(), feeLog.CZBalance.ToString(),
        feeLog.MealType.ToString(), MacSN.ToString(), feeLog.OpterNo.ToString(), feeLog.CardUseTimes.ToString(),
        OprtInfo.OprtSysID, Product, OrderDate, feeLog.PhyID, feeLog.MacTAG, feeLog.TradeNo,feeLog.BTAmount.ToString(),
        feeLog.BTBalance.ToString(),feeLog.BTWay.ToString(),OpterStartDate,OpterEndDate,JSStartTime, JSEndTime, JSCount });
        }

        private void SaveErrorDB(Database db, TFeeLog feeLog, int MacSN, int MacType, bool IsNew)
        {
            List<string> sql = new List<string>();
            sql.Clear();
            DataTableReader dr = null;

            string Product = GetProduct(feeLog);
            string OpterStartDate = "";
            string OpterEndDate = "";
            DateTime StartDt = new DateTime();
            DateTime EndDt = new DateTime();
            dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "251", feeLog.CardID }));
            while (dr.Read())
            {
                OpterStartDate = "";
                OpterEndDate = "";
                OpterStartDate = dr["OpterStartDate"].ToString();
                OpterEndDate = dr["OpterEndDate"].ToString();
                if (OpterStartDate != "")
                {
                    StartDt = Convert.ToDateTime(OpterStartDate);
                }
                if (OpterEndDate != "")
                {
                    EndDt = Convert.ToDateTime(OpterEndDate);
                }
                if (OpterStartDate != "" && OpterEndDate != "")
                {
                    if (feeLog.SFDate > StartDt && feeLog.SFDate < EndDt)
                    {
                        break;
                    }
                }
                else if (OpterStartDate != "" && OpterEndDate == "")
                {
                    if (feeLog.SFDate > StartDt)
                    {
                        OpterEndDate = feeLog.SFDate.ToString(SystemInfo.SQLDateTimeFMT);
                        break;
                    }
                }

            }
            if (OpterStartDate != "")
                OpterStartDate = Convert.ToDateTime(OpterStartDate).ToString(SystemInfo.SQLDateTimeFMT);
            if (OpterEndDate != "")
                OpterEndDate = Convert.ToDateTime(OpterEndDate).ToString(SystemInfo.SQLDateTimeFMT);
            if (MacType == 36)
            {
                if (feeLog.CZAmount != 0) sql.Add(GetSFErrorSQL(feeLog, MacSN, IsNew, OpterStartDate, OpterEndDate));
            }
            else
            {
                if (feeLog.SFType == 100)
                    sql.Add(Pub.GetSQL(DBCode.DB_005001, new string[] { "0", feeLog.CardID, "20",
            feeLog.SFDate.ToString(SystemInfo.SQLDateTimeFMT), Math.Abs(feeLog.CZAmount).ToString(),
            feeLog.CZBalance.ToString(), OprtInfo.OprtSysID }));
                else if (feeLog.SFType == 8 && feeLog.CZAmount == 0)
                    sql.Add(GetSFOrderSQL(feeLog, MacSN, 1, OpterStartDate, OpterEndDate));
                else
                    sql.Add(GetSFErrorSQL(feeLog, MacSN, IsNew, OpterStartDate, OpterEndDate));
            }
            if (sql.Count > 0) db.ExecSQL(sql);
        }

        private void SaveReturnDB(Database db, TFeeLog feeLog, int MacSN, int MacType, bool IsNew)
        {
            List<string> sql = new List<string>();
            sql.Clear();
            DataTableReader dr = null;

            string OpterStartDate = "";
            string OpterEndDate = "";
            DateTime StartDt = new DateTime();
            DateTime EndDt = new DateTime();
            dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "251", feeLog.CardID }));
            while (dr.Read())
            {
                OpterStartDate = "";
                OpterEndDate = "";
                OpterStartDate = dr["OpterStartDate"].ToString();
                OpterEndDate = dr["OpterEndDate"].ToString();
                if (OpterStartDate != "")
                {
                    StartDt = Convert.ToDateTime(OpterStartDate);
                }
                if (OpterEndDate != "")
                {
                    EndDt = Convert.ToDateTime(OpterEndDate);
                }
                if (OpterStartDate != "" && OpterEndDate != "")
                {
                    if (feeLog.SFDate > StartDt && feeLog.SFDate < EndDt)
                    {
                        break;
                    }
                }
                else if (OpterStartDate != "" && OpterEndDate == "")
                {
                    if (feeLog.SFDate > StartDt)
                    {
                        OpterEndDate = feeLog.SFDate.ToString(SystemInfo.SQLDateTimeFMT);
                        break;
                    }
                }

            }
            if (OpterStartDate != "")
                OpterStartDate = Convert.ToDateTime(OpterStartDate).ToString(SystemInfo.SQLDateTimeFMT);
            if (OpterEndDate != "")
                OpterEndDate = Convert.ToDateTime(OpterEndDate).ToString(SystemInfo.SQLDateTimeFMT);
            sql.Add(GetSFReturnSQL(feeLog, MacSN, IsNew, OpterStartDate, OpterEndDate));
            db.ExecSQL(sql);
        }

        private string GetSFMobileFailSQL(TFeeLog feeLog, int MacSN, string OpterStartDate, string OpterEndDate)
        {
            Database db = new Database(SystemInfo.ConnStr);
            string Product = GetProduct(feeLog);

            return Pub.GetSQL(DBCode.DB_004005, new string[] { "15", feeLog.CardID, feeLog.SFType.ToString(),
        feeLog.SFDate.ToString(SystemInfo.SQLDateTimeFMT), feeLog.CZAmount.ToString(), feeLog.CZBalance.ToString(),
        MacSN.ToString(), feeLog.CardUseTimes.ToString(), feeLog.ReadMark.ToString(), feeLog.PhyID, feeLog.MacTAG,
        feeLog.TradeNo, OprtInfo.OprtSysID,null,null, feeLog.BTAmount.ToString(),feeLog.BTBalance.ToString(),
        feeLog.BTWay.ToString(),OpterStartDate,OpterEndDate});

        }

        private void SaveMobileFailDB(Database db, TFeeLog feeLog, int MacSN, int MacType, bool IsNew)
        {
            List<string> sql = new List<string>();
            sql.Clear();
            DataTableReader dr = null;

            string OpterStartDate = "";
            string OpterEndDate = "";
            DateTime StartDt = new DateTime();
            DateTime EndDt = new DateTime();
            dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "251", feeLog.CardID }));
            while (dr.Read())
            {
                OpterStartDate = "";
                OpterEndDate = "";
                OpterStartDate = dr["OpterStartDate"].ToString();
                OpterEndDate = dr["OpterEndDate"].ToString();
                if (OpterStartDate != "")
                {
                    StartDt = Convert.ToDateTime(OpterStartDate);
                }
                if (OpterEndDate != "")
                {
                    EndDt = Convert.ToDateTime(OpterEndDate);
                }
                if (OpterStartDate != "" && OpterEndDate != "")
                {
                    if (feeLog.SFDate > StartDt && feeLog.SFDate < EndDt)
                    {
                        break;
                    }
                }
                else if (OpterStartDate != "" && OpterEndDate == "")
                {
                    if (feeLog.SFDate > StartDt)
                    {
                        OpterEndDate = feeLog.SFDate.ToString(SystemInfo.SQLDateTimeFMT);
                        break;
                    }
                }

            }
            if (OpterStartDate != "")
                OpterStartDate = Convert.ToDateTime(OpterStartDate).ToString(SystemInfo.SQLDateTimeFMT);
            if (OpterEndDate != "")
                OpterEndDate = Convert.ToDateTime(OpterEndDate).ToString(SystemInfo.SQLDateTimeFMT);
            sql.Add(GetSFMobileFailSQL(feeLog, MacSN, OpterStartDate, OpterEndDate));
            db.ExecSQL(sql);
        }
    }

    public class SFDownBlack
    {
        private DataTable dt = null;
        private DataTable sdt = null;
        private QHKS.TConnInfo conn;
        private Base Pub = new Base();

        public SFDownBlack(DataTable dataTable, QHKS.TConnInfo connInfo)
        {
            dt = dataTable.Copy();
            conn = connInfo;
        }
        public SFDownBlack(DataTable dataTable, DataTable sdataTable, QHKS.TConnInfo connInfo)
        {
            dt = dataTable.Copy();
            if (sdataTable != null)
                sdt = sdataTable.Copy();
            conn = connInfo;
        }

        public SFDownBlack(QHKS.TConnInfo connInfo)
        {
            conn = connInfo;
        }

        public bool Down()
        {

            int max = dt.Rows.Count;
            if (max == 0) return true;
            int count = 0;
            for (int i = 0; i < max; i++)
            {
                if (!Pub.ValueToBool(dt.Rows[i]["SelectCheck"])) continue;
                count++;
            }
            if (count > 1)
            {
                if (!DeviceObject.objKS.PubBlackClear()) return false;
            }
            string cardNo = "";
            for (int i = 0; i < max; i++)
            {
                if (!Pub.ValueToBool(dt.Rows[i]["SelectCheck"])) continue;
                cardNo = dt.Rows[i]["CardSectorNo"].ToString();
                DeviceObject.objKS.PubBlackInit(cardNo, i == 0, false);
            }

            return DeviceObject.objKS.PubBlackData(SystemInfo.MainHandle.ToInt32());
        }

        public bool sendDown(string MacAddress, QHKS.KS objKS)
        {

            lock (locker)
            {
                TBlackBag BlackBag = new TBlackBag();
                int max = dt.Rows.Count;
                if (!objKS.PubBlackClear()) return false;
                if (max == 0) return true;
                bool ret = false;
                string cardNo = "";
                BlackBag.Count = 0;
                int c = 0;
                int a = 0;
                BlackBag.CardID = new string[100];
                c = max;
                for (int i = 0; i < max; i++)
                {

                    cardNo = dt.Rows[i]["CardSectorNo"].ToString();
                    BlackBag.CardID[a] = cardNo;
                    a++;
                    BlackBag.Count = a;
                    if (BlackBag.Count == 100 || BlackBag.Count == c)
                    {
                        c = c - 100;
                        ret = objKS.PubBlackBag(BlackBag);
                        BlackBag.Count = 0;
                        a = 0;
                        BlackBag.CardID = new string[100];
                    }

                }

                return ret;

            }
        }

        public static object locker = new object();
        public bool realDown(string Mode, QHKS.KS objKS)
        {
            lock (locker)
            {
                bool ret = false;
                string[] tmp = new string[2];
                tmp = Mode.Split(',');
                if (tmp.Length >= 2)
                {
                    switch (tmp[0])
                    {
                        case "0":
                            ret = objKS.PubBlackOne(tmp[1]);
                            break;

                        case "1":
                            ret = objKS.PubBlackDel(tmp[1]);
                            break;

                    }

                }

                return ret;
            }

        }

        public bool OneDown(string Mode)
        {
            lock (locker)
            {
                bool ret = false;

                ret = DeviceObject.objKS.PubBlackDel(Mode);

                return ret;
            }

        }
    }

    public class SFSoftParamInfo
    {
        private Base Pub = new Base();
        private string[] _BeginTime = new string[4] { "00:01", "09:01", "13:01", "21:01" };
        private string[] _EndTime = new string[4] { "09:00", "13:00", "21:00", "23:59" };

        public SFSoftParamInfo(string ParamString)
        {
            string[] tmp = ParamString.Split('@');
            if (tmp.Length == 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    string[] tmp1 = tmp[i].Split('#');
                    if (tmp1.Length != 2) break;
                    _BeginTime[i] = Pub.ValidatTime(tmp1[0]);
                    _EndTime[i] = Pub.ValidatTime(tmp1[1]);
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

    public class TFeeRechargeGift
    {
        private int _CardType = 0;
        private double _Rate = 0.00;
        private double[] _Value = new double[5] { 0.00, 0.00, 0.00, 0.00, 0.00 };
        private double[] _Gift = new double[5] { 0.00, 0.00, 0.00, 0.00, 0.00 };

        public TFeeRechargeGift(string ParamString)
        {
            string[] tmp = ParamString.Split('#');
            if (tmp.Length == 13)
            {
                _CardType = int.Parse(tmp[0]);
                _Rate = double.Parse(tmp[1]);
                for (int i = 0; i < 5; i++)
                {
                    _Value[i] = double.Parse(tmp[i + 2]);
                    _Gift[i] = double.Parse(tmp[i + 7]);
                }
            }
        }

        public int CardType
        {
            get { return _CardType; }
        }

        public double Rate
        {
            get { return _Rate; }
        }

        public double[] Value
        {
            get { return _Value; }
        }

        public double[] Gift
        {
            get { return _Gift; }
        }
    }

    public class TPrintTitleInfo
    {
        private string[] _title = new string[5] { "", "", "", "", "" };
        private byte[] _zoom = new byte[5] { 3, 1, 4, 4, 3 };
        private byte _line = 1;
        private MemoryStream _logo = null;

        public TPrintTitleInfo(string info)
        {
            _logo = new MemoryStream();
            string[] tmp = info.Split('@');
            if (tmp.Length == 11)
            {
                _title[0] = tmp[0];
                _title[1] = tmp[1];
                _title[2] = tmp[2];
                _title[3] = tmp[3];
                _title[4] = tmp[4];
                byte.TryParse(tmp[5], out _zoom[0]);
                byte.TryParse(tmp[6], out _zoom[1]);
                byte.TryParse(tmp[7], out _zoom[2]);
                byte.TryParse(tmp[8], out _zoom[3]);
                byte.TryParse(tmp[9], out _zoom[4]);
                byte.TryParse(tmp[10], out _line);
            }
            else
            {
                Base Pub = new Base();
                _title[0] = "****************";
                _title[1] = "  " + Pub.GetResText("", "DefaultPrintTitle", "");
                _title[4] = "****************";
                Database db = new Database(SystemInfo.ConnStr);
                DataTableReader dr = null;
                try
                {
                    if (!db.IsOpen) db.Open();
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004002, new string[] { "0" }));
                    if (dr.Read())
                    {
                        _title[0] = dr["PrintTitle1"].ToString();
                        _title[1] = dr["PrintTitle2"].ToString();
                        _title[2] = dr["PrintTitle3"].ToString();
                        _title[3] = dr["PrintTitle4"].ToString();
                        _title[4] = dr["PrintTitle5"].ToString();
                        byte.TryParse(dr["PrintOption1"].ToString(), out _zoom[0]);
                        byte.TryParse(dr["PrintOption2"].ToString(), out _zoom[1]);
                        byte.TryParse(dr["PrintOption3"].ToString(), out _zoom[2]);
                        byte.TryParse(dr["PrintOption4"].ToString(), out _zoom[3]);
                        byte.TryParse(dr["PrintOption5"].ToString(), out _zoom[4]);
                        byte.TryParse(dr["PrintLine"].ToString(), out _line);
                        if (dr["PrintLogo"].ToString() != "")
                        {
                            byte[] buff = (byte[])(dr["PrintLogo"]);
                            if (buff.Length > 0) _logo = new MemoryStream(buff);
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
                    db.Close();
                    db = null;
                }
                Pub = null;
            }
        }

        public string[] Title
        {
            get { return _title; }
        }

        public byte[] Zoom
        {
            get { return _zoom; }
        }

        public MemoryStream Logo
        {
            get { return _logo; }
        }

        public byte Line
        {
            get { return _line; }
        }
    }

    public class TMobileInfo
    {
        private string _ip = "180.96.69.219";
        private int _port = 8180;
        private string _keyID = "BB33F1074E40847A2F8FC5FCFB2781B5";
        private string _mercID = "";
        private string _trmNo = "";
        private string _pwd = "";
        private byte _rate11 = 2;
        private int _rate12 = 0;
        private byte _rate21 = 2;
        private int _rate22 = 0;
        private byte _mobTyp = 0;
        private string _xjlName = "";
        private string _xjlPWD = "";

        private MemoryStream _wx = null;
        private MemoryStream _ali = null;
        private Base Pub = new Base();

        public TMobileInfo(string info)
        {
            _wx = new MemoryStream();
            _ali = new MemoryStream();
            string[] tmp = info.Split('@');
            if (tmp.Length == 6 || tmp.Length == 10 || tmp.Length == 13)
            {
                _ip = tmp[0];
                int.TryParse(tmp[1], out _port);
                _keyID = Pub.GetOprtDecrypt(tmp[2]);
                _mercID = Pub.GetOprtDecrypt(tmp[3]);
                _trmNo = Pub.GetOprtDecrypt(tmp[4]);
                _pwd = Pub.GetOprtDecrypt(tmp[5]);
                if (tmp.Length == 10 || tmp.Length == 13)
                {
                    byte.TryParse(tmp[6], out _rate11);
                    int.TryParse(tmp[7], out _rate12);
                    byte.TryParse(tmp[8], out _rate21);
                    int.TryParse(tmp[9], out _rate22);
                }
                if (tmp.Length == 13)
                {
                    byte.TryParse(tmp[10], out _mobTyp);
                    _xjlName = Pub.GetOprtDecrypt(tmp[11]);
                    _xjlPWD = Pub.GetOprtDecrypt(tmp[12]);
                }
            }
            else
            {
                bool IsOk = false;
                Database db = new Database(SystemInfo.ConnStr);
                DataTableReader dr = null;
                try
                {
                    if (!db.IsOpen) db.Open();
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004002, new string[] { "100" }));
                    if (dr.Read())
                    {
                        _ip = dr["MobileIP"].ToString();
                        int.TryParse(dr["MobilePort"].ToString(), out _port);
                        _keyID = Pub.GetOprtDecrypt(dr["MobileKeyID"].ToString());
                        _mercID = Pub.GetOprtDecrypt(dr["MobileMercID"].ToString());
                        _trmNo = Pub.GetOprtDecrypt(dr["MobileTrmNo"].ToString());
                        _pwd = Pub.GetOprtDecrypt(dr["MobilePWD"].ToString());
                        byte.TryParse(dr["MobileRate11"].ToString(), out _rate11);
                        int.TryParse(dr["MobileRate12"].ToString(), out _rate12);
                        byte.TryParse(dr["MobileRate21"].ToString(), out _rate21);
                        int.TryParse(dr["MobileRate22"].ToString(), out _rate22);
                        byte.TryParse(dr["MobTyp"].ToString(), out _mobTyp);
                        _xjlName = Pub.GetOprtDecrypt(dr["XJLName"].ToString());
                        _xjlPWD = Pub.GetOprtDecrypt(dr["XJLPWD"].ToString());
                        if (dr["ScanWeiXin"].ToString() != "")
                        {
                            byte[] buff = (byte[])(dr["ScanWeiXin"]);
                            if (buff.Length > 0) _wx = new MemoryStream(buff);
                        }
                        if (dr["ScanAliPay"].ToString() != "")
                        {
                            byte[] buff = (byte[])(dr["ScanAliPay"]);
                            if (buff.Length > 0) _ali = new MemoryStream(buff);
                        }
                        IsOk = true;
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
                    db.Close();
                    db = null;
                }
                if (!IsOk)
                {
                    _keyID = Pub.GetOprtDecrypt(_keyID);
                    _mercID = Pub.GetOprtDecrypt(_mercID);
                    _trmNo = Pub.GetOprtDecrypt(_trmNo);
                    _pwd = Pub.GetOprtDecrypt(_pwd);
                }
            }
            if (_keyID == "") _keyID = "000";
        }

        public string IP
        {
            get { return _ip; }
        }

        public int Port
        {
            get { return _port; }
        }

        public string KeyID
        {
            get { return _keyID; }
        }

        public string MercID
        {
            get { return _mercID; }
        }

        public string TrmNo
        {
            get { return _trmNo; }
        }

        public string PWD
        {
            get { return _pwd; }
        }

        public byte Rate11
        {
            get { return _rate11; }
        }

        public int Rate12
        {
            get { return _rate12; }
        }

        public byte Rate21
        {
            get { return _rate21; }
        }

        public int Rate22
        {
            get { return _rate22; }
        }

        public byte MobTyp
        {
            get { return _mobTyp; }
        }

        public string XJLName
        {
            get { return _xjlName; }
        }

        public string XJLPWD
        {
            get { return _xjlPWD; }
        }

        public MemoryStream WeiXin
        {
            get { return _wx; }
        }

        public MemoryStream AliPay
        {
            get { return _ali; }
        }

        public double RateMoney(bool IsWX, double money)
        {
            byte Rate1 = IsWX ? _rate11 : _rate21;
            int Rate2 = IsWX ? _rate12 : _rate22;
            double ret = 0;
            if (Rate2 > 0)
            {
                double v = money * Rate2;
                if (Rate1 == 0) v /= 100;
                if (Rate1 == 1) v /= 1000;
                if (Rate1 == 2) v /= 10000;
                ret = v;
            }
            return ret;
        }
    }
}