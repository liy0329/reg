using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.sjzsyb.bean
{
    class Detailedquery_Out : SJZYB_OUT
    {
        /// <summary>
        /// 就诊日期
        /// </summary>
        public string AKC192 { get; set; }
        /// <summary>
        /// 中心收费项目编码
        /// </summary>
        public string AKC222 { get; set; }
        /// <summary>
        /// 中心收费项目名称
        /// </summary>
        public string AKC223 { get; set; }
        /// <summary>
        ///  剂型
        /// </summary>
        public string AKA070 { get; set; }
        /// <summary>
        ///  规格
        /// </summary>
        public string AKA077 { get; set; }
        /// <summary>
        ///  销售单位
        /// </summary>
        public string BKA076 { get; set; }
        /// <summary>
        ///  数量
        /// </summary>
        public string AKC226 { get; set; }
        /// <summary>
        ///  定点医疗机构编码
        /// </summary>
        public string AKB020 { get; set; }

    }
}
