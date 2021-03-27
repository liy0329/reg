namespace MTREG.medinsur.gzsyb
{
    partial class FrmMain2
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
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPagerydj = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnWscyinfo = new System.Windows.Forms.Button();
            this.btnWsryinfo = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvdjrs = new System.Windows.Forms.DataGridView();
            this.dgvtxtZyjlzyh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtxtFullname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtxtGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtxtOrg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtxtBs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtxtBc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtxtylfkfs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtxtZyjlrysj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvZyjlbah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtxtOwnerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mtzyjl_iid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ylfkfs_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button9 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.btnSyb = new System.Windows.Forms.Button();
            this.btnSybsczd = new System.Windows.Forms.Button();
            this.tabControlMain.SuspendLayout();
            this.tabPagerydj.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdjrs)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPagerydj);
            this.tabControlMain.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControlMain.Location = new System.Drawing.Point(12, 5);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(961, 650);
            this.tabControlMain.TabIndex = 5;
            // 
            // tabPagerydj
            // 
            this.tabPagerydj.Controls.Add(this.btnSybsczd);
            this.tabPagerydj.Controls.Add(this.btnSyb);
            this.tabPagerydj.Controls.Add(this.button2);
            this.tabPagerydj.Controls.Add(this.button1);
            this.tabPagerydj.Controls.Add(this.btnWscyinfo);
            this.tabPagerydj.Controls.Add(this.btnWsryinfo);
            this.tabPagerydj.Controls.Add(this.label9);
            this.tabPagerydj.Controls.Add(this.dgvdjrs);
            this.tabPagerydj.Controls.Add(this.button9);
            this.tabPagerydj.Controls.Add(this.button7);
            this.tabPagerydj.Controls.Add(this.button6);
            this.tabPagerydj.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPagerydj.Location = new System.Drawing.Point(4, 25);
            this.tabPagerydj.Name = "tabPagerydj";
            this.tabPagerydj.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagerydj.Size = new System.Drawing.Size(953, 621);
            this.tabPagerydj.TabIndex = 0;
            this.tabPagerydj.Text = "入院登记";
            this.tabPagerydj.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(284, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(141, 23);
            this.button2.TabIndex = 32;
            this.button2.Text = "出院诊断未上传";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(104, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 23);
            this.button1.TabIndex = 31;
            this.button1.Text = "入院诊断未上传";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // btnWscyinfo
            // 
            this.btnWscyinfo.Location = new System.Drawing.Point(374, 564);
            this.btnWscyinfo.Name = "btnWscyinfo";
            this.btnWscyinfo.Size = new System.Drawing.Size(163, 23);
            this.btnWscyinfo.TabIndex = 30;
            this.btnWscyinfo.Text = "市医保完善出院诊断";
            this.btnWscyinfo.UseVisualStyleBackColor = true;
            this.btnWscyinfo.Click += new System.EventHandler(this.btnWscyinfo_Click);
            // 
            // btnWsryinfo
            // 
            this.btnWsryinfo.Location = new System.Drawing.Point(164, 563);
            this.btnWsryinfo.Name = "btnWsryinfo";
            this.btnWsryinfo.Size = new System.Drawing.Size(164, 25);
            this.btnWsryinfo.TabIndex = 29;
            this.btnWsryinfo.Text = "市医保完善入院诊断";
            this.btnWsryinfo.UseVisualStyleBackColor = true;
            this.btnWsryinfo.Click += new System.EventHandler(this.btnWsryinfo_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(-206, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 16);
            this.label9.TabIndex = 5;
            this.label9.Text = "床号:";
            // 
            // dgvdjrs
            // 
            this.dgvdjrs.AllowUserToResizeRows = false;
            this.dgvdjrs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdjrs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvtxtZyjlzyh,
            this.dgvtxtFullname,
            this.dgvtxtGender,
            this.dgvtxtOrg,
            this.dgvtxtBs,
            this.dgvtxtBc,
            this.dgvtxtylfkfs,
            this.dgvtxtZyjlrysj,
            this.dgvZyjlbah,
            this.dgvtxtOwnerName,
            this.mtzyjl_iid,
            this.ylfkfs_1});
            this.dgvdjrs.Location = new System.Drawing.Point(15, 47);
            this.dgvdjrs.MultiSelect = false;
            this.dgvdjrs.Name = "dgvdjrs";
            this.dgvdjrs.ReadOnly = true;
            this.dgvdjrs.RowHeadersVisible = false;
            this.dgvdjrs.RowTemplate.Height = 23;
            this.dgvdjrs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvdjrs.Size = new System.Drawing.Size(922, 510);
            this.dgvdjrs.TabIndex = 0;
            // 
            // dgvtxtZyjlzyh
            // 
            this.dgvtxtZyjlzyh.DataPropertyName = "zyh";
            this.dgvtxtZyjlzyh.Frozen = true;
            this.dgvtxtZyjlzyh.HeaderText = "住院号";
            this.dgvtxtZyjlzyh.Name = "dgvtxtZyjlzyh";
            this.dgvtxtZyjlzyh.ReadOnly = true;
            // 
            // dgvtxtFullname
            // 
            this.dgvtxtFullname.DataPropertyName = "Fullname";
            this.dgvtxtFullname.Frozen = true;
            this.dgvtxtFullname.HeaderText = "姓名";
            this.dgvtxtFullname.Name = "dgvtxtFullname";
            this.dgvtxtFullname.ReadOnly = true;
            // 
            // dgvtxtGender
            // 
            this.dgvtxtGender.DataPropertyName = "Gender";
            this.dgvtxtGender.HeaderText = "性别";
            this.dgvtxtGender.Name = "dgvtxtGender";
            this.dgvtxtGender.ReadOnly = true;
            // 
            // dgvtxtOrg
            // 
            this.dgvtxtOrg.DataPropertyName = "orgName";
            this.dgvtxtOrg.HeaderText = "科室";
            this.dgvtxtOrg.Name = "dgvtxtOrg";
            this.dgvtxtOrg.ReadOnly = true;
            // 
            // dgvtxtBs
            // 
            this.dgvtxtBs.DataPropertyName = "bs";
            this.dgvtxtBs.HeaderText = "病室";
            this.dgvtxtBs.Name = "dgvtxtBs";
            this.dgvtxtBs.ReadOnly = true;
            // 
            // dgvtxtBc
            // 
            this.dgvtxtBc.DataPropertyName = "bc";
            this.dgvtxtBc.HeaderText = "床号";
            this.dgvtxtBc.Name = "dgvtxtBc";
            this.dgvtxtBc.ReadOnly = true;
            // 
            // dgvtxtylfkfs
            // 
            this.dgvtxtylfkfs.DataPropertyName = "ylfkfsname";
            this.dgvtxtylfkfs.HeaderText = "医疗付款方式";
            this.dgvtxtylfkfs.Name = "dgvtxtylfkfs";
            this.dgvtxtylfkfs.ReadOnly = true;
            // 
            // dgvtxtZyjlrysj
            // 
            this.dgvtxtZyjlrysj.DataPropertyName = "rysj";
            this.dgvtxtZyjlrysj.HeaderText = "入院时间";
            this.dgvtxtZyjlrysj.Name = "dgvtxtZyjlrysj";
            this.dgvtxtZyjlrysj.ReadOnly = true;
            // 
            // dgvZyjlbah
            // 
            this.dgvZyjlbah.DataPropertyName = "bah";
            this.dgvZyjlbah.HeaderText = "病案号";
            this.dgvZyjlbah.Name = "dgvZyjlbah";
            this.dgvZyjlbah.ReadOnly = true;
            // 
            // dgvtxtOwnerName
            // 
            this.dgvtxtOwnerName.DataPropertyName = "ownerName";
            this.dgvtxtOwnerName.HeaderText = " 记录者";
            this.dgvtxtOwnerName.Name = "dgvtxtOwnerName";
            this.dgvtxtOwnerName.ReadOnly = true;
            // 
            // mtzyjl_iid
            // 
            this.mtzyjl_iid.DataPropertyName = "mtzyjl_iid";
            this.mtzyjl_iid.HeaderText = "mtzyjl_iid";
            this.mtzyjl_iid.Name = "mtzyjl_iid";
            this.mtzyjl_iid.ReadOnly = true;
            this.mtzyjl_iid.Visible = false;
            // 
            // ylfkfs_1
            // 
            this.ylfkfs_1.DataPropertyName = "ylfkfs";
            this.ylfkfs_1.HeaderText = "医疗付款方式";
            this.ylfkfs_1.Name = "ylfkfs_1";
            this.ylfkfs_1.ReadOnly = true;
            this.ylfkfs_1.Visible = false;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(560, 434);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(126, 23);
            this.button9.TabIndex = 23;
            this.button9.Text = "入院办理查询";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(321, 434);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(185, 25);
            this.button7.TabIndex = 22;
            this.button7.Text = "入院办理状态不定查询";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(724, 434);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(103, 23);
            this.button6.TabIndex = 21;
            this.button6.Text = "确认入院登记";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // btnSyb
            // 
            this.btnSyb.Location = new System.Drawing.Point(480, 18);
            this.btnSyb.Name = "btnSyb";
            this.btnSyb.Size = new System.Drawing.Size(175, 23);
            this.btnSyb.TabIndex = 33;
            this.btnSyb.Text = "省医保诊断未上传";
            this.btnSyb.UseVisualStyleBackColor = true;
            this.btnSyb.Click += new System.EventHandler(this.btnSyb_Click);
            // 
            // btnSybsczd
            // 
            this.btnSybsczd.Enabled = false;
            this.btnSybsczd.Location = new System.Drawing.Point(602, 565);
            this.btnSybsczd.Name = "btnSybsczd";
            this.btnSybsczd.Size = new System.Drawing.Size(163, 23);
            this.btnSybsczd.TabIndex = 34;
            this.btnSybsczd.Text = "省医保完善出院诊断";
            this.btnSybsczd.UseVisualStyleBackColor = true;
            this.btnSybsczd.Click += new System.EventHandler(this.btnSybsczd_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 668);
            this.Controls.Add(this.tabControlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "住院";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.tabControlMain.ResumeLayout(false);
            this.tabPagerydj.ResumeLayout(false);
            this.tabPagerydj.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdjrs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPagerydj;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvdjrs;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtZyjlzyh;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtFullname;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtOrg;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtBs;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtBc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtylfkfs;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtZyjlrysj;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvZyjlbah;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtOwnerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn mtzyjl_iid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ylfkfs_1;
        private System.Windows.Forms.Button btnWsryinfo;
        private System.Windows.Forms.Button btnWscyinfo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSybsczd;
        private System.Windows.Forms.Button btnSyb;
       

    }
}