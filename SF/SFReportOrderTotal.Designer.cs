namespace ECard78
{
  partial class frmSFReportOrderTotal
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSFReportOrderTotal));
      this.btnSelectDepart = new System.Windows.Forms.Button();
      this.txtDepart = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.btnSelectEmp = new System.Windows.Forms.Button();
      this.txtEmp = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.dtpEnd = new System.Windows.Forms.DateTimePicker();
      this.dtpStart = new System.Windows.Forms.DateTimePicker();
      this.label4 = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.rbMac = new System.Windows.Forms.RadioButton();
      this.rbCardType = new System.Windows.Forms.RadioButton();
      this.rbDate = new System.Windows.Forms.RadioButton();
      this.rbDept = new System.Windows.Forms.RadioButton();
      this.rbEmp = new System.Windows.Forms.RadioButton();
      this.label3 = new System.Windows.Forms.Label();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dispView)).BeginInit();
      this.pnlDisp.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.panel2);
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
      // 
      // dispView
      // 
      this.dispView.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("dispView.OcxState")));
      // 
      // btnSelectDepart
      // 
      this.btnSelectDepart.Location = new System.Drawing.Point(135, 96);
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
      this.txtDepart.Size = new System.Drawing.Size(100, 21);
      this.txtDepart.TabIndex = 4;
      this.txtDepart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDepart_KeyPress);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(10, 99);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(41, 12);
      this.label2.TabIndex = 43;
      this.label2.Tag = "Depart";
      this.label2.Text = "label2";
      // 
      // btnSelectEmp
      // 
      this.btnSelectEmp.Location = new System.Drawing.Point(135, 66);
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
      this.txtEmp.Size = new System.Drawing.Size(100, 21);
      this.txtEmp.TabIndex = 2;
      this.txtEmp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmp_KeyPress);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(10, 69);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 12);
      this.label1.TabIndex = 42;
      this.label1.Tag = "Emp";
      this.label1.Text = "label1";
      // 
      // dtpEnd
      // 
      this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.dtpEnd.Location = new System.Drawing.Point(70, 35);
      this.dtpEnd.Name = "dtpEnd";
      this.dtpEnd.Size = new System.Drawing.Size(100, 21);
      this.dtpEnd.TabIndex = 1;
      // 
      // dtpStart
      // 
      this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.dtpStart.Location = new System.Drawing.Point(70, 10);
      this.dtpStart.Name = "dtpStart";
      this.dtpStart.Size = new System.Drawing.Size(100, 21);
      this.dtpStart.TabIndex = 0;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(10, 14);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(41, 12);
      this.label4.TabIndex = 41;
      this.label4.Tag = "OrderDate";
      this.label4.Text = "label4";
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.rbMac);
      this.panel2.Controls.Add(this.rbCardType);
      this.panel2.Controls.Add(this.rbDate);
      this.panel2.Controls.Add(this.rbDept);
      this.panel2.Controls.Add(this.rbEmp);
      this.panel2.Location = new System.Drawing.Point(70, 125);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(100, 100);
      this.panel2.TabIndex = 6;
      // 
      // rbMac
      // 
      this.rbMac.AutoSize = true;
      this.rbMac.Location = new System.Drawing.Point(0, 80);
      this.rbMac.Name = "rbMac";
      this.rbMac.Size = new System.Drawing.Size(14, 13);
      this.rbMac.TabIndex = 4;
      this.rbMac.UseVisualStyleBackColor = true;
      this.rbMac.Click += new System.EventHandler(this.RadioButton_Click);
      // 
      // rbCardType
      // 
      this.rbCardType.AutoSize = true;
      this.rbCardType.Location = new System.Drawing.Point(0, 60);
      this.rbCardType.Name = "rbCardType";
      this.rbCardType.Size = new System.Drawing.Size(95, 16);
      this.rbCardType.TabIndex = 3;
      this.rbCardType.Text = "radioButton3";
      this.rbCardType.UseVisualStyleBackColor = true;
      this.rbCardType.Click += new System.EventHandler(this.RadioButton_Click);
      // 
      // rbDate
      // 
      this.rbDate.AutoSize = true;
      this.rbDate.Location = new System.Drawing.Point(0, 40);
      this.rbDate.Name = "rbDate";
      this.rbDate.Size = new System.Drawing.Size(95, 16);
      this.rbDate.TabIndex = 2;
      this.rbDate.Text = "radioButton2";
      this.rbDate.UseVisualStyleBackColor = true;
      this.rbDate.Click += new System.EventHandler(this.RadioButton_Click);
      // 
      // rbDept
      // 
      this.rbDept.AutoSize = true;
      this.rbDept.Location = new System.Drawing.Point(0, 20);
      this.rbDept.Name = "rbDept";
      this.rbDept.Size = new System.Drawing.Size(95, 16);
      this.rbDept.TabIndex = 1;
      this.rbDept.Text = "radioButton1";
      this.rbDept.UseVisualStyleBackColor = true;
      this.rbDept.Click += new System.EventHandler(this.RadioButton_Click);
      // 
      // rbEmp
      // 
      this.rbEmp.AutoSize = true;
      this.rbEmp.Checked = true;
      this.rbEmp.Location = new System.Drawing.Point(0, 0);
      this.rbEmp.Name = "rbEmp";
      this.rbEmp.Size = new System.Drawing.Size(95, 16);
      this.rbEmp.TabIndex = 0;
      this.rbEmp.TabStop = true;
      this.rbEmp.Text = "radioButton1";
      this.rbEmp.UseVisualStyleBackColor = true;
      this.rbEmp.Click += new System.EventHandler(this.RadioButton_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(10, 129);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(41, 12);
      this.label3.TabIndex = 45;
      this.label3.Tag = "ReportType";
      this.label3.Text = "label3";
      // 
      // frmSFReportOrderTotal
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(552, 326);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "frmSFReportOrderTotal";
      this.Controls.SetChildIndex(this.panel1, 0);
      this.Controls.SetChildIndex(this.pnlDisp, 0);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dispView)).EndInit();
      this.pnlDisp.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnSelectDepart;
    private System.Windows.Forms.TextBox txtDepart;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnSelectEmp;
    private System.Windows.Forms.TextBox txtEmp;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.DateTimePicker dtpEnd;
    private System.Windows.Forms.DateTimePicker dtpStart;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.RadioButton rbCardType;
    private System.Windows.Forms.RadioButton rbDate;
    private System.Windows.Forms.RadioButton rbDept;
    private System.Windows.Forms.RadioButton rbEmp;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.RadioButton rbMac;
  }
}
