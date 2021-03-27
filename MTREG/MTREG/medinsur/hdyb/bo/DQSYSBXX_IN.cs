using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdyb.bo
{
    class Dqsysbxx_in
    {
        private string _grbh;
        private string _mzzyh;
        /// <summary>
        /// 个人编号
        /// </summary>
        public string Grbh
        {
            set { _grbh = value; }
            get { return _grbh; }
        }
        /// <summary>
        /// 门诊住院号
        /// </summary>
        public string Mzzyh
        {
            set { _mzzyh = value; }
            get { return _mzzyh; }
        }
    }
}
