namespace MTREG.ihsptab
{
    partial class FrmHspAdjustByDoctor
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
            this.tcDoc = new System.Windows.Forms.TabControl();
            this.tpIhspDoc = new System.Windows.Forms.TabPage();
            this.rptIPreviewCtrl = new FastReport.Preview.PreviewControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbIhspItem = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbIhspDoc = new System.Windows.Forms.ComboBox();
            this.btnIhspSearch = new System.Windows.Forms.Button();
            this.btnIhspPrint = new System.Windows.Forms.Button();
            this.dtpIhspEt = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpIhspSt = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tpOhspDoc = new System.Windows.Forms.TabPage();
            this.rptOPreviewCtrl = new FastReport.Preview.PreviewControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbOhspItem = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbOhspDoc = new System.Windows.Forms.ComboBox();
            this.btnOhspSearch = new System.Windows.Forms.Button();
            this.btnOhspPrint = new System.Windows.Forms.Button();
            this.dtpOhspEt = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpOhspSt = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tcDoc.SuspendLayout();
            this.tpIhspDoc.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tpOhspDoc.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcDoc
            // 
            this.tcDoc.Controls.Add(this.tpIhspDoc);
            this.tcDoc.Controls.Add(this.tpOhspDoc);
            this.tcDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcDoc.Location = new System.Drawing.Point(0, 0);
            this.tcDoc.Name = "tcDoc";
            this.tcDoc.SelectedIndex = 0;
            this.tcDoc.Size = new System.Drawing.Size(819, 483);
            this.tcDoc.TabIndex = 0;
            this.tcDoc.Selected += new System.Windows.Forms.TabControlEventHandler(this.tcDoc_Selected);
            // 
            // tpIhspDoc
            // 
            this.tpIhspDoc.Controls.Add(this.rptIPreviewCtrl);
            this.tpIhspDoc.Controls.Add(this.panel1);
            this.tpIhspDoc.Location = new System.Drawing.Point(4, 22);
            this.tpIhspDoc.Name = "tpIhspDoc";
            this.tpIhspDoc.Padding = new System.Windows.Forms.Padding(3);
            this.tpIhspDoc.Size = new System.Drawing.Size(811, 457);
            this.tpIhspDoc.TabIndex = 0;
            this.tpIhspDoc.Text = "住院医生核算";
            this.tpIhspDoc.UseVisualStyleBackColor = true;
            // 
            // rptIPreviewCtrl
            // 
            this.rptIPreviewCtrl.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.rptIPreviewCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptIPreviewCtrl.Font = new System.Drawing.Font("宋体", 9F);
            this.rptIPreviewCtrl.Location = new System.Drawing.Point(3, 61);
            this.rptIPreviewCtrl.Name = "rptIPreviewCtrl";
            this.rptIPreviewCtrl.PageOffset = new System.Drawing.Point(10, 10);
            this.rptIPreviewCtrl.Size = new System.Drawing.Size(805, 393);
            this.rptIPreviewCtrl.TabIndex = 5;
            this.rptIPreviewCtrl.UIStyle = FastReport.Utils.UIStyle.VisualStudio2005;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbIhspItem);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.cmbIhspDoc);
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
            this.panel1.Size = new System.Drawing.Size(805, 58);
            this.panel1.TabIndex = 4;
            // 
            // cmbIhspItem
            // 
            this.cmbIhspItem.Font = new System.Drawing.Font("宋体", 9F);
            this.cmbIhspItem.FormattingEnabled = true;
            this.cmbIhspItem.ItemHeight = 12;
            this.cmbIhspItem.Location = new System.Drawing.Point(488, 18);
            this.cmbIhspItem.Name = "cmbIhspItem";
            this.cmbIhspItem.Size = new System.Drawing.Size(87, 20);
            this.cmbIhspItem.TabIndex = 111;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9F);
            this.label10.Location = new System.Drawing.Point(454, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 12);
            this.label10.TabIndex = 110;
            this.label10.Text = "类型:";
            // 
            // cmbIhspDoc
            // 
            this.cmbIhspDoc.Font = new System.Drawing.Font("宋体", 9F);
            this.cmbIhspDoc.FormattingEnabled = true;
            this.cmbIhspDoc.ItemHeight = 12;
            this.cmbIhspDoc.Location = new System.Drawing.Point(347, 18);
            this.cmbIhspDoc.Name = "cmbIhspDoc";
            this.cmbIhspDoc.Size = new System.Drawing.Size(100, 20);
            this.cmbIhspDoc.TabIndex = 105;
            // 
            // btnIhspSearch
            // 
            this.btnIhspSearch.Font = new System.Drawing.Font("宋体", 9F);
            this.btnIhspSearch.Location = new System.Drawing.Point(578, 16);
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
            this.btnIhspPrint.Location = new System.Drawing.Point(718, 16);
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
            this.dtpIhspEt.Location = new System.Drawing.Point(197, 18);
            this.dtpIhspEt.Name = "dtpIhspEt";
            this.dtpIhspEt.Size = new System.Drawing.Size(112, 21);
            this.dtpIhspEt.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.Location = new System.Drawing.Point(173, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 54;
            this.label1.Text = "至";
            // 
            // dtpIhspSt
            // 
            this.dtpIhspSt.Font = new System.Drawing.Font("宋体", 9F);
            this.dtpIhspSt.Location = new System.Drawing.Point(58, 18);
            this.dtpIhspSt.Name = "dtpIhspSt";
            this.dtpIhspSt.Size = new System.Drawing.Size(109, 21);
            this.dtpIhspSt.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.Location = new System.Drawing.Point(315, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 53;
            this.label2.Text = "科室:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F);
            this.label5.Location = new System.Drawing.Point(27, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 53;
            this.label5.Text = "时间:";
            // 
            // tpOhspDoc
            // 
            this.tpOhspDoc.Controls.Add(this.rptOPreviewCtrl);
            this.tpOhspDoc.Controls.Add(this.panel2);
            this.tpOhspDoc.Location = new System.Drawing.Point(4, 22);
            this.tpOhspDoc.Name = "tpOhspDoc";
            this.tpOhspDoc.Padding = new System.Windows.Forms.Padding(3);
            this.tpOhspDoc.Size = new System.Drawing.Size(811, 457);
            this.tpOhspDoc.TabIndex = 1;
            this.tpOhspDoc.Text = "出院医生核算";
            this.tpOhspDoc.UseVisualStyleBackColor = true;
            // 
            // rptOPreviewCtrl
            // 
            this.rptOPreviewCtrl.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.rptOPreviewCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptOPreviewCtrl.Font = new System.Drawing.Font("宋体", 9F);
            this.rptOPreviewCtrl.Location = new System.Drawing.Point(3, 61);
            this.rptOPreviewCtrl.Name = "rptOPreviewCtrl";
            this.rptOPreviewCtrl.PageOffset = new System.Drawing.Point(10, 10);
            this.rptOPreviewCtrl.Size = new System.Drawing.Size(805, 393);
            this.rptOPreviewCtrl.TabIndex = 5;
            this.rptOPreviewCtrl.UIStyle = FastReport.Utils.UIStyle.VisualStudio2005;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbOhspItem);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cmbOhspDoc);
            this.panel2.Controls.Add(this.btnOhspSearch);
            this.panel2.Controls.Add(this.btnOhspPrint);
            this.panel2.Controls.Add(this.dtpOhspEt);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dtpOhspSt);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(805, 58);
            this.panel2.TabIndex = 4;
            // 
            // cmbOhspItem
            // 
            this.cmbOhspItem.Font = new System.Drawing.Font("宋体", 9F);
            this.cmbOhspItem.FormattingEnabled = true;
            this.cmbOhspItem.ItemHeight = 12;
            this.cmbOhspItem.Location = new System.Drawing.Point(489, 18);
            this.cmbOhspItem.Name = "cmbOhspItem";
            this.cmbOhspItem.Size = new System.Drawing.Size(87, 20);
            this.cmbOhspItem.TabIndex = 113;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F);
            this.label7.Location = new System.Drawing.Point(455, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 112;
            this.label7.Text = "类型:";
            // 
            // cmbOhspDoc
            // 
            this.cmbOhspDoc.Font = new System.Drawing.Font("宋体", 9F);
            this.cmbOhspDoc.FormattingEnabled = true;
            this.cmbOhspDoc.ItemHeight = 12;
            this.cmbOhspDoc.Location = new System.Drawing.Point(347, 18);
            this.cmbOhspDoc.Name = "cmbOhspDoc";
            this.cmbOhspDoc.Size = new System.Drawing.Size(100, 20);
            this.cmbOhspDoc.TabIndex = 105;
            // 
            // btnOhspSearch
            // 
            this.btnOhspSearch.Font = new System.Drawing.Font("宋体", 9F);
            this.btnOhspSearch.Location = new System.Drawing.Point(579, 16);
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
            this.btnOhspPrint.Location = new System.Drawing.Point(717, 16);
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
            this.dtpOhspEt.Location = new System.Drawing.Point(197, 18);
            this.dtpOhspEt.Name = "dtpOhspEt";
            this.dtpOhspEt.Size = new System.Drawing.Size(112, 21);
            this.dtpOhspEt.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F);
            this.label3.Location = new System.Drawing.Point(173, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 54;
            this.label3.Text = "至";
            // 
            // dtpOhspSt
            // 
            this.dtpOhspSt.Font = new System.Drawing.Font("宋体", 9F);
            this.dtpOhspSt.Location = new System.Drawing.Point(58, 18);
            this.dtpOhspSt.Name = "dtpOhspSt";
            this.dtpOhspSt.Size = new System.Drawing.Size(109, 21);
            this.dtpOhspSt.TabIndex = 51;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F);
            this.label4.Location = new System.Drawing.Point(315, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 53;
            this.label4.Text = "科室:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F);
            this.label6.Location = new System.Drawing.Point(28, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 53;
            this.label6.Text = "时间:";
            // 
            // FrmHspAdjustByDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 483);
            this.Controls.Add(this.tcDoc);
            this.Name = "FrmHspAdjustByDoctor";
            this.Text = "医生核算";
            this.Load += new System.EventHandler(this.FrmDoctorAcc_Load);
            this.tcDoc.ResumeLayout(false);
            this.tpIhspDoc.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tpOhspDoc.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcDoc;
        private System.Windows.Forms.TabPage tpIhspDoc;
        private FastReport.Preview.PreviewControl rptIPreviewCtrl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbIhspDoc;
        private System.Windows.Forms.Button btnIhspSearch;
        private System.Windows.Forms.Button btnIhspPrint;
        private System.Windows.Forms.DateTimePicker dtpIhspEt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpIhspSt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tpOhspDoc;
        private FastReport.Preview.PreviewControl rptOPreviewCtrl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbOhspDoc;
        private System.Windows.Forms.Button btnOhspSearch;
        private System.Windows.Forms.Button btnOhspPrint;
        private System.Windows.Forms.DateTimePicker dtpOhspEt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpOhspSt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbIhspItem;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbOhspItem;
        private System.Windows.Forms.Label label7;
    }
}