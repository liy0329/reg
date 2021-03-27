namespace MTREG.clinic
{
    partial class FrmMemCardstatLock
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
            this.lblBalance = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblHspcard = new System.Windows.Forms.Label();
            this.lblIdcard = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("宋体", 11F);
            this.btnOK.Location = new System.Drawing.Point(181, 113);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(70, 25);
            this.btnOK.TabIndex = 137;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 11F);
            this.btnCancel.Location = new System.Drawing.Point(258, 113);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 25);
            this.btnCancel.TabIndex = 136;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("宋体", 11F);
            this.lblBalance.Location = new System.Drawing.Point(191, 54);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(52, 15);
            this.lblBalance.TabIndex = 133;
            this.lblBalance.Text = "×××";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(152, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 135;
            this.label1.Text = "余额:";
            // 
            // lblHspcard
            // 
            this.lblHspcard.AutoSize = true;
            this.lblHspcard.Font = new System.Drawing.Font("宋体", 11F);
            this.lblHspcard.Location = new System.Drawing.Point(83, 19);
            this.lblHspcard.Name = "lblHspcard";
            this.lblHspcard.Size = new System.Drawing.Size(67, 15);
            this.lblHspcard.TabIndex = 132;
            this.lblHspcard.Text = "××××";
            // 
            // lblIdcard
            // 
            this.lblIdcard.AutoSize = true;
            this.lblIdcard.Font = new System.Drawing.Font("宋体", 11F);
            this.lblIdcard.Location = new System.Drawing.Point(84, 88);
            this.lblIdcard.Name = "lblIdcard";
            this.lblIdcard.Size = new System.Drawing.Size(52, 15);
            this.lblIdcard.TabIndex = 134;
            this.lblIdcard.Text = "×××";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("宋体", 11F);
            this.lblName.Location = new System.Drawing.Point(83, 54);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(52, 15);
            this.lblName.TabIndex = 131;
            this.lblName.Text = "×××";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 11F);
            this.label4.Location = new System.Drawing.Point(15, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 128;
            this.label4.Text = "会员卡号:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 11F);
            this.label3.Location = new System.Drawing.Point(15, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 129;
            this.label3.Text = "身份证号:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F);
            this.label2.Location = new System.Drawing.Point(45, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 130;
            this.label2.Text = "姓名:";
            // 
            // FrmMemCardstatLock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 139);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblHspcard);
            this.Controls.Add(this.lblIdcard);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "FrmMemCardstatLock";
            this.Text = "会员卡冻结";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblHspcard;
        private System.Windows.Forms.Label lblIdcard;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}