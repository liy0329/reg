using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.netpay.bo
{
    public class JsonTop
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
    }
}
