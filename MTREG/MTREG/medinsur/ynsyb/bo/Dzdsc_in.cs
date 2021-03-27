using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ynsyb.bo
{
    class Dzdsc_in
    {
        private string grbh;//个人编号

        public string Grbh
        {
            get { return grbh; }
            set { grbh = value; }
        }

        private string jylsh;//交易流水号（登记ID）

        public string Jylsh
        {
            get { return jylsh; }
            set { jylsh = value; }
        }
        private string dzdxx;//多诊断信息

        public string Dzdxx
        {
            get { return dzdxx; }
            set { dzdxx = value; }
        }
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }
    }
}
