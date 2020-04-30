namespace ECard78
{
  partial class frmAbout
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
      this.lblOem = new System.Windows.Forms.Label();
      this.txtInfo = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Enabled = false;
      this.btnCancel.Location = new System.Drawing.Point(360, 235);
      this.btnCancel.Text = "";
      this.btnCancel.Visible = false;
      // 
      // btnOk
      // 
      this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnOk.Location = new System.Drawing.Point(360, 235);
      this.btnOk.Text = "";
      // 
      // ilTreeState
      // 
      this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
      this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
      this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
      this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
      // 
      // lblOem
      // 
      this.lblOem.Location = new System.Drawing.Point(10, 150);
      this.lblOem.Name = "lblOem";
      this.lblOem.Size = new System.Drawing.Size(100, 65);
      this.lblOem.TabIndex = 22;
      this.lblOem.Text = "label3";
      // 
      // txtInfo
      // 
      this.txtInfo.BackColor = System.Drawing.Color.White;
      this.txtInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.txtInfo.ForeColor = System.Drawing.Color.Blue;
      this.txtInfo.Location = new System.Drawing.Point(120, 130);
      this.txtInfo.Multiline = true;
      this.txtInfo.Name = "txtInfo";
      this.txtInfo.ReadOnly = true;
      this.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.txtInfo.Size = new System.Drawing.Size(315, 85);
      this.txtInfo.TabIndex = 23;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(10, 235);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 12);
      this.label1.TabIndex = 24;
      this.label1.Text = "label1";
      // 
      // frmAbout
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.BackColor = System.Drawing.Color.White;
      this.BackgroundImage = global::ECard78.Properties.Resources.about;
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.CancelButton = this.btnOk;
      this.ClientSize = new System.Drawing.Size(444, 268);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtInfo);
      this.Controls.Add(this.lblOem);
      this.KeyPreview = true;
      this.Name = "frmAbout";
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAbout_KeyDown);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.Controls.SetChildIndex(this.lblOem, 0);
      this.Controls.SetChildIndex(this.txtInfo, 0);
      this.Controls.SetChildIndex(this.label1, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblOem;
    private System.Windows.Forms.TextBox txtInfo;
    private System.Windows.Forms.Label label1;


  }
}
