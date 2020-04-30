namespace ECard78
{
  partial class frmSFAllowanceAdd
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
      this.label1 = new System.Windows.Forms.Label();
      this.dtpFlag = new System.Windows.Forms.DateTimePicker();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.cbbWay = new System.Windows.Forms.ComboBox();
      this.label4 = new System.Windows.Forms.Label();
      this.txtMoney = new System.Windows.Forms.TextBox();
      this.lblQuickSearchToolTip = new System.Windows.Forms.Label();
      this.txtQuickSearch = new System.Windows.Forms.TextBox();
      this.lblQuickSearch = new System.Windows.Forms.Label();
      this.btnQuickSearch = new System.Windows.Forms.Button();
      this.cardGrid = new System.Windows.Forms.DataGridView();
      this.button1 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.progBar = new System.Windows.Forms.ProgressBar();
      ((System.ComponentModel.ISupportInitialize)(this.cardGrid)).BeginInit();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(510, 335);
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(430, 335);
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
      this.label1.Tag = "AllowanceFlag";
      this.label1.Text = "label1";
      // 
      // dtpFlag
      // 
      this.dtpFlag.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.dtpFlag.Location = new System.Drawing.Point(100, 10);
      this.dtpFlag.Name = "dtpFlag";
      this.dtpFlag.Size = new System.Drawing.Size(100, 21);
      this.dtpFlag.TabIndex = 0;
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.label2.ForeColor = System.Drawing.Color.Blue;
      this.label2.Location = new System.Drawing.Point(205, 10);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(380, 25);
      this.label2.TabIndex = 21;
      this.label2.Text = "label2";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(10, 44);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(41, 12);
      this.label3.TabIndex = 22;
      this.label3.Tag = "AllowanceWayName";
      this.label3.Text = "label3";
      // 
      // cbbWay
      // 
      this.cbbWay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbWay.FormattingEnabled = true;
      this.cbbWay.Location = new System.Drawing.Point(100, 40);
      this.cbbWay.Name = "cbbWay";
      this.cbbWay.Size = new System.Drawing.Size(100, 20);
      this.cbbWay.TabIndex = 1;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(10, 74);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(41, 12);
      this.label4.TabIndex = 24;
      this.label4.Tag = "AllowanceAmount";
      this.label4.Text = "label4";
      // 
      // txtMoney
      // 
      this.txtMoney.Location = new System.Drawing.Point(100, 70);
      this.txtMoney.Name = "txtMoney";
      this.txtMoney.Size = new System.Drawing.Size(100, 21);
      this.txtMoney.TabIndex = 2;
      // 
      // lblQuickSearchToolTip
      // 
      this.lblQuickSearchToolTip.AutoSize = true;
      this.lblQuickSearchToolTip.ForeColor = System.Drawing.Color.Blue;
      this.lblQuickSearchToolTip.Location = new System.Drawing.Point(275, 110);
      this.lblQuickSearchToolTip.Name = "lblQuickSearchToolTip";
      this.lblQuickSearchToolTip.Size = new System.Drawing.Size(41, 12);
      this.lblQuickSearchToolTip.TabIndex = 29;
      this.lblQuickSearchToolTip.Text = "label1";
      // 
      // txtQuickSearch
      // 
      this.txtQuickSearch.Location = new System.Drawing.Point(170, 105);
      this.txtQuickSearch.Name = "txtQuickSearch";
      this.txtQuickSearch.Size = new System.Drawing.Size(100, 21);
      this.txtQuickSearch.TabIndex = 4;
      this.txtQuickSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuickSearch_KeyDown);
      // 
      // lblQuickSearch
      // 
      this.lblQuickSearch.AutoSize = true;
      this.lblQuickSearch.Location = new System.Drawing.Point(90, 109);
      this.lblQuickSearch.Name = "lblQuickSearch";
      this.lblQuickSearch.Size = new System.Drawing.Size(41, 12);
      this.lblQuickSearch.TabIndex = 27;
      this.lblQuickSearch.Text = "label1";
      // 
      // btnQuickSearch
      // 
      this.btnQuickSearch.Location = new System.Drawing.Point(10, 105);
      this.btnQuickSearch.Name = "btnQuickSearch";
      this.btnQuickSearch.Size = new System.Drawing.Size(75, 25);
      this.btnQuickSearch.TabIndex = 3;
      this.btnQuickSearch.Text = "button1";
      this.btnQuickSearch.UseVisualStyleBackColor = true;
      this.btnQuickSearch.Click += new System.EventHandler(this.btnQuickSearch_Click);
      // 
      // cardGrid
      // 
      this.cardGrid.AllowUserToAddRows = false;
      this.cardGrid.AllowUserToDeleteRows = false;
      this.cardGrid.AllowUserToResizeRows = false;
      this.cardGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.cardGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
      this.cardGrid.ColumnHeadersHeight = 25;
      this.cardGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.cardGrid.DefaultCellStyle = dataGridViewCellStyle8;
      this.cardGrid.Location = new System.Drawing.Point(10, 135);
      this.cardGrid.MultiSelect = false;
      this.cardGrid.Name = "cardGrid";
      this.cardGrid.ReadOnly = true;
      this.cardGrid.RowHeadersVisible = false;
      this.cardGrid.RowTemplate.Height = 23;
      this.cardGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.cardGrid.Size = new System.Drawing.Size(575, 190);
      this.cardGrid.StandardTab = true;
      this.cardGrid.TabIndex = 30;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(10, 335);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 25);
      this.button1.TabIndex = 5;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(90, 335);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(75, 25);
      this.button2.TabIndex = 6;
      this.button2.Text = "button2";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // progBar
      // 
      this.progBar.Location = new System.Drawing.Point(181, 337);
      this.progBar.Name = "progBar";
      this.progBar.Size = new System.Drawing.Size(243, 20);
      this.progBar.Step = 1;
      this.progBar.TabIndex = 31;
      this.progBar.Visible = false;
      // 
      // frmSFAllowanceAdd
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(594, 368);
      this.Controls.Add(this.progBar);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.cardGrid);
      this.Controls.Add(this.lblQuickSearchToolTip);
      this.Controls.Add(this.txtQuickSearch);
      this.Controls.Add(this.lblQuickSearch);
      this.Controls.Add(this.btnQuickSearch);
      this.Controls.Add(this.txtMoney);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.cbbWay);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.dtpFlag);
      this.Name = "frmSFAllowanceAdd";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSFAllowanceAdd_FormClosing);
      this.Controls.SetChildIndex(this.dtpFlag, 0);
      this.Controls.SetChildIndex(this.label1, 0);
      this.Controls.SetChildIndex(this.label2, 0);
      this.Controls.SetChildIndex(this.label3, 0);
      this.Controls.SetChildIndex(this.cbbWay, 0);
      this.Controls.SetChildIndex(this.label4, 0);
      this.Controls.SetChildIndex(this.txtMoney, 0);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.Controls.SetChildIndex(this.btnQuickSearch, 0);
      this.Controls.SetChildIndex(this.lblQuickSearch, 0);
      this.Controls.SetChildIndex(this.txtQuickSearch, 0);
      this.Controls.SetChildIndex(this.lblQuickSearchToolTip, 0);
      this.Controls.SetChildIndex(this.cardGrid, 0);
      this.Controls.SetChildIndex(this.button1, 0);
      this.Controls.SetChildIndex(this.button2, 0);
      this.Controls.SetChildIndex(this.progBar, 0);
      ((System.ComponentModel.ISupportInitialize)(this.cardGrid)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.DateTimePicker dtpFlag;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ComboBox cbbWay;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtMoney;
    private System.Windows.Forms.Label lblQuickSearchToolTip;
    private System.Windows.Forms.TextBox txtQuickSearch;
    private System.Windows.Forms.Label lblQuickSearch;
    private System.Windows.Forms.Button btnQuickSearch;
    private System.Windows.Forms.DataGridView cardGrid;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.ProgressBar progBar;
  }
}
