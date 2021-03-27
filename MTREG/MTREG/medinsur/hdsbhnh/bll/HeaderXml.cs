using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdsbhnh.bo
{
    class HeaderXml
    {
        /// <summary>
        /// 所有的输入参数的头部
        /// </summary>
        /// <returns></returns>
        public string allDataInput_head(string functionNo, string targetOrg, string identity, string password)
        {

            string headdata = "<request xmlns=\"http://www.section9.org/cms/referral/data\">";
            headdata += "<head>";
            headdata += "<version>2000</version>";//版本号
            headdata += "<functionNo>" + functionNo + "</functionNo>";//功能编码
            headdata += "<targetOrg>" + targetOrg + "</targetOrg>";//目标机构代码
            headdata += "<healthcareprovider identity=\"" + identity + "\" password=\"" + password + "\"/>";//医疗单位身份  密码
            headdata += "</head>";
            return headdata;

        }

        /// <summary>
        /// 所有的输入参数的头部结尾
        /// </summary>
        /// <returns></returns>
        public string allDatInput_end()
        {

            string enddata = "</request>";
            return enddata;

        }
    }
}
