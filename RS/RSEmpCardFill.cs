using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using grproLib;

namespace ECard78
{
    public partial class frmRSEmpCardFill : frmBaseForm
    {
        private string title = "";
        private string StrPosition = "";
        private string StrReading = "";
        private string StrFilling = "";
        private string StrDeleteing = "";
        private string OriginSQL = "";
        private string QuerySQL = "";
        private bool IsFillOk = false;
        private bool IsFilling = false;

        protected override void InitForm()
        {
            formCode = "RSEmpCardFill";
            base.InitForm();
            this.Text = title;
            StrPosition = Pub.GetResText(formCode, "ItemPosition", "");
            StrReading = Pub.GetResText(formCode, "MsgReadingData", "");
            StrFilling = Pub.GetResText(formCode, "Msg001", "");
            StrDeleteing = Pub.GetResText(formCode, "Msg002", "");
            IsFillOk = false;
            IsFilling = false;
            OriginSQL = Pub.GetSQL(DBCode.DB_001003, new string[] { "105", OprtInfo.DepartPower });
            QuerySQL = Pub.GetSQL(DBCode.DB_001003, new string[] { "113", OriginSQL });
            toolBar_Resize(null, null);
            LoadData();
            string s = db.GetMaxCardSectorNo();
            UInt32 MaxID = 1;
            if (Pub.IsNumeric(s)) MaxID = Convert.ToUInt32(s);
            ItemStartCard.Items.Clear();
            for (UInt32 i = MaxID; i < MaxID + 1000; i++)
            {
                ItemStartCard.Items.Add(i.ToString());
            }
            if (ItemStartCard.Items.Count > 0) ItemStartCard.SelectedIndex = 0;
            dtpDate.Value = DateTime.Now.Date.AddYears(20);
            dtpDate.Checked = false;
            lblMsg.ForeColor = Color.Blue;
        }

        public frmRSEmpCardFill(string Title)
        {
            title = Title;
            InitializeComponent();
        }

        private void LoadData()
        {
            int row = -1;
            RefreshMsg(StrReading);
            if (QuerySQL != "")
            {
                try
                {
                    if (bindingSource.DataSource != null) row = bindingSource.Position;
                    bindingSource.DataSource = null;
                    if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                    bindingSource.DataSource = db.GetDataTable(QuerySQL);
                }
                catch (Exception E)
                {
                    Pub.ShowErrorMsg(E, QuerySQL);
                }
                finally
                {
                    if (bindingSource.DataSource != null)
                    {
                        if (row < bindingSource.Count)
                            bindingSource.Position = row;
                        else if (bindingSource.Count > 0)
                            bindingSource.Position = bindingSource.Count - 1;
                    }
                }
            }
            RefreshForm(true);
            RefreshMsg("");
        }

        private void RefreshMsg(string msg)
        {
            lblMsg.Text = msg;
            if (lblMsg.Text == "")
            {
                progBar.Value = 0;
                progBar.Style = ProgressBarStyle.Blocks;
            }
            else
            {
                progBar.Value = 50;
                progBar.Style = ProgressBarStyle.Marquee;
            }
            statusBar.Refresh();
        }

        private void RefreshForm(bool state)
        {
            int row = 0;
            int rows = 0;
            if (bindingSource.DataSource != null)
            {
                row = bindingSource.Position + 1;
                rows = bindingSource.Count;
            }
            ItemSearch.Enabled = state && !IsFilling;
            ItemCardLabel.Enabled = ItemSearch.Enabled;
            ItemStartCard.Enabled = ItemSearch.Enabled;
            ItemCardFill.Enabled = ItemSearch.Enabled && (rows > 0);
            ItemCardDelete.Enabled = ItemCardFill.Enabled;
            ItemExit.Enabled = ItemSearch.Enabled;
            ItemEditCardDate.Enabled = ItemSearch.Enabled;
            dtpDate.Enabled = ItemSearch.Enabled;
            dataGrid.Enabled = ItemSearch.Enabled;
            lblCount.Text = string.Format(StrPosition, row, rows);
        }

        private void frmRSEmpCardFill_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (IsFillOk) this.DialogResult = DialogResult.OK;
        }

        private void toolBar_Resize(object sender, EventArgs e)
        {
            int w = 0;
            for (int i = 0; i < toolBar.Items.Count; i++)
            {
                w += toolBar.Items[i].Width + toolBar.Items[i].Margin.Left + toolBar.Items[i].Margin.Right;
            }
            dtpDate.Left = w + 10;
            dtpDate.Top = (toolBar.Height - dtpDate.Height) / 2;
        }

        private void bindingSource_PositionChanged(object sender, EventArgs e)
        {
            RefreshForm(true);
        }

