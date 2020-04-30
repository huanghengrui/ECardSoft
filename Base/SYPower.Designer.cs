namespace ECard78
{
  partial class frmSYPower
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSYPower));
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      this.tabControl = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.funcGrid = new RowMergeView();
      this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column12 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.Column13 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.Column14 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.Column15 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.Column16 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.tvDepart = new System.Windows.Forms.TreeView();
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
      this.tabControl.SuspendLayout();
      this.tabPage1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.funcGrid)).BeginInit();
      this.tabPage2.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControl
      // 
      this.tabControl.Controls.Add(this.tabPage1);
      this.tabControl.Controls.Add(this.tabPage2);
      this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl.Location = new System.Drawing.Point(0, 25);
      this.tabControl.Name = "tabControl";
      this.tabControl.SelectedIndex = 0;
      this.tabControl.Size = new System.Drawing.Size(554, 277);
      this.tabControl.TabIndex = 7;
      // 
      // tabPage1
      // 
      this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
      this.tabPage1.Controls.Add(this.funcGrid);
      this.tabPage1.Location = new System.Drawing.Point(4, 21);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(546, 252);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "tabPage1";
      // 
      // funcGrid
      // 
      this.funcGrid.AllowUserToAddRows = false;
      this.funcGrid.AllowUserToDeleteRows = false;
      this.funcGrid.AllowUserToResizeRows = false;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.funcGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.funcGrid.ColumnHeadersHeight = 25;
      this.funcGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.funcGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14,
            this.Column15,
            this.Column16,
            this.Column17,
            this.Column18});
      dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.funcGrid.DefaultCellStyle = dataGridViewCellStyle4;
      this.funcGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.funcGrid.Location = new System.Drawing.Point(3, 3);
      this.funcGrid.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
      this.funcGrid.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("funcGrid.MergeColumnNames")));
      this.funcGrid.MultiSelect = false;
      this.funcGrid.Name = "funcGrid";
      this.funcGrid.ReadOnly = true;
      this.funcGrid.RowHeadersVisible = false;
      this.funcGrid.RowTemplate.Height = 23;
      this.funcGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.funcGrid.Size = new System.Drawing.Size(540, 246);
      this.funcGrid.StandardTab = true;
      this.funcGrid.TabIndex = 7;
      // 
      // Column10
      // 
      this.Column10.DataPropertyName = "Module";
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      this.Column10.DefaultCellStyle = dataGridViewCellStyle2;
      this.Column10.HeaderText = "Column10";
      this.Column10.Name = "Column10";
      this.Column10.ReadOnly = true;
      this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // Column11
      // 
      this.Column11.DataPropertyName = "SubName";
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      this.Column11.DefaultCellStyle = dataGridViewCellStyle3;
      this.Column11.HeaderText = "Column11";
      this.Column11.Name = "Column11";
      this.Column11.ReadOnly = true;
      this.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // Column12
      // 
      this.Column12.DataPropertyName = "PowerE";
      this.Column12.HeaderText = "Column12";
      this.Column12.Name = "Column12";
      this.Column12.ReadOnly = true;
      // 
      // Column13
      // 
      this.Column13.DataPropertyName = "PowerN";
      this.Column13.HeaderText = "Column13";
      this.Column13.Name = "Column13";
      this.Column13.ReadOnly = true;
      // 
      // Column14
      // 
      this.Column14.DataPropertyName = "PowerM";
      this.Column14.HeaderText = "Column14";
      this.Column14.Name = "Column14";
      this.Column14.ReadOnly = true;
      // 
      // Column15
      // 
      this.Column15.DataPropertyName = "PowerD";
      this.Column15.HeaderText = "Column15";
      this.Column15.Name = "Column15";
      this.Column15.ReadOnly = true;
      // 
      // Column16
      // 
      this.Column16.DataPropertyName = "PowerEX";
      this.Column16.HeaderText = "Column16";
      this.Column16.Name = "Column16";
      this.Column16.ReadOnly = true;
      // 
      // Column17
      // 
      this.Column17.DataPropertyName = "ModuleID";
      this.Column17.HeaderText = "Column17";
      this.Column17.Name = "Column17";
      this.Column17.ReadOnly = true;
      this.Column17.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Column17.Visible = false;
      // 
      // Column18
      // 
      this.Column18.DataPropertyName = "SubID";
      this.Column18.HeaderText = "Column18";
      this.Column18.Name = "Column18";
      this.Column18.ReadOnly = true;
      this.Column18.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Column18.Visible = false;
      // 
      // tabPage2
      // 
      this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
      this.tabPage2.Controls.Add(this.tvDepart);
      this.tabPage2.Location = new System.Drawing.Point(4, 21);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(546, 252);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "tabPage2";
      // 
      // tvDepart
      // 
      this.tvDepart.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tvDepart.FullRowSelect = true;
      this.tvDepart.HideSelection = false;
      this.tvDepart.ItemHeight = 20;
      this.tvDepart.Location = new System.Drawing.Point(3, 3);
      this.tvDepart.Name = "tvDepart";
      this.tvDepart.Size = new System.Drawing.Size(540, 246);
      this.tvDepart.StateImageList = this.imageList1;
      this.tvDepart.TabIndex = 0;
      // 
      // imageList1
      // 
      this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList1.Images.SetKeyName(0, "T1.bmp");
      this.imageList1.Images.SetKeyName(1, "T2.bmp");
      // 
      // frmSYPower
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(554, 328);
      this.Controls.Add(this.tabControl);
      this.Name = "frmSYPower";
      this.Controls.SetChildIndex(this.tabControl, 0);
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
      this.tabControl.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.funcGrid)).EndInit();
      this.tabPage2.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private RowMergeView funcGrid;
    private System.Windows.Forms.TreeView tvDepart;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
    private System.Windows.Forms.DataGridViewCheckBoxColumn Column12;
    private System.Windows.Forms.DataGridViewCheckBoxColumn Column13;
    private System.Windows.Forms.DataGridViewCheckBoxColumn Column14;
    private System.Windows.Forms.DataGridViewCheckBoxColumn Column15;
    private System.Windows.Forms.DataGridViewCheckBoxColumn Column16;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
    private System.Windows.Forms.ImageList imageList1;
  }
}
