using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ynsyb.bo
{
    class Jszh_in
    {
        private string jylbdm;
        /// <summary>
        /// //交易类别代码
        /// </summary>
        public string Jylbdm
        {
            get { return jylbdm; }
            set { jylbdm = value; }
        }
        private string grbh;
        /// <summary>
        /// //个人编号
        /// </summary>
        public string Grbh
        {
            get { return grbh; }
            set { grbh = value; }
        }
        private string ddbh;
        /// <summary>
        /// //定点编号
        /// </summary>
        public string Ddbh
        {
            get { return ddbh; }
            set { ddbh = value; }
        }
        private string jylsh;
        /// <summary>
        /// //交易流水号（结算ID)
        /// </summary>
        public string Jylsh
        {
            get { return jylsh; }
            set { jylsh = value; }
        }
        private string fph;
        /// <summary>
        /// //发票号
        /// </summary>
        public string Fph
        {
            get { return fph; }
            set { fph = value; }
        }
        private string jbr;
        /// <summary>
        /// //经办人
        /// </summary>
        public string Jbr
        {
            get { return jbr; }
            set { jbr = value; }
        }
    }
}
