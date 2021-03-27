using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.sjzsyb.bean
{
    /// <summary>
    /// 【1130】按套限价项目使用情况上传
    /// </summary>
    public  class ATSC
    {
        /// <summary>
        /// 中心收费项目编码
        /// </summary>
        public string AKC222 { get; set; }
        /// <summary>
        /// 中心收费项目名称
        /// </summary>
        public string AKC223 { get; set; }
        /// <summary>
        /// 使用套数
        /// </summary>
        public string CKAA11 { get; set; }
    }
}
