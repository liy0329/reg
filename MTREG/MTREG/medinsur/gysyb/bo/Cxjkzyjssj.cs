using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gysyb.bo
{
    /// <summary>
    /// 3.12	QUERYINFHOSPBILL（查询接口住院结算数据）
    /// </summary>
    class Cxjkzyjssj
    {
        /// <summary>
        /// xml头部分
        /// </summary>
        /// <returns></returns>
        public string Cxjkzyjssj_head()
        {
            string data = "<?xml version=\"1.0\" encoding=\"GB2312\" standalone=\"yes\"?>";
            data += "<DATA>";
            return data;
        }
        /// <summary>
        /// 输入参数
        /// </summary>
        /// <returns></returns>
        public string Cxjkzyjssj_in(string[] parm)
        {
            string data = "<STARTDATE>" + parm[0] + "</STARTDATE>";//开始时间
            data += "<ENDDATE>" + parm[1] + "</ENDDATE>";//结束时间
            data += "<PAYTYPE>" + parm[2] + "</PAYTYPE>";//支付类别
            data += "<PERSONCODE>" + parm[3] + "</PERSONCODE>";//个人编码
            data += "<BILLNO>" + parm[5] + "</BILLNO>";//就诊顺序号
            //data += "<BILLNO>201010000191300019F0</BILLNO>";
            data += "<BALANCEID>" + parm[4] + "</BALANCEID>";//结算编号
            //data += "<BALANCEID></BALANCEID>";//结算编号
            data += "<INVOICENO>" + parm[6] + "</INVOICENO>";//发票号
            data += "";//"<RETURNID>" + parm[7] + "</RETURNID>";//退票标志  参见参数表
            data += "<INSURETYPE>" + parm[8] + "</INSURETYPE>";//保险类别  参见参数表
            data += "<CALTYPE>" + parm[9] + "</CALTYPE>";//结算方式  参见参数表

            return data;
        }
        ////参数尾部分
        public string Cxjkzyjssj_tail()
        {
            return "</DATA>";
        }
    }
}
