namespace MTREG.ihsp
{
    partial class FrmIhspGua
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEnddate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.tbxAmt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxMemo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnGua = new System.Windows.Forms.Button();
            this.dgvGuarantee = new System.Windows.Forms.DataGridView();
            this.btnRet = new System.Windows.Forms.Button();
            this.lblDepart = new System.Windows.Forms.Label();
            this.lblIhspcode = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbDoctor = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbDepart = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuarantee)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 11F);
            this.label9.Location = new System.Drawing.Point(480, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 15);
            this.label9.TabIndex = 34;
            this.label9.Text = "科室:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F);
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(291, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 36;
            this.label2.Text = "担保人:";
            // 
            // dtpEnddate
            // 
            this.dtpEnddate.Font = new System.Drawing.Font("宋体", 11F);
            this.dtpEnddate.Location = new System.Drawing.Point(93, 77);
            this.dtpEnddate.Name = "dtpEnddate";
            this.dtpEnddate.Size = new System.Drawing.Size(147, 24);
            this.dtpEnddate.TabIndex = 6;
            this.dtpEnddate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpEnddate_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 11F);
            this.label11.ForeColor = System.Drawing.Color.Blue;
            this.label11.Location = new System.Drawing.Point(23, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 15);
            this.label11.TabIndex = 38;
            this.label11.Text = "担保期限:";
            // 
            // tbxAmt
            // 
            this.tbxAmt.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxAmt.Location = new System.Drawing.Point(349, 77);
            this.tbxAmt.Name = "tbxAmt";
            this.tbxAmt.Size = new System.Drawing.Size(109, 24);
            this.tbxAmt.TabIndex = 7;
            this.tbxAmt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxAmt_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 11F);
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(276, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 40;
            this.label5.Text = "担保金额:";
            // 
            // tbxMemo
            // 
            this.tbxMemo.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxMemo.Location = new System.Drawing.Point(93, 104);
            this.tbxMemo.Name = "tbxMemo";
            this.tbxMemo.Size = new System.Drawing.Size(309, 24);
            this.tbxMemo.TabIndex = 8;
            this.tbxMemo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxMemo_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 11F);
            this.label3.Location = new System.Drawing.Point(22, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 44;
            this.label3.Text = "担保说明:";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("宋体", 11F);
            this.btnClose.Location = new System.Drawing.Point(568, 107);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(62, 22);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnClose_KeyDown);
            // 
            // btnGua
            // 
            this.btnGua.Font = new System.Drawing.Font("宋体", 11F);
            this.btnGua.Location = new System.Drawing.Point(416, 107);
            this.btnGua.Name = "btnGua";
            this.btnGua.Size = new System.Drawing.Size(62, 23);
            this.btnGua.TabIndex = 1;
            this.btnGua.Text = "担保";
            this.btnGua.UseVisualStyleBackColor = true;
            this.btnGua.Click += new System.EventHandler(this.btnGua_Click);
            this.btnGua.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnGua_KeyDown);
            // 
            // dgvGuarantee
            // 
            this.dgvGuarantee.AllowUserToAddRows = false;
            this.dgvGuarantee.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGuarantee.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvGuarantee.ColumnHeadersHeight = 30;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGuarantee.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvGuarantee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGuarantee.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvGuarantee.Location = new System.Drawing.Point(0, 135);
            this.dgvGuarantee.Name = "dgvGuarantee";
            this.dgvGuarantee.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGuarantee.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvGuarantee.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 11F);
            this.dgvGuarantee.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvGuarantee.RowTemplate.Height = 23;
            this.dgvGuarantee.Size = new System.Drawing.Size(752, 284);
            this.dgvGuarantee.TabIndex = 77;
            this.dgvGuarantee.SelectionChanged += new System.EventHandler(this.dgvGuarantee_SelectionChanged);
            // 
            // btnRet
            // 
            this.btnRet.Font = new System.Drawing.Font("宋体", 11F);
            this.btnRet.Location = new System.Drawing.Point(483, 107);
            this.btnRet.Name = "btnRet";
            this.btnRet.Size = new System.Drawing.Size(79, 23);
            this.btnRet.TabIndex = 2;
            this.btnRet.Text = "取消担保";
            this.btnRet.UseVisualStyleBackColor = true;
            this.btnRet.Click += new System.EventHandler(this.btnRet_Click);
            this.btnRet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnRet_KeyDown);
            // 
            // lblDepart
            // 
            this.lblDepart.AutoSize = true;
            this.lblDepart.Font = new System.Drawing.Font("宋体", 11F);
            this.lblDepart.Location = new System.Drawing.Point(519, 14);
            this.lblDepart.Name = "lblDepart";
            this.lblDepart.Size = new System.Drawing.Size(52, 15);
            this.lblDepart.TabIndex = 34;
            this.lblDepart.Text = "×××";
            // 
            // lblIhspcode
            // 
            this.lblIhspcode.AutoSize = true;
            this.lblIhspcode.Font = new System.Drawing.Font("宋体", 11F);
            this.lblIhspcode.Location = new System.Drawing.Point(387, 14);
            this.lblIhspcode.Name = "lblIhspcode";
            this.lblIhspcode.Size = new System.Drawing.Size(52, 15);
            this.lblIhspcode.TabIndex = 79;
            this.lblIhspcode.Text = "×××";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 11F);
            this.label6.Location = new System.Drawing.Point(333, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 15);
            this.label6.TabIndex = 78;
            this.label6.Text = "住院号:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("宋体", 11F);
            this.lblName.Location = new System.Drawing.Point(61, 14);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(52, 15);
            this.lblName.TabIndex = 81;
            this.lblName.Text = "×××";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 11F);
            this.label7.Location = new System.Drawing.Point(23, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 15);
            this.label7.TabIndex = 80;
            this.label7.Text = "姓名:";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("宋体", 11F);
            this.lblAge.Location = new System.Drawing.Point(261, 14);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(22, 15);
            this.lblAge.TabIndex = 84;
            this.lblAge.Text = "×";
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Font = new System.Drawing.Font("宋体", 11F);
            this.lblSex.Location = new System.Drawing.Point(176, 14);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(22, 15);
            this.lblSex.TabIndex = 85;
            this.lblSex.Text = "×";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 11F);
            this.label8.Location = new System.Drawing.Point(222, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 15);
            this.label8.TabIndex = 82;
            this.label8.Text = "年龄:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 11F);
            this.label10.Location = new System.Drawing.Point(137, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 15);
            this.label10.TabIndex = 83;
            this.label10.Text = "性别:";
            // 
            // cmbDoctor
            // 
            this.cmbDoctor.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbDoctor.FormattingEnabled = true;
            this.cmbDoctor.ItemHeight = 15;
            this.cmbDoctor.Location = new System.Drawing.Point(349, 50);
            this.cmbDoctor.Name = "cmbDoctor";
            this.cmbDoctor.Size = new System.Drawing.Size(109, 23);
            this.cmbDoctor.TabIndex = 5;
            this.cmbDoctor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbDoctor_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 11F);
            this.label12.ForeColor = System.Drawing.Color.Blue;
            this.label12.Location = new System.Drawing.Point(8, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 15);
            this.label12.TabIndex = 36;
            this.label12.Text = "担保人科室:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.cmbDepart);
            this.panel1.Controls.Add(this.cmbDoctor);
            this.panel1.Controls.Add(this.dtpEnddate);
            this.panel1.Controls.Add(this.tbxAmt);
            this.panel1.Controls.Add(this.tbxMemo);
            this.panel1.Controls.Add(this.lblDepart);
            this.panel1.Controls.Add(this.lblAge);
            this.panel1.Controls.Add(this.lblSex);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.lblIhspcode);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnRet);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnGua);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(752, 135);
            this.panel1.TabIndex = 86;
            // 
            // cmbDepart
            // 
            this.cmbDepart.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbDepart.FormattingEnabled = true;
            this.cmbDepart.ItemHeight = 15;
            this.cmbDepart.Location = new System.Drawing.Point(93, 50);
            this.cmbDepart.Name = "cmbDepart";
            this.cmbDepart.Size = new System.Drawing.Size(109, 23);
            this.cmbDepart.TabIndex = 86;
            this.cmbDepart.SelectedValueChanged += new System.EventHandler(this.cmbDepart_SelectedValueChanged);
            this.cmbDepart.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbDepart_KeyUp);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 11F);
            this.button1.Location = new System.Drawing.Point(636, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 23);
            this.button1.TabIndex = 87;
            this.button1.Text = "担保重打";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmIhspGua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 419);
            this.Controls.Add(this.dgvGuarantee);
            this.Controls.Add(this.panel1);
            this.Name = "FrmIhspGua";
            this.Text = "担保";
            this.Activated += new System.EventHandler(this.FrmIhspGua_Activated);
            this.Load += new System.EventHandler(this.FrmIhspGua_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuarantee)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEnddate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbxAmt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxMemo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnGua;
        private System.Windows.Forms.DataGridView dgvGuarantee;
        private System.Windows.Forms.Button btnRet;
        private System.Windows.Forms.Label lblDepart;
        private System.Windows.Forms.Label lblIhspcode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbDoctor;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbDepart;
        private System.Windows.Forms.Button button1;
    }
}