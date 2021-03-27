namespace guizhousheng
{
    partial class Frm_BK
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
            this.btn_ok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_xm = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.tbx_jzkh = new System.Windows.Forms.TextBox();
            this.tbx_addr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(51, 201);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 2;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "姓名:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "卡号:";
            // 
            // label_xm
            // 
            this.label_xm.AutoSize = true;
            this.label_xm.Location = new System.Drawing.Point(103, 45);
            this.label_xm.Name = "label_xm";
            this.label_xm.Size = new System.Drawing.Size(0, 12);
            this.label_xm.TabIndex = 5;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(148, 201);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 8;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // tbx_jzkh
            // 
            this.tbx_jzkh.Location = new System.Drawing.Point(93, 93);
            this.tbx_jzkh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_jzkh.Name = "tbx_jzkh";
            this.tbx_jzkh.Size = new System.Drawing.Size(100, 21);
            this.tbx_jzkh.TabIndex = 32;
            this.tbx_jzkh.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbx_jzkh_KeyUp);
            // 
            // tbx_addr
            // 
            this.tbx_addr.Location = new System.Drawing.Point(93, 136);
            this.tbx_addr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_addr.Name = "tbx_addr";
            this.tbx_addr.Size = new System.Drawing.Size(100, 21);
            this.tbx_addr.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 33;
            this.label3.Text = "地址:";
            // 
            // Frm_BK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.tbx_addr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbx_jzkh);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.label_xm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_ok);
            this.Name = "Frm_BK";
            this.Text = "补卡";
            this.Load += new System.EventHandler(this.Frm_BK_Load);
            this.Activated += new System.EventHandler(this.Frm_BK_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_xm;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.TextBox tbx_jzkh;
        private System.Windows.Forms.TextBox tbx_addr;
        private System.Windows.Forms.Label label3;
    }
}