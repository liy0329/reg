using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ahsjk.bo.inp
{
    class In_InpatientRegisterModify:TopIn
    {
        private string sInpatientID;
        /// <summary>
        /// 就诊ID
        /// </summary>
        public string SInpatientID
        {
            get { return sInpatientID; }
            set { sInpatientID = value; }
        }
        private string sAreaCode;        
        private string sInpatientCode;
        private string sMedicalCode;
        private string sCardCode;
        private string sPeopCode;
        private string sPeopName;
        private string sSex;
        private string sAge;
        private string sBirthDay;
        private string sIDCardNo;
        private string sDiagnoseCodeIn1;
        private string sDiagnoseNameIn1;
        private string sDiagnoseCodeIn2;
        private string sDiagnoseNameIn2;
        private string sDiagnoseCodeIn3;
        private string sDiagnoseNameIn3;
        private string sOperationCode1;
        private string sOperationName1;
        private string sOperationCode2;
        private string sOperationName2;
        private string sOperationCode3;
        private string sOperationName3;
        private string sSectionOfficeName;
        private string sSectionOfficeCode;
        private string sCureCode;
        private string sInHospitalCode;
        private string sInHosptialDate;
        private string sBed;
        private string sDoctorName;
        private string sChangeCode;
        private string sChangeRCode;
        private string sCivilCode;
        private string sBearCode;
        private string sOperatorName;
        /// <summary>
        /// 地区代码
        /// </summary>
        public string SAreaCode
        {
            get { return sAreaCode; }
            set { sAreaCode = value; }
        }
        /// <summary>
        /// //HIS住院号
        /// </summary>
        public string SInpatientCode
        {
            get { return sInpatientCode; }
            set { sInpatientCode = value; }
        }
        /// <summary>
        /// 医疗证号
        /// </summary>
        public string SMedicalCode
        {
            get { return sMedicalCode; }
            set { sMedicalCode = value; }
        }
        /// <summary>
        /// 医疗卡号
        /// </summary>
        public string SCardCode
        {
            get { return sCardCode; }
            set { sCardCode = value; }
        }
        /// <summary>
        /// 人员编号
        /// </summary>
        public string SPeopCode
        {
            get { return sPeopCode; }
            set { sPeopCode = value; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string SPeopName
        {
            get { return sPeopName; }
            set { sPeopName = value; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public string SSex
        {
            get { return sSex; }
            set { sSex = value; }
        }
        /// <summary>
        /// 年龄
        /// </summary>
        public string SAge
        {
            get { return sAge; }
            set { sAge = value; }
        }
        /// <summary>
        /// 出生日期
        /// </summary>
        public string SBirthDay
        {
            get { return sBirthDay; }
            set { sBirthDay = value; }
        }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string SIDCardNo
        {
            get { return sIDCardNo; }
            set { sIDCardNo = value; }
        }
        /// <summary>
        /// 入院疾病诊断编码1
        /// </summary>
        public string SDiagnoseCodeIn1
        {
            get { return sDiagnoseCodeIn1; }
            set { sDiagnoseCodeIn1 = value; }
        }
        //入院疾病诊断名称1
        public string SDiagnoseNameIn1
        {
            get { return sDiagnoseNameIn1; }
            set { sDiagnoseNameIn1 = value; }
        }
        /// <summary>
        /// //入院疾病诊断编码2
        /// </summary>
        public string SDiagnoseCodeIn2
        {
            get { return sDiagnoseCodeIn2; }
            set { sDiagnoseCodeIn2 = value; }
        }
        /// <summary>
        /// 入院疾病诊断名称2
        /// </summary>
        public string SDiagnoseNameIn2
        {
            get { return sDiagnoseNameIn2; }
            set { sDiagnoseNameIn2 = value; }
        }
        /// <summary>
        /// //入院疾病诊断编码3
        /// </summary>
        public string SDiagnoseCodeIn3
        {
            get { return sDiagnoseCodeIn3; }
            set { sDiagnoseCodeIn3 = value; }
        }
        /// <summary>
        /// //入院疾病诊断名称3
        /// </summary>
        public string SDiagnoseNameIn3
        {
            get { return sDiagnoseNameIn3; }
            set { sDiagnoseNameIn3 = value; }
        }
        /// <summary>
        /// //手术编码1
        /// </summary>
        public string SOperationCode1
        {
            get { return sOperationCode1; }
            set { sOperationCode1 = value; }
        }
        /// <summary>
        /// 手术名称1
        /// </summary>
        public string SOperationName1
        {
            get { return sOperationName1; }
            set { sOperationName1 = value; }
        }
        //手术编码2
        public string SOperationCode2
        {
            get { return sOperationCode2; }
            set { sOperationCode2 = value; }
        }
        /// <summary>
        /// //手术名称2
        /// </summary>
        public string SOperationName2
        {
            get { return sOperationName2; }
            set { sOperationName2 = value; }
        }
        /// <summary>
        /// 手术编码3
        /// </summary>
        public string SOperationCode3
        {
            get { return sOperationCode3; }
            set { sOperationCode3 = value; }
        }
        /// <summary>
        /// 手术名称3
        /// </summary>
        public string SOperationName3
        {
            get { return sOperationName3; }
            set { sOperationName3 = value; }
        }
        /// <summary>
        /// HIS入院科室名称
        /// </summary>
        public string SSectionOfficeName
        {
            get { return sSectionOfficeName; }
            set { sSectionOfficeName = value; }
        }
        /// <summary>
        /// 中心入院科室编码
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
        /// 入院时间
        /// </summary>
        public string SInHosptialDate
        {
            get { return sInHosptialDate; }
            set { sInHosptialDate = value; }
        }
        /// <summary>
        /// 床号
        /// </summary>
        public string SBed
        {
            get { return sBed; }
            set { sBed = value; }
        }
        /// <summary>
        /// //床位医生姓名
        /// </summary>
        public string SDoctorName
        {
            get { return sDoctorName; }
            set { sDoctorName = value; }
        }
        /// <summary>
        /// 转诊类型编号
        /// </summary>
        public string SChangeCode
        {
            get { return sChangeCode; }
            set { sChangeCode = value; }
        }
        /// <summary>
        /// //转诊单号
        /// </summary>
        public string SChangeRCode
        {
            get { return sChangeRCode; }
            set { sChangeRCode = value; }
        }
        /// <summary>
        /// //民政通知书号
        /// </summary>
        public string SCivilCode
        {
            get { return sCivilCode; }
            set { sCivilCode = value; }
        }
        //生育证号
        public string SBearCode
        {
            get { return sBearCode; }
            set { sBearCode = value; }
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
