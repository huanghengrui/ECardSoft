namespace ECard78
{
  partial class frmSYOption
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSYOption));
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.chkFaDeposit = new System.Windows.Forms.CheckBox();
      this.chkLongEmpID = new System.Windows.Forms.CheckBox();
      this.chkFaCardFee = new System.Windows.Forms.CheckBox();
      this.chkEmpDelete = new System.Windows.Forms.CheckBox();
      this.txtEmp = new System.Windows.Forms.TextBox();
      this.btnEmp = new System.Windows.Forms.Button();
      this.txtEmpNoNumBit = new System.Windows.Forms.TextBox();
      this.lblEmpNoNumBit = new System.Windows.Forms.Label();
      this.txtEmpNoPrefix = new System.Windows.Forms.TextBox();
      this.lblEmpNoPrefix = new System.Windows.Forms.Label();
      this.chkEmpAuto = new System.Windows.Forms.CheckBox();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.txtCardValidDays = new System.Windows.Forms.TextBox();
      this.lblCardValidDays = new System.Windows.Forms.Label();
      this.txtPubCardSector = new System.Windows.Forms.TextBox();
      this.lblPubCardSector = new System.Windows.Forms.Label();
      this.txtCustomersCode = new System.Windows.Forms.TextBox();
      this.lblCustomersCode = new System.Windows.Forms.Label();
      this.tabPage3 = new System.Windows.Forms.TabPage();
      this.cbbKQCardType = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.cbbOtShow = new System.Windows.Forms.ComboBox();
      this.lblOtShow = new System.Windows.Forms.Label();
      this.cbbNormalShow = new System.Windows.Forms.ComboBox();
      this.lblNormalShow = new System.Windows.Forms.Label();
      this.chkIsNeedOtSure = new System.Windows.Forms.CheckBox();
      this.txtResultDecimalPlaces = new System.Windows.Forms.TextBox();
      this.lblResultDecimalPlaces = new System.Windows.Forms.Label();
      this.txtLeastOtMin = new System.Windows.Forms.TextBox();
      this.lblLeastOtMin = new System.Windows.Forms.Label();
      this.txtLeastWorkMin = new System.Windows.Forms.TextBox();
      this.lblLeastWorkMin = new System.Windows.Forms.Label();
      this.txtRecordInterval = new System.Windows.Forms.TextBox();
      this.lblRecordInterval = new System.Windows.Forms.Label();
      this.tabPage4 = new System.Windows.Forms.TabPage();
      this.chkAdvUseOtherCard = new System.Windows.Forms.CheckBox();
      this.chkAdvTimeGroup = new System.Windows.Forms.CheckBox();
      this.cbbCardProtocol = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.tabPage5 = new System.Windows.Forms.TabPage();
      this.chkMoreDepositType = new System.Windows.Forms.CheckBox();
      this.chkRefAllowance = new System.Windows.Forms.CheckBox();
      this.btnDispSetup = new System.Windows.Forms.Button();
      this.chkExtScreen = new System.Windows.Forms.CheckBox();
      this.chkAllDevAllowance = new System.Windows.Forms.CheckBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.txtSFBtBagDate = new System.Windows.Forms.TextBox();
      this.lblSFBtBagDate = new System.Windows.Forms.Label();
      this.radioButton3 = new System.Windows.Forms.RadioButton();
      this.radioButton2 = new System.Windows.Forms.RadioButton();
      this.radioButton1 = new System.Windows.Forms.RadioButton();
      this.btnLoadKey = new System.Windows.Forms.Button();
      this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
      this.chkLossSelect = new System.Windows.Forms.CheckBox();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.tabPage3.SuspendLayout();
      this.tabPage4.SuspendLayout();
      this.tabPage5.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(360, 280);
      this.btnCancel.Text = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(280, 280);
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
      // tabControl1
      // 
      this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Controls.Add(this.tabPage3);
      this.tabControl1.Controls.Add(this.tabPage4);
      this.tabControl1.Controls.Add(this.tabPage5);
      this.tabControl1.Location = new System.Drawing.Point(10, 10);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(425, 265);
      this.tabControl1.TabIndex = 0;
      // 
      // tabPage1
      // 
      this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
      this.tabPage1.Controls.Add(this.chkFaDeposit);
      this.tabPage1.Controls.Add(this.chkLongEmpID);
      this.tabPage1.Controls.Add(this.chkFaCardFee);
      this.tabPage1.Controls.Add(this.chkEmpDelete);
      this.tabPage1.Controls.Add(this.txtEmp);
      this.tabPage1.Controls.Add(this.btnEmp);
      this.tabPage1.Controls.Add(this.txtEmpNoNumBit);
      this.tabPage1.Controls.Add(this.lblEmpNoNumBit);
      this.tabPage1.Controls.Add(this.txtEmpNoPrefix);
      this.tabPage1.Controls.Add(this.lblEmpNoPrefix);
      this.tabPage1.Controls.Add(this.chkEmpAuto);
      this.tabPage1.Location = new System.Drawing.Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(417, 239);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "tabPage1";
      // 
      // chkFaDeposit
      // 
      this.chkFaDeposit.AutoSize = true;
      this.chkFaDeposit.Location = new System.Drawing.Point(10, 220);
      this.chkFaDeposit.Name = "chkFaDeposit";
      this.chkFaDeposit.Size = new System.Drawing.Size(78, 16);
      this.chkFaDeposit.TabIndex = 10;
      this.chkFaDeposit.Text = "checkBox1";
      this.chkFaDeposit.UseVisualStyleBackColor = true;
      // 
      // chkLongEmpID
      // 
      this.chkLongEmpID.AutoSize = true;
      this.chkLongEmpID.Location = new System.Drawing.Point(10, 200);
      this.chkLongEmpID.Name = "chkLongEmpID";
      this.chkLongEmpID.Size = new System.Drawing.Size(78, 16);
      this.chkLongEmpID.TabIndex = 9;
      this.chkLongEmpID.Text = "checkBox1";
      this.chkLongEmpID.UseVisualStyleBackColor = true;
      // 
      // chkFaCardFee
      // 
      this.chkFaCardFee.AutoSize = true;
      this.chkFaCardFee.Location = new System.Drawing.Point(10, 180);
      this.chkFaCardFee.Name = "chkFaCardFee";
      this.chkFaCardFee.Size = new System.Drawing.Size(78, 16);
      this.chkFaCardFee.TabIndex = 8;
      this.chkFaCardFee.Text = "checkBox1";
      this.chkFaCardFee.UseVisualStyleBackColor = true;
      // 
      // chkEmpDelete
      // 
      this.chkEmpDelete.AutoSize = true;
      this.chkEmpDelete.Location = new System.Drawing.Point(10, 160);
      this.chkEmpDelete.Name = "chkEmpDelete";
      this.chkEmpDelete.Size = new System.Drawing.Size(78, 16);
      this.chkEmpDelete.TabIndex = 7;
      this.chkEmpDelete.Text = "checkBox1";
      this.chkEmpDelete.UseVisualStyleBackColor = true;
      // 
      // txtEmp
      // 
      this.txtEmp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.txtEmp.BackColor = System.Drawing.SystemColors.Control;
      this.txtEmp.Location = new System.Drawing.Point(305, 130);
      this.txtEmp.Name = "txtEmp";
      this.txtEmp.ReadOnly = true;
      this.txtEmp.Size = new System.Drawing.Size(100, 21);
      this.txtEmp.TabIndex = 6;
      // 
      // btnEmp
      // 
      this.btnEmp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnEmp.Location = new System.Drawing.Point(305, 100);
      this.btnEmp.Name = "btnEmp";
      this.btnEmp.Size = new System.Drawing.Size(75, 25);
      this.btnEmp.TabIndex = 5;
      this.btnEmp.Text = "button1";
      this.btnEmp.UseVisualStyleBackColor = true;
      this.btnEmp.Click += new System.EventHandler(this.btnEmp_Click);
      // 
      // txtEmpNoNumBit
      // 
      this.txtEmpNoNumBit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.txtEmpNoNumBit.Location = new System.Drawing.Point(305, 70);
      this.txtEmpNoNumBit.MaxLength = 2;
      this.txtEmpNoNumBit.Name = "txtEmpNoNumBit";
      this.txtEmpNoNumBit.Size = new System.Drawing.Size(100, 21);
      this.txtEmpNoNumBit.TabIndex = 4;
      // 
      // lblEmpNoNumBit
      // 
      this.lblEmpNoNumBit.AutoSize = true;
      this.lblEmpNoNumBit.Location = new System.Drawing.Point(10, 74);
      this.lblEmpNoNumBit.Name = "lblEmpNoNumBit";
      this.lblEmpNoNumBit.Size = new System.Drawing.Size(41, 12);
      this.lblEmpNoNumBit.TabIndex = 3;
      this.lblEmpNoNumBit.Text = "label2";
      // 
      // txtEmpNoPrefix
      // 
      this.txtEmpNoPrefix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.txtEmpNoPrefix.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
      this.txtEmpNoPrefix.Location = new System.Drawing.Point(305, 40);
      this.txtEmpNoPrefix.MaxLength = 1;
      this.txtEmpNoPrefix.Name = "txtEmpNoPrefix";
      this.txtEmpNoPrefix.Size = new System.Drawing.Size(100, 21);
      this.txtEmpNoPrefix.TabIndex = 2;
      // 
      // lblEmpNoPrefix
      // 
      this.lblEmpNoPrefix.AutoSize = true;
      this.lblEmpNoPrefix.Location = new System.Drawing.Point(10, 44);
      this.lblEmpNoPrefix.Name = "lblEmpNoPrefix";
      this.lblEmpNoPrefix.Size = new System.Drawing.Size(41, 12);
      this.lblEmpNoPrefix.TabIndex = 1;
      this.lblEmpNoPrefix.Text = "label1";
      // 
      // chkEmpAuto
      // 
      this.chkEmpAuto.AutoSize = true;
      this.chkEmpAuto.Location = new System.Drawing.Point(10, 10);
      this.chkEmpAuto.Name = "chkEmpAuto";
      this.chkEmpAuto.Size = new System.Drawing.Size(78, 16);
      this.chkEmpAuto.TabIndex = 0;
      this.chkEmpAuto.Text = "checkBox1";
      this.chkEmpAuto.UseVisualStyleBackColor = true;
      // 
      // tabPage2
      // 
      this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
      this.tabPage2.Controls.Add(this.chkLossSelect);
      this.tabPage2.Controls.Add(this.txtCardValidDays);
      this.tabPage2.Controls.Add(this.lblCardValidDays);
      this.tabPage2.Controls.Add(this.txtPubCardSector);
      this.tabPage2.Controls.Add(this.lblPubCardSector);
      this.tabPage2.Controls.Add(this.txtCustomersCode);
      this.tabPage2.Controls.Add(this.lblCustomersCode);
      this.tabPage2.Location = new System.Drawing.Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(417, 239);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "tabPage2";
      // 
      // txtCardValidDays
      // 
      this.txtCardValidDays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.txtCardValidDays.BackColor = System.Drawing.SystemColors.Window;
      this.txtCardValidDays.Location = new System.Drawing.Point(305, 40);
      this.txtCardValidDays.MaxLength = 5;
      this.txtCardValidDays.Name = "txtCardValidDays";
      this.txtCardValidDays.Size = new System.Drawing.Size(100, 21);
      this.txtCardValidDays.TabIndex = 5;
      // 
      // lblCardValidDays
      // 
      this.lblCardValidDays.AutoSize = true;
      this.lblCardValidDays.Location = new System.Drawing.Point(10, 44);
      this.lblCardValidDays.Name = "lblCardValidDays";
      this.lblCardValidDays.Size = new System.Drawing.Size(41, 12);
      this.lblCardValidDays.TabIndex = 4;
      this.lblCardValidDays.Text = "label5";
      // 
      // txtPubCardSector
      // 
      this.txtPubCardSector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.txtPubCardSector.BackColor = System.Drawing.SystemColors.Window;
      this.txtPubCardSector.Location = new System.Drawing.Point(305, 10);
      this.txtPubCardSector.MaxLength = 2;
      this.txtPubCardSector.Name = "txtPubCardSector";
      this.txtPubCardSector.Size = new System.Drawing.Size(100, 21);
      this.txtPubCardSector.TabIndex = 3;
      // 
      // lblPubCardSector
      // 
      this.lblPubCardSector.AutoSize = true;
      this.lblPubCardSector.Location = new System.Drawing.Point(10, 14);
      this.lblPubCardSector.Name = "lblPubCardSector";
      this.lblPubCardSector.Size = new System.Drawing.Size(41, 12);
      this.lblPubCardSector.TabIndex = 2;
      this.lblPubCardSector.Text = "label4";
      // 
      // txtCustomersCode
      // 
      this.txtCustomersCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.txtCustomersCode.BackColor = System.Drawing.SystemColors.Window;
      this.txtCustomersCode.Enabled = false;
      this.txtCustomersCode.Location = new System.Drawing.Point(305, 10);
      this.txtCustomersCode.MaxLength = 6;
      this.txtCustomersCode.Name = "txtCustomersCode";
      this.txtCustomersCode.PasswordChar = '*';
      this.txtCustomersCode.Size = new System.Drawing.Size(100, 21);
      this.txtCustomersCode.TabIndex = 1;
      this.txtCustomersCode.Visible = false;
      // 
      // lblCustomersCode
      // 
      this.lblCustomersCode.AutoSize = true;
      this.lblCustomersCode.Enabled = false;
      this.lblCustomersCode.Location = new System.Drawing.Point(10, 14);
      this.lblCustomersCode.Name = "lblCustomersCode";
      this.lblCustomersCode.Size = new System.Drawing.Size(41, 12);
      this.lblCustomersCode.TabIndex = 0;
      this.lblCustomersCode.Text = "label3";
      this.lblCustomersCode.Visible = false;
      // 
      // tabPage3
      // 
      this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
      this.tabPage3.Controls.Add(this.cbbKQCardType);
      this.tabPage3.Controls.Add(this.label1);
      this.tabPage3.Controls.Add(this.cbbOtShow);
      this.tabPage3.Controls.Add(this.lblOtShow);
      this.tabPage3.Controls.Add(this.cbbNormalShow);
      this.tabPage3.Controls.Add(this.lblNormalShow);
      this.tabPage3.Controls.Add(this.chkIsNeedOtSure);
      this.tabPage3.Controls.Add(this.txtResultDecimalPlaces);
      this.tabPage3.Controls.Add(this.lblResultDecimalPlaces);
      this.tabPage3.Controls.Add(this.txtLeastOtMin);
      this.tabPage3.Controls.Add(this.lblLeastOtMin);
      this.tabPage3.Controls.Add(this.txtLeastWorkMin);
      this.tabPage3.Controls.Add(this.lblLeastWorkMin);
      this.tabPage3.Controls.Add(this.txtRecordInterval);
      this.tabPage3.Controls.Add(this.lblRecordInterval);
      this.tabPage3.Location = new System.Drawing.Point(4, 22);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage3.Size = new System.Drawing.Size(417, 239);
      this.tabPage3.TabIndex = 2;
      this.tabPage3.Text = "tabPage3";
      // 
      // cbbKQCardType
      // 
      this.cbbKQCardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbKQCardType.FormattingEnabled = true;
      this.cbbKQCardType.Location = new System.Drawing.Point(305, 210);
      this.cbbKQCardType.Name = "cbbKQCardType";
      this.cbbKQCardType.Size = new System.Drawing.Size(100, 20);
      this.cbbKQCardType.TabIndex = 18;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(10, 214);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 12);
      this.label1.TabIndex = 17;
      this.label1.Text = "label1";
      // 
      // cbbOtShow
      // 
      this.cbbOtShow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbOtShow.FormattingEnabled = true;
      this.cbbOtShow.Location = new System.Drawing.Point(305, 180);
      this.cbbOtShow.Name = "cbbOtShow";
      this.cbbOtShow.Size = new System.Drawing.Size(100, 20);
      this.cbbOtShow.TabIndex = 16;
      // 
      // lblOtShow
      // 
      this.lblOtShow.AutoSize = true;
      this.lblOtShow.Location = new System.Drawing.Point(10, 184);
      this.lblOtShow.Name = "lblOtShow";
      this.lblOtShow.Size = new System.Drawing.Size(41, 12);
      this.lblOtShow.TabIndex = 15;
      this.lblOtShow.Text = "label1";
      // 
      // cbbNormalShow
      // 
      this.cbbNormalShow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbNormalShow.FormattingEnabled = true;
      this.cbbNormalShow.Location = new System.Drawing.Point(305, 150);
      this.cbbNormalShow.Name = "cbbNormalShow";
      this.cbbNormalShow.Size = new System.Drawing.Size(100, 20);
      this.cbbNormalShow.TabIndex = 14;
      // 
      // lblNormalShow
      // 
      this.lblNormalShow.AutoSize = true;
      this.lblNormalShow.Location = new System.Drawing.Point(10, 154);
      this.lblNormalShow.Name = "lblNormalShow";
      this.lblNormalShow.Size = new System.Drawing.Size(41, 12);
      this.lblNormalShow.TabIndex = 13;
      this.lblNormalShow.Text = "label1";
      // 
      // chkIsNeedOtSure
      // 
      this.chkIsNeedOtSure.AutoSize = true;
      this.chkIsNeedOtSure.Location = new System.Drawing.Point(10, 130);
      this.chkIsNeedOtSure.Name = "chkIsNeedOtSure";
      this.chkIsNeedOtSure.Size = new System.Drawing.Size(78, 16);
      this.chkIsNeedOtSure.TabIndex = 12;
      this.chkIsNeedOtSure.Text = "checkBox1";
      this.chkIsNeedOtSure.UseVisualStyleBackColor = true;
      // 
      // txtResultDecimalPlaces
      // 
      this.txtResultDecimalPlaces.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.txtResultDecimalPlaces.Location = new System.Drawing.Point(305, 100);
      this.txtResultDecimalPlaces.MaxLength = 3;
      this.txtResultDecimalPlaces.Name = "txtResultDecimalPlaces";
      this.txtResultDecimalPlaces.Size = new System.Drawing.Size(100, 21);
      this.txtResultDecimalPlaces.TabIndex = 11;
      // 
      // lblResultDecimalPlaces
      // 
      this.lblResultDecimalPlaces.AutoSize = true;
      this.lblResultDecimalPlaces.Location = new System.Drawing.Point(10, 104);
      this.lblResultDecimalPlaces.Name = "lblResultDecimalPlaces";
      this.lblResultDecimalPlaces.Size = new System.Drawing.Size(41, 12);
      this.lblResultDecimalPlaces.TabIndex = 10;
      this.lblResultDecimalPlaces.Text = "label3";
      // 
      // txtLeastOtMin
      // 
      this.txtLeastOtMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.txtLeastOtMin.Location = new System.Drawing.Point(305, 70);
      this.txtLeastOtMin.MaxLength = 3;
      this.txtLeastOtMin.Name = "txtLeastOtMin";
      this.txtLeastOtMin.Size = new System.Drawing.Size(100, 21);
      this.txtLeastOtMin.TabIndex = 9;
      // 
      // lblLeastOtMin
      // 
      this.lblLeastOtMin.AutoSize = true;
      this.lblLeastOtMin.Location = new System.Drawing.Point(10, 74);
      this.lblLeastOtMin.Name = "lblLeastOtMin";
      this.lblLeastOtMin.Size = new System.Drawing.Size(41, 12);
      this.lblLeastOtMin.TabIndex = 8;
      this.lblLeastOtMin.Text = "label3";
      // 
      // txtLeastWorkMin
      // 
      this.txtLeastWorkMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.txtLeastWorkMin.Location = new System.Drawing.Point(305, 40);
      this.txtLeastWorkMin.MaxLength = 3;
      this.txtLeastWorkMin.Name = "txtLeastWorkMin";
      this.txtLeastWorkMin.Size = new System.Drawing.Size(100, 21);
      this.txtLeastWorkMin.TabIndex = 7;
      // 
      // lblLeastWorkMin
      // 
      this.lblLeastWorkMin.AutoSize = true;
      this.lblLeastWorkMin.Location = new System.Drawing.Point(10, 44);
      this.lblLeastWorkMin.Name = "lblLeastWorkMin";
      this.lblLeastWorkMin.Size = new System.Drawing.Size(41, 12);
      this.lblLeastWorkMin.TabIndex = 6;
      this.lblLeastWorkMin.Text = "label3";
      // 
      // txtRecordInterval
      // 
      this.txtRecordInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.txtRecordInterval.Location = new System.Drawing.Point(305, 10);
      this.txtRecordInterval.MaxLength = 3;
      this.txtRecordInterval.Name = "txtRecordInterval";
      this.txtRecordInterval.Size = new System.Drawing.Size(100, 21);
      this.txtRecordInterval.TabIndex = 5;
      // 
      // lblRecordInterval
      // 
      this.lblRecordInterval.AutoSize = true;
      this.lblRecordInterval.Location = new System.Drawing.Point(10, 14);
      this.lblRecordInterval.Name = "lblRecordInterval";
      this.lblRecordInterval.Size = new System.Drawing.Size(41, 12);
      this.lblRecordInterval.TabIndex = 4;
      this.lblRecordInterval.Text = "label3";
      // 
      // tabPage4
      // 
      this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
      this.tabPage4.Controls.Add(this.chkAdvUseOtherCard);
      this.tabPage4.Controls.Add(this.chkAdvTimeGroup);
      this.tabPage4.Controls.Add(this.cbbCardProtocol);
      this.tabPage4.Controls.Add(this.label2);
      this.tabPage4.Location = new System.Drawing.Point(4, 22);
      this.tabPage4.Name = "tabPage4";
      this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage4.Size = new System.Drawing.Size(417, 239);
      this.tabPage4.TabIndex = 3;
      this.tabPage4.Text = "tabPage4";
      // 
      // chkAdvUseOtherCard
      // 
      this.chkAdvUseOtherCard.AutoSize = true;
      this.chkAdvUseOtherCard.Location = new System.Drawing.Point(10, 65);
      this.chkAdvUseOtherCard.Name = "chkAdvUseOtherCard";
      this.chkAdvUseOtherCard.Size = new System.Drawing.Size(78, 16);
      this.chkAdvUseOtherCard.TabIndex = 22;
      this.chkAdvUseOtherCard.Text = "checkBox1";
      this.chkAdvUseOtherCard.UseVisualStyleBackColor = true;
      // 
      // chkAdvTimeGroup
      // 
      this.chkAdvTimeGroup.AutoSize = true;
      this.chkAdvTimeGroup.Location = new System.Drawing.Point(10, 40);
      this.chkAdvTimeGroup.Name = "chkAdvTimeGroup";
      this.chkAdvTimeGroup.Size = new System.Drawing.Size(78, 16);
      this.chkAdvTimeGroup.TabIndex = 21;
      this.chkAdvTimeGroup.Text = "checkBox1";
      this.chkAdvTimeGroup.UseVisualStyleBackColor = true;
      // 
      // cbbCardProtocol
      // 
      this.cbbCardProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbCardProtocol.FormattingEnabled = true;
      this.cbbCardProtocol.Items.AddRange(new object[] {
            "WG26",
            "WG34"});
      this.cbbCardProtocol.Location = new System.Drawing.Point(305, 10);
      this.cbbCardProtocol.Name = "cbbCardProtocol";
      this.cbbCardProtocol.Size = new System.Drawing.Size(100, 20);
      this.cbbCardProtocol.TabIndex = 20;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(10, 14);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(41, 12);
      this.label2.TabIndex = 19;
      this.label2.Tag = "CardProtocol";
      this.label2.Text = "label2";
      // 
      // tabPage5
      // 
      this.tabPage5.BackColor = System.Drawing.SystemColors.Control;
      this.tabPage5.Controls.Add(this.chkMoreDepositType);
      this.tabPage5.Controls.Add(this.chkRefAllowance);
      this.tabPage5.Controls.Add(this.btnDispSetup);
      this.tabPage5.Controls.Add(this.chkExtScreen);
      this.tabPage5.Controls.Add(this.chkAllDevAllowance);
      this.tabPage5.Controls.Add(this.groupBox1);
      this.tabPage5.Location = new System.Drawing.Point(4, 22);
      this.tabPage5.Name = "tabPage5";
      this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage5.Size = new System.Drawing.Size(417, 239);
      this.tabPage5.TabIndex = 4;
      this.tabPage5.Text = "tabPage5";
      // 
      // chkMoreDepositType
      // 
      this.chkMoreDepositType.AutoSize = true;
      this.chkMoreDepositType.Location = new System.Drawing.Point(10, 210);
      this.chkMoreDepositType.Name = "chkMoreDepositType";
      this.chkMoreDepositType.Size = new System.Drawing.Size(78, 16);
      this.chkMoreDepositType.TabIndex = 12;
      this.chkMoreDepositType.Text = "checkBox1";
      this.chkMoreDepositType.UseVisualStyleBackColor = true;
      // 
      // chkRefAllowance
      // 
      this.chkRefAllowance.AutoSize = true;
      this.chkRefAllowance.Location = new System.Drawing.Point(10, 185);
      this.chkRefAllowance.Name = "chkRefAllowance";
      this.chkRefAllowance.Size = new System.Drawing.Size(78, 16);
      this.chkRefAllowance.TabIndex = 11;
      this.chkRefAllowance.Text = "checkBox1";
      this.chkRefAllowance.UseVisualStyleBackColor = true;
      // 
      // btnDispSetup
      // 
      this.btnDispSetup.Location = new System.Drawing.Point(297, 160);
      this.btnDispSetup.Name = "btnDispSetup";
      this.btnDispSetup.Size = new System.Drawing.Size(75, 20);
      this.btnDispSetup.TabIndex = 10;
      this.btnDispSetup.Text = "button1";
      this.btnDispSetup.UseVisualStyleBackColor = true;
      this.btnDispSetup.Click += new System.EventHandler(this.btnDispSetup_Click);
      // 
      // chkExtScreen
      // 
      this.chkExtScreen.AutoSize = true;
      this.chkExtScreen.Location = new System.Drawing.Point(10, 160);
      this.chkExtScreen.Name = "chkExtScreen";
      this.chkExtScreen.Size = new System.Drawing.Size(78, 16);
      this.chkExtScreen.TabIndex = 9;
      this.chkExtScreen.Text = "checkBox1";
      this.chkExtScreen.UseVisualStyleBackColor = true;
      this.chkExtScreen.CheckedChanged += new System.EventHandler(this.chkExtScreen_CheckedChanged);
      // 
      // chkAllDevAllowance
      // 
      this.chkAllDevAllowance.AutoSize = true;
      this.chkAllDevAllowance.Location = new System.Drawing.Point(10, 135);
      this.chkAllDevAllowance.Name = "chkAllDevAllowance";
      this.chkAllDevAllowance.Size = new System.Drawing.Size(78, 16);
      this.chkAllDevAllowance.TabIndex = 8;
      this.chkAllDevAllowance.Text = "checkBox1";
      this.chkAllDevAllowance.UseVisualStyleBackColor = true;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.txtSFBtBagDate);
      this.groupBox1.Controls.Add(this.lblSFBtBagDate);
      this.groupBox1.Controls.Add(this.radioButton3);
      this.groupBox1.Controls.Add(this.radioButton2);
      this.groupBox1.Controls.Add(this.radioButton1);
      this.groupBox1.Location = new System.Drawing.Point(10, 10);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(397, 110);
      this.groupBox1.TabIndex = 6;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "groupBox1";
      // 
      // txtSFBtBagDate
      // 
      this.txtSFBtBagDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.txtSFBtBagDate.Location = new System.Drawing.Point(287, 80);
      this.txtSFBtBagDate.MaxLength = 3;
      this.txtSFBtBagDate.Name = "txtSFBtBagDate";
      this.txtSFBtBagDate.Size = new System.Drawing.Size(100, 21);
      this.txtSFBtBagDate.TabIndex = 6;
      // 
      // lblSFBtBagDate
      // 
      this.lblSFBtBagDate.AutoSize = true;
      this.lblSFBtBagDate.Location = new System.Drawing.Point(30, 84);
      this.lblSFBtBagDate.Name = "lblSFBtBagDate";
      this.lblSFBtBagDate.Size = new System.Drawing.Size(41, 12);
      this.lblSFBtBagDate.TabIndex = 5;
      this.lblSFBtBagDate.Text = "label3";
      // 
      // radioButton3
      // 
      this.radioButton3.AutoSize = true;
      this.radioButton3.Location = new System.Drawing.Point(10, 60);
      this.radioButton3.Name = "radioButton3";
      this.radioButton3.Size = new System.Drawing.Size(95, 16);
      this.radioButton3.TabIndex = 2;
      this.radioButton3.TabStop = true;
      this.radioButton3.Text = "radioButton3";
      this.radioButton3.UseVisualStyleBackColor = true;
      // 
      // radioButton2
      // 
      this.radioButton2.AutoSize = true;
      this.radioButton2.Location = new System.Drawing.Point(10, 40);
      this.radioButton2.Name = "radioButton2";
      this.radioButton2.Size = new System.Drawing.Size(95, 16);
      this.radioButton2.TabIndex = 1;
      this.radioButton2.TabStop = true;
      this.radioButton2.Text = "radioButton2";
      this.radioButton2.UseVisualStyleBackColor = true;
      // 
      // radioButton1
      // 
      this.radioButton1.AutoSize = true;
      this.radioButton1.Location = new System.Drawing.Point(10, 20);
      this.radioButton1.Name = "radioButton1";
      this.radioButton1.Size = new System.Drawing.Size(95, 16);
      this.radioButton1.TabIndex = 0;
      this.radioButton1.TabStop = true;
      this.radioButton1.Text = "radioButton1";
      this.radioButton1.UseVisualStyleBackColor = true;
      // 
      // btnLoadKey
      // 
      this.btnLoadKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnLoadKey.Location = new System.Drawing.Point(10, 280);
      this.btnLoadKey.Name = "btnLoadKey";
      this.btnLoadKey.Size = new System.Drawing.Size(120, 25);
      this.btnLoadKey.TabIndex = 1;
      this.btnLoadKey.Text = "button2";
      this.btnLoadKey.UseVisualStyleBackColor = true;
      this.btnLoadKey.Click += new System.EventHandler(this.btnLoadKey_Click);
      // 
      // chkLossSelect
      // 
      this.chkLossSelect.AutoSize = true;
      this.chkLossSelect.Location = new System.Drawing.Point(10, 70);
      this.chkLossSelect.Name = "chkLossSelect";
      this.chkLossSelect.Size = new System.Drawing.Size(78, 16);
      this.chkLossSelect.TabIndex = 8;
      this.chkLossSelect.Text = "checkBox1";
      this.chkLossSelect.UseVisualStyleBackColor = true;
      // 
      // frmSYOption
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.ClientSize = new System.Drawing.Size(444, 313);
      this.Controls.Add(this.tabControl1);
      this.Controls.Add(this.btnLoadKey);
      this.KeyPreview = true;
      this.Name = "frmSYOption";
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSYOption_KeyDown);
      this.Controls.SetChildIndex(this.btnLoadKey, 0);
      this.Controls.SetChildIndex(this.tabControl1, 0);
      this.Controls.SetChildIndex(this.btnOk, 0);
      this.Controls.SetChildIndex(this.btnCancel, 0);
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage1.PerformLayout();
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
      this.tabPage3.ResumeLayout(false);
      this.tabPage3.PerformLayout();
      this.tabPage4.ResumeLayout(false);
      this.tabPage4.PerformLayout();
      this.tabPage5.ResumeLayout(false);
      this.tabPage5.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.TextBox txtEmp;
    private System.Windows.Forms.Button btnEmp;
    private System.Windows.Forms.TextBox txtEmpNoNumBit;
    private System.Windows.Forms.Label lblEmpNoNumBit;
    private System.Windows.Forms.TextBox txtEmpNoPrefix;
    private System.Windows.Forms.Label lblEmpNoPrefix;
    private System.Windows.Forms.CheckBox chkEmpAuto;
    private System.Windows.Forms.TextBox txtCardValidDays;
    private System.Windows.Forms.Label lblCardValidDays;
    private System.Windows.Forms.TextBox txtPubCardSector;
    private System.Windows.Forms.Label lblPubCardSector;
    private System.Windows.Forms.TextBox txtCustomersCode;
    private System.Windows.Forms.Label lblCustomersCode;
    private System.Windows.Forms.Button btnLoadKey;
    private System.Windows.Forms.TabPage tabPage3;
    private System.Windows.Forms.OpenFileDialog dlgOpen;
    private System.Windows.Forms.TextBox txtLeastOtMin;
    private System.Windows.Forms.Label lblLeastOtMin;
    private System.Windows.Forms.TextBox txtLeastWorkMin;
    private System.Windows.Forms.Label lblLeastWorkMin;
    private System.Windows.Forms.TextBox txtRecordInterval;
    private System.Windows.Forms.Label lblRecordInterval;
    private System.Windows.Forms.TabPage tabPage4;
    private System.Windows.Forms.CheckBox chkIsNeedOtSure;
    private System.Windows.Forms.TextBox txtResultDecimalPlaces;
    private System.Windows.Forms.Label lblResultDecimalPlaces;
    private System.Windows.Forms.ComboBox cbbOtShow;
    private System.Windows.Forms.Label lblOtShow;
    private System.Windows.Forms.ComboBox cbbNormalShow;
    private System.Windows.Forms.Label lblNormalShow;
    private System.Windows.Forms.CheckBox chkEmpDelete;
    private System.Windows.Forms.ComboBox cbbKQCardType;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TabPage tabPage5;
    private System.Windows.Forms.ComboBox cbbCardProtocol;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.CheckBox chkAdvTimeGroup;
    private System.Windows.Forms.CheckBox chkFaCardFee;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label lblSFBtBagDate;
    private System.Windows.Forms.RadioButton radioButton3;
    private System.Windows.Forms.RadioButton radioButton2;
    private System.Windows.Forms.RadioButton radioButton1;
    private System.Windows.Forms.TextBox txtSFBtBagDate;
    private System.Windows.Forms.CheckBox chkLongEmpID;
    private System.Windows.Forms.CheckBox chkAdvUseOtherCard;
    private System.Windows.Forms.CheckBox chkAllDevAllowance;
    private System.Windows.Forms.CheckBox chkExtScreen;
    private System.Windows.Forms.Button btnDispSetup;
    private System.Windows.Forms.CheckBox chkFaDeposit;
    private System.Windows.Forms.CheckBox chkRefAllowance;
    private System.Windows.Forms.CheckBox chkMoreDepositType;
    private System.Windows.Forms.CheckBox chkLossSelect;
  }
}
