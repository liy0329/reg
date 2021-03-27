using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gzsyb.bo
{
    /// <summary>
    /// §3.7.10.	出院办理回退（26）
    /// </summary>
    class OutHospitalHandleBack
    {
        /// <summary>
        /// xml头部分
        /// </summary>
        /// <returns></returns>
        public string xmlCode_head()
        {
            string data = "<?xml version=\"1.0\" encoding=\"GBK\" standalone=\"yes\" ?>";
            return data;
        }
        /// <summary>
        /// 输入参数
        /// </summary>
        /// <returns></returns>
        public string xmlCode_in(string[] param)
        {
            string data = "<input>";
            data += "<prm_akc190>" + param[0] + "</prm_akc190>";//就诊编号
            data += "<prm_aka130>" + param[1] + "</prm_aka130>";//支付类别
            data += "<prm_ykc141>" + param[2] + "</prm_ykc141>";//经办人姓名
            data += "<prm_aae036>" + param[3] + "</prm_aae036>";//经办时间(可空)
            data += "<prm_yab003>" + param[4] + "</prm_yab003>";//分中心编号
            data += "<prm_aac001>" + param[5] + "</prm_aac001>";//个人编号
            data += "<prm_ykb065>" + param[6] + "</prm_ykb065>";//社会保险办法
            data += "<proxy>1</proxy>";
            data += "</input>";
            return data;
        }
    }
}
