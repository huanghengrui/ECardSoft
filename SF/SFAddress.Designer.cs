namespace ECard78
{
  partial class frmSFAddress
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
      this.imgList.Images.SetKeyName(0, "ѡ��16.bmp");
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
