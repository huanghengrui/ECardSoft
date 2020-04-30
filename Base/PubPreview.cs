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
    public partial class frmPubPreview : frmBaseForm
    {
        private GridppReport Report = null;
        private string title = "";
        private string reportFile = "";
        private string TableName = "";
        private string reportName = "";
        private string StrPosition = "";
        private bool AllowDesignReport = false;

        protected override void InitForm()
        {
            formCode = "PubPreview";
            base.InitForm();
            this.Text = this.Text + "[" + title + "]";
            Rectangle rect = Screen.PrimaryScreen.WorkingArea;
            this.Left = rect.Left;
            this.Top = rect.Top;
            this.Width = rect.Width;
            this.Height = rect.Height;
            this.WindowState = FormWindowState.Maximized;
            ItemReportEdit.Enabled = AllowDesignReport;
            ItemReportEdit.Visible = ItemReportEdit.Enabled;
            ItemLine2.Visible = ItemReportEdit.Enabled;
            StrPosition = Pub.GetResText(formCode, "ItemPosition", "");
            printView.Report = Report;
            printView.Start();
            ItemFit_Click(null, null);
            Pub.SetFormAppIcon(this);
        }

        public frmPubPreview(GridppReport report, string Title, string ReportFile, string ReportTableName, string ReportName,
          bool DesignReport)
        {
            Report = report;
            title = Title;
            reportFile = ReportFile;
            TableName = ReportTableName;
            reportName = ReportName;
            AllowDesignReport = DesignReport;
            InitializeComponent();
        }

        private void printView_StatusChange(object sender, EventArgs e)
        {
            lblRecordState.Text = string.Format(StrPosition, printView.CurPageNo, printView.PageCount);
        }

        private void ItemPrint_Click(object sender, EventArgs e)
        {
            printView.Print(true);
        }

        private void ItemSetup_Click(object sender, EventArgs e)
        {
            if (printView.Report.Printer.PageSetupDialog()) printView.Refresh();
        }

        private void ItemReportEdit_Click(object sender, EventArgs e)
        {
            frmPubDesign frm = new frmPubDesign(Report, ItemReportEdit.Text + "[" + title + "]", reportFile, TableName, reportName);
            bool ret = (frm.ShowDialog() == DialogResult.OK);
            if (ret)
            {
                string ConnStr = Report.DetailGrid.Recordset.ConnectionString;
                string sql = Report.DetailGrid.Recordset.QuerySQL;
                try
                {
                    printView.Stop();
                    Report.LoadFromFile(reportFile);
                    Report.DetailGrid.Recordset.ConnectionString = ConnStr;
                    Report.DetailGrid.Recordset.QuerySQL = sql;
                    printView.Start();
                }
                catch
                {
                }
                finally
                {
                    printView.Refresh();
                }
            }
           
        }

        private void ItemZoomIn_Click(object sender, EventArgs e)
        {
            printView.ZoomIn();
        }

        private void ItemZoomOut_Click(object sender, EventArgs e)
        {
            printView.ZoomOut();
        }

        private void ItemFit_Click(object sender, EventArgs e)
        {
            printView.ZoomToFit();
            ItemFit.CheckState = CheckState.Checked;
            ItemWidth.CheckState = CheckState.Unchecked;
            ItemHeight.CheckState = CheckState.Unchecked;
        }

        private void ItemWidth_Click(object sender, EventArgs e)
        {
            printView.ZoomToWidth();
            ItemFit.CheckState = CheckState.Unchecked;
            ItemWidth.CheckState = CheckState.Checked;
            ItemHeight.CheckState = CheckState.Unchecked;
        }

        private void ItemHeight_Click(object sender, EventArgs e)
        {
            printView.ZoomToHeight();
            ItemFit.CheckState = CheckState.Unchecked;
            ItemWidth.CheckState = CheckState.Unchecked;
            ItemHeight.CheckState = CheckState.Checked;
        }

        private void ItemFirst_Click(object sender, EventArgs e)
        {
            printView.FirstPage();
        }

        private void ItemPrior_Click(object sender, EventArgs e)
        {
            printView.PriorPage();
        }

        private void ItemNext_Click(object sender, EventArgs e)
        {
            printView.NextPage();
        }

        private void ItemLast_Click(object sender, EventArgs e)
        {
            printView.LastPage();
        }

        private void ItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}