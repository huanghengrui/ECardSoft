namespace ECard78
{
  partial class frmDBPassword
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
      this.Label1 = new System.Windows.Forms.Label();
      this.txtOld = new System.Windows.Forms.TextBox();
      this.txtNew = new System.Windows.Forms.TextBox();
      this.Label2 = new System.Windows.Forms.Label();
      this.txtVerify = new System.Windows.Forms.TextBox();
      this.Label3 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(185, 100);
      this.btnCancel.TabIndex = 4;
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(100, 100);
      this.btnOk.TabIndex = 3;
      this.btnOk.Text = "";
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // Label1
      // 
      this.Label1.AutoSize = true;
      this.Label1.Location = new System.Drawing.Point(10, 14);
      this.Label1.Name = "Label1";
      this.Label1.Size = new System.Drawing.Size(41, 12);
      this.Label1.TabIndex = 0;
      this.Label1.Text = "label1";
      // 
      // txtOld
      // 
      this.txtOld.Location = new System.Drawing.Point(100, 10);
      this.txtOld.MaxLength = 20;
      this.txtOld.Name = "txtOld";
      this.txtOld.PasswordChar = '*';
      this.txtOld.Size = new System.Drawing.Size(160, 21);
      this.txtOld.TabIndex = 0;
      // 
      // txtNew
      // 
      this.txtNew.Location = new System.Drawing.Point(100, 40);
      this.txtNew.MaxLength = 20;
      this.txtNew.Name = "txtNew";
      this.txtNew.PasswordChar = '*';
      this.txtNew.Size = new System.Drawing.Size(160, 21);
      this.txtNew.TabIndex = 1;
      // 
      // Label2
      // 
      this.Label2.AutoSize = true;
      this.Label2.Location = new System.Drawing.Point(10, 44);
      this.Label2.Name = "Label2";
      this.Label2.Size = new System.Drawing.Size(41, 12);
      this.Label2.TabIndex = 2;
      this.Label2.Text = "label2";
      // 
      // txtVerify
      // 
      this.txtVerify.Location = new System.Drawing.Point(100, 70);
      this.txtVerify.MaxLength = 20;
      this.txtVerify.Name = "txtVerify";
      this.txtVerify.PasswordChar = '*';
      this.txtVerify.Size = new System.Drawing.Size(160, 21);
      this.txtVerify.TabIndex = 2;
      // 
      // Label3
      // 
      this.Label3.AutoSize = true;
      this.Label3.Location = new System.Drawing.Point(10, 74);
      this.Label3.Name = "Label3";
      this.Label3.Size = new System.Drawing.Size(41, 12);
      this.Label3.TabIndex = 4;
      this.Label3.Text = "label3";
      // 
      // frmDBPassword
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(269, 133);
      this.Controls.Add(this.txtVerify);
      this.Controls.Add(this.Label3);
      this.Controls.Add(this.txtNew);
      this.Controls.Add(this.Label2);
      this.Controls.Add(this.txtOld);
      this.Controls.Add(this.Label1);
      this.Name = "frmDBPassword";
      this.Controls.SetChildIndex(this.Label1, 0);
      this.Controls.SetChildIndex(this.txtOld, 0);
      this.Controls.SetChildIndex(this.Label2, 0);
      this.Controls.SetChildIndex(this.txtNew, 0);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.Label3, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.Controls.SetChildIndex(this.txtVerify, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label Label1;
    private System.Windows.Forms.TextBox txtOld;
    private System.Windows.Forms.TextBox txtNew;
    private System.Windows.Forms.Label Label2;
    private System.Windows.Forms.TextBox txtVerify;
    private System.Windows.Forms.Label Label3;
  }
}
