using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gysyb.bo
{
    /// <summary>
    /// 3.29	RETLX（离休退票）
    /// </summary>
    class Lxtp
    {
        /// <summary>
        /// xml头部分
        /// </summary>
        /// <returns></returns>
        public string Lxtp_head()
        {
            string data = "<?xml version=\"1.0\" encoding=\"GB2312\" standalone=\"yes\"?>";
            data += "<DATA>";
            return data;
        }
        /// <summary>
        /// 输入参数
        /// </summary>
        /// <returns></returns>
        public string Lxtp_in(string[] parm)
        {
            string data = "<BILLNO>" + parm[0] + "</BILLNO>";//就诊顺序号
            data += "<BALANCEID>" + parm[1] + "</BALANCEID>";//结算编号
            data += "<PAYTYPE>" + parm[2] + "</PAYTYPE>";//支付类别
            data += "<OPERATOR>" + parm[3] + "</OPERATOR>";//操作员
            data += "<DODATE>" + parm[4] + "</DODATE>";//办理时间

            return data;
        }
        ////参数尾部分
        public string Lxtp_tail()
        {
            return "</DATA>";
        }
    }
}
