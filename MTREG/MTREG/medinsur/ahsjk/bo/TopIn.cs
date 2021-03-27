    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MTREG.medinsur.ahsjk.bo
{
    /// <summary>
    /// 顶级公共输入参数类
    /// 被所有输入参数继承
    /// </summary>
    public class TopIn
    {

        private string weburl;
        /// <summary>
        /// webservice地址
        /// </summary>
        public string Weburl
        {
            get { return weburl; }
            set { weburl = value; }
        }

        private string sHospitalCode;
        /// <summary>
        /// //医疗机构编号
        /// </summary>
        public string SHospitalCode
        {
            get { return sHospitalCode; }
            set { sHospitalCode = value; }
        }

        private string sObligate1;
        /// <summary>
        /// 预留字段1
        /// </summary>
        public string SObligate1
        {
            get { return sObligate1; }
            set { sObligate1 = value; }
        }
        private string sObligate2;
        /// <summary>
        /// //预留字段2
        /// </summary>
        public string SObligate2
        {
            get { return sObligate2; }
            set { sObligate2 = value; }
        }
        private string sObligate3;
        /// <summary>
        /// //预留字段3
        /// </summary>
        public string SObligate3
        {
            get { return sObligate3; }
            set { sObligate3 = value; }
        }
        private string sObligate4;
        /// <summary>
        /// //预留字段4
        /// </summary>
        public string SObligate4
        {
            get { return sObligate4; }
            set { sObligate4 = value; }
        }
        private string sObligate5;
        /// <summary>
        /// //预留字段5
        /// </summary>
        public string SObligate5
        {
            get { return sObligate5; }
            set { sObligate5 = value; }
        }
    }
}
