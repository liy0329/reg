namespace MTREG.medinsur.gysyb.clinic
{
    partial class FrmWdzgrd
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxGrbh = new System.Windows.Forms.TextBox();
            this.tbxSfzh = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnRd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cbxYbxm = new System.Windows.Forms.ComboBox();
            this.cmbDoctor = new System.Windows.Forms.ComboBox();
            this.cmbDepart = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(41, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "医保个人编号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(64, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "项目名称";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(41, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "医生身份证号";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(65, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "医生姓名";
            // 
            // tbxGrbh
            // 
            this.tbxGrbh.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.tbxGrbh.Location = new System.Drawing.Point(159, 24);
            this.tbxGrbh.Name = "tbxGrbh";
            this.tbxGrbh.Size = new System.Drawing.Size(390, 26);
            this.tbxGrbh.TabIndex = 5;
            this.tbxGrbh.TextChanged += new System.EventHandler(this.tbxGrbh_TextChanged);
            // 
            // tbxSfzh
            // 
            this.tbxSfzh.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.tbxSfzh.Location = new System.Drawing.Point(159, 187);
            this.tbxSfzh.Name = "tbxSfzh";
            this.tbxSfzh.Size = new System.Drawing.Size(390, 26);
            this.tbxSfzh.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(64, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "就诊科室";
            // 
            // btnRd
            // 
            this.btnRd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btnRd.Location = new System.Drawing.Point(218, 245);
            this.btnRd.Name = "btnRd";
            this.btnRd.Size = new System.Drawing.Size(75, 31);
            this.btnRd.TabIndex = 14;
            this.btnRd.Text = "认定";
            this.btnRd.UseVisualStyleBackColor = true;
            this.btnRd.Click += new System.EventHandler(this.btnRd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.Location = new System.Drawing.Point(343, 245);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 31);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbxYbxm
            // 
            this.cbxYbxm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.cbxYbxm.FormattingEnabled = true;
            this.cbxYbxm.Location = new System.Drawing.Point(161, 80);
            this.cbxYbxm.Name = "cbxYbxm";
            this.cbxYbxm.Size = new System.Drawing.Size(390, 24);
            this.cbxYbxm.TabIndex = 17;
            // 
            // cmbDoctor
            // 
            this.cmbDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDoctor.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbDoctor.FormattingEnabled = true;
            this.cmbDoctor.Location = new System.Drawing.Point(159, 152);
            this.cmbDoctor.Name = "cmbDoctor";
            this.cmbDoctor.Size = new System.Drawing.Size(390, 24);
            this.cmbDoctor.TabIndex = 24;
            this.cmbDoctor.SelectedValueChanged += new System.EventHandler(this.cmbDoctor_SelectedValueChanged);
            // 
            // cmbDepart
            // 
            this.cmbDepart.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbDepart.FormattingEnabled = true;
            this.cmbDepart.Location = new System.Drawing.Point(159, 117);
            this.cmbDepart.Name = "cmbDepart";
            this.cmbDepart.Size = new System.Drawing.Size(390, 24);
            this.cmbDepart.TabIndex = 23;
            this.cmbDepart.SelectedValueChanged += new System.EventHandler(this.cmbDepart_SelectedValueChanged);
            this.cmbDepart.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbDepart_KeyDown);
            // 
            // FrmWdzgrd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 379);
            this.Controls.Add(this.cmbDoctor);
            this.Controls.Add(this.cmbDepart);
            this.Controls.Add(this.cbxYbxm);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbxSfzh);
            this.Controls.Add(this.tbxGrbh);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "FrmWdzgrd";
            this.Text = "五定资格认定";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxGrbh;
        private System.Windows.Forms.TextBox tbxSfzh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnRd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cbxYbxm;
        private System.Windows.Forms.ComboBox cmbDoctor;
        private System.Windows.Forms.ComboBox cmbDepart;
    }
}