using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gzsyb.bo
{
    /// <summary>
    /// §3.7.1.	修改密码（02）
    /// </summary>
    class UpdatePassword
    {
        /// <summary>
        /// xml头部分
        /// </summary>
        /// <returns></returns>
        public string xmlCode_head()
        {
            string data = "<?xml version=\"1.0\" encoding=\"GBK\" standalone=\"yes\" ?>";
            return data;
        }
        /// <summary>
        /// 输入参数
        /// </summary>
        /// <returns></returns>
        public string xmlCode_in()
        {
            string data = "<input></input>";
            return data;
        }
        ///// <summary>
        ///// 输出参数
        ///// </summary>
        ///// <returns></returns>
        //private string xmlCode_out()
        //{
        //    string data = "<output></output>";
        //    return data;
        //}
        /// <summary>
        /// //交易的处理流程
        /// </summary>
        /// <param name="retData"></param>
        /// <returns></returns>
        public Call_out UpdatePasswordCall()
        {
            Call_out retData = new Call_out();
            string astr_jybh = "02";
            string astr_jysr_xml = xmlCode_head() + xmlCode_in();
            string astr_jylsh = "";
            string astr_jyyzm = "";
            string astr_jysc_xml = "";
            long aint_appcode = 0;
            string astr_appmsg = "";
            //yh_interface yhInterface = new yh_interface();            
            //yhInterface.yh_interface_call(astr_jybh, astr_jysr_xml, ref astr_jylsh, ref astr_jyyzm, ref astr_jysc_xml, ref aint_appcode, ref astr_appmsg);
            //retData.Aintappcode = aint_appcode;
            if (aint_appcode < 0)
            {
                retData.Astrappms = astr_appmsg;
            }
            retData.Astrjylsh = astr_jylsh;
            retData.Astrjyyzm = astr_jyyzm;
            retData.Astrjyscxml = astr_jysc_xml;
            return retData;

        }
    }
}
