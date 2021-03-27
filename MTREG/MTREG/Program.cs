using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MTHIS.common;
using Bend.Util;
using MTREG.medinsur.hdyb;
using MTHIS.tools;
using MTREG.medinsur.sjzsyb;

namespace MTHIS
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string[] mainArgs = null;
            #region web调用参数处理
            try
            {
                if (args.Length > 0)
                {
                    string[] fromtArgs = args[0].Replace("myprotocol://type", "").Replace("/", "").Split('&');
                    if (fromtArgs.Length == 2)
                    {
                        mainArgs = fromtArgs;
                    }
                    else
                    {
                        LogUtils.writeNorLog("启动参数长度2：" + args.Length + " 值：" + args[0]);
                    }
                }
                else
                {
                    LogUtils.writeNorLog("没收到参数");
                }

            }
            catch (Exception ex)
            {
                LogUtils.writeErrLog("执行错误" + ex);
            }
            #endregion

            GlobalParams.getConfig();
            GlobalParams.startHttpServer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin(mainArgs));
            //Application.Run(new FrmFpdysz());

        }
    }
}
