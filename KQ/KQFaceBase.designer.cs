namespace ECard78
{
  partial class frmKQFaceBase
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
      this.txtMag = new System.Windows.Forms.TextBox();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // txtMag
      // 
      this.txtMag.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.txtMag.Location = new System.Drawing.Point(0, 200);
      this.txtMag.Multiline = true;
      this.txtMag.Name = "txtMag";
      this.txtMag.ReadOnly = true;
      this.txtMag.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txtMag.Size = new System.Drawing.Size(552, 100);
      this.txtMag.TabIndex = 10;
      // 
      // frmKQFaceBase
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(552, 326);
      this.Controls.Add(this.txtMag);
      this.Name = "frmKQFaceBase";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmKQFaceBase_FormClosing);
      this.Controls.SetChildIndex(this.txtMag, 1);
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtMag;
  }
}
