using System.Runtime.InteropServices;
using System.Text;
using System.IO;
using System.Collections;
using System.Windows.Forms;

namespace MTHIS.tools
{
    class IniUtils
    {
        public static string inidir = Application.StartupPath;          // + "\\config";

        //public static string devconfig = inidir + "\\devconfig.ini";  //文件路径
        public static string dbpath = inidir + "\\dbconfig.ini";        //文件路径
        public static string syspath = inidir + "\\sysconfig.ini";      //文件路径
        /*
        static IniUtils()
        {
            if (!Directory.Exists(inidir))
                Directory.CreateDirectory(inidir);
            //if (!File.Exists(devconfig))
            //    File.Create(devconfig).Close();
            if (!File.Exists(dbpath))
                File.Create(dbpath).Close();
            if (!File.Exists(syspath))
                File.Create(syspath).Close();
        }
        */
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

        public static bool ExistINIFile()
        {
            return File.Exists(syspath);
        }
        /// <summary>
        /// 读取所有的section
        /// </summary>
        /// <returns>section集合</returns>
        public static ArrayList readSections(string inipath)
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

    }
}

