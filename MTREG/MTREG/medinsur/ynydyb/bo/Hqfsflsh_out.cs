using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ynydyb.bo
{
    public class Hqfsflsh_out
    {
        private string swqjwyzym;
        /// <summary>
        /// 事务全局唯一资源码
        /// </summary>
        public string Swqjwyzym
        {
            get { return swqjwyzym; }
            set { swqjwyzym = value; }
        }
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }
    }
}
