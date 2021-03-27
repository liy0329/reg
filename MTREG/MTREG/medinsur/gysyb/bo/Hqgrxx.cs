using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gysyb.bo
{
    /// <summary>
    /// 3.1	GETPSNINFO（获取个人信息)
    /// </summary>
    class Hqgrxx
    {
        /// <summary>
        /// xml头部分
        /// </summary>
        /// <returns></returns>
        public string Hqgrxx_head()
        {
            string data = "<?xml version=\"1.0\" encoding=\"GB2312\" standalone=\"yes\" ?>";

            data += "<DATA>";
            return data;
        }
        /// <summary>
        /// 输入参数
        /// </summary>
        /// <returns></returns>
        public string Hqgrxx_in(string[] parm)
        {
            string data = "<CARDTYPE>" + parm[0] + "</CARDTYPE>";//卡类别
            data += "<CARDDATA>" + parm[1] + "</CARDDATA>";//卡类别
            data += "<SNO>" + parm[2] + "</SNO>";//社会保障号
            data += "<IPADDR>" + parm[3] + "</IPADDR>";//终端机IP地址
            data += "<PSAMNO>" + parm[4] + "</PSAMNO>";//PASM卡号
            data += "<PASSWORD>" + parm[5] + "</PASSWORD>";//密码
            data += "<PAYTYPE>" + parm[6] + "</PAYTYPE>";//支付类别
            data += "<INSURETYPE>" + parm[7] + "</INSURETYPE>";//保险类别
            data += "<SPECILLNESSCODE>" + parm[8] + "</SPECILLNESSCODE>";//特种病编码
            data += "<GSRDBH>" + parm[9] + "</GSRDBH>";//工伤认定编号
            data += "<STARTDATE>" + parm[10] + "</STARTDATE>";//经办时间
            return data;
        }
        ////参数尾部分
        public string Hqgrxx_tail()
        {
            return "</DATA>";
        }
    }
}
