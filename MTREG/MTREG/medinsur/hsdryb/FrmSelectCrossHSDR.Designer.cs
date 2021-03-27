namespace MTREG.medinsur.hsdryb
{
    partial class FrmSelectCrossHSDR
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
            this.btnDrugCross = new System.Windows.Forms.Button();
            this.btnDiseaseCase = new System.Windows.Forms.Button();
            this.btnItemCross = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblItemCross
            // 
            this.lblItemCross.AutoSize = true;
            this.lblItemCross.Font = new System.Drawing.Font("宋体", 16F);
            this.lblItemCross.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblItemCross.Location = new System.Drawing.Point(307, 168);
            this.lblItemCross.Name = "lblItemCross";
            this.lblItemCross.Size = new System.Drawing.Size(252, 22);
            this.lblItemCross.TabIndex = 12;
            this.lblItemCross.Text = "衡水武邑县医保目录对照";
            // 
            // btnDrugCross
            // 
            this.btnDrugCross.Location = new System.Drawing.Point(60, 200);
            this.btnDrugCross.Name = "btnDrugCross";
            this.btnDrugCross.Size = new System.Drawing.Size(178, 23);
            this.btnDrugCross.TabIndex = 10;
            this.btnDrugCross.Text = "医药代码对照";
            this.btnDrugCross.UseVisualStyleBackColor = true;
            this.btnDrugCross.Click += new System.EventHandler(this.btnDrugCross_Click);
            // 
            // btnDiseaseCase
            // 
            this.btnDiseaseCase.Location = new System.Drawing.Point(60, 121);
            this.btnDiseaseCase.Name = "btnDiseaseCase";
            this.btnDiseaseCase.Size = new System.Drawing.Size(178, 23);
            this.btnDiseaseCase.TabIndex = 9;
            this.btnDiseaseCase.Text = "病种信息查询";
            this.btnDiseaseCase.UseVisualStyleBackColor = true;
            this.btnDiseaseCase.Click += new System.EventHandler(this.btnDiseaseCase_Click);
            // 
            // btnItemCross
            // 
            this.btnItemCross.Location = new System.Drawing.Point(60, 43);
            this.btnItemCross.Name = "btnItemCross";
            this.btnItemCross.Size = new System.Drawing.Size(178, 23);
            this.btnItemCross.TabIndex = 8;
            this.btnItemCross.Text = "三目录对照";
            this.btnItemCross.UseVisualStyleBackColor = true;
            this.btnItemCross.Click += new System.EventHandler(this.btnItemCross_Click);
            // 
            // FrmSelectCrossHSDR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 273);
            this.Controls.Add(this.lblItemCross);
            this.Controls.Add(this.btnDrugCross);
            this.Controls.Add(this.btnDiseaseCase);
            this.Controls.Add(this.btnItemCross);
            this.Name = "FrmSelectCrossHSDR";
            this.Text = "衡水武邑县医保编码对照";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblItemCross;
        private System.Windows.Forms.Button btnDrugCross;
        private System.Windows.Forms.Button btnDiseaseCase;
        private System.Windows.Forms.Button btnItemCross;
    }
}