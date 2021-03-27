namespace MTREG.medinsur.hdyb
{
    partial class FrmSelectCross
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
            this.btnItemCross = new System.Windows.Forms.Button();
            this.btnItemfrom = new System.Windows.Forms.Button();
            this.btnDrugtype = new System.Windows.Forms.Button();
            this.btnItemtype = new System.Windows.Forms.Button();
            this.lblItemCross = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnItemCross
            // 
            this.btnItemCross.Font = new System.Drawing.Font("宋体", 11F);
            this.btnItemCross.Location = new System.Drawing.Point(63, 45);
            this.btnItemCross.Name = "btnItemCross";
            this.btnItemCross.Size = new System.Drawing.Size(178, 30);
            this.btnItemCross.TabIndex = 1;
            this.btnItemCross.Text = "三目录信息";
            this.btnItemCross.UseVisualStyleBackColor = true;
            this.btnItemCross.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnItemfrom
            // 
            this.btnItemfrom.Font = new System.Drawing.Font("宋体", 11F);
            this.btnItemfrom.Location = new System.Drawing.Point(63, 109);
            this.btnItemfrom.Name = "btnItemfrom";
            this.btnItemfrom.Size = new System.Drawing.Size(178, 30);
            this.btnItemfrom.TabIndex = 1;
            this.btnItemfrom.Text = "医药分类对照";
            this.btnItemfrom.UseVisualStyleBackColor = true;
            this.btnItemfrom.Click += new System.EventHandler(this.btnItemfrom_Click);
            // 
            // btnDrugtype
            // 
            this.btnDrugtype.Font = new System.Drawing.Font("宋体", 11F);
            this.btnDrugtype.Location = new System.Drawing.Point(63, 173);
            this.btnDrugtype.Name = "btnDrugtype";
            this.btnDrugtype.Size = new System.Drawing.Size(178, 30);
            this.btnDrugtype.TabIndex = 1;
            this.btnDrugtype.Text = "药品分类对照";
            this.btnDrugtype.UseVisualStyleBackColor = true;
            this.btnDrugtype.Click += new System.EventHandler(this.btnDrugtype_Click);
            // 
            // btnItemtype
            // 
            this.btnItemtype.Enabled = false;
            this.btnItemtype.Font = new System.Drawing.Font("宋体", 11F);
            this.btnItemtype.Location = new System.Drawing.Point(63, 237);
            this.btnItemtype.Name = "btnItemtype";
            this.btnItemtype.Size = new System.Drawing.Size(178, 30);
            this.btnItemtype.TabIndex = 1;
            this.btnItemtype.Text = "财务分类对照";
            this.btnItemtype.UseVisualStyleBackColor = true;
            this.btnItemtype.Click += new System.EventHandler(this.btnItemtype_Click);
            // 
            // lblItemCross
            // 
            this.lblItemCross.AutoSize = true;
            this.lblItemCross.Font = new System.Drawing.Font("宋体", 16F);
            this.lblItemCross.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblItemCross.Location = new System.Drawing.Point(310, 141);
            this.lblItemCross.Name = "lblItemCross";
            this.lblItemCross.Size = new System.Drawing.Size(208, 22);
            this.lblItemCross.TabIndex = 2;
            this.lblItemCross.Text = "邯郸市医保目录对照";
            // 
            // FrmSelectCross
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 331);
            this.Controls.Add(this.lblItemCross);
            this.Controls.Add(this.btnItemtype);
            this.Controls.Add(this.btnDrugtype);
            this.Controls.Add(this.btnItemfrom);
            this.Controls.Add(this.btnItemCross);
            this.Name = "FrmSelectCross";
            this.Text = "邯郸市医保编码对照";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnItemCross;
        private System.Windows.Forms.Button btnItemfrom;
        private System.Windows.Forms.Button btnDrugtype;
        private System.Windows.Forms.Button btnItemtype;
        private System.Windows.Forms.Label lblItemCross;
    }
}