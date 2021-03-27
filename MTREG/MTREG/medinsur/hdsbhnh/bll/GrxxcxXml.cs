using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTREG.medinsur.hdsbhnh.bll;

namespace MTREG.medinsur.hdsbhnh.bo
{
    class GrxxcxXml
    {
        /// <summary>
        /// 个人信息查询（个人发卡预留）C030002输入参数body
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public string personnalInfoQueryInput_body(string[] parm)
        {
            string bodydata = "<body>";
            bodydata += "<D401_21_A>" + parm[0] + "</D401_21_A>";
            bodydata += "<D401_10>" + parm[1] + "</D401_10>";
            bodydata += "</body>";
            return bodydata;
        }

        //拼接接口输入字符串，并调用接口函数得到返回数据
        public BhnhReturn membersQueryFunction(string weburl, string targetOrg, string identity, string password, string[] parm)
        {
            string functionNo = "C030002";
            HeaderXml allxml = new HeaderXml();
            string data = allxml.allDataInput_head(functionNo, targetOrg, identity, password);
            data += personnalInfoQueryInput_body(parm);
            data += allxml.allDatInput_end();

            string nhdata;
            BhnhReturn ret = new BhnhReturn();
            try
            {
                string[] args = new string[1];
                args[0] = data;
                nhdata = (string)BllHdsbhnh.InvokeWebService(weburl,"nh_pipe", args).ToString();//调用webservice是需要创建实例
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
