using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;

namespace ECard78
{
    public partial class frmKQMacReal : frmKQMacBase
    {
        private KQTextFormatInfo textFormat = new KQTextFormatInfo("");
        private TRealSocket socket;
        private int Port = 0;
        private bool isRealing = false;
        private List<string> RealList = new List<string>();
        private KQReadData readData = null;
        private bool HasWan = false;
        private int maxCount = 1000;
        private TRealSend objRealSend = new TRealSend();
        private bool RealSendPhoto = false;

        protected override void InitForm()
        {
            formCode = "KQMacReal";
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
            if (SystemInfo.UseRealSendKQ && objRealSend.IsInit)
            {
                SetToolItemState("ItemTAG3", true);
                RealSendPhoto = objRealSend.SendEmpPhoto();
            }
            SetToolItemState("ItemLine3", true);
            SetToolItemState("ItemFindLabel", true);
            SetToolItemState("ItemFindText", true);
            SetToolItemState("ItemLine5", true);
            AddColumn(realGrid, 0, "CardNo", false, false, 1, 80);
            AddColumn(realGrid, 0, "CardTime", false, false, 1, 120);
            AddColumn(realGrid, 0, "MacSN", false, false, 0, 80);
            AddColumn(realGrid, 0, "EmpNo", false, false, 0, 80);
            AddColumn(realGrid, 0, "EmpName", false, false, 0, 80);
            AddColumn(realGrid, 0, "DepartID", false, false, 0, 80);
            AddColumn(realGrid, 0, "DepartName", false, false, 0, 80);
            AddColumn(realGrid, 0, "EmpSysID", true, false, 1, 80);
            QueryFlag = SystemInfo.IsRealOther ? 0 : 1;
            ShowFlag = 1;
            base.InitForm();
            ItemFindText.Text = SystemInfo.REAL603Port.ToString();
            dataGrid.Dock = DockStyle.Top;
            dataGrid.Height = 200;
            panel2.Dock = DockStyle.Top;
            panel1.Dock = DockStyle.Fill;
            dataGrid.CellBeginEdit += dataGrid_CellBeginEdit;
            LoadTextFormat();
            maxCount = SystemInfo.ini.ReadIni("Public", "RealMax", 1000);
        }

        public frmKQMacReal()
        {
            InitializeComponent();
        }

        private void LoadTextFormat()
        {
            DataTableReader dr = null;
            try
            {
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "112", KQTextFormatInfo.KQ_ConfigID,
          KQTextFormatInfo.KQ_TextFormat }));
                if (dr.Read()) textFormat = new KQTextFormatInfo(dr["Value"].ToString());
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

        protected override void ExecItemTAG1()
        {
            string s = ItemFindText.Text;
            if (!Pub.IsNumeric(s)) s = SystemInfo.REAL603Port.ToString();
            int.TryParse(s, out Port);
            if (Port > 0xffff) Port = SystemInfo.REAL603Port;
            base.ExecItemTAG1();
            readData = new KQReadData(this.Text + "[" + CurrentTool + "]", true);
            socket = new TRealSocket(Port, ReadSocketData);
            isRealing = true;
            RefreshForm(true);
            timer1.Interval = SystemInfo.WanInterval;
            timer1.Enabled = true;
            socket.Start();
           
        }

        protected override void ExecItemTAG2()
        {
            base.ExecItemTAG2();
            isRealing = false;
            timer1.Enabled = false;
            socket.Stop();
            socket = null;
            readData = null;
            RefreshForm(true);
           
        }

        protected override void ExecItemTAG3()
        {
            base.ExecItemTAG3();
            objRealSend.ShowSetupKQ();
           
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
                    dataGrid[11, i].Value = 0;
                    dataGrid[12, i].Value = "";
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
            if (MacType != 1) return;
            if (HasWan) timer1.Enabled = false;
            string IP = "";
            int Port = 0;
            string MacConnType = "";
            string MacPhysicsAddress = "";
            byte IsBigMac = 0;
            int LogID = 0;
            bool LogIsExists = true;
            int logCount = 0;
            string Version = "";
            GetMacConnType(MacSN.ToString(), ref IsBigMac, ref MacConnType, ref IP, ref Port, ref MacPhysicsAddress, ref Version);
            if (RealList.IndexOf(SocketData) == -1)
            {
                LogIsExists = false;
                RealList.Add(SocketData);
                while (RealList.Count > maxCount) RealList.RemoveAt(0);
                if (readData.ReadDataReal(SocketData, db, textFormat, MacSN, Version, ref logCount, ref LogID, ShowRealDataProcess))
                {
                    for (int i = 0; i < dataGrid.RowCount; i++)
                    {
                        if (dataGrid[2, i].Value.ToString() == MacSN.ToString())
                        {
                            int DataCount = 0;
                            if (dataGrid[11, i].Value != null) int.TryParse(dataGrid[11, i].Value.ToString(), out DataCount);
                            DataCount += logCount;
                            dataGrid[11, i].Value = DataCount;
                            break;
                        }
                    }
                }
            }
            else
            {
                readData.ReadDataReal(SocketData, db, textFormat, MacSN, Version, ref logCount, ref LogID, null);
            }
            if (!LogIsExists || LogID > 0)
            {
                QHKS.TConnInfo connInfo = new QHKS.TConnInfo();
                connInfo.ConnType = (byte)(MacConnType == MacConnTypeString.LAN ? 2 : 3);
                connInfo.MacSN = MacSN;
                connInfo.IsBigMac = IsBigMac;
                connInfo.MacType = MacType;
                connInfo.NetHost = IP;
                connInfo.NetPort = Port;
                connInfo.MacAddress = MacPhysicsAddress;
                DeviceObject.objKS.Init(ref connInfo);
                DeviceObject.objKS.PubRealOk(LogID);
            }
            if (HasWan) timer1.Enabled = true;
            Application.DoEvents();
            
        }

