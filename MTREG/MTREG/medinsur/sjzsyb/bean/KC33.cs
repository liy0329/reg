using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.sjzsyb.bean
{
    class KC33
    {
        /// <summary>
        /// 门诊（住院）号，
        /// </summary>
        public string AKC190 { get; set; }
        /// <summary>
        /// 诊断顺序
        /// </summary>
        public string BKE150 { get; set; }
        /// <summary>
        /// 确诊日期 YYYYMMDDHH24MISS
        /// </summary>
        public string AKC221 { get; set; }
        /// <summary>
        /// 诊断编码
        /// </summary>
        public string AKA120 { get; set; }
        /// <summary>
        /// 诊断名称
        /// </summary>
        public string AKA121 { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string AAE013 { get; set; }
        
    }
}
