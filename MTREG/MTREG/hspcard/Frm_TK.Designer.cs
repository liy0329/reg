namespace guizhousheng
{
    partial class Frm_TK
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
            this.tbx_xm = new System.Windows.Forms.TextBox();
            this.tbx_sfzh = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_tk = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_jzkh = new System.Windows.Forms.TextBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.tbx_addr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbx_xm
            // 
            this.tbx_xm.Location = new System.Drawing.Point(100, 27);
            this.tbx_xm.Name = "tbx_xm";
            this.tbx_xm.Size = new System.Drawing.Size(120, 21);
            this.tbx_xm.TabIndex = 0;
            // 
            // tbx_sfzh
            // 
            this.tbx_sfzh.Location = new System.Drawing.Point(100, 75);
            this.tbx_sfzh.Name = "tbx_sfzh";
            this.tbx_sfzh.Size = new System.Drawing.Size(120, 21);
            this.tbx_sfzh.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "姓名:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "身份证号:";
            // 
            // btn_tk
            // 
            this.btn_tk.Location = new System.Drawing.Point(52, 206);
            this.btn_tk.Name = "btn_tk";
            this.btn_tk.Size = new System.Drawing.Size(75, 23);
            this.btn_tk.TabIndex = 4;
            this.btn_tk.Text = "确定";
            this.btn_tk.UseVisualStyleBackColor = true;
            this.btn_tk.Click += new System.EventHandler(this.btn_tk_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "卡号:";
            // 
            // tbx_jzkh
            // 
            this.tbx_jzkh.Location = new System.Drawing.Point(100, 119);
            this.tbx_jzkh.Name = "tbx_jzkh";
            this.tbx_jzkh.Size = new System.Drawing.Size(120, 21);
            this.tbx_jzkh.TabIndex = 6;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(161, 206);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 7;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // tbx_addr
            // 
            this.tbx_addr.Location = new System.Drawing.Point(100, 161);
            this.tbx_addr.Name = "tbx_addr";
            this.tbx_addr.Size = new System.Drawing.Size(120, 21);
            this.tbx_addr.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "地址:";
            // 
            // Frm_TK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.tbx_addr);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.tbx_jzkh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_tk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbx_sfzh);
            this.Controls.Add(this.tbx_xm);
            this.Name = "Frm_TK";
            this.Text = "退卡";
            this.Load += new System.EventHandler(this.Frm_TK_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbx_xm;
        private System.Windows.Forms.TextBox tbx_sfzh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_tk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbx_jzkh;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.TextBox tbx_addr;
        private System.Windows.Forms.Label label4;
    }
}