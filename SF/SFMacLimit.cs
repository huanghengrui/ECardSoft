using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSFMacLimit : frmBaseDialog
    {
        private void AddNodes(string mealstr)
        {
            TreeNode node = tvGrid.Nodes.Add(mealstr);
            node.Nodes.Add(Pub.GetResText(formCode, "AboveMoney", ""));
            node.Nodes.Add(Pub.GetResText(formCode, "AboveTimes", ""));
        }

        protected override void InitForm()
        {
            formCode = "SFMacLimit";
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
            tvGrid.Nodes.Add(Pub.GetResText(formCode, "CardType", ""));
            AddNodes(Pub.GetResText(formCode, "Breakfast", ""));
            AddNodes(Pub.GetResText(formCode, "Lunch", ""));
            AddNodes(Pub.GetResText(formCode, "Dinner", ""));
            AddNodes(Pub.GetResText(formCode, "Snack", ""));
            AddNodes(Pub.GetResText(formCode, "EveryDay", ""));
            int MaxColIndex = 9;
            if (SystemInfo.IsMonthLimit)
            {
                MaxColIndex = 11;
                AddNodes(Pub.GetResText(formCode, "EveryMonth", ""));
            }
            for (int i = 1; i <= MaxColIndex; i++)
            {
                switch (i)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 9:
                    case 11:
                        SetColCurrencyFormatByColName(dataGrid, dataGrid.Columns[i].Name);
                        break;
                }
            }
            label1.ForeColor = Color.Blue;
            LoadData();
        }

        public frmSFMacLimit(string title, string CurrentTool, string GUID)
        {
            Title = title;
            CurrentOprt = CurrentTool;
            SysID = GUID;
            InitializeComponent();
        }

        private void LoadData()
        {
            DataTableReader dr = null;
            string limitStr = "";
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004004, new string[] { "7", SysID }));
                if (dr.Read()) limitStr = dr["SFLimitConsumption"].ToString();
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
            SFLimitConsumption limit = new SFLimitConsumption(limitStr);
            rbTime.Checked = limit.LimitType == 1;
            rbDay.Checked = limit.LimitType == 2;
            chkAbove.Checked = limit.AbovePass;
            for (int i = 0; i < dataGrid.RowCount; i++)
            {
                dataGrid[1, i].Value = limit.Money1[i];
                dataGrid[3, i].Value = limit.Money2[i];
                dataGrid[5, i].Value = limit.Money3[i];
                dataGrid[7, i].Value = limit.Money4[i];
                dataGrid[9, i].Value = limit.Money1[i];
                dataGrid[2, i].Value = limit.Ci1[i];
                dataGrid[4, i].Value = limit.Ci2[i];
                dataGrid[6, i].Value = limit.Ci3[i];
                dataGrid[8, i].Value = limit.Ci4[i];
                dataGrid[10, i].Value = limit.Ci1[i];
                if (SystemInfo.IsMonthLimit)
                {
                    dataGrid[11, i].Value = limit.Money5[i];
                    dataGrid[12, i].Value = limit.Ci5[i];
                }
            }
            RadioButton_Click(null, null);
        }

        private void RadioButton_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < dataGrid.ColumnCount; i++)
            {
                if (i <= 8)
                    dataGrid.Columns[i].Visible = rbTime.Checked;
                else
                    dataGrid.Columns[i].Visible = rbDay.Checked;
                dataGrid.Columns[i].ReadOnly = false;
            }
            dataGrid.Columns[11].Visible = SystemInfo.IsMonthLimit;
            dataGrid.Columns[12].Visible = SystemInfo.IsMonthLimit;
        }

        private void dataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string v = "";
            switch (e.ColumnIndex)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 9:
                case 11:
                    if (dataGrid[e.ColumnIndex, e.RowIndex].Value != null) v = dataGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
                    v = CurrencyToStringEx(v);
                    v = Convert.ToDecimal(v) < 0 ? "0" : v;
                    v = CurrencyToString(v);
                    dataGrid[e.ColumnIndex, e.RowIndex].Value = v;
                    break;
                case 2:
                case 4:
                case 6:
                case 8:
                case 10:
                case 12:
                    if (dataGrid[e.ColumnIndex, e.RowIndex].Value != null) v = dataGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
                    v = Pub.IsNumeric(v) ? v : "0";
                    v = Convert.ToInt32(v) < 0 ? "0" : v;
                    dataGrid[e.ColumnIndex, e.RowIndex].Value = v;
                    break;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string limitStr = rbTime.Checked ? "01" : "02";
            limitStr += "@";
            string v = "";
            for (int i = 0; i < dataGrid.RowCount; i++)
            {
                if (rbTime.Checked)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        v = "";
                        if (dataGrid[j * 2 + 1, i].Value != null) v = dataGrid[j * 2 + 1, i].Value.ToString();
                        v = CurrencyToStringEx(v);
                        v = Convert.ToDecimal(v) < 0 ? "0" : v;
                        limitStr += v + "#";
                    }
                    for (int j = 0; j < 4; j++)
                    {
                        v = "";
                        if (dataGrid[j * 2 + 2, i].Value != null) v = dataGrid[j * 2 + 2, i].Value.ToString();
                        v = Pub.IsNumeric(v) ? v : "0";
                        v = Convert.ToInt32(v) < 0 ? "0" : v;
                        limitStr += v + "#";
                    }
                }
                else
                {
                    int j = 4;
                    v = "";
                    if (dataGrid[j * 2 + 1, i].Value != null) v = dataGrid[j * 2 + 1, i].Value.ToString();
                    v = CurrencyToStringEx(v);
                    v = Convert.ToDecimal(v) < 0 ? "0" : v;
                    limitStr += v + "#0#0#0#";
                    v = "";
                    if (dataGrid[j * 2 + 2, i].Value != null) v = dataGrid[j * 2 + 2, i].Value.ToString();
                    v = Pub.IsNumeric(v) ? v : "0";
                    v = Convert.ToInt32(v) < 0 ? "0" : v;
                    limitStr += v + "#0#0#0#";
                }
                if (SystemInfo.IsMonthLimit)
                {
                    v = "";
                    if (dataGrid[11, i].Value != null) v = dataGrid[11, i].Value.ToString();
                    v = CurrencyToStringEx(v);
                    v = Convert.ToDecimal(v) < 0 ? "0" : v;
                    limitStr += v + "#";
                    v = "";
                    if (dataGrid[12, i].Value != null) v = dataGrid[12, i].Value.ToString();
                    v = Pub.IsNumeric(v) ? v : "0";
                    v = Convert.ToInt32(v) < 0 ? "0" : v;
                    limitStr += v + "#";
                }
                limitStr += "@";
            }
            limitStr += Convert.ToByte(chkAbove.Checked).ToString() + "@";
            string sql = Pub.GetSQL(DBCode.DB_004004, new string[] { "107", limitStr, SysID });
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
    }
}