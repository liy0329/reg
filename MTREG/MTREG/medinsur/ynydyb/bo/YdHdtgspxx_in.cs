using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ynydyb.bo
{
    public class YdHdtgspxx_in
    {
        private string cbdtcqbh;
        /// <summary>
        /// 参保地统筹区编号
        /// </summary>
        public string Cbdtcqbh
        {
            get { return cbdtcqbh; }
            set { cbdtcqbh = value; }
        }
        private string hzgrbh;
        /// <summary>
        /// 患者个人编号
        /// </summary>
        public string Hzgrbh
        {
            get { return hzgrbh; }
            set { hzgrbh = value; }
        }
        private string splbdbm;
        /// <summary>
        /// 审批类别的编码
        /// </summary>
        public string Splbdbm
        {
            get { return splbdbm; }
            set { splbdbm = value; }
        }
    }
}
