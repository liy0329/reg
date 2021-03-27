namespace MTREG.medinsur.ynsyb.clinic
{
    partial class FrmClinMedinsrYNSYB
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPatientType = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGetInfo = new System.Windows.Forms.Button();
            this.cmbHasCard = new System.Windows.Forms.ComboBox();
            this.cmbHadGrbh = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMediType = new System.Windows.Forms.ComboBox();
            this.tbxCode = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbApproType = new System.Windows.Forms.ComboBox();
            this.dgvApproInfo = new System.Windows.Forms.DataGridView();
            this.col1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bre_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbxDiseaseName = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbxDiseaseCode = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbxApItemName = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tbxApproNum = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tbxApItemCode = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApproInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSuccess
            // 
            this.lblSuccess.AutoSize = true;
            this.lblSuccess.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSuccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblSuccess.Location = new System.Drawing.Point(403, 25);
            this.lblSuccess.Name = "lblSuccess";
            this.lblSuccess.Size = new System.Drawing.Size(146, 20);
            this.lblSuccess.TabIndex = 59;
            this.lblSuccess.Text = "读卡是否成功!";
            // 
            // groupBox1
            // 
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
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(13, 170);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(589, 209);
            this.groupBox1.TabIndex = 58;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "医保信息";
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
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(15, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(106, 19);
            this.label14.TabIndex = 10;
            this.label14.Text = "姓    名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(23, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 19);
            this.label3.TabIndex = 57;
            this.label3.Text = "患者类型：";
            // 
            // cmbPatientType
            // 
            this.cmbPatientType.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbPatientType.FormattingEnabled = true;
            this.cmbPatientType.Location = new System.Drawing.Point(130, 56);
            this.cmbPatientType.Name = "cmbPatientType";
            this.cmbPatientType.Size = new System.Drawing.Size(161, 27);
            this.cmbPatientType.TabIndex = 56;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(343, 507);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(122, 41);
            this.btnClose.TabIndex = 55;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(131, 507);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(122, 41);
            this.btnOk.TabIndex = 54;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(222, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 20);
            this.label5.TabIndex = 53;
            this.label5.Text = "云南省门诊医保";
            // 
            // btnGetInfo
            // 
            this.btnGetInfo.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGetInfo.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGetInfo.Location = new System.Drawing.Point(498, 136);
            this.btnGetInfo.Name = "btnGetInfo";
            this.btnGetInfo.Size = new System.Drawing.Size(98, 41);
            this.btnGetInfo.TabIndex = 60;
            this.btnGetInfo.Text = "提取信息";
            this.btnGetInfo.UseVisualStyleBackColor = true;
            this.btnGetInfo.Click += new System.EventHandler(this.btnGetInfo_Click);
            // 
            // cmbHasCard
            // 
            this.cmbHasCard.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbHasCard.FormattingEnabled = true;
            this.cmbHasCard.Location = new System.Drawing.Point(304, 56);
            this.cmbHasCard.Name = "cmbHasCard";
            this.cmbHasCard.Size = new System.Drawing.Size(74, 27);
            this.cmbHasCard.TabIndex = 61;
            this.cmbHasCard.SelectionChangeCommitted += new System.EventHandler(this.cmbHasCard_SelectionChangeCommitted);
            // 
            // cmbHadGrbh
            // 
            this.cmbHadGrbh.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbHadGrbh.FormattingEnabled = true;
            this.cmbHadGrbh.Location = new System.Drawing.Point(391, 56);
            this.cmbHadGrbh.Name = "cmbHadGrbh";
            this.cmbHadGrbh.Size = new System.Drawing.Size(161, 27);
            this.cmbHadGrbh.TabIndex = 62;
            this.cmbHadGrbh.SelectionChangeCommitted += new System.EventHandler(this.cmbHadGrbh_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(24, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 19);
            this.label2.TabIndex = 64;
            this.label2.Text = "医疗类别：";
            // 
            // cmbMediType
            // 
            this.cmbMediType.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbMediType.FormattingEnabled = true;
            this.cmbMediType.Location = new System.Drawing.Point(131, 108);
            this.cmbMediType.Name = "cmbMediType";
            this.cmbMediType.Size = new System.Drawing.Size(161, 27);
            this.cmbMediType.TabIndex = 63;
            this.cmbMediType.SelectionChangeCommitted += new System.EventHandler(this.cmbMediType_SelectionChangeCommitted);
            // 
            // tbxCode
            // 
            this.tbxCode.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxCode.Location = new System.Drawing.Point(391, 101);
            this.tbxCode.Name = "tbxCode";
            this.tbxCode.Size = new System.Drawing.Size(161, 29);
            this.tbxCode.TabIndex = 65;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCode.Location = new System.Drawing.Point(298, 108);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(104, 19);
            this.lblCode.TabIndex = 66;
            this.lblCode.Text = "医保卡号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(29, 389);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 19);
            this.label1.TabIndex = 67;
            this.label1.Text = "审批类别：";
            // 
            // cmbApproType
            // 
            this.cmbApproType.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbApproType.FormattingEnabled = true;
            this.cmbApproType.Location = new System.Drawing.Point(130, 385);
            this.cmbApproType.Name = "cmbApproType";
            this.cmbApproType.Size = new System.Drawing.Size(161, 27);
            this.cmbApproType.TabIndex = 68;
            this.cmbApproType.SelectionChangeCommitted += new System.EventHandler(this.cmbApproType_SelectionChangeCommitted);
            // 
            // dgvApproInfo
            // 
            this.dgvApproInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApproInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col1,
            this.code,
            this.name,
            this.bre_code});
            this.dgvApproInfo.Location = new System.Drawing.Point(298, 482);
            this.dgvApproInfo.Name = "dgvApproInfo";
            this.dgvApproInfo.RowHeadersVisible = false;
            this.dgvApproInfo.RowTemplate.Height = 23;
            this.dgvApproInfo.Size = new System.Drawing.Size(342, 109);
            this.dgvApproInfo.TabIndex = 69;
            this.dgvApproInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApproInfo_CellClick);
            this.dgvApproInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvApproInfo_KeyDown);
            // 
            // col1
            // 
            this.col1.HeaderText = "";
            this.col1.Name = "col1";
            this.col1.Width = 30;
            // 
            // code
            // 
            this.code.HeaderText = "编码";
            this.code.Name = "code";
            this.code.Width = 130;
            // 
            // name
            // 
            this.name.HeaderText = "名称";
            this.name.Name = "name";
            // 
            // bre_code
            // 
            this.bre_code.HeaderText = "简码";
            this.bre_code.Name = "bre_code";
            this.bre_code.Width = 80;
            // 
            // tbxDiseaseName
            // 
            this.tbxDiseaseName.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxDiseaseName.Location = new System.Drawing.Point(420, 385);
            this.tbxDiseaseName.Name = "tbxDiseaseName";
            this.tbxDiseaseName.Size = new System.Drawing.Size(161, 29);
            this.tbxDiseaseName.TabIndex = 70;
            this.tbxDiseaseName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxDiseaseName_KeyDown);
            this.tbxDiseaseName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tbxDiseaseName_MouseDoubleClick);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(318, 389);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(104, 19);
            this.label15.TabIndex = 71;
            this.label15.Text = "疾病名称：";
            // 
            // tbxDiseaseCode
            // 
            this.tbxDiseaseCode.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxDiseaseCode.Location = new System.Drawing.Point(131, 418);
            this.tbxDiseaseCode.Name = "tbxDiseaseCode";
            this.tbxDiseaseCode.Size = new System.Drawing.Size(161, 29);
            this.tbxDiseaseCode.TabIndex = 72;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(29, 422);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(104, 19);
            this.label19.TabIndex = 73;
            this.label19.Text = "疾病编码：";
            // 
            // tbxApItemName
            // 
            this.tbxApItemName.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxApItemName.Location = new System.Drawing.Point(420, 417);
            this.tbxApItemName.Name = "tbxApItemName";
            this.tbxApItemName.ReadOnly = true;
            this.tbxApItemName.Size = new System.Drawing.Size(161, 29);
            this.tbxApItemName.TabIndex = 74;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(318, 421);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(104, 19);
            this.label20.TabIndex = 75;
            this.label20.Text = "项目编号：";
            // 
            // tbxApproNum
            // 
            this.tbxApproNum.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxApproNum.Location = new System.Drawing.Point(131, 455);
            this.tbxApproNum.Name = "tbxApproNum";
            this.tbxApproNum.ReadOnly = true;
            this.tbxApproNum.Size = new System.Drawing.Size(161, 29);
            this.tbxApproNum.TabIndex = 76;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(29, 459);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(104, 19);
            this.label21.TabIndex = 77;
            this.label21.Text = "审批编号：";
            // 
            // tbxApItemCode
            // 
            this.tbxApItemCode.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxApItemCode.Location = new System.Drawing.Point(420, 451);
            this.tbxApItemCode.Name = "tbxApItemCode";
            this.tbxApItemCode.ReadOnly = true;
            this.tbxApItemCode.Size = new System.Drawing.Size(161, 29);
            this.tbxApItemCode.TabIndex = 78;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(318, 455);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(104, 19);
            this.label22.TabIndex = 79;
            this.label22.Text = "项目名称：";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblMsg.Location = new System.Drawing.Point(516, 507);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(146, 20);
            this.lblMsg.TabIndex = 80;
            this.lblMsg.Text = "读卡是否成功!";
            // 
            // FrmClinMedinsrYNSYB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 588);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.tbxApItemCode);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.tbxApproNum);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.tbxApItemName);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.tbxDiseaseCode);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.tbxDiseaseName);
            this.Controls.Add(this.dgvApproInfo);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cmbApproType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxCode);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbMediType);
            this.Controls.Add(this.cmbHadGrbh);
            this.Controls.Add(this.cmbHasCard);
            this.Controls.Add(this.btnGetInfo);
            this.Controls.Add(this.lblSuccess);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbPatientType);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label5);
            this.Name = "FrmClinMedinsrYNSYB";
            this.Text = "云南省门诊医保";
            this.Load += new System.EventHandler(this.FrmClinMedinsrYNSYB_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApproInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSuccess;
        private System.Windows.Forms.GroupBox groupBox1;
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
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPatientType;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGetInfo;
        private System.Windows.Forms.ComboBox cmbHasCard;
        private System.Windows.Forms.ComboBox cmbHadGrbh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMediType;
        private System.Windows.Forms.TextBox tbxCode;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbApproType;
        private System.Windows.Forms.DataGridView dgvApproInfo;
        private System.Windows.Forms.TextBox tbxDiseaseName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbxDiseaseCode;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tbxApItemName;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tbxApproNum;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox tbxApItemCode;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DataGridViewTextBoxColumn col1;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn bre_code;
        private System.Windows.Forms.Label lblMsg;
    }
}