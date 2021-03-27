using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gzsyb.bo
{
    /// <summary>
    /// 交易辅助函数，完成不确定交易的查询处理
    /// </summary>
    class Getuncertaintytrade_out
    {
        private string astr_jgxml;//交易输出
        private long aintAppcode;//交易标志
        private string astrAppmsg;//交易信息
        /// <summary>
        /// 交易输出
        /// </summary>
        public string Astr_jgxml
        {
            get { return astr_jgxml; }
            set { astr_jgxml = value; }
        }
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
