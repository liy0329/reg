using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ahsjk.bo.outp
{
    class Out_InpatientTryCalculate
    {
        private string sAllInCost;//医疗总费用

        public string SAllInCost
        {
            get { return sAllInCost; }
            set { sAllInCost = value; }
        }
        private string sAllApply;//可报销总费用

        public string SAllApply
        {
            get { return sAllApply; }
            set { sAllApply = value; }
        }
        private string sBegin;//起付线

        public string SBegin
        {
            get { return sBegin; }
            set { sBegin = value; }
        }
        private string sFund;//基金支付

        public string SFund
        {
            get { return sFund; }
            set { sFund = value; }
        }
        private string sAccount;//帐户支付

        public string SAccount
        {
            get { return sAccount; }
            set { sAccount = value; }
        }
        private string sAccountBegin;//帐户支付前余额

        public string SAccountBegin
        {
            get { return sAccountBegin; }
            set { sAccountBegin = value; }
        }
        private string sAccountAfter;//帐户支付后余额

        public string SAccountAfter
        {
            get { return sAccountAfter; }
            set { sAccountAfter = value; }
        }
        private string sSumFund;//年度基金累计支付

        public string SSumFund
        {
            get { return sSumFund; }
            set { sSumFund = value; }
        }
        private string sInHospialCount;//住院次数

        public string SInHospialCount
        {
            get { return sInHospialCount; }
            set { sInHospialCount = value; }
        }
        private string sSelfCost;//自费金额

        public string SSelfCost
        {
            get { return sSelfCost; }
            set { sSelfCost = value; }
        }
        private string sOwnCost;//自付金额

        public string SOwnCost
        {
            get { return sOwnCost; }
            set { sOwnCost = value; }
        }
        private string sMedSum;//药品总费用

        public string SMedSum
        {
            get { return sMedSum; }
            set { sMedSum = value; }
        }
        private string sMedAppSum;//药品可报销总金额

        public string SMedAppSum
        {
            get { return sMedAppSum; }
            set { sMedAppSum = value; }
        }
        private string sCMeSum;//中医药品/诊疗总金额

        public string SCMeSum
        {
            get { return sCMeSum; }
            set { sCMeSum = value; }
        }
        private string sCMeASum;//中医药品/诊疗可报销总金额

        public string SCMeASum
        {
            get { return sCMeASum; }
            set { sCMeASum = value; }
        }
        private string sOutHCheck;//院外检查总金额

        public string SOutHCheck
        {
            get { return sOutHCheck; }
            set { sOutHCheck = value; }
        }
        private string sOutCheckApp;//院外检查可报销总金额

        public string SOutCheckApp
        {
            get { return sOutCheckApp; }
            set { sOutCheckApp = value; }
        }
        private string sOutCheck;//院外检查报销总金额

        public string SOutCheck
        {
            get { return sOutCheck; }
            set { sOutCheck = value; }
        }
        private string sHostName;//户主姓名

        public string SHostName
        {
            get { return sHostName; }
            set { sHostName = value; }
        }
        private string sYear;//业务年份

        public string SYear
        {
            get { return sYear; }
            set { sYear = value; }
        }
        private string sCalculateDate;//结算时间

        public string SCalculateDate
        {
            get { return sCalculateDate; }
            set { sCalculateDate = value; }
        }
        private string sTownName;//乡镇名称

        public string STownName
        {
            get { return sTownName; }
            set { sTownName = value; }
        }
        private string sVillageName;//村名称

        public string SVillageName
        {
            get { return sVillageName; }
            set { sVillageName = value; }
        }
        private string sGroupName;//组名称

        public string SGroupName
        {
            get { return sGroupName; }
            set { sGroupName = value; }
        }
        private string sMemo;//备注

        public string SMemo
        {
            get { return sMemo; }
            set { sMemo = value; }
        }
        private string sPatientAssume;//病人个人承担金额

        public string SPatientAssume
        {
            get { return sPatientAssume; }
            set { sPatientAssume = value; }
        }
        private string sHospialAssume;//医院承担金额

        public string SHospialAssume
        {
            get { return sHospialAssume; }
            set { sHospialAssume = value; }
        }
        private string sBasicMedSum;//基本药物金额

        public string SBasicMedSum
        {
            get { return sBasicMedSum; }
            set { sBasicMedSum = value; }
        }
        private string sBasicMedComp;//基本药物增补金额

        public string SBasicMedComp
        {
            get { return sBasicMedComp; }
            set { sBasicMedComp = value; }
        }
        private string sDisFixMoney;//单病种费用定额

        public string SDisFixMoney
        {
            get { return sDisFixMoney; }
            set { sDisFixMoney = value; }
        }
        private string sCivilComp;//民政救助补偿金额

        public string SCivilComp
        {
            get { return sCivilComp; }
            set { sCivilComp = value; }
        }
        private string sCMeComp;//中医药品/诊疗增补金额

        public string SCMeComp
        {
            get { return sCMeComp; }
            set { sCMeComp = value; }
        }
        private string sIfBottom;//是否保底补偿

        public string SIfBottom
        {
            get { return sIfBottom; }
            set { sIfBottom = value; }
        }
        private string sObligate1;//大病保险补偿金额

        public string SObligate1
        {
            get { return sObligate1; }
            set { sObligate1 = value; }
        }
        private string sObligate2;//个人自付累计

        public string SObligate2
        {
            get { return sObligate2; }
            set { sObligate2 = value; }
        }
        private string sObligate3;//是否贫困人口

        public string SObligate3
        {
            get { return sObligate3; }
            set { sObligate3 = value; }
        }
        private string sObligate4;//财政兜底资金金额

        public string SObligate4
        {
            get { return sObligate4; }
            set { sObligate4 = value; }
        }
        private string sObligate5;//预留字段5

        public string SObligate5
        {
            get { return sObligate5; }
            set { sObligate5 = value; }
        }

        private string sFDJE;//分段金额

        public string SFDJE
        {
            get { return sFDJE; }
            set { sFDJE = value; }
        }
        private string sRDJE;//入段金额

        public string SRDJE
        {
            get { return sRDJE; }
            set { sRDJE = value; }
        }
        private string sBXBL;//报销比例

        public string SBXBL
        {
            get { return sBXBL; }
            set { sBXBL = value; }
        }
        private string sBXJE;//报销金额

        public string SBXJE
        {
            get { return sBXJE; }
            set { sBXJE = value; }
        }

          
    }
}
