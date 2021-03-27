namespace MTREG.medinsur.ahsjk
{
    partial class FrmTruncode
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
            this.cmb_InOrOut = new System.Windows.Forms.ComboBox();
            this.rdo_Back = new System.Windows.Forms.RadioButton();
            this.btn_Search = new System.Windows.Forms.Button();
            this.txt_TurnCode = new System.Windows.Forms.TextBox();
            this.rdo_Modify = new System.Windows.Forms.RadioButton();
            this.rdo_Upload = new System.Windows.Forms.RadioButton();
            this.label28 = new System.Windows.Forms.Label();
            this.btn_Upload = new System.Windows.Forms.Button();
            this.txt_Remark = new System.Windows.Forms.TextBox();
            this.dtp_TurnDate = new System.Windows.Forms.DateTimePicker();
            this.dtp_LvDtOfLstTime = new System.Windows.Forms.DateTimePicker();
            this.dtp_SBirthday = new System.Windows.Forms.DateTimePicker();
            this.cmb_TurnType = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.cmb_SSex = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_ToHspTechLvl = new System.Windows.Forms.ComboBox();
            this.cmb_ToHspLvl = new System.Windows.Forms.ComboBox();
            this.cmb_SType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_BookNo = new System.Windows.Forms.TextBox();
            this.txt_UserPass = new System.Windows.Forms.TextBox();
            this.txt_Telphone = new System.Windows.Forms.TextBox();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.txt_IcdNameOfLstTime = new System.Windows.Forms.TextBox();
            this.txt_DctrName = new System.Windows.Forms.TextBox();
            this.txt_OutOfficeOfLstTime = new System.Windows.Forms.TextBox();
            this.txt_IcdCodeOfLstTime = new System.Windows.Forms.TextBox();
            this.txt_ToHspCode = new System.Windows.Forms.TextBox();
            this.txt_FromHspCode = new System.Windows.Forms.TextBox();
            this.txt_Memberno = new System.Windows.Forms.TextBox();
            this.txt_IdCardno = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_IcdName = new System.Windows.Forms.TextBox();
            this.txt_IcdCode = new System.Windows.Forms.TextBox();
            this.txt_ToHspName = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txt_FromHspName = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txt_UserCode = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmb_InOrOut
            // 
            this.cmb_InOrOut.FormattingEnabled = true;
            this.cmb_InOrOut.Items.AddRange(new object[] {
            "本院转出病人",
            "转入本院病人"});
            this.cmb_InOrOut.Location = new System.Drawing.Point(234, 15);
            this.cmb_InOrOut.Name = "cmb_InOrOut";
            this.cmb_InOrOut.Size = new System.Drawing.Size(100, 20);
            this.cmb_InOrOut.TabIndex = 78;
            // 
            // rdo_Back
            // 
            this.rdo_Back.AutoSize = true;
            this.rdo_Back.Location = new System.Drawing.Point(340, 365);
            this.rdo_Back.Name = "rdo_Back";
            this.rdo_Back.Size = new System.Drawing.Size(47, 16);
            this.rdo_Back.TabIndex = 77;
            this.rdo_Back.TabStop = true;
            this.rdo_Back.Text = "撤销";
            this.rdo_Back.UseVisualStyleBackColor = true;
            this.rdo_Back.CheckedChanged += new System.EventHandler(this.rdo_Back_CheckedChanged);
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(340, 13);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(52, 23);
            this.btn_Search.TabIndex = 76;
            this.btn_Search.Text = "获取";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // txt_TurnCode
            // 
            this.txt_TurnCode.Enabled = false;
            this.txt_TurnCode.Location = new System.Drawing.Point(84, 15);
            this.txt_TurnCode.Name = "txt_TurnCode";
            this.txt_TurnCode.Size = new System.Drawing.Size(144, 21);
            this.txt_TurnCode.TabIndex = 75;
            this.txt_TurnCode.Click += new System.EventHandler(this.txt_TurnCode_Click);
            // 
            // rdo_Modify
            // 
            this.rdo_Modify.AutoSize = true;
            this.rdo_Modify.Location = new System.Drawing.Point(282, 365);
            this.rdo_Modify.Name = "rdo_Modify";
            this.rdo_Modify.Size = new System.Drawing.Size(47, 16);
            this.rdo_Modify.TabIndex = 73;
            this.rdo_Modify.TabStop = true;
            this.rdo_Modify.Text = "修改";
            this.rdo_Modify.UseVisualStyleBackColor = true;
            this.rdo_Modify.CheckedChanged += new System.EventHandler(this.rdo_Modify_CheckedChanged);
            // 
            // rdo_Upload
            // 
            this.rdo_Upload.AutoSize = true;
            this.rdo_Upload.Location = new System.Drawing.Point(221, 365);
            this.rdo_Upload.Name = "rdo_Upload";
            this.rdo_Upload.Size = new System.Drawing.Size(47, 16);
            this.rdo_Upload.TabIndex = 74;
            this.rdo_Upload.TabStop = true;
            this.rdo_Upload.Text = "上传";
            this.rdo_Upload.UseVisualStyleBackColor = true;
            this.rdo_Upload.CheckedChanged += new System.EventHandler(this.rdo_Upload_CheckedChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label28.Location = new System.Drawing.Point(15, 17);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(63, 14);
            this.label28.TabIndex = 72;
            this.label28.Text = "转诊单号";
            // 
            // btn_Upload
            // 
            this.btn_Upload.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Upload.Location = new System.Drawing.Point(393, 360);
            this.btn_Upload.Name = "btn_Upload";
            this.btn_Upload.Size = new System.Drawing.Size(75, 28);
            this.btn_Upload.TabIndex = 71;
            this.btn_Upload.Text = "上传";
            this.btn_Upload.UseVisualStyleBackColor = true;
            this.btn_Upload.Click += new System.EventHandler(this.btn_Upload_Click);
            // 
            // txt_Remark
            // 
            this.txt_Remark.Location = new System.Drawing.Point(88, 268);
            this.txt_Remark.Multiline = true;
            this.txt_Remark.Name = "txt_Remark";
            this.txt_Remark.Size = new System.Drawing.Size(651, 74);
            this.txt_Remark.TabIndex = 70;
            // 
            // dtp_TurnDate
            // 
            this.dtp_TurnDate.Location = new System.Drawing.Point(633, 133);
            this.dtp_TurnDate.Name = "dtp_TurnDate";
            this.dtp_TurnDate.Size = new System.Drawing.Size(106, 21);
            this.dtp_TurnDate.TabIndex = 67;
            // 
            // dtp_LvDtOfLstTime
            // 
            this.dtp_LvDtOfLstTime.Location = new System.Drawing.Point(110, 240);
            this.dtp_LvDtOfLstTime.Name = "dtp_LvDtOfLstTime";
            this.dtp_LvDtOfLstTime.Size = new System.Drawing.Size(104, 21);
            this.dtp_LvDtOfLstTime.TabIndex = 68;
            // 
            // dtp_SBirthday
            // 
            this.dtp_SBirthday.Location = new System.Drawing.Point(282, 107);
            this.dtp_SBirthday.Name = "dtp_SBirthday";
            this.dtp_SBirthday.Size = new System.Drawing.Size(109, 21);
            this.dtp_SBirthday.TabIndex = 69;
            // 
            // cmb_TurnType
            // 
            this.cmb_TurnType.FormattingEnabled = true;
            this.cmb_TurnType.Items.AddRange(new object[] {
            "上转",
            "下转",
            "平行转院"});
            this.cmb_TurnType.Location = new System.Drawing.Point(87, 133);
            this.cmb_TurnType.Name = "cmb_TurnType";
            this.cmb_TurnType.Size = new System.Drawing.Size(108, 20);
            this.cmb_TurnType.TabIndex = 65;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(476, 243);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(101, 12);
            this.label26.TabIndex = 56;
            this.label26.Text = "本次住院责任医生";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(224, 244);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(101, 12);
            this.label23.TabIndex = 57;
            this.label23.Text = "本次住院出院科室";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(576, 137);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 58;
            this.label15.Text = "转诊日期";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(8, 244);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(101, 12);
            this.label22.TabIndex = 53;
            this.label22.Text = "本次住院出院日期";
            // 
            // cmb_SSex
            // 
            this.cmb_SSex.FormattingEnabled = true;
            this.cmb_SSex.Items.AddRange(new object[] {
            "男",
            "女",
            "未知"});
            this.cmb_SSex.Location = new System.Drawing.Point(87, 107);
            this.cmb_SSex.Name = "cmb_SSex";
            this.cmb_SSex.Size = new System.Drawing.Size(108, 20);
            this.cmb_SSex.TabIndex = 66;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(225, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 54;
            this.label9.Text = "出生日期";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(29, 271);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(53, 12);
            this.label27.TabIndex = 55;
            this.label27.Text = "转诊说明";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(29, 137);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 64;
            this.label12.Text = "转诊类型";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(224, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 63;
            this.label6.Text = "身份证号";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 62;
            this.label8.Text = "性    别";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(8, 189);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(77, 12);
            this.label19.TabIndex = 59;
            this.label19.Text = "转入医院代码";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 162);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 12);
            this.label16.TabIndex = 60;
            this.label16.Text = "转出医院代码";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 61;
            this.label5.Text = "成员编码";
            // 
            // cmb_ToHspTechLvl
            // 
            this.cmb_ToHspTechLvl.FormattingEnabled = true;
            this.cmb_ToHspTechLvl.Items.AddRange(new object[] {
            "三级",
            "二级",
            "一级"});
            this.cmb_ToHspTechLvl.Location = new System.Drawing.Point(537, 185);
            this.cmb_ToHspTechLvl.Name = "cmb_ToHspTechLvl";
            this.cmb_ToHspTechLvl.Size = new System.Drawing.Size(202, 20);
            this.cmb_ToHspTechLvl.TabIndex = 50;
            // 
            // cmb_ToHspLvl
            // 
            this.cmb_ToHspLvl.FormattingEnabled = true;
            this.cmb_ToHspLvl.Items.AddRange(new object[] {
            "省级",
            "市级",
            "县级",
            "乡镇级",
            "省外"});
            this.cmb_ToHspLvl.Location = new System.Drawing.Point(537, 159);
            this.cmb_ToHspLvl.Name = "cmb_ToHspLvl";
            this.cmb_ToHspLvl.Size = new System.Drawing.Size(202, 20);
            this.cmb_ToHspLvl.TabIndex = 51;
            // 
            // cmb_SType
            // 
            this.cmb_SType.FormattingEnabled = true;
            this.cmb_SType.Items.AddRange(new object[] {
            "上传转诊单",
            "修改转诊单"});
            this.cmb_SType.Location = new System.Drawing.Point(633, 52);
            this.cmb_SType.Name = "cmb_SType";
            this.cmb_SType.Size = new System.Drawing.Size(106, 20);
            this.cmb_SType.TabIndex = 52;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(575, 109);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 49;
            this.label11.Text = "联系电话";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(575, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 48;
            this.label7.Text = "姓    名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(575, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 47;
            this.label4.Text = "操作类型";
            // 
            // txt_BookNo
            // 
            this.txt_BookNo.Location = new System.Drawing.Point(463, 108);
            this.txt_BookNo.Name = "txt_BookNo";
            this.txt_BookNo.Size = new System.Drawing.Size(100, 21);
            this.txt_BookNo.TabIndex = 35;
            // 
            // txt_UserPass
            // 
            this.txt_UserPass.Location = new System.Drawing.Point(463, 51);
            this.txt_UserPass.Name = "txt_UserPass";
            this.txt_UserPass.Size = new System.Drawing.Size(100, 21);
            this.txt_UserPass.TabIndex = 34;
            // 
            // txt_Telphone
            // 
            this.txt_Telphone.Location = new System.Drawing.Point(633, 106);
            this.txt_Telphone.Name = "txt_Telphone";
            this.txt_Telphone.Size = new System.Drawing.Size(106, 21);
            this.txt_Telphone.TabIndex = 37;
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(633, 79);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(106, 21);
            this.txt_Name.TabIndex = 36;
            // 
            // txt_IcdNameOfLstTime
            // 
            this.txt_IcdNameOfLstTime.Location = new System.Drawing.Point(501, 213);
            this.txt_IcdNameOfLstTime.Name = "txt_IcdNameOfLstTime";
            this.txt_IcdNameOfLstTime.Size = new System.Drawing.Size(238, 21);
            this.txt_IcdNameOfLstTime.TabIndex = 33;
            // 
            // txt_DctrName
            // 
            this.txt_DctrName.Location = new System.Drawing.Point(578, 240);
            this.txt_DctrName.Name = "txt_DctrName";
            this.txt_DctrName.Size = new System.Drawing.Size(161, 21);
            this.txt_DctrName.TabIndex = 31;
            // 
            // txt_OutOfficeOfLstTime
            // 
            this.txt_OutOfficeOfLstTime.Location = new System.Drawing.Point(326, 241);
            this.txt_OutOfficeOfLstTime.Name = "txt_OutOfficeOfLstTime";
            this.txt_OutOfficeOfLstTime.Size = new System.Drawing.Size(142, 21);
            this.txt_OutOfficeOfLstTime.TabIndex = 32;
            // 
            // txt_IcdCodeOfLstTime
            // 
            this.txt_IcdCodeOfLstTime.Location = new System.Drawing.Point(131, 213);
            this.txt_IcdCodeOfLstTime.Name = "txt_IcdCodeOfLstTime";
            this.txt_IcdCodeOfLstTime.Size = new System.Drawing.Size(239, 21);
            this.txt_IcdCodeOfLstTime.TabIndex = 30;
            // 
            // txt_ToHspCode
            // 
            this.txt_ToHspCode.Location = new System.Drawing.Point(88, 186);
            this.txt_ToHspCode.Name = "txt_ToHspCode";
            this.txt_ToHspCode.Size = new System.Drawing.Size(108, 21);
            this.txt_ToHspCode.TabIndex = 38;
            // 
            // txt_FromHspCode
            // 
            this.txt_FromHspCode.Location = new System.Drawing.Point(87, 159);
            this.txt_FromHspCode.Name = "txt_FromHspCode";
            this.txt_FromHspCode.Size = new System.Drawing.Size(108, 21);
            this.txt_FromHspCode.TabIndex = 44;
            // 
            // txt_Memberno
            // 
            this.txt_Memberno.Location = new System.Drawing.Point(87, 79);
            this.txt_Memberno.Name = "txt_Memberno";
            this.txt_Memberno.Size = new System.Drawing.Size(108, 21);
            this.txt_Memberno.TabIndex = 43;
            // 
            // txt_IdCardno
            // 
            this.txt_IdCardno.Location = new System.Drawing.Point(281, 79);
            this.txt_IdCardno.Name = "txt_IdCardno";
            this.txt_IdCardno.Size = new System.Drawing.Size(282, 21);
            this.txt_IdCardno.TabIndex = 46;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(406, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 19;
            this.label10.Text = "医疗证号";
            // 
            // txt_IcdName
            // 
            this.txt_IcdName.Location = new System.Drawing.Point(463, 133);
            this.txt_IcdName.Name = "txt_IcdName";
            this.txt_IcdName.Size = new System.Drawing.Size(100, 21);
            this.txt_IcdName.TabIndex = 45;
            // 
            // txt_IcdCode
            // 
            this.txt_IcdCode.Location = new System.Drawing.Point(281, 132);
            this.txt_IcdCode.Name = "txt_IcdCode";
            this.txt_IcdCode.Size = new System.Drawing.Size(110, 21);
            this.txt_IcdCode.TabIndex = 40;
            // 
            // txt_ToHspName
            // 
            this.txt_ToHspName.Location = new System.Drawing.Point(282, 186);
            this.txt_ToHspName.Name = "txt_ToHspName";
            this.txt_ToHspName.Size = new System.Drawing.Size(110, 21);
            this.txt_ToHspName.TabIndex = 39;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(376, 216);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(125, 12);
            this.label25.TabIndex = 21;
            this.label25.Text = "本次住院出院诊断名称";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(406, 190);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(125, 12);
            this.label21.TabIndex = 22;
            this.label21.Text = "转入医院技术级别编码";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 216);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(125, 12);
            this.label24.TabIndex = 23;
            this.label24.Text = "本次住院出院诊断编码";
            // 
            // txt_FromHspName
            // 
            this.txt_FromHspName.Location = new System.Drawing.Point(281, 159);
            this.txt_FromHspName.Name = "txt_FromHspName";
            this.txt_FromHspName.Size = new System.Drawing.Size(110, 21);
            this.txt_FromHspName.TabIndex = 42;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(406, 163);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(125, 12);
            this.label20.TabIndex = 18;
            this.label20.Text = "转入医院行政级别编码";
            // 
            // txt_UserCode
            // 
            this.txt_UserCode.Location = new System.Drawing.Point(281, 51);
            this.txt_UserCode.Name = "txt_UserCode";
            this.txt_UserCode.Size = new System.Drawing.Size(110, 21);
            this.txt_UserCode.TabIndex = 41;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(406, 137);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 20;
            this.label14.Text = "诊断名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(394, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 27;
            this.label3.Text = "新农合密码";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(201, 189);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 12);
            this.label18.TabIndex = 29;
            this.label18.Text = "转入医院名称";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(224, 136);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 28;
            this.label13.Text = "诊断编码";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(200, 162);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 12);
            this.label17.TabIndex = 24;
            this.label17.Text = "转出医院名称";
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Title.ForeColor = System.Drawing.Color.Red;
            this.lbl_Title.Location = new System.Drawing.Point(406, 13);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(125, 22);
            this.lbl_Title.TabIndex = 25;
            this.lbl_Title.Text = "转诊单业务";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 26;
            this.label2.Text = "新农合用户名";
            // 
            // cmbArea
            // 
            this.cmbArea.Font = new System.Drawing.Font("宋体", 9F);
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(88, 51);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(106, 20);
            this.cmbArea.TabIndex = 81;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.Location = new System.Drawing.Point(23, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 80;
            this.label1.Text = "选择区域:";
            // 
            // FrmTruncode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 401);
            this.Controls.Add(this.cmbArea);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_InOrOut);
            this.Controls.Add(this.rdo_Back);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.txt_TurnCode);
            this.Controls.Add(this.rdo_Modify);
            this.Controls.Add(this.rdo_Upload);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.btn_Upload);
            this.Controls.Add(this.txt_Remark);
            this.Controls.Add(this.dtp_TurnDate);
            this.Controls.Add(this.dtp_LvDtOfLstTime);
            this.Controls.Add(this.dtp_SBirthday);
            this.Controls.Add(this.cmb_TurnType);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.cmb_SSex);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmb_ToHspTechLvl);
            this.Controls.Add(this.cmb_ToHspLvl);
            this.Controls.Add(this.cmb_SType);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_BookNo);
            this.Controls.Add(this.txt_UserPass);
            this.Controls.Add(this.txt_Telphone);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.txt_IcdNameOfLstTime);
            this.Controls.Add(this.txt_DctrName);
            this.Controls.Add(this.txt_OutOfficeOfLstTime);
            this.Controls.Add(this.txt_IcdCodeOfLstTime);
            this.Controls.Add(this.txt_ToHspCode);
            this.Controls.Add(this.txt_FromHspCode);
            this.Controls.Add(this.txt_Memberno);
            this.Controls.Add(this.txt_IdCardno);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_IcdName);
            this.Controls.Add(this.txt_IcdCode);
            this.Controls.Add(this.txt_ToHspName);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.txt_FromHspName);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txt_UserCode);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.label2);
            this.Name = "FrmTruncode";
            this.Text = "FrmTruncode";
            this.Load += new System.EventHandler(this.FrmTruncode_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_InOrOut;
        private System.Windows.Forms.RadioButton rdo_Back;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.TextBox txt_TurnCode;
        private System.Windows.Forms.RadioButton rdo_Modify;
        private System.Windows.Forms.RadioButton rdo_Upload;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button btn_Upload;
        private System.Windows.Forms.TextBox txt_Remark;
        private System.Windows.Forms.DateTimePicker dtp_TurnDate;
        private System.Windows.Forms.DateTimePicker dtp_LvDtOfLstTime;
        private System.Windows.Forms.DateTimePicker dtp_SBirthday;
        private System.Windows.Forms.ComboBox cmb_TurnType;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cmb_SSex;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_ToHspTechLvl;
        private System.Windows.Forms.ComboBox cmb_ToHspLvl;
        private System.Windows.Forms.ComboBox cmb_SType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_BookNo;
        private System.Windows.Forms.TextBox txt_UserPass;
        private System.Windows.Forms.TextBox txt_Telphone;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.TextBox txt_IcdNameOfLstTime;
        private System.Windows.Forms.TextBox txt_DctrName;
        private System.Windows.Forms.TextBox txt_OutOfficeOfLstTime;
        private System.Windows.Forms.TextBox txt_IcdCodeOfLstTime;
        private System.Windows.Forms.TextBox txt_ToHspCode;
        private System.Windows.Forms.TextBox txt_FromHspCode;
        private System.Windows.Forms.TextBox txt_Memberno;
        private System.Windows.Forms.TextBox txt_IdCardno;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_IcdName;
        private System.Windows.Forms.TextBox txt_IcdCode;
        private System.Windows.Forms.TextBox txt_ToHspName;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txt_FromHspName;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txt_UserCode;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Label label1;
    }
}