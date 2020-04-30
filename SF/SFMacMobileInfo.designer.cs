namespace ECard78
{
  partial class frmSFMacMobileInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSFMacMobileInfo));
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.rbType1 = new System.Windows.Forms.RadioButton();
            this.gbxType1 = new System.Windows.Forms.GroupBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.lblIP = new System.Windows.Forms.Label();
            this.txtPWD = new System.Windows.Forms.TextBox();
            this.lblPWD = new System.Windows.Forms.Label();
            this.txtTrmNo = new System.Windows.Forms.TextBox();
            this.lblTrmNo = new System.Windows.Forms.Label();
            this.txtMercID = new System.Windows.Forms.TextBox();
            this.lblMercID = new System.Windows.Forms.Label();
            this.rbType2 = new System.Windows.Forms.RadioButton();
            this.gbxType2 = new System.Windows.Forms.GroupBox();
            this.txtXJLPWD = new System.Windows.Forms.TextBox();
            this.lblXJLPWD = new System.Windows.Forms.Label();
            this.txtXJLName = new System.Windows.Forms.TextBox();
            this.lblXJLName = new System.Windows.Forms.Label();
            this.gbxRate = new System.Windows.Forms.GroupBox();
            this.txtRate2 = new System.Windows.Forms.TextBox();
            this.lblRate21 = new System.Windows.Forms.Label();
            this.cbbRate2 = new System.Windows.Forms.ComboBox();
            this.lblRate20 = new System.Windows.Forms.Label();
            this.txtRate1 = new System.Windows.Forms.TextBox();
            this.lblRate11 = new System.Windows.Forms.Label();
            this.cbbRate1 = new System.Windows.Forms.ComboBox();
            this.lblRate10 = new System.Windows.Forms.Label();
            this.gbxWX = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.picWX = new System.Windows.Forms.PictureBox();
            this.gbxAli = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.picAli = new System.Windows.Forms.PictureBox();
            this.gbxType1.SuspendLayout();
            this.gbxType2.SuspendLayout();
            this.gbxRate.SuspendLayout();
            this.gbxWX.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWX)).BeginInit();
            this.gbxAli.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAli)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(460, 405);
            this.btnCancel.TabIndex = 1001;
            this.btnCancel.Text = "";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(380, 405);
            this.btnOk.TabIndex = 1000;
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
            // dlgOpen
            // 
            this.dlgOpen.Filter = "JPEG|*.jpg";
            // 
            // rbType1
            // 
            this.rbType1.AutoSize = true;
            this.rbType1.Location = new System.Drawing.Point(0, 0);
            this.rbType1.Name = "rbType1";
            this.rbType1.Size = new System.Drawing.Size(95, 16);
            this.rbType1.TabIndex = 0;
            this.rbType1.TabStop = true;
            this.rbType1.Text = "radioButton1";
            this.rbType1.UseVisualStyleBackColor = true;
            this.rbType1.Visible = false;
            // 
            // gbxType1
            // 
            this.gbxType1.Controls.Add(this.txtPort);
            this.gbxType1.Controls.Add(this.lblPort);
            this.gbxType1.Controls.Add(this.txtIP);
            this.gbxType1.Controls.Add(this.lblIP);
            this.gbxType1.Controls.Add(this.rbType1);
            this.gbxType1.Controls.Add(this.txtPWD);
            this.gbxType1.Controls.Add(this.lblPWD);
            this.gbxType1.Controls.Add(this.txtTrmNo);
            this.gbxType1.Controls.Add(this.lblTrmNo);
            this.gbxType1.Controls.Add(this.txtMercID);
            this.gbxType1.Controls.Add(this.lblMercID);
            this.gbxType1.Location = new System.Drawing.Point(12, 256);
            this.gbxType1.Name = "gbxType1";
            this.gbxType1.Size = new System.Drawing.Size(255, 174);
            this.gbxType1.TabIndex = 1;
            this.gbxType1.TabStop = false;
            this.gbxType1.Text = "groupBox1";
            this.gbxType1.Visible = false;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(90, 55);
            this.txtPort.MaxLength = 5;
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(150, 21);
            this.txtPort.TabIndex = 3;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(15, 59);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(41, 12);
            this.lblPort.TabIndex = 48;
            this.lblPort.Text = "label6";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(90, 25);
            this.txtIP.MaxLength = 16;
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(150, 21);
            this.txtIP.TabIndex = 2;
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(15, 29);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(41, 12);
            this.lblIP.TabIndex = 47;
            this.lblIP.Text = "label7";
            // 
            // txtPWD
            // 
            this.txtPWD.Location = new System.Drawing.Point(90, 146);
            this.txtPWD.MaxLength = 32;
            this.txtPWD.Name = "txtPWD";
            this.txtPWD.Size = new System.Drawing.Size(150, 21);
            this.txtPWD.TabIndex = 6;
            // 
            // lblPWD
            // 
            this.lblPWD.AutoSize = true;
            this.lblPWD.Location = new System.Drawing.Point(15, 150);
            this.lblPWD.Name = "lblPWD";
            this.lblPWD.Size = new System.Drawing.Size(41, 12);
            this.lblPWD.TabIndex = 44;
            this.lblPWD.Text = "label5";
            // 
            // txtTrmNo
            // 
            this.txtTrmNo.Location = new System.Drawing.Point(90, 116);
            this.txtTrmNo.MaxLength = 32;
            this.txtTrmNo.Name = "txtTrmNo";
            this.txtTrmNo.Size = new System.Drawing.Size(150, 21);
            this.txtTrmNo.TabIndex = 5;
            // 
            // lblTrmNo
            // 
            this.lblTrmNo.AutoSize = true;
            this.lblTrmNo.Location = new System.Drawing.Point(15, 120);
            this.lblTrmNo.Name = "lblTrmNo";
            this.lblTrmNo.Size = new System.Drawing.Size(41, 12);
            this.lblTrmNo.TabIndex = 43;
            this.lblTrmNo.Text = "label4";
            // 
            // txtMercID
            // 
            this.txtMercID.Location = new System.Drawing.Point(90, 86);
            this.txtMercID.MaxLength = 32;
            this.txtMercID.Name = "txtMercID";
            this.txtMercID.Size = new System.Drawing.Size(150, 21);
            this.txtMercID.TabIndex = 4;
            // 
            // lblMercID
            // 
            this.lblMercID.AutoSize = true;
            this.lblMercID.Location = new System.Drawing.Point(15, 90);
            this.lblMercID.Name = "lblMercID";
            this.lblMercID.Size = new System.Drawing.Size(41, 12);
            this.lblMercID.TabIndex = 42;
            this.lblMercID.Text = "label3";
            // 
            // rbType2
            // 
            this.rbType2.AutoSize = true;
            this.rbType2.Location = new System.Drawing.Point(12, 12);
            this.rbType2.Name = "rbType2";
            this.rbType2.Size = new System.Drawing.Size(95, 16);
            this.rbType2.TabIndex = 7;
            this.rbType2.TabStop = true;
            this.rbType2.Tag = "rbType1";
            this.rbType2.Text = "radioButton1";
            this.rbType2.UseVisualStyleBackColor = true;
            // 
            // gbxType2
            // 
            this.gbxType2.Controls.Add(this.txtXJLPWD);
            this.gbxType2.Controls.Add(this.lblXJLPWD);
            this.gbxType2.Controls.Add(this.txtXJLName);
            this.gbxType2.Controls.Add(this.lblXJLName);
            this.gbxType2.Location = new System.Drawing.Point(10, 43);
            this.gbxType2.Name = "gbxType2";
            this.gbxType2.Size = new System.Drawing.Size(255, 90);
            this.gbxType2.TabIndex = 8;
            this.gbxType2.TabStop = false;
            this.gbxType2.Text = "groupBox1";
            // 
            // txtXJLPWD
            // 
            this.txtXJLPWD.Location = new System.Drawing.Point(90, 55);
            this.txtXJLPWD.MaxLength = 32;
            this.txtXJLPWD.Name = "txtXJLPWD";
            this.txtXJLPWD.Size = new System.Drawing.Size(150, 21);
            this.txtXJLPWD.TabIndex = 10;
            // 
            // lblXJLPWD
            // 
            this.lblXJLPWD.AutoSize = true;
            this.lblXJLPWD.Location = new System.Drawing.Point(15, 59);
            this.lblXJLPWD.Name = "lblXJLPWD";
            this.lblXJLPWD.Size = new System.Drawing.Size(41, 12);
            this.lblXJLPWD.TabIndex = 46;
            this.lblXJLPWD.Text = "label2";
            // 
            // txtXJLName
            // 
            this.txtXJLName.Location = new System.Drawing.Point(90, 25);
            this.txtXJLName.MaxLength = 32;
            this.txtXJLName.Name = "txtXJLName";
            this.txtXJLName.Size = new System.Drawing.Size(150, 21);
            this.txtXJLName.TabIndex = 9;
            // 
            // lblXJLName
            // 
            this.lblXJLName.AutoSize = true;
            this.lblXJLName.Location = new System.Drawing.Point(15, 29);
            this.lblXJLName.Name = "lblXJLName";
            this.lblXJLName.Size = new System.Drawing.Size(41, 12);
            this.lblXJLName.TabIndex = 44;
            this.lblXJLName.Text = "label1";
            // 
            // gbxRate
            // 
            this.gbxRate.Controls.Add(this.txtRate2);
            this.gbxRate.Controls.Add(this.lblRate21);
            this.gbxRate.Controls.Add(this.cbbRate2);
            this.gbxRate.Controls.Add(this.lblRate20);
            this.gbxRate.Controls.Add(this.txtRate1);
            this.gbxRate.Controls.Add(this.lblRate11);
            this.gbxRate.Controls.Add(this.cbbRate1);
            this.gbxRate.Controls.Add(this.lblRate10);
            this.gbxRate.Location = new System.Drawing.Point(10, 160);
            this.gbxRate.Name = "gbxRate";
            this.gbxRate.Size = new System.Drawing.Size(255, 90);
            this.gbxRate.TabIndex = 11;
            this.gbxRate.TabStop = false;
            this.gbxRate.Text = "groupBox2";
            // 
            // txtRate2
            // 
            this.txtRate2.Location = new System.Drawing.Point(200, 55);
            this.txtRate2.MaxLength = 32;
            this.txtRate2.Name = "txtRate2";
            this.txtRate2.Size = new System.Drawing.Size(40, 21);
            this.txtRate2.TabIndex = 15;
            // 
            // lblRate21
            // 
            this.lblRate21.Location = new System.Drawing.Point(155, 59);
            this.lblRate21.Name = "lblRate21";
            this.lblRate21.Size = new System.Drawing.Size(40, 12);
            this.lblRate21.TabIndex = 61;
            this.lblRate21.Tag = "Rate";
            this.lblRate21.Text = "label8";
            this.lblRate21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbbRate2
            // 
            this.cbbRate2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbRate2.FormattingEnabled = true;
            this.cbbRate2.Location = new System.Drawing.Point(90, 55);
            this.cbbRate2.Name = "cbbRate2";
            this.cbbRate2.Size = new System.Drawing.Size(60, 20);
            this.cbbRate2.TabIndex = 14;
            // 
            // lblRate20
            // 
            this.lblRate20.AutoSize = true;
            this.lblRate20.Location = new System.Drawing.Point(15, 59);
            this.lblRate20.Name = "lblRate20";
            this.lblRate20.Size = new System.Drawing.Size(41, 12);
            this.lblRate20.TabIndex = 60;
            this.lblRate20.Text = "label8";
            // 
            // txtRate1
            // 
            this.txtRate1.Location = new System.Drawing.Point(200, 25);
            this.txtRate1.MaxLength = 32;
            this.txtRate1.Name = "txtRate1";
            this.txtRate1.Size = new System.Drawing.Size(40, 21);
            this.txtRate1.TabIndex = 13;
            // 
            // lblRate11
            // 
            this.lblRate11.Location = new System.Drawing.Point(155, 29);
            this.lblRate11.Name = "lblRate11";
            this.lblRate11.Size = new System.Drawing.Size(40, 12);
            this.lblRate11.TabIndex = 59;
            this.lblRate11.Tag = "Rate";
            this.lblRate11.Text = "label8";
            this.lblRate11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbbRate1
            // 
            this.cbbRate1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbRate1.FormattingEnabled = true;
            this.cbbRate1.Location = new System.Drawing.Point(90, 25);
            this.cbbRate1.Name = "cbbRate1";
            this.cbbRate1.Size = new System.Drawing.Size(60, 20);
            this.cbbRate1.TabIndex = 12;
            // 
            // lblRate10
            // 
            this.lblRate10.AutoSize = true;
            this.lblRate10.Location = new System.Drawing.Point(15, 29);
            this.lblRate10.Name = "lblRate10";
            this.lblRate10.Size = new System.Drawing.Size(41, 12);
            this.lblRate10.TabIndex = 58;
            this.lblRate10.Text = "label7";
            // 
            // gbxWX
            // 
            this.gbxWX.Controls.Add(this.button2);
            this.gbxWX.Controls.Add(this.button1);
            this.gbxWX.Controls.Add(this.picWX);
            this.gbxWX.Location = new System.Drawing.Point(280, 10);
            this.gbxWX.Name = "gbxWX";
            this.gbxWX.Size = new System.Drawing.Size(250, 185);
            this.gbxWX.TabIndex = 16;
            this.gbxWX.TabStop = false;
            this.gbxWX.Text = "groupBox1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(170, 50);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 25);
            this.button2.TabIndex = 18;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(170, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 25);
            this.button1.TabIndex = 17;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // picWX
            // 
            this.picWX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picWX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picWX.Location = new System.Drawing.Point(15, 20);
            this.picWX.Name = "picWX";
            this.picWX.Size = new System.Drawing.Size(150, 150);
            this.picWX.TabIndex = 52;
            this.picWX.TabStop = false;
            // 
            // gbxAli
            // 
            this.gbxAli.Controls.Add(this.button4);
            this.gbxAli.Controls.Add(this.button3);
            this.gbxAli.Controls.Add(this.picAli);
            this.gbxAli.Location = new System.Drawing.Point(280, 205);
            this.gbxAli.Name = "gbxAli";
            this.gbxAli.Size = new System.Drawing.Size(250, 185);
            this.gbxAli.TabIndex = 19;
            this.gbxAli.TabStop = false;
            this.gbxAli.Text = "groupBox1";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(170, 50);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(65, 25);
            this.button4.TabIndex = 21;
            this.button4.Text = "button3";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(170, 20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(65, 25);
            this.button3.TabIndex = 20;
            this.button3.Text = "button4";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // picAli
            // 
            this.picAli.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picAli.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picAli.Location = new System.Drawing.Point(15, 20);
            this.picAli.Name = "picAli";
            this.picAli.Size = new System.Drawing.Size(150, 150);
            this.picAli.TabIndex = 52;
            this.picAli.TabStop = false;
            // 
            // frmSFMacMobileInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(544, 437);
            this.Controls.Add(this.gbxAli);
            this.Controls.Add(this.gbxWX);
            this.Controls.Add(this.gbxRate);
            this.Controls.Add(this.rbType2);
            this.Controls.Add(this.gbxType1);
            this.Controls.Add(this.gbxType2);
            this.Name = "frmSFMacMobileInfo";
            this.Controls.SetChildIndex(this.gbxType2, 0);
            this.Controls.SetChildIndex(this.gbxType1, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.rbType2, 0);
            this.Controls.SetChildIndex(this.gbxRate, 0);
            this.Controls.SetChildIndex(this.gbxWX, 0);
            this.Controls.SetChildIndex(this.gbxAli, 0);
            this.gbxType1.ResumeLayout(false);
            this.gbxType1.PerformLayout();
            this.gbxType2.ResumeLayout(false);
            this.gbxType2.PerformLayout();
            this.gbxRate.ResumeLayout(false);
            this.gbxRate.PerformLayout();
            this.gbxWX.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picWX)).EndInit();
            this.gbxAli.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAli)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.OpenFileDialog dlgOpen;
    private System.Windows.Forms.RadioButton rbType1;
    private System.Windows.Forms.GroupBox gbxType1;
    private System.Windows.Forms.TextBox txtPort;
    private System.Windows.Forms.Label lblPort;
    private System.Windows.Forms.TextBox txtIP;
    private System.Windows.Forms.Label lblIP;
    private System.Windows.Forms.TextBox txtPWD;
    private System.Windows.Forms.Label lblPWD;
    private System.Windows.Forms.TextBox txtTrmNo;
    private System.Windows.Forms.Label lblTrmNo;
    private System.Windows.Forms.TextBox txtMercID;
    private System.Windows.Forms.Label lblMercID;
    private System.Windows.Forms.RadioButton rbType2;
    private System.Windows.Forms.GroupBox gbxType2;
    private System.Windows.Forms.TextBox txtXJLPWD;
    private System.Windows.Forms.Label lblXJLPWD;
    private System.Windows.Forms.TextBox txtXJLName;
    private System.Windows.Forms.Label lblXJLName;
    private System.Windows.Forms.GroupBox gbxRate;
    private System.Windows.Forms.TextBox txtRate2;
    private System.Windows.Forms.Label lblRate21;
    private System.Windows.Forms.ComboBox cbbRate2;
    private System.Windows.Forms.Label lblRate20;
    private System.Windows.Forms.TextBox txtRate1;
    private System.Windows.Forms.Label lblRate11;
    private System.Windows.Forms.ComboBox cbbRate1;
    private System.Windows.Forms.Label lblRate10;
    private System.Windows.Forms.GroupBox gbxWX;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.PictureBox picWX;
    private System.Windows.Forms.GroupBox gbxAli;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.PictureBox picAli;


  }
}
