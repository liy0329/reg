using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdyb.bo
{
    class Dqypxx_out
    {
        //费用等级（甲类或乙类或丙类）|门诊自付比例|住院自付比例|药品最高限价（如果为0或空，则表示没有限价） |费用类别（西药、中草药等）|限制性用药标志|限制性用药说明|
        private string _fydj;
        private string _mzzfbl;
        private string _zyzfbl;
        private string _ypzgxj;
        private string _fylb;
        private string _xzxyybz;
        private string _xzxyysm;
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
        /// 药品最高限价（如果为0或空，则表示没有限价）
        /// </summary>
        public string Ypzgxj
        {
            set { _ypzgxj = value; }
            get { return _ypzgxj; }
        }
        /// <summary>
        /// 限制性用药标志
        /// </summary>
        public string Xzxyybz
        {
            set { _xzxyybz = value; }
            get { return _xzxyybz; }
        }
        /// <summary>
        /// 费用类别（西药、中草药等）
        /// </summary>
        public string Fylb
        {
            set { _fylb = value; }
            get { return _fylb; }
        }
        /// <summary>
        /// 限制性用药说明
        /// </summary>
        public string Xzxyysm
        {
            set { _xzxyysm = value; }
            get { return _xzxyysm; }
        }
        public string Message
        {
            set { _message = value; }
            get { return _message; }
        }
    }
}
