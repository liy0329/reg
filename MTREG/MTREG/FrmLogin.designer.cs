namespace MTHIS
{
    partial class FrmLogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.lblName = new System.Windows.Forms.Label();
            this.lblPwd = new System.Windows.Forms.Label();
            this.tbxAccount = new System.Windows.Forms.TextBox();
            this.tbxPwd = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.notiyIconPort = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmenuRight = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.Red;
            this.lblName.Location = new System.Drawing.Point(36, 37);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(76, 16);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "用户名：";
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.BackColor = System.Drawing.Color.Transparent;
            this.lblPwd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.lblPwd.ForeColor = System.Drawing.Color.Red;
            this.lblPwd.Location = new System.Drawing.Point(36, 73);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(77, 16);
            this.lblPwd.TabIndex = 1;
            this.lblPwd.Text = "密  码：";
            // 
            // tbxAccount
            // 
            this.tbxAccount.BackColor = System.Drawing.Color.White;
            this.tbxAccount.Location = new System.Drawing.Point(113, 36);
            this.tbxAccount.MaxLength = 20;
            this.tbxAccount.Name = "tbxAccount";
            this.tbxAccount.Size = new System.Drawing.Size(124, 26);
            this.tbxAccount.TabIndex = 1;
            this.tbxAccount.Text = "admin";
            this.tbxAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxName_KeyDown);
            // 
            // tbxPwd
            // 
            this.tbxPwd.BackColor = System.Drawing.Color.White;
            this.tbxPwd.Location = new System.Drawing.Point(113, 74);
            this.tbxPwd.MaxLength = 20;
            this.tbxPwd.Multiline = true;
            this.tbxPwd.Name = "tbxPwd";
            this.tbxPwd.PasswordChar = '*';
            this.tbxPwd.Size = new System.Drawing.Size(124, 21);
            this.tbxPwd.TabIndex = 2;
            this.tbxPwd.Text = "1";
            this.tbxPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxPwd_KeyDown);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLogin.Font = new System.Drawing.Font("宋体", 10F);
            this.btnLogin.Location = new System.Drawing.Point(43, 125);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancel.Font = new System.Drawing.Font("宋体", 10F);
            this.btnCancel.Location = new System.Drawing.Point(137, 125);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // notiyIconPort
            // 
            this.notiyIconPort.Icon = ((System.Drawing.Icon)(resources.GetObject("notiyIconPort.Icon")));
            this.notiyIconPort.Text = "民腾收费接口";
            this.notiyIconPort.Visible = true;
            this.notiyIconPort.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notiyIconPort_MouseClick);
            // 
            // cmenuRight
            // 
            this.cmenuRight.Name = "cmenuRight";
            this.cmenuRight.Size = new System.Drawing.Size(61, 4);
            this.cmenuRight.MouseLeave += new System.EventHandler(this.cmenuRight_MouseLeave);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("华文行楷", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(477, 114);
            this.label1.TabIndex = 5;
            this.label1.Text = "1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.lblPwd);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.tbxAccount);
            this.groupBox1.Controls.Add(this.tbxPwd);
            this.groupBox1.Controls.Add(this.btnLogin);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(491, 164);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 177);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "欢迎登录";
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(788, 365);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "FrmLogin";
            this.Text = "登录";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmLogin_FormClosed);
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.Shown += new System.EventHandler(this.FrmLogin_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.TextBox tbxAccount;
        private System.Windows.Forms.TextBox tbxPwd;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NotifyIcon notiyIconPort;
        private System.Windows.Forms.ContextMenuStrip cmenuRight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
       
    }
}