using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.netpay.bo
{
   public class NetPayTradeRefundQueryOut
    {
        private String tradeNo;//	支付流水号
       /// <summary>
        /// 支付流水号
       /// </summary>
        public String TradeNo
        {
            get { return tradeNo; }
            set { tradeNo = value; }
        }
        private String outerOrderNo;//	收据号
       /// <summary>
        /// 收据号
       /// </summary>
        public String OuterOrderNo
        {
            get { return outerOrderNo; }
            set { outerOrderNo = value; }
        }
        private String refundFee;//	退款金额
       /// <summary>
        /// 退款金额
       /// </summary>
        public String RefundFee
        {
            get { return refundFee; }
            set { refundFee = value; }
        }
        private String gmt_refund_pay;//	退款时间
       /// <summary>
        /// 退款时间
       /// </summary>
        public String Gmt_refund_pay
        {
            get { return gmt_refund_pay; }
            set { gmt_refund_pay = value; }
        }
        private String paytype;//	支付方式
       /// <summary>
        /// 支付方式
       /// </summary>
        public String Paytype
        {
            get { return paytype; }
            set { paytype = value; }
        }
        private String nonce_str;//	随机字符串
       /// <summary>
        /// 随机字符串
       /// </summary>
        public String Nonce_str
        {
            get { return nonce_str; }
            set { nonce_str = value; }
        }
        private String sign;//	MD5签名

        public String Sign
        {
            get { return sign; }
            set { sign = value; }
        }

    }
}
