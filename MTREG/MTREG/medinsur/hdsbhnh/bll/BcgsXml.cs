using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTREG.medinsur.hdsbhnh.bo;

namespace MTREG.medinsur.hdsbhnh.bll
{
    class BcgsXml
    {
        /// <summary>
        /// 4.16住院补偿公示表C020005输入参数body
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public string outHospitalBuChangRegisterTotalInput_body(string[] parm)
        {
            string bodydata = "<body>";
            bodydata += "<D506_99>" + parm[0] + "</D506_99>";//日期类型
            bodydata += "<D506_97>" + parm[1] + "</D506_97>";//起始结算日期
            bodydata += "<D506_98>" + parm[2] + "</D506_98>";//终止结算日期
            bodydata += "<D504_10>" + parm[3] + "</D504_10>";//就诊类型
            //bodydata += "<D504_01>" + parm[4] + "</D504_01>";//住院登记流水号
            bodydata += "</body>";
            return bodydata;
        }


        //拼接接口输入字符串，并调用接口函数得到返回数据
        public BhnhReturn membersQueryFunction(string weburl, string targetOrg, string identity, string password, string[] parm)
        {
            string functionNo = "C020005";
            HeaderXml allxml = new HeaderXml();
            string data = allxml.allDataInput_head(functionNo, targetOrg, identity, password);
            data += outHospitalBuChangRegisterTotalInput_body(parm);
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
