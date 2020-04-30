namespace ECard78
{
  partial class frmSFAllowance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSFAllowance));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.chkAllowanceStatus = new System.Windows.Forms.CheckBox();
            this.clbAllowanceStatus = new System.Windows.Forms.CheckedListBox();
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
            this.button1 = new System.Windows.Forms.Button();
            this.chkAllowanceStatus1 = new System.Windows.Forms.CheckBox();
            this.clbAllowanceStatus1 = new System.Windows.Forms.CheckedListBox();
            this.btnSelectDepart1 = new System.Windows.Forms.Button();
            this.txtDepart1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSelectEmp1 = new System.Windows.Forms.Button();
            this.txtEmp1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpEnd1 = new System.Windows.Forms.DateTimePicker();
            this.dtpStart1 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dispView = new AxgrproLib.AxGRDisplayViewer();
            this.dispView1 = new AxgrproLib.AxGRDisplayViewer();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dispView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dispView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ilTreeState
            // 
            this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
            this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
            this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
            this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(552, 270);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.dispView);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(544, 244);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.dispView1);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(544, 244);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.chkAllowanceStatus);
            this.panel1.Controls.Add(this.clbAllowanceStatus);
            this.panel1.Controls.Add(this.btnSelectDepart);
            this.panel1.Controls.Add(this.txtDepart);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnSelectEmp);
            this.panel1.Controls.Add(this.txtEmp);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpEnd);
            this.panel1.Controls.Add(this.dtpStart);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 238);
            this.panel1.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(10, 215);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 25);
            this.btnSearch.TabIndex = 33;
            this.btnSearch.Tag = "Search";
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // chkAllowanceStatus
            // 
            this.chkAllowanceStatus.AutoSize = true;
            this.chkAllowanceStatus.Location = new System.Drawing.Point(10, 125);
            this.chkAllowanceStatus.Name = "chkAllowanceStatus";
            this.chkAllowanceStatus.Size = new System.Drawing.Size(78, 16);
            this.chkAllowanceStatus.TabIndex = 31;
            this.chkAllowanceStatus.Tag = "AllowanceStatusName";
            this.chkAllowanceStatus.Text = "checkBox1";
            this.chkAllowanceStatus.UseVisualStyleBackColor = true;
            this.chkAllowanceStatus.CheckedChanged += new System.EventHandler(this.chkAllowanceStatus_CheckedChanged);
            // 
            // clbAllowanceStatus
            // 
            this.clbAllowanceStatus.FormattingEnabled = true;
            this.clbAllowanceStatus.HorizontalScrollbar = true;
            this.clbAllowanceStatus.IntegralHeight = false;
            this.clbAllowanceStatus.Location = new System.Drawing.Point(10, 145);
            this.clbAllowanceStatus.Name = "clbAllowanceStatus";
            this.clbAllowanceStatus.Size = new System.Drawing.Size(160, 60);
            this.clbAllowanceStatus.TabIndex = 32;
            // 
            // btnSelectDepart
            // 
            this.btnSelectDepart.Location = new System.Drawing.Point(135, 96);
            this.btnSelectDepart.Name = "btnSelectDepart";
            this.btnSelectDepart.Size = new System.Drawing.Size(34, 19);
            this.btnSelectDepart.TabIndex = 29;
            this.btnSelectDepart.Text = "button1";
            this.btnSelectDepart.UseVisualStyleBackColor = true;
            this.btnSelectDepart.Click += new System.EventHandler(this.btnSelectDepart_Click);
            // 
            // txtDepart
            // 
            this.txtDepart.Location = new System.Drawing.Point(70, 95);
            this.txtDepart.Name = "txtDepart";
            this.txtDepart.Size = new System.Drawing.Size(100, 21);
            this.txtDepart.TabIndex = 28;
            this.txtDepart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDepart_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 30;
            this.label2.Tag = "Depart";
            this.label2.Text = "label2";
            // 
            // btnSelectEmp
            // 
            this.btnSelectEmp.Location = new System.Drawing.Point(135, 66);
            this.btnSelectEmp.Name = "btnSelectEmp";
            this.btnSelectEmp.Size = new System.Drawing.Size(34, 19);
            this.btnSelectEmp.TabIndex = 26;
            this.btnSelectEmp.Text = "button1";
            this.btnSelectEmp.UseVisualStyleBackColor = true;
            this.btnSelectEmp.Click += new System.EventHandler(this.btnSelectEmp_Click);
            // 
            // txtEmp
            // 
            this.txtEmp.Location = new System.Drawing.Point(70, 65);
            this.txtEmp.Name = "txtEmp";
            this.txtEmp.Size = new System.Drawing.Size(100, 21);
            this.txtEmp.TabIndex = 25;
            this.txtEmp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmp_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 27;
            this.label1.Tag = "Emp";
            this.label1.Text = "label1";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(70, 35);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(100, 21);
            this.dtpEnd.TabIndex = 17;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(70, 10);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(100, 21);
            this.dtpStart.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 18;
            this.label4.Tag = "BTFlag";
            this.label4.Text = "label4";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.chkAllowanceStatus1);
            this.panel2.Controls.Add(this.clbAllowanceStatus1);
            this.panel2.Controls.Add(this.btnSelectDepart1);
            this.panel2.Controls.Add(this.txtDepart1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btnSelectEmp1);
            this.panel2.Controls.Add(this.txtEmp1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.dtpEnd1);
            this.panel2.Controls.Add(this.dtpStart1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(180, 238);
            this.panel2.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 215);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 33;
            this.button1.Tag = "Search";
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkAllowanceStatus1
            // 
            this.chkAllowanceStatus1.AutoSize = true;
            this.chkAllowanceStatus1.Location = new System.Drawing.Point(10, 125);
            this.chkAllowanceStatus1.Name = "chkAllowanceStatus1";
            this.chkAllowanceStatus1.Size = new System.Drawing.Size(78, 16);
            this.chkAllowanceStatus1.TabIndex = 31;
            this.chkAllowanceStatus1.Tag = "AllowanceStatusName";
            this.chkAllowanceStatus1.Text = "checkBox1";
            this.chkAllowanceStatus1.UseVisualStyleBackColor = true;
            this.chkAllowanceStatus1.CheckedChanged += new System.EventHandler(this.chkAllowanceStatus1_CheckedChanged);
            // 
            // clbAllowanceStatus1
            // 
            this.clbAllowanceStatus1.FormattingEnabled = true;
            this.clbAllowanceStatus1.HorizontalScrollbar = true;
            this.clbAllowanceStatus1.IntegralHeight = false;
            this.clbAllowanceStatus1.Location = new System.Drawing.Point(10, 145);
            this.clbAllowanceStatus1.Name = "clbAllowanceStatus1";
            this.clbAllowanceStatus1.Size = new System.Drawing.Size(160, 60);
            this.clbAllowanceStatus1.TabIndex = 32;
            // 
            // btnSelectDepart1
            // 
            this.btnSelectDepart1.Location = new System.Drawing.Point(135, 96);
            this.btnSelectDepart1.Name = "btnSelectDepart1";
            this.btnSelectDepart1.Size = new System.Drawing.Size(34, 19);
            this.btnSelectDepart1.TabIndex = 29;
            this.btnSelectDepart1.Tag = "btnSelectDepart";
            this.btnSelectDepart1.Text = "button1";
            this.btnSelectDepart1.UseVisualStyleBackColor = true;
            this.btnSelectDepart1.Click += new System.EventHandler(this.btnSelectDepart1_Click);
            // 
            // txtDepart1
            // 
            this.txtDepart1.Location = new System.Drawing.Point(70, 95);
            this.txtDepart1.Name = "txtDepart1";
            this.txtDepart1.Size = new System.Drawing.Size(100, 21);
            this.txtDepart1.TabIndex = 28;
            this.txtDepart1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDepart1_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 30;
            this.label3.Tag = "Depart";
            this.label3.Text = "label3";
            // 
            // btnSelectEmp1
            // 
            this.btnSelectEmp1.Location = new System.Drawing.Point(135, 66);
            this.btnSelectEmp1.Name = "btnSelectEmp1";
            this.btnSelectEmp1.Size = new System.Drawing.Size(34, 19);
            this.btnSelectEmp1.TabIndex = 26;
            this.btnSelectEmp1.Tag = "btnSelectEmp";
            this.btnSelectEmp1.Text = "button1";
            this.btnSelectEmp1.UseVisualStyleBackColor = true;
            this.btnSelectEmp1.Click += new System.EventHandler(this.btnSelectEmp1_Click);
            // 
            // txtEmp1
            // 
            this.txtEmp1.Location = new System.Drawing.Point(70, 65);
            this.txtEmp1.Name = "txtEmp1";
            this.txtEmp1.Size = new System.Drawing.Size(100, 21);
            this.txtEmp1.TabIndex = 25;
            this.txtEmp1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmp1_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 27;
            this.label5.Tag = "Emp";
            this.label5.Text = "label5";
            // 
            // dtpEnd1
            // 
            this.dtpEnd1.CustomFormat = "";
            this.dtpEnd1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd1.Location = new System.Drawing.Point(70, 35);
            this.dtpEnd1.Name = "dtpEnd1";
            this.dtpEnd1.Size = new System.Drawing.Size(100, 21);
            this.dtpEnd1.TabIndex = 17;
            // 
            // dtpStart1
            // 
            this.dtpStart1.CustomFormat = "";
            this.dtpStart1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart1.Location = new System.Drawing.Point(70, 10);
            this.dtpStart1.Name = "dtpStart1";
            this.dtpStart1.Size = new System.Drawing.Size(100, 21);
            this.dtpStart1.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 18;
            this.label6.Tag = "BTFlag";
            this.label6.Text = "label6";
            // 
            // dispView
            // 
            this.dispView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dispView.Enabled = true;
            this.dispView.Location = new System.Drawing.Point(183, 3);
            this.dispView.Name = "dispView";
            this.dispView.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("dispView.OcxState")));
            this.dispView.Size = new System.Drawing.Size(358, 238);
            this.dispView.TabIndex = 8;
            this.dispView.TabStop = false;
            // 
            // dispView1
            // 
            this.dispView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dispView1.Enabled = true;
            this.dispView1.Location = new System.Drawing.Point(183, 3);
            this.dispView1.Name = "dispView1";
            this.dispView1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("dispView1.OcxState")));
            this.dispView1.Size = new System.Drawing.Size(358, 238);
            this.dispView1.TabIndex = 6;
            this.dispView1.TabStop = false;
            this.dispView1.MouseDownEvent += new AxgrproLib._IGRDisplayViewerEvents_MouseDownEventHandler(this.dispView1_MouseDownEvent);
            this.dispView1.ColumnLayoutChange += new System.EventHandler(this.dispView1_ColumnLayoutChange);
            this.dispView1.SelectionCellChange += new AxgrproLib._IGRDisplayViewerEvents_SelectionCellChangeEventHandler(this.dispView1_SelectionCellChange);
            // 
            // frmSFAllowance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(552, 326);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSFAllowance";
            this.Activated += new System.EventHandler(this.frmSFAllowance_Activated);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dispView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dispView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.Panel panel1;
    private AxgrproLib.AxGRDisplayViewer dispView1;
    private System.Windows.Forms.DateTimePicker dtpEnd;
    private System.Windows.Forms.DateTimePicker dtpStart;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button btnSelectEmp;
    private System.Windows.Forms.TextBox txtEmp;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnSelectDepart;
    private System.Windows.Forms.TextBox txtDepart;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.CheckBox chkAllowanceStatus;
    private System.Windows.Forms.CheckedListBox clbAllowanceStatus;
    private System.Windows.Forms.Button btnSearch;
        private AxgrproLib.AxGRDisplayViewer dispView;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkAllowanceStatus1;
        private System.Windows.Forms.CheckedListBox clbAllowanceStatus1;
        private System.Windows.Forms.Button btnSelectDepart1;
        private System.Windows.Forms.TextBox txtDepart1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSelectEmp1;
        private System.Windows.Forms.TextBox txtEmp1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpEnd1;
        private System.Windows.Forms.DateTimePicker dtpStart1;
        private System.Windows.Forms.Label label6;
    }
}
