using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.clinic.bo
{
    class Register
    {
        private string id;
        private String regdate;
        private String billcode;
        private String reg_level_id;
        private String bas_patienttype_id;
        private String healthcard;
        private String sys_region_id;
        private String reg_regclass_id;
        private String urgent;
        private String depart_id;
        private String isarchive;
        private String doctor_id;
        private String users_id;
        private String amount;
        private String status;
        private String hspcard;
        private String name;
        private String pincode;
        private String sex;
        private String birthday;
        private String age;
        private String ageunit;
        private String createtime;
        private String updatetime;
        private string moonage;
        private string insuritemtype;//
        private string clinicroom;
        private string regnum;
        private string insurcode;
        private string member_id;

        /// <summary>
        /// 门诊收费方式
        /// </summary>
        public string clininicpay { get; set; }

        public string Member_id
        {
            get { return member_id; }
            set { member_id = value; }
        }

        /// <summary>
        /// 个人编码
        /// </summary>
        public string Insurcode
        {
            get { return insurcode; }
            set { insurcode = value; }
        }

        /// <summary>
        /// 叫号流水号
        /// </summary>
        public string Regnum
        {
            get { return regnum; }
            set { regnum = value; }
        }

        /// <summary>
        /// 诊室名称
        /// </summary>
        public string Clinicroom
        {
            get { return clinicroom; }
            set { clinicroom = value; }
        }
        
        /// <summary>
        /// 如果为省市医保则设置为3
        /// </summary>
        public string Insuritemtype
        {
            get { return insuritemtype; }
            set { insuritemtype = value; }
        }
        /// <summary>
        /// 幼儿月龄
        /// </summary>
        public string Moonage
        {
            get { return moonage; }
            set { moonage = value; }
        }
        private string moonageunit;
        /// <summary>
        /// 幼儿月龄单位
        /// </summary>
        public string Moonageunit
        {
            get { return moonageunit; }
            set { moonageunit = value; }
        }

        /// <summary>
        /// 主键
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// 门诊号
        /// </summary>
        public String Billcode
        {
            get { return billcode; }
            set { billcode = value; }
        }
        /// <summary>
        /// 挂号日期
        /// </summary>
        public String Regdate
        {
            get { return regdate; }
            set { regdate = value; }
        }
        /// <summary>
        /// 挂号级别
        /// </summary>
        public String Reg_level_id
        {
          get { return reg_level_id; }
          set { reg_level_id = value; }
        }
        /// <summary>
        /// 患者类型
        /// </summary>
        public String Bas_patienttype_id
        {
          get { return bas_patienttype_id; }
          set { bas_patienttype_id = value; }
        }
       /// <summary>
       /// 参保证号
       /// </summary>
        public String Healthcard
        {
            get { return healthcard; }
            set { healthcard = value; }
        }
        /// <summary>
        /// 患者区域
        /// </summary>
        public String Sys_region_id
        {
            get { return sys_region_id; }
            set { sys_region_id = value; }
        }
        /// <summary>
        /// 挂号方式
        /// </summary>
        public String Reg_regclass_id
        {
            get { return reg_regclass_id; }
            set { reg_regclass_id = value; }
        }
        /// <summary>
        /// 急诊
        /// </summary>
        public String Urgent
        {
            get { return urgent; }
            set { urgent = value; }
        }
        /// <summary>
        /// 医生
        /// </summary>
        public String Doctor_id
        {
            get { return doctor_id; }
            set { doctor_id = value; }
        }
        /// <summary>
        /// 科室
        /// </summary>
        public String Depart_id
        {
            get { return depart_id; }
            set { depart_id = value; }
        }
        /// <summary>
        /// 挂号员
        /// </summary>
        public String Users_id
        {
            get { return users_id; }
            set { users_id = value; }
        }
        /// <summary>
        /// 挂号金额
        /// </summary>
        public String Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        /// <summary>
        /// 收费操作状态
        /// </summary>
        public String Status
        {
            get { return status; }
            set { status = value; }
        }
        /// <summary>
        /// 归档状态
        /// </summary>
        public String Isarchive
        {
            get { return isarchive; }
            set { isarchive = value; }
        }
        /// <summary>
        /// 医院卡
        /// </summary>
        public String Hspcard
        {
            get { return hspcard; }
            set { hspcard = value; }
        }
        /// <summary>
        /// 患者姓名
        /// </summary>
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// 姓名简码
        /// </summary>
        public String Pincode
        {
            get { return pincode; }
            set { pincode = value; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public String Sex
        {
            get { return sex; }
            set { sex = value; }
        }
       /// <summary>
       /// 出生年月日
       /// </summary>
        public String Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }
        /// <summary>
        /// 年龄
        /// </summary>
        public String Age
        {
            get { return age; }
            set { age = value; }
        }
        /// <summary>
        /// 年龄单位
        /// </summary>
        public String Ageunit
        {
            get { return ageunit; }
            set { ageunit = value; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public String Createtime
        {
            get { return createtime; }
            set { createtime = value; }
        }
        /// <summary>
        /// 更新时间
        /// </summary>
        public String Updatetime
        {
            get { return updatetime; }
            set { updatetime = value; }
        }
    }
 }
