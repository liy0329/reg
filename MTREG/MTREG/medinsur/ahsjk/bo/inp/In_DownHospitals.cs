using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ahsjk.bo.inp
{
    class In_DownHospitals : TopIn
    {
        [Valid(Required = true, Description = "不能为空")]
        private string sUserCode;//用户名
        [Valid(Required = true, Description = "不能为空")]
        private string sUserPass;//密码
        [Valid(Required = true, Description = "不能为空")]
        private string updateTime;//传入的更新时间

        public string SUserCode
        {
            get { return sUserCode; }
            set { sUserCode = value; }
        }

        public string SUserPass
        {
            get { return sUserPass; }
            set { sUserPass = value; }
        }

        public string UpdateTime
        {
            get { return updateTime; }
            set { updateTime = value; }
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
    }
}
