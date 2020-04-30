namespace ECard78
{
  partial class frmKQTypeSetOtAdd
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
      this.txtNo = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtName = new System.Windows.Forms.TextBox();
      this.chkDefault = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(175, 95);
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(95, 95);
      this.btnOk.Text = "";
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.ForeColor = System.Drawing.Color.Red;
      this.label1.Location = new System.Drawing.Point(10, 14);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 12);
      this.label1.TabIndex = 19;
      this.label1.Tag = "OtTypeNo";
      this.label1.Text = "label1";
      // 
      // txtNo
      // 
      this.txtNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
      this.txtNo.Location = new System.Drawing.Point(100, 10);
      this.txtNo.MaxLength = 20;
      this.txtNo.Name = "txtNo";
      this.txtNo.Size = new System.Drawing.Size(150, 21);
      this.txtNo.TabIndex = 0;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.ForeColor = System.Drawing.Color.Red;
      this.label2.Location = new System.Drawing.Point(10, 44);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(41, 12);
      this.label2.TabIndex = 21;
      this.label2.Tag = "OtTypeName";
      this.label2.Text = "label2";
      // 
      // txtName
      // 
      this.txtName.Location = new System.Drawing.Point(100, 40);
      this.txtName.MaxLength = 50;
      this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(150, 21);
      this.txtName.TabIndex = 1;
      // 
      // chkDefault
      // 
      this.chkDefault.AutoSize = true;
      this.chkDefault.Location = new System.Drawing.Point(10, 70);
      this.chkDefault.Name = "chkDefault";
      this.chkDefault.Size = new System.Drawing.Size(78, 16);
      this.chkDefault.TabIndex = 2;
      this.chkDefault.Tag = "OtIsDefault";
      this.chkDefault.Text = "checkBox1";
      this.chkDefault.UseVisualStyleBackColor = true;
      // 
      // frmKQTypeSetOtAdd
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(259, 128);
      this.Controls.Add(this.chkDefault);
      this.Controls.Add(this.txtName);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtNo);
      this.Name = "frmKQTypeSetOtAdd";
      this.Controls.SetChildIndex(this.txtNo, 0);
      this.Controls.SetChildIndex(this.label1, 0);
      this.Controls.SetChildIndex(this.label2, 0);
      this.Controls.SetChildIndex(this.txtName, 0);
      this.Controls.SetChildIndex(this.chkDefault, 0);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtNo;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.CheckBox chkDefault;
  }
}
