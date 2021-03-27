namespace MTREG.clinic
{
    partial class FrmUnlockRcpManage
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
            this.dgvInvoice = new System.Windows.Forms.DataGridView();
            this.btnUnlock = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.dtpEtime = new System.Windows.Forms.DateTimePicker();
            this.dtpStime = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.cmbDoctor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDepart = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbxPatientName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxHspcard = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvInvoice
            // 
            this.dgvInvoice.AllowUserToAddRows = false;
            this.dgvInvoice.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInvoice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInvoice.ColumnHeadersHeight = 25;
            this.dgvInvoice.Location = new System.Drawing.Point(10, 70);
            this.dgvInvoice.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dgvInvoice.Name = "dgvInvoice";
            this.dgvInvoice.RowHeadersVisible = false;
            this.dgvInvoice.RowTemplate.Height = 23;
            this.dgvInvoice.Size = new System.Drawing.Size(943, 417);
            this.dgvInvoice.TabIndex = 86;
            // 
            // btnUnlock
            // 
            this.btnUnlock.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUnlock.Location = new System.Drawing.Point(859, 41);
            this.btnUnlock.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(63, 28);
            this.btnUnlock.TabIndex = 85;
            this.btnUnlock.Text = "解锁";
            this.btnUnlock.UseVisualStyleBackColor = true;
            this.btnUnlock.Click += new System.EventHandler(this.btnUnlock_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(700, 41);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(63, 28);
            this.btnSearch.TabIndex = 83;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(459, 45);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(24, 16);
            this.label15.TabIndex = 82;
            this.label15.Text = "至";
            // 
            // dtpEtime
            // 
            this.dtpEtime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpEtime.Location = new System.Drawing.Point(500, 41);
            this.dtpEtime.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dtpEtime.Name = "dtpEtime";
            this.dtpEtime.Size = new System.Drawing.Size(143, 26);
            this.dtpEtime.TabIndex = 80;
            // 
            // dtpStime
            // 
            this.dtpStime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpStime.Location = new System.Drawing.Point(293, 41);
            this.dtpStime.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dtpStime.Name = "dtpStime";
            this.dtpStime.Size = new System.Drawing.Size(147, 26);
            this.dtpStime.TabIndex = 79;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(206, 45);
            this.label18.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 16);
            this.label18.TabIndex = 81;
            this.label18.Text = "收费日期:";
            // 
            // cmbDoctor
            // 
            this.cmbDoctor.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbDoctor.FormattingEnabled = true;
            this.cmbDoctor.ItemHeight = 16;
            this.cmbDoctor.Location = new System.Drawing.Point(66, 42);
            this.cmbDoctor.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cmbDoctor.Name = "cmbDoctor";
            this.cmbDoctor.Size = new System.Drawing.Size(113, 24);
            this.cmbDoctor.TabIndex = 75;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(14, 46);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 76;
            this.label4.Text = "医生:";
            // 
            // cmbDepart
            // 
            this.cmbDepart.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbDepart.FormattingEnabled = true;
            this.cmbDepart.ItemHeight = 16;
            this.cmbDepart.Location = new System.Drawing.Point(535, 10);
            this.cmbDepart.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cmbDepart.Name = "cmbDepart";
            this.cmbDepart.Size = new System.Drawing.Size(113, 24);
            this.cmbDepart.TabIndex = 73;
            this.cmbDepart.SelectionChangeCommitted += new System.EventHandler(this.cmbDepart_SelectionChangeCommitted);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(474, 14);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 16);
            this.label11.TabIndex = 74;
            this.label11.Text = "科室:";
            // 
            // tbxPatientName
            // 
            this.tbxPatientName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxPatientName.Location = new System.Drawing.Point(67, 10);
            this.tbxPatientName.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbxPatientName.Name = "tbxPatientName";
            this.tbxPatientName.Size = new System.Drawing.Size(113, 26);
            this.tbxPatientName.TabIndex = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 69;
            this.label1.Text = "姓名:";
            // 
            // tbxHspcard
            // 
            this.tbxHspcard.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxHspcard.Location = new System.Drawing.Point(294, 10);
            this.tbxHspcard.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbxHspcard.Name = "tbxHspcard";
            this.tbxHspcard.Size = new System.Drawing.Size(152, 26);
            this.tbxHspcard.TabIndex = 68;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(237, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 67;
            this.label2.Text = "卡号:";
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReset.Location = new System.Drawing.Point(770, 41);
            this.btnReset.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(63, 28);
            this.btnReset.TabIndex = 85;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // FrmUnlockRcpManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 492);
            this.Controls.Add(this.dgvInvoice);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnUnlock);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dtpEtime);
            this.Controls.Add(this.dtpStime);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.cmbDoctor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbDepart);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbxPatientName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxHspcard);
            this.Controls.Add(this.label2);
            this.Name = "FrmUnlockRcpManage";
            this.Text = "发票解锁";
            this.Load += new System.EventHandler(this.FrmClinicRetFeeChk_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInvoice;
        private System.Windows.Forms.Button btnUnlock;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtpEtime;
        private System.Windows.Forms.DateTimePicker dtpStime;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cmbDoctor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDepart;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbxPatientName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxHspcard;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReset;
    }
}