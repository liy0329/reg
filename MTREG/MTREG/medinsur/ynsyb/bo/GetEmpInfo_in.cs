using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ynsyb.bo
{
    class GetEmpInfo_in
    {
        private string kzbz;//卡证标志

        public string Kzbz
        {
            get { return kzbz; }
            set { kzbz = value; }
        }
        private string grbh;//个人编号

        public string Grbh
        {
            get { return grbh; }
            set { grbh = value; }
        }
        private string zh;//证号

        public string Zh
        {
            get { return zh; }
            set { zh = value; }
        }
    }
}
