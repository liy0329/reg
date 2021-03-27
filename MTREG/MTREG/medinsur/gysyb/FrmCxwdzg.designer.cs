namespace MTREG.medinsur.gysyb.clinic
{
    partial class FrmCxwdzg
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
            this.label3 = new System.Windows.Forms.Label();
            this.tbxGrbh = new System.Windows.Forms.TextBox();
            this.tbxXmbm = new System.Windows.Forms.TextBox();
            this.tbxSfzh = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.personcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dodate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operatorname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(14, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "个人编号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(243, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "项目编码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(542, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "医生身份证号";
            // 
            // tbxGrbh
            // 
            this.tbxGrbh.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.tbxGrbh.Location = new System.Drawing.Point(96, 6);
            this.tbxGrbh.Name = "tbxGrbh";
            this.tbxGrbh.Size = new System.Drawing.Size(141, 26);
            this.tbxGrbh.TabIndex = 3;
            // 
            // tbxXmbm
            // 
            this.tbxXmbm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.tbxXmbm.Location = new System.Drawing.Point(326, 6);
            this.tbxXmbm.Name = "tbxXmbm";
            this.tbxXmbm.Size = new System.Drawing.Size(208, 26);
            this.tbxXmbm.TabIndex = 4;
            // 
            // tbxSfzh
            // 
            this.tbxSfzh.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.tbxSfzh.Location = new System.Drawing.Point(659, 6);
            this.tbxSfzh.Name = "tbxSfzh";
            this.tbxSfzh.Size = new System.Drawing.Size(186, 26);
            this.tbxSfzh.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(869, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            this.dodate,
            this.operatorname});
            this.dataGridView1.Location = new System.Drawing.Point(12, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(935, 414);
            this.dataGridView1.TabIndex = 7;
            // 
            // personcode
            // 
            this.personcode.DataPropertyName = "personcode";
            this.personcode.HeaderText = "个人编号";
            this.personcode.Name = "personcode";
            // 
            // itemcode
            // 
            this.itemcode.DataPropertyName = "itemcode";
            this.itemcode.HeaderText = "项目编码";
            this.itemcode.Name = "itemcode";
            // 
            // itemname
            // 
            this.itemname.DataPropertyName = "itemname";
            this.itemname.HeaderText = "项目名称";
            this.itemname.Name = "itemname";
            // 
            // drname
            // 
            this.drname.DataPropertyName = "drname";
            this.drname.HeaderText = "医生姓名";
            this.drname.Name = "drname";
            // 
            // drid
            // 
            this.drid.DataPropertyName = "drid";
            this.drid.HeaderText = "医生身份证号";
            this.drid.Name = "drid";
            // 
            // dodate
            // 
            this.dodate.DataPropertyName = "dodate";
            this.dodate.HeaderText = "登记时间";
            this.dodate.Name = "dodate";
            // 
            // operatorname
            // 
            this.operatorname.DataPropertyName = "operator";
            this.operatorname.HeaderText = "操作员";
            this.operatorname.Name = "operatorname";
            // 
            // FrmCxwdzg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 476);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbxSfzh);
            this.Controls.Add(this.tbxXmbm);
            this.Controls.Add(this.tbxGrbh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmCxwdzg";
            this.Text = "查询五定资格";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxGrbh;
        private System.Windows.Forms.TextBox tbxXmbm;
        private System.Windows.Forms.TextBox tbxSfzh;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn personcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemname;
        private System.Windows.Forms.DataGridViewTextBoxColumn drname;
        private System.Windows.Forms.DataGridViewTextBoxColumn drid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dodate;
        private System.Windows.Forms.DataGridViewTextBoxColumn operatorname;
    }
}