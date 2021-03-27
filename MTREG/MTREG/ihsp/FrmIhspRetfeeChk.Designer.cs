namespace MTREG.ihsp
{
    partial class FrmIhspRetfeeChk
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
            this.cmbDepart = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.dgvIhspRetapp = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIhspRetapp)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbDepart
            // 
            this.cmbDepart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepart.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbDepart.FormattingEnabled = true;
            this.cmbDepart.ItemHeight = 15;
            this.cmbDepart.Location = new System.Drawing.Point(448, 13);
            this.cmbDepart.Name = "cmbDepart";
            this.cmbDepart.Size = new System.Drawing.Size(82, 23);
            this.cmbDepart.TabIndex = 60;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 11F);
            this.label10.Location = new System.Drawing.Point(407, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 15);
            this.label10.TabIndex = 57;
            this.label10.Text = "科室:";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Font = new System.Drawing.Font("宋体", 11F);
            this.dtpEndTime.Location = new System.Drawing.Point(255, 13);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(146, 24);
            this.dtpEndTime.TabIndex = 62;
            this.dtpEndTime.ValueChanged += new System.EventHandler(this.dtpEndTime_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(232, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 15);
            this.label1.TabIndex = 64;
            this.label1.Text = "至";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Font = new System.Drawing.Font("宋体", 11F);
            this.dtpStartTime.Location = new System.Drawing.Point(83, 13);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(146, 24);
            this.dtpStartTime.TabIndex = 61;
            this.dtpStartTime.ValueChanged += new System.EventHandler(this.dtpStartTime_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 11F);
            this.label5.Location = new System.Drawing.Point(12, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 63;
            this.label5.Text = "起始日期:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 11F);
            this.label3.Location = new System.Drawing.Point(536, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 57;
            this.label3.Text = "是否确认:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.ItemHeight = 15;
            this.cmbStatus.Location = new System.Drawing.Point(608, 13);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(73, 23);
            this.cmbStatus.TabIndex = 60;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("宋体", 11F);
            this.btnSearch.Location = new System.Drawing.Point(525, 47);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(79, 25);
            this.btnSearch.TabIndex = 66;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("宋体", 11F);
            this.btnReset.Location = new System.Drawing.Point(605, 47);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(79, 25);
            this.btnReset.TabIndex = 65;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dgvIhspRetapp
            // 
            this.dgvIhspRetapp.AllowUserToAddRows = false;
            this.dgvIhspRetapp.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIhspRetapp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIhspRetapp.ColumnHeadersHeight = 30;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIhspRetapp.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvIhspRetapp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIhspRetapp.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvIhspRetapp.Location = new System.Drawing.Point(0, 79);
            this.dgvIhspRetapp.Name = "dgvIhspRetapp";
            this.dgvIhspRetapp.ReadOnly = true;
            this.dgvIhspRetapp.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIhspRetapp.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvIhspRetapp.RowHeadersVisible = false;
            this.dgvIhspRetapp.RowHeadersWidth = 50;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgvIhspRetapp.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvIhspRetapp.RowTemplate.Height = 23;
            this.dgvIhspRetapp.Size = new System.Drawing.Size(693, 278);
            this.dgvIhspRetapp.TabIndex = 67;
            this.dgvIhspRetapp.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIhspRetapp_CellContentDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbDepart);
            this.panel1.Controls.Add(this.dtpEndTime);
            this.panel1.Controls.Add(this.dtpStartTime);
            this.panel1.Controls.Add(this.cmbStatus);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(693, 79);
            this.panel1.TabIndex = 68;
            // 
            // FrmIhspRetfeeChk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 357);
            this.Controls.Add(this.dgvIhspRetapp);
            this.Controls.Add(this.panel1);
            this.Name = "FrmIhspRetfeeChk";
            this.Text = "退费确定";
            this.Load += new System.EventHandler(this.FrmIhspRetapp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIhspRetapp)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbDepart;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dgvIhspRetapp;
        private System.Windows.Forms.Panel panel1;
    }
}