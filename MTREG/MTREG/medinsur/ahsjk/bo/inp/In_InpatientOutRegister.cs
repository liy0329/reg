using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ahsjk.bo.inp
{
    class In_InpatientOutRegister:TopIn
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
        [Valid(Required = true, Description = "不能为空")]
        private string sDiagnoseCodeOut1;//出院疾病诊断编码1
        [Valid(Required = true, Description = "不能为空")]
        private string sDiagnoseNameOut1;//出院疾病诊断名称1
        private string sDiagnoseCodeOut2;//出院疾病诊断编码2
        private string sDiagnoseNameOut2;//出院疾病诊断名称2
        private string sDiagnoseCodeOut3;//出院疾病诊断编码3
        private string sDiagnoseNameOut3;//出院疾病诊断名称3
        [Valid(Required = true, Description = "不能为空")]
        private string sSectionOfficeName;//HIS出院院科室名称
        [Valid(Required = true, Description = "不能为空")]
        private string sSectionOfficeCode;//中心出院科室编码
        [Valid(Required = true, Description = "不能为空")]
        private string sOutHospitalCode;//出院状态编码
        [Valid(Required = true, Description = "不能为空")]
        private string sOutHosptialDate;//出院时间
        [Valid(Required = true, Description = "不能为空")]
        private string sOperatorName;//操作人姓名
        [Valid(Required = true, Description = "不能为空")]
        private string sReceiptCode;//发票号码
        [Valid(Required = true, Description = "不能为空")]
        private string sAllInCost;//HIS住院发生总费用
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
        /// 出院疾病诊断编码2
        /// </summary>
        public string SDiagnoseCodeOut2
        {
            get { return sDiagnoseCodeOut2; }
            set { sDiagnoseCodeOut2 = value; }
        }
        /// <summary>
        /// 出院疾病诊断名称2
        /// </summary>
        public string SDiagnoseNameOut2
        {
            get { return sDiagnoseNameOut2; }
            set { sDiagnoseNameOut2 = value; }
        }
        /// <summary>
        /// 出院疾病诊断编码3
        /// </summary>
        public string SDiagnoseCodeOut3
        {
            get { return sDiagnoseCodeOut3; }
            set { sDiagnoseCodeOut3 = value; }
        }
        /// <summary>
        /// 出院疾病诊断名称3
        /// </summary>
        public string SDiagnoseNameOut3
        {
            get { return sDiagnoseNameOut3; }
            set { sDiagnoseNameOut3 = value; }
        }
        /// <summary>
        /// HIS出院院科室名称
        /// </summary>
        public string SSectionOfficeName
        {
            get { return sSectionOfficeName; }
            set { sSectionOfficeName = value; }
        }
        /// <summary>
        /// 中心出院科室编码
        /// </summary>
        public string SSectionOfficeCode
        {
            get { return sSectionOfficeCode; }
            set { sSectionOfficeCode = value; }
        }
        /// <summary>
        /// 出院状态编码
        /// </summary>
        public string SOutHospitalCode
        {
            get { return sOutHospitalCode; }
            set { sOutHospitalCode = value; }
        }
        /// <summary>
        /// 出院时间
        /// </summary>
        public string SOutHosptialDate
        {
            get { return sOutHosptialDate; }
            set { sOutHosptialDate = value; }
        }
        /// <summary>
        /// 操作人姓名
        /// </summary>
        public string SOperatorName
        {
            get { return sOperatorName; }
            set { sOperatorName = value; }
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
        /// //HIS住院发生总费用
        /// </summary>
        public string SAllInCost
        {
            get { return sAllInCost; }
            set { sAllInCost = value; }
        }
        
    }
}
