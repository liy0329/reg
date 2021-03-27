namespace MTREG.medinsur.gzsnh
{
    partial class FrmGzsnhSelectCross
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
            this.btnTreatment = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblItemCross
            // 
            this.lblItemCross.AutoSize = true;
            this.lblItemCross.Font = new System.Drawing.Font("宋体", 16F);
            this.lblItemCross.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblItemCross.Location = new System.Drawing.Point(256, 137);
            this.lblItemCross.Name = "lblItemCross";
            this.lblItemCross.Size = new System.Drawing.Size(142, 22);
            this.lblItemCross.TabIndex = 10;
            this.lblItemCross.Text = "贵州省新农合";
            // 
            // btnTreatment
            // 
            this.btnTreatment.Location = new System.Drawing.Point(36, 30);
            this.btnTreatment.Name = "btnTreatment";
            this.btnTreatment.Size = new System.Drawing.Size(178, 23);
            this.btnTreatment.TabIndex = 9;
            this.btnTreatment.Text = "治疗方式下载";
            this.btnTreatment.UseVisualStyleBackColor = true;
            this.btnTreatment.Click += new System.EventHandler(this.btnTreatment_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(36, 108);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "疾病信息下载";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmGzsnhSelectCross
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 314);
            this.Controls.Add(this.lblItemCross);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnTreatment);
            this.Name = "FrmGzsnhSelectCross";
            this.Text = "FrmGzsnhSelectCross";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblItemCross;
        private System.Windows.Forms.Button btnTreatment;
        private System.Windows.Forms.Button button1;
    }
}