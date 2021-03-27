namespace MTREG.medinsur.ahsjk
{
    partial class FrmDownHospitals
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
            this.btn_Down = new System.Windows.Forms.Button();
            this.dgv_HspInfo = new System.Windows.Forms.DataGridView();
            this.dtp_Date = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_UserPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_UserCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HspInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Down
            // 
            this.btn_Down.Location = new System.Drawing.Point(306, 39);
            this.btn_Down.Name = "btn_Down";
            this.btn_Down.Size = new System.Drawing.Size(75, 23);
            this.btn_Down.TabIndex = 13;
            this.btn_Down.Text = "下载";
            this.btn_Down.UseVisualStyleBackColor = true;
            this.btn_Down.Click += new System.EventHandler(this.btn_Down_Click);
            // 
            // dgv_HspInfo
            // 
            this.dgv_HspInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_HspInfo.Location = new System.Drawing.Point(7, 68);
            this.dgv_HspInfo.Name = "dgv_HspInfo";
            this.dgv_HspInfo.RowTemplate.Height = 23;
            this.dgv_HspInfo.Size = new System.Drawing.Size(553, 253);
            this.dgv_HspInfo.TabIndex = 12;
            // 
            // dtp_Date
            // 
            this.dtp_Date.Location = new System.Drawing.Point(68, 39);
            this.dtp_Date.Name = "dtp_Date";
            this.dtp_Date.Size = new System.Drawing.Size(119, 21);
            this.dtp_Date.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "更新时间:";
            // 
            // txt_UserPass
            // 
            this.txt_UserPass.Location = new System.Drawing.Point(460, 11);
            this.txt_UserPass.Name = "txt_UserPass";
            this.txt_UserPass.Size = new System.Drawing.Size(100, 21);
            this.txt_UserPass.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(392, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "新农合密码:";
            // 
            // txt_UserCode
            // 
            this.txt_UserCode.Location = new System.Drawing.Point(281, 11);
            this.txt_UserCode.Name = "txt_UserCode";
            this.txt_UserCode.Size = new System.Drawing.Size(100, 21);
            this.txt_UserCode.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(201, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "新农合用户名:";
            // 
            // cmbArea
            // 
            this.cmbArea.Font = new System.Drawing.Font("宋体", 9F);
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(68, 10);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(119, 20);
            this.cmbArea.TabIndex = 81;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 9F);
            this.label11.Location = new System.Drawing.Point(12, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 80;
            this.label11.Text = "选择区域:";
            // 
            // FrmDownHospitals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 330);
            this.Controls.Add(this.cmbArea);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btn_Down);
            this.Controls.Add(this.dgv_HspInfo);
            this.Controls.Add(this.dtp_Date);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_UserPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_UserCode);
            this.Controls.Add(this.label1);
            this.Name = "FrmDownHospitals";
            this.Text = "下载全省医疗机构信息";
            this.Load += new System.EventHandler(this.FrmDownHospitals_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HspInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Down;
        private System.Windows.Forms.DataGridView dgv_HspInfo;
        private System.Windows.Forms.DateTimePicker dtp_Date;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_UserPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_UserCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Label label11;
    }
}