namespace MTREG.clintab
{
    partial class FrmClicTabReport
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
            this.btnDesign = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpEtime = new System.Windows.Forms.DateTimePicker();
            this.dtpStime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.tcReport = new System.Windows.Forms.TabControl();
            this.tpCharger = new System.Windows.Forms.TabPage();
            this.rptPreviewCtrlC = new FastReport.Preview.PreviewControl();
            this.tpIncome = new System.Windows.Forms.TabPage();
            this.rptPreviewCtrlI = new FastReport.Preview.PreviewControl();
            this.tpPayType = new System.Windows.Forms.TabPage();
            this.rptPreviewCtrlP = new FastReport.Preview.PreviewControl();
            this.tpMember = new System.Windows.Forms.TabPage();
            this.pcMember = new FastReport.Preview.PreviewControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tcReport.SuspendLayout();
            this.tpCharger.SuspendLayout();
            this.tpIncome.SuspendLayout();
            this.tpPayType.SuspendLayout();
            this.tpMember.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDesign
            // 
            this.btnDesign.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDesign.Location = new System.Drawing.Point(730, 9);
            this.btnDesign.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnDesign.Name = "btnDesign";
            this.btnDesign.Size = new System.Drawing.Size(93, 39);
            this.btnDesign.TabIndex = 129;
            this.btnDesign.Text = "设计";
            this.btnDesign.UseVisualStyleBackColor = true;
            this.btnDesign.Click += new System.EventHandler(this.btnDesign_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrint.Location = new System.Drawing.Point(872, 9);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(93, 39);
            this.btnPrint.TabIndex = 128;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(361, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 19);
            this.label1.TabIndex = 126;
            this.label1.Text = "至";
            // 
            // dtpEtime
            // 
            this.dtpEtime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEtime.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpEtime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEtime.Location = new System.Drawing.Point(396, 14);
            this.dtpEtime.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dtpEtime.Name = "dtpEtime";
            this.dtpEtime.Size = new System.Drawing.Size(247, 29);
            this.dtpEtime.TabIndex = 124;
            // 
            // dtpStime
            // 
            this.dtpStime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpStime.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpStime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStime.Location = new System.Drawing.Point(109, 14);
            this.dtpStime.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dtpStime.Name = "dtpStime";
            this.dtpStime.Size = new System.Drawing.Size(246, 29);
            this.dtpStime.TabIndex = 123;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(8, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 19);
            this.label2.TabIndex = 125;
            this.label2.Text = "日结时间:";
            // 
            // tcReport
            // 
            this.tcReport.Controls.Add(this.tpCharger);
            this.tcReport.Controls.Add(this.tpIncome);
            this.tcReport.Controls.Add(this.tpPayType);
            this.tcReport.Controls.Add(this.tpMember);
            this.tcReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcReport.Location = new System.Drawing.Point(0, 64);
            this.tcReport.Name = "tcReport";
            this.tcReport.SelectedIndex = 0;
            this.tcReport.Size = new System.Drawing.Size(998, 686);
            this.tcReport.TabIndex = 130;
            this.tcReport.SelectedIndexChanged += new System.EventHandler(this.tcReport_SelectedIndexChanged);
            // 
            // tpCharger
            // 
            this.tpCharger.Controls.Add(this.rptPreviewCtrlC);
            this.tpCharger.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tpCharger.Location = new System.Drawing.Point(4, 22);
            this.tpCharger.Name = "tpCharger";
            this.tpCharger.Padding = new System.Windows.Forms.Padding(3);
            this.tpCharger.Size = new System.Drawing.Size(990, 660);
            this.tpCharger.TabIndex = 0;
            this.tpCharger.Text = "门诊收费员日结表";
            this.tpCharger.UseVisualStyleBackColor = true;
            // 
            // rptPreviewCtrlC
            // 
            this.rptPreviewCtrlC.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.rptPreviewCtrlC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptPreviewCtrlC.Font = new System.Drawing.Font("宋体", 9F);
            this.rptPreviewCtrlC.Location = new System.Drawing.Point(3, 3);
            this.rptPreviewCtrlC.Name = "rptPreviewCtrlC";
            this.rptPreviewCtrlC.PageOffset = new System.Drawing.Point(10, 10);
            this.rptPreviewCtrlC.Size = new System.Drawing.Size(984, 654);
            this.rptPreviewCtrlC.TabIndex = 116;
            this.rptPreviewCtrlC.UIStyle = FastReport.Utils.UIStyle.Office2007Black;
            // 
            // tpIncome
            // 
            this.tpIncome.Controls.Add(this.rptPreviewCtrlI);
            this.tpIncome.Location = new System.Drawing.Point(4, 22);
            this.tpIncome.Name = "tpIncome";
            this.tpIncome.Padding = new System.Windows.Forms.Padding(3);
            this.tpIncome.Size = new System.Drawing.Size(990, 660);
            this.tpIncome.TabIndex = 1;
            this.tpIncome.Text = "门诊收入汇总日结表";
            this.tpIncome.UseVisualStyleBackColor = true;
            // 
            // rptPreviewCtrlI
            // 
            this.rptPreviewCtrlI.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.rptPreviewCtrlI.Font = new System.Drawing.Font("宋体", 9F);
            this.rptPreviewCtrlI.Location = new System.Drawing.Point(3, 3);
            this.rptPreviewCtrlI.Name = "rptPreviewCtrlI";
            this.rptPreviewCtrlI.PageOffset = new System.Drawing.Point(10, 10);
            this.rptPreviewCtrlI.Size = new System.Drawing.Size(979, 799);
            this.rptPreviewCtrlI.TabIndex = 117;
            this.rptPreviewCtrlI.UIStyle = FastReport.Utils.UIStyle.Office2007Black;
            // 
            // tpPayType
            // 
            this.tpPayType.Controls.Add(this.rptPreviewCtrlP);
            this.tpPayType.Location = new System.Drawing.Point(4, 22);
            this.tpPayType.Name = "tpPayType";
            this.tpPayType.Padding = new System.Windows.Forms.Padding(3);
            this.tpPayType.Size = new System.Drawing.Size(990, 660);
            this.tpPayType.TabIndex = 2;
            this.tpPayType.Text = "支付类型日结表";
            this.tpPayType.UseVisualStyleBackColor = true;
            // 
            // rptPreviewCtrlP
            // 
            this.rptPreviewCtrlP.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.rptPreviewCtrlP.Font = new System.Drawing.Font("宋体", 9F);
            this.rptPreviewCtrlP.Location = new System.Drawing.Point(3, 4);
            this.rptPreviewCtrlP.Name = "rptPreviewCtrlP";
            this.rptPreviewCtrlP.PageOffset = new System.Drawing.Point(10, 10);
            this.rptPreviewCtrlP.Size = new System.Drawing.Size(979, 798);
            this.rptPreviewCtrlP.TabIndex = 117;
            this.rptPreviewCtrlP.UIStyle = FastReport.Utils.UIStyle.Office2007Black;
            // 
            // tpMember
            // 
            this.tpMember.Controls.Add(this.pcMember);
            this.tpMember.Location = new System.Drawing.Point(4, 22);
            this.tpMember.Name = "tpMember";
            this.tpMember.Size = new System.Drawing.Size(990, 660);
            this.tpMember.TabIndex = 3;
            this.tpMember.Text = "储值卡收入汇总表";
            this.tpMember.UseVisualStyleBackColor = true;
            // 
            // pcMember
            // 
            this.pcMember.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pcMember.Font = new System.Drawing.Font("宋体", 9F);
            this.pcMember.Location = new System.Drawing.Point(3, 3);
            this.pcMember.Name = "pcMember";
            this.pcMember.PageOffset = new System.Drawing.Point(10, 10);
            this.pcMember.Size = new System.Drawing.Size(979, 798);
            this.pcMember.TabIndex = 118;
            this.pcMember.UIStyle = FastReport.Utils.UIStyle.Office2007Black;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDesign);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpEtime);
            this.panel1.Controls.Add(this.dtpStime);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(998, 64);
            this.panel1.TabIndex = 131;
            // 
            // FrmClicTabReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 750);
            this.Controls.Add(this.tcReport);
            this.Controls.Add(this.panel1);
            this.Name = "FrmClicTabReport";
            this.Text = "门诊日结/班结打印";
            this.Load += new System.EventHandler(this.FrmClinicTabReport_Load);
            this.tcReport.ResumeLayout(false);
            this.tpCharger.ResumeLayout(false);
            this.tpIncome.ResumeLayout(false);
            this.tpPayType.ResumeLayout(false);
            this.tpMember.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDesign;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpEtime;
        private System.Windows.Forms.DateTimePicker dtpStime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tcReport;
        private System.Windows.Forms.TabPage tpCharger;
        private System.Windows.Forms.TabPage tpIncome;
        private System.Windows.Forms.TabPage tpPayType;
        private FastReport.Preview.PreviewControl rptPreviewCtrlC;
        private FastReport.Preview.PreviewControl rptPreviewCtrlI;
        private FastReport.Preview.PreviewControl rptPreviewCtrlP;
        private System.Windows.Forms.TabPage tpMember;
        private FastReport.Preview.PreviewControl pcMember;
        private System.Windows.Forms.Panel panel1;
    }
}