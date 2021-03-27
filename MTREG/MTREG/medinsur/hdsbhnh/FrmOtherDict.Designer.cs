namespace MTREG.medinsur.hdsbhnh
{
    partial class FrmOtherDict
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
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDictName = new System.Windows.Forms.ComboBox();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbArea
            // 
            this.cmbArea.Font = new System.Drawing.Font("宋体", 14.25F);
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(124, 31);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(161, 27);
            this.cmbArea.TabIndex = 53;
            this.cmbArea.SelectedValueChanged += new System.EventHandler(this.cmbArea_SelectedValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(18, 34);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(114, 19);
            this.label14.TabIndex = 52;
            this.label14.Text = "请选择区域:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(37, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 19);
            this.label1.TabIndex = 52;
            this.label1.Text = "参数选择:";
            // 
            // cmbDictName
            // 
            this.cmbDictName.Font = new System.Drawing.Font("宋体", 14.25F);
            this.cmbDictName.FormattingEnabled = true;
            this.cmbDictName.Location = new System.Drawing.Point(124, 101);
            this.cmbDictName.Name = "cmbDictName";
            this.cmbDictName.Size = new System.Drawing.Size(161, 27);
            this.cmbDictName.TabIndex = 53;
            // 
            // buttonDownload
            // 
            this.buttonDownload.Font = new System.Drawing.Font("宋体", 13F);
            this.buttonDownload.Location = new System.Drawing.Point(42, 170);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(98, 33);
            this.buttonDownload.TabIndex = 54;
            this.buttonDownload.Text = "确认下载";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 13F);
            this.button1.Location = new System.Drawing.Point(167, 170);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 33);
            this.button1.TabIndex = 54;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FrmOtherDict
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 242);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonDownload);
            this.Controls.Add(this.cmbDictName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbArea);
            this.Controls.Add(this.label14);
            this.Name = "FrmOtherDict";
            this.Text = "农合词典信息";
            this.Load += new System.EventHandler(this.FrmOtherDict_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDictName;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.Button button1;
    }
}