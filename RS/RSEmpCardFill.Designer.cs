namespace ECard78
{
  partial class frmRSEmpCardFill
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
      this.toolBar = new System.Windows.Forms.ToolStrip();
      this.ItemSearch = new System.Windows.Forms.ToolStripButton();
      this.ItemLine1 = new System.Windows.Forms.ToolStripSeparator();
      this.ItemCardLabel = new System.Windows.Forms.ToolStripLabel();
      this.ItemStartCard = new System.Windows.Forms.ToolStripComboBox();
      this.ItemLine2 = new System.Windows.Forms.ToolStripSeparator();
      this.ItemCardFill = new System.Windows.Forms.ToolStripButton();
      this.ItemCardDelete = new System.Windows.Forms.ToolStripButton();
      this.ItemLine3 = new System.Windows.Forms.ToolStripSeparator();
      this.ItemExit = new System.Windows.Forms.ToolStripButton();
      this.ItemLine4 = new System.Windows.Forms.ToolStripSeparator();
      this.ItemEditCardDate = new System.Windows.Forms.ToolStripLabel();
      this.dtpDate = new System.Windows.Forms.DateTimePicker();
      this.dataGrid = new System.Windows.Forms.DataGridView();
      this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.statusBar = new System.Windows.Forms.StatusStrip();
      this.lblCount = new System.Windows.Forms.ToolStripStatusLabel();
      this.progBar = new System.Windows.Forms.ToolStripProgressBar();
      this.lblMsg = new System.Windows.Forms.ToolStripStatusLabel();
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
            this.ItemLine1,
            this.ItemCardLabel,
            this.ItemStartCard,
            this.ItemLine2,
            this.ItemCardFill,
            this.ItemCardDelete,
            this.ItemLine3,
            this.ItemExit,
            this.ItemLine4,
            this.ItemEditCardDate});
      this.toolBar.Location = new System.Drawing.Point(0, 0);
      this.toolBar.Name = "toolBar";
      this.toolBar.Size = new System.Drawing.Size(794, 35);
      this.toolBar.TabIndex = 0;
      this.toolBar.Text = "toolStrip1";
      this.toolBar.Resize += new System.EventHandler(this.toolBar_Resize);
      // 
      // ItemSearch
      // 
      this.ItemSearch.Image = global::ECard78.Properties.Resources.ItemSearch_Image;
      this.ItemSearch.ImageTransparentColor = System.Drawing.Color.White;
      this.ItemSearch.Name = "ItemSearch";
      this.ItemSearch.Size = new System.Drawing.Size(105, 32);
      this.ItemSearch.Text = "toolStripButton1";
      this.ItemSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.ItemSearch.Click += new System.EventHandler(this.ItemSearch_Click);
      // 
      // ItemLine1
      // 
      this.ItemLine1.Name = "ItemLine1";
      this.ItemLine1.Size = new System.Drawing.Size(6, 35);
      // 
      // ItemCardLabel
      // 
      this.ItemCardLabel.Name = "ItemCardLabel";
      this.ItemCardLabel.Size = new System.Drawing.Size(95, 32);
      this.ItemCardLabel.Text = "toolStripLabel1";
      // 
      // ItemStartCard
      // 
      this.ItemStartCard.Name = "ItemStartCard";
      this.ItemStartCard.Size = new System.Drawing.Size(100, 35);
      // 
      // ItemLine2
      // 
      this.ItemLine2.Name = "ItemLine2";
      this.ItemLine2.Size = new System.Drawing.Size(6, 35);
      // 
      // ItemCardFill
      // 
      this.ItemCardFill.Image = global::ECard78.Properties.Resources.ItemCardFill_Image;
      this.ItemCardFill.ImageTransparentColor = System.Drawing.Color.White;
      this.ItemCardFill.Name = "ItemCardFill";
      this.ItemCardFill.Size = new System.Drawing.Size(105, 32);
      this.ItemCardFill.Text = "toolStripButton2";
      this.ItemCardFill.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.ItemCardFill.Click += new System.EventHandler(this.ItemCardFill_Click);
      // 
      // ItemCardDelete
      // 
      this.ItemCardDelete.Image = global::ECard78.Properties.Resources.ItemCardDelete_Image;
      this.ItemCardDelete.ImageTransparentColor = System.Drawing.Color.White;
      this.ItemCardDelete.Name = "ItemCardDelete";
      this.ItemCardDelete.Size = new System.Drawing.Size(105, 32);
      this.ItemCardDelete.Text = "toolStripButton3";
      this.ItemCardDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.ItemCardDelete.Click += new System.EventHandler(this.ItemCardDelete_Click);
      // 
      // ItemLine3
      // 
      this.ItemLine3.Name = "ItemLine3";
      this.ItemLine3.Size = new System.Drawing.Size(6, 35);
      // 
      // ItemExit
      // 
      this.ItemExit.Image = global::ECard78.Properties.Resources.ItemExit_Image;
      this.ItemExit.ImageTransparentColor = System.Drawing.Color.White;
      this.ItemExit.Name = "ItemExit";
      this.ItemExit.Size = new System.Drawing.Size(105, 32);
      this.ItemExit.Text = "toolStripButton4";
      this.ItemExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.ItemExit.Click += new System.EventHandler(this.ItemExit_Click);
      // 
      // ItemLine4
      // 
      this.ItemLine4.Name = "ItemLine4";
      this.ItemLine4.Size = new System.Drawing.Size(6, 35);
      // 
      // ItemEditCardDate
      // 
      this.ItemEditCardDate.Name = "ItemEditCardDate";
      this.ItemEditCardDate.Size = new System.Drawing.Size(95, 32);
      this.ItemEditCardDate.Text = "toolStripLabel1";
      // 
      // dtpDate
      // 
      this.dtpDate.Checked = false;
      this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.dtpDate.Location = new System.Drawing.Point(588, 0);
      this.dtpDate.Name = "dtpDate";
      this.dtpDate.ShowCheckBox = true;
      this.dtpDate.Size = new System.Drawing.Size(100, 21);
      this.dtpDate.TabIndex = 1;
      // 
      // dataGrid
      // 
      this.dataGrid.AllowUserToAddRows = false;
      this.dataGrid.AllowUserToDeleteRows = false;
      this.dataGrid.AllowUserToResizeRows = false;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.dataGrid.ColumnHeadersHeight = 25;
      this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
      this.dataGrid.DataSource = this.bindingSource;
      dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dataGrid.DefaultCellStyle = dataGridViewCellStyle7;
      this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGrid.Location = new System.Drawing.Point(0, 35);
      this.dataGrid.MultiSelect = false;
      this.dataGrid.Name = "dataGrid";
      this.dataGrid.ReadOnly = true;
      this.dataGrid.RowHeadersVisible = false;
      this.dataGrid.RowTemplate.Height = 23;
      this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dataGrid.Size = new System.Drawing.Size(794, 413);
      this.dataGrid.StandardTab = true;
      this.dataGrid.TabIndex = 9;
      // 
      // Column1
      // 
      this.Column1.DataPropertyName = "CardSectorNo";
      this.Column1.HeaderText = "Column1";
      this.Column1.Name = "Column1";
      this.Column1.ReadOnly = true;
      this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // Column2
      // 
      this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.Column2.DataPropertyName = "CardStatusName";
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
      this.Column2.HeaderText = "Column2";
      this.Column2.Name = "Column2";
      this.Column2.ReadOnly = true;
      this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Column2.Width = 53;
      // 
      // Column3
      // 
      this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.Column3.DataPropertyName = "CardTypeName";
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
      this.Column3.HeaderText = "Column3";
      this.Column3.Name = "Column3";
      this.Column3.ReadOnly = true;
      this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Column3.Width = 53;
      // 
      // Column4
      // 
      this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.Column4.DataPropertyName = "EmpNo";
      dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      this.Column4.DefaultCellStyle = dataGridViewCellStyle4;
      this.Column4.HeaderText = "Column4";
      this.Column4.Name = "Column4";
      this.Column4.ReadOnly = true;
      this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Column4.Width = 53;
      // 
      // Column5
      // 
      this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.Column5.DataPropertyName = "EmpName";
      dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      this.Column5.DefaultCellStyle = dataGridViewCellStyle5;
      this.Column5.HeaderText = "Column5";
      this.Column5.Name = "Column5";
      this.Column5.ReadOnly = true;
      this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Column5.Width = 53;
      // 
      // Column6
      // 
      this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.Column6.DataPropertyName = "DepartName";
      dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      this.Column6.DefaultCellStyle = dataGridViewCellStyle6;
      this.Column6.HeaderText = "Column6";
      this.Column6.Name = "Column6";
      this.Column6.ReadOnly = true;
      this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Column6.Width = 53;
      // 
      // Column7
      // 
      this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.Column7.DataPropertyName = "CardValudDate";
      this.Column7.HeaderText = "Column7";
      this.Column7.Name = "Column7";
      this.Column7.ReadOnly = true;
      this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Column7.Width = 53;
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
            this.lblMsg});
      this.statusBar.Location = new System.Drawing.Point(0, 422);
      this.statusBar.Name = "statusBar";
      this.statusBar.Size = new System.Drawing.Size(794, 26);
      this.statusBar.TabIndex = 10;
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
      this.lblMsg.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
      this.lblMsg.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
      this.lblMsg.Name = "lblMsg";
      this.lblMsg.Size = new System.Drawing.Size(135, 16);
      this.lblMsg.Text = "toolStripStatusLabel2";
      // 
      // frmRSEmpCardFill
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(794, 448);
      this.Controls.Add(this.statusBar);
      this.Controls.Add(this.dataGrid);
      this.Controls.Add(this.dtpDate);
      this.Controls.Add(this.toolBar);
      this.Name = "frmRSEmpCardFill";
      this.Text = "";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRSEmpCardFill_FormClosed);
      this.toolBar.ResumeLayout(false);
      this.toolBar.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
      this.Controls.SetChildIndex(this.dataGrid, 0);
      this.statusBar.ResumeLayout(false);
      this.statusBar.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStrip toolBar;
    private System.Windows.Forms.ToolStripButton ItemSearch;
    private System.Windows.Forms.ToolStripSeparator ItemLine1;
    private System.Windows.Forms.ToolStripLabel ItemCardLabel;
    private System.Windows.Forms.ToolStripComboBox ItemStartCard;
    private System.Windows.Forms.ToolStripSeparator ItemLine2;
    private System.Windows.Forms.ToolStripButton ItemCardFill;
    private System.Windows.Forms.ToolStripButton ItemCardDelete;
    private System.Windows.Forms.ToolStripSeparator ItemLine3;
    private System.Windows.Forms.ToolStripButton ItemExit;
    private System.Windows.Forms.ToolStripSeparator ItemLine4;
    private System.Windows.Forms.ToolStripLabel ItemEditCardDate;
    private System.Windows.Forms.DateTimePicker dtpDate;
    protected System.Windows.Forms.DataGridView dataGrid;
    private System.Windows.Forms.StatusStrip statusBar;
    private System.Windows.Forms.ToolStripStatusLabel lblCount;
    private System.Windows.Forms.ToolStripProgressBar progBar;
    private System.Windows.Forms.ToolStripStatusLabel lblMsg;
    protected System.Windows.Forms.BindingSource bindingSource;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
  }
}
