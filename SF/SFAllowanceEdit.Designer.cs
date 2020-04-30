namespace ECard78
{
  partial class frmSFAllowanceEdit
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
      this.txtCardSectorNo = new System.Windows.Forms.TextBox();
      this.label12 = new System.Windows.Forms.Label();
      this.txtDepartName = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.txtEmpNo = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.txtEmpName = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtWay = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txtUp = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.txtAmount = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.txtSum = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(375, 135);
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(295, 135);
      this.btnOk.Text = "";
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // txtCardSectorNo
      // 
      this.txtCardSectorNo.Location = new System.Drawing.Point(330, 40);
      this.txtCardSectorNo.MaxLength = 10;
      this.txtCardSectorNo.Name = "txtCardSectorNo";
      this.txtCardSectorNo.ReadOnly = true;
      this.txtCardSectorNo.Size = new System.Drawing.Size(120, 21);
      this.txtCardSectorNo.TabIndex = 3;
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Location = new System.Drawing.Point(240, 44);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(47, 12);
      this.label12.TabIndex = 83;
      this.label12.Tag = "CardSectorNo";
      this.label12.Text = "label12";
      // 
      // txtDepartName
      // 
      this.txtDepartName.Location = new System.Drawing.Point(100, 40);
      this.txtDepartName.Name = "txtDepartName";
      this.txtDepartName.ReadOnly = true;
      this.txtDepartName.Size = new System.Drawing.Size(120, 21);
      this.txtDepartName.TabIndex = 2;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(10, 44);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(41, 12);
      this.label4.TabIndex = 82;
      this.label4.Tag = "Depart";
      this.label4.Text = "label4";
      // 
      // txtEmpNo
      // 
      this.txtEmpNo.Location = new System.Drawing.Point(100, 10);
      this.txtEmpNo.MaxLength = 20;
      this.txtEmpNo.Name = "txtEmpNo";
      this.txtEmpNo.ReadOnly = true;
      this.txtEmpNo.Size = new System.Drawing.Size(120, 21);
      this.txtEmpNo.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(10, 14);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 12);
      this.label1.TabIndex = 80;
      this.label1.Tag = "EmpNo";
      this.label1.Text = "label1";
      // 
      // txtEmpName
      // 
      this.txtEmpName.Location = new System.Drawing.Point(330, 10);
      this.txtEmpName.MaxLength = 50;
      this.txtEmpName.Name = "txtEmpName";
      this.txtEmpName.ReadOnly = true;
      this.txtEmpName.Size = new System.Drawing.Size(120, 21);
      this.txtEmpName.TabIndex = 1;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(240, 14);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(41, 12);
      this.label2.TabIndex = 81;
      this.label2.Tag = "EmpName";
      this.label2.Text = "label2";
      // 
      // txtWay
      // 
      this.txtWay.Location = new System.Drawing.Point(100, 70);
      this.txtWay.Name = "txtWay";
      this.txtWay.ReadOnly = true;
      this.txtWay.Size = new System.Drawing.Size(120, 21);
      this.txtWay.TabIndex = 4;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(10, 74);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(41, 12);
      this.label3.TabIndex = 85;
      this.label3.Tag = "AllowanceWayName";
      this.label3.Text = "label3";
      // 
      // txtUp
      // 
      this.txtUp.Location = new System.Drawing.Point(330, 70);
      this.txtUp.Name = "txtUp";
      this.txtUp.ReadOnly = true;
      this.txtUp.Size = new System.Drawing.Size(120, 21);
      this.txtUp.TabIndex = 5;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(240, 74);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(41, 12);
      this.label5.TabIndex = 87;
      this.label5.Tag = "AllowanceAmountUp";
      this.label5.Text = "label5";
      // 
      // txtAmount
      // 
      this.txtAmount.Location = new System.Drawing.Point(100, 100);
      this.txtAmount.Name = "txtAmount";
      this.txtAmount.Size = new System.Drawing.Size(120, 21);
      this.txtAmount.TabIndex = 6;
      this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(10, 104);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(41, 12);
      this.label6.TabIndex = 89;
      this.label6.Tag = "AllowanceAmount";
      this.label6.Text = "label6";
      // 
      // txtSum
      // 
      this.txtSum.Location = new System.Drawing.Point(330, 100);
      this.txtSum.Name = "txtSum";
      this.txtSum.ReadOnly = true;
      this.txtSum.Size = new System.Drawing.Size(120, 21);
      this.txtSum.TabIndex = 7;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(240, 104);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(41, 12);
      this.label7.TabIndex = 91;
      this.label7.Tag = "AllowanceAmountSum";
      this.label7.Text = "label7";
      // 
      // frmSFAllowanceEdit
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(459, 168);
      this.Controls.Add(this.txtSum);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.txtAmount);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.txtUp);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.txtWay);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txtCardSectorNo);
      this.Controls.Add(this.label12);
      this.Controls.Add(this.txtDepartName);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.txtEmpNo);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtEmpName);
      this.Controls.Add(this.label2);
      this.Name = "frmSFAllowanceEdit";
      this.Shown += new System.EventHandler(this.frmSFAllowanceEdit_Shown);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.Controls.SetChildIndex(this.label2, 0);
      this.Controls.SetChildIndex(this.txtEmpName, 0);
      this.Controls.SetChildIndex(this.label1, 0);
      this.Controls.SetChildIndex(this.txtEmpNo, 0);
      this.Controls.SetChildIndex(this.label4, 0);
      this.Controls.SetChildIndex(this.txtDepartName, 0);
      this.Controls.SetChildIndex(this.label12, 0);
      this.Controls.SetChildIndex(this.txtCardSectorNo, 0);
      this.Controls.SetChildIndex(this.label3, 0);
      this.Controls.SetChildIndex(this.txtWay, 0);
      this.Controls.SetChildIndex(this.label5, 0);
      this.Controls.SetChildIndex(this.txtUp, 0);
      this.Controls.SetChildIndex(this.label6, 0);
      this.Controls.SetChildIndex(this.txtAmount, 0);
      this.Controls.SetChildIndex(this.label7, 0);
      this.Controls.SetChildIndex(this.txtSum, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtCardSectorNo;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.TextBox txtDepartName;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtEmpNo;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtEmpName;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtWay;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtUp;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtAmount;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txtSum;
    private System.Windows.Forms.Label label7;
  }
}
