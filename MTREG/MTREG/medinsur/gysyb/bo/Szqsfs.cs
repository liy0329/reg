using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gysyb.bo
{
    /// <summary>
    ///  3.24	SETRECKONINGTYPE（设置清算方式）
    /// </summary>
    class Szqsfs
    {
        /// <summary>
        /// xml头部分
        /// </summary>
        /// <returns></returns>
        public string Szqsfs_head()
        {
            string data = "<?xml version=\"1.0\" encoding=\"GB2312\" standalone=\"yes\"?>";
            data += "<DATA>";
            return data;
        }
        /// <summary>
        /// 输入参数
        /// </summary>
        /// <returns></returns>
        public string Szqsfs_in(string[] parm)
        {
            string data = "<PERSONCODE>" + parm[0] + "</PERSONCODE>";//个人编码
            data += "<RECKONINGTYPE>" + parm[1] + "</RECKONINGTYPE>";//清算方式        当为1时，单病种编码不能为空
            data += "<SINGLEILLNESSCODE>" + parm[2] + "</SINGLEILLNESSCODE>";//单病种编码
            data += "<OPERATOR>" + parm[3] + "</OPERATOR>";//操作员
            data += "<DODATE>" + parm[4] + "</DODATE>";//办理时间

            return data;
        }
        ////参数尾部分
        public string Szqsfs_tail()
        {
            return "</DATA>";
        }
    }
}
