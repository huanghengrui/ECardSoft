namespace ECard78
{
  partial class frmKQFaceBase
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
