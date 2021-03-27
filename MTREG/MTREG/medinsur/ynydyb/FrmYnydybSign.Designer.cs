namespace MTREG.medinsur.ynydyb
{
    partial class FrmYnydybSign
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
            this.btnSignIn = new System.Windows.Forms.Button();
            this.btnSignOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSignIn
            // 
            this.btnSignIn.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSignIn.Location = new System.Drawing.Point(47, 44);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(100, 50);
            this.btnSignIn.TabIndex = 0;
            this.btnSignIn.Text = "签到";
            this.btnSignIn.UseVisualStyleBackColor = true;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // btnSignOut
            // 
            this.btnSignOut.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSignOut.Location = new System.Drawing.Point(214, 44);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(100, 50);
            this.btnSignOut.TabIndex = 0;
            this.btnSignOut.Text = "签退";
            this.btnSignOut.UseVisualStyleBackColor = true;
            this.btnSignOut.Click += new System.EventHandler(this.btnSignOut_Click);
            // 
            // FrmYnydybSign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 154);
            this.Controls.Add(this.btnSignOut);
            this.Controls.Add(this.btnSignIn);
            this.Name = "FrmYnydybSign";
            this.Text = "操作员签退/签到";
            this.Load += new System.EventHandler(this.FrmYnydybSign_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.Button btnSignOut;
    }
}