namespace ECard78
{
  partial class frmSYDeviceAdd
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
      this.txtNo = new System.Windows.Forms.TextBox();
      this.Label2 = new System.Windows.Forms.Label();
      this.txtName = new System.Windows.Forms.TextBox();
      this.Label3 = new System.Windows.Forms.Label();
      this.txtPass = new System.Windows.Forms.TextBox();
      this.Label4 = new System.Windows.Forms.Label();
      this.Label5 = new System.Windows.Forms.Label();
      this.Label6 = new System.Windows.Forms.Label();
      this.txtPassA = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(310, 135);
      this.btnCancel.TabIndex = 5;
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(230, 135);
      this.btnOk.TabIndex = 4;
      this.btnOk.Text = "";
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // Label1
      // 
      this.Label1.AutoSize = true;
      this.Label1.Location = new System.Drawing.Point(10, 14);
      this.Label1.Name = "Label1";
      this.Label1.Size = new System.Drawing.Size(41, 12);
      this.Label1.TabIndex = 19;
      this.Label1.Tag = "MacOpterID";
      this.Label1.Text = "label1";
      // 
      // txtNo
      // 
      this.txtNo.Location = new System.Drawing.Point(100, 10);
      this.txtNo.MaxLength = 2;
      this.txtNo.Name = "txtNo";
      this.txtNo.Size = new System.Drawing.Size(150, 21);
      this.txtNo.TabIndex = 0;
      // 
      // Label2
      // 
      this.Label2.AutoSize = true;
      this.Label2.Location = new System.Drawing.Point(10, 44);
      this.Label2.Name = "Label2";
      this.Label2.Size = new System.Drawing.Size(41, 12);
      this.Label2.TabIndex = 21;
      this.Label2.Tag = "MacOpterName";
      this.Label2.Text = "label2";
      // 
      // txtName
      // 
      this.txtName.Location = new System.Drawing.Point(100, 40);
      this.txtName.MaxLength = 50;
      this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(150, 21);
      this.txtName.TabIndex = 1;
      // 
      // Label3
      // 
      this.Label3.AutoSize = true;
      this.Label3.Location = new System.Drawing.Point(10, 74);
      this.Label3.Name = "Label3";
      this.Label3.Size = new System.Drawing.Size(41, 12);
      this.Label3.TabIndex = 23;
      this.Label3.Tag = "MacOpterPWD";
      this.Label3.Text = "label3";
      // 
      // txtPass
      // 
      this.txtPass.Location = new System.Drawing.Point(100, 70);
      this.txtPass.MaxLength = 4;
      this.txtPass.Name = "txtPass";
      this.txtPass.PasswordChar = '*';
      this.txtPass.Size = new System.Drawing.Size(150, 21);
      this.txtPass.TabIndex = 2;
      // 
      // Label4
      // 
      this.Label4.AutoSize = true;
      this.Label4.Location = new System.Drawing.Point(255, 14);
      this.Label4.Name = "Label4";
      this.Label4.Size = new System.Drawing.Size(41, 12);
      this.Label4.TabIndex = 25;
      this.Label4.Text = "label4";
      // 
      // Label5
      // 
      this.Label5.AutoSize = true;
      this.Label5.Location = new System.Drawing.Point(255, 74);
      this.Label5.Name = "Label5";
      this.Label5.Size = new System.Drawing.Size(41, 12);
      this.Label5.TabIndex = 26;
      this.Label5.Text = "label5";
      // 
      // Label6
      // 
      this.Label6.AutoSize = true;
      this.Label6.Location = new System.Drawing.Point(10, 104);
      this.Label6.Name = "Label6";
      this.Label6.Size = new System.Drawing.Size(41, 12);
      this.Label6.TabIndex = 27;
      this.Label6.Text = "label3";
      // 
      // txtPassA
      // 
      this.txtPassA.Location = new System.Drawing.Point(100, 100);
      this.txtPassA.MaxLength = 4;
      this.txtPassA.Name = "txtPassA";
      this.txtPassA.PasswordChar = '*';
      this.txtPassA.Size = new System.Drawing.Size(150, 21);
      this.txtPassA.TabIndex = 3;
      // 
      // frmSYDeviceAdd
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(394, 168);
      this.Controls.Add(this.Label6);
      this.Controls.Add(this.txtPassA);
      this.Controls.Add(this.Label5);
      this.Controls.Add(this.Label3);
      this.Controls.Add(this.txtNo);
      this.Controls.Add(this.txtPass);
      this.Controls.Add(this.Label4);
      this.Controls.Add(this.txtName);
      this.Controls.Add(this.Label1);
      this.Controls.Add(this.Label2);
      this.Name = "frmSYDeviceAdd";
      this.Controls.SetChildIndex(this.Label2, 0);
      this.Controls.SetChildIndex(this.Label1, 0);
      this.Controls.SetChildIndex(this.txtName, 0);
      this.Controls.SetChildIndex(this.Label4, 0);
      this.Controls.SetChildIndex(this.txtPass, 0);
      this.Controls.SetChildIndex(this.txtNo, 0);
      this.Controls.SetChildIndex(this.Label3, 0);
      this.Controls.SetChildIndex(this.Label5, 0);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.Controls.SetChildIndex(this.txtPassA, 0);
      this.Controls.SetChildIndex(this.Label6, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label Label1;
    private System.Windows.Forms.TextBox txtNo;
    private System.Windows.Forms.Label Label2;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.Label Label3;
    private System.Windows.Forms.TextBox txtPass;
    private System.Windows.Forms.Label Label4;
    private System.Windows.Forms.Label Label5;
    private System.Windows.Forms.Label Label6;
    private System.Windows.Forms.TextBox txtPassA;
  }
}
