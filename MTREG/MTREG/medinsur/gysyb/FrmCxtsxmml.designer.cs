namespace MTREG.medinsur.gysyb.clinic
{
    partial class FrmCxtsxmml
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnCx = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.xmbm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zfbl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xmlb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ksrq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jsrq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(33, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "医保编码";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.textBox1.Location = new System.Drawing.Point(115, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(235, 26);
            this.textBox1.TabIndex = 1;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.checkBox1.Location = new System.Drawing.Point(358, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(163, 20);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "只包含未失效项目";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnCx
            // 
            this.btnCx.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btnCx.Location = new System.Drawing.Point(658, 6);
            this.btnCx.Name = "btnCx";
            this.btnCx.Size = new System.Drawing.Size(75, 31);
            this.btnCx.TabIndex = 4;
            this.btnCx.Text = "查询";
            this.btnCx.UseVisualStyleBackColor = true;
            this.btnCx.Click += new System.EventHandler(this.btnCx_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.xmbm,
            this.zfbl,
            this.xmlb,
            this.ksrq,
            this.jsrq});
            this.dataGridView1.Location = new System.Drawing.Point(28, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(743, 387);
            this.dataGridView1.TabIndex = 5;
            // 
            // xmbm
            // 
            this.xmbm.DataPropertyName = "itemcode";
            this.xmbm.HeaderText = "医保编码";
            this.xmbm.Name = "xmbm";
            this.xmbm.ReadOnly = true;
            this.xmbm.Width = 150;
            // 
            // zfbl
            // 
            this.zfbl.DataPropertyName = "selfrate";
            this.zfbl.HeaderText = "自付比例";
            this.zfbl.Name = "zfbl";
            this.zfbl.ReadOnly = true;
            this.zfbl.Width = 80;
            // 
            // xmlb
            // 
            this.xmlb.DataPropertyName = "specitemtype";
            this.xmlb.HeaderText = "五定项目类别";
            this.xmlb.Name = "xmlb";
            this.xmlb.ReadOnly = true;
            // 
            // ksrq
            // 
            this.ksrq.DataPropertyName = "startdate";
            this.ksrq.HeaderText = "开始生效日期";
            this.ksrq.Name = "ksrq";
            this.ksrq.ReadOnly = true;
            this.ksrq.Width = 150;
            // 
            // jsrq
            // 
            this.jsrq.DataPropertyName = "enddate";
            this.jsrq.HeaderText = "结束生效日期";
            this.jsrq.Name = "jsrq";
            this.jsrq.ReadOnly = true;
            this.jsrq.Width = 150;
            // 
            // FrmCxtsxmml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 451);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnCx);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "FrmCxtsxmml";
            this.Text = "查询五定特殊项目目录";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnCx;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn xmbm;
        private System.Windows.Forms.DataGridViewTextBoxColumn zfbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn xmlb;
        private System.Windows.Forms.DataGridViewTextBoxColumn ksrq;
        private System.Windows.Forms.DataGridViewTextBoxColumn jsrq;
    }
}