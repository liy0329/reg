using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.sjzsyb.bean
{
    class Reconciliation_Out_xm : SJZYB_OUT
    {
        /// <summary>
        /// 对帐结果
        /// </summary>
        public string AKE150 { get; set; }
        /// <summary>
        /// 提示信息
        /// </summary>
        public string AAA204 { get; set; }
        /// <summary>
        /// 发送方交易流水号
        /// </summary>
        public string MSGID { get; set; }
        /// <summary>
        /// 接收方交易流水号
        /// </summary>
        public string REFMSGID { get; set; }
        /// <summary>
        /// 接收方医疗费总额
        /// </summary>
        public string AKC264 { get; set; }
        /// <summary>
        /// 接收方帐户支付合计
        /// </summary>
        public string AKC255 { get; set; }
        /// <summary>
        /// 接收方统筹基金支付合计
        /// </summary>
        public string AKC260 { get; set; }
        /// <summary>
        /// 接收方现金支付合计
        /// </summary>
        public string AKC261 { get; set; }
        /// <summary>
        /// 接收方大病救助基金支付
        /// </summary>
        public string AKC706 { get; set; }
        /// <summary>
        /// 接收方公务员补助合计
        /// </summary>
        public string AKC707 { get; set; }
        /// <summary>
        /// 接收方其他基金支付
        /// </summary>
        public string AKC708 { get; set; }
    }
}
