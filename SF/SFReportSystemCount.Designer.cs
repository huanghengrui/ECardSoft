namespace ECard78
{
  partial class frmSFReportSystemCount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSFReportSystemCount));
            this.rbDate = new System.Windows.Forms.RadioButton();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.rbCheckDate = new System.Windows.Forms.RadioButton();
            this.cbbCheckDate = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dispView)).BeginInit();
            this.pnlDisp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbbCheckDate);
            this.panel1.Controls.Add(this.rbCheckDate);
            this.panel1.Controls.Add(this.dtpEnd);
            this.panel1.Controls.Add(this.dtpStart);
            this.panel1.Controls.Add(this.rbDate);
            // 
            // dispView
            // 
            this.dispView.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("dispView.OcxState")));
            // 
            // ilTreeState
            // 
            this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
            this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
            this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
            this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
            // 
            // rbDate
            // 
            this.rbDate.AutoSize = true;
            this.rbDate.Location = new System.Drawing.Point(10, 10);
            this.rbDate.Name = "rbDate";
            this.rbDate.Size = new System.Drawing.Size(95, 16);
            this.rbDate.TabIndex = 0;
            this.rbDate.TabStop = true;
            this.rbDate.Tag = "SFDate";
            this.rbDate.Text = "radioButton1";
            this.rbDate.UseVisualStyleBackColor = true;
            this.rbDate.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(40, 55);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(130, 21);
            this.dtpEnd.TabIndex = 3;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(40, 30);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(130, 21);
            this.dtpStart.TabIndex = 2;
            // 
            // rbCheckDate
            // 
            this.rbCheckDate.AutoSize = true;
            this.rbCheckDate.Location = new System.Drawing.Point(10, 80);
            this.rbCheckDate.Name = "rbCheckDate";
            this.rbCheckDate.Size = new System.Drawing.Size(95, 16);
            this.rbCheckDate.TabIndex = 4;
            this.rbCheckDate.TabStop = true;
            this.rbCheckDate.Tag = "CheckOutDate";
            this.rbCheckDate.Text = "radioButton2";
            this.rbCheckDate.UseVisualStyleBackColor = true;
            this.rbCheckDate.Visible = false;
            this.rbCheckDate.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // cbbCheckDate
            // 
            this.cbbCheckDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCheckDate.FormattingEnabled = true;
            this.cbbCheckDate.Location = new System.Drawing.Point(40, 100);
            this.cbbCheckDate.Name = "cbbCheckDate";
            this.cbbCheckDate.Size = new System.Drawing.Size(130, 20);
            this.cbbCheckDate.TabIndex = 5;
            this.cbbCheckDate.Visible = false;
            // 
            // frmSFReportSystemCount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(552, 326);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSFReportSystemCount";
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

    private System.Windows.Forms.RadioButton rbDate;
    private System.Windows.Forms.DateTimePicker dtpEnd;
    private System.Windows.Forms.DateTimePicker dtpStart;
    private System.Windows.Forms.ComboBox cbbCheckDate;
    private System.Windows.Forms.RadioButton rbCheckDate;
  }
}
