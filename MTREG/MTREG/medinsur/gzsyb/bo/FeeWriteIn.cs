using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gzsyb.bo
{
    /// <summary>
    /// §3.7.14.	住院费用明细写入（31）
    /// </summary>
    class FeeWriteIn
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
            data += "<akc190>" + param[0] + "</akc190>";//就诊序号
            data += "<aka130>" + param[1] + "</aka130>";//支付类别
            data += "<yab003>" + param[2] + "</yab003>";//分中心编号
            data += "<aac001>" + param[3] + "</aac001> ";//个人编码
            data += "<ykb065>" + param[4] + "</ykb065>";//社会保险办法
            data += "<dataset>";
            return data;
        }
        /// <summary>
        /// 输入参数结束
        /// </summary>
        /// <returns></returns>
        public string xml_Code_end()
        {
            string data = "</dataset>";
            data += "<proxy>1</proxy>";
            data += "</input>";
            return data;
        }
        /// <summary>
        /// 输入参数
        /// </summary>
        /// <returns></returns>
        public string xml_code_body(string[] param)
        {
            string data = "<row> ";
            data += "<yka105>" + param[0] + "</yka105>";//记账流水号
            data += "<ykd125>" + param[1] + "</ykd125>";//医院项目流水号(可空)
            //<商品名代码>商品名代码</商品名代码>/*考虑增加*/
            data += "<ykd126>" + param[2] + "</ykd126>";//医院项目名称(可空)
            data += "<yka002>" + param[3] + "</yka002>";//医保通用项目编码
            data += "<yka003>" + param[4] + "</yka003>";//医保通用项目名称(可空)
            data += "<akc226>" + param[5] + "</akc226> ";//数量
            data += "<akc225>" + param[6] + "</akc225>";//实际价格
            data += "<yka315>" + param[7] + "</yka315>";//明细项目费用总额
            data += "<yka097>" + param[8] + "</yka097>";//开单科室编码(可空)
            data += "<yka098>" + param[9] + "</yka098>";//开单科室名称(可空)
            data += "<ykd102>" + param[10] + "</ykd102>";//开单医生医师资格证号(可空)
            data += "<yka099>" + param[11] + "</yka099>";//开单医生姓名(可空)
            data += "<yka100>" + param[12] + "</yka100>";//受单科室编码(可空)
            data += "<yka101>" + param[13] + "</yka101>";//受单科室名称(可空)
            data += "<ykd106>" + param[14] + "</ykd106>";//受单医生编码(可空)
            data += "<yka102>" + param[15] + "</yka102>";//受单医生姓名(可空)
            data += "<yke123>" + param[16] + "</yke123>";//明细发生时间
            data += "<ykc141>" + param[17] + "</ykc141>";//经办人姓名
            data += "<aae036>" + param[18] + "</aae036>";//经办时间(可空)
            data += "<aae013>" + param[19] + "</aae013>";//备注(可空)
            data += "<yke201>" + param[20] + "</yke201>";//中药使用方式(可空)
            data += "<yka295>" + param[21] + "</yka295>";//最小计价单位(可空)
            data += "<aka074>" + param[22] + "</aka074>";//规格(可空)
            data += "<aka070>" + param[23] + "</aka070>";//剂型(可空)
            data += "<yae374>" + param[24] + "</yae374>";//剂型名称(可空)
            data += "<yke009>" + param[25] + "</yke009>";//是否医院制剂(可空)
            data += "<yke186>" + param[26] + "</yke186>";//医院审批标志(可空)暂未使用,默认传入值：1
            data += "</row>";//
            return data;
        }
    }
}
