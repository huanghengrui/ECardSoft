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
    public partial class frmPubReportWizard : frmBaseDialog
    {
        public string ReportName = "";
        private string ReportTable = "";

        private string SelectTableName = "";
        private string SelectReportName = "";

        protected override void InitForm()
        {
            formCode = "PubReportWizard";
            base.InitForm();
            this.Text = Title;
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tabPage1);
            tabControl1.SelectedTab = tabPage1;
            LoadDataTable();
            RefreshForm();
            RadioButton_CheckedChanged(null, null);
        }

        public frmPubReportWizard(string title, string reportTable)
        {
            Title = title;
            ReportName = "";
            ReportTable = reportTable;
            InitializeComponent();
        }

        private void LoadDataTable()
        {
            cbbTable.Items.Clear();
            DataTableReader dr = null;
            TCommonType ctype;
            string na;
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { "401", ReportTable.Substring(0, 3),
          SystemInfo.DatabaseName }));
                while (dr.Read())
                {
                    na = dr["name"].ToString();
                    ctype = new TCommonType(na, na, Pub.GetResText(formCode, na, ""));
                    cbbTable.Items.Add(ctype);
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
            if (cbbTable.Items.Count > 0) cbbTable.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MoveGridField(fdGrid, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MoveGridField(fdGrid, false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SelectField(true);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SelectField(false);
        }

        private void SelectField(bool state)
        {
            for (int i = 0; i < fdGrid.RowCount; i++)
            {
                fdGrid[0, i].Value = state;
            }
        }

        private void MoveGridField(DataGridView grid, bool IsUp)
        {
            int row = 0;
            if (grid.SelectedRows.Count > 0) row = grid.SelectedRows[0].Index;
            grid.Rows[row].Selected = true;
            if (IsUp)
            {
                if (row <= 0) return;
            }
            else
            {
                if (row >= grid.RowCount - 1) return;
            }
            int rowx = IsUp ? -1 : 1;
            rowx += row;
            bool sl = (bool)grid[0, rowx].Value;
            string fd = grid[1, rowx].Value.ToString();
            string fc = grid[2, rowx].Value.ToString();
            string ft = grid[3, rowx].Value.ToString();
            grid[0, rowx].Value = grid[0, row].Value;
            grid[1, rowx].Value = grid[1, row].Value;
            grid[2, rowx].Value = grid[2, row].Value;
            grid[3, rowx].Value = grid[3, row].Value;
            grid[0, row].Value = sl;
            grid[1, row].Value = fd;
            grid[2, row].Value = fc;
            grid[3, row].Value = ft;
            grid.Rows[rowx].Selected = true;
            grid.CurrentCell = grid.Rows[rowx].Cells[0];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage6)
            {
                tabControl1.TabPages.Clear();
                tabControl1.TabPages.Add(tabPage5);
            }
            else if (tabControl1.SelectedTab == tabPage5)
            {
                tabControl1.TabPages.Clear();
                tabControl1.TabPages.Add(tabPage4);
            }
            else if (tabControl1.SelectedTab == tabPage4)
            {
                tabControl1.TabPages.Clear();
                tabControl1.TabPages.Add(tabPage3);
            }
            else if (tabControl1.SelectedTab == tabPage3)
            {
                tabControl1.TabPages.Clear();
                tabControl1.TabPages.Add(tabPage2);
            }
            else if (tabControl1.SelectedTab == tabPage2)
            {
                tabControl1.TabPages.Clear();
                tabControl1.TabPages.Add(tabPage1);
            }
            RefreshForm();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                SelectReportName = txtName.Text.Trim();
                if (SelectReportName == "")
                {
                    txtName.Focus();
                    ShowErrorEnterCorrect(label2.Text);
                    return;
                }
                if (!Pub.CheckTextMaxLength(label2.Text, SelectReportName, txtName.MaxLength))
                {
                    txtName.Focus();
                    return;
                }
                if (cbbTable.SelectedIndex == -1)
                {
                    cbbTable.Focus();
                    ShowErrorSelectCorrect(label3.Text);
                    return;
                }
                SelectTableName = ((TCommonType)cbbTable.Items[cbbTable.SelectedIndex]).id;
                if (!LoadSource()) return;
                tabControl1.TabPages.Clear();
                tabControl1.TabPages.Add(tabPage2);
            }
            else if (tabControl1.SelectedTab == tabPage2)
            {
                if (GetGridCount(fdGrid) == 0)
                {
                    fdGrid.Focus();
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", ""));
                    return;
                }
                LoadGroup();
                tabControl1.TabPages.Clear();
                tabControl1.TabPages.Add(tabPage3);
            }
            else if (tabControl1.SelectedTab == tabPage3)
            {
                tabControl1.TabPages.Clear();
                tabControl1.TabPages.Add(tabPage4);
            }
            else if (tabControl1.SelectedTab == tabPage4)
            {
                tabControl1.TabPages.Clear();
                tabControl1.TabPages.Add(tabPage5);
            }
            else if (tabControl1.SelectedTab == tabPage5)
            {
                tabControl1.TabPages.Clear();
                tabControl1.TabPages.Add(tabPage6);
            }
            tabControl1.SelectedTab = tabControl1.TabPages[0];
            RefreshForm();
        }

        private void RefreshForm()
        {
            button5.Enabled = tabControl1.SelectedTab != tabPage1;
            button6.Enabled = tabControl1.SelectedTab != tabPage6;
        }

        private bool LoadSource()
        {
            bool ret = false;
            fdGrid.Rows.Clear();
            DataTable dt = null;
            string na;
            try
            {
                dt = db.GetDataTable(Pub.GetSQL(DBCode.DB_000002, new string[] { "402", ReportTable, SelectTableName }));
                ret = dt.Rows.Count == 0;
                if (!ret)
                {
                    txtName.Focus();
                    ShowErrorCannotRepeated(label2.Text);
                }
                if (ret)
                {
                    dt = db.GetDataTable(Pub.GetSQL(DBCode.DB_000002, new string[] { "403", SelectTableName }));
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        na = dt.Columns[i].ColumnName;
                        fdGrid.Rows.Add();
                        fdGrid[0, fdGrid.RowCount - 1].Value = true;
                        fdGrid[1, fdGrid.RowCount - 1].Value = na;
                        fdGrid[2, fdGrid.RowCount - 1].Value = Pub.GetResText(formCode, na, "");
                        fdGrid[3, fdGrid.RowCount - 1].Value = dt.Columns[i].DataType.Name;
                    }
                }
            }
            catch (Exception E)
            {
                ret = false;
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                if (dt != null) dt.Reset();
            }
            return ret;
        }

        private void LoadGroup()
        {
            gpGrid.Rows.Clear();
            orGrid.Rows.Clear();
            smGrid.Rows.Clear();
            cbbTime1.Items.Clear();
            cbbTime2.Items.Clear();
            cbbTime3.Items.Clear();
            TCommonType ctype;
            for (int i = 0; i < fdGrid.RowCount; i++)
            {
                if ((bool)fdGrid[0, i].EditedFormattedValue)
                {
                    gpGrid.Rows.Add();
                    orGrid.Rows.Add();
                    smGrid.Rows.Add();
                    for (int j = 1; j < fdGrid.ColumnCount; j++)
                    {
                        gpGrid[j, gpGrid.RowCount - 1].Value = fdGrid[j, i].Value;
                        orGrid[j, gpGrid.RowCount - 1].Value = fdGrid[j, i].Value;
                        smGrid[j, smGrid.RowCount - 1].Value = fdGrid[j, i].Value;
                    }
                    ctype = new TCommonType(fdGrid[1, i].Value.ToString(), fdGrid[1, i].Value.ToString(), fdGrid[2, i].Value.ToString());
                    switch (fdGrid[3, i].Value.ToString().ToLower())
                    {
                        case "datetime":
                            cbbTime1.Items.Add(ctype);
                            cbbTime2.Items.Add(ctype);
                            break;
                        case "string":
                            cbbTime3.Items.Add(ctype);
                            break;
                    }
                }
            }
            if (cbbTime1.Items.Count > 0) cbbTime1.SelectedIndex = 0;
            if (cbbTime2.Items.Count > 0) cbbTime2.SelectedIndex = 0;
            if (cbbTime3.Items.Count > 0) cbbTime3.SelectedIndex = 0;
        }

        private int GetGridCount(DataGridView grid)
        {
            int ret = 0;
            for (int i = 0; i < grid.RowCount; i++)
            {
                if ((bool)grid[0, i].EditedFormattedValue) ret += 1;
            }
            return ret;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            
            if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "Msg001", ""))) return;
            bool IsOk = true;
            GridppReport Report = new GridppReport();
            IGRMemoBox memoBox;
            IGRStaticBox staticBox;
            IGRGroup group = null;
            GRFieldType ft;
            IGRField grField;
            IGRColumn grCol;
            IGRFieldBox fieldBox;
            IGRSummaryBox sumBox;
            GRSummaryFun grSum;
            string groupField = "";
            string fn = "";
            string fnEx = "";
            string fr = "";
            string FirstFieldName = "";
            bool IsFirstField = true;
            int l = 0;
            byte DateFlag = 0;
            string DateField = "";
            if (radioButton3.Checked && (cbbTime2.SelectedIndex >= 0))
            {
                DateFlag = 1;
                DateField = ((TCommonType)cbbTime2.Items[cbbTime2.SelectedIndex]).id;
            }
            else if (radioButton2.Checked && (cbbTime1.SelectedIndex >= 0))
            {
                DateFlag = 2;
                DateField = ((TCommonType)cbbTime1.Items[cbbTime1.SelectedIndex]).id;
            }
            else if (radioButton4.Checked && (cbbTime3.SelectedIndex >= 0))
            {
                DateFlag = 3;
                DateField = ((TCommonType)cbbTime3.Items[cbbTime3.SelectedIndex]).id;
            }
            try
            {
                Report.Clear();
                Report.Font.Point = 9;
                Report.Printer.LeftMargin = 0.5;
                Report.Printer.TopMargin = 0.5;
                Report.Printer.RightMargin = 0.5;
                Report.Printer.BottomMargin = 0.5;
                //页眉
                Report.InsertPageHeader();
                Report.PageHeader.Height = 0.8;
                staticBox = Report.PageHeader.Controls.Add(GRControlType.grctStaticBox).AsStaticBox;
                staticBox.Dock = GRDockStyle.grdsLeft;
                staticBox.Name = "StaticBoxCommany";
                staticBox.TextAlign = GRTextAlign.grtaBottomLeft;
                staticBox.Width = 9;
                memoBox = Report.PageHeader.Controls.Add(GRControlType.grctMemoBox).AsMemoBox;
                memoBox.Dock = GRDockStyle.grdsRight;
                memoBox.Text = "[#SystemVar(CurrentDateTime)#] [#SystemVar(PageNumber)#]/[#SystemVar(PageCount)#]";
                memoBox.TextAlign = GRTextAlign.grtaBottomRight;
                memoBox.Width = 9;
                //页尾
                Report.InsertReportFooter();
                Report.get_ReportFooter(1).Height = 0;
                //报表头
                Report.InsertReportHeader();
                Report.get_ReportHeader(1).Height = 0.8;
                Report.get_ReportHeader(1).RepeatOnPage = true;
                IGRLine line = Report.get_ReportHeader(1).Controls.Add(GRControlType.grctLine).AsLine;
                line.Dock = GRDockStyle.grdsTop;
                staticBox = Report.get_ReportHeader(1).Controls.Add(GRControlType.grctStaticBox).AsStaticBox;
                staticBox.Name = "MainTitleBox";
                staticBox.Center = GRCenterStyle.grcsHorizontal;
                staticBox.ForeColor = Pub.ColorToOleColor(Color.Red);
                staticBox.TextAlign = GRTextAlign.grtaBottomCenter;
                staticBox.Font.Bold = true;
                staticBox.Font.Point = 16;
                staticBox.Text = SelectReportName;
                staticBox.Height = 0.71;
                staticBox.Dock = GRDockStyle.grdsTop;
                staticBox = Report.get_ReportHeader(1).Controls.Add(GRControlType.grctStaticBox).AsStaticBox;
                if (DateField != "")
                {
                    Report.get_ReportHeader(1).Height = 1.4;
                    staticBox.Name = "StaticBoxDate";
                    staticBox.Center = GRCenterStyle.grcsHorizontal;
                    staticBox.TextAlign = GRTextAlign.grtaMiddleCenter;
                    staticBox.Font.Point = 9;
                    staticBox.Text = SelectReportName;
                    staticBox.Height = 0.5;
                    staticBox.Dock = GRDockStyle.grdsBottom;
                }
                //明细网格
                Report.InsertDetailGrid();
                Report.DetailGrid.BorderColor = Pub.ColorToOleColor(Color.FromArgb(192, 192, 192));
                Report.DetailGrid.ColLineColor = Pub.ColorToOleColor(Color.FromArgb(192, 192, 192));
                Report.DetailGrid.RowLineColor = Pub.ColorToOleColor(Color.FromArgb(192, 192, 192));
                Report.DetailGrid.ColumnTitle.Height = 0.61;
                Report.DetailGrid.ColumnContent.Height = 0.61;
                Report.DetailGrid.ColumnTitle.RepeatStyle = GRRepeatStyle.grrsOnPage;
                //分组
                if (GetGridCount(gpGrid) > 0)
                {
                    group = Report.DetailGrid.Groups.Add();
                    group.Header.Height = 0.61;
                    for (int i = 0; i < gpGrid.RowCount; i++)
                    {
                        if ((bool)gpGrid[0, i].EditedFormattedValue)
                        {
                            fn = gpGrid[2, i].Value.ToString();
                            if (fn == "") fn = gpGrid[1, i].Value.ToString();
                            groupField = groupField + fn + ";";
                        }
                    }
                    groupField = groupField.Substring(0, groupField.Length - 1);
                }
                for (int i = 0; i < fdGrid.RowCount; i++)
                {
                    if ((bool)fdGrid[0, i].EditedFormattedValue)
                    {
                        fn = fdGrid[1, i].Value.ToString();
                        fr = "";
                        switch (fdGrid[3, i].Value.ToString().ToLower())
                        {
                            case "string":
                                ft = GRFieldType.grftString;
                                break;
                            case "datetime":
                                ft = GRFieldType.grftDateTime;
                                break;
                            case "byte":
                                ft = GRFieldType.grftInteger;
                                fr = "0;;#";
                                break;
                            case "double":
                                ft = GRFieldType.grftCurrency;
                                fr = "￥#,##0.00";
                                break;
                            default:
                                ft = GRFieldType.grftString;
                                break;
                        }
                        grField = Report.DetailGrid.Recordset.AddField(fn, ft);
                        grField.Format = fr;
                        fnEx = fdGrid[2, i].Value.ToString();
                        if (fnEx == "") fnEx = fn;
                        grField.Name = fnEx;
                        grField.DBFieldName = fn;
                        string tmp = groupField + ";";
                        if (tmp.IndexOf(fnEx + ";") == -1)
                        {
                            grCol = Report.DetailGrid.AddColumn(fnEx, fn, fnEx, 2);
                            grCol.TitleCell.Text = fnEx;
                            grCol.TitleCell.BackColor = Pub.ColorToOleColor(Color.FromArgb(128, 255, 128));
                            grCol.TitleCell.TextAlign = GRTextAlign.grtaMiddleCenter;
                            if (IsFirstField)
                            {
                                FirstFieldName = fnEx;
                                IsFirstField = false;
                            }
                        }
                    }
                }
                //分组
                if ((groupField != "") && (group != null))
                {
                    group.ByFields = groupField;
                    l = 0;
                    for (int i = 0; i < gpGrid.RowCount; i++)
                    {
                        if ((bool)gpGrid[0, i].EditedFormattedValue)
                        {
                            fn = gpGrid[2, i].Value.ToString();
                            if (fn == "") fn = gpGrid[1, i].Value.ToString();
                            fieldBox = group.Header.Controls.Add(GRControlType.grctFieldBox).AsFieldBox;
                            fieldBox.DataField = fn;
                            fieldBox.Left = l;
                            fieldBox.Top = 0;
                            fieldBox.Width = 2;
                            fieldBox.Height = 0.61;
                            fieldBox.ForeColor = Pub.ColorToOleColor(Color.FromArgb(0, 0, 128));
                            l += 2;
                        }
                    }
                }
                //合计
                if (GetGridCount(smGrid) > 0)
                {
                    Report.get_ReportFooter(1).Height = 0.61;
                    staticBox = Report.get_ReportFooter(1).Controls.Add(GRControlType.grctStaticBox).AsStaticBox;
                    staticBox.Name = "StaticBoxSum";
                    staticBox.Text = Pub.GetResText(formCode, staticBox.Name, "");
                    staticBox.Font.Bold = true;
                    staticBox.BorderColor = Pub.ColorToOleColor(Color.FromArgb(192, 192, 192));
                    staticBox.Left = 0;
                    staticBox.Height = 0.61;
                    staticBox.AlignColumn = FirstFieldName;
                    staticBox.Width = 2;
                    if (groupField != "")
                    {
                        group.Footer.Height = 0.61;
                        staticBox = group.Footer.Controls.Add(GRControlType.grctStaticBox).AsStaticBox;
                        staticBox.Name = "StaticBoxSumMin";
                        staticBox.Text = Pub.GetResText(formCode, staticBox.Name, "");
                        staticBox.Font.Bold = true;
                        staticBox.BorderColor = Pub.ColorToOleColor(Color.FromArgb(192, 192, 192));
                        staticBox.Left = 0;
                        staticBox.Height = 0.61;
                        staticBox.AlignColumn = FirstFieldName;
                        staticBox.Width = 2;
                    }
                    for (int i = 0; i < smGrid.RowCount; i++)
                    {
                        if ((bool)smGrid[0, i].EditedFormattedValue)
                        {
                            fn = smGrid[2, i].Value.ToString();
                            if (fn == "") fn = smGrid[1, i].Value.ToString();
                            sumBox = Report.get_ReportFooter(1).Controls.Add(GRControlType.grctSummaryBox).AsSummaryBox;
                            switch (smGrid[3, i].Value.ToString().ToLower())
                            {
                                case "byte":
                                case "double":
                                    grSum = GRSummaryFun.grsfSum;
                                    break;
                                default:
                                    grSum = GRSummaryFun.grsfCount;
                                    break;
                            }
                            sumBox.SummaryFun = grSum;
                            sumBox.DataField = fn;
                            sumBox.AlignColumn = fn;
                            if (groupField != "")
                            {
                                sumBox = group.Footer.Controls.Add(GRControlType.grctSummaryBox).AsSummaryBox;
                                sumBox.SummaryFun = grSum;
                                sumBox.DataField = fn;
                                sumBox.AlignColumn = fn;
                            }
                        }
                    }
                }
                string OrderFields = "";
                for (int i = 0; i < orGrid.RowCount; i++)
                {
                    if ((bool)orGrid[0, i].EditedFormattedValue)
                    {
                        OrderFields = OrderFields + orGrid[1, i].Value.ToString() + ",";
                    }
                }
                if (OrderFields != "") OrderFields = OrderFields.Substring(0, OrderFields.Length - 1);
                string sql = Pub.GetSQL(DBCode.DB_000001, new string[] { "603", ReportTable, SelectReportName,
          SelectTableName, OrderFields, DateFlag.ToString(), DateField });
                db.ExecSQL(sql);
                string reportData = Report.SaveToStr();
                db.UpdateTextData(Pub.GetSQL(DBCode.DB_000001, new string[] { "303", ReportTable,
          SelectReportName }), "ReportData", reportData);
                ReportName = SelectReportName;
            }
            catch (Exception E)
            {
                IsOk = false;
                Pub.ShowErrorMsg(E);
            }
            if (!IsOk) return;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            cbbTime1.Enabled = radioButton2.Checked;
            cbbTime2.Enabled = radioButton3.Checked;
            cbbTime3.Enabled = radioButton4.Checked;
        }
    }
}