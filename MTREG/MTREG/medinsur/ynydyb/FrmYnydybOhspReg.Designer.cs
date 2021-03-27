namespace MTREG.medinsur.ynydyb
{
    partial class FrmYnydybOhspReg
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
            this.tbx_dkxm = new System.Windows.Forms.TextBox();
            this.tbx_grbh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_wfty = new System.Windows.Forms.Button();
            this.btnDk = new System.Windows.Forms.Button();
            this.tbx_zyh = new System.Windows.Forms.TextBox();
            this.tbx_xm = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbx_dkxm
            // 
            this.tbx_dkxm.Location = new System.Drawing.Point(79, 128);
            this.tbx_dkxm.Name = "tbx_dkxm";
            this.tbx_dkxm.ReadOnly = true;
            this.tbx_dkxm.Size = new System.Drawing.Size(203, 21);
            this.tbx_dkxm.TabIndex = 76;
            // 
            // tbx_grbh
            // 
            this.tbx_grbh.Location = new System.Drawing.Point(79, 97);
            this.tbx_grbh.Name = "tbx_grbh";
            this.tbx_grbh.ReadOnly = true;
            this.tbx_grbh.Size = new System.Drawing.Size(203, 21);
            this.tbx_grbh.TabIndex = 75;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 74;
            this.label2.Text = "个人编号:";
            // 
            // btn_wfty
            // 
            this.btn_wfty.ForeColor = System.Drawing.Color.Red;
            this.btn_wfty.Location = new System.Drawing.Point(165, 169);
            this.btn_wfty.Name = "btn_wfty";
            this.btn_wfty.Size = new System.Drawing.Size(73, 26);
            this.btn_wfty.TabIndex = 72;
            this.btn_wfty.Text = "无费退院";
            this.btn_wfty.UseVisualStyleBackColor = true;
            this.btn_wfty.Click += new System.EventHandler(this.btn_wfty_Click);
            // 
            // btnDk
            // 
            this.btnDk.ForeColor = System.Drawing.Color.Red;
            this.btnDk.Location = new System.Drawing.Point(30, 169);
            this.btnDk.Name = "btnDk";
            this.btnDk.Size = new System.Drawing.Size(73, 26);
            this.btnDk.TabIndex = 71;
            this.btnDk.Text = "读卡";
            this.btnDk.UseVisualStyleBackColor = true;
            this.btnDk.Click += new System.EventHandler(this.btnDk_Click);
            // 
            // tbx_zyh
            // 
            this.tbx_zyh.Location = new System.Drawing.Point(79, 45);
            this.tbx_zyh.Name = "tbx_zyh";
            this.tbx_zyh.ReadOnly = true;
            this.tbx_zyh.Size = new System.Drawing.Size(203, 21);
            this.tbx_zyh.TabIndex = 70;
            // 
            // tbx_xm
            // 
            this.tbx_xm.Location = new System.Drawing.Point(79, 12);
            this.tbx_xm.Name = "tbx_xm";
            this.tbx_xm.ReadOnly = true;
            this.tbx_xm.Size = new System.Drawing.Size(203, 21);
            this.tbx_xm.TabIndex = 69;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 68;
            this.label3.Text = "住院号:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 67;
            this.label1.Text = "姓   名:";
            // 
            // FrmYnydybOhspReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 220);
            this.Controls.Add(this.tbx_dkxm);
            this.Controls.Add(this.tbx_grbh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_wfty);
            this.Controls.Add(this.btnDk);
            this.Controls.Add(this.tbx_zyh);
            this.Controls.Add(this.tbx_xm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "FrmYnydybOhspReg";
            this.Text = "云南异地医保无费退院";
            this.Load += new System.EventHandler(this.FrmYnydybOhspReg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbx_dkxm;
        private System.Windows.Forms.TextBox tbx_grbh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_wfty;
        private System.Windows.Forms.Button btnDk;
        private System.Windows.Forms.TextBox tbx_zyh;
        private System.Windows.Forms.TextBox tbx_xm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}