namespace MTREG.ihsp
{
    partial class FrmGzsnhInsurMag
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
            this.cmbPatienttype = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnOuthspReg = new System.Windows.Forms.Button();
            this.btnIhspChange = new System.Windows.Forms.Button();
            this.btnReCost = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnTruncode = new System.Windows.Forms.Button();
            this.btnTopLine = new System.Windows.Forms.Button();
            this.btnInUpAudit = new System.Windows.Forms.Button();
            this.btnRetOutHsp = new System.Windows.Forms.Button();
            this.print = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbPatienttype
            // 
            this.cmbPatienttype.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbPatienttype.FormattingEnabled = true;
            this.cmbPatienttype.ItemHeight = 15;
            this.cmbPatienttype.Location = new System.Drawing.Point(90, 18);
            this.cmbPatienttype.Name = "cmbPatienttype";
            this.cmbPatienttype.Size = new System.Drawing.Size(140, 23);
            this.cmbPatienttype.TabIndex = 56;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 11F);
            this.label8.Location = new System.Drawing.Point(19, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 15);
            this.label8.TabIndex = 57;
            this.label8.Text = "患者类型:";
            // 
            // btnOuthspReg
            // 
            this.btnOuthspReg.Font = new System.Drawing.Font("宋体", 11F);
            this.btnOuthspReg.Location = new System.Drawing.Point(108, 86);
            this.btnOuthspReg.Name = "btnOuthspReg";
            this.btnOuthspReg.Size = new System.Drawing.Size(80, 26);
            this.btnOuthspReg.TabIndex = 58;
            this.btnOuthspReg.Text = "出院登记";
            this.btnOuthspReg.UseVisualStyleBackColor = true;
            this.btnOuthspReg.Click += new System.EventHandler(this.btnOuthspReg_Click);
            // 
            // btnIhspChange
            // 
            this.btnIhspChange.Font = new System.Drawing.Font("宋体", 11F);
            this.btnIhspChange.Location = new System.Drawing.Point(26, 86);
            this.btnIhspChange.Name = "btnIhspChange";
            this.btnIhspChange.Size = new System.Drawing.Size(80, 26);
            this.btnIhspChange.TabIndex = 58;
            this.btnIhspChange.Text = "住院变动";
            this.btnIhspChange.UseVisualStyleBackColor = true;
            this.btnIhspChange.Click += new System.EventHandler(this.btnIhspChange_Click);
            // 
            // btnReCost
            // 
            this.btnReCost.Font = new System.Drawing.Font("宋体", 11F);
            this.btnReCost.Location = new System.Drawing.Point(190, 86);
            this.btnReCost.Name = "btnReCost";
            this.btnReCost.Size = new System.Drawing.Size(80, 26);
            this.btnReCost.TabIndex = 58;
            this.btnReCost.Text = "费用重传";
            this.btnReCost.UseVisualStyleBackColor = true;
            this.btnReCost.Click += new System.EventHandler(this.btnReCost_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("宋体", 11F);
            this.btnDelete.Location = new System.Drawing.Point(26, 54);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 26);
            this.btnDelete.TabIndex = 58;
            this.btnDelete.Text = "费用删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnTruncode
            // 
            this.btnTruncode.Font = new System.Drawing.Font("宋体", 11F);
            this.btnTruncode.Location = new System.Drawing.Point(26, 118);
            this.btnTruncode.Name = "btnTruncode";
            this.btnTruncode.Size = new System.Drawing.Size(90, 26);
            this.btnTruncode.TabIndex = 58;
            this.btnTruncode.Text = "转诊单管理";
            this.btnTruncode.UseVisualStyleBackColor = true;
            this.btnTruncode.Click += new System.EventHandler(this.btnTruncode_Click);
            // 
            // btnTopLine
            // 
            this.btnTopLine.Enabled = false;
            this.btnTopLine.Font = new System.Drawing.Font("宋体", 11F);
            this.btnTopLine.Location = new System.Drawing.Point(26, 150);
            this.btnTopLine.Name = "btnTopLine";
            this.btnTopLine.Size = new System.Drawing.Size(124, 26);
            this.btnTopLine.TabIndex = 78;
            this.btnTopLine.Text = "获取住院封顶线";
            this.btnTopLine.UseVisualStyleBackColor = true;
            this.btnTopLine.Visible = false;
            this.btnTopLine.Click += new System.EventHandler(this.btnTopLine_Click);
            // 
            // btnInUpAudit
            // 
            this.btnInUpAudit.Enabled = false;
            this.btnInUpAudit.Font = new System.Drawing.Font("宋体", 11F);
            this.btnInUpAudit.Location = new System.Drawing.Point(131, 118);
            this.btnInUpAudit.Name = "btnInUpAudit";
            this.btnInUpAudit.Size = new System.Drawing.Size(112, 26);
            this.btnInUpAudit.TabIndex = 77;
            this.btnInUpAudit.Text = "住院提交审核";
            this.btnInUpAudit.UseVisualStyleBackColor = true;
            this.btnInUpAudit.Visible = false;
            this.btnInUpAudit.Click += new System.EventHandler(this.btnInUpAudit_Click);
            // 
            // btnRetOutHsp
            // 
            this.btnRetOutHsp.Font = new System.Drawing.Font("宋体", 11F);
            this.btnRetOutHsp.Location = new System.Drawing.Point(163, 150);
            this.btnRetOutHsp.Name = "btnRetOutHsp";
            this.btnRetOutHsp.Size = new System.Drawing.Size(80, 26);
            this.btnRetOutHsp.TabIndex = 79;
            this.btnRetOutHsp.Text = "出院回退";
            this.btnRetOutHsp.UseVisualStyleBackColor = true;
            this.btnRetOutHsp.Click += new System.EventHandler(this.btnRetOutHsp_Click);
            // 
            // print
            // 
            this.print.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.print.Location = new System.Drawing.Point(26, 182);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(105, 23);
            this.print.TabIndex = 80;
            this.print.Text = "报补单打印";
            this.print.UseVisualStyleBackColor = true;
            this.print.Visible = false;
            this.print.Click += new System.EventHandler(this.print_Click);
            // 
            // FrmGzsnhInsurMag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 209);
            this.Controls.Add(this.print);
            this.Controls.Add(this.btnRetOutHsp);
            this.Controls.Add(this.btnTopLine);
            this.Controls.Add(this.btnInUpAudit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnReCost);
            this.Controls.Add(this.btnTruncode);
            this.Controls.Add(this.btnIhspChange);
            this.Controls.Add(this.btnOuthspReg);
            this.Controls.Add(this.cmbPatienttype);
            this.Controls.Add(this.label8);
            this.Name = "FrmGzsnhInsurMag";
            this.Text = "医保管理";
            this.Load += new System.EventHandler(this.FrmInsurMag_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPatienttype;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnOuthspReg;
        private System.Windows.Forms.Button btnIhspChange;
        private System.Windows.Forms.Button btnReCost;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnTruncode;
        private System.Windows.Forms.Button btnTopLine;
        private System.Windows.Forms.Button btnInUpAudit;
        private System.Windows.Forms.Button btnRetOutHsp;
        private System.Windows.Forms.Button print;
    }
}