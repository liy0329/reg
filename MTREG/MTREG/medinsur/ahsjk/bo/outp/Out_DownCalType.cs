using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ahsjk.bo.outp
{
    class Out_DownCalType
    {
        private string sCode;
        /// <summary>
        /// 编号
        /// </summary>
        public string SCode
        {
            get { return sCode; }
            set { sCode = value; }
        }
        private string sName;
        /// <summary>
        /// 名称
        /// </summary>
        public string SName
        {
            get { return sName; }
            set { sName = value; }
        }
    }
}
