namespace ECard78
{
  partial class frmBaseMDIChildReportTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseMDIChildReportTree));
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter = new System.Windows.Forms.Splitter();
            this.tvEmp = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dispView)).BeginInit();
            this.pnlDisp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dispView
            // 
            this.dispView.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("dispView.OcxState")));
            this.dispView.Size = new System.Drawing.Size(370, 270);
            // 
            // pnlDisp
            // 
            this.pnlDisp.Location = new System.Drawing.Point(182, 25);
            this.pnlDisp.MinimumSize = new System.Drawing.Size(100, 0);
            this.pnlDisp.Size = new System.Drawing.Size(370, 270);
            // 
            // ilTreeState
            // 
            this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
            this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
            this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
            this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Silver;
            this.imgList.Images.SetKeyName(0, "REPORTL_p2.bmp");
            this.imgList.Images.SetKeyName(1, "USER_P2.BMP");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitter);
            this.panel1.Controls.Add(this.tvEmp);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.MaximumSize = new System.Drawing.Size(1000, 0);
            this.panel1.MinimumSize = new System.Drawing.Size(10, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(182, 270);
            this.panel1.TabIndex = 9;
            // 
            // splitter
            // 
            this.splitter.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter.Location = new System.Drawing.Point(179, 0);
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(3, 270);
            this.splitter.TabIndex = 10;
            this.splitter.TabStop = false;
            this.splitter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.splitter_MouseDown);
            this.splitter.MouseMove += new System.Windows.Forms.MouseEventHandler(this.splitter_MouseMove);
            this.splitter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.splitter_MouseUp);
            // 
            // tvEmp
            // 
            this.tvEmp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvEmp.FullRowSelect = true;
            this.tvEmp.HideSelection = false;
            this.tvEmp.ImageIndex = 0;
            this.tvEmp.ImageList = this.imgList;
            this.tvEmp.ItemHeight = 20;
            this.tvEmp.Location = new System.Drawing.Point(0, 0);
            this.tvEmp.Name = "tvEmp";
            this.tvEmp.SelectedImageIndex = 0;
            this.tvEmp.Size = new System.Drawing.Size(182, 270);
            this.tvEmp.TabIndex = 9;
            this.tvEmp.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvEmp_AfterSelect);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(182, 0);
            this.panel2.TabIndex = 0;
            // 
            // frmBaseMDIChildReportTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(552, 326);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmBaseMDIChildReportTree";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pnlDisp, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dispView)).EndInit();
            this.pnlDisp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ImageList imgList;
    protected System.Windows.Forms.TreeView tvEmp;
    protected System.Windows.Forms.Panel panel1;
    protected System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter;
    }
}
