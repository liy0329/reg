namespace MTHIS.sys
{
    partial class FrmChangePwd
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxPwdOld = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxPwdReset = new System.Windows.Forms.TextBox();
            this.tbxPwd = new System.Windows.Forms.TextBox();
            this.lblPwdReset = new System.Windows.Forms.Label();
            this.lblPwd = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbxPwdOld);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbxPwdReset);
            this.groupBox1.Controls.Add(this.tbxPwd);
            this.groupBox1.Controls.Add(this.lblPwdReset);
            this.groupBox1.Controls.Add(this.lblPwd);
            this.groupBox1.Location = new System.Drawing.Point(32, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 150);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // tbxPwdOld
            // 
            this.tbxPwdOld.Location = new System.Drawing.Point(102, 25);
            this.tbxPwdOld.Name = "tbxPwdOld";
            this.tbxPwdOld.PasswordChar = '*';
            this.tbxPwdOld.Size = new System.Drawing.Size(100, 21);
            this.tbxPwdOld.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "原 密 码：";
            // 
            // tbxPwdReset
            // 
            this.tbxPwdReset.Location = new System.Drawing.Point(102, 103);
            this.tbxPwdReset.Name = "tbxPwdReset";
            this.tbxPwdReset.PasswordChar = '*';
            this.tbxPwdReset.Size = new System.Drawing.Size(100, 21);
            this.tbxPwdReset.TabIndex = 3;
            // 
            // tbxPwd
            // 
            this.tbxPwd.Location = new System.Drawing.Point(102, 66);
            this.tbxPwd.Name = "tbxPwd";
            this.tbxPwd.PasswordChar = '*';
            this.tbxPwd.Size = new System.Drawing.Size(100, 21);
            this.tbxPwd.TabIndex = 2;
            // 
            // lblPwdReset
            // 
            this.lblPwdReset.AutoSize = true;
            this.lblPwdReset.Location = new System.Drawing.Point(31, 106);
            this.lblPwdReset.Name = "lblPwdReset";
            this.lblPwdReset.Size = new System.Drawing.Size(65, 12);
            this.lblPwdReset.TabIndex = 1;
            this.lblPwdReset.Text = "密码确认：";
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Location = new System.Drawing.Point(31, 69);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(65, 12);
            this.lblPwd.TabIndex = 0;
            this.lblPwd.Text = "新 密 码：";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(163, 168);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(82, 168);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "确认";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // FrmChangePwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 214);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmChangePwd";
            this.Text = "修改密码";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxPwdOld;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxPwdReset;
        private System.Windows.Forms.TextBox tbxPwd;
        private System.Windows.Forms.Label lblPwdReset;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}