using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ynsyb.bo
{
    class Cfmxtf_in
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
        /// //交易流水号（处方ID）
        /// </summary>
        public string Jylsh
        {
            get { return jylsh; }
            set { jylsh = value; }
        }
        private string tcsl;
        /// <summary>
        /// //退除数量
        /// </summary>
        public string Tcsl
        {
            get { return tcsl; }
            set { tcsl = value; }
        }
        private string tcje;
        /// <summary>
        /// //退除金额
        /// </summary>
        public string Tcje
        {
            get { return tcje; }
            set { tcje = value; }
        }
    }
}
