namespace MTREG.medinsur
{
    partial class FrmCostTransfer
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxSelectAll = new System.Windows.Forms.CheckBox();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.cmbPatienttype = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ischecked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvInhospital = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInhospital)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbxSelectAll);
            this.panel1.Controls.Add(this.btnTransfer);
            this.panel1.Controls.Add(this.cmbPatienttype);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1097, 86);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // cbxSelectAll
            // 
            this.cbxSelectAll.AutoSize = true;
            this.cbxSelectAll.Location = new System.Drawing.Point(22, 63);
            this.cbxSelectAll.Name = "cbxSelectAll";
            this.cbxSelectAll.Size = new System.Drawing.Size(48, 16);
            this.cbxSelectAll.TabIndex = 61;
            this.cbxSelectAll.Text = "全选";
            this.cbxSelectAll.UseVisualStyleBackColor = true;
            this.cbxSelectAll.CheckedChanged += new System.EventHandler(this.cbxSelectAll_CheckedChanged);
            // 
            // btnTransfer
            // 
            this.btnTransfer.Font = new System.Drawing.Font("宋体", 11F);
            this.btnTransfer.Location = new System.Drawing.Point(369, 15);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(85, 32);
            this.btnTransfer.TabIndex = 60;
            this.btnTransfer.Text = "预决算";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // cmbPatienttype
            // 
            this.cmbPatienttype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPatienttype.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbPatienttype.FormattingEnabled = true;
            this.cmbPatienttype.ItemHeight = 15;
            this.cmbPatienttype.Location = new System.Drawing.Point(125, 21);
            this.cmbPatienttype.Name = "cmbPatienttype";
            this.cmbPatienttype.Size = new System.Drawing.Size(118, 23);
            this.cmbPatienttype.TabIndex = 58;
            this.cmbPatienttype.SelectedValueChanged += new System.EventHandler(this.cmbPatienttype_SelectedValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 11F);
            this.label8.Location = new System.Drawing.Point(44, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 15);
            this.label8.TabIndex = 59;
            this.label8.Text = "接口类型:";
            // 
            // ischecked
            // 
            this.ischecked.HeaderText = "Column1";
            this.ischecked.Name = "ischecked";
            this.ischecked.ReadOnly = true;
            this.ischecked.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ischecked.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgvInhospital
            // 
            this.dgvInhospital.AllowUserToAddRows = false;
            this.dgvInhospital.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
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
            this.dgvInhospital.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ischecked});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInhospital.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvInhospital.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvInhospital.Location = new System.Drawing.Point(0, 88);
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
            this.dgvInhospital.Size = new System.Drawing.Size(712, 495);
            this.dgvInhospital.TabIndex = 34;
            this.dgvInhospital.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvInhospital_CurrentCellDirtyStateChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(718, 88);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(367, 486);
            this.textBox1.TabIndex = 35;
            // 
            // FrmCostTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 586);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dgvInhospital);
            this.Controls.Add(this.panel1);
            this.Name = "FrmCostTransfer";
            this.Text = "批量预结算";
            this.Load += new System.EventHandler(this.FrmCostTransfer_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInhospital)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.ComboBox cmbPatienttype;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cbxSelectAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ischecked;
        private System.Windows.Forms.DataGridView dgvInhospital;
        private System.Windows.Forms.TextBox textBox1;
    }
}