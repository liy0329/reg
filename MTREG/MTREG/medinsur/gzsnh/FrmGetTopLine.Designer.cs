namespace MTREG.medinsur.gzsnh
{
    partial class FrmGetTopLine
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
            this.cbx_bclx = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbx_cyzd = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.cbx_zlfs = new System.Windows.Forms.ComboBox();
            this.tbx_year = new System.Windows.Forms.TextBox();
            this.tbx_result = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbx_bclx
            // 
            this.cbx_bclx.FormattingEnabled = true;
            this.cbx_bclx.Location = new System.Drawing.Point(352, 446);
            this.cbx_bclx.Name = "cbx_bclx";
            this.cbx_bclx.Size = new System.Drawing.Size(147, 20);
            this.cbx_bclx.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(293, 448);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 23;
            this.label4.Text = "补偿类型";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(48, 449);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "出院诊断";
            // 
            // cbx_cyzd
            // 
            this.cbx_cyzd.FormattingEnabled = true;
            this.cbx_cyzd.Location = new System.Drawing.Point(108, 448);
            this.cbx_cyzd.Name = "cbx_cyzd";
            this.cbx_cyzd.Size = new System.Drawing.Size(121, 20);
            this.cbx_cyzd.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(291, 406);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "治疗方式";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(236, 484);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(70, 23);
            this.btnOk.TabIndex = 19;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cbx_zlfs
            // 
            this.cbx_zlfs.FormattingEnabled = true;
            this.cbx_zlfs.Location = new System.Drawing.Point(352, 402);
            this.cbx_zlfs.Name = "cbx_zlfs";
            this.cbx_zlfs.Size = new System.Drawing.Size(147, 20);
            this.cbx_zlfs.TabIndex = 18;
            // 
            // tbx_year
            // 
            this.tbx_year.Location = new System.Drawing.Point(105, 403);
            this.tbx_year.Name = "tbx_year";
            this.tbx_year.Size = new System.Drawing.Size(124, 21);
            this.tbx_year.TabIndex = 17;
            // 
            // tbx_result
            // 
            this.tbx_result.Location = new System.Drawing.Point(34, 23);
            this.tbx_result.Multiline = true;
            this.tbx_result.Name = "tbx_result";
            this.tbx_result.Size = new System.Drawing.Size(563, 373);
            this.tbx_result.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(48, 406);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 25;
            this.label1.Text = "年份";
            // 
            // FrmGetTopLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 520);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbx_bclx);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbx_cyzd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cbx_zlfs);
            this.Controls.Add(this.tbx_year);
            this.Controls.Add(this.tbx_result);
            this.Name = "FrmGetTopLine";
            this.Text = "获取住院封顶线";
            this.Load += new System.EventHandler(this.FrmGetTopLine_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbx_bclx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbx_cyzd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox cbx_zlfs;
        private System.Windows.Forms.TextBox tbx_year;
        private System.Windows.Forms.TextBox tbx_result;
        private System.Windows.Forms.Label label1;
    }
}