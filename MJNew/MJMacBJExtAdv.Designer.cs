namespace ECard78
{
  partial class frmMJMacBJExtAdv
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
      this.checkBox1 = new System.Windows.Forms.CheckBox();
      this.radioButton1 = new System.Windows.Forms.RadioButton();
      this.radioButton2 = new System.Windows.Forms.RadioButton();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(310, 135);
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(230, 135);
      this.btnOk.Text = "";
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // checkBox1
      // 
      this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
      this.checkBox1.Location = new System.Drawing.Point(10, 10);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new System.Drawing.Size(380, 30);
      this.checkBox1.TabIndex = 0;
      this.checkBox1.Text = "checkBox1";
      this.checkBox1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
      this.checkBox1.UseVisualStyleBackColor = true;
      // 
      // radioButton1
      // 
      this.radioButton1.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
      this.radioButton1.Location = new System.Drawing.Point(10, 45);
      this.radioButton1.Name = "radioButton1";
      this.radioButton1.Size = new System.Drawing.Size(380, 30);
      this.radioButton1.TabIndex = 1;
      this.radioButton1.TabStop = true;
      this.radioButton1.Text = "radioButton1";
      this.radioButton1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
      this.radioButton1.UseVisualStyleBackColor = true;
      // 
      // radioButton2
      // 
      this.radioButton2.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
      this.radioButton2.Location = new System.Drawing.Point(10, 80);
      this.radioButton2.Name = "radioButton2";
      this.radioButton2.Size = new System.Drawing.Size(380, 30);
      this.radioButton2.TabIndex = 2;
      this.radioButton2.TabStop = true;
      this.radioButton2.Text = "radioButton2";
      this.radioButton2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
      this.radioButton2.UseVisualStyleBackColor = true;
      // 
      // frmMJMacBJExtAdv
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(394, 168);
      this.Controls.Add(this.radioButton2);
      this.Controls.Add(this.radioButton1);
      this.Controls.Add(this.checkBox1);
      this.Name = "frmMJMacBJExtAdv";
      this.Controls.SetChildIndex(this.checkBox1, 0);
      this.Controls.SetChildIndex(this.radioButton1, 0);
      this.Controls.SetChildIndex(this.radioButton2, 0);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.CheckBox checkBox1;
    private System.Windows.Forms.RadioButton radioButton1;
    private System.Windows.Forms.RadioButton radioButton2;
  }
}
