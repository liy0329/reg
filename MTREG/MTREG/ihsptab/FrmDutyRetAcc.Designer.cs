namespace MTREG.ihsptab
{
    partial class FrmDutyRetAcc
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
            this.lblBillcode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBillcode
            // 
            this.lblBillcode.AutoSize = true;
            this.lblBillcode.Font = new System.Drawing.Font("宋体", 11F);
            this.lblBillcode.Location = new System.Drawing.Point(98, 49);
            this.lblBillcode.Name = "lblBillcode";
            this.lblBillcode.Size = new System.Drawing.Size(39, 15);
            this.lblBillcode.TabIndex = 121;
            this.lblBillcode.Text = "xxxx";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 15);
            this.label1.TabIndex = 120;
            this.label1.Text = "你确定要撤回最后一次日结算吗?";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 11F);
            this.label14.Location = new System.Drawing.Point(30, 50);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 15);
            this.label14.TabIndex = 119;
            this.label14.Text = "班结单号:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(169, 91);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(61, 23);
            this.btnClose.TabIndex = 117;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(100, 91);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(61, 23);
            this.btnOk.TabIndex = 118;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // FrmDutyRetAcc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 121);
            this.Controls.Add(this.lblBillcode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Name = "FrmDutyRetAcc";
            this.Text = "班结退结算";
            this.Load += new System.EventHandler(this.FrmDutyRetAcc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBillcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOk;
    }
}