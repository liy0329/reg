using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ahsjk.bo.inp
{
    /// <summary>
    /// 【获取家庭成员列表】输入参数封装类
    /// </summary>
    class In_GetPersonInfo:TopIn
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
        private string sMedicalCode;
        /// <summary>
        ///医疗证号 
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
    }
}
