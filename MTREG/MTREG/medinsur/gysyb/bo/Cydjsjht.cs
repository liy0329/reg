using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gysyb.bo
{
    class Cydjsjht
    {
        /// <summary>
        /// xml头部分
        /// </summary>
        /// <returns></returns>
        public string Cydjsjht_head()
        {
            string data = "<?xml version=\"1.0\" encoding=\"GB2312\" standalone=\"yes\"?>";
            data += "<DATA>";
            return data;
        }
        /// <summary>
        /// 输入参数
        /// </summary>
        /// <returns></returns>
        public string Cydjsjht_in(string[] parm)
        {
            string data = "<BILLNO>" + parm[0] + "</BILLNO>";//就诊顺序号
            data += "<OPERATOR>" + parm[1] + "</OPERATOR>";//操作员
            data += "<DODATE>" + parm[2] + "</DODATE>";//办理时间

            return data;
        }
        ////参数尾部分
        public string Cydjsjht_tail()
        {
            return "</DATA>";
        }
    }
}
