using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gzsyb.bo
{
    /// <summary>
    /// §3.7.28.	医保结算单打印(44)
    /// </summary>
    class SettlePrint
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
        /// <param name="param"></param>
        /// <returns></returns>
        public string xmlCode_in(string[] param)
        {
            string data = "<input>";
            data += "<prm_akc190>" + param[0] + "</prm_akc190>";//就诊编号
            data += "<prm_yab003>" + param[1] + "</prm_yab003>";//分中心编号
            data += "<prm_aka130>" + param[2] + "</prm_aka130> ";//支付类别
            data += "<prm_akc021>" + param[3] + "</prm_akc021> ";//医疗人员类别
            data += "<prm_yka103>" + param[4] + "</prm_yka103> ";//结算编号
            data += "<prm_ykb065>" + param[5] + "</prm_ykb065>";//社会保险办法
            data += "<proxy>1</proxy>";
            data += "</input>";
            return data;
        }
             
    }
}
