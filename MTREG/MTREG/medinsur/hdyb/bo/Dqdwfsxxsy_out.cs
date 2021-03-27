using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdyb.bo
{
    class Dqdwfsxxsy_out
    {
        //封锁标志| 封锁开始时间 | 封锁结束时间 | 封锁原因 | 封锁级别|XX
        private string _fsbz;
        private string _fskssj;
        private string _fsjssj;
        private string _fsyy;
        private string _fsjb;
        private string _message;
        /// <summary>
        /// 封锁标志
        /// </summary>
        public string Fsbz
        {
            set { _fsbz = value; }
            get { return _fsbz; }
        }
        /// <summary>
        /// 封锁开始时间
        /// </summary>
        public string Fskssj
        {
            set { _fskssj = value; }
            get { return _fskssj; }
        }
        /// <summary>
        /// 封锁结束时间
        /// </summary>
        public string Fsjssj
        {
            set { _fsjssj = value; }
            get { return _fsjssj; }
        }
        /// <summary>
        /// 封锁原因
        /// </summary>
        public string Fsyy
        {
            set { _fsyy = value; }
            get { return _fsyy; }
        }
        /// <summary>
        /// 封锁级别
        /// </summary>
        public string Fsjb
        {
            set { _fsjb = value; }
            get { return _fsjb; }
        }
        public string Message
        {
            set { _message = value; }
            get { return _message; }
        }
    }
}
