using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gysyb.bo
{
    /// <summary>
    /// 3.2	GETGSINFO（获取工伤认定信息）
    /// </summary>
    class Hqgsqrxx
    {
        /// <summary>
        /// xml头部分
        /// </summary>
        /// <returns></returns>
        public string Hqgsqrxx_head()
        {
            string data = "<?xml version=\"1.0\" encoding=\"GB2312\" standalone=\"yes\"?>";
            data += "<DATA>";
            return data;
        }
        /// <summary>
        /// 输入参数
        /// </summary>
        /// <returns></returns>
        public string Hqgsqrxx_in(string[] parm)
        {
            string data = "<CARDTYPE>" + parm[0] + "</CARDTYPE>";//卡类别
            data += "<CARDDATA>" + parm[1] + "</CARDDATA>";//磁条数据
            data += "<SNO>" + parm[2] + "</SNO>";//社会保障号
            data += "<IPADDR>" + parm[3] + "</IPADDR>";//终端机IP地址
            data += "<PSAMNO>" + parm[4] + "</PSAMNO>";//PASM卡号
            data += "<PASSWORD>" + parm[5] + "</PASSWORD>";//密码
            data += "<PAYTYPE>" + parm[6] + "</PAYTYPE>";//支付类别
            return data;
        }
        ////参数尾部分
        public string Hqgrxx_tail()
        {
            return "</DATA>";
        }
    }
}
