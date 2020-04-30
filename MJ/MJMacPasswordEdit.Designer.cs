namespace ECard78
{
  partial class frmMJMacPasswordEdit
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
      this.txtMacSN = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtMacDoorID = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txtMacDoorName = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.txtPassA = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.txtPassB = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(180, 165);
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(100, 165);
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
      this.label1.Tag = "MacSN";
      this.label1.Text = "label1";
      // 
      // txtMacSN
      // 
      this.txtMacSN.Location = new System.Drawing.Point(100, 10);
      this.txtMacSN.Name = "txtMacSN";
      this.txtMacSN.ReadOnly = true;
      this.txtMacSN.Size = new System.Drawing.Size(155, 21);
      this.txtMacSN.TabIndex = 0;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(10, 44);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(41, 12);
      this.label2.TabIndex = 21;
      this.label2.Tag = "MacDoorID";
      this.label2.Text = "label2";
      // 
      // txtMacDoorID
      // 
      this.txtMacDoorID.Location = new System.Drawing.Point(100, 40);
      this.txtMacDoorID.Name = "txtMacDoorID";
      this.txtMacDoorID.ReadOnly = true;
      this.txtMacDoorID.Size = new System.Drawing.Size(155, 21);
      this.txtMacDoorID.TabIndex = 1;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(10, 74);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(41, 12);
      this.label3.TabIndex = 23;
      this.label3.Tag = "MacDoorName";
      this.label3.Text = "label3";
      // 
      // txtMacDoorName
      // 
      this.txtMacDoorName.Location = new System.Drawing.Point(100, 70);
      this.txtMacDoorName.Name = "txtMacDoorName";
      this.txtMacDoorName.ReadOnly = true;
      this.txtMacDoorName.Size = new System.Drawing.Size(155, 21);
      this.txtMacDoorName.TabIndex = 2;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(10, 104);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(41, 12);
      this.label4.TabIndex = 25;
      this.label4.Tag = "MacDoorPassword";
      this.label4.Text = "label4";
      // 
      // txtPassA
      // 
      this.txtPassA.Location = new System.Drawing.Point(100, 100);
      this.txtPassA.MaxLength = 6;
      this.txtPassA.Multiline = true;
      this.txtPassA.Name = "txtPassA";
      this.txtPassA.Size = new System.Drawing.Size(155, 21);
      this.txtPassA.TabIndex = 3;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(10, 134);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(41, 12);
      this.label5.TabIndex = 27;
      this.label5.Tag = "MacDoorPassword";
      this.label5.Text = "label5";
      // 
      // txtPassB
      // 
      this.txtPassB.Location = new System.Drawing.Point(100, 130);
      this.txtPassB.MaxLength = 6;
      this.txtPassB.Multiline = true;
      this.txtPassB.Name = "txtPassB";
      this.txtPassB.Size = new System.Drawing.Size(155, 21);
      this.txtPassB.TabIndex = 4;
      // 
      // frmMJMacPasswordEdit
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(264, 198);
      this.Controls.Add(this.txtPassB);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.txtPassA);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.txtMacDoorName);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txtMacDoorID);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txtMacSN);
      this.Controls.Add(this.label1);
      this.Name = "frmMJMacPasswordEdit";
      this.Controls.SetChildIndex(this.label1, 0);
      this.Controls.SetChildIndex(this.txtMacSN, 0);
      this.Controls.SetChildIndex(this.label2, 0);
      this.Controls.SetChildIndex(this.txtMacDoorID, 0);
      this.Controls.SetChildIndex(this.label3, 0);
      this.Controls.SetChildIndex(this.txtMacDoorName, 0);
      this.Controls.SetChildIndex(this.label4, 0);
      this.Controls.SetChildIndex(this.txtPassA, 0);
      this.Controls.SetChildIndex(this.label5, 0);
      this.Controls.SetChildIndex(this.txtPassB, 0);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtMacSN;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtMacDoorID;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtMacDoorName;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtPassA;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtPassB;
  }
}
