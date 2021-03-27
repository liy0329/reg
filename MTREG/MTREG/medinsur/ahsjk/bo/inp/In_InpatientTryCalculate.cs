using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ahsjk.bo.inp
{
    class In_InpatientTryCalculate :TopIn 
    {
        [Valid(Required = true, Description = "不能为空")]
        private string sCalcCode;
        [Valid(Required = true, Description = "不能为空")]
        private string sAllInCost;
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
        /// <summary>
        /// //补偿类别编码
        /// </summary>
        public string SCalcCode
        {
            get { return sCalcCode; }
            set { sCalcCode = value; }
        }
        /// <summary>
        /// //HIS住院发生总费用
        /// </summary>
        public string SAllInCost
        {
            get { return sAllInCost; }
            set { sAllInCost = value; }
        }
    }
}
