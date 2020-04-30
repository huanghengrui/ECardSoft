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
    public partial class frmRSEmpCardFillPhysics : frmBaseForm
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
            formCode = "RSEmpCardFillPhysics";
            base.InitForm();
            this.Text = title;
            StrPosition = Pub.GetResText(formCode, "ItemPosition", "");
            StrReading = Pub.GetResText(formCode, "MsgReadingData", "");
            StrFilling = Pub.GetResText(formCode, "Msg001", "");
            StrDeleteing = Pub.GetResText(formCode, "Msg002", "");
            IsFillOk = false;
            IsFilling = false;
            OriginSQL = Pub.GetSQL(DBCode.DB_001003, new string[] { "601", OprtInfo.DepartPower });
            QuerySQL = Pub.GetSQL(DBCode.DB_001003, new string[] { "602", OriginSQL });
            LoadData();
            lblMsg.ForeColor = Color.Blue;
        }

        public frmRSEmpCardFillPhysics(string Title)
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
            ItemCardFill.Enabled = ItemSearch.Enabled && (rows > 0);
            ItemCardDelete.Enabled = ItemCardFill.Enabled;
            ItemCardStop.Enabled = IsFilling;
            ItemExit.Enabled = ItemSearch.Enabled;
            dataGrid.Enabled = ItemSearch.Enabled;
            lblCount.Text = string.Format(StrPosition, row, rows);
        }

        private void frmRSEmpCardFillPhysics_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (IsFillOk) this.DialogResult = DialogResult.OK;
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
            if (!DeviceObject.objCPIC.IsOnline())
            {
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "ReadCardError1", ""));
                return;
            }
            IsFilling = true;
            RefreshForm(false);
            DataTable dt = (DataTable)bindingSource.DataSource;
            DataRow dr = null;
            string msg = "";
            string EmpSysID = "";
            string EmpNo = "";
            string EmpName = "";
            string CardData10;
            string CardDataH;
            string CardData8;
            string CardInfo;
            string ErrMsg = "";
            int pos = bindingSource.Position;
            while (IsFilling)
            {
                for (int i = pos; i < dt.Rows.Count; i++)
                {
                    bindingSource.Position = i;
                    dataGrid.CurrentCell = dataGrid.SelectedRows[0].Cells[0];
                    dr = dt.Rows[i];
                    EmpSysID = dr["EmpSysID"].ToString();
                    EmpNo = dr["EmpNo"].ToString();
                    EmpName = dr["EmpName"].ToString();
                    msg = Pub.GetResText(formCode, "MsgCardFillPhysicsInfo", "");
                    msg = string.Format(msg, EmpNo, EmpName);
                    RefreshMsg(StrFilling + msg);
                LoopCard:
                    Application.DoEvents();
                    if (!IsFilling)
                    {
                        ItemCardStop_Click(null, null);
                        return;
                    }
                    CardData10 = "";
                    CardDataH = "";
                    CardData8 = "";
                    if (!Pub.CheckCardExists(ref CardData10, ref CardDataH, ref CardData8, ref ErrMsg))
                    {
                        lblMsg.Text = ErrMsg;
                        goto LoopCard;
                    }
                    CardInfo = "";
                    if (db.CardPhysicsNoIsExists(EmpSysID, CardData10, ref CardInfo))
                    {
                        if (CardInfo == " ")
                            msg = Pub.GetResText(formCode, "MsgCardFillPhysicsInfo", "");
                        else
                            msg = Pub.GetResText(formCode, "MsgCardPhysicsExistsUseing", "");
                        msg = string.Format(msg, CardData10, CardInfo);
                        if (Pub.MessageBoxShowQuestion(msg))
                        {
                            IsFilling = false;
                            break;
                        }
                        else
                        {
                            goto LoopCard;
                        }
                    }
                ContinueData:
                    Application.DoEvents();
                    if (!IsFilling) break;
                    if (!db.EmpCardFillPhysics(this.Text, ItemCardFill.Text, EmpSysID, CardData10, CardData8))
                    {
                        if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "ErrorCardDB", "")))
                            break;
                        else
                            goto ContinueData;
                    }
                    lblMsg.Text = Pub.GetResText(formCode, "MsgCardFillPhysicsSuccess", "");
                    IsFillOk = true;
                    Pub.CardBuzzer();
                    dr["CardPhysicsNo10"] = CardData10;
                LoopNoCard:
                    Application.DoEvents();
                    if (DeviceObject.objCPIC.CardIsExists()) goto LoopNoCard;
                }
                IsFilling = false;
            }
            ItemCardStop_Click(null, null);
           
        }

        private void ItemCardDelete_Click(object sender, EventArgs e)
        {
            IsFilling = true;
            RefreshForm(false);
            DataTable dt = (DataTable)bindingSource.DataSource;
            DataRow dr = null;
            string msg = "";
            string EmpSysID = "";
            string CardPhysicsNo10 = "";
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
                    CardPhysicsNo10 = dr["CardPhysicsNo10"].ToString();
                    if (CardPhysicsNo10 == "") continue;
                    msg = Pub.GetResText(formCode, "MsgCardFillInfo", "");
                    msg = StrDeleteing + string.Format(msg, EmpNo, EmpName, CardPhysicsNo10);
                    RefreshMsg(msg);
                ContinueData:
                    Application.DoEvents();
                    if (!IsFilling) break;
                    if (!db.EmpCardFillPhysics(this.Text, ItemCardDelete.Text, EmpSysID, "", ""))
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
            ItemCardStop_Click(null, null);
          
        }

        private void ItemCardStop_Click(object sender, EventArgs e)
        {
            IsFilling = false;
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