using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ahsjk.bo
{
    class RegInfo
    {
        private string weburl;
        /// <summary>
        /// webservice地址
        /// </summary>
        public string Weburl
        {
            get { return weburl; }
            set { weburl = value; }
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
        private string sChangeCode;
        /// <summary>
        /// 转诊类型编号
        /// </summary>
        public string SChangeCode
        {
            get { return sChangeCode; }
            set { sChangeCode = value; }
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
        private string sHospitalCode;
        /// <summary>
        /// 医疗机构编号
        /// </summary>
        public string SHospitalCode
        {
            get { return sHospitalCode; }
            set { sHospitalCode = value; }
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
        private string sPeopCode;
        /// <summary>
        /// 个人编号
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
        /// 身份证号
        /// </summary>
        public string SIDCardNo
        {
            get { return sIDCardNo; }
            set { sIDCardNo = value; }
        }
        private string sAddress;
        /// <summary>
        /// 家庭地址
        /// </summary>
        public string SAddress
        {
            get { return sAddress; }
            set { sAddress = value; }
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
        private string sInpatientID;
        /// <summary>
        /// 就诊id
        /// </summary>
        public string SInpatientID
        {
            get { return sInpatientID; }
            set { sInpatientID = value; }
        }
        private string sFamilyBalance;
        /// <summary>
        /// 本户家庭帐户余额
        /// </summary>
        public string SFamilyBalance
        {
            get { return sFamilyBalance; }
            set { sFamilyBalance = value; }
        }                
    }
}
