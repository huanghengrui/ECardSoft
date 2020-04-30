namespace ECard78
{
  partial class frmMJMacTimeOpenDoorEdit
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMJMacTimeOpenDoorEdit));
      this.txtEndTime3 = new System.Windows.Forms.MaskedTextBox();
      this.txtBeginTime3 = new System.Windows.Forms.MaskedTextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.txtEndTime2 = new System.Windows.Forms.MaskedTextBox();
      this.txtBeginTime2 = new System.Windows.Forms.MaskedTextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txtEndTime1 = new System.Windows.Forms.MaskedTextBox();
      this.txtBeginTime1 = new System.Windows.Forms.MaskedTextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtEndTime4 = new System.Windows.Forms.MaskedTextBox();
      this.txtBeginTime4 = new System.Windows.Forms.MaskedTextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.cbbMode1 = new System.Windows.Forms.ComboBox();
      this.cbbMode2 = new System.Windows.Forms.ComboBox();
      this.cbbMode3 = new System.Windows.Forms.ComboBox();
      this.cbbMode4 = new System.Windows.Forms.ComboBox();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(185, 135);
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(105, 135);
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
      // txtEndTime3
      // 
      this.txtEndTime3.Location = new System.Drawing.Point(150, 70);
      this.txtEndTime3.Mask = "90:00";
      this.txtEndTime3.Name = "txtEndTime3";
      this.txtEndTime3.PromptChar = ' ';
      this.txtEndTime3.Size = new System.Drawing.Size(40, 21);
      this.txtEndTime3.TabIndex = 7;
      this.txtEndTime3.Text = "0000";
      // 
      // txtBeginTime3
      // 
      this.txtBeginTime3.Location = new System.Drawing.Point(100, 70);
      this.txtBeginTime3.Mask = "90:00";
      this.txtBeginTime3.Name = "txtBeginTime3";
      this.txtBeginTime3.PromptChar = ' ';
      this.txtBeginTime3.Size = new System.Drawing.Size(40, 21);
      this.txtBeginTime3.TabIndex = 6;
      this.txtBeginTime3.Text = "0000";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(10, 74);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(41, 12);
      this.label4.TabIndex = 27;
      this.label4.Tag = "MacTimezone3";
      this.label4.Text = "label4";
      // 
      // txtEndTime2
      // 
      this.txtEndTime2.Location = new System.Drawing.Point(150, 40);
      this.txtEndTime2.Mask = "90:00";
      this.txtEndTime2.Name = "txtEndTime2";
      this.txtEndTime2.PromptChar = ' ';
      this.txtEndTime2.Size = new System.Drawing.Size(40, 21);
      this.txtEndTime2.TabIndex = 4;
      this.txtEndTime2.Text = "0000";
      // 
      // txtBeginTime2
      // 
      this.txtBeginTime2.Location = new System.Drawing.Point(100, 40);
      this.txtBeginTime2.Mask = "90:00";
      this.txtBeginTime2.Name = "txtBeginTime2";
      this.txtBeginTime2.PromptChar = ' ';
      this.txtBeginTime2.Size = new System.Drawing.Size(40, 21);
      this.txtBeginTime2.TabIndex = 3;
      this.txtBeginTime2.Text = "0000";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(10, 44);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(41, 12);
      this.label3.TabIndex = 26;
      this.label3.Tag = "MacTimezone2";
      this.label3.Text = "label3";
      // 
      // txtEndTime1
      // 
      this.txtEndTime1.Location = new System.Drawing.Point(150, 10);
      this.txtEndTime1.Mask = "90:00";
      this.txtEndTime1.Name = "txtEndTime1";
      this.txtEndTime1.PromptChar = ' ';
      this.txtEndTime1.Size = new System.Drawing.Size(40, 21);
      this.txtEndTime1.TabIndex = 1;
      this.txtEndTime1.Text = "0000";
      // 
      // txtBeginTime1
      // 
      this.txtBeginTime1.Location = new System.Drawing.Point(100, 10);
      this.txtBeginTime1.Mask = "90:00";
      this.txtBeginTime1.Name = "txtBeginTime1";
      this.txtBeginTime1.PromptChar = ' ';
      this.txtBeginTime1.Size = new System.Drawing.Size(40, 21);
      this.txtBeginTime1.TabIndex = 0;
      this.txtBeginTime1.Text = "0000";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(10, 14);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(41, 12);
      this.label2.TabIndex = 20;
      this.label2.Tag = "MacTimezone1";
      this.label2.Text = "label2";
      // 
      // txtEndTime4
      // 
      this.txtEndTime4.Location = new System.Drawing.Point(150, 100);
      this.txtEndTime4.Mask = "90:00";
      this.txtEndTime4.Name = "txtEndTime4";
      this.txtEndTime4.PromptChar = ' ';
      this.txtEndTime4.Size = new System.Drawing.Size(40, 21);
      this.txtEndTime4.TabIndex = 10;
      this.txtEndTime4.Text = "0000";
      // 
      // txtBeginTime4
      // 
      this.txtBeginTime4.Location = new System.Drawing.Point(100, 100);
      this.txtBeginTime4.Mask = "90:00";
      this.txtBeginTime4.Name = "txtBeginTime4";
      this.txtBeginTime4.PromptChar = ' ';
      this.txtBeginTime4.Size = new System.Drawing.Size(40, 21);
      this.txtBeginTime4.TabIndex = 9;
      this.txtBeginTime4.Text = "0000";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(10, 104);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 12);
      this.label1.TabIndex = 30;
      this.label1.Tag = "MacTimezone4";
      this.label1.Text = "label1";
      // 
      // cbbMode1
      // 
      this.cbbMode1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbMode1.FormattingEnabled = true;
      this.cbbMode1.Location = new System.Drawing.Point(200, 10);
      this.cbbMode1.Name = "cbbMode1";
      this.cbbMode1.Size = new System.Drawing.Size(60, 20);
      this.cbbMode1.TabIndex = 2;
      // 
      // cbbMode2
      // 
      this.cbbMode2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbMode2.FormattingEnabled = true;
      this.cbbMode2.Location = new System.Drawing.Point(200, 40);
      this.cbbMode2.Name = "cbbMode2";
      this.cbbMode2.Size = new System.Drawing.Size(60, 20);
      this.cbbMode2.TabIndex = 5;
      // 
      // cbbMode3
      // 
      this.cbbMode3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbMode3.FormattingEnabled = true;
      this.cbbMode3.Location = new System.Drawing.Point(200, 70);
      this.cbbMode3.Name = "cbbMode3";
      this.cbbMode3.Size = new System.Drawing.Size(60, 20);
      this.cbbMode3.TabIndex = 8;
      // 
      // cbbMode4
      // 
      this.cbbMode4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbMode4.FormattingEnabled = true;
      this.cbbMode4.Location = new System.Drawing.Point(200, 100);
      this.cbbMode4.Name = "cbbMode4";
      this.cbbMode4.Size = new System.Drawing.Size(60, 20);
      this.cbbMode4.TabIndex = 11;
      // 
      // frmMJMacTimeOpenDoorEdit
      // 
      this.AcceptButton = this.btnCancel;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(269, 167);
      this.Controls.Add(this.cbbMode4);
      this.Controls.Add(this.cbbMode3);
      this.Controls.Add(this.cbbMode2);
      this.Controls.Add(this.cbbMode1);
      this.Controls.Add(this.txtEndTime4);
      this.Controls.Add(this.txtBeginTime4);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtEndTime3);
      this.Controls.Add(this.txtBeginTime3);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.txtEndTime2);
      this.Controls.Add(this.txtBeginTime2);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txtEndTime1);
      this.Controls.Add(this.txtBeginTime1);
      this.Controls.Add(this.label2);
      this.Name = "frmMJMacTimeOpenDoorEdit";
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.Controls.SetChildIndex(this.label2, 0);
      this.Controls.SetChildIndex(this.txtBeginTime1, 0);
      this.Controls.SetChildIndex(this.txtEndTime1, 0);
      this.Controls.SetChildIndex(this.label3, 0);
      this.Controls.SetChildIndex(this.txtBeginTime2, 0);
      this.Controls.SetChildIndex(this.txtEndTime2, 0);
      this.Controls.SetChildIndex(this.label4, 0);
      this.Controls.SetChildIndex(this.txtBeginTime3, 0);
      this.Controls.SetChildIndex(this.txtEndTime3, 0);
      this.Controls.SetChildIndex(this.label1, 0);
      this.Controls.SetChildIndex(this.txtBeginTime4, 0);
      this.Controls.SetChildIndex(this.txtEndTime4, 0);
      this.Controls.SetChildIndex(this.cbbMode1, 0);
      this.Controls.SetChildIndex(this.cbbMode2, 0);
      this.Controls.SetChildIndex(this.cbbMode3, 0);
      this.Controls.SetChildIndex(this.cbbMode4, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MaskedTextBox txtEndTime3;
    private System.Windows.Forms.MaskedTextBox txtBeginTime3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.MaskedTextBox txtEndTime2;
    private System.Windows.Forms.MaskedTextBox txtBeginTime2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.MaskedTextBox txtEndTime1;
    private System.Windows.Forms.MaskedTextBox txtBeginTime1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.MaskedTextBox txtEndTime4;
    private System.Windows.Forms.MaskedTextBox txtBeginTime4;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cbbMode1;
    private System.Windows.Forms.ComboBox cbbMode2;
    private System.Windows.Forms.ComboBox cbbMode3;
    private System.Windows.Forms.ComboBox cbbMode4;
  }
}
