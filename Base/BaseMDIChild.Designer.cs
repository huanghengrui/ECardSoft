namespace ECard78
{
  partial class frmBaseMDIChild
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseMDIChild));
            this.Toolbar = new System.Windows.Forms.ToolStrip();
            this.ItemImport = new System.Windows.Forms.ToolStripButton();
            this.ItemExport = new System.Windows.Forms.ToolStripButton();
            this.ItemPrint = new System.Windows.Forms.ToolStripButton();
            this.ItemLine1 = new System.Windows.Forms.ToolStripSeparator();
            this.ItemAdd = new System.Windows.Forms.ToolStripButton();
            this.ItemEdit = new System.Windows.Forms.ToolStripButton();
            this.ItemDelete = new System.Windows.Forms.ToolStripButton();
            this.ItemLine2 = new System.Windows.Forms.ToolStripSeparator();
            this.ItemTAG1 = new System.Windows.Forms.ToolStripButton();
            this.ItemTAG9 = new System.Windows.Forms.ToolStripButton();
            this.ItemTAG2 = new System.Windows.Forms.ToolStripButton();
            this.ItemTAG3 = new System.Windows.Forms.ToolStripButton();
            this.ItemTAG4 = new System.Windows.Forms.ToolStripButton();
            this.ItemTAG5 = new System.Windows.Forms.ToolStripButton();
            this.ItemTAG6 = new System.Windows.Forms.ToolStripButton();
            this.ItemTAG8 = new System.Windows.Forms.ToolStripButton();
            this.ItemTAG7 = new System.Windows.Forms.ToolStripButton();
            this.ItemTAGExt = new System.Windows.Forms.ToolStripDropDownButton();
            this.ItemLine3 = new System.Windows.Forms.ToolStripSeparator();
            this.ItemSelect = new System.Windows.Forms.ToolStripButton();
            this.ItemUnselect = new System.Windows.Forms.ToolStripButton();
            this.ItemLine4 = new System.Windows.Forms.ToolStripSeparator();
            this.ItemSearch = new System.Windows.Forms.ToolStripButton();
            this.ItemRefresh = new System.Windows.Forms.ToolStripButton();
            this.ItemLine5 = new System.Windows.Forms.ToolStripSeparator();
            this.ItemlbData = new System.Windows.Forms.ToolStripLabel();
            this.ItemFindLabel = new System.Windows.Forms.ToolStripLabel();
            this.ItemFindText = new System.Windows.Forms.ToolStripTextBox();
            this.ItemLine6 = new System.Windows.Forms.ToolStripSeparator();
            this.ItemZoomIn = new System.Windows.Forms.ToolStripButton();
            this.ItemZoomOut = new System.Windows.Forms.ToolStripButton();
            this.ItemlbDataStartTime = new System.Windows.Forms.ToolStripLabel();
            this.ItemStarTime = new System.Windows.Forms.ToolStripTextBox();
            this.ItemlbDataEndTime = new System.Windows.Forms.ToolStripLabel();
            this.ItemEndTime = new System.Windows.Forms.ToolStripTextBox();
            this.Statusbar = new System.Windows.Forms.StatusStrip();
            this.lblRecordState = new System.Windows.Forms.ToolStripStatusLabel();
            this.progBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lblMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.bindingSource = new System.Windows.Forms.BindingSource();
            this.Toolbar.SuspendLayout();
            this.Statusbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ilTreeState
            // 
            this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
            this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
            this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
            this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
            // 
            // Toolbar
            // 
            this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemImport,
            this.ItemExport,
            this.ItemPrint,
            this.ItemLine1,
            this.ItemAdd,
            this.ItemEdit,
            this.ItemDelete,
            this.ItemLine2,
            this.ItemTAG1,
            this.ItemTAG9,
            this.ItemTAG2,
            this.ItemTAG3,
            this.ItemTAG4,
            this.ItemTAG5,
            this.ItemTAG6,
            this.ItemTAG8,
            this.ItemTAG7,
            this.ItemTAGExt,
            this.ItemLine3,
            this.ItemSelect,
            this.ItemUnselect,
            this.ItemLine4,
            this.ItemSearch,
            this.ItemRefresh,
            this.ItemLine5,
            this.ItemlbData,
            this.ItemFindLabel,
            this.ItemFindText,
            this.ItemLine6,
            this.ItemZoomIn,
            this.ItemZoomOut,
            this.ItemlbDataStartTime,
            this.ItemStarTime,
            this.ItemlbDataEndTime,
            this.ItemEndTime});
            this.Toolbar.Location = new System.Drawing.Point(0, 0);
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.Size = new System.Drawing.Size(423, 25);
            this.Toolbar.TabIndex = 0;
            this.Toolbar.Text = "Toolbar";
            // 
            // ItemImport
            // 
            this.ItemImport.Image = global::ECard78.Properties.Resources.Import;
            this.ItemImport.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemImport.Name = "ItemImport";
            this.ItemImport.Size = new System.Drawing.Size(23, 22);
            this.ItemImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemImport.Click += new System.EventHandler(this.ItemImport_Click);
            // 
            // ItemExport
            // 
            this.ItemExport.Image = global::ECard78.Properties.Resources.Export;
            this.ItemExport.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemExport.Name = "ItemExport";
            this.ItemExport.Size = new System.Drawing.Size(23, 22);
            this.ItemExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemExport.Click += new System.EventHandler(this.ItemExport_Click);
            // 
            // ItemPrint
            // 
            this.ItemPrint.Image = global::ECard78.Properties.Resources.FilePrint;
            this.ItemPrint.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemPrint.Name = "ItemPrint";
            this.ItemPrint.Size = new System.Drawing.Size(23, 22);
            this.ItemPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemPrint.Click += new System.EventHandler(this.ItemPrint_Click);
            // 
            // ItemLine1
            // 
            this.ItemLine1.Name = "ItemLine1";
            this.ItemLine1.Size = new System.Drawing.Size(6, 25);
            // 
            // ItemAdd
            // 
            this.ItemAdd.Image = global::ECard78.Properties.Resources.New;
            this.ItemAdd.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemAdd.Name = "ItemAdd";
            this.ItemAdd.Size = new System.Drawing.Size(23, 22);
            this.ItemAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemAdd.Click += new System.EventHandler(this.ItemAdd_Click);
            // 
            // ItemEdit
            // 
            this.ItemEdit.Image = global::ECard78.Properties.Resources.Note;
            this.ItemEdit.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemEdit.Name = "ItemEdit";
            this.ItemEdit.Size = new System.Drawing.Size(23, 22);
            this.ItemEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemEdit.Click += new System.EventHandler(this.ItemEdit_Click);
            // 
            // ItemDelete
            // 
            this.ItemDelete.Image = global::ECard78.Properties.Resources.Delete;
            this.ItemDelete.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemDelete.Name = "ItemDelete";
            this.ItemDelete.Size = new System.Drawing.Size(23, 22);
            this.ItemDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemDelete.Click += new System.EventHandler(this.ItemDelete_Click);
            // 
            // ItemLine2
            // 
            this.ItemLine2.Name = "ItemLine2";
            this.ItemLine2.Size = new System.Drawing.Size(6, 25);
            // 
            // ItemTAG1
            // 
            this.ItemTAG1.Enabled = false;
            this.ItemTAG1.Image = global::ECard78.Properties.Resources.SignalLEDBlue;
            this.ItemTAG1.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemTAG1.Name = "ItemTAG1";
            this.ItemTAG1.Size = new System.Drawing.Size(23, 37);
            this.ItemTAG1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemTAG1.Visible = false;
            this.ItemTAG1.Click += new System.EventHandler(this.ItemTAG1_Click);
            // 
            // ItemTAG9
            // 
            this.ItemTAG9.Enabled = false;
            this.ItemTAG9.Image = global::ECard78.Properties.Resources.SignalLEDPurplishRed;
            this.ItemTAG9.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemTAG9.Name = "ItemTAG9";
            this.ItemTAG9.Size = new System.Drawing.Size(23, 37);
            this.ItemTAG9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemTAG9.Visible = false;
            this.ItemTAG9.Click += new System.EventHandler(this.ItemTAG9_Click);
            // 
            // ItemTAG2
            // 
            this.ItemTAG2.Enabled = false;
            this.ItemTAG2.Image = global::ECard78.Properties.Resources.SignalLEDGreen;
            this.ItemTAG2.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemTAG2.Name = "ItemTAG2";
            this.ItemTAG2.Size = new System.Drawing.Size(23, 37);
            this.ItemTAG2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemTAG2.Visible = false;
            this.ItemTAG2.Click += new System.EventHandler(this.ItemTAG2_Click);
            // 
            // ItemTAG3
            // 
            this.ItemTAG3.Enabled = false;
            this.ItemTAG3.Image = global::ECard78.Properties.Resources.SignalLEDLtBlue;
            this.ItemTAG3.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemTAG3.Name = "ItemTAG3";
            this.ItemTAG3.Size = new System.Drawing.Size(23, 37);
            this.ItemTAG3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemTAG3.Visible = false;
            this.ItemTAG3.Click += new System.EventHandler(this.ItemTAG3_Click);
            // 
            // ItemTAG4
            // 
            this.ItemTAG4.Enabled = false;
            this.ItemTAG4.Image = global::ECard78.Properties.Resources.SignalLEDOrange;
            this.ItemTAG4.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemTAG4.Name = "ItemTAG4";
            this.ItemTAG4.Size = new System.Drawing.Size(23, 37);
            this.ItemTAG4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemTAG4.Visible = false;
            this.ItemTAG4.Click += new System.EventHandler(this.ItemTAG4_Click);
            // 
            // ItemTAG5
            // 
            this.ItemTAG5.Enabled = false;
            this.ItemTAG5.Image = global::ECard78.Properties.Resources.SignalLEDRed;
            this.ItemTAG5.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemTAG5.Name = "ItemTAG5";
            this.ItemTAG5.Size = new System.Drawing.Size(23, 37);
            this.ItemTAG5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemTAG5.Visible = false;
            this.ItemTAG5.Click += new System.EventHandler(this.ItemTAG5_Click);
            // 
            // ItemTAG6
            // 
            this.ItemTAG6.Enabled = false;
            this.ItemTAG6.Image = global::ECard78.Properties.Resources.SignalLEDViolet;
            this.ItemTAG6.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemTAG6.Name = "ItemTAG6";
            this.ItemTAG6.Size = new System.Drawing.Size(23, 37);
            this.ItemTAG6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemTAG6.Visible = false;
            this.ItemTAG6.Click += new System.EventHandler(this.ItemTAG6_Click);
            // 
            // ItemTAG8
            // 
            this.ItemTAG8.Enabled = false;
            this.ItemTAG8.Image = global::ECard78.Properties.Resources.SignalLEDBlack1;
            this.ItemTAG8.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemTAG8.Name = "ItemTAG8";
            this.ItemTAG8.Size = new System.Drawing.Size(23, 37);
            this.ItemTAG8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemTAG8.Visible = false;
            this.ItemTAG8.Click += new System.EventHandler(this.ItemTAG8_Click);
            // 
            // ItemTAG7
            // 
            this.ItemTAG7.Enabled = false;
            this.ItemTAG7.Image = global::ECard78.Properties.Resources.SignalLEDYellow;
            this.ItemTAG7.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemTAG7.Name = "ItemTAG7";
            this.ItemTAG7.Size = new System.Drawing.Size(23, 37);
            this.ItemTAG7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemTAG7.Visible = false;
            this.ItemTAG7.Click += new System.EventHandler(this.ItemTAG7_Click);
            // 
            // ItemTAGExt
            // 
            this.ItemTAGExt.Enabled = false;
            this.ItemTAGExt.Image = global::ECard78.Properties.Resources.ToolsHammer;
            this.ItemTAGExt.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemTAGExt.Name = "ItemTAGExt";
            this.ItemTAGExt.Size = new System.Drawing.Size(29, 37);
            this.ItemTAGExt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemTAGExt.Visible = false;
            // 
            // ItemLine3
            // 
            this.ItemLine3.Name = "ItemLine3";
            this.ItemLine3.Size = new System.Drawing.Size(6, 40);
            this.ItemLine3.Visible = false;
            // 
            // ItemSelect
            // 
            this.ItemSelect.Image = global::ECard78.Properties.Resources.EditSelectAll;
            this.ItemSelect.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemSelect.Name = "ItemSelect";
            this.ItemSelect.Size = new System.Drawing.Size(23, 22);
            this.ItemSelect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemSelect.Click += new System.EventHandler(this.ItemSelect_Click);
            // 
            // ItemUnselect
            // 
            this.ItemUnselect.Image = global::ECard78.Properties.Resources.EditUnSelectAll;
            this.ItemUnselect.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemUnselect.Name = "ItemUnselect";
            this.ItemUnselect.Size = new System.Drawing.Size(23, 22);
            this.ItemUnselect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemUnselect.Click += new System.EventHandler(this.ItemUnselect_Click);
            // 
            // ItemLine4
            // 
            this.ItemLine4.Name = "ItemLine4";
            this.ItemLine4.Size = new System.Drawing.Size(6, 25);
            // 
            // ItemSearch
            // 
            this.ItemSearch.Enabled = false;
            this.ItemSearch.Image = global::ECard78.Properties.Resources.Search;
            this.ItemSearch.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemSearch.Name = "ItemSearch";
            this.ItemSearch.Size = new System.Drawing.Size(23, 37);
            this.ItemSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemSearch.Visible = false;
            this.ItemSearch.Click += new System.EventHandler(this.ItemSearch_Click);
            // 
            // ItemRefresh
            // 
            this.ItemRefresh.Image = global::ECard78.Properties.Resources.DBRefresh;
            this.ItemRefresh.ImageTransparentColor = System.Drawing.Color.White;
            this.ItemRefresh.Name = "ItemRefresh";
            this.ItemRefresh.Size = new System.Drawing.Size(23, 22);
            this.ItemRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemRefresh.Click += new System.EventHandler(this.ItemRefresh_Click);
            // 
            // ItemLine5
            // 
            this.ItemLine5.Name = "ItemLine5";
            this.ItemLine5.Size = new System.Drawing.Size(6, 40);
            this.ItemLine5.Visible = false;
            // 
            // ItemlbData
            // 
            this.ItemlbData.Enabled = false;
            this.ItemlbData.Name = "ItemlbData";
            this.ItemlbData.Size = new System.Drawing.Size(96, 37);
            this.ItemlbData.Text = "toolStripLabel1";
            this.ItemlbData.Visible = false;
            // 
            // ItemFindLabel
            // 
            this.ItemFindLabel.Enabled = false;
            this.ItemFindLabel.Name = "ItemFindLabel";
            this.ItemFindLabel.Size = new System.Drawing.Size(96, 37);
            this.ItemFindLabel.Text = "toolStripLabel1";
            this.ItemFindLabel.Visible = false;
            // 
            // ItemFindText
            // 
            this.ItemFindText.AutoSize = false;
            this.ItemFindText.Enabled = false;
            this.ItemFindText.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.ItemFindText.Name = "ItemFindText";
            this.ItemFindText.Size = new System.Drawing.Size(100, 20);
            this.ItemFindText.Visible = false;
            this.ItemFindText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ItemFindText_KeyDown);
            // 
            // ItemLine6
            // 
            this.ItemLine6.Name = "ItemLine6";
            this.ItemLine6.Size = new System.Drawing.Size(6, 40);
            this.ItemLine6.Visible = false;
            // 
            // ItemZoomIn
            // 
            this.ItemZoomIn.Image = global::ECard78.Properties.Resources.ViewZoomIn;
            this.ItemZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ItemZoomIn.Name = "ItemZoomIn";
            this.ItemZoomIn.Size = new System.Drawing.Size(107, 37);
            this.ItemZoomIn.Text = "toolStripButton1";
            this.ItemZoomIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemZoomIn.Visible = false;
            this.ItemZoomIn.Click += new System.EventHandler(this.ItemZoomIn_Click);
            // 
            // ItemZoomOut
            // 
            this.ItemZoomOut.Image = global::ECard78.Properties.Resources.ViewZoomOut;
            this.ItemZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ItemZoomOut.Name = "ItemZoomOut";
            this.ItemZoomOut.Size = new System.Drawing.Size(107, 37);
            this.ItemZoomOut.Text = "toolStripButton2";
            this.ItemZoomOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ItemZoomOut.Visible = false;
            this.ItemZoomOut.Click += new System.EventHandler(this.ItemZoomOut_Click);
            // 
            // ItemlbDataStartTime
            // 
            this.ItemlbDataStartTime.Name = "ItemlbDataStartTime";
            this.ItemlbDataStartTime.Size = new System.Drawing.Size(96, 22);
            this.ItemlbDataStartTime.Text = "toolStripLabel1";
            this.ItemlbDataStartTime.Visible = false;
            // 
            // ItemStarTime
            // 
            this.ItemStarTime.AutoSize = false;
            this.ItemStarTime.Enabled = false;
            this.ItemStarTime.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.ItemStarTime.Name = "ItemStarTime";
            this.ItemStarTime.Size = new System.Drawing.Size(100, 20);
            this.ItemStarTime.Visible = false;
            // 
            // ItemlbDataEndTime
            // 
            this.ItemlbDataEndTime.Name = "ItemlbDataEndTime";
            this.ItemlbDataEndTime.Size = new System.Drawing.Size(96, 22);
            this.ItemlbDataEndTime.Text = "toolStripLabel2";
            this.ItemlbDataEndTime.Visible = false;
            // 
            // ItemEndTime
            // 
            this.ItemEndTime.AutoSize = false;
            this.ItemEndTime.Enabled = false;
            this.ItemEndTime.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.ItemEndTime.Name = "ItemEndTime";
            this.ItemEndTime.Size = new System.Drawing.Size(100, 20);
            this.ItemEndTime.Visible = false;
            // 
            // Statusbar
            // 
            this.Statusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblRecordState,
            this.progBar,
            this.lblMsg});
            this.Statusbar.Location = new System.Drawing.Point(0, 341);
            this.Statusbar.Name = "Statusbar";
            this.Statusbar.Size = new System.Drawing.Size(423, 31);
            this.Statusbar.TabIndex = 1;
            this.Statusbar.Text = "Statusbar";
            // 
            // lblRecordState
            // 
            this.lblRecordState.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblRecordState.Margin = new System.Windows.Forms.Padding(5);
            this.lblRecordState.Name = "lblRecordState";
            this.lblRecordState.Size = new System.Drawing.Size(135, 21);
            this.lblRecordState.Text = "toolStripStatusLabel1";
            // 
            // progBar
            // 
            this.progBar.AutoSize = false;
            this.progBar.Margin = new System.Windows.Forms.Padding(5);
            this.progBar.Name = "progBar";
            this.progBar.Size = new System.Drawing.Size(100, 21);
            this.progBar.Step = 1;
            // 
            // lblMsg
            // 
            this.lblMsg.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblMsg.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(135, 21);
            this.lblMsg.Text = "toolStripStatusLabel1";
            // 
            // contextMenu
            // 
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(61, 4);
            this.contextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenu_ItemClicked);
            // 
            // bindingSource
            // 
            this.bindingSource.AllowNew = false;
            this.bindingSource.PositionChanged += new System.EventHandler(this.bindingSource_PositionChanged);
            // 
            // frmBaseMDIChild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(423, 372);
            this.Controls.Add(this.Statusbar);
            this.Controls.Add(this.Toolbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "frmBaseMDIChild";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "";
            this.Activated += new System.EventHandler(this.frmBaseMDIChild_Activated);
            this.Shown += new System.EventHandler(this.frmBaseMDIChild_Shown);
            this.SizeChanged += new System.EventHandler(this.frmBaseMDIChild_SizeChanged);
            this.Toolbar.ResumeLayout(false);
            this.Toolbar.PerformLayout();
            this.Statusbar.ResumeLayout(false);
            this.Statusbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    protected System.Windows.Forms.StatusStrip Statusbar;
    protected System.Windows.Forms.ToolStripButton ItemExport;
    protected System.Windows.Forms.ToolStripButton ItemImport;
    protected System.Windows.Forms.ToolStripButton ItemPrint;
    protected System.Windows.Forms.ToolStripSeparator ItemLine1;
    protected System.Windows.Forms.ToolStripButton ItemAdd;
    protected System.Windows.Forms.ToolStripButton ItemEdit;
    protected System.Windows.Forms.ToolStripButton ItemDelete;
    protected System.Windows.Forms.ToolStripSeparator ItemLine2;
    protected System.Windows.Forms.ToolStripButton ItemTAG1;
    protected System.Windows.Forms.ToolStripButton ItemTAG2;
    protected System.Windows.Forms.ToolStripButton ItemTAG3;
    protected System.Windows.Forms.ToolStripButton ItemTAG4;
    protected System.Windows.Forms.ToolStripButton ItemTAG5;
    protected System.Windows.Forms.ToolStripButton ItemTAG6;
    protected System.Windows.Forms.ToolStripButton ItemTAG7;
    protected System.Windows.Forms.ToolStripSeparator ItemLine3;
    protected System.Windows.Forms.ToolStripButton ItemSelect;
    protected System.Windows.Forms.ToolStripButton ItemUnselect;
    protected System.Windows.Forms.ToolStripSeparator ItemLine4;
    protected System.Windows.Forms.ToolStripButton ItemSearch;
    protected System.Windows.Forms.ToolStripSeparator ItemLine5;
    protected System.Windows.Forms.ToolStripTextBox ItemFindText;
    protected System.Windows.Forms.ToolStrip Toolbar;
    protected System.Windows.Forms.ToolStripLabel ItemFindLabel;
    protected System.Windows.Forms.ToolStripDropDownButton ItemTAGExt;
    protected System.Windows.Forms.ToolStripButton ItemRefresh;
    protected System.Windows.Forms.BindingSource bindingSource;
    protected System.Windows.Forms.ToolStripStatusLabel lblRecordState;
    protected System.Windows.Forms.ToolStripStatusLabel lblMsg;
    protected System.Windows.Forms.ContextMenuStrip contextMenu;
    protected System.Windows.Forms.ToolStripProgressBar progBar;
    private System.Windows.Forms.SaveFileDialog dlgSave;
    private System.Windows.Forms.ToolStripSeparator ItemLine6;
    protected System.Windows.Forms.ToolStripButton ItemZoomIn;
    protected System.Windows.Forms.ToolStripButton ItemZoomOut;
    protected System.Windows.Forms.ToolStripButton ItemTAG8;
    protected System.Windows.Forms.ToolStripLabel ItemlbData;
        protected System.Windows.Forms.ToolStripButton ItemTAG9;
        protected System.Windows.Forms.ToolStripLabel ItemlbDataStartTime;
        protected System.Windows.Forms.ToolStripTextBox ItemStarTime;
        protected System.Windows.Forms.ToolStripLabel ItemlbDataEndTime;
        protected System.Windows.Forms.ToolStripTextBox ItemEndTime;
    }
}
