using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MTHIS.tools
{
    public class FileUtils
    {
        /// <summary>
        /// 将byte输出到指定文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static bool CreateFileByBytes(string filePath, byte[] buffer)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(filePath);
                if (!Directory.Exists(fileInfo.Directory.FullName))
                    Directory.CreateDirectory(fileInfo.Directory.FullName);
                File.WriteAllBytes(filePath, buffer);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 将指定文件读成byte数组
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static byte[] FileToBytes(string filepath)
        {
            FileStream fs = new FileStream(filepath, FileMode.Open);
            byte[] fileBytes = null;
            try
            {
                fileBytes = new byte[fs.Length];
                fs.Read(fileBytes, 0, (int)fs.Length);
                fs.Close();
            }
            catch (Exception ex)
            {
                fs.Close();
            }
            return fileBytes;
        }
    }
}
