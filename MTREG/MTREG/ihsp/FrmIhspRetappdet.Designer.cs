namespace MTREG.ihsp
{
    partial class FrmIhspRetappdet
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
            this.lblDepart = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvRetappdet = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBillcode = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRetappdet)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDepart
            // 
            this.lblDepart.AutoSize = true;
            this.lblDepart.Font = new System.Drawing.Font("宋体", 11F);
            this.lblDepart.Location = new System.Drawing.Point(216, 11);
            this.lblDepart.Name = "lblDepart";
            this.lblDepart.Size = new System.Drawing.Size(52, 15);
            this.lblDepart.TabIndex = 113;
            this.lblDepart.Text = "×××";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 11F);
            this.label7.Location = new System.Drawing.Point(178, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 15);
            this.label7.TabIndex = 107;
            this.label7.Text = "科室:";
            // 
            // dgvRetappdet
            // 
            this.dgvRetappdet.AllowUserToAddRows = false;
            this.dgvRetappdet.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRetappdet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRetappdet.ColumnHeadersHeight = 30;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRetappdet.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRetappdet.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvRetappdet.Location = new System.Drawing.Point(14, 33);
            this.dgvRetappdet.Name = "dgvRetappdet";
            this.dgvRetappdet.ReadOnly = true;
            this.dgvRetappdet.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRetappdet.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRetappdet.RowHeadersVisible = false;
            this.dgvRetappdet.RowHeadersWidth = 50;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgvRetappdet.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRetappdet.RowTemplate.Height = 23;
            this.dgvRetappdet.Size = new System.Drawing.Size(562, 302);
            this.dgvRetappdet.TabIndex = 128;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("宋体", 11F);
            this.btnClose.Location = new System.Drawing.Point(498, 352);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(77, 27);
            this.btnClose.TabIndex = 131;
            this.btnClose.Text = "取消";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("宋体", 11F);
            this.btnOk.Location = new System.Drawing.Point(420, 352);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(77, 27);
            this.btnOk.TabIndex = 130;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("宋体", 11F);
            this.lblTotal.Location = new System.Drawing.Point(62, 339);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(39, 15);
            this.lblTotal.TabIndex = 133;
            this.lblTotal.Text = "xxxx";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 11F);
            this.label22.Location = new System.Drawing.Point(23, 339);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(45, 15);
            this.label22.TabIndex = 132;
            this.label22.Text = "合计:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(26, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 107;
            this.label1.Text = "单号:";
            // 
            // lblBillcode
            // 
            this.lblBillcode.AutoSize = true;
            this.lblBillcode.Font = new System.Drawing.Font("宋体", 11F);
            this.lblBillcode.Location = new System.Drawing.Point(65, 11);
            this.lblBillcode.Name = "lblBillcode";
            this.lblBillcode.Size = new System.Drawing.Size(52, 15);
            this.lblBillcode.TabIndex = 113;
            this.lblBillcode.Text = "×××";
            // 
            // FrmIhspRetappdet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 390);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dgvRetappdet);
            this.Controls.Add(this.lblBillcode);
            this.Controls.Add(this.lblDepart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Name = "FrmIhspRetappdet";
            this.Text = "费用明细";
            this.Load += new System.EventHandler(this.FrmIhspRetappdet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRetappdet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDepart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvRetappdet;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBillcode;
    }
}