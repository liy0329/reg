using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gysyb.bo
{
    /// <summary>
    /// 3.4	QUERYSERVICE（查询医保药品诊疗服务目录）
    /// </summary>
    class Cxybypzlfwml
    {
        /// <summary>
        /// xml头部分
        /// </summary>
        /// <returns></returns>
        public string Cxybypzlfwml_head()
        {
            string data = "<?xml version=\"1.0\" encoding=\"GB2312\" standalone=\"yes\"?>";
            data += "<DATA>";
            return data;
        }
        /// <summary>
        /// 输入参数
        /// </summary>
        /// <returns></returns>
        public string Cxybypzlfwml_in(string[] parm)
        {
            string data = "<ITEMCODE>" + parm[0] + "</ITEMCODE>";//医保编码
            data += "<ITEMPAYTYPE>" + parm[1] + "</ITEMPAYTYPE>";//项目支付类别
            return data;
        }
        ////参数尾部分
        public string Cxybypzlfwml_tail()
        {
            return "</DATA>";
        }
    }
}
