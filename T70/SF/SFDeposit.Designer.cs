namespace ECard78
{
  partial class frmSFDeposit
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSFDeposit));
      this.gbxEmpInfo = new System.Windows.Forms.GroupBox();
      this.picDisc = new System.Windows.Forms.PictureBox();
      this.txtCardBalance = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.txtDepositDiscount = new System.Windows.Forms.TextBox();
      this.label11 = new System.Windows.Forms.Label();
      this.txtCardType = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txtCardSectorNo = new System.Windows.Forms.TextBox();
      this.label12 = new System.Windows.Forms.Label();
      this.txtCardStatusName = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.txtDepartName = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.txtEmpNo = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.txtEmpName = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtMoney = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.btnReadCard = new System.Windows.Forms.Button();
      this.lblResult = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.chkPrint = new System.Windows.Forms.CheckBox();
      this.chkEmptyZero = new System.Windows.Forms.CheckBox();
      this.label7 = new System.Windows.Forms.Label();
      this.cbbType = new System.Windows.Forms.ComboBox();
      this.chkPayCode = new System.Windows.Forms.CheckBox();
      this.lblShowMoney = new System.Windows.Forms.Label();
      this.chkPayCodeUSB = new System.Windows.Forms.CheckBox();
      this.cbbCommPort = new System.Windows.Forms.ComboBox();
      this.gbxEmpInfo.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picDisc)).BeginInit();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(395, 285);
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(315, 285);
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
      // gbxEmpInfo
      // 
      this.gbxEmpInfo.Controls.Add(this.picDisc);
      this.gbxEmpInfo.Controls.Add(this.txtCardBalance);
      this.gbxEmpInfo.Controls.Add(this.label8);
      this.gbxEmpInfo.Controls.Add(this.txtDepositDiscount);
      this.gbxEmpInfo.Controls.Add(this.label11);
      this.gbxEmpInfo.Controls.Add(this.txtCardType);
      this.gbxEmpInfo.Controls.Add(this.label3);
      this.gbxEmpInfo.Controls.Add(this.txtCardSectorNo);
      this.gbxEmpInfo.Controls.Add(this.label12);
      this.gbxEmpInfo.Controls.Add(this.txtCardStatusName);
      this.gbxEmpInfo.Controls.Add(this.label5);
      this.gbxEmpInfo.Controls.Add(this.txtDepartName);
      this.gbxEmpInfo.Controls.Add(this.label4);
      this.gbxEmpInfo.Controls.Add(this.txtEmpNo);
      this.gbxEmpInfo.Controls.Add(this.label1);
      this.gbxEmpInfo.Controls.Add(this.txtEmpName);
      this.gbxEmpInfo.Controls.Add(this.label2);
      this.gbxEmpInfo.Location = new System.Drawing.Point(10, 10);
      this.gbxEmpInfo.Name = "gbxEmpInfo";
      this.gbxEmpInfo.Size = new System.Drawing.Size(460, 140);
      this.gbxEmpInfo.TabIndex = 0;
      this.gbxEmpInfo.TabStop = false;
      this.gbxEmpInfo.Text = "groupBox1";
      // 
      // picDisc
      // 
      this.picDisc.Image = ((System.Drawing.Image)(resources.GetObject("picDisc.Image")));
      this.picDisc.Location = new System.Drawing.Point(200, 110);
      this.picDisc.Name = "picDisc";
      this.picDisc.Size = new System.Drawing.Size(20, 20);
      this.picDisc.TabIndex = 86;
      this.picDisc.TabStop = false;
      this.picDisc.Click += new System.EventHandler(this.picDisc_Click);
      // 
      // txtCardBalance
      // 
      this.txtCardBalance.Location = new System.Drawing.Point(330, 110);
      this.txtCardBalance.MaxLength = 10;
      this.txtCardBalance.Name = "txtCardBalance";
      this.txtCardBalance.ReadOnly = true;
      this.txtCardBalance.Size = new System.Drawing.Size(120, 21);
      this.txtCardBalance.TabIndex = 84;
      this.txtCardBalance.TabStop = false;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(240, 114);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(41, 12);
      this.label8.TabIndex = 85;
      this.label8.Tag = "SFCardBalance";
      this.label8.Text = "label8";
      // 
      // txtDepositDiscount
      // 
      this.txtDepositDiscount.Location = new System.Drawing.Point(100, 110);
      this.txtDepositDiscount.Name = "txtDepositDiscount";
      this.txtDepositDiscount.ReadOnly = true;
      this.txtDepositDiscount.Size = new System.Drawing.Size(100, 21);
      this.txtDepositDiscount.TabIndex = 83;
      this.txtDepositDiscount.TabStop = false;
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(10, 114);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(47, 12);
      this.label11.TabIndex = 82;
      this.label11.Tag = "DepositDiscount";
      this.label11.Text = "label11";
      // 
      // txtCardType
      // 
      this.txtCardType.Location = new System.Drawing.Point(330, 80);
      this.txtCardType.MaxLength = 10;
      this.txtCardType.Name = "txtCardType";
      this.txtCardType.ReadOnly = true;
      this.txtCardType.Size = new System.Drawing.Size(120, 21);
      this.txtCardType.TabIndex = 76;
      this.txtCardType.TabStop = false;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(240, 84);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(41, 12);
      this.label3.TabIndex = 77;
      this.label3.Tag = "CardType";
      this.label3.Text = "label3";
      // 
      // txtCardSectorNo
      // 
      this.txtCardSectorNo.Location = new System.Drawing.Point(330, 50);
      this.txtCardSectorNo.MaxLength = 10;
      this.txtCardSectorNo.Name = "txtCardSectorNo";
      this.txtCardSectorNo.ReadOnly = true;
      this.txtCardSectorNo.Size = new System.Drawing.Size(120, 21);
      this.txtCardSectorNo.TabIndex = 4;
      this.txtCardSectorNo.TabStop = false;
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Location = new System.Drawing.Point(240, 54);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(47, 12);
      this.label12.TabIndex = 75;
      this.label12.Tag = "CardSectorNo";
      this.label12.Text = "label12";
      // 
      // txtCardStatusName
      // 
      this.txtCardStatusName.Location = new System.Drawing.Point(100, 80);
      this.txtCardStatusName.Name = "txtCardStatusName";
      this.txtCardStatusName.ReadOnly = true;
      this.txtCardStatusName.Size = new System.Drawing.Size(120, 21);
      this.txtCardStatusName.TabIndex = 5;
      this.txtCardStatusName.TabStop = false;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(10, 84);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(41, 12);
      this.label5.TabIndex = 73;
      this.label5.Tag = "CardStatusName";
      this.label5.Text = "label5";
      // 
      // txtDepartName
      // 
      this.txtDepartName.Location = new System.Drawing.Point(100, 50);
      this.txtDepartName.Name = "txtDepartName";
      this.txtDepartName.ReadOnly = true;
      this.txtDepartName.Size = new System.Drawing.Size(120, 21);
      this.txtDepartName.TabIndex = 3;
      this.txtDepartName.TabStop = false;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(10, 54);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(41, 12);
      this.label4.TabIndex = 72;
      this.label4.Tag = "Depart";
      this.label4.Text = "label4";
      // 
      // txtEmpNo
      // 
      this.txtEmpNo.Location = new System.Drawing.Point(100, 20);
      this.txtEmpNo.MaxLength = 20;
      this.txtEmpNo.Name = "txtEmpNo";
      this.txtEmpNo.ReadOnly = true;
      this.txtEmpNo.Size = new System.Drawing.Size(120, 21);
      this.txtEmpNo.TabIndex = 1;
      this.txtEmpNo.TabStop = false;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(10, 24);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 12);
      this.label1.TabIndex = 28;
      this.label1.Tag = "EmpNo";
      this.label1.Text = "label1";
      // 
      // txtEmpName
      // 
      this.txtEmpName.Location = new System.Drawing.Point(330, 20);
      this.txtEmpName.MaxLength = 50;
      this.txtEmpName.Name = "txtEmpName";
      this.txtEmpName.ReadOnly = true;
      this.txtEmpName.Size = new System.Drawing.Size(120, 21);
      this.txtEmpName.TabIndex = 2;
      this.txtEmpName.TabStop = false;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(240, 24);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(41, 12);
      this.label2.TabIndex = 29;
      this.label2.Tag = "EmpName";
      this.label2.Text = "label2";
      // 
      // txtMoney
      // 
      this.txtMoney.Location = new System.Drawing.Point(110, 160);
      this.txtMoney.Name = "txtMoney";
      this.txtMoney.Size = new System.Drawing.Size(120, 21);
      this.txtMoney.TabIndex = 1;
      this.txtMoney.TextChanged += new System.EventHandler(this.txtMoney_TextChanged);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(20, 164);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(41, 12);
      this.label6.TabIndex = 19;
      this.label6.Tag = "DepositMoney";
      this.label6.Text = "label6";
      // 
      // btnReadCard
      // 
      this.btnReadCard.Location = new System.Drawing.Point(235, 285);
      this.btnReadCard.Name = "btnReadCard";
      this.btnReadCard.Size = new System.Drawing.Size(75, 25);
      this.btnReadCard.TabIndex = 8;
      this.btnReadCard.Text = "button1";
      this.btnReadCard.UseVisualStyleBackColor = true;
      this.btnReadCard.Click += new System.EventHandler(this.btnReadCard_Click);
      // 
      // lblResult
      // 
      this.lblResult.AutoSize = true;
      this.lblResult.ForeColor = System.Drawing.Color.Blue;
      this.lblResult.Location = new System.Drawing.Point(10, 250);
      this.lblResult.Name = "lblResult";
      this.lblResult.Size = new System.Drawing.Size(47, 12);
      this.lblResult.TabIndex = 27;
      this.lblResult.Tag = "";
      this.lblResult.Text = "label10";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.ForeColor = System.Drawing.Color.Blue;
      this.label9.Location = new System.Drawing.Point(10, 225);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(41, 12);
      this.label9.TabIndex = 26;
      this.label9.Tag = "lblDepositHint";
      this.label9.Text = "label9";
      // 
      // chkPrint
      // 
      this.chkPrint.AutoSize = true;
      this.chkPrint.Location = new System.Drawing.Point(10, 200);
      this.chkPrint.Name = "chkPrint";
      this.chkPrint.Size = new System.Drawing.Size(78, 16);
      this.chkPrint.TabIndex = 3;
      this.chkPrint.Tag = "chkPrintCertificate";
      this.chkPrint.Text = "checkBox1";
      this.chkPrint.UseVisualStyleBackColor = true;
      // 
      // chkEmptyZero
      // 
      this.chkEmptyZero.AutoSize = true;
      this.chkEmptyZero.Location = new System.Drawing.Point(110, 200);
      this.chkEmptyZero.Name = "chkEmptyZero";
      this.chkEmptyZero.Size = new System.Drawing.Size(78, 16);
      this.chkEmptyZero.TabIndex = 4;
      this.chkEmptyZero.Tag = "";
      this.chkEmptyZero.Text = "checkBox1";
      this.chkEmptyZero.UseVisualStyleBackColor = true;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(250, 164);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(41, 12);
      this.label7.TabIndex = 29;
      this.label7.Tag = "DepositType";
      this.label7.Text = "label7";
      // 
      // cbbType
      // 
      this.cbbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbType.FormattingEnabled = true;
      this.cbbType.Location = new System.Drawing.Point(340, 160);
      this.cbbType.Name = "cbbType";
      this.cbbType.Size = new System.Drawing.Size(120, 20);
      this.cbbType.TabIndex = 2;
      this.cbbType.SelectedIndexChanged += new System.EventHandler(this.cbbType_SelectedIndexChanged);
      // 
      // chkPayCode
      // 
      this.chkPayCode.AutoSize = true;
      this.chkPayCode.Enabled = false;
      this.chkPayCode.Location = new System.Drawing.Point(340, 185);
      this.chkPayCode.Name = "chkPayCode";
      this.chkPayCode.Size = new System.Drawing.Size(78, 16);
      this.chkPayCode.TabIndex = 5;
      this.chkPayCode.Tag = "";
      this.chkPayCode.Text = "checkBox1";
      this.chkPayCode.UseVisualStyleBackColor = true;
      this.chkPayCode.Visible = false;
      // 
      // lblShowMoney
      // 
      this.lblShowMoney.AutoSize = true;
      this.lblShowMoney.ForeColor = System.Drawing.Color.Blue;
      this.lblShowMoney.Location = new System.Drawing.Point(10, 275);
      this.lblShowMoney.Name = "lblShowMoney";
      this.lblShowMoney.Size = new System.Drawing.Size(47, 12);
      this.lblShowMoney.TabIndex = 33;
      this.lblShowMoney.Tag = "";
      this.lblShowMoney.Text = "label10";
      // 
      // chkPayCodeUSB
      // 
      this.chkPayCodeUSB.AutoSize = true;
      this.chkPayCodeUSB.Enabled = false;
      this.chkPayCodeUSB.Location = new System.Drawing.Point(340, 205);
      this.chkPayCodeUSB.Name = "chkPayCodeUSB";
      this.chkPayCodeUSB.Size = new System.Drawing.Size(78, 16);
      this.chkPayCodeUSB.TabIndex = 6;
      this.chkPayCodeUSB.Tag = "";
      this.chkPayCodeUSB.Text = "checkBox1";
      this.chkPayCodeUSB.UseVisualStyleBackColor = true;
      this.chkPayCodeUSB.Visible = false;
      // 
      // cbbCommPort
      // 
      this.cbbCommPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbCommPort.FormattingEnabled = true;
      this.cbbCommPort.Location = new System.Drawing.Point(340, 225);
      this.cbbCommPort.Name = "cbbCommPort";
      this.cbbCommPort.Size = new System.Drawing.Size(120, 20);
      this.cbbCommPort.TabIndex = 7;
      // 
      // frmSFDeposit
      // 
      this.AcceptButton = this.btnOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(479, 322);
      this.Controls.Add(this.cbbCommPort);
      this.Controls.Add(this.chkPayCodeUSB);
      this.Controls.Add(this.lblShowMoney);
      this.Controls.Add(this.chkPayCode);
      this.Controls.Add(this.cbbType);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.chkEmptyZero);
      this.Controls.Add(this.btnReadCard);
      this.Controls.Add(this.lblResult);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.chkPrint);
      this.Controls.Add(this.txtMoney);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.gbxEmpInfo);
      this.Name = "frmSFDeposit";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSFDeposit_FormClosing);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.Controls.SetChildIndex(this.gbxEmpInfo, 0);
      this.Controls.SetChildIndex(this.label6, 0);
      this.Controls.SetChildIndex(this.txtMoney, 0);
      this.Controls.SetChildIndex(this.chkPrint, 0);
      this.Controls.SetChildIndex(this.label9, 0);
      this.Controls.SetChildIndex(this.lblResult, 0);
      this.Controls.SetChildIndex(this.btnReadCard, 0);
      this.Controls.SetChildIndex(this.chkEmptyZero, 0);
      this.Controls.SetChildIndex(this.label7, 0);
      this.Controls.SetChildIndex(this.cbbType, 0);
      this.Controls.SetChildIndex(this.chkPayCode, 0);
      this.Controls.SetChildIndex(this.lblShowMoney, 0);
      this.Controls.SetChildIndex(this.chkPayCodeUSB, 0);
      this.Controls.SetChildIndex(this.cbbCommPort, 0);
      this.gbxEmpInfo.ResumeLayout(false);
      this.gbxEmpInfo.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picDisc)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.GroupBox gbxEmpInfo;
    private System.Windows.Forms.TextBox txtCardType;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtCardSectorNo;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.TextBox txtCardStatusName;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtDepartName;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtEmpNo;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtEmpName;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtMoney;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Button btnReadCard;
    private System.Windows.Forms.Label lblResult;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.CheckBox chkPrint;
    private System.Windows.Forms.TextBox txtCardBalance;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox txtDepositDiscount;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.CheckBox chkEmptyZero;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.ComboBox cbbType;
    private System.Windows.Forms.PictureBox picDisc;
    private System.Windows.Forms.CheckBox chkPayCode;
    private System.Windows.Forms.Label lblShowMoney;
    private System.Windows.Forms.CheckBox chkPayCodeUSB;
    private System.Windows.Forms.ComboBox cbbCommPort;
  }
}
