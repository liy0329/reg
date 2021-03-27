using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ynsyb.bo
{
    class Wfty_in
    {
        private string jylbdm;//交易类别代码

        public string Jylbdm
        {
            get { return jylbdm; }
            set { jylbdm = value; }
        }
        private string grbh;//个人编号

        public string Grbh
        {
            get { return grbh; }
            set { grbh = value; }
        }
        private string ddbh;//定点编号

        public string Ddbh
        {
            get { return ddbh; }
            set { ddbh = value; }
        }
        private string jylsh;//交易流水号（登记ID

        public string Jylsh
        {
            get { return jylsh; }
            set { jylsh = value; }
        }
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }
    }
}
