namespace MTREG.medinsur.sjzsyb
{
    partial class FrmDownloadContrast
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
            this.radioButton_yp = new System.Windows.Forms.RadioButton();
            this.radioButton_fw = new System.Windows.Forms.RadioButton();
            this.radioButton_zl = new System.Windows.Forms.RadioButton();
            this.Starttime = new System.Windows.Forms.DateTimePicker();
            this.Endtime = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_page = new System.Windows.Forms.TextBox();
            this.download = new System.Windows.Forms.Button();
            this.tb_ybxmbmgl = new System.Windows.Forms.TextBox();
            this.tb_ybxmmcgl = new System.Windows.Forms.TextBox();
            this.tb_ybpymgl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnImportExcel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_yp);
            this.groupBox1.Controls.Add(this.radioButton_fw);
            this.groupBox1.Controls.Add(this.radioButton_zl);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 39);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            // 
            // radioButton_yp
            // 
            this.radioButton_yp.AutoSize = true;
            this.radioButton_yp.Checked = true;
            this.radioButton_yp.Location = new System.Drawing.Point(19, 15);
            this.radioButton_yp.Name = "radioButton_yp";
            this.radioButton_yp.Size = new System.Drawing.Size(47, 16);
            this.radioButton_yp.TabIndex = 3;
            this.radioButton_yp.TabStop = true;
            this.radioButton_yp.Text = "药品";
            this.radioButton_yp.UseVisualStyleBackColor = true;
            // 
            // radioButton_fw
            // 
            this.radioButton_fw.AutoSize = true;
            this.radioButton_fw.Location = new System.Drawing.Point(186, 15);
            this.radioButton_fw.Name = "radioButton_fw";
            this.radioButton_fw.Size = new System.Drawing.Size(71, 16);
            this.radioButton_fw.TabIndex = 5;
            this.radioButton_fw.Text = "服务设施";
            this.radioButton_fw.UseVisualStyleBackColor = true;
            // 
            // radioButton_zl
            // 
            this.radioButton_zl.AutoSize = true;
            this.radioButton_zl.Location = new System.Drawing.Point(102, 15);
            this.radioButton_zl.Name = "radioButton_zl";
            this.radioButton_zl.Size = new System.Drawing.Size(47, 16);
            this.radioButton_zl.TabIndex = 4;
            this.radioButton_zl.Text = "诊疗";
            this.radioButton_zl.UseVisualStyleBackColor = true;
            // 
            // Starttime
            // 
            this.Starttime.Location = new System.Drawing.Point(86, 14);
            this.Starttime.Name = "Starttime";
            this.Starttime.Size = new System.Drawing.Size(130, 21);
            this.Starttime.TabIndex = 38;
            // 
            // Endtime
            // 
            this.Endtime.Location = new System.Drawing.Point(254, 14);
            this.Endtime.Name = "Endtime";
            this.Endtime.Size = new System.Drawing.Size(130, 21);
            this.Endtime.TabIndex = 40;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.Endtime);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.Starttime);
            this.groupBox2.Location = new System.Drawing.Point(287, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(408, 39);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F);
            this.label2.Location = new System.Drawing.Point(226, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 15);
            this.label2.TabIndex = 39;
            this.label2.Text = "至";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(16, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "下载范围";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 148);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(802, 463);
            this.dataGridView1.TabIndex = 42;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 11F);
            this.label3.Location = new System.Drawing.Point(538, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 43;
            this.label3.Text = "页码：";
            // 
            // textBox_page
            // 
            this.textBox_page.Location = new System.Drawing.Point(588, 64);
            this.textBox_page.Name = "textBox_page";
            this.textBox_page.Size = new System.Drawing.Size(100, 21);
            this.textBox_page.TabIndex = 44;
            // 
            // download
            // 
            this.download.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.download.ForeColor = System.Drawing.Color.Red;
            this.download.Location = new System.Drawing.Point(716, 17);
            this.download.Name = "download";
            this.download.Size = new System.Drawing.Size(98, 35);
            this.download.TabIndex = 45;
            this.download.Text = "下载最新";
            this.download.UseVisualStyleBackColor = true;
            this.download.Click += new System.EventHandler(this.download_Click);
            // 
            // tb_ybxmbmgl
            // 
            this.tb_ybxmbmgl.Location = new System.Drawing.Point(111, 60);
            this.tb_ybxmbmgl.Margin = new System.Windows.Forms.Padding(2);
            this.tb_ybxmbmgl.Name = "tb_ybxmbmgl";
            this.tb_ybxmbmgl.Size = new System.Drawing.Size(152, 21);
            this.tb_ybxmbmgl.TabIndex = 49;
            this.tb_ybxmbmgl.TextChanged += new System.EventHandler(this.tb_ybpymgl_TextChanged);
            // 
            // tb_ybxmmcgl
            // 
            this.tb_ybxmmcgl.Location = new System.Drawing.Point(111, 39);
            this.tb_ybxmmcgl.Margin = new System.Windows.Forms.Padding(2);
            this.tb_ybxmmcgl.Name = "tb_ybxmmcgl";
            this.tb_ybxmmcgl.Size = new System.Drawing.Size(152, 21);
            this.tb_ybxmmcgl.TabIndex = 50;
            this.tb_ybxmmcgl.TextChanged += new System.EventHandler(this.tb_ybpymgl_TextChanged);
            // 
            // tb_ybpymgl
            // 
            this.tb_ybpymgl.Location = new System.Drawing.Point(111, 16);
            this.tb_ybpymgl.Margin = new System.Windows.Forms.Padding(2);
            this.tb_ybpymgl.Name = "tb_ybpymgl";
            this.tb_ybpymgl.Size = new System.Drawing.Size(152, 21);
            this.tb_ybpymgl.TabIndex = 51;
            this.tb_ybpymgl.TextChanged += new System.EventHandler(this.tb_ybpymgl_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 63);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 12);
            this.label4.TabIndex = 47;
            this.label4.Text = "his项目编码过滤";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 40);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 12);
            this.label5.TabIndex = 46;
            this.label5.Text = "his项目名称过滤";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 19);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 12);
            this.label6.TabIndex = 48;
            this.label6.Text = "his拼音码过滤";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tb_ybxmbmgl);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.tb_ybxmmcgl);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.tb_ybpymgl);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(12, 56);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(266, 87);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Green;
            this.label7.Font = new System.Drawing.Font("宋体", 13F);
            this.label7.Location = new System.Drawing.Point(679, 128);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 18);
            this.label7.TabIndex = 46;
            this.label7.Text = "共有xxx条";
            this.label7.Visible = false;
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnImportExcel.Location = new System.Drawing.Point(716, 62);
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(98, 26);
            this.btnImportExcel.TabIndex = 89;
            this.btnImportExcel.Text = "导出Excel";
            this.btnImportExcel.UseVisualStyleBackColor = true;
            this.btnImportExcel.Click += new System.EventHandler(this.btnImportExcel_Click);
            // 
            // FrmDownloadContrast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 623);
            this.Controls.Add(this.btnImportExcel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.download);
            this.Controls.Add(this.textBox_page);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmDownloadContrast";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "三目对照关系下载";
            this.Load += new System.EventHandler(this.FrmDownloadContrast_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_yp;
        private System.Windows.Forms.RadioButton radioButton_fw;
        private System.Windows.Forms.RadioButton radioButton_zl;
        private System.Windows.Forms.DateTimePicker Starttime;
        private System.Windows.Forms.DateTimePicker Endtime;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_page;
        private System.Windows.Forms.Button download;
        private System.Windows.Forms.TextBox tb_ybxmbmgl;
        private System.Windows.Forms.TextBox tb_ybxmmcgl;
        private System.Windows.Forms.TextBox tb_ybpymgl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnImportExcel;
    }
}