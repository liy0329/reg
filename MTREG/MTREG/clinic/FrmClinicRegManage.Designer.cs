namespace MTREG.clinic
{
    partial class FrmClinicRegManage
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
            this.tbxHspcard = new System.Windows.Forms.TextBox();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxStatus = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnReprint = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnChangeInfo = new System.Windows.Forms.Button();
            this.btnDepart = new System.Windows.Forms.Button();
            this.dgvRegister = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRetCard = new System.Windows.Forms.Button();
            this.dgvCostdet = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegister)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostdet)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxHspcard
            // 
            this.tbxHspcard.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxHspcard.Location = new System.Drawing.Point(194, 8);
            this.tbxHspcard.Name = "tbxHspcard";
            this.tbxHspcard.Size = new System.Drawing.Size(140, 24);
            this.tbxHspcard.TabIndex = 2;
            this.tbxHspcard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxHspcard_KeyDown);
            // 
            // tbxName
            // 
            this.tbxName.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxName.Location = new System.Drawing.Point(56, 8);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(82, 24);
            this.tbxName.TabIndex = 1;
            this.tbxName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbxName_KeyUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 11F);
            this.label6.Location = new System.Drawing.Point(147, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 15);
            this.label6.TabIndex = 51;
            this.label6.Text = "卡号:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F);
            this.label2.Location = new System.Drawing.Point(8, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 50;
            this.label2.Text = "姓名:";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Font = new System.Drawing.Font("宋体", 11F);
            this.dtpEndTime.Location = new System.Drawing.Point(245, 37);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(128, 24);
            this.dtpEndTime.TabIndex = 53;
            this.dtpEndTime.ValueChanged += new System.EventHandler(this.dtpEndTime_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(217, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 15);
            this.label1.TabIndex = 55;
            this.label1.Text = "至";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Font = new System.Drawing.Font("宋体", 11F);
            this.dtpStartTime.Location = new System.Drawing.Point(83, 37);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(128, 24);
            this.dtpStartTime.TabIndex = 52;
            this.dtpStartTime.ValueChanged += new System.EventHandler(this.dtpStartTime_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 11F);
            this.label5.Location = new System.Drawing.Point(7, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 54;
            this.label5.Text = "挂号时间:";
            // 
            // cbxStatus
            // 
            this.cbxStatus.AutoSize = true;
            this.cbxStatus.Font = new System.Drawing.Font("宋体", 11F);
            this.cbxStatus.Location = new System.Drawing.Point(342, 10);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(56, 19);
            this.cbxStatus.TabIndex = 75;
            this.cbxStatus.Text = "退号";
            this.cbxStatus.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("宋体", 11F);
            this.btnSearch.Location = new System.Drawing.Point(401, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(78, 27);
            this.btnSearch.TabIndex = 77;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("宋体", 11F);
            this.btnReset.Location = new System.Drawing.Point(400, 36);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(78, 27);
            this.btnReset.TabIndex = 76;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnReprint
            // 
            this.btnReprint.Font = new System.Drawing.Font("宋体", 11F);
            this.btnReprint.Location = new System.Drawing.Point(694, 35);
            this.btnReprint.Name = "btnReprint";
            this.btnReprint.Size = new System.Drawing.Size(78, 27);
            this.btnReprint.TabIndex = 80;
            this.btnReprint.Text = "重打发票";
            this.btnReprint.UseVisualStyleBackColor = true;
            this.btnReprint.Click += new System.EventHandler(this.btnReprint_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("宋体", 11F);
            this.btnBack.Location = new System.Drawing.Point(778, 34);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(78, 27);
            this.btnBack.TabIndex = 81;
            this.btnBack.Text = "退号";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Visible = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnChangeInfo
            // 
            this.btnChangeInfo.Font = new System.Drawing.Font("宋体", 11F);
            this.btnChangeInfo.Location = new System.Drawing.Point(610, 35);
            this.btnChangeInfo.Name = "btnChangeInfo";
            this.btnChangeInfo.Size = new System.Drawing.Size(78, 27);
            this.btnChangeInfo.TabIndex = 78;
            this.btnChangeInfo.Text = "信息修改";
            this.btnChangeInfo.UseVisualStyleBackColor = true;
            this.btnChangeInfo.Click += new System.EventHandler(this.btnChangeInfo_Click);
            // 
            // btnDepart
            // 
            this.btnDepart.Font = new System.Drawing.Font("宋体", 11F);
            this.btnDepart.Location = new System.Drawing.Point(530, 35);
            this.btnDepart.Name = "btnDepart";
            this.btnDepart.Size = new System.Drawing.Size(78, 27);
            this.btnDepart.TabIndex = 79;
            this.btnDepart.Text = "换科室";
            this.btnDepart.UseVisualStyleBackColor = true;
            this.btnDepart.Visible = false;
            this.btnDepart.Click += new System.EventHandler(this.btnDepart_Click);
            // 
            // dgvRegister
            // 
            this.dgvRegister.AllowUserToAddRows = false;
            this.dgvRegister.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRegister.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRegister.ColumnHeadersHeight = 30;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRegister.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRegister.GridColor = System.Drawing.SystemColors.Control;
            this.dgvRegister.Location = new System.Drawing.Point(0, 73);
            this.dgvRegister.Name = "dgvRegister";
            this.dgvRegister.ReadOnly = true;
            this.dgvRegister.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRegister.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRegister.RowHeadersVisible = false;
            this.dgvRegister.RowHeadersWidth = 50;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgvRegister.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRegister.RowTemplate.Height = 23;
            this.dgvRegister.Size = new System.Drawing.Size(907, 288);
            this.dgvRegister.TabIndex = 82;
            this.dgvRegister.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvRegister_CellPainting);
            this.dgvRegister.SelectionChanged += new System.EventHandler(this.dgvRegister_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRetCard);
            this.panel1.Controls.Add(this.tbxName);
            this.panel1.Controls.Add(this.tbxHspcard);
            this.panel1.Controls.Add(this.dtpStartTime);
            this.panel1.Controls.Add(this.dtpEndTime);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnReprint);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.btnChangeInfo);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnDepart);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.cbxStatus);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(909, 70);
            this.panel1.TabIndex = 83;
            // 
            // btnRetCard
            // 
            this.btnRetCard.Font = new System.Drawing.Font("宋体", 11F);
            this.btnRetCard.Location = new System.Drawing.Point(778, 34);
            this.btnRetCard.Name = "btnRetCard";
            this.btnRetCard.Size = new System.Drawing.Size(78, 27);
            this.btnRetCard.TabIndex = 82;
            this.btnRetCard.Text = "退卡";
            this.btnRetCard.UseVisualStyleBackColor = true;
            this.btnRetCard.Click += new System.EventHandler(this.btnRetCard_Click);
            // 
            // dgvCostdet
            // 
            this.dgvCostdet.AllowUserToAddRows = false;
            this.dgvCostdet.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCostdet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCostdet.ColumnHeadersHeight = 30;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCostdet.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCostdet.GridColor = System.Drawing.SystemColors.Control;
            this.dgvCostdet.Location = new System.Drawing.Point(0, 388);
            this.dgvCostdet.Name = "dgvCostdet";
            this.dgvCostdet.ReadOnly = true;
            this.dgvCostdet.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCostdet.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvCostdet.RowHeadersVisible = false;
            this.dgvCostdet.RowHeadersWidth = 50;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgvCostdet.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvCostdet.RowTemplate.Height = 23;
            this.dgvCostdet.Size = new System.Drawing.Size(907, 180);
            this.dgvCostdet.TabIndex = 84;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 11F);
            this.label3.Location = new System.Drawing.Point(3, 368);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 50;
            this.label3.Text = "费用明细";
            // 
            // FrmClinicRegManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 572);
            this.Controls.Add(this.dgvCostdet);
            this.Controls.Add(this.dgvRegister);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Name = "FrmClinicRegManage";
            this.Text = "挂号管理";
            this.Load += new System.EventHandler(this.FrmRegSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegister)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostdet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxHspcard;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbxStatus;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnReprint;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnChangeInfo;
        private System.Windows.Forms.Button btnDepart;
        private System.Windows.Forms.DataGridView dgvRegister;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvCostdet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRetCard;
    }
}