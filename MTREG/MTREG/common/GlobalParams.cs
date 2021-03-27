using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bend.Util;
using System.Threading;


namespace MTHIS.common
{
    class GlobalParams
    {
        public static string dbpath = Application.StartupPath + "\\dbconfig.ini";
        public static string syspath = Application.StartupPath + "\\sysconfig.ini";

        public static string reportDir = Application.StartupPath + "\\report";
        public static string reportBlankImgPath = Application.StartupPath + "\\report\\blank.bmp";

        public static string esignDir = Application.StartupPath + "\\esign";

        public static SysConfig sysConfig;
        public static Thread thread;
        public static void getConfig()
        {
            sysConfig = SysConfig.getSysConfig();
        }
        public static void startHttpServer()
        {
            string port = SysConfig.readHttpServerPort();
            HttpServer httpServer;
            httpServer = new MyHttpServer(int.Parse(  port));
            thread= new Thread(new ThreadStart(httpServer.listen));
            thread.Start();
        }
        public static void stopHttpServer()
        {
            thread.Abort();
        }
    }
}
