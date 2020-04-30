namespace ECard78
{
  partial class frmKQShiftAssertDep
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
      this.txtDepartID = new System.Windows.Forms.TextBox();
      this.txtDate = new System.Windows.Forms.TextBox();
      this.cbbShiftNo = new System.Windows.Forms.ComboBox();
      this.label6 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.txtDepartName = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(335, 75);
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(255, 75);
      this.btnOk.Text = "";
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // txtDepartID
      // 
      this.txtDepartID.Location = new System.Drawing.Point(100, 10);
      this.txtDepartID.Name = "txtDepartID";
      this.txtDepartID.ReadOnly = true;
      this.txtDepartID.Size = new System.Drawing.Size(100, 21);
      this.txtDepartID.TabIndex = 0;
      // 
      // txtDate
      // 
      this.txtDate.Location = new System.Drawing.Point(100, 37);
      this.txtDate.Name = "txtDate";
      this.txtDate.ReadOnly = true;
      this.txtDate.Size = new System.Drawing.Size(100, 21);
      this.txtDate.TabIndex = 2;
      // 
      // cbbShiftNo
      // 
      this.cbbShiftNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbShiftNo.FormattingEnabled = true;
      this.cbbShiftNo.Location = new System.Drawing.Point(310, 40);
      this.cbbShiftNo.Name = "cbbShiftNo";
      this.cbbShiftNo.Size = new System.Drawing.Size(100, 20);
      this.cbbShiftNo.TabIndex = 3;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(220, 44);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(41, 12);
      this.label6.TabIndex = 37;
      this.label6.Tag = "AssertShiftNo";
      this.label6.Text = "label6";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(10, 44);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(41, 12);
      this.label5.TabIndex = 36;
      this.label5.Tag = "SihftKQDate";
      this.label5.Text = "label5";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(10, 14);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(41, 12);
      this.label3.TabIndex = 34;
      this.label3.Tag = "DepartID";
      this.label3.Text = "label3";
      // 
      // txtDepartName
      // 
      this.txtDepartName.Location = new System.Drawing.Point(310, 10);
      this.txtDepartName.Name = "txtDepartName";
      this.txtDepartName.ReadOnly = true;
      this.txtDepartName.Size = new System.Drawing.Size(100, 21);
      this.txtDepartName.TabIndex = 1;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(220, 14);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(41, 12);
      this.label4.TabIndex = 35;
      this.label4.Tag = "DepartName";
      this.label4.Text = "label4";
      // 
      // frmKQShiftAssertDep
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(419, 108);
      this.Controls.Add(this.txtDepartID);
      this.Controls.Add(this.txtDate);
      this.Controls.Add(this.cbbShiftNo);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txtDepartName);
      this.Controls.Add(this.label4);
      this.Name = "frmKQShiftAssertDep";
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.Controls.SetChildIndex(this.label4, 0);
      this.Controls.SetChildIndex(this.txtDepartName, 0);
      this.Controls.SetChildIndex(this.label3, 0);
      this.Controls.SetChildIndex(this.label5, 0);
      this.Controls.SetChildIndex(this.label6, 0);
      this.Controls.SetChildIndex(this.cbbShiftNo, 0);
      this.Controls.SetChildIndex(this.txtDate, 0);
      this.Controls.SetChildIndex(this.txtDepartID, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtDepartID;
    private System.Windows.Forms.TextBox txtDate;
    private System.Windows.Forms.ComboBox cbbShiftNo;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtDepartName;
    private System.Windows.Forms.Label label4;
  }
}
