using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.ihsp.bo
{
    class Member
    {
        private string name;
        private string pincode;
        private string sex;
        private string birthday;
        private string hspcard;
        private string race;
        private string raceid;        
        private string address;
        private string idcard;
        private string profession;
        private string mobile;
        private string companyname;
        private string createdate;
        private string createdby;
        private string homeaddress;
        private string hmstreetname;
        private string hmprovince;
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

        public string Hmprovince
        {
            get { return hmprovince; }
            set { hmprovince = value; }
        }
        private string hmcity;

        public string Hmcity
        {
            get { return hmcity; }
            set { hmcity = value; }
        }
        private string hmcounty;

        public string Hmcounty
        {
            get { return hmcounty; }
            set { hmcounty = value; }
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
        /// 民族
        /// </summary>
        public string Race
        {
            get { return race; }
            set { race = value; }
        }
        /// <summary>
        /// 民族id
        /// </summary>
        public string Raceid
        {
            get { return raceid; }
            set { raceid = value; }
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
