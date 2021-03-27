using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ahsjk.bo.inp
{
    class In_InpatientRegisterCancel:TopIn
    {
        private string sAreaCode;
        /// <summary>
        /// 地区代码
        /// </summary>
        public string SAreaCode
        {
            get { return sAreaCode; }
            set { sAreaCode = value; }
        }
        private string sInpatientID;
        /// <summary>
        /// 就诊ID
        /// </summary>
        public string SInpatientID
        {
            get { return sInpatientID; }
            set { sInpatientID = value; }
        }
        private string sReason;
        private string sOperatorName;
        /// <summary>
        /// //原因
        /// </summary>
        public string SReason
        {
            get { return sReason; }
            set { sReason = value; }
        }
        /// <summary>
        /// 操作人姓名
        /// </summary>
        public string SOperatorName
        {
            get { return sOperatorName; }
            set { sOperatorName = value; }
        }       
    }
}
