using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTREG.medinsur.hdsbhnh.bll;

namespace MTREG.medinsur.hdsbhnh.bo
{
    class ZyjsXml
    {
        /// <summary>
        /// 住院结算 B020012输入参数body
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public string inHospitalJsInput_body(string[] parm)
        {
            string bodydata = "<body>";
            bodydata += "<D504_09>" + parm[0] + "</D504_09>";//住院号
            bodydata += "<D504_02>" + parm[1] + "</D504_02>";//个人编码
            bodydata += "<D506_52>" + parm[2] + "</D506_52>";//发票号
            bodydata += "<D506_53>" + parm[3] + "</D506_53>";//发票时间
            bodydata += "<D504_20>" + parm[4] + "</D504_20>";//出院状态
            bodydata += "<D504_17>" + parm[5] + "</D504_17>";//出院科室
            bodydata += "<D504_54>" + parm[6] + "</D504_54>";//HIS科室代码
            bodydata += "<D504_60>" + parm[7] + "</D504_60>";//HIS科室名称
            bodydata += "<D504_12>" + parm[8] + "</D504_12>";//出院时间
            bodydata += "<D504_03>" + parm[9] + "</D504_03>";//患者姓名
            bodydata += "<item>";
            bodydata += "<D506_101>" + parm[10] + "</D506_101>";//类型代码
            bodydata += "<D506_102>" + parm[11] + "</D506_102>";//类型值
            bodydata += "</item>";
            bodydata += "<D506_54>" + parm[12] + "</D506_54>";//出院诊断
            bodydata += "<D504_100>" + parm[13] + "</D504_100>";//第三方保险
            bodydata += "</body>";
            return bodydata;
        }

        //拼接接口输入字符串，并调用接口函数得到返回数据
        public BhnhReturn membersQueryFunction(string weburl, string targetOrg, string identity, string password, string[] parm)
        {
            string functionNo = "B020012";
            HeaderXml allxml = new HeaderXml();
            string data = allxml.allDataInput_head(functionNo, targetOrg, identity, password);
            data += inHospitalJsInput_body(parm);
            data += allxml.allDatInput_end();
            string[] args = new string[1];
            args[0] = data;
            string nhdata;
            BhnhReturn ret = new BhnhReturn();
            try
            {
                nhdata = (string)BllHdsbhnh.InvokeWebService(weburl, "nh_pipe", args).ToString();//调用webservice是需要创建实例
            }
            catch (Exception e)
            {
                ret.Ret_mesg = "客户端调用失败！" + e.ToString();
                ret.Ret_flag = false;
                return ret;
            }
            ret.Ret_flag = true;
            ret.Ret_data = nhdata; //成功返回数据 
            return ret;
        }
    }
}
