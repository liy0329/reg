using System;
using System.Data;
using System.Windows.Forms;
using MTREG.medinsur;
using MTREG.ihsp.bll;
using MTREG.common;
using System.Text.RegularExpressions;
using MTREG.medinsur.bll;
using MTREG.idcard.bll;
using MTHIS.common;
using MTREG.ihsp.bo;
using MTHIS.main.bll;
using MTREG.medinsur.hdyb.bll;
using MTREG.medinsur.hdxbhnh;
using MTREG.medinsur.hdxbhnh.bll;
using System.Text;
using MTREG.medinsur.hdsch.bll;
using MTREG.medinsur.hdsch;
using MTREG.medinsur.hdssy;
using MTREG.medinsur.hdssy.bll;
using MTREG.medinsur.hdsbhnh.bo;
using MTREG.medinsur.hdsbhnh.bll;
using MTREG.medinsur.hsdryb.ihsp;
using MTREG.medinsur.hsdryb.ihsp.bll;
using MTREG.medinsur.hsdryb.bo;
using MTREG.medinsur.gysyb;
using MTREG.medinsur.gysyb.bll;
using MTREG.medinsur.gysyb.bo;
using MTREG.medinsur.ahsjk.bo.inp;
using MTREG.medinsur.ahsjk.bll;
using MTREG.medinsur.ahsjk.bo.outp;
using MTREG.medinsur.ahsjk.bo;
using MTREG.medinsur.gzsnh.bo;
using MTREG.medinsur.gzsnh.bll;
using System.Net;
using MTREG.medinsur.ahsjk;
using MTREG.medinsur.gzsnh;
using MTREG.medinsur.ynsyb.ihsp;
using MTREG.medinsur.ynsyb.bo;
using MTREG.medinsur.ynsyb.ihsp.bll;
using MTREG.medinsur.ynydyb;
using MTREG.medinsur.ynydyb.bo;
using MTREG.medinsur.ynydyb.bll;
using MTREG.tools;
using System.Runtime.InteropServices;
using System.Threading;
using MTREG.medinsur.gzsyb.Util;
using MTREG.common.bll;
using MTREG.clinic.bll;
using MTREG.netpay;
using MTREG.ihsptab.bo;
using MTREG.netpay.bo;
using MTREG.medinsur.hdyb.dor;
using MTREG.medinsur.hdyb;
using MTREG.medinsur.sjzsyb;
using MTREG.medinsur.sjzsyb.bll;
using MTREG.medinsur.sjzsyb.bean;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace MTREG.ihsp
{
    public partial class FrmIhspReg : Form
    {
        /// <summary>
        /// 读身份证使用
        /// </summary>
        CardMsgs cardmsgs = new CardMsgs();
        private int nport;
        public int Nport
        {
            get { return nport; }
            set { nport = value; }
        }
        private bool falg;
        public bool Falg
        {
            get { return falg; }
            set { falg = value; }
        }

        YBCJ yw1 = new YBCJ();
        Sjzsyb sjzsyb = new Sjzsyb();



        BillCmbList billCmbList = new BillCmbList();
        InsurInfo insurInfo = new InsurInfo();
        //北航农合传参
        HdsbhInfo hdsbhInfo = new HdsbhInfo();
        Header header = new Header();
        BllClinicReg bllClinicReg = new BllClinicReg();
        RegInfo regInfo = new RegInfo();
        SjzybInterface sjzybInterface = new SjzybInterface();
        /// <summary>
        /// 安徽农合
        /// </summary>
        internal RegInfo RegInfo
        {
            get { return regInfo; }
            set { regInfo = value; }
        }
        YnydybRegInfo ynydybRegInfo = new YnydybRegInfo();
        /// <summary>
        /// 云南传参
        /// </summary>
        internal YnydybRegInfo YnydybRegInfo
        {
            get { return ynydybRegInfo; }
            set { ynydybRegInfo = value; }
        }

        GzsnhRegInfo gzsnhRegInfo = new GzsnhRegInfo();
        /// <summary>
        /// 贵州省农合
        /// </summary>
        internal GzsnhRegInfo GzsnhRegInfo
        {
            get { return gzsnhRegInfo; }
            set { gzsnhRegInfo = value; }
        }

        /// <summary>
        /// 用于时间控件转移焦点
        /// </summary>
        int i = 0;

        string clininDiagnICD;
        /// <summary>
        /// 门诊疾病编码字符串
        /// </summary>
        public string ClininDiagnICD
        {
            get { return clininDiagnICD; }
            set { clininDiagnICD = value; }
        }
        string clininDiagnName;
        /// <summary>
        /// 门诊疾病名称字符串
        /// </summary>
        public string ClininDiagnName
        {
            get { return clininDiagnName; }
            set { clininDiagnName = value; }
        }

        internal Header Header
        {
            get { return header; }
            set { header = value; }
        }
        internal HdsbhInfo HdsbhInfo
        {
            get { return hdsbhInfo; }
            set { hdsbhInfo = value; }
        }
        IdCardInfo idCardInfo = new IdCardInfo();
        BillIhspMan billIhspMan = new BillIhspMan();

        BllInsur bllInsur = new BllInsur();
        BllHdsch bllHdsch = new BllHdsch();
        Inhospital inhospital = new Inhospital();
        string registinfo;
        Sybdk_Entity sybdk_entity = new Sybdk_Entity();//贵阳市医保
        //PersonInfo personInfo = new PersonInfo();//贵州省医保
        GetEmpInfo_out getEmpInfo_out = new GetEmpInfo_out();//云南省医保
        /// <summary>
        /// 医保信息字符串
        /// </summary>
        public string Registinfo
        {
            get { return registinfo; }
            set { registinfo = value; }
        }

        int flag;
        string member_id = "-1";

        string clinic_ihspnotice_id = ""; //入院通知
        string register_id = "";//挂号记录id
        string homephone = "";//电话
        string profession_id = "";//职业id
        string profession = ""; //职业
        string marriage_id = "";//婚姻状况

        private string ihsp_id = "";//住院记录id
        private string ihspcode = "";//住院号
        private string casecode = "";//病案号


        private string patienttype;
        private string netpaytype = "-1";//网路支付类型
        /// <summary>
        /// 患者类型
        /// </summary>
        public string Patienttype
        {
            get { return patienttype; }
            set { patienttype = value; }
        }


        /// <summary>
        /// idCardInfo类
        /// </summary>
        internal IdCardInfo IdCardInfo
        {
            get { return idCardInfo; }
            set { idCardInfo = value; }
        }
        /// <summary>
        /// insurInfo类
        /// </summary>
        internal InsurInfo InsurInfo
        {
            get { return insurInfo; }
            set { insurInfo = value; }
        }

        /// <summary>
        /// 无参数构造函数
        /// </summary>
        public FrmIhspReg(string state)
        {
            InitializeComponent();

        }

        /// <summary>
        /// 控制年龄，出生日期变化联动
        /// </summary>
        bool ischarge = false;
        /// <summary>
        /// 控制listbox显示
        /// </summary>
        bool isleave = false;
        /// <summary>
        /// 窗口生成时导入的操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmIhspReg_Load(object sender, EventArgs e)
        {
            //BillSysBase.controlAutoSize(this);            
            cmbSource();
            intDataPoverty();
            intDataForREG();
            dtpIndate.Value = Convert.ToDateTime(BillSysBase.currDate());
            intHm();
        }

        /// <summary>
        /// 绑定combobox数据
        /// </summary>
        private void cmbSource()
        {
            #region   doctor,depart,patienttype,下拉表绑定数据库

            DataTable dtrace = billCmbList.getRaceInfo(cmbRace.Text.Trim());
            if (dtrace.Rows.Count > 0)
            {
                this.cmbRace.DisplayMember = "name";
                this.cmbRace.ValueMember = "id";
                this.cmbRace.DataSource = dtrace;
                this.cmbRace.SelectedValue = 1;
            }

            DataTable dtunit = billCmbList.ageunitList();
            if (dtunit.Rows.Count > 0)
            {
                this.cmbAgeunit.DisplayMember = "name";
                this.cmbAgeunit.ValueMember = "id";
                this.cmbAgeunit.DataSource = dtunit;
                this.cmbAgeunit.SelectedValue = (int)AgeUnit.AGE;
            }
            DataTable dtMonth = billCmbList.ageunitList();
            if (dtMonth.Rows.Count > 0)
            {
                this.cmbMonth.DisplayMember = "name";
                this.cmbMonth.ValueMember = "id";
                this.cmbMonth.DataSource = dtMonth;
                this.cmbMonth.SelectedValue = (int)AgeUnit.MOON;
                this.cmbMonth.Enabled = false;
            }
            DataTable dtCost = billCmbList.regCostclassList();
            if (dtCost.Rows.Count > 0)
            {
                this.cmbCostclass.ValueMember = "keyname";
                this.cmbCostclass.DisplayMember = "name";
                this.cmbCostclass.DataSource = dtCost;
                cmbCostclass.SelectedValue = "COUNTY";//ProgramGlobal.CostClass;
            }

            initCmbDepart();
            initCmbclinicDepart();

            DataTable dtp = billCmbList.patientTypeList();
            if (dtp.Rows.Count > 0)
            {
                this.cmbPatienttype.ValueMember = "id";
                this.cmbPatienttype.DisplayMember = "name";
                this.cmbPatienttype.DataSource = dtp;

            }

            DataTable dtb = billCmbList.ihspSourceList();
            if (dtb.Rows.Count > 0)
            {
                this.cmbBas_ihspsource.ValueMember = "id";
                this.cmbBas_ihspsource.DisplayMember = "name";
                this.cmbBas_ihspsource.DataSource = dtb;
                this.cmbBas_ihspsource.SelectedValue = 2;//默认是门诊
            }

            DataTable dts = billCmbList.sexList();
            if (dts.Rows.Count > 0)
            {
                this.cmbSex.ValueMember = "id";
                this.cmbSex.DisplayMember = "name";
                this.cmbSex.DataSource = dts;
            }

            DataTable dtis = billCmbList.ihspinstatList();
            if (dtis.Rows.Count > 0)
            {
                this.cmbIhspinstat.ValueMember = "id";
                this.cmbIhspinstat.DisplayMember = "name";
                this.cmbIhspinstat.DataSource = dtis;
                this.cmbIhspinstat.SelectedValue = 4;//默认一般
            }

            DataTable dtPayType = billCmbList.payPaytypeList();
            if (dtPayType.Rows.Count > 0)
            {
                this.cmbPayType.ValueMember = "id";
                this.cmbPayType.DisplayMember = "name";
                this.cmbPayType.DataSource = dtPayType;
                this.cmbPayType.SelectedValue = 1;
            }
            //省地址初始化
            DataTable province = bllRegister.provinceList("");
            if (province.Rows.Count > 0)
            {
                var provincePay = province.NewRow();
                provincePay["id"] = 0;
                provincePay["name"] = "-请选择-";
                province.Rows.InsertAt(provincePay, 0);
                cmbProvince.DataSource = province;
                cmbProvince.ValueMember = "id";
                cmbProvince.DisplayMember = "name";

                cmbProvince.SelectedValue = "130000";
                cmbCity.SelectedValue = "130100";

            }
            

            #endregion
        }

        /// <summary>
        /// 登记初始化
        /// </summary>
        private void intDataForREG()
        {
            tbxPayfee.Text = "0";
            tbxLimitamt.Text = "200.00";
            tbxIhspcode.Enabled = false;
            string ihspcode = BillSysBase.currBillcode("inhospital_ihspcode");
            string casecode = BillSysBase.currBillcode("inhospital_casecode");
            tbxIhspcode.Text = ihspcode;
        }
        /// <summary>
        /// 贫困人口类型初始化
        /// </summary>
        public void intDataPoverty()
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("非贫困户", "0"));
            items.Add(new ListItem("农村低保", "1"));
            items.Add(new ListItem("农村特困", "2"));
            items.Add(new ListItem("城镇低保", "3"));
            items.Add(new ListItem("城市特困", "4"));
            items.Add(new ListItem("建档立卡", "5"));

            this.com_Poverty.DisplayMember = "Text";
            this.com_Poverty.ValueMember = "Value";
            this.com_Poverty.DataSource = items;
            this.com_Poverty.SelectedValue = "0";
        }
        /// <summary>
        /// 初始化时分
        /// </summary>
        public void intHm()
        {
            List<ListItem> hours = new List<ListItem>();
            hours.Add(new ListItem("00", "00"));
            hours.Add(new ListItem("01", "01"));
            hours.Add(new ListItem("02", "02"));
            hours.Add(new ListItem("03", "03"));
            hours.Add(new ListItem("04", "04"));
            hours.Add(new ListItem("05", "05"));
            hours.Add(new ListItem("06", "06"));
            hours.Add(new ListItem("07", "07"));
            hours.Add(new ListItem("08", "08"));
            hours.Add(new ListItem("09", "09"));
            hours.Add(new ListItem("10", "10"));
            hours.Add(new ListItem("11", "11"));
            hours.Add(new ListItem("12", "12"));
            hours.Add(new ListItem("13", "13"));
            hours.Add(new ListItem("14", "14"));
            hours.Add(new ListItem("15", "15"));
            hours.Add(new ListItem("16", "16"));
            hours.Add(new ListItem("17", "17"));
            hours.Add(new ListItem("18", "18"));
            hours.Add(new ListItem("19", "19"));
            hours.Add(new ListItem("20", "20"));
            hours.Add(new ListItem("21", "21"));
            hours.Add(new ListItem("22", "22"));
            hours.Add(new ListItem("23", "23"));

            this.cbxHour.DisplayMember = "Text";
            this.cbxHour.ValueMember = "Value";
            this.cbxHour.DataSource = hours;
            this.cbxHour.SelectedValue = "00";

            List<ListItem> minutes = new List<ListItem>();
            minutes.Add(new ListItem("00", "00"));
            minutes.Add(new ListItem("01", "01"));
            minutes.Add(new ListItem("02", "02"));
            minutes.Add(new ListItem("03", "03"));
            minutes.Add(new ListItem("04", "04"));
            minutes.Add(new ListItem("05", "05"));
            minutes.Add(new ListItem("06", "06"));
            minutes.Add(new ListItem("07", "07"));
            minutes.Add(new ListItem("08", "08"));
            minutes.Add(new ListItem("09", "09"));
            minutes.Add(new ListItem("10", "10"));
            minutes.Add(new ListItem("11", "11"));
            minutes.Add(new ListItem("12", "12"));
            minutes.Add(new ListItem("13", "13"));
            minutes.Add(new ListItem("14", "14"));
            minutes.Add(new ListItem("15", "15"));
            minutes.Add(new ListItem("16", "16"));
            minutes.Add(new ListItem("17", "17"));
            minutes.Add(new ListItem("18", "18"));
            minutes.Add(new ListItem("19", "19"));
            minutes.Add(new ListItem("20", "20"));
            minutes.Add(new ListItem("21", "21"));
            minutes.Add(new ListItem("22", "22"));
            minutes.Add(new ListItem("23", "23"));
            minutes.Add(new ListItem("24", "24"));
            minutes.Add(new ListItem("25", "25"));
            minutes.Add(new ListItem("26", "26"));
            minutes.Add(new ListItem("27", "27"));
            minutes.Add(new ListItem("28", "28"));
            minutes.Add(new ListItem("29", "29"));
            minutes.Add(new ListItem("30", "30"));
            minutes.Add(new ListItem("31", "31"));
            minutes.Add(new ListItem("32", "32"));
            minutes.Add(new ListItem("33", "33"));
            minutes.Add(new ListItem("34", "34"));
            minutes.Add(new ListItem("35", "35"));
            minutes.Add(new ListItem("36", "36"));
            minutes.Add(new ListItem("37", "37"));
            minutes.Add(new ListItem("38", "38"));
            minutes.Add(new ListItem("39", "39"));
            minutes.Add(new ListItem("40", "40"));
            minutes.Add(new ListItem("41", "41"));
            minutes.Add(new ListItem("42", "42"));
            minutes.Add(new ListItem("43", "43"));
            minutes.Add(new ListItem("44", "44"));
            minutes.Add(new ListItem("45", "45"));
            minutes.Add(new ListItem("46", "46"));
            minutes.Add(new ListItem("47", "47"));
            minutes.Add(new ListItem("48", "48"));
            minutes.Add(new ListItem("49", "49"));
            minutes.Add(new ListItem("50", "50"));
            minutes.Add(new ListItem("51", "51"));
            minutes.Add(new ListItem("52", "52"));
            minutes.Add(new ListItem("53", "53"));
            minutes.Add(new ListItem("54", "54"));
            minutes.Add(new ListItem("55", "55"));
            minutes.Add(new ListItem("56", "56"));
            minutes.Add(new ListItem("57", "57"));
            minutes.Add(new ListItem("58", "58"));
            minutes.Add(new ListItem("59", "59"));

            this.cbxMinute.DisplayMember = "Text";
            this.cbxMinute.ValueMember = "Value";
            this.cbxMinute.DataSource = minutes;
            this.cbxMinute.SelectedValue = "00";


        }
        /// <summary>
        /// 插入方法
        /// </summary>
        public bool ihspReg(string hisOrderNo, string registdate)
        {

            string regist_sql = "";
            Member member = new Member();
            inhospital.Hspcard = this.tbxHspcard.Text.Trim().ToString();
            inhospital.Name = this.tbxName.Text.Trim().ToString();
            inhospital.Pincode = GetData.GetChineseSpell(tbxName.Text.Trim().ToString());
            inhospital.Ihspsn = this.tbxIhspsn.Text;
            switch (cmbSex.Text.Trim())
            {
                case "男": inhospital.Sex = Sex.M.ToString(); break;
                case "女": inhospital.Sex = Sex.W.ToString(); break;
                case "未说明性别": inhospital.Sex = Sex.U.ToString(); break;
                case "未知性别": inhospital.Sex = ""; break;
            }
            inhospital.Age = this.tbxAge.Text.Trim().ToString();
            inhospital.Ageunit = this.cmbAgeunit.SelectedValue.ToString();
            if (string.IsNullOrEmpty(tbxMonAge.Text.Trim()))
            {
                inhospital.MonAge = "0";
            }
            else
            {
                inhospital.MonAge = this.tbxMonAge.Text.Trim().ToString();
            }
            inhospital.Monageunit = this.cmbMonth.SelectedValue.ToString();
            inhospital.Depart = this.cmbDepart.SelectedValue.ToString();
            inhospital.ClinicDepart = this.cmbClinicDepart.SelectedValue.ToString();
            inhospital.poverty = com_Poverty.SelectedIndex.ToString();
            inhospital.Birthday = this.dtpBirthday.Value.ToString("yyyy-MM-dd ") + this.cbxHour.SelectedValue.ToString() + ":" + this.cbxMinute.SelectedValue.ToString() + ":00";

            inhospital.Inspsource = this.cmbBas_ihspsource.SelectedValue.ToString();
            inhospital.Introducer = this.tbxIntroducer.Text.Trim().ToString();
            inhospital.Registby = ProgramGlobal.User_id;
            if (cmbDoctor.SelectedValue == null || cmbDoctor.SelectedValue.ToString() == "0")
            {
                inhospital.Doctor = "";
            }
            else
            {
                inhospital.Doctor = cmbDoctor.SelectedValue.ToString();
            }
            if (cmbClinicDoctor.SelectedValue == null || cmbClinicDoctor.SelectedValue.ToString() == "0")
            {
                inhospital.ClinicDoctor = "";
            }
            else
            {
                inhospital.ClinicDoctor = cmbClinicDoctor.SelectedValue.ToString();
            }
            //默认自费，转医保后更新
            inhospital.Patienttype = "1";//this.cmbPatienttype.SelectedValue.ToString();
            inhospital.Limitamt = this.tbxLimitamt.Text.Trim().ToString();
            inhospital.Prepamt = this.tbxPayfee.Text.Trim().ToString();
            inhospital.Costclass = this.cmbCostclass.SelectedValue.ToString();
            inhospital.Bas_ihspinstat_id = this.cmbIhspinstat.SelectedValue.ToString();
            inhospital.Registdate = registdate;//登记时间
            inhospital.Clinicdiagn = tbxDiagnName.Text.Trim().ToString();
            inhospital.Clinicicd = ClininDiagnICD;
            //inhospital.Idcard = this.tbxIDCard.Text.Trim().ToString();inhospital
            inhospital.Paytype = cmbPayType.SelectedValue.ToString();

            member.Idcard = this.tbxIDCard.Text.Trim().ToString();
            if (cmbRace.SelectedValue != null)
            {
                member.Raceid = cmbRace.SelectedValue.ToString();
                member.Race = cmbRace.Text.Trim();
            }

            member.Hmprovince = cmbProvince.SelectedValue.ToString();
            member.Hmcity = cmbCity.SelectedValue.ToString();
            member.Hmcounty = cmbCounty.SelectedValue.ToString();
            member.HmhouseNumber = tbxsubAddress.Text.ToString();
            member.Mobile = tbxMobile.Text.ToString();
            member.Companyname = "";//this.tbxCompanyname.Text.Trim().ToString();
            member.Createdby = ProgramGlobal.User_id;
            member.Createdate = registdate;//登记时间 
            member.Provice_id = cmbProvince.SelectedValue.ToString();
            member.City_id = cmbCity.SelectedValue.ToString();
            member.County_id = cmbCounty.SelectedValue.ToString();
            if (string.IsNullOrEmpty(tbxHspcard.Text))
            {
                inhospital.Hspcard = BillSysBase.newBillcode("member_hspcard");
            }

            if (inhospital.Prepamt == "")
            {
                tbxPayfee.Text = "0.00";
            }

            //非会员生成[插入会员表]
            if (member_id == "-1" || member_id == null || member_id == "")
            {
                member_id = DataTool.addIntBraces(BillSysBase.nextId("member"));
                regist_sql += billIhspMan.Regmember(member_id, member, inhospital);
            }
            else
            {
                regist_sql += billIhspMan.Updatemember(member_id, member, inhospital);
            }
            inhospital.Member_id = member_id;
            inhospital.Id = ihsp_id;
            inhospital.Ihspcode = this.ihspcode;
            inhospital.Casecode = this.casecode;
            inhospital.Indate = this.dtpIndate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            inhospital.Clinic_ihspnotice_id = clinic_ihspnotice_id;

            //string keyname = bllInsur.getInsurtype(cmbPatienttype.SelectedValue.ToString());
            //if (keyname == CostInsurtypeKeyname.GYSYB.ToString())
            //{
            //    inhospital.Insurstat = Insurstat.REG.ToString();
            //    inhospital.Insuritemtype = "3";
            //    inhospital.Insurcode = sybdk_entity.Grbh;
            //    inhospital.Bas_patienttype1_id = inhospital.Patienttype;
            //}
            //else if (keyname == CostInsurtypeKeyname.GZSYB.ToString())
            //{
            //    inhospital.Insurstat = Insurstat.REG.ToString();
            //    inhospital.Insuritemtype = "3";
            //    inhospital.Insurcode = personInfo.Swgrbh;
            //    string insurtype = personInfo.Swfzxbm;
            //    inhospital.Bas_patienttype1_id = "16";
            //    if (insurtype == "9900" || insurtype == "9907")
            //    {

            //        inhospital.Bas_patienttype1_id = "29";
            //    }
            //    else if (insurtype == "9908")
            //    {

            //        inhospital.Bas_patienttype1_id = "30";
            //    }
            //}
            //else if (keyname == CostInsurtypeKeyname.SELFCOST.ToString())
            //{
            inhospital.Insurstat = "OO";
            inhospital.Bas_patienttype1_id = inhospital.Patienttype;
            IhspInfo ihspInfo = new IhspInfo();
            if (cmbRace.SelectedValue != null)
            {
                ihspInfo.Raceid = cmbRace.SelectedValue.ToString();
                ihspInfo.Race = cmbRace.Text.Trim();
            }
            ihspInfo.HmhouseNumber = tbxsubAddress.Text.Trim();
            ihspInfo.Ihsp_id = ihsp_id;
            ihspInfo.Idcard = tbxIDCard.Text.Trim();
            //ihspInfo.Companyname = tbxCompanyname.Text.Trim();
            ihspInfo.Province_id = cmbProvince.SelectedValue.ToString();
            ihspInfo.City_id = cmbCity.SelectedValue.ToString();
            ihspInfo.County_id = cmbCounty.SelectedValue.ToString();

            if (ihspInfo.Province_id == "0" || ihspInfo.City_id == "0" || ihspInfo.County_id == "0")
            {
                ihspInfo.Homeaddress = tbxsubAddress.Text.Trim();
            }
            else
            {
                ihspInfo.Homeaddress = cmbProvince.Text.ToString() + cmbCity.Text.ToString() + cmbCounty.Text.ToString() + ihspInfo.HmhouseNumber;
            }

            ihspInfo.Homephone = this.homephone;
            ihspInfo.Profession_id = this.profession_id;
            ihspInfo.Profession = this.profession;
            ihspInfo.Marriage_id = this.marriage_id;
            regist_sql += billIhspMan.inhspReg(inhospital, ihspInfo);//住院记录
            Ihsppayinadv ihsppayinadv = new Ihsppayinadv();
            ihsppayinadv.Id = BillSysBase.nextId("ihsp_payinadv");
            ihsppayinadv.Billcode = BillSysBase.newBillcode("ihsp_payinadv_billcode");
            ihsppayinadv.Ihsp_id = ihsp_id;
            ihsppayinadv.Bas_paysumby_id = billIhspMan.getbaspaysumbyid(cmbPayType.SelectedValue.ToString());
            ihsppayinadv.Paytype = cmbPayType.SelectedValue.ToString();
            ihsppayinadv.Cheque = "";
            ihsppayinadv.Num = "1";
            ihsppayinadv.Payman = tbxPayMan.Text.Trim();
            ihsppayinadv.Prepamt = "0";
            ihsppayinadv.Feeamt = "0";
            ihsppayinadv.Payfee = inhospital.Prepamt;
            ihsppayinadv.Status = IhspPayinadvStatus.CHRG.ToString();
            ihsppayinadv.Depart = ProgramGlobal.Depart_id;
            ihsppayinadv.Chargedby = ProgramGlobal.User_id;
            ihsppayinadv.HisOrderNo = hisOrderNo;
            ihsppayinadv.Chargedate = registdate;
            ihsppayinadv.Ihsp_payinadv_id = null;
            regist_sql += billIhspMan.inhspPay(ihsppayinadv);//预交款

            if (billIhspMan.doExeSql(regist_sql) < 0)
            {
                MessageBox.Show("住院信息HIS操作失败,医保病人请及时撤销医保票据,网路支付病人请及时撤退预交金额！");
                return false;
            }
            BillSysBase.doIhspAmt(ihsp_id);
            if (MessageBox.Show("交预付款成功，是否打印预交款发票?", "提示信息", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                FrxPrintView frxPrintView = new FrxPrintView();
                frxPrintView.getIhspPayInadv(ihsppayinadv.Id);
            }
            return true;
        }









        /// <summary>
        /// 贵州省新农合登记/修改
        /// </summary>
        private bool gzsxnhReg(string state)
        {
            BllGzsnhMethod bllGzsnhMethod = new BllGzsnhMethod();
            ///操作类型:修改/登记
            string oper = "1";
            if (state == "EDIT")
            {
                oper = "2";
            }
            WebClient webClient = new WebClient();
            string url = GzsnhGlobal.Url + "inpatientRegister?userName=" + Base64.encodebase64(GzsnhGlobal.UserName) + "&userPwd=" + Base64.encodebase64(GzsnhGlobal.UserPwd) + "&centerNo=" + Base64.encodebase64(GzsnhGlobal.CenterNo) + "&type=" + Base64.encodebase64(oper) + "&hospCode=" + Base64.encodebase64(GzsnhGlobal.HospCode) + "&inpatientNo=" + Base64.encodebase64(inhospital.Ihspcode) + "&familySysno=" + Base64.encodebase64(GzsnhRegInfo.Familysysno) + "&memberSysno=" + Base64.encodebase64(GzsnhRegInfo.Membersysno) + "&Stature=" + Base64.encodebase64(GzsnhRegInfo.Stature) + "&Weight=" + Base64.encodebase64(GzsnhRegInfo.Weight) + "&icdAllNo=" + Base64.encodebase64(GzsnhRegInfo.Icdallno) + "&secondIcdNo=" + Base64.encodebase64(GzsnhRegInfo.Secondicdno) + "";
            url += "&threeIcdNo=" + Base64.encodebase64(GzsnhRegInfo.Threeicdno) + "&opsId=" + Base64.encodebase64(GzsnhRegInfo.Opsid) + "&treatCode=" + Base64.encodebase64(GzsnhRegInfo.Treatcode) + "&inOfficeId=" + Base64.encodebase64(GzsnhRegInfo.Inofficeid) + "&officeDate=" + Base64.encodebase64(dtpIndate.Value.ToString()) + "&cureId=" + Base64.encodebase64(GzsnhRegInfo.Cureid) + "&complication=" + Base64.encodebase64(GzsnhRegInfo.Complication) + "&inHosId=" + Base64.encodebase64(cmbIhspinstat.SelectedValue.ToString()) + "&cureDoctor=" + Base64.encodebase64(cmbDoctor.Text) + "&bedNo=" + Base64.encodebase64(GzsnhRegInfo.Bedno) + "&sectionNo=" + Base64.encodebase64(GzsnhRegInfo.Sectionno) + "";
            url += "&turnMode=" + Base64.encodebase64(GzsnhRegInfo.Turnmode) + "&turnCode=" + Base64.encodebase64(GzsnhRegInfo.Turncode) + "&turnDate=" + Base64.encodebase64(GzsnhRegInfo.Turndate) + "&ticketNo=" + Base64.encodebase64(GzsnhRegInfo.Ticketno) + "&ministerNotice=" + Base64.encodebase64(GzsnhRegInfo.Ministernotice) + "&procreateNotice=" + Base64.encodebase64(GzsnhRegInfo.Procreatenotice) + "&tel=" + Base64.encodebase64(GzsnhRegInfo.Tel) + "&isNewborn=" + Base64.encodebase64(GzsnhRegInfo.Isnewborn) + "&newbornBirthday=" + Base64.encodebase64(GzsnhRegInfo.Newbornbirthday) + "&newbornName=" + Base64.encodebase64(GzsnhRegInfo.Newbornname) + "&newbornSex=" + Base64.encodebase64(GzsnhRegInfo.Newbornsex) + "";
            string sj = DateTime.Now.ToString("HHmm");
            if (oper == "2")
            {
                //网络地址|农合中心编码|医疗机构编码|用户名|密码|农合住院流水号|个人编号|家庭编码|医疗证卡号 
                gzsnhRegInfo = bllGzsnhMethod.readRegInfo(ihsp_id);
                url += "&registerID=" + Base64.encodebase64(sj + inhospital.Id) + "&inpatientSn=" + Base64.encodebase64(gzsnhRegInfo.Inpatientsn);
            }
            else
            {
                url += "&registerID=" + Base64.encodebase64(sj + inhospital.Id) + "&inpatientSn=" + Base64.encodebase64("");
            }
            string[] data = null;
            try
            {
                string param = webClient.DownloadString(url);//.Split(':')[1].Replace("\"", "").Replace("}", "");
                try
                {
                    string[] info = param.Replace("},{", "@").Split('@');
                    //for (int i = 0; i < info.Length; i++)
                    //{
                    string[] detial = info[0].Replace("[{", "").Replace("}]", "").Replace("\"", "").Split(',');
                    //for (int j = 0; j < detial.Length; j++)
                    //{
                    data = detial[0].Replace("{", "").Replace("}", "").Split(':');
                    //    }
                    //}

                    if (oper == "1")
                    {
                        GzsnhRegInfo.Inpatientsn = Base64.decodebase64(data[1]);
                        //网络地址|农合中心编码|医疗机构编码|用户名|密码|农合住院流水号|个人编号|家庭编码|医疗证卡号                
                        flag = bllGzsnhMethod.saveRegInfo(gzsnhRegInfo, ihsp_id);
                        if (flag < 0)
                        {
                            MessageBox.Show("医保信息存入失败!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取失败:" + Base64.decodebase64(Base64.GetPageCodeBy500Error(url, "utf-8").Split(':')[1].Replace("\"", "").Replace("}", "")));
                return false;
            }
            return true;
        }

        /// <summary>
        /// 确定按钮；添加数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            Billjc blljc = new Billjc();
            //贫困户判断
            //string ts = blljc.getpkh(tbxIDCard.Text.Trim().ToString(), tbxName.Text.Trim().ToString());
            //if (ts == null || ts == "")
            //{

            //}
            //else
            //{
            //    MessageBox.Show(ts, "提示");
            //    return;
            //}
            btnOk.Enabled = false;
            
            if (!doRegist())
            {
                btnOk.Enabled = true;
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        /// <summary>
        /// 确定按钮事件
        /// </summary>
        public bool doRegist()
        {
            //界面信息校验_BEGIN
            if (this.cmbRace.SelectedValue == null || this.cmbRace.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("民族不能为空！");
                this.cmbRace.Focus();
                return false;
            }
            string idcard = this.tbxIDCard.Text.Trim().ToUpper();//身份证号  
            this.tbxIDCard.Text = idcard;
            Regex reg = new Regex(@"^(\d{8}[0-1]\d[0-3]\d{4}$|^\d{6}[1-2][901]\d{2}[0-1]\d[0-3]\d{5}$|^\d{6}[1-2][901]\d{2}[0-1]\d[0-3]\d{4}(\d|X|x))$");//正则表达式
            //身份证判断
            if (idcard != "" && !reg.IsMatch(idcard))
            {
                MessageBox.Show("身份证号位数不够或者有其他字符！");
                this.tbxIDCard.Focus();
                return false;
            }
            if (this.cmbDepart.SelectedValue == null || this.cmbDepart.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("提示：请选择科室！");
                this.cmbDepart.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(tbxName.Text.Trim()))
            {
                MessageBox.Show("提示：姓名栏不能为空！");
                this.tbxName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(cmbBas_ihspsource.Text.Trim()))
            {
                MessageBox.Show("提示：入院途径栏不能为空！");
                this.cmbBas_ihspsource.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(tbxIntroducer.Text.Trim()))
            {
                MessageBox.Show("提示：介绍人不能为空！");
                this.tbxIntroducer.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cmbBas_ihspsource.Text.Trim()))
            {
                MessageBox.Show("提示：患者类型栏不能为空！");
                this.cmbBas_ihspsource.Focus();
                this.cmbBas_ihspsource.DroppedDown = true;
                return false;
            }
            if (string.IsNullOrEmpty(tbxAge.Text) || (tbxAge.Text == "0" && tbxMonAge.Text == "0"))
            {
                MessageBox.Show("提示：年龄不能为空或'0'!");
                this.tbxAge.Focus();
                return false;
            }

            if (!Regex.IsMatch(tbxPayfee.Text, @"(\d+(\.\d+)?)"))
            {
                MessageBox.Show("提示：预交款填写格式有误!");
                this.tbxPayfee.Focus();
                return false;
            }

            if (DataTool.stringToDouble(tbxLimitamt.Text) < 200)
            {
                MessageBox.Show("提示：最低限额不能低于200！");
                this.tbxLimitamt.Focus();
                return false;
            }
            //需要指定住院号时
            if (this.cbxEdit.Checked)
            {
                if (tbxIhspcode.Text == "")
                {
                    MessageBox.Show("住院号不能为空！");
                    this.tbxIhspcode.Focus();
                    return false;
                }
                ihspcode = tbxIhspcode.Text;
            }
            else
            {
                if (string.IsNullOrEmpty(ihspcode))
                {
                    ihspcode = BillSysBase.newBillcode("inhospital_ihspcode");
                }
            }
            casecode = BillSysBase.newBillcode("inhospital_casecode");
            if (string.IsNullOrEmpty(ihsp_id))
            {
                ihsp_id = BillSysBase.nextId("inhospital");
            }
            //界面信息校验_END

            string keyname = bllInsur.getInsurtype(cmbPatienttype.SelectedValue.ToString());
            //if (keyname == CostInsurtypeKeyname.GZSNH.ToString())
            //{
            //    MessageBox.Show("请先按自费登记，然后转医保！");
            //    return false;
            //}

            //网络支付业务:

            string hisOrderNo = "";
            string registdate = BillSysBase.currDate();
            //目前没有网络支付
            //if (!doExecNetPay(registdate, ref hisOrderNo))
            //    return false;
            //网络支付业务_END:


            // if (keyname == CostInsurtypeKeyname.GYSYB.ToString())
            //{
            //    BllInsurGYSYB bllInsurGYSYB = new BllInsurGYSYB();
            //    if (cmbDoctor.SelectedValue != null && cmbDoctor.SelectedValue.ToString() != "0")
            //    {
            //        sybdk_entity.Ys = cmbDoctor.Text;
            //    }

            //        sybdk_entity.Ks = cmbDepart.Text;
            //        sybdk_entity.Ryrq = this.dtpIndate.Value.ToString();

            //    StringBuilder msg = new StringBuilder();
            //    if (!bllInsurGYSYB.insurRegist(ihsp_id,ihspcode,msg, sybdk_entity))
            //    {
            //        MessageBox.Show("市医保动态库，登记失败，动态库返回错误信息为：" + msg.ToString()+"网络支付成功时，请及时撤销网络支付信息");
            //        return false;
            //    }
            //    if (!ihspReg(hisOrderNo, registdate))//His登记
            //    {
            //        MessageBox.Show("市医保动态库 HIS登记失败：请撤销医保病号 ，网络支付成功时，请及时撤销网络支付信息");
            //        return false;
            //    }

            //}
            //else if (keyname == CostInsurtypeKeyname.GZSYB.ToString())
            //{

            //    BllInsurIhspGZS bllInsurIhspGZS = new BllInsurIhspGZS();
            //    string errInfo = "";

            //    if (!bllInsurIhspGZS.rydj(personInfo, ihspcode, dtpIndate.Value.ToString("yyyy-MM-dd HH:mm:ss"), ihsp_id, out errInfo))
            //    {
            //        MessageBox.Show("异地医保登记失败，错误原因为：[" + errInfo + "]，！网络支付成功时，请及时撤销网络支付信息");
            //        return false;
            //    }
            //    if (!ihspReg(hisOrderNo, registdate))
            //    {
            //        MessageBox.Show("省医保动态库 HIS登记失败：请撤销医保病号 ，网络支付成功时，请及时撤销网络支付信息");
            //        return false;
            //    }

            //}

            if (!ihspReg(hisOrderNo, registdate))
            {
                MessageBox.Show("HIS登记失败，网络支付成功时，请及时撤销网络支付信息");
                return false;
            }
            if (keyname == CostInsurtypeKeyname.HDSYB.ToString())
            {
                FrmYbRy frmybry = new FrmYbRy();
                frmybry.Zfrydj.Brxm = tbxName.Text.Trim();
                frmybry.Zfrydj.Brnl = tbxAge.Text.Trim();
                frmybry.Zfrydj.Ryks = cmbDepart.SelectedValue.ToString().Trim();
                frmybry.Zfrydj.Ysname = cmbDoctor.SelectedValue.ToString().Trim();
                frmybry.Zfrydj.Rysj = dtpIndate.Text.Trim();
                frmybry.Zfrydj.Zyh = ihspcode;//2019_3_19 修改 --czh
                frmybry.Zfrydj.Brsfzh = tbxIDCard.Text.Trim();
                frmybry.Zfrydj.Mzryzd = tbxDiagnName.Text.Trim();
                frmybry.StartPosition = FormStartPosition.CenterScreen;
                frmybry.ShowDialog(this);
                //if (!bllInsur.hdsybReg(ihsp_id))
                //{
                //    MessageBox.Show("HIS登记失败，网络支付成功时，请及时撤销网络支付信息");
                //    return false;
                //}
            }
            if (keyname == CostInsurtypeKeyname.HDSCH.ToString())
            {
                FrmChRy frmchry = new FrmChRy();
                frmchry.Zfrydj.Brxm = tbxName.Text.Trim();
                frmchry.Zfrydj.Brnl = tbxAge.Text.Trim();
                frmchry.Zfrydj.Ryks = cmbDepart.SelectedValue.ToString().Trim();
                frmchry.Zfrydj.Ysname = cmbDoctor.SelectedValue.ToString().Trim();
                frmchry.Zfrydj.Rysj = dtpIndate.Text.Trim();
                frmchry.Zfrydj.Zyh = ihspcode;//2019_3_19 修改 --czh
                frmchry.Zfrydj.Brsfzh = tbxIDCard.Text.Trim();
                frmchry.Zfrydj.Mzryzd = tbxDiagnName.Text.Trim();
                frmchry.Ylfkfs_id = cmbPatienttype.SelectedValue.ToString().Trim();
                frmchry.StartPosition = FormStartPosition.CenterScreen;
                frmchry.ShowDialog(this);
                //if (!bllInsur.hdsybReg(ihsp_id))
                //{
                //    MessageBox.Show("HIS登记失败，网络支付成功时，请及时撤销网络支付信息");
                //    return false;
                //}
            }
            if (keyname == CostInsurtypeKeyname.HDSSY.ToString())
            {
                FormSyRy frmsyry = new FormSyRy();
                frmsyry.Zfrydj.Brxm = tbxName.Text.Trim();
                frmsyry.Zfrydj.Brnl = tbxAge.Text.Trim();
                frmsyry.Zfrydj.Ryks = cmbDepart.SelectedValue.ToString().Trim();
                frmsyry.Zfrydj.Ysname = cmbDoctor.SelectedValue.ToString().Trim();
                frmsyry.Zfrydj.Rysj = dtpIndate.Text.Trim();
                frmsyry.Zfrydj.Zyh = ihspcode;//2019_3_19 修改 --czh
                frmsyry.Zfrydj.Brsfzh = tbxIDCard.Text.Trim();
                frmsyry.Zfrydj.Mzryzd = tbxDiagnName.Text.Trim();
                frmsyry.StartPosition = FormStartPosition.CenterScreen;
                frmsyry.ShowDialog(this);
                //if (!bllInsur.hdsybReg(ihsp_id))
                //{
                //    MessageBox.Show("HIS登记失败，网络支付成功时，请及时撤销网络支付信息");
                //    return false;
                //}
            }
            if (keyname == CostInsurtypeKeyname.SJZSYB.ToString() || keyname == CostInsurtypeKeyname.SJZSJM.ToString())
            {
                FrmSybRy frmsjzybry = new FrmSybRy();
                frmsjzybry.Zfrydj.Brxm = tbxName.Text.Trim();
                frmsjzybry.Zfrydj.Brnl = tbxAge.Text.Trim();
                frmsjzybry.Zfrydj.Ryks = cmbDepart.Text.ToString().Trim();
                frmsjzybry.Zfrydj.ryks_id = cmbDepart.SelectedValue.ToString().Trim();
                frmsjzybry.Zfrydj.Ysname = cmbDoctor.Text.ToString().Trim();
                frmsjzybry.Zfrydj.ysname_id = cmbDoctor.SelectedValue.ToString().Trim();
                frmsjzybry.Zyjlh = ihsp_id;
                frmsjzybry.Ylfkfs_id = cmbPatienttype.SelectedValue.ToString();
                frmsjzybry.Zfrydj.Rysj = dtpIndate.Text.Trim();
                frmsjzybry.Zfrydj.Zyh = ihspcode;//2019_3_19 修改 --czh
                frmsjzybry.Zfrydj.Brsfzh = tbxIDCard.Text.Trim();
                frmsjzybry.Zfrydj.Mzryzd = tbxDiagnName.Text.Trim();
                frmsjzybry.Zfrydj.Mzryzd_bm = ClininDiagnICD;
                frmsjzybry.StartPosition = FormStartPosition.CenterScreen;
                frmsjzybry.ShowDialog(this);
            }
            //MessageBox.Show("住院登记成功");
            return true;

        }
        private bool doExecNetPay(string currDate, ref string hisOrderNo)
        {
            bool ret = true;
            if (!netpaytype.Equals("-1"))
            {
                NetPayIn netPayIn = new NetPayIn();
                NetPayOut netPayOut = new NetPayOut();
                NetpayBll netpayBll = new NetpayBll();
                string chk_authCode = tbx_authCode.Text.Trim();
                if (chk_authCode.Length < 18)
                {
                    tbx_authCode.Text = "";
                    MessageBox.Show("扫码失败，请重新扫码，后重新支付");
                    tbx_authCode.Focus();
                    return false;
                }
                if (chk_authCode.Length > 18)
                {
                    chk_authCode = chk_authCode.Substring(0, 18);
                }

                netPayIn.AuthCode = chk_authCode;
                netPayIn.Czyh = ProgramGlobal.User_id;
                hisOrderNo = netPayIn.OuterOrderNo = BillSysBase.newBillcode("hisOrderNo");//结算单; 
                netPayIn.Paytype = netpaytype;
                netPayIn.StoreId = "0";
                netPayIn.Subject = "预付款";
                netPayIn.Ddlx = "3";//订单类型（默认1）：1挂号；2缴费；3预交金 
                netPayIn.Ddly = "2";//订单来源（默认1）：1门诊;2住院
                netPayIn.Hzxm = tbxName.Text;
                netPayIn.Lxdh = homephone;
                // netPayIn.Sfzh = tbxIDCard.Text.Trim();
                netPayIn.Ysje = tbxPayfee.Text.Trim();
                netPayIn.Ksmc = cmbDepart.Text;
                NetpayRetRes netpayRetRes = Netpay.execNetPay(netPayIn, netPayOut);

                NetPayData netPayData = new NetPayData();
                netPayData.AppCode = netPayIn.AppCode;
                netPayData.Czyh = netPayIn.Czyh;
                netPayData.Ddlx = netPayIn.Ddlx;
                netPayData.Ddly = netPayIn.Ddly;
                netPayData.InnerOrderNo = netPayOut.InnerOrderNo;
                netPayData.Jylx = "1"; //交易类型： 1正交易；2负交易
                netPayData.Jyrq = currDate;
                netPayData.Ksmc = netPayIn.Ksmc;
                netPayData.MerchantId = netPayIn.MerchantId;
                netPayData.MerId = netPayIn.MerId;
                netPayData.OrgCode = netPayIn.OrgCode;
                netPayData.OuterOrderNo = netPayIn.OuterOrderNo;
                netPayData.Paytype = netPayIn.Paytype;
                netPayData.SourceOuterOrderNo = "";
                netPayData.StoreId = netPayIn.StoreId;
                netPayData.TradeNo = netPayOut.TradeNo;
                netPayData.Ysje = netPayIn.Ysje;
                netPayData.Hzxm = netPayIn.Hzxm;
                netPayData.Sfzh = netPayIn.Sfzh;
                netPayData.Lxdh = netPayIn.Lxdh;
                netPayData.Yymc = ProgramGlobal.HspName;
                netPayData.Zfzt = "1"; //成功
                netPayData.Ihsp_id = ihsp_id;
                string mesg = "";
                if (netpayRetRes.Errcode > 0)
                {
                    mesg = netpayRetRes.Err_mesg + ", 请重试网络支付结算或选择其它非网络支付类型结算!";
                    netPayData.Zfzt = "0";//失败
                    ret = false;
                }
                if (netpayRetRes.Errcode < 0)
                {
                    netPayData.Zfzt = "-1";//失败[支付不确定]
                    ret = false;
                    mesg = "订单号:[" + netPayIn.OuterOrderNo + "]，姓名:[" + netPayData.Hzxm + "]网络支付超时，处于支付故障状态，请及时撤销未结算信息！";
                }
                if (netpayRetRes.Errcode == 0)
                {
                    mesg = "订单号:[" + netPayIn.OuterOrderNo + "]支付成功";
                }
                netpayBll.saveToDb(netPayData);
                MessageBox.Show(mesg);
            }
            return ret;
        }
        /// <summary>
        /// 弹出入院通知书窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIhspNotice_Click(object sender, EventArgs e)
        {
            FrmIhspNotice frmIhspNotice = new FrmIhspNotice(this);
            frmIhspNotice.ShowDialog();
        }

        /// <summary>
        /// 得到入院通知书的返回数据
        /// </summary>
        /// <param name="source"></param>
        public void getSource(string id, string patienType)
        {
            //初始化科室下拉框
            initCmbDepart();

            DataTable dt = billIhspMan.IhspNoticeId(id);
            if (dt.Rows.Count > 0)
            {
                clinic_ihspnotice_id = id;
                register_id = dt.Rows[0]["regist_id"].ToString();
                DataTable dtDiagn = billIhspMan.getNoticediagn(id);
                //先清空疾病文本框和icd
                tbxDiagnName.Text = "";
                ClininDiagnICD = "";
                for (int i = 0; i < dtDiagn.Rows.Count; i++)
                {

                    tbxDiagnName.Text += dtDiagn.Rows[i]["diagnname"].ToString() + ",";
                    ClininDiagnICD += dtDiagn.Rows[i]["diagnICD"].ToString() + ",";
                }
                if (!string.IsNullOrEmpty(tbxDiagnName.Text))
                {
                    tbxDiagnName.Text = tbxDiagnName.Text.Substring(0, tbxDiagnName.Text.Length - 1);
                    ClininDiagnICD = ClininDiagnICD.Substring(0, ClininDiagnICD.Length - 1);
                    this.clininDiagnName = tbxDiagnName.Text;
                }

                this.tbxHspcard.Text = dt.Rows[0]["hspcard"].ToString();
                this.tbxName.Text = dt.Rows[0]["name"].ToString();
                this.cmbSex.SelectedValue = int.Parse(billCmbList.sexid(dt.Rows[0]["sex"].ToString()));
                if (dt.Rows[0]["bas_ihspinstat_id"].ToString() != "")
                {
                    this.cmbIhspinstat.SelectedValue = dt.Rows[0]["bas_ihspinstat_id"].ToString();
                }
                if (dt.Rows[0]["bas_ihspsource_id"].ToString() != "")
                {
                    this.cmbBas_ihspsource.SelectedValue = dt.Rows[0]["bas_ihspsource_id"].ToString();
                }
                this.tbxAge.Text = dt.Rows[0]["age"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["birthday"].ToString()))
                    dtpBirthday.Value = Convert.ToDateTime(dt.Rows[0]["birthday"].ToString());
                string depid = "";
                if (string.IsNullOrEmpty(dt.Rows[0]["depart_id"].ToString()))
                {
                    depid = "0";
                }
                else
                {
                    depid = dt.Rows[0]["depart_id"].ToString();
                }
                this.cmbDepart.SelectedValue = depid;

                this.tbxPayfee.Text = dt.Rows[0]["payfee"].ToString();
                this.tbxIDCard.Text = dt.Rows[0]["idcard"].ToString();
                this.tbxIntroducer.Text = dt.Rows[0]["introducer"].ToString();
                this.tbxLimitamt.Text = "200";
                this.cmbAgeunit.SelectedValue = dt.Rows[0]["ageunit"].ToString();
                if (patienType != "")
                {
                    this.cmbPatienttype.SelectedValue = int.Parse(patienType);
                }
                else
                {
                    this.cmbPatienttype.SelectedValue = 1;
                }
                changeCmbAddress(dt.Rows[0]["hmprovince"].ToString(), dt.Rows[0]["hmcity"].ToString(), dt.Rows[0]["hmcounty"].ToString());
                tbxsubAddress.Text = dt.Rows[0]["hmhouseNumber"].ToString();
                this.member_id = dt.Rows[0]["memid"].ToString();
                //this.tbxCompanyname.Text = dt.Rows[0]["companyname"].ToString();

                this.homephone = dt.Rows[0]["homephone"].ToString();
                this.profession = dt.Rows[0]["profession"].ToString();
                this.profession_id = dt.Rows[0]["profession_id"].ToString();
                this.marriage_id = dt.Rows[0]["marriage_id"].ToString();
            }
        }

        /// <summary>
        /// 取消按钮:关闭本身
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 编辑按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxEdit.Checked)
            {
                tbxIhspcode.Enabled = true;
            }
            else
            {
                tbxIhspcode.Enabled = false;
                tbxIhspcode.Text = BillSysBase.newBillcode("inhospital_ihspcode");
            }
        }

        /// <summary>
        /// 读取医保
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadHealthcard_Click(object sender, EventArgs e)
        {
            sjzDK();
            //ReadHealthcard();
        }

        /// <summary>
        /// 读医保
        /// </summary> 
        public void ReadHealthcard()
        {
            string keyname = bllInsur.getInsurtype(cmbPatienttype.SelectedValue.ToString());
            if (keyname == CostInsurtypeKeyname.HDSYB.ToString())
            {
                hdsyb();
            }
            else if (keyname == CostInsurtypeKeyname.HDSCH.ToString())
            {
                hdsch();
            }
            else if (keyname == CostInsurtypeKeyname.HDSSY.ToString())
            {
                hdssy();
            }
            else if (keyname == CostInsurtypeKeyname.SJZSYB.ToString() || keyname == CostInsurtypeKeyname.SJZSJM.ToString())
            {
                sjzDK();
            }
            //else if (keyname == CostInsurtypeKeyname.HDBHNH.ToString())
            //{
            //    hdsbh();
            //}
            //else if (keyname == CostInsurtypeKeyname.GZSNH.ToString())
            //{
            //   // gzsxnh();
            //    MessageBox.Show("请先按自费登记，然后转医保！");
            //    return;

            //}
            //else if (keyname == CostInsurtypeKeyname.HDXBHNH.ToString())
            //{
            //    FrmMedinsrXBH frmMedinsrXBH = new FrmMedinsrXBH();
            //    frmMedinsrXBH.PatientType = cmbPatienttype.SelectedValue.ToString();
            //    frmMedinsrXBH.ShowDialog();
            //    if (frmMedinsrXBH.DialogResult == DialogResult.OK)
            //    {
            //        this.registinfo = frmMedinsrXBH.Registinfo;
            //        btnOk.Enabled = true;
            //    }
            //}
            //else if (keyname == CostInsurtypeKeyname.AHSJNH.ToString())
            //{
            //    ahsjnh();
            //}
            //else if (keyname == CostInsurtypeKeyname.HDXZRNH.ToString())
            //{

            //}

            //else if (keyname == CostInsurtypeKeyname.HSDRYB.ToString())
            //{
            //    hsdryb();
            //}
            //    //贵阳市
            //else if (keyname == CostInsurtypeKeyname.GYSYB.ToString())
            //{
            //    gysyb();
            //}
            //    //贵州省
            //else if (keyname.Equals(CostInsurtypeKeyname.GZSYB.ToString()))
            //{
            //    gzsyb();
            //}
            //else if (keyname.Equals(CostInsurtypeKeyname.YNSYB.ToString()))
            //{
            //    ynsyb();
            //}
            //else if (keyname.Equals(CostInsurtypeKeyname.YNYDYB.ToString()))
            //{
            //    ynydyb();
            //}
        }
        /// <summary>
        /// 云南省医保
        /// </summary>
        private void ynsyb()
        {
            bool flag = false;
            FrmIhspMedinsrYNSYB frmIhspMedinsrYNSYB = new FrmIhspMedinsrYNSYB();
            frmIhspMedinsrYNSYB.GetEmpInfo_out = this.getEmpInfo_out;
            frmIhspMedinsrYNSYB.Flag = flag;
            frmIhspMedinsrYNSYB.PatientType = this.cmbPatienttype.SelectedValue.ToString();
            frmIhspMedinsrYNSYB.StartPosition = FormStartPosition.CenterScreen;
            frmIhspMedinsrYNSYB.ShowDialog(this);
            if (flag == false)
            {
                return;
            }
            else if (flag == true)
            {
                tbxName.Text = getEmpInfo_out.Xm;
                this.dtpBirthday.Value = Convert.ToDateTime(getEmpInfo_out.Csrq);
                this.tbxIDCard.Text = getEmpInfo_out.Sfzh;
                //this.tbxCompanyname.Text = getEmpInfo_out.Dwmc;
                //tbxDiagnName.Text = getEmpInfo_out.DiseaseName;
                //tbxIhspdiagn.Text = getEmpInfo_out.DiseaseName;
                //tbxClinicicd.Text = getEmpInfo_out.DiseaseCode;
                //tbxIhspicd.Text = getEmpInfo_out.DiseaseCode;
                btnOk.Enabled = true;
            }
        }
        /// <summary>
        /// 云南省异地医保
        /// </summary>
        private void ynydyb()
        {
            FrmYnydybIhspReg frmYnydybIhspReg = new FrmYnydybIhspReg();
            frmYnydybIhspReg.FrmIhspReg = this;
            frmYnydybIhspReg.Patienttype = cmbPatienttype.SelectedValue.ToString();
            frmYnydybIhspReg.FrmIhspReg = this;
            frmYnydybIhspReg.ShowDialog();
            if (frmYnydybIhspReg.DialogResult == DialogResult.OK)
            {
                btnOk.Enabled = true;
            }
        }
        /// <summary>
        /// 贵州省医保
        /// </summary>
        //private void gzsyb()
        //{
        //    bool flag = false;
        //    FrmIhspMedinsurGZS frmIhspMedinsurGZS = new FrmIhspMedinsurGZS();
        //    frmIhspMedinsurGZS.SickName = tbxName.Text;
        //    frmIhspMedinsurGZS.PatientType = cmbPatienttype.SelectedValue.ToString();
        //    frmIhspMedinsurGZS.Sfzfzyb = false;        
        //    frmIhspMedinsurGZS.StartPosition = FormStartPosition.CenterScreen;
        //    frmIhspMedinsurGZS.ShowDialog(this);
        //    this.registinfo = frmIhspMedinsurGZS.Registinfo;
        //    //this.personInfo = frmIhspMedinsurGZS.PersonInfo;
        //    flag = frmIhspMedinsurGZS.Flag;
        //    if (flag == false)
        //    {
        //        return;
        //    }
        //    else if (flag == true)
        //    {
        //        tbxName.Text = personInfo.Swxm;
        //        this.dtpBirthday.Value = Convert.ToDateTime(personInfo.Swcsrq);
        //        this.tbxIDCard.Text = personInfo.Swsfzh;
        //        this.tbxCompanyname.Text = personInfo.Swdwmc;
        //        btnOk.Enabled = true;
        //    }
        //}
        /// <summary>
        /// 贵阳市医保
        /// </summary>
        private void gysyb()
        {
            FrmIhspMedinsrGYSYB frmIhspMedinsrGYSYB = new FrmIhspMedinsrGYSYB();
            frmIhspMedinsrGYSYB.TextBoxxm = tbxName.Text;
            frmIhspMedinsrGYSYB.Sfzfzyb = false;
            frmIhspMedinsrGYSYB.StartPosition = FormStartPosition.CenterScreen;
            frmIhspMedinsrGYSYB.ShowDialog(this);
            if (frmIhspMedinsrGYSYB.flag)
            {
                this.sybdk_entity = frmIhspMedinsrGYSYB.Sybdk_entity;
                tbxName.Text = sybdk_entity.Xm;
                this.dtpBirthday.Value = Convert.ToDateTime(sybdk_entity.Csrq);
                this.tbxIDCard.Text = sybdk_entity.Sfzhm;
                //this.tbxCompanyname.Text = sybdk_entity.Dwmc;
                btnOk.Enabled = true;
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// 安徽市级农合
        /// </summary>
        public void ahsjnh()
        {
            FrmAhsnhIhsp frmAhsnhIhsp = new FrmAhsnhIhsp();
            frmAhsnhIhsp.PatientType = cmbPatienttype.SelectedValue.ToString();
            frmAhsnhIhsp.FrmIhspReg = this;
            frmAhsnhIhsp.ShowDialog();
            if (frmAhsnhIhsp.DialogResult == DialogResult.OK)
            {
                this.tbxName.Text = RegInfo.SPeopName;
                this.tbxIDCard.Text = RegInfo.SIDCardNo;

                this.dtpBirthday.Value = Convert.ToDateTime(RegInfo.SBirthDay);
                this.cmbSex.SelectedValue = RegInfo.SSex;
                btnOk.Enabled = true;
            }
        }

        /// <summary>
        /// 贵州省新农合
        /// </summary>
        public void gzsxnh()
        {
            FrmGzsnhIhsp frmGzsnhIhsp = new FrmGzsnhIhsp();
            frmGzsnhIhsp.FrmIhspReg = this;
            frmGzsnhIhsp.ShowDialog();
            if (frmGzsnhIhsp.DialogResult == DialogResult.OK)
            {

            }
        }
        /// <summary>
        /// 衡水武邑县医保
        /// </summary>
        public void hsdryb()
        {
            FrmIhspMedinsrHSDR frmIhspMedinsrHSDR = new FrmIhspMedinsrHSDR();
            frmIhspMedinsrHSDR.PatientType = cmbPatienttype.SelectedValue.ToString();
            frmIhspMedinsrHSDR.FrmIhspReg = this;
            frmIhspMedinsrHSDR.ShowDialog();
            if (frmIhspMedinsrHSDR.DialogResult == DialogResult.OK)
            {
                this.cmbPatienttype.SelectedValue = insurInfo.PatientType;
                this.tbxName.Text = insurInfo.Name;
                this.tbxIDCard.Text = insurInfo.Idcard;
                //this.tbxCompanyname.Text = insurInfo.Companyname;
                this.dtpBirthday.Value = Convert.ToDateTime(insurInfo.Birth);
                btnOk.Enabled = true;
            }
        }
        /// <summary>
        /// 邯郸市北航农合
        /// </summary>
        public void hdsbh()
        {
            FrmInHspMedinsrHDSNH frmInHspMedinsrHDSNH = new FrmInHspMedinsrHDSNH();
            frmInHspMedinsrHDSNH.PatientType = cmbPatienttype.SelectedValue.ToString();
            frmInHspMedinsrHDSNH.FrmIhspReg = this;
            frmInHspMedinsrHDSNH.ShowDialog();
            if (frmInHspMedinsrHDSNH.DialogResult == DialogResult.OK)
            {
                this.tbxName.Text = HdsbhInfo.Name;
                this.tbxIDCard.Text = HdsbhInfo.Idcard;
                this.cmbSex.SelectedValue = HdsbhInfo.Sex;
                this.dtpBirthday.Value = Convert.ToDateTime(HdsbhInfo.Birthday);
                //this.tbxCompanyname.Text = HdsbhInfo.Companyname;

                btnOk.Enabled = true;
            }
        }

        /// <summary>
        /// 邯郸市城合
        /// </summary>
        public void hdsch()
        {
            if (tbxIDCard.Text.Trim() == "")
            {
                //读人员基本信息和帐户信息
                YBCJ_IN yw_in_ryjbxxhzh = new YBCJ_IN();
                yw_in_ryjbxxhzh.Yw = "AA311012";
                yw_in_ryjbxxhzh.Ybcjbz = "1";
                yw_in_ryjbxxhzh.Ylzh = "0";
                yw_in_ryjbxxhzh.Hisjl = tbxIhspcode.Text.Trim();
                yw_in_ryjbxxhzh.Rc = "";
                int opt_ryjbxxhzh = yw1.ybcjhs(yw_in_ryjbxxhzh);
                if (opt_ryjbxxhzh != 0)
                {
                    //Tbx_tsxx.Text += yw_in_ryjbxxhzh.Mesg + "\r\n";
                    MessageBox.Show(yw_in_ryjbxxhzh.Mesg, "提示信息");
                    return;
                }
                string[] ryjbxxhzh_cc = yw_in_ryjbxxhzh.Cc.Split('|');
                this.tbxName.Text = ryjbxxhzh_cc[4];//姓名
                this.tbxIDCard.Text = ryjbxxhzh_cc[1];//身份证号
                if (ryjbxxhzh_cc[5] == "男")
                {
                    this.cmbSex.SelectedValue = 1;//性别
                }
                this.cmbSex.SelectedValue = 2;//性别
                //this.tbxCompanyname.Text = ryjbxxhzh_cc[38];//单位名称
                string aa = ryjbxxhzh_cc[6];//出生年月

                string year = aa.Substring(0, 4);
                string moths = aa.Substring(4, 2);
                string dys = aa.Substring(6, 2);
                string sj = year + "-" + moths + "-" + dys;
                string Csrq = Convert.ToDateTime(sj).ToString("yyyy-MM-dd HH:mm:ss");//出生日期
                this.dtpBirthday.Value = Convert.ToDateTime(Csrq);
                //FrmHdschIhspReg frmHdschIhspReg = new FrmHdschIhspReg();
                //frmHdschIhspReg.PatientType = cmbPatienttype.SelectedValue.ToString();
                //frmHdschIhspReg.FrmIhspReg = this;
                //frmHdschIhspReg.ShowDialog();
                //if (frmHdschIhspReg.DialogResult == DialogResult.OK)
                //{
                //    this.cmbPatienttype.SelectedValue = InsurInfo.PatientType;
                //    this.tbxName.Text = InsurInfo.Name;
                //    this.tbxIDCard.Text = InsurInfo.Idcard;
                //    this.tbxCompanyname.Text = insurInfo.Companyname;
                //    this.dtpBirthday.Value = Convert.ToDateTime(insurInfo.Birth);
                //    this.tbxName.Text = InsurInfo.Name;
                //    this.dtpBirthday.Value = Convert.ToDateTime(insurInfo.Birth);
                //    btnOk.Enabled = true;
                //}
            }
            else
            {
                //读人员基本信息和帐户信息
                YBCJ_IN yw_in_ryjbxxhzh = new YBCJ_IN();
                yw_in_ryjbxxhzh.Yw = "AA311012";
                yw_in_ryjbxxhzh.Ybcjbz = "1";
                yw_in_ryjbxxhzh.Ylzh = tbxIDCard.Text.Trim();
                yw_in_ryjbxxhzh.Hisjl = tbxIhspcode.Text.Trim();
                yw_in_ryjbxxhzh.Rc = "";
                int opt_ryjbxxhzh = yw1.ybcjhs(yw_in_ryjbxxhzh);
                if (opt_ryjbxxhzh != 0)
                {
                    //Tbx_tsxx.Text += yw_in_ryjbxxhzh.Mesg + "\r\n";
                    MessageBox.Show(yw_in_ryjbxxhzh.Mesg, "提示信息");
                    return;
                }
                string[] ryjbxxhzh_cc = yw_in_ryjbxxhzh.Cc.Split('|');
                this.tbxName.Text = ryjbxxhzh_cc[4];//姓名
                this.tbxIDCard.Text = ryjbxxhzh_cc[1];//身份证号
                this.cmbSex.SelectedValue = ryjbxxhzh_cc[5];//性别
                //this.tbxCompanyname.Text = ryjbxxhzh_cc[38];//单位名称
                string aa = ryjbxxhzh_cc[6];//出生年月

                string year = aa.Substring(0, 4);
                string moths = aa.Substring(4, 2);
                string dys = aa.Substring(6, 2);
                string sj = year + "-" + moths + "-" + dys;
                string Csrq = Convert.ToDateTime(sj).ToString("yyyy-MM-dd HH:mm:ss");//出生日期
                this.dtpBirthday.Value = Convert.ToDateTime(Csrq);
            }
        }
        /// <summary>
        /// 邯郸市医保
        /// </summary>
        public void hdsyb()
        {
            //读人员基本信息和帐户信息
            YBCJ_IN yw_in_ryjbxxhzh = new YBCJ_IN();
            yw_in_ryjbxxhzh.Yw = "AA311012";
            yw_in_ryjbxxhzh.Ybcjbz = "0";
            yw_in_ryjbxxhzh.Ylzh = "0";
            yw_in_ryjbxxhzh.Hisjl = tbxIhspcode.Text.Trim();
            yw_in_ryjbxxhzh.Rc = "";
            int opt_ryjbxxhzh = yw1.ybcjhs(yw_in_ryjbxxhzh);
            if (opt_ryjbxxhzh != 0)
            {
                //Tbx_tsxx.Text += yw_in_ryjbxxhzh.Mesg + "\r\n";
                MessageBox.Show(yw_in_ryjbxxhzh.Mesg, "提示信息");
                return;
            }
            string[] ryjbxxhzh_cc = yw_in_ryjbxxhzh.Cc.Split('|');
            this.tbxName.Text = ryjbxxhzh_cc[4];//姓名
            this.tbxIDCard.Text = ryjbxxhzh_cc[1];//身份证号
            this.cmbSex.SelectedValue = ryjbxxhzh_cc[5];//性别
            //this.tbxCompanyname.Text = ryjbxxhzh_cc[38];//单位名称
            string aa = ryjbxxhzh_cc[6];//出生年月

            string year = aa.Substring(0, 4);
            string moths = aa.Substring(4, 2);
            string dys = aa.Substring(6, 2);
            string sj = year + "-" + moths + "-" + dys;
            string Csrq = Convert.ToDateTime(sj).ToString("yyyy-MM-dd HH:mm:ss");//出生日期
            this.dtpBirthday.Value = Convert.ToDateTime(Csrq);
            //FrmInHspMedinsr frmInHspMedinsr = new FrmInHspMedinsr();
            //frmInHspMedinsr.FrmIhspReg = this;
            //frmInHspMedinsr.PatientType = this.cmbPatienttype.SelectedValue.ToString();
            //frmInHspMedinsr.ShowDialog();
            //if (frmInHspMedinsr.DialogResult == DialogResult.OK)
            //{
            //    this.cmbPatienttype.SelectedValue = InsurInfo.PatientType;
            //    this.tbxName.Text = InsurInfo.Name;
            //    this.tbxIDCard.Text = InsurInfo.Idcard;
            //    this.tbxCompanyname.Text = insurInfo.Companyname;
            //    this.dtpBirthday.Value = Convert.ToDateTime(insurInfo.Birth);
            //    this.tbxName.Text = InsurInfo.Name;
            //    this.dtpBirthday.Value = Convert.ToDateTime(insurInfo.Birth);
            //    btnOk.Enabled = true;
            //}
        }
        public void sjzDK()
        {
            SJZYB_IN<DK_IN> yb_in_dk = new SJZYB_IN<DK_IN>();
            yb_in_dk.INPUT = new List<DK_IN>();
            DK_IN dk = new DK_IN();
            DK_OUT yb_out_dk = new DK_OUT();
            dk.BKA130 = "30";
            yb_in_dk.INPUT.Add(dk);
            yb_in_dk.MSGNO = "1401";
            yb_in_dk.AAC001 = "0";
            //dk_out.sfcf = "0";
            int ret = sjzybInterface.DK(yb_in_dk, ref yb_out_dk);
            if (ret == -1)
            {
                //Tbx_tsxx.Text += yw_in_ryjbxxhzh.Mesg + "\r\n";
                MessageBox.Show(yb_out_dk.ERRORMSG, "提示信息");
                return;
            }
            if (yb_out_dk.CKAA35 == "1")
            {
                MessageBox.Show("该人员是贫困户！", "提示信息");
                com_Poverty.SelectedValue = "5";
            }
            this.tbxName.Text = yb_out_dk.AAC003;//姓名
            this.tbxIDCard.Text = yb_out_dk.AAC002;//身份证号
            this.cmbSex.SelectedValue = int.Parse(yb_out_dk.AAC004);//性别
            string yllb = yb_out_dk.AKC021;
            if (yllb == "41")
            {
                cmbPatienttype.SelectedValue = "35";
            }
            else
            {
                cmbPatienttype.SelectedValue = "34";
            }
            //this.tbxCompanyname.Text = yb_out_dk.AAB004;//单位名称


            string Csrq = Convert.ToDateTime(yb_out_dk.AAC006).ToString("yyyy-MM-dd HH:mm:ss");//出生日期
            this.dtpBirthday.Value = Convert.ToDateTime(Csrq);

        }
        /// <summary>
        /// 邯郸市生育保险
        /// </summary>
        public void hdssy()
        {
            //读人员基本信息和帐户信息
            YBCJ_IN yw_in_ryjbxxhzh = new YBCJ_IN();
            yw_in_ryjbxxhzh.Yw = "AA311012";
            yw_in_ryjbxxhzh.Ybcjbz = "0";
            yw_in_ryjbxxhzh.Ylzh = "0";
            yw_in_ryjbxxhzh.Hisjl = tbxIhspcode.Text.Trim();
            yw_in_ryjbxxhzh.Rc = "";
            int opt_ryjbxxhzh = yw1.ybcjhs(yw_in_ryjbxxhzh);
            if (opt_ryjbxxhzh != 0)
            {
                //Tbx_tsxx.Text += yw_in_ryjbxxhzh.Mesg + "\r\n";
                MessageBox.Show(yw_in_ryjbxxhzh.Mesg, "提示信息");
                return;
            }
            string[] ryjbxxhzh_cc = yw_in_ryjbxxhzh.Cc.Split('|');
            this.tbxName.Text = ryjbxxhzh_cc[4];//姓名
            this.tbxIDCard.Text = ryjbxxhzh_cc[1];//身份证号
            this.cmbSex.SelectedValue = ryjbxxhzh_cc[5];//性别
            //this.tbxCompanyname.Text = ryjbxxhzh_cc[38];//单位名称
            string aa = ryjbxxhzh_cc[6];//出生年月

            string year = aa.Substring(0, 4);
            string moths = aa.Substring(4, 2);
            string dys = aa.Substring(6, 2);
            string sj = year + "-" + moths + "-" + dys;
            string Csrq = Convert.ToDateTime(sj).ToString("yyyy-MM-dd HH:mm:ss");//出生日期
            this.dtpBirthday.Value = Convert.ToDateTime(Csrq);
            //FrmInHspMedinsrHDSSY frmInHspMedinsrHDSSY = new FrmInHspMedinsrHDSSY();
            //frmInHspMedinsrHDSSY.FrmIhspReg = this;
            //frmInHspMedinsrHDSSY.PatientType = this.cmbPatienttype.SelectedValue.ToString();
            //frmInHspMedinsrHDSSY.ShowDialog();
            //if (frmInHspMedinsrHDSSY.DialogResult == DialogResult.OK)
            //{
            //    this.cmbPatienttype.SelectedValue = insurInfo.PatientType;
            //    this.tbxName.Text = insurInfo.Name;
            //    this.tbxIDCard.Text = insurInfo.Idcard;
            //    this.tbxCompanyname.Text = insurInfo.Companyname;
            //    this.dtpBirthday.Value = Convert.ToDateTime(insurInfo.Birth);
            //    this.tbxName.Text = insurInfo.Name;
            //    this.dtpBirthday.Value = Convert.ToDateTime(insurInfo.Birth);
            //    btnOk.Enabled = true;
            //}
        }

        # region 身份证初始化
        private Thread thread;
        #region 关闭线程方法

        /// <summary>
        /// 关闭线程方法
        /// ReWriter:qinYangYang 2014-4-7
        /// </summary>
        /// <param name="param"></param>
        public void CloseSFZXC(object param)
        {
            try
            {
                thread.Abort();
            }
            catch (Exception ex)
            {
                //关闭线程
            }
        }

        #endregion
        #region 开启线程方法

        /// <summary>
        /// 开启线程方法 读身份信息
        /// ReWriter:qinYangYang 2014-4-6
        /// </summary>
        /// <param name="param"></param>
        public static void StartSFZXC(object param)
        {
            string errInfo = "";
            CustomWindowsMessages cwm = new CustomWindowsMessages();
            CardMsgs carmsg = new CardMsgs();
            int iPort = 0;
            while (true)
            {
                if (cwm.SendMessageInfo(ref iPort))
                {
                    break;
                }
                SysWriteLogs.SleepTimes(1200);
            }

        }

        #endregion
        #region 初始化身份证信息

        /// <summary>
        ///  初始化身份证信息
        ///  Writer:qinYangYang 2014/4/8
        /// </summary>
        public void initidCardInfo()
        {
            this.btnReadIDCard.Enabled = true;
            this.tbxName.Text = "";//姓名
            cmbSex.Text = "";//性别
            this.dtpBirthday.Value = Convert.ToDateTime(BillSysBase.currDate().ToString());//出生日期;

            tbxIDCard.Text = "";//身份证号
        }
        #endregion
        /************************端口类API *************************/
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_GetCOMBaud", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetCOMBaud(int iPort, ref uint puiBaudRate);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetCOMBaud", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetCOMBaud(int iPort, uint uiCurrBaud, uint uiSetBaud);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_OpenPort", CharSet = CharSet.Ansi)]
        public static extern int Syn_OpenPort(int iPort);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ClosePort", CharSet = CharSet.Ansi)]
        public static extern int Syn_ClosePort(int iPort);
        /**************************SAM类函数 **************************/
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetMaxRFByte", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetMaxRFByte(int iPort, byte ucByte, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ResetSAM", CharSet = CharSet.Ansi)]
        public static extern int Syn_ResetSAM(int iPort, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_GetSAMStatus", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetSAMStatus(int iPort, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_GetSAMID", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetSAMID(int iPort, ref byte pucSAMID, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_GetSAMIDToStr", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetSAMIDToStr(int iPort, ref byte pcSAMID, int iIfOpen);
        /*************************身份证卡类函数 ***************************/
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_StartFindIDCard", CharSet = CharSet.Ansi)]
        public static extern int Syn_StartFindIDCard(int iPort, ref byte pucIIN, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SelectIDCard", CharSet = CharSet.Ansi)]
        public static extern int Syn_SelectIDCard(int iPort, ref byte pucSN, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadBaseMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadBaseMsg(int iPort, ref byte pucCHMsg, ref uint puiCHMsgLen, ref byte pucPHMsg, ref uint puiPHMsgLen, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadBaseMsgToFile", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadBaseMsgToFile(int iPort, ref byte pcCHMsgFileName, ref uint puiCHMsgFileLen, ref byte pcPHMsgFileName, ref uint puiPHMsgFileLen, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadBaseFPMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadBaseFPMsg(int iPort, ref byte pucCHMsg, ref uint puiCHMsgLen, ref byte pucPHMsg, ref uint puiPHMsgLen, ref byte pucFPMsg, ref uint puiFPMsgLen, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadBaseFPMsgToFile", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadBaseFPMsgToFile(int iPort, ref byte pcCHMsgFileName, ref uint puiCHMsgFileLen, ref byte pcPHMsgFileName, ref uint puiPHMsgFileLen, ref byte pcFPMsgFileName, ref uint puiFPMsgFileLen, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadNewAppMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadNewAppMsg(int iPort, ref byte pucAppMsg, ref uint puiAppMsgLen, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_GetBmp", CharSet = CharSet.Ansi)]
        public static extern int Syn_GetBmp(int iPort, ref byte Wlt_File);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadMsg(int iPortID, int iIfOpen, ref IDCardData pIDCardData);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadFPMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadFPMsg(int iPortID, int iIfOpen, ref IDCardData pIDCardData, ref byte cFPhotoname);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_FindReader", CharSet = CharSet.Ansi)]
        public static extern int Syn_FindReader();
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_FindUSBReader", CharSet = CharSet.Ansi)]
        public static extern int Syn_FindUSBReader();
        /***********************设置附加功能函数 ************************/
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetPhotoPath", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetPhotoPath(int iOption, ref byte cPhotoPath);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetPhotoType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetPhotoType(int iType);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetPhotoName", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetPhotoName(int iType);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetSexType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetSexType(int iType);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetNationType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetNationType(int iType);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetBornType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetBornType(int iType);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetUserLifeBType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetUserLifeBType(int iType);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetUserLifeEType", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetUserLifeEType(int iType, int iOption);
        public struct IDCardData
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string Name; //姓名   
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
            public string Sex;   //性别
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
            public string Nation; //名族
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
            public string Born; //出生日期
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 72)]
            public string Address; //住址
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 38)]
            public string IDCardNo; //身份证号
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string GrantDept; //发证机关
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
            public string UserLifeBegin; // 有效开始日期
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
            public string UserLifeEnd;  // 有效截止日期
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 38)]
            public string reserved; // 保留
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
            public string PhotoFileName; // 照片路径
        }
        #endregion
        /// <summary>
        /// 读取身份证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadIDCard_Click(object sender, EventArgs e)
        {

            initidCardInfo();
            int m_iPort;
            int i;
            uint[] iBaud = new uint[1];
            i = Syn_FindReader();
            m_iPort = i;


            IDCardData CardMsg = new IDCardData();
            int nRet, nPort, iPhotoType;
            string stmp;
            byte[] cPath = new byte[255];
            byte[] pucIIN = new byte[4];
            byte[] pucSN = new byte[8];
            nPort = m_iPort;
            //Syn_SetPhotoPath(0, ref cPath[0]);	//设置照片路径	iOption 路径选项	0=C:	1=当前路径	2=指定路径
            ////cPhotoPath	绝对路径,仅在iOption=2时有效
            //iPhotoType = 0;
            Syn_SetPhotoType(4); //0 = bmp ,1 = jpg , 2 = base64 , 3 = WLT ,4 = 不生成
            //Syn_SetPhotoName(2); // 生成照片文件名 0=tmp 1=姓名 2=身份证号 3=姓名_身份证号 

            Syn_SetSexType(1);	// 0=卡中存储的数据	1=解释之后的数据,男、女、未知
            Syn_SetNationType(2);// 0=卡中存储的数据	1=解释之后的数据 2=解释之后加"族"
            Syn_SetBornType(3);			// 0=YYYYMMDD,1=YYYY年MM月DD日,2=YYYY.MM.DD,3=YYYY-MM-DD,4=YYYY/MM/DD
            Syn_SetUserLifeBType(3);	// 0=YYYYMMDD,1=YYYY年MM月DD日,2=YYYY.MM.DD,3=YYYY-MM-DD,4=YYYY/MM/DD
            Syn_SetUserLifeEType(1, 1);	// 0=YYYYMMDD(不转换),1=YYYY年MM月DD日,2=YYYY.MM.DD,3=YYYY-MM-DD,4=YYYY/MM/DD,
            // 0=长期 不转换,	1=长期转换为 有效期开始+50年           
            if (Syn_OpenPort(nPort) == 0)
            {
                if (Syn_SetMaxRFByte(nPort, 80, 0) == 0)
                {
                    nRet = Syn_StartFindIDCard(nPort, ref pucIIN[0], 0);
                    nRet = Syn_SelectIDCard(nPort, ref pucSN[0], 0);
                    nRet = Syn_ReadMsg(nPort, 0, ref CardMsg);
                    if (nRet == 0)
                    {

                        //姓名
                        this.tbxName.Text = CardMsg.Name.ToString();

                        //性别
                        string sex = (CardMsg.Sex == "男") ? "M" : "W";
                        cmbSex.Text = CardMsg.Sex;

                        //民族
                        this.cmbRace.Text = CardMsg.Nation;

                        //出生日期
                        DateTime time = Convert.ToDateTime(CardMsg.Born);
                        this.dtpBirthday.Value = time;
                        //this.dtpBirthday.Value = Convert.ToDateTime(date);
                        //stmp = Convert.ToString(System.DateTime.Now) + "  地址:" + CardMsg.Address;
                        //listBox1.Items.Add(stmp);
                        ////地址
                        int s = CardMsg.Address.Length;
                        cmbProvince.Text = CardMsg.Address.Substring(0, 3);
                        cmbCity.Text = CardMsg.Address.Substring(3, 3);
                        cmbCounty.Text = CardMsg.Address.Substring(6, 3);
                        tbxsubAddress.Text = CardMsg.Address.Substring(9, s - 10);
                        //stmp = Convert.ToString(System.DateTime.Now) + "  身份证号:" + CardMsg.IDCardNo;
                        //listBox1.Items.Add(stmp);
                        ////身份证号
                        this.tbxIDCard.Text = CardMsg.IDCardNo;

                    }
                    else
                    {
                        MessageBox.Show("读取身份证信息错误");
                    }
                }
            }
            else
            {
                MessageBox.Show("打开端口失败");
            }
            CloseSFZXC(null);
        }
        /// <summary>
        /// 读取身份证信息
        /// </summary>
        public void readIdcard()
        {
            IdCardInfo idCardInfo = new IdCardInfo();
            idCardInfo.readInsurCard();
            this.tbxIDCard.Text = idCardInfo.Idcard;
            this.tbxName.Text = idCardInfo.Name;
            this.cmbSex.Text = idCardInfo.Sex;

            cmbSex.Text = idCardInfo.Sex;
            this.dtpBirthday.Value = Convert.ToDateTime(idCardInfo.Birth);
        }
        /// <summary>
        /// 出生日期改变--年龄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpBirthday_ValueChanged(object sender, EventArgs e)
        {
            if (ischarge == false)
            {
                DateTime birth = dtpBirthday.Value;
                DateTime current = Convert.ToDateTime(BillSysBase.currDate());
                Sickages yea = DateDiff(current, birth);
                
                
                if (yea.Ageunit.ToString() == "岁")
                {
                    tbxAge.Text = yea.Cur_values.ToString();
                    this.cmbAgeunit.SelectedValue = (int)AgeUnit.AGE;
                }
                if (yea.Ageunit.ToString() == "月")
                {
                    //tbxAge.Text = "0";
                    tbxAge.Text = yea.Cur_values.ToString();
                    this.cmbAgeunit.SelectedValue = (int)AgeUnit.MOON;
                }
                
            }
        }
        
        /// <summary>
        /// 根据出生日期算出实岁
        /// </summary>
        /// <param name="dateTime1"></param>
        /// <param name="dateTime2"></param>
        /// <returns></returns>
        public Sickages DateDiff(DateTime dateTime1, DateTime dateTime2)
        {
            Sickages sickage = new Sickages();

            if (dateTime2.Year == 1900)
            {
                sickage.Ageunit = "岁";
                return sickage;
            }

            string dateTime1Str = dateTime1.ToString("yyyy-MM-dd HH:mm:ss");//当天日期
            string dateTime2Str = dateTime2.ToString("yyyy-MM-dd HH:mm:ss");//出生日期

            string[] time1_s1 = dateTime1Str.Split(' ');
            string[] time1_Date_s = new string[5];
            string[] time1_Time_s = new string[5];
            if (time1_s1.Length >= 2)
            {
                time1_Date_s = time1_s1[0].Split('-');
                time1_Time_s = time1_s1[1].Split(':');
            }
            string[] time2_s1 = dateTime2Str.Split(' ');
            string[] time2_Date_s = new string[5];
            string[] time2_Time_s = new string[5];
            if (time2_s1.Length >= 2)
            {
                time2_Date_s = time2_s1[0].Split('-');
                time2_Time_s = time2_s1[1].Split(':');
            }
            if (time1_Date_s.Length >= 3 && time2_Date_s.Length >= 3)
            {
                if (time1_Date_s[0] == time2_Date_s[0])
                {
                    if (time1_Date_s[1] == time2_Date_s[1])
                    {
                        if (time1_Date_s[2] == time2_Date_s[2])
                        {
                            if (time1_Time_s[0] == time2_Time_s[0])
                            {
                                int dateTiem1_H_int = Convert.ToInt32(time1_Time_s[0]);
                                int dateTiem2_H_int = Convert.ToInt32(time2_Time_s[0]);
                                sickage.Cur_values = dateTiem1_H_int - dateTiem2_H_int;
                                sickage.Ageunit = "时";
                            }
                            else
                            {
                                int dateTiem1_H_int = Convert.ToInt32(time1_Time_s[0]);
                                int dateTiem2_H_int = Convert.ToInt32(time2_Time_s[0]);
                                sickage.Cur_values = dateTiem1_H_int - dateTiem2_H_int;
                                sickage.Ageunit = "时";
                            }
                        }
                        else
                        {
                            int dateTiem1_D_int = Convert.ToInt32(time1_Date_s[2]);
                            int dateTiem2_D_int = Convert.ToInt32(time2_Date_s[2]);
                            sickage.Cur_values = dateTiem1_D_int - dateTiem2_D_int;
                            sickage.Ageunit = "日";
                        }
                    }
                    else
                    {
                        int dateTiem1_M_int = Convert.ToInt32(time1_Date_s[1]);
                        int dateTiem2_M_int = Convert.ToInt32(time2_Date_s[1]);
                        sickage.Cur_values = dateTiem1_M_int - dateTiem2_M_int;
                        sickage.Ageunit = "月";
                    }
                }
                else
                {
                    int dateTiem1_Y_int = Convert.ToInt32(time1_Date_s[0]);
                    int dateTiem2_Y_int = Convert.ToInt32(time2_Date_s[0]);
                    int age = DateTime.Now.Year - dateTime2.Year;
                    if (DateTime.Now.Month < dateTime2.Month || (DateTime.Now.Month == dateTime2.Month && DateTime.Now.Day < dateTime2.Day)) age--;
                    TimeSpan ts = DateTime.Now - dateTime2;
                    string ages = age == 0 ? "-" + ts.Days : age.ToString();
                    sickage.Cur_values = age;
                    sickage.Ageunit = "岁";
                }
            }
            return sickage;
        }
        /// <summary>
        /// 年龄单位变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbAgeunit_SelectedIndexChanged(object sender, EventArgs e)
        {
            ischarge = true;
            if (!string.IsNullOrEmpty(tbxAge.Text))
            {
                if (int.Parse(tbxAge.Text) >= 1 && int.Parse(tbxAge.Text) < 3 && (int)cmbAgeunit.SelectedValue == (int)AgeUnit.AGE)
                {
                    cmbMonth.Visible = true;
                    tbxMonAge.Visible = true;
                }
                else
                {
                    cmbMonth.Visible = false;
                    tbxMonAge.Visible = false;
                }
                ageChanged();
            }
            ischarge = false;
        }
        /// <summary>
        /// 月变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxMonAge_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxMonAge.Text))
            {
                tbxMonAge.Text = "0";
                tbxMonAge.SelectAll();
            }
            if (!Regex.IsMatch(tbxMonAge.Text, @"^([1-9]\d+|[0-9])(\.\d\d?)?$"))
            {
                MessageBox.Show("提示：年龄填写格式有误!");
                this.tbxMonAge.Focus();
                this.tbxMonAge.Text = "1";
                return;
            }
            else
            {
                if (int.Parse(tbxMonAge.Text.Trim()) >= 12)
                {
                    MessageBox.Show("月数不能大于12");
                    tbxMonAge.Text = "0";
                    tbxMonAge.SelectAll();
                }
            }
            ischarge = true;
            string age = tbxMonAge.Text.ToString();
            string currentYear = Convert.ToDateTime(BillSysBase.currDate()).Year.ToString();
            string currentMonth = Convert.ToDateTime(BillSysBase.currDate()).Month.ToString();
            string currentDay = Convert.ToDateTime(BillSysBase.currDate()).Day.ToString();
            string birthYear = dtpBirthday.Value.Year.ToString();
            string birthMonth = (int.Parse(currentMonth)).ToString();
            string birthDay = (int.Parse(currentDay)).ToString();
            string Year = (int.Parse(age) / 12).ToString();
            string Month = (int.Parse(age) % 12).ToString();

            birthMonth = (int.Parse(currentMonth) - int.Parse(Month)).ToString();
            if (int.Parse(birthMonth) <= 0)
            {
                birthMonth = (int.Parse(birthMonth) + 12).ToString();
                birthYear = (int.Parse(birthYear) - 1).ToString();
            }
            birthYear = (int.Parse(birthYear) - int.Parse(Year)).ToString();
            if (int.Parse(birthMonth) == 4 || int.Parse(birthMonth) == 6 || int.Parse(birthMonth) == 9 || int.Parse(birthMonth) == 11)
            {
                if (int.Parse(birthDay) == 31)
                {
                    birthMonth = (int.Parse(birthMonth) + 1).ToString();
                    birthDay = "1";
                }
            }
            if (int.Parse(birthMonth) == 2)
            {
                if ((int.Parse(birthYear) % 4 == 0 && int.Parse(birthYear) % 100 != 0) || (int.Parse(birthYear) % 400 == 0))
                {
                    if (int.Parse(birthDay) == 30 || int.Parse(birthDay) == 31)
                    {
                        birthDay = "29";
                    }
                }
                else
                {
                    if (int.Parse(birthDay) == 30 || int.Parse(birthDay) == 29 || int.Parse(birthDay) == 31)
                    {
                        birthDay = "28";
                    }
                }
            }
            dtpBirthday.Value = Convert.ToDateTime(birthYear + "-" + birthMonth + "-" + birthDay);
            ischarge = false;
        }
        /// <summary>
        /// 年龄数值发生改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxAge_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(tbxAge.Text))
            {
                tbxAge.Text = "0";
                tbxAge.SelectAll();
                //tbxAge.SelectionStart = tbxAge.Text.Length;
            }
            if (!Regex.IsMatch(tbxAge.Text, @"^([1-9]\d+|[0-9])(\.\d\d?)?$"))
            {
                MessageBox.Show("提示：年龄填写格式有误!");
                this.tbxAge.Focus();
                this.tbxAge.Text = "1";
                return;
            }
            ischarge = true;
            #region 2020.11.06 暴要求取消
            if ((int)cmbAgeunit.SelectedValue == (int)AgeUnit.AGE)
            {
                if (int.Parse(tbxAge.Text.Trim()) > 150)
                {
                    MessageBox.Show("年龄不得大于150");
                    tbxAge.Clear();
                    tbxAge.SelectAll();
                }
                if (int.Parse(tbxAge.Text.Trim()) < 3 && int.Parse(tbxAge.Text.Trim()) >= 0)
                {
                    tbxMonAge.Visible = true;
                    cmbMonth.Visible = true;
                }
                else
                {
                    tbxMonAge.Visible = false;
                    cmbMonth.Visible = false;
                }
            }
            else
            {
                tbxMonAge.Visible = false;
                cmbMonth.Visible = false;
            }
            if ((int)cmbAgeunit.SelectedValue == (int)AgeUnit.MOON)
            {
                if (int.Parse(tbxAge.Text.Trim()) > 12)
                {
                    cmbAgeunit.SelectedValue = (int)AgeUnit.AGE;
                    tbxAge.Text = "1";
                    tbxAge.SelectAll();
                }
            }
            if ((int)cmbAgeunit.SelectedValue == (int)AgeUnit.DAY)
            {
                if (int.Parse(tbxAge.Text.Trim()) > 30)
                {
                    cmbAgeunit.SelectedValue = (int)AgeUnit.MOON;
                    tbxAge.Text = "1";
                    tbxAge.SelectAll();
                }
            }
            if ((int)cmbAgeunit.SelectedValue == (int)AgeUnit.HOUR)
            {
                if (int.Parse(tbxAge.Text.Trim()) > 72)
                {
                    cmbAgeunit.SelectedValue = (int)AgeUnit.DAY;
                    tbxAge.Text = "3";
                    tbxAge.SelectAll();
                }
            }
            int i = DateTime.Now.Year - int.Parse(tbxAge.Text) - dtpBirthday.Value.Year;
            if (!(i < 2 && i > -2))
            {
                ageChanged();
            }
            ischarge = false;
            #endregion
        }
        /// <summary>
        /// 计算出生日期
        /// </summary>
        private void ageChanged()
        {
            string monthDay = "";
            string age = tbxAge.Text.ToString();
            if (age != null && !age.Equals("") && Regex.IsMatch(age, @"^[+-]?\d*$"))
            {
                string currentYear = Convert.ToDateTime(BillSysBase.currDate()).Year.ToString();
                string currentMonth = Convert.ToDateTime(BillSysBase.currDate()).Month.ToString();
                string currentDay = Convert.ToDateTime(BillSysBase.currDate()).Day.ToString();
                string birthYear = (int.Parse(currentYear)).ToString();
                string birthMonth = (int.Parse(currentMonth)).ToString();
                string birthDay = (int.Parse(currentDay)).ToString();

                if ((int)cmbAgeunit.SelectedValue == (int)AgeUnit.AGE)
                {
                    birthYear = (int.Parse(currentYear) - int.Parse(age)).ToString();
                    birthMonth = dtpBirthday.Value.Month.ToString();
                    birthDay = dtpBirthday.Value.Day.ToString();
                }
                else if ((int)cmbAgeunit.SelectedValue == (int)AgeUnit.MOON)
                {
                    string Year = (int.Parse(age) / 12).ToString();
                    string Month = (int.Parse(age) % 12).ToString();

                    birthMonth = (int.Parse(currentMonth) - int.Parse(Month)).ToString();
                    if (int.Parse(birthMonth) <= 0)
                    {
                        birthMonth = (int.Parse(birthMonth) + 12).ToString();
                        birthYear = (int.Parse(birthYear) - 1).ToString();
                    }
                    birthYear = (int.Parse(birthYear) - int.Parse(Year)).ToString();
                }
                else if ((int)cmbAgeunit.SelectedValue == (int)AgeUnit.DAY)
                {
                    birthDay = (int.Parse(currentDay) - int.Parse(age)).ToString();
                    while (int.Parse(birthDay) <= 0)
                    {
                        monthDay = getMonthDay(birthMonth, birthYear);
                        birthDay = (int.Parse(birthDay) + int.Parse(monthDay)).ToString();
                        birthMonth = (int.Parse(birthMonth) - 1).ToString();
                        if (int.Parse(birthMonth) <= 0)
                        {
                            birthMonth = (int.Parse(birthMonth) + 12).ToString();
                            birthYear = (int.Parse(birthYear) - 1).ToString();
                        }
                    }
                }
                else if ((int)cmbAgeunit.SelectedValue == (int)AgeUnit.HOUR)
                {
                    string Day = (int.Parse(age) / 24).ToString();
                    birthDay = (int.Parse(currentDay) - int.Parse(Day)).ToString();
                    if (int.Parse(birthDay) < 0)
                    {
                        birthDay = (int.Parse(birthDay) + 30).ToString();
                    }

                }
                if (int.Parse(birthMonth) == 2)
                {
                    if ((int.Parse(birthYear) % 4 == 0 && int.Parse(birthYear) % 100 != 0) || (int.Parse(birthYear) % 400 == 0))
                    {
                        if (int.Parse(birthDay) == 30 || int.Parse(birthDay) == 31)
                        {
                            birthDay = "29";
                        }
                    }
                    else
                    {
                        if (int.Parse(birthDay) == 30 || int.Parse(birthDay) == 29 || int.Parse(birthDay) == 31)
                        {
                            birthDay = "28";
                        }
                    }
                }
                dtpBirthday.Value = Convert.ToDateTime(birthYear + "-" + birthMonth + "-" + birthDay);
            }
            else
            {
                MessageBox.Show("年龄输入有误");
                return;
            }
        }
        /// <summary>
        /// 获取前一个月有多少天
        /// </summary>
        /// <param name="birthMonth">当前的月</param>
        /// <param name="birthYear">当前的年</param>
        /// <returns></returns>
        public string getMonthDay(string birthMonth, string birthYear)
        {
            string monthDay = "";
            string monthy = (int.Parse(birthMonth) - 1).ToString();
            if (monthy == "1")
            {
                monthy = "12";
                birthYear = (int.Parse(birthYear) - 1).ToString();
            }
            if (monthy == "1" || monthy == "3" || monthy == "5" || monthy == "7" || monthy == "8" || monthy == "10" || monthy == "12")
            {
                monthDay = "31";
            }
            else if (monthy == "2")
            {
                if ((int.Parse(birthYear) % 4 == 0 && int.Parse(birthYear) % 100 != 0) || (int.Parse(birthYear) % 400 == 0))
                {
                    monthDay = "29";
                }
                else
                {
                    monthDay = "28";
                }
            }
            else
            {
                monthDay = "30";
            }
            return monthDay;
        }

        #region 控件回车事件

        ///<summary>
        ///当点击回车键时，焦点在控件中一次传递
        ///</summary>
        ///<param name="keyData"></param>
        ///<returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if ((ActiveControl is System.Windows.Forms.Button) && (keyData == Keys.Enter))
            {
                if (ActiveControl == btnIhspNotice)
                {
                    this.tbxHspcard.Focus();
                    return base.ProcessDialogKey(keyData);
                }
                keyData = Keys.Tab;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void btnIhspNotice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                FrmIhspNotice frmIhspNotice = new FrmIhspNotice(this);
                frmIhspNotice.ShowDialog();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                dtpIndate.Focus();
            }

        }

        private void tbxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbSex.Focus();

            }
        }



        private void cmbBas_patienttype_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (btnReadHealthcard.Enabled == false)
                {
                    dtpBirthday.Focus();

                    //显示鼠标指针  
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.IBeam;
                    //保持鼠标指针形状  
                    Cursor = System.Windows.Forms.Cursors.Default;
                }
                else
                {
                    this.btnReadHealthcard.Focus();
                }
            }
        }
        private void btnReadHealthcard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtpBirthday.Focus();

            }
            else if (e.KeyCode == Keys.Space)
            {
                ReadHealthcard();
            }

        }

        private void cmbIhspinstat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxIhspsn.Focus();
            }
        }

        private void tbxIDCard_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Enter)
            {
                if (!checkIdCard())
                {
                    tbxIDCard.Focus();
                }
                else
                {
                    btnReadIDCard.Focus();

                }

            }
        }
        //身份证检查校验自动生成 年龄 与 出生年月
        public bool checkIdCard()
        {

            //正则表达式 身份证验证出生年月日要合法
            //身份证号18位正则表达式
            Regex reg18 = new Regex(@"^([1-9]{1}\d{5}[1-2]{1}[09]{1}\d{2}(([0]{1}[1-9]{1})|([1]{1}[012]{1}))(([0]{1}[1-9]{1})|([12]{1}\d{1})|([3]{1}[01]{1}))(\d{4}|(\d{3}[x]{1})|(\d{3}[X]{1})))$");
            //身份证15位正则表达式
            Regex reg15 = new Regex(@"^([1-9]{1}\d{5}\d{2}(([0]{1}[1-9]{1})|([1]{1}[012]{1}))(([0]{1}[1-9]{1})|([12]{1}\d{1})|([3]{1}[01]{1}))\d{3})$");

            if (string.IsNullOrEmpty(tbxIDCard.Text) || string.IsNullOrWhiteSpace(tbxIDCard.Text))
            {
                dtpBirthday.Focus();
                return true;
            }
            string idCard = tbxIDCard.Text.Trim();
            //身份证判断
            if (!reg18.IsMatch(idCard))
            {
                MessageBox.Show("请输入正确的身份证号，请重新输入！");

                return false;
            }
            if (!idCardEcho())
                return false;

            string county = idCard.Substring(0, 6);
            string city = county.Substring(0, 4) + "00";
            string province = city.Substring(0, 2) + "0000";
            changeCmbAddress(province, city, county);
            return true;
        }
        /// <summary>
        /// 身份证号得到出生日期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private bool idCardEcho()
        {
            string idCard = tbxIDCard.Text.Trim();
            if (idCard == "")
            {
                return false;
            }
            string year = "";
            string month = "";
            string day = "";
            string sex = "";
            string birthday = "";
            if (idCard.Length == 15)
            {
                year = idCard.Substring(6, 2);
                year = "19" + year;
                month = idCard.Substring(8, 2);
                day = idCard.Substring(10, 2);
                sex = idCard.Substring(12, 3);
            }
            else if (idCard.Length == 18)
            {
                year = idCard.Substring(6, 4);
                month = idCard.Substring(10, 2);
                day = idCard.Substring(12, 2);
                sex = idCard.Substring(14, 3);
            }

            birthday = year + "-" + month + "-" + day;
            DateTime birth = new DateTime();
            try
            {
                birth = DateTime.ParseExact(birthday, "yyyy-MM-dd", null);
            }
            catch (Exception e)
            {
                MessageBox.Show("身份证出生年月输入不合法，请重新输入！");
                this.tbxIDCard.Focus();
                return false;
            }
            dtpBirthday.Value = birth;
            if (int.Parse(sex) % 2 == 0)//性别代码为偶数是女性奇数为男性
            {
                this.cmbSex.Text = "女";
            }
            else
            {
                this.cmbSex.Text = "男";
            }
            return true;
        }
        private void tbxClinicicd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxAge.Focus();
            }
        }

        private void cmbSex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tbxAge.Focus();
            }
        }

        private void tbxIhspicd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtpBirthday.Focus();
            }
        }

        private void cmbIhspoutstat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

            }
        }

        private void tbxAge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cmbRace.Focus();

                this.cmbRace.DroppedDown = true;
            }
        }

        private void cmbAgeunit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbxMonAge.Visible)
                {
                    this.tbxMonAge.Focus();
                }
                else
                {
                    this.dtpBirthday.Focus();
                }
            }
        }
        private void tbxMonAge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtpBirthday.Focus();
            }
        }
        private void dtpBirthday_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //i++;
                //SendKeys.Send("{right}");
                //if (i == 3)
                //{
                //    SendKeys.Send("{tab}");
                //    i = 0;
                //}
                cmbProvince.Focus();
                cmbProvince.DroppedDown = true;

            }
        }

        private void dtpIndate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //i++;
                //SendKeys.Send("{right}");
                //if (i == 3)
                //{
                //    SendKeys.Send("{tab}");
                //    i = 0;
                //}
                tbxName.Focus();
            }
        }


        private void tbxCompanyname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cmbBas_ihspsource.Focus();
                this.cmbBas_ihspsource.DroppedDown = true;
            }
        }

        private void cmbDoctor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxIntroducer.Focus();
            }
        }

        private void cmbCostclass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxPayfee.Focus();
            }
        }

        private void tbxLimitamt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tbxPayfee.Focus();
            }
        }

        private void tbxPrepamt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxPayMan.Focus();
            }
        }

        private void cmbBas_ihspsource_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbIhspinstat.Focus();
            }
        }

        private void tbxHspcontacter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd.Focus();
            }
        }

        private void cmbPayType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnOk.Focus();
            }
        }

        private void btnOk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                doRegist();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                btnCancel.Focus();
            }
        }

        private void btnCancel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                tbxHspcard.Focus();
            }
        }
        #endregion

        /// <summary>
        /// 医保类型变化时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBas_patienttype_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (cmbPatienttype.DataSource != null)
            //{
            //    string keyname = bllInsur.getInsurtype(cmbPatienttype.SelectedValue.ToString());
            //    if (keyname != CostInsurtypeKeyname.SELFCOST.ToString())
            //    {
            //        btnReadHealthcard.Enabled = true;
            //        btnOk.Enabled = true;
            //    }
            //    else if (keyname == CostInsurtypeKeyname.SELFCOST.ToString())
            //    {
            //        btnReadHealthcard.Enabled = false;
            //        btnOk.Enabled = true;
            //    }
            //}
        }


        private void FrmIhspReg_Shown(object sender, EventArgs e)
        {
            tbxHspcard.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addMethod();
        }
        private void addMethod()
        {
            ClininDiagnName = tbxDiagnName.Text;
            FrmDiagn frmDiagn = new FrmDiagn();
            frmDiagn.FrmIhspReg = this;
            frmDiagn.ShowDialog();
            if (frmDiagn.DialogResult == DialogResult.OK)
            {
                tbxDiagnName.Text = ClininDiagnName;
                ClininDiagnICD = ClininDiagnICD;
            }
        }

        private void tbxDiagnName_TextChanged(object sender, EventArgs e)
        {
            toolTip();
        }
        private void toolTip()
        {
            ToolTip ttpDiagn = new ToolTip();
            ttpDiagn.AutoPopDelay = 10 * 1000;
            ttpDiagn.ReshowDelay = 200;
            ttpDiagn.ShowAlways = true;
            ttpDiagn.IsBalloon = true;

            string tipOverwrite = tbxDiagnName.Text;
            ttpDiagn.SetToolTip(tbxDiagnName, tipOverwrite);
        }

        private void btnAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                tbxPayfee.Focus();


            }
            if (e.KeyCode == Keys.Space)
            {
                addMethod();
            }
        }

        private void timerIdcard_Tick(object sender, EventArgs e)
        {
            return;
            if (tbxIDCard.Text.Trim() == "" || tbxIDCard.Text.Trim().Length < 15)
            {
                if (this.falg)
                {
                    this.nport = cardmsgs.NPort;

                    if (!(CardInterface.OpenPort(this.nport) == 0))
                    {
                        String stmp = "打开端口失败";
                        cardmsgs.Message = stmp;
                        return;
                    }
                    if (GetIdCardInfo.Hqxx(cardmsgs, this.nport))
                    {
                        tbxName.Text = cardmsgs.Name.Trim();
                        if (cardmsgs.Sex.Equals("1"))
                        {
                            cmbSex.Text = "男";
                        }
                        else
                        {
                            cmbSex.Text = "女";
                        }
                        dtpBirthday.Value = DateTime.ParseExact(cardmsgs.Born, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);

                        tbxIDCard.Text = cardmsgs.IdCarNo.Trim();
                        MessageBox.Show("读取身份证成功!");
                    }
                }
            }
        }

        private void tbxHspcard_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//读卡号 要判断 e 是否为回车
            {
                string hspCard = tbxHspcard.Text.Trim();
                if (hspCard.Length > 2)
                {
                    hspCard = hspCard.Replace(";", "");
                    hspCard = hspCard.Replace("?", "");
                    tbxHspcard.Text = hspCard;
                }
                if (hspCard.Trim().Equals(""))
                {
                    btnIhspNotice.Focus();
                    //显示鼠标指针  
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.IBeam;
                    //保持鼠标指针形状  
                    Cursor = System.Windows.Forms.Cursors.Default;
                    return;
                }
                string hspcard = tbxHspcard.Text.Trim().ToString();
                DataTable dataTable = new DataTable();
                dataTable = bllClinicReg.getMemberInfo(tbxHspcard.Text.Trim().ToString());//billIhspMan.ihspEnterSearchByhspcard(hspcard);
                if (dataTable.Rows.Count == 0)
                {
                    this.cmbPatienttype.Focus();
                    this.cmbPatienttype.DroppedDown = true;
                    //显示鼠标指针  
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.IBeam;
                    //保持鼠标指针形状  
                    Cursor = System.Windows.Forms.Cursors.Default;
                }
                else
                {
                    member_id = dataTable.Rows[0]["id"].ToString();
                    if ("-1" != member_id && null != member_id && "" != member_id)
                    {
                        tbxIhspcode.Text = BillSysBase.newBillcode("inhospital_ihspcode");
                        tbxName.Text = dataTable.Rows[0]["name"].ToString();
                        tbxIDCard.Text = dataTable.Rows[0]["idcard"].ToString();
                        cmbSex.SelectedValue = billCmbList.sexid(dataTable.Rows[0]["sex"].ToString());

                        if (!string.IsNullOrEmpty(dataTable.Rows[0]["race_id"].ToString()))
                        {
                            cmbRace.Text = dataTable.Rows[0]["race"].ToString();
                            cmbRace.SelectedValue = dataTable.Rows[0]["race_id"].ToString();
                        }
                        dtpBirthday.Value = Convert.ToDateTime(dataTable.Rows[0]["birthday"].ToString());
                        //tbxCompanyname.Text = dataTable.Rows[0]["companyname"].ToString();
                        String birthYear = dtpBirthday.Value.Year.ToString();
                        String currentYear = Convert.ToDateTime(BillSysBase.currDate()).Year.ToString();
                        int age = int.Parse(currentYear) - int.Parse(birthYear);
                        tbxAge.Text = age.ToString();
                        //提取地址
                        changeCmbAddress(dataTable.Rows[0]["provice_id"].ToString(), dataTable.Rows[0]["city_id"].ToString(), dataTable.Rows[0]["county_id"].ToString());
                        tbxsubAddress.Text = dataTable.Rows[0]["hmhouseNumber"].ToString();
                    }
                }
                cmbPatienttype.Focus();
                cmbPatienttype.DroppedDown = true;
                //显示鼠标指针  
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.IBeam;
                //保持鼠标指针形状  
                Cursor = System.Windows.Forms.Cursors.Default;

            }
        }

        #region 地址 简码下拉
        BllClinicReg bllRegister = new BllClinicReg();
        string province = "0";
        string city = "0";
        string county = "0";
        /// <summary>
        /// 地址1
        /// </summary>
        private void cmbProvince_SelectedValueChanged(object sender, EventArgs e)
        {
            provinceChange();
        }
        private void provinceChange()
        {
            if (cmbProvince.SelectedValue == null) { return; }
            string value = cmbProvince.SelectedValue.ToString();
            if (!String.IsNullOrEmpty(value) && !string.Equals(value, "System.Data.DataRowView"))
            {
                if (string.Equals(value, "0"))
                {
                    DataTable dt = new DataTable();
                    bindComboxData(dt, cmbCity);
                }
                else
                {

                    bindComboxData(bllClinicReg.cityListB(value), cmbCity);
                }

                if (cmbCity.Items.Count > 1)
                {
                    cmbCity.SelectedIndex = 1;
                }

            }
        }
        /// <summary>
        /// 地址2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCity_SelectedValueChanged(object sender, EventArgs e)
        {
            cityChange();
        }
        private void cityChange()
        {
            if (cmbCity.SelectedValue == null) { return; }
            string value = cmbCity.SelectedValue.ToString();
            if (!String.IsNullOrEmpty(value) && !string.Equals(value, "System.Data.DataRowView"))
            {
                if (string.Equals(value, "0"))
                {
                    DataTable dt = new DataTable();
                    bindComboxData(dt, cmbCounty);
                }
                else
                {
                    bindComboxData(bllClinicReg.countyListB(value), cmbCounty);
                }
                if (value.Equals("520100"))//贵阳市
                {
                    cmbCounty.SelectedValue = "520102";//南明区
                }
                else
                {

                    if (cmbCounty.Items.Count > 1)
                    {
                        cmbCounty.SelectedValue = "130121";//井陉县
                    }
                }
            }
        }
        /// <summary>
        /// 安全的给级联菜单赋值
        /// </summary>
        private void changeCmbAddress(string province, string city, string county)
        {
            if (province == "" || province == null)
            {
                return;
            }
            if (string.IsNullOrEmpty(province))
                return;
            cmbProvince.SelectedValue = province;
            provinceChange();
            cmbCity.SelectedValue = city;
            cityChange();
            cmbCounty.SelectedValue = county;


        }
        //绑定下拉框
        private void bindComboxData(DataTable dt, ComboBox comObject)
        {
            if (dt.ToString() == "")
            {
                dt.Columns.Add("name", Type.GetType("System.String"));
                dt.Columns.Add("id", Type.GetType("System.String"));
            }
            comObject.DisplayMember = "name";
            comObject.ValueMember = "id";
            try
            {
                DataRow dr = dt.NewRow();
                dr["name"] = "--请选择--";
                dr["id"] = 0;
                dt.Rows.InsertAt(dr, 0);
                comObject.DataSource = dt;
                comObject.SelectedValue = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion

        private void cmbRace_KeyUp(object sender, KeyEventArgs e)
        {
            //判断输入是否 为字母键 或者 删除键，delete键 数字键
            if ((e.KeyValue >= 65) && (e.KeyValue <= 90)
                || (e.KeyCode == Keys.Back)
                || (e.KeyCode == Keys.Delete)
                || (e.KeyValue >= 48) && (e.KeyValue <= 57)
                || (e.KeyValue >= 96) && (e.KeyValue <= 105))
            {

                int l = cmbRace.SelectionStart; //记录修改时光标位置
                cmbRace.DroppedDown = false; //下拉框关闭

                string race = cmbRace.Text.Trim();
                //简码查询民族
                DataTable dtrace = billCmbList.getRaceInfo(race);
                //重新绑定
                DataRow dr = dtrace.NewRow();
                cmbRace.DataSource = dtrace;
                cmbRace.Text = race;

                cmbRace.DroppedDown = true; //打开下拉框
                cmbRace.SelectionStart = l; //定位光标至修改时的位置
                this.Cursor = System.Windows.Forms.Cursors.Default; //显示鼠标
            }
        }

        private void cmbDepart_KeyUp(object sender, KeyEventArgs e)
        {
            //判断输入是否 为字母键 或者 删除键，delete键 数字键
            if ((e.KeyValue >= 65) && (e.KeyValue <= 90)
                || (e.KeyCode == Keys.Back)
                || (e.KeyCode == Keys.Delete)
                || (e.KeyValue >= 48) && (e.KeyValue <= 57)
                || (e.KeyValue >= 96) && (e.KeyValue <= 105))
            {

                int l = cmbDepart.SelectionStart; //记录修改时光标位置
                cmbDepart.DroppedDown = false; //下拉框关闭

                string dep = cmbDepart.Text.Trim();
                //简码查询科室
                DataTable dtde = billCmbList.ihspDepart(dep);
                //重新绑定
                DataRow dr = dtde.NewRow();
                dr["id"] = 0;
                dr["name"] = "--请选择--";
                dtde.Rows.InsertAt(dr, 0);
                cmbDepart.DataSource = dtde;
                cmbDepart.Text = dep;

                cmbDepart.DroppedDown = true; //打开下拉框
                cmbDepart.SelectionStart = l; //定位光标至修改时的位置
                this.Cursor = System.Windows.Forms.Cursors.Default; //显示鼠标
            }
        }

        private void cmbDepart_SelectedValueChanged(object sender, EventArgs e)
        {

            departChange();

            //根据科室修改医生
            //if (null != cmbDepart.SelectedValue)
            //{
            //    string departid = cmbDepart.SelectedValue.ToString().Trim();
            //    DataTable dtdo = billCmbList.doctorNameGet(departid);

            //    this.cmbDoctor.ValueMember = "id";
            //    this.cmbDoctor.DisplayMember = "name";
            //    DataRow drdo = dtdo.NewRow();
            //    drdo["id"] = 0;
            //    drdo["name"] = "--请选择--";
            //    dtdo.Rows.InsertAt(drdo, 0);
            //    this.cmbDoctor.DataSource = dtdo;
            //}
        }
        /// <summary>
        /// //科室变化处理: 算法修改医生信息
        /// </summary>
        private void departChange()
        {
            BllClinicReg bllClinicReg = new BllClinicReg();
            if (cmbDepart.Items.Count <= 0)
            {
                return;
            }
            if (null != cmbDepart.SelectedValue)
            {
                String depart_id = cmbDepart.SelectedValue.ToString();
                bindComboxData(bllClinicReg.getDoctorByDepartId(depart_id), cmbDoctor);
            }
        }
        private void cmbClinicDepart_SelectedValueChanged(object sender, EventArgs e)
        {
            clinicdepartChange();
        }
        /// <summary>
        /// //科室变化处理: 算法修改医生信息
        /// </summary>
        private void clinicdepartChange()
        {
            BllClinicReg bllClinicReg = new BllClinicReg();
            if (cmbClinicDepart.Items.Count <= 0)
            {
                return;
            }
            if (null != cmbClinicDepart.SelectedValue)
            {
                String depart_id = cmbClinicDepart.SelectedValue.ToString();
                bindComboxData(bllClinicReg.getDoctorByDepartId(depart_id), cmbClinicDoctor);
            }
        }
        /// <summary>
        /// 初始化科室下拉框
        /// </summary>
        private void initCmbDepart()
        {
            DataTable dtde = billCmbList.ihspDepart("");
            if (dtde.Rows.Count > 0)
            {
                DataRow dr = dtde.NewRow();
                dr["id"] = 0;
                dr["name"] = "--请选择--";
                dtde.Rows.InsertAt(dr, 0);
                this.cmbDepart.ValueMember = "id";
                this.cmbDepart.DisplayMember = "name";
                this.cmbDepart.DataSource = dtde;

            }
        }

        /// <summary>
        /// 初始化接诊科室下拉框
        /// </summary>
        private void initCmbclinicDepart()
        {
            DataTable dtde = bllClinicReg.getDepartInfo("");
            if (dtde.Rows.Count > 0)
            {
                DataRow dr = dtde.NewRow();
                dr["id"] = 0;
                dr["name"] = "--请选择--";
                dtde.Rows.InsertAt(dr, 0);
                this.cmbClinicDepart.ValueMember = "id";
                this.cmbClinicDepart.DisplayMember = "name";
                this.cmbClinicDepart.DataSource = dtde;

            }
        }
        private void cmbDepart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbDoctor.Focus();
                cmbDoctor.DroppedDown = true;
            }
        }
        private void cmbClinicDepart_KeyUp(object sender, KeyEventArgs e)
        {
            //判断输入是否 为字母键 或者 删除键，delete键 数字键
            if ((e.KeyValue >= 65) && (e.KeyValue <= 90)
                || (e.KeyCode == Keys.Back)
                || (e.KeyCode == Keys.Delete)
                || (e.KeyValue >= 48) && (e.KeyValue <= 57)
                || (e.KeyValue >= 96) && (e.KeyValue <= 105))
            {

                int l = cmbClinicDepart.SelectionStart; //记录修改时光标位置
                cmbClinicDepart.DroppedDown = false; //下拉框关闭

                string dep = cmbClinicDepart.Text.Trim();
                //简码查询科室
                DataTable dtde = bllClinicReg.getDepartInfo(dep);
                //重新绑定
                DataRow dr = dtde.NewRow();
                dr["id"] = 0;
                dr["name"] = "--请选择--";
                dtde.Rows.InsertAt(dr, 0);
                cmbClinicDepart.DataSource = dtde;
                cmbClinicDepart.Text = dep;

                cmbClinicDepart.DroppedDown = true; //打开下拉框
                cmbClinicDepart.SelectionStart = l; //定位光标至修改时的位置
                this.Cursor = System.Windows.Forms.Cursors.Default; //显示鼠标
            }
            else if (e.KeyCode == Keys.Enter)
            {
                cmbDoctor.Focus();
                cmbDoctor.DroppedDown = true;
            }
        }

        private void cmbRace_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tbxIDCard.Focus();
            }
        }

        private void cmbPayType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbPayType.Items.Count <= 0)
            {
                return;
            }
            tbx_authCode.ReadOnly = true;
            tbx_authCode.Text = "";
            NetpayBll netpayBll = new NetpayBll();
            netpaytype = netpayBll.getNetPaytype(cmbPayType.SelectedValue.ToString());
            if (netpaytype != "-1")
            {
                tbx_authCode.Clear();
                tbx_authCode.Focus();
                tbx_authCode.ReadOnly = false;
                lblInvoiceMsg.Text = "现在选择网络支付";

            }
            else
            {
                lblInvoiceMsg.Text = "                  ";
            }




        }

        private void tbxIDCard_TextChanged(object sender, EventArgs e)
        {
            int ihspsn = billIhspMan.getIhspsnByIdcard(this.tbxIDCard.Text.Trim()) + 1;
            this.tbxIhspsn.Text = ihspsn.ToString();

            Billjc blljc = new Billjc();
            string idcard = this.tbxIDCard.Text.Trim();//身份证号  
            Regex reg = new Regex(@"^(\d{8}[0-1]\d[0-3]\d{4}$|^\d{6}[1-2][901]\d{2}[0-1]\d[0-3]\d{5}$|^\d{6}[1-2][901]\d{2}[0-1]\d[0-3]\d{4}(\d|X|x))$");//正则表达式
            //身份证判断
            if (idcard != "" && reg.IsMatch(idcard))
            {
                //贫困户判断
                string ts = blljc.getpkh(tbxIDCard.Text.Trim().ToString(), tbxName.Text.Trim().ToString());
                if (ts == null || ts == "")
                {

                }
                else
                {
                    if (ts.Equals("农村低保"))
                    {
                        MessageBox.Show("该人员是"+ts+"！", "提示信息");
                        com_Poverty.SelectedValue = "1";
                    }
                    else if (ts.Equals("农村特困"))
                    {
                        MessageBox.Show("该人员是" + ts + "！", "提示信息");
                        com_Poverty.SelectedValue = "2";
                    }
                    else if (ts.Equals("城镇低保"))
                    {
                        MessageBox.Show("该人员是" + ts + "！", "提示信息");
                        com_Poverty.SelectedValue = "3";
                    }
                    else if (ts.Equals("城市特困"))
                    {
                        MessageBox.Show("该人员是" + ts + "！", "提示信息");
                        com_Poverty.SelectedValue = "4";
                    }
                }

                if (!checkIdCard())
                {
                    tbxIDCard.Focus();
                }
                else
                {
                    btnReadIDCard.Focus();

                }
            }

        }

        private void tbxPayfee_TextChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void cmbDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbProvince_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbCity.Focus();
                cmbCity.DroppedDown = true;
            }
        }

        private void cmbCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbCounty.Focus();
                cmbCounty.DroppedDown = true;
            }
        }

        private void cmbCounty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxsubAddress.Focus();
            }
        }

        private void tbxsubAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //tbxCompanyname.Focus();
            }
        }

        private void tbxIhspsn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbDepart.Focus();
                cmbDepart.DroppedDown = true;
            }
        }

        private void tbxPayMan_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxPayMan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbPayType.Focus();
                cmbPayType.DroppedDown = true;
            }
        }


        private void btnReadIDCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbPatienttype.Focus();
                this.cmbPatienttype.DroppedDown = true;
            }
            else if (e.KeyCode == Keys.Space)
            {
                readIdcard();
            }

        }

        private void tbxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxIntroducer_TextChanged(object sender, EventArgs e)
        {
            lbxDiagn.Visible = true;

            DataTable dt = bllClinicReg.getDoctorByDocname(tbxIntroducer.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                this.lbxDiagn.ValueMember = "icd10";
                this.lbxDiagn.DisplayMember = "name";
                lbxDiagn.DataSource = dt;
            }
        }

        private void tbxIntroducer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                isleave = true;
                lbxDiagn.Focus();
                if (lbxDiagn.Items.Count >= 2)
                {
                    lbxDiagn.SelectedIndex = 0;
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (lbxDiagn.Visible)
                {
                    if (lbxDiagn.Items.Count >= 2)
                    {
                        lbxDiagn.SelectedIndex = 0;
                    }
                    //icdCode = lbxDiagn.SelectedValue.ToString();
                    //tbxDiagn.Text = lbxDiagn.Text.ToString();
                    //lbxDiagn.Visible = false;
                }

            }
        }

        private void tbxIntroducer_Leave(object sender, EventArgs e)
        {
            if (!isleave)
            {
                lbxDiagn.Visible = false;
            }
            else
            {
                isleave = false;
            }
        }

        private void lbxDiagn_MouseDown(object sender, MouseEventArgs e)
        {
            lbxDiagn.Visible = true;
            DataRowView drv = (DataRowView)lbxDiagn.SelectedItem;
            tbxIntroducer.Text = drv.DataView[lbxDiagn.SelectedIndex]["name"].ToString();
            tbxIntroducer.Focus();
            lbxDiagn.Visible = false;
        }

        private void lbxDiagn_Leave(object sender, EventArgs e)
        {
            lbxDiagn.Visible = false;
        }

        private void lbxDiagn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lbxDiagn.SelectedIndex == 1)
                {
                    tbxIntroducer.Focus();
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                DataRowView drv = (DataRowView)lbxDiagn.SelectedItem;
                tbxIntroducer.Text = drv.Row["name"].ToString();          
                tbxIntroducer.Focus();
                lbxDiagn.Visible = false;
            }
        }

        private void tbxIntroducer_MouseDown(object sender, MouseEventArgs e)
        {

        }


        

        


    }
}
