namespace MTREG.medinsur.sjzsyb
{
    partial class FrmExcle
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
            this.tempProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(139, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "正在导出Excle，请误操作！";
            // 
            // tempProgressBar
            // 
            this.tempProgressBar.Location = new System.Drawing.Point(94, 63);
            this.tempProgressBar.Name = "tempProgressBar";
            this.tempProgressBar.Size = new System.Drawing.Size(316, 26);
            this.tempProgressBar.TabIndex = 1;
            // 
            // FrmExcle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 120);
            this.Controls.Add(this.tempProgressBar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmExcle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmExcle";
            this.Shown += new System.EventHandler(this.FrmExcle_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar tempProgressBar;
    }
}