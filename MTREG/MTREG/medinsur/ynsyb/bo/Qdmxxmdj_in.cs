using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ynsyb.bo
{
    class Qdmxxmdj_in
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
        private string ybbh;
        /// <summary>
        /// //医保编号
        /// </summary>
        public string Ybbh
        {
            get { return ybbh; }
            set { ybbh = value; }
        }
        private string fylb;
        /// <summary>
        /// //费用类别
        /// </summary>
        public string Fylb
        {
            get { return fylb; }
            set { fylb = value; }
        }
        private string yydj;
        /// <summary>
        /// //医院单价
        /// </summary>
        public string Yydj
        {
            get { return yydj; }
            set { yydj = value; }
        }
    }
}
