
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdyb.bo
{
    class Dqfwssxx_out
    {
        //费用等级（甲类或乙类或丙类）|费用类别|本地价格|中心价格
        private string _fydj;
        private string _fylb;
        private string _bdjg;
        private string _zxje;
        private string _message;
        /// <summary>
        /// 费用等级
        /// </summary>
        public string Fydj
        {
            set { _fydj = value; }
            get { return _fydj; }
        }
        /// <summary>
        /// 费用类别
        /// </summary>
        public string Fylb
        {
            set { _fylb = value; }
            get { return _fylb; }
        }
        /// <summary>
        /// 本地价格
        /// </summary>
        public string Bdjg
        {
            set { _bdjg = value; }
            get { return _bdjg; }
        }
        /// <summary>
        /// 中心价格
        /// </summary>
        public string Zxje
        {
            set { _zxje = value; }
            get { return _zxje; }
        }
        public string Message
        {
            set { _message = value; }
            get { return _message; }
        }
    }
}
