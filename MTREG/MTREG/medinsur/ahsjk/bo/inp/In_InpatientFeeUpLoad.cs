using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ahsjk.bo.inp
{
    class In_InpatientFeeUpLoad : TopIn
    {
        [Valid(Required = true, Description = "不能为空")]
        private string sCenterItemCode;
        [Valid(Required = true, Description = "不能为空")]
        private string sItemKey;
        [Valid(Required = true, Description = "不能为空")]
        private string sItemType;
        [Valid(Required = true, Description = "不能为空")]
        private string sReceiptName;
        [Valid(Required = true, Description = "不能为空")]
        private string sItemCode;
        [Valid(Required = true, Description = "不能为空")]
        private string sItemName;
        [Valid(Required = true, Description = "不能为空")]
        private string sItemSpec;
        private string sItemDose;
        private string sItemArea;
        private string sItemProc;
        private string sItemPart;
        [Valid(Required = true, Description = "不能为空")]
        private string sIfCompound;
        [Valid(Required = true, Description = "不能为空")]
        private string sTime;
        [Valid(Required = true, Description = "不能为空")]
        private string sUnit;//HIS项目单位
        [Valid(Required = true, Description = "不能为空")]
        private string sPrice;//单价
        [Valid(Required = true, Description = "不能为空")]
        private string sSum;//总金额
        [Valid(Required = true, Description = "不能为空")]
        private string sSectionOfficeName;
        [Valid(Required = true, Description = "不能为空")]
        private string sSectionOfficeCode;//中心科室编码
        [Valid(Required = true, Description = "不能为空")]
        private string sDoctorName;//医生名称
        private string sBed;//床号
        [Valid(Required = true, Description = "不能为空")]
        private string sOperatorDate;//记帐时间
        [Valid(Required = true, Description = "不能为空")]
        private string sInputName;//记帐人姓名
        /// <summary>
        /// //中心项目编码
        /// </summary>
        public string SCenterItemCode
        {
            get { return sCenterItemCode; }
            set { sCenterItemCode = value; }
        }
        /// <summary>
        /// //HIS记帐关键字
        /// </summary>
        public string SItemKey
        {
            get { return sItemKey; }
            set { sItemKey = value; }
        }
        /// <summary>
        /// //费用类型
        /// </summary>
        public string SItemType
        {
            get { return sItemType; }
            set { sItemType = value; }
        }
        /// <summary>
        /// HIS发票项目名称
        /// </summary>
        public string SReceiptName
        {
            get { return sReceiptName; }
            set { sReceiptName = value; }
        }
        /// <summary>
        /// HIS药品/项目编码
        /// </summary>
        public string SItemCode
        {
            get { return sItemCode; }
            set { sItemCode = value; }
        }
        /// <summary>
        /// HIS药品/项目名称
        /// </summary>
        public string SItemName
        {
            get { return sItemName; }
            set { sItemName = value; }
        }
        /// <summary>
        /// HIS药品/项目规格
        /// </summary>
        public string SItemSpec
        {
            get { return sItemSpec; }
            set { sItemSpec = value; }
        }
        /// <summary>
        /// HIS药品/项目剂型
        /// </summary>
        public string SItemDose
        {
            get { return sItemDose; }
            set { sItemDose = value; }
        }
        /// <summary>
        /// HIS药品/项目产地
        /// </summary>
        public string SItemArea
        {
            get { return sItemArea; }
            set { sItemArea = value; }
        }
        /// <summary>
        /// HIS药品/项目加工过程
        /// </summary>
        public string SItemProc
        {
            get { return sItemProc; }
            set { sItemProc = value; }
        }
        /// <summary>
        /// HIS药品/项目入药部位
        /// </summary>
        public string SItemPart
        {
            get { return sItemPart; }
            set { sItemPart = value; }
        }
        /// <summary>
        /// //是否复方
        /// </summary>
        public string SIfCompound
        {
            get { return sIfCompound; }
            set { sIfCompound = value; }
        }
        /// <summary>
        /// //数量
        /// </summary>
        public string STime
        {
            get { return sTime; }
            set { sTime = value; }
        }

        public string SUnit
        {
            get { return sUnit; }
            set { sUnit = value; }
        }

        public string SPrice
        {
            get { return sPrice; }
            set { sPrice = value; }
        }

        public string SSum
        {
            get { return sSum; }
            set { sSum = value; }
        }

        public string SSectionOfficeName
        {
            get { return sSectionOfficeName; }
            set { sSectionOfficeName = value; }
        }

        public string SSectionOfficeCode
        {
            get { return sSectionOfficeCode; }
            set { sSectionOfficeCode = value; }
        }

        public string SDoctorName
        {
            get { return sDoctorName; }
            set { sDoctorName = value; }
        }

        public string SBed
        {
            get { return sBed; }
            set { sBed = value; }
        }

        public string SOperatorDate
        {
            get { return sOperatorDate; }
            set { sOperatorDate = value; }
        }

        public string SInputName
        {
            get { return sInputName; }
            set { sInputName = value; }
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
