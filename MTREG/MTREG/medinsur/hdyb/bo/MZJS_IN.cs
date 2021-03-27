using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdyb.bo
{
    class Mzjs_in
    {
        private string _grbh;
        private string _mzzyh;
        private string _yllb;
        private string _djh;
        private string _jbr;
        private string _zffs;
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
        /// 单据号
        /// </summary>
        public string Djh
        {
            set { _djh = value; }
            get { return _djh; }
        }
        /// <summary>
        /// 经办人
        /// </summary>
        public string Jbr
        {
            set { _jbr = value; }
            get { return _jbr; }
        }
        /// <summary>
        /// 医疗类别
        /// </summary>
        public string Yllb
        {
            set { _yllb = value; }
            get { return _yllb; }
        }
        /// <summary>
        /// 支付方式
        /// </summary>
        public string Zffs
        {
            set { _zffs = value; }
            get { return _zffs; }
        }
    }
}
