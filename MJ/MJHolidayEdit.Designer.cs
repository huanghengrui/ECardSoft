namespace ECard78
{
  partial class frmMJHolidayEdit
  {
    /// <summary>
    /// ����������������
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// ������������ʹ�õ���Դ��
    /// </summary>
    /// <param name="disposing">���Ӧ�ͷ��й���Դ��Ϊ true������Ϊ false��</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows ������������ɵĴ���

    /// <summary>
    /// �����֧������ķ��� - ��Ҫ
    /// ʹ�ô���༭���޸Ĵ˷��������ݡ�
    /// </summary>
    private void InitializeComponent()
    {
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
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(225, 135);
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(145, 135);
      this.btnOk.Text = "";
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
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
      this.txtMemo.Location = new System.Drawing.Point(100, 100);
      this.txtMemo.MaxLength = 255;
      this.txtMemo.Name = "txtMemo";
      this.txtMemo.Size = new System.Drawing.Size(200, 21);
      this.txtMemo.TabIndex = 6;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(10, 104);
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
      // frmMJHolidayEdit
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(309, 168);
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
  }
}
