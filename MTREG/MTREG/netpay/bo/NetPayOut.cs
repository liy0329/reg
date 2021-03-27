using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.netpay.bo
{
    public  class NetPayOut
    {
        String tradeNo="";//	支付流水号
        /// <summary>
        /// 支付流水号
        /// </summary>
        public String TradeNo
        {
            get { return tradeNo; }
            set { tradeNo = value; }
        }
        String outerOrderNo="";//	收据号
        /// <summary>
        /// 收据号
        /// </summary>
        public String OuterOrderNo
        {
            get { return outerOrderNo; }
            set { outerOrderNo = value; }
        }
        String amount="";//	总金额
        /// <summary>
        /// 总金额
        /// </summary>
        public String Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        String innerOrderNo="";//	系统标识
        /// <summary>
        /// 系统标识
        /// </summary>
        public String InnerOrderNo
        {
            get { return innerOrderNo; }
            set { innerOrderNo = value; }
        }
        String paytype="";//	支付方式
        /// <summary>
        /// 支付方式
        /// </summary>
        public String Paytype
        {
            get { return paytype; }
            set { paytype = value; }
        }
        String nonce_str="";//	随机字符串
        /// <summary>
        /// 随机字符串
        /// </summary>
        public String Nonce_str
        {
            get { return nonce_str; }
            set { nonce_str = value; }
        }
        String sign="";//	MD5签名
        /// <summary>
        /// MD5签名
        /// </summary>
        public String Sign
        {
            get { return sign; }
            set { sign = value; }
        }

    }
}
