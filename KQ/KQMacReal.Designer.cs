namespace ECard78
{
  partial class frmKQMacReal
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKQMacReal));
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      this.panel1 = new System.Windows.Forms.Panel();
      this.realGrid = new System.Windows.Forms.DataGridView();
      this.panel3 = new System.Windows.Forms.Panel();
      this.picPhoto = new System.Windows.Forms.PictureBox();
      this.panel2 = new System.Windows.Forms.Panel();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.realGrid)).BeginInit();
      this.panel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).BeginInit();
      this.SuspendLayout();
      // 
      // ilTreeState
      // 
      this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
      this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
      this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
      this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.realGrid);
      this.panel1.Controls.Add(this.panel3);
      this.panel1.Controls.Add(this.panel2);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 87);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(552, 213);
      this.panel1.TabIndex = 9;
      this.panel1.Resize += new System.EventHandler(this.panel1_Resize);
      // 
      // realGrid
      // 
      this.realGrid.AllowUserToAddRows = false;
      this.realGrid.AllowUserToDeleteRows = false;
      this.realGrid.AllowUserToResizeRows = false;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.realGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.realGrid.ColumnHeadersHeight = 25;
      this.realGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.realGrid.DefaultCellStyle = dataGridViewCellStyle2;
      this.realGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.realGrid.Location = new System.Drawing.Point(0, 10);
      this.realGrid.MultiSelect = false;
      this.realGrid.Name = "realGrid";
      this.realGrid.RowHeadersVisible = false;
      this.realGrid.RowTemplate.Height = 23;
      this.realGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.realGrid.Size = new System.Drawing.Size(407, 203);
      this.realGrid.StandardTab = true;
      this.realGrid.TabIndex = 10;
      this.realGrid.SelectionChanged += new System.EventHandler(this.realGrid_SelectionChanged);
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.picPhoto);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
      this.panel3.Location = new System.Drawing.Point(407, 10);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(145, 203);
      this.panel3.TabIndex = 13;
      // 
      // picPhoto
      // 
      this.picPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.picPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
      this.picPhoto.Location = new System.Drawing.Point(0, 0);
      this.picPhoto.Name = "picPhoto";
      this.picPhoto.Size = new System.Drawing.Size(145, 203);
      this.picPhoto.TabIndex = 12;
      this.picPhoto.TabStop = false;
      // 
      // panel2
      // 
      this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel2.Location = new System.Drawing.Point(0, 0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(552, 10);
      this.panel2.TabIndex = 12;
      // 
      // timer1
      // 
      this.timer1.Interval = 1;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // frmKQMacReal
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(552, 326);
      this.Controls.Add(this.panel1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "frmKQMacReal";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmKQMacReal_FormClosing);
      this.Controls.SetChildIndex(this.panel1, 0);
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
      this.panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.realGrid)).EndInit();
      this.panel3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.DataGridView realGrid;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.PictureBox picPhoto;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Timer timer1;


  }
}
