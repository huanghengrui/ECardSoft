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
    public partial class frmKQFaceReal : frmKQFaceBase
    {
        private KQTextFormatInfo textFormat = new KQTextFormatInfo("");
        private int Port = 0;
        private bool isRealing = false;
        private List<string> RealList = new List<string>();
        private int AcPort = 7005;
        private FingerReadData readData = null;
        private TRealSend objRealSend = new TRealSend();
        private bool RealSendPhoto = false;

        protected override void InitForm()
        {
            formCode = "KQFaceReal";
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
            AddColumn(realGrid, 0, "CardFingerNo", false, false, 1, 80);
            AddColumn(realGrid, 0, "CardTime", false, false, 1, 120);
            AddColumn(realGrid, 0, "MacSN", false, false, 0, 80);
            AddColumn(realGrid, 0, "EmpNo", false, false, 0, 80);
            AddColumn(realGrid, 0, "EmpName", false, false, 0, 80);
            AddColumn(realGrid, 0, "DepartID", false, false, 0, 80);
            AddColumn(realGrid, 0, "DepartName", false, false, 0, 80);
            AddColumn(realGrid, 0, "EmpSysID", true, false, 1, 80);
            QueryFlag = 1;
            ShowFlag = 1;
            IgnoreSelect = true;
            base.InitForm();
            dataGrid.Columns[0].Visible = false;
            ItemFindText.Text = AcPort.ToString();
            dataGrid.Dock = DockStyle.Top;
            dataGrid.Height = 200;
            panel2.Dock = DockStyle.Top;
            panel1.Dock = DockStyle.Fill;
            dataGrid.CellBeginEdit += dataGrid_CellBeginEdit;
            LoadTextFormat();
        }

        public frmKQFaceReal()
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
            if (!Pub.IsNumeric(s)) s = AcPort.ToString();
            int.TryParse(s, out Port);
            if (Port > 0xffff) Port = AcPort;
            base.ExecItemTAG1();
            readData = new FingerReadData(this.Text + "[" + CurrentTool + "]");
            int ResultCode = axRealSvr.OpenNetwork(Port);
            if (ResultCode != (int)FKRun.RUN_SUCCESS)
            {
                lblMsg.Text = DeviceObject.objFK623.GetRunMsg(ResultCode);
                return;
            }
            isRealing = true;
            RefreshForm(true);
           
        }

        protected override void ExecItemTAG2()
        {
            base.ExecItemTAG2();
            axRealSvr.CloseNetwork(Port);
            isRealing = false;
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
                    dataGrid[11, i].Value = 0;
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
                    dt.Rows[i][0] = true;
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

        public void ShowRealDataProcess(TFingerLog attLog, int MacSN)
        {
            string EmpSysID = "";
            string EmpNo = "";
            string EmpName = "";
            string DepartID = "";
            string DepartName = "";
            DataTableReader dr = null;
            try
            {
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "240", attLog.CardID }));
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
            realGrid[0, realGrid.RowCount - 1].Value = Convert.ToInt32(attLog.CardID);
            realGrid[1, realGrid.RowCount - 1].Value = attLog.Time;
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
            objRealSend.SendDataKQ(MacSN.ToString(), EmpNo, EmpName, DepartID, DepartName, attLog.CardID, attLog.Time, PhotoData);
        }

        private void frmKQFaceReal_FormClosing(object sender, FormClosingEventArgs e)
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


        private void SaveRealData(UInt32 EnrollNumber, DateTime logTime, int MacSN, byte[] PhotoImage)
        {
            TFingerLog attLog = new TFingerLog();
            attLog.CardID = EnrollNumber.ToString("0000000000");
            attLog.Time = logTime;
            string GUID = "";
            if (readData != null)
            {
                readData.SaveDB(db, attLog, MacSN, ref GUID);
                if (GUID != "" && PhotoImage != null && PhotoImage.Length > 0)
                {
                    readData.SaveDBPhoto(db, GUID, PhotoImage);
                }
            }
            ShowRealDataProcess(attLog, MacSN);
            for (int i = 0; i < dataGrid.RowCount; i++)
            {
                if (dataGrid[2, i].Value.ToString() == MacSN.ToString())
                {
                    int DataCount = 0;
                    if (dataGrid[11, i].Value != null) int.TryParse(dataGrid[11, i].Value.ToString(), out DataCount);
                    DataCount += 1;
                    dataGrid[11, i].Value = DataCount;
                    break;
                }
            }
        }

        private void axRealSvr_OnReceiveGLogDataExtend(object sender, AxRealSvrOcxTcpLib._DRealSvrOcxTcpEvents_OnReceiveGLogDataExtendEvent e)
        {
            UInt32 EnrollNumber = DeviceObject.objFK623.EnrollNumberToUInt32(e.anSEnrollNumber);
            SaveRealData(EnrollNumber, e.anLogDate, e.anDeviceID, null);
        }

        private bool GetFieldValue(string LogText, string FieldName, ref string FieldValue)
        {
            bool ret = false;
            FieldValue = "";
            string[] s1 = LogText.Split(',');
            for (int i = 0; i < s1.Length; i++)
            {
                string[] s2 = s1[i].Split(':');
                if (s2.Length != 2) continue;
                if (s2[0].ToLower() == FieldName)
                {
                    FieldValue = s2[1];
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        private void ProgJsonText(string logText, string LogImage, int flag, ref string sendLog)
        {
            sendLog = "";
            UInt32 EnrollNumber = 0;
            DateTime logTime = new DateTime();
            string v = "";
            if (GetFieldValue(logText, "user_id", ref v)) UInt32.TryParse(v, out EnrollNumber);
            if (GetFieldValue(logText, "io_time", ref v) && v.Length == 14)
            {
                int y = 0;
                int m = 0;
                int d = 0;
                int hh = 0;
                int mi = 0;
                int se = 0;
                if (int.TryParse(v.Substring(0, 4), out y) && int.TryParse(v.Substring(4, 2), out m) &&
                  int.TryParse(v.Substring(6, 2), out d) && int.TryParse(v.Substring(8, 2), out hh) &&
                  int.TryParse(v.Substring(10, 2), out mi) && int.TryParse(v.Substring(12, 2), out se))
                {
                    logTime = new DateTime(y, m, d, hh, mi, se);
                }
            }
            int MacSN = 0;
            if (GetFieldValue(logText, "fk_device_id", ref v)) int.TryParse(v, out MacSN);
            if (EnrollNumber > 0 && logTime.Year != 1)
            {
                string tmp = LogImage;
                int len = tmp.Length / 2;
                byte[] PhotoImage = new byte[len];
                for (int i = 0; i < len; i++)
                {
                    PhotoImage[i] = Convert.ToByte(tmp.Substring(i * 2, 2), 16);
                }
                SaveRealData(EnrollNumber, logTime, MacSN, PhotoImage);
            }
            if (GetFieldValue(logText, "log_id", ref v))
            {
                if (flag == 1)
                    sendLog = "{\"log_id\":\"" + v + "\",\"result\":\"OK\",\"mode\":\"nothing\"}";
                else
                    sendLog = "{\"log_id\":\"" + v + "\",\"result\":\"OK\"}";
            }
        }

        private void axRealSvr_OnReceiveGLogTextAndImage(object sender, AxRealSvrOcxTcpLib._DRealSvrOcxTcpEvents_OnReceiveGLogTextAndImageEvent e)
        {
            string logText = e.astrLogText.Trim().Replace("\"", "").Replace("{", "").Replace("}", "");
            string LogImage = e.astrLogImage.Replace(" ", "");
            string sendLog = "";
            ProgJsonText(logText, LogImage, 0, ref sendLog);
            axRealSvr.SendResponse(e.astrClientIP, e.anClientPort, sendLog);
        }

        private void axRealSvr_OnReceiveGLogTextOnDoorOpen(object sender, AxRealSvrOcxTcpLib._DRealSvrOcxTcpEvents_OnReceiveGLogTextOnDoorOpenEvent e)
        {
            string logText = e.astrLogText.Trim().Replace("\"", "").Replace("{", "").Replace("}", "");
            string LogImage = e.astrLogImage.Replace(" ", "");
            string sendLog = "";
            ProgJsonText(logText, LogImage, 0, ref sendLog);
            axRealSvr.SendRtLogResponseV3(e.astrClientIP, e.anClientPort, sendLog);
        }
    }
}