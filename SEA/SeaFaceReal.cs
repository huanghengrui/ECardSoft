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
    public partial class frmSeaFaceReal : frmSeaFaceBase
    {
        private KQTextFormatInfo textFormat = new KQTextFormatInfo("");
        private int Port = 0;
        private bool isRealing = false;
        private List<string> RealList = new List<string>();
        private int AcPort = 8080;
        private TRealSend objRealSend = new TRealSend();
        private bool RealSendPhoto = false;
        SeaHttpServer seaHttpServer = null;

        protected override void InitForm()
        {
            formCode = "SeaFaceReal";
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
            AddColumn(realGrid, 0, "GUID", true, false, 1, 80);
            QueryFlag = 1;
            ShowFlag = 1;
            IgnoreSelect = true;
            base.InitForm();
            //dataGrid.Columns[0].Visible = false;
           
            dataGrid.Dock = DockStyle.Top;
            dataGrid.Height = 200;
            panel2.Dock = DockStyle.Top;
            panel1.Dock = DockStyle.Fill;
            dataGrid.CellBeginEdit += dataGrid_CellBeginEdit;
            LoadTextFormat();
            ItemFindText.Text = AcPort.ToString();
            Application.DoEvents();
        }

        public frmSeaFaceReal()
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
            seaHttpServer = new SeaHttpServer();
            seaHttpServer.Setup(db,Port, label1, textFormat, ShowRealDataProcess);
            isRealing = true;
            RefreshForm(true);
           
        }

        protected override void ExecItemTAG2()
        {
            base.ExecItemTAG2();
            if(seaHttpServer!=null)
                seaHttpServer.Setup(db, 0, label1, textFormat, ShowRealDataProcess);
            isRealing = false;
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
                    dt.Rows[i].BeginEdit();
                    dt.Rows[i][0] = true;
                    dt.Rows[i].EndEdit();
                    dataGrid[10, i].Value = 0;
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

        public void ShowRealDataProcess(TSeaLog attLog, int MacSN,string GUID)
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
            if(realGrid.RowCount>0)
            {
                if (realGrid[1, realGrid.RowCount - 1].Value.ToString() == attLog.CardTime.ToString() && realGrid[2, realGrid.RowCount - 1].Value.ToString() == MacSN.ToString())
                {
                    return;
                }
            }
           
            realGrid.Rows.Add();
            realGrid[0, realGrid.RowCount - 1].Value = Convert.ToInt32(attLog.CardID);
            realGrid[1, realGrid.RowCount - 1].Value = attLog.CardTime;
            realGrid[2, realGrid.RowCount - 1].Value = MacSN;
            realGrid[3, realGrid.RowCount - 1].Value = EmpNo;
            realGrid[4, realGrid.RowCount - 1].Value = EmpName;
            realGrid[5, realGrid.RowCount - 1].Value = DepartID;
            realGrid[6, realGrid.RowCount - 1].Value = DepartName;
            realGrid[7, realGrid.RowCount - 1].Value = EmpSysID;
            realGrid[8, realGrid.RowCount - 1].Value = GUID;
            realGrid.Rows[realGrid.RowCount - 1].Selected = true;

          
            realGrid.CurrentCell = realGrid.Rows[realGrid.RowCount - 1].Cells[0];
            if (realGrid.RowCount == 1) realGrid_SelectionChanged(null, null);
            //if (!SystemInfo.UseRealSendKQ || !objRealSend.IsInit) return;
            //string PhotoData = RealSendPhoto ? ShowEmpPhoto(false) : "";
         
            //objRealSend.SendDataKQ(MacSN.ToString(), EmpNo, EmpName, DepartID, DepartName, attLog.CardID, attLog.Time, PhotoData);
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
            e.Cancel = true;
        }

        private void realGrid_SelectionChanged(object sender, EventArgs e)
        {
            picPhoto.BackgroundImage = null;
            picData.BackgroundImage = null;
            if (realGrid.SelectedRows.Count < 1) return;
            if (realGrid.SelectedRows[0].Cells[7].Value != null)
            {
                ShowEmpPhoto(true);
            }
            if (realGrid.SelectedRows[0].Cells[8].Value != null)
            {
                ShowDataPhoto(true);
            }


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

        private string ShowDataPhoto(bool IsShow)
        {
            
            string GUID = realGrid.SelectedRows[0].Cells[8].Value.ToString();
            if (GUID == "") return "";
            string ret = "";
            DataTableReader dr = null;
            try
            {
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_006001, new string[] { "15", GUID }));
                if (dr.Read())
                {
                    if (dr["Photo"].ToString() != "")
                    {
                        byte[] buff = (byte[])(dr["Photo"]);
                        if (buff.Length > 0)
                        {
                            MemoryStream ms = new MemoryStream(buff);
                            picData.BackgroundImage = Image.FromStream(ms);
                            ms.Close();
                        }
                    }
                }
                if (picData.BackgroundImage != null) return ret;
                dr.Close();
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_006001, new string[] { "17", GUID }));
                if (dr.Read())
                {
                    if (dr["Photo"].ToString() != "")
                    {
                        byte[] buff = (byte[])(dr["Photo"]);
                        if (buff.Length > 0)
                        {
                            MemoryStream ms = new MemoryStream(buff);
                            picData.BackgroundImage = Image.FromStream(ms);
                            ms.Close();
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
    }
}