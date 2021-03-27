using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ahsjk.bo.inp
{
    class In_InpatDiagnosisUpdate : TopIn
    {
        [Valid(Required = true, Description = "不能为空")]
        private string sUserCode;
        [Valid(Required = true, Description = "不能为空")]
        private string sUserPass;
        private string sStature;
        private string sWeight;
        [Valid(Required = true, Description = "不能为空")]
        private string sTreatCode;
        [Valid(Required = true, Description = "不能为空")]
        private string sIcdno;
        [Valid(Required = true, Description = "不能为空")]
        private string sIcdName;
        [Valid(Required = true, Description = "不能为空")]
        private string sSectionOfficeCode;
        [Valid(Required = true, Description = "不能为空")]
        private string sCureCode;
        [Valid(Required = true, Description = "不能为空")]
        private string sInHospitalCode;
        [Valid(Required = true, Description = "不能为空")]
        private string sInHosptialDate;
        [Valid(Required = true, Description = "不能为空")]
        private string sOperatorName;
        /// <summary>
        /// //用户名
        /// </summary>
        public string SUserCode
        {
            get { return sUserCode; }
            set { sUserCode = value; }
        }
        /// <summary>
        /// //密码
        /// </summary>
        public string SUserPass
        {
            get { return sUserPass; }
            set { sUserPass = value; }
        }
        /// <summary>
        /// //身高（CM）
        /// </summary>
        public string SStature
        {
            get { return sStature; }
            set { sStature = value; }
        }
        /// <summary>
        /// //体重（KG）
        /// </summary>
        public string SWeight
        {
            get { return sWeight; }
            set { sWeight = value; }
        }
        /// <summary>
        /// //治疗方式编码
        /// </summary>
        public string STreatCode
        {
            get { return sTreatCode; }
            set { sTreatCode = value; }
        }
        /// <summary>
        /// //单病种ICD编码
        /// </summary>
        public string SIcdno
        {
            get { return sIcdno; }
            set { sIcdno = value; }
        }
        /// <summary>
        /// //单病种ICD名称
        /// </summary>
        public string SIcdName
        {
            get { return sIcdName; }
            set { sIcdName = value; }
        }
        /// <summary>
        /// //中心入院科室编码
        /// </summary>
        public string SSectionOfficeCode
        {
            get { return sSectionOfficeCode; }
            set { sSectionOfficeCode = value; }
        }
        /// <summary>
        /// //就诊类型编码
        /// </summary>
        public string SCureCode
        {
            get { return sCureCode; }
            set { sCureCode = value; }
        }
        /// <summary>
        /// //入院状态编码
        /// </summary>
        public string SInHospitalCode
        {
            get { return sInHospitalCode; }
            set { sInHospitalCode = value; }
        }
        /// <summary>
        /// //入院时间
        /// </summary>
        public string SInHosptialDate
        {
            get { return sInHosptialDate; }
            set { sInHosptialDate = value; }
        }
        /// <summary>
        /// //操作人姓名
        /// </summary>
        public string SOperatorName
        {
            get { return sOperatorName; }
            set { sOperatorName = value; }
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
