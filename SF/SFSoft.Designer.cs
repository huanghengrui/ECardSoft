namespace ECard78
{
  partial class frmSFSoft
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSFSoft));
            this.gbxEmpInfo = new System.Windows.Forms.GroupBox();
            this.txtCardBalance = new System.Windows.Forms.TextBox();
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
            this.btnReadCard = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chkPrint = new System.Windows.Forms.CheckBox();
            this.txtMoney = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbbMealType = new System.Windows.Forms.ComboBox();
            this.cbbSFType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chkEmptyZero = new System.Windows.Forms.CheckBox();
            this.chkAutoPeriod = new System.Windows.Forms.CheckBox();
            this.txtBTBalance = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chkBTBalance = new System.Windows.Forms.CheckBox();
            this.gbxEmpInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(395, 265);
            this.btnCancel.Text = "";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(315, 265);
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
            this.gbxEmpInfo.Controls.Add(this.txtBTBalance);
            this.gbxEmpInfo.Controls.Add(this.label10);
            this.gbxEmpInfo.Controls.Add(this.txtCardBalance);
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
            // txtCardBalance
            // 
            this.txtCardBalance.Location = new System.Drawing.Point(100, 110);
            this.txtCardBalance.Name = "txtCardBalance";
            this.txtCardBalance.ReadOnly = true;
            this.txtCardBalance.Size = new System.Drawing.Size(120, 21);
            this.txtCardBalance.TabIndex = 79;
            this.txtCardBalance.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 114);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 12);
            this.label11.TabIndex = 78;
            this.label11.Tag = "SFCardBalance";
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
            // btnReadCard
            // 
            this.btnReadCard.Location = new System.Drawing.Point(395, 225);
            this.btnReadCard.Name = "btnReadCard";
            this.btnReadCard.Size = new System.Drawing.Size(75, 25);
            this.btnReadCard.TabIndex = 7;
            this.btnReadCard.Text = "button1";
            this.btnReadCard.UseVisualStyleBackColor = true;
            this.btnReadCard.Click += new System.EventHandler(this.btnReadCard_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.ForeColor = System.Drawing.Color.Blue;
            this.lblResult.Location = new System.Drawing.Point(10, 275);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(47, 12);
            this.lblResult.TabIndex = 33;
            this.lblResult.Tag = "";
            this.lblResult.Text = "label10";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(10, 250);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 32;
            this.label9.Tag = "lblDepositHint";
            this.label9.Text = "label9";
            // 
            // chkPrint
            // 
            this.chkPrint.AutoSize = true;
            this.chkPrint.Location = new System.Drawing.Point(10, 225);
            this.chkPrint.Name = "chkPrint";
            this.chkPrint.Size = new System.Drawing.Size(78, 16);
            this.chkPrint.TabIndex = 4;
            this.chkPrint.Tag = "chkPrintCertificate";
            this.chkPrint.Text = "checkBox1";
            this.chkPrint.UseVisualStyleBackColor = true;
            // 
            // txtMoney
            // 
            this.txtMoney.Location = new System.Drawing.Point(110, 160);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.Size = new System.Drawing.Size(120, 21);
            this.txtMoney.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 31;
            this.label6.Tag = "SoAmount";
            this.label6.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(250, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 34;
            this.label7.Tag = "SpendingTime";
            this.label7.Text = "label7";
            // 
            // cbbMealType
            // 
            this.cbbMealType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMealType.FormattingEnabled = true;
            this.cbbMealType.Location = new System.Drawing.Point(340, 160);
            this.cbbMealType.Name = "cbbMealType";
            this.cbbMealType.Size = new System.Drawing.Size(120, 20);
            this.cbbMealType.TabIndex = 2;
            // 
            // cbbSFType
            // 
            this.cbbSFType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSFType.FormattingEnabled = true;
            this.cbbSFType.Location = new System.Drawing.Point(110, 190);
            this.cbbSFType.Name = "cbbSFType";
            this.cbbSFType.Size = new System.Drawing.Size(120, 20);
            this.cbbSFType.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 194);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 36;
            this.label8.Tag = "SFType";
            this.label8.Text = "label8";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(315, 225);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chkEmptyZero
            // 
            this.chkEmptyZero.AutoSize = true;
            this.chkEmptyZero.Location = new System.Drawing.Point(110, 225);
            this.chkEmptyZero.Name = "chkEmptyZero";
            this.chkEmptyZero.Size = new System.Drawing.Size(78, 16);
            this.chkEmptyZero.TabIndex = 5;
            this.chkEmptyZero.Tag = "";
            this.chkEmptyZero.Text = "checkBox1";
            this.chkEmptyZero.UseVisualStyleBackColor = true;
            // 
            // chkAutoPeriod
            // 
            this.chkAutoPeriod.AutoSize = true;
            this.chkAutoPeriod.Checked = true;
            this.chkAutoPeriod.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoPeriod.Location = new System.Drawing.Point(252, 195);
            this.chkAutoPeriod.Name = "chkAutoPeriod";
            this.chkAutoPeriod.Size = new System.Drawing.Size(78, 16);
            this.chkAutoPeriod.TabIndex = 37;
            this.chkAutoPeriod.Text = "checkBox1";
            this.chkAutoPeriod.UseVisualStyleBackColor = true;
            // 
            // txtBTBalance
            // 
            this.txtBTBalance.Location = new System.Drawing.Point(330, 110);
            this.txtBTBalance.Name = "txtBTBalance";
            this.txtBTBalance.ReadOnly = true;
            this.txtBTBalance.Size = new System.Drawing.Size(120, 21);
            this.txtBTBalance.TabIndex = 81;
            this.txtBTBalance.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(240, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 80;
            this.label10.Tag = "BTBalance";
            this.label10.Text = "label10";
            // 
            // chkBTBalance
            // 
            this.chkBTBalance.AutoSize = true;
            this.chkBTBalance.Location = new System.Drawing.Point(217, 225);
            this.chkBTBalance.Name = "chkBTBalance";
            this.chkBTBalance.Size = new System.Drawing.Size(78, 16);
            this.chkBTBalance.TabIndex = 38;
            this.chkBTBalance.Text = "checkBox1";
            this.chkBTBalance.UseVisualStyleBackColor = true;
            // 
            // frmSFSoft
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(479, 298);
            this.Controls.Add(this.chkBTBalance);
            this.Controls.Add(this.chkAutoPeriod);
            this.Controls.Add(this.chkEmptyZero);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbbSFType);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbbMealType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnReadCard);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.chkPrint);
            this.Controls.Add(this.txtMoney);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.gbxEmpInfo);
            this.Name = "frmSFSoft";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSFRefundment_FormClosing);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.gbxEmpInfo, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtMoney, 0);
            this.Controls.SetChildIndex(this.chkPrint, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.lblResult, 0);
            this.Controls.SetChildIndex(this.btnReadCard, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.cbbMealType, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.cbbSFType, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.chkEmptyZero, 0);
            this.Controls.SetChildIndex(this.chkAutoPeriod, 0);
            this.Controls.SetChildIndex(this.chkBTBalance, 0);
            this.gbxEmpInfo.ResumeLayout(false);
            this.gbxEmpInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.GroupBox gbxEmpInfo;
    private System.Windows.Forms.TextBox txtCardBalance;
    private System.Windows.Forms.Label label11;
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
    private System.Windows.Forms.Button btnReadCard;
    private System.Windows.Forms.Label lblResult;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.CheckBox chkPrint;
    private System.Windows.Forms.TextBox txtMoney;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.ComboBox cbbMealType;
    private System.Windows.Forms.ComboBox cbbSFType;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.CheckBox chkEmptyZero;
    private System.Windows.Forms.CheckBox chkAutoPeriod;
        private System.Windows.Forms.TextBox txtBTBalance;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkBTBalance;
    }
}
