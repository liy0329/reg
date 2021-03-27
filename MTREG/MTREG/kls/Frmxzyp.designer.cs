namespace MTREG.medinsur.gzsyb.nh
{
    partial class Frmxzyp
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
            this.panelxzyp = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_xzyp = new System.Windows.Forms.Label();
            this.dtv_xzyp = new System.Windows.Forms.DataGridView();
            this.iid_ypzl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insureid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_ypzl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.everymoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ratio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adminlevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isclinic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projecttype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark_ypzl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputpycode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updatetime_ypzl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputwbcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approvemaxprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approveminprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approvemaxpricecity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approvemaxpricecounty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approvemaxpricetown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_xzyp = new System.Windows.Forms.Button();
            this.dtpGZSlasttime = new System.Windows.Forms.DateTimePicker();
            this.dtpGYSlasttime = new System.Windows.Forms.DateTimePicker();
            this.panelxzyp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtv_xzyp)).BeginInit();
            this.SuspendLayout();
            // 
            // panelxzyp
            // 
            this.panelxzyp.Controls.Add(this.dtpGYSlasttime);
            this.panelxzyp.Controls.Add(this.dtpGZSlasttime);
            this.panelxzyp.Controls.Add(this.button1);
            this.panelxzyp.Controls.Add(this.label4);
            this.panelxzyp.Controls.Add(this.label3);
            this.panelxzyp.Controls.Add(this.label2);
            this.panelxzyp.Controls.Add(this.lbl_xzyp);
            this.panelxzyp.Controls.Add(this.dtv_xzyp);
            this.panelxzyp.Controls.Add(this.btn_xzyp);
            this.panelxzyp.Location = new System.Drawing.Point(2, 1);
            this.panelxzyp.Name = "panelxzyp";
            this.panelxzyp.Size = new System.Drawing.Size(743, 515);
            this.panelxzyp.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(60, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 33);
            this.button1.TabIndex = 6;
            this.button1.Text = "贵阳市农合";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(310, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(251, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "核准最低价格:缺省为 0，表示不限制最低价格";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(310, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "次报销定额: 0 表示规则不起作用";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(310, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(359, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "用药级别:0：村级,1:一级医院,2:二级医院,3:三级医院,9：不限制";
            // 
            // lbl_xzyp
            // 
            this.lbl_xzyp.AutoSize = true;
            this.lbl_xzyp.Location = new System.Drawing.Point(618, 568);
            this.lbl_xzyp.Name = "lbl_xzyp";
            this.lbl_xzyp.Size = new System.Drawing.Size(41, 12);
            this.lbl_xzyp.TabIndex = 2;
            this.lbl_xzyp.Text = "      ";
            // 
            // dtv_xzyp
            // 
            this.dtv_xzyp.AllowUserToAddRows = false;
            this.dtv_xzyp.AllowUserToDeleteRows = false;
            this.dtv_xzyp.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtv_xzyp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtv_xzyp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iid_ypzl,
            this.insureid,
            this.classno,
            this.grade,
            this.name_ypzl,
            this.spec,
            this.conf,
            this.unit,
            this.price,
            this.everymoney,
            this.ratio,
            this.adminlevel,
            this.isclinic,
            this.projecttype,
            this.remark_ypzl,
            this.inputpycode,
            this.updatetime_ypzl,
            this.inputwbcode,
            this.approvemaxprice,
            this.approveminprice,
            this.approvemaxpricecity,
            this.approvemaxpricecounty,
            this.approvemaxpricetown});
            this.dtv_xzyp.Location = new System.Drawing.Point(60, 107);
            this.dtv_xzyp.Name = "dtv_xzyp";
            this.dtv_xzyp.ReadOnly = true;
            this.dtv_xzyp.RowHeadersVisible = false;
            this.dtv_xzyp.RowTemplate.Height = 23;
            this.dtv_xzyp.Size = new System.Drawing.Size(663, 371);
            this.dtv_xzyp.TabIndex = 1;
            // 
            // iid_ypzl
            // 
            this.iid_ypzl.DataPropertyName = "iid";
            this.iid_ypzl.HeaderText = "项目序号";
            this.iid_ypzl.Name = "iid_ypzl";
            this.iid_ypzl.ReadOnly = true;
            // 
            // insureid
            // 
            this.insureid.DataPropertyName = "insureid";
            this.insureid.HeaderText = "项目编码";
            this.insureid.Name = "insureid";
            this.insureid.ReadOnly = true;
            // 
            // classno
            // 
            this.classno.DataPropertyName = "classno";
            this.classno.HeaderText = "项目类别";
            this.classno.Name = "classno";
            this.classno.ReadOnly = true;
            // 
            // grade
            // 
            this.grade.DataPropertyName = "grade";
            this.grade.HeaderText = "用药级别";
            this.grade.Name = "grade";
            this.grade.ReadOnly = true;
            // 
            // name_ypzl
            // 
            this.name_ypzl.DataPropertyName = "name";
            this.name_ypzl.HeaderText = "中文名称";
            this.name_ypzl.Name = "name_ypzl";
            this.name_ypzl.ReadOnly = true;
            // 
            // spec
            // 
            this.spec.DataPropertyName = "spec";
            this.spec.HeaderText = "规格";
            this.spec.Name = "spec";
            this.spec.ReadOnly = true;
            // 
            // conf
            // 
            this.conf.DataPropertyName = "conf";
            this.conf.HeaderText = "剂型";
            this.conf.Name = "conf";
            this.conf.ReadOnly = true;
            // 
            // unit
            // 
            this.unit.DataPropertyName = "unit";
            this.unit.HeaderText = "单位";
            this.unit.Name = "unit";
            this.unit.ReadOnly = true;
            // 
            // price
            // 
            this.price.DataPropertyName = "price";
            this.price.HeaderText = "基准价格";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // everymoney
            // 
            this.everymoney.DataPropertyName = "everymoney";
            this.everymoney.HeaderText = "次报销定额";
            this.everymoney.Name = "everymoney";
            this.everymoney.ReadOnly = true;
            // 
            // ratio
            // 
            this.ratio.DataPropertyName = "ratio";
            this.ratio.HeaderText = "保 内 比 例";
            this.ratio.Name = "ratio";
            this.ratio.ReadOnly = true;
            // 
            // adminlevel
            // 
            this.adminlevel.DataPropertyName = "adminlevel";
            this.adminlevel.HeaderText = "最低行政级别";
            this.adminlevel.Name = "adminlevel";
            this.adminlevel.ReadOnly = true;
            // 
            // isclinic
            // 
            this.isclinic.DataPropertyName = "isclinic";
            this.isclinic.HeaderText = "是否正常启用";
            this.isclinic.Name = "isclinic";
            this.isclinic.ReadOnly = true;
            // 
            // projecttype
            // 
            this.projecttype.DataPropertyName = "projecttype";
            this.projecttype.HeaderText = "项目属性";
            this.projecttype.Name = "projecttype";
            this.projecttype.ReadOnly = true;
            // 
            // remark_ypzl
            // 
            this.remark_ypzl.DataPropertyName = "remark";
            this.remark_ypzl.HeaderText = "备注说明";
            this.remark_ypzl.Name = "remark_ypzl";
            this.remark_ypzl.ReadOnly = true;
            // 
            // inputpycode
            // 
            this.inputpycode.DataPropertyName = "inputpycode";
            this.inputpycode.HeaderText = "拼音码";
            this.inputpycode.Name = "inputpycode";
            this.inputpycode.ReadOnly = true;
            // 
            // updatetime_ypzl
            // 
            this.updatetime_ypzl.DataPropertyName = "updatetime";
            this.updatetime_ypzl.HeaderText = "更新时间";
            this.updatetime_ypzl.Name = "updatetime_ypzl";
            this.updatetime_ypzl.ReadOnly = true;
            // 
            // inputwbcode
            // 
            this.inputwbcode.DataPropertyName = "inputwbcode";
            this.inputwbcode.HeaderText = "五笔码";
            this.inputwbcode.Name = "inputwbcode";
            this.inputwbcode.ReadOnly = true;
            // 
            // approvemaxprice
            // 
            this.approvemaxprice.DataPropertyName = "approvemaxprice";
            this.approvemaxprice.HeaderText = "核准最高价格_省级";
            this.approvemaxprice.Name = "approvemaxprice";
            this.approvemaxprice.ReadOnly = true;
            // 
            // approveminprice
            // 
            this.approveminprice.DataPropertyName = "approveminprice";
            this.approveminprice.HeaderText = "核准最低价格";
            this.approveminprice.Name = "approveminprice";
            this.approveminprice.ReadOnly = true;
            // 
            // approvemaxpricecity
            // 
            this.approvemaxpricecity.DataPropertyName = "approvemaxpricecity";
            this.approvemaxpricecity.HeaderText = "核准最高价格_市级";
            this.approvemaxpricecity.Name = "approvemaxpricecity";
            this.approvemaxpricecity.ReadOnly = true;
            // 
            // approvemaxpricecounty
            // 
            this.approvemaxpricecounty.DataPropertyName = "approvemaxpricecounty";
            this.approvemaxpricecounty.HeaderText = "核准最高价格_县级";
            this.approvemaxpricecounty.Name = "approvemaxpricecounty";
            this.approvemaxpricecounty.ReadOnly = true;
            // 
            // approvemaxpricetown
            // 
            this.approvemaxpricetown.DataPropertyName = "approvemaxpricetown";
            this.approvemaxpricetown.HeaderText = "核准最高价格_镇级";
            this.approvemaxpricetown.Name = "approvemaxpricetown";
            this.approvemaxpricetown.ReadOnly = true;
            // 
            // btn_xzyp
            // 
            this.btn_xzyp.Location = new System.Drawing.Point(60, 46);
            this.btn_xzyp.Name = "btn_xzyp";
            this.btn_xzyp.Size = new System.Drawing.Size(75, 33);
            this.btn_xzyp.TabIndex = 0;
            this.btn_xzyp.Text = "省农合";
            this.btn_xzyp.UseVisualStyleBackColor = true;
            this.btn_xzyp.Click += new System.EventHandler(this.btn_xzyp_Click_1);
            // 
            // dtpGZSlasttime
            // 
            this.dtpGZSlasttime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpGZSlasttime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpGZSlasttime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpGZSlasttime.Location = new System.Drawing.Point(135, 48);
            this.dtpGZSlasttime.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dtpGZSlasttime.Name = "dtpGZSlasttime";
            this.dtpGZSlasttime.Size = new System.Drawing.Size(171, 26);
            this.dtpGZSlasttime.TabIndex = 69;
            this.dtpGZSlasttime.Value = new System.DateTime(2017, 6, 23, 0, 0, 0, 0);
            // 
            // dtpGYSlasttime
            // 
            this.dtpGYSlasttime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpGYSlasttime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpGYSlasttime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpGYSlasttime.Location = new System.Drawing.Point(135, 76);
            this.dtpGYSlasttime.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dtpGYSlasttime.Name = "dtpGYSlasttime";
            this.dtpGYSlasttime.Size = new System.Drawing.Size(171, 26);
            this.dtpGYSlasttime.TabIndex = 70;
            this.dtpGYSlasttime.Value = new System.DateTime(2017, 6, 23, 0, 0, 0, 0);
            // 
            // Frmxzyp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 544);
            this.Controls.Add(this.panelxzyp);
            this.Name = "Frmxzyp";
            this.Text = "Frmxzyp";
            this.panelxzyp.ResumeLayout(false);
            this.panelxzyp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtv_xzyp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelxzyp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_xzyp;
        private System.Windows.Forms.DataGridView dtv_xzyp;
        private System.Windows.Forms.DataGridViewTextBoxColumn iid_ypzl;
        private System.Windows.Forms.DataGridViewTextBoxColumn insureid;
        private System.Windows.Forms.DataGridViewTextBoxColumn classno;
        private System.Windows.Forms.DataGridViewTextBoxColumn grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_ypzl;
        private System.Windows.Forms.DataGridViewTextBoxColumn spec;
        private System.Windows.Forms.DataGridViewTextBoxColumn conf;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn everymoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn ratio;
        private System.Windows.Forms.DataGridViewTextBoxColumn adminlevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn isclinic;
        private System.Windows.Forms.DataGridViewTextBoxColumn projecttype;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark_ypzl;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputpycode;
        private System.Windows.Forms.DataGridViewTextBoxColumn updatetime_ypzl;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputwbcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn approvemaxprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn approveminprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn approvemaxpricecity;
        private System.Windows.Forms.DataGridViewTextBoxColumn approvemaxpricecounty;
        private System.Windows.Forms.DataGridViewTextBoxColumn approvemaxpricetown;
        private System.Windows.Forms.Button btn_xzyp;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtpGYSlasttime;
        private System.Windows.Forms.DateTimePicker dtpGZSlasttime;
    }
}