namespace ECard78
{
  partial class frmPubDisplay
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
      this.chkDisply = new System.Windows.Forms.CheckedListBox();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(270, 335);
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(190, 335);
      this.btnOk.Text = "";
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // chkDisply
      // 
      this.chkDisply.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.chkDisply.FormattingEnabled = true;
      this.chkDisply.IntegralHeight = false;
      this.chkDisply.Location = new System.Drawing.Point(10, 10);
      this.chkDisply.Name = "chkDisply";
      this.chkDisply.Size = new System.Drawing.Size(335, 315);
      this.chkDisply.TabIndex = 19;
      // 
      // frmPubDisplay
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(354, 368);
      this.Controls.Add(this.chkDisply);
      this.Name = "frmPubDisplay";
      this.Controls.SetChildIndex(this.chkDisply, 0);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.CheckedListBox chkDisply;
  }
}
