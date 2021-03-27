using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ahsjk.bo.inp
{
    class In_InpatientFeeCancel : TopIn
    {
        [Valid(Required = true, Description = "不能为空")]
        private string sCenterKey;
        [Valid(Required = true, Description = "不能为空")]
        private string sItemKey;
        [Valid(Required = true, Description = "不能为空")]
        private string sOperatorDate;
        [Valid(Required = true, Description = "不能为空")]
        private string sInputName;
        /// <summary>
        /// //中心明细关键字
        /// </summary>
        public string SCenterKey
        {
            get { return sCenterKey; }
            set { sCenterKey = value; }
        }
        /// <summary>
        /// //HIS记帐关键字
        /// </summary>
        public string SItemKey
        {
            get { return sItemKey; }
            set { sItemKey = value; }
        }
        /// <summary>
        /// //记帐时间
        /// </summary>
        public string SOperatorDate
        {
            get { return sOperatorDate; }
            set { sOperatorDate = value; }
        }
        /// <summary>
        /// //记帐人姓名
        /// </summary>
        public string SInputName
        {
            get { return sInputName; }
            set { sInputName = value; }
        }
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
    }
}
