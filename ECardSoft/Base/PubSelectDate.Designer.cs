namespace ECard78
{
  partial class frmPubSelectDate
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPubSelectDate));
      this.Calendar = new System.Windows.Forms.MonthCalendar();
      this.label1 = new System.Windows.Forms.Label();
      this.dtpTime = new System.Windows.Forms.DateTimePicker();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(155, 239);
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(75, 239);
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
      // Calendar
      // 
      this.Calendar.Location = new System.Drawing.Point(10, 10);
      this.Calendar.Name = "Calendar";
      this.Calendar.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(10, 204);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 12);
      this.label1.TabIndex = 19;
      this.label1.Text = "label1";
      // 
      // dtpTime
      // 
      this.dtpTime.CustomFormat = "HH:mm:ss";
      this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtpTime.Location = new System.Drawing.Point(80, 200);
      this.dtpTime.Name = "dtpTime";
      this.dtpTime.ShowUpDown = true;
      this.dtpTime.Size = new System.Drawing.Size(150, 21);
      this.dtpTime.TabIndex = 20;
      // 
      // frmPubSelectDate
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(239, 272);
      this.Controls.Add(this.Calendar);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.dtpTime);
      this.Name = "frmPubSelectDate";
      this.Controls.SetChildIndex(this.dtpTime, 0);
      this.Controls.SetChildIndex(this.label1, 0);
      this.Controls.SetChildIndex(this.Calendar, 0);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MonthCalendar Calendar;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.DateTimePicker dtpTime;
  }
}
