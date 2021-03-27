namespace MTREG.medinsur
{
    partial class FrmMesg
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblbcxx = new System.Windows.Forms.TextBox();
            this.btn_qd = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblbcxx);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(638, 516);
            this.groupBox3.TabIndex = 147;
            this.groupBox3.TabStop = false;
            // 
            // lblbcxx
            // 
            this.lblbcxx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblbcxx.Location = new System.Drawing.Point(3, 17);
            this.lblbcxx.Multiline = true;
            this.lblbcxx.Name = "lblbcxx";
            this.lblbcxx.ReadOnly = true;
            this.lblbcxx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lblbcxx.Size = new System.Drawing.Size(632, 496);
            this.lblbcxx.TabIndex = 0;
            // 
            // btn_qd
            // 
            this.btn_qd.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_qd.Location = new System.Drawing.Point(423, 538);
            this.btn_qd.Name = "btn_qd";
            this.btn_qd.Size = new System.Drawing.Size(106, 30);
            this.btn_qd.TabIndex = 148;
            this.btn_qd.Text = "取消";
            this.btn_qd.UseVisualStyleBackColor = true;
            this.btn_qd.Click += new System.EventHandler(this.btn_qd_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(94, 538);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 30);
            this.button1.TabIndex = 149;
            this.button1.Text = "继续结算";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmMesg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 576);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_qd);
            this.Controls.Add(this.groupBox3);
            this.Name = "FrmMesg";
            this.Text = "信息对话框";
            this.Load += new System.EventHandler(this.FrmMesg_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox lblbcxx;
        private System.Windows.Forms.Button btn_qd;
        private System.Windows.Forms.Button button1;

    }
}