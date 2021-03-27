using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ynsyb.bo
{
    class Jszh_out
    {
        //交易流水号（结算结算召回ID）| 总费用|统筹|账户|现金|大病理赔|照顾人员补助|公务员补助|解放前工作人员补助|起付线|住院次数|起付线剩余
        private string jylsh;//交易流水号（结算结算召回ID）

        public string Jylsh
        {
            get { return jylsh; }
            set { jylsh = value; }
        }
        private string zfy;//总费用

        public string Zfy
        {
            get { return zfy; }
            set { zfy = value; }
        }
        private string tc;//统筹

        public string Tc
        {
            get { return tc; }
            set { tc = value; }
        }
        private string zh;//账户

        public string Zh
        {
            get { return zh; }
            set { zh = value; }
        }
        private string xj;//现金

        public string Xj
        {
            get { return xj; }
            set { xj = value; }
        }
        private string dblp;//大病理赔

        public string Dblp
        {
            get { return dblp; }
            set { dblp = value; }
        }
        private string zgrybz;//照顾人员补助

        public string Zgrybz
        {
            get { return zgrybz; }
            set { zgrybz = value; }
        }
        private string gwybz;//公务员补助

        public string Gwybz
        {
            get { return gwybz; }
            set { gwybz = value; }
        }
        private string jfqgzrybz;//解放前工作人员补助

        public string Jfqgzrybz
        {
            get { return jfqgzrybz; }
            set { jfqgzrybz = value; }
        }
        private string qfx;//起付线

        public string Qfx
        {
            get { return qfx; }
            set { qfx = value; }
        }
        private string zycs;//住院次数

        public string Zycs
        {
            get { return zycs; }
            set { zycs = value; }
        }
        private string qfxsy;//起付线剩余

        public string Qfxsy
        {
            get { return qfxsy; }
            set { qfxsy = value; }
        }
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }
    }
}
