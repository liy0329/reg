namespace MTHIS
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statUserInfo = new System.Windows.Forms.StatusStrip();
            this.hspName = new System.Windows.Forms.ToolStripStatusLabel();
            this.blank = new System.Windows.Forms.ToolStripStatusLabel();
            this.departName = new System.Windows.Forms.ToolStripStatusLabel();
            this.blank2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.loginuser = new System.Windows.Forms.ToolStripStatusLabel();
            this.blank3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.datetime = new System.Windows.Forms.ToolStripStatusLabel();
            this.blank4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.versionInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ms = new System.Windows.Forms.MenuStrip();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.statUserInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // statUserInfo
            // 
            this.statUserInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.statUserInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hspName,
            this.blank,
            this.departName,
            this.blank2,
            this.loginuser,
            this.blank3,
            this.datetime,
            this.blank4,
            this.versionInfo});
            this.statUserInfo.Location = new System.Drawing.Point(0, 526);
            this.statUserInfo.Name = "statUserInfo";
            this.statUserInfo.Size = new System.Drawing.Size(1210, 22);
            this.statUserInfo.TabIndex = 1;
            // 
            // hspName
            // 
            this.hspName.Name = "hspName";
            this.hspName.Size = new System.Drawing.Size(0, 17);
            // 
            // blank
            // 
            this.blank.Name = "blank";
            this.blank.Size = new System.Drawing.Size(139, 17);
            this.blank.Text = "1111111111111          ";
            // 
            // departName
            // 
            this.departName.Name = "departName";
            this.departName.Size = new System.Drawing.Size(60, 17);
            this.departName.Text = "             ";
            // 
            // blank2
            // 
            this.blank2.Name = "blank2";
            this.blank2.Size = new System.Drawing.Size(131, 17);
            this.blank2.Text = "toolStripStatusLabel1";
            // 
            // loginuser
            // 
            this.loginuser.Name = "loginuser";
            this.loginuser.Size = new System.Drawing.Size(131, 17);
            this.loginuser.Text = "toolStripStatusLabel2";
            // 
            // blank3
            // 
            this.blank3.Name = "blank3";
            this.blank3.Size = new System.Drawing.Size(131, 17);
            this.blank3.Text = "toolStripStatusLabel3";
            // 
            // datetime
            // 
            this.datetime.Name = "datetime";
            this.datetime.Size = new System.Drawing.Size(131, 17);
            this.datetime.Text = "toolStripStatusLabel4";
            // 
            // blank4
            // 
            this.blank4.Name = "blank4";
            this.blank4.Size = new System.Drawing.Size(11, 17);
            this.blank4.Text = "|";
            // 
            // versionInfo
            // 
            this.versionInfo.Name = "versionInfo";
            this.versionInfo.Size = new System.Drawing.Size(0, 17);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ms
            // 
            this.ms.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ms.Location = new System.Drawing.Point(0, 0);
            this.ms.Name = "ms";
            this.ms.Size = new System.Drawing.Size(1210, 24);
            this.ms.TabIndex = 2;
            this.ms.Text = "menuStrip1";
            this.ms.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ms_ItemClicked);
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1210, 25);
            this.toolStrip.TabIndex = 3;
            this.toolStrip.Text = "toolStrip";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1210, 548);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statUserInfo);
            this.Controls.Add(this.ms);
            this.MainMenuStrip = this.ms;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "收费子系统";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.statUserInfo.ResumeLayout(false);
            this.statUserInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statUserInfo;
        private System.Windows.Forms.ToolStripStatusLabel hspName;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel blank;
        private System.Windows.Forms.ToolStripStatusLabel departName;
        private System.Windows.Forms.ToolStripStatusLabel blank2;
        private System.Windows.Forms.ToolStripStatusLabel loginuser;
        private System.Windows.Forms.ToolStripStatusLabel blank3;
        private System.Windows.Forms.ToolStripStatusLabel datetime;
        private System.Windows.Forms.MenuStrip ms;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripStatusLabel blank4;
        private System.Windows.Forms.ToolStripStatusLabel versionInfo;


    }
}

