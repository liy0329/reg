using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gzsnh.bo
{
    class Disease
    {
        private string icdAllno;

        public string IcdAllno
        {
            get { return icdAllno; }
            set { icdAllno = value; }
        }
        private string icdName;

        public string IcdName
        {
            get { return icdName; }
            set { icdName = value; }
        }
        private string scienceName;

        public string ScienceName
        {
            get { return scienceName; }
            set { scienceName = value; }
        }
        private string enName;

        public string EnName
        {
            get { return enName; }
            set { enName = value; }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private string icdType;

        public string IcdType
        {
            get { return icdType; }
            set { icdType = value; }
        }
        private string icdFlag;

        public string IcdFlag
        {
            get { return icdFlag; }
            set { icdFlag = value; }
        }
        private string sexLimited;

        public string SexLimited
        {
            get { return sexLimited; }
            set { sexLimited = value; }
        }
        private string createTime;

        public string CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
        }
        private string updateTime;

        public string UpdateTime
        {
            get { return updateTime; }
            set { updateTime = value; }
        }
        private string inputcodePy;

        public string InputcodePy
        {
            get { return inputcodePy; }
            set { inputcodePy = value; }
        }
        private string inputcodeWb;

        public string InputcodeWb
        {
            get { return inputcodeWb; }
            set { inputcodeWb = value; }
        }
        private string chronicFlag;

        public string ChronicFlag
        {
            get { return chronicFlag; }
            set { chronicFlag = value; }
        }
        private string state;

        public string State
        {
            get { return state; }
            set { state = value; }
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        private string useFrequence;

        public string UseFrequence
        {
            get { return useFrequence; }
            set { useFrequence = value; }
        }
    }
}
