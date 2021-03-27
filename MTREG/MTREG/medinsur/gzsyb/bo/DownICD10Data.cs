using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gzsyb.bo
{
    /// <summary>
    /// §3.7.40.	中心ICD10数据下载（61）
    /// </summary>
    class DownICD10Data
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
            data += "<prm_outputfile>" + param[0] + "</prm_outputfile>";//输出文件绝对路径和文件名
            data += "</input>";
            return data;
        }
    }
}
