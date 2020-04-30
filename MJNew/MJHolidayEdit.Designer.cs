namespace ECard78
{
  partial class frmMJHolidayEdit
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMJHolidayEdit));
      this.label1 = new System.Windows.Forms.Label();
      this.txtID = new System.Windows.Forms.TextBox();
      this.chkApply = new System.Windows.Forms.CheckBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtBegin = new System.Windows.Forms.TextBox();
      this.txtEnd = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txtMemo = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.btnBegin = new System.Windows.Forms.Button();
      this.btnEnd = new System.Windows.Forms.Button();
      this.label5 = new System.Windows.Forms.Label();
      this.cbbTimeNo = new System.Windows.Forms.ComboBox();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(225, 164);
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(145, 164);
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
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(10, 14);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 12);
      this.label1.TabIndex = 19;
      this.label1.Tag = "MJHoliID";
      this.label1.Text = "label1";
      // 
      // txtID
      // 
      this.txtID.AcceptsReturn = true;
      this.txtID.Location = new System.Drawing.Point(100, 10);
      this.txtID.Name = "txtID";
      this.txtID.ReadOnly = true;
      this.txtID.Size = new System.Drawing.Size(100, 21);
      this.txtID.TabIndex = 0;
      // 
      // chkApply
      // 
      this.chkApply.AutoSize = true;
      this.chkApply.Location = new System.Drawing.Point(220, 12);
      this.chkApply.Name = "chkApply";
      this.chkApply.Size = new System.Drawing.Size(78, 16);
      this.chkApply.TabIndex = 1;
      this.chkApply.Tag = "MJHoliIsApply";
      this.chkApply.Text = "checkBox1";
      this.chkApply.UseVisualStyleBackColor = true;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(10, 44);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(41, 12);
      this.label2.TabIndex = 22;
      this.label2.Tag = "MJHoliBeginDate";
      this.label2.Text = "label2";
      // 
      // txtBegin
      // 
      this.txtBegin.AcceptsReturn = true;
      this.txtBegin.Location = new System.Drawing.Point(100, 40);
      this.txtBegin.Name = "txtBegin";
      this.txtBegin.Size = new System.Drawing.Size(200, 21);
      this.txtBegin.TabIndex = 2;
      // 
      // txtEnd
      // 
      this.txtEnd.Location = new System.Drawing.Point(100, 70);
      this.txtEnd.Name = "txtEnd";
      this.txtEnd.Size = new System.Drawing.Size(200, 21);
      this.txtEnd.TabIndex = 4;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(10, 74);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(41, 12);
      this.label3.TabIndex = 24;
      this.label3.Tag = "MJHoliEndDate";
      this.label3.Text = "label3";
      // 
      // txtMemo
      // 
      this.txtMemo.Location = new System.Drawing.Point(100, 130);
      this.txtMemo.MaxLength = 255;
      this.txtMemo.Name = "txtMemo";
      this.txtMemo.Size = new System.Drawing.Size(200, 21);
      this.txtMemo.TabIndex = 7;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(10, 134);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(41, 12);
      this.label4.TabIndex = 26;
      this.label4.Tag = "MJHoliMemo";
      this.label4.Text = "label4";
      // 
      // btnBegin
      // 
      this.btnBegin.Location = new System.Drawing.Point(265, 41);
      this.btnBegin.Name = "btnBegin";
      this.btnBegin.Size = new System.Drawing.Size(34, 19);
      this.btnBegin.TabIndex = 3;
      this.btnBegin.Tag = "btnSelectEmp";
      this.btnBegin.Text = "...";
      this.btnBegin.UseVisualStyleBackColor = true;
      this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
      // 
      // btnEnd
      // 
      this.btnEnd.Location = new System.Drawing.Point(265, 71);
      this.btnEnd.Name = "btnEnd";
      this.btnEnd.Size = new System.Drawing.Size(34, 19);
      this.btnEnd.TabIndex = 5;
      this.btnEnd.Tag = "btnSelectEmp";
      this.btnEnd.Text = "...";
      this.btnEnd.UseVisualStyleBackColor = true;
      this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(10, 104);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(41, 12);
      this.label5.TabIndex = 27;
      this.label5.Tag = "MacTimeNo";
      this.label5.Text = "label5";
      // 
      // cbbTimeNo
      // 
      this.cbbTimeNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbTimeNo.FormattingEnabled = true;
      this.cbbTimeNo.Location = new System.Drawing.Point(100, 100);
      this.cbbTimeNo.Name = "cbbTimeNo";
      this.cbbTimeNo.Size = new System.Drawing.Size(199, 20);
      this.cbbTimeNo.TabIndex = 6;
      // 
      // frmMJHolidayEdit
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(309, 197);
      this.Controls.Add(this.cbbTimeNo);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.btnEnd);
      this.Controls.Add(this.btnBegin);
      this.Controls.Add(this.txtMemo);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.txtEnd);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txtBegin);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.chkApply);
      this.Controls.Add(this.txtID);
      this.Controls.Add(this.label1);
      this.Name = "frmMJHolidayEdit";
      this.Controls.SetChildIndex(this.label1, 0);
      this.Controls.SetChildIndex(this.txtID, 0);
      this.Controls.SetChildIndex(this.chkApply, 0);
      this.Controls.SetChildIndex(this.label2, 0);
      this.Controls.SetChildIndex(this.txtBegin, 0);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.Controls.SetChildIndex(this.label3, 0);
      this.Controls.SetChildIndex(this.txtEnd, 0);
      this.Controls.SetChildIndex(this.label4, 0);
      this.Controls.SetChildIndex(this.txtMemo, 0);
      this.Controls.SetChildIndex(this.btnBegin, 0);
      this.Controls.SetChildIndex(this.btnEnd, 0);
      this.Controls.SetChildIndex(this.label5, 0);
      this.Controls.SetChildIndex(this.cbbTimeNo, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtID;
    private System.Windows.Forms.CheckBox chkApply;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtBegin;
    private System.Windows.Forms.TextBox txtEnd;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtMemo;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button btnBegin;
    private System.Windows.Forms.Button btnEnd;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ComboBox cbbTimeNo;
  }
}
