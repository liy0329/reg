using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.bo
{
    class InsurItemInfo
    {
        private string cost_insurtype_id;
        /// <summary>
        /// 医保接口类型
        /// </summary>
        public string Cost_insurtype_id
        {
            get { return cost_insurtype_id; }
            set { cost_insurtype_id = value; }
        }
        private string insuritemtype;
        /// <summary>
        /// 医保目录类型码
        /// </summary>
        public string Insuritemtype
        {
            get { return insuritemtype; }
            set { insuritemtype = value; }
        }
        private string insurname;
        /// <summary>
        /// 医保名称
        /// </summary>
        public string Insurname
        {
            get { return insurname; }
            set { insurname = value; }
        }
        private string insurcode;
        /// <summary>
        /// 医保编码
        /// </summary>
        public string Insurcode
        {
            get { return insurcode; }
            set { insurcode = value; }
        }
    }
}
