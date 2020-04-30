namespace ECard78
{
  partial class frmDBBack
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
      this.gbxAccount = new System.Windows.Forms.GroupBox();
      this.txtDBName = new System.Windows.Forms.TextBox();
      this.Label2 = new System.Windows.Forms.Label();
      this.txtAccName = new System.Windows.Forms.TextBox();
      this.Label1 = new System.Windows.Forms.Label();
      this.btnDBPath = new System.Windows.Forms.Button();
      this.txtPath = new System.Windows.Forms.TextBox();
      this.Label4 = new System.Windows.Forms.Label();
      this.txtBak = new System.Windows.Forms.TextBox();
      this.Label3 = new System.Windows.Forms.Label();
      this.gbxAccount.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(355, 210);
      this.btnCancel.TabIndex = 19;
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(275, 210);
      this.btnOk.TabIndex = 18;
      this.btnOk.Text = "";
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // gbxAccount
      // 
      this.gbxAccount.Controls.Add(this.txtDBName);
      this.gbxAccount.Controls.Add(this.Label2);
      this.gbxAccount.Controls.Add(this.txtAccName);
      this.gbxAccount.Controls.Add(this.Label1);
      this.gbxAccount.Location = new System.Drawing.Point(10, 10);
      this.gbxAccount.Name = "gbxAccount";
      this.gbxAccount.Size = new System.Drawing.Size(420, 80);
      this.gbxAccount.TabIndex = 1;
      this.gbxAccount.TabStop = false;
      this.gbxAccount.Text = "groupBox1";
      // 
      // txtDBName
      // 
      this.txtDBName.Location = new System.Drawing.Point(110, 50);
      this.txtDBName.MaxLength = 25;
      this.txtDBName.Name = "txtDBName";
      this.txtDBName.ReadOnly = true;
      this.txtDBName.Size = new System.Drawing.Size(300, 21);
      this.txtDBName.TabIndex = 5;
      // 
      // Label2
      // 
      this.Label2.AutoSize = true;
      this.Label2.Location = new System.Drawing.Point(10, 54);
      this.Label2.Name = "Label2";
      this.Label2.Size = new System.Drawing.Size(41, 12);
      this.Label2.TabIndex = 4;
      this.Label2.Tag = "DBName";
      this.Label2.Text = "label2";
      // 
      // txtAccName
      // 
      this.txtAccName.Location = new System.Drawing.Point(110, 20);
      this.txtAccName.MaxLength = 25;
      this.txtAccName.Name = "txtAccName";
      this.txtAccName.ReadOnly = true;
      this.txtAccName.Size = new System.Drawing.Size(300, 21);
      this.txtAccName.TabIndex = 3;
      // 
      // Label1
      // 
      this.Label1.AutoSize = true;
      this.Label1.Location = new System.Drawing.Point(10, 24);
      this.Label1.Name = "Label1";
      this.Label1.Size = new System.Drawing.Size(41, 12);
      this.Label1.TabIndex = 2;
      this.Label1.Tag = "AccName";
      this.Label1.Text = "label1";
      // 
      // btnDBPath
      // 
      this.btnDBPath.Location = new System.Drawing.Point(410, 175);
      this.btnDBPath.Name = "btnDBPath";
      this.btnDBPath.Size = new System.Drawing.Size(20, 20);
      this.btnDBPath.TabIndex = 17;
      this.btnDBPath.Text = ">";
      this.btnDBPath.UseVisualStyleBackColor = true;
      this.btnDBPath.Click += new System.EventHandler(this.btnDBPath_Click);
      // 
      // txtPath
      // 
      this.txtPath.Location = new System.Drawing.Point(10, 175);
      this.txtPath.Name = "txtPath";
      this.txtPath.ReadOnly = true;
      this.txtPath.Size = new System.Drawing.Size(395, 21);
      this.txtPath.TabIndex = 16;
      // 
      // Label4
      // 
      this.Label4.AutoSize = true;
      this.Label4.Location = new System.Drawing.Point(10, 155);
      this.Label4.Name = "Label4";
      this.Label4.Size = new System.Drawing.Size(41, 12);
      this.Label4.TabIndex = 15;
      this.Label4.Text = "label1";
      // 
      // txtBak
      // 
      this.txtBak.Location = new System.Drawing.Point(10, 120);
      this.txtBak.MaxLength = 50;
      this.txtBak.Name = "txtBak";
      this.txtBak.Size = new System.Drawing.Size(395, 21);
      this.txtBak.TabIndex = 14;
      // 
      // Label3
      // 
      this.Label3.AutoSize = true;
      this.Label3.Location = new System.Drawing.Point(10, 100);
      this.Label3.Name = "Label3";
      this.Label3.Size = new System.Drawing.Size(41, 12);
      this.Label3.TabIndex = 13;
      this.Label3.Text = "label1";
      // 
      // frmDBBack
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(439, 243);
      this.Controls.Add(this.btnDBPath);
      this.Controls.Add(this.txtPath);
      this.Controls.Add(this.Label4);
      this.Controls.Add(this.txtBak);
      this.Controls.Add(this.Label3);
      this.Controls.Add(this.gbxAccount);
      this.Name = "frmDBBack";
      this.Controls.SetChildIndex(this.gbxAccount, 0);
      this.Controls.SetChildIndex(this.Label3, 0);
      this.Controls.SetChildIndex(this.txtBak, 0);
      this.Controls.SetChildIndex(this.Label4, 0);
      this.Controls.SetChildIndex(this.txtPath, 0);
      this.Controls.SetChildIndex(this.btnDBPath, 0);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.gbxAccount.ResumeLayout(false);
      this.gbxAccount.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.GroupBox gbxAccount;
    private System.Windows.Forms.TextBox txtDBName;
    private System.Windows.Forms.Label Label2;
    private System.Windows.Forms.TextBox txtAccName;
    private System.Windows.Forms.Label Label1;
    private System.Windows.Forms.Button btnDBPath;
    private System.Windows.Forms.TextBox txtPath;
    private System.Windows.Forms.Label Label4;
    private System.Windows.Forms.TextBox txtBak;
    private System.Windows.Forms.Label Label3;
  }
}
