namespace ECard78
{
  partial class frmMessage
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
      this.panel1 = new System.Windows.Forms.Panel();
      this.label1 = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.ProgBar = new System.Windows.Forms.ProgressBar();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.label1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(400, 30);
      this.panel1.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.label1.Location = new System.Drawing.Point(0, 18);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(400, 12);
      this.label1.TabIndex = 0;
      this.label1.Text = "label1";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.ProgBar);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel2.Location = new System.Drawing.Point(0, 40);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(400, 20);
      this.panel2.TabIndex = 1;
      this.panel2.Visible = false;
      // 
      // ProgBar
      // 
      this.ProgBar.Dock = System.Windows.Forms.DockStyle.Top;
      this.ProgBar.Location = new System.Drawing.Point(0, 0);
      this.ProgBar.Name = "ProgBar";
      this.ProgBar.Size = new System.Drawing.Size(400, 15);
      this.ProgBar.Step = 1;
      this.ProgBar.TabIndex = 0;
      // 
      // frmMessage
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.ClientSize = new System.Drawing.Size(400, 60);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "frmMessage";
      this.Text = "";
      this.Shown += new System.EventHandler(this.frmMessage_Shown);
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.ProgressBar ProgBar;

  }
}
