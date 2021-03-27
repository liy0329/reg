namespace MTREG.medinsur.gzsyb
{
    partial class Frm_ydjscxall
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
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.btn_cx = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.aac001 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yka065 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yka055 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yka056 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yka057 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yka111 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yka058 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yka248 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yka062 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yke030 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ykc177 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yab037 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yka316 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yka054 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yae366 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.akc021 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ykc121 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ykc280 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ykc281 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aae036 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.akc190 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aac003 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yka103 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ykb65 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aka130 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yab003 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_daochu = new System.Windows.Forms.Button();
            this.btnCx = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "开始日期:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "结束日期:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(100, 20);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(109, 21);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(292, 19);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(109, 21);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // btn_cx
            // 
            this.btn_cx.Location = new System.Drawing.Point(425, 20);
            this.btn_cx.Name = "btn_cx";
            this.btn_cx.Size = new System.Drawing.Size(75, 23);
            this.btn_cx.TabIndex = 4;
            this.btn_cx.Text = "查询";
            this.btn_cx.UseVisualStyleBackColor = true;
            this.btn_cx.Click += new System.EventHandler(this.btn_cx_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.aac001,
            this.yka065,
            this.yka055,
            this.yka056,
            this.yka057,
            this.yka111,
            this.yka058,
            this.yka248,
            this.yka062,
            this.yke030,
            this.ykc177,
            this.yab037,
            this.yka316,
            this.yka054,
            this.yae366,
            this.akc021,
            this.ykc121,
            this.ykc280,
            this.ykc281,
            this.aae036,
            this.akc190,
            this.aac003,
            this.yka103,
            this.ykb65,
            this.aka130,
            this.yab003});
            this.dataGridView1.Location = new System.Drawing.Point(37, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(733, 412);
            this.dataGridView1.TabIndex = 5;
            // 
            // aac001
            // 
            this.aac001.DataPropertyName = "aac001";
            this.aac001.HeaderText = "个人编号";
            this.aac001.Name = "aac001";
            this.aac001.ReadOnly = true;
            // 
            // yka065
            // 
            this.yka065.DataPropertyName = "yka065";
            this.yka065.HeaderText = "个人账户支付金额";
            this.yka065.Name = "yka065";
            this.yka065.ReadOnly = true;
            // 
            // yka055
            // 
            this.yka055.DataPropertyName = "yka055";
            this.yka055.HeaderText = "医疗费总额";
            this.yka055.Name = "yka055";
            this.yka055.ReadOnly = true;
            // 
            // yka056
            // 
            this.yka056.DataPropertyName = "yka056";
            this.yka056.HeaderText = "全自费金额";
            this.yka056.Name = "yka056";
            this.yka056.ReadOnly = true;
            // 
            // yka057
            // 
            this.yka057.DataPropertyName = "yka057";
            this.yka057.HeaderText = "挂钩自付金额";
            this.yka057.Name = "yka057";
            this.yka057.ReadOnly = true;
            // 
            // yka111
            // 
            this.yka111.DataPropertyName = "yka111";
            this.yka111.HeaderText = "符合范围金额";
            this.yka111.Name = "yka111";
            this.yka111.ReadOnly = true;
            // 
            // yka058
            // 
            this.yka058.DataPropertyName = "yka058";
            this.yka058.HeaderText = "进入起伏线金额";
            this.yka058.Name = "yka058";
            this.yka058.ReadOnly = true;
            // 
            // yka248
            // 
            this.yka248.DataPropertyName = "yka248";
            this.yka248.HeaderText = "基本医疗统筹支付金额";
            this.yka248.Name = "yka248";
            this.yka248.ReadOnly = true;
            // 
            // yka062
            // 
            this.yka062.DataPropertyName = "yka062";
            this.yka062.HeaderText = "大额医疗支付金额";
            this.yka062.Name = "yka062";
            this.yka062.ReadOnly = true;
            // 
            // yke030
            // 
            this.yke030.DataPropertyName = "yke030";
            this.yke030.HeaderText = "公务员补助报销金额";
            this.yke030.Name = "yke030";
            this.yke030.ReadOnly = true;
            // 
            // ykc177
            // 
            this.ykc177.DataPropertyName = "ykc177";
            this.ykc177.HeaderText = "个人账户支付后余额";
            this.ykc177.Name = "ykc177";
            this.ykc177.ReadOnly = true;
            // 
            // yab037
            // 
            this.yab037.DataPropertyName = "yab037";
            this.yab037.HeaderText = "清算分中心";
            this.yab037.Name = "yab037";
            this.yab037.ReadOnly = true;
            // 
            // yka316
            // 
            this.yka316.DataPropertyName = "yka316";
            this.yka316.HeaderText = "清算类别";
            this.yka316.Name = "yka316";
            this.yka316.ReadOnly = true;
            // 
            // yka054
            // 
            this.yka054.DataPropertyName = "yka054";
            this.yka054.HeaderText = "清算方式";
            this.yka054.Name = "yka054";
            this.yka054.ReadOnly = true;
            // 
            // yae366
            // 
            this.yae366.DataPropertyName = "yae366";
            this.yae366.HeaderText = "清算期号";
            this.yae366.Name = "yae366";
            this.yae366.ReadOnly = true;
            // 
            // akc021
            // 
            this.akc021.DataPropertyName = "akc021";
            this.akc021.HeaderText = "医疗人员类别";
            this.akc021.Name = "akc021";
            this.akc021.ReadOnly = true;
            // 
            // ykc121
            // 
            this.ykc121.DataPropertyName = "ykc121";
            this.ykc121.HeaderText = "就诊结算方式";
            this.ykc121.Name = "ykc121";
            this.ykc121.ReadOnly = true;
            // 
            // ykc280
            // 
            this.ykc280.DataPropertyName = "ykc280";
            this.ykc280.HeaderText = "居保人员类别";
            this.ykc280.Name = "ykc280";
            this.ykc280.ReadOnly = true;
            // 
            // ykc281
            // 
            this.ykc281.DataPropertyName = "ykc281";
            this.ykc281.HeaderText = "居保人员身份";
            this.ykc281.Name = "ykc281";
            this.ykc281.ReadOnly = true;
            // 
            // aae036
            // 
            this.aae036.DataPropertyName = "aae036";
            this.aae036.HeaderText = "经办时间";
            this.aae036.Name = "aae036";
            this.aae036.ReadOnly = true;
            // 
            // akc190
            // 
            this.akc190.DataPropertyName = "akc190";
            this.akc190.HeaderText = "门诊住院流水号";
            this.akc190.Name = "akc190";
            this.akc190.ReadOnly = true;
            // 
            // aac003
            // 
            this.aac003.DataPropertyName = "aac003";
            this.aac003.HeaderText = "姓名";
            this.aac003.Name = "aac003";
            this.aac003.ReadOnly = true;
            // 
            // yka103
            // 
            this.yka103.DataPropertyName = "yka103";
            this.yka103.HeaderText = "结算编号";
            this.yka103.Name = "yka103";
            this.yka103.ReadOnly = true;
            // 
            // ykb65
            // 
            this.ykb65.DataPropertyName = "ykb65";
            this.ykb65.HeaderText = "执行社会保险方法";
            this.ykb65.Name = "ykb65";
            this.ykb65.ReadOnly = true;
            // 
            // aka130
            // 
            this.aka130.DataPropertyName = "aka130";
            this.aka130.HeaderText = "支付类别";
            this.aka130.Name = "aka130";
            this.aka130.ReadOnly = true;
            // 
            // yab003
            // 
            this.yab003.DataPropertyName = "yab003";
            this.yab003.HeaderText = "行政区域";
            this.yab003.Name = "yab003";
            this.yab003.ReadOnly = true;
            // 
            // btn_daochu
            // 
            this.btn_daochu.Location = new System.Drawing.Point(526, 20);
            this.btn_daochu.Name = "btn_daochu";
            this.btn_daochu.Size = new System.Drawing.Size(75, 23);
            this.btn_daochu.TabIndex = 6;
            this.btn_daochu.Text = "导出Execl";
            this.btn_daochu.UseVisualStyleBackColor = true;
            this.btn_daochu.Click += new System.EventHandler(this.btn_daochu_Click);
            // 
            // btnCx
            // 
            this.btnCx.Location = new System.Drawing.Point(634, 19);
            this.btnCx.Name = "btnCx";
            this.btnCx.Size = new System.Drawing.Size(75, 23);
            this.btnCx.TabIndex = 7;
            this.btnCx.Text = "撤销";
            this.btnCx.UseVisualStyleBackColor = true;
            this.btnCx.Click += new System.EventHandler(this.btnCx_Click);
            // 
            // Frm_ydjscxall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 492);
            this.Controls.Add(this.btnCx);
            this.Controls.Add(this.btn_daochu);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_cx);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Frm_ydjscxall";
            this.Text = "省医保结算查询";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button btn_cx;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn aac001;
        private System.Windows.Forms.DataGridViewTextBoxColumn yka065;
        private System.Windows.Forms.DataGridViewTextBoxColumn yka055;
        private System.Windows.Forms.DataGridViewTextBoxColumn yka056;
        private System.Windows.Forms.DataGridViewTextBoxColumn yka057;
        private System.Windows.Forms.DataGridViewTextBoxColumn yka111;
        private System.Windows.Forms.DataGridViewTextBoxColumn yka058;
        private System.Windows.Forms.DataGridViewTextBoxColumn yka248;
        private System.Windows.Forms.DataGridViewTextBoxColumn yka062;
        private System.Windows.Forms.DataGridViewTextBoxColumn yke030;
        private System.Windows.Forms.DataGridViewTextBoxColumn ykc177;
        private System.Windows.Forms.DataGridViewTextBoxColumn yab037;
        private System.Windows.Forms.DataGridViewTextBoxColumn yka316;
        private System.Windows.Forms.DataGridViewTextBoxColumn yka054;
        private System.Windows.Forms.DataGridViewTextBoxColumn yae366;
        private System.Windows.Forms.DataGridViewTextBoxColumn akc021;
        private System.Windows.Forms.DataGridViewTextBoxColumn ykc121;
        private System.Windows.Forms.DataGridViewTextBoxColumn ykc280;
        private System.Windows.Forms.DataGridViewTextBoxColumn ykc281;
        private System.Windows.Forms.DataGridViewTextBoxColumn aae036;
        private System.Windows.Forms.DataGridViewTextBoxColumn akc190;
        private System.Windows.Forms.DataGridViewTextBoxColumn aac003;
        private System.Windows.Forms.DataGridViewTextBoxColumn yka103;
        private System.Windows.Forms.DataGridViewTextBoxColumn ykb65;
        private System.Windows.Forms.DataGridViewTextBoxColumn aka130;
        private System.Windows.Forms.DataGridViewTextBoxColumn yab003;
        private System.Windows.Forms.Button btn_daochu;
        private System.Windows.Forms.Button btnCx;
    }
}