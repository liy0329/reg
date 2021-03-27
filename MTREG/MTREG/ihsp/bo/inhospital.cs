using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.ihsp.bo
{
    class Inhospital
    {
        private string bas_patienttype1_id;

        public string Bas_patienttype1_id
        {
            get { return bas_patienttype1_id; }
            set { bas_patienttype1_id = value; }
        }

        private string insurcode;

        public string Insurcode
        {
            get { return insurcode; }
            set { insurcode = value; }
        }
        private string ybzt;

        public string Ybzt
        {
            get { return ybzt; }
            set { ybzt = value; }
        }
        private string insuritemtype;

        public string Insuritemtype
        {
            get { return insuritemtype; }
            set { insuritemtype = value; }
        }
        private string insurstat;

        public string Insurstat
        {
            get { return insurstat; }
            set { insurstat = value; }
        }
        
        private string paytype;
        /// <summary>
        /// 付款类型
        /// </summary>
        public string Paytype
        {
            get { return paytype; }
            set { paytype = value; }
        }
        private string idcard;
        /// <summary>
        /// 身份证号
        /// </summary>
        //public string Idcard
        //{
        //    get { return idcard; }
        //    set { idcard = value; }
        //}
        private string hspcard;
        /// <summary>
        /// 医院卡
        /// </summary>
        public string Hspcard
        {
            get { return hspcard; }
            set { hspcard = value; }
        }
       private string name;
        /// <summary>
        /// 姓名
        /// </summary>
       public string Name
       {
           get { return name; }
           set { name = value; }
       }
       private string pincode;
        /// <summary>
        /// 拼音简码
        /// </summary>
       public string Pincode
       {
           get { return pincode; }
           set { pincode = value; }
       }
       private string sex;
        /// <summary>
        /// 性别
        /// </summary>
       public string Sex
       {
           get { return sex; }
           set { sex = value; }
       }
       private string age;
        /// <summary>
        /// 年龄
        /// </summary>
       public string Age
       {
           get { return age; }
           set { age = value; }
       }
       private string ageunit;
        /// <summary>
       /// 年龄单位
        /// </summary>
       public string Ageunit
       {
           get { return ageunit; }
           set { ageunit = value; }
       }
       private string monAge;
       /// <summary>
       /// 幼儿月龄
       /// </summary>
       public string MonAge
       {
           get { return monAge; }
           set { monAge = value; }
       }
       private string monageunit;
       /// <summary>
       /// 幼儿月龄单位
       /// </summary>
       public string Monageunit
       {
           get { return monageunit; }
           set { monageunit = value; }
       }
       private string depart;
        /// <summary>
       /// 住院科室外键
        /// </summary>
       public string Depart
       {
           get { return depart; }
           set { depart = value; }
       }
        /// <summary>
        /// 接诊科室外键
        /// </summary>
       public string ClinicDepart { get; set; }
       private string ihspcode;
        /// <summary>
       /// 住院号
        /// </summary>
       public string Ihspcode
       {
           get { return ihspcode; }
           set { ihspcode = value; }
       }
       private string casecode;
       /// <summary>
       /// 病案号
       /// </summary>
       public string Casecode
       {
           get { return casecode; }
           set { casecode = value; }
       }
       private string birthday;
        /// <summary>
       /// 出生日期
        /// </summary>
       public string Birthday
       {
           get { return birthday; }
           set { birthday = value; }
       }       

       private string inspsource;
        /// <summary>
       /// 入院途径外键
        /// </summary>
       public string Inspsource
       {
           get { return inspsource; }
           set { inspsource = value; }
       }

       private string introducer;
        /// <summary>
       /// 介绍人
        /// </summary>
       public string Introducer
       {
           get { return introducer; }
           set { introducer = value; }
       }
       private string doctor;
        /// <summary>
        /// 医生外键
        /// </summary>
       public string Doctor
       {
           get { return doctor; }
           set { doctor = value; }
       }
        /// <summary>
        /// 接诊医生外键
        /// </summary>
       public string ClinicDoctor { get; set; }
       private string patienttype;
        /// <summary>
       /// 患者类型外键
        /// </summary>
       public string Patienttype
       {
           get { return patienttype; }
           set { patienttype = value; }
       }
       private string limitamt;
        /// <summary>
       /// 底限金额
        /// </summary>
       public string Limitamt
       {
           get { return limitamt; }
           set { limitamt = value; }
       }
       private string prepamt;
        /// <summary>
       /// 总预交款
        /// </summary>
       public string Prepamt
       {
           get { return prepamt; }
           set { prepamt = value; }
       }
       private string member_id;
        /// <summary>
        /// 会员号外键
        /// </summary>
       public string Member_id
       {
           get { return member_id; }
           set { member_id = value; }
       }
       private string indate;
        /// <summary>
        /// 入院时间
        /// </summary>
       public string Indate
       {
           get { return indate; }
           set { indate = value; }
       }
       private string outdate;
        /// <summary>
        /// 出院时间
        /// </summary>
       public string Outdate
       {
           get { return outdate; }
           set { outdate = value; }
       }
       private string status;
        /// <summary>
        /// 状态
        /// </summary>
       public string Status
       {
           get { return status; }
           set { status = value; }
       }
       private string costclass;
        /// <summary>
        /// 费用级别
        /// </summary>
       public string Costclass
       {
           get { return costclass; }
           set { costclass = value; }
       }
       private string id;
        /// <summary>
       /// 住院记录id
        /// </summary>
       public string Id
       {
           get { return id; }
           set { id = value; }
       }
       private string bas_ihspinstat_id;
        /// <summary>
        /// 入院状态
        /// </summary>
       public string Bas_ihspinstat_id
       {
           get { return bas_ihspinstat_id; }
           set { bas_ihspinstat_id = value; }
       }

       private string bas_ihspoutstat_id;
        /// <summary>
        /// 出院状态
        /// </summary>
       public string Bas_ihspoutstat_id
       {
           get { return bas_ihspoutstat_id; }
           set { bas_ihspoutstat_id = value; }
       }
       private string registdate;
        /// <summary>
        /// 登记时间
        /// </summary>
       public string Registdate
       {
           get { return registdate; }
           set { registdate = value; }
       }

       private string clinicicd;
        /// <summary>
        /// 门诊诊断编码
        /// </summary>
       public string Clinicicd
       {
           get { return clinicicd; }
           set { clinicicd = value; }
       }
       private string clinicdiagn;
        /// <summary>
        /// 门诊诊断
        /// </summary>
       public string Clinicdiagn
       {
           get { return clinicdiagn; }
           set { clinicdiagn = value; }
       }
        
       private string clinic_caseicd_id;
       /// <summary>
       /// 门诊疾病id
       /// </summary>
       public string Clinic_caseicd_id
       {
           get { return clinic_caseicd_id; }
           set { clinic_caseicd_id = value; }
       }
       private string registby;
        /// <summary>
        /// 登记人
        /// </summary>
       public string Registby
       {
           get { return registby; }
           set { registby = value; }
       }
       private string clinic_ihspnotice_id;

       public string Clinic_ihspnotice_id
       {
           get { return clinic_ihspnotice_id; }
           set { clinic_ihspnotice_id = value; }
       }
       private string ihspsn;

       public string Ihspsn
       {
           get { return ihspsn; }
           set { ihspsn = value; }
       }
       private string register_id;

       public string Register_id
       {
           get { return register_id; }
           set { register_id = value; }
       }
        /// <summary>
        /// 贫困人口类型
        /// </summary>
       public string poverty { get; set; }
    }
}
