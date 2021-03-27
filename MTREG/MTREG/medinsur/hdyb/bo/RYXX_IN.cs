using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdyb.bo
{
    class Ryxx_in
    {
        //入参为个人编号和门诊住院号的所有业务
        private string _grbh;
        private string _mzzyh;
        private string _message;
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
        public string Message
        {
            set { _message = value; }
            get { return _message; }
        }
    }
}
