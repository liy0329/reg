using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gzsyb.bo
{
    /// <summary>
    /// 交易主函数，完成所有医疗业务的实际处理
    /// </summary>
    class Call_in
    {
        private string astrJybh;//交易编号
        private string astr_jysr_xml;//交易输入
        /// <summary>
        /// 交易编号
        /// </summary>
        public string AstrJybh
        {
            get { return astrJybh; }
            set { astrJybh = value; }
        }
        /// <summary>
        /// 交易输入
        /// </summary>
        public string Astr_jysr_xml
        {
            get { return astr_jysr_xml; }
            set { astr_jysr_xml = value; }
        }
    }
}
