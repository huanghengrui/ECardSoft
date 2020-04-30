namespace ECard78
{
  partial class frmAppMain
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAppMain));
      this.ToolBar = new System.Windows.Forms.ToolStrip();
      this.StatusBar = new System.Windows.Forms.StatusStrip();
      this.lblUser = new System.Windows.Forms.ToolStripStatusLabel();
      this.lblAcc = new System.Windows.Forms.ToolStripStatusLabel();
      this.lblTime = new System.Windows.Forms.ToolStripStatusLabel();
      this.MenuBar = new System.Windows.Forms.MenuStrip();
      this.mnuSY = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuSYPower = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuSYDevice = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuSYLine1 = new System.Windows.Forms.ToolStripSeparator();
      this.mnuSYOption = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuSYAuto = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuSYLine2 = new System.Windows.Forms.ToolStripSeparator();
      this.mnuSYPassword = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuSYLine3 = new System.Windows.Forms.ToolStripSeparator();
      this.mnuSYRegister = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuSYLine4 = new System.Windows.Forms.ToolStripSeparator();
      this.mnuSYClose = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuWindow = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuWindowCascade = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuWindowTileHorizontal = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuWindowTileVertical = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuWindowLine1 = new System.Windows.Forms.ToolStripSeparator();
      this.mnuWindowClose = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuWindowCloseAll = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuWindowLine2 = new System.Windows.Forms.ToolStripSeparator();
      this.mnuWindowList = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuHelpTopic = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuHelpLine1 = new System.Windows.Forms.ToolStripSeparator();
      this.mnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
      this.timer = new System.Windows.Forms.Timer(this.components);
      this.StatusBar.SuspendLayout();
      this.MenuBar.SuspendLayout();
      this.SuspendLayout();
      // 
      // ilTreeState
      // 
      this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
      this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
      this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
      this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
      // 
      // ToolBar
      // 
      this.ToolBar.Location = new System.Drawing.Point(0, 24);
      this.ToolBar.Name = "ToolBar";
      this.ToolBar.Size = new System.Drawing.Size(703, 25);
      this.ToolBar.TabIndex = 2;
      this.ToolBar.Text = "ToolBar";
      // 
      // StatusBar
      // 
      this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUser,
            this.lblAcc,
            this.lblTime});
      this.StatusBar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
      this.StatusBar.Location = new System.Drawing.Point(0, 355);
      this.StatusBar.Name = "StatusBar";
      this.StatusBar.Size = new System.Drawing.Size(703, 26);
      this.StatusBar.TabIndex = 3;
      this.StatusBar.Text = "StatusBar";
      // 
      // lblUser
      // 
      this.lblUser.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
      this.lblUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.lblUser.Margin = new System.Windows.Forms.Padding(5);
      this.lblUser.Name = "lblUser";
      this.lblUser.Size = new System.Drawing.Size(135, 16);
      this.lblUser.Text = "toolStripStatusLabel1";
      // 
      // lblAcc
      // 
      this.lblAcc.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
      this.lblAcc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.lblAcc.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
      this.lblAcc.Name = "lblAcc";
      this.lblAcc.Size = new System.Drawing.Size(135, 16);
      this.lblAcc.Text = "toolStripStatusLabel1";
      // 
      // lblTime
      // 
      this.lblTime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
      this.lblTime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.lblTime.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
      this.lblTime.Name = "lblTime";
      this.lblTime.Size = new System.Drawing.Size(135, 16);
      this.lblTime.Text = "toolStripStatusLabel1";
      // 
      // MenuBar
      // 
      this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSY,
            this.mnuWindow,
            this.mnuHelp});
      this.MenuBar.Location = new System.Drawing.Point(0, 0);
      this.MenuBar.Name = "MenuBar";
      this.MenuBar.Size = new System.Drawing.Size(703, 24);
      this.MenuBar.TabIndex = 5;
      this.MenuBar.Text = "menuStrip1";
      // 
      // mnuSY
      // 
      this.mnuSY.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSYPower,
            this.mnuSYDevice,
            this.mnuSYLine1,
            this.mnuSYOption,
            this.mnuSYAuto,
            this.mnuSYLine2,
            this.mnuSYPassword,
            this.mnuSYLine3,
            this.mnuSYRegister,
            this.mnuSYLine4,
            this.mnuSYClose});
      this.mnuSY.Name = "mnuSY";
      this.mnuSY.Size = new System.Drawing.Size(47, 20);
      this.mnuSY.Text = "mnuSY";
      // 
      // mnuSYPower
      // 
      this.mnuSYPower.Name = "mnuSYPower";
      this.mnuSYPower.Size = new System.Drawing.Size(171, 22);
      this.mnuSYPower.Text = "mnuSYPower";
      this.mnuSYPower.Click += new System.EventHandler(this.mnuSYPower_Click);
      // 
      // mnuSYDevice
      // 
      this.mnuSYDevice.Name = "mnuSYDevice";
      this.mnuSYDevice.Size = new System.Drawing.Size(171, 22);
      this.mnuSYDevice.Text = "mnuSYDevice";
      this.mnuSYDevice.Click += new System.EventHandler(this.mnuSYDevice_Click);
      // 
      // mnuSYLine1
      // 
      this.mnuSYLine1.Name = "mnuSYLine1";
      this.mnuSYLine1.Size = new System.Drawing.Size(168, 6);
      // 
      // mnuSYOption
      // 
      this.mnuSYOption.Name = "mnuSYOption";
      this.mnuSYOption.Size = new System.Drawing.Size(171, 22);
      this.mnuSYOption.Text = "mnuSYOption";
      this.mnuSYOption.Click += new System.EventHandler(this.mnuSYOption_Click);
      // 
      // mnuSYAuto
      // 
      this.mnuSYAuto.Name = "mnuSYAuto";
      this.mnuSYAuto.Size = new System.Drawing.Size(171, 22);
      this.mnuSYAuto.Text = "mnuSYAuto";
      this.mnuSYAuto.Click += new System.EventHandler(this.mnuSYAuto_Click);
      // 
      // mnuSYLine2
      // 
      this.mnuSYLine2.Name = "mnuSYLine2";
      this.mnuSYLine2.Size = new System.Drawing.Size(168, 6);
      // 
      // mnuSYPassword
      // 
      this.mnuSYPassword.Name = "mnuSYPassword";
      this.mnuSYPassword.Size = new System.Drawing.Size(171, 22);
      this.mnuSYPassword.Text = "mnuSYPassword";
      this.mnuSYPassword.Click += new System.EventHandler(this.mnuSYPassword_Click);
      // 
      // mnuSYLine3
      // 
      this.mnuSYLine3.Name = "mnuSYLine3";
      this.mnuSYLine3.Size = new System.Drawing.Size(168, 6);
      // 
      // mnuSYRegister
      // 
      this.mnuSYRegister.Name = "mnuSYRegister";
      this.mnuSYRegister.Size = new System.Drawing.Size(171, 22);
      this.mnuSYRegister.Text = "mnuSYRegister";
      this.mnuSYRegister.Click += new System.EventHandler(this.mnuSYRegister_Click);
      // 
      // mnuSYLine4
      // 
      this.mnuSYLine4.Name = "mnuSYLine4";
      this.mnuSYLine4.Size = new System.Drawing.Size(168, 6);
      // 
      // mnuSYClose
      // 
      this.mnuSYClose.Image = global::ECard78.Properties.Resources.ExitSystem;
      this.mnuSYClose.ImageTransparentColor = System.Drawing.Color.Transparent;
      this.mnuSYClose.Name = "mnuSYClose";
      this.mnuSYClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
      this.mnuSYClose.Size = new System.Drawing.Size(171, 22);
      this.mnuSYClose.Text = "mnuSYClose";
      this.mnuSYClose.Click += new System.EventHandler(this.mnuSYClose_Click);
      // 
      // mnuWindow
      // 
      this.mnuWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuWindowCascade,
            this.mnuWindowTileHorizontal,
            this.mnuWindowTileVertical,
            this.mnuWindowLine1,
            this.mnuWindowClose,
            this.mnuWindowCloseAll,
            this.mnuWindowLine2,
            this.mnuWindowList});
      this.mnuWindow.Name = "mnuWindow";
      this.mnuWindow.Size = new System.Drawing.Size(71, 20);
      this.mnuWindow.Text = "mnuWindow";
      // 
      // mnuWindowCascade
      // 
      this.mnuWindowCascade.Name = "mnuWindowCascade";
      this.mnuWindowCascade.Size = new System.Drawing.Size(208, 22);
      this.mnuWindowCascade.Text = "mnuWindowCascade";
      this.mnuWindowCascade.Click += new System.EventHandler(this.mnuWindowCascade_Click);
      // 
      // mnuWindowTileHorizontal
      // 
      this.mnuWindowTileHorizontal.Name = "mnuWindowTileHorizontal";
      this.mnuWindowTileHorizontal.Size = new System.Drawing.Size(208, 22);
      this.mnuWindowTileHorizontal.Text = "mnuWindowTileHorizontal";
      this.mnuWindowTileHorizontal.Click += new System.EventHandler(this.mnuWindowTileHorizontal_Click);
      // 
      // mnuWindowTileVertical
      // 
      this.mnuWindowTileVertical.Name = "mnuWindowTileVertical";
      this.mnuWindowTileVertical.Size = new System.Drawing.Size(208, 22);
      this.mnuWindowTileVertical.Text = "mnuWindowTileVertical";
      this.mnuWindowTileVertical.Click += new System.EventHandler(this.mnuWindowTileVertical_Click);
      // 
      // mnuWindowLine1
      // 
      this.mnuWindowLine1.Name = "mnuWindowLine1";
      this.mnuWindowLine1.Size = new System.Drawing.Size(205, 6);
      // 
      // mnuWindowClose
      // 
      this.mnuWindowClose.Image = global::ECard78.Properties.Resources.Exit;
      this.mnuWindowClose.ImageTransparentColor = System.Drawing.Color.Transparent;
      this.mnuWindowClose.Name = "mnuWindowClose";
      this.mnuWindowClose.Size = new System.Drawing.Size(208, 22);
      this.mnuWindowClose.Text = "mnuWindowClose";
      this.mnuWindowClose.Click += new System.EventHandler(this.mnuWindowClose_Click);
      // 
      // mnuWindowCloseAll
      // 
      this.mnuWindowCloseAll.Name = "mnuWindowCloseAll";
      this.mnuWindowCloseAll.Size = new System.Drawing.Size(208, 22);
      this.mnuWindowCloseAll.Text = "mnuWindowCloseAll";
      this.mnuWindowCloseAll.Click += new System.EventHandler(this.mnuWindowCloseAll_Click);
      // 
      // mnuWindowLine2
      // 
      this.mnuWindowLine2.Name = "mnuWindowLine2";
      this.mnuWindowLine2.Size = new System.Drawing.Size(205, 6);
      // 
      // mnuWindowList
      // 
      this.mnuWindowList.Name = "mnuWindowList";
      this.mnuWindowList.Size = new System.Drawing.Size(208, 22);
      this.mnuWindowList.Text = "mnuWindowList";
      // 
      // mnuHelp
      // 
      this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelpTopic,
            this.mnuHelpLine1,
            this.mnuHelpAbout});
      this.mnuHelp.Name = "mnuHelp";
      this.mnuHelp.Size = new System.Drawing.Size(59, 20);
      this.mnuHelp.Text = "mnuHelp";
      // 
      // mnuHelpTopic
      // 
      this.mnuHelpTopic.Name = "mnuHelpTopic";
      this.mnuHelpTopic.Size = new System.Drawing.Size(142, 22);
      this.mnuHelpTopic.Text = "mnuHelpTopic";
      this.mnuHelpTopic.Click += new System.EventHandler(this.mnuHelpTopic_Click);
      // 
      // mnuHelpLine1
      // 
      this.mnuHelpLine1.Name = "mnuHelpLine1";
      this.mnuHelpLine1.Size = new System.Drawing.Size(139, 6);
      // 
      // mnuHelpAbout
      // 
      this.mnuHelpAbout.Name = "mnuHelpAbout";
      this.mnuHelpAbout.Size = new System.Drawing.Size(142, 22);
      this.mnuHelpAbout.Text = "mnuHelpAbout";
      this.mnuHelpAbout.Click += new System.EventHandler(this.mnuHelpAbout_Click);
      // 
      // timer
      // 
      this.timer.Enabled = true;
      this.timer.Interval = 500;
      this.timer.Tick += new System.EventHandler(this.timer_Tick);
      // 
      // frmAppMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(703, 381);
      this.Controls.Add(this.StatusBar);
      this.Controls.Add(this.ToolBar);
      this.Controls.Add(this.MenuBar);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.IsMdiContainer = true;
      this.MainMenuStrip = this.MenuBar;
      this.MaximizeBox = true;
      this.MinimizeBox = true;
      this.Name = "frmAppMain";
      this.ShowInTaskbar = true;
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "Main";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
      this.Shown += new System.EventHandler(this.frmMain_Shown);
      this.Resize += new System.EventHandler(this.frmMain_Resize);
      this.StatusBar.ResumeLayout(false);
      this.StatusBar.PerformLayout();
      this.MenuBar.ResumeLayout(false);
      this.MenuBar.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStripStatusLabel lblUser;
    private System.Windows.Forms.ToolStripStatusLabel lblAcc;
    private System.Windows.Forms.MenuStrip MenuBar;
    private System.Windows.Forms.ToolStripMenuItem mnuSY;
    private System.Windows.Forms.ToolStripMenuItem mnuSYPower;
    private System.Windows.Forms.ToolStripMenuItem mnuSYDevice;
    private System.Windows.Forms.ToolStripSeparator mnuSYLine1;
    private System.Windows.Forms.ToolStripMenuItem mnuSYOption;
    private System.Windows.Forms.ToolStripMenuItem mnuSYAuto;
    private System.Windows.Forms.ToolStripMenuItem mnuSYPassword;
    private System.Windows.Forms.ToolStripSeparator mnuSYLine4;
    private System.Windows.Forms.ToolStripMenuItem mnuSYRegister;
    private System.Windows.Forms.ToolStripMenuItem mnuSYClose;
    private System.Windows.Forms.ToolStripMenuItem mnuWindow;
    private System.Windows.Forms.ToolStripMenuItem mnuWindowCascade;
    private System.Windows.Forms.ToolStripMenuItem mnuWindowTileHorizontal;
    private System.Windows.Forms.ToolStripMenuItem mnuWindowTileVertical;
    private System.Windows.Forms.ToolStripSeparator mnuWindowLine1;
    private System.Windows.Forms.ToolStripMenuItem mnuWindowClose;
    private System.Windows.Forms.ToolStripSeparator mnuWindowLine2;
    private System.Windows.Forms.ToolStripMenuItem mnuHelp;
    private System.Windows.Forms.ToolStripMenuItem mnuHelpTopic;
    private System.Windows.Forms.ToolStripSeparator mnuHelpLine1;
    private System.Windows.Forms.ToolStripMenuItem mnuHelpAbout;
    private System.Windows.Forms.ToolStripMenuItem mnuWindowList;
    private System.Windows.Forms.ToolStripMenuItem mnuWindowCloseAll;
    private System.Windows.Forms.ToolStripStatusLabel lblTime;
    private System.Windows.Forms.Timer timer;
    private System.Windows.Forms.ToolStripSeparator mnuSYLine2;
    private System.Windows.Forms.ToolStripSeparator mnuSYLine3;
    private System.Windows.Forms.ToolStrip ToolBar;
    private System.Windows.Forms.StatusStrip StatusBar;
  }
}
