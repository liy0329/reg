using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.clinic.bo
{
    class Member
    {
        private string name;
        private string pincode;
        private string sex;
        private string birthday;
        private string hspcard;
        private string mzfare;
        private string race_id;
        private string race;
        private string address;
        private string idcard;
        private string profession;
        private string profession_id;        
        private string mobile;
        private string companyname;
        private string createdate;
        private string createdby;
        private string homeaddress;
        private string id;
        private string email;
        private string qqcode;
        private string companyaddr;
        private string companyzip;
        private string marriage_id;
        private string balance;
        private string hmstreetname;
        private string city_id;
        private string county_id;
        private string provice_id;

        public string Provice_id
        {
            get { return provice_id; }
            set { provice_id = value; }
        }

        public string County_id
        {
            get { return county_id; }
            set { county_id = value; }
        }
        public string City_id
        {
            get { return city_id; }
            set { city_id = value; }
        }
     

        /// <summary>
        /// 职业编码
        /// </summary>
        public string Profession_id
        {
            get { return profession_id; }
            set { profession_id = value; }
        }
        /// <summary>
        /// 现住址村
        /// </summary>
        public string Hmstreetname
        {
            get { return hmstreetname; }
            set { hmstreetname = value; }
        }
        private string hmhouseNumber;
        /// <summary>
        /// 门牌号
        /// </summary>
        public string HmhouseNumber
        {
            get { return hmhouseNumber; }
            set { hmhouseNumber = value; }
        }
        /// <summary>
        /// 余额
        /// </summary>
        public string Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        /// <summary>
        /// 婚姻状况
        /// </summary>
        public string Marriage_id
        {
            get { return marriage_id; }
            set { marriage_id = value; }
        }
        /// <summary>
        /// 单位邮编
        /// </summary>
        public string Companyzip
        {
            get { return companyzip; }
            set { companyzip = value; }
        }
        /// <summary>
        /// 单位地址
        /// </summary>
        public string Companyaddr
        {
            get { return companyaddr; }
            set { companyaddr = value; }
        }
        /// <summary>
        /// qq号
        /// </summary>
        public string Qqcode
        {
            get { return qqcode; }
            set { qqcode = value; }
        }
        private string bloodtype;
        /// <summary>
        /// 血型
        /// </summary>
        public string Bloodtype
        {
            get { return bloodtype; }
            set { bloodtype = value; }
        }
        private string member_rank_id;
        /// <summary>
        /// 会员等级
        /// </summary>
        public string Member_rank_id
        {
            get { return member_rank_id; }
            set { member_rank_id = value; }
        }
        private string companyphone;
        /// <summary>
        /// 公司电话
        /// </summary>
        public string Companyphone
        {
            get { return companyphone; }
            set { companyphone = value; }
        }
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string cardstat;
        /// <summary>
        /// 会员卡状态
        /// </summary>
        public string Cardstat
        {
            get { return cardstat; }
            set { cardstat = value; }
        }
        /// <summary>
        /// Id
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// 现住址
        /// </summary>
        public string Homeaddress
        {
            get { return homeaddress; }
            set { homeaddress = value; }
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// 拼音简码
        /// </summary>
        public string Pincode
        {
            get { return pincode; }
            set { pincode = value; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        /// <summary>
        /// 出生日期
        /// </summary>
        public string Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }
        /// <summary>
        /// 医院卡
        /// </summary>
        public string Hspcard
        {
            get { return hspcard; }
            set { hspcard = value; }
        }
        /// <summary>
        /// 门诊卡
        /// </summary>
        public string Mzfare
        {
            get { return mzfare; }
            set { mzfare = value; }
        }
        /// <summary>
        /// 民族信息外键
        /// </summary>
        public string Race_id
        {
            get { return race_id; }
            set { race_id = value; }
        }
        /// <summary>
        /// 民族
        /// </summary>
        public string Race
        {
            get { return race; }
            set { race = value; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
         /// <summary>
        /// 身份证号
        /// </summary>
        public string Idcard
        {
            get { return idcard; }
            set { idcard = value; }
        }
        /// <summary>
        /// 职业
        /// </summary>
        public string Profession
        {
            get { return profession; }
            set { profession = value; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string Companyname
        {
            get { return companyname; }
            set { companyname = value; }
        }
        /// <summary>
        /// 办卡时间
        /// </summary>
        public string Createdate
        {
            get { return createdate; }
            set { createdate = value; }
        }

        /// <summary>
        /// 办卡人
        /// </summary>
        public string Createdby
        {
            get { return createdby; }
            set { createdby = value; }
        }
    }
}
