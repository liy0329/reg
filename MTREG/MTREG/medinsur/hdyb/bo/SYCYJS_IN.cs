using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdyb.bo
{
    class Sycyjs_in
    {
        //个人编号|门诊住院号|手术类别|医疗费总额|胎儿数 |经办人
        private string _grbh;
        private string _mzzyh;
        private string _sslb;
        private string _ylfze;
        private string _tes;
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
        /// 手术类别
        /// </summary>
        public string Sslb
        {
            set { _sslb = value; }
            get { return _sslb; }
        }
        /// <summary>
        /// 医疗费总额
        /// </summary>
        public string Ylfze
        {
            set { _ylfze = value; }
            get { return _ylfze; }
        }
        /// <summary>
        /// 胎儿数
        /// </summary>
        public string Tes
        {
            set { _tes = value; }
            get { return _tes; }
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
