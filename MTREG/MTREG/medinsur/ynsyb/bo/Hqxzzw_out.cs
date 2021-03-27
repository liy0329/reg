using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ynsyb.bo
{
    class Hqxzzw_out
    {
        private string xzzwdm;//行政职务代码

        public string Xzzwdm
        {
            get { return xzzwdm; }
            set { xzzwdm = value; }
        }
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }
    }
}
