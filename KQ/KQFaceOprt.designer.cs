namespace ECard78
{
  partial class frmKQFaceOprt
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKQFaceOprt));
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      this.dataGrid = new System.Windows.Forms.DataGridView();
      this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.msgGrid = new System.Windows.Forms.DataGridView();
      this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.btnOprt = new System.Windows.Forms.Button();
      this.btnExit = new System.Windows.Forms.Button();
      this.lblMsg = new System.Windows.Forms.Label();
      this.progBar = new System.Windows.Forms.ProgressBar();
      this.GridMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ItemSelect = new System.Windows.Forms.ToolStripMenuItem();
      this.ItemUnselect = new System.Windows.Forms.ToolStripMenuItem();
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.msgGrid)).BeginInit();
      this.GridMenu.SuspendLayout();
      this.SuspendLayout();
      // 
      // ilTreeState
      // 
      this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
      this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
      this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
      this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
      // 
      // dataGrid
      // 
      this.dataGrid.AllowUserToAddRows = false;
      this.dataGrid.AllowUserToDeleteRows = false;
      this.dataGrid.AllowUserToResizeRows = false;
      this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.dataGrid.AutoGenerateColumns = false;
      this.dataGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
      dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.dataGrid.ColumnHeadersHeight = 25;
      this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dataGrid.ContextMenuStrip = this.GridMenu;
      this.dataGrid.DataSource = this.bindingSource;
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
      dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(241)))), ((int)(((byte)(244)))));
      dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
      dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dataGrid.DefaultCellStyle = dataGridViewCellStyle2;
      this.dataGrid.Location = new System.Drawing.Point(10, 10);
      this.dataGrid.MultiSelect = false;
      this.dataGrid.Name = "dataGrid";
      this.dataGrid.RowHeadersVisible = false;
      this.dataGrid.RowTemplate.Height = 23;
      this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dataGrid.Size = new System.Drawing.Size(675, 256);
      this.dataGrid.StandardTab = true;
      this.dataGrid.TabIndex = 0;
      this.dataGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGrid_DataError);
      // 
      // bindingSource
      // 
      this.bindingSource.AllowNew = false;
      // 
      // msgGrid
      // 
      this.msgGrid.AllowUserToAddRows = false;
      this.msgGrid.AllowUserToDeleteRows = false;
      this.msgGrid.AllowUserToResizeColumns = false;
      this.msgGrid.AllowUserToResizeRows = false;
      this.msgGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
      this.msgGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
      this.msgGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.msgGrid.ColumnHeadersVisible = false;
      this.msgGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
      this.msgGrid.Location = new System.Drawing.Point(10, 275);
      this.msgGrid.MultiSelect = false;
      this.msgGrid.Name = "msgGrid";
      this.msgGrid.ReadOnly = true;
      this.msgGrid.RowHeadersVisible = false;
      this.msgGrid.RowTemplate.Height = 23;
      this.msgGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
      this.msgGrid.Size = new System.Drawing.Size(675, 105);
      this.msgGrid.TabIndex = 1;
      this.msgGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.msgGrid_DataError);
      this.msgGrid.Resize += new System.EventHandler(this.msgGrid_Resize);
      // 
      // Column1
      // 
      this.Column1.HeaderText = "Column1";
      this.Column1.Name = "Column1";
      this.Column1.ReadOnly = true;
      // 
      // btnOprt
      // 
      this.btnOprt.Location = new System.Drawing.Point(10, 390);
      this.btnOprt.Name = "btnOprt";
      this.btnOprt.Size = new System.Drawing.Size(100, 25);
      this.btnOprt.TabIndex = 2;
      this.btnOprt.Text = "button1";
      this.btnOprt.UseVisualStyleBackColor = true;
      this.btnOprt.Click += new System.EventHandler(this.btnOprt_Click);
      // 
      // btnExit
      // 
      this.btnExit.Location = new System.Drawing.Point(610, 390);
      this.btnExit.Name = "btnExit";
      this.btnExit.Size = new System.Drawing.Size(75, 25);
      this.btnExit.TabIndex = 3;
      this.btnExit.Text = "button2";
      this.btnExit.UseVisualStyleBackColor = true;
      this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
      // 
      // lblMsg
      // 
      this.lblMsg.AutoSize = true;
      this.lblMsg.Location = new System.Drawing.Point(130, 390);
      this.lblMsg.Name = "lblMsg";
      this.lblMsg.Size = new System.Drawing.Size(41, 12);
      this.lblMsg.TabIndex = 4;
      this.lblMsg.Text = "label1";
      // 
      // progBar
      // 
      this.progBar.Location = new System.Drawing.Point(130, 405);
      this.progBar.Name = "progBar";
      this.progBar.Size = new System.Drawing.Size(300, 15);
      this.progBar.TabIndex = 5;
      // 
      // GridMenu
      // 
      this.GridMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemSelect,
            this.ItemUnselect});
      this.GridMenu.Name = "GridMenu";
      this.GridMenu.Size = new System.Drawing.Size(179, 70);
      // 
      // ItemSelect
      // 
      this.ItemSelect.Name = "ItemSelect";
      this.ItemSelect.Size = new System.Drawing.Size(178, 22);
      this.ItemSelect.Text = "toolStripMenuItem1";
      this.ItemSelect.Click += new System.EventHandler(this.ItemSelect_Click);
      // 
      // ItemUnselect
      // 
      this.ItemUnselect.Name = "ItemUnselect";
      this.ItemUnselect.Size = new System.Drawing.Size(178, 22);
      this.ItemUnselect.Text = "toolStripMenuItem2";
      this.ItemUnselect.Click += new System.EventHandler(this.ItemUnselect_Click);
      // 
      // frmKQFaceOprt
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(694, 428);
      this.Controls.Add(this.progBar);
      this.Controls.Add(this.lblMsg);
      this.Controls.Add(this.btnExit);
      this.Controls.Add(this.btnOprt);
      this.Controls.Add(this.msgGrid);
      this.Controls.Add(this.dataGrid);
      this.Name = "frmKQFaceOprt";
      this.Text = "";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmKQFaceOprt_FormClosing);
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.msgGrid)).EndInit();
      this.GridMenu.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    public System.Windows.Forms.DataGridView dataGrid;
    protected System.Windows.Forms.BindingSource bindingSource;
    private System.Windows.Forms.DataGridView msgGrid;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    private System.Windows.Forms.Button btnOprt;
    private System.Windows.Forms.Button btnExit;
    private System.Windows.Forms.Label lblMsg;
    private System.Windows.Forms.ProgressBar progBar;
    private System.Windows.Forms.ContextMenuStrip GridMenu;
    private System.Windows.Forms.ToolStripMenuItem ItemSelect;
    private System.Windows.Forms.ToolStripMenuItem ItemUnselect;

  }
}
