namespace MTREG.ihsptab
{
    partial class FrmIhspDutyManage
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
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbxCreatedby = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRetAccount = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvTabAccount = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "yyyy-MM-dd";
            this.dtpStartTime.Font = new System.Drawing.Font("宋体", 11F);
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(82, 9);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(126, 24);
            this.dtpStartTime.TabIndex = 65;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "yyyy-MM-dd";
            this.dtpEndTime.Font = new System.Drawing.Font("宋体", 11F);
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(249, 9);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(124, 24);
            this.dtpEndTime.TabIndex = 66;
            this.dtpEndTime.ValueChanged += new System.EventHandler(this.dtpEndTime_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbxCreatedby);
            this.panel1.Controls.Add(this.dtpStartTime);
            this.panel1.Controls.Add(this.dtpEndTime);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.btnRetAccount);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(820, 69);
            this.panel1.TabIndex = 81;
            // 
            // tbxCreatedby
            // 
            this.tbxCreatedby.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxCreatedby.Location = new System.Drawing.Point(489, 9);
            this.tbxCreatedby.Name = "tbxCreatedby";
            this.tbxCreatedby.Size = new System.Drawing.Size(100, 24);
            this.tbxCreatedby.TabIndex = 71;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F);
            this.label2.Location = new System.Drawing.Point(407, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 58;
            this.label2.Text = "班结人员:";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("宋体", 11F);
            this.btnSearch.Location = new System.Drawing.Point(518, 38);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(69, 25);
            this.btnSearch.TabIndex = 70;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRetAccount
            // 
            this.btnRetAccount.Font = new System.Drawing.Font("宋体", 11F);
            this.btnRetAccount.Location = new System.Drawing.Point(589, 38);
            this.btnRetAccount.Name = "btnRetAccount";
            this.btnRetAccount.Size = new System.Drawing.Size(69, 25);
            this.btnRetAccount.TabIndex = 69;
            this.btnRetAccount.Text = "退结算";
            this.btnRetAccount.UseVisualStyleBackColor = true;
            this.btnRetAccount.Click += new System.EventHandler(this.btnRetAccount_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(218, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 15);
            this.label1.TabIndex = 68;
            this.label1.Text = "至";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 11F);
            this.label5.Location = new System.Drawing.Point(3, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 67;
            this.label5.Text = "结账时间:";
            // 
            // dgvTabAccount
            // 
            this.dgvTabAccount.AllowUserToAddRows = false;
            this.dgvTabAccount.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTabAccount.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTabAccount.ColumnHeadersHeight = 30;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTabAccount.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTabAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTabAccount.Location = new System.Drawing.Point(0, 69);
            this.dgvTabAccount.Name = "dgvTabAccount";
            this.dgvTabAccount.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTabAccount.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTabAccount.RowHeadersWidth = 30;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 11F);
            this.dgvTabAccount.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTabAccount.RowTemplate.Height = 23;
            this.dgvTabAccount.Size = new System.Drawing.Size(820, 347);
            this.dgvTabAccount.TabIndex = 80;
            this.dgvTabAccount.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTabAccount_CellContentClick);
            this.dgvTabAccount.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvTabAccount_RowPostPaint);
            // 
            // FrmIhspDutyManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 416);
            this.Controls.Add(this.dgvTabAccount);
            this.Controls.Add(this.panel1);
            this.Name = "FrmIhspDutyManage";
            this.Text = "住院班结管理";
            this.Load += new System.EventHandler(this.FrmIhspDutyManage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabAccount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRetAccount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvTabAccount;
        private System.Windows.Forms.TextBox tbxCreatedby;
    }
}