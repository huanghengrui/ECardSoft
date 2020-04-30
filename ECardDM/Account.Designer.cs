namespace ECard78
{
  partial class frmAccount
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
      this.label1 = new System.Windows.Forms.Label();
      this.cbbAccount = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtPass = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(180, 77);
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(100, 77);
      this.btnOk.Text = "";
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(10, 14);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 12);
      this.label1.TabIndex = 0;
      this.label1.Text = "label1";
      // 
      // cbbAccount
      // 
      this.cbbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbAccount.FormattingEnabled = true;
      this.cbbAccount.Location = new System.Drawing.Point(55, 10);
      this.cbbAccount.Name = "cbbAccount";
      this.cbbAccount.Size = new System.Drawing.Size(200, 20);
      this.cbbAccount.TabIndex = 0;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(10, 44);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(41, 12);
      this.label2.TabIndex = 19;
      this.label2.Text = "label2";
      // 
      // txtPass
      // 
      this.txtPass.Location = new System.Drawing.Point(55, 40);
      this.txtPass.Name = "txtPass";
      this.txtPass.PasswordChar = '*';
      this.txtPass.Size = new System.Drawing.Size(200, 21);
      this.txtPass.TabIndex = 1;
      // 
      // frmAccount
      // 
      this.AcceptButton = this.btnOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(264, 113);
      this.Controls.Add(this.txtPass);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.cbbAccount);
      this.Controls.Add(this.label1);
      this.Name = "frmAccount";
      this.ShowInTaskbar = true;
      this.Text = "Form1";
      this.Controls.SetChildIndex(this.label1, 0);
      this.Controls.SetChildIndex(this.cbbAccount, 0);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.label2, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.Controls.SetChildIndex(this.txtPass, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cbbAccount;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtPass;
  }
}

