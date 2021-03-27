namespace MTHIS.chklist
{
    partial class FrmChanagePrinter
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
            this.cmbxPrinterName = new System.Windows.Forms.ComboBox();
            this.lblRPT = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblPrinter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbxPrinterName
            // 
            this.cmbxPrinterName.FormattingEnabled = true;
            this.cmbxPrinterName.Location = new System.Drawing.Point(13, 62);
            this.cmbxPrinterName.Name = "cmbxPrinterName";
            this.cmbxPrinterName.Size = new System.Drawing.Size(268, 20);
            this.cmbxPrinterName.TabIndex = 0;
            // 
            // lblRPT
            // 
            this.lblRPT.AutoSize = true;
            this.lblRPT.Location = new System.Drawing.Point(13, 13);
            this.lblRPT.Name = "lblRPT";
            this.lblRPT.Size = new System.Drawing.Size(41, 12);
            this.lblRPT.TabIndex = 1;
            this.lblRPT.Text = "label1";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(48, 112);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(154, 112);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblPrinter
            // 
            this.lblPrinter.AutoSize = true;
            this.lblPrinter.Location = new System.Drawing.Point(13, 38);
            this.lblPrinter.Name = "lblPrinter";
            this.lblPrinter.Size = new System.Drawing.Size(41, 12);
            this.lblPrinter.TabIndex = 1;
            this.lblPrinter.Text = "label1";
            // 
            // FrmChanagePrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 147);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblPrinter);
            this.Controls.Add(this.lblRPT);
            this.Controls.Add(this.cmbxPrinterName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChanagePrinter";
            this.Text = "选择打印机";
            this.Load += new System.EventHandler(this.FrmChanagePrinter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbxPrinterName;
        private System.Windows.Forms.Label lblRPT;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblPrinter;
    }
}