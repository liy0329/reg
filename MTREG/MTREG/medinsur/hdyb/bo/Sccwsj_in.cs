using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdyb.bo
{
    class Sccwsj_in
    {
        //门诊住院号|单据号
        private string _mzzyh;
        private string _djh;
        private string _message;

        /// <summary>
        /// 门诊住院号
        /// </summary>
        public string Mzzyh
        {
            set { _mzzyh = value; }
            get { return _mzzyh; }
        }
        /// <summary>
        /// 单据号
        /// </summary>
        public string Djh
        {
            set { _djh = value; }
            get { return _djh; }
        }
        public string Message
        {
            set { _message = value; }
            get { return _message; }
        }
    }
}
