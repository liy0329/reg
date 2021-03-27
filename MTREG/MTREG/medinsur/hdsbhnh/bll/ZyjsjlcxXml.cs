using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTREG.medinsur.hdsbhnh.bll;

namespace MTREG.medinsur.hdsbhnh.bo
{
    class ZyjsjlcxXml
    {
        /// <summary>
        /// 住院结算记录查询C020007输入参数body
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public string inHospitalJsRecordQueryInput_body(string[] parm)
        {
            string bodydata = "<body>";
            bodydata += "<D504_02>" + parm[0] + "</D504_02>";//个人编码
            bodydata += "<D504_09>" + parm[1] + "</D504_09>";//住院号
            bodydata += "<D506_97>" + parm[2] + "</D506_97>";//起始结算日期
            bodydata += "<D506_98>" + parm[3] + "</D506_98>";//终止结算日期
            bodydata += "</body>";
            return bodydata;
        }

        //拼接接口输入字符串，并调用接口函数得到返回数据
        public BhnhReturn membersQueryFunction(string weburl, string targetOrg, string identity, string password, string[] parm)
        {
            string functionNo = "C020007";
            HeaderXml allxml = new HeaderXml();
            string data = allxml.allDataInput_head(functionNo, targetOrg, identity, password);
            data += inHospitalJsRecordQueryInput_body(parm);
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
