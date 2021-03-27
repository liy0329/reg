using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.clintab.bo
{
    class ClinicTabReport
    {
        private string starTime;
        private string endTime;
        private string clinictab_id;
        
        /// <summary>
        /// dtpStime
        /// </summary>
        public string StarTime
        {
            get { return starTime; }
            set { starTime = value; }
        }
        /// <summary>
        /// dtpEtime
        /// </summary>
        public string EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
        /// <summary>
        /// 门诊日结主键
        /// </summary>
        public string Clinictab_id
        {
            get { return clinictab_id; }
            set { clinictab_id = value; }
        }

        private string clinicDuty_id;
        /// <summary>
        /// 班结外键
        /// </summary>
        public string ClinicDuty_id
        {
            get { return clinicDuty_id; }
            set { clinicDuty_id = value; }
        }

        private string flag;
        /// <summary>
        /// 日结/班结 标记
        /// </summary>
        public string Flag
        {
            get { return flag; }
            set { flag = value; }
        }

        private string info;
        /// <summary>
        /// 结算科室/结算人
        /// </summary>
        public string Info
        {
            get { return info; }
            set { info = value; }
        }
    
    }
}
