using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using grproLib;

namespace ECard78
{
    public partial class frmSFAllowance : frmBaseMDIChild
    {
        private GridppReport Report = new GridppReport();
        private GridppReport Report1 = new GridppReport();
        private string ReportFile = "";
        private string ReportFile1 = "";
        private bool IsFirst = true;
        private string QuerySQL1 = "";
        private string FindSQL = "";
        private string FindSQL1 = "";
        private string FindOrderBy = "";

        protected override void InitForm()
        {
            formCode = "SFAllowance";
            switch (Application.CurrentCulture.LCID)
            {
                case 0x804:
                    Report.Language = 0x804;
                    break;
                case 0x404:
                case 0x0c04:
                case 0x1004:
                case 0x1404:
                    Report.Language = 0x404;
                    break;
                default:
                    Report.Language = 0x0409;
                    break;
            }
            Report1.Language = Report.Language;
            ReportFile = SystemInfo.ReportPath + "SFAllowance.grf";
            ReportFile1 = SystemInfo.ReportPath + "SFAllowanceHistory.grf";
            if ((ReportFile != "") && File.Exists(ReportFile))
            {
                try
                {
                    Report.Register(SystemInfo.ReportRegister);
                    Report.LoadFromFile(ReportFile);
                    Report.DetailGrid.Recordset.ConnectionString = SystemInfo.ConnStrReport;
                    Report.DetailGrid.Recordset.QuerySQL = "";
                    Report.ShowProgressUI = false;
                    ShowReportHeader(false);
                    Report.FetchRecord -= new _IGridppReportEvents_FetchRecordEventHandler(ProductListFetchRecord);
                    Report.FetchRecord += new _IGridppReportEvents_FetchRecordEventHandler(ProductListFetchRecord);
                    dispView.Report = Report;
                    //指示查询显示控件分批获取数据
                    dispView.BatchGetRecord = true;
                    dispView.BatchWantRecords = 0;

                    //指示查询显示控件显示出工具栏，并按分页方式显示数据
                    dispView.ShowToolbar = true;
                    dispView.RowsPerPage = 0;
                    dispView.Start();
                }
                catch (Exception E)
                {
                    Pub.ShowErrorMsg(E);
                }
            }
            if ((ReportFile1 != "") && File.Exists(ReportFile1))
            {
                try
                {
                    Report1.Register(SystemInfo.ReportRegister);
                    Report1.LoadFromFile(ReportFile1);
                    Report1.DetailGrid.Recordset.ConnectionString = SystemInfo.ConnStrReport;
                    Report1.DetailGrid.Recordset.QuerySQL = "";
                    Report1.ShowProgressUI = false;
                    ShowReportHeader(false);
                    Report1.FetchRecord -= new _IGridppReportEvents_FetchRecordEventHandler(ProductListFetchRecord1);
                    Report1.FetchRecord += new _IGridppReportEvents_FetchRecordEventHandler(ProductListFetchRecord1);
                    dispView1.Report = Report1;
                    //指示查询显示控件分批获取数据
                    dispView1.BatchGetRecord = true;
                    dispView1.BatchWantRecords = 0;

                    //指示查询显示控件显示出工具栏，并按分页方式显示数据
                    dispView1.ShowToolbar = true;
                    dispView1.RowsPerPage = 0;
                    dispView1.Start();
                }
                catch (Exception E)
                {
                    Pub.ShowErrorMsg(E);
                }
            }
            AddExtDropDownItem("ItemSetupDisplay", ItemSetupDisplay_Click);
            SetToolItemState("ItemTAG1", true);
            SetToolItemState("ItemTAGExt", true);
            SetToolItemState("ItemLine3", true);
            SetToolItemState("ItemSearch", true);
            AddExtDropDownItem("BatchAllowance", BatchAllowance_Click);
            IgnoreSelect = true;
            base.InitForm();
            QuerySQL = Pub.GetSQL(DBCode.DB_004006, new string[] { "0", OprtInfo.DepartPower });
            QuerySQL1 = Pub.GetSQL(DBCode.DB_004006, new string[] { "1", OprtInfo.DepartPower });
            FindSQL = Pub.GetSQL(DBCode.DB_004006, new string[] { "2", OprtInfo.DepartPower });
            FindSQL1 = Pub.GetSQL(DBCode.DB_004006, new string[] { "3", OprtInfo.DepartPower });
            FindOrderBy = Pub.GetSQL(DBCode.DB_004006, new string[] { "4" });
            if (SystemInfo.AllowanceCardType)
                ImportFieldList = new string[] { "EmpNo", "CardType", "AllowanceFlag", "AllowanceWayName", "AllowanceAmount" };
            else
                ImportFieldList = new string[] { "EmpNo", "AllowanceFlag", "AllowanceWayName", "AllowanceAmount" };
            ImportShowCount = true;
            clbAllowanceStatus.Items.Clear();
            clbAllowanceStatus1.Items.Clear();
            TCommonType cType;
            DataTableReader dr = null;
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004006, new string[] { "21" }));
                while (dr.Read())
                {
                    cType = new TCommonType(dr["AllowanceStatusID"].ToString(), dr["AllowanceStatusID"].ToString(),
                      dr["AllowanceStatusName"].ToString(), true);
                    clbAllowanceStatus.Items.Add(cType);
                    clbAllowanceStatus1.Items.Add(cType);
                    clbAllowanceStatus.SetItemChecked(clbAllowanceStatus.Items.Count - 1, false);
                    clbAllowanceStatus1.SetItemChecked(clbAllowanceStatus1.Items.Count - 1, false);
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
            chkAllowanceStatus_CheckedChanged(null, null);
            chkAllowanceStatus1_CheckedChanged(null, null);
            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
            dtpEnd.Value = DateTime.Now.Date;
            dtpStart1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
            dtpEnd1.Value = DateTime.Now.Date;
        }

