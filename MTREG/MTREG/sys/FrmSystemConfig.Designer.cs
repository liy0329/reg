namespace MTHIS.sys
{
    partial class FrmSystemConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSystemConfig));
            this.dgvSysConfig = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSysConfig)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSysConfig
            // 
            this.dgvSysConfig.BackgroundColor = System.Drawing.Color.White;
            this.dgvSysConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSysConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSysConfig.Location = new System.Drawing.Point(0, 0);
            this.dgvSysConfig.Name = "dgvSysConfig";
            this.dgvSysConfig.RowTemplate.Height = 23;
            this.dgvSysConfig.Size = new System.Drawing.Size(1053, 467);
            this.dgvSysConfig.TabIndex = 0;
            // 
            // FrmSystemConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 467);
            this.Controls.Add(this.dgvSysConfig);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSystemConfig";
            this.Text = "系统配置";
            this.Load += new System.EventHandler(this.FrmSystemConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSysConfig)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSysConfig;
    }
}