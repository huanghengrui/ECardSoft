namespace ECard78
{
  partial class frmMJMacTime
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
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMJMacTime));
      this.dataGrid = new HeaderView(this.components);
      this.tvGrid = new System.Windows.Forms.TreeView();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
      this.SuspendLayout();
      // 
      // dataGrid
      // 
      this.dataGrid.AllowUserToAddRows = false;
      this.dataGrid.AllowUserToDeleteRows = false;
      this.dataGrid.AllowUserToResizeRows = false;
      this.dataGrid.AutoGenerateColumns = false;
      this.dataGrid.CellHeight = 17;
      this.dataGrid.ColumnDeep = 1;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.dataGrid.ColumnHeadersHeight = 17;
      this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dataGrid.ColumnTreeView = new System.Windows.Forms.TreeView[] {
        this.tvGrid};
      this.dataGrid.ContextMenuStrip = this.contextMenu;
      this.dataGrid.DataSource = this.bindingSource;
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dataGrid.DefaultCellStyle = dataGridViewCellStyle2;
      this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGrid.Location = new System.Drawing.Point(0, 25);
      this.dataGrid.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dataGrid.MergeColumnNames")));
      this.dataGrid.MultiSelect = false;
      this.dataGrid.Name = "dataGrid";
      this.dataGrid.RefreshAtHscroll = false;
      this.dataGrid.RowHeadersVisible = false;
      this.dataGrid.RowTemplate.Height = 23;
      this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dataGrid.Size = new System.Drawing.Size(552, 275);
      this.dataGrid.StandardTab = true;
      this.dataGrid.TabIndex = 8;
      // 
      // tvGrid
      // 
      this.tvGrid.LineColor = System.Drawing.Color.Empty;
      this.tvGrid.Location = new System.Drawing.Point(0, 0);
      this.tvGrid.Name = "tvGrid";
      this.tvGrid.Size = new System.Drawing.Size(121, 97);
      this.tvGrid.TabIndex = 0;
      // 
      // frmMJMacTime
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(552, 326);
      this.Controls.Add(this.dataGrid);
      this.Name = "frmMJMacTime";
      this.Controls.SetChildIndex(this.dataGrid, 0);
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    protected HeaderView dataGrid;
    private System.Windows.Forms.TreeView tvGrid;

  }
}
