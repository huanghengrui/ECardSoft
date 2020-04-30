using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmMJMacMoreCardEdit : frmBaseDialog
    {
        private const int MaxCard = 50;

        protected override void InitForm()
        {
            formCode = "MJMacMoreCardEdit";
            CreateCardGridView(cardGrid0);
            CreateCardGridView(cardGrid1);
            CreateCardGridView(cardGrid2);
            CreateCardGridView(cardGrid3);
            CreateCardGridView(cardGrid4);
            CreateCardGridView(cardGrid5);
            CreateCardGridView(cardGrid6);
            CreateCardGridView(cardGrid7);
            CreateCardGridView(cardGrid8);
            CreateCardGridView(cardGrid9);
            base.InitForm();
            this.Text = Title + "[" + CurrentOprt + "]";
            dataGrid.Rows.Clear();
            for (int i = 0; i < 10; i++)
            {
                dataGrid.Rows.Add();
                dataGrid[0, i].Value = Pub.GetResText(formCode, "tabPage1" + i.ToString(), "");
                for (int j = 1; j < dataGrid.ColumnCount; j++)
                {
                    dataGrid[j, i].Value = 0;
                }
            }
            LoadData();
            for (int i = 1; i < dataGrid.ColumnCount; i++)
            {
                dataGrid.Columns[i].ReadOnly = false;
            }
        }

        public frmMJMacMoreCardEdit(string title, string CurrentTool, string GUID)
        {
            Title = title;
            CurrentOprt = CurrentTool;
            SysID = GUID;
            InitializeComponent();
        }

        private void LoadData()
        {
            string IsMoreCard = "";
            string MacMoreCard = "";
            DataTableReader dr = null;
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003001, new string[] { "102", SysID }));
                if (dr.Read())
                {
                    IsMoreCard = dr["IsMoreCard"].ToString();
                    MacMoreCard = dr["MacMoreCard"].ToString();
                }
                dr.Close();
                TMacMoreCardNew card = new TMacMoreCardNew(MacMoreCard);
                for (int i = 0; i < 10; i++)
                {
                    if (card.EmpList[i] != "")
                    {
                        string sql = "";
                        if (SystemInfo.HasFaCard)
                            sql = Pub.GetSQL(DBCode.DB_003001, new string[] { "108", card.EmpList[i] });
                        else
                            sql = Pub.GetSQL(DBCode.DB_003001, new string[] { "301", card.EmpList[i] });
                        dr = db.GetDataReader(sql);
                        while (dr.Read())
                        {
                            switch (i)
                            {
                                case 0:
                                    QuickSearchNormalCardByEmpSysID(dr["EmpSysID"].ToString(), cardGrid0, MaxCard);
                                    break;
                                case 1:
                                    QuickSearchNormalCardByEmpSysID(dr["EmpSysID"].ToString(), cardGrid1, MaxCard);
                                    break;
                                case 2:
                                    QuickSearchNormalCardByEmpSysID(dr["EmpSysID"].ToString(), cardGrid2, MaxCard);
                                    break;
                                case 3:
                                    QuickSearchNormalCardByEmpSysID(dr["EmpSysID"].ToString(), cardGrid3, MaxCard);
                                    break;
                                case 4:
                                    QuickSearchNormalCardByEmpSysID(dr["EmpSysID"].ToString(), cardGrid4, MaxCard);
                                    break;
                                case 5:
                                    QuickSearchNormalCardByEmpSysID(dr["EmpSysID"].ToString(), cardGrid5, MaxCard);
                                    break;
                                case 6:
                                    QuickSearchNormalCardByEmpSysID(dr["EmpSysID"].ToString(), cardGrid6, MaxCard);
                                    break;
                                case 7:
                                    QuickSearchNormalCardByEmpSysID(dr["EmpSysID"].ToString(), cardGrid7, MaxCard);
                                    break;
                                case 8:
                                    QuickSearchNormalCardByEmpSysID(dr["EmpSysID"].ToString(), cardGrid8, MaxCard);
                                    break;
                                case 9:
                                    QuickSearchNormalCardByEmpSysID(dr["EmpSysID"].ToString(), cardGrid9, MaxCard);
                                    break;
                            }
                        }
                    }
                    dataGrid[1, i].Value = card.CountList[i];
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
            chkEnabled.Checked = IsMoreCard.ToUpper() == "Y";
            chkEnabled_CheckedChanged(null, null);
        }

        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            tabControl1.Enabled = chkEnabled.Checked;
        }

        private void btnQuickSearch_Click(object sender, EventArgs e)
        {
            switch (tabControl2.SelectedIndex)
            {
                case 0:
                    QuickSearchNormalCard(btnQuickSearch.Text, cardGrid0, MaxCard);
                    break;
                case 1:
                    QuickSearchNormalCard(btnQuickSearch.Text, cardGrid1, MaxCard);
                    break;
                case 2:
                    QuickSearchNormalCard(btnQuickSearch.Text, cardGrid2, MaxCard);
                    break;
                case 3:
                    QuickSearchNormalCard(btnQuickSearch.Text, cardGrid3, MaxCard);
                    break;
                case 4:
                    QuickSearchNormalCard(btnQuickSearch.Text, cardGrid4, MaxCard);
                    break;
                case 5:
                    QuickSearchNormalCard(btnQuickSearch.Text, cardGrid5, MaxCard);
                    break;
                case 6:
                    QuickSearchNormalCard(btnQuickSearch.Text, cardGrid6, MaxCard);
                    break;
                case 7:
                    QuickSearchNormalCard(btnQuickSearch.Text, cardGrid7, MaxCard);
                    break;
                case 8:
                    QuickSearchNormalCard(btnQuickSearch.Text, cardGrid8, MaxCard);
                    break;
                case 9:
                    QuickSearchNormalCard(btnQuickSearch.Text, cardGrid9, MaxCard);
                    break;
            }
        }

        private void txtQuickSearch_KeyDown(object sender, KeyEventArgs e)
        {
            switch (tabControl2.SelectedIndex)
            {
                case 0:
                    QuickSearchNormalCard(txtQuickSearch, e, cardGrid0, MaxCard);
                    break;
                case 1:
                    QuickSearchNormalCard(txtQuickSearch, e, cardGrid1, MaxCard);
                    break;
                case 2:
                    QuickSearchNormalCard(txtQuickSearch, e, cardGrid2, MaxCard);
                    break;
                case 3:
                    QuickSearchNormalCard(txtQuickSearch, e, cardGrid3, MaxCard);
                    break;
                case 4:
                    QuickSearchNormalCard(txtQuickSearch, e, cardGrid4, MaxCard);
                    break;
                case 5:
                    QuickSearchNormalCard(txtQuickSearch, e, cardGrid5, MaxCard);
                    break;
                case 6:
                    QuickSearchNormalCard(txtQuickSearch, e, cardGrid6, MaxCard);
                    break;
                case 7:
                    QuickSearchNormalCard(txtQuickSearch, e, cardGrid7, MaxCard);
                    break;
                case 8:
                    QuickSearchNormalCard(txtQuickSearch, e, cardGrid8, MaxCard);
                    break;
                case 9:
                    QuickSearchNormalCard(txtQuickSearch, e, cardGrid9, MaxCard);
                    break;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string IsMoreCard = "N";
            string MacMoreCard0 = "";
            string MacMoreCard1 = "";
            string MacMoreCard2 = "";
            string MacMoreCard3 = "";
            string MacMoreCard4 = "";
            string MacMoreCard5 = "";
            string MacMoreCard6 = "";
            string MacMoreCard7 = "";
            string MacMoreCard8 = "";
            string MacMoreCard9 = "";
            string MacCountCard = "";
            string MacMoreCard = "";
            if (chkEnabled.Checked)
            {
                IsMoreCard = "Y";
                DataTable dtGrid = (DataTable)cardGrid0.DataSource;
                if (dtGrid != null)
                {
                    for (int i = 0; i < dtGrid.Rows.Count; i++)
                    {
                        MacMoreCard0 += dtGrid.Rows[i]["EmpSysID"].ToString() + "#";
                    }
                }
                dtGrid = (DataTable)cardGrid1.DataSource;
                if (dtGrid != null)
                {
                    for (int i = 0; i < dtGrid.Rows.Count; i++)
                    {
                        MacMoreCard1 += dtGrid.Rows[i]["EmpSysID"].ToString() + "#";
                    }
                }
                dtGrid = (DataTable)cardGrid2.DataSource;
                if(dtGrid != null)
                {
                    for (int i = 0; i < dtGrid.Rows.Count; i++)
                    {
                        MacMoreCard2 += dtGrid.Rows[i]["EmpSysID"].ToString() + "#";
                    }
                }
                
                dtGrid = (DataTable)cardGrid3.DataSource;
                if (dtGrid != null)
                {
                    for (int i = 0; i < dtGrid.Rows.Count; i++)
                    {
                        MacMoreCard3 += dtGrid.Rows[i]["EmpSysID"].ToString() + "#";
                    }
                }
                dtGrid = (DataTable)cardGrid4.DataSource;
                if (dtGrid != null)
                {
                    for (int i = 0; i < dtGrid.Rows.Count; i++)
                    {
                        MacMoreCard4 += dtGrid.Rows[i]["EmpSysID"].ToString() + "#";
                    }
                }
                dtGrid = (DataTable)cardGrid5.DataSource;
                if (dtGrid != null)
                {
                    for (int i = 0; i < dtGrid.Rows.Count; i++)
                    {
                        MacMoreCard5 += dtGrid.Rows[i]["EmpSysID"].ToString() + "#";
                    }
                }
                dtGrid = (DataTable)cardGrid6.DataSource;
                if (dtGrid != null)
                {
                    for (int i = 0; i < dtGrid.Rows.Count; i++)
                    {
                        MacMoreCard6 += dtGrid.Rows[i]["EmpSysID"].ToString() + "#";
                    }
                }
                dtGrid = (DataTable)cardGrid7.DataSource;
                if (dtGrid != null)
                {
                    for (int i = 0; i < dtGrid.Rows.Count; i++)
                    {
                        MacMoreCard7 += dtGrid.Rows[i]["EmpSysID"].ToString() + "#";
                    }
                }
                dtGrid = (DataTable)cardGrid8.DataSource;
                if (dtGrid != null)
                {
                    for (int i = 0; i < dtGrid.Rows.Count; i++)
                    {
                        MacMoreCard8 += dtGrid.Rows[i]["EmpSysID"].ToString() + "#";
                    }
                }
                dtGrid = (DataTable)cardGrid9.DataSource;
                if (dtGrid != null)
                {
                    for (int i = 0; i < dtGrid.Rows.Count; i++)
                    {
                        MacMoreCard9 += dtGrid.Rows[i]["EmpSysID"].ToString() + "#";
                    }
                }
                for (int i = 0; i < 10; i++)
                {
                    MacCountCard += dataGrid[1, i].Value.ToString() + "@";
                }
                MacCountCard = MacCountCard.Substring(0, MacCountCard.Length - 1);
                MacMoreCard = MacMoreCard0 + "@" + MacMoreCard1 + "@" + MacMoreCard2 + "@" + MacMoreCard3 + "@" + MacMoreCard4 + "@" +
                  MacMoreCard5 + "@" + MacMoreCard6 + "@" + MacMoreCard7 + "@" + MacMoreCard8 + "@" + MacMoreCard9 + "@" + MacCountCard;
            }
            string sql = "";
            try
            {
                sql = Pub.GetSQL(DBCode.DB_003001, new string[] { "107", IsMoreCard, MacMoreCard, SysID });
                db.ExecSQL(sql);
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E, sql);
                return;
            }
            db.WriteSYLog(this.Text, CurrentOprt, sql);
            Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            switch (tabControl2.SelectedIndex)
            {
                case 0:
                    cardGrid0.DataSource = null;
                    break;
                case 1:
                    cardGrid1.DataSource = null;
                    break;
                case 2:
                    cardGrid2.DataSource = null;
                    break;
                case 3:
                    cardGrid3.DataSource = null;
                    break;
                case 4:
                    cardGrid4.DataSource = null;
                    break;
                case 5:
                    cardGrid5.DataSource = null;
                    break;
                case 6:
                    cardGrid6.DataSource = null;
                    break;
                case 7:
                    cardGrid7.DataSource = null;
                    break;
                case 8:
                    cardGrid8.DataSource = null;
                    break;
                case 9:
                    cardGrid9.DataSource = null;
                    break;
            }
        }

        private void dataGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 1:
                    string v = "";
                    if (dataGrid[e.ColumnIndex, e.RowIndex].Value != null) v = dataGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
                    int i = 0;
                    int.TryParse(v, out i);
                    if ((i <= 0) || (i > MaxCard))
                        dataGrid[e.ColumnIndex, e.RowIndex].Value = 0;
                    else
                        dataGrid[e.ColumnIndex, e.RowIndex].Value = i;
                    break;
            }
        }
    }
}