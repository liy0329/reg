﻿namespace MTREG.medinsur.hdsbhnh
{
    partial class FrmSelctcrossHDSBH
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
            this.btnItemtype = new System.Windows.Forms.Button();
            this.btnDrugtype = new System.Windows.Forms.Button();
            this.btnItemfrom = new System.Windows.Forms.Button();
            this.btnItemCross = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblItemCross
            // 
            this.lblItemCross.AutoSize = true;
            this.lblItemCross.Font = new System.Drawing.Font("宋体", 16F);
            this.lblItemCross.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblItemCross.Location = new System.Drawing.Point(248, 139);
            this.lblItemCross.Name = "lblItemCross";
            this.lblItemCross.Size = new System.Drawing.Size(230, 22);
            this.lblItemCross.TabIndex = 12;
            this.lblItemCross.Text = "邯郸[市]北航目录对照";
            // 
            // btnItemtype
            // 
            this.btnItemtype.Location = new System.Drawing.Point(21, 237);
            this.btnItemtype.Name = "btnItemtype";
            this.btnItemtype.Size = new System.Drawing.Size(178, 23);
            this.btnItemtype.TabIndex = 11;
            this.btnItemtype.Text = "财务分类对照";
            this.btnItemtype.UseVisualStyleBackColor = true;
            this.btnItemtype.Click += new System.EventHandler(this.btnItemtype_Click);
            // 
            // btnDrugtype
            // 
            this.btnDrugtype.Location = new System.Drawing.Point(21, 172);
            this.btnDrugtype.Name = "btnDrugtype";
            this.btnDrugtype.Size = new System.Drawing.Size(178, 23);
            this.btnDrugtype.TabIndex = 10;
            this.btnDrugtype.Text = "药品分类对照";
            this.btnDrugtype.UseVisualStyleBackColor = true;
            this.btnDrugtype.Click += new System.EventHandler(this.btnDrugtype_Click);
            // 
            // btnItemfrom
            // 
            this.btnItemfrom.Location = new System.Drawing.Point(21, 104);
            this.btnItemfrom.Name = "btnItemfrom";
            this.btnItemfrom.Size = new System.Drawing.Size(178, 23);
            this.btnItemfrom.TabIndex = 9;
            this.btnItemfrom.Text = "医药项目对照";
            this.btnItemfrom.UseVisualStyleBackColor = true;
            this.btnItemfrom.Click += new System.EventHandler(this.btnItemfrom_Click);
            // 
            // btnItemCross
            // 
            this.btnItemCross.Location = new System.Drawing.Point(21, 43);
            this.btnItemCross.Name = "btnItemCross";
            this.btnItemCross.Size = new System.Drawing.Size(178, 23);
            this.btnItemCross.TabIndex = 8;
            this.btnItemCross.Text = "三目录对照";
            this.btnItemCross.UseVisualStyleBackColor = true;
            this.btnItemCross.Click += new System.EventHandler(this.btnItemCross_Click);
            // 
            // FrmSelctcrossHDSBH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 295);
            this.Controls.Add(this.lblItemCross);
            this.Controls.Add(this.btnItemtype);
            this.Controls.Add(this.btnDrugtype);
            this.Controls.Add(this.btnItemfrom);
            this.Controls.Add(this.btnItemCross);
            this.Name = "FrmSelctcrossHDSBH";
            this.Text = "邯郸[市]北航编码对照";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblItemCross;
        private System.Windows.Forms.Button btnItemtype;
        private System.Windows.Forms.Button btnDrugtype;
        private System.Windows.Forms.Button btnItemfrom;
        private System.Windows.Forms.Button btnItemCross;
    }
}