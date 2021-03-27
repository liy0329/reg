using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gzsyb.bo
{
    /// <summary>
    /// 交易辅助函数，完成交易的确认处理。
    /// </summary>
    class Confirm_in
    {
        private string astrjylsh;//交易流水号
        private string astrjyyzm;//交易验证码
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
    }
}
