using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ahsjk.bo.inp
{
    class In_DownICD:TopIn
    {
        private string sAreaCode;
        /// <summary>
        /// 地区编码
        /// </summary>
        public string SAreaCode
        {
            get { return sAreaCode; }
            set { sAreaCode = value; }
        }
        private string sUserCode;
        /// <summary>
        /// 用户名
        /// </summary>
        public string SUserCode
        {
            get { return sUserCode; }
            set { sUserCode = value; }
        }
        private string sUserPass;
        /// <summary>
        /// 密码
        /// </summary>
        public string SUserPass
        {
            get { return sUserPass; }
            set { sUserPass = value; }
        }
    }
}
