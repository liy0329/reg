using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ynsyb.bo
{
    class Hqxzzw_in
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
        private string ycxdxxbm;//要查询的信息编码

        public string Ycxdxxbm
        {
            get { return ycxdxxbm; }
            set { ycxdxxbm = value; }
        }
        private string fjxx;//附加信息

        public string Fjxx
        {
            get { return fjxx; }
            set { fjxx = value; }
        }
    }
}
