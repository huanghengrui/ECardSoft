using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSFOrderManual : frmBaseDialog
    {
        private DateTime StartDate = new DateTime();
        private List<TCommonType> mealList = new List<TCommonType>();
        private DataTable dtEmp = new DataTable();

        protected override void InitForm()
        {
            formCode = "SFOrderManual";
            base.InitForm();
            this.Text = Title + "[" + CurrentOprt + "]";
            dtpStart.Value = DateTime.Now.Date.AddDays(-6);
            dtpEnd.Value = DateTime.Now.Date;
            DataTableReader dr = null;
            TCommonType cType;
            try
            {
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004005, new string[] { "2" }));
                while (dr.Read())
                {
                    cType = new TCommonType(dr["MealTypeSysID"].ToString(), dr["MealTypeID"].ToString(),
                      dr["MealTypeName"].ToString(), true);
                    mealList.Add(cType);
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

        }

        public frmSFOrderManual(string title, string CurrentTool)
        {
            Title = title;
            CurrentOprt = CurrentTool;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectMeal(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectMeal(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SelectMeal(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SelectMeal(3);
        }

        private void btnQuickSearch_Click(object sender, EventArgs e)
        {
            string OtherCoin = Pub.GetSQL(DBCode.DB_001003, new string[] { "218" });
            if (!Pub.ShowSelectEmpList(btnQuickSearch.Text, OtherCoin, ref dtEmp)) return;
            btnRefresh_Click(null, null);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            StartDate = dtpStart.Value;
            long days = Pub.DateDiff(DateInterval.Day, StartDate, dtpEnd.Value) + 1;
            dataGrid.Rows.Clear();
            dataGrid.Columns.Clear();
            if (days <= 0) return;
            dataGrid.Columns.Add("EmpNo", Pub.GetResText(formCode, "EmpNo", ""));
            dataGrid.Columns.Add("EmpName", Pub.GetResText(formCode, "EmpName", ""));
            dataGrid.Columns.Add("MealType", Pub.GetResText(formCode, "lblMealType", ""));
            for (int i = 0; i < days; i++)
            {
                AddColumn(dataGrid, 1, "DAY" + i.ToString(), false, false, 1, 30);
                dataGrid.Columns[dataGrid.ColumnCount - 1].HeaderText = dtpStart.Value.AddDays(i).Day.ToString();
            }
            AddColumn(dataGrid, 1, "SelectCheck", false, false, 1, 50);
            dataGrid.Columns[dataGrid.ColumnCount - 1].HeaderText = Pub.GetResText(formCode, "SelectCheck", "");
            if (dtEmp.Rows.Count > 0) dataGrid.Rows.Add(dtEmp.Rows.Count * 4);
            for (int i = 0; i < dataGrid.ColumnCount; i++)
            {
                dataGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGrid.Columns[i].ReadOnly = true;
                if (i <= 1)
                    dataGrid.Columns[i].Width = 70;
                else if ((i == 2) || (i == dataGrid.ColumnCount - 1))
                    dataGrid.Columns[i].Width = 50;
                else
                {
                    dataGrid.Columns[i].Width = 30;
                    dataGrid.Columns[i].ReadOnly = false;
                }
            }
            AddColumn(dataGrid, 0, "EmpSysID", true, false, 0, 0);
            AddColumn(dataGrid, 0, "CardSectorNo", true, false, 0, 0);
            AddColumn(dataGrid, 0, "MealTypeID", true, false, 0, 0);
            dataGrid.MergeColumnNames.Add("EmpNo");
            dataGrid.MergeColumnNames.Add("EmpName");
            for (int i = 0; i < dtEmp.Rows.Count; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    dataGrid[dataGrid.ColumnCount - 3, i * 4 + j].Value = dtEmp.Rows[i]["EmpSysID"].ToString();
                    dataGrid[dataGrid.ColumnCount - 2, i * 4 + j].Value = dtEmp.Rows[i]["CardSectorNo"].ToString();
                    dataGrid[dataGrid.ColumnCount - 1, i * 4 + j].Value = j + 1;
                    dataGrid[0, i * 4 + j].Value = dtEmp.Rows[i]["EmpNo"].ToString();
                    dataGrid[1, i * 4 + j].Value = dtEmp.Rows[i]["EmpName"].ToString();
                    if (mealList.Count == 0)
                    {
                        switch (j)
                        {
                            case 0:
                                dataGrid[2, i * 4 + j].Value = button1.Text;
                                break;
                            case 1:
                                dataGrid[2, i * 4 + j].Value = button2.Text;
                                break;
                            case 2:
                                dataGrid[2, i * 4 + j].Value = button3.Text;
                                break;
                            case 3:
                                dataGrid[2, i * 4 + j].Value = button4.Text;
                                break;
                        }
                    }
                    else
                        dataGrid[2, i * 4 + j].Value = mealList[j].name;
                }
            }
        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == dataGrid.ColumnCount - 4)
            {
                bool v = false;
                if (dataGrid[e.ColumnIndex, e.RowIndex].Value == null)
                    v = false;
                else
                    v = Pub.ValueToBool(dataGrid[e.ColumnIndex, e.RowIndex].Value);
                dataGrid[e.ColumnIndex, e.RowIndex].Value = !v;
                for (int i = 3; i < dataGrid.ColumnCount - 4; i++)
                {
                    dataGrid[i, e.RowIndex].Value = dataGrid[e.ColumnIndex, e.RowIndex].EditedFormattedValue;
                }
            }
        }

        private void SelectMeal(int index)
        {
            for (int i = 0; i < dtEmp.Rows.Count; i++)
            {
                for (int j = 3; j < dataGrid.ColumnCount - 4; j++)
                {
                    bool v = false;
                    if (dataGrid[j, i * 4 + index].Value == null)
                        v = false;
                    else
                        v = Pub.ValueToBool(dataGrid[j, i * 4 + index].Value);
                    dataGrid[j, i * 4 + index].Value = !v;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            List<string> sql = new List<string>();
            bool v = false;
            string CardID = "";
            byte MealType = 0;
            for (int i = 0; i < dataGrid.RowCount; i++)
            {
                CardID = dataGrid[dataGrid.ColumnCount - 2, i].Value.ToString();
                byte.TryParse(dataGrid[dataGrid.ColumnCount - 1, i].Value.ToString(), out MealType);
                for (int j = 3; j < dataGrid.ColumnCount - 4; j++)
                {
                    v = false;
                    if (dataGrid[j, i].Value == null)
                        v = false;
                    else
                        v = Pub.ValueToBool(dataGrid[j, i].Value);
                    if (v)
                    {
                        sql.Add(Pub.GetSQL(DBCode.DB_004005, new string[] { "1", CardID,
              StartDate.AddDays(j - 3).ToString(SystemInfo.SQLDateFMT),
              MealType.ToString(), OprtInfo.OprtSysID, "1", "255" }));
                    }
                }
            }
            if (sql.Count > 0)
            {
                if (db.ExecSQL(sql) != 0) return;
                db.WriteSYLog(Title, CurrentOprt, sql);
            }
            Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}