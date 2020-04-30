using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace ECard78
{
    public partial class frmSFMacReal : frmSFMacBase
    {
        public delegate void CardReadEventHandler(string msg);
        private TRealSocket socket;
        private int Port = 0;
        private bool isRealing = false;
        private List<string> RealList = new List<string>();
        private static List<string> sqls = new List<string>();
        //public static event CardReadEventHandler CallBack_First;
        private SFReadData readData = null;
        private bool HasWan = false;
        private int maxCount = 1000;
        public static object locker = new object();
        private TRealSend objRealSend = new TRealSend();
        private bool RealSendPhoto = false;
        public delegate void ProcessDelegate();
        public static DataTableReader drt = null;
        public static DataTable sendbackdr = null;
        public static DataTable backdr = null;
        public static DataTable dre = null;
        public delegate void MyInvoke(string str1);
        public static string numCard = "";
        public static List<string> Info = new List<string>();
        public static bool threadStop = true;
        public static bool threadsql = false;
        // public static MyInvoke mi = new MyInvoke(aUpdateMsg);
        public static DateTime ServerDate = new DateTime();
        protected override void InitForm()
        {
            formCode = "SFMacReal";
            SetToolItemState("ItemImport", false);
            SetToolItemState("ItemExport", false);
            SetToolItemState("ItemPrint", false);
            SetToolItemState("ItemLine1", false);
            SetToolItemState("ItemAdd", false);
            SetToolItemState("ItemEdit", false);
            SetToolItemState("ItemDelete", false);
            SetToolItemState("ItemLine2", false);
            SetToolItemState("ItemTAG1", true);
            SetToolItemState("ItemTAG2", true);
            if (SystemInfo.UseRealSendSF && objRealSend.IsInit)
            {
                SetToolItemState("ItemTAG3", true);
                RealSendPhoto = objRealSend.SendEmpPhoto();
            }
            SetToolItemState("ItemLine3", true);
            SetToolItemState("ItemFindLabel", true);
            SetToolItemState("ItemFindText", true);
            SetToolItemState("ItemLine5", true);
            AddColumn(realGrid, 0, "CardNo", false, false, 1, 80);
            AddColumn(realGrid, 0, "SFDate", false, false, 1, 120);
            AddColumn(realGrid, 0, "MacSN", false, false, 0, 80);
            AddColumn(realGrid, 0, "EmpNo", false, false, 0, 80);
            AddColumn(realGrid, 0, "EmpName", false, false, 0, 80);
            AddColumn(realGrid, 0, "DepartID", false, false, 0, 80);
            AddColumn(realGrid, 0, "DepartName", false, false, 0, 80);
            AddColumn(realGrid, 0, "SFType", false, false, 0, 80);
            AddColumn(realGrid, 0, "SFAmount", false, false, 0, 80);
            AddColumn(realGrid, 0, "SFCardBalance", false, false, 0, 80);
            AddColumn(realGrid, 0, "BTAmount", false, false, 0, 80);
            AddColumn(realGrid, 0, "BTBalance", false, false, 0, 80);
            AddColumn(realGrid, 0, "BTWay", false, false, 0, 80);
            AddColumn(realGrid, 0, "SFMealType", false, false, 0, 80);
            AddColumn(realGrid, 0, "EmpSysID", true, false, 1, 80);
            AddColumn(realGrid, 0, "PhyID", false, false, 1, 80);
            AddColumn(realGrid, 0, "MacTAG", false, false, 1, 60);
            QueryFlag = SystemInfo.IsRealOther ? 0 : 1;
            ShowFlag = 1;
            base.InitForm();
            ItemFindText.Text = SystemInfo.REAL603Port.ToString();
            dataGrid.Dock = DockStyle.Top;
            dataGrid.Height = 200;
            panel2.Dock = DockStyle.Top;
            panel1.Dock = DockStyle.Fill;
            dataGrid.CellBeginEdit += dataGrid_CellBeginEdit;
            RealList.Clear();
            maxCount = SystemInfo.ini.ReadIni("Public", "RealMax", 1000);
            //drt = db.GetDataReader(Pub.GetSQL(DBCode.DB_004004, new string[] { "0" }));
            //dre = ConvertDataReaderToDataTable(drt).Copy();

            ThreadPool.SetMaxThreads(10, 10);
        }

        public frmSFMacReal()
        {
            InitializeComponent();

        }

        public static void RealBackCard(int i, string card)
        {
            if (threadStop) return;
            numCard = i.ToString() + "," + card;
            threadsql = true;
           
        }


        private void ThreadCallBack_First(string msg)
        {
            // MyInvoke mi = new MyInvoke(aUpdateMsg);
            // BeginInvoke(mi, new Object[] { msg});
        }
        protected override void ExecItemTAG1()
        {
            string s = ItemFindText.Text;
            if (!Pub.IsNumeric(s)) s = SystemInfo.REAL603Port.ToString();
            int.TryParse(s, out Port);
            if (Port > 0xffff) Port = SystemInfo.REAL603Port;
            base.ExecItemTAG1();
            //CallBack_First += new CardReadEventHandler(ThreadCallBack_First);
            threadStop = false;
            readData = new SFReadData(this.Text + "[" + CurrentTool + "]", true);
            socket = new TRealSocket(Port, ReadSocketData);
            isRealing = true;
            RefreshForm(true);
            string numCard = 3.ToString() + ",";
            SystemInfo.realBack = true;
            if (SystemInfo.Urealback)
            {

                try
                {
                    //dre = (DataTable)bindingSource.DataSource;
                    dre = db.GetDataTable(Pub.GetSQL(DBCode.DB_004004, new string[] { "0" }));
                    backdr = db.GetDataTable(Pub.GetSQL(DBCode.DB_001003, new string[] { "501" }));
                    //sendbackdr = db.GetDataTable(Pub.GetSQL(DBCode.DB_004004, new string[] { "13" }));
                }
                catch (Exception E)
                {
                    Pub.ShowErrorMsg(E);
                }
                db.GetServerDate(ref ServerDate);
                Info.Clear();
                ThreadPool.QueueUserWorkItem(new WaitCallback(PortBackCardreal), numCard);
                msgbGrid.Rows.Clear();
                // PortBackCardreal("");
            }

            timer1.Interval = SystemInfo.WanInterval;
            timer1.Enabled = true;
            socket.Start();
            formCode = "SFMacReal";
        }

        protected override void ExecItemTAG2()
        {
            base.ExecItemTAG2();
            //CallBack_First -= new CardReadEventHandler(ThreadCallBack_First);
            threadStop = true;
            isRealing = false;
            timer1.Enabled = false;
            socket.Stop();
            socket = null;
            readData = null;
            RefreshForm(true);
            formCode = "SFMacReal";
        }

        protected override void ExecItemTAG3()
        {
            base.ExecItemTAG3();
            objRealSend.ShowSetupSF();
            formCode = "SFMacReal";
        }

        public DataTable ConvertDataReaderToDataTable(DataTableReader dataReader)
        {
            DataTable dataTable = new DataTable();


            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                DataColumn mydc = new DataColumn();
                mydc.DataType = dataReader.GetFieldType(i);
                mydc.ColumnName = dataReader.GetName(i);

                dataTable.Columns.Add(mydc);
            }

            while (dataReader.Read())
            {
                DataRow mydr = dataTable.NewRow();
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    mydr[i] = dataReader[i].ToString();
                }

                dataTable.Rows.Add(mydr);
                mydr = null;
            }

            dataReader.Close();
            return (dataTable);


        }

        protected override void ExecItemRefresh()
        {
            HasWan = false;
            base.ExecItemRefresh();
            if (bindingSource.DataSource != null)
            {
                DataTable dt = (DataTable)bindingSource.DataSource;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["MacConnType"].ToString() == MacConnTypeString.LAN)
                    {
                        dt.Rows[i].BeginEdit();
                        dt.Rows[i][0] = true;
                        dt.Rows[i].EndEdit();
                    }
                    else
                        HasWan = true;
                    dataGrid[13, i].Value = 0;
                    dataGrid[14, i].Value = SystemInfo.CurrencySymbol + "0.00";
                    dataGrid[15, i].Value = "";
                }
            }
        }

        protected override void SelectData(bool State)
        {
            if (bindingSource.DataSource != null)
            {
                DataTable dt = (DataTable)bindingSource.DataSource;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i].BeginEdit();
                    if (dt.Rows[i]["MacConnType"].ToString() != MacConnTypeString.LAN)
                        dt.Rows[i][0] = true;
                    else
                        dt.Rows[i][0] = State;
                    dt.Rows[i].EndEdit();
                }
            }
        }

        protected override void RefreshForm(bool State)
        {
            base.RefreshForm(State);
            ItemTAG1.Enabled = ItemTAG1.Enabled && !isRealing;
            ItemTAG2.Enabled = ItemTAG2.Enabled && isRealing;
            dataGrid.Enabled = dataGrid.Enabled && !isRealing;
            ItemSelect.Enabled = ItemSelect.Enabled && !isRealing;
            ItemUnselect.Enabled = ItemUnselect.Enabled && !isRealing;
            ItemRefresh.Enabled = ItemRefresh.Enabled && !isRealing;
            ItemFindText.Enabled = ItemFindText.Enabled && !isRealing;
            SetContextMenuState();
        }

        public void ReadSocketData(string SocketData)
        {
            if (SocketData == "") return;
            int MacSN = Convert.ToInt32(SocketData.Substring(10, 2), 16);
            byte MacType = Convert.ToByte(SocketData.Substring(12, 2), 16);
            if ((MacType < 2) || (MacType > 6)) return;
            if (HasWan) timer1.Enabled = false;
            MacType = Convert.ToByte(MacType + 30);
            string IP = "";
            int Port = 0;
            string MacConnType = "";
            string MacPhysicsAddress = "";
            byte IsBigMac = 0;
            int LogID = 0;
            bool LogIsExists = true;
            int logCount = 0;
            double money = 0;
            string Version = "";
            GetMacConnType(MacSN.ToString(), ref IsBigMac, ref MacConnType, ref IP, ref Port, ref MacPhysicsAddress, ref Version);
            if (RealList.IndexOf(SocketData) == -1)
            {
                LogIsExists = false;
                RealList.Add(SocketData);
                while (RealList.Count > maxCount) RealList.RemoveAt(0);
                if (readData.ReadDataReal(SocketData, db, MacSN, Version, MacType, ref logCount, ref LogID, ref money, ShowRealDataProcess))
                {
                    for (int i = 0; i < dataGrid.RowCount; i++)
                    {
                        if (dataGrid[2, i].Value.ToString() == MacSN.ToString())
                        {
                            int DataCount = 0;
                            if (dataGrid[13, i].Value != null) int.TryParse(dataGrid[13, i].Value.ToString(), out DataCount);
                            DataCount += logCount;
                            double DataMoney = 0;
                            if (dataGrid[14, i].Value != null) double.TryParse(CurrencyToStringEx(dataGrid[14, i].Value.ToString()), out DataMoney);
                            DataMoney += money;
                            dataGrid[13, i].Value = DataCount;
                            dataGrid[14, i].Value = DataMoney.ToString(SystemInfo.CurrencySymbol + "0.00");
                            break;
                        }
                    }
                }
            }
            else
            {
                readData.ReadDataReal(SocketData, db, MacSN, Version, MacType, ref logCount, ref LogID, ref money, null);
            }
            if (!LogIsExists || LogID > 0)
            {
                QHKS.TConnInfo connInfo = new QHKS.TConnInfo();
                connInfo.ConnType = (byte)(MacConnType == MacConnTypeString.LAN ? 2 : 3);
                connInfo.MacSN = MacSN;
                connInfo.IsBigMac = IsBigMac;
                connInfo.MacType = Convert.ToByte(MacType - 30);
                connInfo.NetHost = IP;
                connInfo.NetPort = Port;
                connInfo.MacAddress = MacPhysicsAddress;
                DeviceObject.objKS.Init(ref connInfo);
                DeviceObject.objKS.PubRealOk(LogID);
            }
            if (HasWan) timer1.Enabled = true;
            Application.DoEvents();
            formCode = "SFMacReal";
        }

        public void ShowRealDataProcess(QHKS.TFeeLog feeLog, int MacSN)
        {
            string EmpSysID = "";
            string EmpNo = "";
            string EmpName = "";
            string DepartID = "";
            string DepartName = "";
            string SFType = "";
            string SFMealType = "";
            string SqlStr = "";
            DataTableReader dr = null;
            try
            {
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "215", feeLog.CardID }));
                if (dr.Read())
                {
                    EmpSysID = dr["EmpSysID"].ToString();
                    EmpNo = dr["EmpNo"].ToString();
                    EmpName = dr["EmpName"].ToString();
                    DepartID = dr["DepartID"].ToString();
                    DepartName = dr["DepartName"].ToString();
                }
                dr.Close();
                if (feeLog.SFType == 200 || feeLog.SFType == 201)
                    SqlStr = Pub.GetSQL(DBCode.DB_004005, new string[] { "11", (feeLog.SFType - 200).ToString() });
                else
                    SqlStr = Pub.GetSQL(DBCode.DB_004005, new string[] { "5", feeLog.SFType.ToString() });
                dr = db.GetDataReader(SqlStr);
                if (dr.Read()) SFType = dr["SFTypeName"].ToString();
                dr.Close();
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004005, new string[] { "6", feeLog.MealType.ToString() }));
                if (dr.Read()) SFMealType = dr["MealTypeName"].ToString();
            }
            catch
            {
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            realGrid.Rows.Add();
            while (realGrid.RowCount > maxCount) realGrid.Rows.RemoveAt(0);
            realGrid[0, realGrid.RowCount - 1].Value = feeLog.CardID;
            realGrid[1, realGrid.RowCount - 1].Value = feeLog.SFDate;
            realGrid[2, realGrid.RowCount - 1].Value = MacSN;
            realGrid[3, realGrid.RowCount - 1].Value = EmpNo;
            realGrid[4, realGrid.RowCount - 1].Value = EmpName;
            realGrid[5, realGrid.RowCount - 1].Value = DepartID;
            realGrid[6, realGrid.RowCount - 1].Value = DepartName;
            realGrid[7, realGrid.RowCount - 1].Value = SFType;
            realGrid[8, realGrid.RowCount - 1].Value = feeLog.CZAmount.ToString(SystemInfo.CurrencySymbol + "0.00");
            realGrid[9, realGrid.RowCount - 1].Value = feeLog.CZBalance.ToString(SystemInfo.CurrencySymbol + "0.00");
            realGrid[10, realGrid.RowCount - 1].Value = feeLog.BTAmount.ToString(SystemInfo.CurrencySymbol + "0.00");
            realGrid[11, realGrid.RowCount - 1].Value = feeLog.BTBalance.ToString(SystemInfo.CurrencySymbol + "0.00");
            realGrid[12, realGrid.RowCount - 1].Value = feeLog.BTWay.ToString(SystemInfo.CurrencySymbol + "0.00");
            realGrid[13, realGrid.RowCount - 1].Value = SFMealType;
            realGrid[14, realGrid.RowCount - 1].Value = EmpSysID;
            realGrid[15, realGrid.RowCount - 1].Value = feeLog.PhyID;
            realGrid[16, realGrid.RowCount - 1].Value = feeLog.MacTAG;
            realGrid.Rows[realGrid.RowCount - 1].Selected = true;
            realGrid.CurrentCell = realGrid.Rows[realGrid.RowCount - 1].Cells[0];
            if (realGrid.RowCount == 1) realGrid_SelectionChanged(null, null);
            if (!SystemInfo.UseRealSendSF || !objRealSend.IsInit) return;
            string PhotoData = RealSendPhoto ? ShowEmpPhoto(false) : "";
            objRealSend.SendDataSF(MacSN.ToString(), EmpNo, EmpName, DepartID, DepartName, feeLog.CardID, feeLog.SFDate, SFType, SFMealType,
              feeLog.CZAmount, feeLog.CZBalance, PhotoData);
            formCode = "SFMacReal";
        }

        private void frmSFMacReal_FormClosing(object sender, FormClosingEventArgs e)
        {

            SystemInfo.realBack = false;
            threadStop = true;
            if (isRealing)
            {
                ExecItemTAG2();

                e.Cancel = true;
            }
        }

        private void dataGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dataGrid[5, e.RowIndex].Value.ToString() == MacConnTypeString.LAN)
            {
                e.Cancel = true;
            }
        }

        private void realGrid_SelectionChanged(object sender, EventArgs e)
        {
            picPhoto.BackgroundImage = null;
            if (realGrid.SelectedRows.Count < 1) return;
            if (realGrid.SelectedRows[0].Cells[14].Value == null) return;
            ShowEmpPhoto(true);
        }

        private string ShowEmpPhoto(bool IsShow)
        {
            string EmpSysID = realGrid.SelectedRows[0].Cells[14].Value.ToString();
            if (EmpSysID == "") return "";
            string ret = "";
            DataTableReader dr = null;
            try
            {
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "104", EmpSysID }));
                if (dr.Read())
                {
                    if (dr["EmpPhotoImage"].ToString() != "")
                    {
                        byte[] buff = (byte[])(dr["EmpPhotoImage"]);
                        if (buff.Length > 0)
                        {
                            if (IsShow)
                            {
                                MemoryStream ms = new MemoryStream(buff);
                                picPhoto.BackgroundImage = Image.FromStream(ms);
                                ms.Close();
                            }
                            else
                            {
                                for (int i = 0; i < buff.Length; i++)
                                {
                                    ret += Convert.ToString(buff[i], 16);
                                }
                            }
                        }
                    }
                }
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

        protected void GetMacConnType(string MacSN, ref byte IsBigMac, ref string MacConnType, ref string IP,
          ref int Port, ref string MacPhysicsAddress, ref string Version)
        {
            MacConnType = "";
            IP = "";
            Port = 0;
            IsBigMac = 0;
            MacPhysicsAddress = "";
            Version = "";
            for (int i = 0; i < dataGrid.RowCount; i++)
            {
                if (dataGrid[2, i].Value.ToString() == MacSN)
                {
                    byte.TryParse(dataGrid[3, i].Value.ToString(), out IsBigMac);
                    MacConnType = dataGrid[5, i].Value.ToString();
                    IP = dataGrid[6, i].Value.ToString();
                    int.TryParse(dataGrid[7, i].Value.ToString(), out Port);
                    MacPhysicsAddress = dataGrid[9, i].Value.ToString();
                    if (dataGrid[15, i].Value != null) Version = dataGrid[15, i].Value.ToString();
                    if (Version == "")
                    {
                        QHKS.TConnInfo connInfo = GetRowConnInfo(i);
                        DeviceObject.objKS.Init(ref connInfo);
                        if (DeviceObject.objKS.SysDeviceInfoGet(ref Version)) dataGrid[15, i].Value = Version;
                    }
                    break;
                }
            }
            formCode = "SFMacReal";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            QHKS.TConnInfo connInfo;
            string realData;

            if (bindingSource.DataSource != null)
            {
                DataTable dt = (DataTable)bindingSource.DataSource;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if ((dt.Rows[i]["MacConnType"].ToString() == MacConnTypeString.GPRS) && Pub.ValueToBool(dt.Rows[i][0]))
                    {
                        connInfo = GetRowConnInfo(i);
                        DeviceObject.objKS.Init(ref connInfo);
                        realData = DeviceObject.objKS.SysBeat();
                        if (realData != "")
                            ReadSocketData(realData);
                    }
                }
            }
            if (threadsql)
            {

                try
                {
                    //dre = (DataTable)bindingSource.DataSource;
                    dre = db.GetDataTable(Pub.GetSQL(DBCode.DB_004004, new string[] { "0" }));
                    backdr = db.GetDataTable(Pub.GetSQL(DBCode.DB_001003, new string[] { "501" }));
                    //sendbackdr = db.GetDataTable(Pub.GetSQL(DBCode.DB_004004, new string[] { "13" }));
                }
                catch (Exception E)
                {
                    Pub.ShowErrorMsg(E);
                }
                ThreadPool.QueueUserWorkItem(new WaitCallback(PortBackCardreal), numCard);
                threadsql = false;
            }
            db.GetServerDate(ref ServerDate);
            if (Info.Count != 0)
            {
                for (int i = 0; i < Info.Count; i++)
                {
                    aUpdateMsg(Info[i]);
                }

                Info.Clear();
            }

        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            int w = panel3.Width;
            int h = panel3.Height;
            if (w * 1.4 < h)
                w = (int)Math.Round(h / 1.4);
            else
                h = (int)Math.Round(w * 1.4);
            panel3.Width = w;
            panel3.Height = h;
        }

        public void aUpdateMsg(string msg)
        {
            msgbGrid.Rows.Add();
            msgbGrid[0, msgbGrid.RowCount - 1].Value = msg;
            msgbGrid.CurrentCell = msgbGrid.Rows[msgbGrid.Rows.Count - 1].Cells[0];
        }


        private static void PortBackCardreal(object obj)
        {
            lock (locker)
            {
                QHKS.TConnInfo connInfo;
                SFDownBlack sfBlack;
                QHKS.KS objKS = new QHKS.KS();
                string msg = "";
                Base Pub = new Base();
                bool state = false;
                bool sendstate = false;
                string card = "";
                if (obj != null)
                    card = obj.ToString();

                try
                {
                    for (int i = 0; i < dre.Rows.Count; i++)
                    {

                        //if (!Convert.ToBoolean(dre.Rows[i]["SelectCheck"])) continue;
                        if (threadStop) return;
                        state = false;
                        sendstate = false;
                        byte IsBigMac = Convert.ToByte(dre.Rows[i]["IsBigMac"]);
                        int MacSN = Convert.ToInt32(dre.Rows[i]["MacSN"]);
                        byte MacType = Convert.ToByte(dre.Rows[i]["MacTypeID"]);
                        string MacConnType = dre.Rows[i]["MacConnType"].ToString();
                        string MacIPAddress = dre.Rows[i]["MacIPAddress"].ToString();
                        string MacPort = dre.Rows[i]["MacPort"].ToString();
                        string MacConnPWD = dre.Rows[i]["MacConnPWD"].ToString();
                        string MacPhysicsAddress = dre.Rows[i]["MacPhysicsAddress"].ToString();
                        connInfo = Pub.ValueToConnInfo(IsBigMac, MacSN, MacType, MacConnType, MacIPAddress,
                          MacPort, MacConnPWD, MacPhysicsAddress);

                        msg = string.Format(Pub.GetResText("SFMacReal", "MsgBlackKQ", ""), connInfo.MacSN);

                        string MacVer = "";
                        msg = string.Format(Pub.GetResText("SFMacReal", "MsgBlackSF", ""), connInfo.MacSN);

                        if (threadStop) return;
                        objKS.Init(ref connInfo);
                        state = objKS.SysDeviceInfoGet(ref MacVer);
                        if (state)
                        {
                            objKS.InitMacVer(MacVer);
                        }
                        else
                        {
                            if (threadStop) return;
                            msg = msg + Pub.GetResText("SFMacReal", "MsgFailure", "");
                            //CallBack_First(msg);
                            Info.Add(msg);
                            continue;
                        }

                        objKS.SysSetState(false);

                        string[] tmp = new string[2];
                        tmp = card.Split(',');
                        if (threadStop) return;
                        if (tmp[0] == "3")
                        {
                            objKS.PubTimeSet(ServerDate);
                            sfBlack = new SFDownBlack(backdr, sendbackdr, connInfo);
                            sendstate = sfBlack.sendDown(connInfo.MacAddress, objKS);
                            //if (!(connInfo.MacAddress == null || connInfo.MacAddress == "") && sendstate)
                            //for (int x = 0; x < backdr.Rows.Count; x++)
                            //{
                            //   string cardNo = backdr.Rows[x]["CardSectorNo"].ToString();
                            //   sqls.Add(Pub.GetSQL(DBCode.DB_004004, new string[] { "12", connInfo.MacAddress, cardNo }));
                            //}
                        }
                        else if (tmp[0] == "0")
                        {
                            sfBlack = new SFDownBlack(connInfo);
                            sendstate = sfBlack.realDown(card, objKS);
                            //if (sendstate)
                            //    if (!(connInfo.MacAddress == null || connInfo.MacAddress == ""))
                            ///sqls.Add(Pub.GetSQL(DBCode.DB_004004, new string[] { "12", connInfo.MacAddress, tmp[1] }));
                        }
                        else if (tmp[0] == "1")
                        {
                            sfBlack = new SFDownBlack(backdr, sendbackdr, connInfo);
                            sendstate = sfBlack.sendDown(connInfo.MacAddress, objKS);
                            //sendstate = sfBlack.realDown(card, objKS);
                            //if(sendstate)
                            //if (!(connInfo.MacAddress == null || connInfo.MacAddress == ""))
                            //    sqls.Add(Pub.GetSQL(DBCode.DB_004004, new string[] { "14", connInfo.MacAddress, tmp[1] }));
                        }
                        objKS.SysSetState(true);
                        if (sendstate)
                        {

                            msg = msg + Pub.GetResText("SFMacReal", "MsgSuccess", "");

                        }
                        else
                        {
                            msg = msg + Pub.GetResText("SFMacReal", "MsgFailure", "");

                        }
                        if (threadStop) return;
                        // CallBack_First(msg);
                        Info.Add(msg);
                    }
                }
                catch (Exception E)
                {
                    Pub.ShowErrorMsg(E);
                }

                if (threadStop) return;
            }
        }
        private void msgbGrid_Resize(object sender, EventArgs e)
        {
            Column1.Width = msgbGrid.Width - 20;
            // Column2.Width = msgbGrid.Width - 20;
        }
    }
}