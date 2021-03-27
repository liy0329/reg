using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ynsyb.bo
{
    class Qdmxxmdj_out
    {
        private string kydj;//可用单价

        public string Kydj
        {
            get { return kydj; }
            set { kydj = value; }
        }

        private string xmdj;//项目等级

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
