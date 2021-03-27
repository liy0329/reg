using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ynydyb.bo
{
    public class Jcjyzt_out
    {
        private string jyzt;
        /// <summary>
        /// 交易状态
        /// </summary>
        public string Jyzt
        {
            get { return jyzt; }
            set { jyzt = value; }
        }

        private string zjybcxzt;
        /// <summary>
        /// 正交易被撤销状态
        /// </summary>
        public string Zjybcxzt
        {
            get { return zjybcxzt; }
            set { zjybcxzt = value; }
        }

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }
    }
}
