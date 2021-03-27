using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ahsjk.bo.outp
{
    class Out_DownTreat
    {
        private string sTreatCode;//治疗方式编码
        private string sTreatName;//治疗方式名称
        private string sIcdno;//单病种ICD编码
        private string sIcdName;//单病种ICD名称
        private string sObligate1;//预留字段1
        private string sObligate2;//预留字段2
        private string sObligate3;//预留字段3
        private string sObligate4;//预留字段4
        private string sObligate5;//预留字段5

        public string STreatCode
        {
            get { return sTreatCode; }
            set { sTreatCode = value; }
        }

        public string STreatName
        {
            get { return sTreatName; }
            set { sTreatName = value; }
        }

        public string SIcdno
        {
            get { return sIcdno; }
            set { sIcdno = value; }
        }

        public string SIcdName
        {
            get { return sIcdName; }
            set { sIcdName = value; }
        }

        public string SObligate1
        {
            get { return sObligate1; }
            set { sObligate1 = value; }
        }

        public string SObligate2
        {
            get { return sObligate2; }
            set { sObligate2 = value; }
        }

        public string SObligate3
        {
            get { return sObligate3; }
            set { sObligate3 = value; }
        }

        public string SObligate4
        {
            get { return sObligate4; }
            set { sObligate4 = value; }
        }

        public string SObligate5
        {
            get { return sObligate5; }
            set { sObligate5 = value; }
        }
    }
}
