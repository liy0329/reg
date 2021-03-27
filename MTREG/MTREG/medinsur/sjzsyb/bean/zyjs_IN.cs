using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.sjzsyb.bean
{
    class zyjs_IN
    {
        /// <summary>
        /// 门诊住院流水号
        /// </summary>
        public string AKC190 { get; set; }
        /// <summary>
        /// 单据号
        /// </summary>
        public string AAE072 { get; set; }
        /// <summary>
        /// 结算方式
        /// </summary>
        public string ZKC759 { get; set; }
        /// <summary>
        /// 医疗费总额
        /// </summary>
        public double AKC264 { get; set; }
        /// <summary>
        /// 是否使用账户
        /// </summary>
        public string BKC111 { get; set; }
    }
}