        public frmSFAllowance()
        {
            InitializeComponent();
        }

        private void ProductListFetchRecord()
        {
            DataTable data = null;
            try
            {
                if (QuerySQL != "")
                {
                    dispView.Report.DetailGrid.Recordset.Empty();
                    Report.DetailGrid.Recordset.Empty();
                    data = db.GetDataTable(QuerySQL);

                    FillRecordToReport(dispView.Report, data);
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
        }

        private void ProductListFetchRecord1()
        {
            DataTable data = null;
            try
            {
                if (QuerySQL1 != "")
                {
                    dispView1.Report.DetailGrid.Recordset.Empty();
                    Report1.DetailGrid.Recordset.Empty();
                    data = db.GetDataTable(QuerySQL1);

                    FillRecordToReport(dispView1.Report, data);
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
        }

        protected override void ExecItemExport()
        {
            ShowReportHeader(true);
            if (tabControl1.SelectedIndex == 0)
                ExportToXLS(Report, this.Text, SystemInfo.AppPath + this.Text + "[" + tabPage1.Text + "]" + ".xls");
            else
                ExportToXLS(Report1, this.Text, SystemInfo.AppPath + this.Text + "[" + tabPage2.Text + "]" + ".xls");
            ShowReportHeader(false);
        }

        protected override void ExecItemPrint()
        {
            ShowReportHeader(true);
            if (tabControl1.SelectedIndex == 0)
            {
                frmPubPreview frm = new frmPubPreview(Report, this.Text + "[" + tabPage1.Text + "]", ReportFile, "", "", false);
                frm.ShowDialog();
            }
            else
            {
                frmPubPreview frm = new frmPubPreview(Report1, this.Text + "[" + tabPage2.Text + "]", ReportFile1, "", "", false);
                frm.ShowDialog();
            }
            ShowReportHeader(false);
           
        }

        protected override void ExecItemAdd()
        {
            if (CheckAllowance()) return;
            frmSFAllowanceAdd frm = new frmSFAllowanceAdd(this.Text, CurrentTool);
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
           
        }

        protected override void ExecItemEdit()
        {
            //if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "Msg001", ""))) return;
            SystemInfo.IsGetData = false;
            frmSFMacData frm1 = new frmSFMacData(1, CurrentTool);
            frm1.ShowDialog();
            if (!db.IsGetDate()) return;
           
            string GUID = "";
            if (CheckAllowanceStatus("Error110", ref GUID) != 0) return;
            frmSFAllowanceEdit frm = new frmSFAllowanceEdit(this.Text, CurrentTool, GUID);
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
           
        }

        protected override void ExecItemDelete()
        {

            // if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "Msg002", ""))) return;
            SystemInfo.IsGetData = false;
            frmSFMacData frm1 = new frmSFMacData(1, CurrentTool);
            frm1.ShowDialog();
            if (!db.IsGetDate()) return;

            string GUID = "";
            if (CheckAllowanceStatus("Error111", ref GUID) != 0) return;
            string sql = Pub.GetSQL(DBCode.DB_004006, new string[] { "16", GUID });
            string msg = Report.FieldByName("EmpNo").AsString + '[' + Report.FieldByName("AllowanceFlag").AsString +
              "  " + Report.FieldByName("AllowanceAmountSum").AsString + "]";
            try
            {
                db.ExecSQL(sql);
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E, sql);
                return;
            }
            db.WriteSYLog(this.Text, CurrentTool, msg + "[" + sql + "]");
            dispView.Refresh();
            //dispView1.Refresh();
            dispView1.Stop();
            dispView1.Start();

            RefreshForm(true);
            Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgDeleteSucceed", ""), MessageBoxIcon.Information);

        }
        protected override void ExecItemTAG1()
        {
            frmSFAllowanceDown frm = new frmSFAllowanceDown(this.Text, CurrentTool);
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
            
        }

        protected override void ExecItemSearch()
        {
            List<string> FieldText = new List<string>();
            List<string> FieldName = new List<string>();
            List<GRFieldType> FieldType = new List<GRFieldType>();
            string s = "";
            string FindKeyWord = formCode;
            if (tabControl1.SelectedIndex == 0)
            {
                for (int i = 1; i <= Report.DetailGrid.Columns.Count; i++)
                {
                    if (Report.DetailGrid.Columns[i].TitleCell.FreeCell) continue;
                    s = Report.DetailGrid.Columns[i].TitleCell.Text;
                    if (Report.DetailGrid.Columns[i].TitleCell.SupCell != null)
                        s = Report.DetailGrid.Columns[i].TitleCell.SupCell.Text + s;
                    FieldText.Add(s);
                    s = Report.DetailGrid.Columns[i].ContentCell.DataField;
                    FieldName.Add(s);
                    FieldType.Add(Report.FieldByName(s).FieldType);
                }
                frmPubFind frm = new frmPubFind(this.Text + "[" + CurrentTool + "]", FindSQL, FindOrderBy,
                  FindKeyWord, FieldText, FieldName, FieldType, false);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    QuerySQL = frm.QuerySQL;
                    ExecItemRefresh();
                }
            }
            else
            {
                FindKeyWord += "History";
                for (int i = 1; i <= Report1.DetailGrid.Columns.Count - 1; i++)
                {
                    if (Report1.DetailGrid.Columns[i].TitleCell.FreeCell) continue;
                    s = Report1.DetailGrid.Columns[i].TitleCell.Text;
                    if (Report1.DetailGrid.Columns[i].TitleCell.SupCell != null)
                        s = Report1.DetailGrid.Columns[i].TitleCell.SupCell.Text + s;
                    FieldText.Add(s);
                    s = Report1.DetailGrid.Columns[i].ContentCell.DataField;
                    FieldName.Add(s);
                    FieldType.Add(Report1.FieldByName(s).FieldType);
                }
                frmPubFind frm = new frmPubFind(this.Text + "[" + CurrentTool + "]", FindSQL1, FindOrderBy,
                  FindKeyWord, FieldText, FieldName, FieldType, false);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    QuerySQL1 = frm.QuerySQL;
                    ExecItemRefresh();
                }
            }
           
        }

        protected override void ExecItemRefresh()
        {
            DateTime StartTime = DateTime.Now;
            contextMenu.Close();
            int row = -1;
            RefreshMsg(StrReading);
            if (tabControl1.SelectedIndex == 0)
            {
                if (QuerySQL != "")
                {
                    dispView.Report.DetailGrid.Recordset.QuerySQL = QuerySQL;
                    try
                    {
                        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                        row = dispView.SelRowNo;
                        dispView.Stop();
                        dispView.Start();
                        Application.DoEvents();
                    }
                    catch (Exception E)
                    {
                        Pub.ShowErrorMsg(E, QuerySQL);
                    }
                    finally
                    {
                        if (row < dispView.RowCount)
                            dispView.SelRowNo = row;
                        else if (dispView.RowCount > 0)
                            dispView.SelRowNo = dispView.RowCount - 1;
                    }
                }
                SetReportTitle(dispView, tabPage1.Text);
            }
            else
            {
                if (QuerySQL1 != "")
                {
                    dispView1.Report.DetailGrid.Recordset.QuerySQL = QuerySQL1;
                    try
                    {
                        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                        row = dispView1.SelRowNo;
                        //dispView1.Refresh();
                        dispView1.Stop();
                        dispView1.Start();
                        Application.DoEvents();
                    }
                    catch (Exception E)
                    {
                        Pub.ShowErrorMsg(E, QuerySQL1);
                    }
                    finally
                    {
                        if (row < dispView1.RowCount)
                            dispView1.SelRowNo = row;
                        else if (dispView1.RowCount > 0)
                            dispView1.SelRowNo = dispView1.RowCount - 1;
                    }
                }
                SetReportTitle(dispView1, tabPage2.Text);
            }
            RefreshForm(true);
            RefreshMsg(StrReadEnd + Pub.GetDateDiffTimes(StartTime, DateTime.Now, true), true);
        }

        protected override void RefreshForm(bool State)
        {
            int row = 0;
            int rows = 0;
            ItemLine1.Visible = true;
            bool isHis = false;
            if (tabControl1.SelectedIndex == 0)
            {
                row = dispView.SelRowNo;
                try
                {
                    rows = dispView.RowCount;
                    if (rows > 0) row = row + 1;
                }
                catch
                {
                }
                finally
                {
                }
            }
            else
            {
                isHis = true;
                row = dispView1.SelRowNo;
                try
                {
                    rows = dispView1.RowCount;
                    if (rows > 0) row = row + 1;
                }
                catch
                {
                }
                finally
                {
                }
            }
            if (row < 0) row = 0;
            ItemImport.Enabled = State && !isHis;
            ItemExport.Enabled = State && (rows > 0);
            ItemPrint.Enabled = State && (rows > 0);
            ItemAdd.Enabled = State && !isHis;
            ItemEdit.Enabled = State && (rows > 0) && !isHis;
            ItemDelete.Enabled = State && (rows > 0) && !isHis;
            ItemTAG1.Enabled = State && (rows > 0);
            ItemTAG2.Enabled = State && (rows > 0);
            ItemTAG3.Enabled = State && (rows > 0);
            ItemTAG4.Enabled = State && (rows > 0);
            ItemTAG5.Enabled = State && (rows > 0);
            ItemTAG6.Enabled = State && (rows > 0);
            ItemTAG7.Enabled = State && (rows > 0);
            ItemTAGExt.Enabled = State;
            for (int i = 0; i < ItemTAGExt.DropDownItems.Count; i++)
            {
                if (ItemTAGExt.DropDownItems[i].Name == "ItemSetupDisplay")
                    ItemTAGExt.DropDownItems[i].Enabled = State;
                else
                    ItemTAGExt.DropDownItems[i].Enabled = State && (rows > 0);
                if (ItemTAGExt.DropDownItems[i].Name == "BatchAllowance")
                    ItemTAGExt.DropDownItems[i].Enabled = ItemAdd.Enabled;
            }
            ItemSelect.Enabled = State && (rows > 0);
            ItemUnselect.Enabled = State && (rows > 0);
            ItemRefresh.Enabled = State;
            ItemSearch.Enabled = State;

            SetContextMenuState();
            lblRecordState.Text = string.Format(StrPosition, row, rows);
        }

        private void dispView_ColumnLayoutChange(object sender, EventArgs e)
        {
            string sql = Report.DetailGrid.Recordset.QuerySQL;
            dispView.PostColumnLayout();
            Report.DetailGrid.Recordset.ConnectionString = "";
            Report.DetailGrid.Recordset.QuerySQL = "";
            Report.SaveToFile(ReportFile);
            Report.DetailGrid.Recordset.ConnectionString = SystemInfo.ConnStrReport;
            Report.DetailGrid.Recordset.QuerySQL = sql;
        }

        private void dispView_ContentCellDblClick(object sender, AxgrproLib._IGRDisplayViewerEvents_ContentCellDblClickEvent e)
        {
            if (ItemEdit.Enabled) ItemEdit.PerformClick();
        }

        private void dispView_SelectionCellChange(object sender, AxgrproLib._IGRDisplayViewerEvents_SelectionCellChangeEvent e)
        {
            RefreshForm(true);
        }

        private void dispView_MouseDownEvent(object sender, AxgrproLib._IGRDisplayViewerEvents_MouseDownEvent e)
        {
            if (e.button == GRMouseButton.grmbRight) contextMenu.Show(dispView, e.xPos, e.yPos);
        }

        private void dispView1_ColumnLayoutChange(object sender, EventArgs e)
        {
            string sql = Report1.DetailGrid.Recordset.QuerySQL;
            dispView1.PostColumnLayout();
            Report1.DetailGrid.Recordset.ConnectionString = "";
            Report1.DetailGrid.Recordset.QuerySQL = "";
            Report1.SaveToFile(ReportFile1);
            Report1.DetailGrid.Recordset.ConnectionString = SystemInfo.ConnStrReport;
            Report1.DetailGrid.Recordset.QuerySQL = sql;
        }

        private void dispView1_SelectionCellChange(object sender, AxgrproLib._IGRDisplayViewerEvents_SelectionCellChangeEvent e)
        {
            RefreshForm(true);
        }

        private void dispView1_MouseDownEvent(object sender, AxgrproLib._IGRDisplayViewerEvents_MouseDownEvent e)
        {
            if (e.button == GRMouseButton.grmbRight) contextMenu.Show(dispView1, e.xPos, e.yPos);
        }

        private void frmSFAllowance_Activated(object sender, EventArgs e)
        {
            if (IsFirst)
            {
                IsFirst = false;
                ExecItemRefresh();
            }
        }

        private void ItemSetupDisplay_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                frmPubDisplay frm = new frmPubDisplay(Report, this.Text + "[" + ((ToolStripItem)sender).Text + "]", 1);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dispView.Refresh();
                    dispView_ColumnLayoutChange(null, null);
                }
            }
            else
            {
                frmPubDisplay frm = new frmPubDisplay(Report1, this.Text + "[" + ((ToolStripItem)sender).Text + "]", 1);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dispView1.Stop();
                    dispView1.Start();
                    dispView1_ColumnLayoutChange(null, null);
                }
            }
            
        }

        private void ShowReportHeader(bool state)
        {
            for (int j = 1; j <= Report.ReportHeaderCount; j++)
            {
                Report.get_ReportHeader(j).Visible = state;
            }
            for (int j = 1; j <= Report1.ReportHeaderCount; j++)
            {
                Report1.get_ReportHeader(j).Visible = state;
            }
        }

        public override bool ProcessImportData(DataRow row, List<string> sys, List<string> src, string DepartUpSysID,
          ref string ErrorMsg, ref double Sum)
        {
            bool ret = base.ProcessImportData(row, sys, src, DepartUpSysID, ref ErrorMsg, ref Sum);
            string EmpNo = "";
            string CardTypeID = "";
            string AllowanceFlag = "";
            string AllowanceWay = "";
            double AllowanceAmount = 0;
            for (int i = 0; i < sys.Count; i++)
            {
                switch (sys[i])
                {
                    case "EmpNo":
                        EmpNo = row[src[i]].ToString();
                        break;
                    case "CardType":
                        CardTypeID = row[src[i]].ToString();
                        break;
                    case "AllowanceFlag":
                        AllowanceFlag = row[src[i]].ToString();
                        break;
                    case "AllowanceWayName":
                        AllowanceWay = row[src[i]].ToString();
                        break;
                    case "AllowanceAmount":
                        double.TryParse(row[src[i]].ToString(), out AllowanceAmount);
                        break;
                }
            }
            if (EmpNo == "")
            {
                ErrorMsg = Pub.GetResText(formCode, "Error101", "");
                return false;
            }
            bool IsError = false;
            DataTableReader dr = null;
            string CardTypeSysID = "";
            string EmpSysID = "";
            List<string> sql = new List<string>();
            sql.Clear();
            bool AllowCount = false;
            try
            {
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "2", EmpNo }));
                if (dr.Read())
                    EmpSysID = dr["EmpSysID"].ToString();
                else
                {
                    ErrorMsg = Pub.GetResText(formCode, "Error102", "");
                    return false;
                }
                if (SystemInfo.AllowanceCardType)
                {
                    if (!Pub.IsNumeric(CardTypeID)) CardTypeID = "0";
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "204", CardTypeID }));
                    if (dr.Read())
                        CardTypeSysID = dr["CardTypeSysID"].ToString();
                    else
                    {
                        dr.Close();
                        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "204", CardTypeID }));
                        if (dr.Read()) CardTypeSysID = dr["CardTypeSysID"].ToString();
                    }
                    if (CardTypeSysID == "")
                    {
                        ErrorMsg = Pub.GetResText(formCode, "Error103", "");
                        return false;
                    }
                }
                DateTime dFlag = new DateTime();
                if (!DateTime.TryParse(AllowanceFlag, out dFlag))
                {
                    ErrorMsg = Pub.GetResText(formCode, "Error104", "");
                    return false;
                }
                if (AllowanceAmount <= 0)
                {
                    ErrorMsg = Pub.GetResText(formCode, "Error105", "");
                    return false;
                }
                AllowanceWay = AllowanceWay.Substring(1, 1);
                int way = 0;
                if (!int.TryParse(AllowanceWay, out way))
                {
                    ErrorMsg = Pub.GetResText(formCode, "Error106", "");
                    return false;
                }
                if ((way < 0) || (way > 2))
                {
                    ErrorMsg = Pub.GetResText(formCode, "Error106", "");
                    return false;
                }
                DateTime dt = new DateTime();
                byte retCheck = db.CheckAllowanceFlag(EmpSysID, dFlag, ref dt);
                if (retCheck == 1)
                {
                    ErrorMsg = string.Format(Pub.GetResText(formCode, "Error107", ""), dt.ToShortDateString());
                    return false;
                }
                else if (retCheck == 2)
                {
                    ErrorMsg = string.Format(Pub.GetResText(formCode, "Error108", ""), dt.ToShortDateString());
                    return false;
                }
                else if (retCheck == 3)
                {
                    ErrorMsg = Pub.GetResText(formCode, "Error109", "");
                    return false;
                }
                sql.Add(Pub.GetSQL(DBCode.DB_004006, new string[] { "7", EmpNo, dFlag.ToString(SystemInfo.SQLDateFMT),
          way.ToString(), AllowanceAmount.ToString() }));
                if (!GetSFAllowance(EmpSysID, dFlag, AllowanceAmount, way, ref sql, ref AllowCount)) return false;
                if (SystemInfo.AllowanceCardType)
                {
                    sql.Add(Pub.GetSQL(DBCode.DB_004006, new string[] { "14", CardTypeSysID, EmpSysID }));
                }
            }
            catch (Exception E)
            {
                IsError = true;
                Pub.ShowErrorMsg(E, sql);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            if (IsError) return false;
            if (db.ExecSQL(sql) != 0) return false;
            db.WriteSYLog(this.Text, CurrentTool, sql);
            ret = true;
            if (AllowCount)
                Sum = Sum + AllowanceAmount;
            else
                ret = false;
            
            return ret;

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshForm(true);
        }

        private byte CheckAllowanceStatus(string msg, ref string GUID)
        {
            byte ret = 0;
            GUID = Report.FieldByName("GUID").AsString;
            DataTableReader dr = null;
            try
            {
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004006, new string[] { "15", GUID }));
                if (dr.Read())
                {
                    int status = 0;
                    int.TryParse(dr["AllowanceStatus"].ToString(), out status);
                    if (status == 1)
                    {
                        ret = 1;
                        Pub.ShowErrorMsg(Pub.GetResText(formCode, msg, ""));
                    }
                }
            }
            catch (Exception E)
            {
                ret = 2;
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }

            return ret;
        }

        private bool CheckAllowance()
        {
            bool ret = false;
            DataTableReader dr = null;
            try
            {
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004006, new string[] { "17" }));
                if (dr.Read()) ret = true;
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
            if (ret)
            {
                //if (!Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "Msg003", ""))) ret = false;
                SystemInfo.IsGetData = false;
                frmSFMacData frm1 = new frmSFMacData(1, CurrentTool);
                frm1.ShowDialog();
                if (!db.IsGetDate()) ret = true;

                else ret = false;
                
            }
           
            return ret;
        }

        private void BatchAllowance_Click(object sender, EventArgs e)
        {
            contextMenu.Close();
            CurrentTool = ((ToolStripItem)sender).Text;
            if (CheckAllowance()) return;
            frmSFBatchAllowance frm = new frmSFBatchAllowance(this.Text, CurrentTool);
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
           
        }


        private void btnSelectEmp_Click(object sender, EventArgs e)
        {
            frmPubSelectEmp frm = new frmPubSelectEmp();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtEmp.Text = frm.EmpName;
                txtEmp.Tag = frm.EmpNo;
            }
           
        }

        private void btnSelectDepart_Click(object sender, EventArgs e)
        {
            frmPubSelectDepart frm = new frmPubSelectDepart();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtDepart.Text = frm.DepartName;
                txtDepart.Tag = frm.DepartID;
            }
           
        }

        private void txtEmp_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtEmp.Tag = null;
        }

        private void txtDepart_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtDepart.Tag = null;
        }

        private void chkAllowanceStatus_CheckedChanged(object sender, EventArgs e)
        {
            clbAllowanceStatus.Enabled = chkAllowanceStatus.Checked;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string EmpTag = "0";
            string EmpNo = "";
            string DepartTag = "0";
            string DepartID = "";
            string DepartList = "";
            string AllowanceStatus = "";
            if ((txtEmp.Text.Trim() != "") && (txtEmp.Tag != null))
            {
                EmpNo = txtEmp.Tag.ToString();
                EmpTag = "1";
            }
            else if (txtEmp.Text.Trim() != "")
            {
                EmpNo = txtEmp.Text.Trim();
            }
            if ((txtDepart.Text.Trim() != "") && (txtDepart.Tag != null))
            {
                DepartID = txtDepart.Tag.ToString();
                DepartTag = "1";
            }
            else if (txtDepart.Text.Trim() != "")
            {
                DepartID = txtDepart.Text.Trim();
            }
            if (DepartTag == "1")
            {
                if (DepartID != "") DepartList = db.GetDepartChildID(DepartID);
                if (DepartList == "") DepartList = "''";
            }
            if (chkAllowanceStatus.Checked)
            {
                for (int i = 0; i < clbAllowanceStatus.Items.Count; i++)
                {
                    if (clbAllowanceStatus.GetItemChecked(i)) AllowanceStatus += "'" + ((TCommonType)clbAllowanceStatus.Items[i]).name + "',";
                }
                if (AllowanceStatus != "") AllowanceStatus = AllowanceStatus.Substring(0, AllowanceStatus.Length - 1);
            }
            QuerySQL1 = Pub.GetSQL(DBCode.DB_004006, new string[] { "22", EmpTag, EmpNo, DepartTag, DepartID, DepartList, AllowanceStatus,
        dtpStart.Value.ToString(SystemInfo.SQLDateFMT), dtpEnd.Value.ToString(SystemInfo.SQLDateFMT), OprtInfo.DepartPower });
            SetReportDate(dispView1, label4.Text + ": " + dtpStart.Value.ToString() + " - " + dtpEnd.Value.ToString());
            ExecItemRefresh();
        }

        private void chkAllowanceStatus1_CheckedChanged(object sender, EventArgs e)
        {
            clbAllowanceStatus1.Enabled = chkAllowanceStatus1.Checked;
        }

        private void btnSelectEmp1_Click(object sender, EventArgs e)
        {
            frmPubSelectEmp frm = new frmPubSelectEmp();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtEmp1.Text = frm.EmpName;
                txtEmp1.Tag = frm.EmpNo;
            }
           
        }

        private void btnSelectDepart1_Click(object sender, EventArgs e)
        {
            frmPubSelectDepart frm = new frmPubSelectDepart();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtDepart1.Text = frm.DepartName;
                txtDepart1.Tag = frm.DepartID;
            }
          
        }

        private void txtEmp1_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtEmp1.Tag = null;
        }

        private void txtDepart1_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtDepart1.Tag = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string EmpTag1 = "0";
            string EmpNo1 = "";
            string DepartTag1 = "0";
            string DepartID1 = "";
            string DepartList1 = "";
            string AllowanceStatus1 = "";
            if ((txtEmp1.Text.Trim() != "") && (txtEmp1.Tag != null))
            {
                EmpNo1 = txtEmp1.Tag.ToString();
                EmpTag1 = "1";
            }
            else if (txtEmp1.Text.Trim() != "")
            {
                EmpNo1 = txtEmp1.Text.Trim();
            }
            if ((txtDepart1.Text.Trim() != "") && (txtDepart1.Tag != null))
            {
                DepartID1 = txtDepart1.Tag.ToString();
                DepartTag1 = "1";
            }
            else if (txtDepart1.Text.Trim() != "")
            {
                DepartID1 = txtDepart1.Text.Trim();
            }
            if (DepartTag1 == "1")
            {
                if (DepartID1 != "") DepartList1 = db.GetDepartChildID(DepartID1);
                if (DepartList1 == "") DepartList1 = "''";
            }
            if (chkAllowanceStatus1.Checked)
            {
                for (int i = 0; i < clbAllowanceStatus1.Items.Count; i++)
                {
                    if (clbAllowanceStatus1.GetItemChecked(i)) AllowanceStatus1 += "'" + ((TCommonType)clbAllowanceStatus1.Items[i]).name + "',";
                }
                if (AllowanceStatus1 != "") AllowanceStatus1 = AllowanceStatus1.Substring(0, AllowanceStatus1.Length - 1);
            }
            QuerySQL = Pub.GetSQL(DBCode.DB_004006, new string[] { "23", EmpTag1, EmpNo1, DepartTag1, DepartID1, DepartList1, AllowanceStatus1,
              dtpStart1.Value.ToString(SystemInfo.SQLDateFMT), dtpEnd1.Value.ToString(SystemInfo.SQLDateFMT), OprtInfo.DepartPower });
            SetReportDate(dispView, label6.Text + ": " + dtpStart1.Value.ToString() + " - " + dtpEnd1.Value.ToString());
            ExecItemRefresh();
        }
        private struct MatchFieldPairType
        {
            public IGRField grField;
            public int MatchColumnIndex;
        }

        // 将 DataReader 的数据转储到 Grid++Report 的数据集中
        public static void FillRecordToReport(IGridppReport Report, IDataReader dr)
        {
            MatchFieldPairType[] MatchFieldPairs = new MatchFieldPairType[Math.Min(Report.DetailGrid.Recordset.Fields.Count, dr.FieldCount)];

            //根据字段名称与列名称进行匹配，建立DataReader字段与Grid++Report记录集的字段之间的对应关系
            int MatchFieldCount = 0;
            for (int i = 0; i < dr.FieldCount; ++i)
            {
                foreach (IGRField fld in Report.DetailGrid.Recordset.Fields)
                {
                    if (String.Compare(fld.RunningDBField, dr.GetName(i), true) == 0)
                    {
                        MatchFieldPairs[MatchFieldCount].grField = fld;
                        MatchFieldPairs[MatchFieldCount].MatchColumnIndex = i;
                        ++MatchFieldCount;
                        break;
                    }
                }
            }


            // Loop through the contents of the OleDbDataReader object.
            // 将 DataReader 中的每一条记录转储到Grid++Report 的数据集中去
            while (dr.Read())
            {
                Report.DetailGrid.Recordset.Append();

                for (int i = 0; i < MatchFieldCount; ++i)
                {
                    if (!dr.IsDBNull(MatchFieldPairs[i].MatchColumnIndex))
                        MatchFieldPairs[i].grField.Value = dr.GetValue(MatchFieldPairs[i].MatchColumnIndex);
                }

                Report.DetailGrid.Recordset.Post();
            }
        }
        /// <summary>
        /// 将 DataTable 的数据转储到 Grid++Report 的数据集中
        /// </summary>
        /// <param name="Report">报表对象</param>
        /// <param name="dt">DataTable对象</param>
        public void FillRecordToReport(IGridppReport report, DataTable dt)
        {
            MatchFieldPairType[] MatchFieldPairs = new MatchFieldPairType[Math.Min(report.DetailGrid.Recordset.Fields.Count, dt.Columns.Count)];
            try
            {
                //根据字段名称与列名称进行匹配，建立DataReader字段与Grid++Report记录集的字段之间的对应关系
                int MatchFieldCount = 0;
                for (int i = 0; i < dt.Columns.Count; ++i)
                {
                    foreach (IGRField fld in report.DetailGrid.Recordset.Fields)
                    {
                        if (string.Compare(fld.Name, dt.Columns[i].ColumnName, true) == 0)
                        {
                            MatchFieldPairs[MatchFieldCount].grField = fld;
                            MatchFieldPairs[MatchFieldCount].MatchColumnIndex = i;
                            ++MatchFieldCount;
                            break;
                        }

                    }
                }

                // 将 DataTable 中的每一条记录转储到 Grid++Report 的数据集中去
                foreach (DataRow dr in dt.Rows)
                {
                    report.DetailGrid.Recordset.Append();
                    for (int i = 0; i < MatchFieldCount; ++i)
                    {
                        var columnIndex = MatchFieldPairs[i].MatchColumnIndex;
                        if (!dr.IsNull(columnIndex))
                        {
                            MatchFieldPairs[i].grField.Value = dr[columnIndex];
                        }
                    }
                    report.DetailGrid.Recordset.Post();

                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                MatchFieldPairs = null;
                dt = null;
                report = null;
            }
        }
    }
}