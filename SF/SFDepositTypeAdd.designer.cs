namespace ECard78
{
  partial class frmSFDepositTypeAdd
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSFDepositTypeAdd));
      this.Label1 = new System.Windows.Forms.Label();
      this.txtNo = new System.Windows.Forms.TextBox();
      this.Label2 = new System.Windows.Forms.Label();
      this.txtName = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(180, 95);
      this.btnCancel.TabIndex = 5;
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(100, 95);
      this.btnOk.TabIndex = 4;
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
      // Label1
      // 
      this.Label1.AutoSize = true;
      this.Label1.Location = new System.Drawing.Point(10, 14);
      this.Label1.Name = "Label1";
      this.Label1.Size = new System.Drawing.Size(41, 12);
      this.Label1.TabIndex = 19;
      this.Label1.Tag = "DepositTypeID";
      this.Label1.Text = "label1";
      // 
      // txtNo
      // 
      this.txtNo.Enabled = false;
      this.txtNo.Location = new System.Drawing.Point(100, 10);
      this.txtNo.MaxLength = 3;
      this.txtNo.Name = "txtNo";
      this.txtNo.Size = new System.Drawing.Size(155, 21);
      this.txtNo.TabIndex = 0;
      // 
      // Label2
      // 
      this.Label2.AutoSize = true;
      this.Label2.Location = new System.Drawing.Point(10, 64);
      this.Label2.Name = "Label2";
      this.Label2.Size = new System.Drawing.Size(41, 12);
      this.Label2.TabIndex = 21;
      this.Label2.Tag = "DepositTypeName";
      this.Label2.Text = "label2";
      // 
      // txtName
      // 
      this.txtName.Location = new System.Drawing.Point(100, 60);
      this.txtName.MaxLength = 50;
      this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(155, 21);
      this.txtName.TabIndex = 1;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(100, 35);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(41, 12);
      this.label3.TabIndex = 22;
      this.label3.Tag = "";
      this.label3.Text = "label1";
      // 
      // frmSFDepositTypeAdd
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(264, 128);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txtNo);
      this.Controls.Add(this.txtName);
      this.Controls.Add(this.Label1);
      this.Controls.Add(this.Label2);
      this.Name = "frmSFDepositTypeAdd";
      this.Controls.SetChildIndex(this.Label2, 0);
      this.Controls.SetChildIndex(this.Label1, 0);
      this.Controls.SetChildIndex(this.txtName, 0);
      this.Controls.SetChildIndex(this.txtNo, 0);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.Controls.SetChildIndex(this.label3, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label Label1;
    private System.Windows.Forms.TextBox txtNo;
    private System.Windows.Forms.Label Label2;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.Label label3;
  }
}
