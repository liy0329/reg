namespace MTREG.medinsur.gysyb.clinic
{
    partial class FrmWdzgcx
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
            this.tbxGrbh = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnQxrz = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.personcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operatorname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(29, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "个人编号";
            // 
            // tbxGrbh
            // 
            this.tbxGrbh.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.tbxGrbh.Location = new System.Drawing.Point(111, 5);
            this.tbxGrbh.Name = "tbxGrbh";
            this.tbxGrbh.Size = new System.Drawing.Size(222, 26);
            this.tbxGrbh.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Location = new System.Drawing.Point(434, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnQxrz
            // 
            this.btnQxrz.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btnQxrz.Location = new System.Drawing.Point(546, 8);
            this.btnQxrz.Name = "btnQxrz";
            this.btnQxrz.Size = new System.Drawing.Size(108, 23);
            this.btnQxrz.TabIndex = 3;
            this.btnQxrz.Text = "撤销认定";
            this.btnQxrz.UseVisualStyleBackColor = true;
            this.btnQxrz.Click += new System.EventHandler(this.btnQxrz_Click);
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
            this.dataGridView1.Location = new System.Drawing.Point(21, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(689, 363);
            this.dataGridView1.TabIndex = 4;
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
            // FrmWdzgcx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 419);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnQxrz);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbxGrbh);
            this.Controls.Add(this.label1);
            this.Name = "FrmWdzgcx";
            this.Text = "五定资格撤销";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxGrbh;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnQxrz;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn personcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemname;
        private System.Windows.Forms.DataGridViewTextBoxColumn drname;
        private System.Windows.Forms.DataGridViewTextBoxColumn drid;
        private System.Windows.Forms.DataGridViewTextBoxColumn operatorname;
    }
}