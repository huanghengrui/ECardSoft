using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ECard78
{
    public partial class frmMJMacReal : frmMJMacBase
    {
        private bool isRealing = false;
        private bool isSaveDB = false;
        private string wavPath = "";
        private UInt32[] watchIndex;
        private int maxCount = 1000;

        protected override void InitForm()
        {
            formCode = "MJMacReal";
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
            SetToolItemState("ItemTAG3", true);
            SetToolItemState("ItemLine3", true);
            if (SystemInfo.HasFaCard)
                AddColumn(realGrid, 0, "CardNo", false, false, 1, 80);
            else
                AddColumn(realGrid, 0, "CardPhysicsNo10", false, false, 1, 80);
            AddColumn(realGrid, 0, "MJDateTime", false, false, 1, 120);
            AddColumn(realGrid, 0, "EmpNo", false, false, 0, 80);
            AddColumn(realGrid, 0, "EmpName", false, false, 0, 80);
            AddColumn(realGrid, 0, "DepartID", false, false, 0, 80);
            AddColumn(realGrid, 0, "DepartName", false, false, 0, 80);
            AddColumn(realGrid, 0, "MacSN", false, false, 1, 80);
            AddColumn(realGrid, 0, "MacDoorName", false, false, 0, 80);
            AddColumn(realGrid, 0, "MacPassState", false, false, 1, 80);
            AddColumn(realGrid, 0, "MacReadImpact", false, false, 1, 80);
            AddColumn(realGrid, 0, "EmpSysID", true, false, 1, 80);
            AddColumn(alarmGrid, 0, "MJDateTime", false, false, 1, 120);
            AddColumn(alarmGrid, 0, "MacSN", false, false, 1, 80);
            AddColumn(alarmGrid, 0, "MacDoorName", false, false, 0, 80);
            AddColumn(alarmGrid, 0, "MacReadID", true, false, 1, 80);
            AddColumn(alarmGrid, 0, "IndexNum", false, false, 1, 80);
            AddColumn(alarmGrid, 0, "Memo", false, false, 0, 200);
            ShowFlag = 2;
            base.InitForm();
            alarmGrid.Columns[0].HeaderText = Pub.GetResText("MJReportAlarm", "MJDateTime", "");
            AddColumn(dataGrid, 0, "MacDoor1", false, false, 1, 80);
            AddColumn(dataGrid, 0, "MacDoor2", false, false, 1, 80);
            AddColumn(dataGrid, 0, "MacDoor3", false, false, 1, 80);
            AddColumn(dataGrid, 0, "MacDoor4", false, false, 1, 80);
            dataGrid.Columns[dataGrid.ColumnCount - 4].HeaderText = Pub.GetResText(formCode, "MacDoor1", "");
            dataGrid.Columns[dataGrid.ColumnCount - 3].HeaderText = Pub.GetResText(formCode, "MacDoor2", "");
            dataGrid.Columns[dataGrid.ColumnCount - 2].HeaderText = Pub.GetResText(formCode, "MacDoor3", "");
            dataGrid.Columns[dataGrid.ColumnCount - 1].HeaderText = Pub.GetResText(formCode, "MacDoor4", "");
            wavPath = SystemInfo.AppPath + "wav\\";
            dataGrid.Dock = DockStyle.Top;
            dataGrid.Height = 200;
            panel1.Dock = DockStyle.Fill;
            maxCount = SystemInfo.ini.ReadIni("Public", "RealMax", 1000);
        }

        public frmMJMacReal()
        {
            InitializeComponent();
        }

        private void frmMJMacReal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isRealing)
            {
                ExecItemTAG3();
                e.Cancel = true;
            }
        }

        protected override void ExecItemTAG1()
        {
            if (!InitMacList()) return;
            base.ExecItemTAG1();
            isSaveDB = false;
            isRealing = true;
            RefreshForm(true);
            watchIndex = new UInt32[connList.Count];
            timer1.Enabled = true;
        }

        protected override void ExecItemTAG2()
        {
            if (!InitMacList()) return;
            base.ExecItemTAG2();
            isSaveDB = true;
            isRealing = true;
            RefreshForm(true);
            watchIndex = new UInt32[connList.Count];
            timer1.Enabled = true;
        }

        protected override void ExecItemTAG3()
        {
            base.ExecItemTAG3();
            timer1.Enabled = false;
            isRealing = false;
            RefreshForm(true);
        }

        protected override void RefreshForm(bool State)
        {
            base.RefreshForm(State);
            ItemTAG1.Enabled = ItemTAG1.Enabled && !isRealing;
            ItemTAG2.Enabled = ItemTAG2.Enabled && !isRealing;
            ItemTAG3.Enabled = ItemTAG3.Enabled && isRealing;
            dataGrid.Enabled = dataGrid.Enabled && !isRealing;
            ItemSelect.Enabled = ItemSelect.Enabled && !isRealing;
            ItemUnselect.Enabled = ItemUnselect.Enabled && !isRealing;
            ItemRefresh.Enabled = ItemRefresh.Enabled && !isRealing;
            SetContextMenuState();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            AccessV2API.TYPE_Setting setting = new AccessV2API.TYPE_Setting();
            for (int i = 0; i < connList.Count; i++)
            {
                Application.DoEvents();
                if (!isRealing) break;
                TConnInfoNewMJ connInfo = connList[i];
                DeviceObject.objMJNew.NewDevice(connInfo, 0);
                if (!DeviceObject.objMJNew.ReadSetting(out setting)) continue;
                SetMacDoorState(connInfo.MacSN.ToString(), setting.DoorState);
                if (watchIndex[i] == 0)
                {
                    watchIndex[i] = setting.LogCount;
                    if (watchIndex[i] == 1) watchIndex[i] = 0;
                }
                AccessV2API.TYPE_Log log;
                if (!DeviceObject.objMJNew.ReadLog(watchIndex[i], out log))
                {
                    continue;
                }
                if (log.DateTime.wYear > 3099)
                {
                    continue;
                }
                if (log.Door == 0 || log.Door == 255) continue;
                QHKS.TMJRecordInfo recInfo = new QHKS.TMJRecordInfo();
                recInfo.AlarmType = Convert.ToByte(log.WarnCode);
                recInfo.CardNo = log.CardNo.ToString("0000000000");
                recInfo.CardTime = DeviceObject.objMJNew.MJDateTimeToDateTime(log.DateTime);
                recInfo.DoorID = Convert.ToByte(log.Door);
                recInfo.IsCard = Convert.ToByte(log.CardNo > 0);
                if (recInfo.DoorID > 0 && recInfo.DoorID <= 4)
                {
                    recInfo.IsPass = Convert.ToByte(log.DoorState[recInfo.DoorID - 1] > 0);
                    if (recInfo.IsCard == 1 && recInfo.AlarmType >= 0x80 && recInfo.AlarmType <= 0x86) recInfo.IsPass = 1;
                }
                recInfo.ReaderID = Convert.ToByte(log.Reader);
                ShowRealData(recInfo, connInfo.MacSN.ToString());
                watchIndex[i]++;
                Application.DoEvents();
                //AccessV2API.TYPE_LogPack LogPack = new AccessV2API.TYPE_LogPack();
                //UInt32 PackIndex = 0;
                //int PackCount;
                //while (true)
                //{
                //    if (!isRealing) break;
                //    Application.DoEvents();
                //    PackCount = DeviceObject.objMJNew.ReadBlockLog(PackIndex, ref LogPack);
                //    if (PackCount <= 0 || LogPack.Count == 0) break;
                //    PackIndex++;
                //    for (int j = 0; j < LogPack.Count; j++)
                //    {
                //        if (LogPack.Log[j].Door != 0 && LogPack.Log[j].Door != 255)
                //        {
                //            QHKS.TMJRecordInfo recInfo = new QHKS.TMJRecordInfo();
                //            recInfo.AlarmType = Convert.ToByte(LogPack.Log[j].WarnCode);
                //            recInfo.CardNo = LogPack.Log[j].CardNo.ToString("0000000000");
                //            recInfo.CardTime = DeviceObject.objMJNew.MJDateTimeToDateTime(LogPack.Log[j].DateTime);
                //            recInfo.DoorID = Convert.ToByte(LogPack.Log[j].Door);
                //            recInfo.IsCard = Convert.ToByte(LogPack.Log[j].CardNo > 0);
                //            if (recInfo.DoorID > 0 && recInfo.DoorID <= 4)
                //            {
                //                recInfo.IsPass = Convert.ToByte(LogPack.Log[j].DoorState[recInfo.DoorID - 1] > 0);
                //                if (recInfo.IsCard == 1 && recInfo.AlarmType >= 0x80 && recInfo.AlarmType <= 0x86) recInfo.IsPass = 1;
                //            }
                //            recInfo.ReaderID = Convert.ToByte(LogPack.Log[j].Reader);
                //            ShowRealData(recInfo, connInfo.MacSN.ToString());
                //            Application.DoEvents();
                //        }
                //    }
                //}

            }
            if (isRealing) timer1.Enabled = true;
        }

        public void ShowRealData(QHKS.TMJRecordInfo recInfo, string MacSN)
        {
            string EmpSysID = "";
            string EmpNo = "";
            string EmpName = "";
            string DepartID = "";
            string DepartName = "";
            string CardSectorNo = "";
            string MacDoorName = "";
            string MacPassState = Pub.GetResText(formCode, "AllowPass", "");
            string MacReadImpact = "";
            string Memo = "";
            string readerid = Pub.GetMJReaderID(MacSN, recInfo.ReaderID);
            string wavFile = "";
            DataTableReader dr = null;
            try
            {
                if (recInfo.IsCard == 1)
                {
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003006, new string[] { "1", recInfo.CardNo }));
                    if (dr.Read())
                    {
                        EmpSysID = dr["EmpSysID"].ToString();
                        EmpNo = dr["EmpNo"].ToString();
                        EmpName = dr["EmpName"].ToString();
                        DepartID = dr["DepartID"].ToString();
                        DepartName = dr["DepartName"].ToString();
                        if (SystemInfo.HasFaCard)
                            CardSectorNo = dr["CardSectorNo"].ToString();
                        else
                            CardSectorNo = dr["CardPhysicsNo10"].ToString();
                    }
                    dr.Close();
                }
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003006, new string[] { "3", MacSN, readerid }));
                if (dr.Read())
                {
                    MacDoorName = dr["MacDoorName"].ToString();
                    MacReadImpact = dr["MacReadImpact"].ToString();
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
            if ((EmpSysID == "") || (recInfo.IsPass == 0))
            {
                int IndexNum = recInfo.AlarmType;
                Memo = Pub.GetResText(formCode, "MJRecordMemo" + IndexNum.ToString(), "");
                if (recInfo.IsCard == 1)
                {
                    Memo += "[" + recInfo.CardNo + "]";
                    wavFile = "PassDis.wav";
                }
                else if (IndexNum == 140)
                    wavFile = "NormalIn.wav";
                else if (IndexNum == 141)
                    wavFile = "AlarmDur.wav";
                else if (IndexNum == 142)
                    wavFile = "DoorTime.wav";
                else if ((IndexNum == 143) || (IndexNum == 145) || (IndexNum == 146))
                    wavFile = "Alarm.wav";
                else if (IndexNum == 148)
                    wavFile = "AlarmDis.wav";
                if (wavFile != "")
                {
                    wavFile = wavPath + wavFile;
                    Pub.PlaySound(wavFile);
                }
                alarmGrid.Rows.Add();
                while (alarmGrid.RowCount > maxCount) alarmGrid.Rows.RemoveAt(0);
                alarmGrid[0, alarmGrid.RowCount - 1].Value = recInfo.CardTime;
                alarmGrid[1, alarmGrid.RowCount - 1].Value = MacSN;
                alarmGrid[2, alarmGrid.RowCount - 1].Value = MacDoorName;
                alarmGrid[3, alarmGrid.RowCount - 1].Value = readerid;
                alarmGrid[4, alarmGrid.RowCount - 1].Value = IndexNum;
                alarmGrid[5, alarmGrid.RowCount - 1].Value = Memo;
                alarmGrid.Rows[alarmGrid.RowCount - 1].Selected = true;
                alarmGrid.CurrentCell = alarmGrid.Rows[alarmGrid.RowCount - 1].Cells[0];
                tabControl1.SelectedIndex = 1;
            }
            else
            {
                if (MacReadImpact.ToLower() == "in")
                    wavFile = "NormalIn.wav";
                else
                    wavFile = "NormalIn.wav";
                wavFile = wavPath + wavFile;
                Pub.PlaySound(wavFile);
                realGrid.Rows.Add();
                while (realGrid.RowCount > maxCount) realGrid.Rows.RemoveAt(0);
                realGrid[0, realGrid.RowCount - 1].Value = CardSectorNo;
                realGrid[1, realGrid.RowCount - 1].Value = recInfo.CardTime;
                realGrid[2, realGrid.RowCount - 1].Value = EmpNo;
                realGrid[3, realGrid.RowCount - 1].Value = EmpName;
                realGrid[4, realGrid.RowCount - 1].Value = DepartID;
                realGrid[5, realGrid.RowCount - 1].Value = DepartName;
                realGrid[6, realGrid.RowCount - 1].Value = MacSN;
                realGrid[7, realGrid.RowCount - 1].Value = MacDoorName;
                realGrid[8, realGrid.RowCount - 1].Value = MacPassState;
                realGrid[9, realGrid.RowCount - 1].Value = MacReadImpact;
                realGrid[10, realGrid.RowCount - 1].Value = EmpSysID;
                realGrid.Rows[realGrid.RowCount - 1].Selected = true;
                realGrid.CurrentCell = realGrid.Rows[realGrid.RowCount - 1].Cells[0];
                if (realGrid.RowCount == 1) realGrid_SelectionChanged(null, null);
                tabControl1.SelectedIndex = 0;
            }
            if (isSaveDB) SaveDB(recInfo, MacSN);
        }

        private void SetMacDoorState(string MacSN, UInt32[] doorStatus)
        {
            string s = "";
            for (int i = 0; i < dataGrid.RowCount; i++)
            {
                if (dataGrid[2, i].Value.ToString() == MacSN)
                {
                    for (int j = 0; j < Convert.ToInt32(MacSN.Substring(1, 1)); j++)
                    {
                        if (doorStatus[j] == 0)
                            s = Pub.GetResText(formCode, "DoorClose", "");
                        else
                            s = Pub.GetResText(formCode, "DoorOpen", "");
                        dataGrid[9 + j, i].Value = s;
                    }
                    break;
                }
            }
        }

        private void SaveDB(QHKS.TMJRecordInfo recInfo, string MacSN)
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
                sql = Pub.GetSQL(DBCode.DB_003005, new string[] { "101", t.ToString(SystemInfo.SQLDateFMT), MJTime.ToString(),
          MacSN, recInfo.DoorID.ToString(), recInfo.AlarmType.ToString(), memo, OprtInfo.OprtSysID });
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
            db.WriteSYLog(this.Text, CurrentTool, sql);
        }

        private void realGrid_SelectionChanged(object sender, EventArgs e)
        {
            picPhoto.BackgroundImage = null;
            string EmpSysID = "";
            if (realGrid.SelectedRows.Count < 1) return;
            if (realGrid.SelectedRows[0].Cells[10].Value == null) return;
            EmpSysID = realGrid.SelectedRows[0].Cells[10].Value.ToString();
           
            if (EmpSysID == "") return;
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
                            MemoryStream ms = new MemoryStream(buff);
                            picPhoto.BackgroundImage = Image.FromStream(ms);
                            ms.Close();
                        }
                    }
                }
                lblRecordState.Text = string.Format(Pub.GetResText("", "ItemPosition", ""), realGrid.CurrentCell.RowIndex + 1, realGrid.Rows.Count);
            }
            catch
            {
            }
            finally
            {

                if (dr != null) dr.Close();
                dr = null;
            }
        }

        private void panel2_Resize(object sender, EventArgs e)
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

        private void alarmGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (realGrid.SelectedRows.Count < 1) return;
            if (realGrid.SelectedRows[0].Cells[10].Value == null) return;
            lblRecordState.Text = string.Format(Pub.GetResText("", "ItemPosition", ""), alarmGrid.CurrentCell.RowIndex+1, alarmGrid.Rows.Count);
        }
    }
}