using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.sjzsyb.bean
{
    /// <summary>
    /// 住院费用明细删除_ 入参
    /// </summary>
    class zyfysc_IN 
    {
        /// <summary>
        /// 个人编号
        /// </summary>
        public string AAC001 { get; set; }
        /// <summary>
        /// 门诊住院流水号
        /// </summary>
        public string AKC190 { get; set; }
        /// <summary>
        /// 医院被撤销交易流水号
        /// </summary>
        public string AKC281 { get; set; }
        /// <summary>
        ///  医院处方流水号
        /// </summary>
        public string AKC378 { get; set; }
    }
}
