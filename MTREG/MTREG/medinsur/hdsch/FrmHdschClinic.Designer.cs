namespace MTREG.medinsur.hdsch
{
    partial class FrmHdschClinic
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
            this.lblSuccess = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbPatientType = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblClinicDisease = new System.Windows.Forms.Label();
            this.tbxClinicDisease = new System.Windows.Forms.TextBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.cmbApproDisease = new System.Windows.Forms.ComboBox();
            this.cmbApproType = new System.Windows.Forms.ComboBox();
            this.cmbMediType = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpBirth = new System.Windows.Forms.DateTimePicker();
            this.tbxIDCard = new System.Windows.Forms.TextBox();
            this.tbxCompanyNum = new System.Windows.Forms.TextBox();
            this.tbxCompanyName = new System.Windows.Forms.TextBox();
            this.tbxIsBlock = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxSex = new System.Windows.Forms.TextBox();
            this.tbxPersonalNum = new System.Windows.Forms.TextBox();
            this.tbxICCardID = new System.Windows.Forms.TextBox();
            this.tbxBalance = new System.Windows.Forms.TextBox();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvClinicDiagn = new System.Windows.Forms.DataGridView();
            this.label17 = new System.Windows.Forms.Label();
            this.tbxPersonNum = new System.Windows.Forms.TextBox();
            this.btnExtract = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClinicDiagn)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSuccess
            // 
            this.lblSuccess.AutoSize = true;
            this.lblSuccess.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSuccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblSuccess.Location = new System.Drawing.Point(418, 18);
            this.lblSuccess.Name = "lblSuccess";
            this.lblSuccess.Size = new System.Drawing.Size(146, 20);
            this.lblSuccess.TabIndex = 53;
            this.lblSuccess.Text = "读卡是否成功!";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(25, 54);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 19);
            this.label14.TabIndex = 52;
            this.label14.Text = "患者类型：";
            // 
            // cmbPatientType
            // 
            this.cmbPatientType.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbPatientType.FormattingEnabled = true;
            this.cmbPatientType.Location = new System.Drawing.Point(132, 51);
            this.cmbPatientType.Name = "cmbPatientType";
            this.cmbPatientType.Size = new System.Drawing.Size(161, 27);
            this.cmbPatientType.TabIndex = 47;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(381, 418);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(122, 41);
            this.btnClose.TabIndex = 51;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(169, 418);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(122, 41);
            this.btnOk.TabIndex = 50;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblClinicDisease);
            this.groupBox1.Controls.Add(this.tbxClinicDisease);
            this.groupBox1.Controls.Add(this.lblMsg);
            this.groupBox1.Controls.Add(this.cmbApproDisease);
            this.groupBox1.Controls.Add(this.cmbApproType);
            this.groupBox1.Controls.Add(this.cmbMediType);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpBirth);
            this.groupBox1.Controls.Add(this.tbxIDCard);
            this.groupBox1.Controls.Add(this.tbxCompanyNum);
            this.groupBox1.Controls.Add(this.tbxCompanyName);
            this.groupBox1.Controls.Add(this.tbxIsBlock);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tbxSex);
            this.groupBox1.Controls.Add(this.tbxPersonalNum);
            this.groupBox1.Controls.Add(this.tbxICCardID);
            this.groupBox1.Controls.Add(this.tbxBalance);
            this.groupBox1.Controls.Add(this.tbxName);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(29, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(589, 311);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "医保信息";
            // 
            // lblClinicDisease
            // 
            this.lblClinicDisease.AutoSize = true;
            this.lblClinicDisease.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblClinicDisease.Location = new System.Drawing.Point(10, 278);
            this.lblClinicDisease.Name = "lblClinicDisease";
            this.lblClinicDisease.Size = new System.Drawing.Size(93, 20);
            this.lblClinicDisease.TabIndex = 40;
            this.lblClinicDisease.Text = "疾病编码";
            // 
            // tbxClinicDisease
            // 
            this.tbxClinicDisease.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxClinicDisease.Location = new System.Drawing.Point(117, 240);
            this.tbxClinicDisease.Name = "tbxClinicDisease";
            this.tbxClinicDisease.Size = new System.Drawing.Size(161, 29);
            this.tbxClinicDisease.TabIndex = 39;
            this.tbxClinicDisease.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxClinicDisease_KeyDown);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblMsg.Location = new System.Drawing.Point(222, 288);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(167, 20);
            this.lblMsg.TabIndex = 38;
            this.lblMsg.Text = "请选择审批病种!";
            // 
            // cmbApproDisease
            // 
            this.cmbApproDisease.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbApproDisease.FormattingEnabled = true;
            this.cmbApproDisease.Location = new System.Drawing.Point(407, 240);
            this.cmbApproDisease.Name = "cmbApproDisease";
            this.cmbApproDisease.Size = new System.Drawing.Size(161, 27);
            this.cmbApproDisease.TabIndex = 35;
            this.cmbApproDisease.SelectedValueChanged += new System.EventHandler(this.cmbApproDisease_SelectedValueChanged);
            // 
            // cmbApproType
            // 
            this.cmbApproType.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbApproType.FormattingEnabled = true;
            this.cmbApproType.Location = new System.Drawing.Point(407, 205);
            this.cmbApproType.Name = "cmbApproType";
            this.cmbApproType.Size = new System.Drawing.Size(161, 27);
            this.cmbApproType.TabIndex = 34;
            this.cmbApproType.SelectedValueChanged += new System.EventHandler(this.cmbApproType_SelectedValueChanged);
            // 
            // cmbMediType
            // 
            this.cmbMediType.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbMediType.FormattingEnabled = true;
            this.cmbMediType.Location = new System.Drawing.Point(117, 205);
            this.cmbMediType.Name = "cmbMediType";
            this.cmbMediType.Size = new System.Drawing.Size(161, 27);
            this.cmbMediType.TabIndex = 32;
            this.cmbMediType.SelectedValueChanged += new System.EventHandler(this.cmbMediType_SelectedValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(304, 246);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(104, 19);
            this.label15.TabIndex = 31;
            this.label15.Text = "审批病种：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(15, 246);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(104, 19);
            this.label16.TabIndex = 30;
            this.label16.Text = "门诊疾病：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(304, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 19);
            this.label2.TabIndex = 27;
            this.label2.Text = "审批类别：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(15, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 19);
            this.label1.TabIndex = 26;
            this.label1.Text = "医疗类别：";
            // 
            // dtpBirth
            // 
            this.dtpBirth.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpBirth.Location = new System.Drawing.Point(407, 24);
            this.dtpBirth.Name = "dtpBirth";
            this.dtpBirth.Size = new System.Drawing.Size(161, 29);
            this.dtpBirth.TabIndex = 4;
            // 
            // tbxIDCard
            // 
            this.tbxIDCard.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxIDCard.Location = new System.Drawing.Point(407, 59);
            this.tbxIDCard.Name = "tbxIDCard";
            this.tbxIDCard.Size = new System.Drawing.Size(161, 29);
            this.tbxIDCard.TabIndex = 6;
            // 
            // tbxCompanyNum
            // 
            this.tbxCompanyNum.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxCompanyNum.Location = new System.Drawing.Point(407, 98);
            this.tbxCompanyNum.Name = "tbxCompanyNum";
            this.tbxCompanyNum.Size = new System.Drawing.Size(161, 29);
            this.tbxCompanyNum.TabIndex = 8;
            // 
            // tbxCompanyName
            // 
            this.tbxCompanyName.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxCompanyName.Location = new System.Drawing.Point(407, 133);
            this.tbxCompanyName.Name = "tbxCompanyName";
            this.tbxCompanyName.Size = new System.Drawing.Size(161, 29);
            this.tbxCompanyName.TabIndex = 10;
            // 
            // tbxIsBlock
            // 
            this.tbxIsBlock.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxIsBlock.Location = new System.Drawing.Point(407, 168);
            this.tbxIsBlock.Name = "tbxIsBlock";
            this.tbxIsBlock.Size = new System.Drawing.Size(161, 29);
            this.tbxIsBlock.TabIndex = 12;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(304, 171);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 19);
            this.label13.TabIndex = 25;
            this.label13.Text = "封锁情况：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(304, 136);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 19);
            this.label12.TabIndex = 24;
            this.label12.Text = "单位名称：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(304, 98);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 19);
            this.label11.TabIndex = 23;
            this.label11.Text = "单位编号：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(304, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 19);
            this.label10.TabIndex = 22;
            this.label10.Text = "身份证号：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(304, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 19);
            this.label9.TabIndex = 21;
            this.label9.Text = "出生年月：";
            // 
            // tbxSex
            // 
            this.tbxSex.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxSex.Location = new System.Drawing.Point(117, 60);
            this.tbxSex.Name = "tbxSex";
            this.tbxSex.Size = new System.Drawing.Size(161, 29);
            this.tbxSex.TabIndex = 5;
            // 
            // tbxPersonalNum
            // 
            this.tbxPersonalNum.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxPersonalNum.Location = new System.Drawing.Point(117, 95);
            this.tbxPersonalNum.Name = "tbxPersonalNum";
            this.tbxPersonalNum.Size = new System.Drawing.Size(161, 29);
            this.tbxPersonalNum.TabIndex = 7;
            // 
            // tbxICCardID
            // 
            this.tbxICCardID.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxICCardID.Location = new System.Drawing.Point(117, 131);
            this.tbxICCardID.Name = "tbxICCardID";
            this.tbxICCardID.Size = new System.Drawing.Size(161, 29);
            this.tbxICCardID.TabIndex = 9;
            // 
            // tbxBalance
            // 
            this.tbxBalance.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxBalance.Location = new System.Drawing.Point(117, 167);
            this.tbxBalance.Name = "tbxBalance";
            this.tbxBalance.Size = new System.Drawing.Size(161, 29);
            this.tbxBalance.TabIndex = 11;
            // 
            // tbxName
            // 
            this.tbxName.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxName.Location = new System.Drawing.Point(117, 24);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(161, 29);
            this.tbxName.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(15, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 19);
            this.label8.TabIndex = 14;
            this.label8.Text = "账户余额：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(15, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 19);
            this.label7.TabIndex = 13;
            this.label7.Text = "IC 卡 号：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(15, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "性    别：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(15, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 19);
            this.label4.TabIndex = 11;
            this.label4.Text = "个人编号：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(15, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "姓    名：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(246, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 48;
            this.label5.Text = "门诊城合";
            // 
            // dgvClinicDiagn
            // 
            this.dgvClinicDiagn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClinicDiagn.ColumnHeadersVisible = false;
            this.dgvClinicDiagn.Location = new System.Drawing.Point(146, 369);
            this.dgvClinicDiagn.Name = "dgvClinicDiagn";
            this.dgvClinicDiagn.RowHeadersVisible = false;
            this.dgvClinicDiagn.RowTemplate.Height = 23;
            this.dgvClinicDiagn.Size = new System.Drawing.Size(161, 109);
            this.dgvClinicDiagn.TabIndex = 54;
            this.dgvClinicDiagn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvClinicDiagn_KeyDown);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(301, 56);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(100, 19);
            this.label17.TabIndex = 11;
            this.label17.Text = "个人编号:";
            // 
            // tbxPersonNum
            // 
            this.tbxPersonNum.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxPersonNum.Location = new System.Drawing.Point(395, 51);
            this.tbxPersonNum.Name = "tbxPersonNum";
            this.tbxPersonNum.Size = new System.Drawing.Size(161, 29);
            this.tbxPersonNum.TabIndex = 7;
            // 
            // btnExtract
            // 
            this.btnExtract.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold);
            this.btnExtract.Location = new System.Drawing.Point(562, 50);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(77, 28);
            this.btnExtract.TabIndex = 55;
            this.btnExtract.Text = "提取";
            this.btnExtract.UseVisualStyleBackColor = true;
            this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
            // 
            // FrmHdschClinic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 481);
            this.Controls.Add(this.btnExtract);
            this.Controls.Add(this.lblSuccess);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmbPatientType);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvClinicDiagn);
            this.Controls.Add(this.tbxPersonNum);
            this.Controls.Add(this.label17);
            this.Name = "FrmHdschClinic";
            this.Text = "门诊城合";
            this.Load += new System.EventHandler(this.FrmHdschClinic_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClinicDiagn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSuccess;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbPatientType;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblClinicDisease;
        private System.Windows.Forms.TextBox tbxClinicDisease;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.ComboBox cmbApproDisease;
        private System.Windows.Forms.ComboBox cmbApproType;
        private System.Windows.Forms.ComboBox cmbMediType;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpBirth;
        private System.Windows.Forms.TextBox tbxIDCard;
        private System.Windows.Forms.TextBox tbxCompanyNum;
        private System.Windows.Forms.TextBox tbxCompanyName;
        private System.Windows.Forms.TextBox tbxIsBlock;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbxSex;
        private System.Windows.Forms.TextBox tbxPersonalNum;
        private System.Windows.Forms.TextBox tbxICCardID;
        private System.Windows.Forms.TextBox tbxBalance;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvClinicDiagn;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbxPersonNum;
        private System.Windows.Forms.Button btnExtract;
    }
}