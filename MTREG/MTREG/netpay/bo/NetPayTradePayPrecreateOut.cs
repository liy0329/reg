using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.netpay.bo
{
   public class NetPayTradePayPrecreateOut
    {
        private String qrCode;//	二维码

        public String QrCode
        {
            get { return qrCode; }
            set { qrCode = value; }
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
        private String nonce_str;//	随机字符串

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
