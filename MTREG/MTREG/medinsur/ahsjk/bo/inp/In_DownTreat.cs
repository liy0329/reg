using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ahsjk.bo.inp
{
    class In_DownTreat : TopIn
    {
        [Valid(Required = true, Description = "不能为空")]
        private string sUserCode;
        [Valid(Required = true, Description = "不能为空")]
        private string sUserPass;
        [Valid(Required = true, Description = "不能为空")]
        private string sYear;
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
        /// //年份
        /// </summary>
        public string SYear
        {
            get { return sYear; }
            set { sYear = value; }
        }
    }
}
