namespace MTREG.ihsptab
{
    partial class FrmHspAdjustByDepart
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
            this.tcDep = new System.Windows.Forms.TabControl();
            this.tpIhspDep = new System.Windows.Forms.TabPage();
            this.rptIPreviewCtrl = new FastReport.Preview.PreviewControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbIhspPt = new System.Windows.Forms.ComboBox();
            this.cmbIhspItem = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbIhspDep = new System.Windows.Forms.ComboBox();
            this.btnIhspSearch = new System.Windows.Forms.Button();
            this.btnIhspPrint = new System.Windows.Forms.Button();
            this.dtpIhspEt = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpIhspSt = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tpOhspDep = new System.Windows.Forms.TabPage();
            this.rptOPreviewCtrl = new FastReport.Preview.PreviewControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbOhspPt = new System.Windows.Forms.ComboBox();
            this.cmbOhspItem = new System.Windows.Forms.ComboBox();
            this.cmbOhspDep = new System.Windows.Forms.ComboBox();
            this.btnOhspSearch = new System.Windows.Forms.Button();
            this.btnOhspPrint = new System.Windows.Forms.Button();
            this.dtpOhspEt = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpOhspSt = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tcDep.SuspendLayout();
            this.tpIhspDep.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tpOhspDep.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcDep
            // 
            this.tcDep.Controls.Add(this.tpIhspDep);
            this.tcDep.Controls.Add(this.tpOhspDep);
            this.tcDep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcDep.Location = new System.Drawing.Point(0, 0);
            this.tcDep.Name = "tcDep";
            this.tcDep.SelectedIndex = 0;
            this.tcDep.Size = new System.Drawing.Size(966, 473);
            this.tcDep.TabIndex = 0;
            this.tcDep.Selected += new System.Windows.Forms.TabControlEventHandler(this.tcDep_Selected);
            // 
            // tpIhspDep
            // 
            this.tpIhspDep.Controls.Add(this.rptIPreviewCtrl);
            this.tpIhspDep.Controls.Add(this.panel1);
            this.tpIhspDep.Location = new System.Drawing.Point(4, 22);
            this.tpIhspDep.Name = "tpIhspDep";
            this.tpIhspDep.Padding = new System.Windows.Forms.Padding(3);
            this.tpIhspDep.Size = new System.Drawing.Size(958, 447);
            this.tpIhspDep.TabIndex = 0;
            this.tpIhspDep.Text = "住院科室核算";
            this.tpIhspDep.UseVisualStyleBackColor = true;
            // 
            // rptIPreviewCtrl
            // 
            this.rptIPreviewCtrl.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.rptIPreviewCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptIPreviewCtrl.Font = new System.Drawing.Font("宋体", 9F);
            this.rptIPreviewCtrl.Location = new System.Drawing.Point(3, 61);
            this.rptIPreviewCtrl.Name = "rptIPreviewCtrl";
            this.rptIPreviewCtrl.PageOffset = new System.Drawing.Point(10, 10);
            this.rptIPreviewCtrl.Size = new System.Drawing.Size(952, 383);
            this.rptIPreviewCtrl.TabIndex = 3;
            this.rptIPreviewCtrl.UIStyle = FastReport.Utils.UIStyle.VisualStudio2005;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbIhspPt);
            this.panel1.Controls.Add(this.cmbIhspItem);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.cmbIhspDep);
            this.panel1.Controls.Add(this.btnIhspSearch);
            this.panel1.Controls.Add(this.btnIhspPrint);
            this.panel1.Controls.Add(this.dtpIhspEt);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpIhspSt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(952, 58);
            this.panel1.TabIndex = 2;
            // 
            // cmbIhspPt
            // 
            this.cmbIhspPt.Font = new System.Drawing.Font("宋体", 9F);
            this.cmbIhspPt.FormattingEnabled = true;
            this.cmbIhspPt.ItemHeight = 12;
            this.cmbIhspPt.Location = new System.Drawing.Point(634, 18);
            this.cmbIhspPt.Name = "cmbIhspPt";
            this.cmbIhspPt.Size = new System.Drawing.Size(87, 20);
            this.cmbIhspPt.TabIndex = 108;
            // 
            // cmbIhspItem
            // 
            this.cmbIhspItem.Font = new System.Drawing.Font("宋体", 9F);
            this.cmbIhspItem.FormattingEnabled = true;
            this.cmbIhspItem.ItemHeight = 12;
            this.cmbIhspItem.Location = new System.Drawing.Point(486, 18);
            this.cmbIhspItem.Name = "cmbIhspItem";
            this.cmbIhspItem.Size = new System.Drawing.Size(87, 20);
            this.cmbIhspItem.TabIndex = 109;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F);
            this.label9.Location = new System.Drawing.Point(579, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 106;
            this.label9.Text = "支付类型:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9F);
            this.label10.Location = new System.Drawing.Point(452, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 12);
            this.label10.TabIndex = 107;
            this.label10.Text = "类型:";
            // 
            // cmbIhspDep
            // 
            this.cmbIhspDep.Font = new System.Drawing.Font("宋体", 9F);
            this.cmbIhspDep.FormattingEnabled = true;
            this.cmbIhspDep.ItemHeight = 12;
            this.cmbIhspDep.Location = new System.Drawing.Point(346, 18);
            this.cmbIhspDep.Name = "cmbIhspDep";
            this.cmbIhspDep.Size = new System.Drawing.Size(100, 20);
            this.cmbIhspDep.TabIndex = 105;
            // 
            // btnIhspSearch
            // 
            this.btnIhspSearch.Font = new System.Drawing.Font("宋体", 9F);
            this.btnIhspSearch.Location = new System.Drawing.Point(723, 17);
            this.btnIhspSearch.Name = "btnIhspSearch";
            this.btnIhspSearch.Size = new System.Drawing.Size(80, 25);
            this.btnIhspSearch.TabIndex = 104;
            this.btnIhspSearch.Text = "查询";
            this.btnIhspSearch.UseVisualStyleBackColor = true;
            this.btnIhspSearch.Click += new System.EventHandler(this.btnIhspSearch_Click);
            // 
            // btnIhspPrint
            // 
            this.btnIhspPrint.Font = new System.Drawing.Font("宋体", 9F);
            this.btnIhspPrint.Location = new System.Drawing.Point(867, 17);
            this.btnIhspPrint.Name = "btnIhspPrint";
            this.btnIhspPrint.Size = new System.Drawing.Size(80, 25);
            this.btnIhspPrint.TabIndex = 103;
            this.btnIhspPrint.Text = "打印";
            this.btnIhspPrint.UseVisualStyleBackColor = true;
            this.btnIhspPrint.Click += new System.EventHandler(this.btnIhspPrint_Click);
            // 
            // dtpIhspEt
            // 
            this.dtpIhspEt.Font = new System.Drawing.Font("宋体", 9F);
            this.dtpIhspEt.Location = new System.Drawing.Point(196, 18);
            this.dtpIhspEt.Name = "dtpIhspEt";
            this.dtpIhspEt.Size = new System.Drawing.Size(112, 21);
            this.dtpIhspEt.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.Location = new System.Drawing.Point(172, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 54;
            this.label1.Text = "至";
            // 
            // dtpIhspSt
            // 
            this.dtpIhspSt.Font = new System.Drawing.Font("宋体", 9F);
            this.dtpIhspSt.Location = new System.Drawing.Point(57, 18);
            this.dtpIhspSt.Name = "dtpIhspSt";
            this.dtpIhspSt.Size = new System.Drawing.Size(109, 21);
            this.dtpIhspSt.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.Location = new System.Drawing.Point(314, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 53;
            this.label2.Text = "科室:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F);
            this.label5.Location = new System.Drawing.Point(26, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 53;
            this.label5.Text = "时间:";
            // 
            // tpOhspDep
            // 
            this.tpOhspDep.Controls.Add(this.rptOPreviewCtrl);
            this.tpOhspDep.Controls.Add(this.panel2);
            this.tpOhspDep.Location = new System.Drawing.Point(4, 22);
            this.tpOhspDep.Name = "tpOhspDep";
            this.tpOhspDep.Padding = new System.Windows.Forms.Padding(3);
            this.tpOhspDep.Size = new System.Drawing.Size(958, 447);
            this.tpOhspDep.TabIndex = 1;
            this.tpOhspDep.Text = "出院科室核算";
            this.tpOhspDep.UseVisualStyleBackColor = true;
            // 
            // rptOPreviewCtrl
            // 
            this.rptOPreviewCtrl.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.rptOPreviewCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptOPreviewCtrl.Font = new System.Drawing.Font("宋体", 9F);
            this.rptOPreviewCtrl.Location = new System.Drawing.Point(3, 61);
            this.rptOPreviewCtrl.Name = "rptOPreviewCtrl";
            this.rptOPreviewCtrl.PageOffset = new System.Drawing.Point(10, 10);
            this.rptOPreviewCtrl.Size = new System.Drawing.Size(952, 383);
            this.rptOPreviewCtrl.TabIndex = 5;
            this.rptOPreviewCtrl.UIStyle = FastReport.Utils.UIStyle.VisualStudio2005;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbOhspPt);
            this.panel2.Controls.Add(this.cmbOhspItem);
            this.panel2.Controls.Add(this.cmbOhspDep);
            this.panel2.Controls.Add(this.btnOhspSearch);
            this.panel2.Controls.Add(this.btnOhspPrint);
            this.panel2.Controls.Add(this.dtpOhspEt);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dtpOhspSt);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(952, 58);
            this.panel2.TabIndex = 4;
            // 
            // cmbOhspPt
            // 
            this.cmbOhspPt.Font = new System.Drawing.Font("宋体", 9F);
            this.cmbOhspPt.FormattingEnabled = true;
            this.cmbOhspPt.ItemHeight = 12;
            this.cmbOhspPt.Location = new System.Drawing.Point(629, 18);
            this.cmbOhspPt.Name = "cmbOhspPt";
            this.cmbOhspPt.Size = new System.Drawing.Size(87, 20);
            this.cmbOhspPt.TabIndex = 105;
            // 
            // cmbOhspItem
            // 
            this.cmbOhspItem.Font = new System.Drawing.Font("宋体", 9F);
            this.cmbOhspItem.FormattingEnabled = true;
            this.cmbOhspItem.ItemHeight = 12;
            this.cmbOhspItem.Location = new System.Drawing.Point(481, 18);
            this.cmbOhspItem.Name = "cmbOhspItem";
            this.cmbOhspItem.Size = new System.Drawing.Size(87, 20);
            this.cmbOhspItem.TabIndex = 105;
            // 
            // cmbOhspDep
            // 
            this.cmbOhspDep.Font = new System.Drawing.Font("宋体", 9F);
            this.cmbOhspDep.FormattingEnabled = true;
            this.cmbOhspDep.ItemHeight = 12;
            this.cmbOhspDep.Location = new System.Drawing.Point(350, 18);
            this.cmbOhspDep.Name = "cmbOhspDep";
            this.cmbOhspDep.Size = new System.Drawing.Size(86, 20);
            this.cmbOhspDep.TabIndex = 105;
            // 
            // btnOhspSearch
            // 
            this.btnOhspSearch.Font = new System.Drawing.Font("宋体", 9F);
            this.btnOhspSearch.Location = new System.Drawing.Point(719, 16);
            this.btnOhspSearch.Name = "btnOhspSearch";
            this.btnOhspSearch.Size = new System.Drawing.Size(80, 25);
            this.btnOhspSearch.TabIndex = 104;
            this.btnOhspSearch.Text = "查询";
            this.btnOhspSearch.UseVisualStyleBackColor = true;
            this.btnOhspSearch.Click += new System.EventHandler(this.btnOhspSearch_Click);
            // 
            // btnOhspPrint
            // 
            this.btnOhspPrint.Font = new System.Drawing.Font("宋体", 9F);
            this.btnOhspPrint.Location = new System.Drawing.Point(865, 16);
            this.btnOhspPrint.Name = "btnOhspPrint";
            this.btnOhspPrint.Size = new System.Drawing.Size(80, 25);
            this.btnOhspPrint.TabIndex = 103;
            this.btnOhspPrint.Text = "打印";
            this.btnOhspPrint.UseVisualStyleBackColor = true;
            this.btnOhspPrint.Click += new System.EventHandler(this.btnOhspPrint_Click);
            // 
            // dtpOhspEt
            // 
            this.dtpOhspEt.Font = new System.Drawing.Font("宋体", 9F);
            this.dtpOhspEt.Location = new System.Drawing.Point(200, 18);
            this.dtpOhspEt.Name = "dtpOhspEt";
            this.dtpOhspEt.Size = new System.Drawing.Size(112, 21);
            this.dtpOhspEt.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F);
            this.label3.Location = new System.Drawing.Point(176, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 54;
            this.label3.Text = "至";
            // 
            // dtpOhspSt
            // 
            this.dtpOhspSt.Font = new System.Drawing.Font("宋体", 9F);
            this.dtpOhspSt.Location = new System.Drawing.Point(61, 18);
            this.dtpOhspSt.Name = "dtpOhspSt";
            this.dtpOhspSt.Size = new System.Drawing.Size(109, 21);
            this.dtpOhspSt.TabIndex = 51;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F);
            this.label8.Location = new System.Drawing.Point(574, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 53;
            this.label8.Text = "支付类型:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F);
            this.label7.Location = new System.Drawing.Point(447, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 53;
            this.label7.Text = "类型:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F);
            this.label4.Location = new System.Drawing.Point(318, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 53;
            this.label4.Text = "科室:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F);
            this.label6.Location = new System.Drawing.Point(30, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 53;
            this.label6.Text = "时间:";
            // 
            // FrmHspAdjustByDepart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 473);
            this.Controls.Add(this.tcDep);
            this.Name = "FrmHspAdjustByDepart";
            this.Text = "科室核算";
            this.Load += new System.EventHandler(this.FrmDepartAcc_Load);
            this.tcDep.ResumeLayout(false);
            this.tpIhspDep.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tpOhspDep.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcDep;
        private System.Windows.Forms.TabPage tpIhspDep;
        private FastReport.Preview.PreviewControl rptIPreviewCtrl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbIhspDep;
        private System.Windows.Forms.Button btnIhspSearch;
        private System.Windows.Forms.Button btnIhspPrint;
        private System.Windows.Forms.DateTimePicker dtpIhspEt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpIhspSt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tpOhspDep;
        private FastReport.Preview.PreviewControl rptOPreviewCtrl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbOhspDep;
        private System.Windows.Forms.Button btnOhspSearch;
        private System.Windows.Forms.Button btnOhspPrint;
        private System.Windows.Forms.DateTimePicker dtpOhspEt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpOhspSt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbIhspPt;
        private System.Windows.Forms.ComboBox cmbIhspItem;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbOhspPt;
        private System.Windows.Forms.ComboBox cmbOhspItem;
        private System.Windows.Forms.Label label8;

    }
}