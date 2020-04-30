namespace ECard78
{
  partial class frmPubSelectVarieties
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPubSelectAddress));
      this.imgList = new System.Windows.Forms.ImageList(this.components);
      this.tvAddress = new System.Windows.Forms.TreeView();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(310, 335);
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(230, 335);
      this.btnOk.Text = "";
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // imgList
      // 
      this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
      this.imgList.TransparentColor = System.Drawing.Color.Silver;
      this.imgList.Images.SetKeyName(0, "选项16.bmp");
      // 
      // tvAddress
      // 
      this.tvAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.tvAddress.FullRowSelect = true;
      this.tvAddress.HideSelection = false;
      this.tvAddress.ImageIndex = 0;
      this.tvAddress.ImageList = this.imgList;
      this.tvAddress.ItemHeight = 20;
      this.tvAddress.Location = new System.Drawing.Point(10, 10);
      this.tvAddress.Name = "tvAddress";
      this.tvAddress.SelectedImageIndex = 0;
      this.tvAddress.Size = new System.Drawing.Size(375, 315);
      this.tvAddress.TabIndex = 0;
      this.tvAddress.DoubleClick += new System.EventHandler(this.tvDepart_DoubleClick);
      // 
      // frmPubSelectAddress
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(394, 368);
      this.Controls.Add(this.tvAddress);
      this.Name = "frmPubSelectAddress";
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.Controls.SetChildIndex(this.tvAddress, 0);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ImageList imgList;
    private System.Windows.Forms.TreeView tvAddress;
  }
}
