using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSeaFaceBase : frmBaseMDIChildGrid
    {
        private List<TConnInfoSEA> connList = new List<TConnInfoSEA>();
        protected bool IsExec = false;
        protected int QueryFlag = 0;
        protected int ShowFlag = 0;
        private string currOprt = "";
        protected bool ShowTextMsg = false;

        protected override void InitForm()
        {
            dataGrid.Columns.Clear();
            AddColumn(1, "SelectCheck", false, false, 1, 60);
            AddColumn(0, "MacSysID", true, false, 0);
            AddColumn(0, "MacSN", false, 0);
            AddColumn(0, "MacIPAddress", false, false, 0);
            AddColumn(0, "MacPort", false, false, 0);
            AddColumn(0, "MacName", false, false, 0);
            AddColumn(0, "MacPWD", true, false, 0);
            AddColumn(0, "MacInOut", true, false, 0);
            AddColumn(0, "MacInOutName", false, false, 0);
            AddColumn(0, "MacDesc", false, false, 0);
            if (ShowFlag == 0)
                AddColumn(0, "MacResult", false, false, 0);
            else if (ShowFlag == 1)
                AddColumn(0, "DataCount", false, false, 100);
            base.InitForm();
            string QueryCoin = "";
            switch (QueryFlag)
            {
                case 1:
                    QueryCoin = Pub.GetSQL(DBCode.DB_002001, new string[] { "103" });
                    break;
                case 255:
                    QueryCoin = Pub.GetSQL(DBCode.DB_002001, new string[] { "107" });
                    break;
            }
            QuerySQL = Pub.GetSQL(DBCode.DB_006001, new string[] { "0", QueryCoin });
            ExecItemRefresh();
        }

        public frmSeaFaceBase()
        {
            InitializeComponent();
        }

        private void RowToConnInfo(int RowIndex)
        {
            string MacSN = dataGrid[2, RowIndex].Value.ToString();
            string MacIPAddress = dataGrid[3, RowIndex].Value.ToString();
            string MacPort = dataGrid[4, RowIndex].Value.ToString();
            string MacName = dataGrid[5, RowIndex].Value.ToString();
            string MacPWD = dataGrid[6, RowIndex].Value.ToString();
            TConnInfoSEA conn = Pub.ValueToConnInfoSEA(MacSN, MacIPAddress, MacPort, MacName, MacPWD);
            connList.Add(conn);
        }

        private bool InitMacList(bool IsMac)
        {
            for (int i = 0; i < dataGrid.RowCount; i++)
            {
                SetMacResult(Convert.ToInt32(dataGrid[2, i].Value.ToString()), true, "");
            }
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
            if ((connList.Count == 0) && !IsMac)
            {
                RowToConnInfo(dataGrid.CurrentRow.Index);
            }
            if (connList.Count == 0)
            {
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorSelectMacOprt", ""));
            }
            return connList.Count > 0;
        }

        private void SetMacResult(int MacSN, bool state, string result)
        {
            for (int i = 0; i < dataGrid.RowCount; i++)
            {
                if (dataGrid[2, i].Value.ToString() == MacSN.ToString())
                {
                    if (result == "")
                        dataGrid[10, i].Value = result;
                    else
                    {
                        dataGrid[10, i].Value = currOprt + ": " + result;
                        if (state)
                            dataGrid[10, i].Style.ForeColor = Color.Blue;
                        else
                            dataGrid[10, i].Style.ForeColor = Color.Red;
                    }
                    break;
                }
            }
        }
        protected void ExecMacOprt(byte flag)
        {
            ExecMacOprt(flag, true);
        }

        protected void ExecMacOprt(byte flag, bool IsMac)
        {
            currOprt = CurrentTool;
            bool state;
            string msg = "";
            string MacMsg = "";
            if (!InitMacList(IsMac)) return;
            IsExec = true;
            string tmp = "";
            RefreshForm(false);
            DateTime start = new DateTime();
            start = DateTime.Now;
            string ExecTimes = "";
            txtMag.Text = "";
            string url = "";
            for (int i = 0; i < connList.Count; i++)
            {

                TConnInfoSEA conn = connList[i];
                if (RegisterInfo.IsValid || RegisterInfo.IsTest)
                {
                    if (RegisterInfo.EndDate < DateTime.Now)
                    {
                        MacMsg = RegisterInfo.StateText;
                        break;
                    }
                }

                url = "http://" + conn.NetIP + "/";
                string body = "";
                string urlTestConnt = "http://" + conn.NetIP + "/action/GetSysParam";
                bool ret = DeviceObject.objFK623.POST_GetResponse(urlTestConnt, conn.NetName, conn.NetPassword, ref body);

                if (ret)
                {
                    state = ExecMacCommand( flag,Convert.ToInt32(conn.MacSN), url,  conn.NetName, conn.NetPassword, ref MacMsg);
                }
                else
                {
                    state = false;
                }

                ExecTimes = "    " + Pub.GetDateDiffTimes(start, DateTime.Now);
                if (IsMac)
                {
                    if (MacMsg != "") MacMsg = "[" + MacMsg + "]";
                    tmp = DeviceObject.objFK623.SeaBodyStr();
                    SetMacResult(Convert.ToInt32(conn.MacSN), state, MacMsg + tmp + ExecTimes);
                    msg = msg + GetMacMsg(Convert.ToInt32(conn.MacSN)) + ":" + MacMsg + DeviceObject.objFK623.SeaBodyStr() + ";";
                }
                else if (state)
                {
                    SetMacResult(Convert.ToInt32(conn.MacSN), state, Pub.GetResText(formCode, "MsgSaveSucceed", "") + ExecTimes);
                    msg = msg + GetMacMsg(Convert.ToInt32(conn.MacSN)) + ":" + Pub.GetResText(formCode, "MsgSaveSucceed", "") + MacMsg + ";";
                }
                else
                {
                    SetMacResult(Convert.ToInt32(conn.MacSN), state, Pub.GetResText(formCode, "MsgSaveFailed", "") + ExecTimes);
                    msg = msg + GetMacMsg(Convert.ToInt32(conn.MacSN)) + ":" + Pub.GetResText(formCode, "MsgSaveFailed", "") + MacMsg + ";";
                }
                Application.DoEvents();
                start = DateTime.Now;
                if (!IsExec) break;
            }
            db.WriteSYLog(this.Text, currOprt, msg);
            IsExec = false;
            RefreshForm(true);
            RefreshMsg("");
        }

        protected virtual bool ExecMacCommand(byte flag, int MacSN, string url, string NetName,string NetPassword, ref string MacMsg)
        {
            MacMsg = "";
            return false;
        }

        protected string GetMacMsg(int MacSN)
        {
            string ret = dataGrid.Columns[2].HeaderText + "=" + MacSN.ToString();
            return ret;
        }

        protected string GetMacSysID()
        {
            DataRowView drv = (DataRowView)bindingSource.Current;
            if (drv == null)
                return "";
            else
                return drv.Row["MacSysID"].ToString();
        }

   
        private void frmKQFaceBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsExec)
            {
                IsExec = false;
            }
            e.Cancel = !dataGrid.Enabled;
        }

        protected bool SyncTime(string url, string name, string pwd)
        {
            bool ret = false;
            DateTime dt = new DateTime();
            string syncTime = "";
            if (db.GetServerDate(ref dt))
            {
                url = url + "action/SetSysTime";
                SeaSeriesSyncTime seaSeriesSyncTime = new SeaSeriesSyncTime(dt.Year,dt.Month,dt.Day,dt.Hour,dt.Minute,dt.Second);
                jsonBody<SeaSeriesSyncTime> jsonBody = new jsonBody<SeaSeriesSyncTime>("SetSysTime", seaSeriesSyncTime);
                syncTime = JsonConvert.SerializeObject(jsonBody);
                ret = DeviceObject.objFK623.POST_GetResponse(url, name, pwd,ref syncTime);
            }

            return ret;
        }

        protected void ShowMsg(string msg)
        {
            txtMag.Text = txtMag.Text + msg;
        }

        protected override void RefreshForm(bool State)
        {
            base.RefreshForm(State);
            txtMag.Enabled = State && !IsExec && ShowTextMsg;
            txtMag.Visible = ShowTextMsg;
        }
    }
}