using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTREG.medinsur.gzsyb.bll;

namespace MTREG.medinsur.gzsyb.bo
{
    public static class GzsGlobal
    {
        private static GzsybInterface gzsyb;
        /// <summary>
        /// 医院名称
        /// </summary>
        internal static GzsybInterface Gzsyb
        {
            get { return GzsGlobal.gzsyb; }
            set { GzsGlobal.gzsyb = value; }
        }
    }
}
