namespace ECard78
{
  partial class frmMJMap
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
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.panel1 = new System.Windows.Forms.Panel();
      this.panel3 = new System.Windows.Forms.Panel();
      this.picPhoto = new System.Windows.Forms.PictureBox();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.lbMsg = new System.Windows.Forms.ListBox();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
      this.panel1.SuspendLayout();
      this.panel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).BeginInit();
      this.SuspendLayout();
      // 
      // timer1
      // 
      this.timer1.Interval = 1;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.lbMsg);
      this.panel1.Controls.Add(this.panel3);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 25);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(552, 203);
      this.panel1.TabIndex = 5;
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.picPhoto);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
      this.panel3.Location = new System.Drawing.Point(407, 0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(145, 203);
      this.panel3.TabIndex = 14;
      // 
      // picPhoto
      // 
      this.picPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.picPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
      this.picPhoto.Location = new System.Drawing.Point(0, 0);
      this.picPhoto.Name = "picPhoto";
      this.picPhoto.Size = new System.Drawing.Size(145, 203);
      this.picPhoto.TabIndex = 12;
      this.picPhoto.TabStop = false;
      // 
      // tabControl1
      // 
      this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl1.Location = new System.Drawing.Point(0, 228);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(552, 72);
      this.tabControl1.TabIndex = 6;
      // 
      // lbMsg
      // 
      this.lbMsg.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lbMsg.FormattingEnabled = true;
      this.lbMsg.IntegralHeight = false;
      this.lbMsg.ItemHeight = 12;
      this.lbMsg.Location = new System.Drawing.Point(0, 0);
      this.lbMsg.Name = "lbMsg";
      this.lbMsg.Size = new System.Drawing.Size(407, 203);
      this.lbMsg.TabIndex = 15;
      this.lbMsg.SelectedIndexChanged += new System.EventHandler(this.lbMsg_SelectedIndexChanged);
      // 
      // frmMJMap
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(552, 326);
      this.Controls.Add(this.tabControl1);
      this.Controls.Add(this.panel1);
      this.Name = "frmMJMap";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMJMap_FormClosing);
      this.Controls.SetChildIndex(this.panel1, 0);
      this.Controls.SetChildIndex(this.tabControl1, 0);
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.PictureBox picPhoto;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.ListBox lbMsg;
  }
}
