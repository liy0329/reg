using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdyb.bo
{
    class Djbypdzxx_in
    {
        private string _jbbm;
        private string _ypbm;
        /// <summary>
        /// 疾病编码
        /// </summary>
        public string Jbbm
        {
            set { _jbbm = value; }
            get { return _jbbm; }
        }
        /// <summary>
        /// 药品编码
        /// </summary>
        public string Ypbm
        {
            set { _ypbm = value; }
            get { return _ypbm; }
        }
    }
}
