using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gysyb.bo
{
    /// <summary>
    /// 3.7	QUERYHOSPSINGLEILLNESS_BG（查询医院单病种包干结算目录）
    /// </summary>
    class Cxyydbzbgjsml
    {
        /// <summary>
        /// xml头部分
        /// </summary>
        /// <returns></returns>
        public string Cxyydbzbgjsml_head()
        {
            string data = "<?xml version=\"1.0\" encoding=\"GB2312\" standalone=\"yes\"?>";
            data += "<DATA>";
            return data;
        }
        /// <summary>
        /// 输入参数
        /// </summary>
        /// <returns></returns>
        public string Cxyydbzbgjsml_in(string[] parm)
        {
            string data = "<MITYPE>" + parm[0] + "</MITYPE>";//医保险种类别  参数说明:1：职工医保；2：居民医保
            data += "<SINGLEILLNESSCODE>" + parm[1] + "</SINGLEILLNESSCODE>";//病种编码

            return data;
        }
        ////参数尾部分
        public string Cxyydbzbgjsml_tail()
        {
            return "</DATA>";
        }
    }
}
