using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ynsyb.bo
{
    class Czjy_in
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
        private string bczjylsh;
        /// <summary>
        /// //被冲正交易流水号
        /// </summary>
        public string Bczjylsh
        {
            get { return bczjylsh; }
            set { bczjylsh = value; }
        }
        private string bczjylxdm;
        /// <summary>
        /// //被冲正交易类型代码
        /// </summary>
        public string Bczjylxdm
        {
            get { return bczjylxdm; }
            set { bczjylxdm = value; }
        }
        private string czy;
        /// <summary>
        /// //操作员
        /// </summary>
        public string Czy
        {
            get { return czy; }
            set { czy = value; }
        }
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }
    }
}
