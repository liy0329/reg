using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gzsyb.bo
{
    /// <summary>
    ///  §3.7.37.	服务项目目录获取（91）
    /// </summary>
    class GetServiceItem
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
            data += "<prm_yae036>" + param[0] + "</prm_yae036>";//变更时间
            data += "<prm_outputfile>" + param[1] + "</prm_outputfile>";//输出文件绝对路径和文件名
            data += "<proxy>1</proxy>";
            data += "</input>";
            return data;
        }
    }
}
