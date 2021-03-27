namespace MTREG.medinsur
{
    partial class FrmItemForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvItemfrom = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.cmbInsurItem = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemfrom)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(200, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "接口医药项目对照";
            // 
            // dgvItemfrom
            // 
            this.dgvItemfrom.AllowUserToAddRows = false;
            this.dgvItemfrom.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItemfrom.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvItemfrom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItemfrom.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvItemfrom.Location = new System.Drawing.Point(12, 88);
            this.dgvItemfrom.Name = "dgvItemfrom";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItemfrom.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvItemfrom.RowHeadersVisible = false;
            this.dgvItemfrom.RowTemplate.Height = 23;
            this.dgvItemfrom.Size = new System.Drawing.Size(562, 310);
            this.dgvItemfrom.TabIndex = 2;
            this.dgvItemfrom.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvItemfrom_CellBeginEdit);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("宋体", 11F);
            this.btnSave.Location = new System.Drawing.Point(181, 405);
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
            this.btnCancel.Location = new System.Drawing.Point(313, 405);
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
            this.btnClose.Location = new System.Drawing.Point(433, 405);
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
            this.btnIn.Location = new System.Drawing.Point(55, 405);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(86, 30);
            this.btnIn.TabIndex = 5;
            this.btnIn.Text = "导入";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // cmbInsurItem
            // 
            this.cmbInsurItem.Font = new System.Drawing.Font("宋体", 13F);
            this.cmbInsurItem.FormattingEnabled = true;
            this.cmbInsurItem.Location = new System.Drawing.Point(94, 56);
            this.cmbInsurItem.Name = "cmbInsurItem";
            this.cmbInsurItem.Size = new System.Drawing.Size(173, 25);
            this.cmbInsurItem.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 13F);
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "接口类型:";
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("宋体", 11F);
            this.btnSelect.Location = new System.Drawing.Point(450, 52);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(86, 30);
            this.btnSelect.TabIndex = 5;
            this.btnSelect.Text = "查询";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // FrmItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 447);
            this.Controls.Add(this.cmbInsurItem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvItemfrom);
            this.Controls.Add(this.label1);
            this.Name = "FrmItemForm";
            this.Text = "医药项目对照";
            this.Load += new System.EventHandler(this.FrmItemForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemfrom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvItemfrom;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.ComboBox cmbInsurItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSelect;

    }
}