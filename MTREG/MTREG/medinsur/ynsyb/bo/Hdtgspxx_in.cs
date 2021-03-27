using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ynsyb.bo
{
    class Hdtgspxx_in
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
        private string splbdbm;//审批类别的编码

        public string Splbdbm
        {
            get { return splbdbm; }
            set { splbdbm = value; }
        }

    }
}
