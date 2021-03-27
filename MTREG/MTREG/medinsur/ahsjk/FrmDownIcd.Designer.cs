namespace MTREG.medinsur.ahsjk
{
    partial class FrmDownIcd
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
            this.label4 = new System.Windows.Forms.Label();
            this.txt_UserPass = new System.Windows.Forms.TextBox();
            this.txt_UserCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.butClose = new System.Windows.Forms.Button();
            this.butDown = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(211, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 12);
            this.label4.TabIndex = 25;
            this.label4.Text = "新农合用户密码:";
            // 
            // txt_UserPass
            // 
            this.txt_UserPass.Location = new System.Drawing.Point(303, 55);
            this.txt_UserPass.Name = "txt_UserPass";
            this.txt_UserPass.Size = new System.Drawing.Size(119, 21);
            this.txt_UserPass.TabIndex = 24;
            // 
            // txt_UserCode
            // 
            this.txt_UserCode.Location = new System.Drawing.Point(87, 55);
            this.txt_UserCode.Name = "txt_UserCode";
            this.txt_UserCode.Size = new System.Drawing.Size(119, 21);
            this.txt_UserCode.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "新农合用户名:";
            // 
            // cmbArea
            // 
            this.cmbArea.Font = new System.Drawing.Font("宋体", 9F);
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(183, 12);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(119, 20);
            this.cmbArea.TabIndex = 85;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 9F);
            this.label11.Location = new System.Drawing.Point(127, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 84;
            this.label11.Text = "选择区域:";
            // 
            // butClose
            // 
            this.butClose.Location = new System.Drawing.Point(357, 137);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(65, 23);
            this.butClose.TabIndex = 87;
            this.butClose.Text = "退出";
            this.butClose.UseVisualStyleBackColor = true;
            // 
            // butDown
            // 
            this.butDown.Location = new System.Drawing.Point(182, 89);
            this.butDown.Name = "butDown";
            this.butDown.Size = new System.Drawing.Size(75, 23);
            this.butDown.TabIndex = 86;
            this.butDown.Text = "开始下载";
            this.butDown.UseVisualStyleBackColor = true;
            this.butDown.Click += new System.EventHandler(this.butDown_Click);
            // 
            // FrmDownIcd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 162);
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.butDown);
            this.Controls.Add(this.cmbArea);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_UserPass);
            this.Controls.Add(this.txt_UserCode);
            this.Controls.Add(this.label3);
            this.Name = "FrmDownIcd";
            this.Text = "下载ICD信息";
            this.Load += new System.EventHandler(this.FrmDownIcd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_UserPass;
        private System.Windows.Forms.TextBox txt_UserCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.Button butDown;
    }
}