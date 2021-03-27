using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gysyb.bo
{
    /// <summary>
    /// 3.27	CALHOSPSP（住院特殊结算）
    /// </summary>
    class Zytsjs
    {
        /// <summary>
        /// xml头部分）
        /// </summary>
        /// <returns></returns>
        public string Zytsjs_head()
        {
            string data = "<?xml version=\"1.0\" encoding=\"GB2312\" standalone=\"yes\"?>";
            data += "<DATA>";
            return data;
        }
        /// <summary>
        /// 输入参数
        /// </summary>
        /// <returns></returns>
        public string Zytsjs_in(string[] parm)
        {
            string data = "<PERSONCODE>" + parm[0] + "</PERSONCODE>";//个人编码
            data += "<ISCAL>" + parm[1] + "</ISCAL>";//是否结算                       1：实际结算；0：模拟结算
            data += "<ACCTWANTTOPAY>" + parm[2] + "</ACCTWANTTOPAY>";//账户支付额     模拟结算时为0
            data += "<INVOICENO>" + parm[3] + "</INVOICENO>";//发票号
            data += "<OPERATOR>" + parm[4] + "</OPERATOR>";//操作员
            data += "<DODATE>" + parm[5] + "</DODATE>";//办理日期


            return data;
        }


        public string Zytsjs_in2(string[] parm2)
        {
            string data = "<ROWSET>";
            data += "<ROW ITEMSERIAL=" + "\"" + parm2[0] + "\"";//数据批号
            data += "ITEMCODE=" + "\"" + parm2[1] + "\"";//医保编码
            data += "ITEMNAME=" + "\"" + parm2[2] + "\"";//项目名称
            data += "SUBJECT=" + "\"" + parm2[3] + "\""; //发票归属科目编码
            data += "SPECIFICATION=" + "\"" + parm2[4] + "\"";//规格
            data += "AGENTTYPE=" + "\"" + parm2[5] + "\"";//剂型
            data += "UNIT=" + "\"" + parm2[6] + "\"";//单位
            data += "PRICE=" + "\"" + parm2[7] + "\"";//单价
            data += "QUANTITY=" + "\"" + parm2[8] + "\"";//数量
            data += "FROMOFFICE=" + "\"" + parm2[9] + "\""; //开单科室
            data += "FROMDOCT=" + "\"" + parm2[10] + "\"";//开单医生
            data += "TOOFFICE=" + "\"" + parm2[11] + "\"";//受单科室
            data += "TODOCT=" + "\"" + parm2[12] + "\"";//受单医生
            data += "DODATE=" + "\"" + parm2[13] + "\"";//开单时间
            data += "NOTE=" + "\"" + parm2[14] + "\"";//备注
            data += "RETURNFLAG=" + "\"" + parm2[15] + "\"" + "/>";//冲销标志
            data += "</ROWSET>";
            return data;
        }
        ////参数尾部分
        public string Zytsjs_tail()
        {
            return "</DATA>";
        }
    }
}
