using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gysyb.bo
{
    /// <summary>
    /// 3.26	HOSPOUT（出院登记）
    /// </summary>
    class Cydj
    {
        /// <summary>
        /// xml头部分
        /// </summary>
        /// <returns></returns>
        public string Cydj_head()
        {
            string data = "<?xml version=\"1.0\" encoding=\"GB2312\" standalone=\"yes\"?>";
            data += "<DATA>";
            return data;
        }
        /// <summary>
        /// 输入参数
        /// </summary>
        /// <returns></returns>
        public string Cydj_in(string[] parm)
        {
            string data = "<PERSONCODE>" + parm[0] + "</PERSONCODE>";//个人编码
            data += "<DOCNO>" + parm[1] + "</DOCNO>";//病案号
            data += "<DIAGNOSES>" + parm[2] + "</DIAGNOSES>";//主诊断
            data += "<OTHERDIAGNOSES>" + parm[3] + "</OTHERDIAGNOSES>";//其他诊断
            data += "<OUTTYPE>" + parm[4] + "</OUTTYPE>";//转归类别
            data += "<DOCTOR>" + parm[5] + "</DOCTOR>";//诊断医生
            data += "<OFFICE>" + parm[6] + "</OFFICE>";//科室
            data += "<ICD>" + parm[7] + "</ICD>";// ICD编码
            data += "<REGDATE>" + parm[8] + "</REGDATE>";//出院时间
            data += "<OPERATOR>" + parm[9] + "</OPERATOR>";//操作员
            data += "<DODATE>" + parm[10] + "</DODATE>";//办理时间

            return data;
        }
        ////参数尾部分
        public string Cydj_tail()
        {
            return "</DATA>";
        }
    }
}
