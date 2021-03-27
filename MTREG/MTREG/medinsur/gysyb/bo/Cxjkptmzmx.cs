using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gzsyb.gysyb.Entity
{
    /// <summary>
    /// 3.13	QUERYINFCLINFEELIST（查询接口普通门诊费用明细）
    /// </summary>
    class Cxjkptmzmx
    {
        /// <summary>
        /// xml头部分
        /// </summary>
        /// <returns></returns>
        public string Cxjkptmzmx_head()
        {
            string data = "<?xml version=\"1.0\" encoding=\"GB2312\" standalone=\"yes\"?>";
            data += "<DATA>";
            return data;
        }
        /// <summary>
        /// 输入参数
        /// </summary>
        /// <returns></returns>
        public string Cxjkptmzmx_in(string[] parm)
        {
            string data = "<BILLNO>" + parm[0] + "</BILLNO>";//就诊顺序号
            data += "<BALANCEID>" + parm[1] + "</BALANCEID>";//结算编号
            data += "<RETURNID>" + parm[2] + "</RETURNID>";//退票标志  参见参数表

            return data;
        }
        ////参数尾部分
        public string Cxjkptmzmx_tail()
        {
            return "</DATA>";
        }
    }
}
