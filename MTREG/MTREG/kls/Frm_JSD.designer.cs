namespace MTREG.medinsur.gzsyb
{
    partial class Frm_JSD
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CrystalReport11 = new MTREG.medinsur.gzsyb.CrystalReport1();
            this.text_jsd = new System.Windows.Forms.TextBox();
            this.find_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_print = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 41);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1042, 573);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.Load += new System.EventHandler(this.crystalReportViewer1_Load);
            // 
            // CrystalReport11
            // 
            this.CrystalReport11.InitReport += new System.EventHandler(this.CrystalReport11_InitReport);
            // 
            // text_jsd
            // 
            this.text_jsd.Location = new System.Drawing.Point(434, 8);
            this.text_jsd.Name = "text_jsd";
            this.text_jsd.Size = new System.Drawing.Size(100, 21);
            this.text_jsd.TabIndex = 1;
            // 
            // find_btn
            // 
            this.find_btn.Location = new System.Drawing.Point(552, 6);
            this.find_btn.Name = "find_btn";
            this.find_btn.Size = new System.Drawing.Size(75, 23);
            this.find_btn.TabIndex = 2;
            this.find_btn.Text = "查询";
            this.find_btn.UseVisualStyleBackColor = true;
            this.find_btn.Click += new System.EventHandler(this.find_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(387, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "住院号:";
            // 
            // btn_print
            // 
            this.btn_print.Location = new System.Drawing.Point(654, 7);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(75, 23);
            this.btn_print.TabIndex = 4;
            this.btn_print.Text = "打印";
            this.btn_print.UseVisualStyleBackColor = true;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // Frm_JSD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 614);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.find_btn);
            this.Controls.Add(this.text_jsd);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "Frm_JSD";
            this.Text = "省直医保报补单打印";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private CrystalReport1 CrystalReport11;
        private System.Windows.Forms.TextBox text_jsd;
        private System.Windows.Forms.Button find_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_print;
    }
}