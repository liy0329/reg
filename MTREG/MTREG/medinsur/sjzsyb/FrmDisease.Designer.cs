namespace MTREG.medinsur.sjzsyb
{
    partial class FrmDisease
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
            this.cBox_category = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cBox_category
            // 
            this.cBox_category.FormattingEnabled = true;
            this.cBox_category.Location = new System.Drawing.Point(123, 37);
            this.cBox_category.Name = "cBox_category";
            this.cBox_category.Size = new System.Drawing.Size(135, 20);
            this.cBox_category.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.5F);
            this.label2.Location = new System.Drawing.Point(27, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 163;
            this.label2.Text = "病种类别:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(313, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 35);
            this.button1.TabIndex = 164;
            this.button1.Text = "下载病种目录";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column3,
            this.Column7});
            this.dataGridView1.Location = new System.Drawing.Point(21, 92);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(935, 458);
            this.dataGridView1.TabIndex = 165;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(748, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 166;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "illcode";
            this.Column1.HeaderText = "病种编码";
            this.Column1.Name = "Column1";
            this.Column1.Width = 300;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "name";
            this.Column2.HeaderText = "病种名称";
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "pincode";
            this.Column4.HeaderText = "拼音助记码";
            this.Column4.Name = "Column4";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "keyname";
            this.Column3.HeaderText = "病种类别";
            this.Column3.Name = "Column3";
            this.Column3.Width = 150;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "updatetime";
            this.Column7.HeaderText = "变更日期";
            this.Column7.Name = "Column7";
            this.Column7.Width = 200;
            // 
            // FrmDisease
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 562);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cBox_category);
            this.Name = "FrmDisease";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "病种目录";
            this.Load += new System.EventHandler(this.FrmDisease_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cBox_category;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}