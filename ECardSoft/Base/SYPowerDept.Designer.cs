namespace ECard78
{
  partial class frmSYPowerDept
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
      this.tvDepart = new System.Windows.Forms.TreeView();
      this.optSelect = new System.Windows.Forms.RadioButton();
      this.optSelectAll = new System.Windows.Forms.RadioButton();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(310, 335);
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(230, 335);
      this.btnOk.Text = "";
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
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
      this.tvDepart.Location = new System.Drawing.Point(10, 10);
      this.tvDepart.Name = "tvDepart";
      this.tvDepart.Size = new System.Drawing.Size(375, 315);
      this.tvDepart.TabIndex = 0;
      this.tvDepart.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvDepart_AfterCheck);
      // 
      // optSelect
      // 
      this.optSelect.AutoSize = true;
      this.optSelect.Checked = true;
      this.optSelect.Location = new System.Drawing.Point(10, 330);
      this.optSelect.Name = "optSelect";
      this.optSelect.Size = new System.Drawing.Size(95, 16);
      this.optSelect.TabIndex = 20;
      this.optSelect.TabStop = true;
      this.optSelect.Text = "radioButton1";
      this.optSelect.UseVisualStyleBackColor = true;
      // 
      // optSelectAll
      // 
      this.optSelectAll.AutoSize = true;
      this.optSelectAll.Location = new System.Drawing.Point(10, 350);
      this.optSelectAll.Name = "optSelectAll";
      this.optSelectAll.Size = new System.Drawing.Size(95, 16);
      this.optSelectAll.TabIndex = 21;
      this.optSelectAll.TabStop = true;
      this.optSelectAll.Text = "radioButton2";
      this.optSelectAll.UseVisualStyleBackColor = true;
      // 
      // frmSYPowerDept
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(394, 368);
      this.Controls.Add(this.optSelectAll);
      this.Controls.Add(this.optSelect);
      this.Controls.Add(this.tvDepart);
      this.Name = "frmSYPowerDept";
      this.Controls.SetChildIndex(this.tvDepart, 0);
      this.Controls.SetChildIndex(this.optSelect, 0);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.Controls.SetChildIndex(this.optSelectAll, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TreeView tvDepart;
    private System.Windows.Forms.RadioButton optSelect;
    private System.Windows.Forms.RadioButton optSelectAll;
  }
}
