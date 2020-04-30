namespace ECard78
{
  partial class frmPubFind
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.button2 = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.dataGrid = new System.Windows.Forms.DataGridView();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.button4 = new System.Windows.Forms.Button();
      this.button3 = new System.Windows.Forms.Button();
      this.orderGrid = new System.Windows.Forms.DataGridView();
      this.Column5 = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.Column1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.Column2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.Column3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column13 = new System.Windows.Forms.DataGridViewButtonColumn();
      this.Column6 = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column9 = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.Column10 = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
      this.groupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.orderGrid)).BeginInit();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(710, 385);
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(630, 385);
      this.btnOk.Text = "";
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.button2);
      this.groupBox1.Controls.Add(this.button1);
      this.groupBox1.Controls.Add(this.dataGrid);
      this.groupBox1.Location = new System.Drawing.Point(10, 10);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(545, 365);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "groupBox1";
      // 
      // button2
      // 
      this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.button2.Location = new System.Drawing.Point(90, 330);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(75, 25);
      this.button2.TabIndex = 22;
      this.button2.Text = "button2";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // button1
      // 
      this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.button1.Location = new System.Drawing.Point(10, 330);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 25);
      this.button1.TabIndex = 21;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // dataGrid
      // 
      this.dataGrid.AllowUserToAddRows = false;
      this.dataGrid.AllowUserToDeleteRows = false;
      this.dataGrid.AllowUserToResizeRows = false;
      this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column13,
            this.Column6,
            this.Column7,
            this.Column8});
      this.dataGrid.Location = new System.Drawing.Point(10, 20);
      this.dataGrid.Name = "dataGrid";
      this.dataGrid.RowHeadersVisible = false;
      this.dataGrid.RowTemplate.Height = 23;
      this.dataGrid.Size = new System.Drawing.Size(525, 300);
      this.dataGrid.TabIndex = 0;
      this.dataGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellValueChanged);
      this.dataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellClick);
      this.dataGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGrid_DataError);
      // 
      // groupBox2
      // 
      this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox2.Controls.Add(this.button4);
      this.groupBox2.Controls.Add(this.button3);
      this.groupBox2.Controls.Add(this.orderGrid);
      this.groupBox2.Location = new System.Drawing.Point(565, 10);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(220, 365);
      this.groupBox2.TabIndex = 1;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "groupBox2";
      // 
      // button4
      // 
      this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.button4.Location = new System.Drawing.Point(90, 330);
      this.button4.Name = "button4";
      this.button4.Size = new System.Drawing.Size(75, 25);
      this.button4.TabIndex = 3;
      this.button4.Text = "button4";
      this.button4.UseVisualStyleBackColor = true;
      this.button4.Click += new System.EventHandler(this.button4_Click);
      // 
      // button3
      // 
      this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.button3.Location = new System.Drawing.Point(10, 330);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(75, 25);
      this.button3.TabIndex = 2;
      this.button3.Text = "button3";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new System.EventHandler(this.button3_Click);
      // 
      // orderGrid
      // 
      this.orderGrid.AllowUserToAddRows = false;
      this.orderGrid.AllowUserToDeleteRows = false;
      this.orderGrid.AllowUserToResizeRows = false;
      this.orderGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.orderGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
      this.orderGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.orderGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12});
      this.orderGrid.Location = new System.Drawing.Point(10, 20);
      this.orderGrid.Name = "orderGrid";
      this.orderGrid.RowHeadersVisible = false;
      this.orderGrid.RowTemplate.Height = 23;
      this.orderGrid.Size = new System.Drawing.Size(200, 300);
      this.orderGrid.TabIndex = 1;
      this.orderGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.orderGrid_CellValueChanged);
      this.orderGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.orderGrid_DataError);
      // 
      // Column5
      // 
      this.Column5.DisplayStyleForCurrentCellOnly = true;
      this.Column5.HeaderText = "Column5";
      this.Column5.Name = "Column5";
      this.Column5.Width = 60;
      // 
      // Column1
      // 
      this.Column1.DisplayStyleForCurrentCellOnly = true;
      this.Column1.HeaderText = "Column1";
      this.Column1.Items.AddRange(new object[] {
            "",
            "("});
      this.Column1.Name = "Column1";
      this.Column1.Width = 60;
      // 
      // Column2
      // 
      this.Column2.DisplayStyleForCurrentCellOnly = true;
      this.Column2.HeaderText = "Column2";
      this.Column2.Name = "Column2";
      // 
      // Column3
      // 
      this.Column3.DisplayStyleForCurrentCellOnly = true;
      this.Column3.HeaderText = "Column3";
      this.Column3.Name = "Column3";
      this.Column3.Width = 60;
      // 
      // Column4
      // 
      this.Column4.HeaderText = "Column4";
      this.Column4.Name = "Column4";
      this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // Column13
      // 
      this.Column13.DataPropertyName = "SelectCheck";
      this.Column13.HeaderText = "Column13";
      this.Column13.Name = "Column13";
      this.Column13.Text = "...";
      this.Column13.Width = 60;
      // 
      // Column6
      // 
      this.Column6.DisplayStyleForCurrentCellOnly = true;
      this.Column6.HeaderText = "Column6";
      this.Column6.Items.AddRange(new object[] {
            "",
            ")"});
      this.Column6.Name = "Column6";
      this.Column6.Width = 60;
      // 
      // Column7
      // 
      this.Column7.HeaderText = "Column7";
      this.Column7.Name = "Column7";
      this.Column7.Visible = false;
      // 
      // Column8
      // 
      this.Column8.HeaderText = "Column8";
      this.Column8.Name = "Column8";
      this.Column8.Visible = false;
      // 
      // Column9
      // 
      this.Column9.DisplayStyleForCurrentCellOnly = true;
      this.Column9.HeaderText = "Column9";
      this.Column9.Name = "Column9";
      this.Column9.Width = 120;
      // 
      // Column10
      // 
      this.Column10.DisplayStyleForCurrentCellOnly = true;
      this.Column10.HeaderText = "Column10";
      this.Column10.Name = "Column10";
      this.Column10.Width = 60;
      // 
      // Column11
      // 
      this.Column11.HeaderText = "Column11";
      this.Column11.Name = "Column11";
      this.Column11.Visible = false;
      // 
      // Column12
      // 
      this.Column12.HeaderText = "Column12";
      this.Column12.Name = "Column12";
      this.Column12.Visible = false;
      // 
      // frmPubFind
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(794, 418);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.groupBox2);
      this.Name = "frmPubFind";
      this.Controls.SetChildIndex(this.groupBox2, 0);
      this.Controls.SetChildIndex(this.groupBox1, 0);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.groupBox1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
      this.groupBox2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.orderGrid)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.DataGridView dataGrid;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.DataGridView orderGrid;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.DataGridViewComboBoxColumn Column5;
    private System.Windows.Forms.DataGridViewComboBoxColumn Column1;
    private System.Windows.Forms.DataGridViewComboBoxColumn Column2;
    private System.Windows.Forms.DataGridViewComboBoxColumn Column3;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    private System.Windows.Forms.DataGridViewButtonColumn Column13;
    private System.Windows.Forms.DataGridViewComboBoxColumn Column6;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    private System.Windows.Forms.DataGridViewComboBoxColumn Column9;
    private System.Windows.Forms.DataGridViewComboBoxColumn Column10;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
  }
}
