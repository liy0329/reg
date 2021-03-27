namespace MTREG.medinsur
{
    partial class FrmInsurItem
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbInsurtype = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvInsurItem = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxInfo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvArea = new System.Windows.Forms.DataGridView();
            this.tbxAreaCode = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsurItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArea)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbInsurtype
            // 
            this.cmbInsurtype.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbInsurtype.FormattingEnabled = true;
            this.cmbInsurtype.Location = new System.Drawing.Point(91, 8);
            this.cmbInsurtype.Name = "cmbInsurtype";
            this.cmbInsurtype.Size = new System.Drawing.Size(174, 23);
            this.cmbInsurtype.TabIndex = 0;
            this.cmbInsurtype.SelectionChangeCommitted += new System.EventHandler(this.cmbInsurtype_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(21, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "接口类型:";
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("宋体", 11F);
            this.btnSelect.Location = new System.Drawing.Point(587, 38);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 26);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "查询";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Font = new System.Drawing.Font("宋体", 11F);
            this.btnDownload.Location = new System.Drawing.Point(684, 38);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 26);
            this.btnDownload.TabIndex = 2;
            this.btnDownload.Text = "下载";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("宋体", 11F);
            this.btnClose.Location = new System.Drawing.Point(765, 37);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 26);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvInsurItem
            // 
            this.dgvInsurItem.AllowUserToAddRows = false;
            this.dgvInsurItem.AllowUserToDeleteRows = false;
            this.dgvInsurItem.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInsurItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvInsurItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInsurItem.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgvInsurItem.Location = new System.Drawing.Point(6, 66);
            this.dgvInsurItem.Name = "dgvInsurItem";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInsurItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvInsurItem.RowHeadersVisible = false;
            this.dgvInsurItem.RowTemplate.Height = 23;
            this.dgvInsurItem.Size = new System.Drawing.Size(834, 423);
            this.dgvInsurItem.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F);
            this.label2.Location = new System.Drawing.Point(523, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "项目名称或简码:";
            // 
            // tbxInfo
            // 
            this.tbxInfo.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxInfo.Location = new System.Drawing.Point(638, 8);
            this.tbxInfo.Name = "tbxInfo";
            this.tbxInfo.Size = new System.Drawing.Size(148, 24);
            this.tbxInfo.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 11F);
            this.label3.Location = new System.Drawing.Point(269, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "地区名称:";
            // 
            // dgvArea
            // 
            this.dgvArea.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvArea.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvArea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvArea.DefaultCellStyle = dataGridViewCellStyle17;
            this.dgvArea.Location = new System.Drawing.Point(272, 30);
            this.dgvArea.Name = "dgvArea";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvArea.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dgvArea.RowHeadersWidth = 25;
            this.dgvArea.RowTemplate.Height = 23;
            this.dgvArea.Size = new System.Drawing.Size(240, 150);
            this.dgvArea.TabIndex = 5;
            this.dgvArea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvArea_KeyDown);
            // 
            // tbxAreaCode
            // 
            this.tbxAreaCode.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxAreaCode.Location = new System.Drawing.Point(339, 7);
            this.tbxAreaCode.Name = "tbxAreaCode";
            this.tbxAreaCode.Size = new System.Drawing.Size(173, 24);
            this.tbxAreaCode.TabIndex = 4;
            this.tbxAreaCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxAreaCode_KeyDown);
            // 
            // FrmInsurItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 494);
            this.Controls.Add(this.dgvArea);
            this.Controls.Add(this.tbxAreaCode);
            this.Controls.Add(this.tbxInfo);
            this.Controls.Add(this.dgvInsurItem);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbInsurtype);
            this.Name = "FrmInsurItem";
            this.Text = "医保目录信息";
            this.Load += new System.EventHandler(this.FrmInsurItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsurItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbInsurtype;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvInsurItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvArea;
        private System.Windows.Forms.TextBox tbxAreaCode;
    }
}