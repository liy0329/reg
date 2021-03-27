using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gzsyb.bo
{
    /// <summary>
    /// 交易辅助函数，完成交易的取消处理
    /// </summary>
    class Cancel_out
    {
        private long aintAppcode;//交易标志
        private string astrAppmsg;//交易信息
        /// <summary>
        /// 交易标志
        /// </summary>
        public long AintAppcode
        {
            get { return aintAppcode; }
            set { aintAppcode = value; }
        }
        /// <summary>
        /// 交易信息
        /// </summary>
        public string AstrAppmsg
        {
            get { return astrAppmsg; }
            set { astrAppmsg = value; }
        }
    }
}
