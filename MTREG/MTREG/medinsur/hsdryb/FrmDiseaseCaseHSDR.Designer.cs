namespace MTREG.medinsur.hsdryb
{
    partial class FrmDiseaseCaseHSDR
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvInsurDisease = new System.Windows.Forms.DataGridView();
            this.btnDownLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsurDisease)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(130, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 22);
            this.label1.TabIndex = 91;
            this.label1.Text = "医保病种信息一览";
            // 
            // dgvInsurDisease
            // 
            this.dgvInsurDisease.AllowDrop = true;
            this.dgvInsurDisease.AllowUserToAddRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInsurDisease.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInsurDisease.ColumnHeadersHeight = 32;
            this.dgvInsurDisease.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvInsurDisease.Location = new System.Drawing.Point(12, 34);
            this.dgvInsurDisease.Name = "dgvInsurDisease";
            this.dgvInsurDisease.ReadOnly = true;
            this.dgvInsurDisease.RowHeadersVisible = false;
            this.dgvInsurDisease.RowHeadersWidth = 200;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvInsurDisease.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInsurDisease.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvInsurDisease.RowTemplate.Height = 38;
            this.dgvInsurDisease.RowTemplate.ReadOnly = true;
            this.dgvInsurDisease.Size = new System.Drawing.Size(465, 372);
            this.dgvInsurDisease.TabIndex = 92;
            // 
            // btnDownLoad
            // 
            this.btnDownLoad.Location = new System.Drawing.Point(539, 34);
            this.btnDownLoad.Name = "btnDownLoad";
            this.btnDownLoad.Size = new System.Drawing.Size(129, 21);
            this.btnDownLoad.TabIndex = 93;
            this.btnDownLoad.Text = "下载医保目录";
            this.btnDownLoad.UseVisualStyleBackColor = true;
            this.btnDownLoad.Click += new System.EventHandler(this.btnDownLoad_Click);
            // 
            // FrmDiseaseCaseHSDR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 418);
            this.Controls.Add(this.btnDownLoad);
            this.Controls.Add(this.dgvInsurDisease);
            this.Controls.Add(this.label1);
            this.Name = "FrmDiseaseCaseHSDR";
            this.Text = "武邑县医保病种信息";
            this.Load += new System.EventHandler(this.FrmDiseaseCaseHSDR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsurDisease)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvInsurDisease;
        private System.Windows.Forms.Button btnDownLoad;
    }
}