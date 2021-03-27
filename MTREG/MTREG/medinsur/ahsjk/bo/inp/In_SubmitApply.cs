using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ahsjk.bo.inp
{
    class In_SubmitApply : TopIn
    {

        [Valid(Required = true, Description = "不能为空")]
        private string sDiagnoseCodeOut1;
        [Valid(Required = true, Description = "不能为空")]
        private string sDiagnoseNameOut1;
        private string sDiagnoseCodeOut2;
        private string sDiagnoseNameOut2;
        private string sDiagnoseCodeOut3;
        private string sDiagnoseNameOut3;
        [Valid(Required = true, Description = "不能为空")]
        private string sCalcCode;
        [Valid(Required = true, Description = "不能为空")]
        private string sOperatorName;
        [Valid(Required = true, Description = "不能为空")]
        private string sAllInCost;
        /// <summary>
        /// //出院疾病诊断编码1
        /// </summary>
        public string SDiagnoseCodeOut1
        {
            get { return sDiagnoseCodeOut1; }
            set { sDiagnoseCodeOut1 = value; }
        }
        /// <summary>
        /// //出院疾病诊断名称1
        /// </summary>
        public string SDiagnoseNameOut1
        {
            get { return sDiagnoseNameOut1; }
            set { sDiagnoseNameOut1 = value; }
        }
        /// <summary>
        /// //出院疾病诊断编码2
        /// </summary>
        public string SDiagnoseCodeOut2
        {
            get { return sDiagnoseCodeOut2; }
            set { sDiagnoseCodeOut2 = value; }
        }
        /// <summary>
        /// //出院疾病诊断名称2
        /// </summary>
        public string SDiagnoseNameOut2
        {
            get { return sDiagnoseNameOut2; }
            set { sDiagnoseNameOut2 = value; }
        }
        /// <summary>
        /// //出院疾病诊断编码3
        /// </summary>
        public string SDiagnoseCodeOut3
        {
            get { return sDiagnoseCodeOut3; }
            set { sDiagnoseCodeOut3 = value; }
        }
        /// <summary>
        /// //出院疾病诊断名称3
        /// </summary>
        public string SDiagnoseNameOut3
        {
            get { return sDiagnoseNameOut3; }
            set { sDiagnoseNameOut3 = value; }
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
        /// //操作人姓名
        /// </summary>
        public string SOperatorName
        {
            get { return sOperatorName; }
            set { sOperatorName = value; }
        }
        /// <summary>
        /// //HIS住院发生总费用
        /// </summary>
        public string SAllInCost
        {
            get { return sAllInCost; }
            set { sAllInCost = value; }
        }
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
    }
}
