using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gzsyb.bo
{
    /// <summary>
    /// 交易辅助函数，完成不确定交易的查询处理
    /// </summary>
    class Getuncertaintytrade_in
    {
        private string astrJybh;//交易编号
        /// <summary>
        /// 交易编号
        /// </summary>
        public string AstrJybh
        {
            get { return astrJybh; }
            set { astrJybh = value; }
        }
    }
}
