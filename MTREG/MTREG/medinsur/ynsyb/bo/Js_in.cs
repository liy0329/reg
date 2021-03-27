using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ynsyb.bo
{
    class Js_in
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
        /// //交易流水号（登记ID)
        /// </summary>
        public string Jylsh
        {
            get { return jylsh; }
            set { jylsh = value; }
        }
        private string cfjzsj;
        /// <summary>
        /// //处方截止时间 (中途结算适用)
        /// </summary>
        public string Cfjzsj
        {
            get { return cfjzsj; }
            set { cfjzsj = value; }
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
        private string jslx;
        /// <summary>
        /// //结算类型
        /// </summary>
        public string Jslx
        {
            get { return jslx; }
            set { jslx = value; }
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
