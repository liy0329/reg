﻿namespace MTREG.medinsur
{
    partial class frmZycjfysc
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
            this.btn_ypqbb = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Tbx_tsxx = new System.Windows.Forms.TextBox();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_ypqb = new System.Windows.Forms.Button();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFeeUpLoad = new System.Windows.Forms.Label();
            this.buttonKssc = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonTc = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_ypqbb
            // 
            this.btn_ypqbb.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ypqbb.Location = new System.Drawing.Point(165, 481);
            this.btn_ypqbb.Name = "btn_ypqbb";
            this.btn_ypqbb.Size = new System.Drawing.Size(128, 24);
            this.btn_ypqbb.TabIndex = 171;
            this.btn_ypqbb.Text = "限制药品全不报";
            this.btn_ypqbb.UseVisualStyleBackColor = true;
            this.btn_ypqbb.Click += new System.EventHandler(this.btn_ypqbb_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Tbx_tsxx);
            this.groupBox3.Location = new System.Drawing.Point(600, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(438, 496);
            this.groupBox3.TabIndex = 169;
            this.groupBox3.TabStop = false;
            // 
            // Tbx_tsxx
            // 
            this.Tbx_tsxx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tbx_tsxx.Location = new System.Drawing.Point(3, 17);
            this.Tbx_tsxx.Multiline = true;
            this.Tbx_tsxx.Name = "Tbx_tsxx";
            this.Tbx_tsxx.ReadOnly = true;
            this.Tbx_tsxx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Tbx_tsxx.Size = new System.Drawing.Size(432, 476);
            this.Tbx_tsxx.TabIndex = 0;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "ys";
            this.Column5.HeaderText = "医生";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "ks";
            this.Column4.HeaderText = "科室";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // btn_ypqb
            // 
            this.btn_ypqb.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ypqb.Location = new System.Drawing.Point(21, 481);
            this.btn_ypqb.Name = "btn_ypqb";
            this.btn_ypqb.Size = new System.Drawing.Size(128, 24);
            this.btn_ypqb.TabIndex = 170;
            this.btn_ypqb.Text = "限制药品全报";
            this.btn_ypqb.UseVisualStyleBackColor = true;
            this.btn_ypqb.Click += new System.EventHandler(this.btn_ypqb_Click);
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ryrq";
            this.Column3.HeaderText = "入院时间";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "xm";
            this.Column2.HeaderText = "姓名";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(17, 443);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(577, 18);
            this.label1.TabIndex = 168;
            this.label1.Text = "0";
            // 
            // lblFeeUpLoad
            // 
            this.lblFeeUpLoad.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFeeUpLoad.ForeColor = System.Drawing.Color.Blue;
            this.lblFeeUpLoad.Location = new System.Drawing.Point(13, 417);
            this.lblFeeUpLoad.Name = "lblFeeUpLoad";
            this.lblFeeUpLoad.Size = new System.Drawing.Size(581, 18);
            this.lblFeeUpLoad.TabIndex = 167;
            this.lblFeeUpLoad.Text = "上传情况：";
            // 
            // buttonKssc
            // 
            this.buttonKssc.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonKssc.Location = new System.Drawing.Point(330, 478);
            this.buttonKssc.Name = "buttonKssc";
            this.buttonKssc.Size = new System.Drawing.Size(101, 30);
            this.buttonKssc.TabIndex = 164;
            this.buttonKssc.Text = "开始上传";
            this.buttonKssc.UseVisualStyleBackColor = true;
            this.buttonKssc.Click += new System.EventHandler(this.buttonKssc_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iid,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView1.Location = new System.Drawing.Point(16, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(578, 392);
            this.dataGridView1.TabIndex = 166;
            // 
            // iid
            // 
            this.iid.DataPropertyName = "iid";
            this.iid.HeaderText = "iid";
            this.iid.Name = "iid";
            this.iid.ReadOnly = true;
            this.iid.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "zyh";
            this.Column1.HeaderText = "住院号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // buttonTc
            // 
            this.buttonTc.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonTc.Location = new System.Drawing.Point(488, 478);
            this.buttonTc.Name = "buttonTc";
            this.buttonTc.Size = new System.Drawing.Size(101, 30);
            this.buttonTc.TabIndex = 165;
            this.buttonTc.Text = "退出";
            this.buttonTc.UseVisualStyleBackColor = true;
            this.buttonTc.Click += new System.EventHandler(this.buttonTc_Click);
            // 
            // frmZycjfysc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1051, 521);
            this.Controls.Add(this.btn_ypqbb);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btn_ypqb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFeeUpLoad);
            this.Controls.Add(this.buttonKssc);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonTc);
            this.Name = "frmZycjfysc";
            this.Text = "住院城居费用上传【限制审批按钮请慎用！】";
            this.Load += new System.EventHandler(this.frmZycjfysc_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_ypqbb;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox Tbx_tsxx;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button btn_ypqb;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFeeUpLoad;
        private System.Windows.Forms.Button buttonKssc;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button buttonTc;
    }
}