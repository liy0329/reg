using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdyb.bo
{
    class Dryspxx_out
    {
        private string _spbz;
        private string _message;

        /// <summary>
        /// 审批标志
        /// </summary>
        public string Spbz
        {
            set { _spbz = value; }
            get { return _spbz; }
        }
        public string Message
        {
            set { _message = value; }
            get { return _message; }
        }
    }
}
