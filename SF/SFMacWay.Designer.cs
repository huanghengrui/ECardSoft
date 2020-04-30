namespace ECard78
{
  partial class frmSFMacWay
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSFMacWay));
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      this.chkAlarm = new System.Windows.Forms.CheckBox();
      this.rbDay = new System.Windows.Forms.RadioButton();
      this.rbTime = new System.Windows.Forms.RadioButton();
      this.dataGrid = new HeaderView(this.components);
      this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.Column3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column5 = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.Column6 = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column8 = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.Column9 = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column11 = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.Column12 = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column14 = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.Column15 = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column17 = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.Column18 = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column20 = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.Column21 = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.Column22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column23 = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.Column24 = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.Column25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column26 = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.Column27 = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.Column28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column29 = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.Column30 = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.Column31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.tvGrid = new System.Windows.Forms.TreeView();
      this.GridMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ItemPasteUpData = new System.Windows.Forms.ToolStripMenuItem();
      this.ItemEmptyData = new System.Windows.Forms.ToolStripMenuItem();
      this.label1 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
      this.GridMenu.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(810, 435);
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(730, 435);
      this.btnOk.Text = "";
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // ilTreeState
      // 
      this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
      this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
      this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
      this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
      // 
      // chkAlarm
      // 
      this.chkAlarm.AutoSize = true;
      this.chkAlarm.Location = new System.Drawing.Point(10, 40);
      this.chkAlarm.Name = "chkAlarm";
      this.chkAlarm.Size = new System.Drawing.Size(78, 16);
      this.chkAlarm.TabIndex = 3;
      this.chkAlarm.Text = "checkBox1";
      this.chkAlarm.UseVisualStyleBackColor = true;
      // 
      // rbDay
      // 
      this.rbDay.AutoSize = true;
      this.rbDay.Location = new System.Drawing.Point(170, 10);
      this.rbDay.Name = "rbDay";
      this.rbDay.Size = new System.Drawing.Size(95, 16);
      this.rbDay.TabIndex = 1;
      this.rbDay.TabStop = true;
      this.rbDay.Text = "radioButton2";
      this.rbDay.UseVisualStyleBackColor = true;
      this.rbDay.Click += new System.EventHandler(this.RadioButton_Click);
      // 
      // rbTime
      // 
      this.rbTime.AutoSize = true;
      this.rbTime.Location = new System.Drawing.Point(10, 10);
      this.rbTime.Name = "rbTime";
      this.rbTime.Size = new System.Drawing.Size(95, 16);
      this.rbTime.TabIndex = 0;
      this.rbTime.TabStop = true;
      this.rbTime.Text = "radioButton1";
      this.rbTime.UseVisualStyleBackColor = true;
      this.rbTime.Click += new System.EventHandler(this.RadioButton_Click);
      // 
      // dataGrid
      // 
      this.dataGrid.AllowUserToAddRows = false;
      this.dataGrid.AllowUserToDeleteRows = false;
      this.dataGrid.AllowUserToResizeRows = false;
      this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.dataGrid.CellHeight = 17;
      this.dataGrid.ColumnDeep = 3;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.dataGrid.ColumnHeadersHeight = 51;
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
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14,
            this.Column15,
            this.Column16,
            this.Column17,
            this.Column18,
            this.Column19,
            this.Column20,
            this.Column21,
            this.Column22,
            this.Column23,
            this.Column24,
            this.Column25,
            this.Column26,
            this.Column27,
            this.Column28,
            this.Column29,
            this.Column30,
            this.Column31});
      this.dataGrid.ColumnTreeView = new System.Windows.Forms.TreeView[] {
        this.tvGrid};
      this.dataGrid.ContextMenuStrip = this.GridMenu;
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dataGrid.DefaultCellStyle = dataGridViewCellStyle3;
      this.dataGrid.Location = new System.Drawing.Point(10, 70);
      this.dataGrid.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dataGrid.MergeColumnNames")));
      this.dataGrid.MultiSelect = false;
      this.dataGrid.Name = "dataGrid";
      this.dataGrid.RefreshAtHscroll = true;
      this.dataGrid.RowHeadersVisible = false;
      this.dataGrid.RowTemplate.Height = 23;
      this.dataGrid.Size = new System.Drawing.Size(875, 355);
      this.dataGrid.TabIndex = 4;
      this.dataGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellEndEdit);
      this.dataGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGrid_DataError);
      // 
      // Column1
      // 
      this.Column1.DataPropertyName = "CardType";
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
      this.Column1.HeaderText = "Column1";
      this.Column1.Name = "Column1";
      this.Column1.ReadOnly = true;
      this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Column1.Width = 120;
      // 
      // Column2
      // 
      this.Column2.DisplayStyleForCurrentCellOnly = true;
      this.Column2.HeaderText = "Column2";
      this.Column2.Name = "Column2";
      this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.Column2.Width = 50;
      // 
      // Column3
      // 
      this.Column3.DisplayStyleForCurrentCellOnly = true;
      this.Column3.HeaderText = "Column3";
      this.Column3.Name = "Column3";
      this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.Column3.Width = 90;
      // 
      // Column4
      // 
      this.Column4.HeaderText = "Column4";
      this.Column4.Name = "Column4";
      this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Column4.Width = 90;
      // 
      // Column5
      // 
      this.Column5.DisplayStyleForCurrentCellOnly = true;
      this.Column5.HeaderText = "Column5";
      this.Column5.Name = "Column5";
      this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.Column5.Width = 90;
      // 
      // Column6
      // 
      this.Column6.DisplayStyleForCurrentCellOnly = true;
      this.Column6.HeaderText = "Column6";
      this.Column6.Name = "Column6";
      this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.Column6.Width = 60;
      // 
      // Column7
      // 
      this.Column7.HeaderText = "Column7";
      this.Column7.Name = "Column7";
      this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Column7.Width = 60;
      // 
      // Column8
      // 
      this.Column8.DisplayStyleForCurrentCellOnly = true;
      this.Column8.HeaderText = "Column8";
      this.Column8.Name = "Column8";
      this.Column8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.Column8.Width = 60;
      // 
      // Column9
      // 
      this.Column9.DisplayStyleForCurrentCellOnly = true;
      this.Column9.HeaderText = "Column9";
      this.Column9.Name = "Column9";
      this.Column9.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.Column9.Width = 60;
      // 
      // Column10
      // 
      this.Column10.HeaderText = "Column10";
      this.Column10.Name = "Column10";
      this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // Column11
      // 
      this.Column11.DisplayStyleForCurrentCellOnly = true;
      this.Column11.HeaderText = "Column11";
      this.Column11.Name = "Column11";
      this.Column11.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      // 
      // Column12
      // 
      this.Column12.DisplayStyleForCurrentCellOnly = true;
      this.Column12.HeaderText = "Column12";
      this.Column12.Name = "Column12";
      this.Column12.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      // 
      // Column13
      // 
      this.Column13.HeaderText = "Column13";
      this.Column13.Name = "Column13";
      this.Column13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // Column14
      // 
      this.Column14.DisplayStyleForCurrentCellOnly = true;
      this.Column14.HeaderText = "Column14";
      this.Column14.Name = "Column14";
      this.Column14.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      // 
      // Column15
      // 
      this.Column15.DisplayStyleForCurrentCellOnly = true;
      this.Column15.HeaderText = "Column15";
      this.Column15.Name = "Column15";
      this.Column15.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      // 
      // Column16
      // 
      this.Column16.HeaderText = "Column16";
      this.Column16.Name = "Column16";
      this.Column16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // Column17
      // 
      this.Column17.DisplayStyleForCurrentCellOnly = true;
      this.Column17.HeaderText = "Column17";
      this.Column17.Name = "Column17";
      this.Column17.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      // 
      // Column18
      // 
      this.Column18.DisplayStyleForCurrentCellOnly = true;
      this.Column18.HeaderText = "Column18";
      this.Column18.Name = "Column18";
      this.Column18.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      // 
      // Column19
      // 
      this.Column19.HeaderText = "Column19";
      this.Column19.Name = "Column19";
      this.Column19.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // Column20
      // 
      this.Column20.DisplayStyleForCurrentCellOnly = true;
      this.Column20.HeaderText = "Column20";
      this.Column20.Name = "Column20";
      this.Column20.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      // 
      // Column21
      // 
      this.Column21.DisplayStyleForCurrentCellOnly = true;
      this.Column21.HeaderText = "Column21";
      this.Column21.Name = "Column21";
      this.Column21.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      // 
      // Column22
      // 
      this.Column22.HeaderText = "Column22";
      this.Column22.Name = "Column22";
      this.Column22.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // Column23
      // 
      this.Column23.DisplayStyleForCurrentCellOnly = true;
      this.Column23.HeaderText = "Column23";
      this.Column23.Name = "Column23";
      this.Column23.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      // 
      // Column24
      // 
      this.Column24.DisplayStyleForCurrentCellOnly = true;
      this.Column24.HeaderText = "Column24";
      this.Column24.Name = "Column24";
      this.Column24.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      // 
      // Column25
      // 
      this.Column25.HeaderText = "Column25";
      this.Column25.Name = "Column25";
      this.Column25.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // Column26
      // 
      this.Column26.DisplayStyleForCurrentCellOnly = true;
      this.Column26.HeaderText = "Column26";
      this.Column26.Name = "Column26";
      this.Column26.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      // 
      // Column27
      // 
      this.Column27.DisplayStyleForCurrentCellOnly = true;
      this.Column27.HeaderText = "Column27";
      this.Column27.Name = "Column27";
      this.Column27.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      // 
      // Column28
      // 
      this.Column28.HeaderText = "Column28";
      this.Column28.Name = "Column28";
      this.Column28.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // Column29
      // 
      this.Column29.DisplayStyleForCurrentCellOnly = true;
      this.Column29.HeaderText = "Column29";
      this.Column29.Name = "Column29";
      this.Column29.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      // 
      // Column30
      // 
      this.Column30.DisplayStyleForCurrentCellOnly = true;
      this.Column30.HeaderText = "Column30";
      this.Column30.Name = "Column30";
      this.Column30.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      // 
      // Column31
      // 
      this.Column31.HeaderText = "Column31";
      this.Column31.Name = "Column31";
      this.Column31.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // tvGrid
      // 
      this.tvGrid.LineColor = System.Drawing.Color.Empty;
      this.tvGrid.Location = new System.Drawing.Point(0, 0);
      this.tvGrid.Name = "tvGrid";
      this.tvGrid.Size = new System.Drawing.Size(121, 97);
      this.tvGrid.TabIndex = 0;
      // 
      // GridMenu
      // 
      this.GridMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemPasteUpData,
            this.ItemEmptyData});
      this.GridMenu.Name = "GridMenu";
      this.GridMenu.Size = new System.Drawing.Size(179, 48);
      this.GridMenu.Opening += new System.ComponentModel.CancelEventHandler(this.GridMenu_Opening);
      // 
      // ItemPasteUpData
      // 
      this.ItemPasteUpData.Name = "ItemPasteUpData";
      this.ItemPasteUpData.Size = new System.Drawing.Size(178, 22);
      this.ItemPasteUpData.Text = "toolStripMenuItem1";
      this.ItemPasteUpData.Click += new System.EventHandler(this.ItemPasteUpData_Click);
      // 
      // ItemEmptyData
      // 
      this.ItemEmptyData.Name = "ItemEmptyData";
      this.ItemEmptyData.Size = new System.Drawing.Size(178, 22);
      this.ItemEmptyData.Text = "toolStripMenuItem2";
      this.ItemEmptyData.Click += new System.EventHandler(this.ItemEmptyData_Click);
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.label1.Location = new System.Drawing.Point(10, 435);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(680, 25);
      this.label1.TabIndex = 20;
      this.label1.Text = "label1";
      // 
      // frmSFMacWay
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(894, 468);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.dataGrid);
      this.Controls.Add(this.chkAlarm);
      this.Controls.Add(this.rbDay);
      this.Controls.Add(this.rbTime);
      this.MaximizeBox = true;
      this.Name = "frmSFMacWay";
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.Controls.SetChildIndex(this.rbTime, 0);
      this.Controls.SetChildIndex(this.rbDay, 0);
      this.Controls.SetChildIndex(this.chkAlarm, 0);
      this.Controls.SetChildIndex(this.dataGrid, 0);
      this.Controls.SetChildIndex(this.label1, 0);
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
      this.GridMenu.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.CheckBox chkAlarm;
    private System.Windows.Forms.RadioButton rbDay;
    private System.Windows.Forms.RadioButton rbTime;
    private HeaderView dataGrid;
    private System.Windows.Forms.TreeView tvGrid;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ContextMenuStrip GridMenu;
    private System.Windows.Forms.ToolStripMenuItem ItemPasteUpData;
    private System.Windows.Forms.ToolStripMenuItem ItemEmptyData;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    private System.Windows.Forms.DataGridViewComboBoxColumn Column2;
    private System.Windows.Forms.DataGridViewComboBoxColumn Column3;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    private System.Windows.Forms.DataGridViewComboBoxColumn Column5;
    private System.Windows.Forms.DataGridViewComboBoxColumn Column6;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    private System.Windows.Forms.DataGridViewComboBoxColumn Column8;
    private System.Windows.Forms.DataGridViewComboBoxColumn Column9;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
    private System.Windows.Forms.DataGridViewComboBoxColumn Column11;
    private System.Windows.Forms.DataGridViewComboBoxColumn Column12;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
    private System.Windows.Forms.DataGridViewComboBoxColumn Column14;
    private System.Windows.Forms.DataGridViewComboBoxColumn Column15;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
    private System.Windows.Forms.DataGridViewComboBoxColumn Column17;
    private System.Windows.Forms.DataGridViewComboBoxColumn Column18;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
    private System.Windows.Forms.DataGridViewComboBoxColumn Column20;
    private System.Windows.Forms.DataGridViewComboBoxColumn Column21;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column22;
    private System.Windows.Forms.DataGridViewComboBoxColumn Column23;
    private System.Windows.Forms.DataGridViewComboBoxColumn Column24;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column25;
    private System.Windows.Forms.DataGridViewComboBoxColumn Column26;
    private System.Windows.Forms.DataGridViewComboBoxColumn Column27;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column28;
    private System.Windows.Forms.DataGridViewComboBoxColumn Column29;
    private System.Windows.Forms.DataGridViewComboBoxColumn Column30;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column31;
  }
}
