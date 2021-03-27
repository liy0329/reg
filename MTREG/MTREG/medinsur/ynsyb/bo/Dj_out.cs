using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ynsyb.bo
{
    class Dj_out
    {
        private string jylsh;//交易流水号（登记ID）

        public string Jylsh
        {
            get { return jylsh; }
            set { jylsh = value; }
        }
        private string zycs;//住院次数

        public string Zycs
        {
            get { return zycs; }
            set { zycs = value; }
        }
        private string qfx;//起付线

        public string Qfx
        {
            get { return qfx; }
            set { qfx = value; }
        }
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }
    }
}
