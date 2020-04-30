namespace ECard78
{
  partial class frmRSCardTypeAdd
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRSCardTypeAdd));
      this.label1 = new System.Windows.Forms.Label();
      this.txtID = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtName = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txtFee = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.txtStored = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.txtDeposit = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.txtDesc = new System.Windows.Forms.TextBox();
      this.chkCheckOrder = new System.Windows.Forms.CheckBox();
      this.lblHint = new System.Windows.Forms.Label();
      this.chkCardRetirement = new System.Windows.Forms.CheckBox();
      this.chkCardRefundment = new System.Windows.Forms.CheckBox();
      this.chkCardRefundmentDev = new System.Windows.Forms.CheckBox();
      this.label7 = new System.Windows.Forms.Label();
      this.txtDepositLimit = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.txtRefundment = new System.Windows.Forms.TextBox();
      this.label9 = new System.Windows.Forms.Label();
      this.txtDepositTimes = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(275, 402);
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(195, 402);
      this.btnOk.Text = "";
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // ilTreeState
      // 
      this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
      this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
      this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
      this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(10, 14);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 12);
      this.label1.TabIndex = 19;
      this.label1.Tag = "CardTypeID";
      this.label1.Text = "label1";
      // 
      // txtID
      // 
      this.txtID.Location = new System.Drawing.Point(150, 10);
      this.txtID.Name = "txtID";
      this.txtID.ReadOnly = true;
      this.txtID.Size = new System.Drawing.Size(200, 21);
      this.txtID.TabIndex = 0;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(10, 44);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(41, 12);
      this.label2.TabIndex = 21;
      this.label2.Tag = "CardTypeName";
      this.label2.Text = "label2";
      // 
      // txtName
      // 
      this.txtName.Location = new System.Drawing.Point(150, 40);
      this.txtName.MaxLength = 50;
      this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(200, 21);
      this.txtName.TabIndex = 1;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(10, 74);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(41, 12);
      this.label3.TabIndex = 23;
      this.label3.Tag = "CardFee";
      this.label3.Text = "label3";
      // 
      // txtFee
      // 
      this.txtFee.Location = new System.Drawing.Point(150, 70);
      this.txtFee.MaxLength = 10;
      this.txtFee.Name = "txtFee";
      this.txtFee.Size = new System.Drawing.Size(200, 21);
      this.txtFee.TabIndex = 2;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(10, 104);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(41, 12);
      this.label4.TabIndex = 25;
      this.label4.Tag = "CardStored";
      this.label4.Text = "label4";
      // 
      // txtStored
      // 
      this.txtStored.Location = new System.Drawing.Point(150, 100);
      this.txtStored.MaxLength = 10;
      this.txtStored.Name = "txtStored";
      this.txtStored.Size = new System.Drawing.Size(200, 21);
      this.txtStored.TabIndex = 3;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(10, 219);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(41, 12);
      this.label5.TabIndex = 27;
      this.label5.Tag = "DepositDiscount";
      this.label5.Text = "label5";
      // 
      // txtDeposit
      // 
      this.txtDeposit.Location = new System.Drawing.Point(150, 215);
      this.txtDeposit.MaxLength = 5;
      this.txtDeposit.Name = "txtDeposit";
      this.txtDeposit.Size = new System.Drawing.Size(200, 21);
      this.txtDeposit.TabIndex = 8;
      // 
      // label6
      // 
      this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(10, 339);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(41, 12);
      this.label6.TabIndex = 29;
      this.label6.Tag = "CardDescription";
      this.label6.Text = "label6";
      // 
      // txtDesc
      // 
      this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.txtDesc.Location = new System.Drawing.Point(150, 335);
      this.txtDesc.MaxLength = 200;
      this.txtDesc.Name = "txtDesc";
      this.txtDesc.Size = new System.Drawing.Size(200, 21);
      this.txtDesc.TabIndex = 12;
      // 
      // chkCheckOrder
      // 
      this.chkCheckOrder.AutoSize = true;
      this.chkCheckOrder.Location = new System.Drawing.Point(150, 130);
      this.chkCheckOrder.Name = "chkCheckOrder";
      this.chkCheckOrder.Size = new System.Drawing.Size(78, 16);
      this.chkCheckOrder.TabIndex = 4;
      this.chkCheckOrder.Tag = "CardCheckOrder";
      this.chkCheckOrder.Text = "checkBox1";
      this.chkCheckOrder.UseVisualStyleBackColor = true;
      // 
      // lblHint
      // 
      this.lblHint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lblHint.Location = new System.Drawing.Point(10, 366);
      this.lblHint.Name = "lblHint";
      this.lblHint.Size = new System.Drawing.Size(340, 30);
      this.lblHint.TabIndex = 30;
      this.lblHint.Text = "label7";
      // 
      // chkCardRetirement
      // 
      this.chkCardRetirement.AutoSize = true;
      this.chkCardRetirement.Location = new System.Drawing.Point(150, 150);
      this.chkCardRetirement.Name = "chkCardRetirement";
      this.chkCardRetirement.Size = new System.Drawing.Size(78, 16);
      this.chkCardRetirement.TabIndex = 5;
      this.chkCardRetirement.Tag = "CardRetirement";
      this.chkCardRetirement.Text = "checkBox1";
      this.chkCardRetirement.UseVisualStyleBackColor = true;
      // 
      // chkCardRefundment
      // 
      this.chkCardRefundment.AutoSize = true;
      this.chkCardRefundment.Location = new System.Drawing.Point(150, 170);
      this.chkCardRefundment.Name = "chkCardRefundment";
      this.chkCardRefundment.Size = new System.Drawing.Size(78, 16);
      this.chkCardRefundment.TabIndex = 6;
      this.chkCardRefundment.Tag = "CardRefundment";
      this.chkCardRefundment.Text = "checkBox1";
      this.chkCardRefundment.UseVisualStyleBackColor = true;
      // 
      // chkCardRefundmentDev
      // 
      this.chkCardRefundmentDev.AutoSize = true;
      this.chkCardRefundmentDev.Location = new System.Drawing.Point(150, 190);
      this.chkCardRefundmentDev.Name = "chkCardRefundmentDev";
      this.chkCardRefundmentDev.Size = new System.Drawing.Size(78, 16);
      this.chkCardRefundmentDev.TabIndex = 7;
      this.chkCardRefundmentDev.Tag = "CardRefundmentDev";
      this.chkCardRefundmentDev.Text = "checkBox2";
      this.chkCardRefundmentDev.UseVisualStyleBackColor = true;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(10, 279);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(41, 12);
      this.label7.TabIndex = 32;
      this.label7.Tag = "CardDepositLimit";
      this.label7.Text = "label7";
      // 
      // txtDepositLimit
      // 
      this.txtDepositLimit.Location = new System.Drawing.Point(150, 275);
      this.txtDepositLimit.MaxLength = 10;
      this.txtDepositLimit.Name = "txtDepositLimit";
      this.txtDepositLimit.Size = new System.Drawing.Size(200, 21);
      this.txtDepositLimit.TabIndex = 10;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(10, 249);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(41, 12);
      this.label8.TabIndex = 34;
      this.label8.Tag = "CardRefundmentDiscount";
      this.label8.Text = "label8";
      // 
      // txtRefundment
      // 
      this.txtRefundment.Location = new System.Drawing.Point(150, 245);
      this.txtRefundment.MaxLength = 5;
      this.txtRefundment.Name = "txtRefundment";
      this.txtRefundment.Size = new System.Drawing.Size(200, 21);
      this.txtRefundment.TabIndex = 9;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(10, 309);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(41, 12);
      this.label9.TabIndex = 36;
      this.label9.Tag = "CardDepositTimes";
      this.label9.Text = "label9";
      // 
      // txtDepositTimes
      // 
      this.txtDepositTimes.Location = new System.Drawing.Point(150, 305);
      this.txtDepositTimes.MaxLength = 5;
      this.txtDepositTimes.Name = "txtDepositTimes";
      this.txtDepositTimes.Size = new System.Drawing.Size(200, 21);
      this.txtDepositTimes.TabIndex = 11;
      // 
      // frmRSCardTypeAdd
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(359, 435);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.txtDepositTimes);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.txtRefundment);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.txtDepositLimit);
      this.Controls.Add(this.chkCardRefundmentDev);
      this.Controls.Add(this.chkCardRefundment);
      this.Controls.Add(this.chkCardRetirement);
      this.Controls.Add(this.lblHint);
      this.Controls.Add(this.chkCheckOrder);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txtStored);
      this.Controls.Add(this.txtName);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.txtDesc);
      this.Controls.Add(this.txtFee);
      this.Controls.Add(this.txtDeposit);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txtID);
      this.Controls.Add(this.label1);
      this.Name = "frmRSCardTypeAdd";
      this.Controls.SetChildIndex(this.label1, 0);
      this.Controls.SetChildIndex(this.txtID, 0);
      this.Controls.SetChildIndex(this.label2, 0);
      this.Controls.SetChildIndex(this.txtDeposit, 0);
      this.Controls.SetChildIndex(this.txtFee, 0);
      this.Controls.SetChildIndex(this.txtDesc, 0);
      this.Controls.SetChildIndex(this.label5, 0);
      this.Controls.SetChildIndex(this.label6, 0);
      this.Controls.SetChildIndex(this.txtName, 0);
      this.Controls.SetChildIndex(this.txtStored, 0);
      this.Controls.SetChildIndex(this.label3, 0);
      this.Controls.SetChildIndex(this.label4, 0);
      this.Controls.SetChildIndex(this.chkCheckOrder, 0);
      this.Controls.SetChildIndex(this.lblHint, 0);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.Controls.SetChildIndex(this.chkCardRetirement, 0);
      this.Controls.SetChildIndex(this.chkCardRefundment, 0);
      this.Controls.SetChildIndex(this.chkCardRefundmentDev, 0);
      this.Controls.SetChildIndex(this.txtDepositLimit, 0);
      this.Controls.SetChildIndex(this.label7, 0);
      this.Controls.SetChildIndex(this.txtRefundment, 0);
      this.Controls.SetChildIndex(this.label8, 0);
      this.Controls.SetChildIndex(this.txtDepositTimes, 0);
      this.Controls.SetChildIndex(this.label9, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtID;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtFee;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtStored;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtDeposit;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txtDesc;
    private System.Windows.Forms.CheckBox chkCheckOrder;
    private System.Windows.Forms.Label lblHint;
    private System.Windows.Forms.CheckBox chkCardRetirement;
    private System.Windows.Forms.CheckBox chkCardRefundment;
    private System.Windows.Forms.CheckBox chkCardRefundmentDev;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox txtDepositLimit;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox txtRefundment;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.TextBox txtDepositTimes;
  }
}
