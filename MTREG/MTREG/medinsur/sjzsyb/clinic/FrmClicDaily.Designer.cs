namespace MTREG.medinsur.sjzsyb.clinic
{
    partial class FrmClicDaily
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
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbPayType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvRechargedet = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRechargedet)).BeginInit();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 11F);
            this.label15.Location = new System.Drawing.Point(345, 22);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 22);
            this.label15.TabIndex = 94;
            this.label15.Text = "至";
            // 
            // dtpEtime
            // 
            this.dtpEtime.CustomFormat = "yyyy-MM-dd";
            this.dtpEtime.Font = new System.Drawing.Font("宋体", 11F);
            this.dtpEtime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEtime.Location = new System.Drawing.Point(387, 15);
            this.dtpEtime.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.dtpEtime.Name = "dtpEtime";
            this.dtpEtime.Size = new System.Drawing.Size(180, 33);
            this.dtpEtime.TabIndex = 92;
            // 
            // dtpStime
            // 
            this.dtpStime.CustomFormat = "yyyy-MM-dd";
            this.dtpStime.Font = new System.Drawing.Font("宋体", 11F);
            this.dtpStime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStime.Location = new System.Drawing.Point(158, 15);
            this.dtpStime.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.dtpStime.Name = "dtpStime";
            this.dtpStime.Size = new System.Drawing.Size(174, 33);
            this.dtpStime.TabIndex = 91;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 11F);
            this.label18.Location = new System.Drawing.Point(35, 21);
            this.label18.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(109, 22);
            this.label18.TabIndex = 93;
            this.label18.Text = "查询时间:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 11F);
            this.label5.Location = new System.Drawing.Point(620, 23);
            this.label5.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 22);
            this.label5.TabIndex = 136;
            this.label5.Text = "收费员:";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("宋体", 11F);
            this.btnSearch.Location = new System.Drawing.Point(1126, 12);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(92, 38);
            this.btnSearch.TabIndex = 138;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbPayType
            // 
            this.cmbPayType.Font = new System.Drawing.Font("宋体", 12F);
            this.cmbPayType.FormattingEnabled = true;
            this.cmbPayType.Location = new System.Drawing.Point(973, 17);
            this.cmbPayType.Name = "cmbPayType";
            this.cmbPayType.Size = new System.Drawing.Size(128, 32);
            this.cmbPayType.TabIndex = 139;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(857, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 22);
            this.label1.TabIndex = 140;
            this.label1.Text = "支付类型:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(22, 59);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1234, 597);
            this.tabControl1.TabIndex = 141;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvRechargedet);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1226, 565);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "储值卡查询";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvRechargedet
            // 
            this.dgvRechargedet.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvRechargedet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRechargedet.Location = new System.Drawing.Point(0, 3);
            this.dgvRechargedet.Name = "dgvRechargedet";
            this.dgvRechargedet.RowHeadersVisible = false;
            this.dgvRechargedet.RowTemplate.Height = 30;
            this.dgvRechargedet.Size = new System.Drawing.Size(1223, 556);
            this.dgvRechargedet.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("宋体", 11F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(707, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 30);
            this.comboBox1.TabIndex = 142;
            // 
            // FrmClicDaily
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 668);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbPayType);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dtpEtime);
            this.Controls.Add(this.dtpStime);
            this.Controls.Add(this.label18);
            this.Name = "FrmClicDaily";
            this.Text = "FrmClicDaily";
            this.Load += new System.EventHandler(this.FrmClicDaily_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRechargedet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtpEtime;
        private System.Windows.Forms.DateTimePicker dtpStime;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbPayType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvRechargedet;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}