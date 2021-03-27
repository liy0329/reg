using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ahsjk.bo.outp
{
    class Out_DownHospitals
    {
        private string organCode;//组织机构代码
        private string hospName;//医疗机构名称
        private string grader;//医院技术等级编码
        private string orgLevel;//医院行政级别编码
        private string sObligate1;//预留字段1
        private string sObligate2;//预留字段2
        private string sObligate3;//预留字段3
        private string sObligate4;//预留字段4
        private string sObligate5;//预留字段5

        public string OrganCode
        {
            get { return organCode; }
            set { organCode = value; }
        }

        public string HospName
        {
            get { return hospName; }
            set { hospName = value; }
        }

        public string Grader
        {
            get { return grader; }
            set { grader = value; }
        }

        public string OrgLevel
        {
            get { return orgLevel; }
            set { orgLevel = value; }
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
