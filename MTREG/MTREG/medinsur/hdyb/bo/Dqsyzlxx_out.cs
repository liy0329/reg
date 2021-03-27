using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdyb.bo
{
    class Dqsyzlxx_out
    {
        //费用等级（甲类或乙类或丙类）|门诊自付比例|住院自付比例| 特殊诊疗标志|特殊诊疗限价|门诊费用类别（检查费、床位费等）| 住院费用类别（检查费、床位费等）|XX
        private string _fydj;
        private string _mzzfbl;
        private string _zyzfbl;
        private string _tszlbz;
        private string _tszlxj;
        private string _mzfylb;
        private string _zyfylb;
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
        /// 特殊诊疗标志
        /// </summary>
        public string Tszlbz
        {
            set { _tszlbz = value; }
            get { return _tszlbz; }
        }
        /// <summary>
        /// 特殊诊疗限价
        /// </summary>
        public string Tszlxj
        {
            set { _tszlxj = value; }
            get { return _tszlxj; }
        }
        /// <summary>
        /// 门诊费用类别
        /// </summary>
        public string Mzfylb
        {
            set { _mzfylb = value; }
            get { return _mzfylb; }
        }
        /// <summary>
        /// 住院费用类别
        /// </summary>
        public string Zyfylb
        {
            set { _zyfylb = value; }
            get { return _zyfylb; }
        }
        public string Message
        {
            set { _message = value; }
            get { return _message; }
        }
    }
}
