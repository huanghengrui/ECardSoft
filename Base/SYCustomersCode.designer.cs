namespace ECard78
{
  partial class frmSYCustomersCode
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
      this.Label1 = new System.Windows.Forms.Label();
      this.txtCode = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(185, 40);
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(105, 40);
      this.btnOk.Text = "";
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // Label1
      // 
      this.Label1.AutoSize = true;
      this.Label1.Location = new System.Drawing.Point(10, 14);
      this.Label1.Name = "Label1";
      this.Label1.Size = new System.Drawing.Size(41, 12);
      this.Label1.TabIndex = 19;
      this.Label1.Text = "label1";
      // 
      // txtCode
      // 
      this.txtCode.Location = new System.Drawing.Point(100, 10);
      this.txtCode.MaxLength = 6;
      this.txtCode.Name = "txtCode";
      this.txtCode.Size = new System.Drawing.Size(160, 21);
      this.txtCode.TabIndex = 0;
      // 
      // frmSYCustomersCode
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(269, 73);
      this.Controls.Add(this.Label1);
      this.Controls.Add(this.txtCode);
      this.Name = "frmSYCustomersCode";
      this.Controls.SetChildIndex(this.txtCode, 0);
      this.Controls.SetChildIndex(this.Label1, 0);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label Label1;
    private System.Windows.Forms.TextBox txtCode;
  }
}
