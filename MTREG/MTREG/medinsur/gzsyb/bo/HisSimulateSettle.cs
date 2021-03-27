using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gzsyb.bo
{
    /// <summary>
    /// §3.7.24.	住院模拟结算(43) 
    /// </summary>
    class HisSimulateSettle
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
            data += "<prm_aac001>" + param[1] + "</prm_aac001>";//个人编号
            data += "<prm_yab003>" + param[2] + "</prm_yab003>";//分中心编号
            data += "<prm_aka130>" + param[3] + "</prm_aka130>";//支付类别
            data += "<prm_ykb065>" + param[4] + "</prm_ykb065>";//执行的社保办法
            data += "<prm_hisfyze>" + param[5] + "</prm_hisfyze>";//HIS费用总额
            data += "<proxy>1</proxy>";
            data += "</input>";
            return data;
        }
    }
}
