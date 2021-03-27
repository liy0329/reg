namespace MTREG.medinsur.gzsyb
{
    partial class FrmClinMedinsurGZS
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
            this.tbxBailorSex = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.tbxBailorID = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.tbxRelationShip = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.tbxBailorName = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.tbxIsInHosp = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.tbxInsurPersonIdentity = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.tbxAge = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.tbxOutside = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tbxInsurOrgonCode = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.tbxMedPerson = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tbxInsurPersonType = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tbxExeInsurMethod = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbxMedicare = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
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
            this.label17 = new System.Windows.Forms.Label();
            this.cmbPayType = new System.Windows.Forms.ComboBox();
            this.btnModifyPassword = new System.Windows.Forms.Button();
            this.btnReadBailor = new System.Windows.Forms.Button();
            this.btnReadCard = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSuccess
            // 
            this.lblSuccess.AutoSize = true;
            this.lblSuccess.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSuccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblSuccess.Location = new System.Drawing.Point(546, 11);
            this.lblSuccess.Name = "lblSuccess";
            this.lblSuccess.Size = new System.Drawing.Size(146, 20);
            this.lblSuccess.TabIndex = 53;
            this.lblSuccess.Text = "读卡是否成功!";
            this.lblSuccess.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(26, 47);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 19);
            this.label14.TabIndex = 52;
            this.label14.Text = "患者类型：";
            // 
            // cmbPatientType
            // 
            this.cmbPatientType.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbPatientType.FormattingEnabled = true;
            this.cmbPatientType.Location = new System.Drawing.Point(133, 44);
            this.cmbPatientType.Name = "cmbPatientType";
            this.cmbPatientType.Size = new System.Drawing.Size(161, 27);
            this.cmbPatientType.TabIndex = 47;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(562, 591);
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
            this.btnOk.Location = new System.Drawing.Point(385, 591);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(122, 41);
            this.btnOk.TabIndex = 50;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbxBailorSex);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Controls.Add(this.tbxBailorID);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.tbxRelationShip);
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.tbxBailorName);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.tbxIsInHosp);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.tbxInsurPersonIdentity);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.tbxAge);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.tbxOutside);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.tbxInsurOrgonCode);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.tbxMedPerson);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.tbxInsurPersonType);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.tbxExeInsurMethod);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.tbxMedicare);
            this.groupBox1.Controls.Add(this.label18);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(691, 505);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "医保信息";
            // 
            // tbxBailorSex
            // 
            this.tbxBailorSex.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxBailorSex.Location = new System.Drawing.Point(488, 459);
            this.tbxBailorSex.Name = "tbxBailorSex";
            this.tbxBailorSex.Size = new System.Drawing.Size(161, 29);
            this.tbxBailorSex.TabIndex = 66;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label30.Location = new System.Drawing.Point(353, 466);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(142, 19);
            this.label30.TabIndex = 65;
            this.label30.Text = "受委托人性别：";
            // 
            // tbxBailorID
            // 
            this.tbxBailorID.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxBailorID.Location = new System.Drawing.Point(179, 459);
            this.tbxBailorID.Name = "tbxBailorID";
            this.tbxBailorID.Size = new System.Drawing.Size(161, 29);
            this.tbxBailorID.TabIndex = 64;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label29.Location = new System.Drawing.Point(14, 462);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(180, 19);
            this.label29.TabIndex = 63;
            this.label29.Text = "受委托人身份证号：";
            // 
            // tbxRelationShip
            // 
            this.tbxRelationShip.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxRelationShip.Location = new System.Drawing.Point(488, 419);
            this.tbxRelationShip.Name = "tbxRelationShip";
            this.tbxRelationShip.Size = new System.Drawing.Size(161, 29);
            this.tbxRelationShip.TabIndex = 62;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label28.Location = new System.Drawing.Point(336, 425);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(161, 19);
            this.label28.TabIndex = 61;
            this.label28.Text = "与受委托人关系：";
            // 
            // tbxBailorName
            // 
            this.tbxBailorName.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxBailorName.Location = new System.Drawing.Point(147, 419);
            this.tbxBailorName.Name = "tbxBailorName";
            this.tbxBailorName.Size = new System.Drawing.Size(161, 29);
            this.tbxBailorName.TabIndex = 60;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.Location = new System.Drawing.Point(14, 425);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(142, 19);
            this.label27.TabIndex = 59;
            this.label27.Text = "受委托人姓名：";
            // 
            // tbxIsInHosp
            // 
            this.tbxIsInHosp.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxIsInHosp.Location = new System.Drawing.Point(488, 204);
            this.tbxIsInHosp.Name = "tbxIsInHosp";
            this.tbxIsInHosp.Size = new System.Drawing.Size(161, 29);
            this.tbxIsInHosp.TabIndex = 58;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.Location = new System.Drawing.Point(355, 210);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(142, 19);
            this.label26.TabIndex = 57;
            this.label26.Text = "当前住院状态：";
            // 
            // tbxInsurPersonIdentity
            // 
            this.tbxInsurPersonIdentity.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxInsurPersonIdentity.Location = new System.Drawing.Point(179, 345);
            this.tbxInsurPersonIdentity.Name = "tbxInsurPersonIdentity";
            this.tbxInsurPersonIdentity.Size = new System.Drawing.Size(161, 29);
            this.tbxInsurPersonIdentity.TabIndex = 56;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.Location = new System.Drawing.Point(10, 348);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(180, 19);
            this.label25.TabIndex = 55;
            this.label25.Text = "居民医疗人员身份：";
            // 
            // tbxAge
            // 
            this.tbxAge.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxAge.Location = new System.Drawing.Point(488, 310);
            this.tbxAge.Name = "tbxAge";
            this.tbxAge.Size = new System.Drawing.Size(161, 29);
            this.tbxAge.TabIndex = 54;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(355, 316);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(104, 19);
            this.label24.TabIndex = 53;
            this.label24.Text = "实足年龄：";
            // 
            // tbxOutside
            // 
            this.tbxOutside.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxOutside.Location = new System.Drawing.Point(488, 277);
            this.tbxOutside.Name = "tbxOutside";
            this.tbxOutside.Size = new System.Drawing.Size(161, 29);
            this.tbxOutside.TabIndex = 52;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.Location = new System.Drawing.Point(355, 283);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(104, 19);
            this.label23.TabIndex = 51;
            this.label23.Text = "驻外标志：";
            // 
            // tbxInsurOrgonCode
            // 
            this.tbxInsurOrgonCode.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxInsurOrgonCode.Location = new System.Drawing.Point(179, 204);
            this.tbxInsurOrgonCode.Name = "tbxInsurOrgonCode";
            this.tbxInsurOrgonCode.Size = new System.Drawing.Size(161, 29);
            this.tbxInsurOrgonCode.TabIndex = 50;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(10, 209);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(180, 19);
            this.label22.TabIndex = 49;
            this.label22.Text = "所属社保机构编码：";
            // 
            // tbxMedPerson
            // 
            this.tbxMedPerson.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxMedPerson.Location = new System.Drawing.Point(488, 239);
            this.tbxMedPerson.Name = "tbxMedPerson";
            this.tbxMedPerson.Size = new System.Drawing.Size(161, 29);
            this.tbxMedPerson.TabIndex = 48;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(355, 245);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(142, 19);
            this.label21.TabIndex = 47;
            this.label21.Text = "医疗人员类别：";
            // 
            // tbxInsurPersonType
            // 
            this.tbxInsurPersonType.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxInsurPersonType.Location = new System.Drawing.Point(179, 309);
            this.tbxInsurPersonType.Name = "tbxInsurPersonType";
            this.tbxInsurPersonType.Size = new System.Drawing.Size(161, 29);
            this.tbxInsurPersonType.TabIndex = 46;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(10, 312);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(180, 19);
            this.label20.TabIndex = 45;
            this.label20.Text = "居民医疗人员类别：";
            // 
            // tbxExeInsurMethod
            // 
            this.tbxExeInsurMethod.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxExeInsurMethod.Location = new System.Drawing.Point(179, 274);
            this.tbxExeInsurMethod.Name = "tbxExeInsurMethod";
            this.tbxExeInsurMethod.Size = new System.Drawing.Size(161, 29);
            this.tbxExeInsurMethod.TabIndex = 44;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(10, 277);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(180, 19);
            this.label19.TabIndex = 43;
            this.label19.Text = "执行社会保险方法：";
            // 
            // tbxMedicare
            // 
            this.tbxMedicare.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxMedicare.Location = new System.Drawing.Point(179, 239);
            this.tbxMedicare.Name = "tbxMedicare";
            this.tbxMedicare.Size = new System.Drawing.Size(161, 29);
            this.tbxMedicare.TabIndex = 42;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(10, 242);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(180, 19);
            this.label18.TabIndex = 41;
            this.label18.Text = "医疗照顾人员类别：";
            // 
            // dtpBirth
            // 
            this.dtpBirth.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpBirth.Location = new System.Drawing.Point(407, 24);
            this.dtpBirth.Name = "dtpBirth";
            this.dtpBirth.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpBirth.Size = new System.Drawing.Size(161, 29);
            this.dtpBirth.TabIndex = 4;
            // 
            // tbxIDCard
            // 
            this.tbxIDCard.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxIDCard.Location = new System.Drawing.Point(407, 59);
            this.tbxIDCard.Name = "tbxIDCard";
            this.tbxIDCard.ReadOnly = true;
            this.tbxIDCard.Size = new System.Drawing.Size(161, 29);
            this.tbxIDCard.TabIndex = 6;
            // 
            // tbxCompanyNum
            // 
            this.tbxCompanyNum.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxCompanyNum.Location = new System.Drawing.Point(407, 98);
            this.tbxCompanyNum.Name = "tbxCompanyNum";
            this.tbxCompanyNum.ReadOnly = true;
            this.tbxCompanyNum.Size = new System.Drawing.Size(161, 29);
            this.tbxCompanyNum.TabIndex = 8;
            // 
            // tbxCompanyName
            // 
            this.tbxCompanyName.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxCompanyName.Location = new System.Drawing.Point(407, 133);
            this.tbxCompanyName.Name = "tbxCompanyName";
            this.tbxCompanyName.ReadOnly = true;
            this.tbxCompanyName.Size = new System.Drawing.Size(161, 29);
            this.tbxCompanyName.TabIndex = 10;
            // 
            // tbxIsBlock
            // 
            this.tbxIsBlock.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxIsBlock.Location = new System.Drawing.Point(407, 168);
            this.tbxIsBlock.Name = "tbxIsBlock";
            this.tbxIsBlock.ReadOnly = true;
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
            this.label13.Text = "在保状态：";
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
            this.tbxSex.ReadOnly = true;
            this.tbxSex.Size = new System.Drawing.Size(161, 29);
            this.tbxSex.TabIndex = 5;
            // 
            // tbxPersonalNum
            // 
            this.tbxPersonalNum.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxPersonalNum.Location = new System.Drawing.Point(117, 95);
            this.tbxPersonalNum.Name = "tbxPersonalNum";
            this.tbxPersonalNum.ReadOnly = true;
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
            this.tbxBalance.ReadOnly = true;
            this.tbxBalance.Size = new System.Drawing.Size(161, 29);
            this.tbxBalance.TabIndex = 11;
            // 
            // tbxName
            // 
            this.tbxName.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxName.Location = new System.Drawing.Point(117, 24);
            this.tbxName.Name = "tbxName";
            this.tbxName.ReadOnly = true;
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
            this.label5.Location = new System.Drawing.Point(296, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 48;
            this.label5.Text = "门诊医保";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(327, 47);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(109, 19);
            this.label17.TabIndex = 56;
            this.label17.Text = "支付类别：";
            // 
            // cmbPayType
            // 
            this.cmbPayType.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbPayType.FormattingEnabled = true;
            this.cmbPayType.Location = new System.Drawing.Point(434, 44);
            this.cmbPayType.Name = "cmbPayType";
            this.cmbPayType.Size = new System.Drawing.Size(161, 27);
            this.cmbPayType.TabIndex = 55;
            // 
            // btnModifyPassword
            // 
            this.btnModifyPassword.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnModifyPassword.Location = new System.Drawing.Point(31, 591);
            this.btnModifyPassword.Name = "btnModifyPassword";
            this.btnModifyPassword.Size = new System.Drawing.Size(122, 41);
            this.btnModifyPassword.TabIndex = 57;
            this.btnModifyPassword.Text = "修改密码";
            this.btnModifyPassword.UseVisualStyleBackColor = true;
            this.btnModifyPassword.Click += new System.EventHandler(this.btnModifyPassword_Click);
            // 
            // btnReadBailor
            // 
            this.btnReadBailor.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReadBailor.Location = new System.Drawing.Point(191, 591);
            this.btnReadBailor.Name = "btnReadBailor";
            this.btnReadBailor.Size = new System.Drawing.Size(166, 41);
            this.btnReadBailor.TabIndex = 58;
            this.btnReadBailor.Text = "读取委托人信息";
            this.btnReadBailor.UseVisualStyleBackColor = true;
            this.btnReadBailor.Click += new System.EventHandler(this.btnReadBailor_Click);
            // 
            // btnReadCard
            // 
            this.btnReadCard.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReadCard.Location = new System.Drawing.Point(611, 42);
            this.btnReadCard.Name = "btnReadCard";
            this.btnReadCard.Size = new System.Drawing.Size(73, 32);
            this.btnReadCard.TabIndex = 59;
            this.btnReadCard.Text = "读卡";
            this.btnReadCard.UseVisualStyleBackColor = true;
            this.btnReadCard.Click += new System.EventHandler(this.btnReadCard_Click);
            // 
            // FrmClinMedinsurGZS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 643);
            this.Controls.Add(this.cmbPatientType);
            this.Controls.Add(this.cmbPayType);
            this.Controls.Add(this.btnReadCard);
            this.Controls.Add(this.btnReadBailor);
            this.Controls.Add(this.btnModifyPassword);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lblSuccess);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Name = "FrmClinMedinsurGZS";
            this.Text = "贵州省医保读卡";
            this.Load += new System.EventHandler(this.FrmClinMedinsurGZS_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cmbPayType;
        private System.Windows.Forms.TextBox tbxMedicare;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbxExeInsurMethod;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tbxInsurPersonType;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tbxMedPerson;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox tbxInsurOrgonCode;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox tbxOutside;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox tbxAge;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox tbxInsurPersonIdentity;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox tbxIsInHosp;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button btnModifyPassword;
        private System.Windows.Forms.Button btnReadBailor;
        private System.Windows.Forms.TextBox tbxBailorSex;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox tbxBailorID;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox tbxRelationShip;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox tbxBailorName;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button btnReadCard;
    }
}