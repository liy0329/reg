namespace MTREG.medinsur.sjzsyb
{
    partial class Frmgrmxbspxxcx
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
            this.button1 = new System.Windows.Forms.Button();
            this.yb_type = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BAE073 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BKC462 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AKA121 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AAE030 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AAE031 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AKB020 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(293, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "读卡查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // yb_type
            // 
            this.yb_type.FormattingEnabled = true;
            this.yb_type.Location = new System.Drawing.Point(116, 30);
            this.yb_type.Name = "yb_type";
            this.yb_type.Size = new System.Drawing.Size(121, 20);
            this.yb_type.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(25, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "医疗类别：";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(23, 71);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 213);
            this.panel1.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BAE073,
            this.BKC462,
            this.AKA121,
            this.AAE030,
            this.AAE031,
            this.AKB020});
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(525, 207);
            this.dataGridView1.TabIndex = 0;
            // 
            // BAE073
            // 
            this.BAE073.DataPropertyName = "BAE073";
            this.BAE073.HeaderText = "审批编号";
            this.BAE073.Name = "BAE073";
            // 
            // BKC462
            // 
            this.BKC462.DataPropertyName = "BKC462";
            this.BKC462.HeaderText = "病种代码";
            this.BKC462.Name = "BKC462";
            // 
            // AKA121
            // 
            this.AKA121.DataPropertyName = "AKA121";
            this.AKA121.HeaderText = "病种名称";
            this.AKA121.Name = "AKA121";
            // 
            // AAE030
            // 
            this.AAE030.DataPropertyName = "AAE030";
            this.AAE030.HeaderText = "开始时间";
            this.AAE030.Name = "AAE030";
            // 
            // AAE031
            // 
            this.AAE031.DataPropertyName = "AAE031";
            this.AAE031.HeaderText = "终止时间";
            this.AAE031.Name = "AAE031";
            // 
            // AKB020
            // 
            this.AKB020.DataPropertyName = "AKB020";
            this.AKB020.HeaderText = "定点医疗机构编码";
            this.AKB020.Name = "AKB020";
            // 
            // Frmgrmxbspxxcx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 305);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.yb_type);
            this.Controls.Add(this.button1);
            this.Name = "Frmgrmxbspxxcx";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "个人慢性(或特殊)病审批信息查询";
            this.Load += new System.EventHandler(this.Frmgrmxbspxxcx_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox yb_type;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn BAE073;
        private System.Windows.Forms.DataGridViewTextBoxColumn BKC462;
        private System.Windows.Forms.DataGridViewTextBoxColumn AKA121;
        private System.Windows.Forms.DataGridViewTextBoxColumn AAE030;
        private System.Windows.Forms.DataGridViewTextBoxColumn AAE031;
        private System.Windows.Forms.DataGridViewTextBoxColumn AKB020;
    }
}