namespace ECard78
{
    partial class frmSFPlate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSFPlate));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gpbPortSet = new System.Windows.Forms.GroupBox();
            this.lbAntennaID = new System.Windows.Forms.Label();
            this.lbFirmwareVersion = new System.Windows.Forms.Label();
            this.cbbBaudRate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbSerialPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gpbInfoSet = new System.Windows.Forms.GroupBox();
            this.cbbMoney = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.cbbVarieties = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cbbCategory = new System.Windows.Forms.TextBox();
            this.cbbCardNo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbbFlavor = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.msgGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.gpbPortSet.SuspendLayout();
            this.gpbInfoSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.msgGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ilTreeState
            // 
            this.ilTreeState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeState.ImageStream")));
            this.ilTreeState.Images.SetKeyName(0, "T1.bmp");
            this.ilTreeState.Images.SetKeyName(1, "T2.bmp");
            this.ilTreeState.Images.SetKeyName(2, "T3.bmp");
            // 
            // gpbPortSet
            // 
            this.gpbPortSet.Controls.Add(this.lbAntennaID);
            this.gpbPortSet.Controls.Add(this.lbFirmwareVersion);
            this.gpbPortSet.Controls.Add(this.cbbBaudRate);
            this.gpbPortSet.Controls.Add(this.label2);
            this.gpbPortSet.Controls.Add(this.cbbSerialPort);
            this.gpbPortSet.Controls.Add(this.label1);
            this.gpbPortSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpbPortSet.Location = new System.Drawing.Point(5, 30);
            this.gpbPortSet.Margin = new System.Windows.Forms.Padding(10);
            this.gpbPortSet.MinimumSize = new System.Drawing.Size(0, 80);
            this.gpbPortSet.Name = "gpbPortSet";
            this.gpbPortSet.Size = new System.Drawing.Size(654, 83);
            this.gpbPortSet.TabIndex = 0;
            this.gpbPortSet.TabStop = false;
            this.gpbPortSet.Text = "串口设置";
            // 
            // lbAntennaID
            // 
            this.lbAntennaID.AutoSize = true;
            this.lbAntennaID.Location = new System.Drawing.Point(301, 61);
            this.lbAntennaID.Name = "lbAntennaID";
            this.lbAntennaID.Size = new System.Drawing.Size(53, 12);
            this.lbAntennaID.TabIndex = 6;
            this.lbAntennaID.Text = "天线号码";
            // 
            // lbFirmwareVersion
            // 
            this.lbFirmwareVersion.AutoSize = true;
            this.lbFirmwareVersion.Location = new System.Drawing.Point(302, 32);
            this.lbFirmwareVersion.Name = "lbFirmwareVersion";
            this.lbFirmwareVersion.Size = new System.Drawing.Size(53, 12);
            this.lbFirmwareVersion.TabIndex = 5;
            this.lbFirmwareVersion.Text = "固件版本";
            // 
            // cbbBaudRate
            // 
            this.cbbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBaudRate.FormattingEnabled = true;
            this.cbbBaudRate.Location = new System.Drawing.Point(90, 56);
            this.cbbBaudRate.Name = "cbbBaudRate";
            this.cbbBaudRate.Size = new System.Drawing.Size(121, 20);
            this.cbbBaudRate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "波特率";
            // 
            // cbbSerialPort
            // 
            this.cbbSerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSerialPort.FormattingEnabled = true;
            this.cbbSerialPort.Location = new System.Drawing.Point(91, 25);
            this.cbbSerialPort.Name = "cbbSerialPort";
            this.cbbSerialPort.Size = new System.Drawing.Size(120, 20);
            this.cbbSerialPort.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "端口号";
            // 
            // gpbInfoSet
            // 
            this.gpbInfoSet.Controls.Add(this.cbbMoney);
            this.gpbInfoSet.Controls.Add(this.button2);
            this.gpbInfoSet.Controls.Add(this.cbbVarieties);
            this.gpbInfoSet.Controls.Add(this.button1);
            this.gpbInfoSet.Controls.Add(this.cbbCategory);
            this.gpbInfoSet.Controls.Add(this.cbbCardNo);
            this.gpbInfoSet.Controls.Add(this.label7);
            this.gpbInfoSet.Controls.Add(this.cbbFlavor);
            this.gpbInfoSet.Controls.Add(this.label6);
            this.gpbInfoSet.Controls.Add(this.label5);
            this.gpbInfoSet.Controls.Add(this.label4);
            this.gpbInfoSet.Controls.Add(this.label3);
            this.gpbInfoSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpbInfoSet.Location = new System.Drawing.Point(5, 113);
            this.gpbInfoSet.Margin = new System.Windows.Forms.Padding(10);
            this.gpbInfoSet.Name = "gpbInfoSet";
            this.gpbInfoSet.Size = new System.Drawing.Size(654, 82);
            this.gpbInfoSet.TabIndex = 1;
            this.gpbInfoSet.TabStop = false;
            this.gpbInfoSet.Text = "信息设置";
            // 
            // cbbMoney
            // 
            this.cbbMoney.Enabled = false;
            this.cbbMoney.Location = new System.Drawing.Point(491, 28);
            this.cbbMoney.Name = "cbbMoney";
            this.cbbMoney.Size = new System.Drawing.Size(120, 21);
            this.cbbMoney.TabIndex = 37;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(374, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(31, 20);
            this.button2.TabIndex = 36;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbbVarieties
            // 
            this.cbbVarieties.Enabled = false;
            this.cbbVarieties.Location = new System.Drawing.Point(284, 28);
            this.cbbVarieties.Name = "cbbVarieties";
            this.cbbVarieties.Size = new System.Drawing.Size(121, 21);
            this.cbbVarieties.TabIndex = 35;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(168, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 20);
            this.button1.TabIndex = 33;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbbCategory
            // 
            this.cbbCategory.Enabled = false;
            this.cbbCategory.Location = new System.Drawing.Point(80, 28);
            this.cbbCategory.Name = "cbbCategory";
            this.cbbCategory.Size = new System.Drawing.Size(121, 21);
            this.cbbCategory.TabIndex = 34;
            // 
            // cbbCardNo
            // 
            this.cbbCardNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCardNo.FormattingEnabled = true;
            this.cbbCardNo.ItemHeight = 12;
            this.cbbCardNo.Location = new System.Drawing.Point(79, 54);
            this.cbbCardNo.MaxDropDownItems = 32;
            this.cbbCardNo.Name = "cbbCardNo";
            this.cbbCardNo.Size = new System.Drawing.Size(232, 20);
            this.cbbCardNo.TabIndex = 32;
            this.cbbCardNo.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "卡号";
            this.label7.Visible = false;
            // 
            // cbbFlavor
            // 
            this.cbbFlavor.FormattingEnabled = true;
            this.cbbFlavor.Location = new System.Drawing.Point(490, 53);
            this.cbbFlavor.Name = "cbbFlavor";
            this.cbbFlavor.Size = new System.Drawing.Size(121, 20);
            this.cbbFlavor.TabIndex = 7;
            this.cbbFlavor.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(442, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "口味";
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(442, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "金额";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(236, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "品种";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "类别";
            // 
            // msgGrid
            // 
            this.msgGrid.AllowUserToAddRows = false;
            this.msgGrid.AllowUserToDeleteRows = false;
            this.msgGrid.AllowUserToResizeRows = false;
            this.msgGrid.BackgroundColor = System.Drawing.Color.White;
            this.msgGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.msgGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.msgGrid.ColumnHeadersHeight = 25;
            this.msgGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.msgGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.msgGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msgGrid.Location = new System.Drawing.Point(5, 195);
            this.msgGrid.Margin = new System.Windows.Forms.Padding(10);
            this.msgGrid.MultiSelect = false;
            this.msgGrid.Name = "msgGrid";
            this.msgGrid.ReadOnly = true;
            this.msgGrid.RowHeadersVisible = false;
            this.msgGrid.RowTemplate.Height = 23;
            this.msgGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.msgGrid.Size = new System.Drawing.Size(654, 311);
            this.msgGrid.TabIndex = 14;
            this.msgGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.msgGrid_DataError);
            // 
            // frmSFPlate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 542);
            this.Controls.Add(this.msgGrid);
            this.Controls.Add(this.gpbInfoSet);
            this.Controls.Add(this.gpbPortSet);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(680, 1000);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(680, 400);
            this.Name = "frmSFPlate";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SFPlate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSFPlate_FormClosing);
            this.Controls.SetChildIndex(this.gpbPortSet, 0);
            this.Controls.SetChildIndex(this.gpbInfoSet, 0);
            this.Controls.SetChildIndex(this.msgGrid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.gpbPortSet.ResumeLayout(false);
            this.gpbPortSet.PerformLayout();
            this.gpbInfoSet.ResumeLayout(false);
            this.gpbInfoSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.msgGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbPortSet;
        private System.Windows.Forms.ComboBox cbbBaudRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbSerialPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gpbInfoSet;
        private System.Windows.Forms.ComboBox cbbCardNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbbFlavor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbAntennaID;
        private System.Windows.Forms.Label lbFirmwareVersion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox cbbCategory;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox cbbVarieties;
        private System.Windows.Forms.TextBox cbbMoney;
        public System.Windows.Forms.DataGridView msgGrid;
    }
}