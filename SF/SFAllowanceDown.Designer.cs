namespace ECard78
{
  partial class frmSFAllowanceDown
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
      this.msgGrid = new System.Windows.Forms.DataGridView();
      this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.msgGrid)).BeginInit();
      this.SuspendLayout();
      // 
      // msgGrid
      // 
      this.msgGrid.AllowUserToAddRows = false;
      this.msgGrid.AllowUserToDeleteRows = false;
      this.msgGrid.AllowUserToResizeColumns = false;
      this.msgGrid.AllowUserToResizeRows = false;
      this.msgGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
      this.msgGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.msgGrid.ColumnHeadersVisible = false;
      this.msgGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
      this.msgGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.msgGrid.Location = new System.Drawing.Point(0, 392);
      this.msgGrid.MultiSelect = false;
      this.msgGrid.Name = "msgGrid";
      this.msgGrid.ReadOnly = true;
      this.msgGrid.RowHeadersVisible = false;
      this.msgGrid.RowTemplate.Height = 23;
      this.msgGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
      this.msgGrid.Size = new System.Drawing.Size(894, 150);
      this.msgGrid.TabIndex = 8;
      this.msgGrid.Resize += new System.EventHandler(this.msgGrid_Resize);
      // 
      // Column1
      // 
      this.Column1.HeaderText = "Column1";
      this.Column1.Name = "Column1";
      this.Column1.ReadOnly = true;
      // 
      // frmSFAllowanceDown
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(894, 568);
      this.Controls.Add(this.msgGrid);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmSFAllowanceDown";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Controls.SetChildIndex(this.msgGrid, 1);
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.msgGrid)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.DataGridView msgGrid;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
  }
}
