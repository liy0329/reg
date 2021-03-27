using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ahsjk.bo.inp
{
    class In_ItemContrastUp : TopIn
    {
        [Valid(Required = true, Description = "不能为空")]
        private string sCenterItemC;
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
        private string sUnit;
        [Valid(Required = true, Description = "不能为空")]
        private string sPrice;
        [Valid(Required = true, Description = "不能为空")]
        private string sItemType;
        /// <summary>
        /// //中心项目编码
        /// </summary>
        public string SCenterItemC
        {
            get { return sCenterItemC; }
            set { sCenterItemC = value; }
        }
        /// <summary>
        /// //HIS药品/项目编码
        /// </summary>
        public string SItemCode
        {
            get { return sItemCode; }
            set { sItemCode = value; }
        }
        /// <summary>
        /// //HIS药品/项目名称
        /// </summary>
        public string SItemName
        {
            get { return sItemName; }
            set { sItemName = value; }
        }
        /// <summary>
        /// //HIS药品/项目规格
        /// </summary>
        public string SItemSpec
        {
            get { return sItemSpec; }
            set { sItemSpec = value; }
        }
        /// <summary>
        /// //HIS药品/项目剂型
        /// </summary>
        public string SItemDose
        {
            get { return sItemDose; }
            set { sItemDose = value; }
        }
        /// <summary>
        /// //HIS药品/项目产地
        /// </summary>
        public string SItemArea
        {
            get { return sItemArea; }
            set { sItemArea = value; }
        }
        /// <summary>
        /// //HIS药品/项目加工过程
        /// </summary>
        public string SItemProc
        {
            get { return sItemProc; }
            set { sItemProc = value; }
        }
        /// <summary>
        /// //HIS药品/项目入药部位
        /// </summary>
        public string SItemPart
        {
            get { return sItemPart; }
            set { sItemPart = value; }
        }
        /// <summary>
        /// //HIS项目单位
        /// </summary>
        public string SUnit
        {
            get { return sUnit; }
            set { sUnit = value; }
        }
        /// <summary>
        /// //单价
        /// </summary>
        public string SPrice
        {
            get { return sPrice; }
            set { sPrice = value; }
        }
        /// <summary>
        /// //费用类型
        /// </summary>
        public string SItemType
        {
            get { return sItemType; }
            set { sItemType = value; }
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
    }
}
