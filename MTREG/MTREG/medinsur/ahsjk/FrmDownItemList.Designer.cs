namespace MTREG.medinsur.ahsjk
{
    partial class FrmDownItemList
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
            this.butClose = new System.Windows.Forms.Button();
            this.butDown = new System.Windows.Forms.Button();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(49, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "下载最新的药品、诊疗信息";
            // 
            // butClose
            // 
            this.butClose.Location = new System.Drawing.Point(178, 148);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(65, 23);
            this.butClose.TabIndex = 4;
            this.butClose.Text = "退出";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // butDown
            // 
            this.butDown.Location = new System.Drawing.Point(89, 87);
            this.butDown.Name = "butDown";
            this.butDown.Size = new System.Drawing.Size(75, 23);
            this.butDown.TabIndex = 3;
            this.butDown.Text = "开始下载";
            this.butDown.UseVisualStyleBackColor = true;
            this.butDown.Click += new System.EventHandler(this.butDown_Click);
            // 
            // cmbArea
            // 
            this.cmbArea.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(81, 52);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(161, 23);
            this.cmbArea.TabIndex = 81;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 11F);
            this.label11.Location = new System.Drawing.Point(11, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 15);
            this.label11.TabIndex = 80;
            this.label11.Text = "选择区域:";
            // 
            // FrmDownItemList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 177);
            this.Controls.Add(this.cmbArea);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.butDown);
            this.Controls.Add(this.label1);
            this.Name = "FrmDownItemList";
            this.Text = "下载最新的药品、诊疗、ICD10码";
            this.Load += new System.EventHandler(this.FrmDownItemList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.Button butDown;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Label label11;
    }
}