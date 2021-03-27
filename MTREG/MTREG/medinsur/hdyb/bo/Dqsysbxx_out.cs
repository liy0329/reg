using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdyb.bo
{
    class Dqsysbxx_out
    {
        //生育流水号|经办时间|审批状态|XX
        private string _sylsh;
        private string _jbsj;
        private string _spzt;
        private string _message;
        /// <summary>
        /// 生育流水号
        /// </summary>
        public string Sylsh
        {
            set { _sylsh = value; }
            get { return _sylsh; }
        }
        /// <summary>
        /// 经办时间
        /// </summary>
        public string Jbsj
        {
            set { _jbsj = value; }
            get { return _jbsj; }
        }
        /// <summary>
        /// 审批状态
        /// </summary>
        public string Spzt
        {
            set { _spzt = value; }
            get { return _spzt; }
        }
        public string Message
        {
            set { _message = value; }
            get { return _message; }
        }
    }
}
