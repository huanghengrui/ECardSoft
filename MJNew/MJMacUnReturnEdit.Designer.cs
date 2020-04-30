namespace ECard78
{
  partial class frmMJMacUnReturnEdit
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMJMacUnReturnEdit));
      this.chkEnabled = new System.Windows.Forms.CheckBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.chk1 = new System.Windows.Forms.CheckBox();
      this.panel2 = new System.Windows.Forms.Panel();
      this.chk23 = new System.Windows.Forms.CheckBox();
      this.chk22 = new System.Windows.Forms.CheckBox();
      this.chk21 = new System.Windows.Forms.CheckBox();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(270, 110);
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(190, 110);
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
      // chkEnabled
      // 
      this.chkEnabled.AutoSize = true;
      this.chkEnabled.Location = new System.Drawing.Point(10, 10);
      this.chkEnabled.Name = "chkEnabled";
      this.chkEnabled.Size = new System.Drawing.Size(78, 16);
      this.chkEnabled.TabIndex = 19;
      this.chkEnabled.Text = "checkBox1";
      this.chkEnabled.UseVisualStyleBackColor = true;
      this.chkEnabled.CheckedChanged += new System.EventHandler(this.chkEnabled_CheckedChanged);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.chk1);
      this.panel1.Location = new System.Drawing.Point(10, 35);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(290, 20);
      this.panel1.TabIndex = 20;
      // 
      // chk1
      // 
      this.chk1.AutoSize = true;
      this.chk1.Location = new System.Drawing.Point(0, 0);
      this.chk1.Name = "chk1";
      this.chk1.Size = new System.Drawing.Size(78, 16);
      this.chk1.TabIndex = 0;
      this.chk1.Text = "checkBox1";
      this.chk1.UseVisualStyleBackColor = true;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.chk23);
      this.panel2.Controls.Add(this.chk22);
      this.panel2.Controls.Add(this.chk21);
      this.panel2.Location = new System.Drawing.Point(10, 35);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(335, 60);
      this.panel2.TabIndex = 21;
      // 
      // chk23
      // 
      this.chk23.AutoSize = true;
      this.chk23.Location = new System.Drawing.Point(0, 40);
      this.chk23.Name = "chk23";
      this.chk23.Size = new System.Drawing.Size(78, 16);
      this.chk23.TabIndex = 2;
      this.chk23.Text = "checkBox3";
      this.chk23.UseVisualStyleBackColor = true;
      this.chk23.Click += new System.EventHandler(this.CheckBox_Click);
      // 
      // chk22
      // 
      this.chk22.AutoSize = true;
      this.chk22.Location = new System.Drawing.Point(0, 20);
      this.chk22.Name = "chk22";
      this.chk22.Size = new System.Drawing.Size(78, 16);
      this.chk22.TabIndex = 1;
      this.chk22.Text = "checkBox2";
      this.chk22.UseVisualStyleBackColor = true;
      this.chk22.Click += new System.EventHandler(this.CheckBox_Click);
      // 
      // chk21
      // 
      this.chk21.AutoSize = true;
      this.chk21.Location = new System.Drawing.Point(0, 0);
      this.chk21.Name = "chk21";
      this.chk21.Size = new System.Drawing.Size(78, 16);
      this.chk21.TabIndex = 0;
      this.chk21.Text = "checkBox1";
      this.chk21.UseVisualStyleBackColor = true;
      this.chk21.Click += new System.EventHandler(this.CheckBox_Click);
      // 
      // frmMJMacUnReturnEdit
      // 
      this.AcceptButton = this.btnCancel;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(354, 142);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.chkEnabled);
      this.Controls.Add(this.panel1);
      this.Name = "frmMJMacUnReturnEdit";
      this.Controls.SetChildIndex(this.panel1, 0);
      this.Controls.SetChildIndex(this.chkEnabled, 0);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.Controls.SetChildIndex(this.panel2, 0);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.CheckBox chkEnabled;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.CheckBox chk1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.CheckBox chk23;
    private System.Windows.Forms.CheckBox chk22;
    private System.Windows.Forms.CheckBox chk21;
  }
}
