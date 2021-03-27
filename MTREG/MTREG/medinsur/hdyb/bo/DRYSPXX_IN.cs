using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdyb.bo
{
    class Dryspxx_in
    {
        //个人编号|审批类别|疾病编码
        private string _grbh;
        private string _splb;
        private string _jbbm;
        /// <summary>
        /// 个人编号
        /// </summary>
        public string Grbh
        {
            set { _grbh = value; }
            get { return _grbh; }
        }
        /// <summary>
        /// 审批类别
        /// </summary>
        public string Splb
        {
            set { _splb = value; }
            get { return _splb; }
        }
        /// <summary>
        /// 疾病编码
        /// </summary>
        public string Jbbm
        {
            set { _jbbm = value; }
            get { return _jbbm; }
        }
    }
}
