namespace ECard78
{
  partial class frmMJMacInOutConfirmEdit
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
      this.chkEnabled = new System.Windows.Forms.CheckBox();
      this.gbxEmpInfo = new System.Windows.Forms.GroupBox();
      this.cardGrid = new System.Windows.Forms.DataGridView();
      this.lblQuickSearchToolTip = new System.Windows.Forms.Label();
      this.txtQuickSearch = new System.Windows.Forms.TextBox();
      this.lblQuickSearch = new System.Windows.Forms.Label();
      this.btnQuickSearch = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.btnClear = new System.Windows.Forms.Button();
      this.gbxEmpInfo.SuspendLayout();
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
      // chkEnabled
      // 
      this.chkEnabled.AutoSize = true;
      this.chkEnabled.Location = new System.Drawing.Point(10, 10);
      this.chkEnabled.Name = "chkEnabled";
      this.chkEnabled.Size = new System.Drawing.Size(78, 16);
      this.chkEnabled.TabIndex = 0;
      this.chkEnabled.Text = "checkBox1";
      this.chkEnabled.UseVisualStyleBackColor = true;
      this.chkEnabled.CheckedChanged += new System.EventHandler(this.chkEnabled_CheckedChanged);
      // 
      // gbxEmpInfo
      // 
      this.gbxEmpInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.gbxEmpInfo.Controls.Add(this.btnClear);
      this.gbxEmpInfo.Controls.Add(this.cardGrid);
      this.gbxEmpInfo.Controls.Add(this.lblQuickSearchToolTip);
      this.gbxEmpInfo.Controls.Add(this.txtQuickSearch);
      this.gbxEmpInfo.Controls.Add(this.lblQuickSearch);
      this.gbxEmpInfo.Controls.Add(this.btnQuickSearch);
      this.gbxEmpInfo.Location = new System.Drawing.Point(10, 35);
      this.gbxEmpInfo.Name = "gbxEmpInfo";
      this.gbxEmpInfo.Size = new System.Drawing.Size(575, 290);
      this.gbxEmpInfo.TabIndex = 1;
      this.gbxEmpInfo.TabStop = false;
      this.gbxEmpInfo.Text = "groupBox1";
      // 
      // cardGrid
      // 
      this.cardGrid.AllowUserToAddRows = false;
      this.cardGrid.AllowUserToDeleteRows = false;
      this.cardGrid.AllowUserToResizeRows = false;
      this.cardGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle5.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.cardGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
      this.cardGrid.ColumnHeadersHeight = 25;
      this.cardGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle6.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.cardGrid.DefaultCellStyle = dataGridViewCellStyle6;
      this.cardGrid.Location = new System.Drawing.Point(10, 50);
      this.cardGrid.MultiSelect = false;
      this.cardGrid.Name = "cardGrid";
      this.cardGrid.ReadOnly = true;
      this.cardGrid.RowHeadersVisible = false;
      this.cardGrid.RowTemplate.Height = 23;
      this.cardGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.cardGrid.Size = new System.Drawing.Size(555, 230);
      this.cardGrid.StandardTab = true;
      this.cardGrid.TabIndex = 9;
      // 
      // lblQuickSearchToolTip
      // 
      this.lblQuickSearchToolTip.AutoSize = true;
      this.lblQuickSearchToolTip.ForeColor = System.Drawing.Color.Blue;
      this.lblQuickSearchToolTip.Location = new System.Drawing.Point(355, 26);
      this.lblQuickSearchToolTip.Name = "lblQuickSearchToolTip";
      this.lblQuickSearchToolTip.Size = new System.Drawing.Size(41, 12);
      this.lblQuickSearchToolTip.TabIndex = 7;
      this.lblQuickSearchToolTip.Text = "label1";
      // 
      // txtQuickSearch
      // 
      this.txtQuickSearch.Location = new System.Drawing.Point(250, 22);
      this.txtQuickSearch.Name = "txtQuickSearch";
      this.txtQuickSearch.Size = new System.Drawing.Size(100, 21);
      this.txtQuickSearch.TabIndex = 6;
      this.txtQuickSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuickSearch_KeyDown);
      // 
      // lblQuickSearch
      // 
      this.lblQuickSearch.AutoSize = true;
      this.lblQuickSearch.Location = new System.Drawing.Point(170, 26);
      this.lblQuickSearch.Name = "lblQuickSearch";
      this.lblQuickSearch.Size = new System.Drawing.Size(41, 12);
      this.lblQuickSearch.TabIndex = 5;
      this.lblQuickSearch.Text = "label1";
      // 
      // btnQuickSearch
      // 
      this.btnQuickSearch.Location = new System.Drawing.Point(10, 20);
      this.btnQuickSearch.Name = "btnQuickSearch";
      this.btnQuickSearch.Size = new System.Drawing.Size(75, 25);
      this.btnQuickSearch.TabIndex = 4;
      this.btnQuickSearch.Text = "button1";
      this.btnQuickSearch.UseVisualStyleBackColor = true;
      this.btnQuickSearch.Click += new System.EventHandler(this.btnQuickSearch_Click);
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label2.AutoSize = true;
      this.label2.ForeColor = System.Drawing.Color.Blue;
      this.label2.Location = new System.Drawing.Point(10, 345);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(41, 12);
      this.label2.TabIndex = 20;
      this.label2.Text = "label2";
      // 
      // btnClear
      // 
      this.btnClear.Location = new System.Drawing.Point(90, 20);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new System.Drawing.Size(75, 25);
      this.btnClear.TabIndex = 5;
      this.btnClear.Text = "button1";
      this.btnClear.UseVisualStyleBackColor = true;
      this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
      // 
      // frmMJMacInOutConfirmEdit
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(594, 368);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.gbxEmpInfo);
      this.Controls.Add(this.chkEnabled);
      this.Name = "frmMJMacInOutConfirmEdit";
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.Controls.SetChildIndex(this.chkEnabled, 0);
      this.Controls.SetChildIndex(this.gbxEmpInfo, 0);
      this.Controls.SetChildIndex(this.label2, 0);
      this.gbxEmpInfo.ResumeLayout(false);
      this.gbxEmpInfo.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cardGrid)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.CheckBox chkEnabled;
    private System.Windows.Forms.GroupBox gbxEmpInfo;
    private System.Windows.Forms.DataGridView cardGrid;
    private System.Windows.Forms.Label lblQuickSearchToolTip;
    private System.Windows.Forms.TextBox txtQuickSearch;
    private System.Windows.Forms.Label lblQuickSearch;
    private System.Windows.Forms.Button btnQuickSearch;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnClear;
  }
}
