namespace MTREG.medinsur.hdsch
{
    partial class FrmHdschIhspReg
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
            this.tbxIhspdiagn = new System.Windows.Forms.TextBox();
            this.dgvIhspdiagn = new System.Windows.Forms.DataGridView();
            this.tbxIhspicd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPatientType = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbYllb = new System.Windows.Forms.ComboBox();
            this.dtpBirth = new System.Windows.Forms.DateTimePicker();
            this.tbxIDCard = new System.Windows.Forms.TextBox();
            this.tbxCompanyNum = new System.Windows.Forms.TextBox();
            this.tbxCompanyName = new System.Windows.Forms.TextBox();
            this.tbxIsBlock = new System.Windows.Forms.TextBox();
            this.tbxSex = new System.Windows.Forms.TextBox();
            this.tbxPersonalNum = new System.Windows.Forms.TextBox();
            this.tbxICCardID = new System.Windows.Forms.TextBox();
            this.tbxBalance = new System.Windows.Forms.TextBox();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxYlzh = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnExtract = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIhspdiagn)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxIhspdiagn
            // 
            this.tbxIhspdiagn.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxIhspdiagn.Location = new System.Drawing.Point(130, 396);
            this.tbxIhspdiagn.Name = "tbxIhspdiagn";
            this.tbxIhspdiagn.Size = new System.Drawing.Size(161, 29);
            this.tbxIhspdiagn.TabIndex = 52;
            this.tbxIhspdiagn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxIhspdiagn_KeyDown);
            // 
            // dgvIhspdiagn
            // 
            this.dgvIhspdiagn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIhspdiagn.ColumnHeadersVisible = false;
            this.dgvIhspdiagn.Location = new System.Drawing.Point(130, 423);
            this.dgvIhspdiagn.Name = "dgvIhspdiagn";
            this.dgvIhspdiagn.RowHeadersVisible = false;
            this.dgvIhspdiagn.RowTemplate.Height = 23;
            this.dgvIhspdiagn.Size = new System.Drawing.Size(161, 109);
            this.dgvIhspdiagn.TabIndex = 56;
            this.dgvIhspdiagn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvIhspdiagn_KeyDown);
            // 
            // tbxIhspicd
            // 
            this.tbxIhspicd.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxIhspicd.Location = new System.Drawing.Point(484, 396);
            this.tbxIhspicd.Name = "tbxIhspicd";
            this.tbxIhspicd.Size = new System.Drawing.Size(161, 29);
            this.tbxIhspicd.TabIndex = 53;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(358, 401);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 19);
            this.label1.TabIndex = 55;
            this.label1.Text = "住院诊断编码:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(40, 401);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 19);
            this.label2.TabIndex = 54;
            this.label2.Text = "住院诊断:";
            // 
            // cmbPatientType
            // 
            this.cmbPatientType.Font = new System.Drawing.Font("宋体", 14.25F);
            this.cmbPatientType.FormattingEnabled = true;
            this.cmbPatientType.Location = new System.Drawing.Point(120, 63);
            this.cmbPatientType.Name = "cmbPatientType";
            this.cmbPatientType.Size = new System.Drawing.Size(161, 27);
            this.cmbPatientType.TabIndex = 51;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(25, 67);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 19);
            this.label14.TabIndex = 50;
            this.label14.Text = "患者类型:";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(383, 455);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(109, 32);
            this.btnClose.TabIndex = 49;
            this.btnClose.Text = "取消";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(197, 455);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(109, 32);
            this.btnOk.TabIndex = 48;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbYllb);
            this.groupBox1.Controls.Add(this.dtpBirth);
            this.groupBox1.Controls.Add(this.tbxIDCard);
            this.groupBox1.Controls.Add(this.tbxCompanyNum);
            this.groupBox1.Controls.Add(this.tbxCompanyName);
            this.groupBox1.Controls.Add(this.tbxIsBlock);
            this.groupBox1.Controls.Add(this.tbxSex);
            this.groupBox1.Controls.Add(this.tbxPersonalNum);
            this.groupBox1.Controls.Add(this.tbxICCardID);
            this.groupBox1.Controls.Add(this.tbxBalance);
            this.groupBox1.Controls.Add(this.tbxName);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(15, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(666, 284);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "医保信息";
            // 
            // cmbYllb
            // 
            this.cmbYllb.Font = new System.Drawing.Font("宋体", 14.25F);
            this.cmbYllb.FormattingEnabled = true;
            this.cmbYllb.Location = new System.Drawing.Point(115, 247);
            this.cmbYllb.Name = "cmbYllb";
            this.cmbYllb.Size = new System.Drawing.Size(161, 27);
            this.cmbYllb.TabIndex = 37;
            // 
            // dtpBirth
            // 
            this.dtpBirth.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpBirth.Location = new System.Drawing.Point(469, 28);
            this.dtpBirth.Name = "dtpBirth";
            this.dtpBirth.Size = new System.Drawing.Size(161, 29);
            this.dtpBirth.TabIndex = 4;
            // 
            // tbxIDCard
            // 
            this.tbxIDCard.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxIDCard.Location = new System.Drawing.Point(469, 70);
            this.tbxIDCard.Name = "tbxIDCard";
            this.tbxIDCard.Size = new System.Drawing.Size(161, 29);
            this.tbxIDCard.TabIndex = 6;
            // 
            // tbxCompanyNum
            // 
            this.tbxCompanyNum.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxCompanyNum.Location = new System.Drawing.Point(469, 113);
            this.tbxCompanyNum.Name = "tbxCompanyNum";
            this.tbxCompanyNum.Size = new System.Drawing.Size(161, 29);
            this.tbxCompanyNum.TabIndex = 8;
            // 
            // tbxCompanyName
            // 
            this.tbxCompanyName.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxCompanyName.Location = new System.Drawing.Point(469, 157);
            this.tbxCompanyName.Name = "tbxCompanyName";
            this.tbxCompanyName.Size = new System.Drawing.Size(161, 29);
            this.tbxCompanyName.TabIndex = 10;
            // 
            // tbxIsBlock
            // 
            this.tbxIsBlock.Enabled = false;
            this.tbxIsBlock.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxIsBlock.Location = new System.Drawing.Point(469, 200);
            this.tbxIsBlock.Name = "tbxIsBlock";
            this.tbxIsBlock.Size = new System.Drawing.Size(161, 29);
            this.tbxIsBlock.TabIndex = 12;
            // 
            // tbxSex
            // 
            this.tbxSex.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxSex.Location = new System.Drawing.Point(116, 70);
            this.tbxSex.Name = "tbxSex";
            this.tbxSex.Size = new System.Drawing.Size(161, 29);
            this.tbxSex.TabIndex = 5;
            // 
            // tbxPersonalNum
            // 
            this.tbxPersonalNum.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxPersonalNum.Location = new System.Drawing.Point(116, 113);
            this.tbxPersonalNum.Name = "tbxPersonalNum";
            this.tbxPersonalNum.Size = new System.Drawing.Size(161, 29);
            this.tbxPersonalNum.TabIndex = 7;
            // 
            // tbxICCardID
            // 
            this.tbxICCardID.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxICCardID.Location = new System.Drawing.Point(116, 157);
            this.tbxICCardID.Name = "tbxICCardID";
            this.tbxICCardID.Size = new System.Drawing.Size(161, 29);
            this.tbxICCardID.TabIndex = 9;
            // 
            // tbxBalance
            // 
            this.tbxBalance.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxBalance.Location = new System.Drawing.Point(116, 200);
            this.tbxBalance.Name = "tbxBalance";
            this.tbxBalance.Size = new System.Drawing.Size(161, 29);
            this.tbxBalance.TabIndex = 11;
            // 
            // tbxName
            // 
            this.tbxName.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxName.Location = new System.Drawing.Point(116, 28);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(161, 29);
            this.tbxName.TabIndex = 3;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(25, 252);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(95, 19);
            this.label17.TabIndex = 32;
            this.label17.Text = "医疗类别:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(381, 205);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 19);
            this.label13.TabIndex = 25;
            this.label13.Text = "封锁情况:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(381, 162);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 19);
            this.label12.TabIndex = 24;
            this.label12.Text = "单位名称:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(381, 118);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 19);
            this.label11.TabIndex = 23;
            this.label11.Text = "单位编号:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(381, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 19);
            this.label10.TabIndex = 22;
            this.label10.Text = "身份证号:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(381, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 19);
            this.label9.TabIndex = 21;
            this.label9.Text = "出生年月:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(24, 205);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 19);
            this.label8.TabIndex = 14;
            this.label8.Text = "账户余额:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(42, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 19);
            this.label7.TabIndex = 13;
            this.label7.Text = "IC卡号:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(63, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "性别:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(24, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 19);
            this.label4.TabIndex = 11;
            this.label4.Text = "个人编号:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(63, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "姓名:";
            // 
            // tbxYlzh
            // 
            this.tbxYlzh.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxYlzh.Location = new System.Drawing.Point(437, 62);
            this.tbxYlzh.Name = "tbxYlzh";
            this.tbxYlzh.Size = new System.Drawing.Size(161, 29);
            this.tbxYlzh.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(341, 67);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 19);
            this.label15.TabIndex = 10;
            this.label15.Text = "个人编号:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(277, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 20);
            this.label5.TabIndex = 46;
            this.label5.Text = "住院登记城合";
            // 
            // btnExtract
            // 
            this.btnExtract.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold);
            this.btnExtract.Location = new System.Drawing.Point(604, 63);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(77, 28);
            this.btnExtract.TabIndex = 49;
            this.btnExtract.Text = "提取";
            this.btnExtract.UseVisualStyleBackColor = true;
            this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
            // 
            // FrmHdschIhspReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 532);
            this.Controls.Add(this.tbxIhspdiagn);
            this.Controls.Add(this.tbxIhspicd);
            this.Controls.Add(this.cmbPatientType);
            this.Controls.Add(this.dgvIhspdiagn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnExtract);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbxYlzh);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label15);
            this.Name = "FrmHdschIhspReg";
            this.Text = "邯郸城合住院登记";
            this.Load += new System.EventHandler(this.FrmHdchIhspReg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIhspdiagn)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxIhspdiagn;
        private System.Windows.Forms.DataGridView dgvIhspdiagn;
        private System.Windows.Forms.TextBox tbxIhspicd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPatientType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbYllb;
        private System.Windows.Forms.DateTimePicker dtpBirth;
        private System.Windows.Forms.TextBox tbxIDCard;
        private System.Windows.Forms.TextBox tbxCompanyNum;
        private System.Windows.Forms.TextBox tbxCompanyName;
        private System.Windows.Forms.TextBox tbxIsBlock;
        private System.Windows.Forms.TextBox tbxSex;
        private System.Windows.Forms.TextBox tbxPersonalNum;
        private System.Windows.Forms.TextBox tbxICCardID;
        private System.Windows.Forms.TextBox tbxBalance;
        private System.Windows.Forms.TextBox tbxYlzh;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnExtract;
    }
}