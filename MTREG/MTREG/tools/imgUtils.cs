using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using MTHIS.common;
using System.Windows.Forms;

namespace MTHIS.tools
{
    public static class imgUtils
    {
        /// <summary>
        /// 按相对路径下载文件,已存在则不下载
        /// </summary>
        /// <param name="relPath"></param>
        public static void downloadImgByRelPath(string relPath)
        {
            string filePath = GlobalParams.sysConfig.CheckImgDir + "\\" + relPath;
            if (File.Exists(filePath))
                return;

            string fileRelDir = relPath.Substring(0, relPath.LastIndexOf('\\'));
            string fileName = relPath.Substring(relPath.LastIndexOf('\\') + 1);

            string ftpUrl = "";
            string ftpuser = "";
            string ftppass = "";

            string filedir = GlobalParams.sysConfig.CheckImgDir + '\\' + fileRelDir;
            string ftpUrlAll = ftpUrl + "/" + fileRelDir.Replace('\\', '/');

            FtpUtils.DownloadFtp(filedir, fileName, ftpUrlAll, ftpuser, ftppass);
        }

        /// <summary>
        /// 获取本地Image
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static Image getImage(string filepath)
        {
            string allFilePaht = Path.Combine(Application.StartupPath, filepath);
            return BytesToImage(FileUtils.FileToBytes(allFilePaht));
        }

        /// <summary>
        /// 将Image转为byte数组
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static byte[] ImageToBytes(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                #region 过时的
                //ImageFormat format = image.RawFormat;
                //if (format.Equals(ImageFormat.Jpeg))
                //{
                //    image.Save(ms, ImageFormat.Jpeg);
                //}
                //else if (format.Equals(ImageFormat.Png))
                //{
                //    image.Save(ms, ImageFormat.Png);
                //}
                //else if (format.Equals(ImageFormat.Bmp))
                //{
                //    image.Save(ms, ImageFormat.Bmp);
                //}
                //else if (format.Equals(ImageFormat.Gif))
                //{
                //    image.Save(ms, ImageFormat.Gif);
                //}
                //else if (format.Equals(ImageFormat.Icon))
                //{
                //    image.Save(ms, ImageFormat.Icon);
                //}
                #endregion
                byte[] buffer = new byte[ms.Length];
                //Image.Save()会改变MemoryStream的Position，需要重新Seek到Begin
                ms.Seek(0, SeekOrigin.Begin);
                ms.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }

        /// <summary>
        /// 将byte数组转为Image
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static Image BytesToImage(byte[] buffer)
        {
            MemoryStream ms = new MemoryStream(buffer);
            Image image = System.Drawing.Image.FromStream(ms);
            return image;
        }

        /// <summary>
        /// 将Image的byte数组输出到指定文件，后缀会自动改变为对应格式
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static string CreateImageFileByBytes(string filePath, byte[] buffer)
        {
            int length = filePath.LastIndexOf('.');
            if (length > 0)
                filePath = filePath.Substring(0, length);
            Image image = BytesToImage(buffer);
            filePath += "." + image.RawFormat.ToString();
            #region 过时的
            //ImageFormat format = image.RawFormat;
            //if (format.Equals(ImageFormat.Jpeg))
            //{
            //    file += ".jpeg";
            //}
            //else if (format.Equals(ImageFormat.Png))
            //{
            //    file += ".png";
            //}
            //else if (format.Equals(ImageFormat.Bmp))
            //{
            //    file += ".bmp";
            //}
            //else if (format.Equals(ImageFormat.Gif))
            //{
            //    file += ".gif";
            //}
            //else if (format.Equals(ImageFormat.Icon))
            //{
            //    file += ".icon";
            //}
            #endregion
            FileUtils.CreateFileByBytes(filePath, buffer);
            return filePath;
        }

        // 这是托盘用的相对路径方法
        //public static string buildpath(string date, string app_id)
        //{
        //    string imagePath = GlobalParams.devConfig.ImgDirFmt; // [dev]\[date]\[app_id]\
        //    string theDev = GlobalParams.devConfig.Devcode + "." + GlobalParams.devConfig.Devname;
        //    date = DateTime.Parse(date).ToString(Constant.DATE_FORMAT_SHORT);

        //    if (imagePath.Contains("[dev]"))
        //    {
        //        imagePath = imagePath.Replace("[dev]", theDev);
        //    }
        //    if (imagePath.Contains("[date]"))
        //    {
        //        imagePath = imagePath.Replace("[date]", date);
        //    }
        //    if (imagePath.Contains("[app_id]"))
        //    {
        //        if (!string.IsNullOrEmpty(app_id))
        //        {
        //            imagePath = imagePath.Replace("[app_id]", app_id);
        //        }
        //    }
        //    return imagePath;
        //}

    }
}
