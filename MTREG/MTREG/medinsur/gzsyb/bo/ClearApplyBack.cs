using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gzsyb.gzswyb.common
{
    /// <summary>
    /// §3.7.34.	清算申请回退（73）
    /// </summary>
    class ClearApplyBack
    {
        /// <summary>
        /// xml头部分
        /// </summary>
        /// <returns></returns>
        private string xmlCode_head()
        {
            string data = "<?xml version=\"1.0\" encoding=\"GBK\" standalone=\"yes\" ?>";
            return data;
        }
        /// <summary>
        /// 输入参数
        /// </summary>
        /// <returns></returns>
        private string xmlCode_in(string[] param)
        {
            string data = "<input>";
            data += "<prm_ykb053>"+param[0]+"</prm_ykb053>";//医院清算申请流水号
            data += "<prm_ykb037>"+param[1]+"</prm_ykb037>";//清算分中心
            data += "<prm_ykc179>"+param[2]+"</prm_ykc179>";//清算申请人姓名
            data += "<prm_yke150>"+param[3]+"</prm_yke150>";//清算申请时间
            data += "<prm_ykb065>"+param[4]+"</prm_ykb065>";//执行社会保险办法
            data += "</input>";
            return data;
        }
    }
}
