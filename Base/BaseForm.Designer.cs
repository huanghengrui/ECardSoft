namespace ECard78
{
  partial class frmBaseForm
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseForm));
      this.toolTip = new System.Windows.Forms.ToolTip(this.components);
      this.ilTreeState = new System.Windows.Forms.ImageList(this.components);
      this.SuspendLayout();
      // 
      // toolTip
      // 
      this.toolTip.ShowAlways = true;
      this.toolTip.StripAmpersands = true;
      this.toolTip.UseAnimation = false;
      this.toolTip.UseFading = false;
      // 
      // ilTreeState
      // 
      this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
      this.ilTreeState.TransparentColor = System.Drawing.Color.Transparent;
      this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
      this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
      this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
      // 
      // frmBaseForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(554, 328);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmBaseForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "BaseForm";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBaseForm_FormClosing);
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBaseForm_FormClosed);
      this.Load += new System.EventHandler(this.frmBaseForm_Load);
      this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmBaseForm_KeyPress);
      this.ResumeLayout(false);

    }

    #endregion

    protected System.Windows.Forms.ToolTip toolTip;
    protected System.Windows.Forms.ImageList ilTreeState;



  }
}

