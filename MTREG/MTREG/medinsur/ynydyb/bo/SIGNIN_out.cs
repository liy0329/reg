using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ynydyb.bo
{
    public class SIGNIN_out
    {
        private string czyywzqh;
        /// <summary>
        /// 操作员业务周期号
        /// </summary>
        public string Czyywzqh
        {
            get { return czyywzqh; }
            set { czyywzqh = value; }
        }
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }
    }
}
