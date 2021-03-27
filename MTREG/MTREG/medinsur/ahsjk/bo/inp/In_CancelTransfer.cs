using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ahsjk.bo.inp
{
    class In_CancelTransfer : TopIn
    {
        [Valid(Required = true, Description = "不能为空")]
        private string sUserCode;
        [Valid(Required = true, Description = "不能为空")]
        private string sUserPass;
        [Valid(Required = true, Description = "不能为空")]
        private string truncode;
        [Valid(Required = true, Description = "不能为空")]
        private string memberno;
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
        /// 账号
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
        /// //转诊单编号
        /// </summary>
        public string Truncode
        {
            get { return truncode; }
            set { truncode = value; }
        }
        /// <summary>
        /// //成员编码
        /// </summary>
        public string Memberno
        {
            get { return memberno; }
            set { memberno = value; }
        }
    }
}
