namespace ECard78
{
  partial class frmKQDepWorkTypeAdd
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
      this.txtDepartName = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.btnSelectDepart = new System.Windows.Forms.Button();
      this.txtDepartID = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.cbbRest = new System.Windows.Forms.ComboBox();
      this.label5 = new System.Windows.Forms.Label();
      this.chkIsPressed = new System.Windows.Forms.CheckBox();
      this.chkOtIsHaveBar = new System.Windows.Forms.CheckBox();
      this.cbbShiftNo = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
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
      this.tvDepart = new System.Windows.Forms.TreeView();
      this.optSelectAll = new System.Windows.Forms.RadioButton();
      this.optSelect = new System.Windows.Forms.RadioButton();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(470, 255);
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(390, 255);
      this.btnOk.Text = "";
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // txtDepartName
      // 
      this.txtDepartName.Location = new System.Drawing.Point(100, 40);
      this.txtDepartName.Name = "txtDepartName";
      this.txtDepartName.ReadOnly = true;
      this.txtDepartName.Size = new System.Drawing.Size(160, 21);
      this.txtDepartName.TabIndex = 35;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
      this.label3.Location = new System.Drawing.Point(10, 44);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(41, 12);
      this.label3.TabIndex = 37;
      this.label3.Tag = "DepartName";
      this.label3.Text = "label3";
      // 
      // btnSelectDepart
      // 
      this.btnSelectDepart.Location = new System.Drawing.Point(225, 11);
      this.btnSelectDepart.Name = "btnSelectDepart";
      this.btnSelectDepart.Size = new System.Drawing.Size(34, 19);
      this.btnSelectDepart.TabIndex = 34;
      this.btnSelectDepart.Text = "button1";
      this.btnSelectDepart.UseVisualStyleBackColor = true;
      this.btnSelectDepart.Click += new System.EventHandler(this.btnSelectDepart_Click);
      // 
      // txtDepartID
      // 
      this.txtDepartID.Location = new System.Drawing.Point(100, 10);
      this.txtDepartID.Name = "txtDepartID";
      this.txtDepartID.Size = new System.Drawing.Size(160, 21);
      this.txtDepartID.TabIndex = 33;
      this.txtDepartID.Leave += new System.EventHandler(this.txtDepartID_Leave);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.ForeColor = System.Drawing.Color.Red;
      this.label2.Location = new System.Drawing.Point(10, 14);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(41, 12);
      this.label2.TabIndex = 36;
      this.label2.Tag = "DepartID";
      this.label2.Text = "label2";
      // 
      // cbbRest
      // 
      this.cbbRest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbRest.FormattingEnabled = true;
      this.cbbRest.Location = new System.Drawing.Point(100, 160);
      this.cbbRest.Name = "cbbRest";
      this.cbbRest.Size = new System.Drawing.Size(160, 20);
      this.cbbRest.TabIndex = 42;
      this.cbbRest.SelectedIndexChanged += new System.EventHandler(this.cbbRest_SelectedIndexChanged);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(10, 164);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(41, 12);
      this.label5.TabIndex = 44;
      this.label5.Tag = "EmpRest";
      this.label5.Text = "label5";
      // 
      // chkIsPressed
      // 
      this.chkIsPressed.Checked = true;
      this.chkIsPressed.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkIsPressed.Location = new System.Drawing.Point(10, 130);
      this.chkIsPressed.Name = "chkIsPressed";
      this.chkIsPressed.Size = new System.Drawing.Size(250, 20);
      this.chkIsPressed.TabIndex = 41;
      this.chkIsPressed.Tag = "EmpIsPressed";
      this.chkIsPressed.Text = "checkBox2";
      this.chkIsPressed.UseVisualStyleBackColor = true;
      // 
      // chkOtIsHaveBar
      // 
      this.chkOtIsHaveBar.Location = new System.Drawing.Point(10, 100);
      this.chkOtIsHaveBar.Name = "chkOtIsHaveBar";
      this.chkOtIsHaveBar.Size = new System.Drawing.Size(250, 20);
      this.chkOtIsHaveBar.TabIndex = 40;
      this.chkOtIsHaveBar.Tag = "EmpOtIsHaveBar";
      this.chkOtIsHaveBar.Text = "checkBox1";
      this.chkOtIsHaveBar.UseVisualStyleBackColor = true;
      // 
      // cbbShiftNo
      // 
      this.cbbShiftNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbShiftNo.FormattingEnabled = true;
      this.cbbShiftNo.Location = new System.Drawing.Point(100, 70);
      this.cbbShiftNo.Name = "cbbShiftNo";
      this.cbbShiftNo.Size = new System.Drawing.Size(160, 20);
      this.cbbShiftNo.TabIndex = 39;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(10, 74);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 12);
      this.label1.TabIndex = 43;
      this.label1.Tag = "DefaultDptShiftNo";
      this.label1.Text = "label1";
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.cbbHoli);
      this.panel1.Controls.Add(this.label7);
      this.panel1.Controls.Add(this.cbbWeek);
      this.panel1.Controls.Add(this.label6);
      this.panel1.Location = new System.Drawing.Point(10, 190);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(250, 55);
      this.panel1.TabIndex = 45;
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
      this.panel2.Location = new System.Drawing.Point(10, 190);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(250, 55);
      this.panel2.TabIndex = 46;
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
      this.groupBox1.Controls.Add(this.tvDepart);
      this.groupBox1.Controls.Add(this.optSelectAll);
      this.groupBox1.Controls.Add(this.optSelect);
      this.groupBox1.Location = new System.Drawing.Point(270, 10);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(275, 230);
      this.groupBox1.TabIndex = 47;
      this.groupBox1.TabStop = false;
      this.groupBox1.Tag = "SameDepart";
      this.groupBox1.Text = "groupBox1";
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
      this.tvDepart.Location = new System.Drawing.Point(10, 70);
      this.tvDepart.Name = "tvDepart";
      this.tvDepart.Size = new System.Drawing.Size(255, 150);
      this.tvDepart.TabIndex = 25;
      this.tvDepart.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvDepart_AfterCheck);
      // 
      // optSelectAll
      // 
      this.optSelectAll.AutoSize = true;
      this.optSelectAll.Location = new System.Drawing.Point(10, 45);
      this.optSelectAll.Name = "optSelectAll";
      this.optSelectAll.Size = new System.Drawing.Size(95, 16);
      this.optSelectAll.TabIndex = 24;
      this.optSelectAll.TabStop = true;
      this.optSelectAll.Text = "radioButton2";
      this.optSelectAll.UseVisualStyleBackColor = true;
      // 
      // optSelect
      // 
      this.optSelect.AutoSize = true;
      this.optSelect.Checked = true;
      this.optSelect.Location = new System.Drawing.Point(10, 20);
      this.optSelect.Name = "optSelect";
      this.optSelect.Size = new System.Drawing.Size(95, 16);
      this.optSelect.TabIndex = 23;
      this.optSelect.TabStop = true;
      this.optSelect.Text = "radioButton1";
      this.optSelect.UseVisualStyleBackColor = true;
      // 
      // frmKQDepWorkTypeAdd
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(554, 288);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.cbbRest);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.chkIsPressed);
      this.Controls.Add(this.chkOtIsHaveBar);
      this.Controls.Add(this.cbbShiftNo);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtDepartName);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.btnSelectDepart);
      this.Controls.Add(this.txtDepartID);
      this.Controls.Add(this.label2);
      this.Name = "frmKQDepWorkTypeAdd";
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.Controls.SetChildIndex(this.label2, 0);
      this.Controls.SetChildIndex(this.txtDepartID, 0);
      this.Controls.SetChildIndex(this.btnSelectDepart, 0);
      this.Controls.SetChildIndex(this.label3, 0);
      this.Controls.SetChildIndex(this.txtDepartName, 0);
      this.Controls.SetChildIndex(this.label1, 0);
      this.Controls.SetChildIndex(this.cbbShiftNo, 0);
      this.Controls.SetChildIndex(this.chkOtIsHaveBar, 0);
      this.Controls.SetChildIndex(this.chkIsPressed, 0);
      this.Controls.SetChildIndex(this.label5, 0);
      this.Controls.SetChildIndex(this.cbbRest, 0);
      this.Controls.SetChildIndex(this.panel1, 0);
      this.Controls.SetChildIndex(this.panel2, 0);
      this.Controls.SetChildIndex(this.groupBox1, 0);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtDepartName;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button btnSelectDepart;
    private System.Windows.Forms.TextBox txtDepartID;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox cbbRest;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.CheckBox chkIsPressed;
    private System.Windows.Forms.CheckBox chkOtIsHaveBar;
    private System.Windows.Forms.ComboBox cbbShiftNo;
    private System.Windows.Forms.Label label1;
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
    private System.Windows.Forms.RadioButton optSelectAll;
    private System.Windows.Forms.RadioButton optSelect;
    private System.Windows.Forms.TreeView tvDepart;
  }
}
