namespace ECard78
{
  partial class frmKQDepShiftBatch
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
      this.label1 = new System.Windows.Forms.Label();
      this.dtpStart = new System.Windows.Forms.DateTimePicker();
      this.label2 = new System.Windows.Forms.Label();
      this.dtpEnd = new System.Windows.Forms.DateTimePicker();
      this.label3 = new System.Windows.Forms.Label();
      this.cbbRule = new System.Windows.Forms.ComboBox();
      this.tvDepart = new System.Windows.Forms.TreeView();
      this.optSelectAll = new System.Windows.Forms.RadioButton();
      this.optSelect = new System.Windows.Forms.RadioButton();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(515, 340);
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(435, 340);
      this.btnOk.Text = "";
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(10, 14);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 12);
      this.label1.TabIndex = 19;
      this.label1.Text = "label1";
      // 
      // dtpStart
      // 
      this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.dtpStart.Location = new System.Drawing.Point(100, 10);
      this.dtpStart.Name = "dtpStart";
      this.dtpStart.Size = new System.Drawing.Size(90, 21);
      this.dtpStart.TabIndex = 0;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(210, 14);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(41, 12);
      this.label2.TabIndex = 21;
      this.label2.Text = "label2";
      // 
      // dtpEnd
      // 
      this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.dtpEnd.Location = new System.Drawing.Point(300, 10);
      this.dtpEnd.Name = "dtpEnd";
      this.dtpEnd.Size = new System.Drawing.Size(90, 21);
      this.dtpEnd.TabIndex = 1;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(410, 14);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(41, 12);
      this.label3.TabIndex = 23;
      this.label3.Tag = "ShiftRuleName";
      this.label3.Text = "label3";
      // 
      // cbbRule
      // 
      this.cbbRule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbRule.FormattingEnabled = true;
      this.cbbRule.Location = new System.Drawing.Point(490, 10);
      this.cbbRule.Name = "cbbRule";
      this.cbbRule.Size = new System.Drawing.Size(100, 20);
      this.cbbRule.TabIndex = 2;
      // 
      // tvDepart
      // 
      this.tvDepart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.tvDepart.CheckBoxes = true;
      this.tvDepart.FullRowSelect = true;
      this.tvDepart.HideSelection = false;
      this.tvDepart.ItemHeight = 20;
      this.tvDepart.Location = new System.Drawing.Point(10, 40);
      this.tvDepart.Name = "tvDepart";
      this.tvDepart.Size = new System.Drawing.Size(580, 290);
      this.tvDepart.TabIndex = 3;
      this.tvDepart.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvDepart_AfterCheck);
      // 
      // optSelectAll
      // 
      this.optSelectAll.AutoSize = true;
      this.optSelectAll.Location = new System.Drawing.Point(10, 355);
      this.optSelectAll.Name = "optSelectAll";
      this.optSelectAll.Size = new System.Drawing.Size(95, 16);
      this.optSelectAll.TabIndex = 5;
      this.optSelectAll.TabStop = true;
      this.optSelectAll.Text = "radioButton2";
      this.optSelectAll.UseVisualStyleBackColor = true;
      // 
      // optSelect
      // 
      this.optSelect.AutoSize = true;
      this.optSelect.Checked = true;
      this.optSelect.Location = new System.Drawing.Point(10, 335);
      this.optSelect.Name = "optSelect";
      this.optSelect.Size = new System.Drawing.Size(95, 16);
      this.optSelect.TabIndex = 4;
      this.optSelect.TabStop = true;
      this.optSelect.Text = "radioButton1";
      this.optSelect.UseVisualStyleBackColor = true;
      // 
      // frmKQDepShiftBatch
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(599, 373);
      this.Controls.Add(this.optSelectAll);
      this.Controls.Add(this.optSelect);
      this.Controls.Add(this.tvDepart);
      this.Controls.Add(this.cbbRule);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.dtpEnd);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.dtpStart);
      this.Name = "frmKQDepShiftBatch";
      this.Controls.SetChildIndex(this.dtpStart, 0);
      this.Controls.SetChildIndex(this.label1, 0);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.Controls.SetChildIndex(this.dtpEnd, 0);
      this.Controls.SetChildIndex(this.label2, 0);
      this.Controls.SetChildIndex(this.label3, 0);
      this.Controls.SetChildIndex(this.cbbRule, 0);
      this.Controls.SetChildIndex(this.tvDepart, 0);
      this.Controls.SetChildIndex(this.optSelect, 0);
      this.Controls.SetChildIndex(this.optSelectAll, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.DateTimePicker dtpStart;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.DateTimePicker dtpEnd;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ComboBox cbbRule;
    private System.Windows.Forms.TreeView tvDepart;
    private System.Windows.Forms.RadioButton optSelectAll;
    private System.Windows.Forms.RadioButton optSelect;
  }
}
