using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ynydyb.bo
{
    public class YdCfmxtf_out
    {
        private string sysl;
        /// <summary>
        /// 剩余数量
        /// </summary>
        public string Sysl
        {
            get { return sysl; }
            set { sysl = value; }
        }
        private string syje;
        /// <summary>
        /// 剩余金额
        /// </summary>
        public string Syje
        {
            get { return syje; }
            set { syje = value; }
        }
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }
    }
}
