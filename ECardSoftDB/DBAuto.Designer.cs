namespace ECard78
{
  partial class frmDBAuto
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
      this.gbxAccount = new System.Windows.Forms.GroupBox();
      this.txtDBName = new System.Windows.Forms.TextBox();
      this.Label2 = new System.Windows.Forms.Label();
      this.txtAccName = new System.Windows.Forms.TextBox();
      this.Label1 = new System.Windows.Forms.Label();
      this.Label3 = new System.Windows.Forms.Label();
      this.dtpTime = new System.Windows.Forms.DateTimePicker();
      this.btnDBPath = new System.Windows.Forms.Button();
      this.txtPath = new System.Windows.Forms.TextBox();
      this.Label4 = new System.Windows.Forms.Label();
      this.Label5 = new System.Windows.Forms.Label();
      this.gbxAccount.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(355, 210);
      this.btnCancel.TabIndex = 24;
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(275, 210);
      this.btnOk.TabIndex = 23;
      this.btnOk.Text = "";
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // gbxAccount
      // 
      this.gbxAccount.Controls.Add(this.txtDBName);
      this.gbxAccount.Controls.Add(this.Label2);
      this.gbxAccount.Controls.Add(this.txtAccName);
      this.gbxAccount.Controls.Add(this.Label1);
      this.gbxAccount.Location = new System.Drawing.Point(10, 10);
      this.gbxAccount.Name = "gbxAccount";
      this.gbxAccount.Size = new System.Drawing.Size(420, 80);
      this.gbxAccount.TabIndex = 3;
      this.gbxAccount.TabStop = false;
      this.gbxAccount.Text = "groupBox1";
      // 
      // txtDBName
      // 
      this.txtDBName.Location = new System.Drawing.Point(110, 50);
      this.txtDBName.MaxLength = 25;
      this.txtDBName.Name = "txtDBName";
      this.txtDBName.ReadOnly = true;
      this.txtDBName.Size = new System.Drawing.Size(300, 21);
      this.txtDBName.TabIndex = 5;
      // 
      // Label2
      // 
      this.Label2.AutoSize = true;
      this.Label2.Location = new System.Drawing.Point(10, 54);
      this.Label2.Name = "Label2";
      this.Label2.Size = new System.Drawing.Size(41, 12);
      this.Label2.TabIndex = 4;
      this.Label2.Tag = "DBName";
      this.Label2.Text = "label2";
      // 
      // txtAccName
      // 
      this.txtAccName.Location = new System.Drawing.Point(110, 20);
      this.txtAccName.MaxLength = 25;
      this.txtAccName.Name = "txtAccName";
      this.txtAccName.ReadOnly = true;
      this.txtAccName.Size = new System.Drawing.Size(300, 21);
      this.txtAccName.TabIndex = 3;
      // 
      // Label1
      // 
      this.Label1.AutoSize = true;
      this.Label1.Location = new System.Drawing.Point(10, 24);
      this.Label1.Name = "Label1";
      this.Label1.Size = new System.Drawing.Size(41, 12);
      this.Label1.TabIndex = 2;
      this.Label1.Tag = "AccName";
      this.Label1.Text = "label1";
      // 
      // Label3
      // 
      this.Label3.AutoSize = true;
      this.Label3.Location = new System.Drawing.Point(10, 100);
      this.Label3.Name = "Label3";
      this.Label3.Size = new System.Drawing.Size(41, 12);
      this.Label3.TabIndex = 8;
      this.Label3.Text = "label1";
      // 
      // dtpTime
      // 
      this.dtpTime.CustomFormat = "HH:mm";
      this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtpTime.Location = new System.Drawing.Point(10, 120);
      this.dtpTime.Name = "dtpTime";
      this.dtpTime.ShowUpDown = true;
      this.dtpTime.Size = new System.Drawing.Size(100, 21);
      this.dtpTime.TabIndex = 9;
      // 
      // btnDBPath
      // 
      this.btnDBPath.Location = new System.Drawing.Point(410, 175);
      this.btnDBPath.Name = "btnDBPath";
      this.btnDBPath.Size = new System.Drawing.Size(20, 20);
      this.btnDBPath.TabIndex = 22;
      this.btnDBPath.Text = ">";
      this.btnDBPath.UseVisualStyleBackColor = true;
      this.btnDBPath.Click += new System.EventHandler(this.btnDBPath_Click);
      // 
      // txtPath
      // 
      this.txtPath.Location = new System.Drawing.Point(10, 175);
      this.txtPath.Name = "txtPath";
      this.txtPath.ReadOnly = true;
      this.txtPath.Size = new System.Drawing.Size(395, 21);
      this.txtPath.TabIndex = 21;
      // 
      // Label4
      // 
      this.Label4.AutoSize = true;
      this.Label4.Location = new System.Drawing.Point(10, 155);
      this.Label4.Name = "Label4";
      this.Label4.Size = new System.Drawing.Size(41, 12);
      this.Label4.TabIndex = 20;
      this.Label4.Text = "label1";
      // 
      // Label5
      // 
      this.Label5.AutoSize = true;
      this.Label5.ForeColor = System.Drawing.Color.Red;
      this.Label5.Location = new System.Drawing.Point(10, 210);
      this.Label5.Name = "Label5";
      this.Label5.Size = new System.Drawing.Size(41, 12);
      this.Label5.TabIndex = 25;
      this.Label5.Text = "label1";
      // 
      // frmDBAuto
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(439, 243);
      this.Controls.Add(this.Label5);
      this.Controls.Add(this.btnDBPath);
      this.Controls.Add(this.txtPath);
      this.Controls.Add(this.Label4);
      this.Controls.Add(this.dtpTime);
      this.Controls.Add(this.Label3);
      this.Controls.Add(this.gbxAccount);
      this.Name = "frmDBAuto";
      this.Controls.SetChildIndex(this.gbxAccount, 0);
      this.Controls.SetChildIndex(this.Label3, 0);
      this.Controls.SetChildIndex(this.dtpTime, 0);
      this.Controls.SetChildIndex(this.Label4, 0);
      this.Controls.SetChildIndex(this.txtPath, 0);
      this.Controls.SetChildIndex(this.btnDBPath, 0);
      this.Controls.SetChildIndex(this.Label5, 0);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.gbxAccount.ResumeLayout(false);
      this.gbxAccount.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.GroupBox gbxAccount;
    private System.Windows.Forms.TextBox txtDBName;
    private System.Windows.Forms.Label Label2;
    private System.Windows.Forms.TextBox txtAccName;
    private System.Windows.Forms.Label Label1;
    private System.Windows.Forms.Label Label3;
    private System.Windows.Forms.DateTimePicker dtpTime;
    private System.Windows.Forms.Button btnDBPath;
    private System.Windows.Forms.TextBox txtPath;
    private System.Windows.Forms.Label Label4;
    private System.Windows.Forms.Label Label5;
  }
}
