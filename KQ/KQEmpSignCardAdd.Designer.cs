namespace ECard78
{
  partial class frmKQEmpSignCardAdd
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
      this.txtRemark = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.txtDepart = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.txtEmpName = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.btnSelectEmp = new System.Windows.Forms.Button();
      this.txtEmpNo = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.dataGrid = new System.Windows.Forms.DataGridView();
      this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.cardGrid = new System.Windows.Forms.DataGridView();
      this.txtQuickSearch = new System.Windows.Forms.TextBox();
      this.lblQuickSearch = new System.Windows.Forms.Label();
      this.btnQuickSearch = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.btnClear = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cardGrid)).BeginInit();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(545, 295);
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(465, 295);
      this.btnOk.Text = "";
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // txtRemark
      // 
      this.txtRemark.Location = new System.Drawing.Point(100, 100);
      this.txtRemark.MaxLength = 2000;
      this.txtRemark.Multiline = true;
      this.txtRemark.Name = "txtRemark";
      this.txtRemark.Size = new System.Drawing.Size(160, 65);
      this.txtRemark.TabIndex = 4;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(10, 104);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(41, 12);
      this.label8.TabIndex = 43;
      this.label8.Tag = "Remark";
      this.label8.Text = "label8";
      // 
      // txtDepart
      // 
      this.txtDepart.Location = new System.Drawing.Point(100, 70);
      this.txtDepart.Name = "txtDepart";
      this.txtDepart.ReadOnly = true;
      this.txtDepart.Size = new System.Drawing.Size(160, 21);
      this.txtDepart.TabIndex = 3;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
      this.label4.Location = new System.Drawing.Point(10, 74);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(41, 12);
      this.label4.TabIndex = 42;
      this.label4.Tag = "Depart";
      this.label4.Text = "label4";
      // 
      // txtEmpName
      // 
      this.txtEmpName.Location = new System.Drawing.Point(100, 40);
      this.txtEmpName.Name = "txtEmpName";
      this.txtEmpName.ReadOnly = true;
      this.txtEmpName.Size = new System.Drawing.Size(160, 21);
      this.txtEmpName.TabIndex = 2;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
      this.label3.Location = new System.Drawing.Point(10, 44);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(41, 12);
      this.label3.TabIndex = 41;
      this.label3.Tag = "EmpName";
      this.label3.Text = "label3";
      // 
      // btnSelectEmp
      // 
      this.btnSelectEmp.Location = new System.Drawing.Point(225, 11);
      this.btnSelectEmp.Name = "btnSelectEmp";
      this.btnSelectEmp.Size = new System.Drawing.Size(34, 19);
      this.btnSelectEmp.TabIndex = 1;
      this.btnSelectEmp.Text = "button1";
      this.btnSelectEmp.UseVisualStyleBackColor = true;
      this.btnSelectEmp.Click += new System.EventHandler(this.btnSelectEmp_Click);
      // 
      // txtEmpNo
      // 
      this.txtEmpNo.Location = new System.Drawing.Point(100, 10);
      this.txtEmpNo.Name = "txtEmpNo";
      this.txtEmpNo.Size = new System.Drawing.Size(160, 21);
      this.txtEmpNo.TabIndex = 0;
      this.txtEmpNo.Leave += new System.EventHandler(this.txtEmpNo_Leave);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.ForeColor = System.Drawing.Color.Red;
      this.label2.Location = new System.Drawing.Point(10, 14);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(41, 12);
      this.label2.TabIndex = 40;
      this.label2.Tag = "EmpNo";
      this.label2.Text = "label2";
      // 
      // dataGrid
      // 
      this.dataGrid.AllowUserToAddRows = false;
      this.dataGrid.AllowUserToDeleteRows = false;
      this.dataGrid.AllowUserToResizeRows = false;
      dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
      this.dataGrid.ColumnHeadersHeight = 25;
      this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
      dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dataGrid.DefaultCellStyle = dataGridViewCellStyle6;
      this.dataGrid.Location = new System.Drawing.Point(10, 175);
      this.dataGrid.MultiSelect = false;
      this.dataGrid.Name = "dataGrid";
      this.dataGrid.ReadOnly = true;
      this.dataGrid.RowHeadersVisible = false;
      this.dataGrid.RowTemplate.Height = 23;
      this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dataGrid.Size = new System.Drawing.Size(250, 110);
      this.dataGrid.StandardTab = true;
      this.dataGrid.TabIndex = 5;
      // 
      // Column1
      // 
      this.Column1.DataPropertyName = "CardKQDate";
      this.Column1.HeaderText = "Column1";
      this.Column1.Name = "Column1";
      this.Column1.ReadOnly = true;
      this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Column1.Width = 80;
      // 
      // Column2
      // 
      this.Column2.DataPropertyName = "CardKQTime";
      this.Column2.HeaderText = "Column2";
      this.Column2.Name = "Column2";
      this.Column2.ReadOnly = true;
      this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Column2.Width = 60;
      // 
      // Column3
      // 
      this.Column3.DataPropertyName = "CardKQDays";
      this.Column3.HeaderText = "Column3";
      this.Column3.Name = "Column3";
      this.Column3.ReadOnly = true;
      this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Column3.Width = 90;
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.btnClear);
      this.groupBox1.Controls.Add(this.cardGrid);
      this.groupBox1.Controls.Add(this.txtQuickSearch);
      this.groupBox1.Controls.Add(this.lblQuickSearch);
      this.groupBox1.Controls.Add(this.btnQuickSearch);
      this.groupBox1.Location = new System.Drawing.Point(270, 10);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(350, 275);
      this.groupBox1.TabIndex = 6;
      this.groupBox1.TabStop = false;
      this.groupBox1.Tag = "SameEmp";
      this.groupBox1.Text = "groupBox1";
      // 
      // cardGrid
      // 
      this.cardGrid.AllowUserToAddRows = false;
      this.cardGrid.AllowUserToDeleteRows = false;
      this.cardGrid.AllowUserToResizeRows = false;
      dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.cardGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
      this.cardGrid.ColumnHeadersHeight = 25;
      this.cardGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.cardGrid.DefaultCellStyle = dataGridViewCellStyle8;
      this.cardGrid.Location = new System.Drawing.Point(10, 50);
      this.cardGrid.MultiSelect = false;
      this.cardGrid.Name = "cardGrid";
      this.cardGrid.ReadOnly = true;
      this.cardGrid.RowHeadersVisible = false;
      this.cardGrid.RowTemplate.Height = 23;
      this.cardGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.cardGrid.Size = new System.Drawing.Size(330, 215);
      this.cardGrid.StandardTab = true;
      this.cardGrid.TabIndex = 8;
      // 
      // txtQuickSearch
      // 
      this.txtQuickSearch.Location = new System.Drawing.Point(250, 22);
      this.txtQuickSearch.Name = "txtQuickSearch";
      this.txtQuickSearch.Size = new System.Drawing.Size(90, 21);
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
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(90, 295);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(75, 25);
      this.button2.TabIndex = 8;
      this.button2.Tag = "ItemDelete";
      this.button2.Text = "button2";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(10, 295);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 25);
      this.button1.TabIndex = 7;
      this.button1.Tag = "ItemAdd";
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // btnClear
      // 
      this.btnClear.Location = new System.Drawing.Point(90, 20);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new System.Drawing.Size(75, 25);
      this.btnClear.TabIndex = 5;
      this.btnClear.Text = "button1";
      this.btnClear.UseVisualStyleBackColor = true;
      this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
      // 
      // frmKQEmpSignCardAdd
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(629, 328);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.dataGrid);
      this.Controls.Add(this.txtRemark);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.txtDepart);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.txtEmpName);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.btnSelectEmp);
      this.Controls.Add(this.txtEmpNo);
      this.Controls.Add(this.label2);
      this.Name = "frmKQEmpSignCardAdd";
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.Controls.SetChildIndex(this.label2, 0);
      this.Controls.SetChildIndex(this.txtEmpNo, 0);
      this.Controls.SetChildIndex(this.btnSelectEmp, 0);
      this.Controls.SetChildIndex(this.label3, 0);
      this.Controls.SetChildIndex(this.txtEmpName, 0);
      this.Controls.SetChildIndex(this.label4, 0);
      this.Controls.SetChildIndex(this.txtDepart, 0);
      this.Controls.SetChildIndex(this.label8, 0);
      this.Controls.SetChildIndex(this.txtRemark, 0);
      this.Controls.SetChildIndex(this.dataGrid, 0);
      this.Controls.SetChildIndex(this.groupBox1, 0);
      this.Controls.SetChildIndex(this.button1, 0);
      this.Controls.SetChildIndex(this.button2, 0);
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cardGrid)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtRemark;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox txtDepart;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtEmpName;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button btnSelectEmp;
    private System.Windows.Forms.TextBox txtEmpNo;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.DataGridView dataGrid;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.DataGridView cardGrid;
    private System.Windows.Forms.TextBox txtQuickSearch;
    private System.Windows.Forms.Label lblQuickSearch;
    private System.Windows.Forms.Button btnQuickSearch;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    private System.Windows.Forms.Button btnClear;
  }
}
