using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ynydyb.bo
{
    class YnydybAccInfo
    {        
        private string feeamt;
        /// <summary>
        /// 总费用
        /// </summary>
        public string Feeamt
        {
            get { return feeamt; }
            set { feeamt = value; }
        }

        private string insurefee;
        /// <summary>
        /// 统筹支付
        /// </summary>
        public string Insurefee
        {
            get { return insurefee; }
            set { insurefee = value; }
        }
        private string insuraccountFee;
        /// <summary>
        /// 账户支付
        /// </summary>
        public string InsuraccountFee
        {
            get { return insuraccountFee; }
            set { insuraccountFee = value; }
        }
    }
}
