using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ynydyb.bo
{
    public class YdXmspjgcx_out
    {
        private string spjglb;
        /// <summary>
        /// 审批结果类别
        /// </summary>
        public string Spjglb
        {
            get { return spjglb; }
            set { spjglb = value; }
        }
        private string spbh;
        /// <summary>
        /// 审批编号
        /// </summary>
        public string Spbh
        {
            get { return spbh; }
            set { spbh = value; }
        }
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }
    }
}
