namespace MTREG.clinic
{
    partial class FrmSearchRegister
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpEtime = new System.Windows.Forms.DateTimePicker();
            this.dtpStime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxPatientName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvRegister = new System.Windows.Forms.DataGridView();
            this.btnOk = new System.Windows.Forms.Button();
            this.tbxHspcard = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegister)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(334, 34);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(68, 30);
            this.btnSearch.TabIndex = 134;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSearch_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(233, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 16);
            this.label1.TabIndex = 131;
            this.label1.Text = "至";
            // 
            // dtpEtime
            // 
            this.dtpEtime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpEtime.Location = new System.Drawing.Point(260, 4);
            this.dtpEtime.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dtpEtime.Name = "dtpEtime";
            this.dtpEtime.Size = new System.Drawing.Size(142, 26);
            this.dtpEtime.TabIndex = 141;
            this.dtpEtime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpEtime_KeyDown);
            // 
            // dtpStime
            // 
            this.dtpStime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpStime.Location = new System.Drawing.Point(88, 5);
            this.dtpStime.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dtpStime.Name = "dtpStime";
            this.dtpStime.Size = new System.Drawing.Size(140, 26);
            this.dtpStime.TabIndex = 140;
            this.dtpStime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpStime_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 130;
            this.label2.Text = "挂号时间:";
            // 
            // tbxPatientName
            // 
            this.tbxPatientName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxPatientName.Location = new System.Drawing.Point(477, 4);
            this.tbxPatientName.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbxPatientName.Name = "tbxPatientName";
            this.tbxPatientName.Size = new System.Drawing.Size(109, 26);
            this.tbxPatientName.TabIndex = 0;
            this.tbxPatientName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxPatientName_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(411, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 134;
            this.label3.Text = "姓  名:";
            // 
            // dgvRegister
            // 
            this.dgvRegister.AllowUserToAddRows = false;
            this.dgvRegister.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRegister.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRegister.ColumnHeadersHeight = 40;
            this.dgvRegister.Location = new System.Drawing.Point(7, 83);
            this.dgvRegister.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dgvRegister.Name = "dgvRegister";
            this.dgvRegister.RowHeadersVisible = false;
            this.dgvRegister.RowTemplate.Height = 23;
            this.dgvRegister.Size = new System.Drawing.Size(645, 332);
            this.dgvRegister.TabIndex = 135;
            this.dgvRegister.DoubleClick += new System.EventHandler(this.dgvRegister_DoubleClick);
            this.dgvRegister.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvRegister_KeyDown);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(451, 34);
            this.btnOk.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(68, 30);
            this.btnOk.TabIndex = 136;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            this.btnOk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnOk_KeyDown);
            // 
            // tbxHspcard
            // 
            this.tbxHspcard.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxHspcard.Location = new System.Drawing.Point(81, 36);
            this.tbxHspcard.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbxHspcard.Name = "tbxHspcard";
            this.tbxHspcard.Size = new System.Drawing.Size(193, 26);
            this.tbxHspcard.TabIndex = 142;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(15, 41);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 143;
            this.label4.Text = "卡 号:";
            // 
            // FrmSearchRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 429);
            this.Controls.Add(this.tbxHspcard);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dgvRegister);
            this.Controls.Add(this.tbxPatientName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpEtime);
            this.Controls.Add(this.dtpStime);
            this.Controls.Add(this.label2);
            this.Name = "FrmSearchRegister";
            this.Text = "挂号记录信息";
            this.Load += new System.EventHandler(this.FrmSearchRegister_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegister)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpEtime;
        private System.Windows.Forms.DateTimePicker dtpStime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxPatientName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvRegister;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox tbxHspcard;
        private System.Windows.Forms.Label label4;
    }
}