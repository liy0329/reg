using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ahsjk.bo.outp
{
    class Out_ItemContrastDown
    {
        private string sState;
        /// <summary>
        /// //审核结果
        /// </summary>
        public string SState
        {
            get { return sState; }
            set { sState = value; }
        }
        private string sAuditName;
        /// <summary>
        /// //审核人
        /// </summary>
        public string SAuditName
        {
            get { return sAuditName; }
            set { sAuditName = value; }
        }
        private string sAuditDate;
        /// <summary>
        /// //审核时间
        /// </summary>
        public string SAuditDate
        {
            get { return sAuditDate; }
            set { sAuditDate = value; }
        }
        private string sReason;
        /// <summary>
        /// //审核不通过原因
        /// </summary>
        public string SReason
        {
            get { return sReason; }
            set { sReason = value; }
        }
    }
}
