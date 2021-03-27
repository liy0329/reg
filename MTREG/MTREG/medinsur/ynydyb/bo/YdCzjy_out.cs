using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ynydyb.bo
{
    public class YdCzjy_out
    {
        private string czzt;
        /// <summary>
        /// 冲正状态
        /// </summary>
        public string Czzt
        {
            get { return czzt; }
            set { czzt = value; }
        }

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }
    }
}
