namespace ECard78
{
  partial class frmRSDepartAdd
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
      this.txtID = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtName = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txtDesc = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.txtParent = new System.Windows.Forms.TextBox();
      this.btnParentDepart = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(345, 135);
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(265, 135);
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
      this.label1.Tag = "DepartID";
      this.label1.Text = "label1";
      // 
      // txtID
      // 
      this.txtID.Location = new System.Drawing.Point(100, 10);
      this.txtID.MaxLength = 12;
      this.txtID.Name = "txtID";
      this.txtID.Size = new System.Drawing.Size(100, 21);
      this.txtID.TabIndex = 0;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(10, 44);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(41, 12);
      this.label2.TabIndex = 21;
      this.label2.Tag = "DepartName";
      this.label2.Text = "label2";
      // 
      // txtName
      // 
      this.txtName.Location = new System.Drawing.Point(100, 40);
      this.txtName.MaxLength = 50;
      this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(320, 21);
      this.txtName.TabIndex = 1;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(10, 74);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(41, 12);
      this.label3.TabIndex = 23;
      this.label3.Tag = "DepartMemo";
      this.label3.Text = "label3";
      // 
      // txtDesc
      // 
      this.txtDesc.Location = new System.Drawing.Point(100, 70);
      this.txtDesc.MaxLength = 200;
      this.txtDesc.Name = "txtDesc";
      this.txtDesc.Size = new System.Drawing.Size(320, 21);
      this.txtDesc.TabIndex = 2;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(10, 104);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(41, 12);
      this.label4.TabIndex = 25;
      this.label4.Text = "label4";
      // 
      // txtParent
      // 
      this.txtParent.Location = new System.Drawing.Point(100, 100);
      this.txtParent.Name = "txtParent";
      this.txtParent.ReadOnly = true;
      this.txtParent.Size = new System.Drawing.Size(320, 21);
      this.txtParent.TabIndex = 3;
      // 
      // btnParentDepart
      // 
      this.btnParentDepart.Location = new System.Drawing.Point(100, 135);
      this.btnParentDepart.Name = "btnParentDepart";
      this.btnParentDepart.Size = new System.Drawing.Size(100, 25);
      this.btnParentDepart.TabIndex = 4;
      this.btnParentDepart.Text = "button1";
      this.btnParentDepart.UseVisualStyleBackColor = true;
      this.btnParentDepart.Click += new System.EventHandler(this.btnParentDepart_Click);
      // 
      // frmRSDepartAdd
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(429, 168);
      this.Controls.Add(this.txtParent);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.btnParentDepart);
      this.Controls.Add(this.txtDesc);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txtName);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txtID);
      this.Controls.Add(this.label1);
      this.Name = "frmRSDepartAdd";
      this.Controls.SetChildIndex(this.label1, 0);
      this.Controls.SetChildIndex(this.txtID, 0);
      this.Controls.SetChildIndex(this.label2, 0);
      this.Controls.SetChildIndex(this.txtName, 0);
      this.Controls.SetChildIndex(this.label3, 0);
      this.Controls.SetChildIndex(this.txtDesc, 0);
      this.Controls.SetChildIndex(this.btnParentDepart, 0);
      this.Controls.SetChildIndex(this.label4, 0);
      this.Controls.SetChildIndex(this.txtParent, 0);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtID;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtDesc;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtParent;
    private System.Windows.Forms.Button btnParentDepart;
  }
}
