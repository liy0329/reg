namespace MTREG.medinsur.sjzsyb
{
    partial class FrmDownloadDirectory
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
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cBox_category = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(301, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 34);
            this.button1.TabIndex = 4;
            this.button1.Text = "下载目录";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14.5F);
            this.label4.Location = new System.Drawing.Point(41, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 170;
            this.label4.Text = "项目类别:";
            // 
            // cBox_category
            // 
            this.cBox_category.FormattingEnabled = true;
            this.cBox_category.Location = new System.Drawing.Point(137, 26);
            this.cBox_category.Name = "cBox_category";
            this.cBox_category.Size = new System.Drawing.Size(135, 20);
            this.cBox_category.TabIndex = 169;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Font = new System.Drawing.Font("宋体", 12F);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(84, 71);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 16);
            this.label9.TabIndex = 171;
            this.label9.Text = "label7";
            this.label9.Visible = false;
            // 
            // FrmDownloadDirectory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 145);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cBox_category);
            this.Controls.Add(this.button1);
            this.Name = "FrmDownloadDirectory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "三目下载 ";
            this.Load += new System.EventHandler(this.FrmDownloadDirectory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cBox_category;
        private System.Windows.Forms.Label label9;
    }
}