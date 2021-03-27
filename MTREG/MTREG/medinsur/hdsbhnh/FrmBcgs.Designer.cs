namespace MTREG.medinsur.hdsbhnh
{
    partial class FrmBcgs
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnTj = new System.Windows.Forms.Button();
            this.cmbRqfl = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBcfl = new System.Windows.Forms.ComboBox();
            this.dtpKssj = new System.Windows.Forms.DateTimePicker();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.dtpJssj = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvBcgs = new System.Windows.Forms.DataGridView();
            this.D504_02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D504_03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D504_04 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D301_09 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D504_74 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D504_05 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D504_77 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D504_14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D101_02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D504_10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D506_96 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D503_20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D603_02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D506_26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D504_11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D504_12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D504_76 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D506_03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D506_19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D506_24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D506_57 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D506_95 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D506_59 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D506_60 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D506_58 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbx_hj = new System.Windows.Forms.TextBox();
            this.testBoxHj = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBcgs)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnTj);
            this.groupBox1.Controls.Add(this.cmbRqfl);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbBcfl);
            this.groupBox1.Controls.Add(this.dtpKssj);
            this.groupBox1.Controls.Add(this.cmbArea);
            this.groupBox1.Controls.Add(this.dtpJssj);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(758, 100);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "统计范围";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnPrint.Font = new System.Drawing.Font("宋体", 11F);
            this.btnPrint.Location = new System.Drawing.Point(435, 59);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(161, 25);
            this.btnPrint.TabIndex = 26;
            this.btnPrint.Text = "打印补偿金额申请表";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(648, 62);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.TabIndex = 25;
            this.btnClose.Text = "退出";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnTj
            // 
            this.btnTj.Font = new System.Drawing.Font("宋体", 11F);
            this.btnTj.Location = new System.Drawing.Point(648, 23);
            this.btnTj.Name = "btnTj";
            this.btnTj.Size = new System.Drawing.Size(75, 25);
            this.btnTj.TabIndex = 24;
            this.btnTj.Text = "统计";
            this.btnTj.UseVisualStyleBackColor = true;
            this.btnTj.Click += new System.EventHandler(this.btnTj_Click);
            // 
            // cmbRqfl
            // 
            this.cmbRqfl.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbRqfl.FormattingEnabled = true;
            this.cmbRqfl.Location = new System.Drawing.Point(454, 25);
            this.cmbRqfl.Name = "cmbRqfl";
            this.cmbRqfl.Size = new System.Drawing.Size(142, 23);
            this.cmbRqfl.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F);
            this.label2.Location = new System.Drawing.Point(384, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "日期分类：";
            // 
            // cmbBcfl
            // 
            this.cmbBcfl.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbBcfl.FormattingEnabled = true;
            this.cmbBcfl.Location = new System.Drawing.Point(286, 58);
            this.cmbBcfl.Name = "cmbBcfl";
            this.cmbBcfl.Size = new System.Drawing.Size(142, 23);
            this.cmbBcfl.TabIndex = 20;
            this.cmbBcfl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbBcfl_KeyUp);
            // 
            // dtpKssj
            // 
            this.dtpKssj.Font = new System.Drawing.Font("宋体", 11F);
            this.dtpKssj.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpKssj.Location = new System.Drawing.Point(58, 25);
            this.dtpKssj.Name = "dtpKssj";
            this.dtpKssj.Size = new System.Drawing.Size(142, 24);
            this.dtpKssj.TabIndex = 19;
            // 
            // cmbArea
            // 
            this.cmbArea.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(58, 55);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(142, 23);
            this.cmbArea.TabIndex = 20;
            this.cmbArea.SelectedValueChanged += new System.EventHandler(this.cmbArea_SelectedValueChanged);
            // 
            // dtpJssj
            // 
            this.dtpJssj.Font = new System.Drawing.Font("宋体", 11F);
            this.dtpJssj.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpJssj.Location = new System.Drawing.Point(232, 24);
            this.dtpJssj.Name = "dtpJssj";
            this.dtpJssj.Size = new System.Drawing.Size(142, 24);
            this.dtpJssj.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 11F);
            this.label3.Location = new System.Drawing.Point(18, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "区域：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 11F);
            this.label5.Location = new System.Drawing.Point(33, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "从：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 11F);
            this.label6.Location = new System.Drawing.Point(204, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "至：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 11F);
            this.label4.Location = new System.Drawing.Point(214, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "补偿分类：";
            // 
            // dgvBcgs
            // 
            this.dgvBcgs.AllowUserToAddRows = false;
            this.dgvBcgs.AllowUserToDeleteRows = false;
            this.dgvBcgs.ColumnHeadersHeight = 25;
            this.dgvBcgs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBcgs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.D504_02,
            this.D504_03,
            this.D504_04,
            this.D301_09,
            this.D504_74,
            this.D504_05,
            this.D504_77,
            this.D504_14,
            this.D101_02,
            this.D504_10,
            this.D506_96,
            this.D503_20,
            this.D603_02,
            this.D506_26,
            this.D504_11,
            this.D504_12,
            this.D504_76,
            this.D506_03,
            this.D506_19,
            this.D506_24,
            this.D506_57,
            this.D506_95,
            this.D506_59,
            this.D506_60,
            this.D506_58});
            this.dgvBcgs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBcgs.Location = new System.Drawing.Point(0, 100);
            this.dgvBcgs.Name = "dgvBcgs";
            this.dgvBcgs.ReadOnly = true;
            this.dgvBcgs.RowHeadersVisible = false;
            this.dgvBcgs.RowTemplate.Height = 23;
            this.dgvBcgs.Size = new System.Drawing.Size(758, 325);
            this.dgvBcgs.TabIndex = 25;
            // 
            // D504_02
            // 
            this.D504_02.HeaderText = "个人编码";
            this.D504_02.Name = "D504_02";
            this.D504_02.ReadOnly = true;
            // 
            // D504_03
            // 
            this.D504_03.HeaderText = "患者姓名";
            this.D504_03.Name = "D504_03";
            this.D504_03.ReadOnly = true;
            // 
            // D504_04
            // 
            this.D504_04.HeaderText = "患者性别";
            this.D504_04.Name = "D504_04";
            this.D504_04.ReadOnly = true;
            // 
            // D301_09
            // 
            this.D301_09.HeaderText = "家庭住址";
            this.D301_09.Name = "D301_09";
            this.D301_09.ReadOnly = true;
            // 
            // D504_74
            // 
            this.D504_74.HeaderText = "出生日期";
            this.D504_74.Name = "D504_74";
            this.D504_74.ReadOnly = true;
            // 
            // D504_05
            // 
            this.D504_05.HeaderText = "患者身份证号";
            this.D504_05.Name = "D504_05";
            this.D504_05.ReadOnly = true;
            // 
            // D504_77
            // 
            this.D504_77.HeaderText = "区划名称";
            this.D504_77.Name = "D504_77";
            this.D504_77.ReadOnly = true;
            // 
            // D504_14
            // 
            this.D504_14.HeaderText = "就医机构代码";
            this.D504_14.Name = "D504_14";
            this.D504_14.ReadOnly = true;
            // 
            // D101_02
            // 
            this.D101_02.HeaderText = "就医机构名称";
            this.D101_02.Name = "D101_02";
            this.D101_02.ReadOnly = true;
            // 
            // D504_10
            // 
            this.D504_10.HeaderText = "就诊类型";
            this.D504_10.Name = "D504_10";
            this.D504_10.ReadOnly = true;
            // 
            // D506_96
            // 
            this.D506_96.HeaderText = "冲红类别";
            this.D506_96.Name = "D506_96";
            this.D506_96.ReadOnly = true;
            // 
            // D503_20
            // 
            this.D503_20.HeaderText = "结算标识";
            this.D503_20.Name = "D503_20";
            this.D503_20.ReadOnly = true;
            // 
            // D603_02
            // 
            this.D603_02.HeaderText = "基金年份";
            this.D603_02.Name = "D603_02";
            this.D603_02.ReadOnly = true;
            // 
            // D506_26
            // 
            this.D506_26.HeaderText = "补偿日期";
            this.D506_26.Name = "D506_26";
            this.D506_26.ReadOnly = true;
            // 
            // D504_11
            // 
            this.D504_11.HeaderText = "入院日期";
            this.D504_11.Name = "D504_11";
            this.D504_11.ReadOnly = true;
            // 
            // D504_12
            // 
            this.D504_12.HeaderText = "出院日期";
            this.D504_12.Name = "D504_12";
            this.D504_12.ReadOnly = true;
            // 
            // D504_76
            // 
            this.D504_76.HeaderText = "疾病名称";
            this.D504_76.Name = "D504_76";
            this.D504_76.ReadOnly = true;
            // 
            // D506_03
            // 
            this.D506_03.HeaderText = "住院总费用";
            this.D506_03.Name = "D506_03";
            this.D506_03.ReadOnly = true;
            // 
            // D506_19
            // 
            this.D506_19.HeaderText = "住院可报总费用";
            this.D506_19.Name = "D506_19";
            this.D506_19.ReadOnly = true;
            // 
            // D506_24
            // 
            this.D506_24.HeaderText = "实际补偿金额";
            this.D506_24.Name = "D506_24";
            this.D506_24.ReadOnly = true;
            // 
            // D506_57
            // 
            this.D506_57.HeaderText = "家庭账户冲抵金额";
            this.D506_57.Name = "D506_57";
            this.D506_57.ReadOnly = true;
            // 
            // D506_95
            // 
            this.D506_95.HeaderText = "大额二次补偿金额";
            this.D506_95.Name = "D506_95";
            this.D506_95.ReadOnly = true;
            // 
            // D506_59
            // 
            this.D506_59.HeaderText = "第三方补充医疗保险补偿金额";
            this.D506_59.Name = "D506_59";
            this.D506_59.ReadOnly = true;
            // 
            // D506_60
            // 
            this.D506_60.HeaderText = "第三方大额救助补偿金额";
            this.D506_60.Name = "D506_60";
            this.D506_60.ReadOnly = true;
            // 
            // D506_58
            // 
            this.D506_58.HeaderText = "特殊重大疾病补偿金额";
            this.D506_58.Name = "D506_58";
            this.D506_58.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.tbx_hj);
            this.panel1.Controls.Add(this.testBoxHj);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 425);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(758, 62);
            this.panel1.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(54, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 28;
            this.label1.Text = "合计：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("宋体", 11F);
            this.label7.Location = new System.Drawing.Point(54, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 15);
            this.label7.TabIndex = 28;
            this.label7.Text = "合计：";
            // 
            // tbx_hj
            // 
            this.tbx_hj.Font = new System.Drawing.Font("宋体", 11F);
            this.tbx_hj.Location = new System.Drawing.Point(98, 35);
            this.tbx_hj.Name = "tbx_hj";
            this.tbx_hj.Size = new System.Drawing.Size(617, 24);
            this.tbx_hj.TabIndex = 27;
            // 
            // testBoxHj
            // 
            this.testBoxHj.Font = new System.Drawing.Font("宋体", 11F);
            this.testBoxHj.Location = new System.Drawing.Point(98, 8);
            this.testBoxHj.Name = "testBoxHj";
            this.testBoxHj.Size = new System.Drawing.Size(617, 24);
            this.testBoxHj.TabIndex = 26;
            // 
            // FrmBcgs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 487);
            this.Controls.Add(this.dgvBcgs);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmBcgs";
            this.Text = "补偿公示表";
            this.Load += new System.EventHandler(this.FrmBcgs_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBcgs)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbRqfl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBcfl;
        private System.Windows.Forms.DateTimePicker dtpKssj;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.DateTimePicker dtpJssj;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTj;
        private System.Windows.Forms.DataGridView dgvBcgs;
        private System.Windows.Forms.DataGridViewTextBoxColumn D504_02;
        private System.Windows.Forms.DataGridViewTextBoxColumn D504_03;
        private System.Windows.Forms.DataGridViewTextBoxColumn D504_04;
        private System.Windows.Forms.DataGridViewTextBoxColumn D301_09;
        private System.Windows.Forms.DataGridViewTextBoxColumn D504_74;
        private System.Windows.Forms.DataGridViewTextBoxColumn D504_05;
        private System.Windows.Forms.DataGridViewTextBoxColumn D504_77;
        private System.Windows.Forms.DataGridViewTextBoxColumn D504_14;
        private System.Windows.Forms.DataGridViewTextBoxColumn D101_02;
        private System.Windows.Forms.DataGridViewTextBoxColumn D504_10;
        private System.Windows.Forms.DataGridViewTextBoxColumn D506_96;
        private System.Windows.Forms.DataGridViewTextBoxColumn D503_20;
        private System.Windows.Forms.DataGridViewTextBoxColumn D603_02;
        private System.Windows.Forms.DataGridViewTextBoxColumn D506_26;
        private System.Windows.Forms.DataGridViewTextBoxColumn D504_11;
        private System.Windows.Forms.DataGridViewTextBoxColumn D504_12;
        private System.Windows.Forms.DataGridViewTextBoxColumn D504_76;
        private System.Windows.Forms.DataGridViewTextBoxColumn D506_03;
        private System.Windows.Forms.DataGridViewTextBoxColumn D506_19;
        private System.Windows.Forms.DataGridViewTextBoxColumn D506_24;
        private System.Windows.Forms.DataGridViewTextBoxColumn D506_57;
        private System.Windows.Forms.DataGridViewTextBoxColumn D506_95;
        private System.Windows.Forms.DataGridViewTextBoxColumn D506_59;
        private System.Windows.Forms.DataGridViewTextBoxColumn D506_60;
        private System.Windows.Forms.DataGridViewTextBoxColumn D506_58;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbx_hj;
        private System.Windows.Forms.TextBox testBoxHj;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
    }
}