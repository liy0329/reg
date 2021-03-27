using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ahsjk.bo.inp
{
    /// <summary>
    /// 【门诊、住院登记】输入参数封装类
    /// </summary>
    class In_InpatientRegister:TopIn
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
        private string sInpatientCode;
        /// <summary>
        /// HIS住院号
        /// </summary>
        public string SInpatientCode
        {
            get { return sInpatientCode; }
            set { sInpatientCode = value; }
        }

        private string sMedicalCode;
        /// <summary>
        /// 医疗证号
        /// </summary>
        public string SMedicalCode
        {
            get { return sMedicalCode; }
            set { sMedicalCode = value; }
        }
        private string sCardCode;
        /// <summary>
        /// 医疗卡号
        /// </summary>
        public string SCardCode
        {
            get { return sCardCode; }
            set { sCardCode = value; }
        }
        private string sPeopCode;
        /// <summary>
        /// 人员编号
        /// </summary>
        public string SPeopCode
        {
            get { return sPeopCode; }
            set { sPeopCode = value; }
        }
        private string sPeopName;
        /// <summary>
        /// 姓名
        /// </summary>
        public string SPeopName
        {
            get { return sPeopName; }
            set { sPeopName = value; }
        }
        private string sSex;
        /// <summary>
        /// 性别
        /// </summary>
        public string SSex
        {
            get { return sSex; }
            set { sSex = value; }
        }

        private string sAge;
        /// <summary>
        /// 年龄
        /// </summary>
        public string SAge
        {
            get { return sAge; }
            set { sAge = value; }
        }
        private string sBirthDay;
        /// <summary>
        /// 出生日期
        /// </summary>
        public string SBirthDay
        {
            get { return sBirthDay; }
            set { sBirthDay = value; }
        }
        private string sIDCardNo;
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string SIDCardNo
        {
            get { return sIDCardNo; }
            set { sIDCardNo = value; }
        }
        private string sDiagnoseCodeIn1;
        /// <summary>
        /// 入院疾病诊断编码1
        /// </summary>
        public string SDiagnoseCodeIn1
        {
            get { return sDiagnoseCodeIn1; }
            set { sDiagnoseCodeIn1 = value; }
        }
        private string sDiagnoseNameIn1;
        /// <summary>
        /// //入院疾病诊断名称
        /// </summary>
        public string SDiagnoseNameIn1
        {
            get { return sDiagnoseNameIn1; }
            set { sDiagnoseNameIn1 = value; }
        }
        private string sDiagnoseCodeIn2;
        /// <summary>
        /// 入院疾病诊断编码2
        /// </summary>
        public string SDiagnoseCodeIn2
        {
            get { return sDiagnoseCodeIn2; }
            set { sDiagnoseCodeIn2 = value; }
        }
        private string sDiagnoseNameIn2;
        /// <summary>
        /// 入院疾病诊断名称2
        /// </summary>
        public string SDiagnoseNameIn2
        {
            get { return sDiagnoseNameIn2; }
            set { sDiagnoseNameIn2 = value; }
        }
        private string sDiagnoseCodeIn3;
        /// <summary>
        /// 入院疾病诊断编码3
        /// </summary>
        public string SDiagnoseCodeIn3
        {
            get { return sDiagnoseCodeIn3; }
            set { sDiagnoseCodeIn3 = value; }
        }
        private string sDiagnoseNameIn3;
        /// <summary>
        /// 入院疾病诊断名称3
        /// </summary>
        public string SDiagnoseNameIn3
        {
            get { return sDiagnoseNameIn3; }
            set { sDiagnoseNameIn3 = value; }
        }
        private string sOperationCode1;
        /// <summary>
        /// 手术编码1
        /// </summary>
        public string SOperationCode1
        {
            get { return sOperationCode1; }
            set { sOperationCode1 = value; }
        }
        private string sOperationName1;
        /// <summary>
        /// 手术名称1
        /// </summary>
        public string SOperationName1
        {
            get { return sOperationName1; }
            set { sOperationName1 = value; }
        }
        private string sOperationCode2;
        /// <summary>
        /// 手术编码2
        /// </summary>
        public string SOperationCode2
        {
            get { return sOperationCode2; }
            set { sOperationCode2 = value; }
        }
        private string sOperationName2;
        /// <summary>
        /// 手术名称2
        /// </summary>
        public string SOperationName2
        {
            get { return sOperationName2; }
            set { sOperationName2 = value; }
        }
        private string sOperationCode3;
        /// <summary>
        /// 手术编码3
        /// </summary>
        public string SOperationCode3
        {
            get { return sOperationCode3; }
            set { sOperationCode3 = value; }
        }
        private string sOperationName4;        
        /// <summary>
        /// 手术名称3
        /// </summary>
        public string SOperationName4
        {
            get { return sOperationName4; }
            set { sOperationName4 = value; }
        }
        private string sSectionOfficeName;
        /// <summary>
        /// HIS入院科室名称
        /// </summary>
        public string SSectionOfficeName
        {
            get { return sSectionOfficeName; }
            set { sSectionOfficeName = value; }
        }
        private string sSectionOfficeCode;
        /// <summary>
        /// 中心入院科室编码
        /// </summary>
        public string SSectionOfficeCode
        {
            get { return sSectionOfficeCode; }
            set { sSectionOfficeCode = value; }
        }
        private string sCureCode;
        /// <summary>
        /// 就诊类型编码
        /// </summary>
        public string SCureCode
        {
            get { return sCureCode; }
            set { sCureCode = value; }
        }
        private string sInHospitalCode;
        /// <summary>
        /// 入院状态编码
        /// </summary>
        public string SInHospitalCode
        {
            get { return sInHospitalCode; }
            set { sInHospitalCode = value; }
        }
        private string sInHosptialDate;
        /// <summary>
        /// 入院时间
        /// </summary>
        public string SInHosptialDate
        {
            get { return sInHosptialDate; }
            set { sInHosptialDate = value; }
        }
        private string sBed;
        /// <summary>
        /// //床号
        /// </summary>
        public string SBed
        {
            get { return sBed; }
            set { sBed = value; }
        }
        private string sDoctorName;
        /// <summary>
        /// 床位医生姓名
        /// </summary>
        public string SDoctorName
        {
            get { return sDoctorName; }
            set { sDoctorName = value; }
        }
        private string sChangeCode;
        /// <summary>
        /// 转诊类型编号
        /// </summary>
        public string SChangeCode
        {
            get { return sChangeCode; }
            set { sChangeCode = value; }
        }
        private string sChangeRCode;
        /// <summary>
        /// 转诊单号
        /// </summary>
        public string SChangeRCode
        {
            get { return sChangeRCode; }
            set { sChangeRCode = value; }
        }
        private string sCivilCode;
        /// <summary>
        /// 民政通知书号
        /// </summary>
        public string SCivilCode
        {
            get { return sCivilCode; }
            set { sCivilCode = value; }
        }
        private string sBearCode;
        /// <summary>
        /// 生育证号
        /// </summary>
        public string SBearCode
        {
            get { return sBearCode; }
            set { sBearCode = value; }
        }
        private string sOperatorName;
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
