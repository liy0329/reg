namespace guizhousheng
{
    partial class Frm_JZK
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
            this.components = new System.ComponentModel.Container();
            this.tbx_xm = new System.Windows.Forms.TextBox();
            this.btn_cx = new System.Windows.Forms.Button();
            this.btn_tk = new System.Windows.Forms.Button();
            this.btn_bk = new System.Windows.Forms.Button();
            this.姓名 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.fullname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ssn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new guizhousheng.DataSet1();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxjzk = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbx_xm
            // 
            this.tbx_xm.Location = new System.Drawing.Point(70, 13);
            this.tbx_xm.Name = "tbx_xm";
            this.tbx_xm.Size = new System.Drawing.Size(84, 21);
            this.tbx_xm.TabIndex = 0;
            this.tbx_xm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbx_xm_KeyUp);
            // 
            // btn_cx
            // 
            this.btn_cx.Location = new System.Drawing.Point(315, 10);
            this.btn_cx.Name = "btn_cx";
            this.btn_cx.Size = new System.Drawing.Size(60, 23);
            this.btn_cx.TabIndex = 1;
            this.btn_cx.Text = "查询";
            this.btn_cx.UseVisualStyleBackColor = true;
            this.btn_cx.Click += new System.EventHandler(this.btn_cx_Click);
            // 
            // btn_tk
            // 
            this.btn_tk.Location = new System.Drawing.Point(393, 11);
            this.btn_tk.Name = "btn_tk";
            this.btn_tk.Size = new System.Drawing.Size(62, 22);
            this.btn_tk.TabIndex = 2;
            this.btn_tk.Text = "退卡";
            this.btn_tk.UseVisualStyleBackColor = true;
            this.btn_tk.Click += new System.EventHandler(this.btn_tk_Click);
            // 
            // btn_bk
            // 
            this.btn_bk.Location = new System.Drawing.Point(471, 10);
            this.btn_bk.Name = "btn_bk";
            this.btn_bk.Size = new System.Drawing.Size(58, 22);
            this.btn_bk.TabIndex = 3;
            this.btn_bk.Text = "补卡";
            this.btn_bk.UseVisualStyleBackColor = true;
            this.btn_bk.Click += new System.EventHandler(this.btn_bk_Click);
            // 
            // 姓名
            // 
            this.姓名.AutoSize = true;
            this.姓名.Location = new System.Drawing.Point(31, 17);
            this.姓名.Name = "姓名";
            this.姓名.Size = new System.Drawing.Size(35, 12);
            this.姓名.TabIndex = 4;
            this.姓名.Text = "姓名:";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fullname,
            this.xb,
            this.userid,
            this.address,
            this.createdat,
            this.ssn,
            this.iid});
            this.dgv.DataSource = this.dataSet1BindingSource;
            this.dgv.Location = new System.Drawing.Point(33, 61);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(522, 279);
            this.dgv.TabIndex = 5;
            // 
            // fullname
            // 
            this.fullname.DataPropertyName = "fullname";
            this.fullname.HeaderText = "姓名";
            this.fullname.Name = "fullname";
            // 
            // xb
            // 
            this.xb.DataPropertyName = "xb";
            this.xb.HeaderText = "性别";
            this.xb.Name = "xb";
            // 
            // userid
            // 
            this.userid.DataPropertyName = "userid";
            this.userid.HeaderText = "卡号";
            this.userid.Name = "userid";
            // 
            // address
            // 
            this.address.DataPropertyName = "address";
            this.address.HeaderText = "地址";
            this.address.Name = "address";
            // 
            // createdat
            // 
            this.createdat.DataPropertyName = "createdat";
            this.createdat.HeaderText = "创建时间";
            this.createdat.Name = "createdat";
            // 
            // ssn
            // 
            this.ssn.DataPropertyName = "ssn";
            this.ssn.HeaderText = "身份证号";
            this.ssn.Name = "ssn";
            // 
            // iid
            // 
            this.iid.DataPropertyName = "iid";
            this.iid.HeaderText = "iid";
            this.iid.Name = "iid";
            this.iid.Visible = false;
            // 
            // dataSet1BindingSource
            // 
            this.dataSet1BindingSource.DataSource = this.dataSet1;
            this.dataSet1BindingSource.Position = 0;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "卡号:";
            // 
            // tbxjzk
            // 
            this.tbxjzk.Location = new System.Drawing.Point(203, 13);
            this.tbxjzk.Name = "tbxjzk";
            this.tbxjzk.Size = new System.Drawing.Size(84, 21);
            this.tbxjzk.TabIndex = 6;
            this.tbxjzk.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbxjzk_KeyUp);
            // 
            // Frm_JZK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 369);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxjzk);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.姓名);
            this.Controls.Add(this.btn_bk);
            this.Controls.Add(this.btn_tk);
            this.Controls.Add(this.btn_cx);
            this.Controls.Add(this.tbx_xm);
            this.Name = "Frm_JZK";
            this.Text = "就诊卡管理";
            this.Load += new System.EventHandler(this.Frm_JZK_Load);
            this.Activated += new System.EventHandler(this.Frm_JZK_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbx_xm;
        private System.Windows.Forms.Button btn_cx;
        private System.Windows.Forms.Button btn_tk;
        private System.Windows.Forms.Button btn_bk;
        private System.Windows.Forms.Label 姓名;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.BindingSource dataSet1BindingSource;
        private DataSet1 dataSet1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxjzk;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullname;
        private System.Windows.Forms.DataGridViewTextBoxColumn xb;
        private System.Windows.Forms.DataGridViewTextBoxColumn userid;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ssn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iid;
    }
}