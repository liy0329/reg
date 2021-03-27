namespace MTREG.medinsur.ahsjk
{
    partial class FrmAhsnhIhsp
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
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbxMedicalCode = new System.Windows.Forms.TextBox();
            this.cmbPatientType = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.dtpBirth = new System.Windows.Forms.DateTimePicker();
            this.tbxCardCode = new System.Windows.Forms.TextBox();
            this.tbxIDCard = new System.Windows.Forms.TextBox();
            this.tbxAddrCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbSex = new System.Windows.Forms.ComboBox();
            this.tbxPersonalNum = new System.Windows.Forms.TextBox();
            this.tbxFamilyBalance = new System.Windows.Forms.TextBox();
            this.tbxAddress = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExtract = new System.Windows.Forms.Button();
            this.cmbChangeCode = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbxChangeRCode = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbArea
            // 
            this.cmbArea.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(352, 96);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(161, 23);
            this.cmbArea.TabIndex = 79;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 11F);
            this.label11.Location = new System.Drawing.Point(282, 100);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 15);
            this.label11.TabIndex = 78;
            this.label11.Text = "选择区域:";
            // 
            // tbxMedicalCode
            // 
            this.tbxMedicalCode.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxMedicalCode.Location = new System.Drawing.Point(100, 96);
            this.tbxMedicalCode.Name = "tbxMedicalCode";
            this.tbxMedicalCode.Size = new System.Drawing.Size(161, 24);
            this.tbxMedicalCode.TabIndex = 64;
            // 
            // cmbPatientType
            // 
            this.cmbPatientType.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbPatientType.FormattingEnabled = true;
            this.cmbPatientType.Location = new System.Drawing.Point(100, 57);
            this.cmbPatientType.Name = "cmbPatientType";
            this.cmbPatientType.Size = new System.Drawing.Size(121, 23);
            this.cmbPatientType.TabIndex = 72;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 11F);
            this.label14.Location = new System.Drawing.Point(30, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 15);
            this.label14.TabIndex = 71;
            this.label14.Text = "患者类型:";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("宋体", 11F);
            this.btnClose.Location = new System.Drawing.Point(363, 413);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 26);
            this.btnClose.TabIndex = 70;
            this.btnClose.Text = "取消";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("宋体", 11F);
            this.btnOk.Location = new System.Drawing.Point(186, 413);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(70, 26);
            this.btnOk.TabIndex = 69;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbxName);
            this.groupBox1.Controls.Add(this.dtpBirth);
            this.groupBox1.Controls.Add(this.tbxCardCode);
            this.groupBox1.Controls.Add(this.tbxIDCard);
            this.groupBox1.Controls.Add(this.tbxAddrCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cmbSex);
            this.groupBox1.Controls.Add(this.tbxPersonalNum);
            this.groupBox1.Controls.Add(this.tbxFamilyBalance);
            this.groupBox1.Controls.Add(this.tbxAddress);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(6, 129);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(606, 242);
            this.groupBox1.TabIndex = 68;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "医保信息";
            // 
            // tbxName
            // 
            this.tbxName.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxName.Location = new System.Drawing.Point(103, 24);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(161, 24);
            this.tbxName.TabIndex = 3;
            // 
            // dtpBirth
            // 
            this.dtpBirth.Font = new System.Drawing.Font("宋体", 11F);
            this.dtpBirth.Location = new System.Drawing.Point(427, 29);
            this.dtpBirth.Name = "dtpBirth";
            this.dtpBirth.Size = new System.Drawing.Size(161, 24);
            this.dtpBirth.TabIndex = 4;
            // 
            // tbxCardCode
            // 
            this.tbxCardCode.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxCardCode.Location = new System.Drawing.Point(427, 72);
            this.tbxCardCode.Name = "tbxCardCode";
            this.tbxCardCode.Size = new System.Drawing.Size(161, 24);
            this.tbxCardCode.TabIndex = 6;
            // 
            // tbxIDCard
            // 
            this.tbxIDCard.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxIDCard.Location = new System.Drawing.Point(427, 114);
            this.tbxIDCard.Name = "tbxIDCard";
            this.tbxIDCard.Size = new System.Drawing.Size(161, 24);
            this.tbxIDCard.TabIndex = 6;
            // 
            // tbxAddrCode
            // 
            this.tbxAddrCode.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxAddrCode.Location = new System.Drawing.Point(427, 159);
            this.tbxAddrCode.Name = "tbxAddrCode";
            this.tbxAddrCode.Size = new System.Drawing.Size(161, 24);
            this.tbxAddrCode.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(356, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 22;
            this.label1.Text = "医疗卡号:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 11F);
            this.label12.Location = new System.Drawing.Point(356, 164);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 15);
            this.label12.TabIndex = 24;
            this.label12.Text = "辖区编码:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 11F);
            this.label10.Location = new System.Drawing.Point(356, 119);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 15);
            this.label10.TabIndex = 22;
            this.label10.Text = "身份证号:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 11F);
            this.label9.Location = new System.Drawing.Point(356, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 15);
            this.label9.TabIndex = 21;
            this.label9.Text = "出生年月:";
            // 
            // cmbSex
            // 
            this.cmbSex.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbSex.FormattingEnabled = true;
            this.cmbSex.Location = new System.Drawing.Point(103, 72);
            this.cmbSex.Name = "cmbSex";
            this.cmbSex.Size = new System.Drawing.Size(161, 23);
            this.cmbSex.TabIndex = 51;
            // 
            // tbxPersonalNum
            // 
            this.tbxPersonalNum.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxPersonalNum.Location = new System.Drawing.Point(103, 114);
            this.tbxPersonalNum.Name = "tbxPersonalNum";
            this.tbxPersonalNum.Size = new System.Drawing.Size(161, 24);
            this.tbxPersonalNum.TabIndex = 7;
            // 
            // tbxFamilyBalance
            // 
            this.tbxFamilyBalance.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxFamilyBalance.Location = new System.Drawing.Point(156, 204);
            this.tbxFamilyBalance.Name = "tbxFamilyBalance";
            this.tbxFamilyBalance.Size = new System.Drawing.Size(161, 24);
            this.tbxFamilyBalance.TabIndex = 9;
            // 
            // tbxAddress
            // 
            this.tbxAddress.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxAddress.Location = new System.Drawing.Point(103, 160);
            this.tbxAddress.Name = "tbxAddress";
            this.tbxAddress.Size = new System.Drawing.Size(161, 24);
            this.tbxAddress.TabIndex = 9;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 11F);
            this.label15.Location = new System.Drawing.Point(62, 27);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(45, 15);
            this.label15.TabIndex = 12;
            this.label15.Text = "姓名:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 11F);
            this.label6.Location = new System.Drawing.Point(63, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "性别:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F);
            this.label2.Location = new System.Drawing.Point(24, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "本户家庭帐户余额:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 11F);
            this.label7.Location = new System.Drawing.Point(32, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "家庭地址:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 11F);
            this.label4.Location = new System.Drawing.Point(32, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "个人编号:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(250, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 20);
            this.label5.TabIndex = 67;
            this.label5.Text = "安徽市农合登记";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 11F);
            this.label3.Location = new System.Drawing.Point(30, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 66;
            this.label3.Text = "医疗证号:";
            // 
            // btnExtract
            // 
            this.btnExtract.Font = new System.Drawing.Font("宋体", 11F);
            this.btnExtract.Location = new System.Drawing.Point(542, 96);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(70, 26);
            this.btnExtract.TabIndex = 69;
            this.btnExtract.Text = "提取";
            this.btnExtract.UseVisualStyleBackColor = true;
            this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
            // 
            // cmbChangeCode
            // 
            this.cmbChangeCode.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbChangeCode.FormattingEnabled = true;
            this.cmbChangeCode.Location = new System.Drawing.Point(130, 377);
            this.cmbChangeCode.Name = "cmbChangeCode";
            this.cmbChangeCode.Size = new System.Drawing.Size(161, 23);
            this.cmbChangeCode.TabIndex = 81;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 11F);
            this.label8.Location = new System.Drawing.Point(60, 381);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 15);
            this.label8.TabIndex = 80;
            this.label8.Text = "是否转院:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 11F);
            this.label13.Location = new System.Drawing.Point(362, 381);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 15);
            this.label13.TabIndex = 24;
            this.label13.Text = "转诊单号:";
            // 
            // tbxChangeRCode
            // 
            this.tbxChangeRCode.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxChangeRCode.Location = new System.Drawing.Point(433, 376);
            this.tbxChangeRCode.Name = "tbxChangeRCode";
            this.tbxChangeRCode.Size = new System.Drawing.Size(161, 24);
            this.tbxChangeRCode.TabIndex = 10;
            // 
            // FrmAhsnhIhsp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 444);
            this.Controls.Add(this.cmbChangeCode);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbArea);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbxChangeRCode);
            this.Controls.Add(this.tbxMedicalCode);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbPatientType);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExtract);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Name = "FrmAhsnhIhsp";
            this.Text = "安徽市农合登记";
            this.Load += new System.EventHandler(this.FrmAhsnhIhsp_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbxMedicalCode;
        private System.Windows.Forms.ComboBox cmbPatientType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.DateTimePicker dtpBirth;
        private System.Windows.Forms.TextBox tbxIDCard;
        private System.Windows.Forms.TextBox tbxAddrCode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbSex;
        private System.Windows.Forms.TextBox tbxPersonalNum;
        private System.Windows.Forms.TextBox tbxAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxFamilyBalance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxCardCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.ComboBox cmbChangeCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbxChangeRCode;
    }
}