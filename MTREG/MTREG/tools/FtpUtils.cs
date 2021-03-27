using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace MTHIS.tools
{
    class FtpUtils
    {
        /// <summary>
        /// ftp方式上传   
        /// </summary>
        /// <param name="fileDir">本机文件路径</param>
        /// <param name="fileName">文件名称</param>
        /// <param name="ftpAddr">服务器地址</param>
        /// <param name="ftpUserID">账号</param>
        /// <param name="ftpPassword">密码</param>
        /// <returns></returns>
        public static int UploadFtp(string fileDir, string fileName, string ftpIpAddr, string ftpUserID, string ftpPassword)
        {
            fileDir = fileDir.TrimEnd('\\');
            ftpIpAddr = ftpIpAddr.Replace("ftp://", "").TrimEnd('/');
            string[] ftppaths = ftpIpAddr.Split('/');
            string ftppath = "";
            for (int i = 0; i < ftppaths.Length; i++)
            {
                ftppath += ftppaths[i] + "/";
                judgeCreateFtpDir(ftppath, ftpUserID, ftpPassword);
            }

            String localFilePath = fileDir + "\\" + fileName;
            FileInfo fileInf = new FileInfo(localFilePath);

            string uri = "ftp://" + ftpIpAddr + "/" + fileInf.Name;
            FtpWebRequest reqFTP;
            // Create FtpWebRequest object from the Uri provided 
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpIpAddr + "/" + fileInf.Name));
            try
            {
                // Provide the WebPermission Credintials
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                // By default KeepAlive is true, where the control connection is not closed
                // after a command is executed.
                reqFTP.KeepAlive = false;
                // Specify the command to be executed.
                reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
                // Specify the data transfer type.
                reqFTP.UseBinary = true;
                // Notify the server about the size of the uploaded file
                reqFTP.ContentLength = fileInf.Length;
                // The buffer size is set to 2kb
                int buffLength = 2048;
                byte[] buff = new byte[buffLength];
                int contentLen;
                // Opens a file stream (System.IO.FileStream) to read the file to be uploaded
                //FileStream fs = fileInf.OpenRead();
                FileStream fs = fileInf.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                // Stream to which the file to be upload is written
                Stream strm = reqFTP.GetRequestStream();
                // Read from the file stream 2kb at a time
                contentLen = fs.Read(buff, 0, buffLength);
                // Till Stream content ends
                while (contentLen != 0)
                {
                    // Write Content from the file stream to the FTP Upload Stream
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }
                // Close the file stream and the Request Stream
                strm.Close();
                fs.Close();
                return 0;
            }
            catch (Exception e)
            {
                LogUtils.writeErrLog("上传失败", e);
                return -2;
            }
            finally
            {
                if (reqFTP != null)
                    reqFTP.Abort();
            }
        }
        /// <summary>        
        /// ftp方式下载         
        /// </summary>        
        public static int DownloadFtp(string fileDir, string fileName, string ftpIpAddr, string ftpUserID, string ftpPassword)
        {
            fileDir = fileDir.TrimEnd('\\');
            ftpIpAddr = ftpIpAddr.Replace("ftp://", "");

            if (!Directory.Exists(fileDir))
                Directory.CreateDirectory(fileDir);

            String localFilePath = fileDir + "\\" + fileName;
            String ftpFileUri = "ftp://" + ftpIpAddr + "/" + fileName;

            FtpWebRequest reqFTP;
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpFileUri));
            try
            {
                //filePath = < <The full path where the file is to be created.>>,
                //fileName = < <Name of the file to be created(Need not be the name of the file on FTP server).>>

                FileStream outputStream = new FileStream(localFilePath, FileMode.Create);
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.KeepAlive = false;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];
                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }
                ftpStream.Close();
                outputStream.Close();
                response.Close();
                return 0;
            }
            catch (Exception e)
            {
                LogUtils.writeErrLog("下载失败", e);
                return -2;
            }
            finally
            {
                if (reqFTP != null)
                    reqFTP.Abort();
            }
        }


        /// <summary>
        /// 检测目录是否存在
        /// </summary>
        /// <param name="pFtpServerIP"></param>
        /// <param name="pFtpUserID"></param>
        /// <param name="pFtpPW"></param>
        /// <returns>false不存在，true存在</returns>
        public static bool DirectoryIsExist(Uri pFtpServerIP, string pFtpUserID, string pFtpPW)
        {
            string[] value = GetFileList(pFtpServerIP, pFtpUserID, pFtpPW);
            if (value == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 获得制定FTP目录下的文件列表
        /// </summary>
        /// <param name="pFtpServerIP"></param>
        /// <param name="pFtpUserID"></param>
        /// <param name="pFtpPW"></param>
        /// <returns></returns>
        public static string[] GetFileList(Uri pFtpServerIP, string pFtpUserID, string pFtpPW)
        {
            StringBuilder result = new StringBuilder();
            try
            {
                FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(pFtpServerIP);
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(pFtpUserID, pFtpPW);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                reader.Close();
                response.Close();
                return result.ToString().Split('\n');
            }
            catch (Exception e)
            {
                LogUtils.writeErrLog("文件列表获取失败", e);
                return null;
            }
        }

        /// <summary>
        /// 判断FTP目录是否存在，不存在则创建
        /// </summary>
        /// <param name="ftppath"></param>
        /// <param name="ftpuser"></param>
        /// <param name="ftppass"></param>
        /// <returns></returns>
        public static bool judgeCreateFtpDir(string ftppath, string ftpuser, string ftppass)
        {
            Uri uri = new Uri("ftp://" + ftppath);
            if (!DirectoryIsExist(uri, ftpuser, ftppass))
            {
                if (CreateDirectory(uri, ftpuser, ftppass))
                {
                    //目录是否存在
                    if (!DirectoryIsExist(uri, ftpuser, ftppass))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// ftp创建目录(创建文件夹)
        /// </summary>
        /// <param name="IP">IP服务地址</param>
        /// <param name="UserName">登陆账号</param>
        /// <param name="UserPass">密码</param>
        /// <param name="FileSource"></param>
        /// <param name="FileCategory"></param>
        /// <returns></returns>
        public static bool CreateDirectory(Uri IP, string UserName, string UserPass)
        {
            try
            {
                FtpWebRequest FTP = (FtpWebRequest)FtpWebRequest.Create(IP);
                FTP.Credentials = new NetworkCredential(UserName, UserPass);
                FTP.Proxy = null;
                FTP.KeepAlive = false;
                FTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                FTP.UseBinary = true;
                FtpWebResponse response = FTP.GetResponse() as FtpWebResponse;
                response.Close();
                return true;
            }
            catch (Exception e)
            {
                LogUtils.writeErrLog("FTP创建目录失败", e);
                return false;
            }
        }

    }
}
