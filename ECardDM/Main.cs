using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmMain : frmBaseForm
    {
        private bool IsCheck = false;
        private bool IsWorking = false;
        private bool IsInitDataGrid = true;

        protected override void InitForm()
        {
            formCode = "DMMain";
            base.InitForm();
            prodGrid.Columns[7].HeaderText = prodGrid.Columns[0].HeaderText;
            prodGrid.Columns[8].HeaderText = prodGrid.Columns[1].HeaderText;
            prodGrid.Columns[9].HeaderText = prodGrid.Columns[2].HeaderText;
            prodGrid.Columns[10].HeaderText = prodGrid.Columns[3].HeaderText;
            prodGrid.Columns[11].HeaderText = prodGrid.Columns[4].HeaderText;
            prodGrid.Columns[12].HeaderText = prodGrid.Columns[5].HeaderText;
            prodGrid.Columns[13].HeaderText = prodGrid.Columns[6].HeaderText;
            Pub.SetFormAppIcon(this);
            this.Text = SystemInfo.AppTitle + " - " + this.Text;
            findGrid.AutoGenerateColumns = false;
            alGrid.AutoGenerateColumns = false;
            dataGrid.AutoGenerateColumns = false;
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                string sql = "";
                switch (SystemInfo.DBType)
                {
                    case 1:
                    case 2:
                        sql = "SELECT * FROM VSF_MealType ORDER BY MealTypeID";
                        break;
                }
                DataTable dt = db.GetDataTable(sql);
                cbbMealType.Items.Clear();
                TCommonType ctype = new TCommonType("", "", "");
                cbbMealType.Items.Add(ctype);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ctype = new TCommonType(dt.Rows[i]["MealTypeSysID"].ToString(), dt.Rows[i]["MealTypeID"].ToString(),
                      dt.Rows[i]["MealTypeName"].ToString());
                    cbbMealType.Items.Add(ctype);
                }
                switch (SystemInfo.DBType)
                {
                    case 1:
                    case 2:
                        sql = "SELECT GUID,MacOpterID,MacOpterName FROM SF_MacOpter ORDER BY MacOpterID";
                        break;
                }
                dt = db.GetDataTable(sql);
                cbbOprtNo.Items.Clear();
                ctype = new TCommonType("", "", "");
                cbbOprtNo.Items.Add(ctype);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ctype = new TCommonType(dt.Rows[i]["GUID"].ToString(), dt.Rows[i]["MacOpterID"].ToString(),
                      dt.Rows[i]["MacOpterName"].ToString());
                    cbbOprtNo.Items.Add(ctype);
                }
                switch (SystemInfo.DBType)
                {
                    case 1:
                    case 2:
                        sql = "SELECT MacSysID,MacSN FROM VSF_MacInfo ORDER BY MacSN";
                        break;
                }
                dt = db.GetDataTable(sql);
                cbbMacSN.Items.Clear();
                ctype = new TCommonType("", "", "", true);
                cbbMacSN.Items.Add(ctype);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ctype = new TCommonType(dt.Rows[i]["MacSysID"].ToString(), dt.Rows[i]["MacSN"].ToString(),
                      dt.Rows[i]["MacSN"].ToString(), true);
                    cbbMacSN.Items.Add(ctype);
                }
                ctype = new TCommonType("255", "255", "255", true);
                cbbMacSN.Items.Add(ctype);
                switch (SystemInfo.DBType)
                {
                    case 1:
                    case 2:
                        sql = "SELECT * FROM VSF_SFType ORDER BY SFTypeID";
                        break;
                }
                dt = db.GetDataTable(sql);
                cbbSFType.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ctype = new TCommonType(dt.Rows[i]["SFTypeSysID"].ToString(), dt.Rows[i]["SFTypeID"].ToString(),
                      dt.Rows[i]["SFTypeName"].ToString());
                    cbbSFType.Items.Add(ctype);
                }
                switch (SystemInfo.DBType)
                {
                    case 1:
                    case 2:
                        sql = "SELECT ProductsID,ProductsName,ProductsPrice,CategoryID,CategoryName FROM SF_MacProducts ORDER BY ProductsID";
                        break;
                }
                dt = db.GetDataTable(sql);
                DataTable dtProd = new DataTable();
                dtProd.Columns.Add("SelectCheck", typeof(bool));
                dtProd.Columns.Add("CategoryID", typeof(int));
                dtProd.Columns.Add("CategoryName", typeof(string));
                dtProd.Columns.Add("ProductsID", typeof(int));
                dtProd.Columns.Add("ProductsName", typeof(string));
                dtProd.Columns.Add("ProductsPrice", typeof(double));
                if (SystemInfo.IsDecimalProduct)
                    dtProd.Columns.Add("ProductNum", typeof(double));
                else
                    dtProd.Columns.Add("ProductNum", typeof(int));
                dtProd.Columns.Add("SelectCheck1", typeof(bool));
                dtProd.Columns.Add("CategoryID1", typeof(int));
                dtProd.Columns.Add("CategoryName1", typeof(string));
                dtProd.Columns.Add("ProductsID1", typeof(int));
                dtProd.Columns.Add("ProductsName1", typeof(string));
                dtProd.Columns.Add("ProductsPrice1", typeof(double));
                if (SystemInfo.IsDecimalProduct)
                    dtProd.Columns.Add("ProductNum1", typeof(double));
                else
                    dtProd.Columns.Add("ProductNum1", typeof(int));
                object[] values = new object[14];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        values[0] = false;
                        values[1] = dt.Rows[i]["CategoryID"];
                        values[2] = dt.Rows[i]["CategoryName"];
                        values[3] = dt.Rows[i]["ProductsID"];
                        values[4] = dt.Rows[i]["ProductsName"];
                        values[5] = dt.Rows[i]["ProductsPrice"];
                        values[6] = 0;
                        if (i == dt.Rows.Count - 1)
                        {
                            values[7] = null;
                            values[8] = null;
                            values[9] = null;
                            values[10] = null;
                            values[11] = null;
                            values[12] = null;
                            values[13] = null;
                            dtProd.Rows.Add(values);
                        }
                    }
                    else
                    {
                        values[7] = false;
                        values[8] = dt.Rows[i]["CategoryID"];
                        values[9] = dt.Rows[i]["CategoryName"];
                        values[10] = dt.Rows[i]["ProductsID"];
                        values[11] = dt.Rows[i]["ProductsName"];
                        values[12] = dt.Rows[i]["ProductsPrice"];
                        values[13] = 0;
                        dtProd.Rows.Add(values);
                    }
                }
                prodGrid.DataSource = dtProd;
                bool ret = false;
                if(dtProd.Rows.Count>0)
                for (int i = 0; i < dtProd.Rows.Count; i++)
                {
                    ret = false;
                    string id = dt.Rows[i]["CategoryID"].ToString();
                    if (txtCategoryID.Items.Count > 0)
                    for (int j = 0; j < txtCategoryID.Items.Count; j++)
                    {
                        if (txtCategoryID.Items[j].ToString() == id)
                        {
                            ret = true;
                            break;    
                        }
                    }
                        if (ret)
                            continue;
                    txtCategoryID.Items.Add(id);
                }
                if(txtCategoryID.Items.Count>0)
                txtCategoryID.SelectedIndex = 0;
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            RefreshForm();
            if (cbbMealType.Items.Count > 0) cbbMealType.SelectedIndex = 0;
            if (cbbOprtNo.Items.Count > 0) cbbOprtNo.SelectedIndex = 0;
            if (cbbMacSN.Items.Count > 0) cbbMacSN.SelectedIndex = 0;
            if (cbbSFType.Items.Count > 0) cbbSFType.SelectedIndex = 0;
            prodGrid.ReadOnly = true;
            if (prodGrid.RowCount > 0)
            {
                prodGrid.ReadOnly = false;
                for (int i = 0; i < prodGrid.ColumnCount; i++)
                {
                    prodGrid.Columns[i].ReadOnly = true;
                }
                prodGrid.Columns[0].ReadOnly = false;
                prodGrid.Columns[6].ReadOnly = false;
                prodGrid.Columns[7].ReadOnly = false;
                prodGrid.Columns[13].ReadOnly = false;
            }
            alGrid.Columns[5].HeaderText = Pub.GetResText(formCode, "SFBTAmount", "");
            alGrid.Columns[6].HeaderText = Pub.GetResText(formCode, "SFBTCardBalance", "");
            findGrid.Columns[4].HeaderText = Pub.GetResText(formCode, "CardDifference", "");
            formCode = "DMMain";
           
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsWorking)
            {
                IsWorking = false;
                e.Cancel = true;
            }
        }

        private void findGrid_Click(object sender, EventArgs e)
        {
            lblRecInfoA.Text = "";
            lblRecInfoB.Text = "";
            RefreshForm();
            if (findGrid.SelectedRows.Count == 0) return;
            int RowIndex = findGrid.SelectedRows[0].Index;
            if (findGrid[0, RowIndex].Value == null) return;
            IsInitDataGrid = true;
            string EmpSysID = findGrid[0, RowIndex].Value.ToString();
            DataTable dt = null;
            try
            {
                switch (SystemInfo.DBType)
                {
                    case 1:
                    case 2:
                        alGrid.DataSource = GetLoseRecord(EmpSysID);
                        dt = db.GetDataTable("SELECT * FROM VSF_SFData WHERE EmpSysID='" + EmpSysID +
                          "' AND SFTypeID<>2 AND SFTypeID<>40 AND SFTypeID<>50 AND IsAlarm=0 ORDER BY CardUseTimes");
                        break;
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }

            dataGrid.DataSource = dt;
            RefreshForm();
            dataGrid.ReadOnly = true;
            if (dataGrid.RowCount > 0)
            {
                dataGrid.ReadOnly = false;
                for (int i = 0; i < dataGrid.ColumnCount; i++)
                {
                    dataGrid.Columns[i].ReadOnly = i <= 2;
                }
                int T1 = 0, T2 = 0;
                double SFAmount = 0, SFCardBalance = 0, CardBalance = 0;
                double BTAmount = 0, BTBalance = 0, CardBTMoney = 0;
                int row = 1;
                int.TryParse(dt.Rows[row - 1]["CardUseTimes"].ToString(), out T1);
                double.TryParse(dt.Rows[row - 1]["SFCardBalance"].ToString(), out SFCardBalance);
                double.TryParse(dt.Rows[row - 1]["BTBalance"].ToString(), out BTBalance);
                T2 = T1;
                while (row < dataGrid.RowCount)
                {
                    T1 = 0;
                    int.TryParse(dt.Rows[row]["CardUseTimes"].ToString(), out T1);
                    SFAmount = 0;
                    double.TryParse(dt.Rows[row]["SFAmount"].ToString(), out SFAmount);
                    CardBalance = 0;
                    double.TryParse(dt.Rows[row]["SFCardBalance"].ToString(), out CardBalance);
                    BTAmount = 0;
                    double.TryParse(dt.Rows[row]["BTAmount"].ToString(), out BTAmount);
                    CardBTMoney = 0;
                    double.TryParse(dt.Rows[row]["BTBalance"].ToString(), out CardBTMoney);
                    if (T2 + 1 == T1)
                    {
                        if (Math.Round(SFCardBalance + SFAmount + BTBalance + BTAmount, 2) != Math.Round(CardBalance + CardBTMoney, 2))
                        {
                            for (int j = 0; j < dataGrid.ColumnCount; j++)
                            {
                                dataGrid.Rows[row].Cells[j].Style.ForeColor = Color.Red;
                            }
                        }
                    }
                    if ((T2 + 1 != T1))
                    {
                        if (Math.Round(SFCardBalance + SFAmount + BTBalance + BTAmount, 2) != Math.Round(CardBalance + CardBTMoney, 2))
                        {
                            for (int j = 0; j < dataGrid.ColumnCount; j++)
                            {
                                dataGrid.Rows[row].Cells[j].Style.ForeColor = Color.Blue;
                            }
                        }
                    }
                    T2 = T1;
                    SFCardBalance = CardBalance;
                    BTBalance = CardBTMoney;
                    row++;
                }
            }
            IsInitDataGrid = false;
            formCode = "DMMain";
        }

        private void findGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void alGrid_Click(object sender, EventArgs e)
        {
            string MealStr = "";
            DateTime dateTime = new DateTime();
            DateTime BeginTime1 = new DateTime();
            DateTime BeginTime2 = new DateTime();
            DateTime BeginTime3 = new DateTime();
            DateTime BeginTime4 = new DateTime();
            DateTime EndTime1 = new DateTime();
            DateTime EndTime2 = new DateTime();
            DateTime EndTime3 = new DateTime();
            DateTime EndTime4 = new DateTime();
           
            if ((cbbSFType.SelectedIndex == -1) && (cbbSFType.Items.Count > 0)) cbbSFType.SelectedIndex = 7;
            if (alGrid.SelectedRows.Count == 0) return;
            int RowIndex = alGrid.SelectedRows[0].Index;
            if (alGrid[9, RowIndex].Value == null)
                txtSFDate.Text = DateTime.Now.ToString();
            else
                txtSFDate.Text = alGrid[9, RowIndex].Value.ToString();

            if (txtSFDate.Text != "")
            {
                dateTime = Convert.ToDateTime(txtSFDate.Text.Trim());
            }

            if (alGrid[10, RowIndex].Value != null)
            {
                for (int i = 0; i < cbbMealType.Items.Count; i++)
                {
                    if (((TCommonType)cbbMealType.Items[i]).id == alGrid[10, RowIndex].Value.ToString())
                    {
                        cbbMealType.SelectedIndex = i;
                        break;
                    }
                }
            }
            if (alGrid[11, RowIndex].Value != null)
            {
                string MacSN = alGrid[11, RowIndex].Value.ToString();

                for (int i = 0; i < cbbMacSN.Items.Count; i++)
                {
                    if (((TCommonType)cbbMacSN.Items[i]).id == MacSN)
                    {
                        cbbMacSN.SelectedIndex = i;
                        break;
                    }
                }
                DataTableReader dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004004, new string[] { "8", MacSN }));
                if (dr.Read())
                {
                    MealStr = dr["MealInfo"].ToString();
                }
            }

            SFMealInfo meal = new SFMealInfo(MealStr);
            BeginTime1 = Convert.ToDateTime(meal.BeginTime[0]);
            BeginTime2 = Convert.ToDateTime(meal.BeginTime[1]);
            BeginTime3 = Convert.ToDateTime(meal.BeginTime[2]);
            BeginTime4 = Convert.ToDateTime(meal.BeginTime[3]);
            EndTime1 = Convert.ToDateTime(meal.EndTime[0]);
            EndTime2 = Convert.ToDateTime(meal.EndTime[1]);
            EndTime3 = Convert.ToDateTime(meal.EndTime[2]);
            EndTime4 = Convert.ToDateTime(meal.EndTime[3]);

            if(dateTime.Hour*60+dateTime.Minute >=BeginTime1.Hour * 60 + BeginTime1.Minute && dateTime.Hour * 60 + dateTime.Minute < EndTime1.Hour * 60 + EndTime1.Minute)
            {
                cbbMealType.SelectedIndex = 1;
            }
            else if(dateTime.Hour * 60 + dateTime.Minute >= BeginTime2.Hour * 60 + BeginTime2.Minute && dateTime.Hour * 60 + dateTime.Minute < EndTime2.Hour * 60 + EndTime2.Minute)
            {
                cbbMealType.SelectedIndex = 2;
            }else if (dateTime.Hour * 60 + dateTime.Minute >= BeginTime3.Hour * 60 + BeginTime3.Minute && dateTime.Hour * 60 + dateTime.Minute < EndTime3.Hour * 60 + EndTime3.Minute)
            {
                cbbMealType.SelectedIndex = 3;
            }
            else if (dateTime.Hour * 60 + dateTime.Minute >= BeginTime4.Hour * 60 + BeginTime4.Minute && dateTime.Hour * 60 + dateTime.Minute < EndTime4.Hour * 60 + EndTime4.Minute)
            {
                cbbMealType.SelectedIndex = 4;
            }

            if (alGrid[12, RowIndex].Value != null)
            {
                for (int i = 0; i < cbbSFType.Items.Count; i++)
                {
                    if (((TCommonType)cbbSFType.Items[i]).id == alGrid[12, RowIndex].Value.ToString())
                    {
                        cbbSFType.SelectedIndex = i;
                        break;
                    }
                }
            }
            if (alGrid[5, RowIndex].Value != null) txtSFAmount.Text = alGrid[5, RowIndex].Value.ToString();
            if (alGrid[6, RowIndex].Value != null) txtSFCardBalance.Text = alGrid[6, RowIndex].Value.ToString();
            if (alGrid[7, RowIndex].Value != null) txtBTAmount.Text = alGrid[7, RowIndex].Value.ToString();
            if (alGrid[8, RowIndex].Value != null) txtBTBalance.Text = alGrid[8, RowIndex].Value.ToString();
            if (alGrid[4, RowIndex].Value != null) txtCardUseTimes.Text = alGrid[4, RowIndex].Value.ToString();
        }

        private void alGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }


        private void dataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (IsInitDataGrid) return;
            string field = "";
            string value = "";
            bool isFind = false;
            string sql = "";
            switch (e.ColumnIndex)
            {
                case 3:
                    field = "CardNo";
                    value = dataGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
                    if (!Pub.IsNumeric(value))
                    {
                        ShowErrorEnterCorrect(dataGrid.Columns[e.ColumnIndex].HeaderText);
                        return;
                    }
                    value = "'" + Convert.ToUInt32(value).ToString("0000000000") + "'";
                    break;
                case 4:
                    field = "CardUseTimes";
                    value = dataGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
                    if (!Pub.IsNumeric(value))
                    {
                        ShowErrorEnterCorrect(dataGrid.Columns[e.ColumnIndex].HeaderText);
                        return;
                    }
                    break;
                case 5:
                    field = "SFAmount";
                    value = dataGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
                    if (!Pub.IsNumeric(value))
                    {
                        ShowErrorEnterCorrect(dataGrid.Columns[e.ColumnIndex].HeaderText);
                        return;
                    }
                    break;
                case 6:
                    field = "SFCardBalance";
                    value = dataGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
                    if (!Pub.IsNumeric(value))
                    {
                        ShowErrorEnterCorrect(dataGrid.Columns[e.ColumnIndex].HeaderText);
                        return;
                    }
                    break;
                case 7:
                    field = "BTAmount";
                    value = dataGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
                    if (!Pub.IsNumeric(value))
                    {
                        ShowErrorEnterCorrect(dataGrid.Columns[e.ColumnIndex].HeaderText);
                        return;
                    }
                    break;
                case 8:
                    field = "BTBalance";
                    value = dataGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
                    if (!Pub.IsNumeric(value))
                    {
                        ShowErrorEnterCorrect(dataGrid.Columns[e.ColumnIndex].HeaderText);
                        return;
                    }
                    break;
                case 9:
                    field = "SFDate";
                    value = dataGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
                    DateTime sfDate = new DateTime();
                    if (!DateTime.TryParse(value, out sfDate))
                    {
                        ShowErrorEnterCorrect(dataGrid.Columns[e.ColumnIndex].HeaderText);
                        return;
                    }
                    value = "'" + sfDate.ToString(SystemInfo.SQLDateTimeFMT) + "'";
                    break;
                case 10:
                    field = "SFMealTypeID";
                    value = dataGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
                    if (!Pub.IsNumeric(value) || (Convert.ToInt32(value) < 0) || (Convert.ToInt32(value) > 4))
                    {
                        ShowErrorEnterCorrect(dataGrid.Columns[e.ColumnIndex].HeaderText);
                        return;
                    }
                    break;
                case 11:
                    field = "SFMacSN";
                    value = dataGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
                    if (value != "")
                    {
                        if (!Pub.IsNumeric(value))
                        {
                            ShowErrorEnterCorrect(dataGrid.Columns[e.ColumnIndex].HeaderText);
                            return;
                        }
                        for (int i = 0; i < cbbMacSN.Items.Count; i++)
                        {
                            if (((TCommonType)cbbMacSN.Items[i]).id == value)
                            {
                                isFind = true;
                                break;
                            }
                        }
                        if (!isFind)
                        {
                            ShowErrorEnterCorrect(dataGrid.Columns[e.ColumnIndex].HeaderText);
                            return;
                        }
                    }
                    value = "'" + value + "'";
                    break;
                case 12:
                    field = "SFType";
                    value = dataGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
                    if (!Pub.IsNumeric(value))
                    {
                        ShowErrorEnterCorrect(dataGrid.Columns[e.ColumnIndex].HeaderText);
                        return;
                    }
                    for (int i = 0; i < cbbSFType.Items.Count; i++)
                    {
                        if (((TCommonType)cbbSFType.Items[i]).id == value)
                        {
                            isFind = true;
                            break;
                        }
                    }
                    if (!isFind)
                    {
                        ShowErrorEnterCorrect(dataGrid.Columns[e.ColumnIndex].HeaderText);
                        return;
                    }
                    break;
            }
            if (field == "") return;
            string GUID = dataGrid[0, e.RowIndex].Value.ToString();
            switch (SystemInfo.DBType)
            {
                case 1:
                case 2:
                    sql = "UPDATE SF_SFData SET " + field + "=" + value + " WHERE GUID='" + GUID + "'";
                    break;
            }
            try
            {
                db.ExecSQL(sql);
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E, sql);
                return;
            }
            int colIdx = e.ColumnIndex;
            int rowIdx = e.RowIndex;
            //findGrid_Click(null, null);
            if (rowIdx < dataGrid.RowCount) dataGrid[colIdx, rowIdx].Selected = true;
            formCode = "DMMain";
        }

        private void dataGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void prodGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if ((e.ColumnIndex == 0) || (e.ColumnIndex == 7))
            {
                if (prodGrid[e.ColumnIndex + 1, e.RowIndex].Value.ToString() == "") e.Cancel = true;
            }
            else if ((e.ColumnIndex == 6) || (e.ColumnIndex == 13))
            {
                if (prodGrid[e.ColumnIndex - 3, e.RowIndex].Value.ToString() == "") e.Cancel = true;
            }
            else
                e.Cancel = true;
        }

        private void prodGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string v = "";
            switch (e.ColumnIndex)
            {
                case 6:
                case 13:
                    v = prodGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
                    if (SystemInfo.IsDecimalProduct)
                    {
                        double d = 0;
                        if (!double.TryParse(v, out d))
                            prodGrid[e.ColumnIndex, e.RowIndex].Value = 0;
                        else if (d < 0)
                            prodGrid[e.ColumnIndex, e.RowIndex].Value = 0;
                    }
                    else
                    {
                        if (!Pub.IsNumeric(v))
                            prodGrid[e.ColumnIndex, e.RowIndex].Value = 0;
                        else if (Convert.ToInt32(v) < 0)
                            prodGrid[e.ColumnIndex, e.RowIndex].Value = 0;
                    }
                    break;
                case 0:
                case 7:
                    if ((bool)prodGrid[e.ColumnIndex, e.RowIndex].Value)
                    {
                        v = prodGrid[e.ColumnIndex + 6, e.RowIndex].Value.ToString();
                        if (!Pub.IsNumeric(v))
                            prodGrid[e.ColumnIndex + 6, e.RowIndex].Value = 1;
                        else if (Convert.ToInt32(v) <= 0)
                            prodGrid[e.ColumnIndex + 6, e.RowIndex].Value = 1;
                    }
                    break;
            }
            formCode = "DMMain";
        }

        private void prodGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (findGrid.SelectedRows.Count == 0) return;
            int row = findGrid.SelectedRows[0].Index;
            string EmpSysID = findGrid[0, row].Value.ToString();
            if (BatchWriteRecord(EmpSysID)) findGrid_Click(null, null);
            formCode = "DMMain";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (findGrid.SelectedRows.Count == 0) return;
            int row = findGrid.SelectedRows[0].Index;
            string EmpSysID = findGrid[0, row].Value.ToString();
            string EmpNo = findGrid[1, row].Value.ToString();
            string EmpName = findGrid[2, row].Value.ToString();
            string Msg = string.Format(Pub.GetResText(formCode, "Msg001", ""), "[" + EmpNo + "]" + EmpName);
            if (Pub.MessageBoxShowQuestion(Msg)) return;
            List<string> sql = new List<string>();
            switch (SystemInfo.DBType)
            {
                case 1:
                case 2:
                    sql.Add("DELETE FROM SF_SFErrorDataProduct WHERE GUID IN(SELECT GUID FROM SF_SFErrorData " +
                      "WHERE EmpSysID='" + EmpSysID + "')");
                    sql.Add("DELETE FROM SF_SFErrorData WHERE EmpSysID='" + EmpSysID + "'");
                    break;
            }
            if (db.ExecSQL(sql) == 0)
            {
                findGrid_Click(null, null);
                Msg = string.Format(Pub.GetResText(formCode, "Msg002", ""), "[" + EmpNo + "]" + EmpName);
                Pub.MessageBoxShow(Msg, MessageBoxIcon.Information);
            }
            formCode = "DMMain";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGrid.SelectedRows.Count == 0) return;
            int row = dataGrid.SelectedRows[0].Index;
            string msg = "";
            for (int i = 1; i < dataGrid.ColumnCount; i++)
            {
                msg = msg + dataGrid.Columns[i].HeaderText + ": " + dataGrid[i, row].Value.ToString() + "\r\n";
            }
            msg = msg + Pub.GetResText(formCode, "Msg003", "");
            if (Pub.MessageBoxShowQuestion(msg)) return;
            string EmpSysID = findGrid[0, findGrid.SelectedRows[0].Index].Value.ToString();
            string GUID = dataGrid[0, row].Value.ToString();
            List<string> sql = new List<string>();
            switch (SystemInfo.DBType)
            {
                case 1:
                case 2:
                    sql.Add("UPDATE RS_EmpCard SET CardBalance=CardBalance+" + dataGrid[5, row].Value.ToString() + ",CardBTMoney=CardBTMoney+" + dataGrid[7, row].Value.ToString() + " WHERE EmpSysID='" + EmpSysID + "'");
                    sql.Add("DELETE FROM SF_SFData WHERE GUID='" + GUID + "'");
                    sql.Add("DELETE FROM SF_SFDataProduct WHERE GUID='" + GUID + "'");
                    break;
            }
            if (db.ExecSQL(sql) == 0)
            {
                //findGrid_Click(null, null);
                dataGrid.Rows.RemoveAt(row);
                if (row < dataGrid.RowCount) dataGrid[1, row].Selected = true;
                Pub.MessageBoxShow(Pub.GetResText(formCode, "Msg004", ""), MessageBoxIcon.Information);
            }
            formCode = "DMMain";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FindLoseData(false);
            formCode = "DMMain";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "Msg005", ""))) return;
            FindLoseData(true);
            formCode = "DMMain";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "Msg006", ""))) return;
            IsWorking = true;
            RefreshForm();
            lblMsg.Text = "0/0";
            progBar.Value = 0;
            Application.DoEvents();
            DataTable dt = null;
            DataTable dt1 = null;
            string sql = "";
            string EmpSysID = "";
            double CardBalance = 0;
            double SFCardBalance = 0;
            double BTBalance = 0;
            double CardBTMoney = 0;
            int CardUseTimes = 0;
            bool isOk = true;
            try
            {
                switch (SystemInfo.DBType)
                {
                    case 1:
                    case 2:
                        sql = "SELECT * FROM VRS_EmpSf WHERE CardStatusID<>'10' ORDER BY EmpNo";
                        break;
                }
                dt = db.GetDataTable(sql);
                sql = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    EmpSysID = dt.Rows[i]["EmpSysID"].ToString();
                    double.TryParse(dt.Rows[i]["CardBalance"].ToString(), out CardBalance);
                    double.TryParse(dt.Rows[i]["CardBTMoney"].ToString(), out CardBTMoney);
                    switch (SystemInfo.DBType)
                    {
                        case 1:
                        case 2:
                            dt1 = db.GetDataTable("SELECT TOP 1 SFCardBalance,BTBalance,CardUseTimes FROM SF_SFData WHERE EmpSysID='" +
                              //EmpSysID + "' AND SFType<>0 AND SFType<>40 AND SFType<>50 ORDER BY CardUseTimes DESC");
                              EmpSysID + "' AND SFType<>40 AND SFType<>50 ORDER BY CardUseTimes DESC");
                            break;
                    }
                    if ((dt1 != null) && (dt1.Rows.Count > 0))
                    {
                        double.TryParse(dt1.Rows[0]["SFCardBalance"].ToString(), out SFCardBalance);
                        double.TryParse(dt1.Rows[0]["BTBalance"].ToString(), out BTBalance);
                        int.TryParse(dt1.Rows[0]["CardUseTimes"].ToString(), out CardUseTimes);
                        if (CardBalance != SFCardBalance || CardBTMoney != BTBalance)
                        {
                            switch (SystemInfo.DBType)
                            {
                                case 1:
                                case 2:
                                    sql = "UPDATE RS_EmpCard SET CardBalance=" + SFCardBalance.ToString() + ",CardBTMoney=" + BTBalance.ToString() + ",CardUseTimes=" +
                                      CardUseTimes.ToString() + " WHERE EmpSysID='" + EmpSysID + "'";
                                    break;
                            }
                            db.ExecSQL(sql);
                            sql = "";
                        }
                    }
                    lblMsg.Text = string.Format("{0}/{1}", i + 1, dt.Rows.Count);
                    progBar.Value = (i + 1) * 100 / dt.Rows.Count;
                    if (!IsWorking) break;
                    Application.DoEvents();
                }
            }
            catch (Exception E)
            {
                isOk = false;
                Pub.ShowErrorMsg(E, sql);
            }
            finally
            {
                if (dt != null) dt.Reset();
                if (dt1 != null) dt1.Reset();
            }
            IsWorking = false;
            RefreshForm();
            if (isOk) Pub.MessageBoxShow(Pub.GetResText(formCode, "Msg007", ""), MessageBoxIcon.Information);
            formCode = "DMMain";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "Msg008", ""))) return;
            List<string> sql = new List<string>();
            switch (SystemInfo.DBType)
            {
                case 1:
                case 2:
                    sql.Add("TRUNCATE TABLE SF_SFErrorDataProduct");
                    sql.Add("TRUNCATE TABLE SF_SFErrorData");
                    break;
            }
            if (db.ExecSQL(sql) == 0)
            {
                findGrid_Click(null, null);
                Pub.MessageBoxShow(Pub.GetResText(formCode, "Msg009", ""), MessageBoxIcon.Information);
            }
            formCode = "DMMain";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (findGrid.SelectedRows.Count == 0) return;
            if (findGrid[0, findGrid.SelectedRows[0].Index].Value == null) return;
            string EmpSysID = findGrid[0, findGrid.SelectedRows[0].Index].Value.ToString();
            string CardNo = findGrid[3, findGrid.SelectedRows[0].Index].Value.ToString();
            DateTime SFDate = new DateTime();
            byte MealTypeID = 0;
            int MacSN = 0;
            double SFAmount = 0;
            double SFCardBalance = 0;

            double BTAmount = 0;
            double BTBalance = 0;
            int CardUseTimes = 0;
            int SFType = 0;
            int OpterNo = 0;
            string sql = "";
            string CardNoX = "";
            string MacSNStr = "";
            if (!DateTime.TryParse(txtSFDate.Text.Trim(), out SFDate))
            {
                txtSFDate.Focus();
                ShowErrorEnterCorrect(label1.Text);
                return;
            }
            int.TryParse(((TCommonType)cbbMacSN.Items[cbbMacSN.SelectedIndex]).id, out MacSN);
            if (!double.TryParse(txtSFAmount.Text.Trim(), out SFAmount))
            {
                txtSFAmount.Focus();
                ShowErrorEnterCorrect(label6.Text);
                return;
            }
            if (!double.TryParse(txtSFCardBalance.Text.Trim(), out SFCardBalance))
            {
                txtSFCardBalance.Focus();
                ShowErrorEnterCorrect(label7.Text);
                return;
            }
            if (!int.TryParse(txtCardUseTimes.Text.Trim(), out CardUseTimes))
            {
                txtCardUseTimes.Focus();
                ShowErrorEnterCorrect(label8.Text);
                return;
            }
            int.TryParse(((TCommonType)cbbSFType.Items[cbbSFType.SelectedIndex]).id, out SFType);
            if (CardNo == "")
                CardNo = GetEmpCard(EmpSysID, CardUseTimes);
            else
            {
                CardNoX = GetEmpCard(EmpSysID, CardUseTimes);
                if ((CardNoX != "") && (CardNo != CardNoX)) CardNo = CardNoX;
            }


            if (!double.TryParse(txtBTAmount.Text.Trim(), out BTAmount))
            {
                txtBTAmount.Focus();
                ShowErrorEnterCorrect(label10.Text);
                return;
            }
            if (!double.TryParse(txtBTBalance.Text.Trim(), out BTBalance))
            {
                txtBTBalance.Focus();
                ShowErrorEnterCorrect(label9.Text);
                return;
            }
            switch (SFType)
            {
                case 1:
                case 2:
                case 3:
                case 7:
                case 8:
                case 130:
                    byte.TryParse(((TCommonType)cbbMealType.Items[cbbMealType.SelectedIndex]).id, out MealTypeID);
                    break;
                default:
                    MealTypeID = 0;
                    break;
            }
            int.TryParse(((TCommonType)cbbOprtNo.Items[cbbOprtNo.SelectedIndex]).id, out OpterNo);
            string ProductInfo = "";
            int ProductCount = 0;
            int ProductID = 0;
            int ProductCategory = 0;
            double ProductNumD = 0.00;
            double ProductNum = 0;
            double ProductPrice = 0.00;
            if (SFType == 3 || SFType == 130 || (SFType == 200))
            {
                ProductCategory = Convert.ToInt32(txtCategoryID.Text.ToString());
                ProductInfo = ProductCategory.ToString("0000");
                for (int i = 0; i < prodGrid.RowCount; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (((bool)prodGrid[j * 7, i].EditedFormattedValue) &&
                          (Convert.ToInt32(prodGrid[j * 7 + 6, i].EditedFormattedValue.ToString()) > 0))
                        {
                            ProductID = Convert.ToInt32(prodGrid[j * 7 + 1, i].EditedFormattedValue.ToString());

                            if (SystemInfo.IsDecimalProduct)
                            {
                                ProductNumD = Convert.ToDouble(prodGrid[j * 7 + 6, i].EditedFormattedValue.ToString()) * 100;
                                ProductInfo = ProductInfo + ProductID.ToString("0000") + ProductNum.ToString("000000000");
                            }
                            else
                            {
                                ProductPrice = Convert.ToDouble(prodGrid[j * 7 + 5, i].EditedFormattedValue.ToString());
                                ProductNum = Convert.ToDouble(prodGrid[j * 7 + 6, i].EditedFormattedValue.ToString());
                                string[] tmp = ProductPrice.ToString("0.00").Split('.');
                                string[] msg = ProductNum.ToString("0.00").Split('.');
                                
                                ProductInfo = ProductInfo + ProductID.ToString("0000") + Convert.ToInt32(msg[0]).ToString("000000") +
                                    Convert.ToInt32(msg[1]).ToString("00") + Convert.ToInt32(tmp[0]).ToString("00000") + "." + Convert.ToInt32(tmp[1]).ToString("00");
                                // ret +=feeLog.ProductID[i].ToString("0000") + Convert.ToInt32(msg[0]).ToString("000000") + 
                                //Convert.ToInt32(msg[1]).ToString("00")+ Convert.ToInt32(tmp[0]).ToString("00000")+"."+ Convert.ToInt32(tmp[1]).ToString("00");  
                            }
                            ProductCount += 1;
                            if (ProductCount >= 10) break;
                        }
                    }
                    if (ProductCount >= 10) break;
                }
                int x = 0;
                int ProdLen = SystemInfo.IsDecimalProduct ? 13 : 20;
                while (ProductInfo.Length < 10 * ProdLen+4)
                {
                    x++;
                    if ((x + 2) % 20 == 0)
                    {
                        ProductInfo = ProductInfo + ".";
                    }
                    else
                    {
                        ProductInfo = ProductInfo + "0";
                    }
                   
                }
                ProductInfo = ProductInfo.Substring(0, 10 * ProdLen+4);
            }
            if ((SFType >= 90 && SFType <= 99) || (SFType >= 100 && SFType <= 109))
                SFAmount = Math.Abs(SFAmount);
            else if ((SFType == 20) || (SFType == 30) || (SFType == 50) || (SFType == 60) ||
              ((SFType != 4) && (SFType != 5) && (SFType != 10) && (SFType != 40) && (SFType != 80) && (SFType != 255)))
            {
                SFAmount = -Math.Abs(SFAmount);
                BTAmount = -Math.Abs(BTAmount);
            }

            else
            {
                SFAmount = Math.Abs(SFAmount);
                BTAmount = Math.Abs(BTAmount);
            }

            if ((SFType != 4) && (SFType != 9)) OpterNo = 0;
            MacSNStr = MacSN.ToString();
            if (SFType == 10 || SFType == 20)
            {
                MacSNStr = "";
                MealTypeID = 0;
            }
            sql = Pub.GetSQL(DBCode.DB_004005, new string[] { "7", EmpSysID, CardNo, SFType.ToString(),
        SFDate.ToString(SystemInfo.SQLDateTimeFMT), SFAmount.ToString(), SFCardBalance.ToString(),
        MealTypeID.ToString(), MacSNStr, OpterNo.ToString(), CardUseTimes.ToString(), "", ProductInfo,BTAmount.ToString(), BTBalance.ToString() });
            try
            {
                db.ExecSQL(sql);
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E, sql);
                return;
            }
            findGrid_Click(null, null);
            formCode = "DMMain";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)prodGrid.DataSource;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i][0] = false;
                dt.Rows[i][6] = 0;
                dt.Rows[i][7] = false;
                dt.Rows[i][13] = 0;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "Msg012", ""))) return;
            IsWorking = true;
            RefreshForm();
            lblMsg.Text = "0/0";
            progBar.Value = 0;
            Application.DoEvents();
            DataTable dt = null;
            DataTable dt1 = null;
            bool isOk = true;
            int MaxTimes = 0;
            int TmpTimes = 0;
            string sql = "";
            string EmpNo = txtEmpNo.Text.Trim();
            if (EmpNo != "") EmpNo = " AND EmpNo='" + EmpNo + "'";
            string EmpSysID = "";
            try
            {
                switch (SystemInfo.DBType)
                {
                    case 1:
                    case 2:
                        sql = "SELECT * FROM VRS_EmpSf WHERE CardStatusID<>'10'" + EmpNo + " ORDER BY EmpNo";
                        break;
                }
                dt = db.GetDataTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    EmpSysID = dt.Rows[i]["EmpSysID"].ToString();
                    switch (SystemInfo.DBType)
                    {
                        case 1:
                        case 2:
                            dt1 = db.GetDataTable("SELECT MAX(CardUseTimes) AS CardUseTimes FROM SF_SFData WHERE EmpSysID='" +
                              EmpSysID + "'");
                            break;
                    }
                    if (dt1.Rows.Count == 1)
                    {
                        MaxTimes = 0;
                        int.TryParse(dt1.Rows[0]["CardUseTimes"].ToString(), out MaxTimes);
                        MaxTimes--;
                        while (MaxTimes > 1)
                        {
                            switch (SystemInfo.DBType)
                            {
                                case 1:
                                case 2:
                                    dt1 = db.GetDataTable("SELECT * FROM SF_SFData WHERE EmpSysID='" + EmpSysID +
                                      "' AND CardUseTimes=" + MaxTimes.ToString());
                                    break;
                            }
                            if (dt1.Rows.Count == 0)
                            {
                                switch (SystemInfo.DBType)
                                {
                                    case 1:
                                    case 2:
                                        sql = "UPDATE SF_SFErrorData SET ReadMark=1 WHERE EmpSysID='" + EmpSysID +
                                          "' AND CardUseTimes=" + MaxTimes.ToString();
                                        break;
                                }
                                db.ExecSQL(sql);
                                TmpTimes = MaxTimes - 1;
                                sql = "UPDATE SF_SFErrorData SET ReadMark=1 WHERE EmpSysID='" + EmpSysID +
                                  "' AND SFType=0 AND CardUseTimes=" + TmpTimes.ToString();
                                db.ExecSQL(sql);
                            }
                            MaxTimes--;
                        }
                    }
                    lblMsg.Text = string.Format("{0}/{1}", i + 1, dt.Rows.Count);
                    progBar.Value = (i + 1) * 100 / dt.Rows.Count;
                    if (!IsWorking) break;
                    Application.DoEvents();
                }
            }
            catch (Exception E)
            {
                isOk = false;
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                if (dt != null) dt.Reset();
            }
            IsWorking = false;
            RefreshForm();
            if (isOk) Pub.MessageBoxShow(Pub.GetResText(formCode, "Msg013", ""), MessageBoxIcon.Information);
            formCode = "DMMain";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "Msg010", ""))) return;
            IsWorking = true;
            RefreshForm();
            lblMsg.Text = "0/0";
            progBar.Value = 0;
            Application.DoEvents();
            DataTable dt = null;
            bool isOk = true;
            string GUID = "";
            try
            {
                switch (SystemInfo.DBType)
                {
                    case 1:
                    case 2:
                        dt = db.GetDataTable("SELECT * FROM SF_SFErrorData WHERE ReadMark=1 ORDER BY CardNo,CardUseTimes");
                        break;
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    GUID = dt.Rows[i]["GUID"].ToString();
                    switch (SystemInfo.DBType)
                    {
                        case 1:
                        case 2:
                            RepairSFData(GUID);
                            break;
                    }
                    lblMsg.Text = string.Format("{0}/{1}", i + 1, dt.Rows.Count);
                    progBar.Value = (i + 1) * 100 / dt.Rows.Count;
                    if (!IsWorking) break;
                    Application.DoEvents();
                }
            }
            catch (Exception E)
            {
                isOk = false;
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                if (dt != null) dt.Reset();
            }
            IsWorking = false;
            RefreshForm();
            if (isOk) Pub.MessageBoxShow(Pub.GetResText(formCode, "Msg011", ""), MessageBoxIcon.Information);
            formCode = "DMMain";
        }

        private DataTable GetFindRecord(string EmpSysID)
        {
            string sql = "DECLARE @EmpSysID varchar(36),@EmpNo varchar(50),@EmpName varchar(50),@CardNo varchar(10),@cnt int\r\n";
            sql = sql + "DECLARE @M1 decimal(16,2),@M2 decimal(16,2),@M3 decimal(16,2),@M decimal(16,2),@Time1 int,@Time2 int,@SFType int\r\n";
            sql = sql + "IF EXISTS(SELECT * FROM sysobjects WHERE name='TempTableFind') DROP TABLE TempTableFind\r\n";
            sql = sql + "CREATE TABLE TempTableFind(EmpSysID varchar(36),EmpNo varchar(50),EmpName varchar(50)," +
              "CardNo varchar(10),[money] money)\r\n";
            sql = sql + "DECLARE RecNo CURSOR SCROLL FOR SELECT EmpSysID,EmpNo,EmpName,CardSectorNo\r\n";
            sql = sql + "  FROM VRS_EmpSf\r\n";
            sql = sql + "  WHERE EmpSysID='" + EmpSysID + "'\r\n";
            sql = sql + "OPEN RecNo\r\n";
            sql = sql + "FETCH FIRST FROM RecNo INTO @EmpSysID,@EmpNo,@EmpName,@CardNo\r\n";
            sql = sql + "WHILE @@FETCH_STATUS=0\r\n";
            sql = sql + "BEGIN\r\n";
            sql = sql + "  SELECT @Time1=MIN(CardUseTimes)\r\n";
            sql = sql + "    FROM SF_SFData\r\n";
            //sql = sql + "    WHERE EmpSysID=@EmpSysID AND (SFType<>2 AND SFType<>40 AND SFType<>50 AND SFType<>0)\r\n";
            sql = sql + "    WHERE EmpSysID=@EmpSysID AND (SFType<>2 AND SFType<>40 AND SFType<>50)\r\n";
            sql = sql + "  IF @Time1 IS NOT NULL\r\n";
            sql = sql + "  BEGIN\r\n";
            sql = sql + "    SELECT @M3=SFCardBalance+BTBalance\r\n";
            sql = sql + "      FROM SF_SFData\r\n";
            //sql = sql + "       WHERE EmpSysID=@EmpSysID AND (SFType<>2 AND SFType<>40 AND SFType<>50 AND SFType<>0) AND CardUseTimes=@Time1\r\n";
            sql = sql + "       WHERE EmpSysID=@EmpSysID AND (SFType<>2 AND SFType<>40 AND SFType<>50) AND CardUseTimes=@Time1\r\n";
            sql = sql + "    DECLARE RecNo1 CURSOR SCROLL FOR SELECT CardUseTimes,(SFAmount+BTAmount) as SFAmount,(SFCardBalance+BTBalance) as SFCardBalance,SFType\r\n";
            sql = sql + "      FROM SF_SFData\r\n";
            //sql = sql + "      WHERE EmpSysID=@EmpSysID AND (SFType<>2 AND SFType<>40 AND SFType<>50 AND SFType<>0) AND CardUseTimes>@Time1\r\n";
            sql = sql + "      WHERE EmpSysID=@EmpSysID AND (SFType<>2 AND SFType<>40 AND SFType<>50) AND CardUseTimes>@Time1\r\n";
            sql = sql + "      ORDER BY CardUseTimes\r\n";
            sql = sql + "    OPEN RecNo1\r\n";
            sql = sql + "    FETCH FIRST FROM RecNo1 INTO @Time2,@M1,@M2,@SFType\r\n";
            sql = sql + "    WHILE @@FETCH_STATUS=0\r\n";
            sql = sql + "    BEGIN\r\n";
            sql = sql + "      SELECT @Time1=@Time1+1\r\n";
            /*sql = sql + "      IF @SFType=5 AND EXISTS(SELECT * FROM SF_SFData WHERE EmpSysID=@EmpSysID AND CardUseTimes=@Time2 AND SFType=0)\r\n";
            sql = sql + "        SELECT @M3=@M3+SFAmount FROM SF_SFData WHERE EmpSysID=@EmpSysID AND CardUseTimes=@Time2 AND SFType=0\r\n";
            sql = sql + "      ELSE IF @SFType=5 AND EXISTS(SELECT * FROM SF_SFData WHERE EmpSysID=@EmpSysID AND CardUseTimes=@Time2-1 AND SFType=0)\r\n";
            sql = sql + "      BEGIN\r\n";
            sql = sql + "        SELECT @M3=@M3+SFAmount FROM SF_SFData WHERE EmpSysID=@EmpSysID AND CardUseTimes=@Time2-1 AND SFType=0\r\n";
            sql = sql + "        SET @Time1=@Time2\r\n";
            sql = sql + "      END\r\n";
            sql = sql + "      ELSE IF @SFType=30 AND EXISTS(SELECT * FROM SF_SFData WHERE EmpSysID=@EmpSysID AND CardUseTimes=@Time2 AND SFType=0)\r\n";
            sql = sql + "        SELECT @M3=@M3+SFAmount FROM SF_SFData WHERE EmpSysID=@EmpSysID AND CardUseTimes=@Time2 AND SFType=0\r\n";
            sql = sql + "      ELSE IF @SFType=30 AND EXISTS(SELECT * FROM SF_SFData WHERE EmpSysID=@EmpSysID AND CardUseTimes=@Time2-1 AND SFType=0)\r\n";
            sql = sql + "      BEGIN\r\n";
            sql = sql + "        SELECT @M3=@M3+SFAmount FROM SF_SFData WHERE EmpSysID=@EmpSysID AND CardUseTimes=@Time2-1 AND SFType=0\r\n";
            sql = sql + "        SET @Time1=@Time2\r\n";
            sql = sql + "      END\r\n";
            sql = sql + "      ELSE\r\n";
            sql = sql + "      BEGIN\r\n";
            sql = sql + "        SELECT @cnt=COUNT(1) FROM SF_SFData WHERE EmpSysID=@EmpSysID AND CardUseTimes=@Time2-1\r\n";
            sql = sql + "        IF @cnt=1 AND EXISTS(SELECT * FROM SF_SFData WHERE EmpSysID=@EmpSysID AND CardUseTimes=@Time2-1 AND SFType=0)\r\n";
            sql = sql + "        BEGIN\r\n";
            sql = sql + "          SELECT @M3=@M3+SFAmount FROM SF_SFData WHERE EmpSysID=@EmpSysID AND CardUseTimes=@Time2-1 AND SFType=0\r\n";
            sql = sql + "          SET @Time1=@Time2\r\n";
            sql = sql + "        END\r\n";
            sql = sql + "      END\r\n";*/
            sql = sql + "      IF @Time1<>@Time2\r\n";
            sql = sql + "      BEGIN\r\n";
            sql = sql + "        SELECT @M=@M2-@M1\r\n";
            sql = sql + "        SELECT @M=@M3-@M\r\n";
            sql = sql + "        IF EXISTS(SELECT * FROM TempTableFind WHERE EmpSysID=@EmpSysID)\r\n";
            sql = sql + "          UPDATE TempTableFind SET [money]=[money]+@M WHERE EmpSysID=@EmpSysID\r\n";
            sql = sql + "        ELSE\r\n";
            sql = sql + "          INSERT INTO TempTableFind SELECT @EmpSysID,@EmpNo,@EmpName,@CardNo,@M\r\n";
            sql = sql + "        SELECT @Time1=@Time2,@M3=@M2\r\n";
            sql = sql + "      END\r\n";
            sql = sql + "      ELSE IF @M3+@M1<>@M2\r\n";
            sql = sql + "      BEGIN\r\n";
            sql = sql + "        SELECT @M=@M3-@M2+@M1\r\n";
            sql = sql + "        IF EXISTS(SELECT * FROM TempTableFind WHERE EmpSysID=@EmpSysID)\r\n";
            sql = sql + "          UPDATE TempTableFind SET [money]=[money]+@M WHERE EmpSysID=@EmpSysID\r\n";
            sql = sql + "        ELSE\r\n";
            sql = sql + "          INSERT INTO TempTableFind SELECT @EmpSysID,@EmpNo,@EmpName,@CardNo,@M\r\n";
            sql = sql + "        SELECT @M3=@M2\r\n";
            sql = sql + "      END\r\n";
            sql = sql + "      ELSE\r\n";
            sql = sql + "        SELECT @M3=@M2\r\n";
            sql = sql + "      FETCH NEXT FROM RecNo1 INTO @Time2,@M1,@M2,@SFType\r\n";
            sql = sql + "    END\r\n";
            sql = sql + "    CLOSE RecNo1\r\n";
            sql = sql + "    DEALLOCATE RecNo1\r\n";
            sql = sql + "  END\r\n";
            sql = sql + "  FETCH NEXT FROM RecNo INTO @EmpSysID,@EmpNo,@EmpName,@CardNo\r\n";
            sql = sql + "END\r\n";
            sql = sql + "CLOSE RecNo\r\n";
            sql = sql + "DEALLOCATE RecNo\r\n";
            sql = sql + "IF NOT EXISTS(SELECT * FROM TempTableFind)\r\n";
            sql = sql + "BEGIN\r\n";
            sql = sql + "  SELECT @M1=ABS(SUM(SFAmount+BTAmount))\r\n";
            sql = sql + "    FROM SF_SFData\r\n";
            sql = sql + "    WHERE EmpSysID=@EmpSysID AND (SFType<>2 AND SFType<>40 AND SFType<>50)\r\n";
            sql = sql + "  SELECT @Time1=MAX(CardUseTimes)\r\n";
            sql = sql + "    FROM SF_SFData\r\n";
            sql = sql + "    WHERE EmpSysID=@EmpSysID\r\n";
            sql = sql + "  SELECT @M2=SFCardBalance+BTBalance\r\n";
            sql = sql + "    FROM SF_SFData\r\n";
            //sql = sql + "    WHERE EmpSysID=@EmpSysID AND (SFType<>2 AND SFType<>40 AND SFType<>50 AND SFType<>0) AND CardUseTimes=@Time1\r\n";
            sql = sql + "    WHERE EmpSysID=@EmpSysID AND (SFType<>2 AND SFType<>40 AND SFType<>50) AND CardUseTimes=@Time1\r\n";
            sql = sql + "  SET @M=@M1-@M2\r\n";
            sql = sql + "  IF @M IS NOT NULL AND @M<>0 INSERT INTO TempTableFind SELECT @EmpSysID,@EmpNo,@EmpName,@CardNo,@M\r\n";
            sql = sql + "END";
            db.ExecSQL(sql);
            DataTable ret = db.GetDataTable("SELECT * FROM TempTableFind ORDER BY EmpNo");
            sql = "IF EXISTS(SELECT * FROM sysobjects WHERE name='TempTableFind') DROP TABLE TempTableFind";
            db.ExecSQL(sql);
            return ret;
        }

        private DataTable GetLoseRecord(string EmpSysID)
        {
            string sql = "DECLARE @EmpSysID varchar(36),@EmpNo varchar(50),@EmpName varchar(50),@CardNo varchar(10)\r\n";
            sql = sql + "DECLARE @M1 decimal(16,2),@M2 decimal(16,2),@MB1 decimal(16,2),@MB2 decimal(16,2),@M3 decimal(16,2),@M decimal(16,2),@MB3 decimal(16,2),@MB decimal(16,2),@Time1 int,@Time2 int,@IsF bit,@MM decimal(16,2),@MMX decimal(16,2),@MMB decimal(16,2),@MMXB decimal(16,2),@I int\r\n";
            sql = sql + "DECLARE @MealID int,@SFType int,@SFType1 int,@SFDate datetime,@MacSN varchar(7),@Count int,@IsFirst bit,@IsSave bit,@MMM decimal(16,2)\r\n";
            sql = sql + "IF EXISTS(SELECT * FROM sysobjects WHERE name='TempTableLose') DROP TABLE TempTableLose\r\n";
            sql = sql + "CREATE TABLE TempTableLose(GUID varchar(36),EmpNo varchar(20),EmpName varchar(50),CardNo varchar(10)," +
              "CardUseTimes int,SFAmount money,SFCardBalance money,BTAmount money,BTBalance money,SFDate datetime,MealType tinyint,MacSN int,SFType int)\r\n";
            sql = sql + "DECLARE RecNo CURSOR SCROLL FOR SELECT EmpSysID,EmpNo,EmpName,CardSectorNo\r\n";
            sql = sql + "  FROM VRS_EmpSf\r\n";
            sql = sql + "  WHERE EmpSysID='" + EmpSysID + "'\r\n";
            sql = sql + "OPEN RecNo\r\n";
            sql = sql + "FETCH FIRST FROM RecNo INTO @EmpSysID,@EmpNo,@EmpName,@CardNo\r\n";
            sql = sql + "WHILE @@FETCH_STATUS=0\r\n";
            sql = sql + "BEGIN\r\n";
            sql = sql + "  SELECT @Time1=MAX(CardUseTimes)\r\n";
            sql = sql + "    FROM SF_SFData\r\n";
            //sql = sql + "    WHERE EmpSysID=@EmpSysID AND (SFType<>2 AND SFType<>40 AND SFType<>50 AND SFType<>0)\r\n";
            sql = sql + "    WHERE EmpSysID=@EmpSysID AND (SFType<>2 AND SFType<>40 AND SFType<>50)\r\n";
            sql = sql + "  IF @Time1 IS NOT NULL\r\n";
            sql = sql + "  BEGIN\r\n";
            sql = sql + "    SELECT @M3=SFCardBalance-SFAmount,@MB3=BTBalance-BTAmount,@MealID=SFMealTypeID,@SFType=SFType,@SFDate=SFDate,@MacSN=SFMacSN\r\n";
            sql = sql + "      FROM SF_SFData\r\n";
            //sql = sql + "       WHERE EmpSysID=@EmpSysID AND (SFType<>2 AND SFType<>40 AND SFType<>50 AND SFType<>0) AND CardUseTimes=@Time1\r\n";
            sql = sql + "       WHERE EmpSysID=@EmpSysID AND (SFType<>2 AND SFType<>40 AND SFType<>50) AND CardUseTimes=@Time1\r\n";
            sql = sql + "    DECLARE RecNo1 CURSOR SCROLL FOR SELECT CardUseTimes,SFAmount,SFCardBalance,BTAmount,BTBalance\r\n";
            sql = sql + "      FROM SF_SFData\r\n";
            //sql = sql + "      WHERE EmpSysID=@EmpSysID AND (SFType<>2 AND SFType<>40 AND SFType<>50 AND SFType<>0) AND CardUseTimes<@Time1\r\n";
            sql = sql + "      WHERE EmpSysID=@EmpSysID AND (SFType<>2 AND SFType<>40 AND SFType<>50) AND CardUseTimes<@Time1\r\n";
            sql = sql + "      ORDER BY CardUseTimes DESC\r\n";
            sql = sql + "    OPEN RecNo1\r\n";
            sql = sql + "    FETCH FIRST FROM RecNo1 INTO @Time2,@M1,@M2,@MB1,@MB2\r\n";
            sql = sql + "    SET @IsFirst=1\r\n";
            sql = sql + "    WHILE @@FETCH_STATUS=0\r\n";
            sql = sql + "    BEGIN\r\n";
            sql = sql + "      SELECT @Time1=@Time1-1\r\n";
            sql = sql + "      IF @Time1<>@Time2\r\n";
            sql = sql + "      BEGIN\r\n";
            sql = sql + "        IF @IsFirst=0\r\n";
            sql = sql + "          SELECT @M3=SFCardBalance-SFAmount,@MB3=BTBalance-BTAmount,@MMM=SFAmount+BTAmount\r\n";
            sql = sql + "            FROM SF_SFData\r\n";
            //sql = sql + "            WHERE EmpSysID=@EmpSysID AND (SFType<>2 AND SFType<>40 AND SFType<>50 AND SFType<>0) AND CardUseTimes=@Time1+1\r\n";
            sql = sql + "            WHERE EmpSysID=@EmpSysID AND (SFType<>2 AND SFType<>40 AND SFType<>50) AND CardUseTimes=@Time1+1\r\n";
            sql = sql + "        SELECT @SFType1=SFType\r\n";
            sql = sql + "          FROM SF_SFData\r\n";
            //sql = sql + "          WHERE EmpSysID=@EmpSysID AND (SFType<>2 AND SFType<>40 AND SFType<>50 AND SFType<>0) AND CardUseTimes=@Time1+1\r\n";
            sql = sql + "          WHERE EmpSysID=@EmpSysID AND (SFType<>2 AND SFType<>40 AND SFType<>50) AND CardUseTimes=@Time1+1\r\n";
            sql = sql + "        SET @IsFirst=0\r\n";
            sql = sql + "        SELECT @MealID=SFMealTypeID,@SFType=SFType,@SFDate=SFDate,@MacSN=SFMacSN\r\n";
            sql = sql + "          FROM SF_SFData\r\n";
            //sql = sql + "          WHERE EmpSysID=@EmpSysID AND (SFType<>2 AND SFType<>40 AND SFType<>50 AND SFType<>0) AND CardUseTimes=@Time2\r\n";
            sql = sql + "          WHERE EmpSysID=@EmpSysID AND (SFType<>2 AND SFType<>40 AND SFType<>50) AND CardUseTimes=@Time2\r\n";
            sql = sql + "        SELECT @M=@M3-@M2,@MB=@MB3-@MB2,@I=@Time1-@Time2\r\n";
            sql = sql + "        SELECT @MM=ROUND(@M/@I,2), @MMB=ROUND(@MB/@I,2),@Count=@I\r\n";
            sql = sql + "        SELECT @SFDate=DATEADD(ss,@I+1,@SFDate)\r\n";
            sql = sql + "        WHILE @I>0\r\n";
            sql = sql + "        BEGIN\r\n";
            sql = sql + "          SELECT @MMX=@MM,@MMXB=@MMB\r\n";
            //sql = sql + "          IF @Time1-1=@Time2 SELECT @MMX=@M-@MM*(@Count-1),@MMXB=@MB-@MMB*(@Count-1)\r\n";
            sql = sql + "          SELECT @SFType=CASE WHEN (@MMX+@MMXB<=0) THEN 1 ELSE 10 END\r\n";
            //sql = sql + "          SELECT @SFType=CASE WHEN @MMM<0 THEN 1 ELSE 10 END\r\n";
            sql = sql + "          SELECT @SFDate=DATEADD(ss,-1,@SFDate),@IsSave=1\r\n";
            sql = sql + "          IF @SFType1=5 AND EXISTS(SELECT * FROM SF_SFData WHERE EmpSysID=@EmpSysID AND SFType=0 AND CardUseTimes=@Time1) SET @IsSave=0\r\n";
            sql = sql + "          IF @IsSave=1 INSERT INTO TempTableLose SELECT newid(),@EmpNo,@EmpName,@CardNo,@Time1,@MMX,@M3,@MMXB,@MB3,@SFDate," +
              "@MealID,@MacSN,@SFType\r\n";
            sql = sql + "          SELECT @I=@I-1,@M3=@M3-@MMX,@MB3=@MB3-@MMXB,@Time1=@Time1-1\r\n";
            sql = sql + "        END\r\n";
            sql = sql + "        SELECT @Time1=@Time2,@M3=@M2,@MB3=@MB2\r\n";
            sql = sql + "      END\r\n";
            sql = sql + "      ELSE\r\n";
            sql = sql + "        SELECT @M3=@M2-@M1,@MB3=@MB2-@MB1\r\n";
            sql = sql + "      FETCH NEXT FROM RecNo1 INTO @Time2,@M1,@M2,@MB1,@MB2\r\n";
            sql = sql + "    END\r\n";
            sql = sql + "    CLOSE RecNo1\r\n";
            sql = sql + "    DEALLOCATE RecNo1\r\n";
            if (!IsCheck)
            {
                //sql = sql + "    IF NOT EXISTS(SELECT * FROM SF_SFData WHERE EmpSysID=@EmpSysID AND (SFType<>2 AND SFType<>40 AND SFType<>50 AND SFType<>0) AND CardUseTimes<@Time1)\r\n";
                sql = sql + "    IF NOT EXISTS(SELECT * FROM SF_SFData WHERE EmpSysID=@EmpSysID AND (SFType<>2 AND SFType<>40 AND SFType<>50) AND CardUseTimes<@Time1)\r\n";
                sql = sql + "      AND NOT EXISTS(SELECT * FROM TempTableLose WHERE CardUseTimes=1)\r\n";
                sql = sql + "    BEGIN\r\n";
                sql = sql + "      SELECT @M3=SFCardBalance-SFAmount,@MB3=BTBalance-BTAmount,@MMM=(SFAmount+BTAmount),@MealID=SFMealTypeID,@SFType=SFType,@SFDate=SFDate,@MacSN=SFMacSN\r\n";
                sql = sql + "        FROM SF_SFData\r\n";
                //sql = sql + "        WHERE EmpSysID=@EmpSysID AND (SFType<>2 AND SFType<>40 AND SFType<>50 AND SFType<>0) AND CardUseTimes=@Time1\r\n";
                sql = sql + "        WHERE EmpSysID=@EmpSysID AND (SFType<>2 AND SFType<>40 AND SFType<>50) AND CardUseTimes=@Time1\r\n";
                sql = sql + "      SELECT @SFType=CASE WHEN (@M3+@MB3<=0) THEN 1 ELSE 10 END\r\n";
                //sql = sql + "          SELECT @SFType=CASE WHEN @MMM<0 THEN 1 ELSE 10 END\r\n";
                //sql = sql + "      IF @MMM<=0 SELECT @SFType=1\r\n";
                //sql = sql + "      IF @MMM>0 SELECT @SFType=10\r\n";
                sql = sql + "      SELECT @M=@M3,@MB=@MB3\r\n";
                sql = sql + "      IF @SFType<>10 SELECT @M=0\r\n";
                sql = sql + "      SELECT @SFDate=DATEADD(ss,-1,@SFDate)\r\n";
                sql = sql + "      IF @Time1-1>0 AND (@M<>0 OR @MB<>0) INSERT INTO TempTableLose SELECT newid(),@EmpNo,@EmpName,@CardNo,@Time1-1,@M,@M3,@MB,@MB3,@SFDate," +
                  "@MealID,@MacSN,@SFType\r\n";
                sql = sql + "    END\r\n";
            }
            sql = sql + "  END\r\n";
            sql = sql + "  FETCH NEXT FROM RecNo INTO @EmpSysID,@EmpNo,@EmpName,@CardNo\r\n";
            sql = sql + "END\r\n";
            sql = sql + "CLOSE RecNo\r\n";
            sql = sql + "DEALLOCATE RecNo\r\n";
            sql = sql + "INSERT INTO TempTableLose SELECT GUID,EmpNo,EmpName,CardNo,CardUseTimes,SFAmount,SFCardBalance,BTAmount,BTBalance," +
              "SFDate,SFMealTypeID,SFMacSN,SFType FROM SF_SFErrorData a INNER JOIN RS_Emp b ON b.EmpSysID=a.EmpSysID " +
              "WHERE a.EmpSysID=@EmpSysID AND ReadMark=1 ORDER BY SFDate";
            db.ExecSQL(sql);
            DataTable ret = db.GetDataTable("SELECT GUID,EmpNo,EmpName,CardNo,CardUseTimes,(SFAmount+BTAmount) as SFAmount,(SFCardBalance+BTBalance) as SFCardBalance," +
                "SFDate,MealType,MacSN,SFType  FROM TempTableLose ORDER BY CardUseTimes");
            sql = "IF EXISTS(SELECT * FROM sysobjects WHERE name='TempTableLose') DROP TABLE TempTableLose";
            db.ExecSQL(sql);
            return ret;
        }

        private void RepairSFData(string GUID)
        {
            string sql = "DECLARE @GUID varchar(36),@EmpSysID varchar(36),@CardNo varchar(10),@CardUseTimes int,@SFType int,\r\n";
            sql = sql + "  @SFDate datetime,@SFAmount decimal(8,2),@CardBalance decimal(8,2),@BTAmount decimal(8,2),@BTBalance decimal(8,2),@SFMealTypeID int,@SFCountHour int,\r\n";
            sql = sql + "  @SFMacSn varchar(7),@SFOprtNo int,@OprtSysID varchar(36),@OprtDate datetime,@Receivables decimal(8,2),\r\n";
            sql = sql + "  @i int,@UseTimes int,@FaDate datetime,@sft datetime,@IsExists tinyint,@GUIDNew varchar(36)\r\n";
            sql = sql + "SELECT @GUID='" + GUID + "',@IsExists=0\r\n";
            sql = sql + "SELECT @EmpSysID=EmpSysID,@CardNo=CardNo,@CardUseTimes=CardUseTimes,@SFType=SFType,@SFDate=SFDate,\r\n";
            sql = sql + "  @SFAmount=SFAmount,@CardBalance=SFCardBalance,@BTAmount=BTAmount,@BTBalance=BTBalance,@SFMealTypeID=SFMealTypeID,@SFCountHour=SFCountHour,\r\n";
            sql = sql + "  @SFMacSn=SFMacSN,@SFOprtNo=SFOprtNo,@OprtSysID=OprtSysID,@OprtDate=OprtDate,\r\n";
            sql = sql + "  @Receivables=ReceivablesAmount FROM SF_SFErrorData WHERE GUID=@GUID\r\n";
            sql = sql + "IF @EmpSysID IS NULL OR @EmpSysID=''\r\n";
            sql = sql + "  SELECT @EmpSysID=EmpSysID FROM RS_EmpCard WHERE CardSectorNo=@CardNo\r\n";
            sql = sql + "IF (@SFAmount<>0 OR @BTAmount<>0) AND EXISTS(SELECT EmpSysID FROM RS_EmpCard WHERE EmpSysID=@EmpSysID)\r\n";
            sql = sql + "BEGIN\r\n";
            sql = sql + "  SELECT @UseTimes=CardUseTimes,@FaDate=FaDate,@sft=CardUseDate\r\n";
            sql = sql + "    FROM RS_EmpCard WHERE EmpSysID=@EmpSysID\r\n";
            sql = sql + "  IF (@SFType=2 AND EXISTS(SELECT CardNo FROM SF_SFData WHERE CardNo=@CardNo AND SFMacSn=@SFMacSn AND SFType=2 AND SFDate=@SFDate AND EmpSysID=@EmpSysID))\r\n";
            sql = sql + "    SELECT @IsExists=1\r\n";
            sql = sql + "  ELSE IF (@SFType=0 AND EXISTS(SELECT CardNo FROM SF_SFData WHERE CardNo=@CardNo AND SFMacSn=@SFMacSn AND SFType=0 AND SFDate=@SFDate AND EmpSysID=@EmpSysID))\r\n";
            sql = sql + "    SELECT @IsExists=1\r\n";
            //sql = sql + "  ELSE IF (@SFType<>0 AND @SFType<>2 AND\r\n";
            sql = sql + "  ELSE IF (@SFType<>2 AND\r\n";
            //sql = sql + "    EXISTS(SELECT CardNo FROM SF_SFData WHERE CardNo=@CardNo AND CardUseTimes=@CardUseTimes AND SFType<>0 AND SFType<>2 AND EmpSysID=@EmpSysID))\r\n";
            sql = sql + "    EXISTS(SELECT CardNo FROM SF_SFData WHERE CardNo=@CardNo AND CardUseTimes=@CardUseTimes AND SFType<>2 AND EmpSysID=@EmpSysID))\r\n";
            sql = sql + "    SELECT @IsExists=1\r\n";
            sql = sql + "  IF @IsExists=0 AND (@FaDate IS NULL OR (@FaDate IS NOT NULL AND @SFDate>@FaDate))\r\n";
            sql = sql + "  BEGIN\r\n";
            sql = sql + "    SELECT @GUIDNew=@GUID\r\n";
            sql = sql + "    IF EXISTS(SELECT * FROM SF_SFData WHERE GUID=@GUIDNew) SET @GUIDNew=newid()\r\n";
            sql = sql + "  INSERT INTO SF_SFData(EmpSysID,CardNo,CardUseTimes,SFType,SFDate,SFAmount,SFCardBalance,SFMealTypeID,\r\n";
            sql = sql + "    SFMacSn,SFOprtNo,OprtSysID,OprtDate,GUID,ReadMark,BTAmount,BTBalance) VALUES(@EmpSysID,@CardNo,@CardUseTimes,@SFType,\r\n";
            sql = sql + "    @SFDate,@SFAmount,@CardBalance,@SFMealTypeID,@SFMacSn,@SFOprtNo,@OprtSysID,@OprtDate,@GUIDNew,2,@BTAmount,@BTBalance)\r\n";
            sql = sql + "  INSERT INTO SF_SFDataProduct(GUID,ProductID,ProductNum,ProductPrice,ProductsName,CategoryID,CategoryName)\r\n";
            sql = sql + "    SELECT @GUIDNew,ProductID,ProductNum,ProductPrice,ProductsName,CategoryID,CategoryName\r\n";
            sql = sql + "    FROM SF_SFErrorDataProduct WHERE GUID=@GUID ORDER BY ProductID\r\n";
            sql = sql + "  END\r\n";
            sql = sql + "  DELETE FROM SF_SFErrorData WHERE GUID=@GUID\r\n";
            sql = sql + "END";
            db.ExecSQL(sql);
        }

        private bool BatchWriteRecord(string EmpSysID)
        {
            bool ret = false;
            DataTable dt = null;
            switch (SystemInfo.DBType)
            {
                case 1:
                case 2:
                    dt = GetLoseRecord(EmpSysID);
                    break;
            }
            if (dt != null)
            {
                List<string> sql = new List<string>();
                string CardNo = "";
                DateTime SFDate;
                byte MealTypeID = 0;
                int MacSN = 0;
                double SFAmount = 0;
                double SFCardBalance = 0;
                double BTAmount = 0;
                double BTBalance = 0;
                int CardUseTimes = 0;
                int SFType = 0;
                string CardNoX = "";
                string MacSNStr = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CardNo = dt.Rows[i]["CardNo"].ToString();
                    DateTime.TryParse(dt.Rows[i]["SFDate"].ToString(), out SFDate);
                    byte.TryParse(dt.Rows[i]["MealType"].ToString(), out MealTypeID);
                    int.TryParse(dt.Rows[i]["MacSN"].ToString(), out MacSN);
                    double.TryParse(dt.Rows[i]["SFAmount"].ToString(), out SFAmount);
                    double.TryParse(dt.Rows[i]["SFCardBalance"].ToString(), out SFCardBalance);
                    int.TryParse(dt.Rows[i]["CardUseTimes"].ToString(), out CardUseTimes);
                    int.TryParse(dt.Rows[i]["SFType"].ToString(), out SFType);
                    //double.TryParse(dt.Rows[i]["BTAmount"].ToString(), out BTAmount);
                    //double.TryParse(dt.Rows[i]["BTBalance"].ToString(), out BTBalance);
                    if (CardNo == "")
                        CardNo = GetEmpCard(EmpSysID, CardUseTimes);
                    else
                    {
                        CardNoX = GetEmpCard(EmpSysID, CardUseTimes);
                        if ((CardNoX != "") && (CardNo != CardNoX)) CardNo = CardNoX;
                    }
                    if (SFType == 0) SFType = SFAmount <= 0 ? 1 : 10;
                    MacSNStr = MacSN.ToString();
                    if (SFType == 10 || SFType == 20)
                    {
                        MealTypeID = 0;
                        MacSNStr = "";
                    }
                    sql.Add(Pub.GetSQL(DBCode.DB_004005, new string[] { "7", EmpSysID,CardNo, SFType.ToString(),
            SFDate.ToString(SystemInfo.SQLDateTimeFMT), SFAmount.ToString(), SFCardBalance.ToString(),
            MealTypeID.ToString(), MacSNStr, "0", CardUseTimes.ToString(), "", "",BTAmount.ToString(), BTBalance.ToString() }));
                }
                if (db.ExecSQL(sql) == 0) ret = true;
            }
            formCode = "DMMain";
            return ret;
        }

        private string GetEmpCard(string EmpSysID, int CardUseTimes)
        {
            string ret = "";
            DataTableReader dr = null;
            int times = 0;
            switch (SystemInfo.DBType)
            {
                case 1:
                case 2:
                    times = CardUseTimes - 1;
                    dr = db.GetDataReader("SELECT CardNo FROM SF_SFData WHERE EmpSysID='" +
                      EmpSysID + "' AND CardUseTimes=" + times.ToString());
                    if (dr.Read())
                        ret = dr["CardNo"].ToString();
                    else
                    {
                        times = CardUseTimes + 1;
                        dr = db.GetDataReader("SELECT CardNo FROM SF_SFData WHERE EmpSysID='" +
                          EmpSysID + "' AND CardUseTimes=" + times.ToString());
                        if (dr.Read())
                            ret = dr["CardNo"].ToString();
                        else
                        {
                            dr = db.GetDataReader("SELECT CardNo FROM SF_SFData WHERE EmpSysID='" +
                              EmpSysID + "' AND CardUseTimes<" + CardUseTimes.ToString());
                            if (dr.Read())
                                ret = dr["CardNo"].ToString();
                            else
                            {
                                dr = db.GetDataReader("SELECT CardNo FROM SF_SFData WHERE EmpSysID='" +
                                  EmpSysID + "' AND CardUseTimes>" + CardUseTimes.ToString());
                                if (dr.Read()) ret = dr["CardNo"].ToString();
                            }
                        }
                    }
                    break;
            }
            formCode = "DMMain";
            return ret;
        }

        private void RefreshForm()
        {
            findGrid.Enabled = !IsWorking;
            alGrid.Enabled = !IsWorking;
            button1.Enabled = !IsWorking && (alGrid.RowCount > 0);
            txtEmpNo.Enabled = !IsWorking;
            button2.Enabled = button1.Enabled;
            dataGrid.Enabled = !IsWorking;
            button3.Enabled = !IsWorking && (dataGrid.RowCount > 0);
            button4.Enabled = !IsWorking;
            button5.Enabled = !IsWorking;
            button6.Enabled = !IsWorking;
            button7.Enabled = !IsWorking;
            button8.Enabled = !IsWorking;
            button11.Enabled = !IsWorking;
            button12.Enabled = !IsWorking;
            groupBox3.Enabled = !IsWorking && (findGrid.RowCount > 0);
        }

        private void FindLoseData(bool WriteData)
        {
            lblRecInfoA.Text = "";
            lblRecInfoA.Text = "";
            bool ret = false;
            IsWorking = true;
            RefreshForm();
            findGrid.DataSource = null;
            alGrid.DataSource = null;
            dataGrid.DataSource = null;
            DataTable dt = null;
            DataTable dt1 = null;
            DataTable dtData = null;
            string sql = "";
            string EmpSysID = "";
            lblMsg.Text = "0/0  0";
            progBar.Value = 0;
            Application.DoEvents();
            string EmpNo = txtEmpNo.Text.Trim();
            if (EmpNo != "") EmpNo = " AND EmpNo='" + EmpNo + "'";
            int FindCount = 0;
            try
            {
                switch (SystemInfo.DBType)
                {
                    case 1:
                    case 2:
                        sql = "SELECT * FROM VRS_EmpSf WHERE CardStatusID<>'10'" + EmpNo + " ORDER BY EmpNo";
                        break;
                }
                dt = db.GetDataTable(sql);
                sql = "";
                dtData = new DataTable();
                dtData.Columns.Add("EmpSysID", typeof(string));
                dtData.Columns.Add("EmpNo", typeof(string));
                dtData.Columns.Add("EmpName", typeof(string));
                dtData.Columns.Add("CardNo", typeof(string));
                dtData.Columns.Add("CardDifference", typeof(double));
                dtData.Columns.Add("CardDifferenceBT", typeof(double));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    EmpSysID = dt.Rows[i]["EmpSysID"].ToString();
                    switch (SystemInfo.DBType)
                    {
                        case 1:
                        case 2:
                            dt1 = GetFindRecord(EmpSysID);
                            break;
                    }
                    if ((dt1 != null) && (dt1.Rows.Count > 0))
                    {
                        if (WriteData)
                        {
                            ret = BatchWriteRecord(EmpSysID);
                            if (!ret) break;
                        }
                        else
                            dtData.Rows.Add(EmpSysID, dt1.Rows[0]["EmpNo"], dt1.Rows[0]["EmpName"], dt1.Rows[0]["CardNo"], dt1.Rows[0]["money"]/*,dt1.Rows[0]["moneyBT"]*/);
                        FindCount++;
                    }
                    lblMsg.Text = string.Format("{0}/{1}  {2}", i + 1, dt.Rows.Count, FindCount);
                    progBar.Value = (i + 1) * 100 / dt.Rows.Count;
                    if (!IsWorking) break;
                    Application.DoEvents();
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E, sql);
            }
            finally
            {
                if (dt != null) dt.Reset();
                if (dt1 != null) dt1.Reset();
            }
            findGrid.DataSource = dtData;
            if (WriteData && ret) findGrid_Click(null, null);
            IsWorking = false;
            RefreshForm();
            formCode = "DMMain";
        }

        private void alGrid_SelectionChanged(object sender, EventArgs e)
        {
            lblRecInfoA.Text = "";
            if (alGrid.SelectedRows.Count > 0)
            {
                lblRecInfoA.Text = string.Format("{0}/{1}", alGrid.SelectedRows[0].Index + 1, alGrid.RowCount);
            }
            formCode = "DMMain";
        }

        private void dataGrid_SelectionChanged(object sender, EventArgs e)
        {
            lblRecInfoB.Text = "";
            if (dataGrid.SelectedRows.Count > 0)
            {
                lblRecInfoB.Text = string.Format("{0}/{1}", dataGrid.SelectedRows[0].Index + 1, dataGrid.RowCount);
            }
            formCode = "DMMain";
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button3_Click(null, null);
        }

        private void dataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                button3_Click(null, null);
        }
    }
}