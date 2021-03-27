using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gzsyb.gysyb.Entity
{
    /// <summary>
    /// 3.10	QUERYINFCLINBILL（查询接口普通门诊结算数据）
    /// </summary>
    class Cxjkptmzjssj
    {
        /// <summary>
        /// xml头部分
        /// </summary>
        /// <returns></returns>
        public string Cxjkptmzjssj_head()
        {
            string data = "<?xml version=\"1.0\" encoding=\"GB2312\" standalone=\"yes\"?>";
            data += "<DATA>";
            return data;
        }
        /// <summary>
        /// 输入参数
        /// </summary>
        /// <returns></returns>
        public string Cxjkptmzjssj_in(string[] parm)
        {
            string data = "<STARTDATE>" + parm[0] + "</STARTDATE>";//开始时间
            data += "<ENDDATE>" + parm[1] + "</ENDDATE>";//结束时间
            data += "<PERSONCODE>" + parm[2] + "</PERSONCODE>";//个人编码
            data += "<BILLNO>" + parm[3] + "</BILLNO>";//就诊顺序号
            data += "<BALANCEID>" + parm[4] + "</BALANCEID>";//结算编号
            data += "<INVOICENO>" + parm[5] + "</INVOICENO>";//发票号
            data += "<RETURNID>" + parm[6] + "</RETURNID>";//退票标志
            data += "<INSURETYPE>" + parm[7] + "</INSURETYPE>";//保险类别
            data += "<CALTYPE>" + parm[8] + "</CALTYPE>";//结算方式

            return data;
        }
        ////参数尾部分
        public string Cxjkptmzjssj_tail()
        {
            return "</DATA>";
        }
    }
}
