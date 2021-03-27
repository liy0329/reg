namespace MTREG.kls
{
    partial class Frmxzybml
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
            this.dateTimeYdyb = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFeeUpLoad = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateTimeYdyb
            // 
            this.dateTimeYdyb.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeYdyb.Location = new System.Drawing.Point(20, 36);
            this.dateTimeYdyb.Name = "dateTimeYdyb";
            this.dateTimeYdyb.Size = new System.Drawing.Size(161, 21);
            this.dateTimeYdyb.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(210, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "更新目录";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(210, 85);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "更新医保信息";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(311, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "检查、药品、诊疗等";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(20, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 18);
            this.label2.TabIndex = 170;
            this.label2.Text = "0";
            // 
            // lblFeeUpLoad
            // 
            this.lblFeeUpLoad.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFeeUpLoad.ForeColor = System.Drawing.Color.Blue;
            this.lblFeeUpLoad.Location = new System.Drawing.Point(16, 69);
            this.lblFeeUpLoad.Name = "lblFeeUpLoad";
            this.lblFeeUpLoad.Size = new System.Drawing.Size(188, 18);
            this.lblFeeUpLoad.TabIndex = 169;
            this.lblFeeUpLoad.Text = "上传情况：";
            // 
            // Frmxzybml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 202);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblFeeUpLoad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimeYdyb);
            this.Name = "Frmxzybml";
            this.Text = "更新医保目录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimeYdyb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFeeUpLoad;
    }
}