using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTREG.medinsur.hdsbhnh.bo;

namespace MTREG.medinsur.hdsbhnh.bll
{
    class SczyjzXml
    {
        /// <summary>
        /// 4.41删除住院记账B020015
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private string scfy_body(string[] parm)
        {
            string bodydata = "<body>";
            bodydata += "<D504_01>" + parm[0] + "</D504_01>";//住院登记流水号

            bodydata += "</body>";
            return bodydata;
        }



        //拼接接口输入字符串，并调用接口函数得到返回数据
        public BhnhReturn membersQueryFunction(string weburl, string targetOrg, string identity, string password, string[] parm)
        {
            string functionNo = "B020015";
            HeaderXml headerXml = new HeaderXml();
            string data = headerXml.allDataInput_head(functionNo, targetOrg, identity, password);
            data += scfy_body(parm);
            data += headerXml.allDatInput_end();
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
