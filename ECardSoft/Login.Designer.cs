namespace ECard78
{
  partial class frmLogin
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
      this.lblTitle = new System.Windows.Forms.Label();
      this.Label1 = new System.Windows.Forms.Label();
      this.cbbAccount = new System.Windows.Forms.ComboBox();
      this.cbbOpter = new System.Windows.Forms.ComboBox();
      this.Label2 = new System.Windows.Forms.Label();
      this.Label3 = new System.Windows.Forms.Label();
      this.chkPass = new System.Windows.Forms.CheckBox();
      this.btnConnect = new System.Windows.Forms.Button();
      this.txtPass = new System.Windows.Forms.TextBox();
      this.lblVersion = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(410, 230);
      this.btnCancel.TabIndex = 11;
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Enabled = false;
      this.btnOk.Location = new System.Drawing.Point(330, 230);
      this.btnOk.TabIndex = 10;
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
      // lblTitle
      // 
      this.lblTitle.BackColor = System.Drawing.Color.Transparent;
      this.lblTitle.ForeColor = System.Drawing.Color.Red;
      this.lblTitle.Location = new System.Drawing.Point(210, 15);
      this.lblTitle.Name = "lblTitle";
      this.lblTitle.Size = new System.Drawing.Size(270, 29);
      this.lblTitle.TabIndex = 1;
      this.lblTitle.Text = "label1";
      this.lblTitle.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // Label1
      // 
      this.Label1.AutoSize = true;
      this.Label1.BackColor = System.Drawing.Color.Transparent;
      this.Label1.Location = new System.Drawing.Point(160, 89);
      this.Label1.Name = "Label1";
      this.Label1.Size = new System.Drawing.Size(41, 12);
      this.Label1.TabIndex = 2;
      this.Label1.Tag = "AccName";
      this.Label1.Text = "label1";
      // 
      // cbbAccount
      // 
      this.cbbAccount.DisplayMember = "Text";
      this.cbbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbAccount.FormattingEnabled = true;
      this.cbbAccount.Location = new System.Drawing.Point(250, 85);
      this.cbbAccount.Name = "cbbAccount";
      this.cbbAccount.Size = new System.Drawing.Size(230, 20);
      this.cbbAccount.TabIndex = 3;
      this.cbbAccount.ValueMember = "Value";
      this.cbbAccount.SelectedIndexChanged += new System.EventHandler(this.cbbAccount_SelectedIndexChanged);
      // 
      // cbbOpter
      // 
      this.cbbOpter.DisplayMember = "Text";
      this.cbbOpter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbOpter.FormattingEnabled = true;
      this.cbbOpter.Location = new System.Drawing.Point(250, 120);
      this.cbbOpter.Name = "cbbOpter";
      this.cbbOpter.Size = new System.Drawing.Size(230, 20);
      this.cbbOpter.TabIndex = 5;
      this.cbbOpter.ValueMember = "Value";
      // 
      // Label2
      // 
      this.Label2.AutoSize = true;
      this.Label2.BackColor = System.Drawing.Color.Transparent;
      this.Label2.Location = new System.Drawing.Point(160, 124);
      this.Label2.Name = "Label2";
      this.Label2.Size = new System.Drawing.Size(41, 12);
      this.Label2.TabIndex = 4;
      this.Label2.Text = "label1";
      // 
      // Label3
      // 
      this.Label3.AutoSize = true;
      this.Label3.BackColor = System.Drawing.Color.Transparent;
      this.Label3.Location = new System.Drawing.Point(160, 159);
      this.Label3.Name = "Label3";
      this.Label3.Size = new System.Drawing.Size(41, 12);
      this.Label3.TabIndex = 6;
      this.Label3.Text = "label1";
      // 
      // chkPass
      // 
      this.chkPass.AutoSize = true;
      this.chkPass.BackColor = System.Drawing.Color.Transparent;
      this.chkPass.Location = new System.Drawing.Point(250, 190);
      this.chkPass.Name = "chkPass";
      this.chkPass.Size = new System.Drawing.Size(78, 16);
      this.chkPass.TabIndex = 8;
      this.chkPass.Text = "checkBox1";
      this.chkPass.UseVisualStyleBackColor = false;
      // 
      // btnConnect
      // 
      this.btnConnect.Location = new System.Drawing.Point(160, 230);
      this.btnConnect.Name = "btnConnect";
      this.btnConnect.Size = new System.Drawing.Size(75, 25);
      this.btnConnect.TabIndex = 9;
      this.btnConnect.Text = "button1";
      this.btnConnect.UseVisualStyleBackColor = true;
      this.btnConnect.Click += new System.EventHandler(this.btnMoreTool_Click);
      // 
      // txtPass
      // 
      this.txtPass.Location = new System.Drawing.Point(250, 155);
      this.txtPass.Name = "txtPass";
      this.txtPass.PasswordChar = '*';
      this.txtPass.Size = new System.Drawing.Size(230, 21);
      this.txtPass.TabIndex = 7;
      this.txtPass.TextChanged += new System.EventHandler(this.txtPass_TextChanged);
      // 
      // lblVersion
      // 
      this.lblVersion.BackColor = System.Drawing.Color.Transparent;
      this.lblVersion.ForeColor = System.Drawing.Color.Blue;
      this.lblVersion.Location = new System.Drawing.Point(250, 45);
      this.lblVersion.Name = "lblVersion";
      this.lblVersion.Size = new System.Drawing.Size(230, 15);
      this.lblVersion.TabIndex = 20;
      this.lblVersion.Text = "label1";
      this.lblVersion.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.BackColor = System.Drawing.Color.Transparent;
      this.label4.Enabled = false;
      this.label4.ForeColor = System.Drawing.Color.Red;
      this.label4.Location = new System.Drawing.Point(210, 16);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(41, 12);
      this.label4.TabIndex = 21;
      this.label4.Text = "label1";
      this.label4.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      this.label4.Visible = false;
      // 
      // frmLogin
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.BackgroundImage = global::ECard78.Properties.Resources.login;
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.ClientSize = new System.Drawing.Size(494, 268);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.lblVersion);
      this.Controls.Add(this.txtPass);
      this.Controls.Add(this.btnConnect);
      this.Controls.Add(this.chkPass);
      this.Controls.Add(this.Label3);
      this.Controls.Add(this.cbbOpter);
      this.Controls.Add(this.Label2);
      this.Controls.Add(this.cbbAccount);
      this.Controls.Add(this.Label1);
      this.Controls.Add(this.lblTitle);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "frmLogin";
      this.ShowInTaskbar = true;
      this.Controls.SetChildIndex(this.lblTitle, 0);
      this.Controls.SetChildIndex(this.Label1, 0);
      this.Controls.SetChildIndex(this.cbbAccount, 0);
      this.Controls.SetChildIndex(this.Label2, 0);
      this.Controls.SetChildIndex(this.cbbOpter, 0);
      this.Controls.SetChildIndex(this.Label3, 0);
      this.Controls.SetChildIndex(this.chkPass, 0);
      this.Controls.SetChildIndex(this.btnConnect, 0);
      this.Controls.SetChildIndex(this.txtPass, 0);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.Controls.SetChildIndex(this.lblVersion, 0);
      this.Controls.SetChildIndex(this.label4, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Label Label1;
    private System.Windows.Forms.ComboBox cbbAccount;
    private System.Windows.Forms.ComboBox cbbOpter;
    private System.Windows.Forms.Label Label2;
    private System.Windows.Forms.Label Label3;
    private System.Windows.Forms.CheckBox chkPass;
    private System.Windows.Forms.Button btnConnect;
    private System.Windows.Forms.TextBox txtPass;
    private System.Windows.Forms.Label lblVersion;
    private System.Windows.Forms.Label label4;
  }
}
