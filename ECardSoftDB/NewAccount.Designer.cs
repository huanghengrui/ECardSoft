namespace ECard78
{
  partial class frmNewAccount
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewAccount));
      this.Label1 = new System.Windows.Forms.Label();
      this.txtAccName = new System.Windows.Forms.TextBox();
      this.txtDBName = new System.Windows.Forms.TextBox();
      this.Label2 = new System.Windows.Forms.Label();
      this.cbbDBName = new System.Windows.Forms.ComboBox();
      this.rbNew = new System.Windows.Forms.RadioButton();
      this.rbOld = new System.Windows.Forms.RadioButton();
      this.Label3 = new System.Windows.Forms.Label();
      this.txtBak = new System.Windows.Forms.TextBox();
      this.btnDBName = new System.Windows.Forms.Button();
      this.btnDBPath = new System.Windows.Forms.Button();
      this.txtPath = new System.Windows.Forms.TextBox();
      this.Label4 = new System.Windows.Forms.Label();
      this.rbMDF = new System.Windows.Forms.RadioButton();
      this.lblMDF = new System.Windows.Forms.Label();
      this.txtMDF = new System.Windows.Forms.TextBox();
      this.btnMDF = new System.Windows.Forms.Button();
      this.rbBak = new System.Windows.Forms.RadioButton();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(380, 230);
      this.btnCancel.TabIndex = 14;
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(300, 230);
      this.btnOk.TabIndex = 13;
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
      // Label1
      // 
      this.Label1.AutoSize = true;
      this.Label1.Location = new System.Drawing.Point(20, 24);
      this.Label1.Name = "Label1";
      this.Label1.Size = new System.Drawing.Size(41, 12);
      this.Label1.TabIndex = 0;
      this.Label1.Tag = "AccName";
      this.Label1.Text = "label1";
      // 
      // txtAccName
      // 
      this.txtAccName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.txtAccName.Location = new System.Drawing.Point(120, 20);
      this.txtAccName.MaxLength = 25;
      this.txtAccName.Name = "txtAccName";
      this.txtAccName.Size = new System.Drawing.Size(335, 21);
      this.txtAccName.TabIndex = 1;
      // 
      // txtDBName
      // 
      this.txtDBName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.txtDBName.Location = new System.Drawing.Point(120, 50);
      this.txtDBName.MaxLength = 25;
      this.txtDBName.Name = "txtDBName";
      this.txtDBName.Size = new System.Drawing.Size(335, 21);
      this.txtDBName.TabIndex = 3;
      // 
      // Label2
      // 
      this.Label2.AutoSize = true;
      this.Label2.Location = new System.Drawing.Point(20, 54);
      this.Label2.Name = "Label2";
      this.Label2.Size = new System.Drawing.Size(41, 12);
      this.Label2.TabIndex = 2;
      this.Label2.Tag = "DBName";
      this.Label2.Text = "label2";
      // 
      // cbbDBName
      // 
      this.cbbDBName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.cbbDBName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbDBName.FormattingEnabled = true;
      this.cbbDBName.Location = new System.Drawing.Point(120, 50);
      this.cbbDBName.Name = "cbbDBName";
      this.cbbDBName.Size = new System.Drawing.Size(335, 20);
      this.cbbDBName.TabIndex = 4;
      // 
      // rbNew
      // 
      this.rbNew.AutoSize = true;
      this.rbNew.Checked = true;
      this.rbNew.Location = new System.Drawing.Point(120, 80);
      this.rbNew.Name = "rbNew";
      this.rbNew.Size = new System.Drawing.Size(95, 16);
      this.rbNew.TabIndex = 5;
      this.rbNew.TabStop = true;
      this.rbNew.Text = "radioButton1";
      this.rbNew.UseVisualStyleBackColor = true;
      this.rbNew.Click += new System.EventHandler(this.RadioButton_Click);
      // 
      // rbOld
      // 
      this.rbOld.AutoSize = true;
      this.rbOld.Location = new System.Drawing.Point(280, 80);
      this.rbOld.Name = "rbOld";
      this.rbOld.Size = new System.Drawing.Size(95, 16);
      this.rbOld.TabIndex = 7;
      this.rbOld.TabStop = true;
      this.rbOld.Text = "radioButton2";
      this.rbOld.UseVisualStyleBackColor = true;
      this.rbOld.Click += new System.EventHandler(this.RadioButton_Click);
      // 
      // Label3
      // 
      this.Label3.AutoSize = true;
      this.Label3.Location = new System.Drawing.Point(20, 115);
      this.Label3.Name = "Label3";
      this.Label3.Size = new System.Drawing.Size(41, 12);
      this.Label3.TabIndex = 7;
      this.Label3.Text = "label1";
      // 
      // txtBak
      // 
      this.txtBak.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.txtBak.Location = new System.Drawing.Point(20, 135);
      this.txtBak.Name = "txtBak";
      this.txtBak.ReadOnly = true;
      this.txtBak.Size = new System.Drawing.Size(410, 21);
      this.txtBak.TabIndex = 11;
      // 
      // btnDBName
      // 
      this.btnDBName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnDBName.Location = new System.Drawing.Point(435, 135);
      this.btnDBName.Name = "btnDBName";
      this.btnDBName.Size = new System.Drawing.Size(20, 20);
      this.btnDBName.TabIndex = 12;
      this.btnDBName.Text = ">";
      this.btnDBName.UseVisualStyleBackColor = true;
      this.btnDBName.Click += new System.EventHandler(this.btnDBName_Click);
      // 
      // btnDBPath
      // 
      this.btnDBPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnDBPath.Location = new System.Drawing.Point(435, 190);
      this.btnDBPath.Name = "btnDBPath";
      this.btnDBPath.Size = new System.Drawing.Size(20, 20);
      this.btnDBPath.TabIndex = 14;
      this.btnDBPath.Text = ">";
      this.btnDBPath.UseVisualStyleBackColor = true;
      this.btnDBPath.Click += new System.EventHandler(this.btnDBPath_Click);
      // 
      // txtPath
      // 
      this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.txtPath.Location = new System.Drawing.Point(20, 190);
      this.txtPath.Name = "txtPath";
      this.txtPath.ReadOnly = true;
      this.txtPath.Size = new System.Drawing.Size(410, 21);
      this.txtPath.TabIndex = 13;
      // 
      // Label4
      // 
      this.Label4.AutoSize = true;
      this.Label4.Location = new System.Drawing.Point(20, 170);
      this.Label4.Name = "Label4";
      this.Label4.Size = new System.Drawing.Size(41, 12);
      this.Label4.TabIndex = 10;
      this.Label4.Text = "label1";
      // 
      // rbMDF
      // 
      this.rbMDF.AutoSize = true;
      this.rbMDF.Location = new System.Drawing.Point(360, 80);
      this.rbMDF.Name = "rbMDF";
      this.rbMDF.Size = new System.Drawing.Size(95, 16);
      this.rbMDF.TabIndex = 8;
      this.rbMDF.TabStop = true;
      this.rbMDF.Text = "radioButton2";
      this.rbMDF.UseVisualStyleBackColor = true;
      this.rbMDF.Click += new System.EventHandler(this.RadioButton_Click);
      // 
      // lblMDF
      // 
      this.lblMDF.AutoSize = true;
      this.lblMDF.Location = new System.Drawing.Point(20, 115);
      this.lblMDF.Name = "lblMDF";
      this.lblMDF.Size = new System.Drawing.Size(41, 12);
      this.lblMDF.TabIndex = 15;
      this.lblMDF.Text = "label1";
      // 
      // txtMDF
      // 
      this.txtMDF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.txtMDF.Location = new System.Drawing.Point(20, 135);
      this.txtMDF.Name = "txtMDF";
      this.txtMDF.ReadOnly = true;
      this.txtMDF.Size = new System.Drawing.Size(410, 21);
      this.txtMDF.TabIndex = 9;
      // 
      // btnMDF
      // 
      this.btnMDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnMDF.Location = new System.Drawing.Point(435, 135);
      this.btnMDF.Name = "btnMDF";
      this.btnMDF.Size = new System.Drawing.Size(20, 20);
      this.btnMDF.TabIndex = 10;
      this.btnMDF.Text = ">";
      this.btnMDF.UseVisualStyleBackColor = true;
      this.btnMDF.Click += new System.EventHandler(this.btnMDF_Click);
      // 
      // rbBak
      // 
      this.rbBak.AutoSize = true;
      this.rbBak.Location = new System.Drawing.Point(200, 80);
      this.rbBak.Name = "rbBak";
      this.rbBak.Size = new System.Drawing.Size(95, 16);
      this.rbBak.TabIndex = 6;
      this.rbBak.Text = "radioButton1";
      this.rbBak.UseVisualStyleBackColor = true;
      this.rbBak.Click += new System.EventHandler(this.RadioButton_Click);
      // 
      // frmNewAccount
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(474, 268);
      this.Controls.Add(this.rbBak);
      this.Controls.Add(this.btnMDF);
      this.Controls.Add(this.lblMDF);
      this.Controls.Add(this.rbMDF);
      this.Controls.Add(this.btnDBPath);
      this.Controls.Add(this.txtPath);
      this.Controls.Add(this.Label4);
      this.Controls.Add(this.btnDBName);
      this.Controls.Add(this.txtBak);
      this.Controls.Add(this.Label3);
      this.Controls.Add(this.rbOld);
      this.Controls.Add(this.rbNew);
      this.Controls.Add(this.cbbDBName);
      this.Controls.Add(this.txtDBName);
      this.Controls.Add(this.Label2);
      this.Controls.Add(this.txtAccName);
      this.Controls.Add(this.Label1);
      this.Controls.Add(this.txtMDF);
      this.Name = "frmNewAccount";
      this.Controls.SetChildIndex(this.txtMDF, 0);
      this.Controls.SetChildIndex(this.Label1, 0);
      this.Controls.SetChildIndex(this.txtAccName, 0);
      this.Controls.SetChildIndex(this.Label2, 0);
      this.Controls.SetChildIndex(this.txtDBName, 0);
      this.Controls.SetChildIndex(this.cbbDBName, 0);
      this.Controls.SetChildIndex(this.rbNew, 0);
      this.Controls.SetChildIndex(this.rbOld, 0);
      this.Controls.SetChildIndex(this.Label3, 0);
      this.Controls.SetChildIndex(this.txtBak, 0);
      this.Controls.SetChildIndex(this.btnDBName, 0);
      this.Controls.SetChildIndex(this.Label4, 0);
      this.Controls.SetChildIndex(this.txtPath, 0);
      this.Controls.SetChildIndex(this.btnDBPath, 0);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.Controls.SetChildIndex(this.rbMDF, 0);
      this.Controls.SetChildIndex(this.lblMDF, 0);
      this.Controls.SetChildIndex(this.btnMDF, 0);
      this.Controls.SetChildIndex(this.rbBak, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label Label1;
    private System.Windows.Forms.TextBox txtAccName;
    private System.Windows.Forms.TextBox txtDBName;
    private System.Windows.Forms.Label Label2;
    private System.Windows.Forms.ComboBox cbbDBName;
    private System.Windows.Forms.RadioButton rbNew;
    private System.Windows.Forms.RadioButton rbOld;
    private System.Windows.Forms.Label Label3;
    private System.Windows.Forms.TextBox txtBak;
    private System.Windows.Forms.Button btnDBName;
    private System.Windows.Forms.Button btnDBPath;
    private System.Windows.Forms.TextBox txtPath;
    private System.Windows.Forms.Label Label4;
    private System.Windows.Forms.RadioButton rbMDF;
    private System.Windows.Forms.Label lblMDF;
    private System.Windows.Forms.TextBox txtMDF;
    private System.Windows.Forms.Button btnMDF;
    private System.Windows.Forms.RadioButton rbBak;
  }
}
