namespace MTREG.medinsur.hdsbhnh.bo
{
    partial class FrmInHspMedinsrHDSNH
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
            this.cmbPatientType = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.dtpDjsj = new System.Windows.Forms.DateTimePicker();
            this.dtpBirth = new System.Windows.Forms.DateTimePicker();
            this.tbxIDCard = new System.Windows.Forms.TextBox();
            this.tbxCompanyName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbSex = new System.Windows.Forms.ComboBox();
            this.tbxAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxCardCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbDjsx = new System.Windows.Forms.ComboBox();
            this.cmbZwlx = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxHospCode = new System.Windows.Forms.TextBox();
            this.tbxPersonalNum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGetInfo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbPatientType
            // 
            this.cmbPatientType.Font = new System.Drawing.Font("宋体", 14.25F);
            this.cmbPatientType.FormattingEnabled = true;
            this.cmbPatientType.Location = new System.Drawing.Point(123, 54);
            this.cmbPatientType.Name = "cmbPatientType";
            this.cmbPatientType.Size = new System.Drawing.Size(161, 27);
            this.cmbPatientType.TabIndex = 51;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(33, 57);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 19);
            this.label14.TabIndex = 50;
            this.label14.Text = "患者类型:";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("宋体", 12F);
            this.btnClose.Location = new System.Drawing.Point(375, 436);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 28);
            this.btnClose.TabIndex = 49;
            this.btnClose.Text = "取消";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("宋体", 12F);
            this.btnOk.Location = new System.Drawing.Point(189, 436);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 28);
            this.btnOk.TabIndex = 48;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbxName);
            this.groupBox1.Controls.Add(this.dtpDjsj);
            this.groupBox1.Controls.Add(this.dtpBirth);
            this.groupBox1.Controls.Add(this.tbxIDCard);
            this.groupBox1.Controls.Add(this.tbxCompanyName);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cmbSex);
            this.groupBox1.Controls.Add(this.tbxAddress);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(8, 180);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(620, 197);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "医保信息";
            // 
            // tbxName
            // 
            this.tbxName.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxName.Location = new System.Drawing.Point(116, 34);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(161, 29);
            this.tbxName.TabIndex = 3;
            // 
            // dtpDjsj
            // 
            this.dtpDjsj.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpDjsj.Location = new System.Drawing.Point(442, 73);
            this.dtpDjsj.Name = "dtpDjsj";
            this.dtpDjsj.Size = new System.Drawing.Size(161, 29);
            this.dtpDjsj.TabIndex = 4;
            // 
            // dtpBirth
            // 
            this.dtpBirth.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpBirth.Location = new System.Drawing.Point(442, 29);
            this.dtpBirth.Name = "dtpBirth";
            this.dtpBirth.Size = new System.Drawing.Size(161, 29);
            this.dtpBirth.TabIndex = 4;
            // 
            // tbxIDCard
            // 
            this.tbxIDCard.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxIDCard.Location = new System.Drawing.Point(442, 114);
            this.tbxIDCard.Name = "tbxIDCard";
            this.tbxIDCard.Size = new System.Drawing.Size(161, 29);
            this.tbxIDCard.TabIndex = 6;
            // 
            // tbxCompanyName
            // 
            this.tbxCompanyName.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxCompanyName.Location = new System.Drawing.Point(115, 162);
            this.tbxCompanyName.Name = "tbxCompanyName";
            this.tbxCompanyName.Size = new System.Drawing.Size(161, 29);
            this.tbxCompanyName.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(27, 167);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 19);
            this.label12.TabIndex = 24;
            this.label12.Text = "单位名称:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(354, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 19);
            this.label1.TabIndex = 21;
            this.label1.Text = "登记时间:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(354, 119);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 19);
            this.label10.TabIndex = 22;
            this.label10.Text = "身份证号:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(354, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 19);
            this.label9.TabIndex = 21;
            this.label9.Text = "出生年月:";
            // 
            // cmbSex
            // 
            this.cmbSex.Font = new System.Drawing.Font("宋体", 14.25F);
            this.cmbSex.FormattingEnabled = true;
            this.cmbSex.Location = new System.Drawing.Point(116, 77);
            this.cmbSex.Name = "cmbSex";
            this.cmbSex.Size = new System.Drawing.Size(161, 27);
            this.cmbSex.TabIndex = 51;
            // 
            // tbxAddress
            // 
            this.tbxAddress.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxAddress.Location = new System.Drawing.Point(116, 119);
            this.tbxAddress.Name = "tbxAddress";
            this.tbxAddress.Size = new System.Drawing.Size(161, 29);
            this.tbxAddress.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(26, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 19);
            this.label7.TabIndex = 13;
            this.label7.Text = "通讯地址:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(62, 37);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 19);
            this.label15.TabIndex = 12;
            this.label15.Text = "姓名:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(64, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "性别:";
            // 
            // tbxCardCode
            // 
            this.tbxCardCode.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxCardCode.Location = new System.Drawing.Point(124, 137);
            this.tbxCardCode.Name = "tbxCardCode";
            this.tbxCardCode.Size = new System.Drawing.Size(227, 29);
            this.tbxCardCode.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(34, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "医疗证号:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(252, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 20);
            this.label5.TabIndex = 46;
            this.label5.Text = "邯郸市农合登记";
            // 
            // cmbDjsx
            // 
            this.cmbDjsx.Font = new System.Drawing.Font("宋体", 14.25F);
            this.cmbDjsx.FormattingEnabled = true;
            this.cmbDjsx.Location = new System.Drawing.Point(123, 383);
            this.cmbDjsx.Name = "cmbDjsx";
            this.cmbDjsx.Size = new System.Drawing.Size(161, 27);
            this.cmbDjsx.TabIndex = 56;
            // 
            // cmbZwlx
            // 
            this.cmbZwlx.Font = new System.Drawing.Font("宋体", 14.25F);
            this.cmbZwlx.FormattingEnabled = true;
            this.cmbZwlx.Location = new System.Drawing.Point(452, 383);
            this.cmbZwlx.Name = "cmbZwlx";
            this.cmbZwlx.Size = new System.Drawing.Size(161, 27);
            this.cmbZwlx.TabIndex = 57;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(31, 387);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(95, 19);
            this.label17.TabIndex = 53;
            this.label17.Text = "登记属性:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(362, 387);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 19);
            this.label2.TabIndex = 54;
            this.label2.Text = "转外类型:";
            // 
            // cmbArea
            // 
            this.cmbArea.Font = new System.Drawing.Font("宋体", 14.25F);
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(418, 56);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(161, 27);
            this.cmbArea.TabIndex = 63;
            this.cmbArea.SelectionChangeCommitted += new System.EventHandler(this.cmbArea_SelectionChangeCommitted);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(330, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 19);
            this.label11.TabIndex = 62;
            this.label11.Text = "选择区域:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(293, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 19);
            this.label8.TabIndex = 60;
            this.label8.Text = "就医机构代码:";
            // 
            // tbxHospCode
            // 
            this.tbxHospCode.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxHospCode.Location = new System.Drawing.Point(420, 96);
            this.tbxHospCode.Name = "tbxHospCode";
            this.tbxHospCode.Size = new System.Drawing.Size(161, 29);
            this.tbxHospCode.TabIndex = 3;
            // 
            // tbxPersonalNum
            // 
            this.tbxPersonalNum.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxPersonalNum.Location = new System.Drawing.Point(123, 95);
            this.tbxPersonalNum.Name = "tbxPersonalNum";
            this.tbxPersonalNum.Size = new System.Drawing.Size(161, 29);
            this.tbxPersonalNum.TabIndex = 64;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(35, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 19);
            this.label4.TabIndex = 65;
            this.label4.Text = "个人编号:";
            // 
            // btnGetInfo
            // 
            this.btnGetInfo.Font = new System.Drawing.Font("宋体", 12F);
            this.btnGetInfo.Location = new System.Drawing.Point(363, 137);
            this.btnGetInfo.Name = "btnGetInfo";
            this.btnGetInfo.Size = new System.Drawing.Size(81, 28);
            this.btnGetInfo.TabIndex = 66;
            this.btnGetInfo.Text = "获取信息";
            this.btnGetInfo.UseVisualStyleBackColor = true;
            this.btnGetInfo.Click += new System.EventHandler(this.btnGetInfo_Click);
            // 
            // FrmInHspMedinsrHDSNH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 478);
            this.Controls.Add(this.btnGetInfo);
            this.Controls.Add(this.tbxHospCode);
            this.Controls.Add(this.tbxPersonalNum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbArea);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbDjsx);
            this.Controls.Add(this.cmbZwlx);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxCardCode);
            this.Controls.Add(this.cmbPatientType);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Name = "FrmInHspMedinsrHDSNH";
            this.Text = "邯郸市农合登记";
            this.Load += new System.EventHandler(this.FrmInHspMedinsrHDSNH_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPatientType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpBirth;
        private System.Windows.Forms.TextBox tbxIDCard;
        private System.Windows.Forms.TextBox tbxCompanyName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbxAddress;
        private System.Windows.Forms.TextBox tbxCardCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtpDjsj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDjsx;
        private System.Windows.Forms.ComboBox cmbZwlx;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSex;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxHospCode;
        private System.Windows.Forms.TextBox tbxPersonalNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGetInfo;
    }
}