namespace MTREG.ihsp
{
    partial class FrmDiagn
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnConsole = new System.Windows.Forms.Button();
            this.tbxDiagn = new System.Windows.Forms.TextBox();
            this.dgvDiagn = new System.Windows.Forms.DataGridView();
            this.icd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.icdname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.lbxDiagn = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiagn)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("宋体", 13F);
            this.btnAdd.Location = new System.Drawing.Point(442, 15);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 29);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("宋体", 13F);
            this.btnOk.Location = new System.Drawing.Point(345, 318);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(80, 29);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnConsole
            // 
            this.btnConsole.Font = new System.Drawing.Font("宋体", 13F);
            this.btnConsole.Location = new System.Drawing.Point(432, 318);
            this.btnConsole.Name = "btnConsole";
            this.btnConsole.Size = new System.Drawing.Size(80, 29);
            this.btnConsole.TabIndex = 0;
            this.btnConsole.Text = "取消";
            this.btnConsole.UseVisualStyleBackColor = true;
            this.btnConsole.Click += new System.EventHandler(this.btnConsole_Click);
            // 
            // tbxDiagn
            // 
            this.tbxDiagn.Font = new System.Drawing.Font("宋体", 13F);
            this.tbxDiagn.Location = new System.Drawing.Point(116, 15);
            this.tbxDiagn.Name = "tbxDiagn";
            this.tbxDiagn.Size = new System.Drawing.Size(309, 27);
            this.tbxDiagn.TabIndex = 1;
            this.tbxDiagn.TextChanged += new System.EventHandler(this.tbxDiagn_TextChanged);
            this.tbxDiagn.Enter += new System.EventHandler(this.tbxDiagn_Enter);
            this.tbxDiagn.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbxDiagn_KeyUP);
            this.tbxDiagn.Leave += new System.EventHandler(this.tbxDiagn_Leave);
            this.tbxDiagn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbxDiagn_MouseDown);
            // 
            // dgvDiagn
            // 
            this.dgvDiagn.AllowUserToAddRows = false;
            this.dgvDiagn.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 13F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDiagn.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDiagn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiagn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.icd,
            this.icdname,
            this.delete});
            this.dgvDiagn.Location = new System.Drawing.Point(5, 55);
            this.dgvDiagn.Name = "dgvDiagn";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvDiagn.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDiagn.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvDiagn.RowTemplate.Height = 30;
            this.dgvDiagn.Size = new System.Drawing.Size(517, 253);
            this.dgvDiagn.TabIndex = 2;
            this.dgvDiagn.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDiagn_CellContentClick);
            this.dgvDiagn.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDiagn_RowPostPaint);
            // 
            // icd
            // 
            this.icd.HeaderText = "疾病编码";
            this.icd.Name = "icd";
            this.icd.Width = 110;
            // 
            // icdname
            // 
            this.icdname.HeaderText = "疾病名称";
            this.icdname.Name = "icdname";
            this.icdname.Width = 262;
            // 
            // delete
            // 
            this.delete.HeaderText = "删除";
            this.delete.Name = "delete";
            this.delete.Text = "删除";
            this.delete.ToolTipText = "删除";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 13F);
            this.label1.Location = new System.Drawing.Point(15, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "名称或简码:";
            // 
            // lbxDiagn
            // 
            this.lbxDiagn.Font = new System.Drawing.Font("宋体", 13F);
            this.lbxDiagn.FormattingEnabled = true;
            this.lbxDiagn.ItemHeight = 17;
            this.lbxDiagn.Location = new System.Drawing.Point(116, 43);
            this.lbxDiagn.Name = "lbxDiagn";
            this.lbxDiagn.Size = new System.Drawing.Size(309, 106);
            this.lbxDiagn.TabIndex = 92;
            this.lbxDiagn.Visible = false;
            this.lbxDiagn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbxDiagn_KeyDown);
            this.lbxDiagn.Leave += new System.EventHandler(this.lbxDiagn_Leave);
            this.lbxDiagn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbxDiagn_MouseDown);
            // 
            // FrmDiagn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 353);
            this.Controls.Add(this.lbxDiagn);
            this.Controls.Add(this.tbxDiagn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDiagn);
            this.Controls.Add(this.btnConsole);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnAdd);
            this.Name = "FrmDiagn";
            this.Text = "添加门诊疾病";
            this.Load += new System.EventHandler(this.FrmDiagn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiagn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnConsole;
        private System.Windows.Forms.TextBox tbxDiagn;
        private System.Windows.Forms.DataGridView dgvDiagn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbxDiagn;
        private System.Windows.Forms.DataGridViewTextBoxColumn icd;
        private System.Windows.Forms.DataGridViewTextBoxColumn icdname;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
    }
}