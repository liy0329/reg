using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gysyb.bo
{
    /// <summary>
    /// 3.20	CALCLIN（普通门诊结算）
    /// </summary>
    class Ptmzjs
    {
        /// <summary>
        /// xml头部分）
        /// </summary>
        /// <returns></returns>
        public string Ptmzjs_head()
        {
            string data = "<?xml version=\"1.0\" encoding=\"GB2312\" standalone=\"yes\"?>";
            data += "<DATA>";
            return data;
        }
        /// <summary>
        /// 输入参数
        /// </summary>
        /// <returns></returns>
        public string Ptmzjs_in(string[] parm)
        {
            string data = "<CARDTYPE>" + parm[0] + "</CARDTYPE>";//卡类别   1：磁条卡；2：IC卡；3：身份证
            data += "<CARDDATA>" + parm[1] + "</CARDDATA>";//磁条数据       使用磁条卡时为磁条数据；使用IC卡时为IC卡号
            data += "<SNO>" + parm[2] + "</SNO>";//社会保障号               使用IC卡时从IC卡中读取的社会保障号，使用身份证时为身份证号码
            data += "<PERSONCODE>" + parm[3] + "</PERSONCODE>";//个人编码   使用IC卡及身份证时，通过GETPSNINFO获得的个人编码
            data += "<IPADDR>" + parm[4] + "</IPADDR>";//终端机IP地址       客户端IP地址
            data += "<PSAMNO> " + parm[5] + "</PSAMNO>";//PASM卡号          PSAM卡芯片号
            data += "<PASSWORD>" + parm[6] + "</PASSWORD>";//密码
            data += "<INSURETYPE>" + parm[7] + "</INSURETYPE>";//保险类别
            data += "<ISCAL>" + parm[8] + "</ISCAL>";//是否结算              1：实际结算，0：模拟结算
            data += "<CALTYPE>" + parm[9] + "</CALTYPE>";//结算方式          0：按项目结算，1：包干结算
            data += "<SINGLEILLNESSCODE>" + parm[10] + "</SINGLEILLNESSCODE>";//单病种编码    当选择包干结算时为必录项
            data += "<ISSPECCTRL>" + parm[11] + "</ISSPECCTRL>";//是否严控特殊项目     0：不严控；1：严控      
            data += "<ACCTWANTTOPAY>" + parm[12] + "</ACCTWANTTOPAY>";//账户支付额            模拟结算时为0；实际结算时为欲支付额
            data += "<INVOICENO>" + parm[13] + "</INVOICENO>";//发票号
            data += "<OPERATOR>" + parm[14] + "</OPERATOR>";//操作员
            data += "<DODATE>" + parm[15] + "</DODATE>";//办理日期
            data += "<STARTDATE>" + parm[16] + "</STARTDATE>";//待遇开始享受时间
            data += "<GSRDBH>" + parm[17] + "</GSRDBH>";//工伤认定编号

            return data;
        }

        public string Ptmzjs_top()
        {
            return "<ROWSET>";
        }
        public string Ptmzjs_in2(string[] parm2)
        {

            String data = "<ROW ITEMCODE=" + "\"" + parm2[0] + "\"";//医保编码
            data += " ITEMNAME=" + "\"" + parm2[1] + "\"";//项目名称
            data += " SUBJECT=" + "\"" + parm2[2] + "\""; //发票归属科目编码
            data += " SPECIFICATION=" + "\"" + parm2[3] + "\"";//规格
            data += " AGENTTYPE=" + "\"" + parm2[4] + "\"";//剂型
            data += " UNIT=" + "\"" + parm2[5] + "\"";//单位
            data += " PRICE=" + "\"" + parm2[6] + "\"";//单价
            data += " QUANTITY=" + "\"" + parm2[7] + "\"";//数量
            data += " FROMOFFICE=" + "\"" + parm2[8] + "\"";//开单科室
            data += " FROMDOCT=" + "\"" + parm2[9] + "\"";//开单医生
            data += " TOOFFICE=" + "\"" + parm2[10] + "\"";//受单科室
            data += " TODOCT=" + "\"" + parm2[11] + "\"";//受单医生
            data += " DODATE=" + "\"" + parm2[12] + "\"";//开单时间
            data += " NOTE=" + "\"" + parm2[13] + "\"";//备注

            data += "WAY=" + "\"" + parm2[14] + "\"";//用药途径
            data += "FREQ=" + "\"" + parm2[15] + "\"";//用药频次
            data += "DOSAGE=" + "\"" + parm2[16] + "\"";//单次用量
            data += "USEDAYS=" + "\"" + parm2[17] + "\"";//用药天数
            data += "DRID=" + "\"" + parm2[18] + "\"";//开药医师身份证号码
            data += "HOSPITEMCODE=" + "\"" + parm2[19] + "\"";//院内收费项目编码
            data += "TOTAL=" + "\"" + parm2[20] + "\"";//取药总量
            data += "TOTALUNIT=" + "\"" + parm2[21] + "\"";//取药总量单位
            data += "GETDAYS=" + "\"" + parm2[22] + "\"";//药量天数
            data += "USEDATE=" + "\"" + parm2[23] + "\"" + "/>";//执行时间
            return data;
        }
        public string Ptmzjs_tail2()
        {
            return "</ROWSET>";
        }
        ////参数尾部分
        public string Ptmzjs_tail()
        {
            return "</DATA>";
        }
    }
}
