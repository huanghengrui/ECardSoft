namespace ECard78
{
  partial class frmKQEmpOtSureAdd
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
      this.dtpEnd = new System.Windows.Forms.DateTimePicker();
      this.label8 = new System.Windows.Forms.Label();
      this.txtReason = new System.Windows.Forms.TextBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.cardGrid = new System.Windows.Forms.DataGridView();
      this.txtQuickSearch = new System.Windows.Forms.TextBox();
      this.lblQuickSearch = new System.Windows.Forms.Label();
      this.btnQuickSearch = new System.Windows.Forms.Button();
      this.btnViewShift = new System.Windows.Forms.Button();
      this.label6 = new System.Windows.Forms.Label();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.chkIsDirect = new System.Windows.Forms.CheckBox();
      this.cbbOtType3 = new System.Windows.Forms.ComboBox();
      this.cbbOutNextDay3 = new System.Windows.Forms.ComboBox();
      this.txtAfter3 = new System.Windows.Forms.TextBox();
      this.txtEndTime3 = new System.Windows.Forms.MaskedTextBox();
      this.cbbInNextDay3 = new System.Windows.Forms.ComboBox();
      this.txtStartTime3 = new System.Windows.Forms.MaskedTextBox();
      this.txtBefore3 = new System.Windows.Forms.TextBox();
      this.label17 = new System.Windows.Forms.Label();
      this.cbbOtType2 = new System.Windows.Forms.ComboBox();
      this.cbbOutNextDay2 = new System.Windows.Forms.ComboBox();
      this.txtAfter2 = new System.Windows.Forms.TextBox();
      this.txtEndTime2 = new System.Windows.Forms.MaskedTextBox();
      this.cbbInNextDay2 = new System.Windows.Forms.ComboBox();
      this.txtStartTime2 = new System.Windows.Forms.MaskedTextBox();
      this.txtBefore2 = new System.Windows.Forms.TextBox();
      this.label16 = new System.Windows.Forms.Label();
      this.cbbOtType1 = new System.Windows.Forms.ComboBox();
      this.cbbOutNextDay1 = new System.Windows.Forms.ComboBox();
      this.txtAfter1 = new System.Windows.Forms.TextBox();
      this.txtEndTime1 = new System.Windows.Forms.MaskedTextBox();
      this.cbbInNextDay1 = new System.Windows.Forms.ComboBox();
      this.txtStartTime1 = new System.Windows.Forms.MaskedTextBox();
      this.txtBefore1 = new System.Windows.Forms.TextBox();
      this.label15 = new System.Windows.Forms.Label();
      this.label14 = new System.Windows.Forms.Label();
      this.label13 = new System.Windows.Forms.Label();
      this.label12 = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.btnClear = new System.Windows.Forms.Button();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cardGrid)).BeginInit();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(765, 360);
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(685, 360);
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
      this.label1.Tag = "OtBillNo";
      this.label1.Text = "label1";
      // 
      // txtNo
      // 
      this.txtNo.Location = new System.Drawing.Point(100, 10);
      this.txtNo.Name = "txtNo";
      this.txtNo.ReadOnly = true;
      this.txtNo.Size = new System.Drawing.Size(380, 21);
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
      this.txtEmpNo.Size = new System.Drawing.Size(380, 21);
      this.txtEmpNo.TabIndex = 1;
      this.txtEmpNo.Leave += new System.EventHandler(this.txtEmpNo_Leave);
      // 
      // btnSelectEmp
      // 
      this.btnSelectEmp.Location = new System.Drawing.Point(445, 41);
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
      this.txtEmpName.Size = new System.Drawing.Size(380, 21);
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
      this.txtDepart.Size = new System.Drawing.Size(380, 21);
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
      this.label5.Tag = "OTDate";
      this.label5.Text = "label5";
      // 
      // dtpStart
      // 
      this.dtpStart.CustomFormat = "";
      this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.dtpStart.Location = new System.Drawing.Point(100, 130);
      this.dtpStart.Name = "dtpStart";
      this.dtpStart.Size = new System.Drawing.Size(170, 21);
      this.dtpStart.TabIndex = 5;
      // 
      // dtpEnd
      // 
      this.dtpEnd.CustomFormat = "";
      this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.dtpEnd.Location = new System.Drawing.Point(310, 130);
      this.dtpEnd.Name = "dtpEnd";
      this.dtpEnd.Size = new System.Drawing.Size(170, 21);
      this.dtpEnd.TabIndex = 6;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(10, 164);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(41, 12);
      this.label8.TabIndex = 34;
      this.label8.Tag = "OtReason";
      this.label8.Text = "label8";
      // 
      // txtReason
      // 
      this.txtReason.Location = new System.Drawing.Point(100, 160);
      this.txtReason.MaxLength = 200;
      this.txtReason.Name = "txtReason";
      this.txtReason.Size = new System.Drawing.Size(380, 21);
      this.txtReason.TabIndex = 7;
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.btnClear);
      this.groupBox1.Controls.Add(this.cardGrid);
      this.groupBox1.Controls.Add(this.txtQuickSearch);
      this.groupBox1.Controls.Add(this.lblQuickSearch);
      this.groupBox1.Controls.Add(this.btnQuickSearch);
      this.groupBox1.Location = new System.Drawing.Point(490, 10);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(350, 340);
      this.groupBox1.TabIndex = 9;
      this.groupBox1.TabStop = false;
      this.groupBox1.Tag = "SameEmp";
      this.groupBox1.Text = "groupBox1";
      // 
      // cardGrid
      // 
      this.cardGrid.AllowUserToAddRows = false;
      this.cardGrid.AllowUserToDeleteRows = false;
      this.cardGrid.AllowUserToResizeRows = false;
      dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.cardGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
      this.cardGrid.ColumnHeadersHeight = 25;
      this.cardGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.cardGrid.DefaultCellStyle = dataGridViewCellStyle6;
      this.cardGrid.Location = new System.Drawing.Point(10, 50);
      this.cardGrid.MultiSelect = false;
      this.cardGrid.Name = "cardGrid";
      this.cardGrid.ReadOnly = true;
      this.cardGrid.RowHeadersVisible = false;
      this.cardGrid.RowTemplate.Height = 23;
      this.cardGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.cardGrid.Size = new System.Drawing.Size(330, 280);
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
      this.btnViewShift.Location = new System.Drawing.Point(10, 360);
      this.btnViewShift.Name = "btnViewShift";
      this.btnViewShift.Size = new System.Drawing.Size(100, 25);
      this.btnViewShift.TabIndex = 10;
      this.btnViewShift.Text = "button1";
      this.btnViewShift.UseVisualStyleBackColor = true;
      this.btnViewShift.Click += new System.EventHandler(this.btnViewShift_Click);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
      this.label6.Location = new System.Drawing.Point(285, 134);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(11, 12);
      this.label6.TabIndex = 30;
      this.label6.Tag = "";
      this.label6.Text = "-";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.chkIsDirect);
      this.groupBox2.Controls.Add(this.cbbOtType3);
      this.groupBox2.Controls.Add(this.cbbOutNextDay3);
      this.groupBox2.Controls.Add(this.txtAfter3);
      this.groupBox2.Controls.Add(this.txtEndTime3);
      this.groupBox2.Controls.Add(this.cbbInNextDay3);
      this.groupBox2.Controls.Add(this.txtStartTime3);
      this.groupBox2.Controls.Add(this.txtBefore3);
      this.groupBox2.Controls.Add(this.label17);
      this.groupBox2.Controls.Add(this.cbbOtType2);
      this.groupBox2.Controls.Add(this.cbbOutNextDay2);
      this.groupBox2.Controls.Add(this.txtAfter2);
      this.groupBox2.Controls.Add(this.txtEndTime2);
      this.groupBox2.Controls.Add(this.cbbInNextDay2);
      this.groupBox2.Controls.Add(this.txtStartTime2);
      this.groupBox2.Controls.Add(this.txtBefore2);
      this.groupBox2.Controls.Add(this.label16);
      this.groupBox2.Controls.Add(this.cbbOtType1);
      this.groupBox2.Controls.Add(this.cbbOutNextDay1);
      this.groupBox2.Controls.Add(this.txtAfter1);
      this.groupBox2.Controls.Add(this.txtEndTime1);
      this.groupBox2.Controls.Add(this.cbbInNextDay1);
      this.groupBox2.Controls.Add(this.txtStartTime1);
      this.groupBox2.Controls.Add(this.txtBefore1);
      this.groupBox2.Controls.Add(this.label15);
      this.groupBox2.Controls.Add(this.label14);
      this.groupBox2.Controls.Add(this.label13);
      this.groupBox2.Controls.Add(this.label12);
      this.groupBox2.Controls.Add(this.label11);
      this.groupBox2.Controls.Add(this.label10);
      this.groupBox2.Controls.Add(this.label9);
      this.groupBox2.Controls.Add(this.label7);
      this.groupBox2.Location = new System.Drawing.Point(10, 190);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(470, 160);
      this.groupBox2.TabIndex = 8;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "groupBox2";
      // 
      // chkIsDirect
      // 
      this.chkIsDirect.AutoSize = true;
      this.chkIsDirect.Location = new System.Drawing.Point(10, 135);
      this.chkIsDirect.Name = "chkIsDirect";
      this.chkIsDirect.Size = new System.Drawing.Size(78, 16);
      this.chkIsDirect.TabIndex = 31;
      this.chkIsDirect.Tag = "OtIsDirectResult";
      this.chkIsDirect.Text = "checkBox1";
      this.chkIsDirect.UseVisualStyleBackColor = true;
      // 
      // cbbOtType3
      // 
      this.cbbOtType3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbOtType3.FormattingEnabled = true;
      this.cbbOtType3.Location = new System.Drawing.Point(360, 100);
      this.cbbOtType3.Name = "cbbOtType3";
      this.cbbOtType3.Size = new System.Drawing.Size(100, 20);
      this.cbbOtType3.TabIndex = 30;
      // 
      // cbbOutNextDay3
      // 
      this.cbbOutNextDay3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbOutNextDay3.FormattingEnabled = true;
      this.cbbOutNextDay3.Items.AddRange(new object[] {
            "0",
            "+1"});
      this.cbbOutNextDay3.Location = new System.Drawing.Point(305, 100);
      this.cbbOutNextDay3.Name = "cbbOutNextDay3";
      this.cbbOutNextDay3.Size = new System.Drawing.Size(50, 20);
      this.cbbOutNextDay3.TabIndex = 29;
      // 
      // txtAfter3
      // 
      this.txtAfter3.Location = new System.Drawing.Point(250, 100);
      this.txtAfter3.Name = "txtAfter3";
      this.txtAfter3.Size = new System.Drawing.Size(50, 21);
      this.txtAfter3.TabIndex = 28;
      this.txtAfter3.Text = "0";
      // 
      // txtEndTime3
      // 
      this.txtEndTime3.Location = new System.Drawing.Point(195, 100);
      this.txtEndTime3.Mask = "99:99";
      this.txtEndTime3.Name = "txtEndTime3";
      this.txtEndTime3.PromptChar = ' ';
      this.txtEndTime3.Size = new System.Drawing.Size(50, 21);
      this.txtEndTime3.TabIndex = 27;
      this.txtEndTime3.Text = "0000";
      // 
      // cbbInNextDay3
      // 
      this.cbbInNextDay3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbInNextDay3.FormattingEnabled = true;
      this.cbbInNextDay3.Items.AddRange(new object[] {
            "0",
            "+1"});
      this.cbbInNextDay3.Location = new System.Drawing.Point(140, 100);
      this.cbbInNextDay3.Name = "cbbInNextDay3";
      this.cbbInNextDay3.Size = new System.Drawing.Size(50, 20);
      this.cbbInNextDay3.TabIndex = 26;
      // 
      // txtStartTime3
      // 
      this.txtStartTime3.Location = new System.Drawing.Point(85, 100);
      this.txtStartTime3.Mask = "99:99";
      this.txtStartTime3.Name = "txtStartTime3";
      this.txtStartTime3.PromptChar = ' ';
      this.txtStartTime3.Size = new System.Drawing.Size(50, 21);
      this.txtStartTime3.TabIndex = 25;
      this.txtStartTime3.Text = "0000";
      // 
      // txtBefore3
      // 
      this.txtBefore3.Location = new System.Drawing.Point(30, 100);
      this.txtBefore3.Name = "txtBefore3";
      this.txtBefore3.Size = new System.Drawing.Size(50, 21);
      this.txtBefore3.TabIndex = 24;
      this.txtBefore3.Text = "0";
      // 
      // label17
      // 
      this.label17.AutoSize = true;
      this.label17.Location = new System.Drawing.Point(10, 104);
      this.label17.Name = "label17";
      this.label17.Size = new System.Drawing.Size(11, 12);
      this.label17.TabIndex = 23;
      this.label17.Text = "3";
      // 
      // cbbOtType2
      // 
      this.cbbOtType2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbOtType2.FormattingEnabled = true;
      this.cbbOtType2.Location = new System.Drawing.Point(360, 70);
      this.cbbOtType2.Name = "cbbOtType2";
      this.cbbOtType2.Size = new System.Drawing.Size(100, 20);
      this.cbbOtType2.TabIndex = 22;
      // 
      // cbbOutNextDay2
      // 
      this.cbbOutNextDay2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbOutNextDay2.FormattingEnabled = true;
      this.cbbOutNextDay2.Items.AddRange(new object[] {
            "0",
            "+1"});
      this.cbbOutNextDay2.Location = new System.Drawing.Point(305, 70);
      this.cbbOutNextDay2.Name = "cbbOutNextDay2";
      this.cbbOutNextDay2.Size = new System.Drawing.Size(50, 20);
      this.cbbOutNextDay2.TabIndex = 21;
      // 
      // txtAfter2
      // 
      this.txtAfter2.Location = new System.Drawing.Point(250, 70);
      this.txtAfter2.Name = "txtAfter2";
      this.txtAfter2.Size = new System.Drawing.Size(50, 21);
      this.txtAfter2.TabIndex = 20;
      this.txtAfter2.Text = "0";
      // 
      // txtEndTime2
      // 
      this.txtEndTime2.Location = new System.Drawing.Point(195, 70);
      this.txtEndTime2.Mask = "99:99";
      this.txtEndTime2.Name = "txtEndTime2";
      this.txtEndTime2.PromptChar = ' ';
      this.txtEndTime2.Size = new System.Drawing.Size(50, 21);
      this.txtEndTime2.TabIndex = 19;
      this.txtEndTime2.Text = "0000";
      // 
      // cbbInNextDay2
      // 
      this.cbbInNextDay2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbInNextDay2.FormattingEnabled = true;
      this.cbbInNextDay2.Items.AddRange(new object[] {
            "0",
            "+1"});
      this.cbbInNextDay2.Location = new System.Drawing.Point(140, 70);
      this.cbbInNextDay2.Name = "cbbInNextDay2";
      this.cbbInNextDay2.Size = new System.Drawing.Size(50, 20);
      this.cbbInNextDay2.TabIndex = 18;
      // 
      // txtStartTime2
      // 
      this.txtStartTime2.Location = new System.Drawing.Point(85, 70);
      this.txtStartTime2.Mask = "99:99";
      this.txtStartTime2.Name = "txtStartTime2";
      this.txtStartTime2.PromptChar = ' ';
      this.txtStartTime2.Size = new System.Drawing.Size(50, 21);
      this.txtStartTime2.TabIndex = 17;
      this.txtStartTime2.Text = "0000";
      // 
      // txtBefore2
      // 
      this.txtBefore2.Location = new System.Drawing.Point(30, 70);
      this.txtBefore2.Name = "txtBefore2";
      this.txtBefore2.Size = new System.Drawing.Size(50, 21);
      this.txtBefore2.TabIndex = 16;
      this.txtBefore2.Text = "0";
      // 
      // label16
      // 
      this.label16.AutoSize = true;
      this.label16.Location = new System.Drawing.Point(10, 74);
      this.label16.Name = "label16";
      this.label16.Size = new System.Drawing.Size(11, 12);
      this.label16.TabIndex = 15;
      this.label16.Text = "2";
      // 
      // cbbOtType1
      // 
      this.cbbOtType1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbOtType1.FormattingEnabled = true;
      this.cbbOtType1.Location = new System.Drawing.Point(360, 40);
      this.cbbOtType1.Name = "cbbOtType1";
      this.cbbOtType1.Size = new System.Drawing.Size(100, 20);
      this.cbbOtType1.TabIndex = 14;
      // 
      // cbbOutNextDay1
      // 
      this.cbbOutNextDay1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbOutNextDay1.FormattingEnabled = true;
      this.cbbOutNextDay1.Items.AddRange(new object[] {
            "0",
            "+1"});
      this.cbbOutNextDay1.Location = new System.Drawing.Point(305, 40);
      this.cbbOutNextDay1.Name = "cbbOutNextDay1";
      this.cbbOutNextDay1.Size = new System.Drawing.Size(50, 20);
      this.cbbOutNextDay1.TabIndex = 13;
      // 
      // txtAfter1
      // 
      this.txtAfter1.Location = new System.Drawing.Point(250, 40);
      this.txtAfter1.Name = "txtAfter1";
      this.txtAfter1.Size = new System.Drawing.Size(50, 21);
      this.txtAfter1.TabIndex = 12;
      this.txtAfter1.Text = "0";
      // 
      // txtEndTime1
      // 
      this.txtEndTime1.Location = new System.Drawing.Point(195, 40);
      this.txtEndTime1.Mask = "99:99";
      this.txtEndTime1.Name = "txtEndTime1";
      this.txtEndTime1.PromptChar = ' ';
      this.txtEndTime1.Size = new System.Drawing.Size(50, 21);
      this.txtEndTime1.TabIndex = 11;
      this.txtEndTime1.Text = "0000";
      // 
      // cbbInNextDay1
      // 
      this.cbbInNextDay1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbInNextDay1.FormattingEnabled = true;
      this.cbbInNextDay1.Items.AddRange(new object[] {
            "0",
            "+1"});
      this.cbbInNextDay1.Location = new System.Drawing.Point(140, 40);
      this.cbbInNextDay1.Name = "cbbInNextDay1";
      this.cbbInNextDay1.Size = new System.Drawing.Size(50, 20);
      this.cbbInNextDay1.TabIndex = 10;
      // 
      // txtStartTime1
      // 
      this.txtStartTime1.Location = new System.Drawing.Point(85, 40);
      this.txtStartTime1.Mask = "99:99";
      this.txtStartTime1.Name = "txtStartTime1";
      this.txtStartTime1.PromptChar = ' ';
      this.txtStartTime1.Size = new System.Drawing.Size(50, 21);
      this.txtStartTime1.TabIndex = 9;
      this.txtStartTime1.Text = "0000";
      // 
      // txtBefore1
      // 
      this.txtBefore1.Location = new System.Drawing.Point(30, 40);
      this.txtBefore1.Name = "txtBefore1";
      this.txtBefore1.Size = new System.Drawing.Size(50, 21);
      this.txtBefore1.TabIndex = 8;
      this.txtBefore1.Text = "0";
      // 
      // label15
      // 
      this.label15.AutoSize = true;
      this.label15.Location = new System.Drawing.Point(10, 44);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(11, 12);
      this.label15.TabIndex = 7;
      this.label15.Text = "1";
      // 
      // label14
      // 
      this.label14.Location = new System.Drawing.Point(305, 20);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(50, 15);
      this.label14.TabIndex = 6;
      this.label14.Tag = "ShiftNextDay";
      this.label14.Text = "label14";
      // 
      // label13
      // 
      this.label13.Location = new System.Drawing.Point(360, 20);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(100, 15);
      this.label13.TabIndex = 5;
      this.label13.Tag = "OtType";
      this.label13.Text = "label13";
      // 
      // label12
      // 
      this.label12.Location = new System.Drawing.Point(250, 20);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(50, 15);
      this.label12.TabIndex = 4;
      this.label12.Tag = "OutAfter";
      this.label12.Text = "label12";
      // 
      // label11
      // 
      this.label11.Location = new System.Drawing.Point(195, 20);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(50, 15);
      this.label11.TabIndex = 3;
      this.label11.Tag = "lblEnd";
      this.label11.Text = "label11";
      // 
      // label10
      // 
      this.label10.Location = new System.Drawing.Point(140, 20);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(50, 15);
      this.label10.TabIndex = 2;
      this.label10.Tag = "ShiftNextDay";
      this.label10.Text = "label10";
      // 
      // label9
      // 
      this.label9.Location = new System.Drawing.Point(85, 20);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(50, 15);
      this.label9.TabIndex = 1;
      this.label9.Tag = "lblBegin";
      this.label9.Text = "label9";
      // 
      // label7
      // 
      this.label7.Location = new System.Drawing.Point(30, 20);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(50, 15);
      this.label7.TabIndex = 0;
      this.label7.Tag = "InBefore";
      this.label7.Text = "label7";
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
      // frmKQEmpOtSureAdd
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(849, 393);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.txtReason);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.txtDepart);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.dtpStart);
      this.Controls.Add(this.btnViewShift);
      this.Controls.Add(this.dtpEnd);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.txtEmpName);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.btnSelectEmp);
      this.Controls.Add(this.txtEmpNo);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtNo);
      this.Name = "frmKQEmpOtSureAdd";
      this.Controls.SetChildIndex(this.txtNo, 0);
      this.Controls.SetChildIndex(this.label1, 0);
      this.Controls.SetChildIndex(this.label2, 0);
      this.Controls.SetChildIndex(this.txtEmpNo, 0);
      this.Controls.SetChildIndex(this.btnSelectEmp, 0);
      this.Controls.SetChildIndex(this.label3, 0);
      this.Controls.SetChildIndex(this.txtEmpName, 0);
      this.Controls.SetChildIndex(this.label6, 0);
      this.Controls.SetChildIndex(this.dtpEnd, 0);
      this.Controls.SetChildIndex(this.btnViewShift, 0);
      this.Controls.SetChildIndex(this.dtpStart, 0);
      this.Controls.SetChildIndex(this.label4, 0);
      this.Controls.SetChildIndex(this.txtDepart, 0);
      this.Controls.SetChildIndex(this.label5, 0);
      this.Controls.SetChildIndex(this.label8, 0);
      this.Controls.SetChildIndex(this.groupBox2, 0);
      this.Controls.SetChildIndex(this.txtReason, 0);
      this.Controls.SetChildIndex(this.groupBox1, 0);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cardGrid)).EndInit();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
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
    private System.Windows.Forms.DateTimePicker dtpEnd;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox txtReason;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TextBox txtQuickSearch;
    private System.Windows.Forms.Label lblQuickSearch;
    private System.Windows.Forms.Button btnQuickSearch;
    private System.Windows.Forms.DataGridView cardGrid;
    private System.Windows.Forms.Button btnViewShift;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox txtBefore1;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.MaskedTextBox txtStartTime1;
    private System.Windows.Forms.ComboBox cbbInNextDay1;
    private System.Windows.Forms.MaskedTextBox txtEndTime1;
    private System.Windows.Forms.TextBox txtAfter1;
    private System.Windows.Forms.ComboBox cbbOutNextDay1;
    private System.Windows.Forms.ComboBox cbbOtType1;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.TextBox txtBefore2;
    private System.Windows.Forms.ComboBox cbbOutNextDay2;
    private System.Windows.Forms.TextBox txtAfter2;
    private System.Windows.Forms.MaskedTextBox txtEndTime2;
    private System.Windows.Forms.ComboBox cbbInNextDay2;
    private System.Windows.Forms.MaskedTextBox txtStartTime2;
    private System.Windows.Forms.ComboBox cbbOtType2;
    private System.Windows.Forms.Label label17;
    private System.Windows.Forms.TextBox txtBefore3;
    private System.Windows.Forms.ComboBox cbbOtType3;
    private System.Windows.Forms.ComboBox cbbOutNextDay3;
    private System.Windows.Forms.TextBox txtAfter3;
    private System.Windows.Forms.MaskedTextBox txtEndTime3;
    private System.Windows.Forms.ComboBox cbbInNextDay3;
    private System.Windows.Forms.MaskedTextBox txtStartTime3;
    private System.Windows.Forms.CheckBox chkIsDirect;
    private System.Windows.Forms.Button btnClear;
  }
}
