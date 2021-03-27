using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.ihsp.bo
{
    class IhspInfo
    {

        private string id;
        /// <summary>
        /// ID
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string ihsp_id;
        //住院记录ID
        public string Ihsp_id
        {
            get { return ihsp_id; }
            set { ihsp_id = value; }
        }
        private string homeaddress;
        /// <summary>
        /// 现住址
        /// </summary>
        public string Homeaddress
        {
            get { return homeaddress; }
            set { homeaddress = value; }
        }
        
        private string hmstreetname;
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
        private string companyname;
        /// <summary>
        /// 单位名称
        /// </summary>
        public string Companyname
        {
            get { return companyname; }
            set { companyname = value; }
        }
        private string idcard;
        /// <summary>
        /// 身份证
        /// </summary>
        public string Idcard
        {
            get { return idcard; }
            set { idcard = value; }
        }
        private string race;
        /// <summary>
        /// 民族
        /// </summary>
        public string Race
        {
            get { return race; }
            set { race = value; }
        }
        private string raceid;
        /// <summary>
        /// 民族id
        /// </summary>
        public string Raceid
        {
            get { return raceid; }
            set { raceid = value; }
        }
        /// <summary>
        /// 省id
        /// </summary>
        private string province_id;

        public string Province_id
        {
            get { return province_id; }
            set { province_id = value; }
        }
        /// <summary>
        /// 市id
        /// </summary>
        private string city_id;

        public string City_id
        {
            get { return city_id; }
            set { city_id = value; }
        }
        /// <summary>
        /// 县id
        /// </summary>
        private string county_id;

        public string County_id
        {
            get { return county_id; }
            set { county_id = value; }
        }

        private string homephone;
        /// <summary>
        /// 电话
        /// </summary>
        public string Homephone
        {
            get { return homephone; }
            set { homephone = value; }
        }

        private string profession_id;
        /// <summary>
        /// 职业id
        /// </summary>
        public string Profession_id
        {
            get { return profession_id; }
            set { profession_id = value; }
        }

        private string profession;
        /// <summary>
        /// 职业
        /// </summary>
        public string Profession
        {
            get { return profession; }
            set { profession = value; }
        }

        private string marriage_id;
        /// <summary>
        /// 婚姻状况
        /// </summary>
        public string Marriage_id
        {
            get { return marriage_id; }
            set { marriage_id = value; }
        }
    }
}
