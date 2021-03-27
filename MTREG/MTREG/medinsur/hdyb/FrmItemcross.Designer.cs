namespace MTREG.medinsur.hdyb
{
    partial class FrmItemcross
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbxNameOrPincode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbxDrug = new System.Windows.Forms.CheckBox();
            this.cbxStuff = new System.Windows.Forms.CheckBox();
            this.cbxCost = new System.Windows.Forms.CheckBox();
            this.dgvCross = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCross)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbxNameOrPincode);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.cbxDrug);
            this.panel1.Controls.Add(this.cbxStuff);
            this.panel1.Controls.Add(this.cbxCost);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(669, 79);
            this.panel1.TabIndex = 0;
            // 
            // tbxNameOrPincode
            // 
            this.tbxNameOrPincode.Font = new System.Drawing.Font("宋体", 12F);
            this.tbxNameOrPincode.Location = new System.Drawing.Point(140, 49);
            this.tbxNameOrPincode.Name = "tbxNameOrPincode";
            this.tbxNameOrPincode.Size = new System.Drawing.Size(198, 26);
            this.tbxNameOrPincode.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(17, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "名称或拼音简码:";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("宋体", 12F);
            this.btnSearch.Location = new System.Drawing.Point(412, 49);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 27);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbxDrug
            // 
            this.cbxDrug.AutoSize = true;
            this.cbxDrug.Font = new System.Drawing.Font("宋体", 12F);
            this.cbxDrug.Location = new System.Drawing.Point(279, 19);
            this.cbxDrug.Name = "cbxDrug";
            this.cbxDrug.Size = new System.Drawing.Size(59, 20);
            this.cbxDrug.TabIndex = 1;
            this.cbxDrug.Text = "药品";
            this.cbxDrug.UseVisualStyleBackColor = true;
            this.cbxDrug.CheckedChanged += new System.EventHandler(this.cbxDrug_CheckedChanged);
            // 
            // cbxStuff
            // 
            this.cbxStuff.AutoSize = true;
            this.cbxStuff.Font = new System.Drawing.Font("宋体", 12F);
            this.cbxStuff.Location = new System.Drawing.Point(152, 19);
            this.cbxStuff.Name = "cbxStuff";
            this.cbxStuff.Size = new System.Drawing.Size(59, 20);
            this.cbxStuff.TabIndex = 1;
            this.cbxStuff.Text = "材料";
            this.cbxStuff.UseVisualStyleBackColor = true;
            this.cbxStuff.CheckedChanged += new System.EventHandler(this.cbxStuff_CheckedChanged);
            // 
            // cbxCost
            // 
            this.cbxCost.AutoSize = true;
            this.cbxCost.Font = new System.Drawing.Font("宋体", 12F);
            this.cbxCost.Location = new System.Drawing.Point(25, 19);
            this.cbxCost.Name = "cbxCost";
            this.cbxCost.Size = new System.Drawing.Size(59, 20);
            this.cbxCost.TabIndex = 0;
            this.cbxCost.Text = "费用";
            this.cbxCost.UseVisualStyleBackColor = true;
            this.cbxCost.CheckedChanged += new System.EventHandler(this.cbxCost_CheckedChanged);
            // 
            // dgvCross
            // 
            this.dgvCross.AllowUserToAddRows = false;
            this.dgvCross.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCross.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCross.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCross.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCross.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCross.Location = new System.Drawing.Point(0, 79);
            this.dgvCross.Name = "dgvCross";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 11F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCross.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCross.RowTemplate.Height = 23;
            this.dgvCross.Size = new System.Drawing.Size(669, 286);
            this.dgvCross.TabIndex = 1;
            this.dgvCross.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvCross_RowPostPaint);
            // 
            // FrmItemcross
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 365);
            this.Controls.Add(this.dgvCross);
            this.Controls.Add(this.panel1);
            this.Name = "FrmItemcross";
            this.Text = "三目录对照";
            this.Load += new System.EventHandler(this.FrmItemcross_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCross)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox cbxDrug;
        private System.Windows.Forms.CheckBox cbxStuff;
        private System.Windows.Forms.CheckBox cbxCost;
        private System.Windows.Forms.DataGridView dgvCross;
        private System.Windows.Forms.TextBox tbxNameOrPincode;
        private System.Windows.Forms.Label label2;
    }
}