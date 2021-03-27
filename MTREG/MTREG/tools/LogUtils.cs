using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace MTHIS.tools
{
    class LogUtils
    {
        private static String logDir = Application.StartupPath + "\\log";

        static LogUtils()
        {
            if (!Directory.Exists(logDir))
                Directory.CreateDirectory(logDir);
        }
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="info">信息</param>
        public static void writeLog(String path, String info)
        {
            lock ("LogUtils")
            {
                
                if (!File.Exists(path))
                    File.Create(path).Close();
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + info);
                }
            }
        }
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="info">信息</param>
        public static void writeFileLog(String filename, String info)
        {
            lock ("LogUtils")
            {
                String path = logDir + "\\" + filename;
                if (!File.Exists(path))
                    File.Create(path).Close();
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + info);
                }
            }
        }
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="info">信息</param>
        public static void writeLog(String path, String info, Exception e)
        {
            lock ("writeLog")
            {
                if (!File.Exists(path))
                    File.Create(path).Close();
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + info + "\r\n" + e.Message + "\r\n");
                }
            }
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="info">信息</param>
        public static void writeNorLog(String info)
        {
             String logPath = logDir + "\\log_" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
             writeLog(logPath, info);
        }
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="info">信息</param>
        public static void writeErrLog(String info)
        {
            String logPath = logDir + "\\err_" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
            writeLog(logPath, info);
        }
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="info">信息</param>
        public static void writeErrLog(String info, Exception e)
        {
             String logPath = logDir + "\\err_" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
             writeLog(logPath, info, e);
        }
    }
}
