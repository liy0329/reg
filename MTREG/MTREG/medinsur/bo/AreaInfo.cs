using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.bo
{
    class AreaInfo
    {
        private string id;
        /// <summary>
        /// 
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string cost_insurtype_id;
        /// <summary>
        /// 接口id
        /// </summary>
        public string Cost_insurtype_id
        {
            get { return cost_insurtype_id; }
            set { cost_insurtype_id = value; }
        }
        private string areaname;
        /// <summary>
        /// 区域名称
        /// </summary>
        public string Areaname
        {
            get { return areaname; }
            set { areaname = value; }
        }
        private string areacode;
        /// <summary>
        /// 区域编码
        /// </summary>
        public string Areacode
        {
            get { return areacode; }
            set { areacode = value; }
        }
        private string memo;
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo
        {
            get { return memo; }
            set { memo = value; }
        }
        private string insuritemtype;
        /// <summary>
        /// 目录类型码
        /// </summary>
        public string Insuritemtype
        {
            get { return insuritemtype; }
            set { insuritemtype = value; }
        }
    }
}
