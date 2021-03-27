using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.netpay.bo
{
    public class JsonSuccess
    {
        /// <summary>
        /// 状态
        /// </summary>
        public string success { get; set; }
        /// <summary>
        /// 错误码
        /// </summary>
        public string errcode { get; set; }
        /// <summary>
        /// 错误原因
        /// </summary>
        public string err { get; set; }
        /// <summary>
        /// 随机字符串
        /// </summary>
        public string nonce_str { get; set; }
        /// <summary>
        /// MD5签名
        /// </summary>
        public string sign { get; set; }

        public string token { get; set; }

        public string userid { get; set; }

        public MSGSuccess msg { get; set; }
    }
    public class MSGSuccess
    {
        /// <summary>
        /// 总金额
        /// </summary>

        public string amount { get; set; }
        /// <summary>
        ///系统标识
        /// </summary>

        public string innerOrderNo { get; set; }
        /// <summary>
        ///收据号
        /// </summary>

        public string outerOrderNo { get; set; }

        /// <summary>
        /// 支付方式
        /// </summary>

        public string paytype { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public string tradeNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string qrCode { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string tradeStatus { get; set; }

        /// <summary>
        /// 退款时间
        /// </summary>
        public string gmt_refund_pay { get; set; }

        /// <summary>
        /// 退款金额
        /// </summary>
        public string refundFee { get; set; }

      
    }
}
