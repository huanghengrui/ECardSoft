namespace ECard78
{
  partial class frmBaseMDIChildTree
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseMDIChildTree));
      this.imgList = new System.Windows.Forms.ImageList(this.components);
      this.tvEmp = new System.Windows.Forms.TreeView();
      this.spl = new System.Windows.Forms.Splitter();
      this.pnlRight = new System.Windows.Forms.Panel();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // imgList
      // 
      this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
      this.imgList.TransparentColor = System.Drawing.Color.Silver;
      this.imgList.Images.SetKeyName(0, "REPORTL_p2.bmp");
      this.imgList.Images.SetKeyName(1, "USER_P2.BMP");
      // 
      // tvEmp
      // 
      this.tvEmp.Dock = System.Windows.Forms.DockStyle.Left;
      this.tvEmp.FullRowSelect = true;
      this.tvEmp.HideSelection = false;
      this.tvEmp.ImageIndex = 0;
      this.tvEmp.ImageList = this.imgList;
      this.tvEmp.ItemHeight = 20;
      this.tvEmp.Location = new System.Drawing.Point(0, 25);
      this.tvEmp.Name = "tvEmp";
      this.tvEmp.SelectedImageIndex = 0;
      this.tvEmp.Size = new System.Drawing.Size(200, 275);
      this.tvEmp.TabIndex = 5;
      // 
      // spl
      // 
      this.spl.Location = new System.Drawing.Point(200, 25);
      this.spl.Name = "spl";
      this.spl.Size = new System.Drawing.Size(4, 275);
      this.spl.TabIndex = 6;
      this.spl.TabStop = false;
      // 
      // pnlRight
      // 
      this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlRight.Location = new System.Drawing.Point(204, 25);
      this.pnlRight.Name = "pnlRight";
      this.pnlRight.Size = new System.Drawing.Size(348, 275);
      this.pnlRight.TabIndex = 7;
      // 
      // frmBaseMDIChildTree
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(552, 326);
      this.Controls.Add(this.pnlRight);
      this.Controls.Add(this.spl);
      this.Controls.Add(this.tvEmp);
      this.Name = "frmBaseMDIChildTree";
      this.Controls.SetChildIndex(this.tvEmp, 0);
      this.Controls.SetChildIndex(this.spl, 0);
      this.Controls.SetChildIndex(this.pnlRight, 0);
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ImageList imgList;
    protected System.Windows.Forms.TreeView tvEmp;
    protected System.Windows.Forms.Splitter spl;
    protected System.Windows.Forms.Panel pnlRight;

  }
}
