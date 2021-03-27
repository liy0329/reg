using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.sjzsyb.bean
{
    public class Directory_In
    {
        /// <summary>
        /// 收费项目类别
        /// </summary>
        public string AKC224 { get; set; }
        /// <summary>
        /// 开始日期
        /// </summary>
        public string AAE030 { get; set; }
        /// <summary>
        /// 结束日期
        /// </summary>
        public string AAE031 { get; set; }
        /// <summary>
        /// 页码
        /// </summary>
        public string CURRENTPAGE { get; set; }
    }
}
