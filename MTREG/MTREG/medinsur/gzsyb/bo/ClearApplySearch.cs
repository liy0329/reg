using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gzsyb.gzswyb.common
{
    /// <summary>
    /// §3.7.35.	清算申请查询（74）
    /// </summary>
    class ClearApplySearch
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
            data += "<prm_begindate>"+param[0]+"</prm_begindate>";// (格式：‘yyyy-mm-dd’)开始时间
            data += "<prm_enddate>"+param[1]+"</prm_enddate >";//   （格式：‘yyyy-mm-dd’）截止时间
            data += "</input>";
            return data;
        }
    }
}
