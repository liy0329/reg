using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gzsyb.bo
{
    /// <summary>
    /// 初始化函数
    /// </summary>
    class Init_out
    {
        private long aintAppcode;//交易标志
        private string astrAppmsg;//交易信息
        /// <summary>
        /// 交易标志long类型
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
