using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gzsyb.gzswyb.common
{
    /// <summary>
    /// 6.7.25 结算信息查询（含门诊和住院）
    /// </summary>
    class GetJsAll
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
            data += "<prm_akb020>" + param[0] + "</prm_akb020>";//医疗机构编号
            data += "<prm_begindate>" + param[1] + "</prm_begindate>";//开始时间
            data += "<prm_enddate>" + param[2] + "</prm_enddate>";//结束时间
            data += "<prm_outputfile>" + param[3] + "</prm_outputfile>";//输出文件路径
            data += "<proxy>1</proxy>";
            data += "</input>";
            return data;
        }
    }
}
