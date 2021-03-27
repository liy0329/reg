using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gzsyb.bo
{
    /// <summary>
    /// §3.7.39.	获取医保中心日期（52）
    /// </summary>
    class GetYiBaoDate
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
            data += "</input>";
            return data;
        }
    }
}
