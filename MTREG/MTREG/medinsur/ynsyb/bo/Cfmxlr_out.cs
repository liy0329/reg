using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ynsyb.bo
{
    class Cfmxlr_out
    {
        private string jylsh;
        /// <summary>
        /// //交易流水号（处方ID）
        /// </summary>
        public string Jylsh
        {
            get { return jylsh; }
            set { jylsh = value; }
        }
        private string sjdj;
        /// <summary>
        /// //实际单价
        /// </summary>
        public string Sjdj
        {
            get { return sjdj; }
            set { sjdj = value; }
        }
        private string xmdj;
        /// <summary>
        /// //项目等级
        /// </summary>
        public string Xmdj
        {
            get { return xmdj; }
            set { xmdj = value; }
        }
        private string sph;
        /// <summary>
        /// //审批号
        /// </summary>
        public string Sph
        {
            get { return sph; }
            set { sph = value; }
        }
        private string zlfy;
        /// <summary>
        /// //自理费用
        /// </summary>
        public string Zlfy
        {
            get { return zlfy; }
            set { zlfy = value; }
        }
        private string zffy;
        /// <summary>
        /// //自费费用
        /// </summary>
        public string Zffy
        {
            get { return zffy; }
            set { zffy = value; }
        }
        private string cfje;
        /// <summary>
        /// //处方金额
        /// </summary>
        public string Cfje
        {
            get { return cfje; }
            set { cfje = value; }
        }
        private string znshydxx;
        /// <summary>
        /// //智能审核疑点信息
        /// </summary>
        public string Znshydxx
        {
            get { return znshydxx; }
            set { znshydxx = value; }
        }
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }
    }
}
