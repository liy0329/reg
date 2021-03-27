using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gzsyb.gzswyb.common
{
    /// <summary>
    /// §3.7.31.	清算申请（71）
    /// </summary>
    class ClearApply
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
            data += "<prm_yae366>"+param[0]+"</prm_yae366>";//清算期号(格式:201201)
            data += "<prm_ykb065>"+param[1]+"</prm_ykb065>";//执行社会保险办法(传入1（含结算信息的ykb065为1,2的数据）、3居民结算表中ykb065=’3’、4离休结算表中ykb065=’4’)
            data += "<prm_yka316>"+param[2]+"</prm_yka316>";//清算类别（01医疗清算 02生育清算 03工伤清算）
            data += "<prm_ykb037>"+param[3]+"</prm_ykb037>";//清算分中心(医疗机构所在分中心)
            data += "<prm_yka055>"+param[4]+"</prm_yka055>";//费用总额（允许为0）
            data += "<prm_yka248>"+param[5]+"</prm_yka248>";//基本医疗统筹支付金额（允许为0）
            data += "<prm_yka062>"+param[6]+"</prm_yka062>";//大额医疗支付金额（允许为0）
            data += "<prm_yka063>"+param[7]+"</prm_yka063>";//公务员统筹支付金额（允许为0）
            data += "<prm_yka065>"+param[8]+"</prm_yka065>";//个人帐户支付金额（允许为0）
            data += "<prm_ykc179>"+param[9]+"</prm_ykc179>";//清算申请人
            data += "<prm_yke150>"+param[10]+"</prm_yke150>";//清算申请时间
            data += "<prm_write>"+param[11]+"</prm_write>";//check标志,'1'表示写表,'0'表示不写表
            data += "<proxy>1</proxy>";
            data += "</input>";
            return data;
        }
    }
}
