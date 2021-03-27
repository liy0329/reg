namespace MTREG.clintab
{
    partial class FrmClicDutyManage
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
            this.dgvClinicTab = new System.Windows.Forms.DataGridView();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnRetreatSettle = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dtpEtime = new System.Windows.Forms.DateTimePicker();
            this.dtpStime = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.tbxPer = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClinicTab)).BeginInit();
            this.SuspendLayout();
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
            this.dgvClinicTab.Location = new System.Drawing.Point(13, 73);
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
            this.dgvClinicTab.Size = new System.Drawing.Size(711, 385);
            this.dgvClinicTab.TabIndex = 111;
            this.dgvClinicTab.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvClinicTab_RowPostPaint);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("宋体", 11F);
            this.btnPrint.Location = new System.Drawing.Point(652, 44);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(72, 26);
            this.btnPrint.TabIndex = 110;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnRetreatSettle
            // 
            this.btnRetreatSettle.Font = new System.Drawing.Font("宋体", 11F);
            this.btnRetreatSettle.Location = new System.Drawing.Point(580, 44);
            this.btnRetreatSettle.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnRetreatSettle.Name = "btnRetreatSettle";
            this.btnRetreatSettle.Size = new System.Drawing.Size(72, 26);
            this.btnRetreatSettle.TabIndex = 109;
            this.btnRetreatSettle.Text = "退班结";
            this.btnRetreatSettle.UseVisualStyleBackColor = true;
            this.btnRetreatSettle.Click += new System.EventHandler(this.btnRetreatSettle_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("宋体", 11F);
            this.btnSearch.Location = new System.Drawing.Point(549, 10);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(72, 26);
            this.btnSearch.TabIndex = 108;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(365, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 106;
            this.label1.Text = "结算人:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 11F);
            this.label15.Location = new System.Drawing.Point(209, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(22, 15);
            this.label15.TabIndex = 105;
            this.label15.Text = "至";
            // 
            // dtpEtime
            // 
            this.dtpEtime.CustomFormat = "yyyy-MM-dd";
            this.dtpEtime.Font = new System.Drawing.Font("宋体", 11F);
            this.dtpEtime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEtime.Location = new System.Drawing.Point(240, 11);
            this.dtpEtime.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dtpEtime.Name = "dtpEtime";
            this.dtpEtime.Size = new System.Drawing.Size(118, 24);
            this.dtpEtime.TabIndex = 103;
            // 
            // dtpStime
            // 
            this.dtpStime.CustomFormat = "yyyy-MM-dd";
            this.dtpStime.Font = new System.Drawing.Font("宋体", 11F);
            this.dtpStime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStime.Location = new System.Drawing.Point(81, 11);
            this.dtpStime.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dtpStime.Name = "dtpStime";
            this.dtpStime.Size = new System.Drawing.Size(117, 24);
            this.dtpStime.TabIndex = 102;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 11F);
            this.label18.Location = new System.Drawing.Point(9, 15);
            this.label18.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(75, 15);
            this.label18.TabIndex = 104;
            this.label18.Text = "班结时间:";
            // 
            // tbxPer
            // 
            this.tbxPer.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxPer.Location = new System.Drawing.Point(421, 12);
            this.tbxPer.Name = "tbxPer";
            this.tbxPer.Size = new System.Drawing.Size(119, 24);
            this.tbxPer.TabIndex = 112;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 11F);
            this.button1.Location = new System.Drawing.Point(506, 44);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 26);
            this.button1.TabIndex = 113;
            this.button1.Text = "班结";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmClicDutyManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 472);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbxPer);
            this.Controls.Add(this.dgvClinicTab);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnRetreatSettle);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dtpEtime);
            this.Controls.Add(this.dtpStime);
            this.Controls.Add(this.label18);
            this.Name = "FrmClicDutyManage";
            this.Text = "门诊班结管理";
            this.Load += new System.EventHandler(this.FrmClicDutyManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClinicTab)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClinicTab;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnRetreatSettle;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtpEtime;
        private System.Windows.Forms.DateTimePicker dtpStime;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbxPer;
        private System.Windows.Forms.Button button1;
    }
}