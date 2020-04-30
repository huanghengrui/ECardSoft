namespace ECard78
{
  partial class frmPubSelectEmpList
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPubSelectEmpList));
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.tvEmp = new System.Windows.Forms.TreeView();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.tvDepart = new System.Windows.Forms.TreeView();
      this.optSelectAll = new System.Windows.Forms.RadioButton();
      this.optSelect = new System.Windows.Forms.RadioButton();
      this.tabPage3 = new System.Windows.Forms.TabPage();
      this.btnAddEmp = new System.Windows.Forms.Button();
      this.dtpDate = new System.Windows.Forms.DateTimePicker();
      this.label1 = new System.Windows.Forms.Label();
      this.clbCardType = new System.Windows.Forms.CheckedListBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.btnClear = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.cardGrid = new System.Windows.Forms.DataGridView();
      this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.tabControl1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage3.SuspendLayout();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cardGrid)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(710, 435);
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(630, 435);
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
      // tabControl1
      // 
      this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)));
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage3);
      this.tabControl1.Location = new System.Drawing.Point(10, 10);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(300, 415);
      this.tabControl1.TabIndex = 0;
      // 
      // tabPage2
      // 
      this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
      this.tabPage2.Controls.Add(this.tvEmp);
      this.tabPage2.Location = new System.Drawing.Point(4, 21);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(292, 390);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "tabPage2";
      // 
      // tvEmp
      // 
      this.tvEmp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.tvEmp.FullRowSelect = true;
      this.tvEmp.HideSelection = false;
      this.tvEmp.ItemHeight = 20;
      this.tvEmp.Location = new System.Drawing.Point(10, 10);
      this.tvEmp.Name = "tvEmp";
      this.tvEmp.Size = new System.Drawing.Size(272, 370);
      this.tvEmp.StateImageList = this.ilTreeState;
      this.tvEmp.TabIndex = 24;
      // 
      // tabPage1
      // 
      this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
      this.tabPage1.Controls.Add(this.tvDepart);
      this.tabPage1.Controls.Add(this.optSelectAll);
      this.tabPage1.Controls.Add(this.optSelect);
      this.tabPage1.Location = new System.Drawing.Point(4, 21);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(292, 390);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "tabPage1";
      // 
      // tvDepart
      // 
      this.tvDepart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.tvDepart.CheckBoxes = true;
      this.tvDepart.FullRowSelect = true;
      this.tvDepart.HideSelection = false;
      this.tvDepart.ItemHeight = 20;
      this.tvDepart.Location = new System.Drawing.Point(10, 60);
      this.tvDepart.Name = "tvDepart";
      this.tvDepart.Size = new System.Drawing.Size(272, 320);
      this.tvDepart.TabIndex = 23;
      this.tvDepart.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvDepart_AfterCheck);
      // 
      // optSelectAll
      // 
      this.optSelectAll.AutoSize = true;
      this.optSelectAll.Location = new System.Drawing.Point(10, 35);
      this.optSelectAll.Name = "optSelectAll";
      this.optSelectAll.Size = new System.Drawing.Size(95, 16);
      this.optSelectAll.TabIndex = 22;
      this.optSelectAll.TabStop = true;
      this.optSelectAll.Text = "radioButton2";
      this.optSelectAll.UseVisualStyleBackColor = true;
      // 
      // optSelect
      // 
      this.optSelect.AutoSize = true;
      this.optSelect.Checked = true;
      this.optSelect.Location = new System.Drawing.Point(10, 10);
      this.optSelect.Name = "optSelect";
      this.optSelect.Size = new System.Drawing.Size(95, 16);
      this.optSelect.TabIndex = 21;
      this.optSelect.TabStop = true;
      this.optSelect.Text = "radioButton1";
      this.optSelect.UseVisualStyleBackColor = true;
      // 
      // tabPage3
      // 
      this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
      this.tabPage3.Controls.Add(this.btnAddEmp);
      this.tabPage3.Controls.Add(this.dtpDate);
      this.tabPage3.Controls.Add(this.label1);
      this.tabPage3.Controls.Add(this.clbCardType);
      this.tabPage3.Location = new System.Drawing.Point(4, 21);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage3.Size = new System.Drawing.Size(292, 390);
      this.tabPage3.TabIndex = 2;
      this.tabPage3.Text = "tabPage3";
      // 
      // btnAddEmp
      // 
      this.btnAddEmp.Location = new System.Drawing.Point(200, 360);
      this.btnAddEmp.Name = "btnAddEmp";
      this.btnAddEmp.Size = new System.Drawing.Size(82, 23);
      this.btnAddEmp.TabIndex = 3;
      this.btnAddEmp.Text = "button1";
      this.btnAddEmp.UseVisualStyleBackColor = true;
      this.btnAddEmp.Click += new System.EventHandler(this.btnAddEmp_Click);
      // 
      // dtpDate
      // 
      this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.dtpDate.Location = new System.Drawing.Point(100, 360);
      this.dtpDate.Name = "dtpDate";
      this.dtpDate.Size = new System.Drawing.Size(90, 21);
      this.dtpDate.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(10, 364);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 12);
      this.label1.TabIndex = 1;
      this.label1.Tag = "EmpHireDate";
      this.label1.Text = "label1";
      // 
      // clbCardType
      // 
      this.clbCardType.FormattingEnabled = true;
      this.clbCardType.IntegralHeight = false;
      this.clbCardType.Location = new System.Drawing.Point(10, 10);
      this.clbCardType.Name = "clbCardType";
      this.clbCardType.Size = new System.Drawing.Size(272, 340);
      this.clbCardType.TabIndex = 0;
      this.clbCardType.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbCardType_ItemCheck);
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.btnClear);
      this.groupBox1.Controls.Add(this.button1);
      this.groupBox1.Controls.Add(this.cardGrid);
      this.groupBox1.Location = new System.Drawing.Point(317, 10);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(465, 415);
      this.groupBox1.TabIndex = 1;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "groupBox1";
      // 
      // btnClear
      // 
      this.btnClear.Location = new System.Drawing.Point(90, 380);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new System.Drawing.Size(75, 25);
      this.btnClear.TabIndex = 27;
      this.btnClear.Text = "button2";
      this.btnClear.UseVisualStyleBackColor = true;
      this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(10, 380);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 25);
      this.button1.TabIndex = 26;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // cardGrid
      // 
      this.cardGrid.AllowUserToAddRows = false;
      this.cardGrid.AllowUserToDeleteRows = false;
      this.cardGrid.AllowUserToResizeRows = false;
      this.cardGrid.AutoGenerateColumns = false;
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.cardGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
      this.cardGrid.ColumnHeadersHeight = 25;
      this.cardGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.cardGrid.DataSource = this.bindingSource;
      dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.cardGrid.DefaultCellStyle = dataGridViewCellStyle4;
      this.cardGrid.Location = new System.Drawing.Point(10, 20);
      this.cardGrid.MultiSelect = false;
      this.cardGrid.Name = "cardGrid";
      this.cardGrid.ReadOnly = true;
      this.cardGrid.RowHeadersVisible = false;
      this.cardGrid.RowTemplate.Height = 23;
      this.cardGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.cardGrid.Size = new System.Drawing.Size(445, 350);
      this.cardGrid.StandardTab = true;
      this.cardGrid.TabIndex = 25;
      // 
      // bindingSource
      // 
      this.bindingSource.AllowNew = false;
      // 
      // frmPubSelectEmpList
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(794, 468);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.tabControl1);
      this.Name = "frmPubSelectEmpList";
      this.Controls.SetChildIndex(this.tabControl1, 0);
      this.Controls.SetChildIndex(this.groupBox1, 0);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.tabControl1.ResumeLayout(false);
      this.tabPage2.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage1.PerformLayout();
      this.tabPage3.ResumeLayout(false);
      this.tabPage3.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.cardGrid)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.TabPage tabPage3;
    private System.Windows.Forms.RadioButton optSelect;
    private System.Windows.Forms.RadioButton optSelectAll;
    private System.Windows.Forms.TreeView tvDepart;
    private System.Windows.Forms.TreeView tvEmp;
    private System.Windows.Forms.Button btnAddEmp;
    private System.Windows.Forms.DateTimePicker dtpDate;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckedListBox clbCardType;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button btnClear;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.DataGridView cardGrid;
    protected System.Windows.Forms.BindingSource bindingSource;
  }
}
