namespace ECard78
{
  partial class frmSFCheckAccount
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
      this.label1 = new System.Windows.Forms.Label();
      this.txtUp = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.dtpCheck = new System.Windows.Forms.DateTimePicker();
      this.label3 = new System.Windows.Forms.Label();
      this.txtAccName = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.txtDBName = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.txtBak = new System.Windows.Forms.TextBox();
      this.btnDBName = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.upGrid = new System.Windows.Forms.DataGridView();
      this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.dataGrid = new System.Windows.Forms.DataGridView();
      this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.lblMsg = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.upGrid)).BeginInit();
      this.groupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
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
      // txtUp
      // 
      this.txtUp.Location = new System.Drawing.Point(100, 10);
      this.txtUp.Name = "txtUp";
      this.txtUp.ReadOnly = true;
      this.txtUp.Size = new System.Drawing.Size(155, 21);
      this.txtUp.TabIndex = 0;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(300, 14);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(41, 12);
      this.label2.TabIndex = 21;
      this.label2.Text = "label2";
      // 
      // dtpCheck
      // 
      this.dtpCheck.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.dtpCheck.Location = new System.Drawing.Point(390, 10);
      this.dtpCheck.Name = "dtpCheck";
      this.dtpCheck.Size = new System.Drawing.Size(155, 21);
      this.dtpCheck.TabIndex = 1;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(10, 44);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(41, 12);
      this.label3.TabIndex = 23;
      this.label3.Tag = "AccName";
      this.label3.Text = "label3";
      // 
      // txtAccName
      // 
      this.txtAccName.Location = new System.Drawing.Point(100, 40);
      this.txtAccName.Name = "txtAccName";
      this.txtAccName.Size = new System.Drawing.Size(155, 21);
      this.txtAccName.TabIndex = 2;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(300, 44);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(41, 12);
      this.label4.TabIndex = 25;
      this.label4.Tag = "DBName";
      this.label4.Text = "label4";
      // 
      // txtDBName
      // 
      this.txtDBName.Location = new System.Drawing.Point(390, 40);
      this.txtDBName.Name = "txtDBName";
      this.txtDBName.Size = new System.Drawing.Size(155, 21);
      this.txtDBName.TabIndex = 3;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(10, 74);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(41, 12);
      this.label5.TabIndex = 27;
      this.label5.Text = "label5";
      // 
      // txtBak
      // 
      this.txtBak.Location = new System.Drawing.Point(100, 70);
      this.txtBak.Name = "txtBak";
      this.txtBak.ReadOnly = true;
      this.txtBak.Size = new System.Drawing.Size(420, 21);
      this.txtBak.TabIndex = 4;
      // 
      // btnDBName
      // 
      this.btnDBName.Location = new System.Drawing.Point(525, 70);
      this.btnDBName.Name = "btnDBName";
      this.btnDBName.Size = new System.Drawing.Size(20, 20);
      this.btnDBName.TabIndex = 5;
      this.btnDBName.Text = ">";
      this.btnDBName.UseVisualStyleBackColor = true;
      this.btnDBName.Click += new System.EventHandler(this.btnDBName_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.upGrid);
      this.groupBox1.Location = new System.Drawing.Point(10, 100);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(260, 190);
      this.groupBox1.TabIndex = 6;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "groupBox1";
      // 
      // upGrid
      // 
      this.upGrid.AllowUserToAddRows = false;
      this.upGrid.AllowUserToDeleteRows = false;
      this.upGrid.AllowUserToResizeColumns = false;
      this.upGrid.AllowUserToResizeRows = false;
      this.upGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.upGrid.ColumnHeadersVisible = false;
      this.upGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
      this.upGrid.Location = new System.Drawing.Point(10, 20);
      this.upGrid.MultiSelect = false;
      this.upGrid.Name = "upGrid";
      this.upGrid.ReadOnly = true;
      this.upGrid.RowHeadersVisible = false;
      this.upGrid.RowTemplate.Height = 23;
      this.upGrid.Size = new System.Drawing.Size(240, 160);
      this.upGrid.TabIndex = 0;
      // 
      // Column1
      // 
      this.Column1.HeaderText = "Column1";
      this.Column1.Name = "Column1";
      this.Column1.ReadOnly = true;
      this.Column1.Width = 120;
      // 
      // Column2
      // 
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
      this.Column2.HeaderText = "Column2";
      this.Column2.Name = "Column2";
      this.Column2.ReadOnly = true;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.dataGrid);
      this.groupBox2.Location = new System.Drawing.Point(285, 100);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(260, 190);
      this.groupBox2.TabIndex = 7;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "groupBox2";
      // 
      // dataGrid
      // 
      this.dataGrid.AllowUserToAddRows = false;
      this.dataGrid.AllowUserToDeleteRows = false;
      this.dataGrid.AllowUserToResizeColumns = false;
      this.dataGrid.AllowUserToResizeRows = false;
      this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGrid.ColumnHeadersVisible = false;
      this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4});
      this.dataGrid.Location = new System.Drawing.Point(10, 20);
      this.dataGrid.MultiSelect = false;
      this.dataGrid.Name = "dataGrid";
      this.dataGrid.ReadOnly = true;
      this.dataGrid.RowHeadersVisible = false;
      this.dataGrid.RowTemplate.Height = 23;
      this.dataGrid.Size = new System.Drawing.Size(240, 160);
      this.dataGrid.TabIndex = 0;
      // 
      // Column3
      // 
      this.Column3.HeaderText = "Column3";
      this.Column3.Name = "Column3";
      this.Column3.ReadOnly = true;
      this.Column3.Width = 120;
      // 
      // Column4
      // 
      dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      this.Column4.DefaultCellStyle = dataGridViewCellStyle4;
      this.Column4.HeaderText = "Column4";
      this.Column4.Name = "Column4";
      this.Column4.ReadOnly = true;
      // 
      // lblMsg
      // 
      this.lblMsg.AutoSize = true;
      this.lblMsg.ForeColor = System.Drawing.Color.Blue;
      this.lblMsg.Location = new System.Drawing.Point(10, 295);
      this.lblMsg.Name = "lblMsg";
      this.lblMsg.Size = new System.Drawing.Size(41, 12);
      this.lblMsg.TabIndex = 28;
      this.lblMsg.Text = "label6";
      // 
      // frmSFCheckAccount
      // 
      this.AcceptButton = this.btnCancel;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(554, 328);
      this.Controls.Add(this.lblMsg);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.btnDBName);
      this.Controls.Add(this.txtUp);
      this.Controls.Add(this.txtBak);
      this.Controls.Add(this.txtDBName);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.txtAccName);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.dtpCheck);
      this.Name = "frmSFCheckAccount";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSFCheckAccount_FormClosing);
      this.Controls.SetChildIndex(this.dtpCheck, 0);
      this.Controls.SetChildIndex(this.label2, 0);
      this.Controls.SetChildIndex(this.label3, 0);
      this.Controls.SetChildIndex(this.label1, 0);
      this.Controls.SetChildIndex(this.label4, 0);
      this.Controls.SetChildIndex(this.txtAccName, 0);
      this.Controls.SetChildIndex(this.label5, 0);
      this.Controls.SetChildIndex(this.txtDBName, 0);
      this.Controls.SetChildIndex(this.txtBak, 0);
      this.Controls.SetChildIndex(this.txtUp, 0);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.Controls.SetChildIndex(this.btnDBName, 0);
      this.Controls.SetChildIndex(this.groupBox1, 0);
      this.Controls.SetChildIndex(this.groupBox2, 0);
      this.Controls.SetChildIndex(this.lblMsg, 0);
      this.groupBox1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.upGrid)).EndInit();
      this.groupBox2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtUp;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.DateTimePicker dtpCheck;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtAccName;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtDBName;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtBak;
    private System.Windows.Forms.Button btnDBName;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.DataGridView upGrid;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.DataGridView dataGrid;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    private System.Windows.Forms.Label lblMsg;
  }
}
