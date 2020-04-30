namespace ECard78
{
  partial class frmSYRegisterDate
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
      this.label2 = new System.Windows.Forms.Label();
      this.txtUser = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.dtpDate = new System.Windows.Forms.DateTimePicker();
      this.chkDate = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(200, 75);
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(120, 75);
      this.btnOk.Text = "";
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(10, 14);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(41, 12);
      this.label2.TabIndex = 21;
      this.label2.Text = "label2";
      // 
      // txtUser
      // 
      this.txtUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.txtUser.Location = new System.Drawing.Point(100, 10);
      this.txtUser.Name = "txtUser";
      this.txtUser.Size = new System.Drawing.Size(175, 21);
      this.txtUser.TabIndex = 1;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(10, 44);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(41, 12);
      this.label3.TabIndex = 23;
      this.label3.Text = "label3";
      // 
      // dtpDate
      // 
      this.dtpDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.dtpDate.Enabled = false;
      this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.dtpDate.Location = new System.Drawing.Point(190, 41);
      this.dtpDate.Name = "dtpDate";
      this.dtpDate.Size = new System.Drawing.Size(85, 21);
      this.dtpDate.TabIndex = 3;
      // 
      // chkDate
      // 
      this.chkDate.AutoSize = true;
      this.chkDate.Checked = true;
      this.chkDate.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkDate.Location = new System.Drawing.Point(100, 44);
      this.chkDate.Name = "chkDate";
      this.chkDate.Size = new System.Drawing.Size(78, 16);
      this.chkDate.TabIndex = 2;
      this.chkDate.Text = "checkBox1";
      this.chkDate.UseVisualStyleBackColor = true;
      this.chkDate.CheckedChanged += new System.EventHandler(this.chkDate_CheckedChanged);
      // 
      // frmSYRegisterDate
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(284, 108);
      this.Controls.Add(this.chkDate);
      this.Controls.Add(this.dtpDate);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txtUser);
      this.Controls.Add(this.label2);
      this.Name = "frmSYRegisterDate";
      this.Controls.SetChildIndex(this.label2, 0);
      this.Controls.SetChildIndex(this.txtUser, 0);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.Controls.SetChildIndex(this.label3, 0);
      this.Controls.SetChildIndex(this.dtpDate, 0);
      this.Controls.SetChildIndex(this.chkDate, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtUser;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.DateTimePicker dtpDate;
    private System.Windows.Forms.CheckBox chkDate;
  }
}
