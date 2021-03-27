using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.sjzsyb.bean
{
    class zyjszh_OUT : SJZYB_OUT
    {
        /// <summary>
        /// 医疗费总额
        /// </summary>
        public string AKC264 { get; set; }
        /// <summary>
        /// 本次现金支付金额
        /// </summary>
        public string AKC261 { get; set; }
        /// <summary>
        /// 结算后卡余额
        /// </summary>
        public string AKC087 { get; set; }
        /// <summary>
        /// 结算回退时间
        /// </summary>
        public string AAE040 { get; set; }
    }
}
