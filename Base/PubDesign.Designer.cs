namespace ECard78
{
  partial class frmPubDesign
  {
    /// <summary>
    /// 必需的设计器变量。
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// 清理所有正在使用的资源。
    /// </summary>
    /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows 窗体设计器生成的代码

    /// <summary>
    /// 设计器支持所需的方法 - 不要
    /// 使用代码编辑器修改此方法的内容。
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPubDesign));
      this.menuBar = new System.Windows.Forms.MenuStrip();
      this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuFileLine1 = new System.Windows.Forms.ToolStripSeparator();
      this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuEditUndo = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuEditRedo = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuEditLine1 = new System.Windows.Forms.ToolStripSeparator();
      this.mnuEditCut = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuEditCopy = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuEditPaste = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuEditDelete = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuEditAll = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuViewObject = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuViewProperty = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuReport = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuReportPage = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuReportParamets = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuReportLine1 = new System.Windows.Forms.ToolStripSeparator();
      this.mnuReportQuery = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuReportFiled = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuReportGroup = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuReportCol = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuReportColTitle = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuReportLine2 = new System.Windows.Forms.ToolStripSeparator();
      this.mnuReportQueryDisplay = new System.Windows.Forms.ToolStripMenuItem();
      this.toolBar = new System.Windows.Forms.ToolStrip();
      this.grd = new AxgrdesLib.AxGRDesigner();
      this.menuBar.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
      this.SuspendLayout();
      // 
      // menuBar
      // 
      this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEdit,
            this.mnuView,
            this.mnuReport});
      this.menuBar.Location = new System.Drawing.Point(0, 0);
      this.menuBar.Name = "menuBar";
      this.menuBar.Size = new System.Drawing.Size(554, 24);
      this.menuBar.TabIndex = 0;
      this.menuBar.Text = "menuStrip1";
      // 
      // mnuFile
      // 
      this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileSave,
            this.mnuFileLine1,
            this.mnuFileExit});
      this.mnuFile.Name = "mnuFile";
      this.mnuFile.Size = new System.Drawing.Size(59, 20);
      this.mnuFile.Text = "mnuFile";
      // 
      // mnuFileSave
      // 
      this.mnuFileSave.Image = ((System.Drawing.Image)(resources.GetObject("mnuFileSave.Image")));
      this.mnuFileSave.ImageTransparentColor = System.Drawing.Color.White;
      this.mnuFileSave.Name = "mnuFileSave";
      this.mnuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
      this.mnuFileSave.Size = new System.Drawing.Size(153, 22);
      this.mnuFileSave.Text = "mnuSave";
      this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
      // 
      // mnuFileLine1
      // 
      this.mnuFileLine1.Name = "mnuFileLine1";
      this.mnuFileLine1.Size = new System.Drawing.Size(150, 6);
      // 
      // mnuFileExit
      // 
      this.mnuFileExit.Image = ((System.Drawing.Image)(resources.GetObject("mnuFileExit.Image")));
      this.mnuFileExit.ImageTransparentColor = System.Drawing.Color.White;
      this.mnuFileExit.Name = "mnuFileExit";
      this.mnuFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
      this.mnuFileExit.Size = new System.Drawing.Size(153, 22);
      this.mnuFileExit.Text = "mnuExit";
      this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
      // 
      // mnuEdit
      // 
      this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditUndo,
            this.mnuEditRedo,
            this.mnuEditLine1,
            this.mnuEditCut,
            this.mnuEditCopy,
            this.mnuEditPaste,
            this.mnuEditDelete,
            this.mnuEditAll});
      this.mnuEdit.Name = "mnuEdit";
      this.mnuEdit.Size = new System.Drawing.Size(59, 20);
      this.mnuEdit.Text = "mnuEdit";
      // 
      // mnuEditUndo
      // 
      this.mnuEditUndo.Image = ((System.Drawing.Image)(resources.GetObject("mnuEditUndo.Image")));
      this.mnuEditUndo.ImageTransparentColor = System.Drawing.Color.White;
      this.mnuEditUndo.Name = "mnuEditUndo";
      this.mnuEditUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
      this.mnuEditUndo.Size = new System.Drawing.Size(189, 22);
      this.mnuEditUndo.Text = "mnuEditUpDo";
      this.mnuEditUndo.Click += new System.EventHandler(this.mnuEditUndo_Click);
      // 
      // mnuEditRedo
      // 
      this.mnuEditRedo.Image = ((System.Drawing.Image)(resources.GetObject("mnuEditRedo.Image")));
      this.mnuEditRedo.ImageTransparentColor = System.Drawing.Color.White;
      this.mnuEditRedo.Name = "mnuEditRedo";
      this.mnuEditRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
      this.mnuEditRedo.Size = new System.Drawing.Size(189, 22);
      this.mnuEditRedo.Text = "mnuEditReboot";
      this.mnuEditRedo.Click += new System.EventHandler(this.mnuEditRedo_Click);
      // 
      // mnuEditLine1
      // 
      this.mnuEditLine1.Name = "mnuEditLine1";
      this.mnuEditLine1.Size = new System.Drawing.Size(186, 6);
      // 
      // mnuEditCut
      // 
      this.mnuEditCut.Image = ((System.Drawing.Image)(resources.GetObject("mnuEditCut.Image")));
      this.mnuEditCut.ImageTransparentColor = System.Drawing.Color.White;
      this.mnuEditCut.Name = "mnuEditCut";
      this.mnuEditCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
      this.mnuEditCut.Size = new System.Drawing.Size(189, 22);
      this.mnuEditCut.Text = "mnuEditCut";
      this.mnuEditCut.Click += new System.EventHandler(this.mnuEditCut_Click);
      // 
      // mnuEditCopy
      // 
      this.mnuEditCopy.Image = ((System.Drawing.Image)(resources.GetObject("mnuEditCopy.Image")));
      this.mnuEditCopy.ImageTransparentColor = System.Drawing.Color.White;
      this.mnuEditCopy.Name = "mnuEditCopy";
      this.mnuEditCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
      this.mnuEditCopy.Size = new System.Drawing.Size(189, 22);
      this.mnuEditCopy.Text = "mnuEditCopy";
      this.mnuEditCopy.Click += new System.EventHandler(this.mnuEditCopy_Click);
      // 
      // mnuEditPaste
      // 
      this.mnuEditPaste.Image = ((System.Drawing.Image)(resources.GetObject("mnuEditPaste.Image")));
      this.mnuEditPaste.ImageTransparentColor = System.Drawing.Color.White;
      this.mnuEditPaste.Name = "mnuEditPaste";
      this.mnuEditPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
      this.mnuEditPaste.Size = new System.Drawing.Size(189, 22);
      this.mnuEditPaste.Text = "mnuEditPaste";
      this.mnuEditPaste.Click += new System.EventHandler(this.mnuEditPaste_Click);
      // 
      // mnuEditDelete
      // 
      this.mnuEditDelete.Image = global::ECard78.Properties.Resources.Delete;
      this.mnuEditDelete.ImageTransparentColor = System.Drawing.Color.White;
      this.mnuEditDelete.Name = "mnuEditDelete";
      this.mnuEditDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
      this.mnuEditDelete.Size = new System.Drawing.Size(189, 22);
      this.mnuEditDelete.Text = "mnuEditDelete";
      this.mnuEditDelete.Click += new System.EventHandler(this.mnuEditDelete_Click);
      // 
      // mnuEditAll
      // 
      this.mnuEditAll.Image = global::ECard78.Properties.Resources.EditSelectAll;
      this.mnuEditAll.ImageTransparentColor = System.Drawing.Color.White;
      this.mnuEditAll.Name = "mnuEditAll";
      this.mnuEditAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
      this.mnuEditAll.Size = new System.Drawing.Size(189, 22);
      this.mnuEditAll.Text = "mnuEditAll";
      this.mnuEditAll.Click += new System.EventHandler(this.mnuEditAll_Click);
      // 
      // mnuView
      // 
      this.mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewObject,
            this.mnuViewProperty});
      this.mnuView.Name = "mnuView";
      this.mnuView.Size = new System.Drawing.Size(59, 20);
      this.mnuView.Text = "mnuView";
      // 
      // mnuViewObject
      // 
      this.mnuViewObject.Checked = true;
      this.mnuViewObject.CheckState = System.Windows.Forms.CheckState.Checked;
      this.mnuViewObject.Name = "mnuViewObject";
      this.mnuViewObject.Size = new System.Drawing.Size(160, 22);
      this.mnuViewObject.Text = "mnuViewObject";
      this.mnuViewObject.Click += new System.EventHandler(this.mnuViewObject_Click);
      // 
      // mnuViewProperty
      // 
      this.mnuViewProperty.Checked = true;
      this.mnuViewProperty.CheckState = System.Windows.Forms.CheckState.Checked;
      this.mnuViewProperty.Name = "mnuViewProperty";
      this.mnuViewProperty.Size = new System.Drawing.Size(160, 22);
      this.mnuViewProperty.Text = "mnuViewProperty";
      this.mnuViewProperty.Click += new System.EventHandler(this.mnuViewProperty_Click);
      // 
      // mnuReport
      // 
      this.mnuReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuReportPage,
            this.mnuReportParamets,
            this.mnuReportLine1,
            this.mnuReportQuery,
            this.mnuReportFiled,
            this.mnuReportGroup,
            this.mnuReportCol,
            this.mnuReportColTitle,
            this.mnuReportLine2,
            this.mnuReportQueryDisplay});
      this.mnuReport.Name = "mnuReport";
      this.mnuReport.Size = new System.Drawing.Size(71, 20);
      this.mnuReport.Text = "mnuReport";
      // 
      // mnuReportPage
      // 
      this.mnuReportPage.Name = "mnuReportPage";
      this.mnuReportPage.Size = new System.Drawing.Size(196, 22);
      this.mnuReportPage.Text = "mnuReportPage";
      this.mnuReportPage.Click += new System.EventHandler(this.mnuReportPage_Click);
      // 
      // mnuReportParamets
      // 
      this.mnuReportParamets.Name = "mnuReportParamets";
      this.mnuReportParamets.Size = new System.Drawing.Size(196, 22);
      this.mnuReportParamets.Text = "mnuReportParamets";
      this.mnuReportParamets.Click += new System.EventHandler(this.mnuReportParamets_Click);
      // 
      // mnuReportLine1
      // 
      this.mnuReportLine1.Name = "mnuReportLine1";
      this.mnuReportLine1.Size = new System.Drawing.Size(193, 6);
      // 
      // mnuReportQuery
      // 
      this.mnuReportQuery.Name = "mnuReportQuery";
      this.mnuReportQuery.Size = new System.Drawing.Size(196, 22);
      this.mnuReportQuery.Text = "mnuReportQuery";
      this.mnuReportQuery.Click += new System.EventHandler(this.mnuReportQuery_Click);
      // 
      // mnuReportFiled
      // 
      this.mnuReportFiled.Name = "mnuReportFiled";
      this.mnuReportFiled.Size = new System.Drawing.Size(196, 22);
      this.mnuReportFiled.Text = "mnuReportFiled";
      this.mnuReportFiled.Click += new System.EventHandler(this.mnuReportFiled_Click);
      // 
      // mnuReportGroup
      // 
      this.mnuReportGroup.Name = "mnuReportGroup";
      this.mnuReportGroup.Size = new System.Drawing.Size(196, 22);
      this.mnuReportGroup.Text = "mnuReportGroup";
      this.mnuReportGroup.Click += new System.EventHandler(this.mnuReportGroup_Click);
      // 
      // mnuReportCol
      // 
      this.mnuReportCol.Name = "mnuReportCol";
      this.mnuReportCol.Size = new System.Drawing.Size(196, 22);
      this.mnuReportCol.Text = "mnuReportCol";
      this.mnuReportCol.Click += new System.EventHandler(this.mnuReportCol_Click);
      // 
      // mnuReportColTitle
      // 
      this.mnuReportColTitle.Name = "mnuReportColTitle";
      this.mnuReportColTitle.Size = new System.Drawing.Size(196, 22);
      this.mnuReportColTitle.Text = "mnuReportColTitle";
      this.mnuReportColTitle.Click += new System.EventHandler(this.mnuReportColTitle_Click);
      // 
      // mnuReportLine2
      // 
      this.mnuReportLine2.Name = "mnuReportLine2";
      this.mnuReportLine2.Size = new System.Drawing.Size(193, 6);
      // 
      // mnuReportQueryDisplay
      // 
      this.mnuReportQueryDisplay.Name = "mnuReportQueryDisplay";
      this.mnuReportQueryDisplay.Size = new System.Drawing.Size(196, 22);
      this.mnuReportQueryDisplay.Text = "mnuReportQueryDisplay";
      this.mnuReportQueryDisplay.Click += new System.EventHandler(this.mnuReportQueryDisplay_Click);
      // 
      // toolBar
      // 
      this.toolBar.Location = new System.Drawing.Point(0, 24);
      this.toolBar.Name = "toolBar";
      this.toolBar.Size = new System.Drawing.Size(554, 25);
      this.toolBar.TabIndex = 1;
      this.toolBar.Text = "toolStrip1";
      // 
      // grd
      // 
      this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grd.Enabled = true;
      this.grd.Location = new System.Drawing.Point(0, 49);
      this.grd.Name = "grd";
      this.grd.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("grd.OcxState")));
      this.grd.Size = new System.Drawing.Size(554, 279);
      this.grd.TabIndex = 2;
      // 
      // frmPubDesign
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(554, 328);
      this.Controls.Add(this.grd);
      this.Controls.Add(this.toolBar);
      this.Controls.Add(this.menuBar);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MainMenuStrip = this.menuBar;
      this.MaximizeBox = true;
      this.Name = "frmPubDesign";
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "";
      this.menuBar.ResumeLayout(false);
      this.menuBar.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuBar;
    private System.Windows.Forms.ToolStripMenuItem mnuFile;
    private System.Windows.Forms.ToolStripMenuItem mnuFileSave;
    private System.Windows.Forms.ToolStripSeparator mnuFileLine1;
    private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
    private System.Windows.Forms.ToolStripMenuItem mnuEdit;
    private System.Windows.Forms.ToolStripMenuItem mnuEditUndo;
    private System.Windows.Forms.ToolStripMenuItem mnuEditRedo;
    private System.Windows.Forms.ToolStripSeparator mnuEditLine1;
    private System.Windows.Forms.ToolStripMenuItem mnuEditCut;
    private System.Windows.Forms.ToolStripMenuItem mnuEditCopy;
    private System.Windows.Forms.ToolStripMenuItem mnuEditPaste;
    private System.Windows.Forms.ToolStripMenuItem mnuEditDelete;
    private System.Windows.Forms.ToolStripMenuItem mnuEditAll;
    private System.Windows.Forms.ToolStripMenuItem mnuView;
    private System.Windows.Forms.ToolStripMenuItem mnuViewObject;
    private System.Windows.Forms.ToolStripMenuItem mnuViewProperty;
    private System.Windows.Forms.ToolStripMenuItem mnuReport;
    private System.Windows.Forms.ToolStripMenuItem mnuReportPage;
    private System.Windows.Forms.ToolStripMenuItem mnuReportParamets;
    private System.Windows.Forms.ToolStripSeparator mnuReportLine1;
    private System.Windows.Forms.ToolStripMenuItem mnuReportQuery;
    private System.Windows.Forms.ToolStripMenuItem mnuReportFiled;
    private System.Windows.Forms.ToolStripMenuItem mnuReportGroup;
    private System.Windows.Forms.ToolStripMenuItem mnuReportCol;
    private System.Windows.Forms.ToolStripMenuItem mnuReportColTitle;
    private System.Windows.Forms.ToolStripSeparator mnuReportLine2;
    private System.Windows.Forms.ToolStripMenuItem mnuReportQueryDisplay;
    private System.Windows.Forms.ToolStrip toolBar;
    private AxgrdesLib.AxGRDesigner grd;
  }
}
