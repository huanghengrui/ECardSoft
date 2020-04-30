using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSFBatchAllowance : frmBaseDialog
    {
        private string title = "";
        private string oprt = "";
        private bool IsWorking = false;

        protected override void InitForm()
        {
            formCode = "SFAllowanceAdd";
            CreateCardGridView(cardGrid);
            AddColumn(cardGrid, 0, "AllowanceAmount", false, true, 1, 100);
            for (int i = 0; i < cardGrid.Columns.Count; i++)
            {
                cardGrid.Columns[i].ReadOnly = true;
                if (cardGrid.Columns[i].DataPropertyName == "OtherCardNo" ||
                  cardGrid.Columns[i].DataPropertyName == "CardValudDate")
                {
                    cardGrid.Columns[i].Visible = false;
                }
            }
            SetColCurrencyFormat(cardGrid, "AllowanceAmount");
            cardGrid.ReadOnly = false;
            base.InitForm();
            lblQuickSearchToolTip.ForeColor = Color.Blue;
            this.Text = title + "[" + oprt + "]";
            cbbWay.Items.Clear();
            DataTableReader dr = null;
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004006, new string[] { "18" }));
                while (dr.Read())
                {
                    cbbWay.Items.Add(new TCommonType(dr["AllowanceWaySysID"].ToString(), dr["AllowanceWayID"].ToString(),
                      dr["AllowanceWayName"].ToString(), true));
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
            if (cbbWay.Items.Count > 0) cbbWay.SelectedIndex = 0;
            dtpFlag.Value = DateTime.Now.Date;
        }

        public frmSFBatchAllowance(string Title, string Oprt)
        {
            title = Title;
            oprt = Oprt;
            InitializeComponent();
        }

        private void InitAllowanceAmount()
        {
            for (int i = 0; i < cardGrid.RowCount; i++)
            {
                if (cardGrid[cardGrid.Columns.Count - 1, i].Value == null)
                    cardGrid[cardGrid.Columns.Count - 1, i].Value = "0.00";
            }
            cardGrid.Columns[cardGrid.Columns.Count - 1].ReadOnly = false;
        }

        private void btnQuickSearch_Click(object sender, EventArgs e)
        {
            QuickSearchNormalCard(btnQuickSearch.Text, cardGrid);
            InitAllowanceAmount();
        }

        private void txtQuickSearch_KeyDown(object sender, KeyEventArgs e)
        {
            QuickSearchNormalCard(txtQuickSearch, e, cardGrid);
            if (e.KeyCode == Keys.Enter) InitAllowanceAmount();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = cardGrid.SelectedRows.Count - 1; i >= 0; i--)
            {
                cardGrid.Rows.Remove(cardGrid.SelectedRows[i]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cardGrid.DataSource = null;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            progBar.Visible = true;
            progBar.Value = 0;
            IsWorking = true;
            bool ret = SaveDB();
            IsWorking = false;
            if (ret)
            {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            progBar.Visible = false;
        }

        private bool SaveDB()
        {
            if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "Msg001", ""))) return false;
            if (cardGrid.RowCount == 0)
            {
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorSelectEmp", ""));
                return false;
            }
            if (cbbWay.SelectedIndex == -1)
            {
                ShowErrorSelectCorrect(label3.Text);
                return false;
            }
            int way = Convert.ToInt32(((TCommonType)cbbWay.Items[cbbWay.SelectedIndex]).id);
            DateTime dFlag = dtpFlag.Value;
            DateTime dt = new DateTime();
            byte retCheck = 0;
            List<string> sql = new List<string>();
            sql.Clear();
            string EmpSysID = "";
            DataTable dtGrid = (DataTable)cardGrid.DataSource;
            double AllowanceAmount = 0;
            string v = "";
            for (int i = 0; i < dtGrid.Rows.Count; i++)
            {
                v = cardGrid[cardGrid.Columns.Count - 1, i].Value.ToString();
                AllowanceAmount = 0;
                if (Pub.IsNumeric(v)) AllowanceAmount = Convert.ToDouble(v);
                if (AllowanceAmount <= 0)
                {
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorMoneyZero", "") + "\r\n\r\n" +
                      dtGrid.Rows[i]["EmpNo"].ToString());
                    return false;
                }
                EmpSysID = dtGrid.Rows[i]["EmpSysID"].ToString();
                retCheck = db.CheckAllowanceFlag(EmpSysID, dFlag, ref dt);
                if (retCheck == 1)
                {
                    Pub.ShowErrorMsg(string.Format(Pub.GetResText(formCode, "Error101", ""), dt.ToShortDateString()));
                    return false;
                }
                else if (retCheck == 2)
                {
                    Pub.ShowErrorMsg(string.Format(Pub.GetResText(formCode, "Error102", ""), dt.ToShortDateString()));
                    return false;
                }
                else if (retCheck == 3)
                {
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error103", ""));
                    return false;
                }
                if (!GetSFAllowance(EmpSysID, dFlag, AllowanceAmount, way, ref sql)) return false;
                progBar.Value = (i + 1) * 100 / (cardGrid.RowCount + 1);
            }
            if (db.ExecSQL(sql) != 0) return false;
            db.WriteSYLog(this.Text, CurrentOprt, sql);
            progBar.Value = 100;
            return true;
        }

        private void cardGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != cardGrid.Columns.Count - 1) return;
            string v = "";
            if (cardGrid[e.ColumnIndex, e.RowIndex].Value != null) v = cardGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
            if (Pub.IsNumeric(v) && (Convert.ToDouble(v) > 0))
            {
                if (Convert.ToDouble(v) * 100 > 0xffffffff)
                    cardGrid[e.ColumnIndex, e.RowIndex].Value = "0.00";
                else
                    cardGrid[e.ColumnIndex, e.RowIndex].Value = Convert.ToDecimal(v).ToString("0.00");
            }
            else
                cardGrid[e.ColumnIndex, e.RowIndex].Value = "0.00";
        }

        private void cardGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void frmSFBatchAllowance_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsWorking) e.Cancel = true;
        }
    }
}