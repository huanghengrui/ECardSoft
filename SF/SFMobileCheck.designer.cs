namespace ECard78
{
  partial class frmSFMobileCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSFMobileCheck));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.gbxInfo = new System.Windows.Forms.GroupBox();
            this.clbUserInfo = new System.Windows.Forms.CheckedListBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.gbxRet = new System.Windows.Forms.GroupBox();
            this.retGrid = new System.Windows.Forms.DataGridView();
            this.btnCheck = new System.Windows.Forms.Button();
            this.lbRet = new System.Windows.Forms.ListBox();
            this.lblUserInfo = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbCount = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.gbxInfo.SuspendLayout();
            this.gbxRet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.retGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1064, 580);
            this.btnCancel.TabIndex = 1001;
            this.btnCancel.Text = "";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(984, 580);
            this.btnOk.TabIndex = 1000;
            this.btnOk.Text = "";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // ilTreeState
            // 
            this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
            this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
            this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
            this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
            // 
            // dlgOpen
            // 
            this.dlgOpen.Filter = "JPEG|*.jpg";
            // 
            // gbxInfo
            // 
            this.gbxInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxInfo.Controls.Add(this.dtpEnd);
            this.gbxInfo.Controls.Add(this.lblEndTime);
            this.gbxInfo.Controls.Add(this.dtpStart);
            this.gbxInfo.Controls.Add(this.lblStartTime);
            this.gbxInfo.Location = new System.Drawing.Point(10, 10);
            this.gbxInfo.Name = "gbxInfo";
            this.gbxInfo.Size = new System.Drawing.Size(241, 91);
            this.gbxInfo.TabIndex = 0;
            this.gbxInfo.TabStop = false;
            this.gbxInfo.Text = "groupBox1";
            // 
            // clbUserInfo
            // 
            this.clbUserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbUserInfo.FormattingEnabled = true;
            this.clbUserInfo.IntegralHeight = false;
            this.clbUserInfo.Location = new System.Drawing.Point(12, 122);
            this.clbUserInfo.Name = "clbUserInfo";
            this.clbUserInfo.Size = new System.Drawing.Size(239, 373);
            this.clbUserInfo.TabIndex = 6;
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(95, 50);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.ShowUpDown = true;
            this.dtpEnd.Size = new System.Drawing.Size(140, 21);
            this.dtpEnd.TabIndex = 4;
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(15, 53);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(41, 12);
            this.lblEndTime.TabIndex = 3;
            this.lblEndTime.Text = "label2";
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(95, 20);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.ShowUpDown = true;
            this.dtpStart.Size = new System.Drawing.Size(140, 21);
            this.dtpStart.TabIndex = 2;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(15, 23);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(41, 12);
            this.lblStartTime.TabIndex = 1;
            this.lblStartTime.Text = "label1";
            // 
            // gbxRet
            // 
            this.gbxRet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxRet.Controls.Add(this.retGrid);
            this.gbxRet.Location = new System.Drawing.Point(252, 21);
            this.gbxRet.Name = "gbxRet";
            this.gbxRet.Size = new System.Drawing.Size(887, 477);
            this.gbxRet.TabIndex = 7;
            this.gbxRet.TabStop = false;
            this.gbxRet.Text = "groupBox1";
            // 
            // retGrid
            // 
            this.retGrid.AllowUserToAddRows = false;
            this.retGrid.AllowUserToDeleteRows = false;
            this.retGrid.AllowUserToResizeRows = false;
            this.retGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.retGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.retGrid.ColumnHeadersHeight = 25;
            this.retGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.retGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.retGrid.Location = new System.Drawing.Point(15, 20);
            this.retGrid.MultiSelect = false;
            this.retGrid.Name = "retGrid";
            this.retGrid.ReadOnly = true;
            this.retGrid.RowHeadersVisible = false;
            this.retGrid.RowTemplate.Height = 23;
            this.retGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.retGrid.Size = new System.Drawing.Size(862, 451);
            this.retGrid.StandardTab = true;
            this.retGrid.TabIndex = 8;
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCheck.Location = new System.Drawing.Point(10, 580);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 25);
            this.btnCheck.TabIndex = 10;
            this.btnCheck.Text = "button1";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // lbRet
            // 
            this.lbRet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbRet.FormattingEnabled = true;
            this.lbRet.IntegralHeight = false;
            this.lbRet.ItemHeight = 12;
            this.lbRet.Location = new System.Drawing.Point(10, 510);
            this.lbRet.Name = "lbRet";
            this.lbRet.Size = new System.Drawing.Size(1129, 60);
            this.lbRet.TabIndex = 9;
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.AutoSize = true;
            this.lblUserInfo.Checked = true;
            this.lblUserInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lblUserInfo.Location = new System.Drawing.Point(12, 105);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(78, 16);
            this.lblUserInfo.TabIndex = 1002;
            this.lblUserInfo.Text = "checkBox1";
            this.lblUserInfo.UseVisualStyleBackColor = true;
            this.lblUserInfo.CheckedChanged += new System.EventHandler(this.lblUserInfo_CheckedChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(276, 586);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 14);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 1003;
            this.progressBar1.Visible = false;
            // 
            // lbCount
            // 
            this.lbCount.AutoSize = true;
            this.lbCount.Location = new System.Drawing.Point(397, 588);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(41, 12);
            this.lbCount.TabIndex = 1004;
            this.lbCount.Text = "label1";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(105, 581);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 1005;
            this.btnStop.Text = "button1";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // frmSFMobileCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1148, 612);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lbCount);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblUserInfo);
            this.Controls.Add(this.clbUserInfo);
            this.Controls.Add(this.lbRet);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.gbxRet);
            this.Controls.Add(this.gbxInfo);
            this.Name = "frmSFMobileCheck";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.gbxInfo, 0);
            this.Controls.SetChildIndex(this.gbxRet, 0);
            this.Controls.SetChildIndex(this.btnCheck, 0);
            this.Controls.SetChildIndex(this.lbRet, 0);
            this.Controls.SetChildIndex(this.clbUserInfo, 0);
            this.Controls.SetChildIndex(this.lblUserInfo, 0);
            this.Controls.SetChildIndex(this.progressBar1, 0);
            this.Controls.SetChildIndex(this.lbCount, 0);
            this.Controls.SetChildIndex(this.btnStop, 0);
            this.gbxInfo.ResumeLayout(false);
            this.gbxInfo.PerformLayout();
            this.gbxRet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.retGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.OpenFileDialog dlgOpen;
    private System.Windows.Forms.GroupBox gbxInfo;
    private System.Windows.Forms.DateTimePicker dtpEnd;
    private System.Windows.Forms.Label lblEndTime;
    private System.Windows.Forms.DateTimePicker dtpStart;
    private System.Windows.Forms.Label lblStartTime;
    private System.Windows.Forms.CheckedListBox clbUserInfo;
    private System.Windows.Forms.GroupBox gbxRet;
    private System.Windows.Forms.Button btnCheck;
    private System.Windows.Forms.DataGridView retGrid;
    private System.Windows.Forms.ListBox lbRet;
        private System.Windows.Forms.CheckBox lblUserInfo;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lbCount;
        private System.Windows.Forms.Button btnStop;
    }
}
