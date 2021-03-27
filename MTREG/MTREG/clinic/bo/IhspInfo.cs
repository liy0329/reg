using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.clinic.bo
{
    class IhspInfo
    {
        private string id;//单纯的主键
        private string ihsp_id;//挂号的存进去的是 registerid 住院其他的不知道
        private string idcard;//身份证号
        private string profession;//职业
        private string homeaddress;//现住址
        private string hmprovince;//省外键     
        private string hmcity;//市外键        
        private string hmcounty;//县外键
        private string hmtownship;//乡外键
        private string hmstreetname;//村外键       
        private string homephone;//现住址电话
        private string companyname;//公司名称
        private string profession_id;//职业ID（真是日了狗了 职业都有id）


        /// <summary>
        /// 村外键
        /// </summary>
        public string Hmtownship
        {
            get { return hmtownship; }
            set { hmtownship = value; }
        }
        /// <summary>
        /// 县外键
        /// </summary>
        public string Hmcounty
        {
            get { return hmcounty; }
            set { hmcounty = value; }
        }
        /// <summary>
        /// 市外键
        /// </summary>
        public string Hmcity
        {
            get { return hmcity; }
            set { hmcity = value; }
        }
        /// <summary>
        /// 省外键
        /// </summary>
        public string Hmprovince
        {
            get { return hmprovince; }
            set { hmprovince = value; }
        }
        /// <summary>
        /// 职业id
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
        /// register表ID
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// 挂号记录id
        /// </summary>
        public string Ihsp_id
        {
            get { return ihsp_id; }
            set { ihsp_id = value; }
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
        /// 家庭住址
        /// </summary>
        public string Homeaddress
        {
            get { return homeaddress; }
            set { homeaddress = value; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string Homephone
        {
            get { return homephone; }
            set { homephone = value; }
        }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string Companyname
        {
            get { return companyname; }
            set { companyname = value; }
        }
        private string race;
        //民族
        public string Race
        {
            get { return race; }
            set { race = value; }
        }

        private string race_id;
        /// <summary>
        /// 民族id
        /// </summary>
        public string Race_id
        {
            get { return race_id; }
            set { race_id = value; }
        }
        private string mobile;
        /// <summary>
        /// 电话
        /// </summary>
        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }
    }
}
