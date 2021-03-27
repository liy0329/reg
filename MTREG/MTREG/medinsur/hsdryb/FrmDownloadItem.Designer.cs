namespace MTREG.medinsur.hsdryb
{
    partial class FrmDownloadInsurItem
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
            this.label8 = new System.Windows.Forms.Label();
            this.cmbItemfrom = new System.Windows.Forms.ComboBox();
            this.btnDownLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(34, 18);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 16);
            this.label8.TabIndex = 88;
            this.label8.Text = "收费类别:";
            // 
            // cmbItemfrom
            // 
            this.cmbItemfrom.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbItemfrom.FormattingEnabled = true;
            this.cmbItemfrom.ItemHeight = 16;
            this.cmbItemfrom.Location = new System.Drawing.Point(118, 14);
            this.cmbItemfrom.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cmbItemfrom.Name = "cmbItemfrom";
            this.cmbItemfrom.Size = new System.Drawing.Size(123, 24);
            this.cmbItemfrom.TabIndex = 87;
            // 
            // btnDownLoad
            // 
            this.btnDownLoad.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDownLoad.Location = new System.Drawing.Point(84, 63);
            this.btnDownLoad.Name = "btnDownLoad";
            this.btnDownLoad.Size = new System.Drawing.Size(129, 41);
            this.btnDownLoad.TabIndex = 93;
            this.btnDownLoad.Text = "下载";
            this.btnDownLoad.UseVisualStyleBackColor = true;
            this.btnDownLoad.Click += new System.EventHandler(this.btnDownLoad_Click);
            // 
            // FrmDownloadInsurItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 123);
            this.Controls.Add(this.btnDownLoad);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbItemfrom);
            this.Name = "FrmDownloadInsurItem";
            this.Text = "下载医保目录";
            this.Load += new System.EventHandler(this.FrmDownloadInsurItem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbItemfrom;
        private System.Windows.Forms.Button btnDownLoad;
    }
}