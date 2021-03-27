using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTREG.medinsur.hdsbhnh.bll;

namespace MTREG.medinsur.hdsbhnh.bo
{
    class QtzdhqXml
    {
        /// <summary>
        /// 其它字典获取A040001输入参数body
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public string getOtherDictionaryInput_body(string[] parm)
        {
            int par = Convert.ToInt32(parm[0]);
            string bodydata = "<body>";
            bodydata += "<item>";
            bodydata += "<D911_01>" + par.ToString("D2") + "</D911_01>";
            bodydata += "</item>";
            bodydata += "</body>";
            return bodydata;
        }

        //拼接接口输入字符串，并调用接口函数得到返回数据
        public BhnhReturn membersQueryFunction(string weburl, string targetOrg, string identity, string password, string[] parm)
        {
            string functionNo = "A040001";
            HeaderXml allxml = new HeaderXml();
            string data = allxml.allDataInput_head(functionNo, targetOrg, identity, password);
            data += getOtherDictionaryInput_body(parm);
            data += allxml.allDatInput_end();
            string[] args = new string[1];
            args[0] = data;
            string nhdata;
            BhnhReturn ret = new BhnhReturn();
            try
            {
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
