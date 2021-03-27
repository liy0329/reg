namespace MTREG.medinsur.ahsjk
{
    partial class FrmInpatDiagnosisUpdate
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
            this.jbbm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jbmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.zlfsmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zlfsbm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.radio_wzw = new System.Windows.Forms.RadioButton();
            this.radio_yzw = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_UserCode = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_UserPass = new System.Windows.Forms.TextBox();
            this.but_qx = new System.Windows.Forms.Button();
            this.but_qd = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbx_jbbm = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_jbmc = new System.Windows.Forms.TextBox();
            this.tbx_sg = new System.Windows.Forms.TextBox();
            this.tbx_tz = new System.Windows.Forms.TextBox();
            this.tbx_zlfsbm = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_jbjm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_jzh = new System.Windows.Forms.TextBox();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // jbbm
            // 
            this.jbbm.DataPropertyName = "jbbm";
            this.jbbm.HeaderText = "疾病编码";
            this.jbbm.Name = "jbbm";
            this.jbbm.ReadOnly = true;
            // 
            // jbmc
            // 
            this.jbmc.DataPropertyName = "jbmc";
            this.jbmc.HeaderText = "疾病名称";
            this.jbmc.Name = "jbmc";
            this.jbmc.ReadOnly = true;
            this.jbmc.Width = 120;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.jbmc,
            this.jbbm,
            this.zlfsmc,
            this.zlfsbm});
            this.dataGridView1.Location = new System.Drawing.Point(107, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(405, 150);
            this.dataGridView1.TabIndex = 52;
            // 
            // zlfsmc
            // 
            this.zlfsmc.DataPropertyName = "zlfsmc";
            this.zlfsmc.HeaderText = "治疗方式名称";
            this.zlfsmc.Name = "zlfsmc";
            this.zlfsmc.ReadOnly = true;
            // 
            // zlfsbm
            // 
            this.zlfsbm.DataPropertyName = "zlfsbm";
            this.zlfsbm.HeaderText = "治疗方式编码";
            this.zlfsbm.Name = "zlfsbm";
            this.zlfsbm.ReadOnly = true;
            // 
            // radio_wzw
            // 
            this.radio_wzw.AutoSize = true;
            this.radio_wzw.Location = new System.Drawing.Point(326, 229);
            this.radio_wzw.Name = "radio_wzw";
            this.radio_wzw.Size = new System.Drawing.Size(59, 16);
            this.radio_wzw.TabIndex = 51;
            this.radio_wzw.TabStop = true;
            this.radio_wzw.Text = "未走完";
            this.radio_wzw.UseVisualStyleBackColor = true;
            // 
            // radio_yzw
            // 
            this.radio_yzw.AutoSize = true;
            this.radio_yzw.Checked = true;
            this.radio_yzw.Location = new System.Drawing.Point(187, 229);
            this.radio_yzw.Name = "radio_yzw";
            this.radio_yzw.Size = new System.Drawing.Size(59, 16);
            this.radio_yzw.TabIndex = 50;
            this.radio_yzw.TabStop = true;
            this.radio_yzw.Text = "已走完";
            this.radio_yzw.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(48, 229);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 12);
            this.label12.TabIndex = 49;
            this.label12.Text = "是否走完临床路径";
            // 
            // txt_UserCode
            // 
            this.txt_UserCode.Location = new System.Drawing.Point(114, 254);
            this.txt_UserCode.Name = "txt_UserCode";
            this.txt_UserCode.Size = new System.Drawing.Size(100, 21);
            this.txt_UserCode.TabIndex = 57;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(251, 256);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 56;
            this.label15.Text = "新农合密码";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(30, 256);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 12);
            this.label14.TabIndex = 55;
            this.label14.Text = "新农合用户名";
            // 
            // txt_UserPass
            // 
            this.txt_UserPass.Location = new System.Drawing.Point(323, 255);
            this.txt_UserPass.Name = "txt_UserPass";
            this.txt_UserPass.Size = new System.Drawing.Size(100, 21);
            this.txt_UserPass.TabIndex = 58;
            // 
            // but_qx
            // 
            this.but_qx.Location = new System.Drawing.Point(339, 304);
            this.but_qx.Name = "but_qx";
            this.but_qx.Size = new System.Drawing.Size(75, 23);
            this.but_qx.TabIndex = 54;
            this.but_qx.Text = "取消";
            this.but_qx.UseVisualStyleBackColor = true;
            this.but_qx.Click += new System.EventHandler(this.but_qx_Click);
            // 
            // but_qd
            // 
            this.but_qd.Location = new System.Drawing.Point(159, 304);
            this.but_qd.Name = "but_qd";
            this.but_qd.Size = new System.Drawing.Size(75, 23);
            this.but_qd.TabIndex = 53;
            this.but_qd.Text = "确定";
            this.but_qd.UseVisualStyleBackColor = true;
            this.but_qd.Click += new System.EventHandler(this.but_qd_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(28, 202);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 48;
            this.label11.Text = "请选择：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 165);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 47;
            this.label10.Text = "治疗方式编码";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(495, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 46;
            this.label9.Text = "kg";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(337, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 45;
            this.label8.Text = "体重";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(221, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 44;
            this.label7.Text = "cm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(72, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 43;
            this.label6.Text = "身高";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 42;
            this.label5.Text = "请输入：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(283, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 41;
            this.label4.Text = "单病种ICD编码";
            // 
            // tbx_jbbm
            // 
            this.tbx_jbbm.Location = new System.Drawing.Point(385, 62);
            this.tbx_jbbm.Name = "tbx_jbbm";
            this.tbx_jbbm.ReadOnly = true;
            this.tbx_jbbm.Size = new System.Drawing.Size(127, 21);
            this.tbx_jbbm.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 39;
            this.label3.Text = "单病种ICD名称";
            // 
            // tbx_jbmc
            // 
            this.tbx_jbmc.Location = new System.Drawing.Point(117, 62);
            this.tbx_jbmc.Name = "tbx_jbmc";
            this.tbx_jbmc.ReadOnly = true;
            this.tbx_jbmc.Size = new System.Drawing.Size(127, 21);
            this.tbx_jbmc.TabIndex = 38;
            // 
            // tbx_sg
            // 
            this.tbx_sg.Location = new System.Drawing.Point(117, 124);
            this.tbx_sg.Name = "tbx_sg";
            this.tbx_sg.Size = new System.Drawing.Size(97, 21);
            this.tbx_sg.TabIndex = 37;
            // 
            // tbx_tz
            // 
            this.tbx_tz.Location = new System.Drawing.Point(385, 124);
            this.tbx_tz.Name = "tbx_tz";
            this.tbx_tz.Size = new System.Drawing.Size(104, 21);
            this.tbx_tz.TabIndex = 36;
            // 
            // tbx_zlfsbm
            // 
            this.tbx_zlfsbm.Location = new System.Drawing.Point(117, 162);
            this.tbx_zlfsbm.Name = "tbx_zlfsbm";
            this.tbx_zlfsbm.Size = new System.Drawing.Size(127, 21);
            this.tbx_zlfsbm.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 34;
            this.label2.Text = "输入简码";
            // 
            // tbx_jbjm
            // 
            this.tbx_jbjm.Location = new System.Drawing.Point(251, 25);
            this.tbx_jbjm.Name = "tbx_jbjm";
            this.tbx_jbjm.Size = new System.Drawing.Size(109, 21);
            this.tbx_jbjm.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(366, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 32;
            this.label1.Text = "就诊号";
            // 
            // tbx_jzh
            // 
            this.tbx_jzh.Location = new System.Drawing.Point(413, 25);
            this.tbx_jzh.Name = "tbx_jzh";
            this.tbx_jzh.ReadOnly = true;
            this.tbx_jzh.Size = new System.Drawing.Size(127, 21);
            this.tbx_jzh.TabIndex = 31;
            // 
            // cmbArea
            // 
            this.cmbArea.Font = new System.Drawing.Font("宋体", 9F);
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(67, 25);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(119, 20);
            this.cmbArea.TabIndex = 85;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 9F);
            this.label13.Location = new System.Drawing.Point(11, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 12);
            this.label13.TabIndex = 84;
            this.label13.Text = "选择区域:";
            // 
            // FrmInpatDiagnosisUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 352);
            this.Controls.Add(this.cmbArea);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.radio_wzw);
            this.Controls.Add(this.radio_yzw);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txt_UserCode);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txt_UserPass);
            this.Controls.Add(this.but_qx);
            this.Controls.Add(this.but_qd);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbx_jbbm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbx_jbmc);
            this.Controls.Add(this.tbx_sg);
            this.Controls.Add(this.tbx_tz);
            this.Controls.Add(this.tbx_zlfsbm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbx_jbjm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbx_jzh);
            this.Name = "FrmInpatDiagnosisUpdate";
            this.Text = "单病种信息上传";
            this.Load += new System.EventHandler(this.FrmInpatDiagnosisUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn jbbm;
        private System.Windows.Forms.DataGridViewTextBoxColumn jbmc;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn zlfsmc;
        private System.Windows.Forms.DataGridViewTextBoxColumn zlfsbm;
        private System.Windows.Forms.RadioButton radio_wzw;
        private System.Windows.Forms.RadioButton radio_yzw;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_UserCode;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txt_UserPass;
        private System.Windows.Forms.Button but_qx;
        private System.Windows.Forms.Button but_qd;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbx_jbbm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbx_jbmc;
        private System.Windows.Forms.TextBox tbx_sg;
        private System.Windows.Forms.TextBox tbx_tz;
        private System.Windows.Forms.TextBox tbx_zlfsbm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_jbjm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_jzh;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Label label13;
    }
}