        private void ItemSearch_Click(object sender, EventArgs e)
        {
            List<string> FieldText = new List<string>();
            List<string> FieldName = new List<string>();
            List<GRFieldType> FieldType = new List<GRFieldType>();
            FieldName.Add("CardStatusName");
            FieldName.Add("CardTypeName");
            FieldName.Add("EmpNo");
            FieldName.Add("EmpName");
            FieldName.Add("DepartID");
            FieldName.Add("DepartName");
            for (int i = 0; i < FieldName.Count; i++)
            {
                FieldText.Add(Pub.GetResText(formCode, FieldName[i], ""));
                FieldType.Add(GRFieldType.grftString);
            }
            frmPubFind frm = new frmPubFind(this.Text + "[" + ItemSearch.Text + "]", OriginSQL,
              Pub.GetSQL(DBCode.DB_001003, new string[] { "302" }), formCode, FieldText, FieldName, FieldType, false);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                QuerySQL = frm.QuerySQL;
                LoadData();
            }
           
        }

        private void ItemCardFill_Click(object sender, EventArgs e)
        {
            IsFilling = true;
            RefreshForm(false);
            string s = ItemStartCard.Text;
            if (!Pub.IsNumeric(s)) s = db.GetMaxCardSectorNo();
            UInt64 ID = 1;
            if (Pub.IsNumeric(s)) ID = Convert.ToUInt32(s);
            DataTable dt = (DataTable)bindingSource.DataSource;
            DataRow dr = null;
            string msg = "";
            string CardNoDays = "";
            string EmpSysID = "";
            string CardSectorNo = "";
            string EmpNo = "";
            string EmpName = "";
            DateTime d = new DateTime();
            int pos = bindingSource.Position;
            while (IsFilling)
            {
                for (int i = pos; i < dt.Rows.Count; i++)
                {
                LoopNext:
                    bindingSource.Position = i;
                    dataGrid.CurrentCell = dataGrid.SelectedRows[0].Cells[0];
                    Application.DoEvents();
                    if (!IsFilling) break;
                    dr = dt.Rows[i];
                    EmpSysID = dr["EmpSysID"].ToString();
                    EmpNo = dr["EmpNo"].ToString();
                    EmpName = dr["EmpName"].ToString();
                    CardSectorNo = ID.ToString("0000000000");
                    if ((ID <= 0) || (ID > SystemInfo.MaxCardID))
                    {
                        Pub.ShowErrorMsg(SystemInfo.MsgMaxCardID);
                        IsFilling = false;
                        break;
                    }
                    if (db.CardSectorNoIsExists(EmpSysID, CardSectorNo, ref CardNoDays))
                    {
                        if (CardNoDays == " ")
                            msg = Pub.GetResText(formCode, "MsgCardExistsBlack", "");
                        else if (DateTime.TryParse(CardNoDays, out d))
                            msg = Pub.GetResText(formCode, "MsgCardExistsUseDays", "");
                        else
                            msg = Pub.GetResText(formCode, "MsgCardExistsUseing", "");
                        msg = string.Format(msg, CardSectorNo, CardNoDays);
                        if (Pub.MessageBoxShowQuestion(msg))
                        {
                            IsFilling = false;
                            break;
                        }
                        else
                        {
                            ID += 1;
                            goto LoopNext;
                        }
                    }
                    msg = Pub.GetResText(formCode, "MsgCardFillInfo", "");
                    msg = StrFilling + string.Format(msg, EmpNo, EmpName, CardSectorNo);
                    RefreshMsg(msg);
                ContinueData:
                    Application.DoEvents();
                    if (!IsFilling) break;
                    if (!db.EmpCardFill(this.Text, ItemCardFill.Text, EmpSysID, CardSectorNo, dtpDate.Checked, dtpDate.Value))
                    {
                        if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "ErrorCardDB", "")))
                            break;
                        else
                            goto ContinueData;
                    }
                    IsFillOk = true;
                    ID += 1;
                }
                IsFilling = false;
            }
            RefreshForm(true);
            RefreshMsg("");
            if (IsFillOk) LoadData();
             
        }

        private void ItemCardDelete_Click(object sender, EventArgs e)
        {
            IsFilling = true;
            RefreshForm(false);
            DataTable dt = (DataTable)bindingSource.DataSource;
            DataRow dr = null;
            string msg = "";
            string EmpSysID = "";
            string CardSectorNo = "";
            string EmpNo = "";
            string EmpName = "";
            int pos = bindingSource.Position;
            while (IsFilling)
            {
                for (int i = pos; i < dt.Rows.Count; i++)
                {
                    bindingSource.Position = i;
                    dataGrid.CurrentCell = dataGrid.SelectedRows[0].Cells[0];
                    Application.DoEvents();
                    if (!IsFilling) break;
                    dr = dt.Rows[i];
                    EmpSysID = dr["EmpSysID"].ToString();
                    EmpNo = dr["EmpNo"].ToString();
                    EmpName = dr["EmpName"].ToString();
                    CardSectorNo = dr["CardSectorNo"].ToString();
                    msg = Pub.GetResText(formCode, "MsgCardFillInfo", "");
                    msg = StrDeleteing + string.Format(msg, EmpNo, EmpName, CardSectorNo);
                    RefreshMsg(msg);
                ContinueData:
                    Application.DoEvents();
                    if (!IsFilling) break;
                    if (!db.EmpCardFill(this.Text, ItemCardDelete.Text, EmpSysID, "", false, dtpDate.Value))
                    {
                        if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "ErrorCardDB", "")))
                            break;
                        else
                            goto ContinueData;
                    }
                    IsFillOk = true;
                }
                IsFilling = false;
            }
            RefreshForm(true);
            RefreshMsg("");
            if (IsFillOk) LoadData();
        }

        private void ItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}