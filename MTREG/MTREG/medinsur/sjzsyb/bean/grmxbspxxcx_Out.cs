using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.sjzsyb.bean
{
    class grmxbspxxcx_Out : SJZYB_OUT
    {
        /// <summary>
        ///  审批编号 
        /// </summary>
        public string BAE073 { get; set; }
        /// <summary>
        ///   医疗类别 
        /// </summary>
        public string AKA130 { get; set; }
        /// <summary>
        ///  病种代码 
        /// </summary>
        public string BKC462 { get; set; }
        /// <summary>
        ///   病种名称 
        /// </summary>
        public string AKA121 { get; set; }
        /// <summary>
        ///   开始日期 
        /// </summary>
        public string AAE030 { get; set; }
        /// <summary>
        ///  终止日期 
        /// </summary>
        public string AAE031 { get; set; }
        /// <summary>
        ///   定点医疗机构编码
        /// </summary>
        public string AKB020 { get; set; }
    }
}
