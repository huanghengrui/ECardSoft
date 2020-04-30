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
    public partial class frmPubDesign : frmBaseForm
    {
        private GridppReport Report = null;
        private GridppReport desReport = null;
        private string title = "";
        private string reportFile = "";
        private string TableName = "";
        private string reportName = "";

        private void AddToolbarButton(string text, Image image, EventHandler onClick)
        {
            toolBar.Items.Add(text, image, onClick);
            toolBar.Items[toolBar.Items.Count - 1].DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            toolBar.Items[toolBar.Items.Count - 1].TextImageRelation = TextImageRelation.ImageAboveText;
        }

        private void AddToolbarSeparator()
        {
            toolBar.Items.Add(new ToolStripSeparator());
        }

        protected override void InitForm()
        {
            formCode = "PubDesign";
            base.InitForm();
            this.Text = title;
            Rectangle rect = Screen.PrimaryScreen.WorkingArea;
            this.Left = rect.Left;
            this.Top = rect.Top;
            this.Width = rect.Width;
            this.Height = rect.Height;
            this.WindowState = FormWindowState.Maximized;
            Pub.SetFormAppIcon(this);
            AddToolbarButton(mnuFileSave.Text, mnuFileSave.Image, mnuFileSave_Click);
            AddToolbarSeparator();
            AddToolbarButton(mnuFileExit.Text, mnuFileExit.Image, mnuFileExit_Click);
            AddToolbarSeparator();
            AddToolbarButton(mnuEditUndo.Text, mnuEditUndo.Image, mnuEditUndo_Click);
            AddToolbarButton(mnuEditRedo.Text, mnuEditRedo.Image, mnuEditRedo_Click);
            AddToolbarSeparator();
            AddToolbarButton(mnuEditCut.Text, mnuEditCut.Image, mnuEditCut_Click);
            AddToolbarButton(mnuEditCopy.Text, mnuEditCopy.Image, mnuEditCopy_Click);
            AddToolbarButton(mnuEditPaste.Text, mnuEditPaste.Image, mnuEditPaste_Click);
            AddToolbarButton(mnuEditDelete.Text, mnuEditDelete.Image, mnuEditDelete_Click);
            AddToolbarButton(mnuEditAll.Text, mnuEditAll.Image, mnuEditAll_Click);
            grd.OnlyLayout = false;
            grd.ShowExplorer = true;
            grd.ShowInspector = true;
            string filename = Pub.GetTempPathFileName("report.tmp");
            if (File.Exists(filename)) File.Delete(filename);
            Report.SaveToFile(filename);
            desReport = new GridppReport();
            desReport.LoadFromFile(filename);
            if (File.Exists(filename)) File.Delete(filename);
            desReport.Language = Report.Language;
            if (desReport.ColumnByName("CheckBox") != null) desReport.ColumnByName("CheckBox").Visible = true;
            grd.Report = desReport;
            grd.Reload();
        }

        public frmPubDesign(GridppReport report, string Title, string ReportFile, string ReportTableName, string ReportName)
        {
            Report = report;
            title = Title;
            reportFile = ReportFile;
            TableName = ReportTableName;
            reportName = ReportName;
            InitializeComponent();
        }

        private void mnuFileSave_Click(object sender, EventArgs e)
        {
           
            bool IsError = false;
            DataTableReader dr = null;
            string sql = desReport.DetailGrid.Recordset.QuerySQL;
            desReport.DetailGrid.Recordset.QuerySQL = "";
            desReport.DetailGrid.Recordset.ConnectionString = "";
            try
            {
                if (grd.Dirty) grd.Post();
                if ((reportFile != "") && (File.Exists(reportFile)))
                {
                    desReport.SaveToFile(reportFile);
                    if (!Report.Running) Report.LoadFromFile(reportFile);
                }
                else if (TableName != "")
                {
                    if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "302", TableName, reportName }));
                    if (dr.Read())
                    {
                        string reportData = desReport.SaveToStr();
                        if (!db.UpdateTextData(Pub.GetSQL(DBCode.DB_000001, new string[] { "303", TableName, reportName }),
                          "ReportData", reportData)) IsError = true;
                        if (!Report.Running) Report.LoadFromStr(reportData);
                    }
                }
            }
            catch (Exception E)
            {
                IsError = true;
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                desReport.DetailGrid.Recordset.QuerySQL = sql;
                desReport.DetailGrid.Recordset.ConnectionString = SystemInfo.ConnStrReport;
                if (dr != null) dr.Close();
                dr = null;
            }
            if (!IsError)
            {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "Msg001", ""), MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuEditUndo_Click(object sender, EventArgs e)
        {
           
            grd.DoAction(grdesLib.GRDesignerAction.grdaEditUndo);
        }

        private void mnuEditRedo_Click(object sender, EventArgs e)
        {
           
            grd.DoAction(grdesLib.GRDesignerAction.grdaEditRedo);
        }

        private void mnuEditCut_Click(object sender, EventArgs e)
        {
            
            grd.DoAction(grdesLib.GRDesignerAction.grdaEditCut);
        }

        private void mnuEditCopy_Click(object sender, EventArgs e)
        {
            
            grd.DoAction(grdesLib.GRDesignerAction.grdaEditCopy);
        }

        private void mnuEditPaste_Click(object sender, EventArgs e)
        {
           
            grd.DoAction(grdesLib.GRDesignerAction.grdaEditPaste);
        }

        private void mnuEditDelete_Click(object sender, EventArgs e)
        {
          
            grd.DoAction(grdesLib.GRDesignerAction.grdaEditDelete);
        }

        private void mnuEditAll_Click(object sender, EventArgs e)
        {
           
            grd.DoAction(grdesLib.GRDesignerAction.grdaEditSelectAll);
        }

        private void mnuViewObject_Click(object sender, EventArgs e)
        {
           
            mnuViewObject.Checked = !mnuViewObject.Checked;
            grd.ShowExplorer = mnuViewObject.Checked;
        }

        private void mnuViewProperty_Click(object sender, EventArgs e)
        {
          
            mnuViewProperty.Checked = !mnuViewProperty.Checked;
            grd.ShowInspector = mnuViewProperty.Checked;
        }

        private void mnuReportPage_Click(object sender, EventArgs e)
        {
           
            grd.DoAction(grdesLib.GRDesignerAction.grdaReportPaperSetting);
        }

        private void mnuReportParamets_Click(object sender, EventArgs e)
        {
           
            grd.DoAction(grdesLib.GRDesignerAction.grdaReportParameterCollection);
        }

        private void mnuReportQuery_Click(object sender, EventArgs e)
        {
            
            grd.DoAction(grdesLib.GRDesignerAction.grdaSetupDBQuery);
        }

        private void mnuReportFiled_Click(object sender, EventArgs e)
        {
            
            grd.DoAction(grdesLib.GRDesignerAction.grdaReportFieldCollection);
        }

        private void mnuReportGroup_Click(object sender, EventArgs e)
        {
           
            grd.DoAction(grdesLib.GRDesignerAction.grdaReportGroupCollection);
        }

        private void mnuReportCol_Click(object sender, EventArgs e)
        {
           
            grd.DoAction(grdesLib.GRDesignerAction.grdaReportColumnCollection);
        }

        private void mnuReportColTitle_Click(object sender, EventArgs e)
        {
            
            grd.DoAction(grdesLib.GRDesignerAction.grdaReportColumnTitleLayout);
        }

        private void mnuReportQueryDisplay_Click(object sender, EventArgs e)
        {
            
            grd.DoAction(grdesLib.GRDesignerAction.grdaSetupParamDBQuery);
        }
    }
}