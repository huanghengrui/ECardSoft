namespace ECard78
{
  partial class frmRSEmpCardModify
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
      this.txtEmpNo = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.txtEmpName = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtCardPWD = new System.Windows.Forms.TextBox();
      this.label16 = new System.Windows.Forms.Label();
      this.txtCardSectorNo = new System.Windows.Forms.TextBox();
      this.label12 = new System.Windows.Forms.Label();
      this.cbbCardType = new System.Windows.Forms.ComboBox();
      this.label11 = new System.Windows.Forms.Label();
      this.txtCardPWDA = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.btnSelectCardEndDate = new System.Windows.Forms.Button();
      this.btnSelectCardStartDate = new System.Windows.Forms.Button();
      this.txtCardEndDate = new System.Windows.Forms.TextBox();
      this.label14 = new System.Windows.Forms.Label();
      this.txtCardStartDate = new System.Windows.Forms.TextBox();
      this.label13 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.txtDepartName = new System.Windows.Forms.TextBox();
      this.txtCardStatusName = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.txtFaDate = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.txtSFCardBalance = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.btnReadCard = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(375, 195);
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(295, 195);
      this.btnOk.Text = "";
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // txtEmpNo
      // 
      this.txtEmpNo.Location = new System.Drawing.Point(100, 10);
      this.txtEmpNo.MaxLength = 20;
      this.txtEmpNo.Name = "txtEmpNo";
      this.txtEmpNo.Size = new System.Drawing.Size(120, 21);
      this.txtEmpNo.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(10, 14);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 12);
      this.label1.TabIndex = 24;
      this.label1.Tag = "EmpNo";
      this.label1.Text = "label1";
      // 
      // txtEmpName
      // 
      this.txtEmpName.Location = new System.Drawing.Point(330, 10);
      this.txtEmpName.MaxLength = 50;
      this.txtEmpName.Name = "txtEmpName";
      this.txtEmpName.Size = new System.Drawing.Size(120, 21);
      this.txtEmpName.TabIndex = 1;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(240, 14);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(41, 12);
      this.label2.TabIndex = 25;
      this.label2.Tag = "EmpName";
      this.label2.Text = "label2";
      // 
      // txtCardPWD
      // 
      this.txtCardPWD.Location = new System.Drawing.Point(100, 70);
      this.txtCardPWD.MaxLength = 6;
      this.txtCardPWD.Name = "txtCardPWD";
      this.txtCardPWD.PasswordChar = '*';
      this.txtCardPWD.Size = new System.Drawing.Size(120, 21);
      this.txtCardPWD.TabIndex = 4;
      // 
      // label16
      // 
      this.label16.AutoSize = true;
      this.label16.Location = new System.Drawing.Point(10, 74);
      this.label16.Name = "label16";
      this.label16.Size = new System.Drawing.Size(47, 12);
      this.label16.TabIndex = 56;
      this.label16.Tag = "CardPWD";
      this.label16.Text = "label16";
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
      this.label12.TabIndex = 55;
      this.label12.Tag = "CardSectorNo";
      this.label12.Text = "label12";
      // 
      // cbbCardType
      // 
      this.cbbCardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbCardType.FormattingEnabled = true;
      this.cbbCardType.Location = new System.Drawing.Point(100, 40);
      this.cbbCardType.Name = "cbbCardType";
      this.cbbCardType.Size = new System.Drawing.Size(120, 20);
      this.cbbCardType.TabIndex = 2;
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(10, 44);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(47, 12);
      this.label11.TabIndex = 58;
      this.label11.Tag = "CardType";
      this.label11.Text = "label11";
      // 
      // txtCardPWDA
      // 
      this.txtCardPWDA.Location = new System.Drawing.Point(330, 70);
      this.txtCardPWDA.MaxLength = 6;
      this.txtCardPWDA.Name = "txtCardPWDA";
      this.txtCardPWDA.PasswordChar = '*';
      this.txtCardPWDA.Size = new System.Drawing.Size(120, 21);
      this.txtCardPWDA.TabIndex = 5;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(240, 74);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(41, 12);
      this.label3.TabIndex = 60;
      this.label3.Tag = "CardSectorNo";
      this.label3.Text = "label3";
      // 
      // btnSelectCardEndDate
      // 
      this.btnSelectCardEndDate.Location = new System.Drawing.Point(415, 101);
      this.btnSelectCardEndDate.Name = "btnSelectCardEndDate";
      this.btnSelectCardEndDate.Size = new System.Drawing.Size(34, 19);
      this.btnSelectCardEndDate.TabIndex = 9;
      this.btnSelectCardEndDate.Text = "...";
      this.btnSelectCardEndDate.UseVisualStyleBackColor = true;
      this.btnSelectCardEndDate.Click += new System.EventHandler(this.btnSelectCardEndDate_Click);
      // 
      // btnSelectCardStartDate
      // 
      this.btnSelectCardStartDate.Location = new System.Drawing.Point(185, 101);
      this.btnSelectCardStartDate.Name = "btnSelectCardStartDate";
      this.btnSelectCardStartDate.Size = new System.Drawing.Size(34, 19);
      this.btnSelectCardStartDate.TabIndex = 7;
      this.btnSelectCardStartDate.Text = "...";
      this.btnSelectCardStartDate.UseVisualStyleBackColor = true;
      this.btnSelectCardStartDate.Click += new System.EventHandler(this.btnSelectCardStartDate_Click);
      // 
      // txtCardEndDate
      // 
      this.txtCardEndDate.Location = new System.Drawing.Point(330, 100);
      this.txtCardEndDate.Name = "txtCardEndDate";
      this.txtCardEndDate.Size = new System.Drawing.Size(120, 21);
      this.txtCardEndDate.TabIndex = 8;
      // 
      // label14
      // 
      this.label14.AutoSize = true;
      this.label14.Location = new System.Drawing.Point(240, 104);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(47, 12);
      this.label14.TabIndex = 66;
      this.label14.Tag = "CardEndDate";
      this.label14.Text = "label14";
      // 
      // txtCardStartDate
      // 
      this.txtCardStartDate.Location = new System.Drawing.Point(100, 100);
      this.txtCardStartDate.Name = "txtCardStartDate";
      this.txtCardStartDate.Size = new System.Drawing.Size(120, 21);
      this.txtCardStartDate.TabIndex = 6;
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Location = new System.Drawing.Point(10, 104);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(47, 12);
      this.label13.TabIndex = 65;
      this.label13.Tag = "CardStartDate";
      this.label13.Text = "label13";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(10, 134);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(41, 12);
      this.label4.TabIndex = 67;
      this.label4.Tag = "Depart";
      this.label4.Text = "label4";
      // 
      // txtDepartName
      // 
      this.txtDepartName.Location = new System.Drawing.Point(100, 130);
      this.txtDepartName.Name = "txtDepartName";
      this.txtDepartName.ReadOnly = true;
      this.txtDepartName.Size = new System.Drawing.Size(120, 21);
      this.txtDepartName.TabIndex = 10;
      // 
      // txtCardStatusName
      // 
      this.txtCardStatusName.Location = new System.Drawing.Point(330, 130);
      this.txtCardStatusName.Name = "txtCardStatusName";
      this.txtCardStatusName.ReadOnly = true;
      this.txtCardStatusName.Size = new System.Drawing.Size(120, 21);
      this.txtCardStatusName.TabIndex = 11;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(240, 134);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(41, 12);
      this.label5.TabIndex = 69;
      this.label5.Tag = "CardStatusName";
      this.label5.Text = "label5";
      // 
      // txtFaDate
      // 
      this.txtFaDate.Location = new System.Drawing.Point(100, 160);
      this.txtFaDate.Name = "txtFaDate";
      this.txtFaDate.ReadOnly = true;
      this.txtFaDate.Size = new System.Drawing.Size(120, 21);
      this.txtFaDate.TabIndex = 12;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(10, 164);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(41, 12);
      this.label6.TabIndex = 71;
      this.label6.Tag = "FaDate";
      this.label6.Text = "label6";
      // 
      // txtSFCardBalance
      // 
      this.txtSFCardBalance.Location = new System.Drawing.Point(330, 160);
      this.txtSFCardBalance.Name = "txtSFCardBalance";
      this.txtSFCardBalance.ReadOnly = true;
      this.txtSFCardBalance.Size = new System.Drawing.Size(120, 21);
      this.txtSFCardBalance.TabIndex = 13;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(240, 164);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(41, 12);
      this.label7.TabIndex = 73;
      this.label7.Tag = "SFCardBalance";
      this.label7.Text = "label7";
      // 
      // btnReadCard
      // 
      this.btnReadCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnReadCard.Location = new System.Drawing.Point(10, 195);
      this.btnReadCard.Name = "btnReadCard";
      this.btnReadCard.Size = new System.Drawing.Size(75, 25);
      this.btnReadCard.TabIndex = 14;
      this.btnReadCard.Text = "button1";
      this.btnReadCard.UseVisualStyleBackColor = true;
      this.btnReadCard.Click += new System.EventHandler(this.btnReadCard_Click);
      // 
      // frmRSEmpCardModify
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(459, 228);
      this.Controls.Add(this.btnReadCard);
      this.Controls.Add(this.txtSFCardBalance);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.txtFaDate);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.txtCardStatusName);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.txtDepartName);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.btnSelectCardEndDate);
      this.Controls.Add(this.btnSelectCardStartDate);
      this.Controls.Add(this.txtCardEndDate);
      this.Controls.Add(this.label14);
      this.Controls.Add(this.txtCardStartDate);
      this.Controls.Add(this.label13);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txtCardPWDA);
      this.Controls.Add(this.cbbCardType);
      this.Controls.Add(this.label11);
      this.Controls.Add(this.txtCardPWD);
      this.Controls.Add(this.label16);
      this.Controls.Add(this.txtCardSectorNo);
      this.Controls.Add(this.label12);
      this.Controls.Add(this.txtEmpNo);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtEmpName);
      this.Controls.Add(this.label2);
      this.Name = "frmRSEmpCardModify";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRSEmpCardModify_FormClosing);
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRSEmpCardModify_FormClosed);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.Controls.SetChildIndex(this.label2, 0);
      this.Controls.SetChildIndex(this.txtEmpName, 0);
      this.Controls.SetChildIndex(this.label1, 0);
      this.Controls.SetChildIndex(this.txtEmpNo, 0);
      this.Controls.SetChildIndex(this.label12, 0);
      this.Controls.SetChildIndex(this.txtCardSectorNo, 0);
      this.Controls.SetChildIndex(this.label16, 0);
      this.Controls.SetChildIndex(this.txtCardPWD, 0);
      this.Controls.SetChildIndex(this.label11, 0);
      this.Controls.SetChildIndex(this.cbbCardType, 0);
      this.Controls.SetChildIndex(this.txtCardPWDA, 0);
      this.Controls.SetChildIndex(this.label3, 0);
      this.Controls.SetChildIndex(this.label13, 0);
      this.Controls.SetChildIndex(this.txtCardStartDate, 0);
      this.Controls.SetChildIndex(this.label14, 0);
      this.Controls.SetChildIndex(this.txtCardEndDate, 0);
      this.Controls.SetChildIndex(this.btnSelectCardStartDate, 0);
      this.Controls.SetChildIndex(this.btnSelectCardEndDate, 0);
      this.Controls.SetChildIndex(this.label4, 0);
      this.Controls.SetChildIndex(this.txtDepartName, 0);
      this.Controls.SetChildIndex(this.label5, 0);
      this.Controls.SetChildIndex(this.txtCardStatusName, 0);
      this.Controls.SetChildIndex(this.label6, 0);
      this.Controls.SetChildIndex(this.txtFaDate, 0);
      this.Controls.SetChildIndex(this.label7, 0);
      this.Controls.SetChildIndex(this.txtSFCardBalance, 0);
      this.Controls.SetChildIndex(this.btnReadCard, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtEmpNo;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtEmpName;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtCardPWD;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.TextBox txtCardSectorNo;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.ComboBox cbbCardType;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.TextBox txtCardPWDA;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button btnSelectCardEndDate;
    private System.Windows.Forms.Button btnSelectCardStartDate;
    private System.Windows.Forms.TextBox txtCardEndDate;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.TextBox txtCardStartDate;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtDepartName;
    private System.Windows.Forms.TextBox txtCardStatusName;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtFaDate;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txtSFCardBalance;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Button btnReadCard;

  }
}
