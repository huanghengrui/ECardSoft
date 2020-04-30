namespace ECard78
{
  partial class frmSFQueryIncomeCount
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSFQueryIncomeCount));
      this.dtpEnd = new System.Windows.Forms.DateTimePicker();
      this.dtpStart = new System.Windows.Forms.DateTimePicker();
      this.label4 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.rbCardType = new System.Windows.Forms.RadioButton();
      this.rbSysOprt = new System.Windows.Forms.RadioButton();
      this.rbOprt = new System.Windows.Forms.RadioButton();
      this.rbDept = new System.Windows.Forms.RadioButton();
      this.btnSelectDepart = new System.Windows.Forms.Button();
      this.txtDepart = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.btnSelectEmp = new System.Windows.Forms.Button();
      this.txtEmp = new System.Windows.Forms.TextBox();
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
      this.panel1.Controls.Add(this.btnSelectDepart);
      this.panel1.Controls.Add(this.txtDepart);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.btnSelectEmp);
      this.panel1.Controls.Add(this.txtEmp);
      this.panel1.Controls.Add(this.label3);
      this.panel1.Controls.Add(this.panel2);
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
      this.label4.Tag = "SFDate";
      this.label4.Text = "label4";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(10, 129);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 12);
      this.label1.TabIndex = 15;
      this.label1.Tag = "ReportType";
      this.label1.Text = "label1";
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.rbCardType);
      this.panel2.Controls.Add(this.rbSysOprt);
      this.panel2.Controls.Add(this.rbOprt);
      this.panel2.Controls.Add(this.rbDept);
      this.panel2.Location = new System.Drawing.Point(70, 125);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(140, 80);
      this.panel2.TabIndex = 6;
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
      // rbSysOprt
      // 
      this.rbSysOprt.AutoSize = true;
      this.rbSysOprt.Location = new System.Drawing.Point(0, 40);
      this.rbSysOprt.Name = "rbSysOprt";
      this.rbSysOprt.Size = new System.Drawing.Size(95, 16);
      this.rbSysOprt.TabIndex = 2;
      this.rbSysOprt.Text = "radioButton2";
      this.rbSysOprt.UseVisualStyleBackColor = true;
      this.rbSysOprt.Click += new System.EventHandler(this.RadioButton_Click);
      // 
      // rbOprt
      // 
      this.rbOprt.AutoSize = true;
      this.rbOprt.Location = new System.Drawing.Point(0, 20);
      this.rbOprt.Name = "rbOprt";
      this.rbOprt.Size = new System.Drawing.Size(95, 16);
      this.rbOprt.TabIndex = 1;
      this.rbOprt.Text = "radioButton1";
      this.rbOprt.UseVisualStyleBackColor = true;
      this.rbOprt.Click += new System.EventHandler(this.RadioButton_Click);
      // 
      // rbDept
      // 
      this.rbDept.AutoSize = true;
      this.rbDept.Checked = true;
      this.rbDept.Location = new System.Drawing.Point(0, 0);
      this.rbDept.Name = "rbDept";
      this.rbDept.Size = new System.Drawing.Size(95, 16);
      this.rbDept.TabIndex = 0;
      this.rbDept.TabStop = true;
      this.rbDept.Text = "radioButton1";
      this.rbDept.UseVisualStyleBackColor = true;
      this.rbDept.Click += new System.EventHandler(this.RadioButton_Click);
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
      this.label2.TabIndex = 20;
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
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(10, 69);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(41, 12);
      this.label3.TabIndex = 17;
      this.label3.Tag = "Emp";
      this.label3.Text = "label3";
      // 
      // frmSFQueryIncomeCount
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(552, 326);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "frmSFQueryIncomeCount";
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

    private System.Windows.Forms.DateTimePicker dtpEnd;
    private System.Windows.Forms.DateTimePicker dtpStart;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.RadioButton rbDept;
    private System.Windows.Forms.RadioButton rbCardType;
    private System.Windows.Forms.RadioButton rbSysOprt;
    private System.Windows.Forms.RadioButton rbOprt;
    private System.Windows.Forms.Button btnSelectDepart;
    private System.Windows.Forms.TextBox txtDepart;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnSelectEmp;
    private System.Windows.Forms.TextBox txtEmp;
    private System.Windows.Forms.Label label3;
  }
}
