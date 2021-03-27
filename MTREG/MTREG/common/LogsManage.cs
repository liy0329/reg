/*************************************************************************************
     * CLR版本：        2.0.50727.4927
     * 类 名 称：       LogsManage
     * 机器名称：       TIANCI
     * 命名空间：       MTLIS.common
     * 文 件 名：       LogsManage
     * 创建时间：       2013/5/13 14:43:37
     * 作    者：       杨天赐
     * 说   明：        管理日志
     * 修改时间：        
     * 修 改 人：        
*************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace MTHIS.common
{


    public class LogsManage
    {
        /*
         * 输入:
           输出:
         * 返回值: 
        */
       public static void  WriteLogs(Logs logs)
        {

        }

       static string errPath_P = Application.StartupPath + "\\log\\";
       /// <summary>
       /// 写日志
       /// </summary>
       /// <param name="path">路径</param>
       /// <param name="info">信息</param>
       static public void writeError(String info)
       {
           lock (errPath_P)
           {
               string errPath_F = DateTime.Now.ToString("yyyy-MM-dd") + "_MTAPP_ERR.log";
               DirectoryInfo dti = new DirectoryInfo(errPath_P);
               if (!dti.Exists)
               {
                   dti.Create();
               }
               string errPath = errPath_P + errPath_F;
               using (StreamWriter sw = new StreamWriter(errPath, true, Encoding.UTF8))
               {
                   sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + info);
                   sw.Close();
               }
           }
       }
       
    }
}
