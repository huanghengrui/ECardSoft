namespace ECard78
{
  partial class frmRSDepositDiscountAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRSDepositDiscountAdd));
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiscStart = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDiscDiscount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbCardType = new System.Windows.Forms.ComboBox();
            this.txtDiscEnd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(335, 80);
            this.btnCancel.Text = "";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(255, 80);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 23;
            this.label3.Tag = "DiscStart";
            this.label3.Text = "label3";
            // 
            // txtDiscStart
            // 
            this.txtDiscStart.Location = new System.Drawing.Point(310, 10);
            this.txtDiscStart.Name = "txtDiscStart";
            this.txtDiscStart.Size = new System.Drawing.Size(100, 21);
            this.txtDiscStart.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(10, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 25;
            this.label4.Tag = "DiscEnd";
            this.label4.Text = "label4";
            this.label4.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 27;
            this.label1.Tag = "DiscDiscount";
            this.label1.Text = "label1";
            // 
            // txtDiscDiscount
            // 
            this.txtDiscDiscount.Location = new System.Drawing.Point(310, 40);
            this.txtDiscDiscount.Name = "txtDiscDiscount";
            this.txtDiscDiscount.Size = new System.Drawing.Size(100, 21);
            this.txtDiscDiscount.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 28;
            this.label2.Tag = "CardType";
            this.label2.Text = "label2";
            // 
            // cbbCardType
            // 
            this.cbbCardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCardType.FormattingEnabled = true;
            this.cbbCardType.Location = new System.Drawing.Point(100, 10);
            this.cbbCardType.Name = "cbbCardType";
            this.cbbCardType.Size = new System.Drawing.Size(100, 20);
            this.cbbCardType.TabIndex = 0;
            // 
            // txtDiscEnd
            // 
            this.txtDiscEnd.Enabled = false;
            this.txtDiscEnd.Location = new System.Drawing.Point(100, 40);
            this.txtDiscEnd.Name = "txtDiscEnd";
            this.txtDiscEnd.Size = new System.Drawing.Size(100, 21);
            this.txtDiscEnd.TabIndex = 2;
            this.txtDiscEnd.Visible = false;
            // 
            // frmRSDepositDiscountAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(419, 113);
            this.Controls.Add(this.cbbCardType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDiscDiscount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDiscEnd);
            this.Controls.Add(this.txtDiscStart);
            this.Name = "frmRSDepositDiscountAdd";
            this.Controls.SetChildIndex(this.txtDiscStart, 0);
            this.Controls.SetChildIndex(this.txtDiscEnd, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtDiscDiscount, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cbbCardType, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtDiscStart;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtDiscDiscount;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox cbbCardType;
        private System.Windows.Forms.TextBox txtDiscEnd;
    }
}
