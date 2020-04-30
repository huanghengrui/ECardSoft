namespace ECard78
{
  partial class frmSFAllowanceDownSelect
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSFAllowanceDownSelect));
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      this.rbAll = new System.Windows.Forms.RadioButton();
      this.rbEmp = new System.Windows.Forms.RadioButton();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.btnClear = new System.Windows.Forms.Button();
      this.lblQuickSearchToolTip = new System.Windows.Forms.Label();
      this.cardGrid = new System.Windows.Forms.DataGridView();
      this.txtQuickSearch = new System.Windows.Forms.TextBox();
      this.lblQuickSearch = new System.Windows.Forms.Label();
      this.btnQuickSearch = new System.Windows.Forms.Button();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cardGrid)).BeginInit();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(510, 335);
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(430, 335);
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
      // rbAll
      // 
      this.rbAll.AutoSize = true;
      this.rbAll.Checked = true;
      this.rbAll.Location = new System.Drawing.Point(10, 10);
      this.rbAll.Name = "rbAll";
      this.rbAll.Size = new System.Drawing.Size(95, 16);
      this.rbAll.TabIndex = 2;
      this.rbAll.TabStop = true;
      this.rbAll.Text = "radioButton1";
      this.rbAll.UseVisualStyleBackColor = true;
      this.rbAll.Click += new System.EventHandler(this.RadioButton_Click);
      // 
      // rbEmp
      // 
      this.rbEmp.AutoSize = true;
      this.rbEmp.Location = new System.Drawing.Point(10, 30);
      this.rbEmp.Name = "rbEmp";
      this.rbEmp.Size = new System.Drawing.Size(95, 16);
      this.rbEmp.TabIndex = 3;
      this.rbEmp.Text = "radioButton2";
      this.rbEmp.UseVisualStyleBackColor = true;
      this.rbEmp.Click += new System.EventHandler(this.RadioButton_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.btnClear);
      this.groupBox1.Controls.Add(this.lblQuickSearchToolTip);
      this.groupBox1.Controls.Add(this.cardGrid);
      this.groupBox1.Controls.Add(this.txtQuickSearch);
      this.groupBox1.Controls.Add(this.lblQuickSearch);
      this.groupBox1.Controls.Add(this.btnQuickSearch);
      this.groupBox1.Location = new System.Drawing.Point(10, 55);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(575, 270);
      this.groupBox1.TabIndex = 4;
      this.groupBox1.TabStop = false;
      this.groupBox1.Tag = "EmpList";
      this.groupBox1.Text = "groupBox1";
      // 
      // btnClear
      // 
      this.btnClear.Location = new System.Drawing.Point(90, 20);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new System.Drawing.Size(75, 25);
      this.btnClear.TabIndex = 5;
      this.btnClear.Text = "button1";
      this.btnClear.UseVisualStyleBackColor = true;
      // 
      // lblQuickSearchToolTip
      // 
      this.lblQuickSearchToolTip.AutoSize = true;
      this.lblQuickSearchToolTip.ForeColor = System.Drawing.Color.Blue;
      this.lblQuickSearchToolTip.Location = new System.Drawing.Point(355, 26);
      this.lblQuickSearchToolTip.Name = "lblQuickSearchToolTip";
      this.lblQuickSearchToolTip.Size = new System.Drawing.Size(41, 12);
      this.lblQuickSearchToolTip.TabIndex = 9;
      this.lblQuickSearchToolTip.Text = "label1";
      // 
      // cardGrid
      // 
      this.cardGrid.AllowUserToAddRows = false;
      this.cardGrid.AllowUserToDeleteRows = false;
      this.cardGrid.AllowUserToResizeRows = false;
      this.cardGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.cardGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.cardGrid.ColumnHeadersHeight = 25;
      this.cardGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.cardGrid.DefaultCellStyle = dataGridViewCellStyle2;
      this.cardGrid.Location = new System.Drawing.Point(10, 50);
      this.cardGrid.MultiSelect = false;
      this.cardGrid.Name = "cardGrid";
      this.cardGrid.ReadOnly = true;
      this.cardGrid.RowHeadersVisible = false;
      this.cardGrid.RowTemplate.Height = 23;
      this.cardGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.cardGrid.Size = new System.Drawing.Size(555, 210);
      this.cardGrid.StandardTab = true;
      this.cardGrid.TabIndex = 8;
      // 
      // txtQuickSearch
      // 
      this.txtQuickSearch.Location = new System.Drawing.Point(250, 22);
      this.txtQuickSearch.Name = "txtQuickSearch";
      this.txtQuickSearch.Size = new System.Drawing.Size(100, 21);
      this.txtQuickSearch.TabIndex = 6;
      this.txtQuickSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuickSearch_KeyDown);
      // 
      // lblQuickSearch
      // 
      this.lblQuickSearch.AutoSize = true;
      this.lblQuickSearch.Location = new System.Drawing.Point(170, 26);
      this.lblQuickSearch.Name = "lblQuickSearch";
      this.lblQuickSearch.Size = new System.Drawing.Size(41, 12);
      this.lblQuickSearch.TabIndex = 5;
      this.lblQuickSearch.Text = "label1";
      // 
      // btnQuickSearch
      // 
      this.btnQuickSearch.Location = new System.Drawing.Point(10, 20);
      this.btnQuickSearch.Name = "btnQuickSearch";
      this.btnQuickSearch.Size = new System.Drawing.Size(75, 25);
      this.btnQuickSearch.TabIndex = 4;
      this.btnQuickSearch.Text = "button1";
      this.btnQuickSearch.UseVisualStyleBackColor = true;
      this.btnQuickSearch.Click += new System.EventHandler(this.btnQuickSearch_Click);
      // 
      // frmSFAllowanceDownSelect
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(594, 368);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.rbEmp);
      this.Controls.Add(this.rbAll);
      this.Name = "frmSFAllowanceDownSelect";
      this.Controls.SetChildIndex(this.rbAll, 0);
      this.Controls.SetChildIndex(this.rbEmp, 0);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.Controls.SetChildIndex(this.groupBox1, 0);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cardGrid)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.RadioButton rbAll;
    private System.Windows.Forms.RadioButton rbEmp;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.DataGridView cardGrid;
    private System.Windows.Forms.TextBox txtQuickSearch;
    private System.Windows.Forms.Label lblQuickSearch;
    private System.Windows.Forms.Button btnQuickSearch;
    private System.Windows.Forms.Label lblQuickSearchToolTip;
    private System.Windows.Forms.Button btnClear;
  }
}
