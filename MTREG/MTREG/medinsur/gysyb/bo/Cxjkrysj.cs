using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gysyb.bo
{
    /// <summary>
    /// 3.16	QUERYINFHOSPREG（查询接口入院数据)
    /// </summary>
    class Cxjkrysj
    {
         /// <summary>
        /// xml头部分
        /// </summary>
        /// <returns></returns>
        public string Cxjkrysj_head()
        {
            string data = "<?xml version=\"1.0\" encoding=\"GB2312\" standalone=\"yes\"?>";
            data += "<DATA>";
            return data;
        }
        /// <summary>
        /// 输入参数
        /// </summary>
        /// <returns></returns>
        public  string Cxjkrysj_in(string[] parm)
        {
            string data = "<STARTDATE>"+parm[0]+"</STARTDATE>";//开始时间
            data += "<ENDDATE>"+parm[1]+"</ENDDATE>";//结束时间
            data += "<PERSONCODE>"+parm[2]+"</PERSONCODE>";//个人编码
            data += "<PAYTYPE>"+parm[3]+"</PAYTYPE>";//支付类别
            data += "<BILLNO>"+parm[4]+"</BILLNO>";//就诊顺序号
            data += "<ISOUT>"+parm[5]+"</ISOUT>";//出院标志
            data += "<INSURETYPE>" + parm[6] + "</INSURETYPE>";//保险类别

            return data;
        }
        ////参数尾部分
        public string Cxjkrysj_tail()
        {
            return "</DATA>";
        }
    }
}
