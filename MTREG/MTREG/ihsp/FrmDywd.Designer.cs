namespace MTREG.ihsp
{
    partial class FrmDywd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDywd));
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnPrintBarcode = new System.Windows.Forms.Button();
            this.code391 = new Barcodes.Code39();
            this.btn_PrintToImg = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(959, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(21, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(907, 91);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnPrintBarcode
            // 
            this.btnPrintBarcode.Location = new System.Drawing.Point(57, 312);
            this.btnPrintBarcode.Name = "btnPrintBarcode";
            this.btnPrintBarcode.Size = new System.Drawing.Size(75, 23);
            this.btnPrintBarcode.TabIndex = 3;
            this.btnPrintBarcode.Text = "打印";
            this.btnPrintBarcode.UseVisualStyleBackColor = true;
            this.btnPrintBarcode.Click += new System.EventHandler(this.btnPrintBarcode_Click);
            // 
            // code391
            // 
            this.code391.Age = "年龄：33";
            this.code391.BackColor = System.Drawing.Color.White;
            this.code391.BarcodeHeight = 30;
            this.code391.BarcodeRect = ((System.Drawing.RectangleF)(resources.GetObject("code391.BarcodeRect")));
            this.code391.barcodeRotation = Barcodes.BarcodeRotation.Rotation0;
            this.code391.barcodeTextAlign = Barcodes.BarcodeTextAlign.Left;
            this.code391.BarcodeValue = "0123456";
            this.code391.BarcodeWeight = Barcodes.BarCodeWeight.Small;
            this.code391.Hspregid = "住院号：1234567";
            this.code391.Inhspat = "入院日期：2014-09-10";
            this.code391.Linespacing = 15F;
            this.code391.Location = new System.Drawing.Point(21, 122);
            this.code391.Name = "code391";
            this.code391.Sex = "性别：男";
            this.code391.ShowText = true;
            this.code391.ShowTextOnTop = false;
            this.code391.Sickname = "姓名：张三";
            this.code391.Size = new System.Drawing.Size(1040, 138);
            this.code391.TabIndex = 5;
            this.code391.ValueTextFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // btn_PrintToImg
            // 
            this.btn_PrintToImg.Location = new System.Drawing.Point(171, 312);
            this.btn_PrintToImg.Name = "btn_PrintToImg";
            this.btn_PrintToImg.Size = new System.Drawing.Size(75, 23);
            this.btn_PrintToImg.TabIndex = 4;
            this.btn_PrintToImg.Text = "打印到图片";
            this.btn_PrintToImg.UseVisualStyleBackColor = true;
            this.btn_PrintToImg.Click += new System.EventHandler(this.btn_PrintToImg_Click);
            // 
            // FrmDywd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 438);
            this.Controls.Add(this.btn_PrintToImg);
            this.Controls.Add(this.btnPrintBarcode);
            this.Controls.Add(this.code391);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Name = "FrmDywd";
            this.Text = "FrmDywd";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Barcodes.Code39 code391;
        private System.Windows.Forms.Button btnPrintBarcode;
        private System.Windows.Forms.Button btn_PrintToImg;
    }
}