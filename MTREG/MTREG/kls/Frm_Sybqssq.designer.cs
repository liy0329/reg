namespace MTREG.medinsur.gzsyb
{
    partial class Frm_Sybqssq
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_qsqh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_qssq = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.cbx_bxlb = new System.Windows.Forms.ComboBox();
            this.cbx_qslb = new System.Windows.Forms.ComboBox();
            this.btn_print = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "清算期号：";
            // 
            // tbx_qsqh
            // 
            this.tbx_qsqh.Location = new System.Drawing.Point(144, 40);
            this.tbx_qsqh.Name = "tbx_qsqh";
            this.tbx_qsqh.Size = new System.Drawing.Size(100, 21);
            this.tbx_qsqh.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "保险类别：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "清算类别：";
            // 
            // btn_qssq
            // 
            this.btn_qssq.Location = new System.Drawing.Point(32, 150);
            this.btn_qssq.Name = "btn_qssq";
            this.btn_qssq.Size = new System.Drawing.Size(75, 23);
            this.btn_qssq.TabIndex = 4;
            this.btn_qssq.Text = "申请清算";
            this.btn_qssq.UseVisualStyleBackColor = true;
            this.btn_qssq.Click += new System.EventHandler(this.btn_qssq_Click);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(223, 150);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 5;
            this.btn_close.Text = "关闭";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // cbx_bxlb
            // 
            this.cbx_bxlb.FormattingEnabled = true;
            this.cbx_bxlb.Location = new System.Drawing.Point(143, 74);
            this.cbx_bxlb.Name = "cbx_bxlb";
            this.cbx_bxlb.Size = new System.Drawing.Size(121, 20);
            this.cbx_bxlb.TabIndex = 6;
            // 
            // cbx_qslb
            // 
            this.cbx_qslb.FormattingEnabled = true;
            this.cbx_qslb.Location = new System.Drawing.Point(143, 105);
            this.cbx_qslb.Name = "cbx_qslb";
            this.cbx_qslb.Size = new System.Drawing.Size(121, 20);
            this.cbx_qslb.TabIndex = 7;
            // 
            // btn_print
            // 
            this.btn_print.Location = new System.Drawing.Point(127, 150);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(75, 23);
            this.btn_print.TabIndex = 8;
            this.btn_print.Text = "打印";
            this.btn_print.UseVisualStyleBackColor = true;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // Frm_Sybqssq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 249);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.cbx_qslb);
            this.Controls.Add(this.cbx_bxlb);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_qssq);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbx_qsqh);
            this.Controls.Add(this.label1);
            this.Name = "Frm_Sybqssq";
            this.Text = "省医保清算申请";
            this.Load += new System.EventHandler(this.Frm_Sybqssq_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_qsqh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_qssq;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.ComboBox cbx_bxlb;
        private System.Windows.Forms.ComboBox cbx_qslb;
        private System.Windows.Forms.Button btn_print;
    }
}