using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdyb.bo
{
    class Drymxbxx_out
    {
        //审批病种his内码1|审批病种名称1|审批病种his内码2|审批病种名称2
        private string _bznm1;
        private string _bzmc1;
        private string _bznm2;
        private string _bzmc2;
        private string _message;
        /// <summary>
        /// 审批病种his内码1
        /// </summary>
        public string Bznm1
        {
            set { _bznm1 = value; }
            get { return _bznm1; }
        }
        /// <summary>
        /// 审批病种名称1
        /// </summary>
        public string Bzmc1
        {
            set { _bzmc1 = value; }
            get { return _bzmc1; }
        }
        /// <summary>
        /// 审批病种his内码2
        /// </summary>
        public string Bznm2
        {
            set { _bznm2 = value; }
            get { return _bznm2; }
        }
        /// <summary>
        /// 审批病种名称2
        /// </summary>
        public string Bzmc2
        {
            set { _bzmc2 = value; }
            get { return _bzmc2; }
        }
        public string Message
        {
            set { _message = value; }
            get { return _message; }
        }

        private string spxx;

        public string Spxx
        {
            get { return spxx; }
            set { spxx = value; }
        }
    }
}
