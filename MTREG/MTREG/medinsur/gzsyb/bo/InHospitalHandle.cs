using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gzsyb.bo
{
    /// <summary>
    /// §3.7.5.	入院办理（21）
    /// </summary>
    class InHospitalHandle
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
            data += "<prm_ykc010>" + param[0] + "</prm_ykc010>";//住院号(可空)
            data += "<prm_aac001>" + param[1] + "</prm_aac001> ";//个人编号
            data += "<prm_akc192>" + param[2] + "</prm_akc192> ";//入院日期
            data += "<prm_akc193>" + param[3] + "</prm_akc193>";//入院诊断(可空)
            data += "<prm_yke120>" + param[4] + "</prm_yke120>";//ICD10代码
            data += "<prm_ykc012>" + param[5] + "</prm_ykc012>";//入院床位(可空)
            data += "<prm_ykc011>" + param[6] + "</prm_ykc011>";//入院科室  科室为中文,不能为编码(可空)
            data += "<prm_ykc013>" + param[7] + "</prm_ykc013>";//入院经办人(可空)
            data += "<prm_ykc141>" + param[8] + "</prm_ykc141>";//入院经办人姓名(可空)
            data += "<prm_ykc014>" + param[9] + "</prm_ykc014> ";//入院经办时间(可空)
            data += "<prm_ykc009>" + param[10] + "</prm_ykc009>";//病历号(可空)
            data += "<prm_aae013>" + param[11] + "</prm_aae013>";//备注(可空)
            data += "<prm_hisbh>" + param[12] + "</prm_hisbh>";//HIS厂商编号 由银海公司提供
            data += "<prm_ykd519>" + param[13] + "</prm_ykd519>";//精神病住院新病人标志(可空)
            data += "<prm_ykb065>" + param[14] + "</prm_ykb065>";//执行社会保险办法
            data += "<proxy>1</proxy>";
            data += "</input>";
            return data;
        }
    }
}
