using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ynsyb.bo
{
    class Yjs_in
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
        /// //交易流水号
        /// </summary>
        public string Jylsh
        {
            get { return jylsh; }
            set { jylsh = value; }
        }
        private string cfjzsj;
        /// <summary>
        /// //处方截止时间
        /// </summary>
        public string Cfjzsj
        {
            get { return cfjzsj; }
            set { cfjzsj = value; }
        }
        private string kzfje;
        /// <summary>
        /// //卡支付金额
        /// </summary>
        public string Kzfje
        {
            get { return kzfje; }
            set { kzfje = value; }
        }
        private string qfxzfje;
        /// <summary>
        /// //起付线支付金额
        /// </summary>
        public string Qfxzfje
        {
            get { return qfxzfje; }
            set { qfxzfje = value; }
        }
    }
}
