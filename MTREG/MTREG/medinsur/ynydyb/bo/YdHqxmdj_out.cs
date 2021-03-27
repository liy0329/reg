using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ynydyb.bo
{
    public class YdHqxmdj_out
    {
        private string kydj;
        /// <summary>
        /// 可用单价
        /// </summary>
        public string Kydj
        {
            get { return kydj; }
            set { kydj = value; }
        }
        private string xmdj;
        /// <summary>
        /// 项目等级
        /// </summary>
        public string Xmdj
        {
            get { return xmdj; }
            set { xmdj = value; }
        }
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }
    }
}
