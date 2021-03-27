﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTREG.medinsur.hdsbhnh.bll;

namespace MTREG.medinsur.hdsbhnh.bo
{
    class ZydjscXml
    {
        /// <summary>
        /// 住院登记删除B020003输入参数body
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public string inHospitalRegisterDeleteInput_body(string[] parm)
        {
            string bodydata = "<body>";
            bodydata += "<D504_01>" + parm[0] + "</D504_01>";//住院登记流水号
            bodydata += "<D504_02>" + parm[1] + "</D504_02>";//个人编码
            bodydata += "<D504_09>" + parm[2] + "</D504_09>";//住院号
            bodydata += "</body>";
            return bodydata;
        }

        //拼接接口输入字符串，并调用接口函数得到返回数据
        public BhnhReturn membersQueryFunction(string weburl, string targetOrg, string identity, string password, string[] parm)
        {
            string functionNo = "B020003";
            HeaderXml allxml = new HeaderXml();
            string data = allxml.allDataInput_head(functionNo, targetOrg, identity, password);
            data += inHospitalRegisterDeleteInput_body(parm);
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
