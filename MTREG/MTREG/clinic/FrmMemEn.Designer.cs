namespace MTREG.clinic
{
    partial class FrmMemEn
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbxAftBalance = new System.Windows.Forms.TextBox();
            this.tbxEnFee = new System.Windows.Forms.TextBox();
            this.tbxNowBalance = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblHspCard = new System.Windows.Forms.Label();
            this.lblIdcard = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPayType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("宋体", 13F);
            this.btnOK.Location = new System.Drawing.Point(491, 137);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(70, 25);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            this.btnOK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnOK_KeyDown);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("宋体", 13F);
            this.btnCancel.Location = new System.Drawing.Point(567, 137);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 25);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnCancel_KeyDown);
            // 
            // tbxAftBalance
            // 
            this.tbxAftBalance.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxAftBalance.Location = new System.Drawing.Point(550, 77);
            this.tbxAftBalance.Multiline = true;
            this.tbxAftBalance.Name = "tbxAftBalance";
            this.tbxAftBalance.Size = new System.Drawing.Size(86, 31);
            this.tbxAftBalance.TabIndex = 113;
            // 
            // tbxEnFee
            // 
            this.tbxEnFee.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxEnFee.Location = new System.Drawing.Point(329, 61);
            this.tbxEnFee.Name = "tbxEnFee";
            this.tbxEnFee.Size = new System.Drawing.Size(100, 31);
            this.tbxEnFee.TabIndex = 1;
            this.tbxEnFee.TextChanged += new System.EventHandler(this.tbxEnFee_TextChanged);
            this.tbxEnFee.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxEnFee_KeyDown);
            // 
            // tbxNowBalance
            // 
            this.tbxNowBalance.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxNowBalance.Location = new System.Drawing.Point(109, 76);
            this.tbxNowBalance.Multiline = true;
            this.tbxNowBalance.Name = "tbxNowBalance";
            this.tbxNowBalance.Size = new System.Drawing.Size(100, 31);
            this.tbxNowBalance.TabIndex = 111;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(447, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 21);
            this.label6.TabIndex = 114;
            this.label6.Text = "剩余余额:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(227, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 21);
            this.label5.TabIndex = 115;
            this.label5.Text = "取现金额:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 21);
            this.label1.TabIndex = 116;
            this.label1.Text = "当前余额:";
            // 
            // lblHspCard
            // 
            this.lblHspCard.AutoSize = true;
            this.lblHspCard.Font = new System.Drawing.Font("宋体", 11F);
            this.lblHspCard.Location = new System.Drawing.Point(105, 21);
            this.lblHspCard.Name = "lblHspCard";
            this.lblHspCard.Size = new System.Drawing.Size(67, 15);
            this.lblHspCard.TabIndex = 109;
            this.lblHspCard.Text = "××××";
            // 
            // lblIdcard
            // 
            this.lblIdcard.AutoSize = true;
            this.lblIdcard.Font = new System.Drawing.Font("宋体", 11F);
            this.lblIdcard.Location = new System.Drawing.Point(444, 21);
            this.lblIdcard.Name = "lblIdcard";
            this.lblIdcard.Size = new System.Drawing.Size(52, 15);
            this.lblIdcard.TabIndex = 110;
            this.lblIdcard.Text = "×××";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("宋体", 11F);
            this.lblName.Location = new System.Drawing.Point(273, 21);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(52, 15);
            this.lblName.TabIndex = 108;
            this.lblName.Text = "×××";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 11F);
            this.label4.Location = new System.Drawing.Point(36, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 105;
            this.label4.Text = "会员卡号:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 11F);
            this.label3.Location = new System.Drawing.Point(375, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 106;
            this.label3.Text = "身份证号:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F);
            this.label2.Location = new System.Drawing.Point(232, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 107;
            this.label2.Text = "姓名:";
            // 
            // cmbPayType
            // 
            this.cmbPayType.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbPayType.FormattingEnabled = true;
            this.cmbPayType.Location = new System.Drawing.Point(328, 102);
            this.cmbPayType.Name = "cmbPayType";
            this.cmbPayType.Size = new System.Drawing.Size(102, 29);
            this.cmbPayType.TabIndex = 2;
            this.cmbPayType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbPayType_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(226, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 21);
            this.label7.TabIndex = 123;
            this.label7.Text = "支付类型:";
            // 
            // FrmMemEn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 168);
            this.Controls.Add(this.cmbPayType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tbxAftBalance);
            this.Controls.Add(this.tbxEnFee);
            this.Controls.Add(this.tbxNowBalance);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblHspCard);
            this.Controls.Add(this.lblIdcard);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "FrmMemEn";
            this.Text = "会员卡取现";
            this.Load += new System.EventHandler(this.FrmMemEn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbxAftBalance;
        private System.Windows.Forms.TextBox tbxEnFee;
        private System.Windows.Forms.TextBox tbxNowBalance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblHspCard;
        private System.Windows.Forms.Label lblIdcard;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPayType;
        private System.Windows.Forms.Label label7;
    }
}