using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gzsyb.bo
{
    /// <summary>
    /// 交易辅助函数，完成交易的取消处理
    /// </summary>
    class Cancel_in
    {
        private string astrjylsh;//交易流水号
        /// <summary>
        /// 交易流水号
        /// </summary>
        public string Astrjylsh
        {
            get { return astrjylsh; }
            set { astrjylsh = value; }
        }
    }
}
