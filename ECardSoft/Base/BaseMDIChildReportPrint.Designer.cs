namespace ECard78
{
  partial class frmBaseMDIChildReportPrint
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseMDIChildReportPrint));
      this.panel1 = new System.Windows.Forms.Panel();
      ((System.ComponentModel.ISupportInitialize)(this.dispView)).BeginInit();
      this.pnlDisp.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // dispView
      // 
      this.dispView.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("dispView.OcxState")));
      this.dispView.Size = new System.Drawing.Size(372, 275);
      // 
      // pnlDisp
      // 
      this.pnlDisp.Location = new System.Drawing.Point(180, 25);
      this.pnlDisp.Size = new System.Drawing.Size(372, 275);
      // 
      // panel1
      // 
      this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
      this.panel1.Location = new System.Drawing.Point(0, 25);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(180, 275);
      this.panel1.TabIndex = 1;
      // 
      // frmBaseMDIChildReportPrint
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(552, 326);
      this.Controls.Add(this.panel1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.KeyPreview = true;
      this.Name = "frmBaseMDIChildReportPrint";
      this.Controls.SetChildIndex(this.panel1, 0);
      this.Controls.SetChildIndex(this.pnlDisp, 0);
      ((System.ComponentModel.ISupportInitialize)(this.dispView)).EndInit();
      this.pnlDisp.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    protected System.Windows.Forms.Panel panel1;

  }
}
