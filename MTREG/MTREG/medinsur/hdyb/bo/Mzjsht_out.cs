using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdyb.bo
{
    class Mzjsht_out
    {
        //医疗费用总额|本次现金支付金额|结算后IC卡余额|XX
        private string _ylfyze;
        private string _bcxjzfje;
        private string _jshickye;
        private string _message;

        /// <summary>
        /// 医疗费用总额
        /// </summary>
        public string Ylfyze
        {
            set { _ylfyze = value; }
            get { return _ylfyze; }
        }
        /// <summary>
        /// 本次现金支付金额
        /// </summary>
        public string Bcxjzfje
        {
            set { _bcxjzfje = value; }
            get { return _bcxjzfje; }
        }
        /// <summary>
        /// 结算后IC卡余额
        /// </summary>
        public string Jshickye
        {
            set { _jshickye = value; }
            get { return _jshickye; }
        }
        public string Message
        {
            set { _message = value; }
            get { return _message; }
        }
    }
}
