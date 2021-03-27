using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace MTREG.medinsur.hdsbhnh.bll
{
    class SysWriteLogs
    {
        public void writeLogs(string fileType, DateTime dateTime, string outErr)
        {
            //创建文件夹
            string strPath = System.Environment.CurrentDirectory + "\\logs";
            //如果源文件夹不存在，则创建
            if (!Directory.Exists(strPath))
            {
                Directory.CreateDirectory(strPath);
            }

            //创建文件
            string filePath = strPath + getFileName(fileType);
            FileInfo finfo = new FileInfo(filePath);

            FileStream fs = finfo.OpenWrite(); //文件流 
            StreamWriter w = new StreamWriter(fs);//写数据流 
            w.BaseStream.Seek(0, SeekOrigin.End);//写数据流的起始位置为文件流的末尾   
            w.Write(dateTime + ":" + outErr + "\r\n"); //写入日志内容并换行 

            w.Flush(); //清空缓冲区内容 
            w.Close();//关闭写数据流 
        }


        //得到文件名
        public string getFileName(string type)
        {
            string dateStr = DateTime.Now.ToString("yyyyMMdd");
            string fileName = "\\" + dateStr + type + ".txt";
            return fileName;
        }

        public static void SleepTimes(int millisecondsTimeout)
        {
            try
            {
                Thread.Sleep(millisecondsTimeout);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
