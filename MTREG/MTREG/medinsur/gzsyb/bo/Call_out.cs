using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gzsyb.bo
{
    /// <summary>
    /// 交易主函数，完成所有医疗业务的实际处理
    /// </summary>
    class Call_out
    {
        private string astrjylsh;//交易流水号
        private string astrjyyzm;//交易验证码
        private string astrjyscxml;//交易输出
        private long aintappcode;//交易标志
        private string astrappms;//交易信息
        /// <summary>
        /// 交易流水号
        /// </summary>
        public string Astrjylsh
        {
            get { return astrjylsh; }
            set { astrjylsh = value; }
        }
        /// <summary>
        /// 交易验证码
        /// </summary>
        public string Astrjyyzm
        {
            get { return astrjyyzm; }
            set { astrjyyzm = value; }
        }
        /// <summary>
        /// 交易输出
        /// </summary>
        public string Astrjyscxml
        {
            get { return astrjyscxml; }
            set { astrjyscxml = value; }
        }
        /// <summary>
        /// 交易标志
        /// </summary>
        public long Aintappcode
        {
            get { return aintappcode; }
            set { aintappcode = value; }
        }
        /// <summary>
        /// 交易信息
        /// </summary>
        public string Astrappms
        {
            get { return astrappms; }
            set { astrappms = value; }
        }
    }
}
