namespace MTREG.clintab
{
    partial class FrmClicTabManage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label15 = new System.Windows.Forms.Label();
            this.dtpEtime = new System.Windows.Forms.DateTimePicker();
            this.dtpStime = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.cmbDpt = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRetreatSettle = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.tcTab = new System.Windows.Forms.TabControl();
            this.tpClinic = new System.Windows.Forms.TabPage();
            this.dgvClinicTab = new System.Windows.Forms.DataGridView();
            this.tpIhsp = new System.Windows.Forms.TabPage();
            this.dgvTabAccount = new System.Windows.Forms.DataGridView();
            this.tcTab.SuspendLayout();
            this.tpClinic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClinicTab)).BeginInit();
            this.tpIhsp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 11F);
            this.label15.Location = new System.Drawing.Point(219, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(22, 15);
            this.label15.TabIndex = 90;
            this.label15.Text = "至";
            // 
            // dtpEtime
            // 
            this.dtpEtime.CustomFormat = "yyyy-MM-dd";
            this.dtpEtime.Font = new System.Drawing.Font("宋体", 11F);
            this.dtpEtime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEtime.Location = new System.Drawing.Point(247, 5);
            this.dtpEtime.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dtpEtime.Name = "dtpEtime";
            this.dtpEtime.Size = new System.Drawing.Size(121, 24);
            this.dtpEtime.TabIndex = 88;
            // 
            // dtpStime
            // 
            this.dtpStime.CustomFormat = "yyyy-MM-dd";
            this.dtpStime.Font = new System.Drawing.Font("宋体", 11F);
            this.dtpStime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStime.Location = new System.Drawing.Point(94, 5);
            this.dtpStime.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dtpStime.Name = "dtpStime";
            this.dtpStime.Size = new System.Drawing.Size(117, 24);
            this.dtpStime.TabIndex = 87;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 11F);
            this.label18.Location = new System.Drawing.Point(12, 9);
            this.label18.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(75, 15);
            this.label18.TabIndex = 89;
            this.label18.Text = "日结时间:";
            // 
            // cmbDpt
            // 
            this.cmbDpt.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbDpt.FormattingEnabled = true;
            this.cmbDpt.ItemHeight = 15;
            this.cmbDpt.Location = new System.Drawing.Point(476, 6);
            this.cmbDpt.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cmbDpt.Name = "cmbDpt";
            this.cmbDpt.Size = new System.Drawing.Size(110, 23);
            this.cmbDpt.TabIndex = 97;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(404, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 93;
            this.label1.Text = "科室汇总:";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("宋体", 11F);
            this.btnSearch.Location = new System.Drawing.Point(503, 34);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(72, 26);
            this.btnSearch.TabIndex = 98;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRetreatSettle
            // 
            this.btnRetreatSettle.Font = new System.Drawing.Font("宋体", 11F);
            this.btnRetreatSettle.Location = new System.Drawing.Point(575, 34);
            this.btnRetreatSettle.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnRetreatSettle.Name = "btnRetreatSettle";
            this.btnRetreatSettle.Size = new System.Drawing.Size(72, 26);
            this.btnRetreatSettle.TabIndex = 99;
            this.btnRetreatSettle.Text = "退结算";
            this.btnRetreatSettle.UseVisualStyleBackColor = true;
            this.btnRetreatSettle.Click += new System.EventHandler(this.btnRetreatSettle_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("宋体", 11F);
            this.btnPrint.Location = new System.Drawing.Point(647, 34);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(72, 26);
            this.btnPrint.TabIndex = 100;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // tcTab
            // 
            this.tcTab.Controls.Add(this.tpClinic);
            this.tcTab.Controls.Add(this.tpIhsp);
            this.tcTab.Location = new System.Drawing.Point(-2, 41);
            this.tcTab.Name = "tcTab";
            this.tcTab.SelectedIndex = 0;
            this.tcTab.Size = new System.Drawing.Size(737, 419);
            this.tcTab.TabIndex = 102;
            // 
            // tpClinic
            // 
            this.tpClinic.Controls.Add(this.dgvClinicTab);
            this.tpClinic.Location = new System.Drawing.Point(4, 22);
            this.tpClinic.Name = "tpClinic";
            this.tpClinic.Padding = new System.Windows.Forms.Padding(3);
            this.tpClinic.Size = new System.Drawing.Size(729, 393);
            this.tpClinic.TabIndex = 0;
            this.tpClinic.Text = "门诊日结信息";
            this.tpClinic.UseVisualStyleBackColor = true;
            // 
            // dgvClinicTab
            // 
            this.dgvClinicTab.AllowUserToAddRows = false;
            this.dgvClinicTab.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClinicTab.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvClinicTab.ColumnHeadersHeight = 27;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClinicTab.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvClinicTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClinicTab.Location = new System.Drawing.Point(3, 3);
            this.dgvClinicTab.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dgvClinicTab.Name = "dgvClinicTab";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClinicTab.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvClinicTab.RowTemplate.Height = 23;
            this.dgvClinicTab.Size = new System.Drawing.Size(723, 387);
            this.dgvClinicTab.TabIndex = 102;
            this.dgvClinicTab.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvClinicTab_RowPostPaint);
            // 
            // tpIhsp
            // 
            this.tpIhsp.Controls.Add(this.dgvTabAccount);
            this.tpIhsp.Location = new System.Drawing.Point(4, 22);
            this.tpIhsp.Name = "tpIhsp";
            this.tpIhsp.Padding = new System.Windows.Forms.Padding(3);
            this.tpIhsp.Size = new System.Drawing.Size(729, 393);
            this.tpIhsp.TabIndex = 1;
            this.tpIhsp.Text = "住院日结信息";
            this.tpIhsp.UseVisualStyleBackColor = true;
            // 
            // dgvTabAccount
            // 
            this.dgvTabAccount.AllowUserToAddRows = false;
            this.dgvTabAccount.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTabAccount.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTabAccount.ColumnHeadersHeight = 30;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTabAccount.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTabAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTabAccount.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvTabAccount.Location = new System.Drawing.Point(3, 3);
            this.dgvTabAccount.Name = "dgvTabAccount";
            this.dgvTabAccount.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTabAccount.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 11F);
            this.dgvTabAccount.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvTabAccount.RowTemplate.Height = 23;
            this.dgvTabAccount.Size = new System.Drawing.Size(723, 387);
            this.dgvTabAccount.TabIndex = 79;
            this.dgvTabAccount.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvTabAccount_RowPostPaint);
            // 
            // FrmClicTabManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 461);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnRetreatSettle);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tcTab);
            this.Controls.Add(this.cmbDpt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dtpEtime);
            this.Controls.Add(this.dtpStime);
            this.Controls.Add(this.label18);
            this.Name = "FrmClicTabManage";
            this.Text = "日结管理";
            this.Load += new System.EventHandler(this.FrmClinicTabManage_Load);
            this.tcTab.ResumeLayout(false);
            this.tpClinic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClinicTab)).EndInit();
            this.tpIhsp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabAccount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtpEtime;
        private System.Windows.Forms.DateTimePicker dtpStime;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cmbDpt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRetreatSettle;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TabControl tcTab;
        private System.Windows.Forms.TabPage tpClinic;
        private System.Windows.Forms.DataGridView dgvClinicTab;
        private System.Windows.Forms.TabPage tpIhsp;
        private System.Windows.Forms.DataGridView dgvTabAccount;
    }
}