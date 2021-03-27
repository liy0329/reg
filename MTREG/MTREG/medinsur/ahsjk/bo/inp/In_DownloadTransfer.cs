using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ahsjk.bo.inp
{
    class In_DownloadTransfer : TopIn
    {
        [Valid(Required = true, Description = "不能为空")]
        private string sUserCode;
        [Valid(Required = true, Description = "不能为空")]
        private string sUserPass;
        [Valid(Required = true, Description = "不能为空")]
        private string inorout;
        private string truncode;
        private string memberno;
        [Valid(Required = true, Description = "不能为空")]
        private string startturndate;
        [Valid(Required = true, Description = "不能为空")]
        private string endturndate;
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
        /// //转诊流向编码
        /// </summary>
        public string Inorout
        {
            get { return inorout; }
            set { inorout = value; }
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
        /// <summary>
        /// //转诊时间段（起始）
        /// </summary>
        public string Startturndate
        {
            get { return startturndate; }
            set { startturndate = value; }
        }
        /// <summary>
        /// //转诊时间段（截止）
        /// </summary>
        public string Endturndate
        {
            get { return endturndate; }
            set { endturndate = value; }
        }
    }
}
