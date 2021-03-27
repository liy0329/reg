using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gysyb.bo
{
    /// <summary>
    /// 3.25	CALHOSP（住院结算）
    /// </summary>
    class Zyjs
    {
        /// <summary>
        /// xml头部分
        /// </summary>
        /// <returns></returns>
        public string Zyjs_head()
        {
            string data = "<?xml version=\"1.0\" encoding=\"GB2312\" standalone=\"yes\"?>";
            data += "<DATA>";
            return data;
        }
        /// <summary>
        /// 输入参数
        /// </summary>
        /// <returns></returns>
        public string Zyjs_in(string[] parm)
        {
            string data = "<CARDTYPE>" + parm[0] + "</CARDTYPE>";//卡类别
            data += "<CARDDATA>" + parm[1] + "</CARDDATA>";//磁条数据
            data += "<SNO>" + parm[2] + "</SNO>";//社会保障号
            data += "<IPADDR>" + parm[3] + "</IPADDR>";//终端机IP地址
            data += "<PSAMNO>" + parm[4] + "</PSAMNO>";//PASM卡号
            data += "<PERSONCODE>" + parm[5] + "</PERSONCODE>";//个人编码
            data += "<PASSWORD>" + parm[6] + "</PASSWORD>";//密码
            data += "<ISCAL>" + parm[7] + "</ISCAL>";//是否结算
            data += "<ISSPECCTRL>" + parm[8] + "</ISSPECCTRL>";//是否严控特殊项目     0：不严控；1：严控      
            data += "<ACCTWANTTOPAY>" + parm[9] + "</ACCTWANTTOPAY>";//账户支付额
            data += "<INVOICENO>" + parm[10] + "</INVOICENO>";//发票号
            data += "<RECKONINGTYPE>" + parm[11] + "</RECKONINGTYPE>";//清算方式
            data += "<SINGLEILLNESSCODE>" + parm[12] + "</SINGLEILLNESSCODE>";//单病种编码
            data += "<OPERATOR>" + parm[13] + "</OPERATOR>";//操作员
            data += "<DODATE>" + parm[14] + "</DODATE>";//办理日期
            data += "<ROWSET>";

            return data;
        }


        public string Zyjs_in2(string[] parm2)
        {
            string data = "<ROW ITEMSERIAL=" + "\"" + parm2[0] + "\"";//数据批号
            data += " ITEMCODE=" + "\"" + parm2[1] + "\"";//医保编码
            data += " ITEMNAME=" + "\"" + parm2[2] + "\"";//项目名称
            data += " SUBJECT=" + "\"" + parm2[3] + "\""; //发票归属科目编码
            data += " SPECIFICATION=" + "\"" + parm2[4] + "\""; //规格
            data += " AGENTTYPE=" + "\"" + parm2[5] + "\"";//剂型
            data += " UNIT=" + "\"" + parm2[6] + "\"";//单位
            data += " PRICE=" + "\"" + parm2[7] + "\"";//单价
            data += " QUANTITY=" + "\"" + parm2[8] + "\"";//数量
            data += " FROMOFFICE=" + "\"" + parm2[9] + "\"";//开单科室
            data += " FROMDOCT=" + "\"" + parm2[10] + "\"";//开单医生
            data += " TOOFFICE=" + "\"" + parm2[11] + "\"";//受单科室
            data += " TODOCT=" + "\"" + parm2[12] + "\"";//受单医生
            data += " DODATE=" + "\"" + parm2[13] + "\"";//开单时间
            data += " NOTE=" + "\"" + parm2[14] + "\"";//备注
            data += " RETURNFLAG=" + "\"" + parm2[15] + "\"";//冲销标志

            data += "WAY=" + "\"" + parm2[16] + "\"";//用药途径
            data += "FREQ=" + "\"" + parm2[17] + "\"";//用药频次
            data += "DOSAGE=" + "\"" + parm2[18] + "\"";//单次用量
            data += "USEDAYS=" + "\"" + parm2[19] + "\"";//用药天数
            data += "DRID=" + "\"" + parm2[20] + "\"";//开药医师身份证号码
            data += "HOSPITEMCODE=" + "\"" + parm2[21] + "\"";//院内收费项目编码
            data += "TOTAL=" + "\"" + parm2[22] + "\"";//取药总量
            data += "TOTALUNIT=" + "\"" + parm2[23] + "\"";//取药总量单位
            data += "GETDAYS=" + "\"" + parm2[24] + "\"";//药量天数
            data += "USEDATE=" + "\"" + parm2[25] + "\"" + "/>";//执行时间

            return data;

        }
        ////参数尾部分
        public string Zyjs_tail()
        {
            string data = " </ROWSET>";
            data += "</DATA >";
            return data;
        }
    }
}
