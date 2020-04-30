namespace ECard78
{
  partial class frmKQEmpWorkTypeAdd
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
      this.txtDepart = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.txtEmpName = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.btnSelectEmp = new System.Windows.Forms.Button();
      this.txtEmpNo = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.cbbShiftNo = new System.Windows.Forms.ComboBox();
      this.chkOtIsHaveBar = new System.Windows.Forms.CheckBox();
      this.chkIsPressed = new System.Windows.Forms.CheckBox();
      this.label5 = new System.Windows.Forms.Label();
      this.cbbRest = new System.Windows.Forms.ComboBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.cbbHoli = new System.Windows.Forms.ComboBox();
      this.label7 = new System.Windows.Forms.Label();
      this.cbbWeek = new System.Windows.Forms.ComboBox();
      this.label6 = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.txtDays = new System.Windows.Forms.TextBox();
      this.label9 = new System.Windows.Forms.Label();
      this.cbbUnit = new System.Windows.Forms.ComboBox();
      this.label8 = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.cardGrid = new System.Windows.Forms.DataGridView();
      this.txtQuickSearch = new System.Windows.Forms.TextBox();
      this.lblQuickSearch = new System.Windows.Forms.Label();
      this.btnQuickSearch = new System.Windows.Forms.Button();
      this.btnClear = new System.Windows.Forms.Button();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cardGrid)).BeginInit();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(550, 285);
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(470, 285);
      this.btnOk.Text = "";
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
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
      this.label4.TabIndex = 33;
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
      this.label3.TabIndex = 32;
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
      this.label2.TabIndex = 31;
      this.label2.Tag = "EmpNo";
      this.label2.Text = "label2";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(10, 104);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 12);
      this.label1.TabIndex = 34;
      this.label1.Tag = "DefaultEmpShiftNo";
      this.label1.Text = "label1";
      // 
      // cbbShiftNo
      // 
      this.cbbShiftNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbShiftNo.FormattingEnabled = true;
      this.cbbShiftNo.Location = new System.Drawing.Point(100, 100);
      this.cbbShiftNo.Name = "cbbShiftNo";
      this.cbbShiftNo.Size = new System.Drawing.Size(160, 20);
      this.cbbShiftNo.TabIndex = 4;
      // 
      // chkOtIsHaveBar
      // 
      this.chkOtIsHaveBar.Location = new System.Drawing.Point(10, 130);
      this.chkOtIsHaveBar.Name = "chkOtIsHaveBar";
      this.chkOtIsHaveBar.Size = new System.Drawing.Size(250, 20);
      this.chkOtIsHaveBar.TabIndex = 5;
      this.chkOtIsHaveBar.Tag = "EmpOtIsHaveBar";
      this.chkOtIsHaveBar.Text = "checkBox1";
      this.chkOtIsHaveBar.UseVisualStyleBackColor = true;
      // 
      // chkIsPressed
      // 
      this.chkIsPressed.Checked = true;
      this.chkIsPressed.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkIsPressed.Location = new System.Drawing.Point(10, 160);
      this.chkIsPressed.Name = "chkIsPressed";
      this.chkIsPressed.Size = new System.Drawing.Size(250, 20);
      this.chkIsPressed.TabIndex = 6;
      this.chkIsPressed.Tag = "EmpIsPressed";
      this.chkIsPressed.Text = "checkBox2";
      this.chkIsPressed.UseVisualStyleBackColor = true;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(10, 194);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(41, 12);
      this.label5.TabIndex = 38;
      this.label5.Tag = "EmpRest";
      this.label5.Text = "label5";
      // 
      // cbbRest
      // 
      this.cbbRest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbRest.FormattingEnabled = true;
      this.cbbRest.Location = new System.Drawing.Point(100, 190);
      this.cbbRest.Name = "cbbRest";
      this.cbbRest.Size = new System.Drawing.Size(160, 20);
      this.cbbRest.TabIndex = 7;
      this.cbbRest.SelectedIndexChanged += new System.EventHandler(this.cbbRest_SelectedIndexChanged);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.cbbHoli);
      this.panel1.Controls.Add(this.label7);
      this.panel1.Controls.Add(this.cbbWeek);
      this.panel1.Controls.Add(this.label6);
      this.panel1.Location = new System.Drawing.Point(10, 220);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(250, 55);
      this.panel1.TabIndex = 8;
      // 
      // cbbHoli
      // 
      this.cbbHoli.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbHoli.FormattingEnabled = true;
      this.cbbHoli.Location = new System.Drawing.Point(90, 30);
      this.cbbHoli.Name = "cbbHoli";
      this.cbbHoli.Size = new System.Drawing.Size(160, 20);
      this.cbbHoli.TabIndex = 3;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(0, 34);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(41, 12);
      this.label7.TabIndex = 2;
      this.label7.Tag = "HolidayEndName";
      this.label7.Text = "label7";
      // 
      // cbbWeek
      // 
      this.cbbWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbWeek.FormattingEnabled = true;
      this.cbbWeek.Location = new System.Drawing.Point(90, 0);
      this.cbbWeek.Name = "cbbWeek";
      this.cbbWeek.Size = new System.Drawing.Size(160, 20);
      this.cbbWeek.TabIndex = 1;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(0, 4);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(41, 12);
      this.label6.TabIndex = 0;
      this.label6.Tag = "WeekEndName";
      this.label6.Text = "label6";
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.txtDays);
      this.panel2.Controls.Add(this.label9);
      this.panel2.Controls.Add(this.cbbUnit);
      this.panel2.Controls.Add(this.label8);
      this.panel2.Location = new System.Drawing.Point(10, 220);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(250, 55);
      this.panel2.TabIndex = 9;
      // 
      // txtDays
      // 
      this.txtDays.Location = new System.Drawing.Point(90, 30);
      this.txtDays.Name = "txtDays";
      this.txtDays.Size = new System.Drawing.Size(160, 21);
      this.txtDays.TabIndex = 3;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(0, 34);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(41, 12);
      this.label9.TabIndex = 2;
      this.label9.Tag = "EmpRestDays";
      this.label9.Text = "label9";
      // 
      // cbbUnit
      // 
      this.cbbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbUnit.FormattingEnabled = true;
      this.cbbUnit.Items.AddRange(new object[] {
            "M",
            "W"});
      this.cbbUnit.Location = new System.Drawing.Point(90, 0);
      this.cbbUnit.Name = "cbbUnit";
      this.cbbUnit.Size = new System.Drawing.Size(160, 20);
      this.cbbUnit.TabIndex = 1;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(0, 4);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(41, 12);
      this.label8.TabIndex = 0;
      this.label8.Tag = "EmpTimeWorkUnit";
      this.label8.Text = "label8";
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
      this.groupBox1.Size = new System.Drawing.Size(355, 261);
      this.groupBox1.TabIndex = 10;
      this.groupBox1.TabStop = false;
      this.groupBox1.Tag = "SameEmp";
      this.groupBox1.Text = "groupBox1";
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
      this.cardGrid.Size = new System.Drawing.Size(335, 200);
      this.cardGrid.StandardTab = true;
      this.cardGrid.TabIndex = 8;
      // 
      // txtQuickSearch
      // 
      this.txtQuickSearch.Location = new System.Drawing.Point(250, 22);
      this.txtQuickSearch.Name = "txtQuickSearch";
      this.txtQuickSearch.Size = new System.Drawing.Size(95, 21);
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
      // frmKQEmpWorkTypeAdd
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(634, 318);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.cbbRest);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.chkIsPressed);
      this.Controls.Add(this.chkOtIsHaveBar);
      this.Controls.Add(this.cbbShiftNo);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtDepart);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.txtEmpName);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.btnSelectEmp);
      this.Controls.Add(this.txtEmpNo);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.Name = "frmKQEmpWorkTypeAdd";
      this.Controls.SetChildIndex(this.panel1, 0);
      this.Controls.SetChildIndex(this.panel2, 0);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.Controls.SetChildIndex(this.label2, 0);
      this.Controls.SetChildIndex(this.txtEmpNo, 0);
      this.Controls.SetChildIndex(this.btnSelectEmp, 0);
      this.Controls.SetChildIndex(this.label3, 0);
      this.Controls.SetChildIndex(this.txtEmpName, 0);
      this.Controls.SetChildIndex(this.label4, 0);
      this.Controls.SetChildIndex(this.txtDepart, 0);
      this.Controls.SetChildIndex(this.label1, 0);
      this.Controls.SetChildIndex(this.cbbShiftNo, 0);
      this.Controls.SetChildIndex(this.chkOtIsHaveBar, 0);
      this.Controls.SetChildIndex(this.chkIsPressed, 0);
      this.Controls.SetChildIndex(this.label5, 0);
      this.Controls.SetChildIndex(this.cbbRest, 0);
      this.Controls.SetChildIndex(this.groupBox1, 0);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cardGrid)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtDepart;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtEmpName;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button btnSelectEmp;
    private System.Windows.Forms.TextBox txtEmpNo;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cbbShiftNo;
    private System.Windows.Forms.CheckBox chkOtIsHaveBar;
    private System.Windows.Forms.CheckBox chkIsPressed;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ComboBox cbbRest;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.ComboBox cbbHoli;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.ComboBox cbbWeek;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.TextBox txtDays;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.ComboBox cbbUnit;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.DataGridView cardGrid;
    private System.Windows.Forms.TextBox txtQuickSearch;
    private System.Windows.Forms.Label lblQuickSearch;
    private System.Windows.Forms.Button btnQuickSearch;
    private System.Windows.Forms.Button btnClear;
  }
}
