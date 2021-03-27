using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ahsjk.bo.inp
{
    class In_DownCalcuList : TopIn
    {
        private string sBeginDate;
        private string sEndDate;
        /// <summary>
        /// //起始时间
        /// </summary>
        public string SBeginDate
        {
            get { return sBeginDate; }
            set { sBeginDate = value; }
        }
        /// <summary>
        /// 截止时间
        /// </summary>
        public string SEndDate
        {
            get { return sEndDate; }
            set { sEndDate = value; }
        }
    }
}
