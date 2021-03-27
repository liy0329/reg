namespace MTREG.medinsur.sjzsyb
{
    partial class FrmYlFyMxDz
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmb_ywlb = new System.Windows.Forms.ComboBox();
            this.lab_kssj = new System.Windows.Forms.Label();
            this.lab_ywlb = new System.Windows.Forms.Label();
            this.lab_jssj = new System.Windows.Forms.Label();
            this.dt_jssj = new System.Windows.Forms.DateTimePicker();
            this.dt_kssj = new System.Windows.Forms.DateTimePicker();
            this.dgv_ybdzmx = new System.Windows.Forms.DataGridView();
            this.dgv_dzxx = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ybdzmx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dzxx)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cmb_ywlb);
            this.groupBox1.Controls.Add(this.lab_kssj);
            this.groupBox1.Controls.Add(this.lab_ywlb);
            this.groupBox1.Controls.Add(this.lab_jssj);
            this.groupBox1.Controls.Add(this.dt_jssj);
            this.groupBox1.Controls.Add(this.dt_kssj);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(1044, 81);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "医疗费信息对账";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(710, 47);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 22);
            this.button2.TabIndex = 101;
            this.button2.Text = "打印对账信息";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(710, 18);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 22);
            this.button1.TabIndex = 100;
            this.button1.Text = "与医保对账";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmb_ywlb
            // 
            this.cmb_ywlb.FormattingEnabled = true;
            this.cmb_ywlb.Location = new System.Drawing.Point(524, 25);
            this.cmb_ywlb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmb_ywlb.Name = "cmb_ywlb";
            this.cmb_ywlb.Size = new System.Drawing.Size(91, 20);
            this.cmb_ywlb.TabIndex = 99;
            this.cmb_ywlb.SelectedIndexChanged += new System.EventHandler(this.cbT_ywlb_SelectedIndexChanged);
            // 
            // lab_kssj
            // 
            this.lab_kssj.AutoSize = true;
            this.lab_kssj.Location = new System.Drawing.Point(18, 28);
            this.lab_kssj.Name = "lab_kssj";
            this.lab_kssj.Size = new System.Drawing.Size(65, 12);
            this.lab_kssj.TabIndex = 98;
            this.lab_kssj.Text = "开始时间：";
            // 
            // lab_ywlb
            // 
            this.lab_ywlb.AutoSize = true;
            this.lab_ywlb.Location = new System.Drawing.Point(459, 28);
            this.lab_ywlb.Name = "lab_ywlb";
            this.lab_ywlb.Size = new System.Drawing.Size(65, 12);
            this.lab_ywlb.TabIndex = 97;
            this.lab_ywlb.Text = "业务类别：";
            // 
            // lab_jssj
            // 
            this.lab_jssj.AutoSize = true;
            this.lab_jssj.Location = new System.Drawing.Point(238, 28);
            this.lab_jssj.Name = "lab_jssj";
            this.lab_jssj.Size = new System.Drawing.Size(65, 12);
            this.lab_jssj.TabIndex = 96;
            this.lab_jssj.Text = "结束时间：";
            // 
            // dt_jssj
            // 
            this.dt_jssj.Location = new System.Drawing.Point(306, 24);
            this.dt_jssj.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dt_jssj.Name = "dt_jssj";
            this.dt_jssj.Size = new System.Drawing.Size(128, 21);
            this.dt_jssj.TabIndex = 95;
            this.dt_jssj.ValueChanged += new System.EventHandler(this.dt_jssj_ValueChanged);
            // 
            // dt_kssj
            // 
            this.dt_kssj.Location = new System.Drawing.Point(89, 25);
            this.dt_kssj.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dt_kssj.Name = "dt_kssj";
            this.dt_kssj.Size = new System.Drawing.Size(128, 21);
            this.dt_kssj.TabIndex = 94;
            this.dt_kssj.ValueChanged += new System.EventHandler(this.dt_kssj_ValueChanged);
            // 
            // dgv_ybdzmx
            // 
            this.dgv_ybdzmx.AllowUserToAddRows = false;
            this.dgv_ybdzmx.AllowUserToDeleteRows = false;
            this.dgv_ybdzmx.AllowUserToResizeColumns = false;
            this.dgv_ybdzmx.AllowUserToResizeRows = false;
            this.dgv_ybdzmx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ybdzmx.Location = new System.Drawing.Point(8, 93);
            this.dgv_ybdzmx.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_ybdzmx.Name = "dgv_ybdzmx";
            this.dgv_ybdzmx.ReadOnly = true;
            this.dgv_ybdzmx.RowHeadersVisible = false;
            this.dgv_ybdzmx.RowTemplate.Height = 27;
            this.dgv_ybdzmx.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ybdzmx.Size = new System.Drawing.Size(520, 457);
            this.dgv_ybdzmx.TabIndex = 1;
            // 
            // dgv_dzxx
            // 
            this.dgv_dzxx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dzxx.Location = new System.Drawing.Point(533, 93);
            this.dgv_dzxx.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_dzxx.Name = "dgv_dzxx";
            this.dgv_dzxx.RowTemplate.Height = 27;
            this.dgv_dzxx.Size = new System.Drawing.Size(520, 457);
            this.dgv_dzxx.TabIndex = 1;
            // 
            // FrmYlFyMxDz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 551);
            this.Controls.Add(this.dgv_dzxx);
            this.Controls.Add(this.dgv_ybdzmx);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmYlFyMxDz";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "医保对账（明细）";
            this.Load += new System.EventHandler(this.FrmYlFyMxDz_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ybdzmx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dzxx)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmb_ywlb;
        private System.Windows.Forms.Label lab_kssj;
        private System.Windows.Forms.Label lab_ywlb;
        private System.Windows.Forms.Label lab_jssj;
        private System.Windows.Forms.DateTimePicker dt_jssj;
        private System.Windows.Forms.DateTimePicker dt_kssj;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgv_ybdzmx;
        private System.Windows.Forms.DataGridView dgv_dzxx;
    }
}