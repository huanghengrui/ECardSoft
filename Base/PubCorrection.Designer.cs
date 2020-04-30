namespace ECard78
{
  partial class frmPubCorrection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPubCorrection));
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.txtMoney = new System.Windows.Forms.TextBox();
            this.txtMoneyBT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(310, 140);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(230, 140);
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
            // txtMoney
            // 
            this.txtMoney.Location = new System.Drawing.Point(175, 41);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.Size = new System.Drawing.Size(120, 21);
            this.txtMoney.TabIndex = 17;
            // 
            // txtMoneyBT
            // 
            this.txtMoneyBT.Location = new System.Drawing.Point(175, 86);
            this.txtMoneyBT.Name = "txtMoneyBT";
            this.txtMoneyBT.Size = new System.Drawing.Size(120, 21);
            this.txtMoneyBT.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 19;
            this.label1.Tag = "CZCountSum";
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 20;
            this.label2.Tag = "BTSum";
            this.label2.Text = "label2";
            // 
            // frmPubCorrection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(394, 173);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMoneyBT);
            this.Controls.Add(this.txtMoney);
            this.Name = "frmPubCorrection";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.txtMoney, 0);
            this.Controls.SetChildIndex(this.txtMoneyBT, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.ImageList ImageList;
        private System.Windows.Forms.TextBox txtMoney;
        private System.Windows.Forms.TextBox txtMoneyBT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
