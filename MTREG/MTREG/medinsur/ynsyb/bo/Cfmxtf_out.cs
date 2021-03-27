using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ynsyb.bo
{
    class Cfmxtf_out
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
        private string xmbm;
        /// <summary>
        /// //项目编码
        /// </summary>
        public string Xmbm
        {
            get { return xmbm; }
            set { xmbm = value; }
        }
        private string sysl;
        /// <summary>
        /// //剩余数量
        /// </summary>
        public string Sysl
        {
            get { return sysl; }
            set { sysl = value; }
        }
        private string syje;
        /// <summary>
        /// //剩余金额
        /// </summary>
        public string Syje
        {
            get { return syje; }
            set { syje = value; }
        }
        private string syzl;
        //剩余自理
        public string Syzl
        {
            get { return syzl; }
            set { syzl = value; }
        }
        private string syzf;
        /// <summary>
        /// //剩余自费
        /// </summary>
        public string Syzf
        {
            get { return syzf; }
            set { syzf = value; }
        }
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }
    }
}
