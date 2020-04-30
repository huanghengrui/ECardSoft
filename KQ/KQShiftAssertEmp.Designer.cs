namespace ECard78
{
  partial class frmKQShiftAssertEmp
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
      this.txtEmpNo = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtEmpName = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txtDepartID = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.txtDepartName = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.txtDate = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.cbbShiftNo = new System.Windows.Forms.ComboBox();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(335, 105);
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(255, 105);
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
      this.label1.Tag = "EmpNo";
      this.label1.Text = "label1";
      // 
      // txtEmpNo
      // 
      this.txtEmpNo.Location = new System.Drawing.Point(100, 10);
      this.txtEmpNo.Name = "txtEmpNo";
      this.txtEmpNo.ReadOnly = true;
      this.txtEmpNo.Size = new System.Drawing.Size(100, 21);
      this.txtEmpNo.TabIndex = 0;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(220, 14);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(41, 12);
      this.label2.TabIndex = 21;
      this.label2.Tag = "EmpName";
      this.label2.Text = "label2";
      // 
      // txtEmpName
      // 
      this.txtEmpName.Location = new System.Drawing.Point(310, 10);
      this.txtEmpName.Name = "txtEmpName";
      this.txtEmpName.ReadOnly = true;
      this.txtEmpName.Size = new System.Drawing.Size(100, 21);
      this.txtEmpName.TabIndex = 1;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(10, 44);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(41, 12);
      this.label3.TabIndex = 23;
      this.label3.Tag = "DepartID";
      this.label3.Text = "label3";
      // 
      // txtDepartID
      // 
      this.txtDepartID.Location = new System.Drawing.Point(100, 40);
      this.txtDepartID.Name = "txtDepartID";
      this.txtDepartID.ReadOnly = true;
      this.txtDepartID.Size = new System.Drawing.Size(100, 21);
      this.txtDepartID.TabIndex = 2;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(220, 44);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(41, 12);
      this.label4.TabIndex = 25;
      this.label4.Tag = "DepartName";
      this.label4.Text = "label4";
      // 
      // txtDepartName
      // 
      this.txtDepartName.Location = new System.Drawing.Point(310, 40);
      this.txtDepartName.Name = "txtDepartName";
      this.txtDepartName.ReadOnly = true;
      this.txtDepartName.Size = new System.Drawing.Size(100, 21);
      this.txtDepartName.TabIndex = 3;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(10, 74);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(41, 12);
      this.label5.TabIndex = 27;
      this.label5.Tag = "SihftKQDate";
      this.label5.Text = "label5";
      // 
      // txtDate
      // 
      this.txtDate.Location = new System.Drawing.Point(100, 67);
      this.txtDate.Name = "txtDate";
      this.txtDate.ReadOnly = true;
      this.txtDate.Size = new System.Drawing.Size(100, 21);
      this.txtDate.TabIndex = 4;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(220, 74);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(41, 12);
      this.label6.TabIndex = 29;
      this.label6.Tag = "AssertShiftNo";
      this.label6.Text = "label6";
      // 
      // cbbShiftNo
      // 
      this.cbbShiftNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbShiftNo.FormattingEnabled = true;
      this.cbbShiftNo.Location = new System.Drawing.Point(310, 70);
      this.cbbShiftNo.Name = "cbbShiftNo";
      this.cbbShiftNo.Size = new System.Drawing.Size(100, 20);
      this.cbbShiftNo.TabIndex = 5;
      // 
      // frmKQShiftAssertEmp
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(419, 138);
      this.Controls.Add(this.txtDepartID);
      this.Controls.Add(this.txtDate);
      this.Controls.Add(this.cbbShiftNo);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txtDepartName);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.txtEmpName);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtEmpNo);
      this.Name = "frmKQShiftAssertEmp";
      this.Controls.SetChildIndex(this.txtEmpNo, 0);
      this.Controls.SetChildIndex(this.label1, 0);
      this.Controls.SetChildIndex(this.label2, 0);
      this.Controls.SetChildIndex(this.txtEmpName, 0);
      this.Controls.SetChildIndex(this.label4, 0);
      this.Controls.SetChildIndex(this.txtDepartName, 0);
      this.Controls.SetChildIndex(this.label3, 0);
      this.Controls.SetChildIndex(this.label5, 0);
      this.Controls.SetChildIndex(this.label6, 0);
      this.Controls.SetChildIndex(this.cbbShiftNo, 0);
      this.Controls.SetChildIndex(this.txtDate, 0);
      this.Controls.SetChildIndex(this.txtDepartID, 0);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtEmpNo;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtEmpName;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtDepartID;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtDepartName;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtDate;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.ComboBox cbbShiftNo;
  }
}
