namespace ECard78
{
  partial class frmSFAddress
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSFAddress));
      this.tvAddress = new System.Windows.Forms.TreeView();
      this.imgList = new System.Windows.Forms.ImageList(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // tvAddress
      // 
      this.tvAddress.ContextMenuStrip = this.contextMenu;
      this.tvAddress.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tvAddress.FullRowSelect = true;
      this.tvAddress.HideSelection = false;
      this.tvAddress.ImageIndex = 0;
      this.tvAddress.ImageList = this.imgList;
      this.tvAddress.ItemHeight = 20;
      this.tvAddress.Location = new System.Drawing.Point(0, 25);
      this.tvAddress.Name = "tvAddress";
      this.tvAddress.SelectedImageIndex = 0;
      this.tvAddress.Size = new System.Drawing.Size(552, 275);
      this.tvAddress.TabIndex = 3;
      this.tvAddress.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvAddress_AfterSelect);
      // 
      // imgList
      // 
      this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
      this.imgList.TransparentColor = System.Drawing.Color.Silver;
      this.imgList.Images.SetKeyName(0, "选项16.bmp");
      // 
      // frmSFAddress
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(552, 326);
      this.Controls.Add(this.tvAddress);
      this.Name = "frmSFAddress";
      this.Controls.SetChildIndex(this.tvAddress, 0);
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TreeView tvAddress;
    private System.Windows.Forms.ImageList imgList;

  }
}
