using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ynsyb.bo
{
    class Xmspjgcx_out
    {
        private string spjglb;//审批结果类别

        public string Spjglb
        {
            get { return spjglb; }
            set { spjglb = value; }
        }
        private string spbh;//审批编号

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
