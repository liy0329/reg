namespace MTREG.clinic
{
    partial class FrmChangeInfo
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
            this.dtpBirthday = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbSex = new System.Windows.Forms.ComboBox();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxIDCard = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxMobile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.cmbAgeunit = new System.Windows.Forms.ComboBox();
            this.tbxMonAge = new System.Windows.Forms.TextBox();
            this.tbxAge = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbxProfession = new System.Windows.Forms.ListBox();
            this.tbxProfession = new System.Windows.Forms.TextBox();
            this.tbxProfesCode = new System.Windows.Forms.TextBox();
            this.lbxRace = new System.Windows.Forms.ListBox();
            this.tbxRace = new System.Windows.Forms.TextBox();
            this.tbxRaceCode = new System.Windows.Forms.TextBox();
            this.cmbProvince = new System.Windows.Forms.ComboBox();
            this.cmbCity = new System.Windows.Forms.ComboBox();
            this.cmbCounty = new System.Windows.Forms.ComboBox();
            this.txbsubAddress = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dtpBirthday
            // 
            this.dtpBirthday.Font = new System.Drawing.Font("宋体", 13F);
            this.dtpBirthday.Location = new System.Drawing.Point(93, 46);
            this.dtpBirthday.Name = "dtpBirthday";
            this.dtpBirthday.Size = new System.Drawing.Size(152, 27);
            this.dtpBirthday.TabIndex = 3;
            this.dtpBirthday.ValueChanged += new System.EventHandler(this.dtpBirthday_ValueChanged);
            this.dtpBirthday.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpBirthday_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 13F);
            this.label11.Location = new System.Drawing.Point(4, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 18);
            this.label11.TabIndex = 55;
            this.label11.Text = "出生年月:";
            // 
            // cmbSex
            // 
            this.cmbSex.Font = new System.Drawing.Font("宋体", 13F);
            this.cmbSex.FormattingEnabled = true;
            this.cmbSex.ItemHeight = 17;
            this.cmbSex.Items.AddRange(new object[] {
            "男",
            "女",
            "未"});
            this.cmbSex.Location = new System.Drawing.Point(305, 13);
            this.cmbSex.Name = "cmbSex";
            this.cmbSex.Size = new System.Drawing.Size(57, 25);
            this.cmbSex.TabIndex = 2;
            this.cmbSex.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSex_KeyDown);
            // 
            // tbxName
            // 
            this.tbxName.Font = new System.Drawing.Font("宋体", 13F);
            this.tbxName.Location = new System.Drawing.Point(93, 13);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(152, 27);
            this.tbxName.TabIndex = 1;
            this.tbxName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxName_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 13F);
            this.label10.ForeColor = System.Drawing.Color.Blue;
            this.label10.Location = new System.Drawing.Point(39, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 18);
            this.label10.TabIndex = 54;
            this.label10.Text = "年龄:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 13F);
            this.label9.Location = new System.Drawing.Point(253, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 18);
            this.label9.TabIndex = 53;
            this.label9.Text = "性别:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 13F);
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(40, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 18);
            this.label8.TabIndex = 52;
            this.label8.Text = "姓名:";
            // 
            // tbxIDCard
            // 
            this.tbxIDCard.Font = new System.Drawing.Font("宋体", 13F);
            this.tbxIDCard.Location = new System.Drawing.Point(94, 186);
            this.tbxIDCard.Name = "tbxIDCard";
            this.tbxIDCard.Size = new System.Drawing.Size(254, 27);
            this.tbxIDCard.TabIndex = 8;
            this.tbxIDCard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxIDCard_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 13F);
            this.label7.Location = new System.Drawing.Point(3, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 18);
            this.label7.TabIndex = 51;
            this.label7.Text = "身份证号:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 13F);
            this.label1.Location = new System.Drawing.Point(39, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 18);
            this.label1.TabIndex = 56;
            this.label1.Text = "电话:";
            // 
            // tbxMobile
            // 
            this.tbxMobile.Font = new System.Drawing.Font("宋体", 13F);
            this.tbxMobile.Location = new System.Drawing.Point(95, 147);
            this.tbxMobile.Name = "tbxMobile";
            this.tbxMobile.Size = new System.Drawing.Size(254, 27);
            this.tbxMobile.TabIndex = 7;
            this.tbxMobile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxMobile_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 13F);
            this.label2.Location = new System.Drawing.Point(39, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 18);
            this.label2.TabIndex = 56;
            this.label2.Text = "职业:";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("宋体", 13F);
            this.btnClose.Location = new System.Drawing.Point(237, 293);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 26);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnClose_KeyDown);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("宋体", 13F);
            this.btnSave.Location = new System.Drawing.Point(93, 292);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(69, 26);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 13F);
            this.label4.Location = new System.Drawing.Point(248, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 18);
            this.label4.TabIndex = 53;
            this.label4.Text = "民族:";
            // 
            // cmbMonth
            // 
            this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth.Font = new System.Drawing.Font("宋体", 13F);
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new System.Drawing.Point(242, 78);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(45, 25);
            this.cmbMonth.TabIndex = 60;
            this.cmbMonth.Visible = false;
            this.cmbMonth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMonth_KeyDown);
            // 
            // cmbAgeunit
            // 
            this.cmbAgeunit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAgeunit.Font = new System.Drawing.Font("宋体", 13F);
            this.cmbAgeunit.FormattingEnabled = true;
            this.cmbAgeunit.ItemHeight = 17;
            this.cmbAgeunit.Location = new System.Drawing.Point(140, 78);
            this.cmbAgeunit.Name = "cmbAgeunit";
            this.cmbAgeunit.Size = new System.Drawing.Size(49, 25);
            this.cmbAgeunit.TabIndex = 58;
            this.cmbAgeunit.SelectedIndexChanged += new System.EventHandler(this.cmbAgeunit_SelectedIndexChanged);
            this.cmbAgeunit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbAgeunit_KeyDown);
            // 
            // tbxMonAge
            // 
            this.tbxMonAge.Font = new System.Drawing.Font("宋体", 13F);
            this.tbxMonAge.Location = new System.Drawing.Point(195, 78);
            this.tbxMonAge.Name = "tbxMonAge";
            this.tbxMonAge.Size = new System.Drawing.Size(45, 27);
            this.tbxMonAge.TabIndex = 59;
            this.tbxMonAge.Visible = false;
            this.tbxMonAge.TextChanged += new System.EventHandler(this.tbxMonAge_TextChanged);
            this.tbxMonAge.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxMonAge_KeyDown);
            // 
            // tbxAge
            // 
            this.tbxAge.Font = new System.Drawing.Font("宋体", 13F);
            this.tbxAge.Location = new System.Drawing.Point(93, 78);
            this.tbxAge.Name = "tbxAge";
            this.tbxAge.Size = new System.Drawing.Size(41, 27);
            this.tbxAge.TabIndex = 4;
            this.tbxAge.TextChanged += new System.EventHandler(this.tbxAge_TextChanged);
            this.tbxAge.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxAge_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 13F);
            this.label5.Location = new System.Drawing.Point(39, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 18);
            this.label5.TabIndex = 65;
            this.label5.Text = "地址:";
            // 
            // lbxProfession
            // 
            this.lbxProfession.Font = new System.Drawing.Font("宋体", 13F);
            this.lbxProfession.FormattingEnabled = true;
            this.lbxProfession.ItemHeight = 17;
            this.lbxProfession.Location = new System.Drawing.Point(94, 138);
            this.lbxProfession.Name = "lbxProfession";
            this.lbxProfession.Size = new System.Drawing.Size(142, 72);
            this.lbxProfession.TabIndex = 152;
            this.lbxProfession.Visible = false;
            this.lbxProfession.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbxProfession_KeyDown);
            this.lbxProfession.Leave += new System.EventHandler(this.lbxProfession_Leave);
            this.lbxProfession.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbxProfession_MouseDoubleClick);
            this.lbxProfession.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbxProfession_MouseDown);
            // 
            // tbxProfession
            // 
            this.tbxProfession.Font = new System.Drawing.Font("宋体", 13F);
            this.tbxProfession.Location = new System.Drawing.Point(94, 111);
            this.tbxProfession.Name = "tbxProfession";
            this.tbxProfession.Size = new System.Drawing.Size(143, 27);
            this.tbxProfession.TabIndex = 150;
            this.tbxProfession.TextChanged += new System.EventHandler(this.tbxProfession_TextChanged);
            this.tbxProfession.Enter += new System.EventHandler(this.tbxProfession_Enter);
            this.tbxProfession.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxProfession_KeyDown);
            this.tbxProfession.Leave += new System.EventHandler(this.tbxProfession_Leave);
            // 
            // tbxProfesCode
            // 
            this.tbxProfesCode.Font = new System.Drawing.Font("宋体", 13F);
            this.tbxProfesCode.Location = new System.Drawing.Point(94, 111);
            this.tbxProfesCode.Name = "tbxProfesCode";
            this.tbxProfesCode.Size = new System.Drawing.Size(143, 27);
            this.tbxProfesCode.TabIndex = 151;
            // 
            // lbxRace
            // 
            this.lbxRace.Font = new System.Drawing.Font("宋体", 13F);
            this.lbxRace.FormattingEnabled = true;
            this.lbxRace.ItemHeight = 17;
            this.lbxRace.Location = new System.Drawing.Point(301, 135);
            this.lbxRace.Name = "lbxRace";
            this.lbxRace.Size = new System.Drawing.Size(89, 72);
            this.lbxRace.TabIndex = 155;
            this.lbxRace.Visible = false;
            this.lbxRace.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbxRace_KeyDown);
            this.lbxRace.Leave += new System.EventHandler(this.lbxRace_Leave);
            this.lbxRace.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbxRace_MouseDoubleClick);
            this.lbxRace.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbxRace_MouseDown);
            // 
            // tbxRace
            // 
            this.tbxRace.Font = new System.Drawing.Font("宋体", 13F);
            this.tbxRace.Location = new System.Drawing.Point(301, 108);
            this.tbxRace.Name = "tbxRace";
            this.tbxRace.Size = new System.Drawing.Size(88, 27);
            this.tbxRace.TabIndex = 153;
            this.tbxRace.TextChanged += new System.EventHandler(this.tbxRace_TextChanged);
            this.tbxRace.Enter += new System.EventHandler(this.tbxRace_Enter);
            this.tbxRace.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxRace_KeyDown);
            this.tbxRace.Leave += new System.EventHandler(this.tbxRace_Leave);
            // 
            // tbxRaceCode
            // 
            this.tbxRaceCode.Font = new System.Drawing.Font("宋体", 13F);
            this.tbxRaceCode.Location = new System.Drawing.Point(301, 108);
            this.tbxRaceCode.Name = "tbxRaceCode";
            this.tbxRaceCode.Size = new System.Drawing.Size(88, 27);
            this.tbxRaceCode.TabIndex = 154;
            // 
            // cmbProvince
            // 
            this.cmbProvince.DropDownHeight = 250;
            this.cmbProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvince.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbProvince.FormattingEnabled = true;
            this.cmbProvince.IntegralHeight = false;
            this.cmbProvince.Location = new System.Drawing.Point(93, 229);
            this.cmbProvince.MaxDropDownItems = 5;
            this.cmbProvince.Name = "cmbProvince";
            this.cmbProvince.Size = new System.Drawing.Size(87, 24);
            this.cmbProvince.TabIndex = 166;
            this.cmbProvince.SelectedValueChanged += new System.EventHandler(this.cmbProvince_SelectedValueChanged);
            this.cmbProvince.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbProvince_KeyDown);
            // 
            // cmbCity
            // 
            this.cmbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCity.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbCity.FormattingEnabled = true;
            this.cmbCity.Location = new System.Drawing.Point(186, 229);
            this.cmbCity.MaxDropDownItems = 5;
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.Size = new System.Drawing.Size(87, 24);
            this.cmbCity.TabIndex = 167;
            this.cmbCity.SelectedValueChanged += new System.EventHandler(this.cmbCity_SelectedValueChanged);
            this.cmbCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCity_KeyDown);
            // 
            // cmbCounty
            // 
            this.cmbCounty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCounty.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbCounty.FormattingEnabled = true;
            this.cmbCounty.Location = new System.Drawing.Point(279, 229);
            this.cmbCounty.MaxDropDownItems = 5;
            this.cmbCounty.Name = "cmbCounty";
            this.cmbCounty.Size = new System.Drawing.Size(87, 24);
            this.cmbCounty.TabIndex = 168;
            // 
            // txbsubAddress
            // 
            this.txbsubAddress.Font = new System.Drawing.Font("宋体", 13F);
            this.txbsubAddress.Location = new System.Drawing.Point(93, 259);
            this.txbsubAddress.Name = "txbsubAddress";
            this.txbsubAddress.Size = new System.Drawing.Size(273, 27);
            this.txbsubAddress.TabIndex = 169;
            // 
            // FrmChangeInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 331);
            this.Controls.Add(this.txbsubAddress);
            this.Controls.Add(this.cmbCounty);
            this.Controls.Add(this.cmbCity);
            this.Controls.Add(this.cmbProvince);
            this.Controls.Add(this.lbxProfession);
            this.Controls.Add(this.lbxRace);
            this.Controls.Add(this.tbxRace);
            this.Controls.Add(this.tbxRaceCode);
            this.Controls.Add(this.tbxProfession);
            this.Controls.Add(this.tbxProfesCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.cmbAgeunit);
            this.Controls.Add(this.tbxMonAge);
            this.Controls.Add(this.tbxAge);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpBirthday);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxMobile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbSex);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbxIDCard);
            this.Controls.Add(this.label7);
            this.Name = "FrmChangeInfo";
            this.Text = "信息修改";
            this.Load += new System.EventHandler(this.FrmChangeInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpBirthday;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbSex;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxIDCard;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxMobile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.ComboBox cmbAgeunit;
        private System.Windows.Forms.TextBox tbxMonAge;
        private System.Windows.Forms.TextBox tbxAge;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lbxProfession;
        private System.Windows.Forms.TextBox tbxProfession;
        private System.Windows.Forms.TextBox tbxProfesCode;
        private System.Windows.Forms.ListBox lbxRace;
        private System.Windows.Forms.TextBox tbxRace;
        private System.Windows.Forms.TextBox tbxRaceCode;
        private System.Windows.Forms.ComboBox cmbProvince;
        private System.Windows.Forms.ComboBox cmbCity;
        private System.Windows.Forms.ComboBox cmbCounty;
        private System.Windows.Forms.TextBox txbsubAddress;
    }
}