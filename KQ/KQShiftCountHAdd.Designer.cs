namespace ECard78
{
  partial class frmKQShiftCountHAdd
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
      this.txtName = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtNo = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.txtInTime = new System.Windows.Forms.MaskedTextBox();
      this.chkInNextDay = new System.Windows.Forms.CheckBox();
      this.label4 = new System.Windows.Forms.Label();
      this.txtOutTime = new System.Windows.Forms.MaskedTextBox();
      this.chkOutNextDay = new System.Windows.Forms.CheckBox();
      this.rbRoundHour = new System.Windows.Forms.RadioButton();
      this.rbRoundHalf = new System.Windows.Forms.RadioButton();
      this.chkRound = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(335, 135);
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(255, 135);
      this.btnOk.Text = "";
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // txtName
      // 
      this.txtName.Location = new System.Drawing.Point(310, 10);
      this.txtName.MaxLength = 50;
      this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(100, 21);
      this.txtName.TabIndex = 1;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.ForeColor = System.Drawing.Color.Red;
      this.label2.Location = new System.Drawing.Point(220, 14);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(41, 12);
      this.label2.TabIndex = 25;
      this.label2.Tag = "ShiftCountHName";
      this.label2.Text = "label2";
      // 
      // txtNo
      // 
      this.txtNo.Location = new System.Drawing.Point(100, 10);
      this.txtNo.MaxLength = 20;
      this.txtNo.Name = "txtNo";
      this.txtNo.Size = new System.Drawing.Size(100, 21);
      this.txtNo.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.ForeColor = System.Drawing.Color.Red;
      this.label1.Location = new System.Drawing.Point(10, 14);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 12);
      this.label1.TabIndex = 24;
      this.label1.Tag = "ShiftCountHNo";
      this.label1.Text = "label1";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(10, 44);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(41, 12);
      this.label3.TabIndex = 26;
      this.label3.Tag = "ShiftCountHInTime";
      this.label3.Text = "label3";
      // 
      // txtInTime
      // 
      this.txtInTime.Location = new System.Drawing.Point(100, 40);
      this.txtInTime.Mask = "99:99";
      this.txtInTime.Name = "txtInTime";
      this.txtInTime.PromptChar = ' ';
      this.txtInTime.Size = new System.Drawing.Size(40, 21);
      this.txtInTime.TabIndex = 2;
      this.txtInTime.Text = "0000";
      // 
      // chkInNextDay
      // 
      this.chkInNextDay.Location = new System.Drawing.Point(145, 40);
      this.chkInNextDay.Name = "chkInNextDay";
      this.chkInNextDay.Size = new System.Drawing.Size(55, 20);
      this.chkInNextDay.TabIndex = 3;
      this.chkInNextDay.Tag = "ShiftNextDay";
      this.chkInNextDay.Text = "checkBox1";
      this.chkInNextDay.UseVisualStyleBackColor = true;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(220, 44);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(41, 12);
      this.label4.TabIndex = 29;
      this.label4.Tag = "ShiftCountHOutTime";
      this.label4.Text = "label4";
      // 
      // txtOutTime
      // 
      this.txtOutTime.Location = new System.Drawing.Point(310, 40);
      this.txtOutTime.Mask = "99:99";
      this.txtOutTime.Name = "txtOutTime";
      this.txtOutTime.PromptChar = ' ';
      this.txtOutTime.Size = new System.Drawing.Size(40, 21);
      this.txtOutTime.TabIndex = 4;
      this.txtOutTime.Text = "0000";
      // 
      // chkOutNextDay
      // 
      this.chkOutNextDay.Location = new System.Drawing.Point(355, 40);
      this.chkOutNextDay.Name = "chkOutNextDay";
      this.chkOutNextDay.Size = new System.Drawing.Size(55, 20);
      this.chkOutNextDay.TabIndex = 5;
      this.chkOutNextDay.Tag = "ShiftNextDay";
      this.chkOutNextDay.Text = "checkBox2";
      this.chkOutNextDay.UseVisualStyleBackColor = true;
      // 
      // rbRoundHour
      // 
      this.rbRoundHour.AutoSize = true;
      this.rbRoundHour.Location = new System.Drawing.Point(100, 90);
      this.rbRoundHour.Name = "rbRoundHour";
      this.rbRoundHour.Size = new System.Drawing.Size(95, 16);
      this.rbRoundHour.TabIndex = 8;
      this.rbRoundHour.Text = "radioButton2";
      this.rbRoundHour.UseVisualStyleBackColor = true;
      // 
      // rbRoundHalf
      // 
      this.rbRoundHalf.AutoSize = true;
      this.rbRoundHalf.Checked = true;
      this.rbRoundHalf.Location = new System.Drawing.Point(100, 70);
      this.rbRoundHalf.Name = "rbRoundHalf";
      this.rbRoundHalf.Size = new System.Drawing.Size(95, 16);
      this.rbRoundHalf.TabIndex = 7;
      this.rbRoundHalf.TabStop = true;
      this.rbRoundHalf.Text = "radioButton1";
      this.rbRoundHalf.UseVisualStyleBackColor = true;
      // 
      // chkRound
      // 
      this.chkRound.AutoSize = true;
      this.chkRound.Location = new System.Drawing.Point(10, 70);
      this.chkRound.Name = "chkRound";
      this.chkRound.Size = new System.Drawing.Size(78, 16);
      this.chkRound.TabIndex = 6;
      this.chkRound.Text = "checkBox1";
      this.chkRound.UseVisualStyleBackColor = true;
      // 
      // frmKQShiftCountHAdd
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(419, 168);
      this.Controls.Add(this.rbRoundHour);
      this.Controls.Add(this.rbRoundHalf);
      this.Controls.Add(this.chkRound);
      this.Controls.Add(this.chkOutNextDay);
      this.Controls.Add(this.txtOutTime);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.chkInNextDay);
      this.Controls.Add(this.txtInTime);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txtName);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txtNo);
      this.Controls.Add(this.label1);
      this.Name = "frmKQShiftCountHAdd";
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.Controls.SetChildIndex(this.label1, 0);
      this.Controls.SetChildIndex(this.txtNo, 0);
      this.Controls.SetChildIndex(this.label2, 0);
      this.Controls.SetChildIndex(this.txtName, 0);
      this.Controls.SetChildIndex(this.label3, 0);
      this.Controls.SetChildIndex(this.txtInTime, 0);
      this.Controls.SetChildIndex(this.chkInNextDay, 0);
      this.Controls.SetChildIndex(this.label4, 0);
      this.Controls.SetChildIndex(this.txtOutTime, 0);
      this.Controls.SetChildIndex(this.chkOutNextDay, 0);
      this.Controls.SetChildIndex(this.chkRound, 0);
      this.Controls.SetChildIndex(this.rbRoundHalf, 0);
      this.Controls.SetChildIndex(this.rbRoundHour, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtNo;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.MaskedTextBox txtInTime;
    private System.Windows.Forms.CheckBox chkInNextDay;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.MaskedTextBox txtOutTime;
    private System.Windows.Forms.CheckBox chkOutNextDay;
    private System.Windows.Forms.RadioButton rbRoundHour;
    private System.Windows.Forms.RadioButton rbRoundHalf;
    private System.Windows.Forms.CheckBox chkRound;
  }
}
