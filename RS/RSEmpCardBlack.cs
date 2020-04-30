using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmRSEmpCardBlack : frmBaseDialog
    {
        private string mode = "";
        private string title = "";
        public List<string> cardList = new List<string>();

        protected override void InitForm()
        {
            formCode = "RSEmpCardBlack";
            AddColumn(cardGrid, 1, "SelectCheck", false, false, 1, 60);
            AddColumn(cardGrid, 0, "CardSectorNo", false, true, 1, 80);
            AddColumn(cardGrid, 0, "EmpNo", false, true, 1, 80);
            AddColumn(cardGrid, 0, "EmpName", false, true, 1, 80);
            AddColumn(cardGrid, 0, "BlackDate", false, true, 1, 0);
            AddColumn(cardGrid, 0, "OprtNo", false, true, 1, 0);
            IsToggleCheckStateAll = true;
            base.InitForm();
            button3.Enabled = (SystemInfo.HasKQ && ((SystemInfo.KQFlag == 0) || (SystemInfo.KQFlag == 2))) || SystemInfo.HasSF;
            button3.Visible = button3.Enabled;
            this.Text = title;
            if (tvMac.StateImageList == null)
            {
                tvMac.AfterCheck += TreeViewAfterCheck;
                tvMac.CheckBoxes = true;
            }
            else
            {
                tvMac.KeyUp += TreeViewKeyUp;
                tvMac.NodeMouseClick += TreeViewNodeMouseClick;
            }
            Application.DoEvents();
            btnRefresh_Click(null, null);
            this.KeyPreview = true;
        }

        public frmRSEmpCardBlack(string Mode, string Title)
        {
            mode = Mode;
            title = Title;
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshData(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            msgGrid.Rows.Clear();
            byte devType = 0;
            QHKS.TConnInfo connInfo;
            QHKS.TMJConnInfo mjConn;
            TConnInfoNewMJ mjNewConn;
            KQDownBlack kqBlack;
            SFDownBlack sfBlack;
            MJDownBlack mjBlack;
            DataTable dt = (DataTable)bindingSource.DataSource;
            string msg = "";
            bool state = false;
            string MacVer = "";
            for (int i = 0; i < tvMac.Nodes.Count; i++)
            {
                devType = Convert.ToByte(tvMac.Nodes[i].Tag);
                for (int j = 0; j < tvMac.Nodes[i].Nodes.Count; j++)
                {
                    if (tvMac.StateImageList == null)
                    {
                        if (!tvMac.Nodes[i].Nodes[j].Checked) continue;
                    }
                    else
                    {
                        if (tvMac.Nodes[i].Nodes[j].StateImageIndex != 1) continue;
                    }
                    switch (devType)
                    {
                        case 0:
                            connInfo = (QHKS.TConnInfo)tvMac.Nodes[i].Nodes[j].Tag;
                            msg = string.Format(Pub.GetResText(formCode, "MsgBlackKQ", ""), connInfo.MacSN);
                            ShowMsg(msg);
                            if (connInfo.MacType == 1)
                            {
                                DeviceObject.objKS.Init(ref connInfo);
                                state = DeviceObject.objKS.SysDeviceInfoGet(ref MacVer);
                                if (state) DeviceObject.objKS.InitMacVer(MacVer);
                                DeviceObject.objKS.SysSetState(false);
                                db.SyncTime();
                                kqBlack = new KQDownBlack(dt, connInfo);
                                if (state) state = kqBlack.Down();
                                DeviceObject.objKS.SysSetState(true);
                                UpdateMsg(state);
                            }
                            break;
                        case 1:
                            if (SystemInfo.IsNewMJ)
                            {
                                mjNewConn = (TConnInfoNewMJ)tvMac.Nodes[i].Nodes[j].Tag;
                                msg = string.Format(Pub.GetResText(formCode, "MsgBlackMJ", ""), mjNewConn.MacSN);
                                ShowMsg(msg);
                                DeviceObject.objMJNew.NewDevice(mjNewConn);
                                mjBlack = new MJDownBlack(dt, mjNewConn);
                                state = mjBlack.DownNew();
                                UpdateMsg(state);
                            }
                            else
                            {
                                mjConn = (QHKS.TMJConnInfo)tvMac.Nodes[i].Nodes[j].Tag;
                                msg = string.Format(Pub.GetResText(formCode, "MsgBlackMJ", ""), mjConn.MacSN);
                                ShowMsg(msg);
                                DeviceObject.objMJ.Init(ref mjConn);
                                mjBlack = new MJDownBlack(dt, mjConn);
                                state = mjBlack.Down();
                                UpdateMsg(state);
                            }
                            break;
                        case 2:
                            connInfo = (QHKS.TConnInfo)tvMac.Nodes[i].Nodes[j].Tag;
                            msg = string.Format(Pub.GetResText(formCode, "MsgBlackSF", ""), connInfo.MacSN);
                            ShowMsg(msg);
                            DeviceObject.objKS.Init(ref connInfo);
                            state = DeviceObject.objKS.SysDeviceInfoGet(ref MacVer);

                            if (state) DeviceObject.objKS.InitMacVer(MacVer);
                            DeviceObject.objKS.SysSetState(false);
                            db.SyncTime();
                            sfBlack = new SFDownBlack(dt, connInfo);
                            if (state) state = sfBlack.Down();
                            DeviceObject.objKS.SysSetState(true);
                            UpdateMsg(state);
                            break;
                    }
                }
            }
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            msgGrid.Rows.Clear();
            if (dlgFolder.ShowDialog() != DialogResult.OK) return;
            string path = dlgFolder.SelectedPath;
            if (path.Substring(path.Length - 1, 1) != "\\") path = path + "\\";
            QHKS.TConnInfo connInfo = new QHKS.TConnInfo();
            connInfo.MacSN = SystemInfo.IsBigMacAdd ? 65535 : 255;
            connInfo.MacType = 255;
            DeviceObject.objKS.Init(ref connInfo);
            DeviceObject.objKS.InitBlackUSBFile(path);
            int max = cardGrid.RowCount;
            int cnt = 0;
            for (int i = 0; i < max; i++)
            {
                if (!Pub.ValueToBool(cardGrid[0, i].Value)) continue;
                DeviceObject.objKS.PubBlackInit(cardGrid[1, i].Value.ToString(), cnt == 0, true);
                cnt++;
            }
            if (cnt == max) DeviceObject.objKS.PubBlackClearUSB();
            DeviceObject.objKS.PubBlackDataUSB();
            string msg = Pub.GetResText(formCode, "MsgCardBlackSuccess", "") + "\r\n\r\n" + path + "Black.dat";
            ShowMsg(msg);
            Pub.MessageBoxShow(msg, MessageBoxIcon.Information);
           
        }

        private void SelectLast()
        {
            msgGrid.Rows[msgGrid.RowCount - 1].Selected = true;
            msgGrid.CurrentCell = msgGrid.Rows[msgGrid.RowCount - 1].Cells[0];
        }

        private void ShowMsg(string msg)
        {
            msgGrid.Rows.Add();
            msgGrid[0, msgGrid.RowCount - 1].Value = msg;
            SelectLast();
        }

        private void UpdateMsg(bool state)
        {
            string msg = "";
            if (state)
                msg = Pub.GetResText(formCode, "MsgSuccess", "");
            else
                msg = Pub.GetResText(formCode, "MsgFailure", "");
            msgGrid[0, msgGrid.RowCount - 1].Value = msgGrid[0, msgGrid.RowCount - 1].Value.ToString() + msg;
            SelectLast();
        }

        private void frmRSEmpCardBlack_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Alt)
            {
                switch (e.KeyCode)
                {
                    case Keys.D:
                        frmRSEmpCardBlackClear frm = new frmRSEmpCardBlackClear();
                        if (frm.ShowDialog() == DialogResult.OK) RefreshData(2);
                        break;
                }
            }
         
        }

        private void RefreshData(byte flag)
        {
            Jdpane.Visible = true;
            
            if (flag == 0 || flag == 1)
            {
                DataTable dt = null;
                TreeNode node;
                TreeNode nod;
                QHKS.TConnInfo connInfo;
                QHKS.TMJConnInfo mjConn;
                TConnInfoNewMJ mjNewConn;
                string s = "";
                int key = 0;
                tvMac.Nodes.Clear();
                try
                {
                    if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                    if (SystemInfo.HasKQ && ((SystemInfo.KQFlag == 0) || (SystemInfo.KQFlag == 2)))
                    {
                        dt = db.GetDataTable(Pub.GetSQL(DBCode.DB_002001, new string[] { "0" }));
                        if (dt.Rows.Count > 0)
                        {
                            node = tvMac.Nodes.Add(Pub.GetResText(formCode, "DeviceTypeKQ", ""));
                            node.Tag = 0;
                            if (tvMac.StateImageList != null) node.StateImageIndex = 0;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                s = dt.Rows[i]["MacConnType"].ToString();
                                if (s == MacConnTypeString.Comm)
                                    s = s + "  " + dt.Rows[i]["MacPort"].ToString() + "/" + dt.Rows[i]["MacConnPWD"].ToString();
                                else if (s == MacConnTypeString.LAN)
                                    s = s + "  " + dt.Rows[i]["MacIpAddress"].ToString() + "/" + dt.Rows[i]["MacPort"].ToString();
                                else if (s == MacConnTypeString.GPRS)
                                    s = s + "  " + dt.Rows[i]["MacIpAddress"].ToString() + "/" + dt.Rows[i]["MacPort"].ToString() + "/" +
                                      dt.Rows[i]["MacPhysicsAddress"].ToString();
                                connInfo = Pub.ValueToConnInfo(Convert.ToByte(dt.Rows[i]["IsBigMac"]),
                                  Convert.ToInt32(dt.Rows[i]["MacSN"]), 1, dt.Rows[i]["MacConnType"].ToString(),
                                  dt.Rows[i]["MacIpAddress"].ToString(), dt.Rows[i]["MacPort"].ToString(),
                                  dt.Rows[i]["MacConnPWD"].ToString(), dt.Rows[i]["MacPhysicsAddress"].ToString());
                                nod = node.Nodes.Add(dt.Rows[i]["MacSN"].ToString() + "  " + dt.Rows[i]["MacType"] + "  " + s);
                                nod.Tag = connInfo;
                                if (tvMac.StateImageList == null)
                                    nod.Checked = true;
                                else
                                    nod.StateImageIndex = 0;
                            }
                            node.Expand();
                            if (tvMac.StateImageList == null)
                                node.Checked = true;
                            else
                                ToggleCheckState(node);
                        }
                        dt.Clear();
                        dt.Reset();
                    }
                    if (SystemInfo.HasMJ)
                    {
                        dt = db.GetDataTable(Pub.GetSQL(DBCode.DB_003001, new string[] { "0" }));
                        if (dt.Rows.Count > 0)
                        {
                            node = tvMac.Nodes.Add(Pub.GetResText(formCode, "DeviceTypeMJ", ""));
                            node.Tag = 1;
                            if (tvMac.StateImageList != null) node.StateImageIndex = 0;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                s = dt.Rows[i]["MacConnType"].ToString();
                                if (s == MacConnTypeString.Comm)
                                    s = s + "  " + dt.Rows[i]["MacPort"].ToString() + "/" + dt.Rows[i]["MacConnPWD"].ToString();
                                else if (s == MacConnTypeString.LAN)
                                    s = s + "  " + dt.Rows[i]["MacIpAddress"].ToString() + "/" + dt.Rows[i]["MacPort"].ToString();
                                key = -1;
                                if (!int.TryParse(dt.Rows[i]["MacKey"].ToString(), out key)) key = -1;
                                if (SystemInfo.IsNewMJ)
                                {
                                    mjNewConn = Pub.ValueToNewMJConnInfo(dt.Rows[i]["MacSN"].ToString(), dt.Rows[i]["MacConnType"].ToString(),
                                      dt.Rows[i]["MacIpAddress"].ToString(), dt.Rows[i]["MacPort"].ToString(), dt.Rows[i]["MacConnPWD"].ToString());
                                    nod = node.Nodes.Add(dt.Rows[i]["MacSN"].ToString() + "  " + s);
                                    nod.Tag = mjNewConn;
                                }
                                else
                                {
                                    mjConn = Pub.ValueToMJConnInfo(dt.Rows[i]["MacSN"].ToString(), dt.Rows[i]["MacConnType"].ToString(),
                                      dt.Rows[i]["MacIpAddress"].ToString(), dt.Rows[i]["MacPort"].ToString(), dt.Rows[i]["MacConnPWD"].ToString());
                                    nod = node.Nodes.Add(dt.Rows[i]["MacSN"].ToString() + "  " + s);
                                    nod.Tag = mjConn;
                                }
                                if (tvMac.StateImageList == null)
                                    nod.Checked = true;
                                else
                                    nod.StateImageIndex = 0;
                            }
                            node.Expand();
                            if (tvMac.StateImageList == null)
                                node.Checked = true;
                            else
                                ToggleCheckState(node);
                        }
                        dt.Clear();
                        dt.Reset();
                    }
                    if (SystemInfo.HasSF)
                    {
                        dt = db.GetDataTable(Pub.GetSQL(DBCode.DB_004004, new string[] { "0" }));
                        if (dt.Rows.Count > 0)
                        {
                            node = tvMac.Nodes.Add(Pub.GetResText(formCode, "DeviceTypeSF", ""));
                            node.Tag = 2;
                            if (tvMac.StateImageList != null) node.StateImageIndex = 0;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                s = dt.Rows[i]["MacConnType"].ToString();
                                if (s == MacConnTypeString.Comm)
                                    s = s + "  " + dt.Rows[i]["MacPort"].ToString() + "/" + dt.Rows[i]["MacConnPWD"].ToString();
                                else if (s == MacConnTypeString.LAN)
                                    s = s + "  " + dt.Rows[i]["MacIpAddress"].ToString() + "/" + dt.Rows[i]["MacPort"].ToString();
                                else if (s == MacConnTypeString.GPRS)
                                    s = s + "  " + dt.Rows[i]["MacIpAddress"].ToString() + "/" + dt.Rows[i]["MacPort"].ToString() + "/" +
                                      dt.Rows[i]["MacPhysicsAddress"].ToString();
                                connInfo = Pub.ValueToConnInfo(Convert.ToByte(dt.Rows[i]["IsBigMac"]),
                                  Convert.ToInt32(dt.Rows[i]["MacSN"]), Convert.ToByte(Convert.ToInt16(dt.Rows[i]["MacTypeID"]) - 30),
                                  dt.Rows[i]["MacConnType"].ToString(), dt.Rows[i]["MacIpAddress"].ToString(),
                                  dt.Rows[i]["MacPort"].ToString(), dt.Rows[i]["MacConnPWD"].ToString(),
                                  dt.Rows[i]["MacPhysicsAddress"].ToString());
                                nod = node.Nodes.Add(dt.Rows[i]["MacSN"].ToString() + "  " + dt.Rows[i]["MacType"] + "  " + s);
                                nod.Tag = connInfo;
                                if (tvMac.StateImageList == null)
                                    nod.Checked = true;
                                else
                                    nod.StateImageIndex = 0;
                            }
                            node.Expand();
                            if (tvMac.StateImageList == null)
                                node.Checked = true;
                            else
                                ToggleCheckState(node);
                        }
                        dt.Clear();
                        dt.Reset();
                    }
                }
                catch (Exception E)
                {
                    Jdpane.Visible = false;
                    Pub.ShowErrorMsg(E);
                }
                finally
                {
                    if (dt != null)
                    {
                        dt.Clear();
                        dt.Reset();
                    }
                }
                button2.Enabled = tvMac.Nodes.Count > 0;
            }
            Application.DoEvents();
            if (flag == 0 || flag == 2)
            {
                string sql = Pub.GetSQL(DBCode.DB_001003, new string[] { "501" });
                try
                {
                    bindingSource.DataSource = db.GetDataTable(sql);
                    Application.DoEvents();
                    if (cardList.Count == 0)
                        button1_Click(null, null);
                    else
                        button4_Click(null, null);
                }
                catch (Exception E)
                {
                    Jdpane.Visible = false;
                    Pub.ShowErrorMsg(E, sql);
                }
            }
            Jdpane.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bindingSource.DataSource == null) return;
            DataTable dt = (DataTable)bindingSource.DataSource;
            for (int i = 0; i < dt.Rows.Count; i++) dt.Rows[i]["SelectCheck"] = true;
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (bindingSource.DataSource == null) return;
            DataTable dt = (DataTable)bindingSource.DataSource;
            for (int i = 0; i < dt.Rows.Count; i++) dt.Rows[i]["SelectCheck"] = false;
            if (sender != null || cardList.Count == 0) return;
            int cnt = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (cardList.IndexOf(dt.Rows[i]["CardSectorNo"].ToString()) >= 0)
                {
                    dt.Rows[i]["SelectCheck"] = true;
                    cnt++;
                    if (cnt >= cardList.Count) break;
                }
            }
          
        }

        private void btnOneDelBack_Click(object sender, EventArgs e)
        {
            msgGrid.Rows.Clear();
            byte devType = 0;
            QHKS.TConnInfo connInfo;
            QHKS.TMJConnInfo mjConn;
            TConnInfoNewMJ mjNewConn;
            KQDownBlack kqBlack;
            SFDownBlack sfBlack;
            MJDownBlack mjBlack;
            DataTable dt = (DataTable)bindingSource.DataSource;
            string msg = "";
            bool state = false;
            string MacVer = "";
            for (int i = 0; i < tvMac.Nodes.Count; i++)
            {
                devType = Convert.ToByte(tvMac.Nodes[i].Tag);
                for (int j = 0; j < tvMac.Nodes[i].Nodes.Count; j++)
                {
                    if (tvMac.StateImageList == null)
                    {
                        if (!tvMac.Nodes[i].Nodes[j].Checked) continue;
                    }
                    else
                    {
                        if (tvMac.Nodes[i].Nodes[j].StateImageIndex != 1) continue;
                    }
                    switch (devType)
                    {
                        case 0:
                            connInfo = (QHKS.TConnInfo)tvMac.Nodes[i].Nodes[j].Tag;
                            msg = string.Format(Pub.GetResText(formCode, "MsgBlackKQ", ""), connInfo.MacSN);
                            ShowMsg(msg);
                            if (connInfo.MacType == 1)
                            {
                                DeviceObject.objKS.Init(ref connInfo);
                                state = DeviceObject.objKS.SysDeviceInfoGet(ref MacVer);
                                if (state) DeviceObject.objKS.InitMacVer(MacVer);
                                DeviceObject.objKS.SysSetState(false);
                                db.SyncTime();
                                kqBlack = new KQDownBlack(dt, connInfo);
                                if (state) state = kqBlack.Down();
                                DeviceObject.objKS.SysSetState(true);
                                UpdateMsg(state);
                            }
                            break;
                        case 1:
                            if (SystemInfo.IsNewMJ)
                            {
                                mjNewConn = (TConnInfoNewMJ)tvMac.Nodes[i].Nodes[j].Tag;
                                msg = string.Format(Pub.GetResText(formCode, "MsgBlackMJ", ""), mjNewConn.MacSN);
                                ShowMsg(msg);
                                DeviceObject.objMJNew.NewDevice(mjNewConn);
                                mjBlack = new MJDownBlack(dt, mjNewConn);
                                state = mjBlack.DownNew();
                                UpdateMsg(state);
                            }
                            else
                            {
                                mjConn = (QHKS.TMJConnInfo)tvMac.Nodes[i].Nodes[j].Tag;
                                msg = string.Format(Pub.GetResText(formCode, "MsgBlackMJ", ""), mjConn.MacSN);
                                ShowMsg(msg);
                                DeviceObject.objMJ.Init(ref mjConn);
                                mjBlack = new MJDownBlack(dt, mjConn);
                                state = mjBlack.Down();
                                UpdateMsg(state);
                            }
                            break;
                        case 2:
                            connInfo = (QHKS.TConnInfo)tvMac.Nodes[i].Nodes[j].Tag;
                            msg = string.Format(Pub.GetResText(formCode, "MsgBlackSF", ""), connInfo.MacSN);
                            ShowMsg(msg);
                            DeviceObject.objKS.Init(ref connInfo);
                            state = DeviceObject.objKS.SysDeviceInfoGet(ref MacVer);

                            if (state) DeviceObject.objKS.InitMacVer(MacVer);
                            DeviceObject.objKS.SysSetState(false);
                            db.SyncTime();
                            sfBlack = new SFDownBlack(dt, connInfo);
                            //if (state) state = sfBlack.OneDown(mode);
                            DeviceObject.objKS.SysSetState(true);
                            UpdateMsg(state);
                            break;
                    }
                }
            }
         
        }
    }
}