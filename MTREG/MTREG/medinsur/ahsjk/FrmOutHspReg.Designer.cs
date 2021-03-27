namespace MTREG.medinsur.ahsjk
{
    partial class FrmOutHspReg
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
            this.comboCyyy = new System.Windows.Forms.ComboBox();
            this.label50 = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.tbxIhspcode = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.btn_qxcydj = new System.Windows.Forms.Button();
            this.btn_cydj = new System.Windows.Forms.Button();
            this.dgvIhspCase = new System.Windows.Forms.DataGridView();
            this.tbxIhspdiagn = new System.Windows.Forms.TextBox();
            this.tbxIhspicd = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.dtpOutDate = new System.Windows.Forms.DateTimePicker();
            this.cmbDepart = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.tbx_qxyy = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIhspCase)).BeginInit();
            this.SuspendLayout();
            // 
            // comboCyyy
            // 
            this.comboCyyy.Font = new System.Drawing.Font("宋体", 11F);
            this.comboCyyy.FormattingEnabled = true;
            this.comboCyyy.Location = new System.Drawing.Point(300, 50);
            this.comboCyyy.Name = "comboCyyy";
            this.comboCyyy.Size = new System.Drawing.Size(100, 23);
            this.comboCyyy.TabIndex = 164;
            this.comboCyyy.Visible = false;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("宋体", 11F);
            this.label50.Location = new System.Drawing.Point(12, 130);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(75, 15);
            this.label50.TabIndex = 155;
            this.label50.Text = "出院日期:";
            // 
            // tbxName
            // 
            this.tbxName.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxName.Location = new System.Drawing.Point(299, 14);
            this.tbxName.Name = "tbxName";
            this.tbxName.ReadOnly = true;
            this.tbxName.Size = new System.Drawing.Size(100, 24);
            this.tbxName.TabIndex = 149;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("宋体", 11F);
            this.label47.Location = new System.Drawing.Point(228, 54);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(75, 15);
            this.label47.TabIndex = 154;
            this.label47.Text = "出院原因:";
            this.label47.Visible = false;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("宋体", 11F);
            this.label42.Location = new System.Drawing.Point(258, 18);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(45, 15);
            this.label42.TabIndex = 147;
            this.label42.Text = "姓名:";
            // 
            // tbxIhspcode
            // 
            this.tbxIhspcode.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxIhspcode.Location = new System.Drawing.Point(89, 15);
            this.tbxIhspcode.Name = "tbxIhspcode";
            this.tbxIhspcode.ReadOnly = true;
            this.tbxIhspcode.Size = new System.Drawing.Size(100, 24);
            this.tbxIhspcode.TabIndex = 146;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("宋体", 11F);
            this.label43.Location = new System.Drawing.Point(30, 18);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(60, 15);
            this.label43.TabIndex = 145;
            this.label43.Text = "住院号:";
            // 
            // btn_qxcydj
            // 
            this.btn_qxcydj.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_qxcydj.Location = new System.Drawing.Point(248, 224);
            this.btn_qxcydj.Name = "btn_qxcydj";
            this.btn_qxcydj.Size = new System.Drawing.Size(126, 24);
            this.btn_qxcydj.TabIndex = 170;
            this.btn_qxcydj.Text = "取消出院登记";
            this.btn_qxcydj.UseVisualStyleBackColor = true;
            this.btn_qxcydj.Visible = false;
            this.btn_qxcydj.Click += new System.EventHandler(this.btn_qxcydj_Click);
            // 
            // btn_cydj
            // 
            this.btn_cydj.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_cydj.Location = new System.Drawing.Point(149, 224);
            this.btn_cydj.Name = "btn_cydj";
            this.btn_cydj.Size = new System.Drawing.Size(93, 24);
            this.btn_cydj.TabIndex = 169;
            this.btn_cydj.Text = "出院登记";
            this.btn_cydj.UseVisualStyleBackColor = true;
            this.btn_cydj.Visible = false;
            this.btn_cydj.Click += new System.EventHandler(this.btn_cydj_Click);
            // 
            // dgvIhspCase
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIhspCase.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIhspCase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIhspCase.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIhspCase.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvIhspCase.Location = new System.Drawing.Point(84, 109);
            this.dgvIhspCase.Name = "dgvIhspCase";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIhspCase.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvIhspCase.RowHeadersVisible = false;
            this.dgvIhspCase.RowTemplate.Height = 23;
            this.dgvIhspCase.Size = new System.Drawing.Size(100, 79);
            this.dgvIhspCase.TabIndex = 175;
            this.dgvIhspCase.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvIhspCase_KeyDown);
            // 
            // tbxIhspdiagn
            // 
            this.tbxIhspdiagn.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxIhspdiagn.Location = new System.Drawing.Point(85, 87);
            this.tbxIhspdiagn.Name = "tbxIhspdiagn";
            this.tbxIhspdiagn.Size = new System.Drawing.Size(100, 24);
            this.tbxIhspdiagn.TabIndex = 171;
            this.tbxIhspdiagn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxIhspdiagn_KeyDown);
            // 
            // tbxIhspicd
            // 
            this.tbxIhspicd.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxIhspicd.Location = new System.Drawing.Point(300, 88);
            this.tbxIhspicd.Name = "tbxIhspicd";
            this.tbxIhspicd.Size = new System.Drawing.Size(105, 24);
            this.tbxIhspicd.TabIndex = 172;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 11F);
            this.label20.Location = new System.Drawing.Point(200, 93);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(105, 15);
            this.label20.TabIndex = 174;
            this.label20.Text = "出院疾病编码:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 11F);
            this.label22.Location = new System.Drawing.Point(15, 91);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(75, 15);
            this.label22.TabIndex = 173;
            this.label22.Text = "出院诊断:";
            // 
            // dtpOutDate
            // 
            this.dtpOutDate.Font = new System.Drawing.Font("宋体", 11F);
            this.dtpOutDate.Location = new System.Drawing.Point(84, 125);
            this.dtpOutDate.Name = "dtpOutDate";
            this.dtpOutDate.Size = new System.Drawing.Size(146, 24);
            this.dtpOutDate.TabIndex = 176;
            // 
            // cmbDepart
            // 
            this.cmbDepart.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbDepart.FormattingEnabled = true;
            this.cmbDepart.ItemHeight = 15;
            this.cmbDepart.Location = new System.Drawing.Point(89, 51);
            this.cmbDepart.Name = "cmbDepart";
            this.cmbDepart.Size = new System.Drawing.Size(100, 23);
            this.cmbDepart.TabIndex = 177;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 11F);
            this.label13.Location = new System.Drawing.Point(49, 54);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 15);
            this.label13.TabIndex = 179;
            this.label13.Text = "科室:";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(380, 224);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(73, 24);
            this.btnClose.TabIndex = 169;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btn_cydj_Click);
            // 
            // tbx_qxyy
            // 
            this.tbx_qxyy.Font = new System.Drawing.Font("宋体", 11F);
            this.tbx_qxyy.Location = new System.Drawing.Point(125, 159);
            this.tbx_qxyy.Name = "tbx_qxyy";
            this.tbx_qxyy.Size = new System.Drawing.Size(134, 24);
            this.tbx_qxyy.TabIndex = 181;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 11F);
            this.label8.Location = new System.Drawing.Point(1, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 15);
            this.label8.TabIndex = 180;
            this.label8.Text = "取消出院登记原因:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(262, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 15);
            this.label1.TabIndex = 180;
            this.label1.Text = "需要取消出院登记时再填写!";
            // 
            // FrmOutHspReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 260);
            this.Controls.Add(this.dgvIhspCase);
            this.Controls.Add(this.tbx_qxyy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbDepart);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dtpOutDate);
            this.Controls.Add(this.tbxIhspdiagn);
            this.Controls.Add(this.tbxIhspicd);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.btn_qxcydj);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btn_cydj);
            this.Controls.Add(this.comboCyyy);
            this.Controls.Add(this.label50);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.label47);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.tbxIhspcode);
            this.Controls.Add(this.label43);
            this.Name = "FrmOutHspReg";
            this.Text = "出院登记";
            this.Load += new System.EventHandler(this.FrmOutHspReg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIhspCase)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboCyyy;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox tbxIhspcode;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Button btn_qxcydj;
        private System.Windows.Forms.Button btn_cydj;
        private System.Windows.Forms.DataGridView dgvIhspCase;
        private System.Windows.Forms.TextBox tbxIhspdiagn;
        private System.Windows.Forms.TextBox tbxIhspicd;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DateTimePicker dtpOutDate;
        private System.Windows.Forms.ComboBox cmbDepart;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox tbx_qxyy;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
    }
}