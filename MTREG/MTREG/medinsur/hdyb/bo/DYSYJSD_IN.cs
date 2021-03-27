using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdyb.bo
{
    class Dysyjsd_in
    {
        private string _grbh;
        private string _mzzyh;
        private string _jbr;

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
        /// <summary>
        /// 经办人
        /// </summary>
        public string Jbr
        {
            set { _jbr = value; }
            get { return _jbr; }
        }
    }
}
