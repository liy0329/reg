using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdyb.bo
{
    class Dqsyypxx_out
    {
        //费用等级登记（甲类或乙类或丙类）|门诊自付比例|住院自付比例|药品最高限价|费用类别（西药、中草药等）|XX
        private string _fydjdj;
        private string _mzzfbl;
        private string _zyzfbl;
        private string _ypzgxj;
        private string _fylb;
        private string _message;
        /// <summary>
        /// 费用等级登记
        /// </summary>
        public string Fydjdj
        {
            set { _fydjdj = value; }
            get { return _fydjdj; }
        }
        /// <summary>
        /// 门诊自付比例
        /// </summary>
        public string Mzzfbl
        {
            set { _mzzfbl = value; }
            get { return _mzzfbl; }
        }
        /// <summary>
        /// 住院自付比例
        /// </summary>
        public string Zyzfbl
        {
            set { _zyzfbl = value; }
            get { return _zyzfbl; }
        }
        /// <summary>
        /// 药品最高限价
        /// </summary>
        public string Ypzgxj
        {
            set { _ypzgxj = value; }
            get { return _ypzgxj; }
        }
        /// <summary>
        /// 费用类别
        /// </summary>
        public string Fylb
        {
            set { _fylb = value; }
            get { return _fylb; }
        }
        public string Message
        {
            set { _message = value; }
            get { return _message; }
        }
    }
}
