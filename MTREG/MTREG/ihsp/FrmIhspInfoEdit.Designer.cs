namespace MTREG.ihsp
{
    partial class FrmIhspInfoEdit
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
            this.cmbAgeunit = new System.Windows.Forms.ComboBox();
            this.cmbSex = new System.Windows.Forms.ComboBox();
            this.tbxAge = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxIDCard = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnReadIDCard = new System.Windows.Forms.Button();
            this.dtpBirthday = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblIhspcode = new System.Windows.Forms.Label();
            this.lblHspcard = new System.Windows.Forms.Label();
            this.tbxMonAge = new System.Windows.Forms.TextBox();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.cmbDepart = new System.Windows.Forms.ComboBox();
            this.cmbDoctor = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tbxIntroducer = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbAgeunit
            // 
            this.cmbAgeunit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAgeunit.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbAgeunit.FormattingEnabled = true;
            this.cmbAgeunit.ItemHeight = 15;
            this.cmbAgeunit.Location = new System.Drawing.Point(113, 159);
            this.cmbAgeunit.Name = "cmbAgeunit";
            this.cmbAgeunit.Size = new System.Drawing.Size(38, 23);
            this.cmbAgeunit.TabIndex = 7;
            this.cmbAgeunit.Tag = "7";
            this.cmbAgeunit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbAgeunit_KeyDown);
            // 
            // cmbSex
            // 
            this.cmbSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSex.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbSex.FormattingEnabled = true;
            this.cmbSex.ItemHeight = 15;
            this.cmbSex.Items.AddRange(new object[] {
            "男",
            "女",
            "未"});
            this.cmbSex.Location = new System.Drawing.Point(76, 113);
            this.cmbSex.Name = "cmbSex";
            this.cmbSex.Size = new System.Drawing.Size(58, 23);
            this.cmbSex.TabIndex = 4;
            this.cmbSex.Tag = "4";
            // 
            // tbxAge
            // 
            this.tbxAge.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxAge.Location = new System.Drawing.Point(76, 159);
            this.tbxAge.Name = "tbxAge";
            this.tbxAge.Size = new System.Drawing.Size(35, 24);
            this.tbxAge.TabIndex = 6;
            this.tbxAge.Tag = "6";
            this.tbxAge.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxAge_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 11F);
            this.label10.ForeColor = System.Drawing.Color.Blue;
            this.label10.Location = new System.Drawing.Point(35, 163);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 15);
            this.label10.TabIndex = 51;
            this.label10.Text = "年龄:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 11F);
            this.label9.Location = new System.Drawing.Point(36, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 15);
            this.label9.TabIndex = 50;
            this.label9.Text = "性别:";
            // 
            // tbxName
            // 
            this.tbxName.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxName.Location = new System.Drawing.Point(76, 66);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(100, 24);
            this.tbxName.TabIndex = 1;
            this.tbxName.Tag = "1";
            this.tbxName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxName_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 11F);
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(37, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 15);
            this.label8.TabIndex = 58;
            this.label8.Text = "姓名:";
            // 
            // tbxIDCard
            // 
            this.tbxIDCard.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxIDCard.Location = new System.Drawing.Point(350, 66);
            this.tbxIDCard.Name = "tbxIDCard";
            this.tbxIDCard.Size = new System.Drawing.Size(158, 24);
            this.tbxIDCard.TabIndex = 3;
            this.tbxIDCard.Tag = "3";
            this.tbxIDCard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxIDCard_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 11F);
            this.label7.Location = new System.Drawing.Point(280, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 15);
            this.label7.TabIndex = 57;
            this.label7.Text = "身份证号:";
            // 
            // btnReadIDCard
            // 
            this.btnReadIDCard.Font = new System.Drawing.Font("宋体", 11F);
            this.btnReadIDCard.Location = new System.Drawing.Point(182, 66);
            this.btnReadIDCard.Name = "btnReadIDCard";
            this.btnReadIDCard.Size = new System.Drawing.Size(64, 22);
            this.btnReadIDCard.TabIndex = 2;
            this.btnReadIDCard.Tag = "2";
            this.btnReadIDCard.Text = "身份证";
            this.btnReadIDCard.UseVisualStyleBackColor = true;
            this.btnReadIDCard.Visible = false;
            this.btnReadIDCard.Click += new System.EventHandler(this.btnReadIDCard_Click);
            this.btnReadIDCard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnReadIDCard_KeyDown);
            // 
            // dtpBirthday
            // 
            this.dtpBirthday.Font = new System.Drawing.Font("宋体", 11F);
            this.dtpBirthday.Location = new System.Drawing.Point(350, 159);
            this.dtpBirthday.Name = "dtpBirthday";
            this.dtpBirthday.Size = new System.Drawing.Size(158, 24);
            this.dtpBirthday.TabIndex = 10;
            this.dtpBirthday.Tag = "10";
            this.dtpBirthday.ValueChanged += new System.EventHandler(this.dtpBirthday_ValueChanged);
            this.dtpBirthday.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpBirthday_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 11F);
            this.label11.Location = new System.Drawing.Point(279, 163);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 15);
            this.label11.TabIndex = 62;
            this.label11.Text = "出生年月:";
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("宋体", 11F);
            this.btnOk.Location = new System.Drawing.Point(330, 297);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(69, 26);
            this.btnOk.TabIndex = 14;
            this.btnOk.Tag = "13";
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            this.btnOk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnOk_KeyDown);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("宋体", 11F);
            this.btnCancel.Location = new System.Drawing.Point(405, 297);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 26);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Tag = "14";
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnCancel_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(59, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 58;
            this.label1.Text = "住院号:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F);
            this.label2.Location = new System.Drawing.Point(264, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 58;
            this.label2.Text = "卡号:";
            // 
            // lblIhspcode
            // 
            this.lblIhspcode.AutoSize = true;
            this.lblIhspcode.Font = new System.Drawing.Font("宋体", 11F);
            this.lblIhspcode.Location = new System.Drawing.Point(116, 19);
            this.lblIhspcode.Name = "lblIhspcode";
            this.lblIhspcode.Size = new System.Drawing.Size(67, 15);
            this.lblIhspcode.TabIndex = 58;
            this.lblIhspcode.Text = "××××";
            // 
            // lblHspcard
            // 
            this.lblHspcard.AutoSize = true;
            this.lblHspcard.Font = new System.Drawing.Font("宋体", 11F);
            this.lblHspcard.Location = new System.Drawing.Point(305, 19);
            this.lblHspcard.Name = "lblHspcard";
            this.lblHspcard.Size = new System.Drawing.Size(67, 15);
            this.lblHspcard.TabIndex = 58;
            this.lblHspcard.Text = "××××";
            // 
            // tbxMonAge
            // 
            this.tbxMonAge.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxMonAge.Location = new System.Drawing.Point(158, 159);
            this.tbxMonAge.Name = "tbxMonAge";
            this.tbxMonAge.Size = new System.Drawing.Size(35, 24);
            this.tbxMonAge.TabIndex = 8;
            this.tbxMonAge.Tag = "8";
            this.tbxMonAge.Visible = false;
            this.tbxMonAge.TextChanged += new System.EventHandler(this.tbxMonAge_TextChanged);
            this.tbxMonAge.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxMonAge_KeyDown);
            // 
            // cmbMonth
            // 
            this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth.Font = new System.Drawing.Font("宋体", 11F);
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbMonth.ItemHeight = 15;
            this.cmbMonth.Location = new System.Drawing.Point(195, 159);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(38, 23);
            this.cmbMonth.TabIndex = 9;
            this.cmbMonth.Tag = "9";
            this.cmbMonth.Visible = false;
            // 
            // cmbDepart
            // 
            this.cmbDepart.Font = new System.Drawing.Font("宋体", 13F);
            this.cmbDepart.FormattingEnabled = true;
            this.cmbDepart.ItemHeight = 17;
            this.cmbDepart.Location = new System.Drawing.Point(91, 211);
            this.cmbDepart.Name = "cmbDepart";
            this.cmbDepart.Size = new System.Drawing.Size(213, 25);
            this.cmbDepart.TabIndex = 63;
            this.cmbDepart.SelectedValueChanged += new System.EventHandler(this.cmbDepart_SelectedValueChanged);
            // 
            // cmbDoctor
            // 
            this.cmbDoctor.Font = new System.Drawing.Font("宋体", 13F);
            this.cmbDoctor.FormattingEnabled = true;
            this.cmbDoctor.ItemHeight = 17;
            this.cmbDoctor.Location = new System.Drawing.Point(385, 211);
            this.cmbDoctor.Name = "cmbDoctor";
            this.cmbDoctor.Size = new System.Drawing.Size(123, 25);
            this.cmbDoctor.TabIndex = 64;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 13F);
            this.label14.Location = new System.Drawing.Point(327, 214);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 18);
            this.label14.TabIndex = 66;
            this.label14.Text = "医生:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 13F);
            this.label19.ForeColor = System.Drawing.Color.Blue;
            this.label19.Location = new System.Drawing.Point(37, 214);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 18);
            this.label19.TabIndex = 65;
            this.label19.Text = "科室:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 8F);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(93, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(225, 11);
            this.label3.TabIndex = 67;
            this.label3.Text = "已经成功入科接受的患者无法更改科室医生！";
            this.label3.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(41, 297);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(60, 16);
            this.checkBox1.TabIndex = 68;
            this.checkBox1.Text = "新生儿";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // tbxIntroducer
            // 
            this.tbxIntroducer.Font = new System.Drawing.Font("宋体", 13F);
            this.tbxIntroducer.Location = new System.Drawing.Point(350, 111);
            this.tbxIntroducer.Name = "tbxIntroducer";
            this.tbxIntroducer.Size = new System.Drawing.Size(94, 27);
            this.tbxIntroducer.TabIndex = 69;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 11F);
            this.label21.Location = new System.Drawing.Point(279, 115);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(60, 15);
            this.label21.TabIndex = 70;
            this.label21.Text = "介绍人:";
            // 
            // FrmIhspInfoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 339);
            this.Controls.Add(this.tbxIntroducer);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbDepart);
            this.Controls.Add(this.cmbDoctor);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dtpBirthday);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblHspcard);
            this.Controls.Add(this.lblIhspcode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbxIDCard);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnReadIDCard);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.cmbAgeunit);
            this.Controls.Add(this.tbxMonAge);
            this.Controls.Add(this.cmbSex);
            this.Controls.Add(this.tbxAge);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Name = "FrmIhspInfoEdit";
            this.Text = "住院登记信息修改";
            this.Load += new System.EventHandler(this.FrmIhspInfoEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbAgeunit;
        private System.Windows.Forms.ComboBox cmbSex;
        private System.Windows.Forms.TextBox tbxAge;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxIDCard;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnReadIDCard;
        private System.Windows.Forms.DateTimePicker dtpBirthday;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblIhspcode;
        private System.Windows.Forms.Label lblHspcard;
        private System.Windows.Forms.TextBox tbxMonAge;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.ComboBox cmbDepart;
        private System.Windows.Forms.ComboBox cmbDoctor;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.TextBox tbxIntroducer;
        private System.Windows.Forms.Label label21;
    }
}