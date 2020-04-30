namespace ECard78
{
  partial class frmSFReportSFDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSFReportSFDetail));
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSelectDepart = new System.Windows.Forms.Button();
            this.txtDepart = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelectEmp = new System.Windows.Forms.Button();
            this.txtEmp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.clbCardType = new System.Windows.Forms.CheckedListBox();
            this.clbSFType = new System.Windows.Forms.CheckedListBox();
            this.clbMealType = new System.Windows.Forms.CheckedListBox();
            this.chkCardType = new System.Windows.Forms.CheckBox();
            this.chkSFType = new System.Windows.Forms.CheckBox();
            this.chkSFMealType = new System.Windows.Forms.CheckBox();
            this.chkMacSN = new System.Windows.Forms.CheckBox();
            this.clbMacSN = new System.Windows.Forms.CheckedListBox();
            this.btnAddress = new System.Windows.Forms.Button();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkShowAlarm = new System.Windows.Forms.CheckBox();
            this.btnCardNo = new System.Windows.Forms.Button();
            this.txtCardNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dispView)).BeginInit();
            this.pnlDisp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnCardNo);
            this.panel1.Controls.Add(this.txtCardNo);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnAddress);
            this.panel1.Controls.Add(this.txtAddress);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnSelectDepart);
            this.panel1.Controls.Add(this.txtDepart);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnSelectEmp);
            this.panel1.Controls.Add(this.txtEmp);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpEnd);
            this.panel1.Controls.Add(this.dtpStart);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Size = new System.Drawing.Size(220, 846);
            // 
            // dispView
            // 
            this.dispView.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("dispView.OcxState")));
            this.dispView.Size = new System.Drawing.Size(447, 846);
            // 
            // pnlDisp
            // 
            this.pnlDisp.Location = new System.Drawing.Point(220, 25);
            this.pnlDisp.Size = new System.Drawing.Size(447, 846);
            // 
            // ilTreeState
            // 
            this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
            this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
            this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
            this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(70, 35);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.ShowUpDown = true;
            this.dtpEnd.Size = new System.Drawing.Size(140, 21);
            this.dtpEnd.TabIndex = 1;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(70, 10);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.ShowUpDown = true;
            this.dtpStart.Size = new System.Drawing.Size(140, 21);
            this.dtpStart.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 15;
            this.label4.Tag = "SFDate";
            this.label4.Text = "label4";
            // 
            // btnSelectDepart
            // 
            this.btnSelectDepart.Location = new System.Drawing.Point(175, 96);
            this.btnSelectDepart.Name = "btnSelectDepart";
            this.btnSelectDepart.Size = new System.Drawing.Size(34, 19);
            this.btnSelectDepart.TabIndex = 5;
            this.btnSelectDepart.Text = "button1";
            this.btnSelectDepart.UseVisualStyleBackColor = true;
            this.btnSelectDepart.Click += new System.EventHandler(this.btnSelectDepart_Click);
            // 
            // txtDepart
            // 
            this.txtDepart.Location = new System.Drawing.Point(70, 95);
            this.txtDepart.Name = "txtDepart";
            this.txtDepart.Size = new System.Drawing.Size(140, 21);
            this.txtDepart.TabIndex = 4;
            this.txtDepart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDepart_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 25;
            this.label2.Tag = "Depart";
            this.label2.Text = "label2";
            // 
            // btnSelectEmp
            // 
            this.btnSelectEmp.Location = new System.Drawing.Point(175, 66);
            this.btnSelectEmp.Name = "btnSelectEmp";
            this.btnSelectEmp.Size = new System.Drawing.Size(34, 19);
            this.btnSelectEmp.TabIndex = 3;
            this.btnSelectEmp.Text = "button1";
            this.btnSelectEmp.UseVisualStyleBackColor = true;
            this.btnSelectEmp.Click += new System.EventHandler(this.btnSelectEmp_Click);
            // 
            // txtEmp
            // 
            this.txtEmp.Location = new System.Drawing.Point(70, 65);
            this.txtEmp.Name = "txtEmp";
            this.txtEmp.Size = new System.Drawing.Size(140, 21);
            this.txtEmp.TabIndex = 2;
            this.txtEmp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmp_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 24;
            this.label1.Tag = "Emp";
            this.label1.Text = "label1";
            // 
            // clbCardType
            // 
            this.clbCardType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbCardType.FormattingEnabled = true;
            this.clbCardType.HorizontalScrollbar = true;
            this.clbCardType.IntegralHeight = false;
            this.clbCardType.Location = new System.Drawing.Point(9, 30);
            this.clbCardType.Name = "clbCardType";
            this.clbCardType.Size = new System.Drawing.Size(197, 67);
            this.clbCardType.TabIndex = 9;
            // 
            // clbSFType
            // 
            this.clbSFType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbSFType.FormattingEnabled = true;
            this.clbSFType.HorizontalExtent = 50;
            this.clbSFType.HorizontalScrollbar = true;
            this.clbSFType.IntegralHeight = false;
            this.clbSFType.Location = new System.Drawing.Point(9, 27);
            this.clbSFType.Name = "clbSFType";
            this.clbSFType.Size = new System.Drawing.Size(195, 261);
            this.clbSFType.TabIndex = 11;
            // 
            // clbMealType
            // 
            this.clbMealType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.clbMealType.FormattingEnabled = true;
            this.clbMealType.HorizontalScrollbar = true;
            this.clbMealType.IntegralHeight = false;
            this.clbMealType.Location = new System.Drawing.Point(12, 33);
            this.clbMealType.Name = "clbMealType";
            this.clbMealType.Size = new System.Drawing.Size(189, 61);
            this.clbMealType.TabIndex = 13;
            // 
            // chkCardType
            // 
            this.chkCardType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.chkCardType.AutoSize = true;
            this.chkCardType.Location = new System.Drawing.Point(9, 8);
            this.chkCardType.Name = "chkCardType";
            this.chkCardType.Size = new System.Drawing.Size(78, 16);
            this.chkCardType.TabIndex = 8;
            this.chkCardType.Tag = "CardType";
            this.chkCardType.Text = "checkBox1";
            this.chkCardType.UseVisualStyleBackColor = true;
            this.chkCardType.CheckedChanged += new System.EventHandler(this.chkCardType_CheckedChanged);
            // 
            // chkSFType
            // 
            this.chkSFType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSFType.AutoSize = true;
            this.chkSFType.Location = new System.Drawing.Point(9, 5);
            this.chkSFType.Name = "chkSFType";
            this.chkSFType.Size = new System.Drawing.Size(78, 16);
            this.chkSFType.TabIndex = 10;
            this.chkSFType.Tag = "SFType";
            this.chkSFType.Text = "checkBox1";
            this.chkSFType.UseVisualStyleBackColor = true;
            this.chkSFType.CheckedChanged += new System.EventHandler(this.chkSFType_CheckedChanged);
            // 
            // chkSFMealType
            // 
            this.chkSFMealType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSFMealType.AutoSize = true;
            this.chkSFMealType.Location = new System.Drawing.Point(9, 9);
            this.chkSFMealType.Name = "chkSFMealType";
            this.chkSFMealType.Size = new System.Drawing.Size(78, 16);
            this.chkSFMealType.TabIndex = 12;
            this.chkSFMealType.Tag = "SFMealType";
            this.chkSFMealType.Text = "checkBox1";
            this.chkSFMealType.UseVisualStyleBackColor = true;
            this.chkSFMealType.CheckedChanged += new System.EventHandler(this.chkSFMealType_CheckedChanged);
            // 
            // chkMacSN
            // 
            this.chkMacSN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.chkMacSN.AutoSize = true;
            this.chkMacSN.Location = new System.Drawing.Point(9, 9);
            this.chkMacSN.Name = "chkMacSN";
            this.chkMacSN.Size = new System.Drawing.Size(78, 16);
            this.chkMacSN.TabIndex = 14;
            this.chkMacSN.Tag = "MacSN";
            this.chkMacSN.Text = "checkBox1";
            this.chkMacSN.UseVisualStyleBackColor = true;
            this.chkMacSN.CheckedChanged += new System.EventHandler(this.chkMacSN_CheckedChanged);
            // 
            // clbMacSN
            // 
            this.clbMacSN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbMacSN.FormattingEnabled = true;
            this.clbMacSN.HorizontalScrollbar = true;
            this.clbMacSN.IntegralHeight = false;
            this.clbMacSN.Location = new System.Drawing.Point(9, 32);
            this.clbMacSN.Name = "clbMacSN";
            this.clbMacSN.Size = new System.Drawing.Size(195, 62);
            this.clbMacSN.TabIndex = 15;
            // 
            // btnAddress
            // 
            this.btnAddress.Location = new System.Drawing.Point(175, 126);
            this.btnAddress.Name = "btnAddress";
            this.btnAddress.Size = new System.Drawing.Size(34, 19);
            this.btnAddress.TabIndex = 7;
            this.btnAddress.Text = "button1";
            this.btnAddress.UseVisualStyleBackColor = true;
            this.btnAddress.Click += new System.EventHandler(this.btnAddress_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(70, 125);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(140, 21);
            this.txtAddress.TabIndex = 6;
            this.txtAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAddress_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 30;
            this.label3.Tag = "MacAddress";
            this.label3.Text = "label3";
            // 
            // chkShowAlarm
            // 
            this.chkShowAlarm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkShowAlarm.AutoSize = true;
            this.chkShowAlarm.Enabled = false;
            this.chkShowAlarm.Location = new System.Drawing.Point(9, 102);
            this.chkShowAlarm.Name = "chkShowAlarm";
            this.chkShowAlarm.Size = new System.Drawing.Size(78, 16);
            this.chkShowAlarm.TabIndex = 31;
            this.chkShowAlarm.Text = "checkBox1";
            this.chkShowAlarm.UseVisualStyleBackColor = true;
            this.chkShowAlarm.Visible = false;
            this.chkShowAlarm.Click += new System.EventHandler(this.chkShowAlarm_Click);
            // 
            // btnCardNo
            // 
            this.btnCardNo.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCardNo.Location = new System.Drawing.Point(175, 153);
            this.btnCardNo.Name = "btnCardNo";
            this.btnCardNo.Size = new System.Drawing.Size(34, 19);
            this.btnCardNo.TabIndex = 33;
            this.btnCardNo.Text = "button1";
            this.btnCardNo.UseVisualStyleBackColor = true;
            this.btnCardNo.Click += new System.EventHandler(this.btnCardNo_Click);
            // 
            // txtCardNo
            // 
            this.txtCardNo.Location = new System.Drawing.Point(70, 152);
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(140, 21);
            this.txtCardNo.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 34;
            this.label5.Tag = "CardSectorNo";
            this.label5.Text = "label5";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Location = new System.Drawing.Point(3, 179);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(217, 638);
            this.panel2.TabIndex = 5;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chkCardType);
            this.splitContainer1.Panel1.Controls.Add(this.clbCardType);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(217, 638);
            this.splitContainer1.SplitterDistance = 107;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.clbSFType);
            this.splitContainer2.Panel1.Controls.Add(this.chkSFType);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(217, 527);
            this.splitContainer2.SplitterDistance = 293;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.clbMealType);
            this.splitContainer3.Panel1.Controls.Add(this.chkSFMealType);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.chkMacSN);
            this.splitContainer3.Panel2.Controls.Add(this.clbMacSN);
            this.splitContainer3.Panel2.Controls.Add(this.chkShowAlarm);
            this.splitContainer3.Size = new System.Drawing.Size(217, 230);
            this.splitContainer3.SplitterDistance = 103;
            this.splitContainer3.TabIndex = 0;
            // 
            // frmSFReportSFDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(667, 902);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSFReportSFDetail";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pnlDisp, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dispView)).EndInit();
            this.pnlDisp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.DateTimePicker dtpEnd;
    private System.Windows.Forms.DateTimePicker dtpStart;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button btnSelectDepart;
    private System.Windows.Forms.TextBox txtDepart;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnSelectEmp;
    private System.Windows.Forms.TextBox txtEmp;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckedListBox clbSFType;
    private System.Windows.Forms.CheckedListBox clbCardType;
    private System.Windows.Forms.CheckedListBox clbMealType;
    private System.Windows.Forms.CheckBox chkCardType;
    private System.Windows.Forms.CheckBox chkSFType;
    private System.Windows.Forms.CheckBox chkSFMealType;
    private System.Windows.Forms.CheckBox chkMacSN;
    private System.Windows.Forms.CheckedListBox clbMacSN;
    private System.Windows.Forms.Button btnAddress;
    private System.Windows.Forms.TextBox txtAddress;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.CheckBox chkShowAlarm;
        private System.Windows.Forms.Button btnCardNo;
        private System.Windows.Forms.TextBox txtCardNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
    }
}
