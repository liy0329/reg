using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gysyb.bo
{
    /// <summary>
    /// 3.23	SETCALTYPE（设置结算方式)
    /// </summary>
    class Szjsfs
    {
        /// <summary>
        /// xml头部分
        /// </summary>
        /// <returns></returns>
        public string Szjsfs_head()
        {
            string data = "<?xml version=\"1.0\" encoding=\"GB2312\" standalone=\"yes\"?>";
            data += "<DATA>";
            return data;
        }
        /// <summary>
        /// 输入参数
        /// </summary>
        /// <returns></returns>
        public string Szjsfs_in(string[] parm)
        {
            string data = "<PERSONCODE>" + parm[0] + "</PERSONCODE>";//个人编码
            data += "<CALTYPE>" + parm[1] + "</CALTYPE>";//结算方式          当为1时，单病种编码不能为空
            data += "<SINGLEILLNESSCODE>" + parm[2] + "</SINGLEILLNESSCODE>";//单病种编码
            data += "<OPERATOR>" + parm[3] + "</OPERATOR>";//操作员
            data += "<DODATE>" + parm[4] + "</DODATE>";//办理时间
            return data;
        }
        ////参数尾部分
        public string Szjsfs_tail()
        {
            return "</DATA>";
        }
    }
}
