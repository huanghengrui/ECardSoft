namespace ECard78
{
  partial class frmRSEmpCardRetirement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRSEmpCardRetirement));
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.rbLoss = new System.Windows.Forms.RadioButton();
            this.btnReadCard = new System.Windows.Forms.Button();
            this.btnFindEmp = new System.Windows.Forms.Button();
            this.btnSelectEmp = new System.Windows.Forms.Button();
            this.lblFind = new System.Windows.Forms.Label();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.gbxEmpInfo = new System.Windows.Forms.GroupBox();
            this.txtCardBalanceBT = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCardType = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCardUseDate = new System.Windows.Forms.TextBox();
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
            this.txtReFee = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCardFee = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.chkPrint = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBT = new System.Windows.Forms.TextBox();
            this.lbBTNotget = new System.Windows.Forms.Label();
            this.lbBTget = new System.Windows.Forms.Label();
            this.gbxEmpInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(395, 284);
            this.btnCancel.Text = "";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(315, 284);
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
            // rbNormal
            // 
            this.rbNormal.AutoSize = true;
            this.rbNormal.Checked = true;
            this.rbNormal.Location = new System.Drawing.Point(10, 10);
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.Size = new System.Drawing.Size(95, 16);
            this.rbNormal.TabIndex = 0;
            this.rbNormal.TabStop = true;
            this.rbNormal.Text = "radioButton1";
            this.rbNormal.UseVisualStyleBackColor = true;
            this.rbNormal.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // rbLoss
            // 
            this.rbLoss.AutoSize = true;
            this.rbLoss.Location = new System.Drawing.Point(10, 30);
            this.rbLoss.Name = "rbLoss";
            this.rbLoss.Size = new System.Drawing.Size(95, 16);
            this.rbLoss.TabIndex = 1;
            this.rbLoss.Text = "radioButton2";
            this.rbLoss.UseVisualStyleBackColor = true;
            this.rbLoss.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // btnReadCard
            // 
            this.btnReadCard.Location = new System.Drawing.Point(395, 25);
            this.btnReadCard.Name = "btnReadCard";
            this.btnReadCard.Size = new System.Drawing.Size(75, 25);
            this.btnReadCard.TabIndex = 2;
            this.btnReadCard.Text = "button1";
            this.btnReadCard.UseVisualStyleBackColor = true;
            this.btnReadCard.Click += new System.EventHandler(this.btnReadCard_Click);
            // 
            // btnFindEmp
            // 
            this.btnFindEmp.Location = new System.Drawing.Point(395, 25);
            this.btnFindEmp.Name = "btnFindEmp";
            this.btnFindEmp.Size = new System.Drawing.Size(75, 20);
            this.btnFindEmp.TabIndex = 5;
            this.btnFindEmp.Text = "button1";
            this.btnFindEmp.UseVisualStyleBackColor = true;
            this.btnFindEmp.Click += new System.EventHandler(this.btnFindEmp_Click);
            // 
            // btnSelectEmp
            // 
            this.btnSelectEmp.Location = new System.Drawing.Point(355, 26);
            this.btnSelectEmp.Name = "btnSelectEmp";
            this.btnSelectEmp.Size = new System.Drawing.Size(34, 19);
            this.btnSelectEmp.TabIndex = 4;
            this.btnSelectEmp.Text = "...";
            this.btnSelectEmp.UseVisualStyleBackColor = true;
            this.btnSelectEmp.Click += new System.EventHandler(this.btnSelectEmp_Click);
            // 
            // lblFind
            // 
            this.lblFind.AutoSize = true;
            this.lblFind.Location = new System.Drawing.Point(180, 29);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(41, 12);
            this.lblFind.TabIndex = 25;
            this.lblFind.Text = "label6";
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(270, 25);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(120, 21);
            this.txtFind.TabIndex = 3;
            // 
            // gbxEmpInfo
            // 
            this.gbxEmpInfo.Controls.Add(this.lbBTNotget);
            this.gbxEmpInfo.Controls.Add(this.lbBTget);
            this.gbxEmpInfo.Controls.Add(this.txtBT);
            this.gbxEmpInfo.Controls.Add(this.label9);
            this.gbxEmpInfo.Controls.Add(this.txtCardBalanceBT);
            this.gbxEmpInfo.Controls.Add(this.label8);
            this.gbxEmpInfo.Controls.Add(this.txtCardType);
            this.gbxEmpInfo.Controls.Add(this.label11);
            this.gbxEmpInfo.Controls.Add(this.txtCardUseDate);
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
            this.gbxEmpInfo.Location = new System.Drawing.Point(10, 60);
            this.gbxEmpInfo.Name = "gbxEmpInfo";
            this.gbxEmpInfo.Size = new System.Drawing.Size(460, 178);
            this.gbxEmpInfo.TabIndex = 6;
            this.gbxEmpInfo.TabStop = false;
            this.gbxEmpInfo.Text = "groupBox1";
            // 
            // txtCardBalanceBT
            // 
            this.txtCardBalanceBT.Location = new System.Drawing.Point(330, 110);
            this.txtCardBalanceBT.MaxLength = 10;
            this.txtCardBalanceBT.Name = "txtCardBalanceBT";
            this.txtCardBalanceBT.ReadOnly = true;
            this.txtCardBalanceBT.Size = new System.Drawing.Size(120, 21);
            this.txtCardBalanceBT.TabIndex = 80;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(240, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 81;
            this.label8.Tag = "CardBalanceBT";
            this.label8.Text = "label8";
            // 
            // txtCardType
            // 
            this.txtCardType.Location = new System.Drawing.Point(100, 110);
            this.txtCardType.Name = "txtCardType";
            this.txtCardType.ReadOnly = true;
            this.txtCardType.Size = new System.Drawing.Size(120, 21);
            this.txtCardType.TabIndex = 79;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 114);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 12);
            this.label11.TabIndex = 78;
            this.label11.Tag = "CardType";
            this.label11.Text = "label11";
            // 
            // txtCardUseDate
            // 
            this.txtCardUseDate.Location = new System.Drawing.Point(330, 80);
            this.txtCardUseDate.MaxLength = 10;
            this.txtCardUseDate.Name = "txtCardUseDate";
            this.txtCardUseDate.ReadOnly = true;
            this.txtCardUseDate.Size = new System.Drawing.Size(120, 21);
            this.txtCardUseDate.TabIndex = 76;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 77;
            this.label3.Tag = "CardUseDate";
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
            // txtReFee
            // 
            this.txtReFee.Location = new System.Drawing.Point(340, 244);
            this.txtReFee.Name = "txtReFee";
            this.txtReFee.ReadOnly = true;
            this.txtReFee.Size = new System.Drawing.Size(120, 21);
            this.txtReFee.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(250, 248);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 30;
            this.label7.Tag = "";
            this.label7.Text = "label7";
            // 
            // txtCardFee
            // 
            this.txtCardFee.Location = new System.Drawing.Point(110, 244);
            this.txtCardFee.MaxLength = 10;
            this.txtCardFee.Name = "txtCardFee";
            this.txtCardFee.Size = new System.Drawing.Size(120, 21);
            this.txtCardFee.TabIndex = 7;
            this.txtCardFee.TextChanged += new System.EventHandler(this.txtCardFee_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 29;
            this.label6.Tag = "CardFee";
            this.label6.Text = "label6";
            // 
            // lblResult
            // 
            this.lblResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(10, 299);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(41, 12);
            this.lblResult.TabIndex = 31;
            this.lblResult.Text = "label9";
            // 
            // chkPrint
            // 
            this.chkPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkPrint.AutoSize = true;
            this.chkPrint.Location = new System.Drawing.Point(10, 279);
            this.chkPrint.Name = "chkPrint";
            this.chkPrint.Size = new System.Drawing.Size(78, 16);
            this.chkPrint.TabIndex = 32;
            this.chkPrint.Tag = "chkPrintCertificate";
            this.chkPrint.Text = "checkBox1";
            this.chkPrint.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 151);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 83;
            this.label9.Tag = "BTBalance";
            this.label9.Text = "label9";
            // 
            // txtBT
            // 
            this.txtBT.Location = new System.Drawing.Point(100, 145);
            this.txtBT.Name = "txtBT";
            this.txtBT.ReadOnly = true;
            this.txtBT.Size = new System.Drawing.Size(120, 21);
            this.txtBT.TabIndex = 86;
            // 
            // lbBTNotget
            // 
            this.lbBTNotget.AutoSize = true;
            this.lbBTNotget.ForeColor = System.Drawing.Color.Red;
            this.lbBTNotget.Location = new System.Drawing.Point(240, 148);
            this.lbBTNotget.Name = "lbBTNotget";
            this.lbBTNotget.Size = new System.Drawing.Size(47, 12);
            this.lbBTNotget.TabIndex = 88;
            this.lbBTNotget.Text = "label10";
            this.lbBTNotget.Visible = false;
            // 
            // lbBTget
            // 
            this.lbBTget.AutoSize = true;
            this.lbBTget.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbBTget.Location = new System.Drawing.Point(240, 147);
            this.lbBTget.Name = "lbBTget";
            this.lbBTget.Size = new System.Drawing.Size(47, 12);
            this.lbBTget.TabIndex = 87;
            this.lbBTget.Text = "label10";
            this.lbBTget.Visible = false;
            // 
            // frmRSEmpCardRetirement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(479, 317);
            this.Controls.Add(this.chkPrint);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.txtReFee);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCardFee);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.gbxEmpInfo);
            this.Controls.Add(this.btnFindEmp);
            this.Controls.Add(this.btnSelectEmp);
            this.Controls.Add(this.lblFind);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.btnReadCard);
            this.Controls.Add(this.rbLoss);
            this.Controls.Add(this.rbNormal);
            this.Name = "frmRSEmpCardRetirement";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRSEmpCardRetirement_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRSEmpCardRetirement_FormClosed);
            this.Controls.SetChildIndex(this.rbNormal, 0);
            this.Controls.SetChildIndex(this.rbLoss, 0);
            this.Controls.SetChildIndex(this.btnReadCard, 0);
            this.Controls.SetChildIndex(this.txtFind, 0);
            this.Controls.SetChildIndex(this.lblFind, 0);
            this.Controls.SetChildIndex(this.btnSelectEmp, 0);
            this.Controls.SetChildIndex(this.btnFindEmp, 0);
            this.Controls.SetChildIndex(this.gbxEmpInfo, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtCardFee, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtReFee, 0);
            this.Controls.SetChildIndex(this.lblResult, 0);
            this.Controls.SetChildIndex(this.chkPrint, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.gbxEmpInfo.ResumeLayout(false);
            this.gbxEmpInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.RadioButton rbNormal;
    private System.Windows.Forms.RadioButton rbLoss;
    private System.Windows.Forms.Button btnReadCard;
    private System.Windows.Forms.Button btnFindEmp;
    private System.Windows.Forms.Button btnSelectEmp;
    private System.Windows.Forms.Label lblFind;
    private System.Windows.Forms.TextBox txtFind;
    private System.Windows.Forms.GroupBox gbxEmpInfo;
    private System.Windows.Forms.TextBox txtCardBalanceBT;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox txtCardType;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.TextBox txtCardUseDate;
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
    private System.Windows.Forms.TextBox txtReFee;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox txtCardFee;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label lblResult;
    private System.Windows.Forms.CheckBox chkPrint;
        private System.Windows.Forms.TextBox txtBT;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbBTNotget;
        private System.Windows.Forms.Label lbBTget;
    }
}
