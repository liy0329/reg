using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.bo
{
    class InHspData
    {
        private string Ihspcode;
        /// <summary>
        /// 住院号
        /// </summary>
        public string Ihspcode1
        {
            get { return Ihspcode; }
            set { Ihspcode = value; }
        }
        private string ihspsn;
        /// <summary>
        /// 住院次数号
        /// </summary>
        public string Ihspsn
        {
            get { return ihspsn; }
            set { ihspsn = value; }
        }
        private string healthcard;
        /// <summary>
        /// 参保证号
        /// </summary>
        public string Healthcard
        {
            get { return healthcard; }
            set { healthcard = value; }
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
        private string birthday;
        /// <summary>
        /// 出生日期
        /// </summary>
        public string Birthday
        {
            get { return birthday; }
            set { birthday = value; }
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
        private string ihspdiagn;
        /// <summary>
        /// 住院诊断
        /// </summary>
        public string Ihspdiagn
        {
            get { return ihspdiagn; }
            set { ihspdiagn = value; }
        }
        private string ihspicd;
        /// <summary>
        /// 住院诊断编码
        /// </summary>
        public string Ihspicd
        {
            get { return ihspicd; }
            set { ihspicd = value; }
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
        private string registdate;
        /// <summary>
        /// 登记时间
        /// </summary>
        public string Registdate
        {
            get { return registdate; }
            set { registdate = value; }
        }


    }
}
