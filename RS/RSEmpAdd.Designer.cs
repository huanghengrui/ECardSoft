namespace ECard78
{
  partial class frmRSEmpAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRSEmpAdd));
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmpNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbEmpSex = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDepartName = new System.Windows.Forms.TextBox();
            this.btnSelectDepart = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmpHireDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmpCertNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmpAddress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEmpZipNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEmpEmail = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbbCardType = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCardSectorNo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCardStartDate = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCardEndDate = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCardFingerNo = new System.Windows.Forms.TextBox();
            this.picPhoto = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.chkIsAdd = new System.Windows.Forms.CheckBox();
            this.txtCardPWD = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.btnSelectEmpHireDate = new System.Windows.Forms.Button();
            this.btnSelectCardStartDate = new System.Windows.Forms.Button();
            this.btnSelectCardEndDate = new System.Windows.Forms.Button();
            this.chkIsAttend = new System.Windows.Forms.CheckBox();
            this.txtEmpPhoneNo = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cbbFingerPrivilege = new System.Windows.Forms.ComboBox();
            this.txtOtherCardNo = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.btnIDCard = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tcCommonImg = new System.Windows.Forms.TabControl();
            this.tpCommonImg = new System.Windows.Forms.TabPage();
            this.lbPhotoSize = new System.Windows.Forms.Label();
            this.tpDynamicImg = new System.Windows.Forms.TabPage();
            this.lbDynPhotoSize = new System.Windows.Forms.Label();
            this.picDynPhoto = new System.Windows.Forms.PictureBox();
            this.btnFPReader = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).BeginInit();
            this.tcCommonImg.SuspendLayout();
            this.tpCommonImg.SuspendLayout();
            this.tpDynamicImg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDynPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(551, 311);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(471, 311);
            this.btnOk.TabIndex = 28;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 19;
            this.label1.Tag = "EmpNo";
            this.label1.Text = "label1";
            // 
            // txtEmpNo
            // 
            this.txtEmpNo.Location = new System.Drawing.Point(100, 10);
            this.txtEmpNo.MaxLength = 20;
            this.txtEmpNo.Name = "txtEmpNo";
            this.txtEmpNo.Size = new System.Drawing.Size(120, 21);
            this.txtEmpNo.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 21;
            this.label2.Tag = "EmpName";
            this.label2.Text = "label2";
            // 
            // txtEmpName
            // 
            this.txtEmpName.Location = new System.Drawing.Point(330, 10);
            this.txtEmpName.MaxLength = 50;
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(120, 21);
            this.txtEmpName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 23;
            this.label3.Tag = "EmpSexName";
            this.label3.Text = "label3";
            // 
            // cbbEmpSex
            // 
            this.cbbEmpSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbEmpSex.FormattingEnabled = true;
            this.cbbEmpSex.Location = new System.Drawing.Point(100, 40);
            this.cbbEmpSex.Name = "cbbEmpSex";
            this.cbbEmpSex.Size = new System.Drawing.Size(120, 20);
            this.cbbEmpSex.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 25;
            this.label4.Tag = "Depart";
            this.label4.Text = "label4";
            // 
            // txtDepartName
            // 
            this.txtDepartName.Location = new System.Drawing.Point(100, 70);
            this.txtDepartName.Name = "txtDepartName";
            this.txtDepartName.ReadOnly = true;
            this.txtDepartName.Size = new System.Drawing.Size(350, 21);
            this.txtDepartName.TabIndex = 5;
            // 
            // btnSelectDepart
            // 
            this.btnSelectDepart.Location = new System.Drawing.Point(415, 71);
            this.btnSelectDepart.Name = "btnSelectDepart";
            this.btnSelectDepart.Size = new System.Drawing.Size(34, 19);
            this.btnSelectDepart.TabIndex = 6;
            this.btnSelectDepart.Text = "...";
            this.btnSelectDepart.UseVisualStyleBackColor = true;
            this.btnSelectDepart.Click += new System.EventHandler(this.btnSelectDepart_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(240, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 28;
            this.label5.Tag = "EmpHireDate";
            this.label5.Text = "label5";
            // 
            // txtEmpHireDate
            // 
            this.txtEmpHireDate.Location = new System.Drawing.Point(330, 40);
            this.txtEmpHireDate.Name = "txtEmpHireDate";
            this.txtEmpHireDate.Size = new System.Drawing.Size(120, 21);
            this.txtEmpHireDate.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(240, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 30;
            this.label6.Tag = "EmpCertNo";
            this.label6.Text = "label6";
            // 
            // txtEmpCertNo
            // 
            this.txtEmpCertNo.Location = new System.Drawing.Point(330, 97);
            this.txtEmpCertNo.MaxLength = 50;
            this.txtEmpCertNo.Name = "txtEmpCertNo";
            this.txtEmpCertNo.Size = new System.Drawing.Size(120, 21);
            this.txtEmpCertNo.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 224);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 32;
            this.label7.Tag = "EmpAddress";
            this.label7.Text = "label7";
            // 
            // txtEmpAddress
            // 
            this.txtEmpAddress.Location = new System.Drawing.Point(100, 220);
            this.txtEmpAddress.MaxLength = 200;
            this.txtEmpAddress.Name = "txtEmpAddress";
            this.txtEmpAddress.Size = new System.Drawing.Size(350, 21);
            this.txtEmpAddress.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 254);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 34;
            this.label8.Tag = "EmpZipNo";
            this.label8.Text = "label8";
            // 
            // txtEmpZipNo
            // 
            this.txtEmpZipNo.Location = new System.Drawing.Point(100, 250);
            this.txtEmpZipNo.MaxLength = 20;
            this.txtEmpZipNo.Name = "txtEmpZipNo";
            this.txtEmpZipNo.Size = new System.Drawing.Size(120, 21);
            this.txtEmpZipNo.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(240, 194);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 36;
            this.label9.Tag = "FingerPrivilege";
            this.label9.Text = "label9";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(240, 254);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 38;
            this.label10.Tag = "EmpEmail";
            this.label10.Text = "label10";
            // 
            // txtEmpEmail
            // 
            this.txtEmpEmail.Location = new System.Drawing.Point(330, 250);
            this.txtEmpEmail.MaxLength = 50;
            this.txtEmpEmail.Name = "txtEmpEmail";
            this.txtEmpEmail.Size = new System.Drawing.Size(120, 21);
            this.txtEmpEmail.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 12);
            this.label11.TabIndex = 40;
            this.label11.Tag = "CardTypeName";
            this.label11.Text = "label11";
            // 
            // cbbCardType
            // 
            this.cbbCardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCardType.FormattingEnabled = true;
            this.cbbCardType.Location = new System.Drawing.Point(100, 100);
            this.cbbCardType.Name = "cbbCardType";
            this.cbbCardType.Size = new System.Drawing.Size(120, 20);
            this.cbbCardType.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(240, 134);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 12);
            this.label12.TabIndex = 42;
            this.label12.Tag = "CardSectorNo";
            this.label12.Text = "label12";
            // 
            // txtCardSectorNo
            // 
            this.txtCardSectorNo.Location = new System.Drawing.Point(330, 130);
            this.txtCardSectorNo.MaxLength = 10;
            this.txtCardSectorNo.Name = "txtCardSectorNo";
            this.txtCardSectorNo.Size = new System.Drawing.Size(120, 21);
            this.txtCardSectorNo.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 164);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 12);
            this.label13.TabIndex = 44;
            this.label13.Tag = "CardStartDate";
            this.label13.Text = "label13";
            // 
            // txtCardStartDate
            // 
            this.txtCardStartDate.Location = new System.Drawing.Point(100, 160);
            this.txtCardStartDate.Name = "txtCardStartDate";
            this.txtCardStartDate.Size = new System.Drawing.Size(120, 21);
            this.txtCardStartDate.TabIndex = 12;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(240, 164);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 12);
            this.label14.TabIndex = 46;
            this.label14.Tag = "CardEndDate";
            this.label14.Text = "label14";
            // 
            // txtCardEndDate
            // 
            this.txtCardEndDate.Location = new System.Drawing.Point(330, 160);
            this.txtCardEndDate.Name = "txtCardEndDate";
            this.txtCardEndDate.Size = new System.Drawing.Size(120, 21);
            this.txtCardEndDate.TabIndex = 14;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 194);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 12);
            this.label15.TabIndex = 48;
            this.label15.Tag = "CardFingerNo";
            this.label15.Text = "label15";
            // 
            // txtCardFingerNo
            // 
            this.txtCardFingerNo.Location = new System.Drawing.Point(100, 190);
            this.txtCardFingerNo.MaxLength = 10;
            this.txtCardFingerNo.Name = "txtCardFingerNo";
            this.txtCardFingerNo.Size = new System.Drawing.Size(120, 21);
            this.txtCardFingerNo.TabIndex = 16;
            // 
            // picPhoto
            // 
            this.picPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picPhoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picPhoto.Location = new System.Drawing.Point(6, 6);
            this.picPhoto.Name = "picPhoto";
            this.picPhoto.Size = new System.Drawing.Size(147, 196);
            this.picPhoto.TabIndex = 50;
            this.picPhoto.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(460, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 25);
            this.button1.TabIndex = 24;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(530, 265);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(70, 25);
            this.button2.TabIndex = 25;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // chkIsAdd
            // 
            this.chkIsAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkIsAdd.AutoSize = true;
            this.chkIsAdd.Checked = true;
            this.chkIsAdd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsAdd.Location = new System.Drawing.Point(10, 315);
            this.chkIsAdd.Name = "chkIsAdd";
            this.chkIsAdd.Size = new System.Drawing.Size(78, 16);
            this.chkIsAdd.TabIndex = 26;
            this.chkIsAdd.Text = "checkBox1";
            this.chkIsAdd.UseVisualStyleBackColor = true;
            // 
            // txtCardPWD
            // 
            this.txtCardPWD.Location = new System.Drawing.Point(100, 130);
            this.txtCardPWD.MaxLength = 6;
            this.txtCardPWD.Name = "txtCardPWD";
            this.txtCardPWD.PasswordChar = '*';
            this.txtCardPWD.Size = new System.Drawing.Size(119, 21);
            this.txtCardPWD.TabIndex = 10;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 134);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 12);
            this.label16.TabIndex = 52;
            this.label16.Tag = "CardPWD";
            this.label16.Text = "label16";
            // 
            // dlgOpen
            // 
            this.dlgOpen.Filter = "JPEG|*.jpg|Bitmaps|*.bmp|JIF|*.jif|ICO|*.ico";
            // 
            // btnSelectEmpHireDate
            // 
            this.btnSelectEmpHireDate.Location = new System.Drawing.Point(415, 41);
            this.btnSelectEmpHireDate.Name = "btnSelectEmpHireDate";
            this.btnSelectEmpHireDate.Size = new System.Drawing.Size(34, 19);
            this.btnSelectEmpHireDate.TabIndex = 4;
            this.btnSelectEmpHireDate.Text = "...";
            this.btnSelectEmpHireDate.UseVisualStyleBackColor = true;
            this.btnSelectEmpHireDate.Click += new System.EventHandler(this.btnSelectEmpHireDate_Click);
            // 
            // btnSelectCardStartDate
            // 
            this.btnSelectCardStartDate.Location = new System.Drawing.Point(185, 161);
            this.btnSelectCardStartDate.Name = "btnSelectCardStartDate";
            this.btnSelectCardStartDate.Size = new System.Drawing.Size(34, 19);
            this.btnSelectCardStartDate.TabIndex = 13;
            this.btnSelectCardStartDate.Text = "...";
            this.btnSelectCardStartDate.UseVisualStyleBackColor = true;
            this.btnSelectCardStartDate.Click += new System.EventHandler(this.btnSelectCardStartDate_Click);
            // 
            // btnSelectCardEndDate
            // 
            this.btnSelectCardEndDate.Location = new System.Drawing.Point(415, 161);
            this.btnSelectCardEndDate.Name = "btnSelectCardEndDate";
            this.btnSelectCardEndDate.Size = new System.Drawing.Size(34, 19);
            this.btnSelectCardEndDate.TabIndex = 15;
            this.btnSelectCardEndDate.Text = "...";
            this.btnSelectCardEndDate.UseVisualStyleBackColor = true;
            this.btnSelectCardEndDate.Click += new System.EventHandler(this.btnSelectCardEndDate_Click);
            // 
            // chkIsAttend
            // 
            this.chkIsAttend.AutoSize = true;
            this.chkIsAttend.Checked = true;
            this.chkIsAttend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsAttend.Location = new System.Drawing.Point(464, 292);
            this.chkIsAttend.Name = "chkIsAttend";
            this.chkIsAttend.Size = new System.Drawing.Size(78, 16);
            this.chkIsAttend.TabIndex = 23;
            this.chkIsAttend.Tag = "IsAttend";
            this.chkIsAttend.Text = "checkBox1";
            this.chkIsAttend.UseVisualStyleBackColor = true;
            // 
            // txtEmpPhoneNo
            // 
            this.txtEmpPhoneNo.Location = new System.Drawing.Point(100, 280);
            this.txtEmpPhoneNo.MaxLength = 50;
            this.txtEmpPhoneNo.Name = "txtEmpPhoneNo";
            this.txtEmpPhoneNo.Size = new System.Drawing.Size(120, 21);
            this.txtEmpPhoneNo.TabIndex = 21;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(10, 284);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 12);
            this.label17.TabIndex = 55;
            this.label17.Tag = "EmpPhoneNo";
            this.label17.Text = "label17";
            // 
            // label18
            // 
            this.label18.ForeColor = System.Drawing.Color.Blue;
            this.label18.Location = new System.Drawing.Point(463, 2);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(145, 25);
            this.label18.TabIndex = 56;
            this.label18.Text = "label18";
            // 
            // cbbFingerPrivilege
            // 
            this.cbbFingerPrivilege.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFingerPrivilege.FormattingEnabled = true;
            this.cbbFingerPrivilege.Location = new System.Drawing.Point(330, 190);
            this.cbbFingerPrivilege.Name = "cbbFingerPrivilege";
            this.cbbFingerPrivilege.Size = new System.Drawing.Size(120, 20);
            this.cbbFingerPrivilege.TabIndex = 17;
            // 
            // txtOtherCardNo
            // 
            this.txtOtherCardNo.Location = new System.Drawing.Point(330, 280);
            this.txtOtherCardNo.MaxLength = 10;
            this.txtOtherCardNo.Name = "txtOtherCardNo";
            this.txtOtherCardNo.Size = new System.Drawing.Size(120, 21);
            this.txtOtherCardNo.TabIndex = 22;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(240, 284);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 12);
            this.label19.TabIndex = 58;
            this.label19.Tag = "OtherCardNo";
            this.label19.Text = "label19";
            // 
            // btnIDCard
            // 
            this.btnIDCard.Location = new System.Drawing.Point(248, 311);
            this.btnIDCard.Name = "btnIDCard";
            this.btnIDCard.Size = new System.Drawing.Size(110, 25);
            this.btnIDCard.TabIndex = 27;
            this.btnIDCard.Text = "button3";
            this.btnIDCard.UseVisualStyleBackColor = true;
            this.btnIDCard.Click += new System.EventHandler(this.btnIDCard_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(205, 133);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 59;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            this.checkBox1.MouseEnter += new System.EventHandler(this.checkBox1_MouseEnter);
            this.checkBox1.MouseLeave += new System.EventHandler(this.checkBox1_MouseLeave);
            this.checkBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.checkBox1_MouseMove);
            // 
            // tcCommonImg
            // 
            this.tcCommonImg.Controls.Add(this.tpCommonImg);
            this.tcCommonImg.Controls.Add(this.tpDynamicImg);
            this.tcCommonImg.Location = new System.Drawing.Point(460, 30);
            this.tcCommonImg.Name = "tcCommonImg";
            this.tcCommonImg.SelectedIndex = 0;
            this.tcCommonImg.Size = new System.Drawing.Size(167, 235);
            this.tcCommonImg.TabIndex = 60;
            // 
            // tpCommonImg
            // 
            this.tpCommonImg.Controls.Add(this.lbPhotoSize);
            this.tpCommonImg.Controls.Add(this.picPhoto);
            this.tpCommonImg.Location = new System.Drawing.Point(4, 22);
            this.tpCommonImg.Name = "tpCommonImg";
            this.tpCommonImg.Padding = new System.Windows.Forms.Padding(3);
            this.tpCommonImg.Size = new System.Drawing.Size(159, 209);
            this.tpCommonImg.TabIndex = 0;
            this.tpCommonImg.Text = "tabPage1";
            this.tpCommonImg.UseVisualStyleBackColor = true;
            // 
            // lbPhotoSize
            // 
            this.lbPhotoSize.AutoSize = true;
            this.lbPhotoSize.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbPhotoSize.Location = new System.Drawing.Point(11, 185);
            this.lbPhotoSize.Name = "lbPhotoSize";
            this.lbPhotoSize.Size = new System.Drawing.Size(47, 12);
            this.lbPhotoSize.TabIndex = 51;
            this.lbPhotoSize.Text = "label20";
            // 
            // tpDynamicImg
            // 
            this.tpDynamicImg.Controls.Add(this.lbDynPhotoSize);
            this.tpDynamicImg.Controls.Add(this.picDynPhoto);
            this.tpDynamicImg.Location = new System.Drawing.Point(4, 22);
            this.tpDynamicImg.Name = "tpDynamicImg";
            this.tpDynamicImg.Padding = new System.Windows.Forms.Padding(3);
            this.tpDynamicImg.Size = new System.Drawing.Size(159, 209);
            this.tpDynamicImg.TabIndex = 1;
            this.tpDynamicImg.Text = "tabPage2";
            this.tpDynamicImg.UseVisualStyleBackColor = true;
            // 
            // lbDynPhotoSize
            // 
            this.lbDynPhotoSize.AutoSize = true;
            this.lbDynPhotoSize.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbDynPhotoSize.Location = new System.Drawing.Point(11, 185);
            this.lbDynPhotoSize.Name = "lbDynPhotoSize";
            this.lbDynPhotoSize.Size = new System.Drawing.Size(47, 12);
            this.lbDynPhotoSize.TabIndex = 52;
            this.lbDynPhotoSize.Text = "label20";
            // 
            // picDynPhoto
            // 
            this.picDynPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picDynPhoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picDynPhoto.Location = new System.Drawing.Point(6, 6);
            this.picDynPhoto.Name = "picDynPhoto";
            this.picDynPhoto.Size = new System.Drawing.Size(147, 196);
            this.picDynPhoto.TabIndex = 51;
            this.picDynPhoto.TabStop = false;
            // 
            // btnFPReader
            // 
            this.btnFPReader.Location = new System.Drawing.Point(364, 312);
            this.btnFPReader.Name = "btnFPReader";
            this.btnFPReader.Size = new System.Drawing.Size(101, 23);
            this.btnFPReader.TabIndex = 61;
            this.btnFPReader.Text = "button3";
            this.btnFPReader.UseVisualStyleBackColor = true;
            this.btnFPReader.Click += new System.EventHandler(this.btnFPReader_Click);
            // 
            // frmRSEmpAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(635, 343);
            this.Controls.Add(this.btnFPReader);
            this.Controls.Add(this.tcCommonImg);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnIDCard);
            this.Controls.Add(this.txtOtherCardNo);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.cbbFingerPrivilege);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtEmpPhoneNo);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.chkIsAttend);
            this.Controls.Add(this.btnSelectCardEndDate);
            this.Controls.Add(this.btnSelectCardStartDate);
            this.Controls.Add(this.btnSelectEmpHireDate);
            this.Controls.Add(this.txtCardPWD);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.chkIsAdd);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtCardFingerNo);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtCardEndDate);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtCardStartDate);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtCardSectorNo);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cbbCardType);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtEmpEmail);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtEmpZipNo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtEmpAddress);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtEmpCertNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEmpHireDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSelectDepart);
            this.Controls.Add(this.txtDepartName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbbEmpSex);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEmpNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEmpName);
            this.Controls.Add(this.label2);
            this.Name = "frmRSEmpAdd";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRSEmpAdd_KeyDown);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtEmpName, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtEmpNo, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cbbEmpSex, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtDepartName, 0);
            this.Controls.SetChildIndex(this.btnSelectDepart, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.txtEmpHireDate, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtEmpCertNo, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtEmpAddress, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtEmpZipNo, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.txtEmpEmail, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.cbbCardType, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.txtCardSectorNo, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.txtCardStartDate, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.txtCardEndDate, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.txtCardFingerNo, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.chkIsAdd, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.txtCardPWD, 0);
            this.Controls.SetChildIndex(this.btnSelectEmpHireDate, 0);
            this.Controls.SetChildIndex(this.btnSelectCardStartDate, 0);
            this.Controls.SetChildIndex(this.btnSelectCardEndDate, 0);
            this.Controls.SetChildIndex(this.chkIsAttend, 0);
            this.Controls.SetChildIndex(this.label17, 0);
            this.Controls.SetChildIndex(this.txtEmpPhoneNo, 0);
            this.Controls.SetChildIndex(this.label18, 0);
            this.Controls.SetChildIndex(this.cbbFingerPrivilege, 0);
            this.Controls.SetChildIndex(this.label19, 0);
            this.Controls.SetChildIndex(this.txtOtherCardNo, 0);
            this.Controls.SetChildIndex(this.btnIDCard, 0);
            this.Controls.SetChildIndex(this.checkBox1, 0);
            this.Controls.SetChildIndex(this.tcCommonImg, 0);
            this.Controls.SetChildIndex(this.btnFPReader, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).EndInit();
            this.tcCommonImg.ResumeLayout(false);
            this.tpCommonImg.ResumeLayout(false);
            this.tpCommonImg.PerformLayout();
            this.tpDynamicImg.ResumeLayout(false);
            this.tpDynamicImg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDynPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtEmpNo;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtEmpName;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ComboBox cbbEmpSex;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtDepartName;
    private System.Windows.Forms.Button btnSelectDepart;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtEmpHireDate;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txtEmpCertNo;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox txtEmpAddress;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox txtEmpZipNo;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.TextBox txtEmpEmail;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.ComboBox cbbCardType;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.TextBox txtCardSectorNo;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.TextBox txtCardStartDate;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.TextBox txtCardEndDate;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.TextBox txtCardFingerNo;
    private System.Windows.Forms.PictureBox picPhoto;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.CheckBox chkIsAdd;
    private System.Windows.Forms.TextBox txtCardPWD;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.OpenFileDialog dlgOpen;
    private System.Windows.Forms.Button btnSelectEmpHireDate;
    private System.Windows.Forms.Button btnSelectCardStartDate;
    private System.Windows.Forms.Button btnSelectCardEndDate;
    private System.Windows.Forms.CheckBox chkIsAttend;
    private System.Windows.Forms.TextBox txtEmpPhoneNo;
    private System.Windows.Forms.Label label17;
    private System.Windows.Forms.Label label18;
    private System.Windows.Forms.ComboBox cbbFingerPrivilege;
    private System.Windows.Forms.TextBox txtOtherCardNo;
    private System.Windows.Forms.Label label19;
    private System.Windows.Forms.Button btnIDCard;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TabControl tcCommonImg;
        private System.Windows.Forms.TabPage tpCommonImg;
        private System.Windows.Forms.Label lbPhotoSize;
        private System.Windows.Forms.TabPage tpDynamicImg;
        private System.Windows.Forms.Label lbDynPhotoSize;
        private System.Windows.Forms.PictureBox picDynPhoto;
        private System.Windows.Forms.Button btnFPReader;
    }
}
