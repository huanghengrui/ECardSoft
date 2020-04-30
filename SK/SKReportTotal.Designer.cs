namespace ECard78
{
  partial class frmSKReportTotal
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSKReportTotal));
      this.dtpEnd = new System.Windows.Forms.DateTimePicker();
      this.dtpStart = new System.Windows.Forms.DateTimePicker();
      this.label4 = new System.Windows.Forms.Label();
      this.btnSelectDepart = new System.Windows.Forms.Button();
      this.txtDepart = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.btnSelectEmp = new System.Windows.Forms.Button();
      this.txtEmp = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.chkSKType = new System.Windows.Forms.CheckBox();
      this.clbSKType = new System.Windows.Forms.CheckedListBox();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dispView)).BeginInit();
      this.pnlDisp.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.chkSKType);
      this.panel1.Controls.Add(this.clbSKType);
      this.panel1.Controls.Add(this.btnSelectDepart);
      this.panel1.Controls.Add(this.txtDepart);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.btnSelectEmp);
      this.panel1.Controls.Add(this.txtEmp);
      this.panel1.Controls.Add(this.label1);
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
      this.label4.TabIndex = 12;
      this.label4.Tag = "SKDate";
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
      this.label2.TabIndex = 19;
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
      this.label1.TabIndex = 16;
      this.label1.Tag = "Emp";
      this.label1.Text = "label1";
      // 
      // chkSKType
      // 
      this.chkSKType.AutoSize = true;
      this.chkSKType.Location = new System.Drawing.Point(10, 125);
      this.chkSKType.Name = "chkSKType";
      this.chkSKType.Size = new System.Drawing.Size(78, 16);
      this.chkSKType.TabIndex = 6;
      this.chkSKType.Tag = "SKType";
      this.chkSKType.Text = "checkBox1";
      this.chkSKType.UseVisualStyleBackColor = true;
      this.chkSKType.CheckedChanged += new System.EventHandler(this.chkSKType_CheckedChanged);
      // 
      // clbSKType
      // 
      this.clbSKType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.clbSKType.FormattingEnabled = true;
      this.clbSKType.HorizontalScrollbar = true;
      this.clbSKType.IntegralHeight = false;
      this.clbSKType.Location = new System.Drawing.Point(10, 145);
      this.clbSKType.Name = "clbSKType";
      this.clbSKType.Size = new System.Drawing.Size(200, 115);
      this.clbSKType.TabIndex = 7;
      // 
      // frmSKReportTotal
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(552, 326);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "frmSKReportTotal";
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
    private System.Windows.Forms.Button btnSelectDepart;
    private System.Windows.Forms.TextBox txtDepart;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnSelectEmp;
    private System.Windows.Forms.TextBox txtEmp;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckBox chkSKType;
    private System.Windows.Forms.CheckedListBox clbSKType;
  }
}
