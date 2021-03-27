namespace MTREG.ihsp
{
    partial class FrmIhspChkRetSetle
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
            this.cmbPatienttype = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxHspcard = new System.Windows.Forms.TextBox();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.tbxIhspcode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnApprover = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvIhspCost = new System.Windows.Forms.DataGridView();
            this.dgvInhospital = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIhspCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInhospital)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbPatienttype
            // 
            this.cmbPatienttype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPatienttype.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbPatienttype.FormattingEnabled = true;
            this.cmbPatienttype.ItemHeight = 15;
            this.cmbPatienttype.Location = new System.Drawing.Point(563, 9);
            this.cmbPatienttype.Name = "cmbPatienttype";
            this.cmbPatienttype.Size = new System.Drawing.Size(105, 23);
            this.cmbPatienttype.TabIndex = 72;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 11F);
            this.label8.Location = new System.Drawing.Point(493, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 15);
            this.label8.TabIndex = 73;
            this.label8.Text = "患者类型:";
            // 
            // tbxHspcard
            // 
            this.tbxHspcard.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxHspcard.Location = new System.Drawing.Point(381, 9);
            this.tbxHspcard.Name = "tbxHspcard";
            this.tbxHspcard.Size = new System.Drawing.Size(105, 24);
            this.tbxHspcard.TabIndex = 60;
            // 
            // tbxName
            // 
            this.tbxName.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxName.Location = new System.Drawing.Point(219, 9);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(111, 24);
            this.tbxName.TabIndex = 59;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 11F);
            this.label6.Location = new System.Drawing.Point(340, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 15);
            this.label6.TabIndex = 70;
            this.label6.Text = "卡号:";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "";
            this.dtpEndTime.Font = new System.Drawing.Font("宋体", 11F);
            this.dtpEndTime.Location = new System.Drawing.Point(242, 38);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(146, 24);
            this.dtpEndTime.TabIndex = 64;
            this.dtpEndTime.ValueChanged += new System.EventHandler(this.dtpEndTime_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F);
            this.label2.Location = new System.Drawing.Point(179, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 61;
            this.label2.Text = "姓名:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(220, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 15);
            this.label1.TabIndex = 69;
            this.label1.Text = "至";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "";
            this.dtpStartTime.Font = new System.Drawing.Font("宋体", 11F);
            this.dtpStartTime.Location = new System.Drawing.Point(71, 38);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(146, 24);
            this.dtpStartTime.TabIndex = 63;
            this.dtpStartTime.ValueChanged += new System.EventHandler(this.dtpStartTime_ValueChanged);
            // 
            // tbxIhspcode
            // 
            this.tbxIhspcode.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxIhspcode.Location = new System.Drawing.Point(69, 8);
            this.tbxIhspcode.Name = "tbxIhspcode";
            this.tbxIhspcode.Size = new System.Drawing.Size(105, 24);
            this.tbxIhspcode.TabIndex = 65;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 11F);
            this.label4.Location = new System.Drawing.Point(13, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 66;
            this.label4.Text = "住院号:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 11F);
            this.label5.Location = new System.Drawing.Point(2, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 68;
            this.label5.Text = "结算时间:";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("宋体", 11F);
            this.btnSearch.Location = new System.Drawing.Point(394, 38);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(64, 25);
            this.btnSearch.TabIndex = 76;
            this.btnSearch.Text = "查找";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("宋体", 11F);
            this.btnReset.Location = new System.Drawing.Point(459, 38);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(64, 25);
            this.btnReset.TabIndex = 75;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnApprover
            // 
            this.btnApprover.Font = new System.Drawing.Font("宋体", 11F);
            this.btnApprover.Location = new System.Drawing.Point(641, 38);
            this.btnApprover.Name = "btnApprover";
            this.btnApprover.Size = new System.Drawing.Size(64, 25);
            this.btnApprover.TabIndex = 75;
            this.btnApprover.Text = "审批";
            this.btnApprover.UseVisualStyleBackColor = true;
            this.btnApprover.Click += new System.EventHandler(this.btnApprover_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("宋体", 11F);
            this.lblTotal.Location = new System.Drawing.Point(57, 224);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(71, 15);
            this.lblTotal.TabIndex = 98;
            this.lblTotal.Text = "        ";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 11F);
            this.label22.Location = new System.Drawing.Point(19, 224);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(45, 15);
            this.label22.TabIndex = 97;
            this.label22.Text = "合计:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 11F);
            this.label9.Location = new System.Drawing.Point(14, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 96;
            this.label9.Text = "费用详单";
            // 
            // dgvIhspCost
            // 
            this.dgvIhspCost.AllowUserToAddRows = false;
            this.dgvIhspCost.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIhspCost.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIhspCost.ColumnHeadersHeight = 30;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIhspCost.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvIhspCost.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvIhspCost.Location = new System.Drawing.Point(12, 21);
            this.dgvIhspCost.Name = "dgvIhspCost";
            this.dgvIhspCost.ReadOnly = true;
            this.dgvIhspCost.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIhspCost.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvIhspCost.RowHeadersVisible = false;
            this.dgvIhspCost.RowHeadersWidth = 50;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgvIhspCost.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvIhspCost.RowTemplate.Height = 23;
            this.dgvIhspCost.Size = new System.Drawing.Size(693, 200);
            this.dgvIhspCost.TabIndex = 94;
            // 
            // dgvInhospital
            // 
            this.dgvInhospital.AllowUserToAddRows = false;
            this.dgvInhospital.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInhospital.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvInhospital.ColumnHeadersHeight = 30;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInhospital.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvInhospital.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvInhospital.Location = new System.Drawing.Point(12, 6);
            this.dgvInhospital.Name = "dgvInhospital";
            this.dgvInhospital.ReadOnly = true;
            this.dgvInhospital.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInhospital.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvInhospital.RowHeadersVisible = false;
            this.dgvInhospital.RowHeadersWidth = 50;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgvInhospital.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvInhospital.RowTemplate.Height = 23;
            this.dgvInhospital.Size = new System.Drawing.Size(693, 202);
            this.dgvInhospital.TabIndex = 95;
            this.dgvInhospital.SelectionChanged += new System.EventHandler(this.dgvInhospital_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtpStartTime);
            this.panel1.Controls.Add(this.dtpEndTime);
            this.panel1.Controls.Add(this.tbxHspcard);
            this.panel1.Controls.Add(this.tbxName);
            this.panel1.Controls.Add(this.tbxIhspcode);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnApprover);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cmbPatienttype);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(715, 72);
            this.panel1.TabIndex = 100;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 72);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvInhospital);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblTotal);
            this.splitContainer1.Panel2.Controls.Add(this.dgvIhspCost);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2.Controls.Add(this.label22);
            this.splitContainer1.Size = new System.Drawing.Size(715, 472);
            this.splitContainer1.SplitterDistance = 214;
            this.splitContainer1.TabIndex = 99;
            // 
            // FrmIhspChkRetSetle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 544);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmIhspChkRetSetle";
            this.Text = "回退审批";
            this.Activated += new System.EventHandler(this.FrmIhspChkRetSetle_Activated);
            this.Load += new System.EventHandler(this.FrmApprover_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIhspCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInhospital)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPatienttype;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxHspcard;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.TextBox tbxIhspcode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnApprover;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvIhspCost;
        private System.Windows.Forms.DataGridView dgvInhospital;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}