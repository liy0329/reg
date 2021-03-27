namespace MTREG.medinsur.gzsnh
{
    partial class FrmUpDateDisease
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
            this.dtpLastdate = new System.Windows.Forms.DateTimePicker();
            this.cbxFirst = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tbxCenterNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtpLastdate
            // 
            this.dtpLastdate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpLastdate.Font = new System.Drawing.Font("宋体", 11F);
            this.dtpLastdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLastdate.Location = new System.Drawing.Point(105, 127);
            this.dtpLastdate.Name = "dtpLastdate";
            this.dtpLastdate.Size = new System.Drawing.Size(197, 24);
            this.dtpLastdate.TabIndex = 0;
            // 
            // cbxFirst
            // 
            this.cbxFirst.AutoSize = true;
            this.cbxFirst.Font = new System.Drawing.Font("宋体", 11F);
            this.cbxFirst.Location = new System.Drawing.Point(18, 60);
            this.cbxFirst.Name = "cbxFirst";
            this.cbxFirst.Size = new System.Drawing.Size(101, 19);
            this.cbxFirst.TabIndex = 1;
            this.cbxFirst.Text = "第一次下载";
            this.cbxFirst.UseVisualStyleBackColor = true;
            this.cbxFirst.CheckedChanged += new System.EventHandler(this.cbxFirst_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "如果是第一次下载请勾选第一次下载!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F);
            this.label2.Location = new System.Drawing.Point(6, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "最后更新时间:";
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(122, 170);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 4;
            this.btnDownload.Text = "开始下载";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(245, 208);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tbxCenterNo
            // 
            this.tbxCenterNo.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxCenterNo.Location = new System.Drawing.Point(105, 97);
            this.tbxCenterNo.Name = "tbxCenterNo";
            this.tbxCenterNo.Size = new System.Drawing.Size(133, 24);
            this.tbxCenterNo.TabIndex = 172;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 11F);
            this.label4.Location = new System.Drawing.Point(6, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 15);
            this.label4.TabIndex = 171;
            this.label4.Text = "农合中心编码:";
            // 
            // FrmUpDateDisease
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 239);
            this.Controls.Add(this.tbxCenterNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.dtpLastdate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxFirst);
            this.Name = "FrmUpDateDisease";
            this.Text = "下载(更新)疾病信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpLastdate;
        private System.Windows.Forms.CheckBox cbxFirst;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox tbxCenterNo;
        private System.Windows.Forms.Label label4;
    }
}