namespace MTREG.medinsur.sjzsyb
{
    partial class FrmDepartments
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.AKF001 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AKF003 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AKF002 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AKB020 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BKF075 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AKF015 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AKF008 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BKF005 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BKF006 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BKF061 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AAE013 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGxypzd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AKF001,
            this.AKF003,
            this.AKF002,
            this.AKB020,
            this.BKF075,
            this.AKF015,
            this.AKF008,
            this.BKF005,
            this.BKF006,
            this.BKF061,
            this.AAE013});
            this.dataGridView1.Location = new System.Drawing.Point(12, 105);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(950, 445);
            this.dataGridView1.TabIndex = 0;
            // 
            // AKF001
            // 
            this.AKF001.DataPropertyName = "AKF001";
            this.AKF001.HeaderText = "科室编码";
            this.AKF001.Name = "AKF001";
            // 
            // AKF003
            // 
            this.AKF003.DataPropertyName = "AKF003";
            this.AKF003.HeaderText = "科室代码";
            this.AKF003.Name = "AKF003";
            // 
            // AKF002
            // 
            this.AKF002.DataPropertyName = "AKF002";
            this.AKF002.HeaderText = "科室名称";
            this.AKF002.Name = "AKF002";
            // 
            // AKB020
            // 
            this.AKB020.DataPropertyName = "AKB020";
            this.AKB020.HeaderText = "医疗机构编号";
            this.AKB020.Name = "AKB020";
            // 
            // BKF075
            // 
            this.BKF075.DataPropertyName = "BKF075";
            this.BKF075.HeaderText = "科室分类";
            this.BKF075.Name = "BKF075";
            // 
            // AKF015
            // 
            this.AKF015.DataPropertyName = "AKF015";
            this.AKF015.HeaderText = "床位数";
            this.AKF015.Name = "AKF015";
            // 
            // AKF008
            // 
            this.AKF008.DataPropertyName = "AKF008";
            this.AKF008.HeaderText = "职工数量";
            this.AKF008.Name = "AKF008";
            // 
            // BKF005
            // 
            this.BKF005.DataPropertyName = "BKF005";
            this.BKF005.HeaderText = "负责人";
            this.BKF005.Name = "BKF005";
            // 
            // BKF006
            // 
            this.BKF006.DataPropertyName = "BKF006";
            this.BKF006.HeaderText = "联系电话";
            this.BKF006.Name = "BKF006";
            // 
            // BKF061
            // 
            this.BKF061.DataPropertyName = "BKF061";
            this.BKF061.HeaderText = "业务范围";
            this.BKF061.Name = "BKF061";
            // 
            // AAE013
            // 
            this.AAE013.DataPropertyName = "AAE013";
            this.AAE013.HeaderText = "备注";
            this.AAE013.Name = "AAE013";
            // 
            // btnGxypzd
            // 
            this.btnGxypzd.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnGxypzd.ForeColor = System.Drawing.Color.Red;
            this.btnGxypzd.Location = new System.Drawing.Point(41, 31);
            this.btnGxypzd.Name = "btnGxypzd";
            this.btnGxypzd.Size = new System.Drawing.Size(170, 35);
            this.btnGxypzd.TabIndex = 22;
            this.btnGxypzd.Text = "获取科室";
            this.btnGxypzd.UseVisualStyleBackColor = true;
            this.btnGxypzd.Click += new System.EventHandler(this.btnGxypzd_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(793, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 163;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // FrmDepartments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 562);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGxypzd);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmDepartments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "医保科室下载";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn AKF001;
        private System.Windows.Forms.DataGridViewTextBoxColumn AKF003;
        private System.Windows.Forms.DataGridViewTextBoxColumn AKF002;
        private System.Windows.Forms.DataGridViewTextBoxColumn AKB020;
        private System.Windows.Forms.DataGridViewTextBoxColumn BKF075;
        private System.Windows.Forms.DataGridViewTextBoxColumn AKF015;
        private System.Windows.Forms.DataGridViewTextBoxColumn AKF008;
        private System.Windows.Forms.DataGridViewTextBoxColumn BKF005;
        private System.Windows.Forms.DataGridViewTextBoxColumn BKF006;
        private System.Windows.Forms.DataGridViewTextBoxColumn BKF061;
        private System.Windows.Forms.DataGridViewTextBoxColumn AAE013;
        private System.Windows.Forms.Button btnGxypzd;
        private System.Windows.Forms.Label label1;
    }
}