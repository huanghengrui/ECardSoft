namespace ECard78
{
  partial class frmDBUpdate
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
      this.btnDBName = new System.Windows.Forms.Button();
      this.txtBak = new System.Windows.Forms.TextBox();
      this.Label3 = new System.Windows.Forms.Label();
      this.ofd = new System.Windows.Forms.OpenFileDialog();
      this.gbxAccount.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(355, 155);
      this.btnCancel.TabIndex = 26;
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(275, 155);
      this.btnOk.TabIndex = 25;
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
      this.gbxAccount.TabIndex = 3;
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
      // btnDBName
      // 
      this.btnDBName.Location = new System.Drawing.Point(410, 120);
      this.btnDBName.Name = "btnDBName";
      this.btnDBName.Size = new System.Drawing.Size(20, 20);
      this.btnDBName.TabIndex = 24;
      this.btnDBName.Text = ">";
      this.btnDBName.UseVisualStyleBackColor = true;
      this.btnDBName.Click += new System.EventHandler(this.btnDBName_Click);
      // 
      // txtBak
      // 
      this.txtBak.Location = new System.Drawing.Point(10, 120);
      this.txtBak.Name = "txtBak";
      this.txtBak.ReadOnly = true;
      this.txtBak.Size = new System.Drawing.Size(395, 21);
      this.txtBak.TabIndex = 23;
      // 
      // Label3
      // 
      this.Label3.AutoSize = true;
      this.Label3.Location = new System.Drawing.Point(10, 100);
      this.Label3.Name = "Label3";
      this.Label3.Size = new System.Drawing.Size(41, 12);
      this.Label3.TabIndex = 22;
      this.Label3.Text = "label1";
      // 
      // frmDBUpdate
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(439, 188);
      this.Controls.Add(this.btnDBName);
      this.Controls.Add(this.txtBak);
      this.Controls.Add(this.Label3);
      this.Controls.Add(this.gbxAccount);
      this.Name = "frmDBUpdate";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDBUpdate_FormClosed);
      this.Controls.SetChildIndex(this.gbxAccount, 0);
      this.Controls.SetChildIndex(this.Label3, 0);
      this.Controls.SetChildIndex(this.txtBak, 0);
      this.Controls.SetChildIndex(this.btnDBName, 0);
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
    private System.Windows.Forms.Button btnDBName;
    private System.Windows.Forms.TextBox txtBak;
    private System.Windows.Forms.Label Label3;
    private System.Windows.Forms.OpenFileDialog ofd;
  }
}
