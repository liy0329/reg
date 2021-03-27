using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTHIS.tools;

namespace MTREG.medinsur.gzsnh.bo
{
    public static class GzsnhGlobal
    {
        //农合登录信息
        private static string userName;//用户名

        public static string UserName
        {
            get { return GzsnhGlobal.userName; }
            set { GzsnhGlobal.userName = value; }
        }

        private static string userPwd;//密码

        public static string UserPwd
        {
            get { return GzsnhGlobal.userPwd; }
            set { GzsnhGlobal.userPwd = value; }
        }
        private static string centerNo;//农合中心编码

        public static string CenterNo
        {
            get { return GzsnhGlobal.centerNo; }
            set { GzsnhGlobal.centerNo = value; }
        }
        private static string hospCode;//医疗机构编码

        public static string HospCode
        {
            get { return GzsnhGlobal.hospCode; }
            set { GzsnhGlobal.hospCode = value; }
        }
        private static string url;//地址

        public static string Url
        {
            get { return GzsnhGlobal.url; }
            set { GzsnhGlobal.url = value; }
        }
    }
}
