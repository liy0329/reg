namespace MTREG.clintab.bll
{
    partial class FrmDepartAccount
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
            this.label15 = new System.Windows.Forms.Label();
            this.dtpEtime = new System.Windows.Forms.DateTimePicker();
            this.dtpStime = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.cmbDepart = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbPatientType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDesign = new System.Windows.Forms.Button();
            this.rptPreviewCtrl = new FastReport.Preview.PreviewControl();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDepartType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(262, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 19);
            this.label15.TabIndex = 94;
            this.label15.Text = "至";
            // 
            // dtpEtime
            // 
            this.dtpEtime.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpEtime.Location = new System.Drawing.Point(300, 4);
            this.dtpEtime.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dtpEtime.Name = "dtpEtime";
            this.dtpEtime.Size = new System.Drawing.Size(186, 29);
            this.dtpEtime.TabIndex = 92;
            // 
            // dtpStime
            // 
            this.dtpStime.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpStime.Location = new System.Drawing.Point(66, 5);
            this.dtpStime.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dtpStime.Name = "dtpStime";
            this.dtpStime.Size = new System.Drawing.Size(186, 29);
            this.dtpStime.TabIndex = 91;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(6, 9);
            this.label18.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(60, 19);
            this.label18.TabIndex = 93;
            this.label18.Text = "时间:";
            // 
            // cmbDepart
            // 
            this.cmbDepart.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbDepart.FormattingEnabled = true;
            this.cmbDepart.ItemHeight = 19;
            this.cmbDepart.Location = new System.Drawing.Point(802, 6);
            this.cmbDepart.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cmbDepart.Name = "cmbDepart";
            this.cmbDepart.Size = new System.Drawing.Size(106, 27);
            this.cmbDepart.TabIndex = 95;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(721, 12);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 19);
            this.label11.TabIndex = 96;
            this.label11.Text = "科  室:";
            // 
            // cmbPatientType
            // 
            this.cmbPatientType.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbPatientType.FormattingEnabled = true;
            this.cmbPatientType.ItemHeight = 19;
            this.cmbPatientType.Location = new System.Drawing.Point(1014, 8);
            this.cmbPatientType.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cmbPatientType.Name = "cmbPatientType";
            this.cmbPatientType.Size = new System.Drawing.Size(112, 27);
            this.cmbPatientType.TabIndex = 97;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(918, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 19);
            this.label1.TabIndex = 98;
            this.label1.Text = "患者类型:";
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrint.Location = new System.Drawing.Point(1395, 4);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(93, 34);
            this.btnPrint.TabIndex = 102;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(1144, 4);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(93, 34);
            this.btnSearch.TabIndex = 101;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnDesign
            // 
            this.btnDesign.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDesign.Location = new System.Drawing.Point(1269, 4);
            this.btnDesign.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnDesign.Name = "btnDesign";
            this.btnDesign.Size = new System.Drawing.Size(93, 34);
            this.btnDesign.TabIndex = 104;
            this.btnDesign.Text = "设计";
            this.btnDesign.UseVisualStyleBackColor = true;
            this.btnDesign.Click += new System.EventHandler(this.btnDesign_Click);
            // 
            // rptPreviewCtrl
            // 
            this.rptPreviewCtrl.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.rptPreviewCtrl.Font = new System.Drawing.Font("宋体", 9F);
            this.rptPreviewCtrl.Location = new System.Drawing.Point(10, 47);
            this.rptPreviewCtrl.Name = "rptPreviewCtrl";
            this.rptPreviewCtrl.PageOffset = new System.Drawing.Point(10, 10);
            this.rptPreviewCtrl.Size = new System.Drawing.Size(1478, 696);
            this.rptPreviewCtrl.TabIndex = 105;
            this.rptPreviewCtrl.UIStyle = FastReport.Utils.UIStyle.Office2007Black;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(498, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 19);
            this.label2.TabIndex = 106;
            this.label2.Text = "科室类型:";
            // 
            // cmbDepartType
            // 
            this.cmbDepartType.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbDepartType.FormattingEnabled = true;
            this.cmbDepartType.ItemHeight = 19;
            this.cmbDepartType.Location = new System.Drawing.Point(597, 7);
            this.cmbDepartType.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cmbDepartType.Name = "cmbDepartType";
            this.cmbDepartType.Size = new System.Drawing.Size(112, 27);
            this.cmbDepartType.TabIndex = 107;
            // 
            // FrmDepartAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1498, 746);
            this.Controls.Add(this.cmbDepartType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rptPreviewCtrl);
            this.Controls.Add(this.btnDesign);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cmbPatientType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDepart);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dtpEtime);
            this.Controls.Add(this.dtpStime);
            this.Controls.Add(this.label18);
            this.Name = "FrmDepartAccount";
            this.Text = "科室核算";
            this.Load += new System.EventHandler(this.FrmDepartAccount_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtpEtime;
        private System.Windows.Forms.DateTimePicker dtpStime;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cmbDepart;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbPatientType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnDesign;
        private FastReport.Preview.PreviewControl rptPreviewCtrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDepartType;
    }
}