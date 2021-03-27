/*************************************************************************************
     * CLR版本：        2.0.50727.4927
     * 类 名 称：       Ini
     * 机器名称：       AARON-PC
     * 命名空间：       MTLIS.db
     * 文 件 名：       Ini
     * 创建时间：       2013/5/16 14:43:37
     * 作    者：       田非
     * 说   明：        操作ini工具类
     * 修改时间：
     * 修 改 人：
*************************************************************************************/
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Windows.Forms;

namespace MTHIS.db
{
    class Ini
    {
        public static string inipath = Application.StartupPath + "\\dbconfig.ini";   //文件路径
        public static string dbpath = Application.StartupPath + "\\dbconfig.ini";   //文件路径
        public static string syspath = Application.StartupPath + "\\sysconfig.ini";   //文件路径

        private static string dbStr;

        public static string DbStr
        {
            get { return Ini.dbStr; }
            set { Ini.dbStr = value; }
        }

        /// <summary>
        /// 参数说明：section：INI文件中的段落；key：INI文件中的关键字；val：INI文件中关键字的数值；filePath：INI文件的完整的路径和名称。 
        /// </summary>
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        /// <summary>
        /// 参数说明：section：INI文件中的段落名称；key：INI文件中的关键字；def：无法读取时候时候的缺省数值；retVal：读取数值；size：数值的大小；filePath：INI文件的完整路径和名称。
        /// </summary>
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        /// <summary>
        /// 判断一个ini文件中有多少个节
        /// </summary>
        /// <param name="lpszReturnBuffer">指向一个缓冲区，用来保存返回的所有节名</param>
        /// <param name="nSize">参数lpszReturnBuffer的大小</param>
        /// <param name="lpFileName">文件名，若该ini文件与程序在同一个目录下</param>
        /// <returns>复制的字节数</returns>
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileSectionNamesA(byte[] lpszReturnBuffer, int nSize, string lpFileName);

        /// <summary> 
        /// 构造方法 
        /// </summary> 
        /// <param name="INIPath">文件路径</param> 
        public static void INIClass(string INIPath)
        {
            inipath = INIPath;
        }


        /// <summary> 
        /// 写入INI文件 
        /// </summary> 
        /// <param name="Section">项目名称(如 [TypeName] )</param> 
        /// <param name="Key">键</param> 
        /// <param name="Value">值</param> 
        public static void IniWriteValue(string inipath, string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, inipath);
        }
        /// <summary> 
        /// 写入INI文件 
        /// </summary> 
        /// <param name="Section">项目名称(如 [TypeName] )</param> 
        /// <param name="Key">键</param> 
        /// <param name="Value">值</param> 
        public static void IniWriteValue(string Section, string Key, string Value)
        {
            IniWriteValue(inipath, Section, Key, Value);
        }

        /// <summary> 
        /// 读出INI文件 
        /// </summary> 
        /// <param name="Section">项目名称(如 [TypeName] )</param> 
        /// <param name="Key">键</param> 
        public static string IniReadValue(string inipath, string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(500);
            int i = GetPrivateProfileString(Section, Key, "", temp, 500, inipath);
            return temp.ToString();
        }

        /// <summary> 
        /// 读出INI文件 
        /// </summary> 
        /// <param name="Section">项目名称(如 [TypeName] )</param> 
        /// <param name="Key">键</param> 
        public static string IniReadValue(string Section, string Key)
        {
            return IniReadValue(inipath, Section, Key);
        }
        /// <summary> 
        /// 读出INI文件 
        /// </summary> 
        /// <param name="Section">项目名称(如 [TypeName] )</param> 
        /// <param name="Key">键</param> 
        public static string IniReadValue2(string Section, string Key)
        {
            return IniReadValue(syspath, Section, Key);
        }
        /// <summary> 
        /// 验证文件是否存在 
        /// </summary> 
        /// <returns>布尔值</returns> 
        public static bool ExistINIFile()
        {
            return File.Exists(inipath);
        }

        /// <summary>
        /// 读取所有的section
        /// </summary>
        /// <returns>section集合</returns>
        public static ArrayList readSections()
        {
            byte[] buffer = new byte[65535];
            int rel = GetPrivateProfileSectionNamesA(buffer, buffer.GetUpperBound(0), inipath);
            int iCnt, iPos;
            ArrayList arrayList = new ArrayList();
            string tmp;
            if (rel > 0)
            {
                iCnt = 0; iPos = 0;
                for (iCnt = 0; iCnt < rel; iCnt++)
                {
                    if (buffer[iCnt] == 0x00)
                    {
                        tmp = System.Text.ASCIIEncoding.Default.GetString(buffer, iPos, iCnt - iPos).Trim();
                        iPos = iCnt + 1;
                        if (tmp != "")
                            arrayList.Add(tmp);
                    }
                }
            }
            return arrayList;
        }



        /// <summary>
        /// 删除指定区域。
        /// </summary>
        /// <param name="Section">指定区域名。</param>
        /// <returns>返回删除是否成功。</returns>
        public static void EraseSection(string Section)
        {
            WritePrivateProfileString(Section, null, null, inipath);
        }


        /// <summary>
        /// 读取区域变量名列表。
        /// </summary>
        /// <param name="Section">指定区域名。</param>
        /// <param name="Strings">指定输出列表。</param>
        /// <returns>返回获取是否成功。</returns>
        //public static bool ReadSection(string Section, List<string> Strings)
        //{
        //    StringBuilder temp = new StringBuilder(500);
        //    int length = GetPrivateProfileString(Section, null, null, temp, temp.Length, inipath);
        //    int j = 0;
        //    for (int i = 0; i < length; i++)
        //        if (temp[i] == 0)
        //        {
        //            Strings.Add();
        //            j = i + 1;
        //        }
        //    return true;
        //}



    }
}

