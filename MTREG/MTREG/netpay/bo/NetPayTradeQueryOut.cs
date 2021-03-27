using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.netpay.bo
{
   public class NetPayTradeQueryOut
    {
        private String tradeNo;//	支付流水号

        public String TradeNo
        {
            get { return tradeNo; }
            set { tradeNo = value; }
        }
        private String outerOrderNo;//	收据号

        public String OuterOrderNo
        {
            get { return outerOrderNo; }
            set { outerOrderNo = value; }
        }
        private String amount;//	总金额

        public String Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        private String innerOrderNo;//	系统标识

        public String InnerOrderNo
        {
            get { return innerOrderNo; }
            set { innerOrderNo = value; }
        }
        private String paytype;//	支付方式

        public String Paytype
        {
            get { return paytype; }
            set { paytype = value; }
        }
        private String tradeStatus;//	交易状态

        public String TradeStatus
        {
            get { return tradeStatus; }
            set { tradeStatus = value; }
        }
        private String nonce_str;//	随机字符串

        public String Nonce_str
        {
            get { return nonce_str; }
            set { nonce_str = value; }
        }
        private String merchantId;//	客户端编码

        public String MerchantId
        {
            get { return merchantId; }
            set { merchantId = value; }
        }
        private String sign;//	MD5签名

        public String Sign
        {
            get { return sign; }
            set { sign = value; }
        }

    }
}
