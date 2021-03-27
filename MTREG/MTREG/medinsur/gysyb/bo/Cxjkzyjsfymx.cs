using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gysyb.bo
{
    /// <summary>
    /// 3.15	QUERYINFHOSPFEELIST（查询接口住院结算费用明细)
    /// </summary>
    class Cxjkzyjsfymx
    {
        /// <summary>
        /// xml头部分
        /// </summary>
        /// <returns></returns>
        public string Cxjkzyjsfymx_head()
        {
            string data = "<?xml version=\"1.0\" encoding=\"GB2312\" standalone=\"yes\"?>";
            data += "<DATA>";
            return data;
        }
        /// <summary>
        /// 输入参数
        /// </summary>
        /// <returns></returns>
        public string Cxjkzyjsfymx_in(string[] parm)
        {
            string data = "<BILLNO>" + parm[0] + "</BILLNO>";//就诊顺序号
            data += "<BALANCEID>" + parm[1] + "</BALANCEID>";//结算编号
            data += "<RETURNID>" + parm[2] + "</RETURNID>";//退票标志   参见参数表
            data += "<STARTDATE>" + parm[3] + "</STARTDATE>";//开始时间
            data += "<ENDDATE>" + parm[4] + "</ENDDATE>";//结束时间

            return data;
        }
        ////参数尾部分
        public string Cxjkzyjsfymx_tail()
        {
            return "</DATA>";
        }
    }
}
