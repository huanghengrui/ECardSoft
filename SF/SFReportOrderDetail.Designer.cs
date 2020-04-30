namespace ECard78
{
  partial class frmSFReportOrderDetail
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSFReportOrderDetail));
      this.btnSelectDepart = new System.Windows.Forms.Button();
      this.txtDepart = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.btnSelectEmp = new System.Windows.Forms.Button();
      this.txtEmp = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.dtpEnd = new System.Windows.Forms.DateTimePicker();
      this.dtpStart = new System.Windows.Forms.DateTimePicker();
      this.label4 = new System.Windows.Forms.Label();
      this.rbAll = new System.Windows.Forms.RadioButton();
      this.rbOrderSF = new System.Windows.Forms.RadioButton();
      this.rbNotOrderSF = new System.Windows.Forms.RadioButton();
      this.rbOrderNoSF = new System.Windows.Forms.RadioButton();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dispView)).BeginInit();
      this.pnlDisp.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.rbOrderNoSF);
      this.panel1.Controls.Add(this.rbNotOrderSF);
      this.panel1.Controls.Add(this.rbOrderSF);
      this.panel1.Controls.Add(this.rbAll);
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
      this.label2.TabIndex = 34;
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
      this.label1.TabIndex = 33;
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
      this.label4.TabIndex = 32;
      this.label4.Tag = "OrderDate";
      this.label4.Text = "label4";
      // 
      // rbAll
      // 
      this.rbAll.AutoSize = true;
      this.rbAll.Checked = true;
      this.rbAll.Location = new System.Drawing.Point(10, 130);
      this.rbAll.Name = "rbAll";
      this.rbAll.Size = new System.Drawing.Size(95, 16);
      this.rbAll.TabIndex = 6;
      this.rbAll.TabStop = true;
      this.rbAll.Text = "radioButton1";
      this.rbAll.UseVisualStyleBackColor = true;
      this.rbAll.Click += new System.EventHandler(this.RadioButton_Click);
      // 
      // rbOrderSF
      // 
      this.rbOrderSF.AutoSize = true;
      this.rbOrderSF.Location = new System.Drawing.Point(10, 150);
      this.rbOrderSF.Name = "rbOrderSF";
      this.rbOrderSF.Size = new System.Drawing.Size(95, 16);
      this.rbOrderSF.TabIndex = 7;
      this.rbOrderSF.Text = "radioButton1";
      this.rbOrderSF.UseVisualStyleBackColor = true;
      this.rbOrderSF.Click += new System.EventHandler(this.RadioButton_Click);
      // 
      // rbNotOrderSF
      // 
      this.rbNotOrderSF.AutoSize = true;
      this.rbNotOrderSF.Location = new System.Drawing.Point(10, 170);
      this.rbNotOrderSF.Name = "rbNotOrderSF";
      this.rbNotOrderSF.Size = new System.Drawing.Size(95, 16);
      this.rbNotOrderSF.TabIndex = 8;
      this.rbNotOrderSF.Text = "radioButton1";
      this.rbNotOrderSF.UseVisualStyleBackColor = true;
      this.rbNotOrderSF.Click += new System.EventHandler(this.RadioButton_Click);
      // 
      // rbOrderNoSF
      // 
      this.rbOrderNoSF.AutoSize = true;
      this.rbOrderNoSF.Location = new System.Drawing.Point(10, 190);
      this.rbOrderNoSF.Name = "rbOrderNoSF";
      this.rbOrderNoSF.Size = new System.Drawing.Size(95, 16);
      this.rbOrderNoSF.TabIndex = 9;
      this.rbOrderNoSF.Text = "radioButton1";
      this.rbOrderNoSF.UseVisualStyleBackColor = true;
      this.rbOrderNoSF.Click += new System.EventHandler(this.RadioButton_Click);
      // 
      // frmSFReportOrderDetail
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(552, 326);
      this.Name = "frmSFReportOrderDetail";
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

    private System.Windows.Forms.Button btnSelectDepart;
    private System.Windows.Forms.TextBox txtDepart;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnSelectEmp;
    private System.Windows.Forms.TextBox txtEmp;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.DateTimePicker dtpEnd;
    private System.Windows.Forms.DateTimePicker dtpStart;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.RadioButton rbOrderSF;
    private System.Windows.Forms.RadioButton rbAll;
    private System.Windows.Forms.RadioButton rbNotOrderSF;
    private System.Windows.Forms.RadioButton rbOrderNoSF;
  }
}
