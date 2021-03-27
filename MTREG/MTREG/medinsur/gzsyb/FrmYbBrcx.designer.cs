namespace MTREG.medinsur.gzsyb
{
    partial class FrmYbBrcx
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
            this.btncx = new System.Windows.Forms.Button();
            this.dgvybbr = new System.Windows.Forms.DataGridView();
            this.hzxm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.csrq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sfzh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tczf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dectzf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gwybx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kxx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxyblx = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerKsrq = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerJsrq = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvybbr)).BeginInit();
            this.SuspendLayout();
            // 
            // btncx
            // 
            this.btncx.Location = new System.Drawing.Point(861, 23);
            this.btncx.Name = "btncx";
            this.btncx.Size = new System.Drawing.Size(84, 26);
            this.btncx.TabIndex = 0;
            this.btncx.Text = "查询";
            this.btncx.UseVisualStyleBackColor = true;
            this.btncx.Click += new System.EventHandler(this.btncx_Click);
            // 
            // dgvybbr
            // 
            this.dgvybbr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvybbr.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hzxm,
            this.grbh,
            this.xb,
            this.csrq,
            this.sfzh,
            this.tczf,
            this.dectzf,
            this.gwybx,
            this.kxx});
            this.dgvybbr.Location = new System.Drawing.Point(49, 70);
            this.dgvybbr.Name = "dgvybbr";
            this.dgvybbr.RowTemplate.Height = 23;
            this.dgvybbr.Size = new System.Drawing.Size(916, 338);
            this.dgvybbr.TabIndex = 1;
            // 
            // hzxm
            // 
            this.hzxm.DataPropertyName = "hzxm";
            this.hzxm.HeaderText = "患者姓名";
            this.hzxm.Name = "hzxm";
            // 
            // grbh
            // 
            this.grbh.DataPropertyName = "grbh";
            this.grbh.HeaderText = "个人编号";
            this.grbh.Name = "grbh";
            // 
            // xb
            // 
            this.xb.DataPropertyName = "xb";
            this.xb.HeaderText = "性别";
            this.xb.Name = "xb";
            // 
            // csrq
            // 
            this.csrq.DataPropertyName = "csrq";
            this.csrq.HeaderText = "出生日期";
            this.csrq.Name = "csrq";
            // 
            // sfzh
            // 
            this.sfzh.DataPropertyName = "sfzh";
            this.sfzh.HeaderText = "身份证号";
            this.sfzh.Name = "sfzh";
            // 
            // tczf
            // 
            this.tczf.DataPropertyName = "tczf";
            this.tczf.HeaderText = "统筹支付";
            this.tczf.Name = "tczf";
            // 
            // dectzf
            // 
            this.dectzf.DataPropertyName = "dectzf";
            this.dectzf.HeaderText = "大额补助";
            this.dectzf.Name = "dectzf";
            // 
            // gwybx
            // 
            this.gwybx.DataPropertyName = "gwybx";
            this.gwybx.HeaderText = "公务员补助";
            this.gwybx.Name = "gwybx";
            // 
            // kxx
            // 
            this.kxx.DataPropertyName = "kxx";
            this.kxx.HeaderText = "卡信息";
            this.kxx.Name = "kxx";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(46, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "医保类型：";
            // 
            // cbxyblx
            // 
            this.cbxyblx.FormattingEnabled = true;
            this.cbxyblx.Location = new System.Drawing.Point(128, 26);
            this.cbxyblx.Name = "cbxyblx";
            this.cbxyblx.Size = new System.Drawing.Size(98, 20);
            this.cbxyblx.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(253, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "开始日期:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(455, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "结束日期:";
            // 
            // dateTimePickerKsrq
            // 
            this.dateTimePickerKsrq.Location = new System.Drawing.Point(318, 25);
            this.dateTimePickerKsrq.Name = "dateTimePickerKsrq";
            this.dateTimePickerKsrq.Size = new System.Drawing.Size(107, 21);
            this.dateTimePickerKsrq.TabIndex = 6;
            // 
            // dateTimePickerJsrq
            // 
            this.dateTimePickerJsrq.Location = new System.Drawing.Point(520, 26);
            this.dateTimePickerJsrq.Name = "dateTimePickerJsrq";
            this.dateTimePickerJsrq.Size = new System.Drawing.Size(109, 21);
            this.dateTimePickerJsrq.TabIndex = 7;
            // 
            // FrmYbBrcx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 460);
            this.Controls.Add(this.dateTimePickerJsrq);
            this.Controls.Add(this.dateTimePickerKsrq);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxyblx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvybbr);
            this.Controls.Add(this.btncx);
            this.Name = "FrmYbBrcx";
            this.Text = "FrmYbBrcx";
            this.Load += new System.EventHandler(this.FrmYbBrcx_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvybbr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btncx;
        private System.Windows.Forms.DataGridView dgvybbr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxyblx;
        private System.Windows.Forms.DataGridViewTextBoxColumn hzxm;
        private System.Windows.Forms.DataGridViewTextBoxColumn grbh;
        private System.Windows.Forms.DataGridViewTextBoxColumn xb;
        private System.Windows.Forms.DataGridViewTextBoxColumn csrq;
        private System.Windows.Forms.DataGridViewTextBoxColumn sfzh;
        private System.Windows.Forms.DataGridViewTextBoxColumn tczf;
        private System.Windows.Forms.DataGridViewTextBoxColumn dectzf;
        private System.Windows.Forms.DataGridViewTextBoxColumn gwybx;
        private System.Windows.Forms.DataGridViewTextBoxColumn kxx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerKsrq;
        private System.Windows.Forms.DateTimePicker dateTimePickerJsrq;
    }
}