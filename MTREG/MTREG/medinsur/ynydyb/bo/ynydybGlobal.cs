using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ynydyb.bo
{
    public static class ynydybGlobal
    {
        private static string signtime;
        /// <summary>
        /// 签到时间
        /// </summary>
        public static string Signtime
        {
            get { return signtime; }
            set { signtime = value; }
        }
        private static string signOuttime;
        /// <summary>
        /// 签退时间
        /// </summary>
        public static string SignOuttime
        {
            get { return signOuttime; }
            set { signOuttime = value; }
        }
        private static string ywzqh;
        /// <summary>
        /// 业务周期号
        /// </summary>
        public static string Ywzqh
        {
            get { return ywzqh; }
            set { ywzqh = value; }
        }
    }
}
