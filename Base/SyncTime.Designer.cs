namespace ECard78
{
  partial class frmSyncTime
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSyncTime));
      this.cbbMacType = new System.Windows.Forms.ComboBox();
      this.lblMacType = new System.Windows.Forms.Label();
      this.txtMacSN = new System.Windows.Forms.TextBox();
      this.lblMacSN = new System.Windows.Forms.Label();
      this.pnlWAN = new System.Windows.Forms.Panel();
      this.txtWANAddress = new System.Windows.Forms.TextBox();
      this.lblWANAddress = new System.Windows.Forms.Label();
      this.txtWANPort = new System.Windows.Forms.TextBox();
      this.lblWANPort = new System.Windows.Forms.Label();
      this.txtWANIP = new System.Windows.Forms.TextBox();
      this.lblWANIP = new System.Windows.Forms.Label();
      this.rbWAN = new System.Windows.Forms.RadioButton();
      this.pnlLAN = new System.Windows.Forms.Panel();
      this.txtLANPort = new System.Windows.Forms.TextBox();
      this.lblLANPort = new System.Windows.Forms.Label();
      this.txtLANIP = new System.Windows.Forms.TextBox();
      this.lblLANIP = new System.Windows.Forms.Label();
      this.pnlComm = new System.Windows.Forms.Panel();
      this.lblCommPort = new System.Windows.Forms.Label();
      this.cbbCommPort = new System.Windows.Forms.ComboBox();
      this.cbbCommBaudRate = new System.Windows.Forms.ComboBox();
      this.lblCommBaudRate = new System.Windows.Forms.Label();
      this.rbLAN = new System.Windows.Forms.RadioButton();
      this.rbComm = new System.Windows.Forms.RadioButton();
      this.rbUSB = new System.Windows.Forms.RadioButton();
      this.btnOk = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.pnlWAN.SuspendLayout();
      this.pnlLAN.SuspendLayout();
      this.pnlComm.SuspendLayout();
      this.SuspendLayout();
      // 
      // ilTreeState
      // 
      this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
      this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
      this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
      this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
      // 
      // cbbMacType
      // 
      this.cbbMacType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbMacType.FormattingEnabled = true;
      this.cbbMacType.Location = new System.Drawing.Point(330, 10);
      this.cbbMacType.Name = "cbbMacType";
      this.cbbMacType.Size = new System.Drawing.Size(121, 20);
      this.cbbMacType.TabIndex = 23;
      // 
      // lblMacType
      // 
      this.lblMacType.AutoSize = true;
      this.lblMacType.Location = new System.Drawing.Point(240, 14);
      this.lblMacType.Name = "lblMacType";
      this.lblMacType.Size = new System.Drawing.Size(41, 12);
      this.lblMacType.TabIndex = 25;
      this.lblMacType.Tag = "MacType";
      this.lblMacType.Text = "label1";
      // 
      // txtMacSN
      // 
      this.txtMacSN.Location = new System.Drawing.Point(100, 10);
      this.txtMacSN.MaxLength = 3;
      this.txtMacSN.Name = "txtMacSN";
      this.txtMacSN.Size = new System.Drawing.Size(120, 21);
      this.txtMacSN.TabIndex = 22;
      // 
      // lblMacSN
      // 
      this.lblMacSN.AutoSize = true;
      this.lblMacSN.Location = new System.Drawing.Point(10, 14);
      this.lblMacSN.Name = "lblMacSN";
      this.lblMacSN.Size = new System.Drawing.Size(41, 12);
      this.lblMacSN.TabIndex = 24;
      this.lblMacSN.Tag = "MacSN";
      this.lblMacSN.Text = "label1";
      // 
      // pnlWAN
      // 
      this.pnlWAN.Controls.Add(this.txtWANPort);
      this.pnlWAN.Controls.Add(this.lblWANPort);
      this.pnlWAN.Controls.Add(this.txtWANIP);
      this.pnlWAN.Controls.Add(this.lblWANIP);
      this.pnlWAN.Location = new System.Drawing.Point(10, 185);
      this.pnlWAN.Name = "pnlWAN";
      this.pnlWAN.Size = new System.Drawing.Size(445, 55);
      this.pnlWAN.TabIndex = 40;
      // 
      // txtWANAddress
      // 
      this.txtWANAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
      this.txtWANAddress.Location = new System.Drawing.Point(100, 215);
      this.txtWANAddress.MaxLength = 50;
      this.txtWANAddress.Name = "txtWANAddress";
      this.txtWANAddress.Size = new System.Drawing.Size(120, 21);
      this.txtWANAddress.TabIndex = 13;
      // 
      // lblWANAddress
      // 
      this.lblWANAddress.AutoSize = true;
      this.lblWANAddress.Location = new System.Drawing.Point(10, 219);
      this.lblWANAddress.Name = "lblWANAddress";
      this.lblWANAddress.Size = new System.Drawing.Size(41, 12);
      this.lblWANAddress.TabIndex = 6;
      this.lblWANAddress.Tag = "MacPhysicsAddress";
      this.lblWANAddress.Text = "label3";
      // 
      // txtWANPort
      // 
      this.txtWANPort.Location = new System.Drawing.Point(320, 0);
      this.txtWANPort.MaxLength = 6;
      this.txtWANPort.Name = "txtWANPort";
      this.txtWANPort.Size = new System.Drawing.Size(120, 21);
      this.txtWANPort.TabIndex = 11;
      // 
      // lblWANPort
      // 
      this.lblWANPort.AutoSize = true;
      this.lblWANPort.Location = new System.Drawing.Point(230, 4);
      this.lblWANPort.Name = "lblWANPort";
      this.lblWANPort.Size = new System.Drawing.Size(41, 12);
      this.lblWANPort.TabIndex = 2;
      this.lblWANPort.Tag = "MacPort";
      this.lblWANPort.Text = "label3";
      // 
      // txtWANIP
      // 
      this.txtWANIP.Location = new System.Drawing.Point(90, 0);
      this.txtWANIP.MaxLength = 50;
      this.txtWANIP.Name = "txtWANIP";
      this.txtWANIP.Size = new System.Drawing.Size(120, 21);
      this.txtWANIP.TabIndex = 10;
      // 
      // lblWANIP
      // 
      this.lblWANIP.AutoSize = true;
      this.lblWANIP.Location = new System.Drawing.Point(0, 4);
      this.lblWANIP.Name = "lblWANIP";
      this.lblWANIP.Size = new System.Drawing.Size(41, 12);
      this.lblWANIP.TabIndex = 0;
      this.lblWANIP.Tag = "MacIPAddress";
      this.lblWANIP.Text = "label4";
      // 
      // rbWAN
      // 
      this.rbWAN.AutoSize = true;
      this.rbWAN.Location = new System.Drawing.Point(10, 165);
      this.rbWAN.Name = "rbWAN";
      this.rbWAN.Size = new System.Drawing.Size(95, 16);
      this.rbWAN.TabIndex = 37;
      this.rbWAN.Text = "radioButton1";
      this.rbWAN.UseVisualStyleBackColor = true;
      this.rbWAN.Click += new System.EventHandler(this.RadioButton_Click);
      // 
      // pnlLAN
      // 
      this.pnlLAN.Controls.Add(this.txtLANPort);
      this.pnlLAN.Controls.Add(this.lblLANPort);
      this.pnlLAN.Controls.Add(this.txtLANIP);
      this.pnlLAN.Controls.Add(this.lblLANIP);
      this.pnlLAN.Location = new System.Drawing.Point(10, 135);
      this.pnlLAN.Name = "pnlLAN";
      this.pnlLAN.Size = new System.Drawing.Size(445, 25);
      this.pnlLAN.TabIndex = 39;
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
      // pnlComm
      // 
      this.pnlComm.Controls.Add(this.lblCommPort);
      this.pnlComm.Controls.Add(this.cbbCommPort);
      this.pnlComm.Controls.Add(this.cbbCommBaudRate);
      this.pnlComm.Controls.Add(this.lblCommBaudRate);
      this.pnlComm.Location = new System.Drawing.Point(10, 85);
      this.pnlComm.Name = "pnlComm";
      this.pnlComm.Size = new System.Drawing.Size(445, 25);
      this.pnlComm.TabIndex = 38;
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
      this.cbbCommBaudRate.Size = new System.Drawing.Size(121, 20);
      this.cbbCommBaudRate.TabIndex = 5;
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
      // rbLAN
      // 
      this.rbLAN.AutoSize = true;
      this.rbLAN.Location = new System.Drawing.Point(10, 115);
      this.rbLAN.Name = "rbLAN";
      this.rbLAN.Size = new System.Drawing.Size(95, 16);
      this.rbLAN.TabIndex = 36;
      this.rbLAN.Text = "radioButton1";
      this.rbLAN.UseVisualStyleBackColor = true;
      this.rbLAN.Click += new System.EventHandler(this.RadioButton_Click);
      // 
      // rbComm
      // 
      this.rbComm.AutoSize = true;
      this.rbComm.Location = new System.Drawing.Point(10, 65);
      this.rbComm.Name = "rbComm";
      this.rbComm.Size = new System.Drawing.Size(95, 16);
      this.rbComm.TabIndex = 35;
      this.rbComm.Text = "radioButton1";
      this.rbComm.UseVisualStyleBackColor = true;
      this.rbComm.Click += new System.EventHandler(this.RadioButton_Click);
      // 
      // rbUSB
      // 
      this.rbUSB.AutoSize = true;
      this.rbUSB.Checked = true;
      this.rbUSB.Location = new System.Drawing.Point(10, 40);
      this.rbUSB.Name = "rbUSB";
      this.rbUSB.Size = new System.Drawing.Size(95, 16);
      this.rbUSB.TabIndex = 34;
      this.rbUSB.TabStop = true;
      this.rbUSB.Text = "radioButton1";
      this.rbUSB.UseVisualStyleBackColor = true;
      this.rbUSB.Click += new System.EventHandler(this.RadioButton_Click);
      // 
      // btnOk
      // 
      this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnOk.Location = new System.Drawing.Point(10, 250);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(75, 25);
      this.btnOk.TabIndex = 41;
      this.btnOk.Text = "button1";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(380, 250);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 25);
      this.btnCancel.TabIndex = 42;
      this.btnCancel.Text = "button1";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // frmSyncTime
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(459, 283);
      this.Controls.Add(this.txtWANAddress);
      this.Controls.Add(this.lblWANAddress);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOk);
      this.Controls.Add(this.pnlWAN);
      this.Controls.Add(this.rbWAN);
      this.Controls.Add(this.pnlLAN);
      this.Controls.Add(this.pnlComm);
      this.Controls.Add(this.rbLAN);
      this.Controls.Add(this.rbComm);
      this.Controls.Add(this.rbUSB);
      this.Controls.Add(this.cbbMacType);
      this.Controls.Add(this.lblMacType);
      this.Controls.Add(this.txtMacSN);
      this.Controls.Add(this.lblMacSN);
      this.Name = "frmSyncTime";
      this.Text = "";
      this.pnlWAN.ResumeLayout(false);
      this.pnlWAN.PerformLayout();
      this.pnlLAN.ResumeLayout(false);
      this.pnlLAN.PerformLayout();
      this.pnlComm.ResumeLayout(false);
      this.pnlComm.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox cbbMacType;
    private System.Windows.Forms.Label lblMacType;
    private System.Windows.Forms.TextBox txtMacSN;
    private System.Windows.Forms.Label lblMacSN;
    private System.Windows.Forms.Panel pnlWAN;
    private System.Windows.Forms.TextBox txtWANAddress;
    private System.Windows.Forms.Label lblWANAddress;
    private System.Windows.Forms.TextBox txtWANPort;
    private System.Windows.Forms.Label lblWANPort;
    private System.Windows.Forms.TextBox txtWANIP;
    private System.Windows.Forms.Label lblWANIP;
    private System.Windows.Forms.RadioButton rbWAN;
    private System.Windows.Forms.Panel pnlLAN;
    private System.Windows.Forms.TextBox txtLANPort;
    private System.Windows.Forms.Label lblLANPort;
    private System.Windows.Forms.TextBox txtLANIP;
    private System.Windows.Forms.Label lblLANIP;
    private System.Windows.Forms.Panel pnlComm;
    private System.Windows.Forms.Label lblCommPort;
    private System.Windows.Forms.ComboBox cbbCommPort;
    private System.Windows.Forms.ComboBox cbbCommBaudRate;
    private System.Windows.Forms.Label lblCommBaudRate;
    private System.Windows.Forms.RadioButton rbLAN;
    private System.Windows.Forms.RadioButton rbComm;
    private System.Windows.Forms.RadioButton rbUSB;
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.Button btnCancel;
  }
}