        public void ShowRealDataProcess(QHKS.TAttLog attLog, int MacSN)
        {
            if (attLog.CardTime == null || attLog.CardTime.ToOADate() == 0) return;
            string EmpSysID = "";
            string EmpNo = "";
            string EmpName = "";
            string DepartID = "";
            string DepartName = "";
            DataTableReader dr = null;
            try
            {
                if (SystemInfo.CardType == 0)
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "215", attLog.CardID }));
                else
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "228", attLog.CardID }));
                if (dr.Read())
                {
                    EmpSysID = dr["EmpSysID"].ToString();
                    EmpNo = dr["EmpNo"].ToString();
                    EmpName = dr["EmpName"].ToString();
                    DepartID = dr["DepartID"].ToString();
                    DepartName = dr["DepartName"].ToString();
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
            realGrid.Rows.Add();
            while (realGrid.RowCount > maxCount) realGrid.Rows.RemoveAt(0);
            realGrid[0, realGrid.RowCount - 1].Value = attLog.CardID;
            realGrid[1, realGrid.RowCount - 1].Value = attLog.CardTime;
            realGrid[2, realGrid.RowCount - 1].Value = MacSN;
            realGrid[3, realGrid.RowCount - 1].Value = EmpNo;
            realGrid[4, realGrid.RowCount - 1].Value = EmpName;
            realGrid[5, realGrid.RowCount - 1].Value = DepartID;
            realGrid[6, realGrid.RowCount - 1].Value = DepartName;
            realGrid[7, realGrid.RowCount - 1].Value = EmpSysID;
            realGrid.Rows[realGrid.RowCount - 1].Selected = true;
            realGrid.CurrentCell = realGrid.Rows[realGrid.RowCount - 1].Cells[0];
            if (realGrid.RowCount == 1) realGrid_SelectionChanged(null, null);
            if (!SystemInfo.UseRealSendKQ || !objRealSend.IsInit) return;
            string PhotoData = RealSendPhoto ? ShowEmpPhoto(false) : "";
            
            objRealSend.SendDataKQ(MacSN.ToString(), EmpNo, EmpName, DepartID, DepartName, attLog.CardID, attLog.CardTime, PhotoData);
        }

        private void frmKQMacReal_FormClosing(object sender, FormClosingEventArgs e)
        {
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
            if (realGrid.SelectedRows[0].Cells[7].Value == null) return;
            ShowEmpPhoto(true);
            
        }

        private string ShowEmpPhoto(bool IsShow)
        {
            string EmpSysID = realGrid.SelectedRows[0].Cells[7].Value.ToString();
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

        protected void GetMacConnType(string MacSN, ref byte IsBigMac, ref string MacConnType, ref string IP, ref int Port,
          ref string MacPhysicsAddress, ref string Version)
        {
            MacConnType = "";
            IP = "";
            Port = 0;
            MacPhysicsAddress = "";
            IsBigMac = 0;
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
                    if (dataGrid[12, i].Value != null) Version = dataGrid[12, i].Value.ToString();
                    if (Version == "")
                    {
                        QHKS.TConnInfo connInfo = GetRowConnInfo(i);
                        DeviceObject.objKS.Init(ref connInfo);
                        if (DeviceObject.objKS.SysDeviceInfoGet(ref Version)) dataGrid[12, i].Value = Version;
                    }
                    break;
                }
            }
           
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
                    dt.Rows[i].BeginEdit();
                    if ((dt.Rows[i]["MacConnType"].ToString() == MacConnTypeString.GPRS) && Pub.ValueToBool(dt.Rows[i][0]))
                    {
                        connInfo = GetRowConnInfo(i);
                        DeviceObject.objKS.Init(ref connInfo);
                        realData = DeviceObject.objKS.SysBeat();
                        if (realData != "") ReadSocketData(realData);
                    }
                }
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
    }
}