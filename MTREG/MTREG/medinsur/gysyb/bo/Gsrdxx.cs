using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gysyb.bo
{
    class Gsrdxx
    {
        private string gsrdbh;//工伤认定编号

        public string Gsrdbh
        {
            get { return gsrdbh; }
            set { gsrdbh = value; }
        }
        private string sgsj;//事故时间

        public string Sgsj
        {
            get { return sgsj; }
            set { sgsj = value; }
        }
        private string gsrylb;//工伤人员类别

        public string Gsrylb
        {
            get { return gsrylb; }
            set { gsrylb = value; }
        }
        private string zyblb;//职业病类别

        public string Zyblb
        {
            get { return zyblb; }
            set { zyblb = value; }
        }
        private string shbw;//伤害部位

        public string Shbw
        {
            get { return shbw; }
            set { shbw = value; }
        }
        private string rdjl;//认定结论

        public string Rdjl
        {
            get { return rdjl; }
            set { rdjl = value; }
        }
        private string scdj;//伤残等级

        public string Scdj
        {
            get { return scdj; }
            set { scdj = value; }
        }
        private string dwbm;//单位编码

        public string Dwbm
        {
            get { return dwbm; }
            set { dwbm = value; }
        }
        private string dwmc;//单位名称

        public string Dwmc
        {
            get { return dwmc; }
            set { dwmc = value; }
        }
    }
}
