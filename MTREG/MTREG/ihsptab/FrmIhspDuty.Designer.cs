namespace MTREG.ihsptab
{
    partial class FrmIhspDuty
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbxCharger = new System.Windows.Forms.TextBox();
            this.lblAccNoCash = new System.Windows.Forms.Label();
            this.lblAccIsCash = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblAll = new System.Windows.Forms.Label();
            this.lblAllNoCash = new System.Windows.Forms.Label();
            this.lblAllIsCash = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPayNoCash = new System.Windows.Forms.Label();
            this.dgvIhsptabAcc = new System.Windows.Forms.DataGridView();
            this.lblPayIsCash = new System.Windows.Forms.Label();
            this.dgvIhsptabPay = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.btnAccount = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxPer = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIhsptabAcc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIhsptabPay)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxCharger
            // 
            this.tbxCharger.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxCharger.Location = new System.Drawing.Point(548, 14);
            this.tbxCharger.Name = "tbxCharger";
            this.tbxCharger.Size = new System.Drawing.Size(73, 24);
            this.tbxCharger.TabIndex = 110;
            // 
            // lblAccNoCash
            // 
            this.lblAccNoCash.AutoSize = true;
            this.lblAccNoCash.Font = new System.Drawing.Font("宋体", 13F);
            this.lblAccNoCash.ForeColor = System.Drawing.Color.Red;
            this.lblAccNoCash.Location = new System.Drawing.Point(239, 494);
            this.lblAccNoCash.Name = "lblAccNoCash";
            this.lblAccNoCash.Size = new System.Drawing.Size(44, 18);
            this.lblAccNoCash.TabIndex = 108;
            this.lblAccNoCash.Text = "0000";
            // 
            // lblAccIsCash
            // 
            this.lblAccIsCash.AutoSize = true;
            this.lblAccIsCash.Font = new System.Drawing.Font("宋体", 13F);
            this.lblAccIsCash.ForeColor = System.Drawing.Color.Red;
            this.lblAccIsCash.Location = new System.Drawing.Point(58, 494);
            this.lblAccIsCash.Name = "lblAccIsCash";
            this.lblAccIsCash.Size = new System.Drawing.Size(44, 18);
            this.lblAccIsCash.TabIndex = 109;
            this.lblAccIsCash.Text = "0000";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 13F);
            this.label19.Location = new System.Drawing.Point(194, 494);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 18);
            this.label19.TabIndex = 106;
            this.label19.Text = "支票:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 13F);
            this.label20.Location = new System.Drawing.Point(13, 494);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 18);
            this.label20.TabIndex = 107;
            this.label20.Text = "现金:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblAll);
            this.groupBox1.Controls.Add(this.lblAllNoCash);
            this.groupBox1.Controls.Add(this.lblAllIsCash);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 11F);
            this.groupBox1.Location = new System.Drawing.Point(13, 539);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(563, 53);
            this.groupBox1.TabIndex = 105;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "日结汇总列表:";
            // 
            // lblAll
            // 
            this.lblAll.AutoSize = true;
            this.lblAll.Font = new System.Drawing.Font("宋体", 13F);
            this.lblAll.ForeColor = System.Drawing.Color.Red;
            this.lblAll.Location = new System.Drawing.Point(452, 24);
            this.lblAll.Name = "lblAll";
            this.lblAll.Size = new System.Drawing.Size(44, 18);
            this.lblAll.TabIndex = 55;
            this.lblAll.Text = "0000";
            // 
            // lblAllNoCash
            // 
            this.lblAllNoCash.AutoSize = true;
            this.lblAllNoCash.Font = new System.Drawing.Font("宋体", 13F);
            this.lblAllNoCash.ForeColor = System.Drawing.Color.Red;
            this.lblAllNoCash.Location = new System.Drawing.Point(240, 25);
            this.lblAllNoCash.Name = "lblAllNoCash";
            this.lblAllNoCash.Size = new System.Drawing.Size(44, 18);
            this.lblAllNoCash.TabIndex = 55;
            this.lblAllNoCash.Text = "0000";
            // 
            // lblAllIsCash
            // 
            this.lblAllIsCash.AutoSize = true;
            this.lblAllIsCash.Font = new System.Drawing.Font("宋体", 13F);
            this.lblAllIsCash.ForeColor = System.Drawing.Color.Red;
            this.lblAllIsCash.Location = new System.Drawing.Point(55, 24);
            this.lblAllIsCash.Name = "lblAllIsCash";
            this.lblAllIsCash.Size = new System.Drawing.Size(44, 18);
            this.lblAllIsCash.TabIndex = 55;
            this.lblAllIsCash.Text = "0000";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 13F);
            this.label11.Location = new System.Drawing.Point(370, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 18);
            this.label11.TabIndex = 55;
            this.label11.Text = "总计金额:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 13F);
            this.label8.Location = new System.Drawing.Point(195, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 18);
            this.label8.TabIndex = 55;
            this.label8.Text = "支票:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 13F);
            this.label6.Location = new System.Drawing.Point(10, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 18);
            this.label6.TabIndex = 55;
            this.label6.Text = "现金:";
            // 
            // lblPayNoCash
            // 
            this.lblPayNoCash.AutoSize = true;
            this.lblPayNoCash.Font = new System.Drawing.Font("宋体", 13F);
            this.lblPayNoCash.ForeColor = System.Drawing.Color.Red;
            this.lblPayNoCash.Location = new System.Drawing.Point(240, 275);
            this.lblPayNoCash.Name = "lblPayNoCash";
            this.lblPayNoCash.Size = new System.Drawing.Size(44, 18);
            this.lblPayNoCash.TabIndex = 94;
            this.lblPayNoCash.Text = "0000";
            // 
            // dgvIhsptabAcc
            // 
            this.dgvIhsptabAcc.AllowUserToAddRows = false;
            this.dgvIhsptabAcc.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIhsptabAcc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIhsptabAcc.ColumnHeadersHeight = 30;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIhsptabAcc.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvIhsptabAcc.Location = new System.Drawing.Point(13, 323);
            this.dgvIhsptabAcc.Name = "dgvIhsptabAcc";
            this.dgvIhsptabAcc.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIhsptabAcc.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvIhsptabAcc.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 11F);
            this.dgvIhsptabAcc.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvIhsptabAcc.RowTemplate.Height = 23;
            this.dgvIhsptabAcc.Size = new System.Drawing.Size(840, 168);
            this.dgvIhsptabAcc.TabIndex = 103;
            // 
            // lblPayIsCash
            // 
            this.lblPayIsCash.AutoSize = true;
            this.lblPayIsCash.Font = new System.Drawing.Font("宋体", 13F);
            this.lblPayIsCash.ForeColor = System.Drawing.Color.Red;
            this.lblPayIsCash.Location = new System.Drawing.Point(61, 275);
            this.lblPayIsCash.Name = "lblPayIsCash";
            this.lblPayIsCash.Size = new System.Drawing.Size(44, 18);
            this.lblPayIsCash.TabIndex = 93;
            this.lblPayIsCash.Text = "0000";
            // 
            // dgvIhsptabPay
            // 
            this.dgvIhsptabPay.AllowUserToAddRows = false;
            this.dgvIhsptabPay.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIhsptabPay.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvIhsptabPay.ColumnHeadersHeight = 30;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIhsptabPay.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvIhsptabPay.Location = new System.Drawing.Point(13, 78);
            this.dgvIhsptabPay.Name = "dgvIhsptabPay";
            this.dgvIhsptabPay.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIhsptabPay.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvIhsptabPay.RowHeadersVisible = false;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 11F);
            this.dgvIhsptabPay.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvIhsptabPay.RowTemplate.Height = 23;
            this.dgvIhsptabPay.Size = new System.Drawing.Size(840, 194);
            this.dgvIhsptabPay.TabIndex = 104;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("宋体", 11F);
            this.btnSearch.Location = new System.Drawing.Point(603, 44);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 25);
            this.btnSearch.TabIndex = 102;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 13F);
            this.label14.Location = new System.Drawing.Point(194, 275);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 18);
            this.label14.TabIndex = 91;
            this.label14.Text = "支票:";
            // 
            // btnAccount
            // 
            this.btnAccount.Font = new System.Drawing.Font("宋体", 11F);
            this.btnAccount.Location = new System.Drawing.Point(684, 44);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(80, 25);
            this.btnAccount.TabIndex = 101;
            this.btnAccount.Text = "结算";
            this.btnAccount.UseVisualStyleBackColor = true;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 13F);
            this.label13.Location = new System.Drawing.Point(15, 275);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 18);
            this.label13.TabIndex = 92;
            this.label13.Text = "现金:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 11F);
            this.label4.Location = new System.Drawing.Point(11, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 15);
            this.label4.TabIndex = 90;
            this.label4.Text = "出院结算单列表:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 11F);
            this.label3.Location = new System.Drawing.Point(10, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 15);
            this.label3.TabIndex = 96;
            this.label3.Text = "预交款列表:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 11F);
            this.label10.Location = new System.Drawing.Point(493, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 15);
            this.label10.TabIndex = 95;
            this.label10.Text = "收费员:";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CalendarFont = new System.Drawing.Font("宋体", 11F);
            this.dtpEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEndTime.Font = new System.Drawing.Font("宋体", 11F);
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(299, 13);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(190, 24);
            this.dtpEndTime.TabIndex = 86;
            this.dtpEndTime.ValueChanged += new System.EventHandler(this.dtpEndTime_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(276, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 15);
            this.label1.TabIndex = 89;
            this.label1.Text = "至";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CalendarFont = new System.Drawing.Font("宋体", 11F);
            this.dtpStartTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpStartTime.Font = new System.Drawing.Font("宋体", 11F);
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(80, 13);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(194, 24);
            this.dtpStartTime.TabIndex = 85;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F);
            this.label2.Location = new System.Drawing.Point(627, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 88;
            this.label2.Text = "结账员:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 11F);
            this.label5.Location = new System.Drawing.Point(11, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 87;
            this.label5.Text = "结账时间:";
            // 
            // tbxPer
            // 
            this.tbxPer.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxPer.Location = new System.Drawing.Point(683, 14);
            this.tbxPer.Name = "tbxPer";
            this.tbxPer.Size = new System.Drawing.Size(73, 24);
            this.tbxPer.TabIndex = 110;
            // 
            // FrmIhspDuty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 602);
            this.Controls.Add(this.tbxPer);
            this.Controls.Add(this.tbxCharger);
            this.Controls.Add(this.lblAccNoCash);
            this.Controls.Add(this.lblAccIsCash);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblPayNoCash);
            this.Controls.Add(this.dgvIhsptabAcc);
            this.Controls.Add(this.lblPayIsCash);
            this.Controls.Add(this.dgvIhsptabPay);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnAccount);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtpEndTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpStartTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Name = "FrmIhspDuty";
            this.Text = "住院班结表";
            this.Load += new System.EventHandler(this.FrmIhsptabDuty_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIhsptabAcc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIhsptabPay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxCharger;
        private System.Windows.Forms.Label lblAccNoCash;
        private System.Windows.Forms.Label lblAccIsCash;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblAll;
        private System.Windows.Forms.Label lblAllNoCash;
        private System.Windows.Forms.Label lblAllIsCash;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPayNoCash;
        private System.Windows.Forms.DataGridView dgvIhsptabAcc;
        private System.Windows.Forms.Label lblPayIsCash;
        private System.Windows.Forms.DataGridView dgvIhsptabPay;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnAccount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxPer;
    }
}