using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gysyb.bo
{

    class Tp
    {
        /// <summary>
        /// 3.28	RETBALANCE（退票）
        /// </summary>
        /// <returns></returns>
        public string Tp_head()
        {
            string data = "<?xml version=\"1.0\" encoding=\"GB2312\" standalone=\"yes\"?>";
            data += "<DATA>";
            return data;
        }
        /// <summary>
        /// 输入参数
        /// </summary>
        /// <returns></returns>
        public string Tp_in(string[] parm)
        {
            string data = "<BILLNO>" + parm[0] + "</BILLNO>";//就诊顺序号
            data += "<BALANCEID>" + parm[1] + "</BALANCEID>";//结算编号
            data += "<PAYTYPE>" + parm[2] + "</PAYTYPE>";//支付类别
            data += "<OPERATOR>" + parm[3] + "</OPERATOR>";//操作员
            data += "<DODATE>" + parm[4] + "</DODATE>";//办理时间

            return data;
        }
        ////参数尾部分
        public string Tp_tail()
        {
            return "</DATA>";
        }
    }
}
