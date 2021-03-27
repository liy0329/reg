namespace MTREG.medinsur.gzsnh
{
    partial class FrmGzsnhOhsp
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
            this.dgvIhspCase = new System.Windows.Forms.DataGridView();
            this.tbxReason = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbDepart = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpOutDate = new System.Windows.Forms.DateTimePicker();
            this.tbxIhspdiagn = new System.Windows.Forms.TextBox();
            this.tbxIhspicd = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.btn_qxcydj = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOuthsp = new System.Windows.Forms.Button();
            this.cmbOutHosId = new System.Windows.Forms.ComboBox();
            this.label50 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.tbxCode = new System.Windows.Forms.TextBox();
            this.cmbTurnMode = new System.Windows.Forms.ComboBox();
            this.label64 = new System.Windows.Forms.Label();
            this.dtpTurnDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lblHisTotal = new System.Windows.Forms.Label();
            this.cmbTreatCode = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIhspCase)).BeginInit();
            this.SuspendLayout();
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
            this.dgvIhspCase.Location = new System.Drawing.Point(94, 112);
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
            this.dgvIhspCase.TabIndex = 196;
            // 
            // tbxReason
            // 
            this.tbxReason.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxReason.Location = new System.Drawing.Point(134, 219);
            this.tbxReason.Name = "tbxReason";
            this.tbxReason.Size = new System.Drawing.Size(134, 24);
            this.tbxReason.TabIndex = 202;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(271, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 15);
            this.label1.TabIndex = 201;
            this.label1.Text = "需要取消出院登记时再填写!";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 11F);
            this.label8.Location = new System.Drawing.Point(10, 222);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 15);
            this.label8.TabIndex = 200;
            this.label8.Text = "取消出院登记原因:";
            // 
            // cmbDepart
            // 
            this.cmbDepart.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbDepart.FormattingEnabled = true;
            this.cmbDepart.ItemHeight = 15;
            this.cmbDepart.Location = new System.Drawing.Point(93, 54);
            this.cmbDepart.Name = "cmbDepart";
            this.cmbDepart.Size = new System.Drawing.Size(100, 23);
            this.cmbDepart.TabIndex = 198;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 11F);
            this.label13.Location = new System.Drawing.Point(23, 58);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 15);
            this.label13.TabIndex = 199;
            this.label13.Text = "出院科室:";
            // 
            // dtpOutDate
            // 
            this.dtpOutDate.Font = new System.Drawing.Font("宋体", 11F);
            this.dtpOutDate.Location = new System.Drawing.Point(93, 17);
            this.dtpOutDate.Name = "dtpOutDate";
            this.dtpOutDate.Size = new System.Drawing.Size(146, 24);
            this.dtpOutDate.TabIndex = 197;
            // 
            // tbxIhspdiagn
            // 
            this.tbxIhspdiagn.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxIhspdiagn.Location = new System.Drawing.Point(94, 90);
            this.tbxIhspdiagn.Name = "tbxIhspdiagn";
            this.tbxIhspdiagn.Size = new System.Drawing.Size(100, 24);
            this.tbxIhspdiagn.TabIndex = 192;
            // 
            // tbxIhspicd
            // 
            this.tbxIhspicd.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxIhspicd.Location = new System.Drawing.Point(320, 93);
            this.tbxIhspicd.Name = "tbxIhspicd";
            this.tbxIhspicd.Size = new System.Drawing.Size(119, 24);
            this.tbxIhspicd.TabIndex = 193;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 11F);
            this.label20.Location = new System.Drawing.Point(221, 98);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(105, 15);
            this.label20.TabIndex = 195;
            this.label20.Text = "出院疾病编码:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 11F);
            this.label22.Location = new System.Drawing.Point(24, 94);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(75, 15);
            this.label22.TabIndex = 194;
            this.label22.Text = "出院诊断:";
            // 
            // btn_qxcydj
            // 
            this.btn_qxcydj.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_qxcydj.Location = new System.Drawing.Point(257, 272);
            this.btn_qxcydj.Name = "btn_qxcydj";
            this.btn_qxcydj.Size = new System.Drawing.Size(126, 24);
            this.btn_qxcydj.TabIndex = 191;
            this.btn_qxcydj.Text = "取消出院登记";
            this.btn_qxcydj.UseVisualStyleBackColor = true;
            this.btn_qxcydj.Visible = false;
            this.btn_qxcydj.Click += new System.EventHandler(this.btn_qxcydj_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(389, 272);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(73, 24);
            this.btnClose.TabIndex = 190;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Visible = false;
            // 
            // btnOuthsp
            // 
            this.btnOuthsp.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOuthsp.Location = new System.Drawing.Point(158, 272);
            this.btnOuthsp.Name = "btnOuthsp";
            this.btnOuthsp.Size = new System.Drawing.Size(93, 24);
            this.btnOuthsp.TabIndex = 189;
            this.btnOuthsp.Text = "出院登记";
            this.btnOuthsp.UseVisualStyleBackColor = true;
            this.btnOuthsp.Visible = false;
            this.btnOuthsp.Click += new System.EventHandler(this.btnOuthsp_Click);
            // 
            // cmbOutHosId
            // 
            this.cmbOutHosId.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbOutHosId.FormattingEnabled = true;
            this.cmbOutHosId.Location = new System.Drawing.Point(320, 55);
            this.cmbOutHosId.Name = "cmbOutHosId";
            this.cmbOutHosId.Size = new System.Drawing.Size(119, 23);
            this.cmbOutHosId.TabIndex = 188;
            this.cmbOutHosId.Visible = false;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("宋体", 11F);
            this.label50.Location = new System.Drawing.Point(24, 20);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(75, 15);
            this.label50.TabIndex = 187;
            this.label50.Text = "出院日期:";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("宋体", 11F);
            this.label47.Location = new System.Drawing.Point(249, 59);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(75, 15);
            this.label47.TabIndex = 186;
            this.label47.Text = "出院状态:";
            this.label47.Visible = false;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("宋体", 11F);
            this.label43.Location = new System.Drawing.Point(249, 22);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(75, 15);
            this.label43.TabIndex = 182;
            this.label43.Text = "治疗方式:";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Font = new System.Drawing.Font("宋体", 11F);
            this.label60.Location = new System.Drawing.Point(220, 136);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(105, 15);
            this.label60.TabIndex = 206;
            this.label60.Text = "转诊转院编码:";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("宋体", 11F);
            this.label56.Location = new System.Drawing.Point(23, 136);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(75, 15);
            this.label56.TabIndex = 205;
            this.label56.Text = "转诊类型:";
            // 
            // tbxCode
            // 
            this.tbxCode.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxCode.Location = new System.Drawing.Point(319, 131);
            this.tbxCode.Name = "tbxCode";
            this.tbxCode.ReadOnly = true;
            this.tbxCode.Size = new System.Drawing.Size(146, 24);
            this.tbxCode.TabIndex = 204;
            // 
            // cmbTurnMode
            // 
            this.cmbTurnMode.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbTurnMode.FormattingEnabled = true;
            this.cmbTurnMode.Location = new System.Drawing.Point(93, 131);
            this.cmbTurnMode.Name = "cmbTurnMode";
            this.cmbTurnMode.Size = new System.Drawing.Size(121, 23);
            this.cmbTurnMode.TabIndex = 203;
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Font = new System.Drawing.Font("宋体", 11F);
            this.label64.Location = new System.Drawing.Point(23, 179);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(75, 15);
            this.label64.TabIndex = 208;
            this.label64.Text = "转院日期:";
            // 
            // dtpTurnDate
            // 
            this.dtpTurnDate.Font = new System.Drawing.Font("宋体", 11F);
            this.dtpTurnDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTurnDate.Location = new System.Drawing.Point(93, 172);
            this.dtpTurnDate.Name = "dtpTurnDate";
            this.dtpTurnDate.Size = new System.Drawing.Size(121, 24);
            this.dtpTurnDate.TabIndex = 207;
            this.dtpTurnDate.Value = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F);
            this.label2.Location = new System.Drawing.Point(224, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 15);
            this.label2.TabIndex = 208;
            this.label2.Text = "住院总费用:";
            // 
            // lblHisTotal
            // 
            this.lblHisTotal.AutoSize = true;
            this.lblHisTotal.Font = new System.Drawing.Font("宋体", 11F);
            this.lblHisTotal.Location = new System.Drawing.Point(312, 179);
            this.lblHisTotal.Name = "lblHisTotal";
            this.lblHisTotal.Size = new System.Drawing.Size(31, 15);
            this.lblHisTotal.TabIndex = 208;
            this.lblHisTotal.Text = "200";
            // 
            // cmbTreatCode
            // 
            this.cmbTreatCode.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbTreatCode.FormattingEnabled = true;
            this.cmbTreatCode.Location = new System.Drawing.Point(320, 20);
            this.cmbTreatCode.Name = "cmbTreatCode";
            this.cmbTreatCode.Size = new System.Drawing.Size(119, 23);
            this.cmbTreatCode.TabIndex = 188;
            this.cmbTreatCode.Visible = false;
            // 
            // FrmGzsnhOhsp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 304);
            this.Controls.Add(this.cmbDepart);
            this.Controls.Add(this.dgvIhspCase);
            this.Controls.Add(this.tbxCode);
            this.Controls.Add(this.lblHisTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label64);
            this.Controls.Add(this.dtpTurnDate);
            this.Controls.Add(this.label60);
            this.Controls.Add(this.label56);
            this.Controls.Add(this.cmbTurnMode);
            this.Controls.Add(this.tbxReason);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dtpOutDate);
            this.Controls.Add(this.tbxIhspdiagn);
            this.Controls.Add(this.tbxIhspicd);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.btn_qxcydj);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOuthsp);
            this.Controls.Add(this.cmbTreatCode);
            this.Controls.Add(this.cmbOutHosId);
            this.Controls.Add(this.label50);
            this.Controls.Add(this.label47);
            this.Controls.Add(this.label43);
            this.Name = "FrmGzsnhOhsp";
            this.Text = "出院登记";
            this.Load += new System.EventHandler(this.FrmGzsnhOhsp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIhspCase)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIhspCase;
        private System.Windows.Forms.TextBox tbxReason;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbDepart;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpOutDate;
        private System.Windows.Forms.TextBox tbxIhspdiagn;
        private System.Windows.Forms.TextBox tbxIhspicd;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btn_qxcydj;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOuthsp;
        private System.Windows.Forms.ComboBox cmbOutHosId;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.TextBox tbxCode;
        private System.Windows.Forms.ComboBox cmbTurnMode;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.DateTimePicker dtpTurnDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblHisTotal;
        private System.Windows.Forms.ComboBox cmbTreatCode;
    }
}