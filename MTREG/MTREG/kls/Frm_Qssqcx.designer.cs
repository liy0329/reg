namespace MTREG.medinsur.gzsyb
{
    partial class Frm_Qssqcx
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
            this.btn_search = new System.Windows.Forms.Button();
            this.btn_hzdy = new System.Windows.Forms.Button();
            this.btn_mxdy = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.akb020 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ykb053 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yka316 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ykb037 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aae030 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aae031 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ykb009 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yka441 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yka055 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yka065 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yka248 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yka062 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yka063 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yka108 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ykc179 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yke150 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ykb065 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ykb065_bm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aka130 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aka130_bm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yka054_bm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yka054 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ykb037_bm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yae366 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yka316_bm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbxqsqh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "清算期号：";
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(216, 25);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 4;
            this.btn_search.Text = "查询";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btn_hzdy
            // 
            this.btn_hzdy.Location = new System.Drawing.Point(305, 25);
            this.btn_hzdy.Name = "btn_hzdy";
            this.btn_hzdy.Size = new System.Drawing.Size(75, 23);
            this.btn_hzdy.TabIndex = 5;
            this.btn_hzdy.Text = "汇总打印";
            this.btn_hzdy.UseVisualStyleBackColor = true;
            this.btn_hzdy.Click += new System.EventHandler(this.btn_hzdy_Click);
            // 
            // btn_mxdy
            // 
            this.btn_mxdy.Location = new System.Drawing.Point(391, 25);
            this.btn_mxdy.Name = "btn_mxdy";
            this.btn_mxdy.Size = new System.Drawing.Size(75, 23);
            this.btn_mxdy.TabIndex = 6;
            this.btn_mxdy.Text = "明细打印";
            this.btn_mxdy.UseVisualStyleBackColor = true;
            this.btn_mxdy.Click += new System.EventHandler(this.btn_mxdy_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.akb020,
            this.ykb053,
            this.yka316,
            this.ykb037,
            this.aae030,
            this.aae031,
            this.ykb009,
            this.yka441,
            this.yka055,
            this.yka065,
            this.yka248,
            this.yka062,
            this.yka063,
            this.yka108,
            this.ykc179,
            this.yke150,
            this.ykb065,
            this.ykb065_bm,
            this.aka130,
            this.aka130_bm,
            this.yka054_bm,
            this.yka054,
            this.ykb037_bm,
            this.yae366,
            this.yka316_bm});
            this.dataGridView1.Location = new System.Drawing.Point(21, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(751, 357);
            this.dataGridView1.TabIndex = 7;
            // 
            // akb020
            // 
            this.akb020.DataPropertyName = "akb020";
            this.akb020.HeaderText = "服务机构编号";
            this.akb020.Name = "akb020";
            this.akb020.ReadOnly = true;
            // 
            // ykb053
            // 
            this.ykb053.DataPropertyName = "ykb053";
            this.ykb053.HeaderText = "清算申请流水号";
            this.ykb053.Name = "ykb053";
            this.ykb053.ReadOnly = true;
            // 
            // yka316
            // 
            this.yka316.DataPropertyName = "yka316";
            this.yka316.HeaderText = "清算类别";
            this.yka316.Name = "yka316";
            this.yka316.ReadOnly = true;
            // 
            // ykb037
            // 
            this.ykb037.DataPropertyName = "ykb037";
            this.ykb037.HeaderText = "清算分中心";
            this.ykb037.Name = "ykb037";
            this.ykb037.ReadOnly = true;
            // 
            // aae030
            // 
            this.aae030.DataPropertyName = "aae030";
            this.aae030.HeaderText = "开始日期";
            this.aae030.Name = "aae030";
            this.aae030.ReadOnly = true;
            // 
            // aae031
            // 
            this.aae031.DataPropertyName = "aae031";
            this.aae031.HeaderText = "结束日期";
            this.aae031.Name = "aae031";
            this.aae031.ReadOnly = true;
            // 
            // ykb009
            // 
            this.ykb009.DataPropertyName = "ykb009";
            this.ykb009.HeaderText = "人次";
            this.ykb009.Name = "ykb009";
            this.ykb009.ReadOnly = true;
            // 
            // yka441
            // 
            this.yka441.DataPropertyName = "yka441";
            this.yka441.HeaderText = "就诊人数";
            this.yka441.Name = "yka441";
            this.yka441.ReadOnly = true;
            // 
            // yka055
            // 
            this.yka055.DataPropertyName = "yka055";
            this.yka055.HeaderText = "医疗费总额";
            this.yka055.Name = "yka055";
            this.yka055.ReadOnly = true;
            // 
            // yka065
            // 
            this.yka065.DataPropertyName = "yka065";
            this.yka065.HeaderText = "个人账户支付金额";
            this.yka065.Name = "yka065";
            this.yka065.ReadOnly = true;
            // 
            // yka248
            // 
            this.yka248.DataPropertyName = "yka248";
            this.yka248.HeaderText = "统筹支付金额";
            this.yka248.Name = "yka248";
            this.yka248.ReadOnly = true;
            // 
            // yka062
            // 
            this.yka062.DataPropertyName = "yka062";
            this.yka062.HeaderText = "大额统筹支付金额";
            this.yka062.Name = "yka062";
            this.yka062.ReadOnly = true;
            // 
            // yka063
            // 
            this.yka063.DataPropertyName = "yka063";
            this.yka063.HeaderText = "公务员统筹支付金额";
            this.yka063.Name = "yka063";
            this.yka063.ReadOnly = true;
            // 
            // yka108
            // 
            this.yka108.DataPropertyName = "yka108";
            this.yka108.HeaderText = "清算状态";
            this.yka108.Name = "yka108";
            this.yka108.ReadOnly = true;
            // 
            // ykc179
            // 
            this.ykc179.DataPropertyName = "ykc179";
            this.ykc179.HeaderText = "清算申请人姓名";
            this.ykc179.Name = "ykc179";
            this.ykc179.ReadOnly = true;
            // 
            // yke150
            // 
            this.yke150.DataPropertyName = "yke150";
            this.yke150.HeaderText = "清算申请人时间";
            this.yke150.Name = "yke150";
            this.yke150.ReadOnly = true;
            // 
            // ykb065
            // 
            this.ykb065.DataPropertyName = "ykb065";
            this.ykb065.HeaderText = "社会保险方法";
            this.ykb065.Name = "ykb065";
            // 
            // ykb065_bm
            // 
            this.ykb065_bm.DataPropertyName = "ykb065_bm";
            this.ykb065_bm.HeaderText = "社会保险方法编码";
            this.ykb065_bm.Name = "ykb065_bm";
            // 
            // aka130
            // 
            this.aka130.DataPropertyName = "aka130";
            this.aka130.HeaderText = "支付类别名称";
            this.aka130.Name = "aka130";
            // 
            // aka130_bm
            // 
            this.aka130_bm.DataPropertyName = "aka130_bm";
            this.aka130_bm.HeaderText = "支付类别编码";
            this.aka130_bm.Name = "aka130_bm";
            // 
            // yka054_bm
            // 
            this.yka054_bm.DataPropertyName = "yka054_bm";
            this.yka054_bm.HeaderText = "清算方式编码";
            this.yka054_bm.Name = "yka054_bm";
            this.yka054_bm.ReadOnly = true;
            // 
            // yka054
            // 
            this.yka054.DataPropertyName = "yka054";
            this.yka054.HeaderText = "清算方式名称";
            this.yka054.Name = "yka054";
            this.yka054.ReadOnly = true;
            // 
            // ykb037_bm
            // 
            this.ykb037_bm.DataPropertyName = "ykb037_bm";
            this.ykb037_bm.HeaderText = "清算分中心编码";
            this.ykb037_bm.Name = "ykb037_bm";
            // 
            // yae366
            // 
            this.yae366.DataPropertyName = "yae366";
            this.yae366.HeaderText = "清算期号";
            this.yae366.Name = "yae366";
            // 
            // yka316_bm
            // 
            this.yka316_bm.DataPropertyName = "yka316_bm";
            this.yka316_bm.HeaderText = "清算类别编码";
            this.yka316_bm.Name = "yka316_bm";
            // 
            // tbxqsqh
            // 
            this.tbxqsqh.Location = new System.Drawing.Point(119, 24);
            this.tbxqsqh.Name = "tbxqsqh";
            this.tbxqsqh.Size = new System.Drawing.Size(75, 21);
            this.tbxqsqh.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 421);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(293, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "注：支付类别 11 普通门诊 18 特殊门诊 31 普通住院";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(484, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "清算撤销";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Frm_Qssqcx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 464);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxqsqh);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_mxdy);
            this.Controls.Add(this.btn_hzdy);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.label1);
            this.Name = "Frm_Qssqcx";
            this.Text = "Frm_Qssqcx";
            this.Load += new System.EventHandler(this.Frm_Qssqcx_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_hzdy;
        private System.Windows.Forms.Button btn_mxdy;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox tbxqsqh;
        private System.Windows.Forms.DataGridViewTextBoxColumn akb020;
        private System.Windows.Forms.DataGridViewTextBoxColumn ykb053;
        private System.Windows.Forms.DataGridViewTextBoxColumn yka316;
        private System.Windows.Forms.DataGridViewTextBoxColumn ykb037;
        private System.Windows.Forms.DataGridViewTextBoxColumn aae030;
        private System.Windows.Forms.DataGridViewTextBoxColumn aae031;
        private System.Windows.Forms.DataGridViewTextBoxColumn ykb009;
        private System.Windows.Forms.DataGridViewTextBoxColumn yka441;
        private System.Windows.Forms.DataGridViewTextBoxColumn yka055;
        private System.Windows.Forms.DataGridViewTextBoxColumn yka065;
        private System.Windows.Forms.DataGridViewTextBoxColumn yka248;
        private System.Windows.Forms.DataGridViewTextBoxColumn yka062;
        private System.Windows.Forms.DataGridViewTextBoxColumn yka063;
        private System.Windows.Forms.DataGridViewTextBoxColumn yka108;
        private System.Windows.Forms.DataGridViewTextBoxColumn ykc179;
        private System.Windows.Forms.DataGridViewTextBoxColumn yke150;
        private System.Windows.Forms.DataGridViewTextBoxColumn ykb065;
        private System.Windows.Forms.DataGridViewTextBoxColumn ykb065_bm;
        private System.Windows.Forms.DataGridViewTextBoxColumn aka130;
        private System.Windows.Forms.DataGridViewTextBoxColumn aka130_bm;
        private System.Windows.Forms.DataGridViewTextBoxColumn yka054_bm;
        private System.Windows.Forms.DataGridViewTextBoxColumn yka054;
        private System.Windows.Forms.DataGridViewTextBoxColumn ykb037_bm;
        private System.Windows.Forms.DataGridViewTextBoxColumn yae366;
        private System.Windows.Forms.DataGridViewTextBoxColumn yka316_bm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}