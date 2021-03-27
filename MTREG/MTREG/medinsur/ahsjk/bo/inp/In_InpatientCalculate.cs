using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ahsjk.bo.inp
{
    class In_InpatientCalculate : TopIn
    {
        [Valid(Required = true, Description = "不能为空")]
        private string sCalcCode;
        [Valid(Required = true, Description = "不能为空")]
        private string sReceiptCode;
        [Valid(Required = true, Description = "不能为空")]
        private string sAllInCost;
        [Valid(Required = true, Description = "不能为空")]
        private string sOperatorName;
        [Valid(Required = true, Description = "不能为空")]
        private string sAreaCode;
        /// <summary>
        /// 地区代码
        /// </summary>
        public string SAreaCode
        {
            get { return sAreaCode; }
            set { sAreaCode = value; }
        }
        [Valid(Required = true, Description = "不能为空")]
        private string sInpatientID;
        /// <summary>
        /// 就诊ID
        /// </summary>
        public string SInpatientID
        {
            get { return sInpatientID; }
            set { sInpatientID = value; }
        }
        /// <summary>
        /// 补偿类别编码
        /// </summary>
        public string SCalcCode
        {
            get { return sCalcCode; }
            set { sCalcCode = value; }
        }
        /// <summary>
        /// 发票号码
        /// </summary>
        public string SReceiptCode
        {
            get { return sReceiptCode; }
            set { sReceiptCode = value; }
        }
        /// <summary>
        /// HIS住院发生总费用
        /// </summary>
        public string SAllInCost
        {
            get { return sAllInCost; }
            set { sAllInCost = value; }
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
