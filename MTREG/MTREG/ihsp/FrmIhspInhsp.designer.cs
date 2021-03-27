namespace MTREG.ihsp
{
    partial class FrmIhspInhsp
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
            this.dgvInhospital = new System.Windows.Forms.DataGridView();
            this.btnReset = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxIhspcode = new System.Windows.Forms.TextBox();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.panel = new System.Windows.Forms.Panel();
            this.cbxByInDate = new System.Windows.Forms.CheckBox();
            this.btnPrintWD = new System.Windows.Forms.Button();
            this.cmbDepart = new System.Windows.Forms.ComboBox();
            this.btnInsur = new System.Windows.Forms.Button();
            this.cmbPatienttype = new System.Windows.Forms.ComboBox();
            this.tbxHspcard = new System.Windows.Forms.TextBox();
            this.cbxPay = new System.Windows.Forms.CheckBox();
            this.btnGuarantee = new System.Windows.Forms.Button();
            this.btnPrepamt = new System.Windows.Forms.Button();
            this.btnInsurMag = new System.Windows.Forms.Button();
            this.btnOutInhs = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInhospital)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvInhospital
            // 
            this.dgvInhospital.AllowUserToAddRows = false;
            this.dgvInhospital.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 13F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInhospital.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInhospital.ColumnHeadersHeight = 30;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 13F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInhospital.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInhospital.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInhospital.Location = new System.Drawing.Point(0, 124);
            this.dgvInhospital.Name = "dgvInhospital";
            this.dgvInhospital.ReadOnly = true;
            this.dgvInhospital.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInhospital.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInhospital.RowHeadersVisible = false;
            this.dgvInhospital.RowHeadersWidth = 50;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 13F);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgvInhospital.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInhospital.RowTemplate.Height = 23;
            this.dgvInhospital.Size = new System.Drawing.Size(1078, 424);
            this.dgvInhospital.TabIndex = 33;
            this.dgvInhospital.SelectionChanged += new System.EventHandler(this.dgvInhospital_SelectionChanged);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("宋体", 13F);
            this.btnReset.Location = new System.Drawing.Point(891, 40);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(81, 30);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnRest_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 13F);
            this.label5.Location = new System.Drawing.Point(466, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 18);
            this.label5.TabIndex = 26;
            this.label5.Text = "入院时间:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 13F);
            this.label3.Location = new System.Drawing.Point(21, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "科室:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 13F);
            this.label4.Location = new System.Drawing.Point(6, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "住院号:";
            // 
            // tbxIhspcode
            // 
            this.tbxIhspcode.Font = new System.Drawing.Font("宋体", 13F);
            this.tbxIhspcode.Location = new System.Drawing.Point(80, 9);
            this.tbxIhspcode.Name = "tbxIhspcode";
            this.tbxIhspcode.Size = new System.Drawing.Size(124, 27);
            this.tbxIhspcode.TabIndex = 1;
            this.tbxIhspcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxIhspcode_KeyDown);
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Font = new System.Drawing.Font("宋体", 13F);
            this.dtpStartTime.Location = new System.Drawing.Point(553, 40);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(141, 27);
            this.dtpStartTime.TabIndex = 5;
            this.dtpStartTime.ValueChanged += new System.EventHandler(this.dtpStartTime_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 13F);
            this.label1.Location = new System.Drawing.Point(694, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 18);
            this.label1.TabIndex = 34;
            this.label1.Text = "至";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 13F);
            this.label2.Location = new System.Drawing.Point(259, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "姓名:";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Font = new System.Drawing.Font("宋体", 13F);
            this.dtpEndTime.Location = new System.Drawing.Point(722, 40);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(140, 27);
            this.dtpEndTime.TabIndex = 6;
            this.dtpEndTime.ValueChanged += new System.EventHandler(this.dtpEndTime_ValueChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("宋体", 13F);
            this.btnSearch.Location = new System.Drawing.Point(891, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(81, 30);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 13F);
            this.label6.Location = new System.Drawing.Point(502, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 18);
            this.label6.TabIndex = 35;
            this.label6.Text = "卡号:";
            // 
            // tbxName
            // 
            this.tbxName.Font = new System.Drawing.Font("宋体", 13F);
            this.tbxName.Location = new System.Drawing.Point(320, 7);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(110, 27);
            this.tbxName.TabIndex = 2;
            this.tbxName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxName_KeyDown);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.cbxByInDate);
            this.panel.Controls.Add(this.btnPrintWD);
            this.panel.Controls.Add(this.cmbDepart);
            this.panel.Controls.Add(this.btnInsur);
            this.panel.Controls.Add(this.cmbPatienttype);
            this.panel.Controls.Add(this.tbxHspcard);
            this.panel.Controls.Add(this.cbxPay);
            this.panel.Controls.Add(this.btnGuarantee);
            this.panel.Controls.Add(this.btnPrepamt);
            this.panel.Controls.Add(this.btnInsurMag);
            this.panel.Controls.Add(this.btnOutInhs);
            this.panel.Controls.Add(this.btnEdit);
            this.panel.Controls.Add(this.btnLogin);
            this.panel.Controls.Add(this.cmbStatus);
            this.panel.Controls.Add(this.tbxName);
            this.panel.Controls.Add(this.label6);
            this.panel.Controls.Add(this.btnSearch);
            this.panel.Controls.Add(this.dtpEndTime);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.dtpStartTime);
            this.panel.Controls.Add(this.tbxIhspcode);
            this.panel.Controls.Add(this.label4);
            this.panel.Controls.Add(this.label7);
            this.panel.Controls.Add(this.label3);
            this.panel.Controls.Add(this.label5);
            this.panel.Controls.Add(this.btnReset);
            this.panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1078, 124);
            this.panel.TabIndex = 36;
            // 
            // cbxByInDate
            // 
            this.cbxByInDate.AutoSize = true;
            this.cbxByInDate.Font = new System.Drawing.Font("宋体", 13F);
            this.cbxByInDate.Location = new System.Drawing.Point(452, 46);
            this.cbxByInDate.Name = "cbxByInDate";
            this.cbxByInDate.Size = new System.Drawing.Size(15, 14);
            this.cbxByInDate.TabIndex = 62;
            this.cbxByInDate.UseVisualStyleBackColor = true;
            this.cbxByInDate.CheckedChanged += new System.EventHandler(this.cbxByInDate_CheckedChanged);
            // 
            // btnPrintWD
            // 
            this.btnPrintWD.Font = new System.Drawing.Font("宋体", 13F);
            this.btnPrintWD.Location = new System.Drawing.Point(975, 40);
            this.btnPrintWD.Name = "btnPrintWD";
            this.btnPrintWD.Size = new System.Drawing.Size(100, 30);
            this.btnPrintWD.TabIndex = 61;
            this.btnPrintWD.Text = "打印腕带";
            this.btnPrintWD.UseVisualStyleBackColor = true;
            this.btnPrintWD.Click += new System.EventHandler(this.btnPrintWD_Click);
            // 
            // cmbDepart
            // 
            this.cmbDepart.Font = new System.Drawing.Font("宋体", 13F);
            this.cmbDepart.FormattingEnabled = true;
            this.cmbDepart.ItemHeight = 17;
            this.cmbDepart.Location = new System.Drawing.Point(80, 40);
            this.cmbDepart.Name = "cmbDepart";
            this.cmbDepart.Size = new System.Drawing.Size(124, 25);
            this.cmbDepart.TabIndex = 60;
            this.cmbDepart.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbDepart_KeyUp);
            // 
            // btnInsur
            // 
            this.btnInsur.Font = new System.Drawing.Font("宋体", 13F);
            this.btnInsur.Location = new System.Drawing.Point(966, 83);
            this.btnInsur.Name = "btnInsur";
            this.btnInsur.Size = new System.Drawing.Size(100, 30);
            this.btnInsur.TabIndex = 59;
            this.btnInsur.Text = "转医保";
            this.btnInsur.UseVisualStyleBackColor = true;
            this.btnInsur.Click += new System.EventHandler(this.btnInsur_Click);
            // 
            // cmbPatienttype
            // 
            this.cmbPatienttype.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbPatienttype.FormattingEnabled = true;
            this.cmbPatienttype.ItemHeight = 15;
            this.cmbPatienttype.Location = new System.Drawing.Point(825, 89);
            this.cmbPatienttype.Name = "cmbPatienttype";
            this.cmbPatienttype.Size = new System.Drawing.Size(135, 23);
            this.cmbPatienttype.TabIndex = 58;
            this.cmbPatienttype.SelectedIndexChanged += new System.EventHandler(this.cmbPatienttype_SelectedIndexChanged);
            // 
            // tbxHspcard
            // 
            this.tbxHspcard.Font = new System.Drawing.Font("宋体", 13F);
            this.tbxHspcard.Location = new System.Drawing.Point(553, 6);
            this.tbxHspcard.Name = "tbxHspcard";
            this.tbxHspcard.Size = new System.Drawing.Size(113, 27);
            this.tbxHspcard.TabIndex = 42;
            this.tbxHspcard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxHspcard_KeyDown);
            this.tbxHspcard.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbxHspcard_KeyUp);
            // 
            // cbxPay
            // 
            this.cbxPay.AutoSize = true;
            this.cbxPay.Font = new System.Drawing.Font("宋体", 13F);
            this.cbxPay.Location = new System.Drawing.Point(678, 11);
            this.cbxPay.Name = "cbxPay";
            this.cbxPay.Size = new System.Drawing.Size(99, 22);
            this.cbxPay.TabIndex = 41;
            this.cbxPay.Text = "交预付款";
            this.cbxPay.UseVisualStyleBackColor = true;
            // 
            // btnGuarantee
            // 
            this.btnGuarantee.Font = new System.Drawing.Font("宋体", 13F);
            this.btnGuarantee.Location = new System.Drawing.Point(507, 83);
            this.btnGuarantee.Name = "btnGuarantee";
            this.btnGuarantee.Size = new System.Drawing.Size(100, 30);
            this.btnGuarantee.TabIndex = 39;
            this.btnGuarantee.Text = "担保";
            this.btnGuarantee.UseVisualStyleBackColor = true;
            this.btnGuarantee.Click += new System.EventHandler(this.btnGuarantee_Click);
            // 
            // btnPrepamt
            // 
            this.btnPrepamt.Font = new System.Drawing.Font("宋体", 13F);
            this.btnPrepamt.Location = new System.Drawing.Point(401, 83);
            this.btnPrepamt.Name = "btnPrepamt";
            this.btnPrepamt.Size = new System.Drawing.Size(100, 30);
            this.btnPrepamt.TabIndex = 38;
            this.btnPrepamt.Text = "预交款";
            this.btnPrepamt.UseVisualStyleBackColor = true;
            this.btnPrepamt.Click += new System.EventHandler(this.btnPrepamt_Click);
            // 
            // btnInsurMag
            // 
            this.btnInsurMag.Font = new System.Drawing.Font("宋体", 13F);
            this.btnInsurMag.ForeColor = System.Drawing.Color.Red;
            this.btnInsurMag.Location = new System.Drawing.Point(975, 7);
            this.btnInsurMag.Name = "btnInsurMag";
            this.btnInsurMag.Size = new System.Drawing.Size(100, 30);
            this.btnInsurMag.TabIndex = 40;
            this.btnInsurMag.Text = "错误处理";
            this.btnInsurMag.UseVisualStyleBackColor = true;
            this.btnInsurMag.Visible = false;
            this.btnInsurMag.Click += new System.EventHandler(this.btnInsurMag_Click);
            // 
            // btnOutInhs
            // 
            this.btnOutInhs.Font = new System.Drawing.Font("宋体", 13F);
            this.btnOutInhs.Location = new System.Drawing.Point(613, 83);
            this.btnOutInhs.Name = "btnOutInhs";
            this.btnOutInhs.Size = new System.Drawing.Size(100, 30);
            this.btnOutInhs.TabIndex = 40;
            this.btnOutInhs.Text = "入院回退";
            this.btnOutInhs.UseVisualStyleBackColor = true;
            this.btnOutInhs.Click += new System.EventHandler(this.btnOutInhs_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("宋体", 13F);
            this.btnEdit.Location = new System.Drawing.Point(719, 83);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 30);
            this.btnEdit.TabIndex = 37;
            this.btnEdit.Text = "修改信息";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("宋体", 13F);
            this.btnLogin.Location = new System.Drawing.Point(314, 83);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(81, 30);
            this.btnLogin.TabIndex = 37;
            this.btnLogin.Text = "登记";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.Font = new System.Drawing.Font("宋体", 13F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.ItemHeight = 17;
            this.cmbStatus.Location = new System.Drawing.Point(318, 40);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(111, 25);
            this.cmbStatus.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 13F);
            this.label7.Location = new System.Drawing.Point(223, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 18);
            this.label7.TabIndex = 9;
            this.label7.Text = "住院状态:";
            // 
            // FrmIhspInhsp
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1078, 548);
            this.Controls.Add(this.dgvInhospital);
            this.Controls.Add(this.panel);
            this.Name = "FrmIhspInhsp";
            this.Text = "住院管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Activated += new System.EventHandler(this.FrmIhspInhsp_Activated);
            this.Load += new System.EventHandler(this.FrmIhspInhsp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInhospital)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxIhspcode;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button btnGuarantee;
        private System.Windows.Forms.Button btnPrepamt;
        private System.Windows.Forms.Button btnOutInhs;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.CheckBox cbxPay;
        private System.Windows.Forms.TextBox tbxHspcard;
        private System.Windows.Forms.Button btnInsurMag;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ComboBox cmbPatienttype;
        private System.Windows.Forms.Button btnInsur;
        private System.Windows.Forms.ComboBox cmbDepart;
        private System.Windows.Forms.Button btnPrintWD;
        private System.Windows.Forms.CheckBox cbxByInDate;
        private System.Windows.Forms.DataGridView dgvInhospital;
    }
}