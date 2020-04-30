namespace ECard78
{
  partial class frmDBMain
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
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDBMain));
      this.MenuBar = new System.Windows.Forms.MenuStrip();
      this.mnuSystem = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuPassword = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuLine1 = new System.Windows.Forms.ToolStripSeparator();
      this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuAccount = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuNewAccount = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuDelAccount = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuData = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuBack = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuRest = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuUpdate = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuLine2 = new System.Windows.Forms.ToolStripSeparator();
      this.mnuAuto = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuCompact = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolBar = new System.Windows.Forms.ToolStrip();
      this.StatusBar = new System.Windows.Forms.StatusStrip();
      this.lblMsg = new System.Windows.Forms.ToolStripStatusLabel();
      this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ImageList = new System.Windows.Forms.ImageList(this.components);
      this.dataGrid = new System.Windows.Forms.DataGridView();
      this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.MenuBar.SuspendLayout();
      this.StatusBar.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
      this.SuspendLayout();
      // 
      // MenuBar
      // 
      this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSystem,
            this.mnuAccount,
            this.mnuData});
      this.MenuBar.Location = new System.Drawing.Point(0, 0);
      this.MenuBar.Name = "MenuBar";
      this.MenuBar.Size = new System.Drawing.Size(554, 24);
      this.MenuBar.TabIndex = 0;
      this.MenuBar.Text = "menuStrip1";
      // 
      // mnuSystem
      // 
      this.mnuSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPassword,
            this.mnuLine1,
            this.mnuExit});
      this.mnuSystem.Name = "mnuSystem";
      this.mnuSystem.Size = new System.Drawing.Size(41, 20);
      this.mnuSystem.Text = "系统";
      // 
      // mnuPassword
      // 
      this.mnuPassword.Image = global::ECard78.Properties.Resources.Password;
      this.mnuPassword.ImageTransparentColor = System.Drawing.Color.White;
      this.mnuPassword.Name = "mnuPassword";
      this.mnuPassword.Size = new System.Drawing.Size(159, 22);
      this.mnuPassword.Text = "修改密码";
      this.mnuPassword.Click += new System.EventHandler(this.mnuPassword_Click);
      // 
      // mnuLine1
      // 
      this.mnuLine1.Name = "mnuLine1";
      this.mnuLine1.Size = new System.Drawing.Size(156, 6);
      // 
      // mnuExit
      // 
      this.mnuExit.Image = global::ECard78.Properties.Resources.ExitSystem;
      this.mnuExit.Name = "mnuExit";
      this.mnuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
      this.mnuExit.Size = new System.Drawing.Size(159, 22);
      this.mnuExit.Text = "退出系统";
      this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
      // 
      // mnuAccount
      // 
      this.mnuAccount.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewAccount,
            this.mnuDelAccount});
      this.mnuAccount.Name = "mnuAccount";
      this.mnuAccount.Size = new System.Drawing.Size(65, 20);
      this.mnuAccount.Text = "帐套管理";
      // 
      // mnuNewAccount
      // 
      this.mnuNewAccount.Image = global::ECard78.Properties.Resources.New;
      this.mnuNewAccount.ImageTransparentColor = System.Drawing.Color.White;
      this.mnuNewAccount.Name = "mnuNewAccount";
      this.mnuNewAccount.Size = new System.Drawing.Size(118, 22);
      this.mnuNewAccount.Text = "新建帐套";
      this.mnuNewAccount.Click += new System.EventHandler(this.mnuNewAccount_Click);
      // 
      // mnuDelAccount
      // 
      this.mnuDelAccount.Image = global::ECard78.Properties.Resources.Delete;
      this.mnuDelAccount.ImageTransparentColor = System.Drawing.Color.White;
      this.mnuDelAccount.Name = "mnuDelAccount";
      this.mnuDelAccount.Size = new System.Drawing.Size(118, 22);
      this.mnuDelAccount.Text = "删除帐套";
      this.mnuDelAccount.Click += new System.EventHandler(this.mnuDelAccount_Click);
      // 
      // mnuData
      // 
      this.mnuData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBack,
            this.mnuRest,
            this.mnuUpdate,
            this.mnuLine2,
            this.mnuAuto,
            this.mnuCompact});
      this.mnuData.Name = "mnuData";
      this.mnuData.Size = new System.Drawing.Size(65, 20);
      this.mnuData.Text = "数据管理";
      // 
      // mnuBack
      // 
      this.mnuBack.Image = global::ECard78.Properties.Resources.Export;
      this.mnuBack.ImageTransparentColor = System.Drawing.Color.White;
      this.mnuBack.Name = "mnuBack";
      this.mnuBack.Size = new System.Drawing.Size(118, 22);
      this.mnuBack.Text = "备份数据";
      this.mnuBack.Click += new System.EventHandler(this.mnuBack_Click);
      // 
      // mnuRest
      // 
      this.mnuRest.Image = global::ECard78.Properties.Resources.Import;
      this.mnuRest.ImageTransparentColor = System.Drawing.Color.White;
      this.mnuRest.Name = "mnuRest";
      this.mnuRest.Size = new System.Drawing.Size(118, 22);
      this.mnuRest.Text = "恢复数据";
      this.mnuRest.Click += new System.EventHandler(this.mnuRest_Click);
      // 
      // mnuUpdate
      // 
      this.mnuUpdate.Image = global::ECard78.Properties.Resources.Note;
      this.mnuUpdate.ImageTransparentColor = System.Drawing.Color.White;
      this.mnuUpdate.Name = "mnuUpdate";
      this.mnuUpdate.Size = new System.Drawing.Size(118, 22);
      this.mnuUpdate.Text = "升级数据";
      this.mnuUpdate.Click += new System.EventHandler(this.mnuUpdate_Click);
      // 
      // mnuLine2
      // 
      this.mnuLine2.Name = "mnuLine2";
      this.mnuLine2.Size = new System.Drawing.Size(115, 6);
      // 
      // mnuAuto
      // 
      this.mnuAuto.Image = global::ECard78.Properties.Resources.CalendarDate;
      this.mnuAuto.ImageTransparentColor = System.Drawing.Color.White;
      this.mnuAuto.Name = "mnuAuto";
      this.mnuAuto.Size = new System.Drawing.Size(118, 22);
      this.mnuAuto.Text = "自动备份";
      this.mnuAuto.Click += new System.EventHandler(this.mnuAuto_Click);
      // 
      // mnuCompact
      // 
      this.mnuCompact.Image = global::ECard78.Properties.Resources.Execute;
      this.mnuCompact.ImageTransparentColor = System.Drawing.Color.White;
      this.mnuCompact.Name = "mnuCompact";
      this.mnuCompact.Size = new System.Drawing.Size(118, 22);
      this.mnuCompact.Text = "压缩帐套";
      this.mnuCompact.Click += new System.EventHandler(this.mnuCompact_Click);
      // 
      // ToolBar
      // 
      this.ToolBar.Location = new System.Drawing.Point(0, 24);
      this.ToolBar.Name = "ToolBar";
      this.ToolBar.Size = new System.Drawing.Size(554, 25);
      this.ToolBar.TabIndex = 1;
      this.ToolBar.Text = "toolStrip1";
      // 
      // StatusBar
      // 
      this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMsg});
      this.StatusBar.Location = new System.Drawing.Point(0, 306);
      this.StatusBar.Name = "StatusBar";
      this.StatusBar.Size = new System.Drawing.Size(554, 22);
      this.StatusBar.TabIndex = 2;
      this.StatusBar.Text = "statusStrip1";
      // 
      // lblMsg
      // 
      this.lblMsg.Margin = new System.Windows.Forms.Padding(5, 5, 0, 5);
      this.lblMsg.Name = "lblMsg";
      this.lblMsg.Size = new System.Drawing.Size(534, 12);
      this.lblMsg.Spring = true;
      this.lblMsg.Text = "toolStripStatusLabel1";
      this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // contextMenu
      // 
      this.contextMenu.Name = "ContextMenu";
      this.contextMenu.Size = new System.Drawing.Size(153, 26);
      // 
      // ImageList
      // 
      this.ImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
      this.ImageList.ImageSize = new System.Drawing.Size(1, 25);
      this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
      // 
      // dataGrid
      // 
      this.dataGrid.AllowUserToAddRows = false;
      this.dataGrid.AllowUserToDeleteRows = false;
      this.dataGrid.AllowUserToResizeRows = false;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.dataGrid.ColumnHeadersHeight = 25;
      this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
      this.dataGrid.ContextMenuStrip = this.contextMenu;
      dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dataGrid.DefaultCellStyle = dataGridViewCellStyle5;
      this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGrid.Location = new System.Drawing.Point(0, 49);
      this.dataGrid.MultiSelect = false;
      this.dataGrid.Name = "dataGrid";
      this.dataGrid.ReadOnly = true;
      this.dataGrid.RowHeadersVisible = false;
      this.dataGrid.RowTemplate.Height = 23;
      this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dataGrid.Size = new System.Drawing.Size(554, 257);
      this.dataGrid.TabIndex = 4;
      this.dataGrid.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGrid_ColumnWidthChanged);
      // 
      // Column1
      // 
      this.Column1.DataPropertyName = "AccName";
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
      this.Column1.HeaderText = "Column1";
      this.Column1.Name = "Column1";
      this.Column1.ReadOnly = true;
      this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Column1.Width = 120;
      // 
      // Column2
      // 
      this.Column2.DataPropertyName = "DBName";
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
      this.Column2.HeaderText = "Column2";
      this.Column2.Name = "Column2";
      this.Column2.ReadOnly = true;
      this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Column2.Width = 120;
      // 
      // Column3
      // 
      this.Column3.DataPropertyName = "CrtdDay";
      this.Column3.HeaderText = "Column3";
      this.Column3.Name = "Column3";
      this.Column3.ReadOnly = true;
      this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Column3.Width = 125;
      // 
      // Column4
      // 
      this.Column4.DataPropertyName = "IsForward";
      this.Column4.HeaderText = "Column4";
      this.Column4.Name = "Column4";
      this.Column4.ReadOnly = true;
      this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.Column4.Width = 70;
      // 
      // Column5
      // 
      this.Column5.DataPropertyName = "BackupDay";
      this.Column5.HeaderText = "Column5";
      this.Column5.Name = "Column5";
      this.Column5.ReadOnly = true;
      this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Column5.Width = 125;
      // 
      // Column6
      // 
      this.Column6.DataPropertyName = "RestoreDay";
      this.Column6.HeaderText = "Column6";
      this.Column6.Name = "Column6";
      this.Column6.ReadOnly = true;
      this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Column6.Width = 125;
      // 
      // Column7
      // 
      this.Column7.DataPropertyName = "ForwardNote";
      dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      this.Column7.DefaultCellStyle = dataGridViewCellStyle4;
      this.Column7.HeaderText = "Column7";
      this.Column7.Name = "Column7";
      this.Column7.ReadOnly = true;
      this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // frmDBMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(554, 328);
      this.Controls.Add(this.dataGrid);
      this.Controls.Add(this.StatusBar);
      this.Controls.Add(this.ToolBar);
      this.Controls.Add(this.MenuBar);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.MenuBar;
      this.MaximizeBox = true;
      this.MinimizeBox = true;
      this.Name = "frmDBMain";
      this.ShowInTaskbar = true;
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDBMain_FormClosing);
      this.Resize += new System.EventHandler(this.frmDBMain_Resize);
      this.MenuBar.ResumeLayout(false);
      this.MenuBar.PerformLayout();
      this.StatusBar.ResumeLayout(false);
      this.StatusBar.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip MenuBar;
    private System.Windows.Forms.ToolStripMenuItem mnuSystem;
    private System.Windows.Forms.ToolStripMenuItem mnuPassword;
    private System.Windows.Forms.ToolStripSeparator mnuLine1;
    private System.Windows.Forms.ToolStripMenuItem mnuExit;
    private System.Windows.Forms.ToolStripMenuItem mnuAccount;
    private System.Windows.Forms.ToolStripMenuItem mnuNewAccount;
    private System.Windows.Forms.ToolStripMenuItem mnuDelAccount;
    private System.Windows.Forms.ToolStripMenuItem mnuData;
    private System.Windows.Forms.ToolStripMenuItem mnuBack;
    private System.Windows.Forms.ToolStripMenuItem mnuRest;
    private System.Windows.Forms.ToolStripMenuItem mnuUpdate;
    private System.Windows.Forms.ToolStripSeparator mnuLine2;
    private System.Windows.Forms.ToolStripMenuItem mnuAuto;
    private System.Windows.Forms.ToolStripMenuItem mnuCompact;
    private System.Windows.Forms.ToolStrip ToolBar;
    private System.Windows.Forms.StatusStrip StatusBar;
    private System.Windows.Forms.ToolStripStatusLabel lblMsg;
    private System.Windows.Forms.ContextMenuStrip contextMenu;
    private System.Windows.Forms.ImageList ImageList;
    private System.Windows.Forms.DataGridView dataGrid;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    private System.Windows.Forms.DataGridViewCheckBoxColumn Column4;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
  }
}
