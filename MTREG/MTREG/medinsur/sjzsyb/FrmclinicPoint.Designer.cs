namespace MTREG.medinsur.sjzsyb
{
    partial class FrmclinicPoint
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
            this.button1 = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.comboYllb = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(276, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 26);
            this.button1.TabIndex = 0;
            this.button1.Text = "设置门诊定点";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(17, 51);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(63, 14);
            this.label18.TabIndex = 174;
            this.label18.Text = "定点类型";
            // 
            // comboYllb
            // 
            this.comboYllb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboYllb.FormattingEnabled = true;
            this.comboYllb.Location = new System.Drawing.Point(86, 48);
            this.comboYllb.Name = "comboYllb";
            this.comboYllb.Size = new System.Drawing.Size(164, 20);
            this.comboYllb.TabIndex = 173;
            // 
            // Frmactivation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 138);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.comboYllb);
            this.Controls.Add(this.button1);
            this.Name = "Frmactivation";
            this.Text = "设置门诊定点";
            this.Load += new System.EventHandler(this.Frmactivation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox comboYllb;
    }
}