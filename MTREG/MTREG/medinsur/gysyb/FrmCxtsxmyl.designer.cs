namespace MTREG.medinsur.gysyb.clinic
{
    partial class FrmCxtsxmyl
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
            this.tbxNd = new System.Windows.Forms.TextBox();
            this.tbxGrbh = new System.Windows.Forms.TextBox();
            this.btnCxrdyp = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.personcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operatorname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxZhsysj = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxLjyl = new System.Windows.Forms.TextBox();
            this.tbxZhjsyy = new System.Windows.Forms.TextBox();
            this.tbxDnsyl = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.tbxZflb = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(31, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "年度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(307, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "个人编号";
            // 
            // tbxNd
            // 
            this.tbxNd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.tbxNd.Location = new System.Drawing.Point(89, 4);
            this.tbxNd.Name = "tbxNd";
            this.tbxNd.Size = new System.Drawing.Size(100, 26);
            this.tbxNd.TabIndex = 2;
            // 
            // tbxGrbh
            // 
            this.tbxGrbh.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.tbxGrbh.Location = new System.Drawing.Point(398, 2);
            this.tbxGrbh.Name = "tbxGrbh";
            this.tbxGrbh.Size = new System.Drawing.Size(169, 26);
            this.tbxGrbh.TabIndex = 3;
            // 
            // btnCxrdyp
            // 
            this.btnCxrdyp.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btnCxrdyp.Location = new System.Drawing.Point(606, 2);
            this.btnCxrdyp.Name = "btnCxrdyp";
            this.btnCxrdyp.Size = new System.Drawing.Size(127, 31);
            this.btnCxrdyp.TabIndex = 4;
            this.btnCxrdyp.Text = "查询认定药品";
            this.btnCxrdyp.UseVisualStyleBackColor = true;
            this.btnCxrdyp.Click += new System.EventHandler(this.btnCxrdyp_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.personcode,
            this.itemcode,
            this.itemname,
            this.drname,
            this.drid,
            this.operatorname});
            this.dataGridView1.Location = new System.Drawing.Point(12, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(721, 294);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // personcode
            // 
            this.personcode.DataPropertyName = "personcode";
            this.personcode.HeaderText = "个人编号";
            this.personcode.Name = "personcode";
            this.personcode.ReadOnly = true;
            // 
            // itemcode
            // 
            this.itemcode.DataPropertyName = "itemcode";
            this.itemcode.HeaderText = "项目编码";
            this.itemcode.Name = "itemcode";
            this.itemcode.ReadOnly = true;
            // 
            // itemname
            // 
            this.itemname.DataPropertyName = "itemname";
            this.itemname.HeaderText = "项目名称";
            this.itemname.Name = "itemname";
            this.itemname.ReadOnly = true;
            // 
            // drname
            // 
            this.drname.DataPropertyName = "drname";
            this.drname.HeaderText = "医生姓名";
            this.drname.Name = "drname";
            this.drname.ReadOnly = true;
            // 
            // drid
            // 
            this.drid.DataPropertyName = "drid";
            this.drid.HeaderText = "医生身份证号";
            this.drid.Name = "drid";
            this.drid.ReadOnly = true;
            // 
            // operatorname
            // 
            this.operatorname.DataPropertyName = "operatorname";
            this.operatorname.HeaderText = "操作员";
            this.operatorname.Name = "operatorname";
            this.operatorname.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(10, 345);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "本次就诊前当年累计用量";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(46, 376);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "最后一次结算医院";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(12, 410);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(195, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "最后一次结算当中使用量";
            // 
            // tbxZhsysj
            // 
            this.tbxZhsysj.AutoSize = true;
            this.tbxZhsysj.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.tbxZhsysj.Location = new System.Drawing.Point(48, 443);
            this.tbxZhsysj.Name = "tbxZhsysj";
            this.tbxZhsysj.Size = new System.Drawing.Size(144, 16);
            this.tbxZhsysj.TabIndex = 9;
            this.tbxZhsysj.Text = "最后一次使用时间";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(10, 475);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(195, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "最后一次使用的支付类别";
            // 
            // tbxLjyl
            // 
            this.tbxLjyl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.tbxLjyl.Location = new System.Drawing.Point(211, 342);
            this.tbxLjyl.Name = "tbxLjyl";
            this.tbxLjyl.Size = new System.Drawing.Size(271, 26);
            this.tbxLjyl.TabIndex = 11;
            // 
            // tbxZhjsyy
            // 
            this.tbxZhjsyy.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.tbxZhjsyy.Location = new System.Drawing.Point(211, 373);
            this.tbxZhjsyy.Name = "tbxZhjsyy";
            this.tbxZhjsyy.Size = new System.Drawing.Size(271, 26);
            this.tbxZhjsyy.TabIndex = 12;
            // 
            // tbxDnsyl
            // 
            this.tbxDnsyl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.tbxDnsyl.Location = new System.Drawing.Point(211, 406);
            this.tbxDnsyl.Name = "tbxDnsyl";
            this.tbxDnsyl.Size = new System.Drawing.Size(271, 26);
            this.tbxDnsyl.TabIndex = 13;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.textBox4.Location = new System.Drawing.Point(211, 439);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(271, 26);
            this.textBox4.TabIndex = 14;
            // 
            // tbxZflb
            // 
            this.tbxZflb.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.tbxZflb.Location = new System.Drawing.Point(211, 472);
            this.tbxZflb.Name = "tbxZflb";
            this.tbxZflb.Size = new System.Drawing.Size(271, 26);
            this.tbxZflb.TabIndex = 15;
            // 
            // FrmCxtsxmyl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 508);
            this.Controls.Add(this.tbxZflb);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.tbxDnsyl);
            this.Controls.Add(this.tbxZhjsyy);
            this.Controls.Add(this.tbxLjyl);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbxZhsysj);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnCxrdyp);
            this.Controls.Add(this.tbxGrbh);
            this.Controls.Add(this.tbxNd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmCxtsxmyl";
            this.Text = "查询特殊项目用量";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxNd;
        private System.Windows.Forms.TextBox tbxGrbh;
        private System.Windows.Forms.Button btnCxrdyp;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn personcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemname;
        private System.Windows.Forms.DataGridViewTextBoxColumn drname;
        private System.Windows.Forms.DataGridViewTextBoxColumn drid;
        private System.Windows.Forms.DataGridViewTextBoxColumn operatorname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label tbxZhsysj;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxLjyl;
        private System.Windows.Forms.TextBox tbxZhjsyy;
        private System.Windows.Forms.TextBox tbxDnsyl;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox tbxZflb;
    }
}