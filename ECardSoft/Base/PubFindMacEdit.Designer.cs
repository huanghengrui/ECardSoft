namespace ECard78
{
  partial class frmPubFindMacEdit
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
      this.txtIP = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtNetMask = new System.Windows.Forms.TextBox();
      this.txtGateway = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txtPort = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(175, 135);
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(95, 135);
      this.btnOk.Text = "";
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(10, 14);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 12);
      this.label1.TabIndex = 19;
      this.label1.Text = "label1";
      // 
      // txtIP
      // 
      this.txtIP.Location = new System.Drawing.Point(100, 10);
      this.txtIP.Name = "txtIP";
      this.txtIP.Size = new System.Drawing.Size(150, 21);
      this.txtIP.TabIndex = 0;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(10, 44);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(41, 12);
      this.label2.TabIndex = 21;
      this.label2.Tag = "MacSubnetMask";
      this.label2.Text = "label2";
      // 
      // txtNetMask
      // 
      this.txtNetMask.Location = new System.Drawing.Point(100, 40);
      this.txtNetMask.Name = "txtNetMask";
      this.txtNetMask.Size = new System.Drawing.Size(150, 21);
      this.txtNetMask.TabIndex = 1;
      // 
      // txtGateway
      // 
      this.txtGateway.Location = new System.Drawing.Point(100, 70);
      this.txtGateway.Name = "txtGateway";
      this.txtGateway.Size = new System.Drawing.Size(150, 21);
      this.txtGateway.TabIndex = 2;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(10, 74);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(41, 12);
      this.label3.TabIndex = 23;
      this.label3.Tag = "MacGateway";
      this.label3.Text = "label3";
      // 
      // txtPort
      // 
      this.txtPort.Location = new System.Drawing.Point(100, 100);
      this.txtPort.Name = "txtPort";
      this.txtPort.Size = new System.Drawing.Size(150, 21);
      this.txtPort.TabIndex = 3;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(10, 104);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(41, 12);
      this.label4.TabIndex = 25;
      this.label4.Tag = "MacPort";
      this.label4.Text = "label4";
      // 
      // frmPubFindMacEdit
      // 
      this.AcceptButton = this.btnCancel;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(259, 168);
      this.Controls.Add(this.txtPort);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.txtGateway);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txtNetMask);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txtIP);
      this.Controls.Add(this.label1);
      this.Name = "frmPubFindMacEdit";
      this.Controls.SetChildIndex(this.label1, 0);
      this.Controls.SetChildIndex(this.txtIP, 0);
      this.Controls.SetChildIndex(this.label2, 0);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.Controls.SetChildIndex(this.txtNetMask, 0);
      this.Controls.SetChildIndex(this.label3, 0);
      this.Controls.SetChildIndex(this.txtGateway, 0);
      this.Controls.SetChildIndex(this.label4, 0);
      this.Controls.SetChildIndex(this.txtPort, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtIP;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtNetMask;
    private System.Windows.Forms.TextBox txtGateway;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtPort;
    private System.Windows.Forms.Label label4;
  }
}
