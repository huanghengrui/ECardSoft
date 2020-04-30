using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmRSEmpCardLoss : frmBaseDialog
    {
        private string title = "";
        private string oprt = "";
        public string lossCard = "";
        protected override void InitForm()
        {
            formCode = "RSEmpCardLoss";
            CreateCardGridView(cardGrid);
            base.InitForm();
            lblQuickSearchToolTip.ForeColor = Color.Blue;
            this.Text = title + "[" + oprt + "]";
            HasAbnormal = true;
            if (SysID != "") QuickSearchNormalCardByEmpSysID(SysID, cardGrid, 0);
            btnDelete.Text = Pub.GetResText(formCode, "ItemDelete", "");
            if (!SystemInfo.AllowLossSelect)
            {
                btnQuickSearch.Enabled = false;
                btnQuickSearch.Visible = false;
                lblQuickSearch.Left -= btnDelete.Width;
                txtQuickSearch.Left -= btnDelete.Width;
                lblQuickSearchToolTip.Left -= btnDelete.Width;
                btnDelete.Left = btnClear.Left;
                btnClear.Left = btnQuickSearch.Left;
            }
        }

        public frmRSEmpCardLoss(string Title, string Oprt, string GUID)
        {
            title = Title;
            oprt = Oprt;
            SysID = GUID;
            InitializeComponent();
        }

        private void btnQuickSearch_Click(object sender, EventArgs e)
        {
            QuickSearchNormalCard(btnQuickSearch.Text, cardGrid);
        }

        private void txtQuickSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if ((txtQuickSearch.Text != "") && (e.KeyCode == Keys.Enter))
            {
                QuickSearchNormalCard(txtQuickSearch, e, cardGrid);

                SendKeys.Send("{TAB}");
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cardGrid.DataSource = null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cardGrid.RowCount == 0) return;
            if (cardGrid.SelectedRows.Count == 0) return;
            int idx = cardGrid.SelectedRows[0].Index;
            cardGrid.Rows.RemoveAt(cardGrid.SelectedRows[0].Index);
            if (idx < cardGrid.RowCount)
                cardGrid.Rows[idx].Selected = true;
            else if (cardGrid.RowCount > 0)
                cardGrid.Rows[idx - 1].Selected = true;
           
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string EmpName = "";
            string CardNo = "";
            List<string> cardList = new List<string>();
            if (cardGrid.RowCount == 0)
            {
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorSelectEmp", ""));
                return;
            }

            List<string> sql = new List<string>();
            DataTable dtGrid = (DataTable)cardGrid.DataSource;
            int index = cardGrid.CurrentCell.RowIndex;
            for (int i = 0; i < dtGrid.Rows.Count; i++)
            {
                if (i == index)
                {
                    sql.Add(Pub.GetSQL(DBCode.DB_001003, new string[] { "221", dtGrid.Rows[i]["EmpSysID"].ToString(), OprtInfo.OprtSysID }));
                    cardList.Add(dtGrid.Rows[i]["CardSectorNo"].ToString());
                    CardNo = dtGrid.Rows[i]["CardSectorNo"].ToString();
                    EmpName = dtGrid.Rows[i]["EmpName"].ToString();
                }

            }
            string msg = string.Format(Pub.GetResText(formCode, "MsgCardLossOk", ""), CardNo, EmpName);
            lossCard = CardNo;
            if (Pub.MessageBoxShowQuestion(msg)) return;
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
                return;
            }
            if (db.ExecSQL(sql) != 0) return;
            if (SystemInfo.realBack && SystemInfo.UbackEmp)
            {
                SystemInfo.realHandle = SystemInfo.MainHandle;
                frmSFMacReal.RealBackCard(0, lossCard);
            }

            db.WriteSYLog(title, oprt, sql);
            this.Close();
            this.DialogResult = DialogResult.OK;
            if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "MsgCardLossSuccess", ""))) return;
            frmRSEmpCardBlack frm = new frmRSEmpCardBlack("", Pub.GetResText(formCode, "ItemCardBlack", ""));
            //frmRSEmpDelCardBlack frm = new frmRSEmpDelCardBlack(lossCard, Pub.GetResText(formCode, "ItemCardBlack", ""));
            frm.cardList.Clear();
            for (int i = 0; i < cardList.Count; i++)
            {
                frm.cardList.Add(cardList[i]);
            }
            frm.ShowDialog();
          
        }

        private void cardGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk_Click(null, null);
            }
        }

    }
}