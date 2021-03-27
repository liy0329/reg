using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ahsjk.bo.inp
{
    class In_ItemContrastDown:TopIn
    {
        [Valid(Required = true, Description = "不能为空")]
        private string sCenterItemC;
        [Valid(Required = true, Description = "不能为空")]
        private string sItemCode;
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
    }
}
