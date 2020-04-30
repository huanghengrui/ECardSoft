namespace ECard78
{
  partial class frmMJMacTimeGroup
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
      this.txtName = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtID = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.cbbSun = new System.Windows.Forms.ComboBox();
      this.cbbMon = new System.Windows.Forms.ComboBox();
      this.label4 = new System.Windows.Forms.Label();
      this.cbbTue = new System.Windows.Forms.ComboBox();
      this.label5 = new System.Windows.Forms.Label();
      this.cbbWed = new System.Windows.Forms.ComboBox();
      this.label6 = new System.Windows.Forms.Label();
      this.cbbThu = new System.Windows.Forms.ComboBox();
      this.label7 = new System.Windows.Forms.Label();
      this.cbbFri = new System.Windows.Forms.ComboBox();
      this.label8 = new System.Windows.Forms.Label();
      this.cbbSat = new System.Windows.Forms.ComboBox();
      this.label9 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(180, 285);
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(100, 285);
      this.btnOk.Text = "";
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // txtName
      // 
      this.txtName.Location = new System.Drawing.Point(100, 40);
      this.txtName.MaxLength = 50;
      this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(155, 21);
      this.txtName.TabIndex = 1;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(10, 44);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(47, 12);
      this.label2.TabIndex = 25;
      this.label2.Tag = "MacTimeHeaderName";
      this.label2.Text = "label10";
      // 
      // txtID
      // 
      this.txtID.Location = new System.Drawing.Point(100, 10);
      this.txtID.MaxLength = 50;
      this.txtID.Name = "txtID";
      this.txtID.Size = new System.Drawing.Size(155, 21);
      this.txtID.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(10, 14);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 12);
      this.label1.TabIndex = 24;
      this.label1.Tag = "MacTimeHeaderTimeNo";
      this.label1.Text = "label1";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(10, 74);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(47, 12);
      this.label3.TabIndex = 26;
      this.label3.Tag = "Sunday";
      this.label3.Text = "label10";
      // 
      // cbbSun
      // 
      this.cbbSun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbSun.FormattingEnabled = true;
      this.cbbSun.Location = new System.Drawing.Point(100, 70);
      this.cbbSun.Name = "cbbSun";
      this.cbbSun.Size = new System.Drawing.Size(155, 20);
      this.cbbSun.TabIndex = 2;
      // 
      // cbbMon
      // 
      this.cbbMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbMon.FormattingEnabled = true;
      this.cbbMon.Location = new System.Drawing.Point(100, 100);
      this.cbbMon.Name = "cbbMon";
      this.cbbMon.Size = new System.Drawing.Size(155, 20);
      this.cbbMon.TabIndex = 3;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(10, 104);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(47, 12);
      this.label4.TabIndex = 28;
      this.label4.Tag = "Monday";
      this.label4.Text = "label10";
      // 
      // cbbTue
      // 
      this.cbbTue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbTue.FormattingEnabled = true;
      this.cbbTue.Location = new System.Drawing.Point(100, 130);
      this.cbbTue.Name = "cbbTue";
      this.cbbTue.Size = new System.Drawing.Size(155, 20);
      this.cbbTue.TabIndex = 4;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(10, 134);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(47, 12);
      this.label5.TabIndex = 30;
      this.label5.Tag = "Tuesday";
      this.label5.Text = "label10";
      // 
      // cbbWed
      // 
      this.cbbWed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbWed.FormattingEnabled = true;
      this.cbbWed.Location = new System.Drawing.Point(100, 160);
      this.cbbWed.Name = "cbbWed";
      this.cbbWed.Size = new System.Drawing.Size(155, 20);
      this.cbbWed.TabIndex = 5;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(10, 164);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(47, 12);
      this.label6.TabIndex = 32;
      this.label6.Tag = "Wednesday";
      this.label6.Text = "label10";
      // 
      // cbbThu
      // 
      this.cbbThu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbThu.FormattingEnabled = true;
      this.cbbThu.Location = new System.Drawing.Point(100, 190);
      this.cbbThu.Name = "cbbThu";
      this.cbbThu.Size = new System.Drawing.Size(155, 20);
      this.cbbThu.TabIndex = 6;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(10, 194);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(47, 12);
      this.label7.TabIndex = 34;
      this.label7.Tag = "Thursday";
      this.label7.Text = "label10";
      // 
      // cbbFri
      // 
      this.cbbFri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbFri.FormattingEnabled = true;
      this.cbbFri.Location = new System.Drawing.Point(100, 220);
      this.cbbFri.Name = "cbbFri";
      this.cbbFri.Size = new System.Drawing.Size(155, 20);
      this.cbbFri.TabIndex = 7;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(10, 224);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(47, 12);
      this.label8.TabIndex = 36;
      this.label8.Tag = "Friday";
      this.label8.Text = "label10";
      // 
      // cbbSat
      // 
      this.cbbSat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbSat.FormattingEnabled = true;
      this.cbbSat.Location = new System.Drawing.Point(100, 250);
      this.cbbSat.Name = "cbbSat";
      this.cbbSat.Size = new System.Drawing.Size(155, 20);
      this.cbbSat.TabIndex = 8;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(10, 254);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(47, 12);
      this.label9.TabIndex = 38;
      this.label9.Tag = "Saturday";
      this.label9.Text = "label10";
      // 
      // frmMJMacTimeGroup
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(264, 318);
      this.Controls.Add(this.cbbSat);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.cbbFri);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.cbbThu);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.cbbWed);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.cbbTue);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.cbbMon);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.cbbSun);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txtName);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txtID);
      this.Controls.Add(this.label1);
      this.Name = "frmMJMacTimeGroup";
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.Controls.SetChildIndex(this.label1, 0);
      this.Controls.SetChildIndex(this.txtID, 0);
      this.Controls.SetChildIndex(this.label2, 0);
      this.Controls.SetChildIndex(this.txtName, 0);
      this.Controls.SetChildIndex(this.label3, 0);
      this.Controls.SetChildIndex(this.cbbSun, 0);
      this.Controls.SetChildIndex(this.label4, 0);
      this.Controls.SetChildIndex(this.cbbMon, 0);
      this.Controls.SetChildIndex(this.label5, 0);
      this.Controls.SetChildIndex(this.cbbTue, 0);
      this.Controls.SetChildIndex(this.label6, 0);
      this.Controls.SetChildIndex(this.cbbWed, 0);
      this.Controls.SetChildIndex(this.label7, 0);
      this.Controls.SetChildIndex(this.cbbThu, 0);
      this.Controls.SetChildIndex(this.label8, 0);
      this.Controls.SetChildIndex(this.cbbFri, 0);
      this.Controls.SetChildIndex(this.label9, 0);
      this.Controls.SetChildIndex(this.cbbSat, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtID;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ComboBox cbbSun;
    private System.Windows.Forms.ComboBox cbbMon;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ComboBox cbbTue;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ComboBox cbbWed;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.ComboBox cbbThu;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.ComboBox cbbFri;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.ComboBox cbbSat;
    private System.Windows.Forms.Label label9;
  }
}
