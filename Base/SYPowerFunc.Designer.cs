namespace ECard78
{
  partial class frmSYPowerFunc
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSYPowerFunc));
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      this.contMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ItemSelect = new System.Windows.Forms.ToolStripMenuItem();
      this.ItemUnselect = new System.Windows.Forms.ToolStripMenuItem();
      this.ItemLine1 = new System.Windows.Forms.ToolStripSeparator();
      this.ItemSelectCurrent = new System.Windows.Forms.ToolStripMenuItem();
      this.ItemSelectUnCurrent = new System.Windows.Forms.ToolStripMenuItem();
      this.ItemLine2 = new System.Windows.Forms.ToolStripSeparator();
      this.ItemSelectNewAll = new System.Windows.Forms.ToolStripMenuItem();
      this.ItemSelectNewUnAll = new System.Windows.Forms.ToolStripMenuItem();
      this.ItemLine3 = new System.Windows.Forms.ToolStripSeparator();
      this.ItemSelectEditAll = new System.Windows.Forms.ToolStripMenuItem();
      this.ItemSelectEditUnAll = new System.Windows.Forms.ToolStripMenuItem();
      this.ItemLine4 = new System.Windows.Forms.ToolStripSeparator();
      this.ItemSelectDeleteAll = new System.Windows.Forms.ToolStripMenuItem();
      this.ItemSelectDeleteUnAll = new System.Windows.Forms.ToolStripMenuItem();
      this.ItemLine5 = new System.Windows.Forms.ToolStripSeparator();
      this.ItemSelectExtAll = new System.Windows.Forms.ToolStripMenuItem();
      this.ItemSelectExtUnAll = new System.Windows.Forms.ToolStripMenuItem();
      this.ItemLine6 = new System.Windows.Forms.ToolStripSeparator();
      this.ItemSelectAll = new System.Windows.Forms.ToolStripMenuItem();
      this.ItemSelectUnAll = new System.Windows.Forms.ToolStripMenuItem();
      this.funcGrid = new RowMergeView();
      this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.Column5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.Column6 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.Column7 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.contMenu.SuspendLayout();
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
      // contMenu
      // 
      this.contMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemSelect,
            this.ItemUnselect,
            this.ItemLine1,
            this.ItemSelectCurrent,
            this.ItemSelectUnCurrent,
            this.ItemLine2,
            this.ItemSelectNewAll,
            this.ItemSelectNewUnAll,
            this.ItemLine3,
            this.ItemSelectEditAll,
            this.ItemSelectEditUnAll,
            this.ItemLine4,
            this.ItemSelectDeleteAll,
            this.ItemSelectDeleteUnAll,
            this.ItemLine5,
            this.ItemSelectExtAll,
            this.ItemSelectExtUnAll,
            this.ItemLine6,
            this.ItemSelectAll,
            this.ItemSelectUnAll});
      this.contMenu.Name = "contMenu";
      this.contMenu.Size = new System.Drawing.Size(179, 370);
      // 
      // ItemSelect
      // 
      this.ItemSelect.Name = "ItemSelect";
      this.ItemSelect.Size = new System.Drawing.Size(178, 22);
      this.ItemSelect.Text = "toolStripMenuItem1";
      this.ItemSelect.Click += new System.EventHandler(this.ItemSelect_Click);
      // 
      // ItemUnselect
      // 
      this.ItemUnselect.Name = "ItemUnselect";
      this.ItemUnselect.Size = new System.Drawing.Size(178, 22);
      this.ItemUnselect.Text = "toolStripMenuItem1";
      this.ItemUnselect.Click += new System.EventHandler(this.ItemUnselect_Click);
      // 
      // ItemLine1
      // 
      this.ItemLine1.Name = "ItemLine1";
      this.ItemLine1.Size = new System.Drawing.Size(175, 6);
      // 
      // ItemSelectCurrent
      // 
      this.ItemSelectCurrent.Name = "ItemSelectCurrent";
      this.ItemSelectCurrent.Size = new System.Drawing.Size(178, 22);
      this.ItemSelectCurrent.Text = "SelectAllCurrent";
      this.ItemSelectCurrent.Click += new System.EventHandler(this.ItemSelectCurrent_Click);
      // 
      // ItemSelectUnCurrent
      // 
      this.ItemSelectUnCurrent.Name = "ItemSelectUnCurrent";
      this.ItemSelectUnCurrent.Size = new System.Drawing.Size(178, 22);
      this.ItemSelectUnCurrent.Text = "SelectUnAllCurrent";
      this.ItemSelectUnCurrent.Click += new System.EventHandler(this.ItemSelectUnCurrent_Click);
      // 
      // ItemLine2
      // 
      this.ItemLine2.Name = "ItemLine2";
      this.ItemLine2.Size = new System.Drawing.Size(175, 6);
      // 
      // ItemSelectNewAll
      // 
      this.ItemSelectNewAll.Name = "ItemSelectNewAll";
      this.ItemSelectNewAll.Size = new System.Drawing.Size(178, 22);
      this.ItemSelectNewAll.Text = "SelectNewAll";
      this.ItemSelectNewAll.Click += new System.EventHandler(this.ItemSelectNewAll_Click);
      // 
      // ItemSelectNewUnAll
      // 
      this.ItemSelectNewUnAll.Name = "ItemSelectNewUnAll";
      this.ItemSelectNewUnAll.Size = new System.Drawing.Size(178, 22);
      this.ItemSelectNewUnAll.Text = "SelectNewUnAll";
      this.ItemSelectNewUnAll.Click += new System.EventHandler(this.ItemSelectNewUnAll_Click);
      // 
      // ItemLine3
      // 
      this.ItemLine3.Name = "ItemLine3";
      this.ItemLine3.Size = new System.Drawing.Size(175, 6);
      // 
      // ItemSelectEditAll
      // 
      this.ItemSelectEditAll.Name = "ItemSelectEditAll";
      this.ItemSelectEditAll.Size = new System.Drawing.Size(178, 22);
      this.ItemSelectEditAll.Text = "SelectEditAll";
      this.ItemSelectEditAll.Click += new System.EventHandler(this.ItemSelectEditAll_Click);
      // 
      // ItemSelectEditUnAll
      // 
      this.ItemSelectEditUnAll.Name = "ItemSelectEditUnAll";
      this.ItemSelectEditUnAll.Size = new System.Drawing.Size(178, 22);
      this.ItemSelectEditUnAll.Text = "SelectEditUnAll";
      this.ItemSelectEditUnAll.Click += new System.EventHandler(this.ItemSelectEditUnAll_Click);
      // 
      // ItemLine4
      // 
      this.ItemLine4.Name = "ItemLine4";
      this.ItemLine4.Size = new System.Drawing.Size(175, 6);
      // 
      // ItemSelectDeleteAll
      // 
      this.ItemSelectDeleteAll.Name = "ItemSelectDeleteAll";
      this.ItemSelectDeleteAll.Size = new System.Drawing.Size(178, 22);
      this.ItemSelectDeleteAll.Text = "SelectDeleteAll";
      this.ItemSelectDeleteAll.Click += new System.EventHandler(this.ItemSelectDeleteAll_Click);
      // 
      // ItemSelectDeleteUnAll
      // 
      this.ItemSelectDeleteUnAll.Name = "ItemSelectDeleteUnAll";
      this.ItemSelectDeleteUnAll.Size = new System.Drawing.Size(178, 22);
      this.ItemSelectDeleteUnAll.Text = "SelectDeleteUnAll";
      this.ItemSelectDeleteUnAll.Click += new System.EventHandler(this.ItemSelectDeleteUnAll_Click);
      // 
      // ItemLine5
      // 
      this.ItemLine5.Name = "ItemLine5";
      this.ItemLine5.Size = new System.Drawing.Size(175, 6);
      // 
      // ItemSelectExtAll
      // 
      this.ItemSelectExtAll.Name = "ItemSelectExtAll";
      this.ItemSelectExtAll.Size = new System.Drawing.Size(178, 22);
      this.ItemSelectExtAll.Text = "SelectExtAll";
      this.ItemSelectExtAll.Click += new System.EventHandler(this.ItemSelectExtAll_Click);
      // 
      // ItemSelectExtUnAll
      // 
      this.ItemSelectExtUnAll.Name = "ItemSelectExtUnAll";
      this.ItemSelectExtUnAll.Size = new System.Drawing.Size(178, 22);
      this.ItemSelectExtUnAll.Text = "SelectExtUnAll";
      this.ItemSelectExtUnAll.Click += new System.EventHandler(this.ItemSelectExtUnAll_Click);
      // 
      // ItemLine6
      // 
      this.ItemLine6.Name = "ItemLine6";
      this.ItemLine6.Size = new System.Drawing.Size(175, 6);
      // 
      // ItemSelectAll
      // 
      this.ItemSelectAll.Name = "ItemSelectAll";
      this.ItemSelectAll.Size = new System.Drawing.Size(178, 22);
      this.ItemSelectAll.Text = "ItemSelectAll";
      this.ItemSelectAll.Click += new System.EventHandler(this.ItemSelectAll_Click);
      // 
      // ItemSelectUnAll
      // 
      this.ItemSelectUnAll.Name = "ItemSelectUnAll";
      this.ItemSelectUnAll.Size = new System.Drawing.Size(178, 22);
      this.ItemSelectUnAll.Text = "ItemSelectUnAll";
      this.ItemSelectUnAll.Click += new System.EventHandler(this.ItemSelectUnAll_Click);
      // 
      // funcGrid
      // 
      this.funcGrid.AllowUserToAddRows = false;
      this.funcGrid.AllowUserToDeleteRows = false;
      this.funcGrid.AllowUserToResizeRows = false;
      this.funcGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.funcGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.funcGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.funcGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
      this.funcGrid.ContextMenuStrip = this.contMenu;
      dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.funcGrid.DefaultCellStyle = dataGridViewCellStyle4;
      this.funcGrid.Location = new System.Drawing.Point(10, 10);
      this.funcGrid.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
      this.funcGrid.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("funcGrid.MergeColumnNames")));
      this.funcGrid.MultiSelect = false;
      this.funcGrid.Name = "funcGrid";
      dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.funcGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
      this.funcGrid.RowHeadersVisible = false;
      this.funcGrid.RowTemplate.Height = 23;
      this.funcGrid.Size = new System.Drawing.Size(535, 275);
      this.funcGrid.TabIndex = 0;
      this.funcGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.funcGrid_CellClick);
      // 
      // Column1
      // 
      this.Column1.DataPropertyName = "Module";
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
      this.Column1.HeaderText = "Column1";
      this.Column1.Name = "Column1";
      this.Column1.ReadOnly = true;
      this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // Column2
      // 
      this.Column2.DataPropertyName = "SubName";
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
      this.Column2.HeaderText = "Column2";
      this.Column2.Name = "Column2";
      this.Column2.ReadOnly = true;
      this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Column2.Width = 110;
      // 
      // Column3
      // 
      this.Column3.DataPropertyName = "PowerE";
      this.Column3.HeaderText = "Column3";
      this.Column3.Name = "Column3";
      this.Column3.Width = 60;
      // 
      // Column4
      // 
      this.Column4.DataPropertyName = "PowerN";
      this.Column4.HeaderText = "Column4";
      this.Column4.Name = "Column4";
      this.Column4.Width = 60;
      // 
      // Column5
      // 
      this.Column5.DataPropertyName = "PowerM";
      this.Column5.HeaderText = "Column5";
      this.Column5.Name = "Column5";
      this.Column5.Width = 60;
      // 
      // Column6
      // 
      this.Column6.DataPropertyName = "PowerD";
      this.Column6.HeaderText = "Column6";
      this.Column6.Name = "Column6";
      this.Column6.Width = 60;
      // 
      // Column7
      // 
      this.Column7.DataPropertyName = "PowerEX";
      this.Column7.HeaderText = "Column7";
      this.Column7.Name = "Column7";
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
      // frmSYPowerFunc
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(554, 328);
      this.Controls.Add(this.funcGrid);
      this.Name = "frmSYPowerFunc";
      this.Controls.SetChildIndex(this.funcGrid, 0);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.contMenu.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.funcGrid)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ContextMenuStrip contMenu;
    private System.Windows.Forms.ToolStripMenuItem ItemSelectCurrent;
    private System.Windows.Forms.ToolStripMenuItem ItemSelectUnCurrent;
    private System.Windows.Forms.ToolStripSeparator ItemLine2;
    private System.Windows.Forms.ToolStripMenuItem ItemSelectNewAll;
    private System.Windows.Forms.ToolStripMenuItem ItemSelectNewUnAll;
    private System.Windows.Forms.ToolStripSeparator ItemLine3;
    private System.Windows.Forms.ToolStripMenuItem ItemSelectEditAll;
    private System.Windows.Forms.ToolStripMenuItem ItemSelectEditUnAll;
    private System.Windows.Forms.ToolStripSeparator ItemLine4;
    private System.Windows.Forms.ToolStripMenuItem ItemSelectDeleteAll;
    private System.Windows.Forms.ToolStripMenuItem ItemSelectDeleteUnAll;
    private System.Windows.Forms.ToolStripSeparator ItemLine5;
    private System.Windows.Forms.ToolStripMenuItem ItemSelectExtAll;
    private System.Windows.Forms.ToolStripMenuItem ItemSelectExtUnAll;
    private System.Windows.Forms.ToolStripMenuItem ItemSelect;
    private System.Windows.Forms.ToolStripMenuItem ItemUnselect;
    private System.Windows.Forms.ToolStripSeparator ItemLine1;
    private System.Windows.Forms.ToolStripSeparator ItemLine6;
    private System.Windows.Forms.ToolStripMenuItem ItemSelectAll;
    private System.Windows.Forms.ToolStripMenuItem ItemSelectUnAll;
    private RowMergeView funcGrid;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    private System.Windows.Forms.DataGridViewCheckBoxColumn Column3;
    private System.Windows.Forms.DataGridViewCheckBoxColumn Column4;
    private System.Windows.Forms.DataGridViewCheckBoxColumn Column5;
    private System.Windows.Forms.DataGridViewCheckBoxColumn Column6;
    private System.Windows.Forms.DataGridViewCheckBoxColumn Column7;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
  }
}
