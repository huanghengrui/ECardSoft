namespace ECard78
{
  partial class frmPubContinue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPubContinue));
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNotAllContinue = new System.Windows.Forms.Button();
            this.btnAllContinue = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(310, 101);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(230, 101);
            this.btnOk.TabIndex = 15;
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
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList.Images.SetKeyName(0, "Closed Folder_p4.bmp");
            this.ImageList.Images.SetKeyName(1, "Open Folder_p5.bmp");
            this.ImageList.Images.SetKeyName(2, "37_p5.bmp");
            this.ImageList.Images.SetKeyName(3, "Hard Drive_p5.bmp");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(369, 82);
            this.panel1.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNotAllContinue
            // 
            this.btnNotAllContinue.Location = new System.Drawing.Point(15, 102);
            this.btnNotAllContinue.Name = "btnNotAllContinue";
            this.btnNotAllContinue.Size = new System.Drawing.Size(75, 23);
            this.btnNotAllContinue.TabIndex = 18;
            this.btnNotAllContinue.Text = "button1";
            this.btnNotAllContinue.UseVisualStyleBackColor = true;
            this.btnNotAllContinue.Click += new System.EventHandler(this.btnNotAllContinue_Click);
            // 
            // btnAllContinue
            // 
            this.btnAllContinue.Location = new System.Drawing.Point(106, 102);
            this.btnAllContinue.Name = "btnAllContinue";
            this.btnAllContinue.Size = new System.Drawing.Size(75, 23);
            this.btnAllContinue.TabIndex = 19;
            this.btnAllContinue.Text = "button2";
            this.btnAllContinue.UseVisualStyleBackColor = true;
            this.btnAllContinue.Click += new System.EventHandler(this.btnAllContinue_Click);
            // 
            // frmPubContinue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(394, 134);
            this.Controls.Add(this.btnAllContinue);
            this.Controls.Add(this.btnNotAllContinue);
            this.Controls.Add(this.panel1);
            this.Name = "frmPubContinue";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnNotAllContinue, 0);
            this.Controls.SetChildIndex(this.btnAllContinue, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.ImageList ImageList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNotAllContinue;
        private System.Windows.Forms.Button btnAllContinue;
    }
}
