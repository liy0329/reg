using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdyb.bo
{
    class Dqkcxfdhje_out
    {
        //扣除先负担后金额|药品等级|费用类别|自付比例
        private string _kcxfdhje;
        private string _ypdj;
        private string _fylb;
        private string _zfbl;
        /// <summary>
        /// 扣除先负担后金额
        /// </summary>
        public string Kcxfdhje
        {
            set { _kcxfdhje = value; }
            get { return _kcxfdhje; }
        }
        /// <summary>
        /// 药品等级
        /// </summary>
        public string Ypdj
        {
            set { _ypdj = value; }
            get { return _ypdj; }
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
        /// 自付比例
        /// </summary>
        public string Zfbl
        {
            set { _zfbl = value; }
            get { return _zfbl; }
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
    }
}
