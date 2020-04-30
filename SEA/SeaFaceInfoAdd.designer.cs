namespace ECard78
{
  partial class frmSeaFaceInfoAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSeaFaceInfoAdd));
            this.lblMacSN = new System.Windows.Forms.Label();
            this.txtMacSN = new System.Windows.Forms.TextBox();
            this.pnlLAN = new System.Windows.Forms.Panel();
            this.txtMacConnPWD = new System.Windows.Forms.TextBox();
            this.lbMacPWD = new System.Windows.Forms.Label();
            this.txtMacConnName = new System.Windows.Forms.TextBox();
            this.lbMacName = new System.Windows.Forms.Label();
            this.txtLANPort = new System.Windows.Forms.TextBox();
            this.lblLANPort = new System.Windows.Forms.Label();
            this.txtLANIP = new System.Windows.Forms.TextBox();
            this.lblLANIP = new System.Windows.Forms.Label();
            this.btnTestConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.lbInOut = new System.Windows.Forms.Label();
            this.cbbInOut = new System.Windows.Forms.ComboBox();
            this.pnlLAN.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(375, 207);
            this.btnCancel.Text = "";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(295, 207);
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
            this.lblMacSN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.txtMacSN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMacSN.Location = new System.Drawing.Point(100, 10);
            this.txtMacSN.MaxLength = 3;
            this.txtMacSN.Name = "txtMacSN";
            this.txtMacSN.Size = new System.Drawing.Size(120, 21);
            this.txtMacSN.TabIndex = 0;
            // 
            // pnlLAN
            // 
            this.pnlLAN.Controls.Add(this.txtMacConnPWD);
            this.pnlLAN.Controls.Add(this.lbMacPWD);
            this.pnlLAN.Controls.Add(this.txtMacConnName);
            this.pnlLAN.Controls.Add(this.lbMacName);
            this.pnlLAN.Controls.Add(this.txtLANPort);
            this.pnlLAN.Controls.Add(this.lblLANPort);
            this.pnlLAN.Controls.Add(this.txtLANIP);
            this.pnlLAN.Controls.Add(this.lblLANIP);
            this.pnlLAN.Location = new System.Drawing.Point(10, 50);
            this.pnlLAN.Name = "pnlLAN";
            this.pnlLAN.Size = new System.Drawing.Size(445, 76);
            this.pnlLAN.TabIndex = 31;
            // 
            // txtMacConnPWD
            // 
            this.txtMacConnPWD.Location = new System.Drawing.Point(319, 42);
            this.txtMacConnPWD.MaxLength = 6;
            this.txtMacConnPWD.Name = "txtMacConnPWD";
            this.txtMacConnPWD.PasswordChar = '*';
            this.txtMacConnPWD.Size = new System.Drawing.Size(120, 21);
            this.txtMacConnPWD.TabIndex = 12;
            // 
            // lbMacPWD
            // 
            this.lbMacPWD.AutoSize = true;
            this.lbMacPWD.Location = new System.Drawing.Point(231, 46);
            this.lbMacPWD.Name = "lbMacPWD";
            this.lbMacPWD.Size = new System.Drawing.Size(41, 12);
            this.lbMacPWD.TabIndex = 10;
            this.lbMacPWD.Tag = "MacPort";
            this.lbMacPWD.Text = "label2";
            // 
            // txtMacConnName
            // 
            this.txtMacConnName.Location = new System.Drawing.Point(92, 42);
            this.txtMacConnName.MaxLength = 50;
            this.txtMacConnName.Name = "txtMacConnName";
            this.txtMacConnName.Size = new System.Drawing.Size(120, 21);
            this.txtMacConnName.TabIndex = 11;
            // 
            // lbMacName
            // 
            this.lbMacName.AutoSize = true;
            this.lbMacName.Location = new System.Drawing.Point(1, 46);
            this.lbMacName.Name = "lbMacName";
            this.lbMacName.Size = new System.Drawing.Size(41, 12);
            this.lbMacName.TabIndex = 9;
            this.lbMacName.Tag = "MacIPAddress";
            this.lbMacName.Text = "label1";
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
            this.btnTestConnect.Location = new System.Drawing.Point(10, 207);
            this.btnTestConnect.Name = "btnTestConnect";
            this.btnTestConnect.Size = new System.Drawing.Size(75, 25);
            this.btnTestConnect.TabIndex = 15;
            this.btnTestConnect.Text = "button1";
            this.btnTestConnect.UseVisualStyleBackColor = true;
            this.btnTestConnect.Click += new System.EventHandler(this.btnTestConnect_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 34;
            this.label1.Tag = "MacDesc";
            this.label1.Text = "label1";
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(100, 165);
            this.txtDesc.MaxLength = 100;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(350, 21);
            this.txtDesc.TabIndex = 10;
            // 
            // lbInOut
            // 
            this.lbInOut.AutoSize = true;
            this.lbInOut.Location = new System.Drawing.Point(11, 133);
            this.lbInOut.Name = "lbInOut";
            this.lbInOut.Size = new System.Drawing.Size(41, 12);
            this.lbInOut.TabIndex = 35;
            this.lbInOut.Text = "label2";
            // 
            // cbbInOut
            // 
            this.cbbInOut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbInOut.FormattingEnabled = true;
            this.cbbInOut.Location = new System.Drawing.Point(102, 131);
            this.cbbInOut.Name = "cbbInOut";
            this.cbbInOut.Size = new System.Drawing.Size(121, 20);
            this.cbbInOut.TabIndex = 36;
            // 
            // frmSeaFaceInfoAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(459, 240);
            this.Controls.Add(this.cbbInOut);
            this.Controls.Add(this.lbInOut);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTestConnect);
            this.Controls.Add(this.pnlLAN);
            this.Controls.Add(this.txtMacSN);
            this.Controls.Add(this.lblMacSN);
            this.Name = "frmSeaFaceInfoAdd";
            this.Controls.SetChildIndex(this.lblMacSN, 0);
            this.Controls.SetChildIndex(this.txtMacSN, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.pnlLAN, 0);
            this.Controls.SetChildIndex(this.btnTestConnect, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtDesc, 0);
            this.Controls.SetChildIndex(this.lbInOut, 0);
            this.Controls.SetChildIndex(this.cbbInOut, 0);
            this.pnlLAN.ResumeLayout(false);
            this.pnlLAN.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblMacSN;
    private System.Windows.Forms.TextBox txtMacSN;
    private System.Windows.Forms.Panel pnlLAN;
    private System.Windows.Forms.TextBox txtLANPort;
    private System.Windows.Forms.Label lblLANPort;
    private System.Windows.Forms.TextBox txtLANIP;
    private System.Windows.Forms.Label lblLANIP;
    private System.Windows.Forms.Button btnTestConnect;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtMacConnPWD;
        private System.Windows.Forms.Label lbMacPWD;
        private System.Windows.Forms.TextBox txtMacConnName;
        private System.Windows.Forms.Label lbMacName;
        private System.Windows.Forms.Label lbInOut;
        private System.Windows.Forms.ComboBox cbbInOut;
    }
}
