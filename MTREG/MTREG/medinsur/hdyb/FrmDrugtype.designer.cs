namespace MTREG.medinsur.hdyb
{
    partial class FrmDrugtype
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDrugtype = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDrugtype)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 16F);
            this.label1.Location = new System.Drawing.Point(222, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "药品分类对照";
            // 
            // dgvDrugtype
            // 
            this.dgvDrugtype.AllowUserToAddRows = false;
            this.dgvDrugtype.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDrugtype.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDrugtype.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDrugtype.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDrugtype.Location = new System.Drawing.Point(12, 57);
            this.dgvDrugtype.Name = "dgvDrugtype";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDrugtype.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDrugtype.RowHeadersVisible = false;
            this.dgvDrugtype.RowTemplate.Height = 23;
            this.dgvDrugtype.Size = new System.Drawing.Size(562, 283);
            this.dgvDrugtype.TabIndex = 2;
            this.dgvDrugtype.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvDrugtype_CellBeginEdit);
            this.dgvDrugtype.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDrugtype_CellEndEdit);
            this.dgvDrugtype.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvDrugtype_RowsAdded);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("宋体", 11F);
            this.btnSave.Location = new System.Drawing.Point(181, 358);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 30);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("宋体", 11F);
            this.btnCancel.Location = new System.Drawing.Point(314, 358);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("宋体", 11F);
            this.btnClose.Location = new System.Drawing.Point(447, 358);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 30);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnIn
            // 
            this.btnIn.Font = new System.Drawing.Font("宋体", 11F);
            this.btnIn.Location = new System.Drawing.Point(48, 358);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(86, 30);
            this.btnIn.TabIndex = 4;
            this.btnIn.Text = "导入";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // FrmDrugtype
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 402);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvDrugtype);
            this.Controls.Add(this.label1);
            this.Name = "FrmDrugtype";
            this.Text = "药品分类对照";
            this.Load += new System.EventHandler(this.FrmDrugtype_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDrugtype)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDrugtype;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnIn;


    }
}