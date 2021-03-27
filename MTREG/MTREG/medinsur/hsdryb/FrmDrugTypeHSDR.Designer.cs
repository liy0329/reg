namespace MTREG.medinsur.hsdryb
{
    partial class FrmDrugTypeHSDR
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
            this.dgvInsurDrugType = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsurDrugType)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvInsurDrugType
            // 
            this.dgvInsurDrugType.AllowDrop = true;
            this.dgvInsurDrugType.AllowUserToAddRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInsurDrugType.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInsurDrugType.ColumnHeadersHeight = 32;
            this.dgvInsurDrugType.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvInsurDrugType.Location = new System.Drawing.Point(2, 34);
            this.dgvInsurDrugType.Name = "dgvInsurDrugType";
            this.dgvInsurDrugType.ReadOnly = true;
            this.dgvInsurDrugType.RowHeadersVisible = false;
            this.dgvInsurDrugType.RowHeadersWidth = 200;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvInsurDrugType.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInsurDrugType.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvInsurDrugType.RowTemplate.Height = 38;
            this.dgvInsurDrugType.RowTemplate.ReadOnly = true;
            this.dgvInsurDrugType.Size = new System.Drawing.Size(570, 393);
            this.dgvInsurDrugType.TabIndex = 93;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(196, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 22);
            this.label1.TabIndex = 94;
            this.label1.Text = "医保医药代码对照";
            // 
            // btnImport
            // 
            this.btnImport.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnImport.Location = new System.Drawing.Point(58, 448);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(130, 26);
            this.btnImport.TabIndex = 95;
            this.btnImport.Text = "导入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEdit.Location = new System.Drawing.Point(252, 448);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(130, 26);
            this.btnEdit.TabIndex = 96;
            this.btnEdit.Text = "编辑";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(452, 449);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 26);
            this.btnSave.TabIndex = 97;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmDrugTypeHSDR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 487);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvInsurDrugType);
            this.Name = "FrmDrugTypeHSDR";
            this.Text = "医药代码对照";
            this.Load += new System.EventHandler(this.FrmDrugTypeHSDR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsurDrugType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInsurDrugType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
    }
}