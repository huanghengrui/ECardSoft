namespace ECard78
{
  partial class frmMainHomeAdd
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainHomeAdd));
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
      this.funcGrid = new RowMergeView();
      this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cbbOrder = new System.Windows.Forms.ComboBox();
      this.button2 = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.funcGrid)).BeginInit();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Text = "";
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // funcGrid
      // 
      this.funcGrid.AllowUserToAddRows = false;
      this.funcGrid.AllowUserToDeleteRows = false;
      this.funcGrid.AllowUserToResizeRows = false;
      this.funcGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.funcGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
      this.funcGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.funcGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column7,
            this.Column8,
            this.Column9});
      dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle14.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.funcGrid.DefaultCellStyle = dataGridViewCellStyle14;
      this.funcGrid.Location = new System.Drawing.Point(10, 10);
      this.funcGrid.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
      this.funcGrid.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("funcGrid.MergeColumnNames")));
      this.funcGrid.MultiSelect = false;
      this.funcGrid.Name = "funcGrid";
      dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle15.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.funcGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
      this.funcGrid.RowHeadersVisible = false;
      this.funcGrid.RowTemplate.Height = 23;
      this.funcGrid.Size = new System.Drawing.Size(535, 275);
      this.funcGrid.TabIndex = 0;
      this.funcGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.funcGrid_CellEndEdit);
      this.funcGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.funcGrid_DataError);
      // 
      // Column1
      // 
      this.Column1.DataPropertyName = "Module";
      dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      this.Column1.DefaultCellStyle = dataGridViewCellStyle12;
      this.Column1.HeaderText = "Column1";
      this.Column1.Name = "Column1";
      this.Column1.ReadOnly = true;
      this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // Column2
      // 
      this.Column2.DataPropertyName = "SubName";
      dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      this.Column2.DefaultCellStyle = dataGridViewCellStyle13;
      this.Column2.HeaderText = "Column2";
      this.Column2.Name = "Column2";
      this.Column2.ReadOnly = true;
      this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Column2.Width = 150;
      // 
      // Column3
      // 
      this.Column3.DataPropertyName = "FuncShow";
      this.Column3.HeaderText = "Column3";
      this.Column3.Name = "Column3";
      this.Column3.Width = 60;
      // 
      // Column7
      // 
      this.Column7.DataPropertyName = "FuncOrder";
      this.Column7.HeaderText = "Column7";
      this.Column7.Name = "Column7";
      this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.Column7.Width = 60;
      // 
      // Column8
      // 
      this.Column8.DataPropertyName = "ModuleID";
      this.Column8.HeaderText = "Column8";
      this.Column8.Name = "Column8";
      this.Column8.ReadOnly = true;
      this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Column8.Visible = false;
      // 
      // Column9
      // 
      this.Column9.DataPropertyName = "SubID";
      this.Column9.HeaderText = "Column9";
      this.Column9.Name = "Column9";
      this.Column9.ReadOnly = true;
      this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Column9.Visible = false;
      // 
      // cbbOrder
      // 
      this.cbbOrder.Enabled = false;
      this.cbbOrder.FormattingEnabled = true;
      this.cbbOrder.Location = new System.Drawing.Point(10, 290);
      this.cbbOrder.Name = "cbbOrder";
      this.cbbOrder.Size = new System.Drawing.Size(121, 20);
      this.cbbOrder.Sorted = true;
      this.cbbOrder.TabIndex = 19;
      this.cbbOrder.Visible = false;
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(90, 295);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(75, 25);
      this.button2.TabIndex = 21;
      this.button2.Tag = "ItemUnselect";
      this.button2.Text = "button2";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(10, 295);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 25);
      this.button1.TabIndex = 20;
      this.button1.Tag = "ItemSelect";
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // frmMainHomeAdd
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(554, 328);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.cbbOrder);
      this.Controls.Add(this.funcGrid);
      this.Name = "frmMainHomeAdd";
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.Controls.SetChildIndex(this.funcGrid, 0);
      this.Controls.SetChildIndex(this.cbbOrder, 0);
      this.Controls.SetChildIndex(this.button1, 0);
      this.Controls.SetChildIndex(this.button2, 0);
      ((System.ComponentModel.ISupportInitialize)(this.funcGrid)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private RowMergeView funcGrid;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    private System.Windows.Forms.DataGridViewCheckBoxColumn Column3;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    private System.Windows.Forms.ComboBox cbbOrder;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button1;
  }
}
