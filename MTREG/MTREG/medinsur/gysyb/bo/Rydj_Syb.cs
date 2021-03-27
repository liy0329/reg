using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gysyb.bo
{
    /// <summary>
    /// 入院登记
    /// </summary>
    class Rydj_Syb
    {
        /// <summary>
        /// xml头部分
        /// </summary>
        /// <returns></returns>
        public string Rydj_head()
        {
            string data = "<?xml version=\"1.0\" encoding=\"GB2312\" standalone=\"yes\"?>";
            data += "<DATA>";
            return data;
        }
        /// <summary>
        /// 输入参数
        /// </summary>
        /// <returns></returns>
        public string Rydj_in(string[] parm)
        {
            string data = "<CARDTYPE>" + parm[0] + "</CARDTYPE>";//卡类别        使用IC卡及身份证时，通过GETPSNINFO获得的个人编码。
            data += "<CARDDATA>" + parm[1] + "</CARDDATA>";//磁条数据            客户端IP地址
            data += "<SNO>" + parm[2] + "</SNO>";//社会保障号                    PSAM卡芯片号
            data += "<PERSONCODE>" + parm[3] + "</PERSONCODE>";//个人编码        六位数字
            data += "<IPADDR>" + parm[4] + "</IPADDR>";//终端机IP地址            参见参数表
            data += "<PSAMNO>" + parm[5] + "</PSAMNO>";//PASM卡号                参见参数表
            data += "<PASSWORD>" + parm[6] + "</PASSWORD>";//密码
            data += "<INSURETYPE>" + parm[7] + "</INSURETYPE>";//保险类别
            data += "<PAYTYPE>" + parm[8] + "</PAYTYPE>";//支付类别
            data += "<HOSPNO>" + parm[9] + "</HOSPNO>";//住院号
            data += "<ISINHOSP>" + parm[10] + "</ISINHOSP>";//参保前已在院
            data += "<DIAGNOSES>" + parm[11] + "</DIAGNOSES>";//诊断
            data += "<DOCTOR>" + parm[12] + "</DOCTOR>";//诊断医生
            data += "<OFFICE>" + parm[13] + "</OFFICE>";//科室
            data += "<REGDATE>" + parm[14] + "</REGDATE>";//入院时间
            data += "<OPERATOR>" + parm[15] + "</OPERATOR>";//操作员
            data += "<DODATE>" + parm[16] + "</DODATE>";//办理时间
            data += "<GSRDBH>" + parm[17] + "</GSRDBH>";//工伤认定编号
            data += "<KFZYBZ>" + parm[18] + "</KFZYBZ>";//工伤康复住院标志         0：否；1：是

            return data;
        }
        ////参数尾部分
        public string Rydj_tail()
        {
            return "</DATA>";
        }
    }
}
