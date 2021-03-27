namespace MTREG.medinsur.ahsjk
{
    partial class FrmDownTreat
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
            this.label4 = new System.Windows.Forms.Label();
            this.txt_UserPass = new System.Windows.Forms.TextBox();
            this.txt_UserCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.but_tc = new System.Windows.Forms.Button();
            this.but_dcExcel = new System.Windows.Forms.Button();
            this.but_xz = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_nf = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dbzicdbm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yl5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zlfsmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dbzicdmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zlfsbm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yl4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yl1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yl3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.yl2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "新农合用户密码:";
            // 
            // txt_UserPass
            // 
            this.txt_UserPass.Location = new System.Drawing.Point(336, 39);
            this.txt_UserPass.Name = "txt_UserPass";
            this.txt_UserPass.Size = new System.Drawing.Size(100, 21);
            this.txt_UserPass.TabIndex = 20;
            // 
            // txt_UserCode
            // 
            this.txt_UserCode.Location = new System.Drawing.Point(130, 39);
            this.txt_UserCode.Name = "txt_UserCode";
            this.txt_UserCode.Size = new System.Drawing.Size(100, 21);
            this.txt_UserCode.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "新农合用户名:";
            // 
            // but_tc
            // 
            this.but_tc.Location = new System.Drawing.Point(445, 519);
            this.but_tc.Name = "but_tc";
            this.but_tc.Size = new System.Drawing.Size(75, 23);
            this.but_tc.TabIndex = 17;
            this.but_tc.Text = "退出";
            this.but_tc.UseVisualStyleBackColor = true;
            // 
            // but_dcExcel
            // 
            this.but_dcExcel.Location = new System.Drawing.Point(256, 519);
            this.but_dcExcel.Name = "but_dcExcel";
            this.but_dcExcel.Size = new System.Drawing.Size(75, 23);
            this.but_dcExcel.TabIndex = 16;
            this.but_dcExcel.Text = "导出Excel";
            this.but_dcExcel.UseVisualStyleBackColor = true;
            // 
            // but_xz
            // 
            this.but_xz.Location = new System.Drawing.Point(570, 31);
            this.but_xz.Name = "but_xz";
            this.but_xz.Size = new System.Drawing.Size(132, 23);
            this.but_xz.TabIndex = 15;
            this.but_xz.Text = "下载单病种治疗方式";
            this.but_xz.UseVisualStyleBackColor = true;
            this.but_xz.Click += new System.EventHandler(this.but_xz_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "输入年份(4位数):";
            // 
            // tbx_nf
            // 
            this.tbx_nf.Location = new System.Drawing.Point(130, 12);
            this.tbx_nf.Name = "tbx_nf";
            this.tbx_nf.Size = new System.Drawing.Size(100, 21);
            this.tbx_nf.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(282, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "单病种治疗方式列表";
            // 
            // dbzicdbm
            // 
            this.dbzicdbm.DataPropertyName = "dbzicdbm";
            this.dbzicdbm.HeaderText = "单病种ICD编码";
            this.dbzicdbm.Name = "dbzicdbm";
            this.dbzicdbm.ReadOnly = true;
            this.dbzicdbm.Width = 120;
            // 
            // yl5
            // 
            this.yl5.DataPropertyName = "yl5";
            this.yl5.HeaderText = "预留5";
            this.yl5.Name = "yl5";
            this.yl5.ReadOnly = true;
            // 
            // zlfsmc
            // 
            this.zlfsmc.DataPropertyName = "zlfsmc";
            this.zlfsmc.HeaderText = "治疗方式名称";
            this.zlfsmc.Name = "zlfsmc";
            this.zlfsmc.ReadOnly = true;
            this.zlfsmc.Width = 120;
            // 
            // dbzicdmc
            // 
            this.dbzicdmc.DataPropertyName = "dbzicdmc";
            this.dbzicdmc.HeaderText = "单病种ICD名称";
            this.dbzicdmc.Name = "dbzicdmc";
            this.dbzicdmc.ReadOnly = true;
            this.dbzicdmc.Width = 120;
            // 
            // zlfsbm
            // 
            this.zlfsbm.DataPropertyName = "zlfsbm";
            this.zlfsbm.HeaderText = "治疗方式编码";
            this.zlfsbm.Name = "zlfsbm";
            this.zlfsbm.ReadOnly = true;
            this.zlfsbm.Width = 120;
            // 
            // yl4
            // 
            this.yl4.DataPropertyName = "yl4";
            this.yl4.HeaderText = "预留4";
            this.yl4.Name = "yl4";
            this.yl4.ReadOnly = true;
            // 
            // yl1
            // 
            this.yl1.DataPropertyName = "yl1";
            this.yl1.HeaderText = "预留1";
            this.yl1.Name = "yl1";
            this.yl1.ReadOnly = true;
            // 
            // yl3
            // 
            this.yl3.DataPropertyName = "yl3";
            this.yl3.HeaderText = "预留3";
            this.yl3.Name = "yl3";
            this.yl3.ReadOnly = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.zlfsbm,
            this.zlfsmc,
            this.dbzicdbm,
            this.dbzicdmc,
            this.yl1,
            this.yl2,
            this.yl3,
            this.yl4,
            this.yl5});
            this.dataGridView1.Location = new System.Drawing.Point(-2, 99);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(751, 398);
            this.dataGridView1.TabIndex = 11;
            // 
            // yl2
            // 
            this.yl2.DataPropertyName = "yl2";
            this.yl2.HeaderText = "预留2";
            this.yl2.Name = "yl2";
            this.yl2.ReadOnly = true;
            // 
            // cmbArea
            // 
            this.cmbArea.Font = new System.Drawing.Font("宋体", 9F);
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(336, 5);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(119, 20);
            this.cmbArea.TabIndex = 83;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 9F);
            this.label11.Location = new System.Drawing.Point(280, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 82;
            this.label11.Text = "选择区域:";
            // 
            // FrmDownTreat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 555);
            this.Controls.Add(this.cmbArea);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_UserPass);
            this.Controls.Add(this.txt_UserCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.but_tc);
            this.Controls.Add(this.but_dcExcel);
            this.Controls.Add(this.but_xz);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbx_nf);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmDownTreat";
            this.Text = "FrmDownTreat";
            this.Load += new System.EventHandler(this.FrmDownTreat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_UserPass;
        private System.Windows.Forms.TextBox txt_UserCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button but_tc;
        private System.Windows.Forms.Button but_dcExcel;
        private System.Windows.Forms.Button but_xz;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_nf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dbzicdbm;
        private System.Windows.Forms.DataGridViewTextBoxColumn yl5;
        private System.Windows.Forms.DataGridViewTextBoxColumn zlfsmc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dbzicdmc;
        private System.Windows.Forms.DataGridViewTextBoxColumn zlfsbm;
        private System.Windows.Forms.DataGridViewTextBoxColumn yl4;
        private System.Windows.Forms.DataGridViewTextBoxColumn yl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn yl3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn yl2;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Label label11;

    }
}