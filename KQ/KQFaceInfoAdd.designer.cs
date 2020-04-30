namespace ECard78
{
  partial class frmKQFaceInfoAdd
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKQFaceInfoAdd));
      this.lblMacSN = new System.Windows.Forms.Label();
      this.txtMacSN = new System.Windows.Forms.TextBox();
      this.rbUSB = new System.Windows.Forms.RadioButton();
      this.rbComm = new System.Windows.Forms.RadioButton();
      this.lblCommPort = new System.Windows.Forms.Label();
      this.cbbCommPort = new System.Windows.Forms.ComboBox();
      this.lblCommBaudRate = new System.Windows.Forms.Label();
      this.cbbCommBaudRate = new System.Windows.Forms.ComboBox();
      this.rbLAN = new System.Windows.Forms.RadioButton();
      this.pnlComm = new System.Windows.Forms.Panel();
      this.pnlLAN = new System.Windows.Forms.Panel();
      this.chkGPRS = new System.Windows.Forms.CheckBox();
      this.txtLANPort = new System.Windows.Forms.TextBox();
      this.lblLANPort = new System.Windows.Forms.Label();
      this.txtLANIP = new System.Windows.Forms.TextBox();
      this.lblLANIP = new System.Windows.Forms.Label();
      this.btnTestConnect = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.txtDesc = new System.Windows.Forms.TextBox();
      this.pnlComm.SuspendLayout();
      this.pnlLAN.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(375, 229);
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(295, 229);
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
      // lblMacSN
      // 
      this.lblMacSN.AutoSize = true;
      this.lblMacSN.Location = new System.Drawing.Point(10, 14);
      this.lblMacSN.Name = "lblMacSN";
      this.lblMacSN.Size = new System.Drawing.Size(41, 12);
      this.lblMacSN.TabIndex = 19;
      this.lblMacSN.Tag = "MacSN";
      this.lblMacSN.Text = "label1";
      // 
      // txtMacSN
      // 
      this.txtMacSN.Location = new System.Drawing.Point(100, 10);
      this.txtMacSN.MaxLength = 3;
      this.txtMacSN.Name = "txtMacSN";
      this.txtMacSN.Size = new System.Drawing.Size(120, 21);
      this.txtMacSN.TabIndex = 0;
      // 
      // rbUSB
      // 
      this.rbUSB.AutoSize = true;
      this.rbUSB.Checked = true;
      this.rbUSB.Location = new System.Drawing.Point(10, 35);
      this.rbUSB.Name = "rbUSB";
      this.rbUSB.Size = new System.Drawing.Size(95, 16);
      this.rbUSB.TabIndex = 2;
      this.rbUSB.TabStop = true;
      this.rbUSB.Text = "radioButton1";
      this.rbUSB.UseVisualStyleBackColor = true;
      this.rbUSB.Click += new System.EventHandler(this.RadioButton_Click);
      // 
      // rbComm
      // 
      this.rbComm.AutoSize = true;
      this.rbComm.Location = new System.Drawing.Point(10, 60);
      this.rbComm.Name = "rbComm";
      this.rbComm.Size = new System.Drawing.Size(95, 16);
      this.rbComm.TabIndex = 3;
      this.rbComm.Text = "radioButton1";
      this.rbComm.UseVisualStyleBackColor = true;
      this.rbComm.Click += new System.EventHandler(this.RadioButton_Click);
      // 
      // lblCommPort
      // 
      this.lblCommPort.AutoSize = true;
      this.lblCommPort.Location = new System.Drawing.Point(0, 4);
      this.lblCommPort.Name = "lblCommPort";
      this.lblCommPort.Size = new System.Drawing.Size(41, 12);
      this.lblCommPort.TabIndex = 25;
      this.lblCommPort.Text = "label1";
      // 
      // cbbCommPort
      // 
      this.cbbCommPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbCommPort.FormattingEnabled = true;
      this.cbbCommPort.Location = new System.Drawing.Point(90, 0);
      this.cbbCommPort.Name = "cbbCommPort";
      this.cbbCommPort.Size = new System.Drawing.Size(120, 20);
      this.cbbCommPort.TabIndex = 4;
      // 
      // lblCommBaudRate
      // 
      this.lblCommBaudRate.AutoSize = true;
      this.lblCommBaudRate.Location = new System.Drawing.Point(230, 4);
      this.lblCommBaudRate.Name = "lblCommBaudRate";
      this.lblCommBaudRate.Size = new System.Drawing.Size(41, 12);
      this.lblCommBaudRate.TabIndex = 27;
      this.lblCommBaudRate.Text = "label1";
      // 
      // cbbCommBaudRate
      // 
      this.cbbCommBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbCommBaudRate.FormattingEnabled = true;
      this.cbbCommBaudRate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600"});
      this.cbbCommBaudRate.Location = new System.Drawing.Point(320, 0);
      this.cbbCommBaudRate.Name = "cbbCommBaudRate";
      this.cbbCommBaudRate.Size = new System.Drawing.Size(120, 20);
      this.cbbCommBaudRate.TabIndex = 5;
      // 
      // rbLAN
      // 
      this.rbLAN.AutoSize = true;
      this.rbLAN.Location = new System.Drawing.Point(10, 110);
      this.rbLAN.Name = "rbLAN";
      this.rbLAN.Size = new System.Drawing.Size(95, 16);
      this.rbLAN.TabIndex = 6;
      this.rbLAN.Text = "radioButton1";
      this.rbLAN.UseVisualStyleBackColor = true;
      this.rbLAN.Click += new System.EventHandler(this.RadioButton_Click);
      // 
      // pnlComm
      // 
      this.pnlComm.Controls.Add(this.lblCommPort);
      this.pnlComm.Controls.Add(this.cbbCommPort);
      this.pnlComm.Controls.Add(this.cbbCommBaudRate);
      this.pnlComm.Controls.Add(this.lblCommBaudRate);
      this.pnlComm.Location = new System.Drawing.Point(10, 80);
      this.pnlComm.Name = "pnlComm";
      this.pnlComm.Size = new System.Drawing.Size(445, 25);
      this.pnlComm.TabIndex = 30;
      // 
      // pnlLAN
      // 
      this.pnlLAN.Controls.Add(this.chkGPRS);
      this.pnlLAN.Controls.Add(this.txtLANPort);
      this.pnlLAN.Controls.Add(this.lblLANPort);
      this.pnlLAN.Controls.Add(this.txtLANIP);
      this.pnlLAN.Controls.Add(this.lblLANIP);
      this.pnlLAN.Location = new System.Drawing.Point(10, 130);
      this.pnlLAN.Name = "pnlLAN";
      this.pnlLAN.Size = new System.Drawing.Size(445, 55);
      this.pnlLAN.TabIndex = 31;
      // 
      // chkGPRS
      // 
      this.chkGPRS.AutoSize = true;
      this.chkGPRS.Location = new System.Drawing.Point(90, 30);
      this.chkGPRS.Name = "chkGPRS";
      this.chkGPRS.Size = new System.Drawing.Size(78, 16);
      this.chkGPRS.TabIndex = 9;
      this.chkGPRS.Tag = "IsGPRS";
      this.chkGPRS.Text = "checkBox1";
      this.chkGPRS.UseVisualStyleBackColor = true;
      // 
      // txtLANPort
      // 
      this.txtLANPort.Location = new System.Drawing.Point(320, 0);
      this.txtLANPort.MaxLength = 6;
      this.txtLANPort.Name = "txtLANPort";
      this.txtLANPort.Size = new System.Drawing.Size(120, 21);
      this.txtLANPort.TabIndex = 8;
      // 
      // lblLANPort
      // 
      this.lblLANPort.AutoSize = true;
      this.lblLANPort.Location = new System.Drawing.Point(230, 4);
      this.lblLANPort.Name = "lblLANPort";
      this.lblLANPort.Size = new System.Drawing.Size(41, 12);
      this.lblLANPort.TabIndex = 2;
      this.lblLANPort.Tag = "MacPort";
      this.lblLANPort.Text = "label2";
      // 
      // txtLANIP
      // 
      this.txtLANIP.Location = new System.Drawing.Point(90, 0);
      this.txtLANIP.MaxLength = 50;
      this.txtLANIP.Name = "txtLANIP";
      this.txtLANIP.Size = new System.Drawing.Size(120, 21);
      this.txtLANIP.TabIndex = 7;
      // 
      // lblLANIP
      // 
      this.lblLANIP.AutoSize = true;
      this.lblLANIP.Location = new System.Drawing.Point(0, 4);
      this.lblLANIP.Name = "lblLANIP";
      this.lblLANIP.Size = new System.Drawing.Size(41, 12);
      this.lblLANIP.TabIndex = 0;
      this.lblLANIP.Tag = "MacIPAddress";
      this.lblLANIP.Text = "label1";
      // 
      // btnTestConnect
      // 
      this.btnTestConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnTestConnect.Location = new System.Drawing.Point(10, 229);
      this.btnTestConnect.Name = "btnTestConnect";
      this.btnTestConnect.Size = new System.Drawing.Size(75, 25);
      this.btnTestConnect.TabIndex = 15;
      this.btnTestConnect.Text = "button1";
      this.btnTestConnect.UseVisualStyleBackColor = true;
      this.btnTestConnect.Click += new System.EventHandler(this.btnTestConnect_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(10, 199);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 12);
      this.label1.TabIndex = 34;
      this.label1.Tag = "MacDesc";
      this.label1.Text = "label1";
      // 
      // txtDesc
      // 
      this.txtDesc.Location = new System.Drawing.Point(100, 195);
      this.txtDesc.MaxLength = 100;
      this.txtDesc.Name = "txtDesc";
      this.txtDesc.Size = new System.Drawing.Size(350, 21);
      this.txtDesc.TabIndex = 10;
      // 
      // frmKQFaceInfoAdd
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(459, 262);
      this.Controls.Add(this.txtDesc);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btnTestConnect);
      this.Controls.Add(this.pnlLAN);
      this.Controls.Add(this.pnlComm);
      this.Controls.Add(this.rbLAN);
      this.Controls.Add(this.rbComm);
      this.Controls.Add(this.rbUSB);
      this.Controls.Add(this.txtMacSN);
      this.Controls.Add(this.lblMacSN);
      this.Name = "frmKQFaceInfoAdd";
      this.Controls.SetChildIndex(this.lblMacSN, 0);
      this.Controls.SetChildIndex(this.txtMacSN, 0);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.Controls.SetChildIndex(this.rbUSB, 0);
      this.Controls.SetChildIndex(this.rbComm, 0);
      this.Controls.SetChildIndex(this.rbLAN, 0);
      this.Controls.SetChildIndex(this.pnlComm, 0);
      this.Controls.SetChildIndex(this.pnlLAN, 0);
      this.Controls.SetChildIndex(this.btnTestConnect, 0);
      this.Controls.SetChildIndex(this.label1, 0);
      this.Controls.SetChildIndex(this.txtDesc, 0);
      this.pnlComm.ResumeLayout(false);
      this.pnlComm.PerformLayout();
      this.pnlLAN.ResumeLayout(false);
      this.pnlLAN.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblMacSN;
    private System.Windows.Forms.TextBox txtMacSN;
    private System.Windows.Forms.RadioButton rbUSB;
    private System.Windows.Forms.RadioButton rbComm;
    private System.Windows.Forms.Label lblCommPort;
    private System.Windows.Forms.ComboBox cbbCommPort;
    private System.Windows.Forms.Label lblCommBaudRate;
    private System.Windows.Forms.ComboBox cbbCommBaudRate;
    private System.Windows.Forms.RadioButton rbLAN;
    private System.Windows.Forms.Panel pnlComm;
    private System.Windows.Forms.Panel pnlLAN;
    private System.Windows.Forms.TextBox txtLANPort;
    private System.Windows.Forms.Label lblLANPort;
    private System.Windows.Forms.TextBox txtLANIP;
    private System.Windows.Forms.Label lblLANIP;
    private System.Windows.Forms.Button btnTestConnect;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtDesc;
    private System.Windows.Forms.CheckBox chkGPRS;
  }
}
