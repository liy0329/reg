using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gysyb.bo
{
    /// <summary>
    /// 3.19	GETCLINNO（普通门诊挂号）
    /// </summary>
    class Ptmzgh
    {
        /// <summary>
        /// xml头部分
        /// </summary>
        /// <returns></returns>
        public string Ptmzgh_head()
        {
            string data = "<?xml version=\"1.0\" encoding=\"GB2312\" standalone=\"yes\"?>";
            data += "<DATA>";
            return data;
        }
        /// <summary>
        /// 输入参数
        /// </summary>
        /// <returns></returns>
        public string Ptmzgh_in(string[] parm)
        {
            string data = "<PERSONCODE>" + parm[0] + "</PERSONCODE>";//个人编码
            data += "<OPERATOR>" + parm[1] + "</OPERATOR>";//操作员
            data += "<DODATE>" + parm[2] + "</DODATE>";//办理时间

            return data;
        }
        ////参数尾部分
        public string Ptmzgh_tail()
        {
            return "</DATA>";
        }
    }
}
