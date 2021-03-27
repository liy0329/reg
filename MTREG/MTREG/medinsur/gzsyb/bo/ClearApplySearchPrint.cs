using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gzsyb.gzswyb.common
{
    /// <summary>
    /// §3.7.36.	清算申请查询打印（75）（适用贵州省统一项目）
    /// </summary>
    class ClearApplySearchPrint
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
            data += "<prm_ykb053>"+param[0]+"</prm_ykb053>";//清算申请流水号【传入：职工对应的清算流水号,居民居民对应的清算流水号】
            data += "<prm_ykb065>"+param[1]+"</prm_ykb065>";//执行社会保险办法【(传入1（含结算信息的ykb065为1,2的数据）、3居民结算表中ykb065=’3’、4离休结算表中ykb065=’4’)】
            data += "<prm_yka054>"+param[2]+"</prm_yka054>";//报表模板【(调用报表模板：HIS接口转入：2)】
            data += "<prm_aka130>"+param[3]+"</prm_aka130>";//支付类别(可空)【默认：31 医；M31 生育；G31 工伤】
            data += "<prm_akb020>"+param[4]+"</prm_akb020>";//医院编码
            data += "<prm_yab003>"+param[5]+"</prm_yab003>";//社保经办机构
            data += "<prm_yae366>"+param[6]+"</prm_yae366>";//清算期号：201201
            data += "<proxy>1</proxy>";
            data += "</input>";
            return data;
        }
    }
}
