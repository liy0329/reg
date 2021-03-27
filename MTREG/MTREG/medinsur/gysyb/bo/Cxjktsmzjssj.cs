using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gzsyb.gysyb.Entity
{
    /// <summary>
    /// 3.11	QUERYINFSPECCLINBILL（查询接口特殊门诊结算数据）
    /// </summary>
    class Cxjktsmzjssj
    {
        /// <summary>
        /// xml头部分
        /// </summary>
        /// <returns></returns>
        public string Cxjktsmzjssj_head()
        {
            string data = "<?xml version=\"1.0\" encoding=\"GB2312\" standalone=\"yes\"?>";
            data += "<DATA>";
            return data;
        }
        /// <summary>
        /// 输入参数
        /// </summary>
        /// <returns></returns>
        public string Cxjktsmzjssj_in(string[] parm)
        {
            string data = "<STARTDATE>" + parm[0] + "</STARTDATE>";//开始时间
            data += "<ENDDATE>" + parm[1] + "</ENDDATE>";//结束时间
            data += "<PERSONCODE>" + parm[2] + "</PERSONCODE>";//个人编码
            data += "<BILLNO>" + parm[3] + "</BILLNO>";//就诊顺序号
            data += "<BALANCEID>" + parm[4] + "</BALANCEID>";//结算编号
            data += "<RETURNID>" + parm[5] + "</RETURNID>";//退票标志  参见参数表
            data += "<INVOICENO>" + parm[6] + "</INVOICENO>";//发票号
            data += "<INSURETYPE>" + parm[7] + "</INSURETYPE>";//保险类别  参见参数表

            return data;
        }
        ////参数尾部分
        public string Cxjktsmzjssj_tail()
        {
            return "</DATA>";
        }
    }
}
