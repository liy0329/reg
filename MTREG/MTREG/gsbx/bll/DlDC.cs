using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;
using System.Security.Cryptography;
using WindowsFormsApplication1.common;
using zhongluyiyuan.Util;
using WindowsFormsApplication1;
using MTREG.gsbx1;
using System.IO;
using MTHIS.tools;
namespace zhongluyiyuan.gsbx.bll
{
    class DlDC
    {
        SendHisControllerImplService webServ = new SendHisControllerImplService();
        private string falg;
        public string Falg
        {
            get { return falg; }
            set { falg = value; }
        }
        private string sessionid;
        public string Sessionid
        {
            get { return sessionid; }
            set { sessionid = value; }
        }
        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        GSBX_IN in1 = new GSBX_IN();
        GSBX_OUT out1 = new GSBX_OUT();
        GSBXinterface GSBXinterface = new GSBXinterface();
        public string dengru()
        {
            in1.Log_name = "login";
            in1.YwName = "login";
            MD5 md5 = new MD5CryptoServiceProvider();
            string user = IniUtils.IniReadValue(IniUtils.syspath, "gsbx", "user");
            string sign = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(IniUtils.IniReadValue(IniUtils.syspath, "gsbx", "pwd"), "MD5").ToUpper();

            string data1 = "<loginReqData>";
            data1 += " <username>" + user + "</username>";
            data1 += " <password>" + sign + "</password>";
            data1 += " </loginReqData>";
            in1.YwData = Base64.encodebase64(in1.head() + data1);

            out1 = GSBXinterface.request(in1);
            if (out1.State == "2")
            {
                falg = "1";
                message= "工伤保险提示！\r\n" + in1.Log_name + "出错！\r\n【" + out1.Message + "】";
                return falg;
            }

            out1.State = out1.Ds.Tables["loginRespData"].Rows[0]["code"].ToString().Trim();
            out1.Message = out1.Ds.Tables["loginRespData"].Rows[0]["msg"].ToString().Trim();
            if (out1.State != "0")
            {
                if (out1.State == "21003")
                {
                    sessionid = out1.Ds.Tables["loginRespData"].Rows[0]["sessionid"].ToString().Trim();
                    falg = "0";
                    return falg;
                }
                //MessageBox.Show(in1.Log_name + "出错！【" + out1.Message + "】");
                falg = "1";
                message = out1.Message;
                return falg;
            }
            sessionid = out1.Ds.Tables["loginRespData"].Rows[0]["sessionid"].ToString().Trim();
            falg = "0";
            return falg;
        }
        public string dengchu(string sessionid)
        {
            in1.Log_name = "logout";
            in1.YwName = "logout";
            MD5 md5 = new MD5CryptoServiceProvider();
            string user = IniUtils.IniReadValue(IniUtils.syspath, "gsbx", "user");
            string sign = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(IniUtils.IniReadValue(IniUtils.syspath, "gsbx", "pwd"), "MD5").ToUpper();

            string data1 = "<logoutReqData>";
            data1 += " <sessionid>" + sessionid + "</sessionid>";
            data1 += " <username>" + user + "</username>";
            data1 += " <password>" + sign + "</password>";
            data1 += " </logoutReqData>";
            in1.YwData = Base64.encodebase64(in1.head() + data1);

            out1 = GSBXinterface.request(in1);
            if (out1.State == "2")
            {
                falg = "1";
                message = "工伤保险提示！\r\n" + in1.Log_name + "出错！\r\n【" + out1.Message + "】";
                return falg;
            }

            out1.State = out1.Ds.Tables["logoutRespData"].Rows[0]["code"].ToString().Trim();
            out1.Message = out1.Ds.Tables["logoutRespData"].Rows[0]["msg"].ToString().Trim();
            if (out1.State != "0")
            {
                //MessageBox.Show(in1.Log_name + "出错！【" + out1.Message + "】");
                falg = "1";
                message = out1.Message;
                return falg;
            }
            falg = "0";
            sessionid = "";
            return falg;
        }
    }
}
