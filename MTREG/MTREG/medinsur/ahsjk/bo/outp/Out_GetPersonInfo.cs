using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ahsjk.bo.outp
{
    class Out_GetPersonInfo
    {
        private string sMedicalCode;//医疗证号
        private string sPeopCode;//人员编号
        private string sPeopName;//姓名
        private string sSex;//性别
        private string sAge;//年龄
        private string sBirthDay;//出生日期
        private string sIDCardNo;//身份证号码
        private string sAddress;//家庭地址
        private string sCardCode;//医疗卡号
        private string sTelephone;//电话号码
        private string sPeopProp;//户属性名称
        private string sAddrCode;//辖区编码
        private string sFamilyBalance;//本户家庭帐户余额
        private string sChronicName1;//慢性病病种1
        private string sChronicName2;//慢性病病种2
        private string sChronicName3;//慢性病病种3

        public string SMedicalCode
        {
            get { return sMedicalCode; }
            set { sMedicalCode = value; }
        }

        public string SPeopCode
        {
            get { return sPeopCode; }
            set { sPeopCode = value; }
        }

        public string SPeopName
        {
            get { return sPeopName; }
            set { sPeopName = value; }
        }

        public string SSex
        {
            get { return sSex; }
            set { sSex = value; }
        }

        public string SAge
        {
            get { return sAge; }
            set { sAge = value; }
        }

        public string SBirthDay
        {
            get { return sBirthDay; }
            set { sBirthDay = value; }
        }

        public string SIDCardNo
        {
            get { return sIDCardNo; }
            set { sIDCardNo = value; }
        }

        public string SAddress
        {
            get { return sAddress; }
            set { sAddress = value; }
        }

        public string SCardCode
        {
            get { return sCardCode; }
            set { sCardCode = value; }
        }

        public string STelephone
        {
            get { return sTelephone; }
            set { sTelephone = value; }
        }

        public string SPeopProp
        {
            get { return sPeopProp; }
            set { sPeopProp = value; }
        }

        public string SAddrCode
        {
            get { return sAddrCode; }
            set { sAddrCode = value; }
        }

        public string SFamilyBalance
        {
            get { return sFamilyBalance; }
            set { sFamilyBalance = value; }
        }

        public string SChronicName1
        {
            get { return sChronicName1; }
            set { sChronicName1 = value; }
        }

        public string SChronicName2
        {
            get { return sChronicName2; }
            set { sChronicName2 = value; }
        }

        public string SChronicName3
        {
            get { return sChronicName3; }
            set { sChronicName3 = value; }
        }
    }
}
