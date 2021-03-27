namespace MTREG.medinsur
{
    partial class FrmAreaInfodet
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbInsurtype = new System.Windows.Forms.ComboBox();
            this.tbxAreaname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxAreacode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxMemo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxInsuritemtype = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(27, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "接口类型:";
            // 
            // cmbInsurtype
            // 
            this.cmbInsurtype.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbInsurtype.FormattingEnabled = true;
            this.cmbInsurtype.Location = new System.Drawing.Point(97, 12);
            this.cmbInsurtype.Name = "cmbInsurtype";
            this.cmbInsurtype.Size = new System.Drawing.Size(174, 23);
            this.cmbInsurtype.TabIndex = 4;
            // 
            // tbxAreaname
            // 
            this.tbxAreaname.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxAreaname.Location = new System.Drawing.Point(97, 55);
            this.tbxAreaname.Name = "tbxAreaname";
            this.tbxAreaname.Size = new System.Drawing.Size(174, 24);
            this.tbxAreaname.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F);
            this.label2.Location = new System.Drawing.Point(27, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "区域名称:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 11F);
            this.label3.Location = new System.Drawing.Point(27, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "区域编码:";
            // 
            // tbxAreacode
            // 
            this.tbxAreacode.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxAreacode.Location = new System.Drawing.Point(97, 100);
            this.tbxAreacode.Name = "tbxAreacode";
            this.tbxAreacode.Size = new System.Drawing.Size(174, 24);
            this.tbxAreacode.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 11F);
            this.label4.Location = new System.Drawing.Point(57, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "备注:";
            // 
            // tbxMemo
            // 
            this.tbxMemo.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxMemo.Location = new System.Drawing.Point(97, 151);
            this.tbxMemo.Name = "tbxMemo";
            this.tbxMemo.Size = new System.Drawing.Size(174, 24);
            this.tbxMemo.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 11F);
            this.label5.Location = new System.Drawing.Point(12, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "目录类型码:";
            // 
            // tbxInsuritemtype
            // 
            this.tbxInsuritemtype.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxInsuritemtype.Location = new System.Drawing.Point(97, 199);
            this.tbxInsuritemtype.Name = "tbxInsuritemtype";
            this.tbxInsuritemtype.Size = new System.Drawing.Size(174, 24);
            this.tbxInsuritemtype.TabIndex = 6;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("宋体", 11F);
            this.btnClose.Location = new System.Drawing.Point(220, 261);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 26);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("宋体", 11F);
            this.btnSave.Location = new System.Drawing.Point(139, 261);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 26);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmAreaInfodet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 293);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tbxMemo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxInsuritemtype);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbxAreacode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxAreaname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbInsurtype);
            this.Name = "FrmAreaInfodet";
            this.Text = "编辑区域信息";
            this.Load += new System.EventHandler(this.FrmAreaInfodet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbInsurtype;
        private System.Windows.Forms.TextBox tbxAreaname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxAreacode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxMemo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxInsuritemtype;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
    }
}