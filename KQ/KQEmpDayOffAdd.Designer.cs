namespace ECard78
{
  partial class frmKQEmpDayOffAdd
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
      this.label1 = new System.Windows.Forms.Label();
      this.txtNo = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtEmpNo = new System.Windows.Forms.TextBox();
      this.btnSelectEmp = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.txtEmpName = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.txtDepart = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.dtpStart = new System.Windows.Forms.DateTimePicker();
      this.label6 = new System.Windows.Forms.Label();
      this.dtpEnd = new System.Windows.Forms.DateTimePicker();
      this.label7 = new System.Windows.Forms.Label();
      this.cbbType = new System.Windows.Forms.ComboBox();
      this.label8 = new System.Windows.Forms.Label();
      this.txtReason = new System.Windows.Forms.TextBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.btnClear = new System.Windows.Forms.Button();
      this.cardGrid = new System.Windows.Forms.DataGridView();
      this.txtQuickSearch = new System.Windows.Forms.TextBox();
      this.lblQuickSearch = new System.Windows.Forms.Label();
      this.btnQuickSearch = new System.Windows.Forms.Button();
      this.btnViewShift = new System.Windows.Forms.Button();
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
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
      this.label1.Location = new System.Drawing.Point(10, 14);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 12);
      this.label1.TabIndex = 19;
      this.label1.Tag = "DayoffBillNo";
      this.label1.Text = "label1";
      // 
      // txtNo
      // 
      this.txtNo.Location = new System.Drawing.Point(100, 10);
      this.txtNo.Name = "txtNo";
      this.txtNo.ReadOnly = true;
      this.txtNo.Size = new System.Drawing.Size(160, 21);
      this.txtNo.TabIndex = 0;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.ForeColor = System.Drawing.Color.Red;
      this.label2.Location = new System.Drawing.Point(10, 44);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(41, 12);
      this.label2.TabIndex = 21;
      this.label2.Tag = "EmpNo";
      this.label2.Text = "label2";
      // 
      // txtEmpNo
      // 
      this.txtEmpNo.Location = new System.Drawing.Point(100, 40);
      this.txtEmpNo.Name = "txtEmpNo";
      this.txtEmpNo.Size = new System.Drawing.Size(160, 21);
      this.txtEmpNo.TabIndex = 1;
      this.txtEmpNo.Leave += new System.EventHandler(this.txtEmpNo_Leave);
      // 
      // btnSelectEmp
      // 
      this.btnSelectEmp.Location = new System.Drawing.Point(225, 41);
      this.btnSelectEmp.Name = "btnSelectEmp";
      this.btnSelectEmp.Size = new System.Drawing.Size(34, 19);
      this.btnSelectEmp.TabIndex = 2;
      this.btnSelectEmp.Text = "button1";
      this.btnSelectEmp.UseVisualStyleBackColor = true;
      this.btnSelectEmp.Click += new System.EventHandler(this.btnSelectEmp_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
      this.label3.Location = new System.Drawing.Point(10, 74);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(41, 12);
      this.label3.TabIndex = 24;
      this.label3.Tag = "EmpName";
      this.label3.Text = "label3";
      // 
      // txtEmpName
      // 
      this.txtEmpName.Location = new System.Drawing.Point(100, 70);
      this.txtEmpName.Name = "txtEmpName";
      this.txtEmpName.ReadOnly = true;
      this.txtEmpName.Size = new System.Drawing.Size(160, 21);
      this.txtEmpName.TabIndex = 3;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
      this.label4.Location = new System.Drawing.Point(10, 104);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(41, 12);
      this.label4.TabIndex = 26;
      this.label4.Tag = "Depart";
      this.label4.Text = "label4";
      // 
      // txtDepart
      // 
      this.txtDepart.Location = new System.Drawing.Point(100, 100);
      this.txtDepart.Name = "txtDepart";
      this.txtDepart.ReadOnly = true;
      this.txtDepart.Size = new System.Drawing.Size(160, 21);
      this.txtDepart.TabIndex = 4;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.ForeColor = System.Drawing.Color.Red;
      this.label5.Location = new System.Drawing.Point(10, 134);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(41, 12);
      this.label5.TabIndex = 28;
      this.label5.Tag = "DayoffStartTime";
      this.label5.Text = "label5";
      // 
      // dtpStart
      // 
      this.dtpStart.CustomFormat = "yyyy-MM-dd HH:mm";
      this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtpStart.Location = new System.Drawing.Point(100, 130);
      this.dtpStart.Name = "dtpStart";
      this.dtpStart.ShowUpDown = true;
      this.dtpStart.Size = new System.Drawing.Size(160, 21);
      this.dtpStart.TabIndex = 5;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.ForeColor = System.Drawing.Color.Red;
      this.label6.Location = new System.Drawing.Point(10, 164);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(41, 12);
      this.label6.TabIndex = 30;
      this.label6.Tag = "DayoffEndTime";
      this.label6.Text = "label6";
      // 
      // dtpEnd
      // 
      this.dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm";
      this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtpEnd.Location = new System.Drawing.Point(100, 160);
      this.dtpEnd.Name = "dtpEnd";
      this.dtpEnd.ShowUpDown = true;
      this.dtpEnd.Size = new System.Drawing.Size(160, 21);
      this.dtpEnd.TabIndex = 6;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.ForeColor = System.Drawing.Color.Red;
      this.label7.Location = new System.Drawing.Point(10, 194);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(41, 12);
      this.label7.TabIndex = 32;
      this.label7.Tag = "DayOffType";
      this.label7.Text = "label7";
      // 
      // cbbType
      // 
      this.cbbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbType.FormattingEnabled = true;
      this.cbbType.Location = new System.Drawing.Point(100, 190);
      this.cbbType.Name = "cbbType";
      this.cbbType.Size = new System.Drawing.Size(160, 20);
      this.cbbType.TabIndex = 7;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(10, 224);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(41, 12);
      this.label8.TabIndex = 34;
      this.label8.Tag = "DayoffReason";
      this.label8.Text = "label8";
      // 
      // txtReason
      // 
      this.txtReason.Location = new System.Drawing.Point(100, 220);
      this.txtReason.MaxLength = 200;
      this.txtReason.Multiline = true;
      this.txtReason.Name = "txtReason";
      this.txtReason.Size = new System.Drawing.Size(160, 65);
      this.txtReason.TabIndex = 8;
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
      this.groupBox1.TabIndex = 9;
      this.groupBox1.TabStop = false;
      this.groupBox1.Tag = "SameEmp";
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
      this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
      // 
      // cardGrid
      // 
      this.cardGrid.AllowUserToAddRows = false;
      this.cardGrid.AllowUserToDeleteRows = false;
      this.cardGrid.AllowUserToResizeRows = false;
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
      // btnViewShift
      // 
      this.btnViewShift.Location = new System.Drawing.Point(10, 295);
      this.btnViewShift.Name = "btnViewShift";
      this.btnViewShift.Size = new System.Drawing.Size(100, 25);
      this.btnViewShift.TabIndex = 10;
      this.btnViewShift.Text = "button1";
      this.btnViewShift.UseVisualStyleBackColor = true;
      this.btnViewShift.Click += new System.EventHandler(this.btnViewShift_Click);
      // 
      // frmKQEmpDayOffAdd
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(629, 328);
      this.Controls.Add(this.btnViewShift);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.txtReason);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.cbbType);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.dtpEnd);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.dtpStart);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.txtDepart);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.txtEmpName);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.btnSelectEmp);
      this.Controls.Add(this.txtEmpNo);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtNo);
      this.Name = "frmKQEmpDayOffAdd";
      this.Controls.SetChildIndex(this.txtNo, 0);
      this.Controls.SetChildIndex(this.label1, 0);
      this.Controls.SetChildIndex(this.label2, 0);
      this.Controls.SetChildIndex(this.txtEmpNo, 0);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.Controls.SetChildIndex(this.btnSelectEmp, 0);
      this.Controls.SetChildIndex(this.label3, 0);
      this.Controls.SetChildIndex(this.txtEmpName, 0);
      this.Controls.SetChildIndex(this.label4, 0);
      this.Controls.SetChildIndex(this.txtDepart, 0);
      this.Controls.SetChildIndex(this.label5, 0);
      this.Controls.SetChildIndex(this.dtpStart, 0);
      this.Controls.SetChildIndex(this.label6, 0);
      this.Controls.SetChildIndex(this.dtpEnd, 0);
      this.Controls.SetChildIndex(this.label7, 0);
      this.Controls.SetChildIndex(this.cbbType, 0);
      this.Controls.SetChildIndex(this.label8, 0);
      this.Controls.SetChildIndex(this.txtReason, 0);
      this.Controls.SetChildIndex(this.groupBox1, 0);
      this.Controls.SetChildIndex(this.btnViewShift, 0);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cardGrid)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtNo;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtEmpNo;
    private System.Windows.Forms.Button btnSelectEmp;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtEmpName;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtDepart;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.DateTimePicker dtpStart;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.DateTimePicker dtpEnd;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.ComboBox cbbType;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox txtReason;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TextBox txtQuickSearch;
    private System.Windows.Forms.Label lblQuickSearch;
    private System.Windows.Forms.Button btnQuickSearch;
    private System.Windows.Forms.DataGridView cardGrid;
    private System.Windows.Forms.Button btnViewShift;
    private System.Windows.Forms.Button btnClear;
  }
}
