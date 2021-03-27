using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gzsyb.bo
{
    /// <summary>
    /// §3.7.3.	获取医院信息（04）
    /// </summary>
    class GetHisInfo
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
        private string xmlCode_in()
        {
            string data = "<input></input>";
            return data;
        }
        ///// <summary>
        ///// 输出参数
        ///// </summary>
        ///// <returns></returns>
        //private string xmlCode_out(string[] param)
        //{
        //    string data = "<output>";
        //    data += "<prm_akb021>" + param[0] + "</prm_akb021>";//服务机构名称
        //    data += "<prm_yke362>" + param[1] + "</prm_yke362>";//医院类别
        //    data += "<prm_aka101>" + param[2] + "</prm_aka101>";//医疗等级
        //    data += "<prm_akb023>" + param[3] + "</prm_akb023>";//医疗机构类别
        //    data += "<prm_akb022>" + param[4] + "</prm_akb022>";//服务机构类型
        //    data += "<prm_akb020>" + param[5] + "</prm_akb020>";//医院编码
        //    data += "</output>";
        //    return data;
        //}
    }
}
