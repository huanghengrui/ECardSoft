namespace ECard78
{
  partial class frmRSEmpCardFa
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRSEmpCardFa));
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
      this.toolBar = new System.Windows.Forms.ToolStrip();
      this.ItemSearch = new System.Windows.Forms.ToolStripButton();
      this.ItemFindLabel = new System.Windows.Forms.ToolStripLabel();
      this.ItemFindText = new System.Windows.Forms.ToolStripTextBox();
      this.ItemLine1 = new System.Windows.Forms.ToolStripSeparator();
      this.ItemBatchFa = new System.Windows.Forms.ToolStripButton();
      this.ItemStop = new System.Windows.Forms.ToolStripButton();
      this.ItemLine2 = new System.Windows.Forms.ToolStripSeparator();
      this.ItemMoneyLabel = new System.Windows.Forms.ToolStripLabel();
      this.ItemMoneyText = new System.Windows.Forms.ToolStripTextBox();
      this.ItemSingleFa = new System.Windows.Forms.ToolStripButton();
      this.ItemLine3 = new System.Windows.Forms.ToolStripSeparator();
      this.ItemCardFill = new System.Windows.Forms.ToolStripButton();
      this.ItemLine4 = new System.Windows.Forms.ToolStripSeparator();
      this.ItemExit = new System.Windows.Forms.ToolStripButton();
      this.dataGrid = new System.Windows.Forms.DataGridView();
      this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.statusBar = new System.Windows.Forms.StatusStrip();
      this.lblCount = new System.Windows.Forms.ToolStripStatusLabel();
      this.progBar = new System.Windows.Forms.ToolStripProgressBar();
      this.lblMsg = new System.Windows.Forms.ToolStripStatusLabel();
      this.lblResult = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolBar.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
      this.statusBar.SuspendLayout();
      this.SuspendLayout();
      // 
      // toolBar
      // 
      this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemSearch,
            this.ItemFindLabel,
            this.ItemFindText,
            this.ItemLine1,
            this.ItemBatchFa,
            this.ItemStop,
            this.ItemLine2,
            this.ItemMoneyLabel,
            this.ItemMoneyText,
            this.ItemSingleFa,
            this.ItemLine3,
            this.ItemCardFill,
            this.ItemLine4,
            this.ItemExit});
      this.toolBar.Location = new System.Drawing.Point(0, 0);
      this.toolBar.Name = "toolBar";
      this.toolBar.Size = new System.Drawing.Size(834, 35);
      this.toolBar.TabIndex = 0;
      this.toolBar.Text = "toolStrip1";
      // 
      // ItemSearch
      // 
      this.ItemSearch.Image = ((System.Drawing.Image)(resources.GetObject("ItemSearch.Image")));
      this.ItemSearch.ImageTransparentColor = System.Drawing.Color.White;
      this.ItemSearch.Name = "ItemSearch";
      this.ItemSearch.Size = new System.Drawing.Size(23, 32);
      this.ItemSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.ItemSearch.Click += new System.EventHandler(this.ItemSearch_Click);
      // 
      // ItemFindLabel
      // 
      this.ItemFindLabel.Name = "ItemFindLabel";
      this.ItemFindLabel.Size = new System.Drawing.Size(23, 32);
      this.ItemFindLabel.Text = "222";
      // 
      // ItemFindText
      // 
      this.ItemFindText.AutoSize = false;
      this.ItemFindText.Name = "ItemFindText";
      this.ItemFindText.Size = new System.Drawing.Size(100, 25);
      this.ItemFindText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ItemFindText_KeyDown);
      // 
      // ItemLine1
      // 
      this.ItemLine1.Name = "ItemLine1";
      this.ItemLine1.Size = new System.Drawing.Size(6, 35);
      // 
      // ItemBatchFa
      // 
      this.ItemBatchFa.Image = ((System.Drawing.Image)(resources.GetObject("ItemBatchFa.Image")));
      this.ItemBatchFa.ImageTransparentColor = System.Drawing.Color.White;
      this.ItemBatchFa.Name = "ItemBatchFa";
      this.ItemBatchFa.Size = new System.Drawing.Size(105, 32);
      this.ItemBatchFa.Text = "toolStripButton3";
      this.ItemBatchFa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.ItemBatchFa.Click += new System.EventHandler(this.ItemBatchFa_Click);
      // 
      // ItemStop
      // 
      this.ItemStop.Image = ((System.Drawing.Image)(resources.GetObject("ItemStop.Image")));
      this.ItemStop.ImageTransparentColor = System.Drawing.Color.White;
      this.ItemStop.Name = "ItemStop";
      this.ItemStop.Size = new System.Drawing.Size(105, 32);
      this.ItemStop.Text = "toolStripButton1";
      this.ItemStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.ItemStop.Click += new System.EventHandler(this.ItemStop_Click);
      // 
      // ItemLine2
      // 
      this.ItemLine2.Name = "ItemLine2";
      this.ItemLine2.Size = new System.Drawing.Size(6, 35);
      // 
      // ItemMoneyLabel
      // 
      this.ItemMoneyLabel.Name = "ItemMoneyLabel";
      this.ItemMoneyLabel.Size = new System.Drawing.Size(95, 32);
      this.ItemMoneyLabel.Text = "toolStripLabel2";
      // 
      // ItemMoneyText
      // 
      this.ItemMoneyText.AutoSize = false;
      this.ItemMoneyText.Name = "ItemMoneyText";
      this.ItemMoneyText.Size = new System.Drawing.Size(100, 25);
      // 
      // ItemSingleFa
      // 
      this.ItemSingleFa.Image = ((System.Drawing.Image)(resources.GetObject("ItemSingleFa.Image")));
      this.ItemSingleFa.ImageTransparentColor = System.Drawing.Color.White;
      this.ItemSingleFa.Name = "ItemSingleFa";
      this.ItemSingleFa.Size = new System.Drawing.Size(105, 32);
      this.ItemSingleFa.Text = "toolStripButton4";
      this.ItemSingleFa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.ItemSingleFa.Click += new System.EventHandler(this.ItemSingleFa_Click);
      // 
      // ItemLine3
      // 
      this.ItemLine3.Name = "ItemLine3";
      this.ItemLine3.Size = new System.Drawing.Size(6, 35);
      // 
      // ItemCardFill
      // 
      this.ItemCardFill.Image = ((System.Drawing.Image)(resources.GetObject("ItemCardFill.Image")));
      this.ItemCardFill.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ItemCardFill.Name = "ItemCardFill";
      this.ItemCardFill.Size = new System.Drawing.Size(105, 32);
      this.ItemCardFill.Text = "toolStripButton5";
      this.ItemCardFill.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.ItemCardFill.Click += new System.EventHandler(this.ItemCardFill_Click);
      // 
      // ItemLine4
      // 
      this.ItemLine4.Name = "ItemLine4";
      this.ItemLine4.Size = new System.Drawing.Size(6, 6);
      // 
      // ItemExit
      // 
      this.ItemExit.Image = ((System.Drawing.Image)(resources.GetObject("ItemExit.Image")));
      this.ItemExit.ImageTransparentColor = System.Drawing.Color.White;
      this.ItemExit.Name = "ItemExit";
      this.ItemExit.Size = new System.Drawing.Size(105, 32);
      this.ItemExit.Text = "toolStripButton6";
      this.ItemExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.ItemExit.Click += new System.EventHandler(this.ItemExit_Click);
      // 
      // dataGrid
      // 
      this.dataGrid.AllowUserToAddRows = false;
      this.dataGrid.AllowUserToDeleteRows = false;
      this.dataGrid.AllowUserToResizeRows = false;
      this.dataGrid.AutoGenerateColumns = false;
      dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
      this.dataGrid.ColumnHeadersHeight = 25;
      this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
      this.dataGrid.DataSource = this.bindingSource;
      dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle18.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dataGrid.DefaultCellStyle = dataGridViewCellStyle18;
      this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGrid.Location = new System.Drawing.Point(0, 35);
      this.dataGrid.MultiSelect = false;
      this.dataGrid.Name = "dataGrid";
      this.dataGrid.ReadOnly = true;
      this.dataGrid.RowHeadersVisible = false;
      this.dataGrid.RowTemplate.Height = 23;
      this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dataGrid.Size = new System.Drawing.Size(834, 407);
      this.dataGrid.StandardTab = true;
      this.dataGrid.TabIndex = 8;
      // 
      // Column1
      // 
      this.Column1.DataPropertyName = "CardSectorNo";
      this.Column1.HeaderText = "Column1";
      this.Column1.Name = "Column1";
      this.Column1.ReadOnly = true;
      this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Column1.Width = 80;
      // 
      // Column2
      // 
      this.Column2.DataPropertyName = "CardStatusName";
      dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      this.Column2.DefaultCellStyle = dataGridViewCellStyle11;
      this.Column2.HeaderText = "Column2";
      this.Column2.Name = "Column2";
      this.Column2.ReadOnly = true;
      this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Column2.Width = 60;
      // 
      // Column3
      // 
      this.Column3.DataPropertyName = "CardTypeName";
      dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      this.Column3.DefaultCellStyle = dataGridViewCellStyle12;
      this.Column3.HeaderText = "Column3";
      this.Column3.Name = "Column3";
      this.Column3.ReadOnly = true;
      this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Column3.Width = 80;
      // 
      // Column4
      // 
      this.Column4.DataPropertyName = "EmpNo";
      dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      this.Column4.DefaultCellStyle = dataGridViewCellStyle13;
      this.Column4.HeaderText = "Column4";
      this.Column4.Name = "Column4";
      this.Column4.ReadOnly = true;
      this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Column4.Width = 70;
      // 
      // Column5
      // 
      this.Column5.DataPropertyName = "EmpName";
      dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      this.Column5.DefaultCellStyle = dataGridViewCellStyle14;
      this.Column5.HeaderText = "Column5";
      this.Column5.Name = "Column5";
      this.Column5.ReadOnly = true;
      this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Column5.Width = 70;
      // 
      // Column6
      // 
      this.Column6.DataPropertyName = "DepartName";
      dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      this.Column6.DefaultCellStyle = dataGridViewCellStyle15;
      this.Column6.HeaderText = "Column6";
      this.Column6.Name = "Column6";
      this.Column6.ReadOnly = true;
      this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // Column7
      // 
      this.Column7.DataPropertyName = "CardValudDate";
      this.Column7.HeaderText = "Column7";
      this.Column7.Name = "Column7";
      this.Column7.ReadOnly = true;
      this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Column7.Width = 150;
      // 
      // Column8
      // 
      this.Column8.DataPropertyName = "CardFee";
      dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      this.Column8.DefaultCellStyle = dataGridViewCellStyle16;
      this.Column8.HeaderText = "Column8";
      this.Column8.Name = "Column8";
      this.Column8.ReadOnly = true;
      this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Column8.Width = 60;
      // 
      // Column9
      // 
      this.Column9.DataPropertyName = "CardStored";
      dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      this.Column9.DefaultCellStyle = dataGridViewCellStyle17;
      this.Column9.HeaderText = "Column9";
      this.Column9.Name = "Column9";
      this.Column9.ReadOnly = true;
      this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Column9.Width = 140;
      // 
      // bindingSource
      // 
      this.bindingSource.AllowNew = false;
      this.bindingSource.PositionChanged += new System.EventHandler(this.bindingSource_PositionChanged);
      // 
      // statusBar
      // 
      this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCount,
            this.progBar,
            this.lblMsg,
            this.lblResult});
      this.statusBar.Location = new System.Drawing.Point(0, 442);
      this.statusBar.Name = "statusBar";
      this.statusBar.Size = new System.Drawing.Size(834, 26);
      this.statusBar.TabIndex = 9;
      this.statusBar.Text = "statusStrip1";
      // 
      // lblCount
      // 
      this.lblCount.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
      this.lblCount.Margin = new System.Windows.Forms.Padding(5);
      this.lblCount.Name = "lblCount";
      this.lblCount.Size = new System.Drawing.Size(135, 16);
      this.lblCount.Text = "toolStripStatusLabel1";
      // 
      // progBar
      // 
      this.progBar.AutoSize = false;
      this.progBar.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
      this.progBar.Name = "progBar";
      this.progBar.Size = new System.Drawing.Size(100, 16);
      // 
      // lblMsg
      // 
      this.lblMsg.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
      this.lblMsg.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
      this.lblMsg.Name = "lblMsg";
      this.lblMsg.Size = new System.Drawing.Size(135, 16);
      this.lblMsg.Text = "toolStripStatusLabel2";
      // 
      // lblResult
      // 
      this.lblResult.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
      this.lblResult.Name = "lblResult";
      this.lblResult.Size = new System.Drawing.Size(424, 16);
      this.lblResult.Spring = true;
      this.lblResult.Text = "toolStripStatusLabel1";
      this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // frmRSEmpCardFa
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(834, 468);
      this.Controls.Add(this.dataGrid);
      this.Controls.Add(this.statusBar);
      this.Controls.Add(this.toolBar);
      this.Name = "frmRSEmpCardFa";
      this.Text = "";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRSEmpCardFa_FormClosed);
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRSEmpCardFa_FormClosing);
      this.toolBar.ResumeLayout(false);
      this.toolBar.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
      this.statusBar.ResumeLayout(false);
      this.statusBar.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStrip toolBar;
    private System.Windows.Forms.ToolStripButton ItemSearch;
    private System.Windows.Forms.ToolStripLabel ItemFindLabel;
    private System.Windows.Forms.ToolStripTextBox ItemFindText;
    private System.Windows.Forms.ToolStripSeparator ItemLine1;
    private System.Windows.Forms.ToolStripButton ItemBatchFa;
    private System.Windows.Forms.ToolStripLabel ItemMoneyLabel;
    private System.Windows.Forms.ToolStripTextBox ItemMoneyText;
    private System.Windows.Forms.ToolStripButton ItemSingleFa;
    private System.Windows.Forms.ToolStripSeparator ItemLine2;
    private System.Windows.Forms.ToolStripButton ItemCardFill;
    private System.Windows.Forms.ToolStripSeparator ItemLine3;
    private System.Windows.Forms.ToolStripButton ItemExit;
    private System.Windows.Forms.ToolStripButton ItemStop;
    private System.Windows.Forms.ToolStripSeparator ItemLine4;
    protected System.Windows.Forms.DataGridView dataGrid;
    private System.Windows.Forms.StatusStrip statusBar;
    private System.Windows.Forms.ToolStripStatusLabel lblCount;
    private System.Windows.Forms.ToolStripStatusLabel lblMsg;
    private System.Windows.Forms.ToolStripProgressBar progBar;
    protected System.Windows.Forms.BindingSource bindingSource;
    private System.Windows.Forms.ToolStripStatusLabel lblResult;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
  }
}
