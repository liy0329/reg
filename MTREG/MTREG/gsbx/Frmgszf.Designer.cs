namespace zhongluyiyuan.gsbx
{
    partial class Frmgszf
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
            this.tbx_xmid = new System.Windows.Forms.TextBox();
            this.btn_qd = new System.Windows.Forms.Button();
            this.but_gb = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_xmmc = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(16, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 19);
            this.label4.TabIndex = 37;
            this.label4.Text = "项目ID";
            // 
            // tbx_xmid
            // 
            this.tbx_xmid.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_xmid.Location = new System.Drawing.Point(107, 22);
            this.tbx_xmid.Name = "tbx_xmid";
            this.tbx_xmid.ReadOnly = true;
            this.tbx_xmid.Size = new System.Drawing.Size(267, 29);
            this.tbx_xmid.TabIndex = 36;
            // 
            // btn_qd
            // 
            this.btn_qd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_qd.Location = new System.Drawing.Point(54, 167);
            this.btn_qd.Name = "btn_qd";
            this.btn_qd.Size = new System.Drawing.Size(75, 28);
            this.btn_qd.TabIndex = 35;
            this.btn_qd.Text = "确定";
            this.btn_qd.UseVisualStyleBackColor = true;
            this.btn_qd.Click += new System.EventHandler(this.btn_qd_Click);
            // 
            // but_gb
            // 
            this.but_gb.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_gb.Location = new System.Drawing.Point(269, 167);
            this.but_gb.Name = "but_gb";
            this.but_gb.Size = new System.Drawing.Size(75, 28);
            this.but_gb.TabIndex = 32;
            this.but_gb.Text = "关闭";
            this.but_gb.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(16, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 19);
            this.label2.TabIndex = 31;
            this.label2.Text = "项目名称";
            // 
            // tbx_xmmc
            // 
            this.tbx_xmmc.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_xmmc.Location = new System.Drawing.Point(107, 68);
            this.tbx_xmmc.Name = "tbx_xmmc";
            this.tbx_xmmc.ReadOnly = true;
            this.tbx_xmmc.Size = new System.Drawing.Size(267, 29);
            this.tbx_xmmc.TabIndex = 30;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("宋体", 15F);
            this.checkBox1.Location = new System.Drawing.Point(107, 127);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(108, 24);
            this.checkBox1.TabIndex = 39;
            this.checkBox1.Text = "是否自付";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Frmgszf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 226);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbx_xmid);
            this.Controls.Add(this.btn_qd);
            this.Controls.Add(this.but_gb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbx_xmmc);
            this.Name = "Frmgszf";
            this.Text = "修改自负";
            this.Load += new System.EventHandler(this.Frmgszf_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbx_xmid;
        private System.Windows.Forms.Button btn_qd;
        private System.Windows.Forms.Button but_gb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_xmmc;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}