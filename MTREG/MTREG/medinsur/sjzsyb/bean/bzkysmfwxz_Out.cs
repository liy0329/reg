using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.sjzsyb.bean
{
    public class bzkysmfwxz_Out : SJZYB_OUT
    {
        /// <summary>
        ///  当前页
        /// </summary>
        public string CURRENTPAGE { get; set; }
        /// <summary>
        ///  总页数
        /// </summary>
        public string TOTALPAGE { get; set; }
        /// <summary>
        ///  总记录数
        /// </summary>
        public string TOTALRECORD { get; set; }
        /// <summary>
        ///  每页条数
        /// </summary>
        public string PAGESIZE { get; set; }
        /// <summary>
        /// 特定
        /// </summary>
        public List<bzkysmfwxz_Out_OUTROW> OUTROW { get; set; }
    }
    public class bzkysmfwxz_Out_OUTROW
    {
        /// <summary>
        ///  医疗类别
        /// </summary>
        public string AKA130 { get; set; }
        /// <summary>
        ///  病种编码
        /// </summary>
        public string AKA120 { get; set; }
        /// <summary>
        ///  药品/项目编码
        /// </summary>
        public string AKE001 { get; set; }
        /// <summary>
        ///  有效标志
        /// </summary>
        public string AAE100 { get; set; }
        /// <summary>
        ///  备注
        /// </summary>
        public string AAE013 { get; set; }
        /// <summary>
        ///  开始时间
        /// </summary>
        public string AAE030 { get; set; }
        /// <summary>
        ///  终止时间
        /// </summary>
        public string AAE031 { get; set; }
    }
}
