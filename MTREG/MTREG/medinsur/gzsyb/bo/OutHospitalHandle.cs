using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gzsyb.bo
{
    /// <summary>
    /// §3.7.9.	出院办理（25）
    /// </summary>
    class OutHospitalHandle
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
            data += "<prm_aac001>" + param[1] + "</prm_aac001>";//个人编号
            data += "<prm_aka130>" + param[2] + "</prm_aka130>";//支付类别
            data += "<prm_akc195>" + param[3] + "</prm_akc195>";//出院原因(可空) (1、治愈；2、好转；3、死亡；4转院;5精神病中途结算(只有精神病按日包干的中途结算使用);9 其他)
            data += "<prm_akc194>" + param[4] + "</prm_akc194>";//出院日期(可空)
            data += "<prm_akc196>" + param[5] + "</prm_akc196>";//出院诊断(可空)
            data += "<prm_ykc015>" + param[6] + "</prm_ykc015>";//出院科室(可空)科室为中文,不能为编码
            data += "<prm_ykc016>" + param[7] + "</prm_ykc016>";//出院床位(可空)
            data += "<prm_ykc017>" + param[8] + "</prm_ykc017>";//经办人姓名(可空)
            data += "<prm_ykc018>" + param[9] + "</prm_ykc018>";//出院经办时间(可空)
            data += "<prm_yab003>" + param[10] + "</prm_yab003>";//分中心编号
            data += "<prm_ykd065>" + param[11] + "</prm_ykd065>";//出院附属诊断代码
            data += "<prm_ykd018>" + param[12] + "</prm_ykd018>";//第一出院疾病诊断代码(可空)
            data += "<prm_ykd019>" + param[13] + "</prm_ykd019>";//第二出院疾病诊断代码(可空)
            data += "<prm_ykd020>" + param[14] + "</prm_ykd020>";//第三出院疾病诊断代码(可空)
            data += "<prm_ykd021>" + param[15] + "</prm_ykd021>";//第四出院疾病诊断代码(可空)
            data += "<prm_ykd022>" + param[16] + "</prm_ykd022>";//第五出院疾病诊断代码(可空)
            data += "<prm_ykd023>" + param[17] + "</prm_ykd023>";//第六出院疾病诊断代码(可空)
            data += "<prm_ykd024>" + param[18] + "</prm_ykd024>";//第七出院疾病诊断代码(可空)
            data += "<prm_ykd025>" + param[19] + "</prm_ykd025>";//第八出院疾病诊断代码(可空)
            data += "<prm_ykb065>" + param[20] + "</prm_ykb065>";//社会保险办法
            data += "<proxy>1</proxy>";
            data += "</input>";
            return data;
        }
    }
}
