namespace MTREG.clintab
{
    partial class FrmClicAfterinfo
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
            this.tcGether = new System.Windows.Forms.TabControl();
            this.tpItemGather = new System.Windows.Forms.TabPage();
            this.btnDesignI = new System.Windows.Forms.Button();
            this.rptPreviewCtrlI = new FastReport.Preview.PreviewControl();
            this.btnPrintI = new System.Windows.Forms.Button();
            this.btnSearchI = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.dtpEtimeI = new System.Windows.Forms.DateTimePicker();
            this.dtpStimeI = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.tpPaytypeGather = new System.Windows.Forms.TabPage();
            this.btnDesignP = new System.Windows.Forms.Button();
            this.rptPreviewCtrlP = new FastReport.Preview.PreviewControl();
            this.btnPrintP = new System.Windows.Forms.Button();
            this.btnSearchP = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpEtimeP = new System.Windows.Forms.DateTimePicker();
            this.dtpStimeP = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.tcGether.SuspendLayout();
            this.tpItemGather.SuspendLayout();
            this.tpPaytypeGather.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcGether
            // 
            this.tcGether.Controls.Add(this.tpItemGather);
            this.tcGether.Controls.Add(this.tpPaytypeGather);
            this.tcGether.Location = new System.Drawing.Point(12, 12);
            this.tcGether.Name = "tcGether";
            this.tcGether.SelectedIndex = 0;
            this.tcGether.Size = new System.Drawing.Size(1165, 893);
            this.tcGether.TabIndex = 0;
            // 
            // tpItemGather
            // 
            this.tpItemGather.Controls.Add(this.btnDesignI);
            this.tpItemGather.Controls.Add(this.rptPreviewCtrlI);
            this.tpItemGather.Controls.Add(this.btnPrintI);
            this.tpItemGather.Controls.Add(this.btnSearchI);
            this.tpItemGather.Controls.Add(this.label15);
            this.tpItemGather.Controls.Add(this.dtpEtimeI);
            this.tpItemGather.Controls.Add(this.dtpStimeI);
            this.tpItemGather.Controls.Add(this.label18);
            this.tpItemGather.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tpItemGather.Location = new System.Drawing.Point(4, 22);
            this.tpItemGather.Name = "tpItemGather";
            this.tpItemGather.Padding = new System.Windows.Forms.Padding(3);
            this.tpItemGather.Size = new System.Drawing.Size(1157, 867);
            this.tpItemGather.TabIndex = 0;
            this.tpItemGather.Text = "项目汇总";
            this.tpItemGather.UseVisualStyleBackColor = true;
            // 
            // btnDesignI
            // 
            this.btnDesignI.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDesignI.Location = new System.Drawing.Point(676, 11);
            this.btnDesignI.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnDesignI.Name = "btnDesignI";
            this.btnDesignI.Size = new System.Drawing.Size(93, 38);
            this.btnDesignI.TabIndex = 116;
            this.btnDesignI.Text = "设计";
            this.btnDesignI.UseVisualStyleBackColor = true;
            this.btnDesignI.Click += new System.EventHandler(this.btnDesignI_Click);
            // 
            // rptPreviewCtrlI
            // 
            this.rptPreviewCtrlI.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.rptPreviewCtrlI.Font = new System.Drawing.Font("宋体", 9F);
            this.rptPreviewCtrlI.Location = new System.Drawing.Point(13, 53);
            this.rptPreviewCtrlI.Name = "rptPreviewCtrlI";
            this.rptPreviewCtrlI.PageOffset = new System.Drawing.Point(10, 10);
            this.rptPreviewCtrlI.Size = new System.Drawing.Size(896, 608);
            this.rptPreviewCtrlI.TabIndex = 115;
            this.rptPreviewCtrlI.UIStyle = FastReport.Utils.UIStyle.Office2007Black;
            // 
            // btnPrintI
            // 
            this.btnPrintI.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrintI.Location = new System.Drawing.Point(803, 10);
            this.btnPrintI.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnPrintI.Name = "btnPrintI";
            this.btnPrintI.Size = new System.Drawing.Size(93, 39);
            this.btnPrintI.TabIndex = 114;
            this.btnPrintI.Text = "打印";
            this.btnPrintI.UseVisualStyleBackColor = true;
            this.btnPrintI.Click += new System.EventHandler(this.btnPrintI_Click);
            // 
            // btnSearchI
            // 
            this.btnSearchI.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearchI.Location = new System.Drawing.Point(551, 10);
            this.btnSearchI.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnSearchI.Name = "btnSearchI";
            this.btnSearchI.Size = new System.Drawing.Size(93, 39);
            this.btnSearchI.TabIndex = 113;
            this.btnSearchI.Text = "查询";
            this.btnSearchI.UseVisualStyleBackColor = true;
            this.btnSearchI.Click += new System.EventHandler(this.btnSearchI_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(306, 17);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 19);
            this.label15.TabIndex = 110;
            this.label15.Text = "至";
            // 
            // dtpEtimeI
            // 
            this.dtpEtimeI.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpEtimeI.Location = new System.Drawing.Point(344, 11);
            this.dtpEtimeI.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dtpEtimeI.Name = "dtpEtimeI";
            this.dtpEtimeI.Size = new System.Drawing.Size(186, 29);
            this.dtpEtimeI.TabIndex = 108;
            // 
            // dtpStimeI
            // 
            this.dtpStimeI.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpStimeI.Location = new System.Drawing.Point(110, 12);
            this.dtpStimeI.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dtpStimeI.Name = "dtpStimeI";
            this.dtpStimeI.Size = new System.Drawing.Size(186, 29);
            this.dtpStimeI.TabIndex = 107;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(9, 16);
            this.label18.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(100, 19);
            this.label18.TabIndex = 109;
            this.label18.Text = "日结时间:";
            // 
            // tpPaytypeGather
            // 
            this.tpPaytypeGather.Controls.Add(this.btnDesignP);
            this.tpPaytypeGather.Controls.Add(this.rptPreviewCtrlP);
            this.tpPaytypeGather.Controls.Add(this.btnPrintP);
            this.tpPaytypeGather.Controls.Add(this.btnSearchP);
            this.tpPaytypeGather.Controls.Add(this.label1);
            this.tpPaytypeGather.Controls.Add(this.dtpEtimeP);
            this.tpPaytypeGather.Controls.Add(this.dtpStimeP);
            this.tpPaytypeGather.Controls.Add(this.label2);
            this.tpPaytypeGather.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tpPaytypeGather.Location = new System.Drawing.Point(4, 22);
            this.tpPaytypeGather.Name = "tpPaytypeGather";
            this.tpPaytypeGather.Padding = new System.Windows.Forms.Padding(3);
            this.tpPaytypeGather.Size = new System.Drawing.Size(1157, 867);
            this.tpPaytypeGather.TabIndex = 1;
            this.tpPaytypeGather.Text = "支付类型汇总";
            this.tpPaytypeGather.UseVisualStyleBackColor = true;
            // 
            // btnDesignP
            // 
            this.btnDesignP.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDesignP.Location = new System.Drawing.Point(693, 7);
            this.btnDesignP.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnDesignP.Name = "btnDesignP";
            this.btnDesignP.Size = new System.Drawing.Size(93, 39);
            this.btnDesignP.TabIndex = 122;
            this.btnDesignP.Text = "设计";
            this.btnDesignP.UseVisualStyleBackColor = true;
            this.btnDesignP.Click += new System.EventHandler(this.btnDesignP_Click);
            // 
            // rptPreviewCtrlP
            // 
            this.rptPreviewCtrlP.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.rptPreviewCtrlP.Font = new System.Drawing.Font("宋体", 9F);
            this.rptPreviewCtrlP.Location = new System.Drawing.Point(13, 48);
            this.rptPreviewCtrlP.Name = "rptPreviewCtrlP";
            this.rptPreviewCtrlP.PageOffset = new System.Drawing.Point(10, 10);
            this.rptPreviewCtrlP.Size = new System.Drawing.Size(1138, 819);
            this.rptPreviewCtrlP.TabIndex = 121;
            this.rptPreviewCtrlP.UIStyle = FastReport.Utils.UIStyle.Office2007Black;
            // 
            // btnPrintP
            // 
            this.btnPrintP.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrintP.Location = new System.Drawing.Point(835, 7);
            this.btnPrintP.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnPrintP.Name = "btnPrintP";
            this.btnPrintP.Size = new System.Drawing.Size(93, 39);
            this.btnPrintP.TabIndex = 120;
            this.btnPrintP.Text = "打印";
            this.btnPrintP.UseVisualStyleBackColor = true;
            this.btnPrintP.Click += new System.EventHandler(this.btnPrintP_Click);
            // 
            // btnSearchP
            // 
            this.btnSearchP.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearchP.Location = new System.Drawing.Point(549, 7);
            this.btnSearchP.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnSearchP.Name = "btnSearchP";
            this.btnSearchP.Size = new System.Drawing.Size(93, 39);
            this.btnSearchP.TabIndex = 119;
            this.btnSearchP.Text = "查询";
            this.btnSearchP.UseVisualStyleBackColor = true;
            this.btnSearchP.Click += new System.EventHandler(this.btnSearchP_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(306, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 19);
            this.label1.TabIndex = 118;
            this.label1.Text = "至";
            // 
            // dtpEtimeP
            // 
            this.dtpEtimeP.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpEtimeP.Location = new System.Drawing.Point(344, 11);
            this.dtpEtimeP.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dtpEtimeP.Name = "dtpEtimeP";
            this.dtpEtimeP.Size = new System.Drawing.Size(186, 29);
            this.dtpEtimeP.TabIndex = 116;
            // 
            // dtpStimeP
            // 
            this.dtpStimeP.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpStimeP.Location = new System.Drawing.Point(110, 12);
            this.dtpStimeP.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dtpStimeP.Name = "dtpStimeP";
            this.dtpStimeP.Size = new System.Drawing.Size(186, 29);
            this.dtpStimeP.TabIndex = 115;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(9, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 19);
            this.label2.TabIndex = 117;
            this.label2.Text = "日结时间:";
            // 
            // FrmClicAfterinfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 701);
            this.Controls.Add(this.tcGether);
            this.Name = "FrmClicAfterinfo";
            this.Text = "结算后情况";
            this.Load += new System.EventHandler(this.FrmAccountGathered_Load);
            this.tcGether.ResumeLayout(false);
            this.tpItemGather.ResumeLayout(false);
            this.tpItemGather.PerformLayout();
            this.tpPaytypeGather.ResumeLayout(false);
            this.tpPaytypeGather.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcGether;
        private System.Windows.Forms.TabPage tpItemGather;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtpEtimeI;
        private System.Windows.Forms.DateTimePicker dtpStimeI;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnPrintI;
        private System.Windows.Forms.Button btnSearchI;
        private System.Windows.Forms.TabPage tpPaytypeGather;
        private System.Windows.Forms.Button btnPrintP;
        private System.Windows.Forms.Button btnSearchP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpEtimeP;
        private System.Windows.Forms.DateTimePicker dtpStimeP;
        private System.Windows.Forms.Label label2;
        private FastReport.Preview.PreviewControl rptPreviewCtrlI;
        private FastReport.Preview.PreviewControl rptPreviewCtrlP;
        private System.Windows.Forms.Button btnDesignI;
        private System.Windows.Forms.Button btnDesignP;
    }
}