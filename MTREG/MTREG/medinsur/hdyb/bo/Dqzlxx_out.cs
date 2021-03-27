using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdyb.bo
{
    class Dqzlxx_out
    {
        //费用等级（甲类或乙类或丙类）|门诊自付比例 | 住院自付比例 |最高限价 | 限价标志 | 特殊诊疗标志|特殊诊疗限价|门诊费用类别（检查费、床位费等）| 住院费用类别（检查费、床位费等）|体内置换材料标志|XX
        private string _fydj;
        private string _mzzfbl;
        private string _zyzfbl;
        private string _zgxj;
        private string _xjbz;
        private string _tszlbz;
        private string _tszlxj;
        private string _mzfylb;
        private string _zyfylb;
        private string _tnzhclbz;
        private string _message;
        /// <summary>
        /// 费用等级（甲类或乙类或丙类）
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
        /// 最高限价
        /// </summary>
        public string Zgxj
        {
            set { _zgxj = value; }
            get { return _zgxj; }
        }
        /// <summary>
        /// 限价标志
        /// </summary>
        public string Xjbz
        {
            set { _xjbz = value; }
            get { return _xjbz; }
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
        /// 门诊费用类别（检查费、床位费等）
        /// </summary>
        public string Mzfylb
        {
            set { _mzfylb = value; }
            get { return _mzfylb; }
        }
        /// <summary>
        /// 住院费用类别（检查费、床位费等）
        /// </summary>
        public string Zyfylb
        {
            set { _zyfylb = value; }
            get { return _zyfylb; }
        }
        /// <summary>
        /// 体内置换材料标志
        /// </summary>
        public string Tnzhclbz
        {
            set { _tnzhclbz = value; }
            get { return _tnzhclbz; }
        }
        public string Message
        {
            set { _message = value; }
            get { return _message; }
        }
    }
}
