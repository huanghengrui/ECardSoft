namespace ECard78
{
  partial class frmSFReportSFMobileError
  {
    /// <summary>
    /// ����������������
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// ������������ʹ�õ���Դ��
    /// </summary>
    /// <param name="disposing">���Ӧ�ͷ��й���Դ��Ϊ true������Ϊ false��</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows ������������ɵĴ���

    /// <summary>
    /// �����֧������ķ��� - ��Ҫ
    /// ʹ�ô���༭���޸Ĵ˷��������ݡ�
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSFReportSFMobileError));
      this.dtpEnd = new System.Windows.Forms.DateTimePicker();
      this.dtpStart = new System.Windows.Forms.DateTimePicker();
      this.label4 = new System.Windows.Forms.Label();
      this.chkMacSN = new System.Windows.Forms.CheckBox();
      this.clbMacSN = new System.Windows.Forms.CheckedListBox();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dispView)).BeginInit();
      this.pnlDisp.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.clbMacSN);
      this.panel1.Controls.Add(this.chkMacSN);
      this.panel1.Controls.Add(this.dtpEnd);
      this.panel1.Controls.Add(this.dtpStart);
      this.panel1.Controls.Add(this.label4);
      this.panel1.Size = new System.Drawing.Size(220, 270);
      // 
      // dispView
      // 
      this.dispView.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("dispView.OcxState")));
      this.dispView.Size = new System.Drawing.Size(332, 270);
      // 
      // pnlDisp
      // 
      this.pnlDisp.Location = new System.Drawing.Point(220, 25);
      this.pnlDisp.Size = new System.Drawing.Size(332, 270);
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
      // chkMacSN
      // 
      this.chkMacSN.AutoSize = true;
      this.chkMacSN.Location = new System.Drawing.Point(10, 65);
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
      this.clbMacSN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)));
      this.clbMacSN.FormattingEnabled = true;
      this.clbMacSN.HorizontalScrollbar = true;
      this.clbMacSN.IntegralHeight = false;
      this.clbMacSN.Location = new System.Drawing.Point(10, 85);
      this.clbMacSN.Name = "clbMacSN";
      this.clbMacSN.Size = new System.Drawing.Size(200, 174);
      this.clbMacSN.TabIndex = 15;
      // 
      // frmSFReportSFMobileError
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(552, 326);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "frmSFReportSFMobileError";
      this.Controls.SetChildIndex(this.panel1, 0);
      this.Controls.SetChildIndex(this.pnlDisp, 0);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dispView)).EndInit();
      this.pnlDisp.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.DateTimePicker dtpEnd;
    private System.Windows.Forms.DateTimePicker dtpStart;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.CheckBox chkMacSN;
    private System.Windows.Forms.CheckedListBox clbMacSN;
  }
}