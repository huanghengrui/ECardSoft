using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSFMacWay : frmBaseDialog
    {
        private List<TCommonType> sfTypeList = new List<TCommonType>();

        private void AddNodes(TreeNode node, string timestr)
        {
            TreeNode nod = node.Nodes.Add(timestr);
            nod.Nodes.Add(Pub.GetResText(formCode, "Enabled", ""));
            nod.Nodes.Add(Pub.GetResText(formCode, "SFType", ""));
            nod.Nodes.Add(Pub.GetResText(formCode, "AboveMoney", ""));
        }

        private void AddNodes(string mealstr)
        {
            TreeNode node = tvGrid.Nodes.Add(mealstr);
            AddNodes(node, Pub.GetResText(formCode, "TimesOne", ""));
            AddNodes(node, Pub.GetResText(formCode, "TimesTwo", ""));
        }

        protected override void InitForm()
        {
            formCode = "SFMacWay";
            base.InitForm();
            this.Text = Title + "[" + CurrentOprt + "]";
            GetCardTypeList();
            dataGrid.Rows.Clear();
            for (int i = 0; i < cardTypeList.Count; i++)
            {
                dataGrid.Rows.Add();
                dataGrid[0, i].Value = cardTypeList[i];
            }
            tvGrid.Nodes.Clear();
            TreeNode node = tvGrid.Nodes.Add(Pub.GetResText(formCode, "CardType", ""));
            AddNodes(Pub.GetResText(formCode, "Breakfast", ""));
            AddNodes(Pub.GetResText(formCode, "Lunch", ""));
            AddNodes(Pub.GetResText(formCode, "Dinner", ""));
            AddNodes(Pub.GetResText(formCode, "Snack", ""));
            AddNodes(Pub.GetResText(formCode, "EveryDay", ""));
            for (int i = 3; i < dataGrid.ColumnCount; i++)
            {
                switch (i)
                {
                    case 3:
                    case 6:
                    case 9:
                    case 12:
                    case 15:
                    case 18:
                    case 21:
                    case 24:
                    case 27:
                    case 30:
                        SetColCurrencyFormatByColName(dataGrid, dataGrid.Columns[i].Name);
                        break;
                }
            }
            label1.ForeColor = Color.Blue;
            LoadData();
        }

        public frmSFMacWay(string title, string CurrentTool, string GUID)
        {
            Title = title;
            CurrentOprt = CurrentTool;
            SysID = GUID;
            InitializeComponent();
        }

        private void LoadData()
        {
            DataTableReader dr = null;
            string consStr = "";
            for (int i = 1; i < dataGrid.ColumnCount; i++)
            {
                switch (i)
                {
                    case 1:
                    case 4:
                    case 7:
                    case 10:
                    case 13:
                    case 16:
                    case 19:
                    case 22:
                    case 25:
                    case 28:
                        ((DataGridViewComboBoxColumn)dataGrid.Columns[i]).Items.Clear();
                        ((DataGridViewComboBoxColumn)dataGrid.Columns[i]).Items.Add("");
                        ((DataGridViewComboBoxColumn)dataGrid.Columns[i]).Items.Add("Y");
                        ((DataGridViewComboBoxColumn)dataGrid.Columns[i]).Items.Add("N");
                        break;
                    case 2:
                    case 5:
                    case 8:
                    case 11:
                    case 14:
                    case 17:
                    case 20:
                    case 23:
                    case 26:
                    case 29:
                        ((DataGridViewComboBoxColumn)dataGrid.Columns[i]).Items.Clear();
                        ((DataGridViewComboBoxColumn)dataGrid.Columns[i]).Items.Add("");
                        break;
                }
            }
            sfTypeList.Clear();
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004004, new string[] { "108" }));
                while (dr.Read())
                {
                    sfTypeList.Add(new TCommonType(dr["SFTypeSysID"].ToString(), dr["SFTypeID"].ToString(),
                      dr["SFTypeName"].ToString(), true));
                    for (int i = 2; i < dataGrid.ColumnCount; i++)
                    {
                        switch (i)
                        {
                            case 2:
                            case 5:
                            case 8:
                            case 11:
                            case 14:
                            case 17:
                            case 20:
                            case 23:
                            case 26:
                            case 29:
                                ((DataGridViewComboBoxColumn)dataGrid.Columns[i]).Items.Add(dr["SFTypeName"].ToString());
                                break;
                        }
                    }
                }
                dr.Close();
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004004, new string[] { "7", SysID }));
                if (dr.Read()) consStr = dr["ConsumptionWay"].ToString();
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
            SFConsumptionWay way = new SFConsumptionWay(consStr);
            rbTime.Checked = way.Way == 1;
            rbDay.Checked = way.Way == 2;
            chkAlarm.Checked = way.TwoBJ == 1;
            string v = "";
            for (int i = 0; i < dataGrid.RowCount; i++)
            {
                string[] tmp = way.CardTypeTime[i].Split(' ');
                int i1 = 0;
                int i2 = 24;
                if (rbDay.Checked)
                {
                    i1 = 24;
                    i2 = 30;
                }
                for (int j = i1; j < i2; j++)
                {
                    if (rbDay.Checked)
                        dataGrid[j + 1, i].Value = tmp[j - i1] == "*" ? "" : tmp[j - i1];
                    else
                        dataGrid[j + 1, i].Value = tmp[j] == "*" ? "" : tmp[j];
                    switch (j + 1)
                    {
                        case 1:
                        case 4:
                        case 7:
                        case 10:
                        case 13:
                        case 16:
                        case 19:
                        case 22:
                        case 25:
                        case 28:
                            if (rbTime.Checked) dataGrid.Columns[j + 1].Width = 40;
                            if (rbDay.Checked)
                                v = tmp[j - i1] == "*" ? "" : tmp[j - i1];
                            else
                                v = tmp[j] == "*" ? "" : tmp[j];
                            dataGrid[j + 1, i].Value = v.ToUpper();
                            break;
                        case 3:
                        case 6:
                        case 9:
                        case 12:
                        case 15:
                        case 18:
                        case 21:
                        case 24:
                        case 27:
                        case 30:
                            if (rbTime.Checked) dataGrid.Columns[j + 1].Width = 60;
                            if (dataGrid[j + 1, i].Value.ToString() != "")
                            {
                                v = CurrencyToStringEx(dataGrid[j + 1, i].Value.ToString());
                                v = Convert.ToDecimal(v) <= 0 ? "1" : v;
                                dataGrid[j + 1, i].Value = CurrencyToString(v);
                            }
                            break;
                        default:
                            if (rbTime.Checked) dataGrid.Columns[j + 1].Width = 70;
                            if (dataGrid[j + 1, i].Value.ToString() != "")
                            {
                                dataGrid[j + 1, i].Value = GetSFTypeName(dataGrid[j + 1, i].Value.ToString());
                            }
                            break;
                    }
                }
            }
            RadioButton_Click(null, null);
        }

        private void RadioButton_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < dataGrid.ColumnCount; i++)
            {
                if (i <= 24)
                    dataGrid.Columns[i].Visible = rbTime.Checked;
                else
                    dataGrid.Columns[i].Visible = rbDay.Checked;
                dataGrid.Columns[i].ReadOnly = false;
            }
            if (rbDay.Checked)
            {
                tvGrid.Nodes[5].Text = Pub.GetResText(formCode, "EveryDay", "");
                tvGrid.Refresh();
                dataGrid.Refresh();
            }
        }

        private void dataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string v = "";
            switch (e.ColumnIndex)
            {
                case 1:
                case 4:
                case 7:
                case 10:
                case 13:
                case 16:
                case 19:
                case 22:
                case 25:
                case 28:
                    bool ret = false;
                    if (dataGrid[e.ColumnIndex, e.RowIndex].Value != null)
                    {
                        bool.TryParse(dataGrid[e.ColumnIndex, e.RowIndex].Value.ToString(), out ret);
                    }
                    if (ret)
                    {
                        if (dataGrid[e.ColumnIndex + 1, e.RowIndex].Value.ToString() == "")
                        {
                            dataGrid[e.ColumnIndex + 1, e.RowIndex].Value = sfTypeList[0].name;
                        }
                        v = CurrencyToStringEx(dataGrid[e.ColumnIndex + 2, e.RowIndex].Value.ToString());
                        if (Convert.ToDecimal(v) <= 0)
                        {
                            dataGrid[e.ColumnIndex + 2, e.RowIndex].Value = CurrencyToString("1");
                        }
                    }
                    break;
                case 3:
                case 6:
                case 9:
                case 12:
                case 15:
                case 18:
                case 21:
                case 24:
                case 27:
                case 30:
                    if (dataGrid[e.ColumnIndex, e.RowIndex].Value != null) v = dataGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
                    v = CurrencyToStringEx(v);
                    v = Convert.ToDecimal(v) <= 0 ? "1" : v;
                    v = CurrencyToString(v);
                    dataGrid[e.ColumnIndex, e.RowIndex].Value = v;
                    break;
            }
        }

        private string GetSFTypeID(string value)
        {
            string ret = "";
            for (int i = 0; i < sfTypeList.Count; i++)
            {
                if (sfTypeList[i].name == value)
                {
                    ret = sfTypeList[i].id;
                    break;
                }
            }
            return ret;
        }

        private string GetSFTypeName(string value)
        {
            string ret = null;
            for (int i = 0; i < sfTypeList.Count; i++)
            {
                if (sfTypeList[i].id == value)
                {
                    ret = sfTypeList[i].name;
                    break;
                }
            }
            return ret;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string consStr = rbTime.Checked ? "01" : "02";
            consStr += "@" + Convert.ToByte(chkAlarm.Checked).ToString() + "@";
            string v = "";
            string v1 = "";
            string v2 = "";
            bool ret = false;
            string msg = Pub.GetResText(formCode, "ErrorMoneyZero", "");
            string msg1 = Pub.GetResText(formCode, "Error001", "");
            for (int i = 0; i < dataGrid.RowCount; i++)
            {
                int i1 = 0;
                int i2 = 8;
                if (rbDay.Checked)
                {
                    i1 = 8;
                    i2 = 10;
                }
                for (int j = i1; j < i2; j++)
                {
                    v = "";
                    if (dataGrid[j * 3 + 1, i].Value != null) v = dataGrid[j * 3 + 1, i].Value.ToString().ToUpper();
                    if (v == "") v = "*";
                    v1 = "*";
                    v2 = "*";
                    ret = v == "Y";
                    if (ret)
                    {
                        v1 = "";
                        if (dataGrid[j * 3 + 2, i].Value != null) v1 = dataGrid[j * 3 + 2, i].Value.ToString();
                        if (v1 == "")
                        {
                            Pub.ShowErrorMsg(msg1);
                            return;
                        }
                        v1 = GetSFTypeID(dataGrid[j * 3 + 2, i].Value.ToString());
                        v2 = "0";
                        if (dataGrid[j * 3 + 3, i].Value != null)
                        {
                            v2 = dataGrid[j * 3 + 3, i].Value.ToString();
                            v2 = CurrencyToStringEx(v2);
                        }
                        if (Convert.ToDecimal(v2) <= 0)
                        {
                            Pub.ShowErrorMsg(msg);
                            return;
                        }
                    }
                    consStr += v + " " + v1 + " " + v2 + " ";
                }
                consStr += "@";
            }
            consStr = consStr.Substring(0, consStr.Length - 1);
            string sql = Pub.GetSQL(DBCode.DB_004004, new string[] { "109", consStr, SysID });
            try
            {
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

        private void dataGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void GridMenu_Opening(object sender, CancelEventArgs e)
        {
            ItemPasteUpData.Enabled = dataGrid.CurrentRow.Index > 0;
        }

        private void ItemPasteUpData_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < dataGrid.ColumnCount; i++)
            {
                dataGrid.CurrentRow.Cells[i].Value = dataGrid[i, dataGrid.CurrentRow.Index - 1].Value;
            }
        }

        private void ItemEmptyData_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < dataGrid.ColumnCount; i++)
            {
                dataGrid.CurrentRow.Cells[i].Value = "";
            }
        }
    }
}