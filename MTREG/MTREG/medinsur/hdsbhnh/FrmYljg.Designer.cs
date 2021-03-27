namespace MTREG.medinsur.hdsbhnh
{
    partial class FrmYljg
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
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvHospital = new System.Windows.Forms.DataGridView();
            this.yljgid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jgmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jgmcpy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jgbz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jgnf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cfmlhxmdbz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qhdm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jgdj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sbddlx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spddlx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jglb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sfdd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sfxtmryy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jgzt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnGxypzd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHospital)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbArea
            // 
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(94, 340);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(98, 20);
            this.cmbArea.TabIndex = 17;
            this.cmbArea.SelectedValueChanged += new System.EventHandler(this.cmbArea_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 344);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "区域:";
            // 
            // dgvHospital
            // 
            this.dgvHospital.AllowUserToAddRows = false;
            this.dgvHospital.AllowUserToDeleteRows = false;
            this.dgvHospital.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHospital.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.yljgid,
            this.jgmc,
            this.jgmcpy,
            this.jgbz,
            this.jgnf,
            this.cfmlhxmdbz,
            this.qhdm,
            this.jgdj,
            this.sbddlx,
            this.spddlx,
            this.jglb,
            this.sfdd,
            this.sfxtmryy,
            this.jgzt});
            this.dgvHospital.Location = new System.Drawing.Point(15, 12);
            this.dgvHospital.Name = "dgvHospital";
            this.dgvHospital.ReadOnly = true;
            this.dgvHospital.RowHeadersVisible = false;
            this.dgvHospital.RowTemplate.Height = 23;
            this.dgvHospital.Size = new System.Drawing.Size(642, 308);
            this.dgvHospital.TabIndex = 15;
            // 
            // yljgid
            // 
            this.yljgid.DataPropertyName = "yljgid";
            this.yljgid.HeaderText = "代码";
            this.yljgid.Name = "yljgid";
            this.yljgid.ReadOnly = true;
            // 
            // jgmc
            // 
            this.jgmc.DataPropertyName = "jgmc";
            this.jgmc.HeaderText = "名称";
            this.jgmc.Name = "jgmc";
            this.jgmc.ReadOnly = true;
            // 
            // jgmcpy
            // 
            this.jgmcpy.DataPropertyName = "jgmcpy";
            this.jgmcpy.HeaderText = "拼音";
            this.jgmcpy.Name = "jgmcpy";
            this.jgmcpy.ReadOnly = true;
            // 
            // jgbz
            // 
            this.jgbz.DataPropertyName = "jgbz";
            this.jgbz.HeaderText = "备注";
            this.jgbz.Name = "jgbz";
            this.jgbz.ReadOnly = true;
            // 
            // jgnf
            // 
            this.jgnf.DataPropertyName = "jgnf";
            this.jgnf.HeaderText = "年份";
            this.jgnf.Name = "jgnf";
            this.jgnf.ReadOnly = true;
            // 
            // cfmlhxmdbz
            // 
            this.cfmlhxmdbz.DataPropertyName = "cfmlhxmdbz";
            this.cfmlhxmdbz.HeaderText = "区分目录和项目的标志";
            this.cfmlhxmdbz.Name = "cfmlhxmdbz";
            this.cfmlhxmdbz.ReadOnly = true;
            // 
            // qhdm
            // 
            this.qhdm.DataPropertyName = "qhdm";
            this.qhdm.HeaderText = "区划代码";
            this.qhdm.Name = "qhdm";
            this.qhdm.ReadOnly = true;
            // 
            // jgdj
            // 
            this.jgdj.DataPropertyName = "jgdj";
            this.jgdj.HeaderText = "机构等级";
            this.jgdj.Name = "jgdj";
            this.jgdj.ReadOnly = true;
            // 
            // sbddlx
            // 
            this.sbddlx.DataPropertyName = "sbddlx";
            this.sbddlx.HeaderText = "申报定点类型";
            this.sbddlx.Name = "sbddlx";
            this.sbddlx.ReadOnly = true;
            // 
            // spddlx
            // 
            this.spddlx.DataPropertyName = "spddlx";
            this.spddlx.HeaderText = "审批定点类型";
            this.spddlx.Name = "spddlx";
            this.spddlx.ReadOnly = true;
            // 
            // jglb
            // 
            this.jglb.DataPropertyName = "jglb";
            this.jglb.HeaderText = "机构类别";
            this.jglb.Name = "jglb";
            this.jglb.ReadOnly = true;
            // 
            // sfdd
            // 
            this.sfdd.DataPropertyName = "sfdd";
            this.sfdd.HeaderText = "是否定点";
            this.sfdd.Name = "sfdd";
            this.sfdd.ReadOnly = true;
            // 
            // sfxtmryy
            // 
            this.sfxtmryy.DataPropertyName = "sfxtmryy";
            this.sfxtmryy.HeaderText = "是否系统默认医院";
            this.sfxtmryy.Name = "sfxtmryy";
            this.sfxtmryy.ReadOnly = true;
            // 
            // jgzt
            // 
            this.jgzt.DataPropertyName = "jgzt";
            this.jgzt.HeaderText = "机构状态";
            this.jgzt.Name = "jgzt";
            this.jgzt.ReadOnly = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(490, 337);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 25);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "退出";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnGxypzd
            // 
            this.btnGxypzd.Location = new System.Drawing.Point(274, 337);
            this.btnGxypzd.Name = "btnGxypzd";
            this.btnGxypzd.Size = new System.Drawing.Size(92, 25);
            this.btnGxypzd.TabIndex = 18;
            this.btnGxypzd.Text = "更新医疗机构字典";
            this.btnGxypzd.UseVisualStyleBackColor = true;
            this.btnGxypzd.Click += new System.EventHandler(this.btnGxypzd_Click);
            // 
            // FrmYljg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 384);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnGxypzd);
            this.Controls.Add(this.cmbArea);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvHospital);
            this.Name = "FrmYljg";
            this.Text = "FrmYljg";
            this.Load += new System.EventHandler(this.FrmYljg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHospital)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvHospital;
        private System.Windows.Forms.DataGridViewTextBoxColumn yljgid;
        private System.Windows.Forms.DataGridViewTextBoxColumn jgmc;
        private System.Windows.Forms.DataGridViewTextBoxColumn jgmcpy;
        private System.Windows.Forms.DataGridViewTextBoxColumn jgbz;
        private System.Windows.Forms.DataGridViewTextBoxColumn jgnf;
        private System.Windows.Forms.DataGridViewTextBoxColumn cfmlhxmdbz;
        private System.Windows.Forms.DataGridViewTextBoxColumn qhdm;
        private System.Windows.Forms.DataGridViewTextBoxColumn jgdj;
        private System.Windows.Forms.DataGridViewTextBoxColumn sbddlx;
        private System.Windows.Forms.DataGridViewTextBoxColumn spddlx;
        private System.Windows.Forms.DataGridViewTextBoxColumn jglb;
        private System.Windows.Forms.DataGridViewTextBoxColumn sfdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn sfxtmryy;
        private System.Windows.Forms.DataGridViewTextBoxColumn jgzt;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnGxypzd;
    }
}