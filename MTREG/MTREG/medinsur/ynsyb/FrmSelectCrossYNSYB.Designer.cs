namespace MTREG.medinsur.ynsyb
{
    partial class FrmSelectCrossYNSYB
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
            this.lblItemCross = new System.Windows.Forms.Label();
            this.btnItemCross = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblItemCross
            // 
            this.lblItemCross.AutoSize = true;
            this.lblItemCross.Font = new System.Drawing.Font("宋体", 16F);
            this.lblItemCross.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblItemCross.Location = new System.Drawing.Point(281, 60);
            this.lblItemCross.Name = "lblItemCross";
            this.lblItemCross.Size = new System.Drawing.Size(208, 22);
            this.lblItemCross.TabIndex = 12;
            this.lblItemCross.Text = "云南省医保目录对照";
            // 
            // btnItemCross
            // 
            this.btnItemCross.Location = new System.Drawing.Point(41, 59);
            this.btnItemCross.Name = "btnItemCross";
            this.btnItemCross.Size = new System.Drawing.Size(178, 23);
            this.btnItemCross.TabIndex = 8;
            this.btnItemCross.Text = "三目录对照";
            this.btnItemCross.UseVisualStyleBackColor = true;
            this.btnItemCross.Click += new System.EventHandler(this.btnItemCross_Click);
            // 
            // FrmSelectCrossYNSYB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 170);
            this.Controls.Add(this.lblItemCross);
            this.Controls.Add(this.btnItemCross);
            this.Name = "FrmSelectCrossYNSYB";
            this.Text = "云南本地医保";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblItemCross;
        private System.Windows.Forms.Button btnItemCross;
    }
}