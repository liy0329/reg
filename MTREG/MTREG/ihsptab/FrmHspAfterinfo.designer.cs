namespace MTREG.ihsptab
{
    partial class FrmHspAfterinfo
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
            this.tbxCharger = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.cmbPer = new System.Windows.Forms.ComboBox();
            this.cmbDep = new System.Windows.Forms.ComboBox();
            this.cbxDep = new System.Windows.Forms.CheckBox();
            this.cbxPer = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.cbxAfterAcc = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rptPreviewCtrl = new FastReport.Preview.PreviewControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxCharger
            // 
            this.tbxCharger.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxCharger.Location = new System.Drawing.Point(70, 42);
            this.tbxCharger.Name = "tbxCharger";
            this.tbxCharger.Size = new System.Drawing.Size(99, 24);
            this.tbxCharger.TabIndex = 110;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("宋体", 11F);
            this.btnSearch.Location = new System.Drawing.Point(609, 39);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 25);
            this.btnSearch.TabIndex = 102;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("宋体", 11F);
            this.btnPrint.Location = new System.Drawing.Point(712, 38);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(80, 25);
            this.btnPrint.TabIndex = 101;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cmbPer
            // 
            this.cmbPer.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbPer.FormattingEnabled = true;
            this.cmbPer.ItemHeight = 15;
            this.cmbPer.Location = new System.Drawing.Point(304, 40);
            this.cmbPer.Name = "cmbPer";
            this.cmbPer.Size = new System.Drawing.Size(100, 23);
            this.cmbPer.TabIndex = 97;
            // 
            // cmbDep
            // 
            this.cmbDep.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbDep.FormattingEnabled = true;
            this.cmbDep.ItemHeight = 15;
            this.cmbDep.Location = new System.Drawing.Point(503, 40);
            this.cmbDep.Name = "cmbDep";
            this.cmbDep.Size = new System.Drawing.Size(100, 23);
            this.cmbDep.TabIndex = 98;
            // 
            // cbxDep
            // 
            this.cbxDep.AutoSize = true;
            this.cbxDep.Font = new System.Drawing.Font("宋体", 11F);
            this.cbxDep.Location = new System.Drawing.Point(415, 44);
            this.cbxDep.Name = "cbxDep";
            this.cbxDep.Size = new System.Drawing.Size(94, 19);
            this.cbxDep.TabIndex = 99;
            this.cbxDep.Text = "科室汇总:";
            this.cbxDep.UseVisualStyleBackColor = true;
            this.cbxDep.CheckedChanged += new System.EventHandler(this.cbxDep_CheckedChanged);
            // 
            // cbxPer
            // 
            this.cbxPer.AutoSize = true;
            this.cbxPer.Font = new System.Drawing.Font("宋体", 11F);
            this.cbxPer.Location = new System.Drawing.Point(245, 44);
            this.cbxPer.Name = "cbxPer";
            this.cbxPer.Size = new System.Drawing.Size(64, 19);
            this.cbxPer.TabIndex = 100;
            this.cbxPer.Text = "个人:";
            this.cbxPer.UseVisualStyleBackColor = true;
            this.cbxPer.CheckedChanged += new System.EventHandler(this.cbxPer_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 11F);
            this.label10.Location = new System.Drawing.Point(13, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 15);
            this.label10.TabIndex = 95;
            this.label10.Text = "收费员:";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Font = new System.Drawing.Font("宋体", 11F);
            this.dtpEndTime.Location = new System.Drawing.Point(314, 10);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(146, 24);
            this.dtpEndTime.TabIndex = 86;
            this.dtpEndTime.ValueChanged += new System.EventHandler(this.dtpEndTime_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(292, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 15);
            this.label1.TabIndex = 89;
            this.label1.Text = "至";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Font = new System.Drawing.Font("宋体", 11F);
            this.dtpStartTime.Location = new System.Drawing.Point(143, 10);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(147, 24);
            this.dtpStartTime.TabIndex = 85;
            this.dtpStartTime.ValueChanged += new System.EventHandler(this.dtpStartTime_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F);
            this.label2.Location = new System.Drawing.Point(174, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 88;
            this.label2.Text = "结账方式:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 11F);
            this.label5.Location = new System.Drawing.Point(73, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 87;
            this.label5.Text = "结账时间:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 11F);
            this.label7.Location = new System.Drawing.Point(464, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 15);
            this.label7.TabIndex = 95;
            this.label7.Text = "患者姓名:";
            // 
            // tbxName
            // 
            this.tbxName.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxName.Location = new System.Drawing.Point(536, 11);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(99, 24);
            this.tbxName.TabIndex = 110;
            // 
            // cbxAfterAcc
            // 
            this.cbxAfterAcc.AutoSize = true;
            this.cbxAfterAcc.Font = new System.Drawing.Font("宋体", 11F);
            this.cbxAfterAcc.Location = new System.Drawing.Point(8, 12);
            this.cbxAfterAcc.Name = "cbxAfterAcc";
            this.cbxAfterAcc.Size = new System.Drawing.Size(79, 19);
            this.cbxAfterAcc.TabIndex = 100;
            this.cbxAfterAcc.Text = "结算后:";
            this.cbxAfterAcc.UseVisualStyleBackColor = true;
            this.cbxAfterAcc.CheckedChanged += new System.EventHandler(this.cbxAfterAcc_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtpStartTime);
            this.panel1.Controls.Add(this.dtpEndTime);
            this.panel1.Controls.Add(this.tbxName);
            this.panel1.Controls.Add(this.cmbDep);
            this.panel1.Controls.Add(this.tbxCharger);
            this.panel1.Controls.Add(this.cmbPer);
            this.panel1.Controls.Add(this.cbxPer);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cbxAfterAcc);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.cbxDep);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(804, 73);
            this.panel1.TabIndex = 111;
            // 
            // rptPreviewCtrl
            // 
            this.rptPreviewCtrl.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.rptPreviewCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptPreviewCtrl.Font = new System.Drawing.Font("宋体", 9F);
            this.rptPreviewCtrl.Location = new System.Drawing.Point(0, 73);
            this.rptPreviewCtrl.Name = "rptPreviewCtrl";
            this.rptPreviewCtrl.PageOffset = new System.Drawing.Point(10, 10);
            this.rptPreviewCtrl.Size = new System.Drawing.Size(804, 492);
            this.rptPreviewCtrl.TabIndex = 112;
            this.rptPreviewCtrl.UIStyle = FastReport.Utils.UIStyle.VisualStudio2005;
            // 
            // FrmHspAfterinfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 565);
            this.Controls.Add(this.rptPreviewCtrl);
            this.Controls.Add(this.panel1);
            this.Name = "FrmHspAfterinfo";
            this.Text = "结算后情况";
            this.Load += new System.EventHandler(this.FrmAfterAcc_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbxCharger;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ComboBox cmbPer;
        private System.Windows.Forms.ComboBox cmbDep;
        private System.Windows.Forms.CheckBox cbxDep;
        private System.Windows.Forms.CheckBox cbxPer;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.CheckBox cbxAfterAcc;
        private System.Windows.Forms.Panel panel1;
        private FastReport.Preview.PreviewControl rptPreviewCtrl;
    }
}